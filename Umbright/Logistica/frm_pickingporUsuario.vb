Public Class frm_pickingporUsuario
    Private ds_picking As New DataSet
    Dim prt As prtcom.Imprimir_Puerto
    'Dim prt As Object
    'Dim clsgen As New ClasesGenerales.General
    Private Sub btnBuscarPicking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPicking.Click
        Dim picker As String
        picker = cmbPickers.Text
        If (picker.Length > 20) Then
            picker = picker.Substring(0, 20)
        End If

        If Not tienepickingPendienteCerrar(picker) Then
            agregarFacturasAsignadas("pa_sel_um_documentos_picking_pendiente '" & picker & "'")
        End If

    End Sub

    Private Function tienepickingPendienteCerrar(ByVal sNombrePicker As String) As Boolean

        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lbtienepicking As Boolean = False

        Try
            lsSQL = "pa_var_um_gen_log_documento_tracking_picking_pendiente '" & sNombrePicker & "'"
            dt = clsgen.selectQuery("FlexLine", lsSQL)

            If dt.Rows.Count > 0 Then
                lbtienepicking = True
                MessageBox.Show("Tiene Picking Pendiente de Cerrar", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = dt
                clsgen.Alinear_GridView(dt, oform.dgv_resultado, "", "", "", "", "", "", "", True, True, 200, 0)
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing
            End If

        Catch ex As Exception
        Finally
            clsgen = Nothing
        End Try

        Return lbtienepicking
    End Function


    Private Sub agregarFacturasAsignadasTotal(ByVal ls_sql As String)

        Dim dr, draux As DataRow
        Dim dtAsignar, dtaux As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        estructuraFacturasAsignadas()
        dtAsignar = ds_picking.Tables("facturas_asignadas")
        dtAsignar.Columns.Add(New DataColumn("Picker", GetType(String)))
        Try
            otrans.open()
            dtaux = otrans.Obtiene(ls_sql)
            For Each dr In dtaux.Rows
                draux = dtAsignar.NewRow
                draux.Item("Imprimir") = False
                draux.Item("Lineas") = dr.Item("lineas")
                draux.Item("Empresa") = dr.Item("empresa")
                draux.Item("Tipo Cliente") = dr.Item("tipocliente")
                draux.Item("Nombre Cliente") = dr.Item("nombre_cliente")
                draux.Item("TipoDocto") = dr.Item("tipodocto")
                draux.Item("Factura") = dr.Item("factura")
                draux.Item("Bodega") = dr.Item("bodega")
                draux.Item("Ruta") = dr.Item("ruta")
                draux.Item("Lote") = dr.Item("lote")
                draux.Item("picker") = dr.Item("nombre_picking")
                draux.Item("Fecha Asignación") = dr.Item("fecha_asignacion_picking")
                draux.Item("Fecha factura") = dr.Item("fecha_factura")
                dtAsignar.Rows.Add(draux)
            Next
            dg_picking_sin_guia.DataSource = dtAsignar
            Dim clsgen As New ClasesGenerales.General
            clsgen.Alinear_GridView(dtAsignar, Me.dg_picking_sin_guia, "", ",imprimir,", ",Empresa,Tipo Cliente,Nombre Cliente,TipoDocto,Factura,Bodega,Ruta,Fecha Asignación,fecha factura,", "", "", ",Lineas=30,Lote=20,", "", False, True, 300, 40)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub agregarFacturasAsignadas(ByVal ls_sql As String)

        Dim dr, draux As DataRow
        Dim dtAsignar, dtaux As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        estructuraFacturasAsignadas()
        dtAsignar = ds_picking.Tables("facturas_asignadas")
        Try
            otrans.open()
            dtaux = otrans.Obtiene(ls_sql)
            For Each dr In dtaux.Rows
                draux = dtAsignar.NewRow
                draux.Item("Imprimir") = False
                draux.Item("Lineas") = dr.Item("lineas")
                draux.Item("Empresa") = dr.Item("empresa")
                draux.Item("Tipo Cliente") = dr.Item("tipocliente")
                draux.Item("Nombre Cliente") = dr.Item("nombre_cliente")
                draux.Item("TipoDocto") = dr.Item("tipodocto")
                draux.Item("Factura") = dr.Item("factura")
                draux.Item("Bodega") = dr.Item("bodega")
                draux.Item("Ruta") = dr.Item("ruta")
                draux.Item("Lote") = dr.Item("lote")
                draux.Item("Fecha Asignación") = dr.Item("fecha_asignacion_picking")
                draux.Item("Fecha factura") = dr.Item("fecha_factura")
                dtAsignar.Rows.Add(draux)
            Next
            dgPickingAsignado.DataSource = dtAsignar
            Dim clsgen As New ClasesGenerales.General
            clsgen.Alinear_GridView(dtAsignar, dgPickingAsignado, "", "", ",Empresa,Tipo Cliente,Nombre Cliente,TipoDocto,Factura,Bodega,Ruta,Fecha Asignación,fecha_factura,", "", False, True, 300, 40)
        Catch ex As Exception
        Finally
            otrans.close()
        End Try
    End Sub
    Private Sub estructuraFacturasAsignadas()

        Dim dt As New DataTable("facturas_asignadas")
        dt.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Lineas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre Cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Factura", GetType(String)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("Ruta", GetType(String)))
        dt.Columns.Add(New DataColumn("Lote", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Fecha Asignación", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha factura", GetType(DateTime)))
        Try
            ds_picking.Tables.Remove("facturas_asignadas")
        Catch ex As Exception

        End Try
        ds_picking.Tables.Add(dt.Copy)
    End Sub

    Private Sub Agregar_Re_Impresion(ByVal _pdt As DataTable)
        Dim dr, dr_aux As DataRow

        For Each dr In _pdt.Rows
            dr_aux = ds_picking.Tables("re_impresion").NewRow

            dr_aux.Item("imprimir") = False
            dr_aux.Item("lineas") = dr.Item("lineas")
            dr_aux.Item("empresa") = dr.Item("empresa")
            dr_aux.Item("tipo_cliente") = dr.Item("tipo_cliente")
            dr_aux.Item("nombre") = dr.Item("nombre_cliente")
            dr_aux.Item("area") = dr.Item("area")
            dr_aux.Item("serie") = dr.Item("TipoDocto")
            dr_aux.Item("factura") = dr.Item("numero")
            dr_aux.Item("bodega") = dr.Item("bodega")
            dr_aux.Item("fecha") = dr.Item("fechaUModif")
            dr_aux.Item("minutos") = dr.Item("minutos")
            dr_aux.Item("ruta_logistica") = dr.Item("ruta_logistica")
            dr_aux.Item("fecha_impresion") = dr.Item("fecha_impresion")
            dr_aux.Item("picker") = dr.Item("picker")
            dr_aux.Item("tipodocto") = dr.Item("tipodocto")
            dr_aux.Item("chequeo") = dr.Item("chequeo")
            dr_aux.Item("fecha factura") = dr.Item("fecha_factura")
            ds_picking.Tables("re_impresion").Rows.Add(dr_aux)
        Next


    End Sub

    Private Sub Colorear_Grid_reimpresion()

        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.Alinear_GridView(ds_picking.Tables("re_impresion"), Me.dgv_reimpresion, "", ",cod_empresa,serie,minutos,area,", ",,nombre,area,serie,factura,bodega,fecha,ruta_logistica,fecha_impresion,picker,tipodocto,", "", "", ",lineas=20,", "", True, True, 200, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

        'Dim tableStyle As New DataGridTableStyle
        'tableStyle.MappingName = "re_impresion"

        'For Each col As DataColumn In ds_picking.Tables("re_impresion").Columns
        '    If col.ColumnName.ToLower <> "imprimir" Then
        '        Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
        '        gridCol.MappingName = col.ColumnName                    Case "lineas"
        '        Select Case col.ColumnName.ToLower
        '            Case "cod_empresa", "serie", "minutos", "area"
        '                gridCol.Width = 0
        '            Case "fecha", "fecha_impresion"
        '                gridCol.Width = 95
        '            Case Else
        '                gridCol.Width = clGenerales.tamaño_maximo_campo(ds_picking.Tables("re_impresion"), " ", col.ColumnName, Me.dg_listado_pendientes, 200, 0)
        '        End Select
        '        gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")

        '        gridCol.NullText = ""
        '        tableStyle.GridColumnStyles.Add(gridCol)
        '    Else
        '        Dim mydatacol As New ClasesGenerales.DataGridCheckBox(col.ColumnName, 60, _
        '                                HorizontalAlignment.Center, _
        '                                False, "Imprimir", _
        '                                String.Empty, False, True, _
        '                                False, String.Empty)
        '        tableStyle.GridColumnStyles.Add(mydatacol)
        '    End If
        'Next
        'tableStyle.HeaderForeColor = Color.Black
        'tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        'tableStyle.GridLineColor = Color.LightGray
        'tableStyle.RowHeaderWidth = 5

        'Me.dg_reimpresion.TableStyles.Clear()
        'Me.dg_reimpresion.TableStyles.Add(tableStyle)
    End Sub

    Private Sub Llenar_Reimpresion()
        Dim ls_sql As String
        Dim dt, dt_aux As DataTable
        Dim dr As DataRow
        Dim clsgen As New ClasesGenerales.General

        'Dim otrans As New Transaccional.Conexion_mysql("OnBase")
        Dim otrans_sql As New Transaccional.Conexion("flexline")
        Try
            Me.dgv_reimpresion.DataSource = Nothing
            Try
                ds_picking.Tables("re_impresion").Rows.Clear()
            Catch ex As Exception
            End Try

            ' otrans.open()
            otrans_sql.open()
            ls_sql = "pa_sel_um_gen_tabcod null,'GEN_DOCTO_PICKING',null"
            dt_aux = otrans_sql.Obtiene(ls_sql)
            'otrans.close()

            For Each dr In dt_aux.Rows
                If dr.Item("texto").ToString.ToLower = gs_usuario.ToLower Or _
                    dr.Item("texto1").ToString.ToLower = gs_usuario.ToLower Or _
                    gi_tipo_usuario = 1 Then

                    ls_sql = "pa_var_um_facturas_picking_reimpresion '" & Me.dtp_fecha_inicio_reimpresion.Text & "','" & Me.dtp_fecha_final_reimpresion.Text & "','" & _
                                dr.Item("CODIGO") & "','" & dr.Item("empresa") & "'"

                    dt = otrans_sql.Obtiene(ls_sql)
                    Try
                        If dt.Rows.Count > 0 Then
                            Agregar_Re_Impresion(dt)
                        End If
                    Catch ex As Exception
                    End Try

                End If
            Next

            ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""
            ds_picking.Tables("re_impresion").DefaultView.Sort = "fecha_impresion desc"

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            '  otrans.close()
            ' otrans = Nothing
            otrans_sql.close()
            otrans_sql = Nothing

            clsgen = Nothing
            If ds_picking.Tables("re_impresion").Rows.Count > 0 Then
                Me.dgv_reimpresion.DataSource = ds_picking.Tables("re_impresion")
                Colorear_Grid_reimpresion()
            End If
        End Try
        Try
            Me.dgv_reimpresion.CurrentCell = Me.dgv_reimpresion.Rows(0).Cells(0)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnPrintTMU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTMU.Click
        'Asigna las fechas de impresión
        setPrintDate("TMU")
        'Refresca la Información de el DataGridView
        agregarFacturasAsignadas("pa_sel_um_documentos_picking_pendiente '" & cmbPickers.Text & "'")
    End Sub

    Private Sub setPrintDate(ByVal tipo As String)
        Dim empresa, tipodocto, factura, sql, nombrePicker, lssql As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ldfechagrupo As Date = Now

        Try
            otrans.open()

            For Each dr As DataGridViewRow In dgPickingAsignado.Rows
                If (Boolean.Parse(dr.Cells("imprimir").Value.ToString)) Then
                    empresa = dr.Cells("empresa").Value.ToString
                    tipodocto = dr.Cells("tipodocto").Value.ToString
                    factura = dr.Cells("factura").Value.ToString
                    'nombrePicker = cmbPickers.Text
                    'If (nombrePicker.Length > 20) Then
                    '    nombrePicker = nombrePicker.Substring(0, 20)
                    'End If


                    If (tipo.Equals("TMU")) Then
                        Imprimir_TMU(dr.Cells("empresa").Value.ToString, dr.Cells("tipodocto").Value.ToString, dr.Cells("factura").Value.ToString.PadLeft(10, "0"), False, False)
                    Else
                        Dim ncopias As Integer = 1
                        Try

                            If dr.Cells("lote").Value > 0 Then ncopias = 2
                        Catch ex As Exception
                        End Try
                        If imprimirLaser(dr.Cells("empresa").Value.ToString, dr.Cells("tipodocto").Value.ToString, dr.Cells("factura").Value.ToString.PadLeft(10, "0"), False, False, ncopias) Then
                            sql = "pa_upd_um_documento_tracking_asignacion_fecha_impresion '" & _
                            empresa & "','" & tipodocto & "','" & factura & "','" & ldfechagrupo.ToString("dd/MM/yyyy HH:mm") & "'"
                            otrans.Actualiza(sql)
                            otrans.Escribir_Log(sql)
                        End If


                    End If
                End If
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub
    Private Sub Imprimir_TMU(ByVal _Empresa As String, ByVal _TipoDocto As String, _
                ByVal _Numero As String, ByVal bEsReimpresion As Boolean, ByVal bCopia As Boolean)


        Dim ls_sql, spuntos As String
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cajas As Integer = 0
        Dim cajas_decimal As Double = 0
        Dim totalunidades As Integer = 0
        Dim totalunidades_decimal As Decimal = 0


        Dim cantidad_decimal As Double = 0


        Dim btienelote As Boolean = False

        spuntos = "  .  .  .  .  .  .  .  .  .  .  .  .  .  .  .  .  .  ."

        Try



            ls_sql = "pa_var_um_documento_picking '" & _Empresa & "','" & _TipoDocto & "','" & _Numero & "'"

            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            otrans.close()
            otrans = Nothing

            prt = New prtcom.Imprimir_Puerto

            If bCopia Then
                Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & "               -- COPIA --")
                Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0))
            End If


            Imprimir_TMU_Encabezado(dt)
            Imprimir_TMU_Linea(Chr(27))
            Imprimir_TMU_Linea(Chr(27))
            Imprimir_TMU_Linea("Codigo       Medida    Cajas   Unidades")

            For Each dr In dt.Rows

                cantidad_decimal = 0
                cajas_decimal = 0
                cajas = 0

                If dr.Item("unidadingreso").ToString.StartsWith("LIB") Or dr.Item("unidadingreso").ToString.StartsWith("KI") Then
                    If dr.Item("FactorAlt") = 0 Then
                        cajas_decimal = 0
                    Else
                        cajas_decimal = dr.Item("Cantidad") / dr.Item("FACTORALT")
                        cajas_decimal = Format(Convert.ToDecimal(cajas_decimal), "###,###,##0.00").ToString()
                        cantidad_decimal = Format(Convert.ToDecimal(dr.Item("cantidad").ToString), "###,###,##0.00").ToString()
                    End If

                Else

                    If dr.Item("FactorAlt") = 0 Then
                        cajas = 0
                    Else
                        cajas = dr.Item("Cantidad") / dr.Item("FACTORALT")
                    End If
                End If




                ls_sql = dr.Item("producto").ToString.PadRight(10) & "     " & _
                        Format(Convert.ToDecimal(dr.Item("volumen").ToString), "###,###,##0.00").ToString.PadRight(5) & " " & _
                        IIf(cajas > 0, cajas.ToString.PadLeft(7), cajas_decimal.ToString.PadLeft(7)) & " " & _
                IIf(cantidad_decimal > 0, Format(Convert.ToDecimal(cantidad_decimal.ToString), "###,###,##0.00").ToString.PadLeft(10), Format(Convert.ToDecimal(dr.Item("cantidad")), "###,###,##0").ToString.PadLeft(10))
                ' Format(Convert.ToDecimal(cantidad_decimal.ToString), "###,###,##0").ToString.PadLeft(10)

                'Format(Convert.ToDecimal(dr.Item("volumen").ToString), "###,###,##0.00").ToString.PadRight(5) & " " & _
                '      cajas.ToString.PadLeft(7) & " " & _
                '      Format(Convert.ToDecimal(dr.Item("cantidad").ToString), "###,###,##0").ToString.PadLeft(10)


                ' imprimeLineaNegraRoja(ls_sql)

                Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0) & ls_sql)

                If dr.Item("glosa").ToString.Length <= 40 Then
                    ls_sql = dr.Item("glosa").ToString.ToLower & spuntos
                    ls_sql = ls_sql.Substring(0, 40)
                Else
                    ls_sql = dr.Item("glosa").ToString.ToLower.PadRight(75).Substring(0, 75) & " "
                End If

                If ls_sql.Length > 40 Then
                    ls_sql = ls_sql.PadRight(75).Substring(0, 75) & " "



                End If

                Imprimir_TMU_Linea(ls_sql)

                If dr.Item("lote").ToString.Length > 0 And dr.Item("fechavcto").ToString.Length > 0 Then
                    ' si el trae lote y fechavcto
                    ls_sql = "Lote: " & dr.Item("lote").ToString.ToLower & "  FechaVcto.:" & Date.Parse(dr.Item("fechavcto").ToString).ToString("dd/MM/yyyy")
                ElseIf dr.Item("lote").ToString.Length > 0 And dr.Item("fechavcto").ToString.Length = 0 Then
                    ' solo trae lote
                    ls_sql = "Lote: " & dr.Item("lote").ToString.ToLower
                End If

                If ls_sql.Length <= 40 And ls_sql.Length > 0 And dr.Item("lote").ToString.Length > 0 Then
                    'ls_sql = ls_sql.PadRight(79).Substring(0, 79) & " "
                    'ls_sql = ls_sql.ToString.ToLower & spuntos
                    'ls_sql = ls_sql.Substring(0, 40)
                    Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & ls_sql)
                    Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0))
                    btienelote = True
                Else
                    Imprimir_TMU_Linea(Chr(27))
                End If
                If cantidad_decimal > 0 Then
                    totalunidades_decimal += Format(Convert.ToDecimal(dr.Item("cantidad")), "###,###,##0.00").ToString
                Else
                    totalunidades += dr.Item("cantidad")
                End If


            Next
            Imprimir_TMU_Linea(Chr(27))
            ' Imprimir_TMU_Linea("   ::. Puntos Acumulados .::  " & Me.lbl_total.Text)
            Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & "Total de Unidades .: " & IIf(totalunidades_decimal > 0, totalunidades_decimal.ToString, totalunidades.ToString))
            Imprimir_TMU_Linea(Chr(27))

            If dt.Rows(0).Item("tipocliente").ToString.Length > 0 Then
                Imprimir_TMU_Linea(dt.Rows(0).Item("tipocliente").ToString.ToUpper, True)
            End If

            Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0) & "Ruta   : " & dt.Rows(0).Item("analisisCtacte9").ToString)
            'Imprimir_TMU_Linea("Ruta   : " & dt.Rows(0).Item("analisisCtacte9").ToString & " " & Now.ToShortDateString & " " & Now.ToLongTimeString)
            Imprimir_TMU_Linea("Picker : " & dt.Rows(0).Item("nombre_picking").ToString)

            imprimir_TMU_finalizar()


        Catch ex As Exception
        Finally
            prt = Nothing

            If btienelote And bEsReimpresion = False Then
                Imprimir_TMU(_Empresa, _TipoDocto, _Numero, True, True)
            End If
        End Try

    End Sub
    Private Sub Imprimir_TMU_Encabezado(ByVal dt As DataTable)

        Dim dr As DataRow
        dr = dt.Rows(0)
        Dim linea As String = String.Empty
        If dr.Item("empresa").ToString.ToLower = "dmarte1" Then
            linea = "DISTRIBUIDORA MARTE, S.A."
        ElseIf dr.Item("empresa").ToString.ToLower = "codicasa" Then
            linea = "CODICASA"
        ElseIf dr.Item("empresa").ToString.ToLower = "alamsa" Then
            linea = "ALAMSA"
        ElseIf dr.Item("empresa").ToString.ToLower = "diuva" Then
            linea = "DISTRIBUIDORA LA UVA, S.A."
        ElseIf dr.Item("empresa").ToString.ToLower = "vinoteca" Then
            linea = "VINOTECA"
        End If
        Imprimir_TMU_Linea(linea, True)
        Imprimir_TMU_Linea(Chr(27) & "r" & Chr(1) & dr.Item("tipodocto").ToString & "-" & dr.Item("Numero").ToString)
        Imprimir_TMU_Linea(Chr(27) & "r" & Chr(0) & "Bodega     :" & dr.Item("Bodega").ToString)
        Imprimir_TMU_Linea(Chr(27))
        Imprimir_TMU_Linea("Fecha      :" & Date.Parse(dr.Item("Fecha").ToString).ToString("dd/MM/yyyy"))
        Imprimir_TMU_Linea("Cliente    :" & dr.Item("Cliente").ToString)
        Imprimir_TMU_Linea(IIf(dr.Item("Vigencia").ToString = "A", "****DOCUMENTO ANULADO", dr.Item("RazonSocial").ToString))
        Imprimir_TMU_Linea("Direccion  :" & dr.Item("Direccion").ToString)
        Imprimir_TMU_Linea(Chr(27))
        Imprimir_TMU_Linea("Comentario :" & dr.Item("Comentario1").ToString.Trim & " " & dr.Item("glosa_docto").ToString.Trim)
        Imprimir_TMU_Linea(Chr(27))
    End Sub
    Private Sub Imprimir_TMU_Linea(ByVal Cadena As String)

        Dim CadenaImprimir As String
        '        prt.Imprimir(Cadena, "COM1")   'Nombre empresa
        CadenaImprimir = Cadena.ToString.Replace("ñ", Chr(164)).Replace("ó", Chr(162)).Replace("é", Chr(130))
        prt.Imprimir(CadenaImprimir, "LPT1")

        Threading.Thread.Sleep(150)
    End Sub
    Private Sub imprimir_TMU_finalizar()
        'lpt1 en CD
        'com1 en cd
        'instalado el 20/06/2011
        prt.FinyCortar("LPT1")
    End Sub


    Private Function imprimirLaser(ByVal _Empresa As String, ByVal _TipoDocto As String, _
                ByVal _Numero As String, ByVal bEsReimpresion As Boolean, ByVal bCopia As Boolean, iNumeroCopias As Integer) As Boolean
        Dim path_reporte As String
        Dim nombre_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lbreturn As Boolean = False
        Try
            'Obtengo Datos de Conexion
            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte


            path_reporte += "Logistica\Picking\Picking Barra.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = _Empresa

            pm_parametros(1) = "@TipoDocto"
            pm_valores(1) = _TipoDocto

            pm_parametros(2) = "@Numero"
            pm_valores(2) = _Numero
            lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                           False, True, "PDF", True, "", True, 1)


            If iNumeroCopias = 2 Then
                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                           False, True, "PDF", True, "", True, 1)
            End If

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
        Return lbreturn
    End Function

    Private Sub btnPrintLaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLaser.Click
        setPrintDate("LASER")
        agregarFacturasAsignadas("pa_sel_um_documentos_picking_pendiente '" & cmbPickers.Text & "'")
    End Sub



    Private Sub Crear_Estructura()
        Dim dt As New DataTable("pendientes_impresion")

        dt.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("lineas", GetType(String)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("area", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("factura", GetType(String)))
        dt.Columns.Add(New DataColumn("bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("minutos", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ruta_logistica", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_impresion", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("picker", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("chequeo", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha factura", GetType(DateTime)))
        ds_picking.Tables.Add(dt.Copy)

        dt.TableName = "re_impresion"
        ds_picking.Tables.Add(dt.Copy)

    End Sub

    Private Sub frm_pickingporUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ClsGen As New ClasesGenerales.General
        Try
            clsgen.fillComboBox(otrans, "pa_sel_um_pickers_dia 'LUNES'", "pickers", "nombre_picker", "nombre_picker", cmbPickers)
            clsgen.fillComboBox(otrans, "pa_sel_um_pickers_dia 'LUNES'", "pickersConsolidado", "nombre_picker", "nombre_picker", cmbPickerConsolidado)
            Crear_Estructura()

        Catch ex As Exception

        Finally
            otrans = Nothing
            ClsGen = Nothing
        End Try
        'clsgen.fillComboBox(otrans, "pa_sel_um_pickers_dia '" & getDiaLetras() & "'", "pickers", "nombre_picker", "nombre_picker", cmbPickers)
    End Sub


    Public Sub Imprimir_TMU_Linea(ByVal Cadena As String, ByVal Centrar As Boolean)
        Dim diferencia As Integer
        Dim CadenaImprimir As String
        Dim MaxLen As Integer = 40
        If Centrar Then

            If Len(Cadena) < MaxLen Then
                diferencia = (MaxLen - Len(Cadena)) / 2
                If Len(Cadena) + (diferencia) * 2 > MaxLen Then
                    diferencia -= 1
                End If
                '  Cadena = Cadena.PadLeft(diferencia, Space(1))
                ' Cadena = Cadena.PadRight(diferencia - 1, Space(1))
            End If
        End If
        CadenaImprimir = Cadena.ToString.Replace("ñ", Chr(164)).Replace("ó", Chr(162)).Replace("é", Chr(130))
        prt.Imprimir(Space(diferencia) + CadenaImprimir, "LPT1")
        System.Threading.Thread.CurrentThread.Sleep(150)
    End Sub

    Private Sub btn_buscar_reimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_reimpresion.Click
        Try
            Me.Cursor.Current = Cursors.WaitCursor
            Me.btn_buscar_reimpresion.Enabled = False
            Llenar_Reimpresion()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
            Me.btn_buscar_reimpresion.Enabled = True

        End Try
    End Sub

    Private Sub BtnReimpresionPickign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresionPickign.Click
        Try

            ds_picking.Tables("re_impresion").DefaultView.RowFilter = "imprimir = True"

            For Each drv As DataRowView In ds_picking.Tables("re_impresion").DefaultView

                'Imprimir_TMU(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString.PadLeft(10, "0"), True, False)

                imprimirLaser(drv.Item("empresa"), drv.Item("tipodocto").ToString, drv.Item("factura").ToString, True, True, 1)
                'drv.Item("imprimir") = False
            Next

        Catch ex As Exception
        Finally
            'ds_picking.Tables("re_impresion").DefaultView.RowFilter = ""
        End Try


        Llenar_Reimpresion()
        'ImprimeFact()

    End Sub

    Private Sub dgPickingAsignado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPickingAsignado.CellContentClick

    End Sub

    Private Sub dgPickingAsignado_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgPickingAsignado.CellPainting

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgPickingAsignado.Rows(rowIndex)

                If Me.dgPickingAsignado.Item("ruta", rowIndex).Value.ToString.ToLower = "telemarketing" Then
                    Me.dgPickingAsignado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.DarkMagenta
                ElseIf Me.dgPickingAsignado.Item("Tipo Cliente", rowIndex).Value.ToString.ToLower = "on capital" Then
                    Me.dgPickingAsignado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        agregarFacturasAsignadasTotal("pa_sel_um_documentos_picking_pendiente null")
    End Sub

    Private Sub dg_picking_sin_guia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_picking_sin_guia.CellContentClick

    End Sub

    Private Sub dg_picking_sin_guia_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dg_picking_sin_guia.CellPainting

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dg_picking_sin_guia.Rows(rowIndex)

                If Me.dg_picking_sin_guia.Item("ruta", rowIndex).Value.ToString.ToLower = "telemarketing" Then
                    Me.dg_picking_sin_guia.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.DarkMagenta
                ElseIf Me.dg_picking_sin_guia.Item("Tipo Cliente", rowIndex).Value.ToString.ToLower = "on capital" Then
                    Me.dg_picking_sin_guia.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Chocolate
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_refrescarConsolidado_Click(sender As Object, e As EventArgs) Handles btn_refrescarConsolidado.Click
        listarConsolidables()
    End Sub


    Private Sub listarConsolidables()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            lsSQL = "pa_var_um_picking_para_consolidar"
            dt = ClsGen.selectQuery("FlexLine", lsSQL)
            Me.dgv_documentos_a_consolidar.DataSource = dt


            ClsGen.Alinear_GridView(dt, Me.dgv_documentos_a_consolidar, "", "", ",empresa,tipodocto,numero,fecha,ctacte,razonsocial,", "", True, True, 250, 0)



        Catch ex As Exception

        Finally
            ClsGen = Nothing
        End Try
    End Sub
    Private Sub btn_generar_lote_Click(sender As Object, e As EventArgs) Handles btn_generar_lote.Click
        If MessageBox.Show("Confirmacion", "Esta Seguro de Generar Lote", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim dt, dtCorrelativo As DataTable

            Dim clsGen As New ClasesGenerales.General
            Dim lsSQL As String

            Try
                dt = TryCast(Me.dgv_documentos_a_consolidar.DataSource, DataTable)
                dt.DefaultView.RowFilter = "Agregar = True"

                If dt.DefaultView.Count > 0 Then
                    lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_correlativo"
                    dtCorrelativo = clsGen.selectQuery("FlexLine", lsSQL)
                End If

                For Each drv As DataRowView In dt.DefaultView

                    '   If dr.Item("Agregar").ToString.ToLower.Equals("true") Then

                    lsSQL = "pa_ins_um_gen_log_documento_picking_consolidado '" & drv.Item("Empresa").ToString & "','" &
                            drv.Item("tipodocto").ToString & "','" &
                            drv.Item("numero").ToString & "','" &
                            gs_usuario & "','" &
                            Me.cmbPickerConsolidado.SelectedValue & "'," &
                    dtCorrelativo.Rows(0).Item("correlativo").ToString

                    clsGen.insertQuery("FlexLine", lsSQL)

                    '  End If
                Next

                '' Imprimir Pickign Consolidad



                Dim path_reporte As String
                Dim pm_valores(0) As String
                Dim pm_parametros(0) As String
                Dim pm_conexion(3) As String

                Dim lbreturn As Boolean = False
                Try
                    'Obtengo Datos de Conexion
                    pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
                    path_reporte = ClsGen.Path_Reporte


                    path_reporte += "Logistica\Picking\Picking On Trade Consolidado.rpt"

                    pm_parametros(0) = "@Identificador"
                    pm_valores(0) = dtCorrelativo.Rows(0).Item("correlativo").ToString

                    lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                   pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                   False, True, "PDF", True, "", True, 1)




                Catch ex As Exception
                Finally
                    ClsGen = Nothing
                End Try

                MessageBox.Show("Numero de Lote Generado " & dtCorrelativo.Rows(0).Item("correlativo").ToString, "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception

            Finally
                listarConsolidables()
            End Try

        End If
    End Sub

    Private Sub btn_refrescar_picking_consolidado_Click(sender As Object, e As EventArgs) Handles btn_refrescar_picking_consolidado.Click
        refrescarPickingConsolidado()
    End Sub

    Private Sub refrescarPickingConsolidado()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_lotes"
            dt = ClsGen.selectQuery("FlexLine", lsSQL)

            Me.dgvReimpresionPickingConsolidado.DataSource = dt

            ClsGen.Alinear_GridView(dt, Me.dgvReimpresionPickingConsolidado, "", "", ",lote,nombre_picking,fecha,doctos,", "", True, True, 250, 0)

        Catch ex As Exception

        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btnReimpresionConsolidado_Click(sender As Object, e As EventArgs) Handles btnReimpresionConsolidado.Click



        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General

        Try
            dt = TryCast(Me.dgvReimpresionPickingConsolidado.DataSource, DataTable)
            dt.DefaultView.RowFilter = "Agregar = True"

            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False

            If dt.DefaultView.Count > 0 Then
                For Each drv As DataRowView In dt.DefaultView


                    Try
                        'Obtengo Datos de Conexion
                        pm_conexion = clsgen.Parametros_Conexion("vDataServer")
                        path_reporte = clsgen.Path_Reporte


                        path_reporte += "Logistica\Picking\Picking On Trade Consolidado.rpt"

                        pm_parametros(0) = "@Identificador"
                        pm_valores(0) = drv.Item("lote").ToString

                        lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                       False, True, "PDF", True, "", True, 1)



                    Catch ex As Exception
                    Finally
                        clsgen = Nothing
                    End Try


                Next


            End If


        Catch ex As Exception

        Finally
            ClsGen = Nothing
        End Try
        refrescarPickingConsolidado()
    End Sub

    Private Sub reimprimir_picking_consolidado(piLote As Integer)

        Dim clsGen As New ClasesGenerales.General

        Try


            Dim path_reporte As String
            Dim pm_valores(0) As String
            Dim pm_parametros(0) As String
            Dim pm_conexion(3) As String

            Dim lbreturn As Boolean = False





            Try
                'Obtengo Datos de Conexion
                pm_conexion = clsgen.Parametros_Conexion("vDataServer")
                path_reporte = clsgen.Path_Reporte


                path_reporte += "Logistica\Picking\Picking On Trade Consolidado.rpt"

                pm_parametros(0) = "@Identificador"
                pm_valores(0) = piLote

                lbreturn = _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                       pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                       False, True, "PDF", True, "", True, 1)



            Catch ex As Exception
            Finally
                clsgen = Nothing
            End Try







        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub


    Private Sub btn_quitar_facturas_refrescar_Click(sender As Object, e As EventArgs) Handles btn_quitar_facturas_refrescar.Click
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_lotes_vigentes"
            dt = ClsGen.selectQuery("FlexLine", lsSQL)

            Me.dgv_quitar_facturas_lotes.DataSource = dt

            ClsGen.Alinear_GridView(dt, Me.dgv_quitar_facturas_lotes, "", "", ",lote,nombre_picking,fecha,doctos,", "", True, True, 250, 0)

        Catch ex As Exception

        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_quitar_facturas_lotes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_quitar_facturas_lotes.CellContentClick

    End Sub

    Private Sub dgv_quitar_facturas_lotes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_quitar_facturas_lotes.CellDoubleClick
        Dim nrow As Integer = Me.dgv_quitar_facturas_lotes.CurrentRow.Index

        Try
            Dim lsSQL As String
            Dim dt As DataTable

            'Otrans.open()
            'lsSQL = "pa_upd_um_documento_comentario2 '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("tipodocto", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("numero", nrow).Value & "','" & _
            '            Me.txtComentario2.Text & "','" & gs_usuario & "'"
            'Otrans.Actualiza(lsSQL)

            ''Verificar Stock

            llenar_quitar_facturas_asignadas_documentos(Me.dgv_quitar_facturas_lotes.Item("lote", nrow).Value)
            'lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_lotes_documentos " & Me.dgv_quitar_facturas_lotes.Item("lote", nrow).Value


            '            dt = clsgen.selectQuery("FlexLine", lsSQL)

            '            Me.dgv_quitar_facturas_asignadas.DataSource = dt

            '            clsgen.Alinear_GridView(dt, Me.dgv_quitar_facturas_asignadas, "", "", ",lote,nombre_picking,fecha,doctos,", "", True, True, 250, 0)



        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenar_quitar_facturas_asignadas_documentos(piLote As Integer)
        Dim clsGen As New ClasesGenerales.General

        Try
            Dim lsSQL As String
            Dim dt As DataTable

            'Otrans.open()
            'lsSQL = "pa_upd_um_documento_comentario2 '" & Me.dgv_encabezado.Item("empresa", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("tipodocto", nrow).Value & "','" & _
            '            Me.dgv_encabezado.Item("numero", nrow).Value & "','" & _
            '            Me.txtComentario2.Text & "','" & gs_usuario & "'"
            'Otrans.Actualiza(lsSQL)

            ''Verificar Stock


            lsSQL = "pa_var_um_gen_log_documento_picking_consolidado_lotes_documentos " & piLote


            dt = clsgen.selectQuery("FlexLine", lsSQL)

            Me.dgv_quitar_facturas_asignadas.DataSource = dt

            clsgen.Alinear_GridView(dt, Me.dgv_quitar_facturas_asignadas, "", "", ",lote,nombre_picking,fecha,doctos,", "", True, True, 250, 0)



        Catch ex As Exception

        Finally
            clsgen = Nothing
        End Try

    End Sub

    Private Sub btn_quitar_facturas_aplicar_Click(sender As Object, e As EventArgs) Handles btn_quitar_facturas_aplicar.Click

        Try
            Dim dt As DataTable
            Dim lsSQL As String
            Dim clsGEN As New ClasesGenerales.General
            dt = TryCast(Me.dgv_quitar_facturas_asignadas.DataSource, DataTable)
            dt.DefaultView.RowFilter = "quitar = True"


            If dt.DefaultView.Count > 0 Then

                If MessageBox.Show("Esta Seguro de Quitar Estos (" & dt.DefaultView.Count & ") Documentos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    For Each drv As DataRowView In dt.DefaultView

                        lsSQL = "pa_del_um_gen_log_docto_picking_consolidado " &
drv.Item("Lote") & ",'" &
drv.Item("empresa") & "','" &
drv.Item("tipodocto") & "','" &
drv.Item("numero") & "','" &
gs_usuario & "'"


                        clsGEN.insertQuery("FlexLine", lsSQL)
                    Next

                    llenar_quitar_facturas_asignadas_documentos(dt.DefaultView(0).Item("lote"))
                    reimprimir_picking_consolidado(dt.DefaultView(0).Item("lote"))
                Else
                    dt.DefaultView.RowFilter = ""
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_quitar_facturas_reimprimir_Click(sender As Object, e As EventArgs) Handles btn_quitar_facturas_reimprimir.Click



        Try
            Dim nrow As Integer = Me.dgv_quitar_facturas_lotes.CurrentRow.Index

            reimprimir_picking_consolidado(Me.dgv_quitar_facturas_lotes.Item("lote", nrow).Value)


        Catch ex As Exception

            End Try
    End Sub
End Class