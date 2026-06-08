Public Class frm_int_etiquetado
    Dim Ods As New DataSet

    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function


    Private Function informacionValidaGrabar() As Boolean
        Dim lbInformacionValida As Boolean = False


        If Val(Me.txtNumeroPersonas.Text) > 0 And Val(Me.txtNumeroPersonas.Text) < 25 Then

            For i As Integer = 0 To clbx_etiquetas.Items.Count - 1
                If clbx_etiquetas.GetItemChecked(i) Then
                    'clbx_etiquetas.SetSelected(i, True)
                    lbInformacionValida = True
                End If
            Next
            If Not lbInformacionValida Then
                MessageBox.Show("Debe Seleccionar Que Etiquetas Se Aplicaran", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            MessageBox.Show("Debe Indicar Numero de Personas que Etiquetaran", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If



        If Me.txtCodigoBarra.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Codigo de Barra", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lbInformacionValida = False
        End If

        Return lbInformacionValida



    End Function

    Private Sub llenar_combos_mysql()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim index As Integer = 0
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim newRow As DataRow

        Try
            myOtrans.open()
            otrans.open()

            'ls_sql = "CALL pa_sel_um_sg_usuario_busqueda('" & gs_usuario & "')"
            'dt = myOtrans.Obtiene(ls_sql)
            'solicitado_por.Text = dt.Rows(0)("nombre")

            'ls_sql = "pa_sel_um_maq_control_numero'" & gs_empresa & "'"
            'dt = otrans.Obtiene(ls_sql)

            'If dt.Rows(0)("numero").ToString <> "" Then
            '    Me.txt_op_numero_orden.Text = dt.Rows(0)("numero")
            'Else
            '    Me.txt_op_numero_orden.Text = 1
            'End If

            'Me.txt_op_cantidad_solicitada.Text = 1

            ls_sql = "call pa_sel_um_maq_costo_materiales (2)"
            dt = myOtrans.Obtiene(ls_sql)
            'newRow = dt.NewRow()
            'newRow("descripcion") = "No. Operadores Asignados"
            'dt.Rows.Add(newRow)
            dt.TableName = "costo_primo"
            'dt.Columns.Add("cantidad")
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta_chequeo 1"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "chequeo1"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta_chequeo 2"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "chequeo2"
            dt.Columns.Add("cantidad", GetType(Integer))
            Ods.Tables.Add(dt.Copy)

            clbx_etiquetas.DataSource = Ods.Tables("chequeo1")
            dgv_estados.DataSource = Ods.Tables("chequeo2")

            clbx_etiquetas.DisplayMember = "descripcion"
            clbx_etiquetas.ValueMember = "cod_chequeo"

            dgv_estados.DataSource = Ods.Tables("chequeo2")



            ClsGen.Alinear_GridView(Ods.Tables("chequeo2"), dgv_estados, ",descripcion,cantidad,", ",COD_CHEQUEO,", ",descripcion,", "", "", "", "", False, True, 250, 0)

            'index = 0


            'index = 0
            'For Each row As DataGridViewRow In dgv_estados.Rows
            '    dgv_estados.Item("cantidad", index).Value = 0
            '    index += 1
            'Next


        Catch ex As Exception
            myOtrans.close()
            myOtrans = Nothing

            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub llenar_combos()
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim index As Integer = 0
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim newRow As DataRow

        Try
            '   myOtrans.open()
            otrans.open()

            'ls_sql = "CALL pa_sel_um_sg_usuario_busqueda('" & gs_usuario & "')"
            'dt = myOtrans.Obtiene(ls_sql)
            'solicitado_por.Text = dt.Rows(0)("nombre")

            'ls_sql = "pa_sel_um_maq_control_numero'" & gs_empresa & "'"
            'dt = otrans.Obtiene(ls_sql)

            'If dt.Rows(0)("numero").ToString <> "" Then
            '    Me.txt_op_numero_orden.Text = dt.Rows(0)("numero")
            'Else
            '    Me.txt_op_numero_orden.Text = 1
            'End If

            'Me.txt_op_cantidad_solicitada.Text = 1

            ls_sql = "pa_sel_um_maq_costo_materiales 2"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            'newRow = dt.NewRow()
            'newRow("descripcion") = "No. Operadores Asignados"
            'dt.Rows.Add(newRow)
            dt.TableName = "costo_primo"
            'dt.Columns.Add("cantidad")
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta_chequeo 1"
            dt = otrans.Obtiene(ls_sql)

            dt.TableName = "chequeo1"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_maq_control_produccion_etiqueta_chequeo 2"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "chequeo2"
            dt.Columns.Add("cantidad", GetType(Integer))
            Ods.Tables.Add(dt.Copy)

            clbx_etiquetas.DataSource = Ods.Tables("chequeo1")
            dgv_estados.DataSource = Ods.Tables("chequeo2")

            clbx_etiquetas.DisplayMember = "descripcion"
            clbx_etiquetas.ValueMember = "cod_chequeo"

            dgv_estados.DataSource = Ods.Tables("chequeo2")



            ClsGen.Alinear_GridView(Ods.Tables("chequeo2"), dgv_estados, ",descripcion,cantidad,", ",COD_CHEQUEO,", ",descripcion,", "", "", "", "", False, True, 250, 0)

            'index = 0


            'index = 0
            'For Each row As DataGridViewRow In dgv_estados.Rows
            '    dgv_estados.Item("cantidad", index).Value = 0
            '    index += 1
            'Next


        Catch ex As Exception
            'myOtrans.close()
            'myOtrans = Nothing

            otrans.close()
            otrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub


    Private Sub Llenar_Internaciones_pendientes()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim dr As DataRow

        Dim clsgen As New ClasesGenerales.General
        Dim clsDias As New ClasesGenerales.DiasHabiles

        Try
            otrans.open()

            If Ods.Tables.IndexOf("internaciones_pendientes") > -1 Then Ods.Tables.Remove("internaciones_pendientes")
            If Ods.Tables.IndexOf("internaciones_detalle") > -1 Then Ods.Tables.Remove("internaciones_detalle")

            'If Ods.Tables.IndexOf("internaciones_dua") > -1 Then ds_internaciones.Tables.Remove("internaciones_dua")


            ls_sql = "pa_var_um_int_pedido_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_pendientes"
            Ods.Tables.Add(dt.Copy)
            Me.dgvInternaciones.DataSource = Ods.Tables("internaciones_pendientes")

            ls_sql = "pa_sel_um_int_pedido_detalle_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_detalle"
            Ods.Tables.Add(dt.Copy)
            Me.dgvInternacionesDetalle.DataSource = Ods.Tables("internaciones_detalle")

            aplicarFiltro()
            'verificarFechaIngreso()



            'For Each drv As DataRowView In ds_internaciones.Tables("internaciones_pendientes").DefaultView
            '    drv.Item("dias_tramite") = clsDias.Obtener_DiasHabiles(gs_empresa, Date.Parse(drv.Item("fecha").ToString), Today) - 1

            '    If drv.Item("dias_tramite") < 0 Then drv.Item("dias_tramite") = 0

            'Next
            Ods.Tables("internaciones_pendientes").DefaultView.RowFilter = "di <> ''"
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If Ods.Tables.Contains("internaciones_pendientes") Then clsgen.Alinear_GridView(Ods.Tables("internaciones_pendientes"), dgvInternaciones, ",empresa,di,nombre,", "", "", ",dias_estado_actual,", ",fechaingreso=Fecha Prob Ingreso,", ",cod_pedido=40,fecha=75,fechaingreso=75,dias_tramite=30,dias_estado_actual=40,", ",empresa,proveedor,di", True, True, 200, 0)
        'If ds_internaciones.Tables.Contains("internaciones_detalle") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", "", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)
        clsgen = Nothing
        filtrarDI()
    End Sub

    Private Sub filtrarDI()
        Try
            If Me.txtFiltroDI.Text.Length > 0 Then
                Ods.Tables("internaciones_pendientes").DefaultView.RowFilter = "di like '%" & Me.txtFiltroDI.Text & "%'"
            Else
                Ods.Tables("internaciones_pendientes").DefaultView.RowFilter = "di <> ''"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub buscarProducto()
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Try

            Ods.Tables("internaciones_detalle").DefaultView.RowFilter = "cod_pedido = " & Me.txtCodPedido.Text & " and producto = '" & Me.txtCodigoProducto.Text & "'"
            If Ods.Tables("internaciones_detalle").DefaultView.Count > 0 Then
                drv = Ods.Tables("internaciones_detalle").DefaultView(0)
                Me.txtGlosaProducto.Text = drv.Item("glosa").ToString
                Me.txtCantidad.Text = drv.Item("cantidad").ToString * drv.Item("factoralt").ToString

                ''Debo verificar si ya inicio el etiquetado
                dt = clsGen.selectQuery("SCM", "pa_var_um_maq_control_produccion_etiqueta '" & Me.txtEmpresa.Text & "','" & Me.txtCodigoProducto.Text & "','" & Me.txtDI.Text & "'")
                If dt.Rows.Count > 0 Then
                    Me.txtNumeroOrdenEtiquetado.Text = dt.Rows(0)("numero")

                    ''Debo Establecer si esta en Pausa
                    dt = clsGen.selectQuery("SCM", "pa_sel_um_maq_control_produccion_avance '" & Me.txtEmpresa.Text & "','" & Me.txtNumeroOrdenEtiquetado.Text & "'")

                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("motivo").ToString.ToLower = "pausa" Then
                            Me.btnIniciar.Visible = False
                            Me.btnPausa.Visible = False
                            Me.btnFinalizar.Visible = False
                            Me.gbInicial.Enabled = False
                            Me.gbFinal.Enabled = False
                            Me.lblCantidadActual.Visible = False
                            Me.txtCantidadActual.Visible = False
                            Me.btnReinicio.Visible = True
                        Else
                            Me.btnIniciar.Visible = False
                            Me.btnPausa.Visible = True
                            Me.btnFinalizar.Visible = True
                            Me.gbInicial.Enabled = False
                            Me.gbFinal.Enabled = True
                            Me.lblCantidadActual.Visible = True
                            Me.txtCantidadActual.Visible = True
                            Me.btnReinicio.Visible = False

                        End If

                    Else
                        Me.btnIniciar.Visible = False
                        Me.btnPausa.Visible = True
                        Me.btnFinalizar.Visible = True
                        Me.gbInicial.Enabled = False
                        Me.gbFinal.Enabled = False
                        Me.lblCantidadActual.Visible = True
                        Me.txtCantidadActual.Visible = True
                    End If

 

                Else 'iniciara con el proceso
                    Me.gbInicial.Enabled = True
                    Me.gbFinal.Enabled = False
                    Me.btnIniciar.Visible = True
                    Me.btnPausa.Visible = False
                    Me.btnFinalizar.Visible = False
                End If

                Else
                    MessageBox.Show("Este Producto No Forma Parte de la DI " & Me.txtDI.Text, "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnIniciar.Visible = False
                    Me.btnPausa.Visible = False
                    Me.btnIniciar.Visible = False
                    Me.btnFinalizar.Visible = False
                End If

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub limpiarProducto()
        Me.txtGlosaProducto.Text = String.Empty
        Me.txtCantidad.Text = String.Empty
        Me.btnIniciar.Visible = False
        Me.btnPausa.Visible = False
        Me.btnIniciar.Visible = False
        Me.btnFinalizar.Visible = False
        Me.gbFinal.Enabled = False
        Me.gbInicial.Enabled = False
        Me.lblCantidadActual.Visible = False
        Me.txtCantidadActual.Visible = False
        Me.btnReinicio.Visible = False
        Me.txtBarraOriginal.Text = String.Empty

        Try
            For Each dr As DataRow In Ods.Tables("chequeo2").Rows
                dr.Item("cantidad") = 0
            Next

        Catch ex As Exception

        End Try

        Try
            For i As Integer = 0 To clbx_etiquetas.Items.Count - 1
                clbx_etiquetas.SetItemCheckState(i, CheckState.Unchecked)
            Next

        Catch ex As Exception

        End Try
    End Sub


    Private Sub LimpiarPantalla()
        limpiarProducto()
        Me.txtDI.Text = String.Empty
        Me.txtEmpresa.Text = String.Empty
        Me.txtProveedor.Text = String.Empty
        Me.txtCodPedido.Text = String.Empty
        Me.txtCodigoBarra.Text = String.Empty
        Me.txtCodigoProducto.Text = String.Empty
        Me.txtGlosaProducto.Text = String.Empty
        Me.txtCantidad.Text = String.Empty
        Me.btnIniciar.Visible = False
        Me.btnPausa.Visible = False
        Me.btnIniciar.Visible = False
        Me.btnFinalizar.Visible = False
        Me.gbFinal.Enabled = False
        Me.gbInicial.Enabled = False
        Me.lblCantidadActual.Visible = False
        Me.txtCantidadActual.Visible = False
        Me.btnReinicio.Visible = False
    End Sub

    Private Sub grabar_Inicial()

        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable


        Try

            lsSQL = "pa_sel_um_maq_control_numero'" & Me.txtEmpresa.Text & "'"
            dt = clsGen.selectQuery("SCM", lsSQL)


            If dt.Rows(0)("numero").ToString <> "" Then
                Me.txtNumeroOrdenEtiquetado.Text = dt.Rows(0)("numero")
            Else
                Me.txtNumeroOrdenEtiquetado.Text = 1
            End If



            lsSQL = "pa_ins_um_maq_control_produccion_etiqueta '" & Me.txtEmpresa.Text & "','" & Me.txtNumeroOrdenEtiquetado.Text & "','" & _
                        Me.txtCodigoProducto.Text & "'," & Me.txtCantidad.Text & ",'" & Me.txtDI.Text & "','" & _
                        Today.ToString("dd/MM/yyyy") & "','" & gs_usuario & "',0,0,0," & Me.txtNumeroPersonas.Text
            clsGen.insertQuery("SCM", lsSQL)

            lsSQL = "pa_ins_um_maq_orden_produccion_avance '" & Me.txtEmpresa.Text & "'," & Me.txtNumeroOrdenEtiquetado.Text & ",0,'" & _
                        gs_usuario & "','Inicio'"
            clsGen.insertQuery("SCM", lsSQL)



            For i As Integer = 0 To clbx_etiquetas.Items.Count - 1
                If clbx_etiquetas.GetItemChecked(i) Then
                    clbx_etiquetas.SetSelected(i, True)
                    lsSQL = "pa_ins_um_maq_control_produccion_etiqueta_detalle " & _
                                        txtNumeroOrdenEtiquetado.Text & ",'" & Me.txtEmpresa.Text & "'," & clbx_etiquetas.SelectedValue.ToString & _
                                        ",1,'" & gs_usuario & "','" & Now() & "'"

                    clsGen.insertQuery("SCM", lsSQL)
                    'otrans.Ingresa(ls_sql)
                End If
            Next

            ''Informacion se Graba Al Final

            'index = 0
            'For Each row As DataGridViewRow In dgv_chequeo.Rows
            '    If dgv_chequeo.Item("cantidad", index).Value > 0 Then
            '        ls_sql = "pa_ins_um_maq_control_produccion_etiqueta_detalle " & _
            '                            txt_op_numero_orden.Text & ",'" & gs_empresa & "'," & dgv_chequeo.Item("cod_chequeo", index).Value & _
            '                            "," & dgv_chequeo.Item("cantidad", index).Value & ",'" & gs_usuario & "','" & Now() & "'"


            '        otrans.Ingresa(ls_sql)

            '    End If
            '    index += 1
            'Next

            MessageBox.Show("Informacion Grabada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.limpiarProducto()

        Catch ex As Exception

        End Try



    End Sub


    Private Sub grabarPausa()

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Try

            lsSQL = "pa_ins_um_maq_orden_produccion_avance '" & Me.txtEmpresa.Text & "'," & Me.txtNumeroOrdenEtiquetado.Text & "," & Me.txtCantidadActual.Text & ",'" & _
                    gs_usuario & "','Pausa'"
            clsGen.insertQuery("SCM", lsSQL)

            MessageBox.Show("Proceso Almacenado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.limpiarProducto()
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub


    Private Sub grabarReinicio()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Try

            lsSQL = "pa_ins_um_maq_orden_produccion_avance '" & Me.txtEmpresa.Text & "'," & Me.txtNumeroOrdenEtiquetado.Text & ",0,'" & _
                    gs_usuario & "','Reinicio'"
            clsGen.insertQuery("SCM", lsSQL)

            MessageBox.Show("Proceso Almacenado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.limpiarProducto()

        Catch ex As Exception
            clsGen = Nothing
        End Try
    End Sub

    Private Function validarFinalizar() As Boolean
        Dim lbDatosValidos As Boolean = False
        Dim cantidad As Integer
        Try
            If Val(Me.txtCantidadActual.Text) = Val(Me.txtCantidad.Text) Then

                'cantidad = Ods.Tables("chequeo2").Compute("sum(Cantidad)", "Cantidad > 0")
                For Each dr As DataRow In Ods.Tables("chequeo2").Rows
                    cantidad += dr.Item("cantidad")
                Next
                If cantidad = 0 Then

                    If MessageBox.Show("Esta Seguro Que No Hay Producto con Daño/Faltante", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        lbDatosValidos = True
                    End If

                Else
                    lbDatosValidos = True


                End If


            Else
                MessageBox.Show("La Cantidad No Corresponde a la DI", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try



        Return lbDatosValidos

    End Function

    Private Sub grabarFinalizar()


        Try
            Dim clsGen As New ClasesGenerales.General
            Dim lsSQL As String
            Try

                lsSQL = "pa_ins_um_maq_orden_produccion_avance '" & Me.txtEmpresa.Text & "'," & Me.txtNumeroOrdenEtiquetado.Text & "," & Me.txtCantidadActual.Text & ",'" & _
                        gs_usuario & "','Finalizo'"
                clsGen.insertQuery("SCM", lsSQL)


                For Each dr As DataRow In Ods.Tables("chequeo2").Rows
                    If dr.Item("cantidad") > 0 Then
                        lsSQL = "pa_ins_um_maq_control_produccion_etiqueta_detalle " & _
                                                    txtNumeroOrdenEtiquetado.Text & ",'" & Me.txtEmpresa.Text & "'," & _
                                                        dr.Item("cod_chequeo") & "," & dr.Item("cantidad") & ",'" & gs_usuario & "','" & Now() & "'"
                        clsGen.insertQuery("SCM", lsSQL)
                    End If
                Next

                ''Calcular el Costo Primo
                calcularCostoPrimo()

                MessageBox.Show("Proceso Almacenado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.limpiarProducto()
            Catch ex As Exception
                clsGen = Nothing
            End Try


        Catch ex As Exception
        Finally

        End Try
    End Sub


    Private Sub calcularCostoPrimo()

        Dim clsGen As New ClasesGenerales.General

        Try

            Dim ldCostoPrimo As Double = 0
            Dim ldCostoHora As Double = 0
            Dim ldHoras As Double
            Dim dt As DataTable
            Dim ldOperarios As Double = 0
            'Horas Laboradas x Costo Por Hora x Cantidad de Personas

            If Me.chkTiempoExtra.CheckState = CheckState.Unchecked Then
                Ods.Tables("costo_primo").DefaultView.RowFilter = "cod_material = 15"
            Else
                Ods.Tables("costo_primo").DefaultView.RowFilter = "cod_material = 16"
            End If
            ldCostoHora = Ods.Tables("costo_primo").DefaultView(0).Item("costo")

            ''Debo verificar si ya inicio el etiquetado
            dt = clsGen.selectQuery("SCM", "pa_var_um_maq_control_produccion_etiqueta '" & Me.txtEmpresa.Text & "','" & Me.txtCodigoProducto.Text & "','" & Me.txtDI.Text & "'")
            ldOperarios = dt.Rows(0).Item("operario")


            ''Debo Establecer si esta en Pausa
            dt = clsGen.selectQuery("SCM", "pa_sel_um_maq_control_produccion_avance '" & Me.txtEmpresa.Text & "','" & Me.txtNumeroOrdenEtiquetado.Text & "'")
            Dim ldtInicio, ldtfinal As Date
            Dim ldtInicioPausa, ldtfinalPausa As Date
            Dim ldtiempoIntermedio As Double = 0

            For Each dr As DataRow In dt.Rows
                If dr.Item("motivo").ToString.ToLower = "inicio" Then
                    ldtInicio = dr.Item("fecha_grabo")
                ElseIf dr.Item("motivo").ToString.ToLower = "final" Then
                    ldtfinal = dr.Item("fecha_grabo")
                ElseIf dr.Item("motivo").ToString.ToLower = "pausa" Then
                    ldtInicioPausa = dr.Item("fecha_grabo")
                ElseIf dr.Item("motivo").ToString.ToLower = "reinicio" Then
                    ldtfinalPausa = dr.Item("fecha_grabo")
                    ldtiempoIntermedio = ldtiempoIntermedio + DateDiff(DateInterval.Hour, ldtfinalPausa, ldtInicioPausa)
                End If
            Next


            ldHoras = DateDiff(DateInterval.Hour, ldtfinalPausa, ldtInicioPausa) - ldtiempoIntermedio


            ldCostoPrimo = ldHoras * ldCostoHora * ldOperarios


            clsGen.insertQuery("SCM", "pa_up_um_maq_control_produccion_etiqueta_CostoPrimo '" & Me.txtEmpresa.Text & "','" & Me.txtNumeroOrdenEtiquetado.Text & "'," & ldCostoPrimo)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AplicarFiltro()
        Dim nrow, npedido As Integer
        Dim clsGen As New ClasesGenerales.General

        Try
            nrow = Me.dgvInternaciones.CurrentCell.RowIndex
            npedido = Me.dgvInternaciones.Item("cod_pedido", nrow).Value.ToString

            Ods.Tables("internaciones_detalle").DefaultView.RowFilter = "cod_pedido = " & npedido
            'ds_internaciones.Tables("internaciones_dua").DefaultView.RowFilter = "cod_pedido = " & npedido
            clsGen.Alinear_GridView(Ods.Tables("internaciones_detalle"), dgvInternacionesDetalle, "", "", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub actualizarBarra()

        Dim clsGen As New ClasesGenerales.General
        Try
            clsGen.insertQuery("SCM", "pa_ins_um_producto_verificacion_barra '" & Me.txtEmpresa.Text & "','" & Me.txtCodigoProducto.Text & "','" & _
                                                Me.txtCodigoBarra.Text & "','Etiquetado DA','" & gs_usuario & "'")

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub
    Private Sub frm_int_etiquetado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarPantalla()
        llenar_combos()
    End Sub


    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        Llenar_Internaciones_pendientes()
    End Sub

    
    Private Sub dgvInternaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInternaciones.CellDoubleClick
        Try
            LimpiarPantalla()
            AplicarFiltro()
            
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtCodigoProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoProducto.KeyPress
        If e.KeyChar = Chr(13) Then
            limpiarProducto()
            buscarProducto()
        End If
    End Sub



    Private Sub txtCodigoProducto_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoProducto.TextChanged

    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        'Me.gbFinal.Enabled = True
        If Val(Me.txtCantidadActual.Text) > 0 Then
            If MessageBox.Show("Esta Seguro de Finalizar El Etiquetado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If validarFinalizar() = True Then
                    grabarFinalizar()

                End If
            End If
        Else
            MessageBox.Show("Debe Ingresar La Cantidad Etiquetada Actual", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btnPausa_Click(sender As Object, e As EventArgs) Handles btnPausa.Click
        If Val(Me.txtCantidadActual.Text) > 0 Then
            grabarPausa()
        Else
            MessageBox.Show("Debe Ingresar La Cantidad Etiquetada Actual", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAplicarInformacionInicial_Click(sender As Object, e As EventArgs) Handles btnAplicarInformacionInicial.Click
        If informacionValidaGrabar() Then


            If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                grabar_Inicial()
            End If
        End If
    End Sub

    Private Sub txtNumeroPersonas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroPersonas.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnReinicio_Click(sender As Object, e As EventArgs) Handles btnReinicio.Click
        If MessageBox.Show("Esta Seguro de Reiniciar El Etiquetado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            grabarReinicio()
        End If
    End Sub

    Private Sub txtFiltroDI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroDI.KeyPress
        If e.KeyChar = Chr(13) Then
            filtrarDI()
        End If
    End Sub

    Private Sub txtFiltroDI_TextChanged(sender As Object, e As EventArgs) Handles txtFiltroDI.TextChanged

    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click

    End Sub

    Private Sub dgvInternacionesDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInternacionesDetalle.CellContentClick

    End Sub

    Private Sub dgvInternacionesDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInternacionesDetalle.CellDoubleClick
        Try

            LimpiarPantalla()
            Dim nrow As Integer = Me.dgvInternaciones.CurrentRow.Index
            'If MessageBox.Show("Esta Seguro que la Factura " & Me.dg_facturas.Item("numero", nrow).Value.ToString & " La Recogera El Cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.txtEmpresa.Text = Me.dgvInternaciones.Item("empresa", nrow).Value.ToString
            Me.txtDI.Text = Me.dgvInternaciones.Item("di", nrow).Value.ToString
            Me.txtProveedor.Text = Me.dgvInternaciones.Item("nombre", nrow).Value.ToString
            Me.txtCodPedido.Text = Me.dgvInternaciones.Item("cod_pedido", nrow).Value.ToString

            nrow = Me.dgvInternacionesDetalle.CurrentRow.Index

            Me.txtCodigoProducto.Text = Me.dgvInternacionesDetalle.Item("producto", nrow).Value.ToString
            Me.buscarProducto()

            TabControl1.SelectedIndex = 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCodigoBarra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoBarra.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.txtCodigoBarra.Text <> Me.txtBarraOriginal.Text Then
                If MessageBox.Show("Esta Seguro de Esta Barra", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    actualizarBarra()
                    Me.txtCodigoBarra.SelectAll()
                End If

            End If
        End If
    End Sub


End Class