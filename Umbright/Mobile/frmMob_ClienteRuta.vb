
Public Class frmMob_ClienteRuta
    Dim ods As New DataSet
    Private Sub crearEstructura()
        Dim dt As New DataTable("cliente_ruta")

        dt.Columns.Add(New DataColumn("corporativo", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("razon_social", GetType(String)))
        dt.Columns.Add(New DataColumn("ruta", GetType(String)))
        dt.Columns.Add(New DataColumn("frecuencia", GetType(String)))
        dt.Columns.Add(New DataColumn("orden_visita", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ejecutivo", GetType(String)))
        dt.Columns.Add(New DataColumn("nuevo", GetType(Integer)))

        ods.Tables.Add(dt.Copy)

        dt.TableName = "cliente_ruta_eliminado"
        ods.Tables.Add(dt.Copy)

        dt = New DataTable("mfrecuencia")
        dt.Columns.Add(New DataColumn("frecuencia", GetType(String)))
        ods.Tables.Add(dt.Copy)

        dt = New DataTable("mruta")
        dt.Columns.Add(New DataColumn("ruta", GetType(String)))
        ods.Tables.Add(dt.Copy)



    End Sub

    Private Sub llenarCombo()
        Dim dr As DataRow

        Dim mdatos(6) As String
        mdatos(0) = "SS"
        mdatos(1) = "M1"
        mdatos(2) = "M2"
        mdatos(3) = "M3"
        mdatos(4) = "M4"
        mdatos(5) = "Q1"
        mdatos(6) = "Q2"

        Dim mdatos2(6) As String
        mdatos2(0) = "LUNES"
        mdatos2(1) = "MARTES"
        mdatos2(2) = "MIERCOLES"
        mdatos2(3) = "JUEVES"
        mdatos2(4) = "VIERNES"
        mdatos2(5) = "SABADO"
        mdatos2(6) = "DOMINGO"


        For icount As Integer = 0 To 6
            dr = ods.Tables("mruta").NewRow
            dr.Item("ruta") = mdatos2(icount)
            ods.Tables("mruta").Rows.Add(dr)

            dr = ods.Tables("mfrecuencia").NewRow
            dr.Item("frecuencia") = mdatos(icount)
            ods.Tables("mfrecuencia").Rows.Add(dr)
        Next


        Dim dt As DataTable
        dt = ods.Tables("mfrecuencia").Copy
        cmbFrecuencia.DataSource = dt
        cmbFrecuencia.DisplayMember = "frecuencia"
        cmbFrecuencia.ValueMember = "frecuencia"

        cmbRuta.DataSource = ods.Tables("mruta")
        cmbRuta.DisplayMember = "ruta"
        cmbRuta.ValueMember = "ruta"



    End Sub

    Private Sub llenarInformacion()
        Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")
        Dim clsGen As New ClasesGenerales.General()
        Dim dt As DataTable
        Dim lsSQL As String
        Dim draux As DataRow

        Try
            myOtrans.open()
            lsSQL = "call pa_sel_um_mov_cliente ('" & gs_empresa & "')"
            dt = myOtrans.Obtiene(lsSQL)
            'dt.Columns.Add(New DataColumn("asignado", GetType(Integer)))
            dt.TableName = "cliente_empresa"
            If ods.Tables.Contains("cliente_empresa") Then ods.Tables.Remove("cliente_empresa")

            ods.Tables.Add(dt.Copy)
            Me.dgListadoCliente.DataSource = ods.Tables("cliente_empresa")
            clsGen.Alinear_GridView(ods.Tables("cliente_empresa"), Me.dgListadoCliente, "", ",empresa,condpago,ruta,ordenvisita,frecuencia,asignado,", "", "", "", "", ",ctacte,razonsocial,direccion,ejecutivo,", True, True, 200, 0)

            lsSQL = "call pa_sel_um_mov_cliente_ruta ('" & gs_empresa & "')"
            dt = myOtrans.Obtiene(lsSQL)

            ods.Tables("cliente_ruta").Rows.Clear()
            ods.Tables("cliente_ruta_eliminado").Rows.Clear()

            For Each dr As DataRow In dt.Rows
                draux = ods.Tables("cliente_ruta").NewRow
                If dr.Item("corporativo") = 1 Then
                    draux.Item("corporativo") = 1
                Else
                    draux.Item("corporativo") = 0
                End If
                draux.Item("corporativo") = dr.Item("corporativo")

                draux.Item("ctacte") = dr.Item("ctacte")
                draux.Item("razon_social") = dr.Item("razonsocial")
                draux.Item("ruta") = dr.Item("ruta")
                draux.Item("frecuencia") = dr.Item("frecuencia")
                draux.Item("orden_visita") = dr.Item("ordenvisita")
                draux.Item("ejecutivo") = dr.Item("ejecutivo")
                draux.Item("nuevo") = 0

                ods.Tables("cliente_ruta").Rows.Add(draux)
            Next


            Me.dgv_enrutados.DataSource = ods.Tables("cliente_ruta")

            'Dim dgtbc As New DataGridViewComboBoxColumn
            'dgtbc.DataSource = ods.Tables("mfrecuencia")
            'dgtbc.ValueMember = "frecuencia"
            'dgtbc.DisplayMember = "frecuencia"
            'dgtbc.HeaderText = "frecuencia"
            'dgtbc.DataPropertyName = "frecuencia"
            'dgtbc.Name = "frecuencia"

            'clsGen.Alinear_GridViewComboBox(dgtbc)

            'clsGen.Alinear_GridView(ods.Tables("cliente_ruta"), Me.dgv_enrutados, "", ",ejecutivo,nuevo,", ",ctacte,razon_social,ruta,ejecutivo,", "", "", "", "", True, True, 200, 0)


            lsSQL = "CALL pa_sel_um_sg_usuario_busqueda(null)"
            dt = myOtrans.Obtiene(lsSQL)
            dt.DefaultView.RowFilter = "estatus = 1 and (cod_tipo_usuario = 7 or cod_tipo_usuario = 6)"
            dt = dt.DefaultView.Table
            lsSQL = cmbVendedor.Text.ToString
            cmbVendedor.DataSource = dt
            cmbVendedor.DisplayMember = "nombre"
            cmbVendedor.ValueMember = "nombre"
            cmbVendedor.SelectedValue = lsSQL


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing
            aplicarFiltro()
            filtroClientes()

        End Try

    End Sub

    Private Sub aplicarFiltro()
        Dim lsFiltro As String
        Dim clsGen As New ClasesGenerales.General

        Try


            If Me.cmbVendedor.SelectedValue.ToString.Length > 0 Then


                lsFiltro = "ejecutivo = '" & Me.cmbVendedor.SelectedValue.ToString & "'"
                If Me.chk_ruta.CheckState = CheckState.Checked Then lsFiltro += " and ruta = '" & Me.cmbRuta.SelectedValue.ToString & "'"
                If Me.chk_frecuencia.CheckState = CheckState.Checked Then lsFiltro += " and frecuencia = '" & Me.cmbFrecuencia.SelectedValue.ToString & "'"

                ods.Tables("cliente_ruta").DefaultView.RowFilter = lsFiltro
            End If


            Me.dgv_enrutados.DataSource = ods.Tables("cliente_ruta")

            Dim dgtbc As New DataGridViewComboBoxColumn
            dgtbc.DataSource = ods.Tables("mfrecuencia")
            dgtbc.ValueMember = "frecuencia"
            dgtbc.DisplayMember = "frecuencia"
            dgtbc.HeaderText = "frecuencia"
            dgtbc.DataPropertyName = "frecuencia"
            dgtbc.Name = "frecuencia"

            clsGen.Alinear_GridViewComboBox(dgtbc)

            clsGen.Alinear_GridView(ods.Tables("cliente_ruta"), Me.dgv_enrutados, ",corporativo,ctacte,razon_social,ruta,ejecutivo,orden_visita,", ",ejecutivo,nuevo,", ",ctacte,razon_social,ruta,ejecutivo,", "", "", "", "", True, True, 200, 0)


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub

    Private Sub agregarCliente()
        Dim nrow As Integer

        nrow = Me.dgListadoCliente.CurrentCell.RowIndex
        Dim dr As DataRow
        dr = ods.Tables("cliente_ruta").NewRow
        With dr
            .Item("corporativo") = 0
            .Item("ctacte") = Me.dgListadoCliente.Item("ctacte", nrow).Value
            .Item("razon_social") = Me.dgListadoCliente.Item("razonsocial", nrow).Value
            .Item("ruta") = Me.cmbRuta.SelectedValue.ToString
            .Item("frecuencia") = Me.cmbFrecuencia.SelectedValue.ToString
            .Item("orden_visita") = 0
            .Item("ejecutivo") = Me.cmbVendedor.SelectedValue.ToString
            .Item("nuevo") = 1
        End With

        ods.Tables("cliente_ruta").Rows.Add(dr)
        Me.dgListadoCliente.Rows.RemoveAt(nrow)


    End Sub

    Private Sub agregarRowelimados()
        Dim nrow As Integer

        nrow = Me.dgv_enrutados.CurrentCell.RowIndex
        Dim dr As DataRow
        dr = ods.Tables("cliente_ruta_eliminado").NewRow
        With dr
            .Item("ctacte") = Me.dgv_enrutados.Item("ctacte", nrow).Value
            .Item("razon_social") = Me.dgv_enrutados.Item("razon_social", nrow).Value
            .Item("ruta") = Me.dgv_enrutados.Item("ruta", nrow).Value
            .Item("frecuencia") = Me.dgv_enrutados.Item("frecuencia", nrow).Value
            .Item("orden_visita") = Me.dgv_enrutados.Item("orden_visita", nrow).Value
            .Item("ejecutivo") = Me.dgv_enrutados.Item("ejecutivo", nrow).Value
        End With
        ods.Tables("cliente_ruta_eliminado").Rows.Add(dr)

    End Sub


    Private Sub filtroClientes()
        Dim lsFiltro As String
        If Me.txtValor.Text.Length > 0 Then
            lsFiltro = Me.cmbCriterio.SelectedItem.ToString & " "
            lsFiltro += Me.cmbCondicion.SelectedItem.ToString & "'" & IIf(Me.cmbCondicion.SelectedItem.ToString.StartsWith("lik"), "%", "")
            lsFiltro += Me.txtValor.Text & IIf(Me.cmbCondicion.SelectedItem.ToString.StartsWith("lik"), "%", "") & "'"
        Else
            lsFiltro = ""
        End If
        Try
            ods.Tables("cliente_empresa").DefaultView.RowFilter = lsFiltro
        Catch ex As Exception

        End Try



    End Sub

    Private Sub guardarCambios()
        Dim lsMensaje As String
        Dim lsSQL, ls_sql As String
        Dim icount As Integer
        Dim i As Integer
        Dim dt As DataTable

        Dim empresa As String = ""

        lsMensaje = "Se Procedera a Realizar Los Siguientes Cambios " & Chr(13)


        icount = ods.Tables("cliente_ruta").Compute("Count(ctacte)", "nuevo = 1")
        If icount > 0 Then lsMensaje += "Se Agregaran " & icount & " Clientes " & Chr(13)
        icount = ods.Tables("cliente_ruta").Compute("Count(ctacte)", "nuevo = 2")
        If icount > 0 Then lsMensaje += "Se Modificaran " & icount & " Clientes " & Chr(13)
        If ods.Tables("cliente_ruta_eliminado").Rows.Count > 0 Then lsMensaje += "Se Eliminaran " & ods.Tables("cliente_ruta_eliminado").Rows.Count & " Clientes " & Chr(13)

        lsMensaje += "Esta Seguro de Continuar"
        If MessageBox.Show(lsMensaje, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")
            Try


                myOtrans.open()

                For Each dr As DataRow In ods.Tables("cliente_ruta_eliminado").Rows
                    'ls_sql = "call pa_sel_um_mov_cliente_ruta_count ('" & dr.Item("ctacte").ToString & "')"
                    'dt = myOtrans.Obtiene(ls_sql)

                    'If dt.Rows(0).Item("cantidad") > 1 Then
                    '    For i = 0 To 2
                    '        If i = 1 Then
                    '            empresa = "CODICASA"
                    '        ElseIf i = 2 Then
                    '            empresa = "DMARTE1"
                    '        Else
                    '            empresa = "DIUVA"
                    '        End If
                    '        lsSQL = "call pa_del_um_mov_cliente_ruta_corp ('" & empresa & "','" & dr.Item("ctacte").ToString & "','" & _
                    '       dr.Item("ejecutivo").ToString & "','" & dr.Item("ruta").ToString & "','" & gs_usuario & "')"
                    '        myOtrans.Elimina(lsSQL)
                    '    Next

                    'Else
                    'Se Debe Eliminar en Cada Empresa
                    lsSQL = "call pa_del_um_mov_cliente_ruta ('" & gs_empresa & "','" & dr.Item("ctacte").ToString & "','" & _
                          dr.Item("ejecutivo").ToString & "','" & dr.Item("ruta").ToString & "','" & gs_usuario & "')"
                    myOtrans.Elimina(lsSQL)

                    'End If


                    If myOtrans.Codigo_error > 0 Then
                        MessageBox.Show("Problemas al Eliminar " & dr.Item("ctacte") & dr.Item("razon_social"), "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next

                ''Agregar Clientes Nuevos

                ods.Tables("cliente_ruta").DefaultView.RowFilter = "nuevo = 1"
                For Each drv As DataRowView In ods.Tables("cliente_ruta").DefaultView


                    If drv.Item("corporativo") Then
                        ' for para empresas cuando es corporativo
                        'Cuando Es corporativo nos aseguramos que se elimen por completo
                        lsSQL = "call pa_del_um_mov_cliente_ruta_corp ('" & gs_empresa & "','" & drv.Item("ctacte").ToString & "','" & _
                         drv.Item("ejecutivo").ToString & "','" & drv.Item("ruta").ToString & "','" & gs_usuario & "')"
                        myOtrans.Elimina(lsSQL)

                        For i = 0 To 2
                            If i = 0 Then
                                empresa = "CODICASA"
                            ElseIf i = 1 Then
                                empresa = "DMARTE1"
                            Else
                                empresa = "DIUVA"
                            End If

 
                            lsSQL = "call pa_ins_um_mov_cliente_ruta ('" & empresa & "','" & drv.Item("ctacte").ToString & "','" & _
                                                        drv.Item("ejecutivo").ToString & "','" & drv.Item("ruta").ToString & "','" & _
                                                        drv.Item("frecuencia").ToString & "'," & drv.Item("orden_visita") & ",'" & _
                                                        gs_usuario & "'," & 1 & ")"
                            myOtrans.Ingresa(lsSQL)
                        Next

                    Else
                        lsSQL = "call pa_ins_um_mov_cliente_ruta ('" & gs_empresa & "','" & drv.Item("ctacte").ToString & "','" & _
                                                        drv.Item("ejecutivo").ToString & "','" & drv.Item("ruta").ToString & "','" & _
                                                        drv.Item("frecuencia").ToString & "'," & drv.Item("orden_visita") & ",'" & _
                                                        gs_usuario & "'," & 0 & ")"
                        myOtrans.Ingresa(lsSQL)
                    End If

                    If myOtrans.Codigo_error > 0 Then
                        MessageBox.Show("Problemas al Insertar " & drv.Item("ctacte") & drv.Item("razon_social"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next



                ods.Tables("cliente_ruta").DefaultView.RowFilter = "nuevo = 2"
                For Each drv As DataRowView In ods.Tables("cliente_ruta").DefaultView

                    If drv.Item("corporativo") Then
                        ' cambiar a corporativo

                        lsSQL = "call pa_del_um_mov_cliente_ruta_corp ('" & gs_empresa & "','" & drv.Item("ctacte").ToString & "','" & _
                         drv.Item("ejecutivo").ToString & "','" & drv.Item("ruta").ToString & "','" & gs_usuario & "')"
                        myOtrans.Elimina(lsSQL)

                        For i = 0 To 2
                            If i = 1 Then
                                empresa = "CODICASA"
                            ElseIf i = 2 Then
                                empresa = "DMARTE1"
                            Else
                                empresa = "DIUVA"
                            End If
                            lsSQL = "call pa_ins_um_mov_cliente_ruta ('" & empresa & "','" & drv.Item("ctacte").ToString & "','" & _
                                                        drv.Item("ejecutivo").ToString & "','" & drv.Item("ruta").ToString & "','" & _
                                                        drv.Item("frecuencia").ToString & "'," & drv.Item("orden_visita") & ",'" & _
                                                        gs_usuario & "'," & 1 & ")"
                            myOtrans.Ingresa(lsSQL)
                        Next
                    Else
                        'actualiza si no esta chequeado (por empresa)

                        lsSQL = "call pa_upd_um_mov_cliente_ruta ('" & gs_empresa & "','" & drv.Item("ctacte").ToString & "','" & _
                                               drv.Item("ejecutivo").ToString & "','" & drv.Item("ruta").ToString & "','" & _
                                               drv.Item("frecuencia").ToString & "'," & drv.Item("orden_visita") & ",'" & _
                                               gs_usuario & "')"
                        myOtrans.Actualiza(lsSQL)

                    End If

                    If myOtrans.Codigo_error > 0 Then
                        MessageBox.Show("Problemas al Actualizar " & drv.Item("ctacte") & drv.Item("razon_social"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next


            Catch ex As Exception
            Finally
                myOtrans.close()
                myOtrans = Nothing
                llenarInformacion()

            End Try

        End If
    End Sub

    Private Sub frmMob_ClienteRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombo()
    End Sub

    Private Sub btnObtener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtener.Click
        llenarInformacion()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardarCambios()
    End Sub

    Private Sub dgListadoCliente_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListadoCliente.CellDoubleClick
        agregarCliente()
    End Sub

    Private Sub dgv_enrutados_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_enrutados.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim icount As Integer
        Dim sname As String

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgv_enrutados.Rows(rowIndex)
                If therow.Cells("nuevo").Value.ToString() = "1" Then
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                ElseIf therow.Cells("nuevo").Value.ToString() = "2" Then
                    therow.DefaultCellStyle.ForeColor = Color.Brown
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Black
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_enrutados_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_enrutados.DataError
        MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub dgv_enrutados_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_enrutados.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim icount As Integer
        Dim sname As String

        Try
            If colIndex > -1 Then
                Dim cell As DataGridViewCell = Me.dgv_enrutados.Item(e.ColumnIndex, e.RowIndex)

                If cell.IsInEditMode Then
                    Dim c As Control = Me.dgv_enrutados.EditingControl
                    'If (Me.dgv_enrutados.Columns(colIndex).Name.ToLower = "orden_visita" Or _
                    '   Me.dgv_enrutados) And 
                    If Me.dgv_enrutados.Item("nuevo", e.RowIndex).Value = 0 Then
                        Me.dgv_enrutados.Item("nuevo", e.RowIndex).Value = 2
                    End If
                End If

                End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chk_ruta_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_ruta.CheckStateChanged, chk_frecuencia.CheckStateChanged
        aplicarFiltro()
    End Sub


    Private Sub txtValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress
        If e.KeyChar = Chr(13) Then
            filtroClientes()
        End If
    End Sub

    Private Sub dgListadoCliente_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgListadoCliente.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim icount As Integer
        Dim sname As String

        Try

            If colIndex > -1 Then
                Dim therow As DataGridViewRow
                therow = Me.dgListadoCliente.Rows(rowIndex)
                If therow.Cells("asignado").Value.ToString() = "0" Then
                    therow.DefaultCellStyle.ForeColor = Color.Black
                Else
                    therow.DefaultCellStyle.ForeColor = Color.Blue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbFrecuencia_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFrecuencia.SelectedValueChanged, cmbRuta.SelectedValueChanged, cmbVendedor.SelectedValueChanged
        aplicarFiltro()
    End Sub

    Private Sub dgv_enrutados_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgv_enrutados.UserDeletingRow
        agregarRowelimados()
    End Sub

    Private Sub cmbVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVendedor.SelectedIndexChanged

    End Sub

 
End Class