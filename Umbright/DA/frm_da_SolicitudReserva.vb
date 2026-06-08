Imports System.Text
Public Class frm_da_SolicitudReserva
    Public ds_informacion_productos As DataSet
    Public columnasOcultas As String = String.Empty

    Dim nfrozen As Integer = 0
    Dim pdiaActual As Integer = DatePart(DateInterval.DayOfYear, Today)
    Private Sub colorearGrid()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String

        Try

            ls_columnas_ocultar = String.Empty
            'If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
            ls_columnas_ocultar += ",pv_inv_maximo,pv_lead_time_total,bloqueado_internacion,saldo,cobertura,pareto,valida_registro,pv_inv_reorden,pv_inv_seguridad,transito,sugerido,min_cajas,max_cajas,,existencia,cdx_cajas,empresa,marca,procedencia,diario_cajas,estatus,sugerido_proveedor,valor_sugerido,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,calculos,full,cajasxlayer,cajasxpallet,peso,volumen,peso_total,volumen_total,dua,fob,dai,iva,"
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
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("ppto") Then
                    dc.Visible = True
                    dc.Width = 50
                    dc.DefaultCellStyle.Format = "n1"
                ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("trans") Or dc.Name.ToLower = "pedido" Then
                    dc.DefaultCellStyle.Format = "n0"
                    dc.Width = 50
                ElseIf dc.Name.StartsWith("cd_") Or dc.Name.StartsWith("da_") Or dc.Name.StartsWith("cdx_") Or dc.Name.StartsWith("internaci") Or dc.Name.ToLower = "uxc" Or dc.Name.ToLower = "pareto" Then
                    dc.Width = 60
                    dc.DefaultCellStyle.Format = "n0"
                End If

                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    dc.Visible = False
                    If gs_empresa.ToLower.Equals("divinos") Then
                        'dc.Visible = True
                        If dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2) > 30 Then dc.Visible = False

                        dc.ToolTipText = Today.AddDays(1 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                        dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " " + Today.AddDays(1 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                        dc.Width = 50
                        dc.DefaultCellStyle.Format = "n1"
                    End If
                    'If dc.Name.ToLower.StartsWith("tran") Then dc.DefaultCellStyle.Format = "n0"
                    'DatePart(DateInterval.WeekOfYear, Today.AddDays(1 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString()
                ElseIf dc.Name.ToLower.StartsWith("trans") Then
                    dc.ToolTipText = Today.ToString("dd-MMM-yyyy")
                End If

                If dc.Name.ToLower.StartsWith("pedido") Or dc.Name.ToLower.StartsWith("agre") Then
                    dc.ReadOnly = False
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
            'lsfiltro.Append("((sugerido > 0 and da_cajas > 0) or (sugerido < 1 and da_cajas > 0 and ppto_total < 1)) ")
            lsfiltro.Append("da_cajas > 0")
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




        Dim oCompras As New Compras.Internaciones(ds_informacion_productos)
        Try
            oCompras.Empresa = gs_empresa

            'oCompras.productoLimite = "0900000000"

            oCompras.crearEstructura()
            oCompras.agregarParametros()
            oCompras.inicializarProductos(False, False, False, False)
            oCompras.revisarProductosDerivados()
            If gs_empresa.ToLower.Equals("divinos") Then
                oCompras.Empresa = "DIUVA"
            End If
            oCompras.llenarExistenciasDA()
            oCompras.obtenerExistenciasDA("1")

            If gs_empresa.ToLower.Equals("divinos") Then
                oCompras.Empresa = "DIVINOS"
                oCompras.llenarExistenciasCD()
                llenarPresupuesto()
                oCompras.generarMinimosyMaximos(0, True)
                oCompras.generarPedidoSugerido(0, True)
            End If
            'quitarDerivados()
            'Generar_Transitos()
            'obtenerExistenciasDA()
            ' oCompras.generarSaldosyCoberturas(30)
            ' calcularDiasRealesTransito()
            'oCompras.generarMinimosyMaximos(0, True)
            'oCompras.generarPedidoSugerido(0, True)
            'oCompras.verificarProductosBloqueados()
            '  oCompras.verificarProductosRegistroSanitario()

            ''Agregar Campo para detalle de reservas

            ds_informacion_productos.Tables("").Columns.Add(New DataColumn("Cajas", GetType(Integer)))
        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try


        '     Dim oform As New frm_int_prepara_informacion(ds_informacion_productos)
        '      oform.ShowDialog()
        'Me.lblFechaIngreso.Text = "Fecha Ingreso " & oform.pdfechaIngreso.ToString("dd/MMM/yyyy")
        '        oform.Dispose()
        '       oform = Nothing
        'Me.dg_productos.DataSource = ds_informacion_productos.Tables("detalle_productos")
        ds_informacion_productos.Tables("detalle_productos").DefaultView.Sort = "sugerido desc"
        Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")

        ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "producto = ''"
        Me.dgvDuas.DataSource = ds_informacion_productos.Tables("detalle_dua").DefaultView
        colorearGrid()
        aplicarFiltro()

        'Colorear_Grid()
        'Posicionar_Producto()

    End Sub


    Private Sub llenarPresupuesto()

        Dim ls_sql, ls_mes As String
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("umbral")
        Dim clsGen As New ClasesGenerales.General
        Dim nsemana As Integer
        Dim ndia, ndiasaño As Integer

        ndiasaño = DatePart(DateInterval.DayOfYear, Date.Parse("31/12/" & Year(Today).ToString))

        Try
            otrans.open()
            Dim dtunicos As DataTable = clsGen.ValoresDistinto(ds_informacion_productos.Tables("detalle_productos"), "empresa".Split(","))

            For Each dr_aux In dtunicos.Rows


                ''Presupuesto Diario
                ls_sql = "pa_sel_um_producto_presupuesto_dia 0, '" & dr_aux.Item("empresa") & "'"
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows

                    ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter _
                                 = "producto = '" & dr.Item("producto") & "'"
                    '= "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"


                    If ds_informacion_productos.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_informacion_productos.Tables("detalle_productos").DefaultView(0)

                        ndia = dr.Item("dia") - pdiaActual

                        If ndia < 0 Then ndia += ndiasaño

                        If ndia < 52 Then
                            ls_mes = "ppto"
                            If ndia > 0 Then ls_mes += "+" + ndia.ToString.PadLeft(2, "00")
                            drv(ls_mes) += dr.Item("ppto_diario")
                        End If
                        drv("ppto_total") += dr.Item("ppto_diario")

                    End If

                    ds_informacion_productos.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and " & _
                             "producto = '" & dr.Item("producto").ToString & "'"
                    'Derivador 110613
                    If ds_informacion_productos.Tables("derivados").DefaultView.Count > 0 Then
                        For Each drvaux As DataRowView In ds_informacion_productos.Tables("derivados").DefaultView
                            'Try
                            '    drvaux.Item("existencia") = dr.Item("Existencia") '(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
                            'Catch ex As Exception

                            'End Try

                            ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter _
                                        = "producto = '" & drvaux.Item("producto_padre").ToString & "' and empresa = '" & drvaux.Item("empresa").ToString & "'"

                            If ds_informacion_productos.Tables("detalle_productos").DefaultView.Count Then


                                drv = ds_informacion_productos.Tables("detalle_productos").DefaultView(0)
                                ndia = dr.Item("dia") - pdiaActual

                                If ndia < 0 Then ndia += ndiasaño

                                If ndia < 52 Then
                                    ls_mes = "ppto"
                                    If ndia > 0 Then ls_mes += "+" + ndia.ToString.PadLeft(2, "00")
                                    drv(ls_mes) += dr.Item("ppto_diario")
                                End If
                                drv("ppto_total") += dr.Item("ppto_diario")
                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = ""

        End Try


    End Sub


    Private Sub btn_propuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_propuesta.Click

        If MessageBox.Show("Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'revisionRegistroSanitario()
            prepararReserva()
            'guardarReserva()
        End If

    End Sub

    Private Sub revisionRegistroSanitario()

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = "agregar = true"

        For Each drv As DataRowView In ds_informacion_productos.Tables("detalle_productos").DefaultView
            Try
                If drv.Item("numero_registro_sanitario").ToString.Trim.Length > 0 Then
                    If drv.Item("fecha_vencimiento_registro").ToString.Trim.Length > 0 Then

                        If drv.Item("fecha_vencimiento_registro") <= Today Then
                            MessageBox.Show("El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " Tiene El Registro Sanitario Vencido y No se Procesara ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            guardarAvisoRegistro("Internaciones El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " Tiene El Registro Sanitario Vencido")

                            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & drv.Item("producto") & "'"

                            For Each drv2 As DataRowView In ds_informacion_productos.Tables("detalle_dua").DefaultView
                                drv2.Item("asociar") = False
                                drv2.Item("cantidad_trasladar") = 0
                            Next

                        End If
                    End If
                Else
                    MessageBox.Show("El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " No Tiene Registro Sanitario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    guardarAvisoRegistro("Internaciones El Producto " & drv.Item("Glosa").ToString.Trim & Chr(13) & " No Tiene Registro Sanitario")
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub prepararReserva()

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



            ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True"

            dt = ClsGen.ValoresDistinto(ds_informacion_productos.Tables("detalle_dua").DefaultView.ToTable, "dua".Split(","))
            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            For Each dr As DataRow In dt.Rows
                dr.Item("producto") = ""
            Next

            dt.DefaultView.RowFilter = "dua like '%FPA%'"
            If dt.DefaultView.Count > 0 Then


                ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True and dua like '%FPA%'"
                For Each drv As DataRowView In ds_informacion_productos.Tables("detalle_dua").DefaultView
                    dt.DefaultView.RowFilter = "dua = '" & drv.Item("dua") & "' and producto = ''"
                    If dt.DefaultView.Count > 0 Then
                        dt.DefaultView(0).Item("producto") = drv.Item("producto")
                    Else
                        Dim dr As DataRow
                        dr = dt.NewRow
                        dr.Item("dua") = drv.Item("dua")
                        dr.Item("producto") = drv.Item("producto")
                        dt.Rows.Add(dr)
                    End If

                Next
            End If
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
            guardarReserva(dt)
        End If
    End Sub

    Private Sub guardarReserva(ByVal dtDuas As DataTable)
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim drv, drv_aux As DataRowView
        Dim inumero As Integer = 0

        Try
            oTrans.open()
            Dim lsTipoReserva As String = "RE-"
            For Each dr As DataRow In dtDuas.Rows

                ''Obtener Correlativo de las reservas
                ls_sql = "pa_var_um_da_reserva_encabezado_correlativo_tipo "

                If gs_usuario.ToString.ToLower.StartsWith("bastu") Then
                    lsTipoReserva = "ES-"
                End If
                ls_sql += "'" + lsTipoReserva + "'"
                dt = oTrans.Obtiene(ls_sql)

                If dt.Rows.Count > 0 Then
                    inumero = Val(dt.Rows(0)("no_orden").ToString) + 1
                Else
                    inumero = 1
                End If


                ls_sql = "asociar = True and dua = '" & dr.Item("dua") & "'"
                If dr.Item("producto").ToString.Trim.Length > 0 Then
                    ls_sql += " and producto = '" & dr.Item("producto") & "'"
                End If
                ds_informacion_productos.Tables("detalle_dua").DefaultView.RowFilter = ls_sql

                ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = _
                 "producto = '" & ds_informacion_productos.Tables("detalle_dua").DefaultView(0)("producto") & "'"

                ls_sql = "pa_ins_um_da_reserva_encabezado '" & gs_empresa & "','" & lsTipoReserva & inumero.ToString.PadLeft(5, "0") & "','" & _
                        "DA_CENTRAL','" + Today.ToString("dd/MM/yyyy") + "','" & dr.Item("dua").ToString & "','" & _
                    ds_informacion_productos.Tables("detalle_productos").DefaultView(0)("proveedor").ToString & "','" & _
                    gs_usuario & "','CREADA','" & _
                    ds_informacion_productos.Tables("detalle_dua").DefaultView(0)("comentarios") & "'"
                oTrans.Ingresa(ls_sql)

                If oTrans.Codigo_error = 0 Then
                    If ds_informacion_productos.Tables("detalle_dua").DefaultView.Count > 0 Then
                        Dim icount As Integer = 0
                        For Each drv_aux In ds_informacion_productos.Tables("detalle_dua").DefaultView


                            ''Actualizar el Filtro
                            ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = _
                             "producto = '" & drv_aux.Item("producto") & "'"



                            '(c) Debe mantener el Factor que genero el ingreso

                            If drv_aux.Item("cantidad_trasladar") > 0 Then

                                icount += 1
                                ls_sql = "pa_ins_um_da_reserva_detalle '" & gs_empresa & "','" & lsTipoReserva & _
                                        inumero.ToString.PadLeft(5, "0") & "','DA_CENTRAL'," & _
                                        icount.ToString & ",'" & drv_aux.Item("dua") & "','" & drv_aux.Item("producto") & "'," & _
                                        drv_aux.Item("cantidad_trasladar") * drv_aux.Item("factor_ingreso") & "," & _
                                        drv_aux.Item("cantidad_trasladar") & ",'" & _
                                        drv_aux.Item("lote") & "'"

                                '                        ls_sql = "pa_ins_um_da_reserva_detalle '" & gs_empresa & "','" & lsTipoReserva & _
                                'inumero.ToString.PadLeft(5, "0") & "','DA_CENTRAL'," & _
                                'icount.ToString & ",'" & drv_aux.Item("dua") & "','" & drv_aux.Item("producto") & "'," & _
                                'drv_aux.Item("cantidad_trasladar") * ds_informacion_productos.Tables("detalle_productos").DefaultView(0)("uxc") & "," & _
                                'drv_aux.Item("cantidad_trasladar") & ",'" & _
                                'drv_aux.Item("lote") & "'"

                                oTrans.Ingresa(ls_sql)
                            End If
                        Next


                        MessageBox.Show("Se Genero la Reserva  No. " & lsTipoReserva & inumero.ToString.PadLeft(5, "0") & " Para " & _
                                    ds_informacion_productos.Tables("detalle_dua").DefaultView(0)("comentarios"), "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


                        guardarAvisoReserva(inumero, ds_informacion_productos.Tables("detalle_productos").DefaultView(0)("proveedor").ToString & _
                           " - " & ds_informacion_productos.Tables("detalle_dua").DefaultView(0)("comentarios"))

                    End If
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

    Private Sub guardarAvisoReserva(ByVal inumero As Integer, ByVal snombre As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable

        Try

            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (24)" '1= Ingreso de Dua OC
            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Solicitud de Reserva No " & _
                                      inumero & "  " & _
                                      snombre, 10)
            Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing
        End Try


    End Sub

    Private Sub guardarAvisoRegistro(ByVal smensaje As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable

        Try

            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (17)" '17= Registros Sanitarios

            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", smensaje, 17)
            Next


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
            myOtrans.close()
            myOtrans = Nothing
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
            clsgen.Alinear_GridView(ds_informacion_productos.Tables("detalle_dua").DefaultView.ToTable, _
                    Me.dgvDuas, _
                    "", ",empresa,fecha,fobunitario,daiunitario,producto,glosa,", ",producto,glosa,dua,fecha,saldo_cajas,saldo_unidades,fecha_vencimiento_dua,fecha_vencimiento_producto,observaciones,fob,dai,iva,fob_unitario,dai_unitario", "", _
                    ",cantidad_trasladar=cantidad,saldo_cajas=cajas,saldo_unidades=unidades,fecha_vencimiento_dua=venc_dua,fecha_vencimiento_producto=venc_producto,", _
                    ",asociar=30,saldo_unidades=40,saldo_cajas=40,cantidad_trasladar=40,fecha_vencimiento_producto=70,fecha_vencimiento_dua=70,factor_ingreso=40,", _
                    "", True, True, 130, 0)


            clsgen = Nothing
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub dgv_detalle_BindingContextChanged(sender As Object, e As EventArgs) Handles dgv_detalle.BindingContextChanged

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

    Private Sub txt_texto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_texto.TextChanged

    End Sub

    Private Sub dgv_detalle_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_detalle.MouseClick
        mostrarDua()
        hacerResumen()
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
                            Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, Me.dgv_detalle.Item("pedido", Me.dgv_detalle.CurrentRow.Index).Value, True)
                        Else
                            Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, 0, False)
                        End If
                    End If

                    If Me.dgvDuas.Columns(colIndex).Name.ToLower.Equals("cantidad_trasladar") Then
                        Me.aplicar_producto(Me.dgvDuas.Item("producto", rowIndex).Value.ToString, Me.dgvDuas.Item("dua", rowIndex).Value, Me.dgv_detalle.Item("pedido", Me.dgv_detalle.CurrentRow.Index).Value, Me.dgvDuas.Item("asociar", rowIndex).Value)
                    End If
                    hacerResumen()
                    '                    dg_producto_dua.CurrentCell = dg_producto_dua.Item(colIndex, rowIndex)
                End If
            End If


        Catch ex As Exception
        End Try

    End Sub

    Private Sub aplicar_producto(ByVal sproducto As String, ByVal sdua As String, ByVal icantidad As Integer, ByVal bagregar As Boolean)


        For Each dr As DataRow In ds_informacion_productos.Tables("detalle_dua").Rows
            If dr.Item("producto").ToString = sproducto And dr.Item("dua").ToString = sdua Then
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

            If drv.Item("cantidad_trasladar") <= drv.Item("saldo_cajas") Then

                ds_informacion_productos.Tables("detalle_seleccion").DefaultView.RowFilter = "producto = '" & drv.Item("producto").ToString & "' and dua = '" & drv.Item("dua") & "'"

                If ds_informacion_productos.Tables("detalle_seleccion").DefaultView.Count = 0 Then
                    Dim dr As DataRow = ds_informacion_productos.Tables("detalle_seleccion").NewRow
                    dr.Item("producto") = drv.Item("producto")
                    dr.Item("glosa") = drv.Item("glosa")
                    dr.Item("dua") = drv.Item("dua")
                    dr.Item("cantidad") = drv.Item("cantidad_trasladar")
                    dr.Item("comentarios") = drv.Item("comentarios")
                    dr.Item("uxc") = drv.Item("factor_ingreso")

                    ds_informacion_productos.Tables("detalle_seleccion").Rows.Add(dr)
                End If
            Else
                MessageBox.Show("No Puede Trasladar mas del Saldo", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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


    Private Sub frm_int_Pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub dgvDuas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDuas.CellContentClick

    End Sub
End Class