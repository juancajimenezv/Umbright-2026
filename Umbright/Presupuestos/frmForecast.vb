Imports ZedGraph
Imports System.Text
Imports Microsoft.Office.Interop
Public Class frmForecast
    Dim Ods As DataSet
    Dim mExcel As Excel.Application
    Dim libro As Excel.Workbook
    Dim hoja As Excel.Worksheet
    Dim pronostico(35) As Double
    Dim nfrozen As Integer = 0

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
            ls_sql = " select distinct SubFamilia as codigo from Producto where empresa='" & gs_empresa & "'  and validastock = 's' and vigente = 's' order by 1 "
            dt = Otrans.Obtiene(ls_sql)

            Me.chk_marcas.DataSource = dt
            Me.chk_marcas.ValueMember = "CODIGO"


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub


    Private Sub crearEstructura()
        Ods = New DataSet
        Dim dt As New DataTable
        Dim sname As String
        Dim icount As Integer

        dt.TableName = "ventasMensual"
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Marca", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("uxc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("pareto", GetType(String)))
        dt.Columns.Add(New DataColumn("agregar", GetType(Boolean)))

        For icount = 1 To 37
            sname = "venta_" & icount.ToString.PadLeft(2, "0")
            dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        Next
        For icount = 1 To 12
            sname = "ppto_" & icount.ToString.PadLeft(2, "0")
            dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        Next
        dt.Columns.Add(New DataColumn("alpha", GetType(Double)))
        dt.Columns.Add(New DataColumn("beta", GetType(Double)))
        dt.Columns.Add(New DataColumn("gamma", GetType(Double)))
        'dt.Columns.Add(New DataColumn("total", GetType(Integer)))

        dt.Columns.Add(New DataColumn("mad", GetType(Double)))
        dt.Columns.Add(New DataColumn("mape", GetType(Double)))
        dt.Columns.Add(New DataColumn("ts", GetType(Double)))


        Ods.Tables.Add(dt.Copy)
        'dt.TableName = "resumen_ppto_mensual"
        'Ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub generarInformacion()

        Dim dt, dtproductos As DataTable
        Dim draux As DataRow

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsfechafinal, lsfechainicio As String
        Dim sfechaperiodo, scampo As String
        Dim oCompras As New Compras.SCM(Ods)

        lsfechainicio = "01/" & Today.AddMonths(-25).Month.ToString.PadLeft(2, "0") & "/" & Today.AddMonths(-25).Year
        lsfechafinal = "01/" & Today.Month & "/" & Today.Year

        Try

            Otrans.open()
            Dim lproveedor As String = String.Empty
            For ii As Integer = 0 To chk_marcas.Items.Count - 1

                If Me.chk_marcas.GetItemChecked(ii) Then
                    lproveedor += "," & Me.chk_marcas.Items(ii)("codigo")
                End If
            Next

            lsSQL = "pa_var_um_ventas_24 '" & gs_empresa & "','" & lsfechainicio & "','" & Date.Parse(lsfechafinal).AddDays(-1).ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(lsSQL)


            dtproductos = ClsGen.ValoresDistinto(dt, "producto".Split(","))

            For Each dr As DataRow In dtproductos.Rows
                If dr.Item("producto") = "0044540001" Then
                    dr.Item("producto") = "0044540001"
                End If
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "'"
                If lproveedor.ToLower.IndexOf(dt.DefaultView(0)("subfamilia").ToString.ToLower) > 0 Then


                    draux = Ods.Tables("ventasMensual").NewRow
                    draux.Item("empresa") = gs_empresa
                    draux.Item("proveedor") = dt.DefaultView(0)("subfamilia")
                    draux.Item("marca") = dt.DefaultView(0)("tipo")
                    draux.Item("producto") = dt.DefaultView(0)("producto")
                    draux.Item("glosa") = dt.DefaultView(0)("glosa")
                    draux.Item("pareto") = dt.DefaultView(0)("pareto")
                    draux.Item("uxc") = dt.DefaultView(0)("uxc")

                    For Each drv As DataRowView In dt.DefaultView
                        Try

                            sfechaperiodo = "01/" + drv.Item("periodo").ToString.Substring(4) + "/" + drv.Item("periodo").ToString.Substring(0, 4)
                            'MessageBox.Show(drv.Item("periodo"))
                            scampo = "venta_" & DateDiff(DateInterval.Month, Date.Parse(sfechaperiodo), Date.Parse(lsfechafinal)).ToString.PadLeft(2, "0")
                            draux.Item(scampo) = drv.Item("unidades")
                        Catch ex As Exception
                        End Try
                    Next

                    draux.Item("alpha") = 0.1
                    draux.Item("beta") = 0.1
                    draux.Item("gamma") = 0.1
                    draux.Item("agregar") = False
                    Ods.Tables("ventasMensual").Rows.Add(draux)
                End If
            Next
            oCompras.Empresa = gs_empresa
            oCompras.Revisar_productoDerivados("ventasMensual")

            dt = Ods.Tables("ventasMensual").Copy
            dt.Rows.Clear()

            For Each dr As DataRow In Ods.Tables("ventasMensual").Rows
                If dr.Item("producto") = "0044540001" Then
                    dr.Item("producto") = "0044540001"
                End If

                Ods.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and " & _
                          "producto = '" & dr.Item("producto") & "'"

                If Ods.Tables("derivados").DefaultView.Count = 0 Then
                    draux = dt.NewRow
                    For Each dc As DataColumn In dt.Columns
                        draux.Item(dc.ColumnName) = dr.Item(dc.ColumnName)
                    Next
                    dt.Rows.Add(draux)
                End If
            Next

            For Each dr As DataRow In Ods.Tables("ventasMensual").Rows
                If dr.Item("producto") = "0044540001" Then
                    dr.Item("producto") = "0044540001"
                End If

                Ods.Tables("derivados").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and " & _
                          "producto = '" & dr.Item("producto") & "'"

                If Ods.Tables("derivados").DefaultView.Count > 0 Then
                    dt.DefaultView.RowFilter = "producto = '" & Ods.Tables("derivados").DefaultView(0)("producto_padre") & "'"
                    If dt.DefaultView.Count > 0 Then
                        With dt.DefaultView(0)
                            For icount As Integer = 1 To 25
                                Try
                                    .Item("venta_" & icount.ToString.PadLeft(2, "0")) = .Item("venta_" & icount.ToString.PadLeft(2, "0")) + (dr.Item("venta_" & icount.ToString.PadLeft(2, "0")) * Ods.Tables("derivados").DefaultView(0).Item("unidades"))
                                Catch ex As Exception
                                End Try
                            Next
                        End With



                    End If
                End If
            Next



            dt.TableName = "ventasMensual"
            Ods.Tables.Remove("ventasMensual")
            Ods.Tables.Add(dt.Copy)
            Ods.Tables("ventasMensual").DefaultView.RowFilter = ""
            Me.dgv_productos.DataSource = Ods.Tables("ventasMensual")

            dt = ClsGen.ValoresDistinto(Ods.Tables("ventasMensual"), "marca".Split(","))

            If dt.Rows.Count > 1 Then
                Me.lblMarca.Visible = True
                Me.cmbMarca.Visible = True
                cmbMarca.Items.Clear()
                cmbMarca.Items.Add("-TODOS-")
                For Each dr As DataRow In dt.Rows
                    cmbMarca.Items.Add(dr.Item("marca"))
                Next

            Else
                Me.lblMarca.Visible = False
                Me.cmbMarca.Visible = False
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            oCompras = Nothing
        End Try
        alinearGrid()
    End Sub

    Private Sub enviarExcel()
        mExcel = New Excel.Application
        Dim iCount As Integer
        Dim myRange As String()
        myRange = ",GY,GZ,HA,HB,HC,HD,HE,HF,HG,HH,HI,HJ".Split(",")
        Dim ClsGen As New ClasesGenerales.General

        libro = mExcel.Workbooks.Open("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & Clsgen.Obtener_XMLConfig("ubicacion", False), False) & "\tools$\Pruebas\Forecast.xls")
        hoja = libro.Sheets.Item("Detalle")
        Dim iaux As Integer

        Ods.Tables("ventasMensual").DefaultView.Sort = "producto"
        iCount = 3
        Dim smes As String
        For iaux = 24 To 1 Step -1
            smes = hoja.Cells(iCount, 27 - iaux).value
            smes = Today.AddMonths(iaux * -1).ToString("yyyyMM")
            hoja.Cells(iCount, 27 - iaux) = "'" & smes
        Next

        For Each drv As DataRowView In Ods.Tables("ventasMensual").DefaultView
            iCount += 1
            hoja.Cells(iCount, 1) = drv.Item("producto")
            hoja.Cells(iCount, 2) = drv.Item("glosa")
            For iaux = 24 To 1 Step -1
                hoja.Cells(iCount, 27 - iaux) = drv.Item("venta_" & iaux.ToString.PadLeft(2, "0"))
            Next

            For iaux = 1 To 12
                drv.Item("ppto_" & iaux.ToString.PadLeft(2, "0")) = hoja.Range(myRange(iaux) & iCount).Value
            Next

            drv.Item("MAD") = hoja.Range("HK" & iCount).Value
            drv.Item("MAPE") = hoja.Range("HL" & iCount).Value
            drv.Item("TS") = hoja.Range("HM" & iCount).Value
        Next



        ClsGen = Nothing
    End Sub

    Private Sub graficar(ByVal demanda() As Double, ByVal periodos() As String)

        Dim myPane As GraphPane = zgc1.GraphPane
        myPane.CurveList.Clear()
        ' Set the titles and axis labels
        myPane.Title.Text = Me.dgv_productos.Item("glosa", Me.dgv_productos.CurrentCell.RowIndex).Value
        '    Dim ncol As Integer = Me.DataGridView1.CurrentCell.ColumnIndex


        'myPane.XAxis.Title.Text = "X Value"
        myPane.YAxis.Title.Text = "Unidades"

        '' Make up some data points from the Sine function
        'Dim list = New PointPairList()
        'Dim x As Double, y As Double
        'For x = 0 To 36
        '    y = Math.Sin(x * Math.PI / 15.0)

        '    list.Add(x, y)
        'Next x

        '        // Add a curve to the graph
        'LineItem curve;
        'curve = myPane.AddCurve( "Total Sales", null, y5, Color.Black, SymbolType.Circle );
        '// Associate the curve with the Y2 axis
        'curve.IsY2Axis = true;
        'curve.Line.Width = 1.5F;
        '// Make the symbols solid red
        'curve.Line.Color = Color.Red;
        'curve.Symbol.Fill = new Fill( Color.Red );
        'myPane.Y2Axis.Title.FontSpec.FontColor = Color.Red;
        'curve.Symbol.Size = 8;

        Dim xx() As Double
        ' Generate a blue curve with circle symbols, and "My Crve 2" in the legend
        Dim myCurve As LineItem = myPane.AddCurve("Demanda", xx, demanda, Color.Brown, SymbolType.None)
        myCurve.Line.Width = 2

        myCurve = myPane.AddCurve("Pronostico", xx, pronostico, Color.Blue, SymbolType.None)
        myCurve.Line.Width = 2

        myPane.XAxis.Title.Text = "Periodos"
        myPane.XAxis.Type = AxisType.Text
        myPane.XAxis.Scale.Align = AlignP.Center
        myPane.XAxis.Scale.FontSpec.Angle = 90


        myPane.XAxis.Scale.TextLabels = periodos
       
        ' Calculate the Axis Scale Ranges
        zgc1.AxisChange()
        zgc1.Refresh()

    End Sub

    Private Sub alinearGrid()
        Dim clsGen As New ClasesGenerales.General

        Try

            clsGen.Alinear_GridView(Ods.Tables("ventasMensual"), Me.dgv_productos, "", ",empresa,proveedor,alpha,beta,gamma,", "", "", ",pareto=categoria,", "", "", True, True, 250, 0)

            Dim ffont As Font
            ffont = New Font(dgv_productos.DefaultCellStyle.Font.FontFamily, 7.5)

            For Each dc As DataGridViewColumn In Me.dgv_productos.Columns
                dc.ReadOnly = True
                dc.DefaultCellStyle.Font = font
                If dc.Name.ToLower.StartsWith("venta") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("ppto") Then
                    dc.DefaultCellStyle.Format = "n0"
                    dc.HeaderText = Today.AddMonths(dc.Name.Substring(dc.Name.IndexOf("_") + 1, 2) - 1).ToString("yyyyMM")
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    dc.Width = 50
                End If
                If dc.Name.ToLower.StartsWith("agrega") Then
                    dc.ReadOnly = False
                End If
                If dc.Name.ToLower.StartsWith("pare") Or dc.Name.ToLower.StartsWith("uxc") Then
                    dc.Width = 30
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mostrarProducto()

        Dim demanda(23) As Double

        Dim periodos(35) As String
        Dim myRange As String()
        myRange = ",GY,GZ,HA,HB,HC,HD,HE,HF,HG,HH,HI,HJ".Split(",")

        'libro = mExcel.Workbooks.Open("C:\temp\Forecast.xls")
        hoja = libro.Sheets.Item("Individual")
        Dim nrow As Integer = Me.dgv_productos.CurrentCell.RowIndex
        '    Dim ncol As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
        hoja.Range("D1").Value = Me.dgv_productos.Item("producto", nrow).Value

        Me.nupalpha.Value = Me.dgv_productos.Item("alpha", nrow).Value
        Me.nupbeta.Value = Me.dgv_productos.Item("beta", nrow).Value
        Me.nupgama.Value = Me.dgv_productos.Item("gamma", nrow).Value




        For icount As Integer = 1 To 36
            If icount < 25 Then demanda(icount - 1) = hoja.Cells(5 + icount, 3).value

            pronostico(icount - 1) = hoja.Cells(5 + icount, 9).value
            periodos(icount - 1) = hoja.Cells(5 + icount, 1).value
            If icount > 24 Then periodos(icount - 1) = Today.AddMonths(icount - 25).ToString("yyyyMM")
        Next
        ' ReDim demanda(23)

        graficar(demanda, periodos)

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

    Private Sub frmForecast_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            libro.Close(False)
            libro = Nothing
            hoja = Nothing
            mExcel = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub exportarVistaActual()
        Dim Oaut As New Automatizar.exportar_excel
        Dim socultar_columnas As New StringBuilder
        Try


            Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}, {4, 2}}

            Oaut.Nombre_Columnas = ",,,,,,,,,,,,,,,,"

            For Each dc As DataGridViewColumn In Me.dgv_productos.Columns
                If Not dc.Visible Then socultar_columnas.Append("," & dc.Name.ToLower)
            Next
            socultar_columnas.Append(",")
            Oaut.ocultar_columnas = socultar_columnas.ToString

            Oaut.nAgregar_Filas = 2
            Oaut.DataTableToExcel(Ods.Tables("ventasMensual").DefaultView.ToTable)

        Catch ex As Exception
        Finally
            Oaut = Nothing

        End Try

    End Sub

    Private Sub mostrarDerivados()
        Dim oform As New frm_resultado
        Dim clsGen As New ClasesGenerales.General

        Try
            oform.Text = "Productos Derivados de " + dgv_productos.Item("producto", Me.dgv_productos.CurrentRow.Index).Value + "--" + dgv_productos.Item("glosa", Me.dgv_productos.CurrentRow.Index).Value

            'dt.DefaultView.Sort = "periodo DESC"
            Ods.Tables("derivados").DefaultView.RowFilter = "producto_padre = '" & dgv_productos.Item("producto", Me.dgv_productos.CurrentRow.Index).Value & "'"
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
    Private Sub frmForecast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarLista()
    End Sub


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_productos.CellMouseDoubleClick
        mostrarProducto()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupalpha.ValueChanged

        Try
            Dim nrow As Integer = Me.dgv_productos.CurrentCell.RowIndex

            hoja = libro.Sheets.Item("Individual")


            Me.dgv_productos.Item("alpha", nrow).Value = nupalpha.Value
            hoja.Range("AA1").Value = nupalpha.Value * 100

            Dim myPane As GraphPane = zgc1.GraphPane

            For icount As Integer = 1 To 36
                'If icount < 25 Then demanda(icount - 1) = hoja.Cells(5 + icount, 3).value
                pronostico(icount - 1) = hoja.Cells(5 + icount, 9).value
                myPane.CurveList(1).Points(icount - 1).Y = hoja.Cells(5 + icount, 9).value
                If icount > 24 Then
                    Me.dgv_productos.Item("ppto_" & (icount - 24).ToString.PadLeft(2, "0"), nrow).Value = hoja.Cells(5 + icount, 9).value
                End If
            Next

            zgc1.Refresh()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub nupbeta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupbeta.ValueChanged

        Try
            Dim nrow As Integer = Me.dgv_productos.CurrentCell.RowIndex
            hoja = libro.Sheets.Item("Individual")

            Me.dgv_productos.Item("beta", nrow).Value = nupbeta.Value
            hoja.Range("AC1").Value = nupbeta.Value * 100
            ' mExcel.Visible = True
            Dim myPane As GraphPane = zgc1.GraphPane

            For icount As Integer = 1 To 36
                'If icount < 25 Then demanda(icount - 1) = hoja.Cells(5 + icount, 3).value
                pronostico(icount - 1) = hoja.Cells(5 + icount, 9).value
                myPane.CurveList(1).Points(icount - 1).Y = hoja.Cells(5 + icount, 9).value
                If icount > 24 Then
                    Me.dgv_productos.Item("ppto_" & (icount - 24).ToString.PadLeft(2, "0"), nrow).Value = hoja.Cells(5 + icount, 9).value
                End If
            Next

            zgc1.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub nupgama_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupgama.ValueChanged

        Try
            Dim nrow As Integer = Me.dgv_productos.CurrentCell.RowIndex
            hoja = libro.Sheets.Item("Individual")

            Me.dgv_productos.Item("gamma", nrow).Value = nupgama.Value
            hoja.Range("AA1").Value = nupgama.Value * 100

            Dim myPane As GraphPane = zgc1.GraphPane

            For icount As Integer = 1 To 36
                'If icount < 25 Then demanda(icount - 1) = hoja.Cells(5 + icount, 3).value
                pronostico(icount - 1) = hoja.Cells(5 + icount, 9).value
                myPane.CurveList(1).Points(icount - 1).Y = hoja.Cells(5 + icount, 9).value
                If icount > 24 Then
                    Me.dgv_productos.Item("ppto_" & (icount - 24).ToString.PadLeft(2, "0"), nrow).Value = hoja.Cells(5 + icount, 9).value
                End If
            Next

            zgc1.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        crearEstructura()
        generarInformacion()
        enviarExcel()
    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMarca.SelectedIndexChanged
        Try
            Dim lsFiltro As String = "marca = '" & Me.cmbMarca.SelectedItem & "'"
            If Me.cmbMarca.SelectedItem.ToString.StartsWith("-T") Then lsFiltro = String.Empty
            Ods.Tables("ventasMensual").DefaultView.RowFilter = lsFiltro.ToString

        Catch ex As Exception

        End Try

    End Sub

    
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        exportarVistaActual()
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Me.ContextMenuStrip1.Items.Clear()
        Try
            Me.ContextMenuStrip1.Items.Add("Inmovilizar Paneles '" & Me.dgv_productos.Columns(Me.dgv_productos.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Movilizar Paneles ", Nothing, AddressOf ToolStripMenuItem_Click)

            Dim nrow As Integer = Me.dgv_productos.CurrentRow.Index
            If Me.dgv_productos.Item("glosa", nrow).Value.ToString.StartsWith("**") Then
                Me.ContextMenuStrip1.Items.Add("Ver Derivados ", Nothing, AddressOf ToolStripMenuItem_Click)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        Try
            If menuItem IsNot Nothing Then
                'Tell the user which menu item they just clicked.

                If menuItem.Text.ToLower.StartsWith("inmovi") Then
                    Me.dgv_productos.Columns(Me.dgv_productos.CurrentCell.ColumnIndex).Frozen = True
                    nfrozen = Me.dgv_productos.CurrentCell.ColumnIndex
                ElseIf menuItem.Text.ToLower.StartsWith("movili") Then
                    For iaux As Integer = 1 To nfrozen
                        Me.dgv_productos.Columns(iaux).Frozen = False
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

    Private Sub dgv_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos.CellContentClick

    End Sub

    Private Sub dgv_productos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_productos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_productos.Rows(rowIndex)

                'If dg_productos.Columns(colIndex).Name.ToLower = "cobertura" Then
                If Me.dgv_productos.Item("agregar", rowIndex).Value = True Then
                    Me.dgv_productos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    Me.dgv_productos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If
            End If

        Catch ex As Exception

        End Try
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
End Class