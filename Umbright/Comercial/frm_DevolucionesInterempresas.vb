Public Class frm_DevolucionesInterempresas

    Dim ods As New DataSet
    Private Sub generarInformacion()
        Dim clsGen As New ClasesGenerales.General
        Dim dt, dtBU As DataTable


        Try
            dt = clsGen.selectQuery("SCM", "pa_var_um_aut_devoluciones_vinoteca_preparar")
            Me.dgvExistencias.DataSource = dt

            dtBU = clsGen.ValoresDistinto(dt, "subfamilia_origen_empresa,familia_destino_devolucion".Split(","))
            dtBU.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
            dtBU.TableName = "bu"

            If ods.Tables.Contains("bu") Then ods.Tables.Remove("bu")
            ods.Tables.Add(dtBU.Copy)


            clsGen.Alinear_GridView(dt, dgvExistencias, "", "", "", "", True, True, 150, 0)
            Me.dgvBU.DataSource = ods.Tables("bu")
            clsGen.Alinear_GridView(ods.Tables("bu"), Me.dgvBU, "", "", "", "", ",subfamilia_origen_empresa=empresa,familia_destino_devolucion=bu,", "", "", True, True, 150, 0)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub procesarDevolucion_Verificacion()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            clsGen.insertQuery("SCM", "pa_var_um_aut_elimina_rechazo_temporales")


            For Each dr As DataRow In ods.Tables("bu").Rows
                If dr.Item("Agregar").ToString.ToLower = "true" Then
                    clsGen.insertQuery("SCM", "pa_var_um_aut_devoluciones_vinoteca_temporal '" & dr.Item("subfamilia_origen_empresa").ToString & "','" & dr.Item("familia_destino_devolucion").ToString & "'")
                End If
            Next
            clsGen.insertQuery("SCM", "scm.flexline.pa_var_um_aut_devoluciones_vinoteca_entrada_preparar")

            dt = clsGen.selectQuery("SCM", "pa_var_um_aut_Documentod_tmp_rechazo")
            Me.dgvProductosDevolucion.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvProductosDevolucion, "", ",analisis21,", "", "", ",cantidad=Existencia,cantidadasignada=maximo_devolucion,analisis24=documento,analisis25=numero,", "", "", True, True, 300, 0)

            Me.TabControl1.SelectedTab = Me.TabPage2

            dt = clsGen.selectQuery("SCM", "pa_var_um_aut_Documentod_tmp_rechazo_detalle")
            Me.dgvProductosDevolucionDetalle.DataSource = dt

            clsGen.Alinear_GridView(dt, Me.dgvProductosDevolucionDetalle, "", "", "", "", "", "", "", True, True, 300, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub aplicarDevolucion()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            For Each dr As DataRow In ods.Tables("bu").Rows
                If dr.Item("Agregar").ToString.ToLower = "true" Then
                    clsGen.insertQuery("FlexLine", "pa_var_um_devoluciones_vinoteca '" & dr.Item("subfamilia_origen_empresa").ToString & "','" & dr.Item("familia_destino_devolucion").ToString & "'")
                    imprimirDevolucion()
                End If
            Next

            'dt = clsGen.selectQuery("SCM", "pa_var_um_Documentod_tmp_rechazo")
            'Me.dgvDevolucion.DataSource = dt

            Me.TabControl1.SelectedTab = Me.TabPage2
        Catch ex As Exception
        End Try

    End Sub


    Private Sub imprimirDevolucion()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ldFechaDocto As Date
        Try

            dt = clsGen.selectQuery("SCM", "pa_sel_um_gen_monitor_impresiones 'VINOTECA','SALIDA X DEVOLUCION',0")
            For Each dr As DataRow In dt.Rows
                imprimiryPDFSalidaEntrada(dr.Item("Empresa"), dr.Item("TipoDocto"), dr.Item("Numero"))
                clsGen.insertQuery("SCM", "pa_upd_um_gen_monitor_impresiones '" & dr.Item("Empresa").ToString & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "',1")
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Imprimir_SolicitudDevolucion(psEmpresa As String, psCodigoDevolucion As Integer)
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(4) As String
        Dim ClsGen As New ClasesGenerales.General
        'Dim oflex As New Umbral_Flex.guateFacturas(gs_empresa)
        Try


            pm_conexion = ClsGen.Parametros_Conexion("VDataServer")
            path_reporte = ClsGen.Path_Reporte()
            path_reporte += "Direccion Comercial\Devoluciones.rpt"

            pm_parametros(0) = "@Pempresa"
            pm_parametros(1) = "@Pcod_devolucion"

            pm_valores(0) = psEmpresa
            pm_valores(1) = psCodigoDevolucion

            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '               pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '               False, True, "PDF", False, "", True)



            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                          False, True, "PDF", False, "", True, 1, gs_empresa, "")

        Catch ex As Exception
            ClsGen.Escribir_Log("Imprimir Ordenes Pdf " & ex.ToString)
            ClsGen.Escribir_Log("Imprimir Ordenes Pdf " & ex.Message)
        Finally
            ClsGen = Nothing


        End Try


    End Sub



    Private Sub llenarInformacionDevoluciones()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_devolucion_encabezado_listado_gen null,'" & Today.AddDays(-180).ToString("dd/MM/yyyy") & "','" & Today.ToString("dd/MM/yyyy") & "'")
            dt.DefaultView.RowFilter = "ctacte = '2968550'"
            Me.dgvDevolucionesPendientes.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvDevolucionesPendientes, _
                        ",empresa,correlativo,ctacte,estadod,ctacte,razonsocial,total_devolucion,fecha_devolucion,comentarios,CodEstado,usuario_solicito,usuario_aprobo,usuario_grabo,estadotransporte,fecha_rechazo,motivo_rechazo,bum_asignado,fecha_recepcion,operado,", _
                        ",Numero,usuario_solicitoD,CodEstado,estadotransporte,", _
                        ",Numero,Estado,Ctacte,Razon_Social,Total,Fecha,Observaciones,Usuario_solicito,usuario_aprobo,usuario_grabo,", _
                        ",Total,", ",Correlativo=Numero,estadod=estado,fecha_recepcion=fecha_recepcion_bodega,", "", _
                        ",empresa,correlativo,comentarios,estadod,fecha_devolucion,usuario_grabo,usuario_solicito,usuario_aprobo,", True, True, 200, 0)


        Catch ex As Exception

        End Try


    End Sub

    Private Sub procesarRecepcionDevolucion(pirow As Integer)
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Try





            lsSQL = "pa_ins_um_devolucion_recepcion '" & _
                Me.dgvDevolucionesPendientes.Item("empresa", pirow).Value & "','DEVOLUCION'," & _
                Me.dgvDevolucionesPendientes.Item("cod_devolucion", pirow).Value & ",'" & Now.ToString("dd/MM/yyyy HH:mm") & "','" & _
                gs_usuario & "','" & Now.ToString("dd/MM/yyyy HH:mm") & "','1'"
            clsGen.insertQuery("SCM", lsSQL)




        Catch ex As Exception
        Finally
            clsGen = Nothing
            Me.llenarInformacionDevoluciones()
        End Try
    End Sub
    Private Sub aprobarRecepcionDevolucion(pirow As Integer)
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Try

            lsSQL = "pa_upd_um_mov_devolucion_encabezado_estado_apruebaP " &
                Me.dgvDevolucionesPendientes.Item("cod_devolucion", pirow).Value & _
                ",'" & Me.dgvDevolucionesPendientes.Item("comentarios", pirow).Value & "','" & gs_usuario & "',1,0"

            clsGen.insertQuery("FlexLine", lsSQL)


        Catch ex As Exception

        End Try

    End Sub


    Private Sub aprobarDevolucion()

        Dim nrow As Integer = Me.dgvDevolucionesPendientes.CurrentCell.RowIndex
        Try

            If Me.dgvDevolucionesPendientes.Item("estadod", nrow).Value.ToString.ToLower.StartsWith("aproba") Then
                If MessageBox.Show("Esta Seguro de Procesar la Devolucion " & _
                                   Me.dgvDevolucionesPendientes.Item("correlativo", nrow).Value, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    procesarRecepcionDevolucion(nrow)

                End If

            ElseIf Me.dgvDevolucionesPendientes.Item("estadod", nrow).Value.ToString.ToLower.StartsWith("pendiente de aproba") Then
                If DateDiff(DateInterval.Day, Me.dgvDevolucionesPendientes.Item("fecha_devolucion", nrow).Value, Today) > 1 Then
                    If MessageBox.Show("Esta Seguro de Aprobar la Devolucion " & _
                                       Me.dgvDevolucionesPendientes.Item("correlativo", nrow).Value, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                        aprobarRecepcionDevolucion(nrow)

                    End If
                Else
                    MessageBox.Show("No Puede Aprobar Esta Devolucion, No ha pasado el tiempo suficiente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                End If
                End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_DevolucionesInterempresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGenerarInformacion_Click(sender As Object, e As EventArgs) Handles btnGenerarInformacion.Click
        generarInformacion()
    End Sub

    Private Sub btnProcesarDevolucion_Click(sender As Object, e As EventArgs) Handles btnProcesarDevolucion.Click
        ProcesarDevolucion_Verificacion() 'Proceso de Verificacion
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        AplicarDevolucion()
    End Sub

 
    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        LlenarInformacionDevoluciones()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        AprobarDevolucion()
    End Sub

    Private Sub dgvProductosDevolucion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductosDevolucion.CellContentClick

    End Sub


    Private Sub btnRefrescarImpresiones_Click(sender As Object, e As EventArgs) Handles btnRefrescarImpresiones.Click
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_devolucion_encabezado_listado_gen null,'" & Today.AddDays(-180).ToString("dd/MM/yyyy") & "','" & Today.ToString("dd/MM/yyyy") & "'")
            dt.DefaultView.RowFilter = "ctacte = '2968550'"
            Me.dgvDevolucionesImprimir.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvDevolucionesImprimir, _
                        ",empresa,correlativo,ctacte,estadod,ctacte,razonsocial,total_devolucion,fecha_devolucion,comentarios,CodEstado,usuario_solicito,usuario_aprobo,usuario_grabo,estadotransporte,fecha_rechazo,motivo_rechazo,bum_asignado,fecha_recepcion,operado,", _
                        ",Numero,usuario_solicitoD,CodEstado,estadotransporte,", _
                        ",Numero,Estado,Ctacte,Razon_Social,Total,Fecha,Observaciones,Usuario_solicito,usuario_aprobo,usuario_grabo,", ",Total,", ",Codigo=Numero,", "", "", True, True, 200, 0)


            dt = clsGen.selectQuery("FlexLine", "pa_var_um_documento_reimpresion_vinoteca")
            Me.dgvDevolucionMovimientoFlexLine.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvDevolucionMovimientoFlexLine, "", "", "", "", True, True, 300, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub


    Private Sub btnImprimirImpresiones_Click(sender As Object, e As EventArgs) Handles btnImprimirImpresiones.Click
        Dim nrow As Integer = Me.dgvDevolucionesImprimir.CurrentCell.RowIndex
        Try

            Imprimir_SolicitudDevolucion(Me.dgvDevolucionesImprimir.Item("empresa", nrow).Value.ToString, _
                                          Me.dgvDevolucionesImprimir.Item("cod_devolucion", nrow).Value.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImprimirMovimientoFlexLine_Click(sender As Object, e As EventArgs) Handles btnImprimirMovimientoFlexLine.Click
        Dim nrow As Integer = Me.dgvDevolucionMovimientoFlexLine.CurrentCell.RowIndex
        Try
            Dim Oflex As New Umbral_Flex.Pedidos
            If Me.dgvDevolucionMovimientoFlexLine.Item("tipodocto", nrow).Value.ToString.ToLower.StartsWith("salida") Then
                imprimiryPDFSalidaEntrada(Me.dgvDevolucionMovimientoFlexLine.Item("empresa", nrow).Value.ToString, _
                              Me.dgvDevolucionMovimientoFlexLine.Item("tipodocto", nrow).Value.ToString,
                              Me.dgvDevolucionMovimientoFlexLine.Item("numero", nrow).Value.ToString)

            Else
                Oflex.imprimirDevolucion(Me.dgvDevolucionMovimientoFlexLine.Item("empresa", nrow).Value.ToString,
                                         Me.dgvDevolucionMovimientoFlexLine.Item("numero", nrow).Value.ToString,
                                         Me.dgvDevolucionMovimientoFlexLine.Item("tipodocto", nrow).Value.ToString, 1, "local,local")


            End If
            Oflex = Nothing

        Catch ex As Exception

        End Try
    End Sub
End Class