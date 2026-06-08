Public Class Frm_Tracking_Pagos_Electronicos
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "lsolis"
    Dim paso As Int16 = 0
    Dim Paso1 As String = ""
    Dim Paso2 As String = ""
    Dim Paso3 As String = ""
    Dim Paso4 As String = ""
    Dim Paso5 As String = ""
    Dim Paso6 As String = ""
    Dim Ods As New DataSet
    Private Sub Frm_Tracking_Pagos_Electronicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Text + " - " + gs_usuario

        btn_Emitir.Enabled = False
        btn_Ok1.Enabled = False
        btn_Ok2.Enabled = False
        btn_Ok3.Enabled = False
        btn_Ok4.Enabled = False
        btn_Ok5.Enabled = False
        btn_Ok6.Enabled = False
        btn_Obtener.Enabled = False
        btn_ObtenerAnular.Enabled = False
        Carga_Combos()
        Bloqueo()
        'Carga_Combos()
    End Sub
    Private Sub Bloqueo()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        '    Dim dt As DataTable
        '   Dim ls_SqlScript As String
        '     Dim otrans As New Transaccional.Conexion("flexline")

        Try
            ' otrans.open()

            'ls_SqlScript = "flexline.pa_sel_um_usr_lotes '" & gs_usuario & "'"
            'dt = otrans.Obtiene(ls_SqlScript)

            'If dt.Rows.Count > 0 Then
            '    If UCase(gs_usuario) = dt.Rows(0).Item("Codigo").ToString Then

            '   LOS USUARIOS SE GUARDAN EN UMBRAL FLEXLINE GEN_TABCOD TIPO GEN_USR_LOTES
            '   -----------------------------------------------------------------------

            '     If dt.Rows(0).Item("Valor1").ToString = "1" Then ' EMISION

            If tiene_permisos("mfi_emision_pagos_electronicos") Then
                btn_Obtener.Enabled = True
                btn_Emitir.Enabled = True
            End If



            '  If dt.Rows(0).Item("Valor1").ToString = "2" Then 'LSOLIS'
            If cb_Paso1.Text = "" Then
                btn_Ok1.Enabled = False
            Else
                If tiene_permisos("mfi_revision_pagos_electronicos") Then
                    btn_Ok1.Enabled = True
                End If

            End If

            'MGRAMAJO'
            'If dt.Rows(0).Item("Valor1").ToString = "3" Or dt.Rows(0).Item("Valor1").ToString = "5" Or dt.Rows(0).Item("Valor1").ToString = "8" Then
            If cb_paso2.Text = "" Then
                btn_Ok2.Enabled = False
            Else
                ' If tiene_permisos("mfi_carga_pagos_electronicos") Then
                If tiene_permisos("mfi_autorizar_pagos_electronicos") Then
                    btn_Ok2.Enabled = True
                End If
            End If


            'If dt.Rows(0).Item("Valor1").ToString = "6" Then ' ACAMEY
            If cb_Paso3.Text = "" Then
                btn_Ok3.Enabled = False
            Else
                If tiene_permisos("mfi_aprobar_pagos_electronicos") Then
                    btn_Ok3.Enabled = True
                End If
            End If


            If cb_paso4.Text = "" Then
                btn_Ok4.Enabled = False
            Else
                If tiene_permisos("mfi_autorizar_pagos_electronicos") Then
                    '        tiene_permisos("mfi_recepcion_pagos_electronicos") Then
                    btn_Ok4.Enabled = True
                End If
            End If


            'If dt.Rows(0).Item("Valor1").ToString = "4" Or dt.Rows(0).Item("Valor1").ToString = "7" Then 'LRIVERA'
            If cb_paso5.Text = "" Then
                btn_Ok5.Enabled = False
            Else
                If tiene_permisos("mfi_autorizar_pagos_electronicos") Then
                    btn_Ok5.Enabled = True
                End If
            End If


            If cb_paso6.Text = "" Then
                btn_Ok6.Enabled = False
            Else
                If tiene_permisos("mfi_tesoreria_pagos_electronicos") Then
                    btn_Ok6.Enabled = True
                End If
            End If

            If tiene_permisos("mfi_eliminar_pagos_electronicos") Then
                btn_ObtenerAnular.Enabled = True
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub Carga_Combos()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim dt As DataTable
        Dim ls_SqlScript As String
        Dim otrans As New Transaccional.Conexion("flexline")

        Try
            otrans.open()

            ls_SqlScript = "flexline.pa_um_sel_Pagos_Electronicos_Estado '" & gs_empresa & "',1"
            dt = otrans.Obtiene(ls_SqlScript)
            If dt.Rows.Count > 0 Then
                lb1.Visible = True
            Else
                lb1.Visible = False
            End If

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "p1"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_Paso1.DisplayMember = "Lote"
            Me.cb_Paso1.ValueMember = "Lote"
            Me.cb_Paso1.DataSource = ldt_table
            Me.cb_Paso1.SelectedValue = 0
            ' Me.cb_Paso1.SelectedIndex = 0



            ls_SqlScript = "flexline.pa_um_sel_Pagos_Electronicos_Estado '" & gs_empresa & "',2"
            dt = otrans.Obtiene(ls_SqlScript)
            If dt.Rows.Count > 0 Then
                lb2.Visible = True
            Else
                lb2.Visible = False
            End If

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "p2"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_paso2.DisplayMember = "Lote"
            Me.cb_paso2.ValueMember = "Lote"
            Me.cb_paso2.DataSource = ldt_table
            Me.cb_paso2.SelectedValue = -1
            '  Me.cb_paso2.SelectedIndex = 0

            ls_SqlScript = "flexline.pa_um_sel_Pagos_Electronicos_Estado '" & gs_empresa & "',3"
            dt = otrans.Obtiene(ls_SqlScript)
            If dt.Rows.Count > 0 Then
                lb3.Visible = True
            Else
                lb3.Visible = False
            End If

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "p3"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_Paso3.DisplayMember = "Lote"
            Me.cb_Paso3.ValueMember = "Lote"
            Me.cb_Paso3.DataSource = ldt_table
            Me.cb_Paso3.SelectedValue = -1
            'Me.cb_Paso3.SelectedIndex = 0

            ls_SqlScript = "flexline.pa_um_sel_Pagos_Electronicos_Estado '" & gs_empresa & "',4"
            dt = otrans.Obtiene(ls_SqlScript)
            If dt.Rows.Count > 0 Then
                lb4.Visible = True
            Else
                lb4.Visible = False
            End If

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "p4"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_paso4.DisplayMember = "Lote"
            Me.cb_paso4.ValueMember = "Lote"
            Me.cb_paso4.DataSource = ldt_table
            Me.cb_paso4.SelectedValue = -1
            ' Me.cb_paso4.SelectedIndex = 0

            ls_SqlScript = "flexline.pa_um_sel_Pagos_Electronicos_Estado '" & gs_empresa & "',5"
            dt = otrans.Obtiene(ls_SqlScript)
            If dt.Rows.Count > 0 Then
                lb5.Visible = True
            Else
                lb5.Visible = False
            End If

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "p5"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_paso5.DisplayMember = "Lote"
            Me.cb_paso5.ValueMember = "Lote"
            Me.cb_paso5.DataSource = ldt_table
            Me.cb_paso5.SelectedValue = -1
            'Me.cb_paso5.SelectedIndex = 0

            ls_SqlScript = "flexline.pa_um_sel_Pagos_Electronicos_Estado '" & gs_empresa & "',6"
            dt = otrans.Obtiene(ls_SqlScript)
            If dt.Rows.Count > 0 Then
                lb6.Visible = True
            Else
                lb6.Visible = False
            End If

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "p6"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_paso6.DisplayMember = "Lote"
            Me.cb_paso6.ValueMember = "Lote"
            Me.cb_paso6.DataSource = ldt_table
            Me.cb_paso6.SelectedValue = -1
            'Me.cb_paso6.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub btn_Obtener_Click(sender As Object, e As EventArgs) Handles btn_Obtener.Click
        If tiene_permisos("mfi_emision_pagos_electronicos") Then
            Obtiene_Lote_Creado()
        End If

    End Sub

    Private Sub Obtiene_Lote_Creado()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()

            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_Busca '" & gs_empresa & "','" & tb_Lote.Text & "'"
            dt = oTrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                MsgBox("Este Lote ya fue Emitido Por Favor verifique...", MsgBoxStyle.Information, "Lote Emitido")
                Limpiar()

            Else
                lsSQL = "Select Tipo, Cuenta, Nit, Proveedor, Correo, CASE WHEN LOTE LIKE ('ACH%') then Razon else NoFactura end Facturas, Monto, Usuario, FechaModif from flexline.Log_PagosBI where Lote='" & tb_Lote.Text & "' and empresa= '" & gs_empresa & "'"
                dt = oTrans.Obtiene(lsSQL)
                Me.dgv_Detalle_Lote.DataSource = dt

                If dt.Rows.Count > 0 Then
                    Total()
                    btn_Emitir.Enabled = True
                Else
                    MsgBox("LOTE no Existe, Verifique!!", MsgBoxStyle.Critical, "Error")
                    Limpiar()
                End If
            End If


            'ClsGen.Alinear_GridView(dt, Me.dgv_pagos, "", ",Empresa,Usuario,FechaModif,", ",Tipo,Cuenta,NIT,Proveedor,Monto,Correo,Razon,", "", "", "", "", True, True, 475, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Total()
        Dim ntotal As Double
        Dim dt As DataTable

        Try

            dt = Me.dgv_Detalle_Lote.DataSource

            ntotal = dt.Compute("sum(Monto)", "Monto>=0")
            Me.lb_Total.Text = Format(ntotal, "###,###.00")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpiar()
    End Sub
    Private Sub Limpiar()
        btn_Emitir.Enabled = False
        dgv_Detalle_Lote.DataSource = Nothing
        tb_Lote.Text = ""
        lb_Total.Text = "0.00"
        tb_Lote.Focus()
    End Sub

    Private Sub btn_Emitir_Click(sender As Object, e As EventArgs) Handles btn_Emitir.Click

        If MessageBox.Show("Seguro de Emitir el Lote " & tb_Lote.Text & "?", "Emisión de Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Emision_Lote()
        Carga_Combos()

    End Sub

    Private Sub Emision_Lote()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_1 '" & gs_empresa & "','" & tb_Lote.Text & "','" & gs_usuario & "'"
            oTrans.Obtiene(lsSQL)

            oTrans.open()
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_Log '" & gs_empresa & "','" & tb_Lote.Text & "','" & gs_usuario & "'"
            oTrans.Obtiene(lsSQL)

            ' se salta al paso de autorizacion dejandolo listo para operar en tesoreria

            '     Previo_autorizacion()


            MsgBox("Lote Emitido y Autorizado para Operar en Tesorería Correctamente!!!", MsgBoxStyle.Information, "Emitido y Autorizado...")
            Limpiar()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Ok1_Click(sender As Object, e As EventArgs) Handles btn_Ok1.Click
        If tiene_permisos("mfi_revision_pagos_Electronicos") Then
            Paso1_Revision()
        End If

    End Sub

    Private Sub Paso1_Revision()
        If MessageBox.Show("Seguro de Revisar el Lote " & tb_Lote.Text & "?", "Revisión de Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
        paso = 2
        Revisado()
    End Sub

    Private Sub Revisado()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & Paso1.Trim & "','" & gs_usuario & "'," & paso
            oTrans.Obtiene(lsSQL)

            MsgBox("Lote Revisado Correctamente!!!", MsgBoxStyle.Information, "Emisión...")
            Carga_Combos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Ok2_Click(sender As Object, e As EventArgs) Handles btn_Ok2.Click

        If tiene_permisos("mfi_autorizar_pagos_electronicos") Then
            If MessageBox.Show("Seguro de Autorizar el Lote " & Mid(cb_paso2.Text, 1, 13) & "?", "Autorización de Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            paso = 3
            ' Cargado()
            Autorizacion()
        End If

    End Sub

    Private Sub Autorizacion()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & Paso2.Trim & "','" & gs_usuario & "'," & paso
            oTrans.Obtiene(lsSQL)

            MsgBox("Lote Autorizado Correctamente!!!", MsgBoxStyle.Information, "Autorización de Lote...")
            Carga_Combos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Ok3_Click(sender As Object, e As EventArgs) Handles btn_Ok3.Click
        If tiene_permisos("mfi_carga_pagos_electronicos") Then
            If MessageBox.Show("Seguro de Cargar a Banco el Lote " & Paso3.Trim & "?", "Carga de Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            paso = 4
            Cargado()
        End If

    End Sub
    Private Sub Cargado()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & Paso3.Trim & "','" & gs_usuario & "'," & paso
            oTrans.Obtiene(lsSQL)

            MsgBox("Lote Cargado a Banco Correctamente!!!", MsgBoxStyle.Information, "Carga de Lote...")
            Carga_Combos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Ok4_Click(sender As Object, e As EventArgs) Handles btn_Ok4.Click
        If tiene_permisos("mfi_aprobar_pagos_electronicos") Then
            If MessageBox.Show("Seguro de Pagar el Lote " & Paso4.Trim & "?", "Pago de Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            paso = 5
            Pago_tesoreria()
        End If

    End Sub
    Private Sub Pago_tesoreria()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & Paso4.Trim & "','" & gs_usuario & "'," & paso
            oTrans.Obtiene(lsSQL)

            MsgBox("Pago Tesorería de Lote Correctamente!!!", MsgBoxStyle.Information, "Pago de Lote...")
            Carga_Combos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub
    Private Sub cb_Paso1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Paso1.SelectedValueChanged

        Paso1 = Mid(cb_Paso1.Text, 1, 13)
        If Paso1 = "" Then
            btn_Ok1.Enabled = False
        Else
            If tiene_permisos("mfi_revision_pagos_Electronicos") Then 'mfi_revision_pagos_Electronicos
                btn_Ok1.Enabled = True
            End If

        End If
        Bloqueo()
    End Sub
    Private Sub cb_Paso2_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_paso2.SelectedValueChanged
        Paso2 = Mid(cb_paso2.Text, 1, 13)
        If Paso2 = "" Then
            btn_Ok2.Enabled = False
        Else
            If tiene_permisos("mfi_autorizar_pagos_electronicos") Then 'mfi_autorizar_pagos_electronicos
                btn_Ok2.Enabled = True
            End If

        End If
        Bloqueo()
    End Sub
    Private Sub cb_paso3_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Paso3.SelectedValueChanged
        Paso3 = Mid(cb_Paso3.Text, 1, 13)
        If Paso3 = "" Then
            btn_Ok3.Enabled = False
        Else
            If tiene_permisos("mfi_carga_pagos_electronicos") Then 'mfi_carga_pagos_electronicos
                btn_Ok3.Enabled = True
            End If

        End If
        Bloqueo()
    End Sub
    Private Sub cb_paso4_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_paso4.SelectedValueChanged
        Paso4 = Mid(cb_paso4.Text, 1, 13)
        If Paso4 = "" Then
            btn_Ok4.Enabled = False
        Else
            If tiene_permisos("mfi_aprobar_pagos_electronicos") Then
                btn_Ok4.Enabled = True
            End If

        End If
        Bloqueo()
    End Sub
    Private Sub cb_paso5_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_paso5.SelectedValueChanged
        Paso5 = Mid(cb_paso5.Text, 1, 13)
        If Paso5 = "" Then
            btn_Ok5.Enabled = False
        Else
            If tiene_permisos("mfi_tesoreria_pagos_electronicos") Then 'mfi_tesoreria_pagos_electronicos
                btn_Ok5.Enabled = True
            End If
        End If
        Bloqueo()
    End Sub
    Private Sub cb_paso6_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_paso6.SelectedValueChanged
        Paso6 = Mid(cb_paso6.Text, 1, 13)
        If Paso6 = "" Then
            btn_Ok6.Enabled = False
        Else
            If tiene_permisos("mfi_tesoreria_pagos_electronicos") Then
                btn_Ok6.Enabled = True
            End If

        End If
        Bloqueo()
    End Sub

    Private Sub Aprobacion()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            oTrans.open()
            lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & Paso3.Trim & "','" & gs_usuario & "'," & paso
            oTrans.Obtiene(lsSQL)

            MsgBox("Lote Aprobado Correctamente!!!", MsgBoxStyle.Information, "Aprobación de Lote...")
            Carga_Combos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Ok5_Click(sender As Object, e As EventArgs) Handles btn_Ok5.Click
        If tiene_permisos("mfi_tesoreria_pagos_electronicos") Then
            If MessageBox.Show("Seguro Crear N.D.en FlexLine el Lote " & Paso5.Trim & "?", "Autorización de Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            paso = 6
            Tesoreria()

        End If

    End Sub

    Private Sub Previo_autorizacion()
        If tiene_permisos("mfi_tesoreria_pagos_electronicos") Then
            If MessageBox.Show("Seguro de Autorizar el Lote " & tb_Lote.Text & "?", "Autorización de Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            paso = 6
            Paso5 = tb_Lote.Text
            'MsgBox(tb_Lote.Text)
            Autorizacion()
        End If
    End Sub



    Private Sub btn_Ok6_Click(sender As Object, e As EventArgs) Handles btn_Ok6.Click
        If tiene_permisos("mfi_tesoreria_pagos_electronicos") Then
            If MessageBox.Show("Seguro(a) de Aplicar el Lote a Tesorería? " & tb_Lote.Text & "?", "Tesorería", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            paso = 7
            Tesoreria()
        End If

    End Sub

    Private Sub Tesoreria()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Dim lote As String = ""

        Try

            lote = Paso6.Trim

            oTrans.open()


            ' lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & Paso6.Trim & "','" & gs_usuario & "'," & paso
            lsSQL = "flexline.pa_um_sel_Pagos_Electronicos_Lotes '" & gs_empresa & "','" & Paso5.Trim & "'"
            dt = oTrans.Obtiene(lsSQL)


            If dt.Rows.Count > 0 Then
                Dim oform As New Frm_Tracking_Pagos_Electronicos_Tesoreria
                oform.lote = Paso5.Trim
                oform.ShowDialog()
                Carga_Combos()
            End If
            '    dgv_Detalle.DataSource = dt


            '            lsSQL = "Select Case EMPRESA, Fecha, TIPO_COMPROBANTE, CORRELATIVO From CON_ENCCOM Where EMPRESA ='" & gs_empresa & "' and TIPO_COMPROBANTE='nota de debito' and CORRELATIVO=847001 and PERIODO=YEAR('04-05-2017')"

            'MsgBox("El Lote se Encuentra en Tesorería!!!", MsgBoxStyle.Information, "Tesorería...")
            'Carga_Combos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Busca_Factura_Click(sender As Object, e As EventArgs) Handles btn_Busca_Factura.Click
        If tb_Proveedor.Text.Length = 0 Then
            MsgBox("Debe Ingresar Proveedor!!!", MsgBoxStyle.Critical, "Proveedor")
            tb_Proveedor.Focus()
            tb_Proveedor.SelectAll()
        Else
            dgv_Seguimiento.DataSource = Nothing
            Detalla_Facturas()
        End If
    End Sub

    Private Sub Detalla_Facturas()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            oTrans.open()
            lsSQL = "flexline.pa_um_sel_Pagos_Electronicos_Facturas '" & gs_empresa & "','" & tb_Proveedor.Text & "','" & tb_Factura.Text & "'"
            dt = oTrans.Obtiene(lsSQL)
            dgv_Detalle.DataSource = dt

            If dt.Rows.Count > 0 Then


                If tb_Factura.Text.Length > 0 Then

                    dgv_Seguimiento.DataSource = Nothing

                    lsSQL = "flexline.pa_um_sel_Pagos_Electronicos_Factura '" & gs_empresa & "','" & dt.Rows(0).Item("Lote").ToString & "'"
                    dt = oTrans.Obtiene(lsSQL)

                    If dt.Rows.Count > 0 Then
                        dgv_Seguimiento.DataSource = dt

                    End If

                End If
            Else
                MsgBox("La factura Ingresada No Corresponde al Proveedor, Verifique", MsgBoxStyle.Critical, "Error")
                Limpia_Estados()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Limpia_Estados_Click(sender As Object, e As EventArgs) Handles btn_Limpia_Estados.Click
        Limpia_Estados()
    End Sub

    Private Sub Limpia_Estados()
        dgv_Detalle.DataSource = Nothing
        dgv_Seguimiento.DataSource = Nothing
        tb_Factura.Text = ""
        tb_Proveedor.Text = ""
        tb_Proveedor.Focus()
    End Sub

    Private Sub btn_ObtenerAnular_Click(sender As Object, e As EventArgs) Handles btn_ObtenerAnular.Click
        If tbLoteAnular.Text.Length = 0 Then
            MsgBox("Debe Ingresar Lote", MsgBoxStyle.Critical, "Error")
            tbLoteAnular.Focus()
        Else
            If tiene_permisos("mfi_eliminar_pagos_electronicos") Then
                Obtener()
            End If

        End If
    End Sub

    Private Sub Obtener()
        Dim oform As New Frm_Tracking_Pagos_Electronicos_Obtiene
        oform.Lote = tbLoteAnular.Text
        oform.ShowDialog()
        oform = Nothing
    End Sub

    Private Sub cargaLotesPendientesRevision()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Try

            lsSQL = "pa_var_um_Pagos_Electronicos_Estado '" & gs_empresa & "',4"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "Encabezado_revision"

            If Ods.Tables.Contains(dt.TableName) Then Ods.Tables.Remove(dt.TableName)
            Ods.Tables.Add(dt.Copy)



            lsSQL = "pa_var_um_Pagos_Electronicos_Estado_detalle '" & gs_empresa & "',null,4"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "detalle_revision"
            If Ods.Tables.Contains(dt.TableName) Then Ods.Tables.Remove(dt.TableName)

            Ods.Tables.Add(dt.Copy)


            Me.dgv_encabezado_revision.DataSource = Ods.Tables("encabezado_revision")
            Me.dgv_detalle_revision.DataSource = Ods.Tables("detalle_revision")

            clsGen.Alinear_GridView(Ods.Tables("encabezado_revision"), Me.dgv_encabezado_revision, "", "", "", "", "", "", "", True, True, 200, 0)
            clsGen.Alinear_GridView(Ods.Tables("detalle_revision"), Me.dgv_detalle_revision, "", "", "", "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub
    Private Sub btn_carga_pendientes_revision_Click(sender As Object, e As EventArgs) Handles btn_carga_pendientes_revision.Click

        cargaLotesPendientesRevision()


    End Sub

    Private Sub mostrarDetalleLote()
        Try

            Dim liRow As Integer
            Dim lsFiltro As String

            liRow = Me.dgv_encabezado_revision.CurrentRow.Index

            'ls_resultado = Me.dgv_encabezado_revision.Item("numero", pi_RowNumber).Value
            'tipo_docto = Me.dgv_encabezado.Item("tipodocto", pi_RowNumber).Value
            'ls_empresa = Me.dgv_encabezado.Item("empresa", pi_RowNumber).Value


            ''Se Debe Agregar Empresa Para que no duplique cuando sean los mismo numeros en diferentes empresas

            lsFiltro = "lote = '" & Me.dgv_encabezado_revision.Item("lote", liRow).Value & "'"
            Ods.Tables("detalle_revision").DefaultView.RowFilter = lsFiltro

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_encabezado_revision_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv_encabezado_revision.CurrentCellChanged
        mostrarDetalleLote()
    End Sub



    Private Sub btn_revision_enviar_tesoreria_Click(sender As Object, e As EventArgs) Handles btn_revision_enviar_tesoreria.Click
        Dim liRow As Integer
        Dim lsLote As String
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try

            If tiene_permisos("mfi_revision_pagos_Electronicos") Then



                liRow = Me.dgv_encabezado_revision.CurrentRow.Index

                'ls_resultado = Me.dgv_encabezado_revision.Item("numero", pi_RowNumber).Value
                'tipo_docto = Me.dgv_encabezado.Item("tipodocto", pi_RowNumber).Value
                'ls_empresa = Me.dgv_encabezado.Item("empresa", pi_RowNumber).Value


                ''Se Debe Agregar Empresa Para que no duplique cuando sean los mismo numeros en diferentes empresas

                lsLote = Me.dgv_encabezado_revision.Item("lote", liRow).Value

                If MessageBox.Show("Esta Seguro de Enviar el Lote " & lsLote & " a Tesoreria", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    'lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & lsLote & "','" & gs_usuario & "',2"
                    'clsGen.insertQuery("Flexline", lsSQL)
                    lsSQL = "flexline.pa_umb_ins_Log_Pagos_Electronicos_2 '" & gs_empresa & "','" & lsLote & "','" & gs_usuario & "',6"
                    clsGen.insertQuery("Flexline", lsSQL)

                    MessageBox.Show("Traslado Exitoso", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cargaLotesPendientesRevision()
                End If
            Else
                MessageBox.Show("No Tiene Acceso a Procesar esta informacion ", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If



        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub btnObtenerLotesTesoreria_Click(sender As Object, e As EventArgs) Handles btnObtenerLotesTesoreria.Click
        cargaLotesPendientesTesoreria()
    End Sub

    Private Sub cargaLotesPendientesTesoreria()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Try

            lsSQL = "pa_var_um_Pagos_Electronicos_Estado '" & gs_empresa & "'," & Paso6.Trim
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "Encabezado_tesoreria"

            If Ods.Tables.Contains(dt.TableName) Then Ods.Tables.Remove(dt.TableName)
            Ods.Tables.Add(dt.Copy)



            lsSQL = "pa_var_um_Pagos_Electronicos_Estado_detalle '" & gs_empresa & "',null," & Paso6.Trim
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            dt.TableName = "detalle_tesoreria"
            If Ods.Tables.Contains(dt.TableName) Then Ods.Tables.Remove(dt.TableName)

            Ods.Tables.Add(dt.Copy)


            Me.dgv_encabezado_lote_tesoreria.DataSource = Ods.Tables("encabezado_tesoreria")
            Me.dgv_detalle_lote_tesoreria.DataSource = Ods.Tables("detalle_tesoreria")

            clsGen.Alinear_GridView(Ods.Tables("encabezado_tesoreria"), Me.dgv_encabezado_lote_tesoreria, "", "", "", "", "", "", "", True, True, 200, 0)
            clsGen.Alinear_GridView(Ods.Tables("detalle_tesoreria"), Me.dgv_detalle_lote_tesoreria, "", "", "", "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub



    Private Sub dgv_encabezado_lote_tesoreria_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv_encabezado_lote_tesoreria.CurrentCellChanged
        mostrarDetalleLote_Tesoreria()
    End Sub
    Private Sub mostrarDetalleLote_Tesoreria()
        Try

            Dim liRow As Integer
            Dim lsFiltro As String

            liRow = Me.dgv_encabezado_lote_tesoreria.CurrentRow.Index

            'ls_resultado = Me.dgv_encabezado_revision.Item("numero", pi_RowNumber).Value
            'tipo_docto = Me.dgv_encabezado.Item("tipodocto", pi_RowNumber).Value
            'ls_empresa = Me.dgv_encabezado.Item("empresa", pi_RowNumber).Value


            ''Se Debe Agregar Empresa Para que no duplique cuando sean los mismo numeros en diferentes empresas

            lsFiltro = "lote = '" & Me.dgv_encabezado_lote_tesoreria.Item("lote", liRow).Value & "'"
            Ods.Tables("detalle_tesoreria").DefaultView.RowFilter = lsFiltro

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnProcesarLotesTesoreria_Click(sender As Object, e As EventArgs) Handles btnProcesarLotesTesoreria.Click
        If Not tiene_permisos("mfi_tesoreria_pagos_electronicos") Then
            MessageBox.Show("No Tiene Permisos para realizar este proceso", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim liRow As Integer

        liRow = Me.dgv_encabezado_lote_tesoreria.CurrentRow.Index

        'ls_resultado = Me.dgv_encabezado_revision.Item("numero", pi_RowNumber).Value
        'tipo_docto = Me.dgv_encabezado.Item("tipodocto", pi_RowNumber).Value
        'ls_empresa = Me.dgv_encabezado.Item("empresa", pi_RowNumber).Value


        ''Se Debe Agregar Empresa Para que no duplique cuando sean los mismo numeros en diferentes empresas


        Paso6 = Me.dgv_encabezado_lote_tesoreria.Item("lote", liRow).Value

        Tesoreria()


    End Sub

    Private Sub txtLoteRevision_TextChanged(sender As Object, e As EventArgs) Handles txtLoteRevision.TextChanged

    End Sub

    Private Sub txtLoteRevision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteRevision.KeyPress
        If e.KeyChar = Chr(13) Then
            Ods.Tables("encabezado_revision").DefaultView.RowFilter = ""
            If txtLoteRevision.Text.Length > 0 Then
                Ods.Tables("encabezado_revision").DefaultView.RowFilter = "lote like '%" & Me.txtLoteRevision.Text & "%'"
            End If

        End If
    End Sub

    Private Sub txtLoteTesoreria_TextChanged(sender As Object, e As EventArgs) Handles txtLoteTesoreria.TextChanged

    End Sub

    Private Sub txtLoteTesoreria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoteTesoreria.KeyPress
        If e.KeyChar = Chr(13) Then
            '   Ods.Tables("encabezado_tesoreria").DefaultView.RowFilter = ""
            If txtLoteTesoreria.Text.Length > 0 Then
                '      Ods.Tables("encabezado_tesoreria").DefaultView.RowFilter = "lote like '%" & Me.txtLoteTesoreria.Text & "%'"
                If tiene_permisos("mfi_emision_pagos_electronicos") Then
                    Obtiene_Lote_Creado()
                End If
            End If

        End If
    End Sub

    Private Sub cb_paso5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_paso5.SelectedIndexChanged


































































































    End Sub
End Class