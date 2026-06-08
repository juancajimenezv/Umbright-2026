Public Class frm_MinMax_Solicitud_Vinoteca
    Dim ds As New DataSet
    Dim tdet As Boolean = False

    Private Sub frm_MinMax_Solicitud_Vinoteca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StatusBarPanel1.Text = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString & " " & Application.ProductVersion & " En Equipo.: (" & gs_nombre_equipo & ")"
        Me.StatusBarPanel2.Text = "Usuario .: (" & gs_usuario & ") " & gs_nombre_usuario
        Me.StatusBarPanel3.Text = "Fecha Actual .: " & Now.ToLongDateString
        GroupBox3.Visible = False
        btn_agregar.Enabled = False
        crea_estructura()
        llena_datos()
        llena_combobox()
        llenarCombos()

        lb_Aleatorio.Text = "###"
    End Sub

    Private Sub Generar_numero()
        Dim numeroaleatorio As New Random
        lb_Aleatorio.Text = System.Convert.ToString(numeroaleatorio.Next)

    End Sub

    Private Sub crea_estructura()
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Marca", GetType(String)))
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("UxC", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("Lote", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaVcto", GetType(Date)))
        dt.Columns.Add(New DataColumn("Existencia", GetType(Double)))
        dt.Columns.Add(New DataColumn("StockMinimo", GetType(Double)))
        dt.Columns.Add(New DataColumn("StockMaximo", GetType(Double)))
        dt.Columns.Add(New DataColumn("ExistenciaVnt", GetType(Double)))
        dt.Columns.Add(New DataColumn("Sugerido", GetType(Double)))
        dt.Columns.Add(New DataColumn("Procesar", GetType(Double)))

        dt.TableName = "productos"

        If ds.Tables.Contains("productos") Then ds.Tables.Remove("productos")
        ds.Tables.Add(dt.Copy)

        dgv_detalle.DataSource = dt

    End Sub

    Private Sub llena_combobox()
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        Try
            ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_BODEGA','" & gs_empresa & "'"
            ldt_table = oTransaccion.Obtiene(ls_sql)
            ldt_table.TableName = "GBOD"
            ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
            Me.cb_Bodega.DisplayMember = "CODIGO"
            Me.cb_Bodega.ValueMember = "CODIGO"
            Me.cb_Bodega.DataSource = ldt_table.DefaultView

            ls_sql = "select codigo marca from gen_tabcod where empresa='" & gs_empresa & "' and tipo='gen_marca_solicitud' order by codigo"
            ldt_table = oTransaccion.Obtiene(ls_sql)
            ldt_table.TableName = "mar"
            'ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
            Me.cmb_Proveedor.DisplayMember = "marca"
            Me.cmb_Proveedor.ValueMember = "marca"
            Me.cmb_Proveedor.DataSource = ldt_table.DefaultView
            Me.cmb_Proveedor.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTransaccion.close()
            oTransaccion = Nothing
        End Try


    End Sub

    Private Sub llena_datos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            Otrans.open()
            lsSQL = "pa_vnt_sel_solicitud_datos '" & gs_empresa & "','" & gs_usuario & "'"
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                tb_tienda.Text = dt.Rows(0)("Ubicacion")
                tb_bodega.Text = dt.Rows(0)("Bodega")
                tb_usuario.Text = dt.Rows(0)("Usuario")
                tb_cliente.Text = dt.Rows(0)("Cliente")

            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub genera_detalle_cero()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim ClsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            lsSQL = "pa_vnt_sel_solicitud_saldos '" & gs_empresa & "','" & cb_Bodega.Text & "','" & tb_bodega.Text & "','" & cmb_Proveedor.Text & "'"
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                For Each dr In dt.Rows
                    dr_aux = ds.Tables("productos").NewRow
                    dr_aux.Item("Proveedor") = dr.Item("Proveedor")
                    dr_aux.Item("Marca") = dr.Item("Marca")
                    dr_aux.Item("Producto") = dr.Item("Producto")
                    dr_aux.Item("Glosa") = dr.Item("Glosa")
                    dr_aux.Item("UxC") = dr.Item("UxC")
                    dr_aux.Item("Bodega") = dr.Item("Bodega")
                    dr_aux.Item("Lote") = dr.Item("Lote")
                    dr_aux.Item("FechaVcto") = dr.Item("FechaVcto")
                    dr_aux.Item("Existencia") = dr.Item("ExistenciaCD")
                    dr_aux.Item("StockMinimo") = dr.Item("StockMinimo")
                    dr_aux.Item("StockMaximo") = dr.Item("StockMaximo")
                    dr_aux.Item("ExistenciaVnt") = dr.Item("ExistenciaVnt")
                    dr_aux.Item("Sugerido") = dr.Item("Sugerido")
                    dr_aux.Item("Procesar") = 0 ' dr.Item("Procesar")


                    ds.Tables("productos").Rows.Add(dr_aux)


                    'If dr.Item("ExistenciaCD") < dr.Item("Sugerido") Then
                    '    dgv_detalle.Columns(11).DefaultCellStyle.ForeColor = Color.Red
                    'End If

                Next

                Me.dgv_detalle.DataSource = ds.Tables("productos")
                dgv_detalle.Columns(0).ReadOnly = True
                dgv_detalle.Columns(1).ReadOnly = True
                dgv_detalle.Columns(2).ReadOnly = True
                dgv_detalle.Columns(3).ReadOnly = True
                dgv_detalle.Columns(4).ReadOnly = True
                dgv_detalle.Columns(5).ReadOnly = True
                dgv_detalle.Columns(6).ReadOnly = True
                dgv_detalle.Columns(7).ReadOnly = True
                dgv_detalle.Columns(8).ReadOnly = True
                'dgv_detalle.Columns(9).ReadOnly = True
                'dgv_detalle.Columns(10).ReadOnly = True
                dgv_detalle.Columns(11).ReadOnly = True
                dgv_detalle.Columns(12).ReadOnly = True
                GroupBox3.Visible = True
                Total()
                MessageBox.Show("Información Generada con Exito...Recuerde agregar Comentario...", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ClsGen.Alinear_GridView(ds.Tables("productos"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub llenarCombos()
        Me.cmb_valor1.Items.Add("Producto")
        Me.cmb_valor1.Items.Add("Glosa")
        Me.cmb_1.Items.Add("=")
        Me.cmb_1.Items.Add(">")
        Me.cmb_1.Items.Add("<")
        Me.cmb_1.Items.Add("like")
        'Me.cmb_proveedor.Items.Add("CODICASA")
        'Me.cmb_proveedor.Items.Add("DISTRIBUIDORA MARTE")
        'Me.cmb_proveedor.Items.Add("DIUVA")
        Me.cmb_valor1.Text = "Glosa"
        Me.cmb_1.Text = "like"
    End Sub

    Private Sub Hacer_Filtro()


        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_valor1.Text, "", "", Me.txt_filtro1.Text, "", "", Me.cmb_1.Text, "", "", Me.txt_filtro1.Text, "")
        clsgen = Nothing
        ds.Tables("productos").DefaultView.RowFilter = ls_filtro
    End Sub

    Private Sub genera_detalle()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim clsGen As New ClasesGenerales.General

        Try
            Otrans.open()
            lsSQL = "pa_vnt_sel_solicitud_saldos '" & gs_empresa & "','" & cb_Bodega.Text & "','" & tb_bodega.Text & "','" & cmb_Proveedor.Text & "'"
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                For Each dr In dt.Rows
                    dr_aux = ds.Tables("productos").NewRow
                    dr_aux.Item("Proveedor") = dr.Item("Proveedor")
                    dr_aux.Item("Marca") = dr.Item("Marca")
                    dr_aux.Item("Producto") = dr.Item("Producto")
                    dr_aux.Item("Glosa") = dr.Item("Glosa")
                    dr_aux.Item("UxC") = dr.Item("UxC")
                    dr_aux.Item("Bodega") = dr.Item("Bodega")
                    dr_aux.Item("Lote") = dr.Item("Lote")
                    dr_aux.Item("FechaVcto") = dr.Item("FechaVcto")
                    dr_aux.Item("Existencia") = dr.Item("ExistenciaCD")
                    dr_aux.Item("StockMinimo") = dr.Item("StockMinimo")
                    dr_aux.Item("StockMaximo") = dr.Item("StockMaximo")
                    dr_aux.Item("ExistenciaVnt") = dr.Item("ExistenciaVnt")
                    dr_aux.Item("Sugerido") = dr.Item("Sugerido")
                    dr_aux.Item("Procesar") = dr.Item("Procesar")

                    ds.Tables("productos").Rows.Add(dr_aux)

                    'If dr.Item("ExistenciaCD") < dr.Item("Sugerido") Then
                    '    dgv_detalle.Columns(11).DefaultCellStyle.ForeColor = Color.Red
                    'End If

                Next

                Me.dgv_detalle.DataSource = ds.Tables("productos")
                dgv_detalle.Columns(0).ReadOnly = True
                dgv_detalle.Columns(1).ReadOnly = True
                dgv_detalle.Columns(2).ReadOnly = True
                dgv_detalle.Columns(3).ReadOnly = True
                dgv_detalle.Columns(4).ReadOnly = True
                dgv_detalle.Columns(5).ReadOnly = True
                dgv_detalle.Columns(6).ReadOnly = True
                dgv_detalle.Columns(7).ReadOnly = True
                dgv_detalle.Columns(8).ReadOnly = True
                'dgv_detalle.Columns(9).ReadOnly = True
                'dgv_detalle.Columns(10).ReadOnly = True
                dgv_detalle.Columns(11).ReadOnly = True
                dgv_detalle.Columns(12).ReadOnly = True
                GroupBox3.Visible = True
                Total()
                MessageBox.Show("Información Generada con Exito...Recuerde agregar Comentario...", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            clsGen.Alinear_GridView(ds.Tables("productos"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_generar_Click(sender As Object, e As EventArgs) Handles btn_generar.Click
        If cb_Bodega.Text = "" Or tb_bodega.Text = "" Or tb_tienda.Text = "" Or tb_usuario.Text = "" Then

            MessageBox.Show("Usuario No Registrado para Solicitar Traslado o Datos Incorrectos...", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            btn_agregar.Enabled = True

            If MessageBox.Show("Desea Cantidad a Solicitar a Cero?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' poner datos a cero
                crea_estructura()
                Generar_numero()
                genera_detalle_cero()
                tdet = True
            Else
                crea_estructura()
                Generar_numero()
                genera_detalle()
                tdet = False
            End If
            'dgv_detalle.DataSource = «»

        End If
    End Sub

    Private Sub Total()
        Dim ntotal As Double = 0.00
        Dim ptotal As Double = 0.00
        Dim dt As DataTable

        Try

            dt = Me.dgv_detalle.DataSource

            ntotal = dt.Compute("sum(Sugerido)", "Sugerido>0")
            ptotal = dt.Compute("sum(Procesar)", "Procesar>0")

            Me.lb_total.Text = Format(ntotal, "###,##0.00")
            Me.lb_procesar.Text = Format(ptotal, "###,##0.00")

        Catch ex As Exception
            ntotal = 0.00
            ptotal = 0.00
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_detalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detalle.CellValueChanged
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex

        Try
            Otrans.open()

            If colIndex > -1 And rowIndex > -1 Then

                If dgv_detalle.Item("StockMinimo", rowIndex).Value > 0 Or dgv_detalle.Item("StockMaximo", rowIndex).Value > 0 Then

                    ls_sql = "pa_vnt_ins_min_max '" & tb_bodega.Text & "','" & dgv_detalle.Item("Producto", rowIndex).Value & "','" & dgv_detalle.Item("StockMinimo", rowIndex).Value & "','" & dgv_detalle.Item("StockMaximo", rowIndex).Value & "'"
                    Otrans.Obtiene(ls_sql)

                    MsgBox("Actualizar " & dgv_detalle.Item("Producto", rowIndex).Value)

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try




        Total()
    End Sub

    Private Sub btn_crear_Click(sender As Object, e As EventArgs) Handles btn_crear.Click
        If MessageBox.Show("Esta Seguro de Crear Solicitud?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            crear_solicitud()
        Else

        End If
    End Sub

    Private Sub crear_solicitud()
        '    Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim dt, dtcorrelativo As DataTable
        Dim ls_sql, lssql, lssql2, lsql_update As String
        Dim lCorrelativo As Integer = 0
        Dim n As Integer = 0
        Dim guid As String = ""

        Try
            Otrans.open()   'abre conexion
            dt = Me.dgv_detalle.DataSource()

            'lssql = " pa_vnt_upd_correlativo_traslado '" & gs_empresa & "'"
            'dtcorrelativo = Otrans.Obtiene(lssql)
            'lCorrelativo = dtcorrelativo.Rows(0)("Correlativo")
            'lb_correlativo.Text = lCorrelativo

            guid = gs_empresa + tb_usuario.Text + tb_tienda.Text + lb_Aleatorio.Text
            '  MsgBox(guid)

            '            lssql2 = " pa_vnt_ins_Traslado '" & gs_empresa & "'," & lCorrelativo & ",'" & tb_tienda.Text & "','" & tb_bodega.Text & "','" & tb_cliente.Text & "','" & gs_usuario & "','" & tb_comentario.Text & "'"
            lssql2 = " pa_vnt_ins_Traslado '" & dtp_fecha.Text & "','" & cb_Bodega.Text & "','" & gs_empresa & "','" & tb_comentario.Text & "','ZONA 13','" & tb_tienda.Text & "','" & tb_usuario.Text & "','" & guid & "'"
            Otrans.Obtiene(lssql2)


            '----busca id por GUID

            lssql = "pv_vnt_busca_Guid '" & guid & "'"
            dtcorrelativo = Otrans.Obtiene(lssql)

            lCorrelativo = dtcorrelativo.Rows(0)("id") 'dtcorrelativo.Rows.Item("id").ToString

            For Each dr As DataRow In dt.Rows

                If dr.Item("Bodega").ToString <> Nothing Then
                    If dr.Item("Procesar") <> 0 Then
                        n = n + 1
                        '    ls_sql = "pa_vnt_ins_solicitud '" & gs_empresa & "','SALIDA POR TRASLADO'," & lCorrelativo & ",'" & dtp_fecha.Text & "','" & tb_cliente.Text & "','" & dr.Item("Proveedor") & "','" &
                        'dr.Item("Marca") & "','" & dr.Item("Bodega") & "'," & n & ",'" & dr.Item("Producto") & "','" & dr.Item("Glosa") & "'," & dr.Item("Sugerido") & "," & dr.Item("Procesar") & ",0.00,'" &
                        'tb_tienda.Text & "','" & gs_usuario & "','" & dr.Item("Lote") & "','" & dr.Item("FechaVcto") & "'"
                        ls_sql = "flexline.pa_vnt_ins_solicitud '" & lCorrelativo & "','" & dr.Item("Producto") & "','" & dr.Item("Procesar") & "'"
                        Otrans.Obtiene(ls_sql)

                    End If
                    ' ACTUALIZA MINIMOS Y MAXIMOS
                    ' ----------------------------
                    lsql_update = "pa_vnt_actualiza_min_max '" & gs_empresa & dr.Item("Bodega") & "'," & dr.Item("Producto") & "','" & dr.Item("StockMinimo") & "," & dr.Item("StockMaximo") & ","
                    Otrans.Obtiene(lsql_update)

                End If

            Next


            MessageBox.Show("Solicitud Creada Con Exito, Numero: " & lb_correlativo.Text & " ......", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub



    Private Sub dgv_detalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv_detalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)

                If Me.dgv_detalle.Item("Existencia", rowIndex).Value < Me.dgv_detalle.Item("Sugerido", rowIndex).Value Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red

                ElseIf Me.dgv_detalle.Item("Bodega", rowIndex).Value = "SIN MM" Then
                    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.RoyalBlue
                    '    sumardatos()
                    'Else
                    '    Me.dgv_Seleccion.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If


            End If

        Catch ex As Exception
            '  MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        agrega_producto()
        lb_producto.Focus()

    End Sub

    Private Sub agrega_producto()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lssql As String
        'Dim lCorrelativo As Integer = 0
        'Dim n As Integer = 0
        'Dim guid As String = ""


        Try
            Otrans.open()   'abre conexion

            If lb_producto.Text.Length <> 0 And txt_minimo.Text > "0" And txt_maximo.Text > "0" Then

                lssql = "pa_vnt_ins_min_max '" & tb_bodega.Text & "','" & lb_producto.Text & "','" & txt_minimo.Text & "','" & txt_maximo.Text & "'"
                Otrans.Obtiene(lssql)

                If tdet = True Then
                    genera_detalle_cero()
                Else
                    genera_detalle()
                End If

            Else
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    'Private Sub txt_producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lb_producto.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Dim Otrans As New Transaccional.Conexion("FlexLine")
    '        Dim dt As DataTable
    '        Dim lssql As String

    '        Try
    '            Otrans.open()   'abre conexion

    '            lssql = "Select producto, glosa from producto where empresa='VINOTECA' AND PRODUCTO='" & lb_producto.Text & "'"
    '            dt = Otrans.Obtiene(lssql)

    '            lb_producto.Text = dt.Rows(0).Item("producto").ToString
    '            txt_descripcion.Text = dt.Rows(0).Item("descripcion").ToString

    '            txt_minimo.Focus()

    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        Finally
    '            Otrans.close()
    '            Otrans = Nothing
    '        End Try

    '    End If

    'End Sub

    Private Sub txt_producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim Otrans As New Transaccional.Conexion("FlexLine")
            Dim dt As DataTable
            Dim lssql As String

            Try
                Otrans.open()   'abre conexion

                lssql = "Select producto, glosa from producto where empresa='VINOTECA' AND PRODUCTO='" & txt_producto.Text & "'"
                dt = Otrans.Obtiene(lssql)

                txt_producto.Text = dt.Rows(0).Item("producto").ToString
                txt_descripcion.Text = dt.Rows(0).Item("glosa").ToString

                txt_minimo.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Otrans.close()
                Otrans = Nothing
            End Try

        End If
    End Sub

    Private Sub txt_filtro1_TextChanged(sender As Object, e As EventArgs) Handles txt_filtro1.TextChanged

    End Sub

    Private Sub txt_filtro1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_filtro1.KeyPress
        If e.KeyChar = Chr(13) Then
            Hacer_Filtro()
        End If
    End Sub

    Private Sub chkMostrarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarTodo.CheckedChanged
        If chkMostrarTodo.CheckState = CheckState.Checked Then
            ds.Tables("productos").DefaultView.RowFilter = ""
        Else
            ds.Tables("productos").DefaultView.RowFilter = "procesar > 0"

        End If
    End Sub

    Private Sub dgv_detalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub dgv_detalle_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_detalle.CellFormatting

        Dim drv As DataRowView
        Try
            If e.RowIndex > -1 Then
                drv = ds.Tables("productos").DefaultView.Item(e.RowIndex)
                If drv.Item("procesar").ToString > 0 Then
                    dgv_detalle.Item("procesar", e.RowIndex).Style.BackColor = Color.Gold
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_detalle_CellErrorTextChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detalle.CellErrorTextChanged
        If e.RowIndex > 0 Then
            MessageBox.Show("Ingreso un Valor Invalido", "Validar")
        End If
    End Sub
End Class