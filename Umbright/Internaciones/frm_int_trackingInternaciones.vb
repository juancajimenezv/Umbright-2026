Imports System.Text
Public Class frm_int_trackingInternaciones

    Dim ds_internaciones As New DataSet

    Private Sub aplicarFiltroReal()
        Dim lsFiltro As String = "estado_real in ("
        Dim lsdatos As String()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        '   gs_usuario = "festrada"
        If gi_tipo_usuario = 1 Or gi_tipo_usuario = 2 Then
            lsFiltro = "estado_real not in (99,24)"
            '    'Si revisa memos solo le muestro aquellos que estan solicitados
            '    Me.chkOperadasCD.Visible = True
        Else

            Try
                otrans.open()
                dt = otrans.Obtiene("pa_sel_um_sg_usuario_menu_opcion_empresa 14,'" & gs_usuario & "',null,'" & gs_empresa & "'")
                dt.DefaultView.RowFilter = "cod_sub_menu = 15"
                dt = clsGen.ValoresDistinto(dt.DefaultView.ToTable, "opcion".Split(","))
                For Each dr As DataRow In dt.Rows
                    lsdatos = dr.Item("opcion").ToString.Split("_")
                    If lsdatos.Length > 3 Then
                        Try
                            If CInt(lsdatos(lsdatos.Length - 1)) > 0 Then
                                lsFiltro += lsdatos(lsdatos.Length - 1) + ","
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
                lsFiltro += ")"

            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing
            End Try
        End If

        ds_internaciones.Tables("internaciones_pendientes").DefaultView.RowFilter = lsFiltro

    End Sub

    Private Sub Llenar_Internaciones_pendientes()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim dr As DataRow
        Dim tipo As String


        Dim clsgen As New ClasesGenerales.General
        Dim clsDias As New ClasesGenerales.DiasHabiles

        Try
            otrans.open()

            If ds_internaciones.Tables.IndexOf("internaciones_pendientes") > -1 Then ds_internaciones.Tables.Remove("internaciones_pendientes")
            If ds_internaciones.Tables.IndexOf("internaciones_detalle") > -1 Then ds_internaciones.Tables.Remove("internaciones_detalle")
            Me.dg_detalle.DataSource = Nothing
            If ds_internaciones.Tables.IndexOf("internaciones_estado") > -1 Then ds_internaciones.Tables.Remove("internaciones_estado")
            Me.dgvEstados.DataSource = Nothing

            If LTrim(Me.cmb_campos.Text).Length > 0 And LTrim(Me.cmb_operadores.Text).Length > 0 And LTrim(Me.txt_texto.Text).Length > 0 Then
                If Me.cmb_operadores.Text = "like" Then
                    ls_sql = "select * from  v_int_pedido_pendientes_listado" & _
                    " where  fecha >= Cast('" & Me.dtpFechaInicio.Text & "'" & " as DateTime) and fecha < dateadd(dd,1,Cast('" & Me.dtpFechaFinal.Text & "' as DateTime))" & _
                    "and " & Me.cmb_campos.Text & "  like '%" & Me.txt_texto.Text & "%'   and empresa='" & gs_empresa & "'"
                Else
                    ls_sql = "select cod_pedido,fecha,nombre,comentario,dias_tramite,fechaingreso,estado,DI,fecha_real_ingreso,estado_real from  v_int_pedido_pendientes_listado" & _
                    " where  fecha >= Cast('" & Me.dtpFechaInicio.Text & "'" & " as DateTime) and fecha < dateadd(dd,1,Cast('" & Me.dtpFechaFinal.Text & "' as DateTime))" & _
                    "and " & Me.cmb_campos.Text & Me.cmb_operadores.Text & "'" & Me.txt_texto.Text & "' and empresa='" & gs_empresa & "'"
                End If
                dt = otrans.Obtiene(ls_sql)
                dt.TableName = "internaciones_pendientes"

                dt = clsgen.ValoresDistinto(dt, "cod_pedido,fecha,nombre,comentario,dias_tramite,fechaingreso,estado,DI,fecha_real_ingreso,estado_real".Split(","))
                ds_internaciones.Tables.Add(dt.Copy)
                Me.dg_internaciones.DataSource = ds_internaciones.Tables("internaciones_pendientes")
            Else
                ls_sql = "pa_var_um_int_pedido_pendientes_listado '" & gs_empresa & "','" & Me.dtpFechaInicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpFechaFinal.Value.ToString("dd/MM/yyyy") & "'"
                dt = otrans.Obtiene(ls_sql)
                dt.TableName = "internaciones_pendientes"
                ds_internaciones.Tables.Add(dt.Copy)
                Me.dg_internaciones.DataSource = ds_internaciones.Tables("internaciones_pendientes")
            End If

            If ds_internaciones.Tables("internaciones_pendientes").Rows.Count > 0 Then

                ls_sql = "pa_sel_um_int_pedido_detalle_pendientes_listado '" & gs_empresa & "','" & Me.dtpFechaInicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpFechaFinal.Value.ToString("dd/MM/yyyy") & "'"
                dt = otrans.Obtiene(ls_sql)
                dt.TableName = "internaciones_detalle"
                ds_internaciones.Tables.Add(dt.Copy)
                Me.dg_detalle.DataSource = ds_internaciones.Tables("internaciones_detalle")

                ls_sql = "pa_var_um_int_pedido_pendientes_estado_listado '" & gs_empresa & "','" & Me.dtpFechaInicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtpFechaFinal.Value.ToString("dd/MM/yyyy") & "'"
                dt = otrans.Obtiene(ls_sql)
                dt.TableName = "internaciones_estado"
                ds_internaciones.Tables.Add(dt.Copy)
                Me.dgvEstados.DataSource = ds_internaciones.Tables("internaciones_estado")

                If Me.chkCerrados.CheckState = CheckState.Unchecked Then ds_internaciones.Tables("internaciones_pendientes").DefaultView.RowFilter = "estado_real <> 24"
                For Each drv As DataRowView In ds_internaciones.Tables("internaciones_pendientes").DefaultView
                    Try
                        If drv.Item("estado_real") = 24 Then
                            drv.Item("dias_tramite") = clsDias.Obtener_DiasHabiles(gs_empresa, Date.Parse(drv.Item("fecha").ToString), Date.Parse(drv.Item("fecha_real_ingreso").ToString)) - 1
                        Else
                            drv.Item("dias_tramite") = clsDias.Obtener_DiasHabiles(gs_empresa, Date.Parse(drv.Item("fecha").ToString), Today) - 1
                        End If
                        If drv.Item("dias_tramite") < 0 Then drv.Item("dias_tramite") = 0
                    Catch ex As Exception
                    End Try
                Next
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If ds_internaciones.Tables.Contains("internaciones_pendientes") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_pendientes"), dg_internaciones, "", ",lead_time,empresa,estado_real,", "", "", ",fechaingreso=Fecha Prob Ingreso,cod_pedido=No Pedido,", ",cod_pedido=40,fecha=75,fechaingreso=75,dias_tramite=30,", "", True, True, 200, 0)
        If ds_internaciones.Tables.Contains("internaciones_detalle") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", ",cod_pedido,daiv,iva,", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)
        If ds_internaciones.Tables.Contains("internaciones_estado") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_estado"), Me.dgvEstados, "", ",cod_pedido,daiv,iva,cod_estado,", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)
        clsgen = Nothing
    End Sub

    Private Sub verificarFechaIngreso()
        Dim oTrans As New Transaccional.Conexion("Umbral")

        Dim dfechaInicio As DateTime
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            oTrans.open()
            ds_internaciones.Tables("internaciones_pendientes").DefaultView.Sort = "fecha" '.Compute("Min(Fecha)", "cod_pedido>0")
            dfechaInicio = ds_internaciones.Tables("internaciones_pendientes").DefaultView(0)("fecha")
            lsSQL = "pa_var_um_calendario_habil '" & gs_empresa & "','" & dfechaInicio.ToString("dd/MM/yyyy") & "'"
            dt = oTrans.Obtiene(lsSQL)

            For Each drv As DataRowView In ds_internaciones.Tables("internaciones_pendientes").DefaultView
                dt.DefaultView.RowFilter = "fecha >= '" & drv.Item("fecha") & "'"
                dt.DefaultView.Sort = "fecha"
                drv.Item("fechaIngreso") = dt.DefaultView(drv.Item("lead_time") - 1).Item("fecha")
            Next


        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
    End Sub

    'Mostrar los productos en los diferentes grids
    Private Sub Mostrar_Productos()

        Dim nrow, npedido As Integer
        Dim clsGen As New ClasesGenerales.General

        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString

            ds_internaciones.Tables("internaciones_detalle").DefaultView.RowFilter = "cod_pedido = " & npedido
            clsGen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", "", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 250, 0)

            ds_internaciones.Tables("internaciones_estado").DefaultView.RowFilter = "cod_pedido = " & npedido
            ds_internaciones.Tables("internaciones_estado").DefaultView.Sort = "fecha_grabo desc, cod_estado desc"
            clsGen.Alinear_GridView(ds_internaciones.Tables("internaciones_estado"), Me.dgvEstados, "", ",cod_pedido,", ",cod_pedido,", "", ",fecha_grabo=fecha,", ",usuario_grabo=30,cantidad=40,", "", True, True, 250, 0)

        Catch ex As Exception
        End Try

    End Sub

      Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Llenar_Internaciones_pendientes()
    End Sub

    Private Sub dg_internaciones_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dg_internaciones.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dg_internaciones.Rows(rowIndex)

                If Me.dg_internaciones.Item("estado_real", rowIndex).Value = 24 Then
                    Me.dg_internaciones.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightYellow

                    'ElseIf Me.dgv_detalle.Item("sugerido", rowIndex).Value > 0 And dgv_detalle.Item("pedido", rowIndex).Value = 0 Then
                    '    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    'ElseIf Me.dgv_detalle.Item("bloqueado_internacion", rowIndex).Value = True Then
                    '    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightSalmon
                    'Else
                    '    Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black

                End If

                'If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("transi") > -1 Then
                '    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                '        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                '    Else
                '        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.White
                '    End If
                'End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dg_internaciones_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg_internaciones.CurrentCellChanged
        Mostrar_Productos()
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        Llenar_Internaciones_pendientes()
        If Me.dg_internaciones.Rows.Count > 0 Then
            Mostrar_Productos()
        End If

    End Sub

    Private Sub dg_internaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_internaciones.CellContentClick

    End Sub

    Private Sub frm_int_trackingInternaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb_operadores.Text = "like"
    End Sub

    Private Sub VerDIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDIToolStripMenuItem.Click


        Dim ClsGen As New ClasesGenerales.frm_mostrarImagen
        Dim cls As New ClasesGenerales.General
        Dim nrow As Integer
        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            Dim sfile As String = "\\" & cls.Obtener_XMLConfig("Servidor_Alterno_" & cls.Obtener_XMLConfig("ubicacion", False), False) & "\di$\" & gs_empresa.ToUpper & "\" &
                                    Me.dg_internaciones.Item("di", nrow).Value.ToString.Trim & ".jpg"

            If System.IO.File.Exists(sfile) Then
                ClsGen.psimagen = sfile
                ClsGen.ShowDialog()
            Else
                Try
                    Dim proceso As Process = New Process
                    proceso.StartInfo.FileName = sfile.Replace(".jpg", ".pdf")
                    proceso.Start()
                    proceso = Nothing
                Catch ex2 As Exception
                End Try
            End If
        Catch ex As Exception
        Finally
            ClsGen.Dispose()
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class