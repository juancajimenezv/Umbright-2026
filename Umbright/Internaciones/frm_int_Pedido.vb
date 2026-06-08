Imports System.Text
Public Class frm_int_pedido
    Public ds_informacion_productos As DataSet
    Public columnasOcultas As String = String.Empty

    Dim nfrozen As Integer = 0

    Private Sub colorearGrid()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String

        Try

            ls_columnas_ocultar = String.Empty
            'If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
            ls_columnas_ocultar += ",existencia,cdx_cajas,empresa,marca,procedencia,diario_cajas,estatus,sugerido_proveedor,valor_sugerido,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,calculos,full,cajasxlayer,cajasxpallet,peso,volumen,peso_total,volumen_total,dua,fob,dai,iva,"
            ls_columnas_fijas = ",pedido=50,proveedor=70,min_cajas=50,max_cajas=50,sugerido=50,"

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("detalle_productos"), Me.dgv_detalle, "", ls_columnas_ocultar, "", "", "", ls_columnas_fijas, "", True, True, 250, 0)
            Dim font As New Font( _
                dgv_detalle.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)

            For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns
                dc.DefaultCellStyle.Font = font

                dc.ReadOnly = True
                If dc.Name.ToLower.StartsWith("cober") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    dc.Width = 50
                ElseIf dc.Name.ToLower.StartsWith("sugerido+") Then
                    'dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("ppto") Then
                    '  dc.Visible = False
                    dc.Width = 50
                    dc.DefaultCellStyle.Format = "n1"
                ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("trans") Or dc.Name.ToLower = "pedido" Then
                    dc.DefaultCellStyle.Format = "n0"
                    dc.Width = 50
                ElseIf dc.Name.StartsWith("cd_") Or dc.Name.StartsWith("da_") Or dc.Name.StartsWith("cdx_") Or dc.Name.StartsWith("internaci") Or dc.Name.ToLower = "uxc" Or dc.Name.ToLower = "pareto" Then
                    dc.Width = 35
                    dc.DefaultCellStyle.Format = "n1"
                End If

                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    If dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2) > 30 Then
                        dc.Visible = False
                    End If
                    dc.ToolTipText = Today.AddDays(1 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " " + Today.AddDays(1 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                    dc.Width = 50
                    dc.DefaultCellStyle.Format = "n1"
                    If dc.Name.ToLower.StartsWith("tran") Then dc.DefaultCellStyle.Format = "n0"
                    'DatePart(DateInterval.WeekOfYear, Today.AddDays(1 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString()
                ElseIf dc.Name.ToLower.StartsWith("trans") Then
                    dc.ToolTipText = Today.ToString("dd-MMM-yyyy")
                End If

                If dc.Name.ToLower.StartsWith("pedido") Or dc.Name.ToLower.StartsWith("agre") Then
                    dc.ReadOnly = False
                End If
                If dc.Name.ToLower.StartsWith("cobertura_pedido") Or dc.Name.ToLower.StartsWith("existencia_pedido") Then
                    dc.Width = 35
                    dc.DefaultCellStyle.Format = "n1"
                End If


            Next
            font = Nothing

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub aplicarFiltro()
        Dim lsfiltro As New StringBuilder
        lsfiltro.Append(String.Empty)


        If Me.chkVerTodos.CheckState = CheckState.Unchecked Then
            'lsfiltro.Append("((sugerido > 0 and da_cajas > 0) or (cd_cajas = 0 and da_cajas > 0) )")
            lsfiltro.Append("((sugerido > 0 and da_cajas > 0) or (sugerido < 1 and da_cajas > 0 and ppto_total < 1)) ")
        End If

        Try
            If Me.txt_texto.Text.Length > 0 Then
                'If Not cmbProveedor.SelectedItem.StartsWith("-") Then
                If lsfiltro.ToString.Length > 0 Then lsfiltro.Append(" and ")
                lsfiltro.Append(Me.cmb_campos.Text & " " & Me.cmb_operadores.Text & " '" & IIf(Me.cmb_operadores.Text.ToLower.Equals("like"), "%", "") & Me.txt_texto.Text & IIf(Me.cmb_operadores.Text.ToLower.Equals("like"), "%", "") & "'")
            End If
            'End If
        Catch ex As Exception
        End Try

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = lsfiltro.ToString

    End Sub

    'Private Sub AplicarProducto(ByVal psEmpresa As String, ByVal psProducto As String, ByVal pscolumnaCambio As String, ByVal ncantidad As Integer, ByVal clickAgregar As Boolean)
    '    Dim dr As DataRow
    '    Dim smes_actual As String
    '    Dim oCompras As New Compras.SCM(ds_informacion_productos)
    '    Dim dt As DataTable
    '    Dim ldporcentajeAjuste As Double = 0
    '    Dim dsugerido() As Double
    '    ReDim dsugerido(piSemanas)


    '    Try
    '        Me.Cursor = Cursors.WaitCursor


    '        'dt = ds_informacion_productos.Tables("calculo_original").Copy
    '        'dt.TableName = "copia"
    '        For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
    '            If dr.Item("producto").ToString.Equals(psProducto) And dr.Item("empresa").ToString.Equals(psEmpresa) Then
    '                ds_informacion_productos.Tables("calculo_original").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"


    '                For iaux As Integer = 0 To piSemanas - 1
    '                    smes_actual = "sugerido"
    '                    If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
    '                    dsugerido(iaux) = dr.Item(smes_actual)
    '                Next
    '                Dim lbagregar As Boolean = dr.Item("agregar")

    '                Dim ldpedido As Double = IIf(ncantidad = -99, dr.Item("pedido"), ncantidad)
    '                Dim itransito As Integer = 0
    '                ldporcentajeAjuste = dr.Item("porcentaje_ajuste")
    '                Dim ldLeadTime As Double = dr.Item("pv_lead_time_total")
    '                For Each dc As DataColumn In ds_informacion_productos.Tables("detalle_productos").Columns
    '                    dr.Item(dc.ColumnName) = ds_informacion_productos.Tables("calculo_original").DefaultView(0)(dc.ColumnName)
    '                Next

    '                dr.Item("porcentaje_ajuste") = ldporcentajeAjuste

    '                If pscolumnaCambio.Equals("porcentaje_ajuste") Then
    '                    '                  modificarPresupuestoProducto(dr.Item("empresa"), dr.Item("producto"), dr.Item("porcentaje_ajuste"))
    '                Else
    '                    If Not lbagregar Then
    '                        dr.Item("pedido") = 0
    '                    End If

    '                    Dim ileadtime As Integer = dr.Item("pv_lead_time_total")
    '                    dt = Me.transitoProductoSemana(dr.Item("empresa"), dr.Item("producto"), DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(ileadtime * 7)))
    '                    'pa_var_um_transito_productos_semana_producto()
    '                    Try
    '                        'If dt.Rows.Count > 0 Then
    '                        itransito = dt.Compute("cajas", "cajas>0")
    '                        'End If
    '                    Catch ex As Exception
    '                    End Try

    '                    smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
    '                    dr.Item(smes_actual) = itransito 'dr.Item(smes_actual) + dr.Item("pedido")



    '                    dr.Item("agregar") = lbagregar



    '                    If dr.Item("Agregar").ToString.ToLower = "true" Then
    '                        dr.Item("Agregar") = "True"
    '                        dr.Item("pedido") = IIf(clickAgregar, dr.Item("pedido"), ldpedido)
    '                        'Dim ileadtime As Integer = dr.Item("pv_lead_time_total")
    '                        If dr.Item("pedido") = 0 Then
    '                            For iaux As Integer = 0 To piSemanas - 1
    '                                smes_actual = "sugerido"
    '                                If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
    '                                If dr.Item(smes_actual) > 0 Then
    '                                    dr.Item("pedido") = dr.Item(smes_actual)
    '                                    Exit For

    '                                End If
    '                                'dr.Item(smes_actual) = dsugerido(iaux)
    '                            Next
    '                        End If

    '                        smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
    '                        dr.Item(smes_actual) = dr.Item(smes_actual) + dr.Item("pedido")

    '                    End If

    '                    dr.Item("valor_sugerido") = dr.Item("pedido") * dr.Item("fob")
    '                    dr.Item("peso_total") = dr.Item("pedido") * dr.Item("peso")
    '                    dr.Item("volumen_total") = dr.Item("pedido") * dr.Item("pedido")

    '                End If

    '                Exit For

    '            End If
    '        Next

    '        oCompras.Generar_SaldosyCoberturasProducto(psProducto)
    '        If pscolumnaCambio.Equals("porcentaje_ajuste") Or pscolumnaCambio.Equals("pv_lead_time_total") Then
    '            For iaux As Integer = 0 To piSemanas
    '                If pscolumnaCambio.Equals("porcentaje_ajuste") Then
    '                    oCompras.Minimos_MaximosProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
    '                End If
    '                oCompras.generarPedidoSugeridoProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
    '            Next
    '        End If

    '        Recargar_Resumen()
    '    Catch ex As Exception
    '    Finally
    '        oCompras = Nothing
    '        Me.Cursor = Cursors.Default
    '    End Try

    'End Sub

    Private Sub graficarSeleccion()

        Dim selectedCellCount As Integer = _
                            Me.dgv_detalle.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount > 0 Then



            Dim i, nrow As Integer
            Dim ncolumn As Integer = -1
            Dim coberturas, saldos As Double(,)

            Dim nombre_productos As String()
            Dim periodos As String()


            ReDim nombre_productos(selectedCellCount - 1)

            ReDim coberturas(7, 20)
            ReDim saldos(7, 20)


            ReDim periodos(20)



            If selectedCellCount > 6 Then
                MessageBox.Show("El Maximo Para Graficar es 6", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For i = 0 To selectedCellCount - 1

                nrow = dgv_detalle.SelectedCells(i).RowIndex

                nombre_productos(i) = dgv_detalle.Item("glosa", dgv_detalle.SelectedCells(i).RowIndex).Value.ToString
                saldos(7, 0) = Me.dgv_detalle.Item("pv_inv_maximo", nrow).Value.ToString
                saldos(6, 0) = Me.dgv_detalle.Item("pv_inv_reorden", nrow).Value.ToString
                coberturas(i, 0) = Math.Round(Double.Parse(dgv_detalle.Item("cobertura", nrow).Value.ToString), 0)
                periodos(0) = Today.ToString("dd-MMM-yyyy")
                saldos(i, 0) = Math.Round(Double.Parse(dgv_detalle.Item("Saldo", nrow).Value.ToString), 0)

                For icount As Integer = 1 To 20
                    coberturas(i, icount) = Math.Round(Double.Parse(Me.dgv_detalle.Item("cobertura+" + icount.ToString.PadLeft(2, "0"), nrow).Value.ToString), 0)
                    saldos(i, icount) = Math.Round(Double.Parse(Me.dgv_detalle.Item("saldo+" + icount.ToString.PadLeft(2, "0"), nrow).Value.ToString), 0)
                    periodos(icount) = Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).HeaderText.Replace("cobertura", "")
                    If icount Mod 4 = 0 Then
                        periodos(icount) = Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).ToolTipText
                    End If
                    saldos(6, icount) = Me.dgv_detalle.Item("pv_inv_reorden", nrow).Value.ToString
                    saldos(7, icount) = Me.dgv_detalle.Item("pv_inv_maximo", nrow).Value.ToString
                Next


            Next i


            Dim ileadtime As Integer = Me.dgv_detalle.Item("pv_lead_time_total", nrow).Value.ToString

            periodos(ileadtime) = "****" & periodos(ileadtime)


            Dim ocompras As New Compras.SCM

            Try
                ocompras.mostrarGrafica(selectedCellCount, coberturas, saldos, nombre_productos, periodos, "Cobertura Dias", "Existencias Cajas", 21)
            Catch ex As Exception
            Finally
                ocompras = Nothing
            End Try

        End If



    End Sub

    'Private Sub Calcular_Total()
    '    Dim dr As DataRow
    '    Dim itraslado As Integer
    '    Dim ldaiq, liva As Decimal

    '    Dim dtdaiq, dtiva As Decimal
    '    dtdaiq = 0
    '    dtiva = 0

    '    For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
    '        itraslado = dr.Item("traslado")
    '        itraslado = IIf(itraslado < 0, 0, itraslado) ' si es negativo es por que hay suficiente en el cd
    '        itraslado = IIf(dr.Item("da_cajas") < itraslado, dr.Item("da_cajas"), itraslado) ' valido que haya en el cd
    '        dr.Item("traslado") = itraslado
    '        If itraslado = 0 Then
    '            ldaiq = 0
    '            liva = 0
    '        Else
    '            ldaiq = (dr.Item("fob") * (dr.Item("dai") / 100)) * itraslado
    '            liva = (((dr.Item("fob") * itraslado)) + (dr.Item("fob") * (dr.Item("dai") / 100))) * 0.12
    '        End If

    '        dr.Item("daiV") = ldaiq
    '        dr.Item("iva") = liva
    '        If dr.Item("agregar") Then
    '            dtdaiq = dtdaiq + ldaiq
    '            dtiva = dtiva + liva
    '        End If
    '    Next
    '    Me.lbl_daiv.Text = dtdaiq
    '    Me.lbl_iva.Text = dtiva
    'End Sub

    Private Sub OcultarColumna(ByVal EsSemana As Boolean, ByVal nombre_campo As String)
        Dim icount As Integer
        'Dim saux As String = MenuItem.Text.Split("'")(1)
        'columnasOcultas += "," + MenuItem.Text.Split(" ")(1)
        If EsSemana Then
            For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                If dc.HeaderText.ToLower.IndexOf(" " & nombre_campo.ToLower) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                    icount += 1
                    dc.Visible = False
                    '        columnasOcultas = columnasOcultas.Replace("," & saux, "")
                End If
                If icount = 4 Then
                    Exit For
                End If
            Next
        Else
            Me.dgv_detalle.Columns(nombre_campo).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.dgv_detalle.Columns(nombre_campo).Visible = False


        End If




    End Sub

    Private Sub mostrarDerivados()
        Dim oform As New frm_resultado
        Dim clsGen As New ClasesGenerales.General

        Try
            oform.Text = "Productos Derivados de " + dgv_detalle.Item("producto", Me.dgv_detalle.CurrentRow.Index).Value + "--" + dgv_detalle.Item("glosa", dgv_detalle.CurrentRow.Index).Value


            ds_informacion_productos.Tables("derivados").DefaultView.RowFilter = "producto_padre = '" & dgv_detalle.Item("producto", dgv_detalle.CurrentRow.Index).Value & "'"
            oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("derivados")
            Dim lcolumnasmostrar As String = ",empresa,producto,glosa,unidades,existencia,"

            clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", ",existencia=existencia_unidades,", "", ",empresa,producto,glosa,unidades,", True, True, 250, 0)

            For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                If dc.Name.ToLower = "unidades" Then
                    dc.DefaultCellStyle.Format = "n4"
                End If
            Next
            With oform.dgv_resultado
                .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            End With
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing

        Catch ex As Exception
        Finally
            oform = Nothing
        End Try


    End Sub

    Private Sub mostrarPresupuesto()
        ''Tengo que levantar una forma en la que se muestre el presupuesto a futuro
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable
        Dim lssql As String

        Try
            Dim nrow As Integer = Me.dgv_detalle.CurrentRow.Index

            Otrans.open()
            lssql = "pa_sel_um_ppt_presupuesto_general '" & Me.dgv_detalle.Item("empresa", nrow).Value & "',null,'" & _
                                                    Me.dgv_detalle.Item("producto", nrow).Value & "'"

            dt = Otrans.Obtiene(lssql)
            dt.Columns.Add(New DataColumn("cajas", GetType(Double)))
            dt.DefaultView.RowFilter = "periodo >= '" & Today.ToString("yyyyMM") & "'"
            dt.DefaultView.Sort = "periodo"

            If dt.DefaultView.Count > 0 Then
                For Each drv As DataRowView In dt.DefaultView
                    drv.Item("cajas") = drv.Item("cantidad") / drv.Item("factoralt")
                Next
                Dim oform As New frm_resultado
                oform.Text = ":: Presupuesto Mensual ::"
                Dim clsGen As New ClasesGenerales.General

                Dim lcolumnasmostrar As String = ",periodo,producto,glosa,cajas,"

                oform.dgv_resultado.DataSource = dt.DefaultView
                clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", ",empresa,producto,glosa,periodo,cajas,", True, True, 250, 0)
                For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                    If dc.Name.ToLower = "cajas" Then
                        dc.DefaultCellStyle.Format = "n2"
                        dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If


                Next
                With oform.dgv_resultado
                    .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                End With
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing
                clsGen = Nothing
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        ds_informacion_productos = New DataSet

        Dim oform As New frm_int_prepara_informacion(ds_informacion_productos)
        oform.ShowDialog()
        Me.lblFechaIngreso.Text = "Fecha Ingreso " & oform.pdfechaIngreso.ToString("dd/MMM/yyyy")
        oform.Dispose()
        oform = Nothing

        Dim smes_actual As String
        Try
            'Me.dg_productos.DataSource = ds_informacion_productos.Tables("detalle_productos")
            ds_informacion_productos.Tables("detalle_productos").DefaultView.Sort = "sugerido desc"
            Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")

            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "producto = ''"
            For Each dr As DataRow In ds_informacion_productos.Tables("detalle_productos").Rows
                smes_actual = "cobertura+" & Integer.Parse(dr.Item("pv_lead_time_total")).ToString.PadLeft(2, "0")
                dr.Item("cobertura_pedido") = dr.Item(smes_actual)
                smes_actual = "saldo+" & Integer.Parse(dr.Item("pv_lead_time_total")).ToString.PadLeft(2, "0")
                dr.Item("existencia_pedido") = dr.Item(smes_actual)
            Next
        Catch ex As Exception
        End Try
        Me.dgvDuas.DataSource = ds_informacion_productos.Tables("detalle_dua").DefaultView
        colorearGrid()
        aplicarFiltro()

        'Colorear_Grid()
        'Posicionar_Producto()

    End Sub

    Private Sub btn_propuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_propuesta.Click

        If MessageBox.Show("Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            revisionRegistroSanitario()
            prepararPedido()
            guardarLog()
        End If
    End Sub

    Private Sub revisionRegistroSanitario()

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = "agregar = true"

        For Each drv As DataRowView In ds_informacion_productos.Tables("detalle_productos").DefaultView


            Try


                If drv.Item("numero_registro_sanitario").ToString.Trim.Length > 0 Then
                    If drv.Item("fecha_vencimiento_registro") <= Today Then
                        MessageBox.Show("El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " Tiene El Registro Sanitario Vencido y No se Procesara ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                        'guardarAvisoRegistro("Internaciones El Producto " & drv.Item("producto").ToString.Trim & drv.Item("Glosa").ToString.Trim & Chr(13) & " Tiene El Registro Sanitario Vencido")

                        guardarAvisoRegistro("El Producto " & drv.Item("producto").ToString.Trim & "-" & drv.Item("Glosa").ToString.Trim & Chr(13) & " Vence el " & drv.Item("fecha_vencimiento_registro"))

                        ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & drv.Item("producto") & "'"

                        For Each drv2 As DataRowView In ds_informacion_productos.Tables("detalle_dua").DefaultView
                            drv2.Item("asociar") = False
                            drv2.Item("cantidad_trasladar") = 0
                        Next

                    ElseIf drv.Item("fecha_vencimiento_registro") <= Today.AddDays(180) Then
                        guardarAvisoRegistro("El Producto " & drv.Item("producto").ToString.Trim & "-" & drv.Item("Glosa").ToString.Trim & Chr(13) & " Vence el " & drv.Item("fecha_vencimiento_registro"))

                    End If
                Else
                    If gs_empresa <> "DIMAEXSA" Then
                        If MessageBox.Show("El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " No Tiene  Registro Sanitario, Desea Procesara ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                            guardarAvisoRegistro("Internaciones El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " Tiene El Registro Sanitario Vencido")

                        Else
                            guardarAvisoRegistro("Internaciones El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " Tiene El Registro Sanitario Vencido")

                            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & drv.Item("producto") & "'"

                            For Each drv2 As DataRowView In ds_informacion_productos.Tables("detalle_dua").DefaultView
                                drv2.Item("asociar") = False
                                drv2.Item("cantidad_trasladar") = 0
                            Next

                        End If
                    End If


                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub prepararPedido()

        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim lbContinuar As Boolean = False

        Try

            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = ""
            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True and cantidad_trasladar < 1"

            If ds_informacion_productos.Tables("detalle_dua").DefaultView.Count > 0 Then
                For Each drv As DataRowView In ds_informacion_productos.Tables("detalle_dua").DefaultView
                    MessageBox.Show("El Producto " & drv.Item("glosa").ToString & " Tiene Cantidad Invalida", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Next
                ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = ""
                Exit Sub
            End If


            Dim Utrans As New Transaccional.Conexion("scm")

            Utrans.open()

            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True"

            ''Validacion Final
            For Each drv As DataRowView In ds_informacion_productos.Tables("detalle_dua").DefaultView
                dt = Utrans.Obtiene("pa_var_um_saldo_producto '" & gs_empresa & "', '" & drv.Item("dua").ToString & _
                        "', '" & drv.Item("producto") & "','" & drv.Item("lote") & "'")
                If dt.Rows(0)("bultos") < drv.Item("cantidad_trasladar") Then

                    MessageBox.Show("No se puede continuar con la grabación ya que el producto (" & drv.Item("producto") & ") " & _
                                    drv.Item("dua") & " execele el saldo que posee en la DUA. " & vbCrLf & _
                                    "Por favor revise los valores.")
                    Exit Sub
                End If

            Next
            '(c)06062014 Las FPA salen en una sola salida balvarez
            'ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True and dua not like '%FPA%'"
            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True"
            dt = ClsGen.ValoresDistinto(ds_informacion_productos.Tables("detalle_dua").DefaultView.ToTable, "dua".Split(","))
            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            For Each dr As DataRow In dt.Rows
                dr.Item("producto") = ""
            Next

            '(c)06062014 Las FPA salen en una sola salida balvarez
            'Dim dtFPA As DataTable
            'ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True and dua  like '%FPA%'"

            'dtFPA = ClsGen.ValoresDistinto(ds_informacion_productos.Tables("detalle_dua").DefaultView.ToTable, "dua,producto".Split(","))
            'For Each dr As DataRow In dtFPA.Rows
            '    Dim dr2 As DataRow
            '    dr2 = dt.NewRow
            '    dr2.Item("dua") = dr.Item("dua")
            '    dr2.Item("producto") = dr.Item("producto")
            '    dt.Rows.Add(dr2)
            'Next

            'dt.DefaultView.RowFilter = "dua like '%FPA%'"
            'If dt.DefaultView.Count > 0 Then

            '    ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True and dua like '%FPA%'"
            '    For Each drv As DataRowView In ds_informacion_productos.Tables("detalle_dua").DefaultView

            '        dt.DefaultView.RowFilter = "dua = '" & drv.Item("dua") & "' and producto = '" & drv.Item("producto") & "'"

            '        If dt.DefaultView.Count > 0 Then
            '            dt.DefaultView(0).Item("producto") = drv.Item("producto")
            '        Else
            '            Dim dr As DataRow
            '            dr = dt.NewRow
            '            dr.Item("dua") = drv.Item("dua")
            '            dr.Item("producto") = drv.Item("producto")
            '            dt.Rows.Add(dr)
            '        End If

            '    Next
            'End If
            dt.DefaultView.RowFilter = ""



            If dt.Rows.Count > 1 Then
                If MessageBox.Show("Se Generaran " & dt.Rows.Count & " DI, Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    lbContinuar = True
                End If
            ElseIf dt.Rows.Count = 1 Then
                lbContinuar = True
            End If



        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

        If lbContinuar Then
            guardarPedido(dt)
        End If
    End Sub


    Private Sub guardarPedido(ByVal dtDuas As DataTable)
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim drv, drv_aux As DataRowView
        Dim ldaiq, liva, lfob As Double
        Dim ltotal_daiq, ltotal_iva As Double
        Dim inumero As Integer = 0
        ldaiq = 0
        liva = 0
        lfob = 0
        ltotal_daiq = 0
        ltotal_iva = 0
        Dim fFechaIngreso As DateTime


        Try
            Dim umOtrans As New Transaccional.Conexion("Umbral")
            umOtrans.open()
            dt = umOtrans.Obtiene("pa_var_um_calendario_habil '" & gs_empresa & "','" & Today.ToString("dd/MM/yyyy") & "'")
            umOtrans.close()
            umOtrans = Nothing

            dt.DefaultView.RowFilter = "fecha >= '" & Today & "'"
            dt.DefaultView.Sort = "fecha"
            fFechaIngreso = dt.DefaultView(ds_informacion_productos.Tables("parametros").Rows(0).Item("lead_time") - 1).Item("fecha")
        Catch ex As Exception
        End Try


        Try
            oTrans.open()

            For Each dr As DataRow In dtDuas.Rows

                ls_sql = "pa_ins_um_int_pedido_encabezado '" & gs_empresa & "','" & "" & "','" & gs_usuario & "'," & _
                             "0,0" & ",'" & fFechaIngreso.ToString("dd/MM/yyyy") & "'"
                oTrans.Ingresa(ls_sql)

                If oTrans.Codigo_error = 0 Then
                    dt = oTrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    inumero = dt.Rows(0).Item("newid").ToString
                    ltotal_daiq = 0
                    ltotal_iva = 0
                End If



                If inumero > 0 Then

                    'Inicializo los estados
                    ls_sql = "pa_ins_um_int_pedido_estado_real " & inumero.ToString & ",1,'" & gs_usuario & "',''"
                    oTrans.Ingresa(ls_sql)

                    ldaiq = 0
                    liva = 0
                    lfob = 0

                    ls_sql = "asociar = True and dua = '" & dr.Item("dua") & "'"
                    If dr.Item("producto").ToString.Trim.Length > 0 Then
                        ls_sql += " and producto = '" & dr.Item("producto") & "'"
                    End If
                    ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = ls_sql

                    Dim sproducto As String = ""
                    Dim slote As String = ""
                    'Agregar Asociaciones con Duas
                    If ds_informacion_productos.Tables("detalle_dua").DefaultView.Count > 0 Then


                        Dim ldcantidad As Double = 0
                        liva = 0
                        ldaiq = 0

                        For Each drv_aux In ds_informacion_productos.Tables("detalle_dua").DefaultView

                            If drv_aux.Item("cantidad_trasladar") > 0 Then


                                ls_sql = "pa_ins_um_int_pedido_detalle_dua " & inumero.ToString & ",'" & drv_aux.Item("producto") & "','" & _
                                         drv_aux.Item("dua") & "'," & drv_aux.Item("cantidad_trasladar") & ",'" & _
                                         drv_aux.Item("lote") & "','" & drv_aux.Item("fecha_vencimiento_producto") & "'"
                                oTrans.Ingresa(ls_sql)

                                liva += drv_aux("iva")
                                ldaiq += drv_aux("dai")
                                ldcantidad += drv_aux("cantidad_trasladar")

                                ltotal_daiq += ldaiq
                                ltotal_iva += liva

                                If sproducto <> drv_aux.Item("producto") Or slote <> drv_aux.Item("lote") Then
                                    sproducto = drv_aux.Item("producto")
                                    slote = drv_aux.Item("lote")
                                    ls_sql = "pa_ins_um_int_pedido_detalle " & inumero.ToString & ",'" & sproducto & "'," & ldcantidad & _
                                                                        "," & ldaiq & "," & liva
                                    oTrans.Ingresa(ls_sql)
                                End If
                                liva = 0
                                ldaiq = 0
                                ldcantidad = 0
                            End If
                        Next

                        sproducto = ds_informacion_productos.Tables("detalle_dua").DefaultView(0).Item("producto")
                    End If
                    ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & sproducto & "'"

                    ls_sql = "pa_upd_um_int_pedido_encabezado " & inumero.ToString & ",'" & _
                            ds_informacion_productos.Tables("detalle_productos").DefaultView(0)("proveedor").ToString & _
                            "'," & ltotal_daiq.ToString & "," & ltotal_iva
                    oTrans.Actualiza(ls_sql)

                    ls_sql = "pa_ins_um_int_pedido_estado_real " & inumero.ToString & ",2,'" & gs_usuario & "',''"
                    oTrans.Ingresa(ls_sql)

                    guardarAviso(inumero, ds_informacion_productos.Tables("detalle_productos").DefaultView(0)("proveedor").ToString)
                End If
            Next

            Me.Close() ''Cierra El Formulario al Terminar de guardar
        Catch ex As Exception
            MessageBox.Show("Problemas al Guardar el Pedido " & ex.ToString, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub guardarAviso(ByVal inumero As Integer, ByVal snombre As String)
        'Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt, dtCorreo As DataTable
        Dim sNombreReporte As String
        Dim sCuentas As String = ""

        Try
            sNombreReporte = "detalle_pedido_internaciones_individual"
            sNombreReporte = exportar_reporte(sNombreReporte, False, gs_empresa, inumero)

            'myOtrans.open()
            'lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (10)" '1= Ingreso de Dua OC
            'dt = myOtrans.Obtiene(lsSQL)

            dt = clsGen.selectQuery("Corporativo", "pa_sel_um_seg_usuario_aviso_sistema 10")
            For Each dr As DataRow In dt.Rows

                'clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Nueva Solicitud No " &
                '                      inumero & "  " &
                '                      snombre, 10)
                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & dr.Item("usuario").ToString & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If

            Next

            If sCuentas.Length > 0 Then
                clsGen.enviarcorreo("notificacion@umbralcorp.com", "Notificaciones Umbral", sCuentas, "Nueva Internacion " & gs_empresa & "-" & inumero, "Se Genero Una Nueva Internacion", sNombreReporte, "")
            End If


        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            clsGen = Nothing
        End Try


    End Sub


    Private Function exportar_reporte(ByVal psNombreReporte As String, ByVal pbVisualizar As Boolean, psEmpresa As String, psNumero As String) As String
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim lsArchivoGenerado As String = Environment.GetEnvironmentVariable("TEMP") & "\internacion_" & psEmpresa & "_" & psNumero & ".pdf"

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = lsArchivoGenerado

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Compras e Importaciones\da\" & psNombreReporte & ".rpt"
            pm_parametros(0) = "@Pcod_pedido"
            pm_parametros(1) = "@Pempresa"
            pm_valores(0) = psNumero
            pm_valores(1) = psEmpresa


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", Not pbVisualizar, False, "PDF", pbVisualizar)

        Catch ex As Exception
            clsgen.Escribir_Log(ex.ToString)
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try

        Return lsArchivoGenerado
    End Function


    Private Sub guardarAvisoRegistro(ByVal smensaje As String)
        'Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable

        Try

            'myOtrans.open()

            clsGen.enviarcorreo_html("registros_sanitarios@logiservicios.com", "Registros Sanitarios - Internaciones", smensaje, "", "", "notificacion@umbralcorp.com", "Notificaciones Umbral")
            lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null,'mlo_avisos_registros_sanitarios'" '17= Registros Sanitarios
            dt = clsGen.selectQuery("FlexLine", lsSQL)


            'dt = myOtrans.Obtiene(lsSQL)
            'For Each dr As DataRow In dt.Rows

            '    clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", smensaje, 17)


            'Next


            clsGen.enviarMensajeTeams("analises.perez@logiservicios.com", "Registro Sanitario", smensaje & "|" & clsGen.Fecha_Servidor("FlexLine").Rows(0).Item(0))


            'lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(17)" '17= Registros Sanitarios
            'dt = myOtrans.Obtiene(lsSQL)



            'For Each dr3 As DataRow In dt3.Rows

            '    guardarAviso = False
            '    Dim lsMensaje As String
            '    lsMensaje = "El Producto " & dr3.Item("producto").ToString.Trim & "-" & dr3.Item("glosa").ToString.Trim

            '    If dr3.Item("registro").ToString.Length = 0 Then
            '        guardarAviso = True
            '        lsMensaje += " No tiene Registro Sanitario, Ingreso en la Dua " & Me.txt_numero.Text
            '    Else
            '        If dr3.Item("Fecha_vencimiento").ToString.Length = 0 Then
            '            guardarAviso = True
            '            lsMensaje += " No tiene Fecha de Vencimiento, Ingreso en la Dua " & Me.txt_numero.Text
            '        Else
            '            Try
            '                If CDate(dr3.Item("Fecha_vencimiento")).Date < Today() Then
            '                    guardarAviso = True
            '                    lsMensaje += " El Registro Ya Vencio, Ingreso en la Dua " & Me.txt_numero.Text
            '                ElseIf CDate(dr3.Item("Fecha_vencimiento")).Date < Today().AddMonths(3) Then
            '                    guardarAviso = True
            '                    lsMensaje += " El Registro Esta Por Vencer, Ingreso en la Dua " & Me.txt_numero.Text
            '                End If
            '            Catch ex As Exception
            '                guardarAviso = True
            '                lsMensaje += " Problemas con la Fecha, Ingreso en la Dua " & Me.txt_numero.Text

            '            End Try

            '        End If
            '    End If


            '    If guardarAviso() Then

            '        For Each dr As DataRow In dt.Rows
            '            If dr.Item("validar_marca").ToString = "1" Then
            '                dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
            '                If dt2.DefaultView.Count > 0 Then guardarAviso = True

            '            ElseIf dr.Item("validar_empresa").ToString = "1" Then

            '                dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
            '                If dtUsuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True
            '            End If


            '            If guardarAviso() Then

            '                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", lsMensaje, 17)
            '                guardarAviso = False
            '            End If
            '        Next
            '    End If

            'Next
            'End If

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            clsGen = Nothing
        End Try


    End Sub

    Private Sub guardarLog()
        Dim clsGen As New ClasesGenerales.General
        Dim sNombre As String = gs_empresa + "_" + Now.ToString("ddMMyyyyHHmm") + "_" + gs_usuario

        Try
            ds_informacion_productos.WriteXml("\\" & clsGen.Obtener_XMLConfig("Servidor_Alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\internaciones$\" & sNombre.Trim & ".xml", XmlWriteMode.WriteSchema)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try


    End Sub

    Private Sub mostrarDua()
        Try
            Dim nrow As Integer
            Dim lsProducto As String
            nrow = Me.dgv_detalle.CurrentCell.RowIndex

            'Detalle_Productos(nrow)
            lsProducto = Me.dgv_detalle.Item("producto", nrow).Value.ToString
            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & lsProducto & "'"
            ds_informacion_productos.Tables("detalle_dua").DefaultView.Sort = "fecha_vencimiento_dua"


            Dim clsgen As New ClasesGenerales.General
            'clsgen.Alinea_Grid(ds_asociacion.Tables("detalle_dua"), Me.dg_producto_dua, ds_asociacion.Tables("detalle_dua").TableName, -1, 250, 0, True, True, "", True, "")
            clsgen.Alinear_GridView(ds_informacion_productos.Tables("detalle_dua").DefaultView.ToTable, Me.dgvDuas, _
                    "", ",empresa,fecha,fobunitario,daiunitario,producto,glosa,", ",producto,glosa,dua,fecha,saldo_cajas,saldo_unidades,fecha_vencimiento_dua,fecha_vencimiento_producto,observaciones,fob,dai,iva,fob_unitario,dai_unitario", "", _
                    ",cantidad_trasladar=cantidad,saldo_cajas=cajas,saldo_unidades=unidades,fecha_vencimiento_dua=venc_dua,fecha_vencimiento_producto=venc_producto,", ",asociar=30,saldo_unidades=40,saldo_cajas=40,cantidad_trasladar=40,fecha_vencimiento_producto=70,fecha_vencimiento_dua=70,", "", True, True, 130, 0)

            clsgen = Nothing
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub dgv_detalle_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_detalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)

                If Me.dgv_detalle.Item("agregar", rowIndex).Value = True Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                ElseIf Me.dgv_detalle.Item("sugerido", rowIndex).Value > 0 And dgv_detalle.Item("pedido", rowIndex).Value = 0 Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                ElseIf Me.dgv_detalle.Item("bloqueado_internacion", rowIndex).Value = 1 Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightSalmon
                ElseIf Me.dgv_detalle.Item("bloqueado_internacion", rowIndex).Value = 2 Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightCoral  'Bloqueado por Registro Sanitario
                ElseIf Me.dgv_detalle.Item("bloqueado_internacion", rowIndex).Value = 3 Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightYellow 'Producto Proximo a Vencer
                    'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.White
                    'Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.White
                Else
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If

                If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("transi") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                    Else
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.White
                    End If
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Me.ContextMenuStrip1.Items.Clear()
        Try
            Me.ContextMenuStrip1.Items.Add("Inmovilizar Paneles '" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Movilizar Paneles ", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Graficar", Nothing, AddressOf ToolStripMenuItem_Click)
            'If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.ToLower.StartsWith("glosa") Then
            Dim nrow As Integer = Me.dgv_detalle.CurrentRow.Index
            If Me.dgv_detalle.Item("glosa", nrow).Value.ToString.StartsWith("**") Then
                Me.ContextMenuStrip1.Items.Add("Ver Derivados ", Nothing, AddressOf ToolStripMenuItem_Click)
            End If
            If columnasOcultas.Length > 0 Then
                For Each saux As String In columnasOcultas.Split(",")
                    If saux.Length > 0 Then
                        Me.ContextMenuStrip1.Items.Add("Mostrar Columna '" & saux & "'", Nothing, AddressOf ToolStripMenuItem_Click)
                    End If
                Next
            End If
            Me.ContextMenuStrip1.Items.Add("Ver Ventas", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Ver Presupuesto", Nothing, AddressOf ToolStripMenuItem_Click)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        Try
            If menuItem IsNot Nothing Then
                'Tell the user which menu item they just clicked.

                If menuItem.Text.ToLower.StartsWith("ocultar co") Then
                    columnasOcultas += "," + Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Visible = False
                ElseIf menuItem.Text.ToLower.StartsWith("ocultar sem") Then
                    Dim saux As String = menuItem.Text.Split("'")(1)
                    columnasOcultas += "," + menuItem.Text.Split(" ")(1)

                    Me.OcultarColumna(True, saux)
                ElseIf menuItem.Text.ToLower.StartsWith("inmovi") Then
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Frozen = True
                    nfrozen = Me.dgv_detalle.CurrentCell.ColumnIndex

                ElseIf menuItem.Text.ToLower.StartsWith("mostrar") Then
                    Dim saux As String = menuItem.Text.Split("'")(1)
                    If saux.ToLower.StartsWith("semana") Then

                        For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                            If dc.HeaderText.LastIndexOf(menuItem.Text.Split("'")(2)) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                                dc.Visible = True
                                columnasOcultas = columnasOcultas.Replace("," & "Semana'" & menuItem.Text.Split("'")(2) & "'", "")
                            End If
                        Next
                    Else


                        For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                            If dc.Name.ToLower = saux.ToLower Then
                                dc.Visible = True
                                columnasOcultas = columnasOcultas.Replace("," & saux, "")
                            End If
                        Next
                    End If

                ElseIf menuItem.Text.ToLower.StartsWith("ver d") Then
                    mostrarDerivados()
                ElseIf menuItem.Text.ToLower.StartsWith("ver p") Then
                    mostrarPresupuesto()
                ElseIf menuItem.Text.ToLower.StartsWith("ver v") Then
                    Me.generarVentas()
                ElseIf menuItem.Text.ToLower.StartsWith("grafi") Then
                    graficarSeleccion()
                Else

                    For iaux As Integer = 1 To nfrozen
                        Me.dgv_detalle.Columns(iaux).Frozen = False
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkVerTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVerTodos.CheckedChanged
        aplicarFiltro()
    End Sub

    Private Sub txt_texto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_texto.KeyPress
        If e.KeyChar = Chr(13) Then aplicarFiltro()
    End Sub

    Private Sub dgv_detalle_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_detalle.MouseClick
        mostrarDua()
        hacerResumen()
    End Sub

    Private Sub dgvDuas_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvDuas.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDuas.Rows(rowIndex)

                If Me.dgvDuas.Item("fecha_vencimiento_dua", rowIndex).Value < Today Then
                    Me.dgvDuas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvDuas_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDuas.CellValueChanged

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDuas.Rows(rowIndex)
                If (",asociar,cantidad_trasladar,").IndexOf(Me.dgvDuas.Columns(colIndex).Name.ToLower) > -1 Then
                    Dim ncantidad As Integer = -99
                    Dim clickasociar As Boolean = Me.dgvDuas.Columns(colIndex).Name.ToLower.Equals("asociar")
                    'Me.dgv_detalle.Item("valor_sugerido", rowIndex).Value = Me.dgv_detalle.Item("pedido", rowIndex).Value * Me.dgv_detalle.Item("fob", rowIndex).Value

                    If Me.dgvDuas.Columns(colIndex).Name.ToLower.Equals("asociar") Then
                        If Me.dgvDuas.Item(colIndex, rowIndex).Value = True Then
                            Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, Me.dgv_detalle.Item("pedido", Me.dgv_detalle.CurrentRow.Index).Value, True, Me.dgvDuas.Item("lote", rowIndex).Value)
                        Else
                            Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, 0, False, Me.dgvDuas.Item("lote", rowIndex).Value)
                        End If
                    End If
                    If Me.dgvDuas.Columns(colIndex).Name.ToLower.Equals("cantidad_trasladar") Then
                        If Me.dgvDuas.Item("cantidad_trasladar", rowIndex).Value > Me.dgvDuas.Item("saldo_cajas", rowIndex).Value Then

                            Me.dgvDuas.Item("cantidad_trasladar", rowIndex).Value = Me.dgvDuas.Item("saldo_cajas", rowIndex).Value
                            If Me.dgvDuas.Item("asociar", rowIndex).Value = True Then
                                Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, Me.dgv_detalle.Item("pedido", Me.dgv_detalle.CurrentRow.Index).Value, True, Me.dgv_detalle.Item("Lote", Me.dgv_detalle.CurrentRow.Index).Value)
                            End If
                        End If

                    End If
                    hacerResumen()
                    '                    dg_producto_dua.CurrentCell = dg_producto_dua.Item(colIndex, rowIndex)
                End If
            End If


        Catch ex As Exception
        End Try

    End Sub

    Private Sub aplicar_producto(ByVal sproducto As String, ByVal sdua As String, ByVal icantidad As Integer, ByVal bagregar As Boolean, ByVal slote As String)


        For Each dr As DataRow In ds_informacion_productos.Tables("detalle_dua").Rows
            If dr.Item("producto").ToString = sproducto And dr.Item("dua").ToString = sdua And dr.Item("Lote").ToString = slote Then
                dr.Item("asociar") = bagregar
                If dr.Item("saldo_cajas") < icantidad Then icantidad = dr.Item("saldo_cajas")


                dr.Item("cantidad_trasladar") = icantidad
                Dim lfob As Double = Val(dr.Item("fobunitario").ToString)

                Dim ldaiq As Double = 0
                Dim liva As Double = 0

                Try
                    dr.Item("fob") = lfob * dr.Item("cantidad_trasladar")
                    'ldaiq = (lfob * (.Item("dai") / 100)) * drv2.Item("cantidad_trasladar")
                    ldaiq = dr.Item("daiunitario") * dr.Item("cantidad_trasladar")
                Catch ex As Exception
                End Try
                dr.Item("dai") = ldaiq

                Try
                    liva = (((lfob * dr.Item("cantidad_trasladar"))) + (dr.Item("daiunitario") * dr.Item("cantidad_trasladar"))) * 0.12
                Catch ex As Exception
                    liva = 0
                End Try
                dr.Item("iva") = liva
                Exit For

            End If
        Next

        Dim icantidadProcesar As Integer = icantidad

        For Each dr As DataRow In ds_informacion_productos.Tables("detalle_dua").Rows
            If dr.Item("producto").ToString = sproducto And dr.Item("asociar") = True And dr.Item("dua").ToString = sdua And dr.Item("Lote").ToString = slote Then
                If icantidadProcesar >= dr.Item("saldo_cajas") Then
                    icantidadProcesar = icantidadProcesar - dr.Item("saldo_cajas")
                    dr.Item("cantidad_trasladar") = dr.Item("saldo_cajas")
                ElseIf icantidad > 0 And icantidad < dr.Item("saldo_cajas") Then
                    dr.Item("cantidad_trasladar") = icantidadProcesar
                    icantidadProcesar = 0
                Else
                    dr.Item("cantidad_trasladar") = 0
                End If

                If dr.Item("cantidad_trasladar") > 0 Then

                    Dim lfob As Double = Val(dr.Item("fobunitario").ToString)
                    Dim ldaiq As Double = 0
                    Dim liva As Double = 0

                    Try
                        dr.Item("fob") = lfob * dr.Item("cantidad_trasladar")
                        ldaiq = dr.Item("daiunitario") * dr.Item("cantidad_trasladar")
                    Catch ex As Exception
                    End Try
                    dr.Item("dai") = ldaiq
                    Try
                        liva = (((lfob * dr.Item("cantidad_trasladar"))) + (dr.Item("daiunitario") * dr.Item("cantidad_trasladar"))) * 0.12
                    Catch ex As Exception
                        liva = 0
                    End Try
                    dr.Item("iva") = liva
                End If

            End If
        Next



    End Sub

    Private Sub hacerResumen()
        Dim lfob, ldaiq, liva As Double
        Dim lsSQL As String
        Dim dt, pdt As DataTable
        Dim clsGen As New ClasesGenerales.General


        lfob = 0
        ldaiq = 0
        liva = 0
        dt = ds_informacion_productos.Tables("detalle_dua").Copy

        ds_informacion_productos.Tables("detalle_seleccion").Rows.Clear()
        dt.DefaultView.RowFilter = "asociar = true"

        For Each drv As DataRowView In dt.DefaultView
            ds_informacion_productos.Tables("detalle_seleccion").DefaultView.RowFilter = "producto = '" & drv.Item("producto").ToString & "' and dua = '" & drv.Item("dua") & "' and lote = '" & drv.Item("lote") & "'"

            If ds_informacion_productos.Tables("detalle_seleccion").DefaultView.Count = 0 Then
                If drv.Item("cantidad_trasladar") > 0 Then
                    Dim dr As DataRow = ds_informacion_productos.Tables("detalle_seleccion").NewRow
                    dr.Item("producto") = drv.Item("producto")
                    dr.Item("glosa") = drv.Item("glosa")
                    dr.Item("dua") = drv.Item("dua")
                    dr.Item("cantidad") = drv.Item("cantidad_trasladar")
                    dr.Item("lote") = drv.Item("lote")
                    ds_informacion_productos.Tables("detalle_seleccion").Rows.Add(dr)
                End If
            End If

        Next




        Try
            ds_informacion_productos.Tables("detalle_seleccion").DefaultView.RowFilter = ""
            Me.dgvProductosAsociados.DataSource = ds_informacion_productos.Tables("detalle_seleccion")
            clsGen.Alinear_GridView(ds_informacion_productos.Tables("detalle_seleccion"), Me.dgvProductosAsociados, "", ",producto,", "", "", "", "", "", True, True, 150, 0)
            clsGen = Nothing

        Catch ex As Exception
        End Try

    End Sub




    Private Sub ProductosEnDuaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosEnDuaToolStripMenuItem.Click


        Try

            Dim dt As DataTable
            dt = ds_informacion_productos.Tables("detalle_dua").Copy


            'MessageBox.Show(Me.dgvDuas.Item("dua", Me.dgvDuas.CurrentCell.RowIndex).Value)

            dt.DefaultView.RowFilter = "Dua = '" & Me.dgvDuas.Item("dua", Me.dgvDuas.CurrentCell.RowIndex).Value & "'"


            Dim clsGen As New ClasesGenerales.General
            Dim oform As New frm_resultado
            oform.dgv_resultado.DataSource = dt.DefaultView.ToTable
            oform.Text = "Productos en Dua " & Me.dgvDuas.Item("dua", Me.dgvDuas.CurrentCell.RowIndex).Value.ToString.Trim & _
                        " Fecha Vencimiento Dua " & Me.dgvDuas.Item("fecha_vencimiento_dua", Me.dgvDuas.CurrentCell.RowIndex).Value
            clsGen.Alinear_GridView(dt.DefaultView.ToTable, oform.dgv_resultado, ",producto,glosa,saldo_cajas,saldo_unidades,fecha_vencimiento,fecha_vencimiento_producto,observaciones,cantidad_trasladar,", _
                            "", "", "", ",cantidad_trasladar=pedido (Cajas),", "", "producto,glosa,saldo_cajas,saldo_unidades,fecha_vencimiento,fecha_vencimiento_producto,observaciones,cantidad_trasladar,", True, True, 250, 0)
            oform.ShowDialog()
            oform = Nothing
            clsGen = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_detalle_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellValueChanged

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)
                If (",pedido,").IndexOf(Me.dgv_detalle.Columns(colIndex).Name.ToLower) > -1 Then
                    If Me.dgv_detalle.Item("pedido", rowIndex).Value > Me.dgv_detalle.Item("da_cajas", rowIndex).Value Then
                        Try
                            If Me.dgv_detalle.Item("da_cajas", rowIndex).Value > 0 Then
                                'Genera Conflictos 121212 (c)
                                '                                Me.dgv_detalle.Item("pedido", rowIndex).Value = Me.dgv_detalle.Item("da_cajas", rowIndex).Value
                            End If
                        Catch ex As Exception
                        End Try

                    End If

                End If
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub dgvDuas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDuas.CellContentClick

    End Sub

    Private Sub generarVentas()

        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim therow As DataGridViewRow

        Try


            therow = Me.dgv_detalle.CurrentRow
            oCompras.Empresa = dgv_detalle.Item("empresa", therow.Index).Value
            oCompras.mostrarVentas(dgv_detalle.Item("producto", therow.Index).Value, _
                                    dgv_detalle.Item("glosa", therow.Index).Value, True)


        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try


    End Sub

    Private Sub generarVentaPerdida()

    End Sub

    Private Sub frm_int_pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MostrarVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarVentasToolStripMenuItem.Click
        generarVentas()
    End Sub

    Private Sub cMenuProductoDuas_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cMenuProductoDuas.Opening

    End Sub

    Private Sub FiltrarProductosDeDuaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltrarProductosDeDuaToolStripMenuItem.Click

        Try
            Dim dt As DataTable
            Dim lsfiltro As String
            dt = ds_informacion_productos.Tables("detalle_dua").Copy
            dt.DefaultView.RowFilter = "Dua = '" & Me.dgvDuas.Item("dua", Me.dgvDuas.CurrentCell.RowIndex).Value & "'"

            lsfiltro = "producto in ("
            For Each drv As DataRowView In dt.DefaultView
                'If lsfiltro.Empty Then lsfiltro = "producto in ("


                lsfiltro += "'" + drv.Item("producto").ToString + "',"
            Next
            lsfiltro += ")"
            ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = lsfiltro
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_texto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_texto.TextChanged

    End Sub

    'Private Sub MostrarMovimientoDuaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarMovimientoDuaToolStripMenuItem.Click
    '    Dim oTrans As New Transaccional.Conexion("FlexLine")

    '    Dim lsSQL As String
    '    Dim dt As DataTable

    '    Try
    '        oTrans.open()


    '        lsSQL = "pa_var_um_saldo_producto '" + gs_empresa + "','" + Me.dgvDuas.Item("dua", Me.dgvDuas.CurrentCell.RowIndex).Value & "','" & _
    '            Me.dgvDuas.Item("producto", Me.dgvDuas.CurrentCell.RowIndex).Value & "','" & _
    '            Me.dgvDuas.Item("lote", Me.dgvDuas.CurrentCell.RowIndex).Value & "'"


    '        dt = oTrans.Obtiene(lsSQL)


    '        Dim clsGen As New ClasesGenerales.General
    '        Dim oform As New frm_resultado
    '        oform.dgv_resultado.DataSource = dt.DefaultView.ToTable
    '        oform.Text = "Saldos En Productos en Dua " & Me.dgvDuas.Item("dua", Me.dgvDuas.CurrentCell.RowIndex).Value.ToString.Trim
    '        '" Fecha Vencimiento Dua " & Me.dgvDuas.Item("fecha_vencimiento_dua", Me.dgvDuas.CurrentCell.RowIndex).Value
    '        'clsGen.Alinear_GridView(dt.DefaultView.ToTable, oform.dgv_resultado, ",producto,glosa,saldo_cajas,saldo_unidades,fecha_vencimiento,fecha_vencimiento_producto,observaciones,cantidad_trasladar,", _
    '        '                "", "", "", ",cantidad_trasladar=pedido (Cajas),", "", "producto,glosa,saldo_cajas,saldo_unidades,fecha_vencimiento,fecha_vencimiento_producto,observaciones,cantidad_trasladar,", True, True, 250, 0)
    '        oform.ShowDialog()
    '        oform = Nothing
    '        clsGen = Nothing



    '    Catch ex As Exception
    '    Finally
    '        oTrans.close()
    '        oTrans = Nothing
    '    End Try

    'End Sub
    Private Sub MostrarMovimientoDuaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarMovimientoDuaToolStripMenuItem.Click

        Dim clsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable

        Dim ilCell As Integer = Me.dgvDuas.CurrentCell.RowIndex




        Try
            otrans.open()

            lsSQL = "pa_var_um_detalle_movimiento_producto '" & gs_empresa & "','" & Me.dgvDuas.Item("dua", ilCell).Value.ToString.Trim _
                    & "','" & Me.dgvDuas.Item("producto", ilCell).Value & "','" & Me.dgvDuas.Item("lote", ilCell).Value.ToString.Trim & "'"

            dt = otrans.Obtiene(lsSQL)

            '            MessageBox.Show(lsSQL)

            Dim oform As New frm_resultado
            oform.dgv_resultado.DataSource = dt
            oform.Text = "Saldos En Productos en Dua " & Me.dgvDuas.Item("dua", Me.dgvDuas.CurrentCell.RowIndex).Value.ToString.Trim & _
                    " Producto " & Me.dgvDuas.Item("producto", Me.dgvDuas.CurrentCell.RowIndex).Value
            clsGen.Alinear_GridView(dt.DefaultView.ToTable, oform.dgv_resultado, "", _
                            "", "", "", "", "", "", True, True, 250, 0)
            oform.ShowDialog()
            oform = Nothing
            'clsGen = Nothing

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim snumero As String = InputBox("Ingrese Numero", "Reenviar Pedido")
        guardarAviso(snumero, "")
    End Sub
End Class