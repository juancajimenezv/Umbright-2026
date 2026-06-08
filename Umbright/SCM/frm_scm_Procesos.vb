Public Class frm_SCM_Procesos

    Dim dtProveedores As New DataTable
    Dim psemanaActual As Integer = DatePart(DateInterval.WeekOfYear, Today, FirstDayOfWeek.Monday)
    Private Sub crearEstructura()

        Try
            dtProveedores.Columns.Add(New DataColumn("agregar", GetType(Boolean)))
            dtProveedores.Columns.Add(New DataColumn("proveedor", GetType(String)))
            dtProveedores.Columns.Add(New DataColumn("empresa", GetType(String)))

        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenarEmpresas()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            otrans.open()
            ls_sql = "bdflexline..pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_empresa.DataSource = dt
            Me.cmb_empresa.DisplayMember = "empresa"
            Me.cmb_empresa.ValueMember = "empresa"
            Me.cmb_empresa.SelectedValue = gs_empresa

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub llenarProveedores()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim draux As DataRow

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_prv_proveedor '" & Me.cmb_empresa.SelectedValue.ToString & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt = clsGen.ValoresDistinto(dt, "proveedor".Split(","))
            dtProveedores.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                draux = dtProveedores.NewRow
                draux.Item("agregar") = False
                draux.Item("Empresa") = Me.cmb_empresa.SelectedValue.ToString
                draux.Item("proveedor") = dr.Item("proveedor")
                dtProveedores.Rows.Add(draux)


            Next

            Me.DataGridView1.DataSource = dtProveedores
            clsGen.Alinear_GridView(dtProveedores, Me.DataGridView1, "", ",empresa,", ",proveedor,", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub generarInformacion(ByVal psProveedor As String, ByVal psEmpresa As String)
        Dim ds_preparacion As New DataSet
        Dim ls_sql As String
        Dim iaux As Integer
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim oCompras As New Compras.SCM(ds_preparacion)
        Dim clsGen As New ClasesGenerales.General



        Try
            Otrans.open()


            oCompras = New Compras.SCM(ds_preparacion)
            oCompras.Crear_Estructura()
            oCompras.Empresa = psEmpresa

            '            If Me.chk_generar_region.CheckState = CheckState.Checked Then oCompras.Region = Me.cmb_region.Text
            '           If Me.chk_generar_individual.CheckState = CheckState.Checked Then oCompras.SetOrigen(cmb_origen.Text)



            oCompras.SetProductoLimite(IIf(psEmpresa = "ALAMSA", "0090000000", "0060000000"))

            oCompras.Proveedor = psproveedor

            '            If Me.chk_generar_puerto.CheckState = CheckState.Checked Then oCompras.Puerto = Me.cmb_puerto.Text


            'oCompras.Inicializar_Productos(Me.chk_generar_global.Checked, Me.chk_generar_region.Checked, Me.chk_generar_individual.Checked, True)
            oCompras.Inicializar_Productos(False, False, False, True)
            oCompras.Revisar_productoDerivados("detalle_productos")


            'Dim dtunicos As DataTable = clsGen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            'For Each dr_aux In dtunicos.Rows

            '    ''Existencia CD
            '    '  Me.chk_existencias_cd.Checked = True

            '    '       ls_sql = "pa_var_um_existencias_producto '" & dr_aux.Item("empresa") & "','" & _
            '    '                  dr_aux.Item("proveedor") & "'," & _
            '    '                 "NULL" & _
            '    '                  ",'CD_CENTRAL','" & IIf(dr_aux.Item("empresa") = "ALAMSA", "0090000000", "0060000000") & "'"


            '    ls_sql = "pa_var_um_existencias_producto '" & dr_aux.Item("empresa") & "','" & _
            '                dr_aux.Item("proveedor") & "'," & _
            '                "NULL" & _
            '                  ",NULL,'" & IIf(dr_aux.Item("empresa") = "ALAMSA", "0090000000", "0060000000") & "'"

            '    dt = Otrans.Obtiene(ls_sql)
            '    dt.DefaultView.RowFilter = "bodega = 'CD_CENTRAL'"

            '    For Each drv2 As DataRowView In dt.DefaultView
            '        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & drv2.Item("producto") & "' and proveedor = '" & drv2.Item("proveedor") & "'"
            '        For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '            Try
            '                iaux = drv2.Item("Existencia") / drv.Item("uxc")
            '            Catch ex As Exception
            '                iaux = 0
            '            End Try
            '            drv.Item("cd_cajas") = iaux
            '            drv.Item("existencia") += drv.Item("cd_cajas")
            '        Next


            '        ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & drv2.Item("empresa") & "' and " & _
            '                    "producto = '" & drv2.Item("producto") & "'"
            '        If ds_preparacion.Tables("derivados").DefaultView.Count > 0 Then
            '            For Each drvaux As DataRowView In ds_preparacion.Tables("derivados").DefaultView
            '                Try
            '                    drvaux.Item("existencia") = drv2.Item("Existencia") '(c) solo se mostraran unidades * drvaux("unidades")) / drv.Item("uxc")
            '                Catch ex As Exception

            '                End Try

            '                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                            = "producto = '" & drvaux.Item("producto_padre") & "' and empresa = '" & drvaux.Item("empresa") & "'"

            '                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '                    Try
            '                        iaux = (drv2.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
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
            '    ' Me.chk_existencias_cd.Checked = True

            '    'ls_sql = "pa_var_um_existencias_producto '" & dr_aux.Item("empresa") & "','" & _
            '    '         dr_aux.Item("proveedor") & "',NULL" & _
            '    '         ",'CDX_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            '    ''IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL") & _
            '    'dt = Otrans.Obtiene(ls_sql)
            '    dt.DefaultView.RowFilter = "bodega = 'CDX_CENTRAL'"

            '    For Each drv2 As DataRowView In dt.DefaultView
            '        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & drv2.Item("producto") & "' and proveedor = '" & drv2.Item("proveedor") & "'"
            '        For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '            Try
            '                iaux = drv2.Item("Existencia") / drv.Item("uxc")
            '            Catch ex As Exception
            '                iaux = 0
            '            End Try
            '            drv.Item("cdx_cajas") = iaux
            '            drv.Item("existencia") += drv.Item("cdx_cajas")
            '        Next


            '        ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & drv2.Item("empresa") & "' and " & _
            '                    "producto = '" & drv2.Item("producto") & "'"
            '        If ds_preparacion.Tables("derivados").DefaultView.Count > 0 Then
            '            For Each drvaux As DataRowView In ds_preparacion.Tables("derivados").DefaultView


            '                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                            = "producto = '" & drvaux.Item("producto_padre") & "' and empresa = '" & drvaux.Item("empresa") & "'"

            '                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '                    Try
            '                        iaux = (drv2.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
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
            '    ' Me.chk_existencias_da.Checked = True

            '    'ls_sql = "pa_var_um_existencias_producto '" & dr_aux.Item("empresa") & "','" & _
            '    '         dr_aux.Item("proveedor") & "',NULL" & _
            '    '        ",'DA_CENTRAL','" & IIf(gs_empresa = "ALAMSA", "0090000000", "0060000000") & "'"
            '    'dt = Otrans.Obtiene(ls_sql)

            '    dt.DefaultView.RowFilter = "bodega = 'DA_CENTRAL'"

            '    For Each drv2 As DataRowView In dt.DefaultView
            '        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & drv2.Item("producto") & "' and proveedor = '" & drv2.Item("proveedor") & "'"
            '        For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '            drv.Item("da_cajas") = drv2.Item("Existencia") / drv.Item("uxc")
            '            drv.Item("existencia") += drv.Item("da_cajas")
            '        Next
            '    Next


            '    dt.Columns.Add(New DataColumn("cajas", GetType(Double)))

            '    'Existencias de Bodegas Restantes
            '    dt.DefaultView.RowFilter = "bodega <> 'CDX_CENTRAL' and bodega <> 'CD_CENTRAL' and bodega <> 'DA_CENTRAL'"

            '    For Each drv2 As DataRowView In dt.DefaultView
            '        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                        = "producto = '" & drv2.Item("producto") & "' and proveedor = '" & drv2.Item("proveedor") & "'"
            '        For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '            Try
            '                iaux = drv2.Item("Existencia") / drv.Item("uxc")
            '            Catch ex As Exception
            '                iaux = 0
            '            End Try
            '            drv.Item("bodegas") += iaux
            '            drv2.Item("cajas") = iaux
            '            'drv.Item("existencia") += drv.Item("cdx_cajas")
            '        Next


            '        ds_preparacion.Tables("derivados").DefaultView.RowFilter = "empresa = '" & drv2.Item("empresa") & "' and " & _
            '                    "producto = '" & drv2.Item("producto") & "'"
            '        If ds_preparacion.Tables("derivados").DefaultView.Count > 0 Then
            '            For Each drvaux As DataRowView In ds_preparacion.Tables("derivados").DefaultView


            '                ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                            = "producto = '" & drvaux.Item("producto_padre") & "' and empresa = '" & drvaux.Item("empresa") & "'"

            '                For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '                    Try
            '                        iaux = (drv2.Item("Existencia") * drvaux("unidades")) / drv.Item("uxc")
            '                    Catch ex As Exception
            '                        iaux = 0
            '                    End Try
            '                    drv.Item("bodegas") += iaux
            '                    drv2.Item("cajas") = iaux
            '                    'drv.Item("existencia") += iaux
            '                Next

            '            Next
            '        End If
            '    Next

            '    dt.TableName = "existencias"
            '    dt.DefaultView.ToTable.Copy()
            '    ds_preparacion.Tables.Add(dt.DefaultView.ToTable.Copy())

            'Next 'Principal
            ''producto en internacion
            'dtunicos = clsGen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa".Split(","))

            'For Each dr_aux In dtunicos.Rows

            '    ls_sql = "pa_var_um_producto_transito_internacion '" & dr_aux.Item("empresa") & "'"
            '    dt = Otrans.Obtiene(ls_sql)

            '    For Each dr In dt.Rows
            '        ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
            '                           = "producto = '" & dr.Item("producto") & "' and empresa = '" & dr.Item("empresa") & "'"
            '        For Each drv In ds_preparacion.Tables("detalle_productos").DefaultView
            '            Try
            '                iaux = dr.Item("cantidad") / drv.Item("uxc")
            '            Catch ex As Exception
            '                iaux = 0
            '            End Try
            '            drv.Item("internacion") = iaux
            '            drv.Item("existencia") += drv.Item("internacion")
            '        Next

            '    Next
            'Next


            ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter = ""
            oCompras.generarExistencia(True, False)
            oCompras.generarTransitos(psemanaActual, "", False)
            oCompras.generarPresupuestos(psemanaActual, "", False)
        Catch ex As Exception
        Finally


            oCompras = Nothing


            ''Generando Transitos
            'Generar_Transitos(ds_preparacion)

            ''Generando Presupuestos
            'Generar_Presupuestos(ds_preparacion)
            'Generar_Pedido_Sugerido(ds_preparacion)
            Generar_Precios(ds_preparacion)


            Dim snombre As String
            Dim berror As Boolean = False

            Dim ds As New DataSet("calculo")



            Try

                ds.Tables.Add(ds_preparacion.Tables("detalle_productos").Copy)
                ds.Tables.Add(ds_preparacion.Tables("derivados").Copy)
                ds.Tables.Add(ds_preparacion.Tables("existencias").Copy)
                ds.Tables.Add(ds_preparacion.Tables("transitos").Copy)

                snombre = Me.TextBox1.Text & "_" & psProveedor '& "_" '' & Today.ToString("ddMMyyyy") '(c) se quito 2907 por solicitud de OB

                If snombre.Length > 0 Then
                    ds.WriteXml("\\" & clsGen.Obtener_XMLConfig("Servidor_Alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\compras$\" & snombre.Trim & ".xml", XmlWriteMode.WriteSchema)
                    ls_sql = "pa_ins_um_inv_pedido_encabezado '" & psEmpresa & "','" & snombre & "','" & gs_usuario & "','',''," & Me.NupSemanasReorden.Value.ToString & ",0"
                    Otrans.Ingresa(ls_sql)
                End If

            Catch ex As Exception
            Finally
                clsGen = Nothing
                Otrans.close()
                Otrans = Nothing
            End Try



            'Otrans.close()
            'Otrans = Nothing

        End Try

      
    End Sub




    Private Sub Generar_Precios(ByRef ds_preparacion As DataSet)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim clsgen As New ClasesGenerales.General

        Dim ls_sql As String


        Try
            otrans.open()

            ls_sql = "pa_sel_um_scm_parametros_generales"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "scm_parametros_generales"
            ds_preparacion.Tables.Add(dt.Copy)

            Dim dtunicos As DataTable = clsgen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa".Split(","))

            For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_sel_um_listaprecioD '" & dr_aux.Item("empresa") & "',NULL,'" & _
                        ds_preparacion.Tables("scm_parametros_generales").Rows(0).Item("lista_precio").ToString & "'"


                dt = otrans.Obtiene(ls_sql)
                For Each dr In dt.Rows
                    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                        = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"

                    If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)

                        'If dr.Item("meses_diferencia") <= 0 + pi_meses_adicionales Then
                        drv.Item("fob") = dr.Item("valor") * drv.Item("uxc")
                        'Else

                        '  ls_mes = "transito+" & (dr.Item("meses_diferencia") + pi_meses_adicionales).ToString.PadLeft(2, "0")
                        ' drv.Item(ls_mes) = drv.Item(ls_mes) + dr.Item("cajas_pedidas")
                    End If
                    'End If
                Next
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Generar_Transitos(ByRef ds_preparacion As DataSet)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim otrans As New Transaccional.Conexion("scm")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql, ls_mes As String
        Dim nsemana As String
        Dim ntotalSemanas As Integer
        Dim ntransito As Integer

        Try
            otrans.open()
            Dim dtunicos As DataTable = ClsGen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            For Each dr_aux As DataRow In dtunicos.Rows

                ls_sql = "pa_var_um_transito_productos '" & dr_aux.Item("empresa") & "','" & _
                         dr_aux.Item("proveedor") & "',NULL"

                dt = otrans.Obtiene(ls_sql)
                For Each dr In dt.Rows
                    If dr.Item("producto") = "0010101018" Then
                        dr.Item("producto") = "0010101018"
                    End If

                    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                    = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"

                    If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)


                        If dr.Item("semana") < psemanaActual And DateTime.Parse(dr.Item("fecha_vencimiento").ToString).Year = Today.Year Then
                            nsemana = 0
                        Else
                            nsemana = dr.Item("semana") - psemanaActual
                        End If
                        If DateTime.Parse(dr.Item("fecha_vencimiento").ToString).Year = Today.Year Then
                            ntotalSemanas = DatePart(DateInterval.WeekOfYear, Date.Parse("01/01/" & Today.Year + 1).AddDays(-1), FirstDayOfWeek.Monday)
                        Else
                            ntotalSemanas = 52
                        End If



                        If nsemana < 0 Then nsemana += ntotalSemanas
                        ls_mes = "transito"
                        If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")

                        ntransito = IIf(dr.Item("CantidadArriboPuerto") Is System.DBNull.Value, dr.Item("cajas_pedidas"), dr.Item("cantidadArriboPuerto"))
                        drv.Item(ls_mes) += ntransito
                    End If
                Next

                dt.TableName = "transitos"
                ds_preparacion.Tables.Add(dt.Copy)
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    ''Generar Presupuestos, pendiente validar que se incluya mes actual
    Private Sub Generar_Presupuestos(ByRef ds_preparacion As DataSet)
        Dim ls_sql, ls_mes As String
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("umbral")
        Dim clsGen As New ClasesGenerales.General
        Dim nsemana As Integer

        Try
            otrans.open()
            Dim dtunicos As DataTable = clsGen.ValoresDistinto(ds_preparacion.Tables("detalle_productos"), "empresa,proveedor".Split(","))

            For Each dr_aux In dtunicos.Rows


                ls_sql = "pa_sel_um_producto_presupuesto 0, '" & dr_aux.Item("empresa") & "','" & _
                         dr_aux.Item("proveedor") & "',NULL"
                'IIf(Me.chk_generar_individual.Checked = True, "'" & Me.cmb_origen.Text & "'", "NULL")
                dt = otrans.Obtiene(ls_sql)

                For Each dr In dt.Rows
                    ds_preparacion.Tables("detalle_productos").DefaultView.RowFilter _
                                    = "producto = '" & dr.Item("producto") & "' and proveedor = '" & dr.Item("proveedor") & "'"


                    If ds_preparacion.Tables("detalle_productos").DefaultView.Count > 0 Then
                        drv = ds_preparacion.Tables("detalle_productos").DefaultView(0)

                        nsemana = dr.Item("semana") - psemanaActual

                        If nsemana < 0 Then nsemana += 52

                        ls_mes = "ppto"
                        If nsemana > 0 Then ls_mes += "+" + nsemana.ToString.PadLeft(2, "00")
                        drv.Item(ls_mes) += dr.Item("ppto_semanal")

                    End If
                Next
            Next


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try


    End Sub


    Private Sub Generar_Pedido_Sugerido(ByRef ds_preparacion)
        'Dim nSemanasReorden As Integer = 4
        Dim oCompras As New Compras.SCM(ds_preparacion)
        Try
            'Me.chk_saldos.Checked = True
            oCompras.Generar_SaldosyCoberturas(False)

            For iaux As Integer = 0 To Me.NupSemanasReorden.Value - 1 ' nSemanasReorden
                'Me.chk_minimos.Checked = True
                oCompras.Minimos_Maximos(iaux, IIf(iaux = 0, True, False))
                ''Generando Saldos
                'Me.chk_saldos.Checked = True

                oCompras.Generar_Pedido_Sugerido(iaux, IIf(iaux = 0, True, False))

            Next



        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try

    End Sub

    Private Sub frm_SCM_Procesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarEmpresas()
        llenarProveedores()
    End Sub


    Private Sub cmb_empresa_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectionChangeCommitted
        llenarProveedores()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If Me.TextBox1.Text.Length > 0 Then
            Me.Cursor.Current = Cursors.WaitCursor
            dtProveedores.DefaultView.RowFilter = "agregar = true"

            For Each drv As DataRowView In dtProveedores.DefaultView
                generarInformacion(drv.Item("proveedor"), Me.cmb_empresa.SelectedValue)
            Next
            dtProveedores.DefaultView.RowFilter = ""
            Me.Cursor.Current = Cursors.Default
            MessageBox.Show("Proceso Finalizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Debe Agregar Nombre Para el Calculo", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class