Public Class frm_maq_etiquetas_produccion
    Dim ods, ds_solicitadas As New DataSet
    Dim numero As String = ""

    Private Sub llenar_combos()
        Me.cmb_valor1.Items.Add("Producto")
        Me.cmb_valor1.Items.Add("Glosa")
        Me.cmb_1.Items.Add("=")
        Me.cmb_1.Items.Add(">")
        Me.cmb_1.Items.Add("<")
        Me.cmb_1.Items.Add("like")
      
        Me.cmb_valor1.Text = "Glosa"
        Me.cmb_1.Text = "like"


    End Sub

    Private Sub crear_estructura()
        Dim dt2 As DataTable
        Dim clsgen As New ClasesGenerales.General

        ods = New DataSet
        dt2 = New DataTable("listado")
        dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt2.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt2.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("estado", GetType(String)))
        dt2.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt2.Columns.Add(New DataColumn("fecha_grabo", GetType(String)))
        dt2.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))


        ods.Tables.Add(dt2)
        Me.dgv_listado.DataSource = ods.Tables("listado")
        clsgen.Alinear_GridView(ods.Tables("listado"), dgv_listado, ",empresa,correlativo,producto,glosa,cantidad,estado,observaciones,fecha_grabo,usuario_grabo,", "", ",empresa,correlativo,producto,glosa,cantidad,estado,observaciones,fecha_grabo,usuario_grabo,", "", ",,", ",empresa=100,correlativo=90,producto=100,glosa=200,cantidad=90,estado=90,observaciones=90,fecha_grabo=90,usuario_grabo=90,", "", True, True, 175, 0)
    End Sub
 

    Private Sub frm_maq_etiquetas_produccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructura()

        llenar_combos()
        mostrar_ordenes_completas()
        ' Me.TabControl1.SelectedTab() = Me.TabPage2


    End Sub
    Private Sub mostrar_ordenes_completas()
        Dim ls_sql As String
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Try
            myOtrans.open()
            ls_sql = "pa_var_um_maq_control_produccion_etiqueta_avance '" & gs_empresa & "'"
            dt = myOtrans.Obtiene(ls_sql)

            If dgv_solicitadas.Rows.Count > -1 Then
                Me.dgv_solicitadas.DataSource = Nothing
                ods.Tables("listado").Rows.Clear()

            End If

           

            For Each dr In dt.Rows
                If dt.DefaultView.Count > 0 Then
                    Try
                        dr_aux = ods.Tables("listado").NewRow
                        dr_aux.Item("empresa") = dr.Item("empresa")
                        dr_aux.Item("correlativo") = dr.Item("correlativo")
                        dr_aux.Item("producto") = dr.Item("producto")
                        dr_aux.Item("glosa") = dr.Item("glosa")
                        dr_aux.Item("cantidad") = dr.Item("cantidad")
                        dr_aux.Item("estado") = dr.Item("estado")
                        dr_aux.Item("observaciones") = dr.Item("observaciones")
                        dr_aux.Item("fecha_grabo") = dr.Item("fecha_grabo")
                        dr_aux.Item("usuario_grabo") = dr.Item("usuario_grabo")
                        ods.Tables("listado").Rows.Add(dr_aux)
                    Catch ex As Exception
                    End Try
                End If
            Next
            If ds_solicitadas.Tables.Contains("listado") Then
                ds_solicitadas.Tables.Remove("listado")
            End If
            ds_solicitadas.Tables.Add(ods.Tables("listado").Copy)
            'l_Dataset.Tables.Add(ods.Tables.Copy)

            Me.dgv_listado.DataSource = ods.Tables("listado")
            ClsGen.Alinear_GridView(dt, dgv_listado, ",empresa,correlativo,producto,glosa,cantidad,estado,observaciones,fecha_grabo,usuario_grabo,", ",,", ",empresa,correlativo,producto,glosa,cantidad,estado,observaciones,fecha_grabo,usuario_grabo,", "", ",,", ",empresa=80,correlativo=90,producto=100,glosa=200,cantidad=90,estado=90,observaciones=90,fecha_grabo=90,usuario_grabo=90,", "", True, True, 175, 0)

            ds_solicitadas.Tables("listado").DefaultView.RowFilter = "estado='Solicitada'"

            Me.dgv_solicitadas.DataSource = ds_solicitadas.Tables("listado")
            ClsGen.Alinear_GridView(dt, dgv_solicitadas, ",empresa,glosa,cantidad,estado,numero,fecha_grabo,observaciones,usuario_grabo,producto,", ",,", ",empresa,correlativo,glosa,cantidad,estado,observaciones,fecha_grabo,usuario_grabo,producto,", "", "", ",empresa=80,correlativo=90,glosa=200,cantidad=90,estado=90,observaciones=90,fecha_grabo=90,usuario_grabo=90,producto=100,", "", True, True, 175, 0)


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub
    Private Sub hacer_filtro()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_valor1.Text, "", "", Me.txt_filtro1.Text, "", "", Me.cmb_1.Text, "", "", Me.txt_filtro1.Text, "")
        clsgen = Nothing
        ods.Tables("listado").DefaultView.RowFilter = ls_filtro
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        hacer_filtro()
    End Sub

    Private Sub txt_filtro1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_filtro1.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub


 



  
    Private Sub txt_cantidad_operada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_operada.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txt_cantidad_operada.Text) <= 0 Then
                MessageBox.Show("la cantidad no puede ser negativa ni igual a cero (0).", "Error en cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_cantidad_operada.Focus()
                Exit Sub
            End If

            If Val(txt_cantidad_operada.Text) + Val(txt_avance.Text) > Val(txt_cantidad.Text) Then
                MessageBox.Show("La suma de la Cantidad más el Total Maquilado no puede exeder lo Solicitado", "Error en cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_cantidad_operada.Focus()
                Exit Sub
            End If


            Actualizar_Avance()
            'Mostrar_Avance()
            '   Mostrar_Avance_Diario()

            mostrar_ordenes_completas()
            txt_cantidad_operada.Text = "1"
        End If

    End Sub

    Private Sub Mostrar_Avance_Diario()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try
            myOtrans.open()

            ls_sql = "call pa_sel_um_maq_orden_produccion_avance_diario()"

            dt = myOtrans.Obtiene(ls_sql)
            ' Me.dg_avance_diario.DataSource = dt
            ' ClsGen.Alinea_Grid(dt, Me.dg_avance_diario, dt.TableName, -1, 250, 0, False, True, "", True, "")

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Cerrar_Orden_Produccion(ByVal _Pcorrelativo As String)
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion("SCM")

        Try
            myOtrans.open()

            ls_sql = "pa_upd_um_maq_produccion_estado '" & gs_empresa & "'," & _Pcorrelativo & ",2,'" & gs_usuario & "'"
            myOtrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ' Ordenes_Pendientes()
        End Try

    End Sub

    Private Sub Mostrar_Avance(ByVal _correlativo As String)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion("SCM")
        Dim LlenarInformacion As Boolean = False

        Try
            myOtrans.open()
            Try
                If dgv_avance.Rows.Count > 0 Then
                    Me.dgv_avance.DataSource = Nothing
                    ' ods.Tables.Remove("oso")
                    ods.Tables("oso").Rows.Clear()

                End If

            Catch ex As Exception

            End Try
           

     



            ls_sql = "pa_sel_um_maq_control_produccion_avance '" & gs_empresa & "'," & _correlativo & ""
            dt = myOtrans.Obtiene(ls_sql)


            dt.TableName = "oso"

            If ods.Tables.Contains("oso") Then
                ods.Tables.Remove("oso")
            End If
            ods.Tables.Add(dt.Copy)

            Me.txt_avance.Text = Val(ods.Tables("oso").Compute("sum(cantidad)", "1=1").ToString)

            If dt.Rows.Count > 0 Then

                If Int32.Parse(Me.txt_avance.Text) >= Int32.Parse(Me.txt_cantidad.Text) Then
                    Cerrar_Orden_Produccion(_correlativo)
                    LlenarInformacion = True
                Else
                    Me.dgv_avance.DataSource = dt
                End If
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try
        If LlenarInformacion Then
            Me.mostrar_ordenes_completas()
            'Mostrar_Detalle_Orden()
        End If
    End Sub

    Private Sub Actualizar_Avance()
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion("SCM")
        Dim suma As Integer = 0


        Try
            myOtrans.open()

            'ls_sql = "call pa_ins_um_maq_orden_produccion_avance (" & Odt.Rows(0).Item("cod_produccion") & "," & _
            'Me.txt_cantidad_operada.Text & ",'" & gs_usuario & "')"

            ls_sql = " pa_ins_um_maq_orden_produccion_avance '" & gs_empresa & "'," & numero & "," & _
          Me.txt_cantidad_operada.Text & ",'" & gs_usuario & "'"

            myOtrans.Ingresa(ls_sql)

            suma = Val(Me.txt_cantidad_operada.Text) + Val(Me.txt_avance.Text)

            If suma = Val(Me.txt_cantidad.Text) Then
                ls_sql = "pa_upd_um_maq_produccion_estado '" & gs_empresa & "'," & numero & ",2,'" & gs_usuario & "'"
                myOtrans.Actualiza(ls_sql)

            End If

           


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try
    End Sub

    


    Private Sub dgv_solicitadas_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_solicitadas.CurrentCellChanged
        Dim nRow As Integer


        Try
            nRow = Me.dgv_solicitadas.CurrentCell.RowIndex
            numero = Me.dgv_solicitadas.Item(1, nRow).Value.ToString
            Me.txt_producto.Text = Me.dgv_solicitadas.Item(3, nRow).Value.ToString
            Me.txt_cantidad.Text = Me.dgv_solicitadas.Item(4, nRow).Value.ToString
            Me.txt_observaciones.Text = Me.dgv_solicitadas.Item(6, nRow).Value.ToString


            Mostrar_Avance(Me.dgv_solicitadas.Item(1, nRow).Value.ToString)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_solicitadas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_solicitadas.CellContentClick

    End Sub

    Private Sub txt_cantidad_operada_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_operada.TextChanged

    End Sub

    Private Sub dgv_listado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listado.CellContentClick

    End Sub
End Class