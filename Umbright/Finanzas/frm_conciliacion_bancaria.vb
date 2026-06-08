Public Class frm_conciliacion_bancaria
    Dim ban As Integer
    Dim ods As DataSet
    Dim dt As DataTable
    Dim origen1, origen2, origen3, origen4 As String
    Dim destino1, destino2, destino3, destino4 As String
    Dim OpAddNew As Boolean


    Private Sub Inicializar()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        ods = New DataSet
        Try
            Otrans.open()
            ls_sql = "pa_sel_um_con_ctaban '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "gen_ctas"
            ods.Tables.Add(dt.Copy)

            'combo conciliacion
            Me.cmb_cta_banco.DataSource = Nothing
            Me.cmb_cta_banco.DataSource = ods.Tables(0)
            Me.cmb_cta_banco.DisplayMember = "Descripcion"
            Me.cmb_cta_banco.ValueMember = "cuenta_banco" 'la propiedad valueMember contiene el numero de cuenta
            cta.Text = Me.cmb_cta_banco.SelectedValue.ToString
            If tiene_permisos("mfi_revertir_conciliacion") Then
                btn_revertir_conciliacion.Visible = True
            Else
                btn_revertir_conciliacion.Visible = False
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub consolidacion_manual()
        Dim drv As DataGridViewRow
        Dim DebeBanco, DebeConta, HaberBanco, HaberConta, DebeContaLinea, HaberContaLinea, DebeBancoLinea, HaberBancoLinea, DiferenciaDebe, DiferenciaHaber As Double
        Dim DocConciliadoBanco, TipoDocBanco, DocConciliadoConta, TipoDocConta As String
        Dim DocConciliadoBanco2, TipoDocBanco2, DocConciliadoConta2, TipoDocConta2 As String
        Dim Sql, ID_BANCO, ID_CONTA As String
        Dim Resp As VariantType
        Dim Conteo, Conteo2 As Integer

        DebeBanco = 0
        DebeConta = 0
        HaberBanco = 0
        HaberConta = 0

        DebeContaLinea = 0
        HaberContaLinea = 0
        DebeBancoLinea = 0
        HaberBancoLinea = 0



        DocConciliadoBanco = ""

        ID_CONTA = ""
        ID_BANCO = ""
        TipoDocBanco = ""
        DocConciliadoConta = ""
        TipoDocConta = ""

        Dim oTrans As New Transaccional.Conexion("Flexline")
        Try
            oTrans.open()
            For Each drv In dgv_banco.Rows
                If drv.DataGridView.Item("Conciliar", drv.Index).Value = True Then
                    ' 1 voy a sumar la cantidad banco
                    DebeBanco = +drv.DataGridView.Item("Debe", drv.Index).Value
                    HaberBanco = +drv.DataGridView.Item("Haber", drv.Index).Value
                    DocConciliadoBanco = DocConciliadoBanco & "-" & drv.DataGridView.Item("Documento", drv.Index).Value
                    TipoDocBanco = TipoDocBanco & "-" & drv.DataGridView.Item("Tipo", drv.Index).Value
                    ID_BANCO = ID_BANCO & "-" & drv.DataGridView.Item("ID", drv.Index).Value
                    Conteo = +1

                End If
            Next

            For Each drv In dgv_conta.Rows()
                If drv.DataGridView.Item("Conciliar", drv.Index).Value = True Then
                    ' 1 voy a sumar la cantidad conta
                    DebeConta = +drv.DataGridView.Item("Debe", drv.Index).Value
                    HaberConta = +drv.DataGridView.Item("Haber", drv.Index).Value
                    DocConciliadoConta = DocConciliadoConta & "-" & drv.DataGridView.Item("Referencia", drv.Index).Value
                    TipoDocConta = TipoDocConta & "-" & drv.DataGridView.Item("Tipo", drv.Index).Value
                    ID_CONTA = ID_CONTA & "-" & drv.DataGridView.Item("Identificador", drv.Index).Value
                    Conteo2 = +1
                End If
            Next


            If HaberBanco <> HaberConta Or DebeBanco <> DebeConta And HaberBanco + DebeBanco + HaberConta + DebeConta > 0 And Conteo2 = 1 And Conteo = 1 Then
                Resp = MessageBox.Show("los documentos seleccionados no concilian en montos tiene diferencias en el debe de " & Math.Round(DebeBanco - DebeConta) & " o en el haber de " & Math.Round(HaberBanco - HaberConta, 2) & " Desea Continuar?? ", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbYes Then

                    DiferenciaDebe = DebeBanco - DebeConta
                    DiferenciaHaber = HaberBanco - HaberConta

                    Sql = "pa_ins_um_cta_conciliado_diferencia '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "'," & ID_BANCO & "," & ID_CONTA & "," & DiferenciaDebe & ", " & DiferenciaHaber & ", '" & Me.periodo.Text & Me.cmb_mes.Text & "' "
                    oTrans.Actualiza(Sql)
                    HaberBanco = HaberConta
                    DebeBanco = DebeConta

                End If
            End If

            If HaberBanco = HaberConta And DebeBanco = DebeConta And HaberBanco + DebeBanco + HaberConta + DebeConta > 0 Then
                'conciliamos por haber
                Resp = MessageBox.Show("Esta seguro de conciliar los documentos seleccionados", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbYes Then

                    'proc actualiza la parte de banco
                    'For Each drv In dgv_banco.Rows
                    'If drv.DataGridView.Item("Conciliar", drv.Index).Value = True Then
                    ' 1 voy a sumar la cantidad banco
                    'DocConciliadoBanco2 = drv.DataGridView.Item("Documento", drv.Index).Value
                    'TipoDocBanco2 = drv.DataGridView.Item("Tipo", drv.Index).Value
                    'DebeBancoLinea = drv.DataGridView.Item("Debe", drv.Index).Value
                    'HaberBancoLinea = drv.DataGridView.Item("haber", drv.Index).Value
                    'ID_BANCO = drv.DataGridView.Item("ID", drv.Index).Value
                    Sql = "pa_upd_um_cta_conciliado_Manual '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & TipoDocConta & "','" & DocConciliadoConta & "'," & DebeBancoLinea & "," & HaberBancoLinea & ",'" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & TipoDocBanco2 & "','" & DocConciliadoBanco2 & "','B' , '" & ID_BANCO & "' , '" & ID_CONTA & "'"
                    oTrans.Actualiza(Sql)
                    '    End If
                    ' Next

                    'proc actualiza la parte de conta
                    'For Each drv In dgv_conta.Rows()
                    'If drv.DataGridView.Item("Conciliar", drv.Index).Value = True Then
                    ' 1 voy a sumar la cantidad conta
                    'DocConciliadoConta2 = drv.DataGridView.Item("Referencia", drv.Index).Value
                    'TipoDocConta2 = drv.DataGridView.Item("Tipo", drv.Index).Value
                    'DebeContaLinea = drv.DataGridView.Item("Debe", drv.Index).Value
                    'HaberContaLinea = drv.DataGridView.Item("haber", drv.Index).Value
                    'ID_CONTA = drv.DataGridView.Item("Identificador", drv.Index).Value
                    Sql = "pa_upd_um_cta_conciliado_Manual '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & TipoDocBanco & "','" & DocConciliadoBanco & "'," & DebeContaLinea & "," & HaberContaLinea & ",'" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & TipoDocConta2 & "','" & DocConciliadoConta2 & "','C'  , '" & ID_BANCO & "' , '" & ID_CONTA & "'"
                    oTrans.Actualiza(Sql)
                    'End If
                    '   Next

                    MessageBox.Show("Conciliacion Manual Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Los documentos seleccionados no son conciliables o su integracion no es exacta!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch er As Exception

            MessageBox.Show("Los documentos seleccionados no son conciliables o su integracion no es exacta!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
        End Try
        oTrans.close()
        oTrans = Nothing
    End Sub

    Private Sub estructura()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_Script As String
        Dim oTrans As Transaccional.Conexion
        Dim oTabla As DataTable
        Dim DebeConta, HaberConta As Double

        Dim dr, dr_aux As DataRow
        oTrans = New Transaccional.Conexion("flexline")
        ls_Script = "pa_sel_um_det_ctaban '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & "0" & "'"
        'ls_Script = "pa_sel_um_det_ctaban '" & gs_empresa & "','" & "004-206179-4" & "','" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & "0" & "'"

        oTrans.open()

        Me.dgv_conta.DataSource = Nothing
        Me.dgv_conta.Refresh()

        Try

            Me.conteo_conta.Text = ""
            oTabla = oTrans.Obtiene(ls_Script) '
            If oTabla.Rows.Count > 0 Then
                Me.conteo_conta.Text = "Registros  " & oTabla.Rows.Count

                ods = New DataSet
                dt = New DataTable("conta")

                dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
                dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
                dt.Columns.Add(New DataColumn("Referencia", GetType(String)))
                dt.Columns.Add(New DataColumn("Debe", GetType(Double)))
                dt.Columns.Add(New DataColumn("Haber", GetType(Double)))
                dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt.Columns.Add(New DataColumn("Conciliar", GetType(Boolean)))
                dt.Columns.Add(New DataColumn("Identificador", GetType(Integer)))

                If oTabla.Rows.Count > 0 Then
                    ods.Tables.Add(dt.Copy)
                    dt.TableName = "nce"
                    ods.Tables.Add(dt.Copy)
                    Me.dgv_conta.DataSource = ods.Tables("conta")

                    For Each dr In oTabla.Rows

                        dr_aux = ods.Tables("conta").NewRow

                        dr_aux.Item("Fecha") = dr.Item("Fecha")
                        dr_aux.Item("Tipo") = dr.Item("Tipo")
                        dr_aux.Item("Referencia") = dr.Item("Referencia")
                        dr_aux.Item("Debe") = dr.Item("Debe")
                        dr_aux.Item("Haber") = dr.Item("Haber")
                        dr_aux.Item("Descripcion") = dr.Item("Descripcion")
                        dr_aux.Item("Conciliar") = 0
                        dr_aux.Item("Identificador") = dr.Item("Identificador")

                        DebeConta += CDbl(dr.Item("Debe").ToString)
                        HaberConta += CDbl(dr.Item("Haber").ToString)


                        ods.Tables("conta").Rows.Add(dr_aux)
                    Next

                    Me.conteo_conta.Text = "Registros:  " & oTabla.Rows.Count & " Debe: " & Format(DebeConta, "#,##0.00") & " Haber: " & Format(HaberConta, "#,##0.00")

                    ClsGen.Alinear_GridView(ods.Tables("conta"), Me.dgv_conta, ",Fecha,Tipo,Referencia,Debe,Haber,Descripcion,Conciliar,identificador,", ",identificador,", ",Fecha,Tipo,Referencia,Debe,Haber,Descripcion,", ",Debe,Haber,", ",Debe,Haber,", "", "", True, True, 150, 0)
                    Me.btn_conciliar_manual.Enabled = True
                    Me.btn_reconciliar.Enabled = True

                Else
                    Me.dgv_conta.DataSource = Nothing
                    Me.dgv_conta.Refresh()

                    '   MessageBox.Show("No Hay Informacion disponible ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
        Finally
        End Try
        oTrans.close()
        oTrans = Nothing
        ClsGen = Nothing

    End Sub

    Public Sub EstructuraEstado()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_Script As String
        Dim oTrans As Transaccional.Conexion
        Dim oTabla As DataTable
        Dim dr, dr_aux As DataRow
        Dim DebeBanco, HaberBanco As Double
        oTrans = New Transaccional.Conexion("flexline")
        oTrans.open()

        Me.dgv_banco.DataSource = Nothing
        Me.dgv_banco.Refresh()
        Try
            ls_Script = "pa_sel_estado_cuenta_bancario '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & Me.periodo.Text & "','" & Me.cmb_mes.Text & "'"


            oTabla = oTrans.Obtiene(ls_Script) '
            If oTabla.Rows.Count > 0 Then

                Me.conteo_banco.Text = ""

                ods = New DataSet
                dt = New DataTable("banco")

                dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
                dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
                dt.Columns.Add(New DataColumn("Documento", GetType(String)))
                dt.Columns.Add(New DataColumn("Concepto", GetType(String)))
                dt.Columns.Add(New DataColumn("Debe", GetType(Double)))
                dt.Columns.Add(New DataColumn("Haber", GetType(Double)))
                dt.Columns.Add(New DataColumn("Conciliar", GetType(Boolean)))
                dt.Columns.Add(New DataColumn("ID", GetType(Integer)))

                If oTabla.Rows.Count > 0 Then
                    ods.Tables.Add(dt.Copy)
                    dt.TableName = "nce"
                    ods.Tables.Add(dt.Copy)
                    Me.dgv_banco.DataSource = ods.Tables("banco")

                    For Each dr In oTabla.Rows

                        dr_aux = ods.Tables("banco").NewRow

                        dr_aux.Item("Fecha") = dr.Item("Fecha")
                        dr_aux.Item("Tipo") = dr.Item("Tipo")
                        dr_aux.Item("Documento") = dr.Item("Documento")
                        dr_aux.Item("Concepto") = dr.Item("Concepto")
                        dr_aux.Item("Debe") = dr.Item("Debe")
                        dr_aux.Item("Haber") = dr.Item("Haber")
                        dr_aux.Item("Conciliar") = 0
                        dr_aux.Item("ID") = dr.Item("ID")

                        DebeBanco += CDbl(dr.Item("Debe").ToString)

                        HaberBanco += CDbl(dr.Item("Haber").ToString)

                        ods.Tables("banco").Rows.Add(dr_aux)

                    Next
                    Me.conteo_banco.Text = "Registros:  " & oTabla.Rows.Count & " Debe: " & Format(DebeBanco, "#,##0.00") & " Haber: " & Format(HaberBanco, "#,##0.00")

                    ClsGen.Alinear_GridView(ods.Tables("banco"), Me.dgv_banco, ",Fecha,Tipo,Documento,Concepto,Debe,Haber,Conciliar,ID,", ",ID,", ",Fecha,Tipo,Documento,Debe,Haber,Concepto,", ",Debe,Haber,", ",Debe,Haber,", "", "", True, True, 150, 0)

                Else
                    Me.dgv_banco.DataSource = Nothing
                    Me.dgv_banco.Refresh()

                End If
            End If
        Catch ex As Exception
        Finally
        End Try
        oTrans.close()
        oTrans = Nothing
        ClsGen = Nothing

    End Sub

    Private Sub tipo_nuevo()

        origen.Text = ""
        destino.Text = ""
        origen.Enabled = True
        destino.Enabled = True
        btn_nuevo.Visible = False
        btn_modificar.Visible = False
        btn_guardar.Visible = True
        btn_Cancelar.Visible = True
        Me.banco.Enabled = True
        OpAddNew = True

    End Sub

    Private Sub tipo_nuevo_pos()

        pos_fecha.Text = ""
        pos_documento.Text = ""
        pos_tipo.Text = ""
        pos_con.Text = ""
        pos_debe.Text = ""
        pos_haber.Text = ""


        pos_fecha.Enabled = True
        pos_documento.Enabled = True
        pos_concepto.Enabled = True
        pos_tipo.Enabled = True
        pos_con.Enabled = True
        pos_debe.Enabled = True
        pos_haber.Enabled = True
        Cmb_bancos.Enabled = True
        Cmb_bancos.Focus()

        nuevo.Visible = False
        modificar.Visible = False

        guardar.Visible = True
        cancelar.Visible = True


    End Sub

    Private Sub Proceso_modificar_tipo()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sta_mer As String

        Try
            Otrans.open()
            If origen.Text <> String.Empty Or destino.Text <> String.Empty Then
                ls_sql = "pa_upd_um_gen_tipo '" & gs_empresa & "','" & _
                                                  origen.Text & "','" & _
                                                  destino.Text & "'"


                Otrans.Actualiza(ls_sql)
                If Otrans.Codigo_error = 0 Then
                    tipo_nuevo()
                Else
                    MessageBox.Show("Problemas al Guardar " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Complete la Informacion ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
            tipo_nuevo()
            Me.origen.Focus()
        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub



    Private Sub Proceso_modificar_pos()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sta_mer As String

        Try
            Otrans.open()

            If pos_fecha.Text <> String.Empty And pos_documento.Text <> String.Empty And pos_tipo.Text <> String.Empty And pos_concepto.Text <> String.Empty And pos_debe.Text <> String.Empty And pos_haber.Text <> String.Empty And Cmb_bancos.Text <> String.Empty Then

                ls_sql = "pa_upd_um_gen_pos '" & gs_empresa & "','" & _
                                                  Me.Cmb_bancos.SelectedItem & "','" & _
                                                  Me.pos_fecha.Text & "','" & _
                                                  Me.pos_documento.Text & "','" & _
                                                  Me.pos_tipo.Text & "','" & _
                                                  Me.pos_con.Text & "','" & _
                                                  Me.pos_debe.Text & "','" & _
                                                  Me.pos_haber.Text & "'"


                Otrans.Actualiza(ls_sql)
                If Otrans.Codigo_error = 0 Then
                    tipo_nuevo()
                Else
                    MessageBox.Show("Problemas al Guardar " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Complete la informacion ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            tipo_nuevo()
            Me.origen.Focus()
        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub



    Private Sub Proceso_Guardar_tipo()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sta_mer As String

        Try
            Otrans.open()
            If origen.Text <> String.Empty Or destino.Text <> String.Empty Then
                ls_sql = "pa_ins_um_banco_tipo  '" & gs_empresa & "','" & Me.banco.SelectedItem & "','" & origen.Text & "','" & destino.Text & "'"

                Otrans.Ingresa(ls_sql)

                If Otrans.Codigo_error = 0 Then
                    tipo_nuevo()
                Else
                    MessageBox.Show("Problemas al Guardar " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Complete la Informacion ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            tipo_nuevo()
            Me.origen.Focus()
        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Proceso_Guardar_pos()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sta_mer As String

        Try
            Otrans.open()
            If pos_fecha.Text <> String.Empty And pos_documento.Text <> String.Empty And pos_tipo.Text <> String.Empty And pos_concepto.Text <> String.Empty And pos_debe.Text <> String.Empty And pos_haber.Text <> String.Empty And Cmb_bancos.Text <> String.Empty Then


                ls_sql = "pa_ins_um_pos_banco '" & gs_empresa & "','" & _
                                                  Me.Cmb_bancos.SelectedItem & "','" & _
                                                  Me.pos_fecha.Text & "','" & _
                                                  Me.pos_documento.Text & "','" & _
                                                  Me.pos_tipo.Text & "','" & _
                                                  Me.pos_con.Text & "','" & _
                                                  Me.pos_debe.Text & "','" & _
                                                  Me.pos_haber.Text & "'"


                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error = 0 Then
                    MessageBox.Show("Informacion Ingresada Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tipo_nuevo()
                Else
                    MessageBox.Show("Problemas al Guardar " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show("Complete la Informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Me.origen.Focus()
        Catch ex As Exception
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Private Sub guardar_modificar_tipo()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        ls_sql = "pa_sel_um_gen_tipo '" & Me.banco.SelectedItem & "','" & origen.Text & "','" & destino.Text & "'"
        Otrans.open()
        dt = Otrans.Obtiene(ls_sql)

        If dt.Rows.Count > 0 Then

            If MessageBox.Show("Esta seguro de Modificar el Tipo ? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Proceso_modificar_tipo()
            End If

        Else
            If MessageBox.Show("Esta seguro de Guardar el Tipo ? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Proceso_Guardar_tipo()
                tipo_nuevo()
            End If
        End If
    End Sub

    Private Sub guardar_modificar_pos()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        ls_sql = "pa_var_Configuracion_Concilicaciones_bancos '" & gs_empresa & "','" & Me.Cmb_bancos.SelectedItem & "'"

        Otrans.open()
        dt = Otrans.Obtiene(ls_sql)

        If dt.Rows.Count > 0 Then

            If MessageBox.Show("Esta seguro de Modificar las Posiciones ? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Proceso_modificar_pos()
            End If
        Else
            If MessageBox.Show("Esta seguro de Guardar las posiciones ? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Proceso_Guardar_pos()
            End If
        End If
    End Sub


    Private Sub mostrar_item()
        If Me.listado_tipos.CurrentRow.IsNewRow = False Then

            origen.Text = Me.listado_tipos.Item(3, listado_tipos.CurrentRow.Index).Value()
            destino.Text = Me.listado_tipos.Item(4, listado_tipos.CurrentRow.Index).Value()

        End If
    End Sub


    Private Sub mostrar_pos()
        Dim cadena As String
        If Me.listadoposiciones.CurrentRow.IsNewRow = False Then

            pos_fecha.Text = Me.listadoposiciones.Item(3, listadoposiciones.CurrentRow.Index).Value()
            pos_documento.Text = Me.listadoposiciones.Item(4, listadoposiciones.CurrentRow.Index).Value()
            pos_tipo.Text = Me.listadoposiciones.Item(5, listadoposiciones.CurrentRow.Index).Value()
            pos_con.Text = Me.listadoposiciones.Item(6, listadoposiciones.CurrentRow.Index).Value()
            pos_debe.Text = Me.listadoposiciones.Item(7, listadoposiciones.CurrentRow.Index).Value()
            pos_haber.Text = Me.listadoposiciones.Item(8, listadoposiciones.CurrentRow.Index).Value()

            cadena = Me.listadoposiciones.Item(1, listadoposiciones.CurrentRow.Index).Value()
            cadena = cadena.Replace(" "c, String.Empty)
            Cmb_bancos.SelectedItem = cadena

        End If
    End Sub


    Private Sub llenado_de_tipos()
        Dim oTranss As Transaccional.Conexion
        Dim ClsGen As New ClasesGenerales.General
        Dim oTablaMerc As DataTable
        Dim dr, dr_aux As DataRow
        Dim ls_sqltxt As String
        Dim cl As DataGridViewTextBoxColumn
        Dim oform As New frm_conciliacion_bancaria
        ods = New DataSet
        oTranss = New Transaccional.Conexion("flexline")

        Try
            oTranss.open()
            ls_sqltxt = "pa_var_Configuracion_tipos '" & gs_empresa & "'"

            oTablaMerc = oTranss.Obtiene(ls_sqltxt)
            Me.listado_tipos.DataSource = oTablaMerc
            ClsGen.Alinear_GridView(oTablaMerc, listado_tipos, ",Banco,Origen,Destino,", "", ",Banco,Origen,Destino,", "", ",Banco=Banco,Origen=Origen,Destino=Destino,", "", "", True, True, 150, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTranss.close()
        oTranss = Nothing


    End Sub

    Private Sub llenado_de_pos()
        Dim oTranss As Transaccional.Conexion
        Dim ClsGen As New ClasesGenerales.General
        Dim oTablaMerc As DataTable
        Dim ls_sqltxt As String
        Dim cl As DataGridViewTextBoxColumn
        Dim oform As New frm_conciliacion_bancaria
        ods = New DataSet
        oTranss = New Transaccional.Conexion("flexline")

        Try
            oTranss.open()
            ls_sqltxt = "pa_var_Configuracion_Cuentas '" & gs_empresa & "'"
            oTablaMerc = oTranss.Obtiene(ls_sqltxt)
            oTablaMerc.TableName = "lst_pos"
            ods.Tables.Add(oTablaMerc.Copy)
            Me.listadoposiciones.DataSource = ods.Tables("lst_pos").DefaultView

            oform.listadoposiciones.DataSource = oTablaMerc
            ClsGen.Alinear_GridView(ods.Tables("lst_pos"), listadoposiciones, ",Tipo_Banco,Pos_Fecha,Pos_Documento,Pos_Tipo,Pos_Concepto,Pos_Debe,Pos_haber,", " ", ",Tipo_Banco,Pos_Fecha,Pos_Documento,Pos_Tipo,Pos_Concepto,Pos_Debe,Pos_Haber,", "", ",Tipo_Banco=Banco,Pos_Fecha=Posicion Fecha,Pos_Documento=Posicion Docto.,Pos_Tipo=Posicion Tipo,Pos_Concepto= Posicion Concepto,Pos_Debe=Posicion Debe,Pos_Haber=Posicion Haber,", "", "", True, True, 150, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTranss.close()
        oTranss = Nothing


    End Sub


    Private Sub reconciliar()


        Dim drv3 As DataRow 'tabla banco
        Dim drv2 As DataRow 'tabla conta
        Dim sql As String
        Dim dt_banco, dt_conta As DataTable
        Dim ls_Script As String

        Dim oTrans As New Transaccional.Conexion("Flexline")
        Try
            oTrans.open()

            ls_Script = "pa_sel_estado_cuenta_bancario '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & Me.periodo.Text & "','" & Me.cmb_mes.Text & "'"
            dt_banco = oTrans.Obtiene(ls_Script)

            ls_Script = "pa_sel_um_det_ctaban '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & "0" & "'"
            dt_conta = oTrans.Obtiene(ls_Script)


            If dt_banco.Rows.Count > 0 Then

                For Each drv3 In dt_banco.Rows
                    For Each drv2 In dt_conta.Rows

                        If drv3.Item("Documento") = drv2.Item("Referencia") Then

                            drv2.Item("debe") = Math.Round(drv2.Item("debe"), 2, MidpointRounding.ToEven)
                            drv2.Item("haber") = Math.Round(drv2.Item("haber"), 2, MidpointRounding.ToEven)
                            'If drv3.Item("Documento") = "624001" Then
                            '        MsgBox("AQUI")
                            'End If

                            If drv3.Item("Debe") <> "0.00" Then
                                If drv3.Item("Debe") = drv2.Item("Debe") Then
                                    sql = "pa_upd_um_cta_conciliado '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & drv2.Item("Tipo") & "','" & drv2.Item("Referencia") & "','" & drv3.Item("Debe") & "','" & drv3.Item("Haber") & "','" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & drv3.Item("Tipo") & "'," & drv3.Item("ID") & "," & drv2.Item("Identificador")
                                    oTrans.Actualiza(sql)
                                End If
                            End If


                            If drv3.Item("Haber") <> "0.00" Then
                                If drv3.Item("Haber") = drv2.Item("Haber") Then
                                    sql = "pa_upd_um_cta_conciliado '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString & "','" & drv2.Item("Tipo") & "','" & drv2.Item("Referencia") & "','" & drv3.Item("Debe") & "','" & drv3.Item("Haber") & "','" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & drv3.Item("Tipo") & "'," & drv3.Item("ID") & "," & drv2.Item("Identificador")

                                    oTrans.Actualiza(sql)
                                End If
                            End If



                        End If
                    Next
                Next
            End If
        Catch
        End Try
        MsgBox("Proceso de reconciliacion automatica terminado", MsgBoxStyle.Information)
    End Sub


    Private Sub estructura_consolidado()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_Script As String
        Dim oTrans As Transaccional.Conexion
        Dim oTabla As DataTable
        Dim dr, dr_aux As DataRow
        Dim DebeConciliado, HaberConciliado As Double
        oTrans = New Transaccional.Conexion("flexline")
        ls_Script = "pa_sel_um_det_ctaban '" & gs_empresa & "','" & Me.cmb_cta_banco.SelectedValue.ToString() & "','" & Me.periodo.Text & "'," & Me.cmb_mes.Text & ",'" & "1" & "'"

        Me.dgv_conciliado.DataSource = Nothing
        Me.dgv_conciliado.Refresh()

        oTrans.open()

        Try
            Me.conteo_conciliado.Text = ""
            oTabla = oTrans.Obtiene(ls_Script) '
            If oTabla.Rows.Count > 0 Then



                ods = New DataSet
                dt = New DataTable("conciliado")

                dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
                dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
                dt.Columns.Add(New DataColumn("Referencia", GetType(String)))
                dt.Columns.Add(New DataColumn("Debe", GetType(Double)))
                dt.Columns.Add(New DataColumn("Haber", GetType(Double)))
                dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt.Columns.Add(New DataColumn("Doc_Concilio", GetType(String)))
                dt.Columns.Add(New DataColumn("Tipo_Concilio", GetType(String)))
                dt.Columns.Add(New DataColumn("Identificador", GetType(String)))
                dt.Columns.Add(New DataColumn("Revertir", GetType(Boolean)))


                ods.Tables.Add(dt.Copy)
                dt.TableName = "conciliado"
                Me.dgv_conciliado.DataSource = ods.Tables("conciliado")

                For Each dr In oTabla.Rows

                    dr_aux = ods.Tables("conciliado").NewRow

                    dr_aux.Item("Fecha") = dr.Item("Fecha")
                    dr_aux.Item("Tipo") = dr.Item("Tipo")
                    dr_aux.Item("Referencia") = dr.Item("Referencia")
                    dr_aux.Item("Debe") = dr.Item("Debe")
                    dr_aux.Item("Haber") = dr.Item("Haber")
                    dr_aux.Item("Descripcion") = dr.Item("Descripcion")
                    dr_aux.Item("Doc_Concilio") = dr.Item("Doc_Concilio")
                    dr_aux.Item("Tipo_Concilio") = dr.Item("Tipo_Concilio")
                    dr_aux.Item("Identificador") = dr.Item("Identificador")
                    dr_aux.Item("Revertir") = 0

                    DebeConciliado += CDbl(dr.Item("Debe").ToString)
                    HaberConciliado += CDbl(dr.Item("Haber").ToString)


                    Me.conteo_conciliado.Text = "Registros:  " & oTabla.Rows.Count & " Debe: " & Format(DebeConciliado, "#,##0.00") & " Haber: " & Format(HaberConciliado, "#,##0.00")

                    ods.Tables("conciliado").Rows.Add(dr_aux)
                Next
                ClsGen.Alinear_GridView(ods.Tables("conciliado"), Me.dgv_conciliado, ",Fecha,Tipo,Referencia,Debe,Haber,Descripcion,Doc_Concilio,Tipo_Concilio,Identificador,Revertir,", ",Identificador,", ",Fecha,Tipo,Referencia,Debe,Habe,Descripcion,Doc_Concilio,Tipo_Concilio,Doc_Concilio,Tipo_Concilio,", ",Debe,Haber,", ",Debe,Haber,", "", "", True, True, 150, 0)
                Me.btn_revertir_conciliacion.Enabled = True
            Else
                Me.dgv_conciliado.DataSource = Nothing
                Me.dgv_conciliado.Refresh()
                Me.btn_revertir_conciliacion.Enabled = False
            End If
        Catch ex As Exception
        Finally
        End Try
        oTrans.close()
        oTrans = Nothing
        ClsGen = Nothing



    End Sub

    Private Sub mostrar()
        Dim cadena2 As String
        If Me.listado_tipos.CurrentRow.IsNewRow = False Then
            Me.origen.Text = Me.listado_tipos.Item(1, Me.listado_tipos.CurrentRow.Index).Value
            Me.destino.Text = Me.listado_tipos.Item(2, Me.listado_tipos.CurrentRow.Index).Value

            cadena2 = Me.listado_tipos.Item(0, listado_tipos.CurrentRow.Index).Value()
            cadena2 = cadena2.Replace(" "c, String.Empty)
            banco.SelectedItem = cadena2



        End If
    End Sub

    Private Sub frm_conciliacion_bancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenado_de_tipos()
        llenado_de_pos()
        Inicializar()
    End Sub

    Private Sub empresa_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_importar_Click(sender As Object, e As EventArgs)
        Dim frm As New frm_importar_estado_de_cuenta()
        frm.Show()
    End Sub

    Private Sub Process1_Exited(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgv_banco_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
    Private Sub cmb_cta_banco_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If periodo.Text = "" Or cmb_mes.Text = "" Then
            MessageBox.Show("Debe Ingresar el Periodo y el mes", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            periodo.Focus()
        Else

            EstructuraEstado() 'llena grid banco
            estructura() 'llena grid conta
            estructura_consolidado() 'llena grid de Movimientos consolidados

        End If

    End Sub

    Private Sub cmb_cta_banco_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmb_cta_banco.SelectedIndexChanged

    End Sub

    Private Sub cmb_cta_banco_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_cta_banco.SelectedValueChanged
        cta.Text = Me.cmb_cta_banco.SelectedValue.ToString
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs)
        tipo_nuevo()
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs)
        guardar_modificar_tipo()
        llenado_de_tipos()
        tipo_nuevo()
    End Sub

    Private Sub listado_tipos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        mostrar_item()

    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs)
        Me.btn_Cancelar.Visible = False
        Me.btn_guardar.Visible = False
        Me.btn_nuevo.Visible = True
        Me.btn_modificar.Visible = True

    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs)
        origen.Enabled = True
        destino.Enabled = True
        destino.Enabled = True

        Me.btn_modificar.Visible = False
        Me.btn_nuevo.Visible = False
    End Sub

    Private Sub btn_reconciliar_Click(sender As Object, e As EventArgs) Handles btn_reconciliar.Click

        If dgv_banco.Rows().Count > 0 Then

            reconciliar() ' conciliacion automatica

            dgv_banco.DataSource = Nothing
            EstructuraEstado() ''llena la grid de banco
            estructura()  ''llena la grid de conta
            estructura_consolidado() ''llena grid de Movimientos consolidados
        Else
            MessageBox.Show("No existen Datos en la tabla de Bancos. !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btn_importar_Click_1(sender As Object, e As EventArgs) Handles btn_importar.Click

        If periodo.Text <> "" And cmb_mes.Text <> "" Then

            Dim frm As New frm_importar_estado_de_cuenta()
            frm.cuenta = cta.Text
            frm.ShowDialog(Me)
            frm = Nothing
            EstructuraEstado()

            '  If dgv_conta.Rows().Count > 0 Then
            ' EstructuraEstado() 'llena grid banco
            ' estructura() 'llena grid conta
            ' estructura_consolidado() 'llena grid de Movimientos consolidados
            ' End If
        Else
            MsgBox("Debe seleccionar un periodo y un mes", MsgBoxStyle.Critical)
        End If


    End Sub

    Private Sub btn_conciliar_manual_Click(sender As Object, e As EventArgs) Handles btn_conciliar_manual.Click
        Dim drv As DataGridViewRow
        Dim conteo1, conteo2 As Integer
        For Each drv In dgv_conta.Rows()
            If drv.DataGridView.Item("Conciliar", drv.Index).Value = True Then
                conteo1 = +1
            End If
        Next
        For Each drv In dgv_banco.Rows()
            If drv.DataGridView.Item("Conciliar", drv.Index).Value = True Then
                conteo2 = +1
            End If
        Next

        If conteo1 > 0 And conteo2 > 0 Then
            consolidacion_manual()

            dgv_banco.DataSource = Nothing
            EstructuraEstado() 'llena grid banco
            estructura() 'llena grid conta
            estructura_consolidado() 'llena grid de Movimientos consolidados

        Else
            MessageBox.Show("Debe seleccionar los documentos a Conciliar en la tabla Bancos y Conta. !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmb_destino_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub nota_credito_origen_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles nuevo.Click
        tipo_nuevo_pos()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles guardar.Click
        guardar_modificar_pos()
        llenado_de_pos()
        nuevo.Visible = True
        modificar.Visible = True
        guardar.Visible = False
        cancelar.Visible = False

    End Sub

    Private Sub btn_nuevo_Click_1(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        tipo_nuevo()
    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub listado_tipos_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles listado_tipos.CellContentClick

    End Sub

    Private Sub listadoposiciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles listadoposiciones.CellContentClick

    End Sub

    Private Sub listado_tipos_Click(sender As Object, e As EventArgs) Handles listado_tipos.Click
        mostrar()
    End Sub

    Private Sub btn_modificar_Click_1(sender As Object, e As EventArgs) Handles btn_modificar.Click
        origen.Enabled = True
        destino.Enabled = True

        btn_nuevo.Visible = False
        btn_modificar.Visible = False

        btn_guardar.Visible = True
        btn_Cancelar.Visible = True

    End Sub

    Private Sub cheque_origen_TextChanged(sender As Object, e As EventArgs) Handles origen.TextChanged

    End Sub

    Private Sub btn_guardar_Click_1(sender As Object, e As EventArgs) Handles btn_guardar.Click
        guardar_modificar_tipo()
        llenado_de_tipos()
        btn_nuevo.Visible = True
        btn_modificar.Visible = True
        btn_guardar.Visible = False
        btn_Cancelar.Visible = False
        origen.Enabled = False
        destino.Enabled = False
        OpAddNew = False
    End Sub

    Private Sub btn_Cancelar_Click_1(sender As Object, e As EventArgs) Handles btn_Cancelar.Click

        origen.Enabled = False
        destino.Enabled = False

        btn_nuevo.Visible = True
        btn_modificar.Visible = True

        btn_guardar.Visible = False
        btn_Cancelar.Visible = False
        Me.banco.Enabled = False
    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        nuevo.Visible = False
        modificar.Visible = False
        guardar.Visible = True
        cancelar.Visible = True

        pos_fecha.Enabled = True
        pos_documento.Enabled = True
        pos_con.Enabled = True
        pos_tipo.Enabled = True
        pos_concepto.Enabled = True
        pos_debe.Enabled = True
        pos_haber.Enabled = True

    End Sub

    Private Sub cancelar_Click(sender As Object, e As EventArgs) Handles cancelar.Click
        nuevo.Visible = True
        modificar.Visible = True

        guardar.Visible = False
        cancelar.Visible = False

    End Sub

    Private Sub cmb_ctas_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmb_ctas_SelectedValueChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub listadoposiciones_Click(sender As Object, e As EventArgs) Handles listadoposiciones.Click
        mostrar_pos()
    End Sub

    Private Sub Cheque_destino_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub nota_credito_destino_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub nota_debito_destino_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cuentas_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles imprimir.Click
        Dim frm As New frm_imprimir_conciliacion()
        frm.pm_Cuenta = cta.Text
        frm.pm_Periodo = periodo.Text

        frm.pm_Mes = CDbl(cmb_mes.Text)

        frm.ShowDialog(Me)
        frm = Nothing

    End Sub

    Private Sub dgv_banco_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub conteo_conciliado_Click(sender As Object, e As EventArgs) Handles conteo_conciliado.Click

    End Sub
    Private Sub generar_reporte()
        Dim otrans As New Transaccional.Conexion("DWH")
        Dim ls_sql As String
        Dim llenar_memos As Boolean = False
        Dim ls_ubicaciones As String = ""
        Dim ubicacion_actual As String
        Dim path_reporte, ppath_reporte As String
        Dim pm_valores(6), pm_valores_consolidado(3) As String
        Dim pm_parametros(6) As String
        Dim pm_conexion(3) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim ruta As String
        Randomize()
        Dim aleat As Integer

        ''Obtengo Datos de Conexion

        Try

            otrans.open()
            pm_conexion = clsgen.Parametros_Conexion("")
            ppath_reporte = clsgen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)

            '023:
            path_reporte = ppath_reporte & "Finanzas\Facturacion\Conciliacion Bancaria.rpt"
            'path_reporte = "c:\reportes\Retail-Link2.rpt"
            pm_parametros(0) = "Empresa"
            pm_parametros(1) = "Cuenta"
            pm_parametros(2) = "Periodo"
            pm_parametros(3) = "Mes"
            pm_parametros(4) = "SaldoBanco"
            pm_parametros(5) = "SaldoContable"
            pm_parametros(6) = "Usuario"

            pm_valores(0) = gs_empresa

            pm_valores(1) = gs_empresa


            aleat = CInt(Int((2000 * Rnd()) + 1))
            ruta = "c:\tempo\conciliacion Bancaria" + aleat + ".pdf"

            Oaut.Archivo_Generado = ruta
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                   True, True, "PDF", False)


            ' pm_valores(1) & "','" & _
            ' pm_valores(2) & "',NULL,NULL,NULL,100"
            ' otrans.Actualiza(ls_sql)


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

            Oaut.finalizar()
            Oaut = Nothing
            clsgen = Nothing

        End Try

    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btn_revertir_conciliacion.Click
        Dim docrevertir As Integer
        Dim resp As VariantType
        Dim drv As DataGridViewRow
        Dim conteor, IDCONTA As Integer
        Dim sql As String
        Dim oTrans As New Transaccional.Conexion("Flexline")

        If tiene_permisos("mfi_revertir_conciliacion") Then
            oTrans.open()
            Try
                For Each drv In dgv_conciliado.Rows()
                    If drv.DataGridView.Item("Revertir", drv.Index).Value = True Then
                        docrevertir = drv.DataGridView.Item("referencia", drv.Index).Value
                        resp = MessageBox.Show("Esta seguro de revertir la conciliacion de documento " & docrevertir & " de este mes Desea Continuar?? ", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If resp = vbYes Then
                            IDCONTA = drv.DataGridView.Item("Identificador", drv.Index).Value
                            conteor = +1
                            sql = "pa_upd_um_cta_revertir_conciliado " & IDCONTA & ",' " & gs_empresa & "', '" & Me.periodo.Text & Me.cmb_mes.Text & "' "
                            oTrans.Actualiza(sql)
                        End If
                    End If
                Next
                EstructuraEstado() 'llena grid banco
                estructura() 'llena grid conta
                estructura_consolidado() 'llena grid de Movimientos consolidados
            Catch ex As Exception
            End Try
            oTrans.close()
            oTrans = Nothing

        End If


    End Sub
End Class

