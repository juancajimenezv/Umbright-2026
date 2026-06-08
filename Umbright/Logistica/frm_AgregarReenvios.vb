Public Class frm_AgregarReenvios
    Dim ds_guia As DataSet

    Private Sub Crear_Estructura()
        ds_guia = New DataSet
        Dim dt As New DataTable("detalle_guia")

        dt.Columns.Add(New DataColumn("picker", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_docto", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("comentario_factura", GetType(String)))
        dt.Columns.Add(New DataColumn("distancia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("motivo_reenvio", GetType(String)))
        '47391075
        ds_guia.Tables.Add(dt.Copy)
    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()



        ls_sql = "pa_sel_um_gen_parametros_sistema"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        tipos_doctos = ldt_table.Rows(0).Item("documentos_control_transporte").ToString.Split(",")
        Me.cmb_tipos.Items.AddRange(tipos_doctos)


        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "empresa"

        Me.cmbEmpresa.DisplayMember = "descripcion"
        Me.cmbEmpresa.ValueMember = "descripcion"
        Me.cmbEmpresa.DataSource = ldt_table


        oTransaccion.close()
        oTransaccion = Nothing
    End Sub

    Private Sub Colorear_Grid()
        Dim clsGen As New ClasesGenerales.General
        Me.dg_detalle_guia.DataSource = ds_guia.Tables("detalle_guia")
        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "detalle_guia"


        For Each col As DataColumn In ds_guia.Tables("detalle_guia").Columns

            Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
            gridCol.MappingName = col.ColumnName

            Select Case col.ColumnName.ToLower
                Case "picker"
                    gridCol.Width = 0
                Case "monto", "peso"
                    gridCol.Format = "n"
                    gridCol.Alignment = HorizontalAlignment.Right
                Case Else
                    gridCol.Width = clsGen.tamaño_maximo_campo(ds_guia.Tables("detalle_guia"), " ", col.ColumnName, Me.dg_detalle_guia, 200, 0)
            End Select

            gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
            gridCol.NullText = ""
            AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
            tableStyle.GridColumnStyles.Add(gridCol)
        Next

        tableStyle.RowHeaderWidth = 5
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray

        Me.dg_detalle_guia.TableStyles.Clear()
        Me.dg_detalle_guia.TableStyles.Add(tableStyle)
    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value2 As String

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value2 = data("picker").ToString

            If value2.Trim.ToLower = "sin picker" Then
                e.RowColor = Color.Red
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub buscarControl()
        'Private Sub Mostrar_registro(ByVal prownumber As Integer, ByVal pnumero As String)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView

        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General


        Try
            Me.txtNumeroControl.Text = Me.txtNumeroControl.Text.PadLeft(10, "0")
            otrans.open()
            ds_guia.Tables("detalle_guia").Rows.Clear()

            ls_sql = "pa_var_um_documento_control_transporte_recepcion 'CONTROL DE TRANSPORTE',Null,'" & Me.txtNumeroControl.Text.PadLeft(10, "0") & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Me.txtNumeroControl.Enabled = False
                With dt.Rows(0)
                    'ds_guia.Tables("pendientes_aprobacion").DefaultView.RowFilter = "numero = '" & Me.dg_controles_pendientes.Item(prownumber, 2) & "'"
                    'drv = ds_guia.Tables("pendientes_aprobacion").DefaultView(0)
                    Me.txtRuta.Text = .Item("ruta")
                    Me.txtVehicuo.Text = .Item("vehiculo")
                    Me.txtPiloto.Text = .Item("piloto")
                    Me.txtAyudante.Text = .Item("auxiliar")

                    Me.dtp_fecha_vcto.Value = .Item("vencimiento_guia")
                    Me.dtp_fecha_control.Value = .Item("fecha_guia")
                End With



                dt = clsGen.ValoresDistinto(dt, "empresa".Split(","))

                dt.TableName = "empresas_control"
                If ds_guia.Tables.Contains("empresas_control") Then
                    ds_guia.Tables.Remove("empresas_control")
                End If
                ds_guia.Tables.Add(dt.Copy)
                Me.dgvEmpresas.DataSource = dt

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            'Colorear_Grid()
            'Recalcular_Totales(ds_guia.Tables("detalle_guia"))

        End Try

    End Sub


    Private Sub Buscar_Factura()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dr, dr_aux As DataRow

        otrans.open()

        Try


            If Me.cmb_tipos.Text.ToString.ToLower.StartsWith("devolu") Then

                ls_sql = "pa_sel_um_devolucion '" & Me.cmbEmpresa.SelectedValue & "'," & Me.txt_numero.Text
                dt = otrans.Obtiene(ls_sql)
                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                Else
                    If Es_Unico("detalle_guia", ds_guia.Tables("detalle_guia"), "numero", Me.txt_numero.Text) Then

                        Dim lsMotivo As String = InputBox("Por Que Motivo es Reenvio?", "Motivo")
                        If lsMotivo.Trim.Length > 10 Then




                            dr = dt.Rows(0)
                            dr_aux = ds_guia.Tables("detalle_guia").NewRow
                            dr_aux.Item("tipo_docto") = "Devolucion"
                            dr_aux.Item("numero") = dr.Item("correlativo")
                            dr_aux.Item("nombre") = dr.Item("nombre_cliente")
                            dr_aux.Item("monto") = 0 'dr.Item("total")
                            dr_aux.Item("peso") = 0 'dr.Item("peso")
                            dr_aux.Item("picker") = "" 'dr.Item("picker")
                            dr_aux.Item("comentario_factura") = dr.Item("comentarios")
                            'dr_aux.Item("distancia") = Me.txtDistancia.Text
                            dr_aux.Item("empresa") = Me.cmbEmpresa.SelectedValue
                            dr_aux.Item("motivo_reenvio") = lsMotivo
                            ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)


                            Colorear_Grid()
                            'Recalcular_Totales(ds_guia.Tables("detalle_guia"))
                            Me.dg_detalle_guia.CurrentRowIndex = ds_guia.Tables("detalle_guia").Rows.Count - 1
                        End If
                    Else
                        MessageBox.Show("Numero ya Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else ''Es Otro Tipo de Documento diferente a Devolucion
                Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")
                ls_sql = "pa_var_um_documento_control_transporte '" & Me.cmbEmpresa.SelectedValue & "','" & _
                                Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"

                dt = otrans.Obtiene(ls_sql)

                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                Else
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("porcentajeAsignado") > 0 Or _
                            dt.Rows(0).Item("numero_temporal").ToString.Trim.Length > 0 Then
                            MessageBox.Show("Factura Asignada En Otro Control " & _
                            IIf(dt.Rows(0).Item("numero_temporal").ToString.Trim.Length > 0, " Temporal No. " & dt.Rows(0).Item("numero_temporal").ToString, " "), _
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        Else
                            'Verificar Picker
                            If dt.Rows(0).Item("picker").ToString = "SIN PICKER" Then
                                MessageBox.Show("Esta Factura No ha Sido Pickeada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                            End If

                            If dt.Rows(0).Item("area_despacho").ToString.Length > 0 Then
                                If dt.Rows(0).Item("NroImprimir") = 0 Then
                                    MessageBox.Show("Esta Factura No ha Sido Impresa, No se puede agregar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    Exit Try
                                End If
                            End If

                            If Es_Unico("detalle_guia", ds_guia.Tables("detalle_guia"), "numero", Me.txt_numero.Text) Then


                                '(c) debe valir que haya existido en otro control

                                Dim dtReenvio As DataTable

                                ls_sql = "pa_sel_um_gen_log_guia_liquidador '" & Me.cmbEmpresa.SelectedValue & "','" & _
                                Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"
                                dtReenvio = otrans.Obtiene(ls_sql)


                                If dtReenvio.Rows.Count > 0 Then
                                    dr = dt.Rows(0)
                                    Try
                                        If Val(dr.Item("distancia").ToString) > 0 Then
                                            'Me.txtDistancia.Text = dr.Item("distancia")
                                        End If

                                    Catch ex As Exception
                                    End Try

                                    dr_aux = ds_guia.Tables("detalle_guia").NewRow
                                    dr_aux.Item("tipo_docto") = dr.Item("tipodocto")
                                    dr_aux.Item("numero") = dr.Item("numero")
                                    dr_aux.Item("nombre") = dr.Item("nombre_cliente")
                                    dr_aux.Item("monto") = dr.Item("total")
                                    dr_aux.Item("peso") = dr.Item("peso")
                                    dr_aux.Item("picker") = dr.Item("picker")
                                    dr_aux.Item("comentario_factura") = dr.Item("comentario1")
                                    'Try
                                    '    dr_aux.Item("distancia") = Val(Me.txtDistancia.Text)
                                    'Catch ex As Exception

                                    'End Try

                                    dr_aux.Item("empresa") = Me.cmbEmpresa.SelectedValue

                                    ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)
                                    Colorear_Grid()
                                    'Recalcular_Totales(ds_guia.Tables("detalle_guia"))

                                    Me.dg_detalle_guia.CurrentRowIndex = ds_guia.Tables("detalle_guia").Rows.Count - 1

                                Else
                                    MessageBox.Show("Este Numero No Ha Sido Marcado como Reenvio", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("Numero ya Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Else
                        MessageBox.Show("Documento No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If 'codigo_error
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.txt_numero.Focus()
            Me.txt_numero.SelectAll()

        End Try

    End Sub

    Private Function Es_Unico(ByVal TableName As String, _
                              ByVal SourceTable As DataTable, _
                              ByVal FieldName As String, _
                              ByVal DatoActual As String) As Boolean


        Dim ReturnValue As Boolean = True
        Dim dt As New DataTable(TableName)
        Dim nveces As Integer = 0

        dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)


        For Each dr As DataRow In SourceTable.Select("", FieldName)
            If ColumnEqual(DatoActual, dr(FieldName)) Then
                ReturnValue = False
            End If
            'If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
            '   LastValue = dr(FieldName)
            '    dt.Rows.Add(New Object() {LastValue})
            'End If
        Next
        'If Not ds Is Nothing Then ds.Tables.Add(dt)
        'Return dt
        Return ReturnValue
    End Function

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        '
        ' Compares two values to determine if they are equal. Also compares DBNULL.Value.
        '
        ' NOTE: If your DataTable contains object fields, you must extend this
        ' function to handle the fields in a meaningful way if you intend to group on them.
        '
        If A Is DBNull.Value And B Is DBNull.Value Then Return True ' Both are DBNull.Value.
        If A Is DBNull.Value Or B Is DBNull.Value Then Return False ' Only one is DBNull.Value.
        Return A = B                                                ' Value type standard comparison
    End Function

    Private Sub guardarDocumento()
        Dim dr As DataRow
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            For Each dr In ds_guia.Tables("detalle_guia").Rows
                Try
                    ls_sql = "pa_ins_um_gen_control_transporte_temporal '" & dr.Item("empresa").ToString & "','CONTROL DE TRANSPORTE','" & Me.txtNumeroControl.Text.Trim & "','" & _
                             dr.Item("tipo_docto").ToString & "','" & _
                             dr.Item("numero").ToString & "','" & _
                             gs_usuario & "',0"

                    otrans.Ingresa(ls_sql)
                    If otrans.Codigo_error > 0 Then
                        MessageBox.Show(otrans.descripcion_error)
                    Else
                        ls_sql = "pa_ins_um_gen_control_transporte_temporal_reenvio '" & dr.Item("empresa").ToString & "','CONTROL DE TRANSPORTE','" & Me.txtNumeroControl.Text.Trim & "','" & _
                             dr.Item("tipo_docto").ToString & "','" & _
                             dr.Item("numero").ToString & "','" & _
                             dr.Item("motivo_rechazo") & "'"
                        otrans.Ingresa(ls_sql)
                    End If
                Catch ex As Exception
                End Try
            Next
            If MessageBox.Show("Proceso Finalizado con Exito, Desea Imprimir", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                imprimirControl()
            End If
            Me.limpiarPantalla()
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub limpiarPantalla()

        Me.txtNumeroControl.Text = String.Empty
        Me.txtAyudante.Text = String.Empty
        Me.txtPiloto.Text = String.Empty
        Me.txtRuta.Text = String.Empty
        Me.txtVehicuo.Text = String.Empty
        ds_guia.Tables("detalle_guia").Rows.Clear()

    End Sub


    Public Sub imprimirControl()
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim dtEmpresas As DataTable

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte()
            'path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            'path_reporte += "Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            'path_reporte += "Logistica\Trafico\Guía del Liquidador Global 2005 Corporativa.rpt"
            path_reporte += "Logistica\Trafico\Guía del Liquidador Global citizen.rpt"
            '  pm_parametros(0) = "empresa"
            pm_parametros(0) = "Numero de Documento"
            pm_valores(0) = Me.txtNumeroControl.Text

            '(c) 20150601

            For i As Integer = 1 To Me.NUDcopias.Value
                _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                                pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                False, True, "PDF", False, "", True, 1)

            Next


        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try


    End Sub


    Private Sub frm_AgregarReenvios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Llenar_Combos()
    End Sub

    
    Private Sub txtNumeroControl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroControl.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarControl()
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroControl.TextChanged

    End Sub

    Private Sub txt_numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            Buscar_Factura()
        End If
    End Sub

    Private Sub txt_numero_TextChanged(sender As Object, e As EventArgs) Handles txt_numero.TextChanged

    End Sub


    Private Sub crearEncabezado(psEmpresa As String)
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim ls_periodo As String
        Dim ldfecha As Date
        Try



            Try
                ldfecha = Me.dtp_fecha_control.Value
                ls_periodo = ldfecha.Year & ldfecha.Month.ToString.PadLeft(2, "0")

                lsSQL = "pa_ins_um_control_transporte '" & psEmpresa & "','CONTROL DE TRANSPORTE'" &
                                 ",'" & Me.txtNumeroControl.Text.Trim & "','" &
                                 Me.dtp_fecha_control.Text & "','" & Me.dtp_fecha_vcto.Text & "','" &
                                 Me.txtPiloto.Text & "','" & Me.txtVehicuo.Text & "','" &
                                 Me.txtAyudante.Text & "',0," &
                                "12,'S','" & ls_periodo & "','" & Me.txtRuta.Text & "','','" &
                                                    gs_usuario & "',null,'NO'"


                clsGen.insertQuery("FlexLine", lsSQL)


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub guardarencabezado()

        Dim dtEmpresasDetalle As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try

            dtEmpresasDetalle = clsGen.ValoresDistinto(ds_guia.Tables("detalle_guia"), "empresa".Split(","))

            For Each drEmpresa As DataRow In dtEmpresasDetalle.Rows

                ds_guia.Tables("empresas_control").DefaultView.RowFilter = "empresa = '" & drEmpresa.Item("empresa") & "'"
                If ds_guia.Tables("empresas_control").DefaultView.Count = 0 Then
                    crearEncabezado(drEmpresa.Item("empresa"))
                End If

            Next



        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta Seguro de Agregar los Documentos al Control", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'valido encabezados
            guardarEncabezado
            guardarDocumento()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.limpiarPantalla()
    End Sub
End Class