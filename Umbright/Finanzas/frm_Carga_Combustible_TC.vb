Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Public Class frm_Carga_Combustible_TC
    Dim dt_Table, _dtlogdetalle As DataTable
    Dim encabezados_seleccionados As String = ""
    Dim _dtregistros, dt As New DataTable()
    Dim Nombre_Hoja As String = ""
    Dim dsConvierte As New DataSet
    Dim ds As New DataSet

    Dim dtCargaTeams As DataTable


    Private Sub frm_Carga_Combustible_TC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Estructura()
    End Sub

    Private Sub Estructura()
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NIT", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre_Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Galones", GetType(Double)))
        dt.Columns.Add(New DataColumn("Tipo_Combustible", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("CentroCosto", GetType(String)))
        dt.Columns.Add(New DataColumn("Item", GetType(String)))
        dt.Columns.Add(New DataColumn("Personal", GetType(String)))

        dt.TableName = "Cargac"

        If dsConvierte.Tables.Contains("Cargac") Then dsConvierte.Tables.Remove("Cargac")
        ds.Tables.Add(dt.Copy)

        dgv_Detalle.DataSource = dt

        dtCargaTeams = dt.Copy

    End Sub
    Private Sub btn_Carga_Archivo_Click(sender As Object, e As EventArgs) Handles btn_Carga_Archivo.Click
        Procesar_Excel()
    End Sub

    Public Function fImport(sPath As String, sExt As String) As DataTable
        Dim sCn As String = ""
        'llenar el dataset
        Dim ds As New DataSet()
        'Dim dt As New DataTable()

        Try
            Dim hoja As String = "Hoja1"
            Dim Conex As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=Excel 12.0;")

            Dim CmdOle As New OleDbCommand()

            CmdOle.Connection = Conex
            CmdOle.CommandType = CommandType.Text
            CmdOle.CommandText = "SELECT * FROM [" + Nombre_Hoja + "$A1:AI25000]"

            Dim AdaptadorOle As New OleDbDataAdapter(CmdOle.CommandText, Conex)

            AdaptadorOle.Fill(dt)
            '  dt.Columns.Add(New DataColumn("Empresa", GetType(Date)))
            dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
            dt.Columns.Add(New DataColumn("Serie", GetType(String)))
            dt.Columns.Add(New DataColumn("Numero", GetType(String)))
            dt.Columns.Add(New DataColumn("Nit", GetType(String)))
            dt.Columns.Add(New DataColumn("Nombre_Proveedor", GetType(String)))
            dt.Columns.Add(New DataColumn("Galones", GetType(Double)))
            dt.Columns.Add(New DataColumn("Tipo_Combustible", GetType(String)))
            dt.Columns.Add(New DataColumn("Monto", GetType(Double)))
            dt.Columns.Add(New DataColumn("CentroCosto", GetType(String)))
            dt.Columns.Add(New DataColumn("Item", GetType(String)))
            dt.Columns.Add(New DataColumn("Personal", GetType(String)))

            dt.PrimaryKey = New DataColumn() {dt_Table.Columns(0), dt_Table.Columns(2)}

            For Each dr As DataRow In dt.Rows
                If dr.Item("Fecha").ToString.Length = 0 Then
                    dr.Delete()
                End If
            Next

            dt.AcceptChanges()

            Me.dgv_Detalle.DataSource = dt

            _dtregistros = dt.Copy

            'llenar dataset con datos de Excel
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Dim clsgen As New ClasesGenerales.General
            clsgen.Escribir_Log(ex.ToString)
            clsgen.Escribir_Log(ex.Message)
            clsgen = Nothing
        End Try
        Return dt
    End Function

    Private Sub Procesar_Excel()
        Dim snombre_archivo As String
        Dim Oaut As New Automatizar.importar_excel()
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados(), encabezados_completo As String
        Dim icount As Integer

        Try
            Me.OpenFileDialog1.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"
            Me.OpenFileDialog1.FileName = ""
            Me.OpenFileDialog1.ShowDialog()

            snombre_archivo = Me.OpenFileDialog1.FileName
            Oaut.pNombreArchivo = snombre_archivo

            hojas_encabezados = Oaut.Obtener_Hojas
            If hojas_encabezados.Length > 1 Then
                Oaut2.Llenar_Combo_Vector(hojas_encabezados)
                Oaut2.Text = "Seleccion de Hoja"
                Oaut2.StartPosition = FormStartPosition.CenterParent
                Oaut2.ShowDialog()
                Oaut.pNombreHoja = Oaut2._selectedValue.ToString
                Nombre_Hoja = Oaut.pNombreHoja
                Oaut2 = Nothing
            Else
                Oaut.pNombreHoja = hojas_encabezados(0)
            End If

            Dim dt As DataTable = fImport(snombre_archivo, snombre_archivo.Split(".")(1))

            lb_registros.Text = dt.Rows.Count.ToString
            dgv_Detalle.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Oaut.Cerrar_libro()
            Oaut = Nothing
        End Try

    End Sub

    Private Sub btn_Convertir_Click(sender As Object, e As EventArgs) Handles btn_Convertir.Click
        Try
            If dtCargaTeams.Rows.Count > 0 Then


                If MessageBox.Show("Esta Seguro de Recibir Esta Liquidacion", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then



                    Convertir_a_Flexline()
                    Procesa_Umbral()
                    Carga2()
                    Carga3()


                    EnviarAviso()

                    MessageBox.Show("Proceso Finalizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    limpiarForma()

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub limpiarForma()
        Me.lblCorreo.Text = String.Empty
        Me.lblMonto.Text = String.Empty
        Me.lblNumeroLiquidacion.Text = String.Empty
        Me.lb_registros.Text = String.Empty
        dtCargaTeams.Rows.Clear()
        Me.dgvListado.DataSource = dtCargaTeams

    End Sub

    Private Sub EnviarAviso()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim lsLiquidaciones As String
        Dim lsCorreoAprobacion As String = String.Empty


        Try

            dt = clsGen.selectQuery("RegionalDBintOut", "pa_sel_um_liquidaciones_combustible_correlativo")
            lsLiquidaciones = dt.Rows(0).Item("numero").ToString
            Me.lblNumeroLiquidacion.Text = lsLiquidaciones


            lsSQL = "pa_sel_um_sg_usuario_simple '" & gs_usuario & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            If dt.Rows.Count > 0 Then
                lsCorreoAprobacion = dt.Rows(0).Item("cuenta_office").ToString
            End If


            dt = Me.dgv_Detalle.DataSource

            For Each dr As DataRow In dt.Rows

                lsSQL = "pa_upd_um_liquidaciones_combustible_liquidado '" &
                    Me.lblCorreo.Text & "','" &
                    dr.Item("Numero").ToString & "','" &
                    dr.Item("Serie").ToString & "','" &
                    Me.lblNumeroLiquidacion.Text & "','" &
                    gs_usuario & "','" &
                    lsCorreoAprobacion & "'"

                clsGen.insertQuery("RegionalDBintOut", lsSQL)

            Next




            lsSQL = "pa_ins_um_bot_avisos_teams '" &
                    "Liquidacion_Combustible_" & Me.lblNumeroLiquidacion.Text & "','" &
                    Me.lblCorreo.Text & "','UMBRIGHT','" &
                    "Recepcion de Liquidacion de Combustible No. " & Me.lblNumeroLiquidacion.Text & "','" &
                    "Nombre :" & dt.Rows(0).Item("Personal").ToString & "|" &
                    "No. de Doctos :" & Me.lb_registros.Text & "|" &
                    "Monto:" & Me.lblMonto.Text & "|" &
                    "Recibido Por :" & gs_nombre_usuario & "|"



            dt = clsGen.Fecha_Servidor("FlexLine")
            lsSQL = lsSQL & "Fecha :" & dt.Rows(0).Item("Fecha_Actual") & "'"
            clsGen.insertQuery("RegionalDBintOut", lsSQL)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Convertir_a_Flexline()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()
            dt = Me.dgv_Detalle.DataSource

            For Each dr As DataRowView In dt.DefaultView

                lsSQL = "pa_ins_um_Combustible_TC '" & dr.Item("Empresa").ToString & "','" & dr.Item("Fecha").ToString & "','" & dr.Item("Serie").ToString & "','" & dr.Item("Numero").ToString & "','" &
                dr.Item("NIT").ToString & "','" & dr.Item("Nombre_Proveedor").ToString & "','" & dr.Item("Galones").ToString & "','" & dr.Item("Tipo_Combustible").ToString & "','" & dr.Item("Monto").ToString & "','" &
                dr.Item("CentroCosto").ToString & "','" & dr.Item("Item").ToString & "','" & dr.Item("Personal").ToString & "','" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)

            Next

            dt.DefaultView.RowFilter = ""


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub Procesa_Umbral()
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("flexline")

        Try
            Otrans.open()

            lsSQL = "pa_ins_um_Carga_Combustible_Umbral '" & gs_empresa & "'"
            Otrans.Ingresa(lsSQL)

            '            MsgBox("Se han Convertido: " & lb_registros.Text & " Documentos a FlexLine", MsgBoxStyle.Information, "Verifique...")

            '  Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub btnObtenerTeams_Click(sender As Object, e As EventArgs)

        Dim clsGen As New ClasesGenerales.General

        Try

            Dim dt, dtLiquidacion, dtProveedores As DataTable
            Dim lsSQL As String
            Dim drAux As DataRow

            lsSQL = "pa_sel_um_liquidaciones_combustible"
            dtLiquidacion = clsGen.selectQuery("RegionalDBintOut", lsSQL)

            lsSQL = "pa_var_um_ctacte_traslado 'UMBRAL','PROVEEDOR'"
            dtProveedores = clsGen.selectQuery("FlexLine", lsSQL)



            'Me.dgv_Detalle.DataSource = dt

            For Each dr As DataRow In dtLiquidacion.Rows
                drAux = dtCargaTeams.NewRow
                drAux.Item("fecha") = dr.Item("fechafac")
                drAux.Item("Serie") = dr.Item("serie")
                drAux.Item("numero") = dr.Item("no_factura")
                drAux.Item("Nit") = dr.Item("Nit")
                drAux.Item("nombre_proveedor") = String.Empty
                drAux.Item("galones") = dr.Item("galones")
                drAux.Item("Tipo_Combustible") = dr.Item("tipo_combustible").ToString.Substring(0, 1).ToUpper
                drAux.Item("Monto") = dr.Item("total_factura")
                drAux.Item("CentroCosto") = String.Empty
                drAux.Item("Item") = String.Empty
                drAux.Item("Personal") = String.Empty



                Try
                    dtProveedores.DefaultView.RowFilter = "ctacte = '" & dr.Item("Nit").ToString.Substring(0, dr.Item("Nit").ToString.Trim.Length - 1) & "'"
                    If dtProveedores.DefaultView.Count > 0 Then
                        drAux.Item("nombre_proveedor") = dtProveedores.DefaultView(0).Item("razonsocial").ToString
                    End If
                Catch ex As Exception

                End Try


                Try
                    lsSQL = "pa_sel_um_sg_usuario_cuenta_office '" & dr.Item("correo").ToString & "'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        drAux.Item("Personal") = dt.Rows(0).Item("nombre").ToString
                    End If
                Catch ex As Exception

                End Try

                Try

                    lsSQL = "pa_sel_um_gen_tabcod '" & dt.Rows(0).Item("usuario").ToString & "','USUARIO.LIQUIDACION'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        drAux.Item("empresa") = dt.Rows(0).Item("empresa")
                        drAux.Item("Item") = dt.Rows(0).Item("texto1")
                        drAux.Item("CentroCosto") = dt.Rows(0).Item("texto")
                    End If
                Catch ex As Exception

                End Try

                dtCargaTeams.Rows.Add(drAux)
                Me.lblNumeroLiquidacion.Text = dr.Item("NoLiquidacion")
                Me.lblCorreo.Text = dr.Item("correo").ToString
            Next
            Me.dgv_Detalle.DataSource = dtCargaTeams
            clsGen.Alinear_GridView(dtCargaTeams, Me.dgv_Detalle, "", "", "", "", True, True, 250, 0)

            Me.lblMonto.Text = dtCargaTeams.Compute("sum(Monto)", "monto>0")
            Me.lb_registros.Text = dtCargaTeams.Rows.Count

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label2.Click

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsGen.selectQuery("RegionalDBintOut", "pa_sel_um_liquidaciones_combustible_pendiente")
            dgvListado.DataSource = dt
            clsGen.Alinear_GridView(dt, dgvListado, "", "", "", "", True, True, 100, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub dgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub Carga2()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("flexline")

        Try
            Otrans.open()
            dt = Me.dgv_Detalle.DataSource

            For Each dr As DataRowView In dt.DefaultView


                lsSQL = "pa_ins_um_Combustible_tc_umbral 'UMBRAL','" & dr.Item("Numero").ToString & "','" & dr.Item("NIT").ToString & "','" & dr.Item("Fecha").ToString & "'"
                Otrans.Obtiene(lsSQL)

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    Private Sub Carga3()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("flexline")

        Try
            Otrans.open()
            dt = Me.dgv_Detalle.DataSource


            For Each dr As DataRowView In dt.DefaultView

                lsSQL = "pa_ins_um_Combustible_tc '" & dr.Item("Empresa").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("NIT").ToString & "','" & dr.Item("Fecha").ToString & "'"
                Otrans.Obtiene(lsSQL)

            Next

            dt.DefaultView.RowFilter = ""

            MsgBox("Se han Convertido: " & lb_registros.Text & " Documentos a FlexLine", MsgBoxStyle.Information, "Verifique...")

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub



    Private Sub mostrarLiquidacionTeams(psCorreoLiquidacion As String, psPeriodo As String)

        Dim clsGen As New ClasesGenerales.General

        Try

            Dim dt, dtLiquidacion, dtProveedores As DataTable
            Dim lsSQL As String
            Dim drAux As DataRow

            lsSQL = "pa_sel_um_liquidaciones_combustible '" & psCorreoLiquidacion & "','" & psPeriodo & "'"
            dtLiquidacion = clsGen.selectQuery("RegionalDBintOut", lsSQL)

            lsSQL = "pa_var_um_ctacte_traslado 'UMBRAL','PROVEEDOR'"
            dtProveedores = clsGen.selectQuery("FlexLine", lsSQL)


            dtCargaTeams.Rows.Clear()
            'Me.dgv_Detalle.DataSource = dt

            For Each dr As DataRow In dtLiquidacion.Rows
                drAux = dtCargaTeams.NewRow
                drAux.Item("fecha") = dr.Item("fechafac")
                drAux.Item("Serie") = dr.Item("serie")
                drAux.Item("numero") = dr.Item("no_factura")
                drAux.Item("Nit") = dr.Item("Nit")
                drAux.Item("nombre_proveedor") = String.Empty
                drAux.Item("galones") = dr.Item("galones")
                drAux.Item("Tipo_Combustible") = dr.Item("tipo_combustible").ToString.Substring(0, 1).ToUpper
                drAux.Item("Monto") = dr.Item("total_factura")
                drAux.Item("CentroCosto") = String.Empty
                drAux.Item("Item") = String.Empty
                drAux.Item("Personal") = String.Empty



                Try
                    dtProveedores.DefaultView.RowFilter = "ctacte = '" & dr.Item("Nit").ToString.Substring(0, dr.Item("Nit").ToString.Trim.Length - 1) & "'"
                    If dtProveedores.DefaultView.Count > 0 Then
                        drAux.Item("nombre_proveedor") = dtProveedores.DefaultView(0).Item("razonsocial").ToString
                        drAux.Item("nit") = dtProveedores.DefaultView(0).Item("codlegal").ToString
                    Else
                        '(c) Debo Crear el Proveedor
                        lsSQL = "pa_um_pwa_sel_fel_documento_compras_nit '" & dr.Item("proveedor").ToString & "'"
                        dt = clsGen.selectQuery("RegionalDBintOut", lsSQL)
                        If dt.Rows.Count = 1 Then
                            With dt.Rows(0)
                                If .Item("pdf_link").ToString.Length > 20 Then
                                    Dim lsnuevoctate = .Item("nitEmisor").ToString.Substring(0, .Item("nitEmisor").ToString.Trim.Length - 1)
                                    dr.Item("razonsocial") = "*Nuevo* " & .Item("RazonEmisor").ToString
                                    dr.Item("codigo") = lsnuevoctate
                                    dr.Item("proveedor") = lsnuevoctate
                                    'crearProveedor(dt)

                                Else
                                    dr.Item("razonsocial") = "**** Mal Ingresado---"
                                End If
                            End With

                        End If
                    End If
                Catch ex As Exception

                End Try


                Try
                    lsSQL = "pa_sel_um_sg_usuario_cuenta_office '" & dr.Item("correo").ToString & "'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        drAux.Item("Personal") = dt.Rows(0).Item("nombre").ToString
                    End If
                Catch ex As Exception

                End Try

                Try

                    lsSQL = "pa_sel_um_gen_tabcod '" & dt.Rows(0).Item("usuario").ToString & "','USUARIO.LIQUIDACION'"
                    dt = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt.Rows.Count > 0 Then
                        drAux.Item("empresa") = dt.Rows(0).Item("empresa").ToString
                        drAux.Item("Item") = dt.Rows(0).Item("texto1").ToString
                        drAux.Item("CentroCosto") = dt.Rows(0).Item("texto").ToString
                        drAux.Item("Personal") = dt.Rows(0).Item("descripcion").ToString
                    End If
                Catch ex As Exception

                End Try

                dtCargaTeams.Rows.Add(drAux)
                'Me.lblNumeroLiquidacion.Text = dr.Item("NoLiquidacion")
                Me.lblCorreo.Text = dr.Item("correo").ToString
            Next
            Me.dgv_Detalle.DataSource = dtCargaTeams
            clsGen.Alinear_GridView(dtCargaTeams, Me.dgv_Detalle, "", "", "", "", True, True, 250, 0)

            Me.lblMonto.Text = dtCargaTeams.Compute("sum(Monto)", "monto>0")
            Me.lb_registros.Text = dtCargaTeams.Rows.Count

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub crearProveedor(pdt As DataTable)
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow = pdt.Rows(0)
        Try



            Dim lsnuevoctate = dr.Item("nitEmisor").ToString.Substring(0, dr.Item("nitEmisor").ToString.Trim.Length - 1)
            If lsnuevoctate.ToString.Length > 10 Then 'Es DPI
                lsnuevoctate = dr.Item("nitEmisor").ToString
            End If

            lsSQL = "pa_ins_um_ctacte_tipoctacte '" &
                        dr.Item("empresa").ToString & "','PROVEEDOR','" &
                        lsnuevoctate & "','" &
                        dr.Item("nitEmisor").ToString & "','" &
                        dr.Item("RazonEmisor").ToString & "','CREDITO 30 DIAS','','" &
                        dr.Item("municipioEmisor").ToString & " " & dr.Item("departamentoEmisor").ToString & "','" &
                        dr.Item("municipioEmisor").ToString & "','" & dr.Item("departamentoEmisor").ToString & "','GUATEMALA','" &
                        "','','','','root'"


            clsGen.insertQuery("Flexline", lsSQL)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub



    Private Sub dgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        mostrarLiquidacionTeams(dgvListado.Item("correo", e.RowIndex).Value.ToString, dgvListado.Item("periodo", e.RowIndex).Value.ToString)
        Me.TabControl1.SelectedTab = Me.TabPage1

    End Sub
End Class