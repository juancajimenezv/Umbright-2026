Imports System.Text
Public Class frm_scm_coberturas

    Dim ods As DataSet
    Dim nfrozen As Integer = 0
    Dim psemanaActual As Integer = DatePart(DateInterval.WeekOfYear, Today, FirstDayOfWeek.Monday)

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        ods = New DataSet

        Dim oCompras As New Compras.SCM(ods)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim iaux As Integer


        Try
            otrans.open()
            oCompras.Empresa = gs_empresa
            oCompras.Crear_Estructura()
            oCompras.SetProductoLimite("0060000000")
            oCompras.Inicializar_Productos(True, False, False, False)
            oCompras.Revisar_productoDerivados("detalle_productos")

            'If Not Me.btnMarcar.Text.ToLower.StartsWith("des") Then

            dt = ods.Tables("detalle_productos").Copy
            dt.Rows.Clear()
            For ii As Integer = 0 To chk_marcas.Items.Count - 1

                If Me.chk_marcas.GetItemChecked(ii) Then
                    'ods.Tables("detalle_productos").DefaultView.RowFilter = "proveedor = '" & Me.chk_marcas.Items(ii)("codigo") & "'"
                    ods.Tables("detalle_productos").DefaultView.RowFilter = "familia = '" & Me.chk_marcas.Items(ii)("codigo") & "'"
                    For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
                        If drv.Item("producto") = "0010101004" Then
                            drv.Item("producto") = "0010101004"
                        End If
                        ods.Tables("derivados").DefaultView.RowFilter = "empresa = '" & drv.Item("empresa") & "' and " &
                            "producto = '" & drv.Item("producto") & "'"


                        If ods.Tables("derivados").DefaultView.Count = 0 Then

                            dr = dt.NewRow
                            For Each dc As DataColumn In dt.Columns
                                dr.Item(dc.ColumnName) = drv.Item(dc.ColumnName)
                            Next
                            dt.Rows.Add(dr)
                        End If
                    Next


                End If
            Next
            dt.TableName = "detalle_productos"
            ods.Tables.Remove("detalle_productos")
            ods.Tables.Add(dt.Copy)

            ' End If

            Dim dtunicos As DataTable = ClsGen.ValoresDistinto(ods.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            oCompras.generarExistencia(False, False)

            'For Each dr_aux As DataRow In dtunicos.Rows

            '    ''Existencia CD
            '    ' Me.chk_existencias_cd.Checked = True

            '    ls_sql = "pa_var_um_existencias_producto '" & dr_aux.Item("empresa") & "','" & _
            '                dr_aux.Item("proveedor") & "'," & _
            '                "NULL" & _
            '                  ",'CD_CENTRAL','" & IIf(dr_aux.Item("empresa") = "ALAMSA", "0090000000", "0060000000") & "'"
            '    dt = otrans.Obtiene(ls_sql)

            '    For Each dr In dt.Rows
            '        ods.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"
            '        For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
            '            Try
            '                iaux = dr.Item("Existencia") / drv.Item("uxc")
            '            Catch ex As Exception
            '                iaux = 0
            '            End Try
            '            drv.Item("cd_cajas") = iaux
            '            drv.Item("existencia") += drv.Item("cd_cajas")
            '        Next

            '        ods.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and " & _
            '                    "producto = '" & dr.Item("producto") & "'"
            '        If ods.Tables("derivados").DefaultView.Count > 0 Then
            '            For Each drvaux As DataRowView In ods.Tables("derivados").DefaultView


            '                ods.Tables("detalle_productos").DefaultView.RowFilter _
            '                            = "producto = '" & drvaux.Item("producto_padre") & "' and empresa = '" & drvaux.Item("empresa") & "'"

            '                For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
            '                    Try
            '                        iaux = (dr.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
            '                    Catch ex As Exception
            '                        iaux = 0
            '                    End Try
            '                    drv.Item("cd_cajas") += iaux
            '                    drv.Item("existencia") += iaux
            '                Next

            '            Next


            '        End If
            '    Next

            '    ''Existencia CD XELA
            '    'Me.chk_existencias_cd.Checked = True

            '    ls_sql = "pa_var_um_existencias_producto '" & dr_aux.Item("empresa") & "','" & _
            '             dr_aux.Item("proveedor") & "',NULL" & _
            '             ",'CDX_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            '    'IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL") & _
            '    dt = otrans.Obtiene(ls_sql)

            '    For Each dr In dt.Rows
            '        ods.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"
            '        For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
            '            Try
            '                iaux = dr.Item("Existencia") / drv.Item("uxc")
            '            Catch ex As Exception
            '                iaux = 0
            '            End Try
            '            drv.Item("cdx_cajas") = iaux
            '            drv.Item("existencia") += drv.Item("cdx_cajas")
            '        Next

            '        ods.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and " & _
            '                    "producto = '" & dr.Item("producto") & "'"
            '        If ods.Tables("derivados").DefaultView.Count > 0 Then
            '            For Each drvaux As DataRowView In ods.Tables("derivados").DefaultView


            '                ods.Tables("detalle_productos").DefaultView.RowFilter _
            '                            = "producto = '" & drvaux.Item("producto_padre") & "' and empresa = '" & drvaux.Item("empresa") & "'"

            '                For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
            '                    Try
            '                        iaux = (dr.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
            '                    Catch ex As Exception
            '                        iaux = 0
            '                    End Try
            '                    drv.Item("cdx_cajas") += iaux
            '                    drv.Item("existencia") += iaux
            '                Next

            '            Next


            '        End If
            '    Next

            '    ''Existencias DA
            '    'Me.chk_existencias_da.Checked = True

            '    ls_sql = "pa_var_um_existencias_producto '" & dr_aux.Item("empresa") & "','" & _
            '             dr_aux.Item("proveedor") & "',NULL" & _
            '            ",'DA_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            '    dt = otrans.Obtiene(ls_sql)

            '    For Each dr In dt.Rows
            '        ods.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"
            '        For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
            '            drv.Item("da_cajas") = dr.Item("Existencia") / drv.Item("uxc")
            '            drv.Item("existencia") += drv.Item("da_cajas")
            '        Next
            '    Next

            'Next 'Principal

            'producto en internacion
            dtunicos = ClsGen.ValoresDistinto(ods.Tables("detalle_productos"), "empresa".Split(","))

            For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_var_um_producto_transito_internacion '" & dr_aux.Item("empresa") & "'"
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows
                    ods.Tables("detalle_productos").DefaultView.RowFilter _
                                       = "producto = '" & dr.Item("producto") & "' and empresa = '" & dr.Item("empresa") & "'"
                    For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
                        Try
                            iaux = dr.Item("cantidad") / drv.Item("uxc")
                        Catch ex As Exception
                            iaux = 0
                        End Try
                        drv.Item("internacion") = iaux
                        drv.Item("existencia") += drv.Item("internacion")
                    Next

                Next
            Next

            '            Generar_Presupuestos()
            '          Generar_Transitos()


            oCompras.generarTransitos(psemanaActual, "", False)

            ''Generando Presupuestos
            '          Me.chk_presupuestos.Checked = True
            '  Generar_Presupuestos()
            oCompras.generarPresupuestos(psemanaActual, "", False)
            oCompras.Generar_SaldosyCoberturas(False)

            dg_productos.DataSource = ods.Tables("detalle_productos")

            dt = ClsGen.ValoresDistinto(ods.Tables("detalle_productos"), "marca".Split(","))

            If dt.Rows.Count > 1 Then
                Me.lblMarca.Visible = True
                Me.cmbMarca.Visible = True
                cmbMarca.Items.Clear()
                cmbMarca.Items.Add("-TODOS-")
                For Each dr In dt.Rows
                    cmbMarca.Items.Add(dr.Item("marca"))
                Next

            Else
                Me.lblMarca.Visible = False
                Me.cmbMarca.Visible = False
            End If



            ''Agregar Informacion del CUBO 20170327

            'ods.Tables("detalle_productos")
            ods.Tables("detalle_productos").Columns.Add(New DataColumn("costo_inventario", GetType(Double)))
            ods.Tables("detalle_productos").Columns.Add(New DataColumn("unidades_ss", GetType(Double)))
            ods.Tables("detalle_productos").Columns.Add(New DataColumn("costo_ss", GetType(Double)))




            Dim dtss As DataTable

            dtss = otrans.Obtiene("Select * from Sobre_Inventario4 where bodega = 'cd_da'")
            For Each dr2 As DataRow In ods.Tables("detalle_productos").Rows
                dtss.DefaultView.RowFilter = "empresa = '" & dr2.Item("empresa").ToString & "' and producto = '" & dr2.Item("producto").ToString & "'"
                Try
                    If dtss.DefaultView.Count > 0 Then
                        dr2.Item("costo_inventario") = dtss.DefaultView(0).Item("costo_inventario")
                        dr2.Item("costo_ss") = dtss.DefaultView(0).Item("costo_sobre_inventario")
                        dr2.Item("unidades_ss") = dtss.DefaultView(0).Item("sobre_inventario")
                    End If
                Catch ex As Exception
                End Try
            Next

            dtss.DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"
            For Each drv As DataRowView In dtss.DefaultView

                Try

                    ods.Tables("detalle_productos").DefaultView.RowFilter = "producto = '" & drv.Item("producto").ToString & "'"
                    If ods.Tables("detalle_productos").DefaultView.Count = 0 Then
                        Dim dr2 As DataRow

                        dr2 = ods.Tables("detalle_productos").NewRow
                        dr2.Item("producto") = drv.Item("producto").ToString
                        dr2.Item("glosa") = drv.Item("glosa").ToString
                        dr2.Item("costo_inventario") = drv.Item("costo_inventario")
                        dr2.Item("costo_ss") = drv.Item("costo_sobre_inventario")
                        dr2.Item("unidades_ss") = drv.Item("sobre_inventario")
                        dr2.Item("pareto") = drv.Item("pareto").ToString

                        ods.Tables("detalle_productos").Rows.Add(dr2)

                    End If
                Catch ex As Exception

                End Try

            Next


        Catch ex As Exception
        Finally
            oCompras = Nothing
            otrans.close()
            otrans = Nothing
            oCompras = Nothing
            ods.Tables("detalle_productos").DefaultView.RowFilter = ""

            'ods.WriteXml("c:\aplicaciones\cobertura\" & gs_empresa.Trim & Today.ToString("ddMMMMyy") & ".xml", XmlWriteMode.WriteSchema)


            ''Dim ods As New DataSet
            ''ods.ReadXml("c:\aplicaciones\cobertura\diuva.xml")

            ''''Dim odsnew As New DataSet

            'Dim dt As New DataTable
            dt = ods.Tables("detalle_productos").Copy
            dt.Columns.Add(New DataColumn("fecha_generacion", GetType(String)))
            For Each draux As DataRow In dt.Rows
                draux.Item("fecha_generacion") = Today.ToString("dd/MM/yyyy")
            Next
            '''Dim clsgen As New ClasesGenerales.General
            ClsGen.dtTableToCSV(dt, "c:\aplicaciones\cobertura\" & gs_empresa & Today.ToString("ddMMMMyy"), True, "|")
            ClsGen = Nothing


            'dt.TableName = "detalle_productos"

            'dt.WriteXml("c:\aplicaciones\cobertura\test.xml", XmlWriteMode.WriteSchema)
        End Try

        'Colorear_Grid()



    End Sub

    Private Sub Colorear_Grid()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String
        Dim piSemanas As String = 0
        Try

            ls_columnas_ocultar = String.Empty
            'If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
            ls_columnas_ocultar += ",empresa,cajasxlayer,procedencia,cajasxpallet,fob,pedido,agregar,full,calculos,pv_margen_seguridad,pv_inv_maximo,pv_ciclo_compra,valor_sugerido,pv_lead_time_total,diario_cajas,estatus,sugerido_proveedor,min_cajas,max_cajas,tiene_compra,peso,volumen,peso_total,volumen_total,pv_inv_seguridad,"
            ls_columnas_ocultar += ",cobertura_pedido,porcentaje_ajuste,minimo_compra,pv_inv_reorden,pv_modificar_transito,costo_unitario,"
            ls_columnas_fijas = ",pareto=25,uxc=25,cd_cajas=35,da_cajas=35,cdx_cajas=35,ppto=50,existencia=50,internacion=35,bodegas=35,transito=35,"

            ClsGen.Alinear_GridView(ods.Tables("detalle_productos"), dg_productos, "", ls_columnas_ocultar, "", "", ",pareto=categoria,", ls_columnas_fijas, "", True, True, 150, 0)



            For Each dc As DataGridViewColumn In dg_productos.Columns
                'If dc.Name.ToLower.StartsWith("cober") Then
                '    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                '    dc.Width = 50
                'ElseIf dc.Name.ToLower.StartsWith("suger") Then
                '    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                '    If piSemanas > 0 Then
                '        Try
                '            If dc.Name.IndexOf("+") > 0 Then
                '                If Val(dc.Name.Split("+")(1)) < piSemanas Then
                '                    dc.Width = 70
                '                Else
                '                    dc.Visible = False
                '                End If
                '            Else
                '                dc.Width = 70
                '            End If
                '        Catch ex As Exception
                '            dc.Width = 70
                '        End Try

                '    End If


                'ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                '    dc.Visible = False
                'End If
                If dc.Name.ToLower.StartsWith("transito+") Then
                    dc.DefaultCellStyle.Format = "n0"
                    If Me.clb_opciones.GetItemChecked(0) Then
                        dc.Visible = True
                    Else
                        dc.Visible = False
                    End If
                ElseIf dc.Name.ToLower.StartsWith("ppto+") Then
                    If Me.clb_opciones.GetItemChecked(1) Then
                        dc.Visible = True
                    Else
                        dc.Visible = False
                    End If
                ElseIf dc.Name.ToLower.StartsWith("cobertura+") Then
                    If Me.clb_opciones.GetItemChecked(2) Then
                        dc.Visible = True
                    Else
                        dc.Visible = False
                    End If
                ElseIf dc.Name.ToLower.StartsWith("teorico") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("saldo+") Then
                    'If Me.clb_opciones.GetItemChecked(3) Then
                    '    dc.Visible = True
                    'Else
                    '    dc.Visible = False
                    'End If
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("sugeri") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("marca") Then
                    dc.Visible = True
                ElseIf dc.Name.ToLower.StartsWith("uxc") Then
                    dc.DefaultCellStyle.Format = "n0"
                End If



                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    Try
                        dc.ToolTipText = Today.AddDays(7 * dc.Name.Substring(dc.Name.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")

                        dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " + _
                                     DatePart(DateInterval.WeekOfYear, Today.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString
                    Catch ex As Exception

                    End Try
                ElseIf dc.Name.ToLower.StartsWith("trans") Then
                    dc.ToolTipText = Today.ToString("dd-MMM-yyyy")

                End If

            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Alinear_Grids()
        Dim ClsGen As New ClasesGenerales.General
        Try


            ClsGen.Alinear_GridView(ods.Tables("detalle_productos"), Me.dg_productos, ",ppto,trasi,proveedor,marca,producto,glosa,uxc,saldo,cobertura,", "", "", "", "", ",pareto=50,", "", True, True, 100, 0)

            If Me.clb_opciones.GetItemChecked(0) Or _
                 Me.clb_opciones.GetItemChecked(1) Then

                For Each dc As DataGridViewTextBoxColumn In Me.dg_productos.Columns
                    If dc.Name.ToLower.StartsWith("transi") Then
                        If Me.clb_opciones.GetItemChecked(0) Then
                            dc.Visible = True
                        Else
                            dc.Visible = False
                        End If
                    End If

                    If dc.Name.ToLower.StartsWith("ppto") Then
                        If Me.clb_opciones.GetItemChecked(1) Then
                            dc.Visible = True
                        Else
                            dc.Visible = False
                        End If
                    End If
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Generar_Presupuestos()
        Dim ls_sql, ls_mes As String
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("umbral")
        Dim clsGen As New ClasesGenerales.General
        Dim nsemana As Integer
        Dim psemanaActual As Integer = DatePart(DateInterval.WeekOfYear, Today)
        Try
            otrans.open()
            Dim dtunicos As DataTable = clsGen.ValoresDistinto(ods.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            For Each dr_aux In dtunicos.Rows


                ls_sql = "pa_sel_um_producto_presupuesto 0,'" & dr_aux.Item("empresa") & "','" & _
                         dr_aux.Item("proveedor") & "',NULL"
                'IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL")
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows
                    ods.Tables("detalle_productos").DefaultView.RowFilter _
                                    = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"


                    If ods.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ods.Tables("detalle_productos").DefaultView(0)

                        nsemana = dr.Item("semana") - psemanaActual

                        If nsemana < 0 Then nsemana += 52

                        ls_mes = "ppto"
                        If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")
                        drv.Item(ls_mes) += dr.Item("ppto_semanal")

                        'If dr.Item("meses_diferencia") <= 0 Then
                        '    drv.Item("ppto") = drv.Item("ppto") + dr.Item("cantidad_cajas")
                        'Else
                        '    If dr.Item("meses_diferencia") > 70 Then
                        '        dr.Item("meses_diferencia") = dr.Item("meses_diferencia") - 88
                        '    End If
                        '    ls_mes = "ppto+" & dr.Item("meses_diferencia").ToString.PadLeft(2, "0")
                        '    drv.Item(ls_mes) = drv.Item(ls_mes) + dr.Item("cantidad_cajas")

                        'End If
                    End If
                Next
            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub

    ''Generar Transitos
    Private Sub Generar_Transitos()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim clsGen As New ClasesGenerales.General
        Dim ls_sql, ls_mes As String

        Dim nsemana As String
        Dim psemanaActual As Integer = DatePart(DateInterval.WeekOfYear, Today)



        Try
            otrans.open()
            Dim dtunicos As DataTable = clsGen.ValoresDistinto(ods.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_var_um_transito_productos '" & dr_aux.Item("empresa") & "','" & _
                         dr_aux.Item("proveedor") & "',NULL"
                'IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL")

                dt = otrans.Obtiene(ls_sql)
                For Each dr In dt.Rows
                    ods.Tables("detalle_productos").DefaultView.RowFilter _
                                    = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"

                    If ods.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ods.Tables("detalle_productos").DefaultView(0)


                        If dr.Item("semana") < psemanaActual And DateTime.Parse(dr.Item("fecha_vencimiento").ToString).Year = Today.Year Then
                            nsemana = 0
                        Else
                            nsemana = dr.Item("semana") - psemanaActual
                        End If

                        If nsemana < 0 Then nsemana += 53

                        ls_mes = "transito"

                        If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")
                        drv.Item(ls_mes) += dr.Item("cajas_pedidas")

                    End If
                Next

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub


    Private Sub Exportar_Vista_Actual()
        Dim Oaut As New Automatizar.exportar_excel

        Dim socultar_columnas As New StringBuilder


        Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}, {4, 2}}

        Oaut.Nombre_Columnas = ",,,,,,,,,,,,,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

        For Each dc As DataGridViewColumn In Me.dg_productos.Columns
            If Not dc.Visible Then socultar_columnas.Append("," & dc.Name.ToLower)
        Next
        socultar_columnas.Append(",")
        Oaut.ocultar_columnas = socultar_columnas.ToString

        Oaut.nAgregar_Filas = 2
        Oaut.DataTableToExcel(ods.Tables("detalle_productos"))
        Oaut = Nothing
    End Sub

    Private Sub LlenarLista()
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dt As DataTable
        Dim ls_sql As String
        Try
            Otrans.open()
            'dt = Otrans.Obtiene("pa_sel_um_gen_tabcod NULL,'producto.tipo','" & gs_empresa & "'")

            'ls_sql = "Select distinct CODIGO from gen_tabcod " & _
            '    " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.SUBFAMILIA' " & _
            '    " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' UNION " & _
            'ls_sql = " select distinct SubFamilia  as codigo from Producto where empresa='" & gs_empresa & "'  and validastock = 's' and vigente = 's' order by 1 "
            '06/06/2013 (c) Solicitud de Phillip
            ls_sql = " select distinct Familia  as codigo from Producto where empresa='" & gs_empresa & "'  and validastock = 's' and vigente = 's' order by 1 "
            dt = Otrans.Obtiene(ls_sql)

            Me.chk_marcas.DataSource = dt
            Me.chk_marcas.ValueMember = "CODIGO"


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub MarcarTodos(ByVal popcion As String)

        For ii As Integer = 0 To chk_marcas.Items.Count - 1
            If popcion.StartsWith("marcar") Then
                Me.chk_marcas.SetItemChecked(ii, True)
            Else
                Me.chk_marcas.SetItemChecked(ii, False)
            End If

        Next
    End Sub

    Private Sub clb_opciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clb_opciones.SelectedIndexChanged

    End Sub

    Private Sub clb_opciones_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clb_opciones.SelectedValueChanged
        'Alinear_Grid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Colorear_Grid()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Exportar_Vista_Actual()
    End Sub

    Private Sub mostrarDerivados()
        Dim oform As New frm_resultado
        Dim clsGen As New ClasesGenerales.General

        Try
            oform.Text = "Productos Derivados de " + dg_productos.Item("producto", Me.dg_productos.CurrentRow.Index).Value + "--" + dg_productos.Item("glosa", Me.dg_productos.CurrentRow.Index).Value

            'dt.DefaultView.Sort = "periodo DESC"
            ods.Tables("derivados").DefaultView.RowFilter = "producto_padre = '" & dg_productos.Item("producto", Me.dg_productos.CurrentRow.Index).Value & "'"
            oform.dgv_resultado.DataSource = ods.Tables("derivados")
            Dim lcolumnasmostrar As String = ",empresa,producto,glosa,unidades,"
            'If Not dt2 Is Nothing Then lcolumnasmostrar += "producto,glosa,"


            clsGen.Alinear_GridView(ods.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", "", "", ",empresa,producto,glosa,unidades,", True, True, 250, 0)
            '  ClsGen.Alinea_Grid(dt, oform.DataGrid1, dt.TableName, -1, 250, 0, False, True, ",,", True, "")
            For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
                If dc.Name.ToLower = "unidades" Then
                    dc.DefaultCellStyle.Format = "n4"
                End If
            Next
            oform.ShowDialog()

        Catch ex As Exception
        Finally
            oform = Nothing
        End Try


    End Sub

    Private Sub generarReporte()
        '[Empresa]([varchar](20))
        '[Proveedor]([varchar](50))
        '[Marca]([varchar](50))
        '[Producto]([varchar](20))
        '[Descripcion]([varchar](100))
        '[Existencia_CD]([numeric](22, 8))
        '[Existencia_CDX]([numeric](22, 8))
        '[Existencia_DA]([numeric](22, 8))
        '[Existencia_Total]([numeric](22, 8))
        '[Costo_Dolares]([numeric](22, 8))
        '[Cobertura_Semanas]([numeric](22, 8))
        '[Existencia_Ideal]([numeric](22, 8))


        Dim dt = New DataTable()
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("internacion", GetType(Double)))
        dt.Columns.Add(New DataColumn("existencia_cd", GetType(Double)))
        dt.Columns.Add(New DataColumn("existencia_cdx", GetType(Double)))
        dt.Columns.Add(New DataColumn("existencia_da", GetType(Double)))
        dt.Columns.Add(New DataColumn("existencia_total", GetType(Double)))
        dt.Columns.Add(New DataColumn("transito", GetType(Double)))
        dt.Columns.Add(New DataColumn("ppto", GetType(Double)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Double)))
        dt.Columns.Add(New DataColumn("costo", GetType(Double)))
        dt.Columns.Add(New DataColumn("cobertura_semanas", GetType(Double)))
        dt.Columns.Add(New DataColumn("existencia_ideal", GetType(Double)))
        dt.Columns.Add(New DataColumn("usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("uxc", GetType(Decimal)))




        'ods.Tables.Add(dt)
        Dim dr As DataRow
        Dim snombreCampo As String

        For Each drv As DataRowView In ods.Tables("detalle_productos").DefaultView
            dr = dt.NewRow

            dr.Item("empresa") = drv.Item("empresa")
            dr.Item("proveedor") = drv.Item("proveedor")
            dr.Item("marca") = drv.Item("marca")
            dr.Item("producto") = drv.Item("producto")
            dr.Item("descripcion") = drv.Item("glosa")
            dr.Item("internacion") = drv.Item("internacion")
            dr.Item("existencia_cd") = drv.Item("cd_cajas")
            dr.Item("existencia_cdx") = drv.Item("cdx_cajas")
            dr.Item("existencia_da") = drv.Item("da_cajas")
            dr.Item("existencia_total") = drv.Item("existencia")
            dr.Item("transito") = drv.Item("transito")
            dr.Item("ppto") = drv.Item("ppto")
            dr.Item("saldo") = drv.Item("saldo")
            dr.Item("costo") = 0  ''Debo Obtener el Costo Por Bodega
            dr.Item("cobertura_semanas") = drv.Item("cobertura")
            dr.Item("existencia_ideal") = 0
            For i As Integer = 0 To 11
                snombreCampo = "ppto"
                If i > 0 Then snombreCampo += "+" + i.ToString("00")
                dr.Item("existencia_ideal") += drv.Item(snombreCampo)
            Next

            dr.Item("usuario") = gs_usuario
            dr.Item("tipo") = drv.Item("pareto")
            dr.Item("uxc") = drv.Item("uxc")

            dt.Rows.Add(dr)
        Next

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String

        Try
            Otrans.open()
            ''Debo Llenar El Costo de los productos
            Dim dtaux As DataTable
            lsSQL = "pa_sel_um_prodbodegas '" & gs_empresa & "','DA_CENTRAL'"
            dtaux = Otrans.Obtiene(lsSQL)
            For Each dr In dtaux.Rows
                dt.DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto") & "'"
                If dt.DefaultView.Count > 0 Then
                    dt.DefaultView(0).Item("costo") = dr.Item("costo") * dt.DefaultView(0)("uxc")
                End If
            Next





            ''Debo Eliminar Calculos Previos
            Otrans.Elimina("pa_del_um_exs_coberturas '" & gs_usuario & "'")
            For Each dr In dt.Rows
                lsSQL = "pa_ins_um_exs_coberturas '" & dr.Item("empresa") & "','" & dr.Item("proveedor") & "','" & _
                         dr.Item("marca") & "','" & dr.Item("producto") & "','" & dr.Item("descripcion") & "','" & dr.Item("tipo") & "'," & _
                         dr.Item("internacion") & "," & dr.Item("existencia_cd") & "," & dr.Item("existencia_cdx") & "," & dr.Item("existencia_da") & "," & _
                         dr.Item("existencia_total") & "," & dr.Item("transito") & "," & dr.Item("ppto") & "," & dr.Item("saldo") & "," & _
                         dr.Item("costo") & "," & dr.Item("cobertura_semanas") & "," & dr.Item("existencia_ideal") & ",'" & _
                         dr.Item("usuario") & "'"
                Otrans.Ingresa(lsSQL)

            Next





        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        cargarReporte()
    End Sub

    Private Sub cargarReporte()
        Dim path_reporte As String

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim fecha2 As String
        Dim dt As DataTable

        Dim fecha As Date
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            pm_conexion = ClsGen.Parametros_Conexion("")
            path_reporte = ClsGen.Path_Reporte()
            Otrans.open()


            ''Aplico Seguridad
            ''Levanto el estado de cuenta
            ''Cargo el Reporte
            fecha = Format(Today, "d")
            fecha2 = fecha.ToShortDateString


            ReDim pm_parametros(2)
            ReDim pm_valores(2)
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "usuario"


            pm_valores(0) = gs_empresa
            pm_valores(1) = gs_usuario

            Otrans.close()
            Otrans = Nothing



            path_reporte += "proyectos\Inventario Ideal.rpt"





            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                        False, False, "PDF", True, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub frm_scm_coberturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarLista()
    End Sub

    Private Sub btnMarcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarcar.Click
        If btnMarcar.Text.ToLower.StartsWith("marcar") Then
            MarcarTodos("marcar")
            btnMarcar.Text = "Des-Marcar Todos"
        Else
            MarcarTodos("des marcar")
            btnMarcar.Text = "Marcar Todos"

        End If
    End Sub

    Private Sub dg_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_productos.CellContentClick

    End Sub

    Private Sub dg_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dg_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dg_productos.Rows(rowIndex)

                'If dg_productos.Columns(colIndex).Name.ToLower = "cobertura" Then
                If Me.dg_productos.Item("cobertura", rowIndex).Value.ToString > 0 And Me.dg_productos.Item("cobertura", rowIndex).Value.ToString < 5 Then
                    Me.dg_productos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                ElseIf Me.dg_productos.Item("cobertura", rowIndex).Value.ToString = 0 And Me.dg_productos.Item("ppto", rowIndex).Value.ToString > 0 Then
                    Me.dg_productos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    '    Else
                    '       Me.dg_productos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black

                End If
                If dg_productos.Columns(colIndex).Name.ToLower.StartsWith("transito") Then
                    If Me.dg_productos.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        Me.dg_productos.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Me.ContextMenuStrip1.Items.Clear()
        Try
            Me.ContextMenuStrip1.Items.Add("Inmovilizar Paneles '" & Me.dg_productos.Columns(Me.dg_productos.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Movilizar Paneles ", Nothing, AddressOf ToolStripMenuItem_Click)

            ' If Me.dg_productos.Columns(Me.dg_productos.CurrentCell.ColumnIndex).Name.ToLower.StartsWith("glosa") Then
            Dim nrow As Integer = Me.dg_productos.CurrentRow.Index
            If Me.dg_productos.Item("glosa", nrow).Value.ToString.StartsWith("**") Then
                Me.ContextMenuStrip1.Items.Add("Ver Derivados ", Nothing, AddressOf ToolStripMenuItem_Click)
            End If

            'End If
            'If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.IndexOf("+") > 0 Then
            '    Me.ContextMenuStrip1.Items.Add("Ocultar Semana'" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText.Split(" ")(2) & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            'End If
            'Me.ContextMenuStrip1.Items.Add("Ocultar Columna '" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            'If columnasOcultas.Length > 0 Then
            '    For Each saux As String In columnasOcultas.Split(",")
            '        If saux.Length > 0 Then
            '            Me.ContextMenuStrip1.Items.Add("Mostrar Columna '" & saux & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            '        End If
            '    Next
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        Try
            If menuItem IsNot Nothing Then
                'Tell the user which menu item they just clicked.

                If menuItem.Text.ToLower.StartsWith("inmovi") Then
                    Me.dg_productos.Columns(Me.dg_productos.CurrentCell.ColumnIndex).Frozen = True
                    nfrozen = Me.dg_productos.CurrentCell.ColumnIndex
                ElseIf menuItem.Text.ToLower.StartsWith("movili") Then
                    For iaux As Integer = 1 To nfrozen
                        Me.dg_productos.Columns(iaux).Frozen = False
                    Next
                    'Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Frozen = False
                    'menuItem.Text.Replace("Filtrar ", " ")
                    'Dim nombre_supervisor As String = menuItem.Text.Replace("Filtrar ", "")
                    'MessageBox.Show("The " & nombre_supervisor & " item was just selected.")
                    '            ods.Tables("productos").DefaultView.RowFilter = filtro_actual & " and supervisor = '" & nombre_supervisor & "'"
                ElseIf menuItem.Text.ToLower.StartsWith("ver d") Then
                    mostrarDerivados()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMarca.SelectedIndexChanged
        Try
            Dim lsFiltro As String = "marca = '" & Me.cmbMarca.SelectedItem & "'"
            If Me.cmbMarca.SelectedItem.ToString.StartsWith("-T") Then lsFiltro = String.Empty
            ods.Tables("detalle_productos").DefaultView.RowFilter = lsFiltro.ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MenuAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAyuda.Click
        Dim ClsGen As New ClasesGenerales.General
        Try
            ClsGen.mostrarAyuda("Coberturas.pdf")

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        generarReporte()
    End Sub

    Private Sub chk_marcas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_marcas.SelectedIndexChanged

    End Sub
End Class