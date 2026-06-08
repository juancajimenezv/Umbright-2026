Public Class frmImpresionFacturasAreas

    Dim dtFacturas As DataTable
    'Llena Facturas marcadas para recoger en bodega
    Private Sub llenarfacturas()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable



        Try
            lsSQL = "pa_sel_um_facturas_transporte_recoge_bodega '" &
                  dtp_fel_inicio.Text & "', '" & dtp_fel_final.Text & "','" & gs_empresa & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)


            If Me.lblTipoPago.Text.IndexOf(",") = 0 Then
                dt.DefaultView.RowFilter = "forma_pago like '%" & Me.lblTipoPago.Text.Replace(",", "") & "%'"
            End If

            Me.dgv_pedidosFACE.DataSource = dt.DefaultView
            clsGen.Alinear_GridView(dt, dgv_pedidosFACE, "", ",correlativo,", "", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try


    End Sub

    Private Sub llenarfacturas_centro_impresion()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable



        Try
            lsSQL = String.Format("pa_sel_um_facturas_transporte_centro_impresion '{0}','{1}','{2}','{3}'",
                  dtp_fel_inicio.Text, dtp_fel_final.Text, gs_empresa, Me.cmbArea.SelectedValue)
            dtFacturas = clsGen.selectQuery("FlexLine", lsSQL)


            'If Me.lblTipoPago.Text.IndexOf(",") = 0 Then
            '    dt.DefaultView.RowFilter = "forma_pago like '%" & Me.lblTipoPago.Text.Replace(",", "") & "%'"
            'End If

            Me.dgv_pedidosFACE.DataSource = dtFacturas.DefaultView
            clsGen.Alinear_GridView(dtFacturas, dgv_pedidosFACE, "", ",correlativo,", "", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try


    End Sub



    'Llena Facturas marcadas para recoger en bodega
    Private Sub llenarfacturas_imprimeFacturacion()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String




        Try
            lsSQL = "pa_sel_um_facturas_transporte_imprime_facturacion '" &
                  dtp_fel_inicio.Text & "', '" & dtp_fel_final.Text & "','" & gs_empresa & "'"
            dtFacturas = clsGen.selectQuery("FlexLine", lsSQL)


            'If Me.lblTipoPago.Text.IndexOf(",") = 0 Then
            '    dt.DefaultView.RowFilter = "forma_pago like '%" & Me.lblTipoPago.Text.Replace(",", "") & "%'"
            'End If

            Me.dgv_pedidosFACE.DataSource = dtFacturas.DefaultView
            clsGen.Alinear_GridView(dtFacturas, dgv_pedidosFACE, "", ",correlativo,", "", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try


    End Sub

    Private Sub imprimirFacturas(psEmpresa As String, psTipodocto As String, psNumero As String)
        Dim clsGen As New ClasesGenerales.General


        Dim lsSQL As String

        Dim dt As DataTable

        Dim pm_valores(3), pm_valores_consolidado(2) As String
        Dim pm_parametros(3) As String
        Dim pm_conexion(3) As String
        Dim ppath_reporte As String
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Dim pm_parametros2(2) As String
        Dim pm_valores2(2) As String

        Oaut.pnNumeroCopias = nupCopias.Value


        Try


            pm_conexion = clsGen.Parametros_Conexion("")
            ppath_reporte = clsGen.Path_Reporte

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"


            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
            ppath_reporte += psEmpresa + " "
            ppath_reporte += psTipodocto
            ppath_reporte += ".rpt"

            pm_valores(0) = psEmpresa
            pm_valores(1) = psTipodocto
            pm_valores(2) = psNumero
            pm_valores(3) = gs_usuario & " - " & gs_nombre_equipo

            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
            False, True, "PDF", True, "", True, Oaut.pnNumeroCopias)

            'Agregar quien imprimio
            lsSQL = "pa_ins_um_gen_log_documento_impresion '" & psEmpresa & "','" & psTipodocto & "','" & psNumero & "','" & gs_usuario & "','" & gs_nombre_equipo & "','frmImpresionFacturasAreas'," & nupCopias.Value
            clsGen.insertQuery("FlexLine", lsSQL)

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try


    End Sub


    Private Sub Imprimir_recibos(psEmpresa As String, psTipodocto As String, psNumero As String)

        'Imprimir Recibo
        Dim clsGen As New ClasesGenerales.General
        Dim pm_valores(3), pm_valores_consolidado(2) As String
        Dim pm_parametros(3) As String
        Dim pm_conexion(3) As String
        Dim ppath_reporte As String
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Dim pm_parametros2(2) As String
        Dim pm_valores2(2) As String

        Oaut.pnNumeroCopias = nupCopias.Value

        Try


            ppath_reporte = clsGen.Path_Reporte
            ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Impresion De Recibos Citizen.rpt"


            pm_conexion = clsGen.Parametros_Conexion("SCM")

            pm_parametros2(0) = "Empresa"
            pm_parametros2(1) = "Tipodocto"
            pm_parametros2(2) = "Numero"


            pm_valores2(0) = psEmpresa
            pm_valores2(2) = psNumero
            pm_valores2(1) = psTipodocto


            _reporte_generico_clase(ppath_reporte, pm_parametros2, pm_valores2,
                    pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                    False, True, "PDF", True, "", True, Oaut.pnNumeroCopias)

        Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub lbl_tipo_impresion_Click(sender As Object, e As EventArgs) Handles lbl_tipo_impresion.Click


    End Sub

    Private Sub enviarFactura()
        Dim nrow As Integer = dgv_pedidosFACE.CurrentRow.Index

        Try



            Dim clsgen As New ClasesGenerales.General
            Dim lsSQL As String

            lsSQL = "pa_upd_um_documento_analisis_transporte '" &
                Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString & "','" &
                Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString & "','" &
                Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString & "','" &
                    gs_usuario & "',null,null,'" & cmbTrasladarArea.SelectedValue & "'"

            clsgen.insertQuery("FlexLine", lsSQL)
            clsgen = Nothing


        Catch ex As Exception

            End Try

    End Sub

    Private Sub btnObtener_Click(sender As Object, e As EventArgs) Handles btnTrasladar.Click
        'llenarfacturas()
        If MessageBox.Show("Esta Seguro de Enviar este Documento a " & Me.cmbTrasladarArea.SelectedValue, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            enviarFactura()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnImprimirRecibos.Click
        Dim nrow As Integer = dgv_pedidosFACE.CurrentRow.Index

        Try





            Imprimir_recibos(Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnReimpresionNC_Click(sender As Object, e As EventArgs) Handles btnReimpresionNC.Click
        Dim nrow As Integer = dgv_pedidosFACE.CurrentRow.Index

        Try




            If MessageBox.Show("Esta Seguro de Imprimir", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                If Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString.ToLower.StartsWith("consi") Then
                    imprimir_consignaciones(Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString)
                Else


                    imprimirFacturas(Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString)

                    If Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString.ToUpper.StartsWith("CONTA") Then
                        If MessageBox.Show("Desea Imprimir Recibos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Imprimir_recibos(Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString)
                        End If
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub imprimir_consignaciones(ByVal pEmpresa As String, ByVal pTipoDocto As String, ByVal pNumero As String)

        Dim path_reporte As String
        Dim pm_valores(4) As String
        Dim pm_parametros(4) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            pm_conexion = ClsGen.Parametros_Conexion("vDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            ''path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Finanzas\Facturacion\Consignaciones "
            path_reporte += pEmpresa & ".rpt"

            'path_reporte = "\\192.192.1.170\reportes$\Logistica\Bodega\Impresion de Movimientos.rpt"

            pm_parametros(0) = "Empresa"
            pm_parametros(2) = "tipoDocto"
            pm_parametros(1) = "Numero"
            pm_valores(0) = pEmpresa
            pm_valores(2) = pTipoDocto
            pm_valores(1) = pNumero
            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True, nupCopias.Value)

            lsSQL = String.Format("pa_ins_um_gen_log_documento_impresion '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'",
                      pEmpresa, pTipoDocto, pNumero, gs_usuario, gs_nombre_equipo, "frmImpresionFacturasAreas", nupCopias.Value)

            ClsGen.insertQuery("FlexLine", lsSQL)


        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

    End Sub



    Private Sub validarPermisos()
        'Me.lblTipoPago.Text = ""
        'If tiene_permisos("mfi_fc_impresion_areas_contado") Then
        '    Me.lblTipoPago.Text = "CONTADO"
        '    Me.btnObtener.Visible = True
        'End If
        'If tiene_permisos("mfi_fc_impresion_areas_credito") Then
        '    Me.lblTipoPago.Text += ",CREDITO"
        '    Me.btnObtener.Visible = True
        'End If
        'If tiene_permisos("mfi_fc_impresion_areas_facturacion") Then
        '    'Me.lblTipoPago.Text += ",FACTURACION"
        '    Me.btnActualizarFacturacion.Visible = True
        'End If


    End Sub
    Private Sub frmImpresionFacturasAreas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'validarPermisos()
        llenarAreas()
        llenarAreas_envio()
    End Sub
    Private Sub llenarAreas_envio()
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsgen.selectQuery("FlexLine", "pa_var_um_centros_de_impresion_listado")
            Me.cmbTrasladarArea.DataSource = dt
            Me.cmbTrasladarArea.ValueMember = "centro_impresion"
            Me.cmbTrasladarArea.DisplayMember = "centro_impresion"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenarAreas()
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsgen.selectQuery("FlexLine", String.Format("pa_var_um_centros_de_impresion '{0}'", gs_usuario))
            Me.cmbArea.DataSource = dt
            Me.cmbArea.ValueMember = "centro_impresion"
            Me.cmbArea.DisplayMember = "centro_impresion"

        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnActualizarFacturacion_Click(sender As Object, e As EventArgs) Handles btnActualizarFacturacion.Click
        'llenarfacturas_imprimeFacturacion()
        llenarfacturas_centro_impresion()
    End Sub

    Private Sub chkboxpedientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkboxpedientes.CheckedChanged

        Try
            If Me.chkboxpedientes.CheckState = CheckState.Checked Then
                dtFacturas.DefaultView.RowFilter = "impreso=0"
            Else
                dtFacturas.DefaultView.RowFilter = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnImpresionFEL_PDF_Click(sender As Object, e As EventArgs) Handles btnImpresionFEL_PDF.Click
        Dim nrow As Integer = dgv_pedidosFACE.CurrentRow.Index
        Dim lsRuta As String = ""
        Dim clsgen As New ClasesGenerales.General
        Try
            If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                lsRuta = Me.FolderBrowserDialog1.SelectedPath
            End If
            clsgen.Escribir_Log(lsRuta)




            If MessageBox.Show("Esta Seguro de Imprimir", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                If Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString.ToLower.StartsWith("consi") Then
                    imprimir_consignaciones(Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString)
                Else


                    imprimirFacturas_PDF(Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString, lsRuta)

                    If Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString.ToUpper.StartsWith("CONTA") Then
                        If MessageBox.Show("Desea Imprimir Recibos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Imprimir_recibos(Me.dgv_pedidosFACE.Item("empresa", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("tipodocto", nrow).Value.ToString, Me.dgv_pedidosFACE.Item("numero", nrow).Value.ToString)
                        End If
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub imprimirFacturas_PDF(psEmpresa As String, psTipodocto As String, psNumero As String, psRuta As String)
        Dim clsGen As New ClasesGenerales.General

        Dim lsArchivoGenerado As String = psRuta & "\" & psEmpresa & "_" & psTipodocto.Replace(" ", "_") & "_" & psNumero & ".pdf"





        Dim lsSQL As String

            Dim dt As DataTable

            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String
            Dim ppath_reporte As String
        'Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Dim pm_parametros2(2) As String
            Dim pm_valores2(2) As String

        '   Oaut.pnNumeroCopias = 1 'nupCopias.Value
        'Oaut.Archivo_Generado = lsArchivoGenerado

        Try


                pm_conexion = clsGen.Parametros_Conexion("")
                ppath_reporte = clsGen.Path_Reporte

                'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

                pm_parametros(0) = "empresa"
                pm_parametros(1) = "tipodocto"
                pm_parametros(2) = "numero"
                pm_parametros(3) = "user_name"


                ppath_reporte = clsGen.Path_Reporte
                ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                ppath_reporte += psEmpresa + " "
                ppath_reporte += psTipodocto
                ppath_reporte += ".rpt"

                pm_valores(0) = psEmpresa
                pm_valores(1) = psTipodocto
                pm_valores(2) = psNumero
                pm_valores(3) = gs_usuario & " - " & gs_nombre_equipo

            _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), True, False, "PDF", False, lsArchivoGenerado, True, 1)


            'Agregar quien imprimio
            lsSQL = "pa_ins_um_gen_log_documento_impresion '" & psEmpresa & "','" & psTipodocto & "','" & psNumero & "','" & gs_usuario & "','" & gs_nombre_equipo & "','frmImpresionFacturasAreas'," & nupCopias.Value
            clsGen.insertQuery("FlexLine", lsSQL)

        Catch ex As Exception
            Finally
            'Oaut = Nothing
            clsGen = Nothing
            End Try


    End Sub


    Private Sub imprimir_consignaciones_pfd(ByVal pEmpresa As String, ByVal pTipoDocto As String, ByVal pNumero As String, psRuta As String)


        Dim lsArchivoGenerado As String = psRuta & "\" & pEmpresa & "_" & pTipoDocto.Replace(" ", "_") & "_" & pNumero & ".pdf"


        Dim path_reporte As String
        Dim pm_valores(4) As String
        Dim pm_parametros(4) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            pm_conexion = clsGen.Parametros_Conexion("vDATASERVER")
            path_reporte = clsGen.Path_Reporte()
            ''path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Logistica\Trafico\Guía del Liquidador Global 2005 onBase.rpt"
            path_reporte += "Finanzas\Facturacion\Consignaciones "
            path_reporte += pEmpresa & ".rpt"

            'path_reporte = "\\192.192.1.170\reportes$\Logistica\Bodega\Impresion de Movimientos.rpt"

            pm_parametros(0) = "Empresa"
            pm_parametros(2) = "tipoDocto"
            pm_parametros(1) = "Numero"
            pm_valores(0) = pEmpresa
            pm_valores(2) = pTipoDocto
            pm_valores(1) = pNumero
            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '                          True, False, "PDF", False, "", True)
            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            True, False, "PDF", False, lsArchivoGenerado, True, nupCopias.Value)


            lsSQL = String.Format("pa_ins_um_gen_log_documento_impresion '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'",
                      pEmpresa, pTipoDocto, pNumero, gs_usuario, gs_nombre_equipo, "frmImpresionFacturasAreas", nupCopias.Value)



            ClsGen.insertQuery("FlexLine", lsSQL)


        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub



End Class