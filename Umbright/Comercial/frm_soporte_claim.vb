Public Class frm_soporte_claim
    Dim dtListado As DataTable
    Dim dtListadoCosto As DataTable



    Private Sub crearEstructura()

    End Sub

    Private Sub llenarCombos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_gen_tabcod null,'con_marca','" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt = clsgen.ValoresDistinto(dt, "TEXTO4".Split(","))

            Me.cmbBU.DataSource = dt
            Me.cmbBU.ValueMember = "TEXTO4"
            Me.cmbBU.DisplayMember = "TEXTO4"


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub generarInformacion()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dtMarca As DataTable
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow
        Try

            Otrans.open()
            lsSQL = "pa_var_um_requisicion_claim '" & dtpFechaInicio.Value.ToString & "','" & dtpFechaFinal.Value.ToString & "','" & Me.cmbBU.SelectedValue & "'"
            dtListado = Otrans.Obtiene(lsSQL)

            Me.DataGridView1.DataSource = dtListado

            clsGen.Alinear_GridView(dtListado, Me.DataGridView1, "", "", "", "", True, True, 250, 0)

            dtMarca = clsGen.ValoresDistinto(dtListado, "Marca".Split(","))
            dr = dtMarca.NewRow
            dr.Item("Marca") = "TODAS"
            dtMarca.Rows.Add(dr)

            Me.cmbMarca.DataSource = dtMarca
            Me.cmbMarca.ValueMember = "Marca"
            Me.cmbMarca.DisplayMember = "Marca"

            Me.cmbMarca.Text = "TODAS"
            aplicarFiltroMarca()
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub aplicarFiltroMarca()

        Try
            If Me.cmbMarca.Text = "TODAS" Then
                dtListado.DefaultView.RowFilter = ""
            Else
                dtListado.DefaultView.RowFilter = "Marca = '" & Me.cmbMarca.Text & "'"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub imprimirDocumentos(pBVistaPrevia As Boolean)
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            Otrans.open()

            For Each drv As DataRowView In Me.dtListado.DefaultView
                If drv.Item("Imprimir") = True Then
                    If drv.Item("imagen_factura") > 0 Then

                        exportar_reporte("Orden de Compra Local", drv.Item("Empresa").ToString,
                                             drv.Item("Requisicion").ToString, pBVistaPrevia)


                        lsSQL = "pa_sel_um_requisicionImagen '" & drv.Item("Empresa").ToString & "','" & drv.Item("Requisicion").ToString & "'"
                        dt = Otrans.Obtiene(lsSQL)
                        For Each dr As DataRow In dt.Rows

                            lsSQL = dr.Item("rutaactual").ToString

                            Try
                                If Not pBVistaPrevia Then

                                    With New Process
                                        .StartInfo.Verb = "print"
                                        .StartInfo.CreateNoWindow = False
                                        .StartInfo.FileName = lsSQL
                                        .Start()
                                        .WaitForExit(10000)
                                        .CloseMainWindow()
                                        .Close()
                                    End With
                                Else
                                    Dim proceso As Process = New Process

                                    proceso.StartInfo.FileName = lsSQL '.Replace(".jpg", ".pdf")
                                    proceso.Start()
                                    proceso = Nothing

                                End If
                            Catch ex As Exception

                            End Try
                        Next
                    End If

                End If
            Next

        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


        If False Then



        End If
    End Sub

    Private Function exportar_reporte(ByVal psNombreReporte As String, ByVal psEmpresa As String, ByVal psNumero As String, pBVistaPrevia As Boolean) As String
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim lsArchivoGenerado As String = Environment.GetEnvironmentVariable("TEMP") & "\" & psNombreReporte & "_" & psEmpresa & "_" & psNumero & ".pdf"
        Dim pm_conexion(3) As String
        pm_conexion = clsgen.Parametros_Conexion("SCM")

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = lsArchivoGenerado

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Compras e Importaciones\" & psNombreReporte & ".rpt"
            pm_parametros(0) = "@PEmpresa"
            pm_parametros(1) = "@PNumero"
            pm_valores(0) = psEmpresa
            pm_valores(1) = psNumero


            'Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", pBVistaPrevia, Not pBVistaPrevia, "PDF", True)
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), pBVistaPrevia, Not pBVistaPrevia, "PDF", True)
            'Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), Not pbVisualizar, False, "PDF", pbVisualizar)


        Catch ex As Exception
            clsgen.Escribir_Log(Oaut.Descripcion_Error)
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try

        Return lsArchivoGenerado
    End Function

    Private Function exportar_reporte(ByVal psNombreReporte As String, ByVal psEmpresa As String, ByVal psNumero As String, pBVistaPrevia As Boolean, psCarpeta As String) As String
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim lsArchivoGenerado As String = psCarpeta & "\" & psNombreReporte & "_" & psEmpresa & "_" & psNumero & ".pdf"
        Dim pm_conexion(3) As String
        pm_conexion = clsgen.Parametros_Conexion("SCM")
        Try

            clsgen.Escribir_Log(lsArchivoGenerado)

            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = lsArchivoGenerado

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Compras e Importaciones\" & psNombreReporte & ".rpt"
            pm_parametros(0) = "@PEmpresa"
            pm_parametros(1) = "@PNumero"
            pm_valores(0) = psEmpresa
            pm_valores(1) = psNumero


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), True, False, "PDF", False)




        Catch ex As Exception
            clsgen.Escribir_Log(Oaut.Descripcion_Error)
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try

        Return lsArchivoGenerado
    End Function



    Private Sub copiarDocumentos(pSRutaLocal As String)
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try
            clsGen.Escribir_Log("Ruta Seleccionada: " & pSRutaLocal)

            Otrans.open()

            For Each drv As DataRowView In Me.dtListado.DefaultView
                If drv.Item("Imprimir") = True Then
                    If drv.Item("imagen_factura") > 0 Then

                        exportar_reporte("Orden de Compra Local", drv.Item("Empresa").ToString,
                                             drv.Item("Requisicion").ToString, False, pSRutaLocal)


                        lsSQL = "pa_sel_um_requisicionImagen '" & drv.Item("Empresa").ToString & "','" & drv.Item("Requisicion").ToString & "'"
                        dt = Otrans.Obtiene(lsSQL)
                        For Each dr As DataRow In dt.Rows
                            Try
                                lsSQL = dr.Item("rutaactual").ToString


                                Dim fi As New IO.FileInfo(lsSQL)
                                Dim justFileName As String = fi.Name
                                'MessageBox.Show(justFileName)





                                clsGen.Copiar_Archivo(lsSQL, pSRutaLocal + "\" + justFileName, True)


                                'If Not pBVistaPrevia Then

                                '    With New Process
                                '        .StartInfo.Verb = "print"
                                '        .StartInfo.CreateNoWindow = False
                                '        .StartInfo.FileName = lsSQL
                                '        .Start()
                                '        .WaitForExit(10000)
                                '        .CloseMainWindow()
                                '        .Close()
                                '    End With
                                'Else
                                '    Dim proceso As Process = New Process

                                '    proceso.StartInfo.FileName = lsSQL '.Replace(".jpg", ".pdf")
                                '    proceso.Start()
                                '    proceso = Nothing

                                'End If
                            Catch ex As Exception

                            End Try
                        Next
                    End If

                End If
            Next

        Catch ex As Exception
            clsGen.Escribir_Log(ex.Message)
            clsGen.Escribir_Log(ex.ToString)

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


        If False Then



        End If
    End Sub
    Private Sub frm_soporte_claim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombos()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        generarInformacion()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedValueChanged

        'cmbBU.SelectedValueChanged()

        Me.aplicarFiltroMarca()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta Seguro de Imprimir Documento", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            imprimirDocumentos(False)
        End If
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        imprimirDocumentos(True)
    End Sub

    Private Sub btnMarcar_Click(sender As Object, e As EventArgs) Handles btnMarcar.Click


        Try
            For Each dr As DataRow In dtListado.Rows
                dr.Item("Imprimir") = Not dr.Item("Imprimir")
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        Dim lsRuta As String = ""
        Dim clsgen As New ClasesGenerales.General
        Try
            If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                lsRuta = Me.FolderBrowserDialog1.SelectedPath
            End If
            clsgen.Escribir_Log(lsRuta)

        Catch ex As Exception

        End Try



        copiarDocumentos(lsRuta)

    End Sub

    Private Sub cmbBU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBU.SelectedIndexChanged

    End Sub




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnGenerarFaC.Click
        mostrarFacturasAlCosto()
    End Sub

    Private Sub mostrarFacturasAlCosto()
        'Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dtMarca As DataTable
        Dim dtBU As DataTable
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow
        Try

            'Otrans.open()
            lsSQL = "pa_var_um_documento_costo_claim '" & gs_empresa & "','" & dtpInicioFaC.Value.ToString("dd/MM/yyyy") & "','" & dtpFinalFaC.Value.ToString("dd/MM/yyyy") & "'"
            dtListadoCosto = clsGen.selectQuery("FlexLine", lsSQL)

            Me.dgvDocumentosFaC.DataSource = dtListadoCosto

            clsGen.Alinear_GridView(dtListadoCosto, Me.dgvDocumentosFaC, "", "", "", "", True, True, 250, 0)

            dtBU = clsGen.ValoresDistinto(dtListadoCosto, "bu".Split(","))
            Me.cmbBU_costo.DataSource = dtBU
            Me.cmbBU_costo.ValueMember = "bu"
            Me.cmbBU_costo.DisplayMember = "bu"
            'dr = dtMarca.NewRow
            'dr.Item("Marca") = "TODAS"
            'dtMarca.Rows.Add(dr)

            dtMarca = clsGen.ValoresDistinto(dtListadoCosto, "Marca".Split(","))
            dr = dtMarca.NewRow
            dr.Item("Marca") = "TODAS"
            dtMarca.Rows.Add(dr)

            Me.cmbMARCA_costo.DataSource = dtMarca
            Me.cmbMARCA_costo.ValueMember = "Marca"
            Me.cmbMARCA_costo.DisplayMember = "Marca"

            Me.cmbMARCA_costo.Text = "TODAS"
            aplicarFiltrobu_costo()
            aplicarFiltroMarca_costo()
        Catch ex As Exception
        Finally
            'Otrans.close()
            'Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub aplicarFiltrobu_costo()

        Dim dtMarca As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow

        Try
            dtListadoCosto.DefaultView.RowFilter = "bu = '" & Me.cmbBU_costo.Text & "'"


            dtMarca = dtListadoCosto.DefaultView.ToTable.Copy
            dtMarca = clsGen.ValoresDistinto(dtMarca, "Marca".Split(","))
            dr = dtMarca.NewRow
            dr.Item("Marca") = "TODAS"
            dtMarca.Rows.Add(dr)

            Me.cmbMARCA_costo.DataSource = dtMarca
            Me.cmbMARCA_costo.ValueMember = "Marca"
            Me.cmbMARCA_costo.DisplayMember = "Marca"

            Me.cmbMARCA_costo.Text = "TODAS"

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub aplicarFiltroMarca_costo()
        Try
            If Me.cmbMARCA_costo.Text = "TODAS" Then
                dtListadoCosto.DefaultView.RowFilter = "bu = '" & Me.cmbBU_costo.Text & "'"
            Else
                dtListadoCosto.DefaultView.RowFilter = "Marca = '" & Me.cmbMARCA_costo.Text & "'"
            End If
        Catch ex As Exception

        End Try
    End Sub





    Private Sub cmbBU_costo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBU_costo.SelectedValueChanged
        aplicarFiltrobu_costo()
    End Sub


    Private Sub cmbMARCA_costo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMARCA_costo.SelectedValueChanged
        aplicarFiltroMarca_costo()
    End Sub

    Private Sub btnMarcarFaC_Click(sender As Object, e As EventArgs) Handles btnMarcarFaC.Click
        Try
            For Each dr As DataRow In dtListadoCosto.Rows
                dr.Item("Imprimir") = Not dr.Item("Imprimir")
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDescargarFaC_Click(sender As Object, e As EventArgs) Handles btnDescargarFaC.Click
        Dim lsRuta As String = ""



        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            lsRuta = Me.FolderBrowserDialog1.SelectedPath
        End If

        copiarDocumentosCosto(lsRuta)
    End Sub

    Private Sub copiarDocumentosCosto(pSRutaLocal As String)
        'Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try

            'Otrans.open()

            For Each drv As DataRowView In Me.dtListadoCosto.DefaultView
                If drv.Item("Imprimir") = True Then
                    'If drv.Item("imagen_factura") > 0 Then

                    'exportar_reporteCosto("Guatefacturas " & drv.Item("Empresa").ToString & " FEL AL COSTO", drv.Item("Empresa").ToString,
                    'drv.Item("numero").ToString, False, pSRutaLocal, drv.Item("tipodocto").ToString)


                    exportar_reporteCosto("Guatefacturas " & drv.Item("Empresa").ToString & " " & drv.Item("tipodocto").ToString, drv.Item("Empresa").ToString,
                                             drv.Item("numero").ToString, False, pSRutaLocal, drv.Item("tipodocto").ToString)


                    'lsSQL = "pa_sel_um_requisicionImagen '" & drv.Item("Empresa").ToString & "','" & drv.Item("Requisicion").ToString & "'"
                    'dt = Otrans.Obtiene(lsSQL)
                    'For Each dr As DataRow In dt.Rows

                    '    lsSQL = dr.Item("rutaactual").ToString


                    '    Dim fi As New IO.FileInfo(lsSQL)
                    '    Dim justFileName As String = fi.Name
                    '    'MessageBox.Show(justFileName)




                    '    Try
                    '        clsGen.Copiar_Archivo(lsSQL, pSRutaLocal + "\" + justFileName, True)


                    '        'If Not pBVistaPrevia Then

                    '        '    With New Process
                    '        '        .StartInfo.Verb = "print"
                    '        '        .StartInfo.CreateNoWindow = False
                    '        '        .StartInfo.FileName = lsSQL
                    '        '        .Start()
                    '        '        .WaitForExit(10000)
                    '        '        .CloseMainWindow()
                    '        '        .Close()
                    '        '    End With
                    '        'Else
                    '        '    Dim proceso As Process = New Process

                    '        '    proceso.StartInfo.FileName = lsSQL '.Replace(".jpg", ".pdf")
                    '        '    proceso.Start()
                    '        '    proceso = Nothing

                    '        'End If
                    '    Catch ex As Exception

                    '    End Try
                    'Next
                    'End If

                End If
            Next

        Catch ex As Exception

        Finally
            ' Otrans.close()
            ' Otrans = Nothing
            clsGen = Nothing
        End Try


        If False Then



        End If
    End Sub

    Private Function exportar_reporteCosto(ByVal psNombreReporte As String, ByVal psEmpresa As String, ByVal psNumero As String, pBVistaPrevia As Boolean, psCarpeta As String, psTipodocto As String) As String
        Dim path_reporte As String
        Dim pm_valores(3) As String
        Dim pm_parametros(3) As String
        Dim pm_conexion(3) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim lsArchivoGenerado As String = psCarpeta & "\" & psEmpresa & "_" & psNumero & ".pdf"

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = lsArchivoGenerado

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Finanzas\Facturacion\" & psNombreReporte & ".rpt"




            pm_conexion = clsgen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsgen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"


            pm_valores(0) = psEmpresa
            pm_valores(1) = psTipodocto '"FEL AL COSTO"
            pm_valores(2) = psNumero
            pm_valores(3) = gs_usuario


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), True, False, "PDF", False)


        Catch ex As Exception
            clsgen.Escribir_Log(Oaut.Descripcion_Error)
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try

        Return lsArchivoGenerado
    End Function

End Class