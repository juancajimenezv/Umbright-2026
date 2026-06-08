Public Class frmRequisicionRecepcionFactura
    Dim oDS As DataSet

    Private Sub crearEstructura()

        oDS = New DataSet
        Dim dt As DataTable = New DataTable("imagenes")
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("rutaLocal", GetType(String)))
        dt.Columns.Add(New DataColumn("operar", GetType(Integer)))
        '        dt.Columns("codigo").Unique = True 'Llave Unica
        oDS.Tables.Add(dt)
    End Sub

    Private Sub cargarEmpresas()
        Dim otransaccion = New Transaccional.Conexion("flexline")
        Dim ls_SqlScript As String
        Dim ldt_table As DataTable
        Try
            otransaccion.open()

            ls_SqlScript = "flexline.pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            ldt_table = otransaccion.Obtiene(ls_SqlScript)
            Me.cmb_empresa.DisplayMember = "empresa"
            Me.cmb_empresa.ValueMember = "empresa"
            Me.cmb_empresa.DataSource = ldt_table

            Me.cmbEmpresaIMG.DisplayMember = "empresa"
            Me.cmbEmpresaIMG.ValueMember = "empresa"
            Me.cmbEmpresaIMG.DataSource = ldt_table

        Catch ex As Exception
        Finally
            otransaccion.close()
            otransaccion = Nothing

        End Try

    End Sub

    Private Sub guardarFactura()
        Dim clsGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            Otrans.open()
            lsSQL = "pa_sel_um_requisicionr_proximo_numero '" & Me.cmb_empresa.Text & "'"
            dt = Otrans.Obtiene(lsSQL)

            lsSQL = "pa_ins_um_requisicionr '" & Me.cmb_empresa.Text & "'," & dt.Rows(0).Item("numero_control") & ",'" & _
                                txtNumeroRequisicion.Text.PadLeft(10, "0") & "','" & _
                                Me.txtSerieReferencia.Text & "','" & Me.txtNumeroReferencia.Text & "','" & Me.dtpFechaReferencia.Value.ToString("dd/MM/yyyy") & "'," & Me.txtMontoReferencia.Text & ",'" & _
                                gs_usuario & "','" & _
                                Me.txtEntregaReferencia.Text & "'"

            If Me.txtSerieFEL.Text.Length > 0 Then

                lsSQL = "pa_ins_um_requisicionr '" & Me.cmb_empresa.Text & "'," & dt.Rows(0).Item("numero_control") & ",'" &
                                    txtNumeroRequisicion.Text.PadLeft(10, "0") & "','" &
                                    Me.txtSerieFEL.Text & "','" & Me.txtNumeroFEL.Text & "','" & Me.dtpFechaFEL.Value.ToString("dd/MM/yyyy") & "'," & Me.txtMontoFEL.Text & ",'" &
                                    gs_usuario & "','" &
                                    Me.txtEntregaReferencia.Text & "'"
            End If


            Otrans.Ingresa(lsSQL)
            If Otrans.Codigo_error > 0 Then
                MessageBox.Show(Otrans.descripcion_error)
            Else
                imprimirRecepcion(cmb_empresa.Text, dt.Rows(0).Item("numero_control"))
            End If

            Me.lblNumero.Text = dt.Rows(0).Item("numero_control")

            If MessageBox.Show("Desea Agregar Mas Facturas?", "Confirmacion", MessageBoxButtons.YesNo) = DialogResult.Yes Then


            End If




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub imprimirRecepcion(ByRef psEmpresa As String, ByRef piNumero As Integer)
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim pm_conexion(3) As String
        pm_conexion = clsgen.Parametros_Conexion("SCM")
        'Dim lsArchivoGenerado As String = Environment.GetEnvironmentVariable("TEMP") & "\" & psNombreReporte & "_" & gs_empresa & "_" & Me.lblNumero.Text & ".pdf"

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            'Oaut.Archivo_Generado = lsArchivoGenerado
            Oaut.pnNumeroCopias = 1

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Compras e Importaciones\requisiciones\Comprobante.rpt"
            pm_parametros(0) = "@PEmpresa"
            pm_parametros(1) = "@PNumero_control"
            pm_valores(0) = psEmpresa
            pm_valores(1) = piNumero




            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), False, True, "PDF", False)
            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), False, True, "PDF", False)
        Catch ex As Exception
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try
    End Sub


    Private Sub imprimirRecepcionPDF(ByRef psEmpresa As String, ByRef piNumero As Integer)
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim clsgen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim lsArchivoGenerado As String = Environment.GetEnvironmentVariable("TEMP") & "\" & gs_empresa & "_" & Me.lblNumero.Text & ".pdf"
        Dim pm_conexion(3) As String
        pm_conexion = clsgen.Parametros_Conexion("SCM")

        Try
            Oaut = New Automatizar.Reportes_CraxDrt(gs_empresa)
            Oaut.Archivo_Generado = lsArchivoGenerado
            Oaut.pnNumeroCopias = 1

            path_reporte = clsgen.Path_Reporte()
            path_reporte += "Compras e Importaciones\requisiciones\Comprobante.rpt"
            pm_parametros(0) = "@PEmpresa"
            pm_parametros(1) = "@PNumero_control"
            pm_valores(0) = psEmpresa
            pm_valores(1) = piNumero


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), True, False, "PDF", True)
            'Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, "SCM", "SCM", "flexline", "flexline", False, True, "PDF", True)
        Catch ex As Exception
        Finally
            clsgen = Nothing
            Oaut.finalizar()
            Oaut = Nothing

        End Try
    End Sub

    Private Sub limpiarCampos()
        Me.txtNumeroRequisicion.Text = String.Empty
        Me.txtEntregaReferencia.Text = String.Empty
        Me.txtNumeroReferencia.Text = String.Empty
        Me.txtSerieReferencia.Text = String.Empty
        Me.txtCodigoBarra.Text = String.Empty
        Me.txtMontoReferencia.Text = String.Empty

        Me.dtpFechaReferencia.Value = Today

        Me.txtMontoRequisicion.Text = "0.00"
        Me.lblNumero.Text = "0"
        Me.txtProveedor.Text = String.Empty
        Me.txtCodigoBarra.Text = String.Empty

        Me.txtMontoFEL.Text = String.Empty
        Me.txtSerieFEL.Text = String.Empty
        Me.txtNumeroFEL.Text = String.Empty
        Me.txtpdfLink.Text = String.Empty

        Me.txtNumeroReferencia.Enabled = False
        Me.btnGuardar.Enabled = False

        Me.txtCodigoBarra.Focus()


    End Sub

    Private Sub buscarRequisicion()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()

            lsSQL = "pa_sel_um_requisicion '" & Me.cmb_empresa.Text & "','" & Me.txtNumeroRequisicion.Text.PadLeft(10, "0") & "'"
            dt = Otrans.Obtiene(lsSQL)

            Dim dr As DataRow = dt.Rows(0)
            If dr.Item("estado").ToString = "60" Then
                'Me.lblNumero.Text = dr.Item("numero")
                Me.txtProveedor.Text = dr.Item("proveedor").ToString & "/" & dt.Rows(0).Item("RazonSocial").ToString
                'Me.lblEstadoActual.Text = Me.dgvListado.Item("estado", iRowIndex).Value()
                Me.txtMontoRequisicion.Text = dr.Item("totalDetalle")
                Me.txtNumeroReferencia.Enabled = True
                Me.btnGuardar.Enabled = True

            Else
                MessageBox.Show("Valide el Estado de Esta Orden de Compra", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNumeroReferencia.Enabled = False
                Me.btnGuardar.Enabled = False
                Return

            End If




        Catch ex As Exception
            Me.txtNumeroReferencia.Enabled = False
            Me.btnGuardar.Enabled = False
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub


    Private Sub buscarRequisicionIMG()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()

            Me.txtNumeroReqIMG.Text = Me.txtNumeroReqIMG.Text.PadLeft(10, "0")

            lsSQL = "pa_sel_um_requisicion '" & Me.cmbEmpresaIMG.Text & "','" & Me.txtNumeroReqIMG.Text.PadLeft(10, "0") & "'"
            dt = Otrans.Obtiene(lsSQL)

            Dim dr As DataRow = dt.Rows(0)
            'Me.lblNumero.Text = dr.Item("numero")
            Me.txtProveedorIMG.Text = dr.Item("proveedor").ToString & "/" & dt.Rows(0).Item("RazonSocial").ToString
            'Me.lblEstadoActual.Text = Me.dgvListado.Item("estado", iRowIndex).Value()
            Me.txtMontoIMG.Text = dr.Item("totalDetalle")
            Me.lblCorrelativoIMG.Text = dr.Item("correlativo")

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub


    Private Sub subirPDF(ByVal psTipo As String)
        Dim sNombreArchivo, sNombreImagen As String
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow

        Try


            OFD.FileName = ""
            OFD.Filter = "pdf|*.pdf"
            OFD.ShowDialog()

            sNombreArchivo = OFD.FileName

            If MessageBox.Show("Esta Seguro de Cargar PDF", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sNombreImagen = InputBox("Ingrese Nombre de Imagen", "Nombre")
                'psTipo = imagenes, cotizaciones
                dr = oDS.Tables(psTipo).NewRow
                dr.Item("nombre") = sNombreImagen
                dr.Item("rutaLocal") = sNombreArchivo
                dr.Item("operar") = 1
                oDS.Tables(psTipo).Rows.Add(dr)
            End If

            Me.dgvIMG.DataSource = oDS.Tables(psTipo)
            clsGen.Alinear_GridView(oDS.Tables("imagenes"), Me.dgvIMG, "", ",operar,", ",nombre,rutalocal,operar,", "", True, True, 250, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Sub guardarImagenes(ByVal Otrans As Transaccional.Conexion, ByVal clsgen As ClasesGenerales.General, ByVal sNumero As String)

        Dim lsSQL As String
        'Guardar Imagenes
        For Each dr As DataRow In oDS.Tables("imagenes").Rows
            'Dim sRuta As String = "\\onbase\tools$\images\req\" & gs_empresa & "_" & Me.lblNumero.Text & "_" & dr.Item("rutaLocal").ToString.Substring(dr.Item("rutaLocal").ToString.LastIndexOf("\") + 1, _
            '      dr.Item("rutaLocal").ToString.Length - dr.Item("rutaLocal").ToString.LastIndexOf("\") - 1)

            If dr.Item("operar") = 1 Then


                Dim sRuta As String = clsgen.Path_Imagenes & "Requisicion\" & Me.cmbEmpresaIMG.Text & _
                    "_" & Me.txtNumeroReqIMG.Text & "_" & dr.Item("rutaLocal").ToString.Substring(dr.Item("rutaLocal").ToString.LastIndexOf("\") + 1, _
                    dr.Item("rutaLocal").ToString.Length - dr.Item("rutaLocal").ToString.LastIndexOf("\") - 1)



                lsSQL = "pa_ins_um_requisicionImagen '" & Me.cmbEmpresaIMG.Text & "'," & sNumero & ",'" & _
                    dr.Item("nombre").ToString & " ','" & _
                    dr.Item("rutaLocal").ToString & "','" & sRuta & "'"
                Otrans.Ingresa(lsSQL)

                clsgen.Copiar_Archivo(dr.Item("rutaLocal").ToString, sRuta, False)

                dr.Item("operar") = 0
            End If
        Next
        MessageBox.Show("Proceso Finalizado, Puede Continuar", "Informacion", MessageBoxButtons.OK)


    End Sub


    Private Sub frmRequisicionRecepcionFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crearEstructura()
        cargarEmpresas()
        limpiarCampos()
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Me.txtNumeroFEL.Text.Length > 0 Then
            If MessageBox.Show("Esta Seguro de Guardar Contraseña", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.guardarFactura()
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiarCampos()
    End Sub

    Private Sub txtNumeroRequisicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroRequisicion.KeyPress

        If e.KeyChar = Chr(13) Then
            buscarRequisicion()
        End If
    End Sub

    Private Sub txtNumeroRequisicion_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroRequisicion.TextChanged

    End Sub

    Private Sub txtMontoRequisicion_TextChanged(sender As Object, e As EventArgs) Handles txtMontoRequisicion.TextChanged
        txtMontoRequisicion.Text = Format(Convert.ToDecimal(txtMontoRequisicion.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub txtCodigoBarra_GotFocus(sender As Object, e As EventArgs) Handles txtCodigoBarra.GotFocus
        Me.txtCodigoBarra.SelectAll()
    End Sub

    Private Sub txtCodigoBarra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoBarra.KeyPress
        If e.KeyChar = Chr(13) Then
            Try


                If Me.txtCodigoBarra.Text.Length = 12 Then
                    Dim lsEmpresa As String = Me.txtCodigoBarra.Text.Substring(0, 1)
                    If lsEmpresa = "1" Then
                        Me.cmb_empresa.SelectedValue = "DMARTE1"
                    ElseIf lsEmpresa = "2" Then
                        Me.cmb_empresa.SelectedValue = "CODICASA"
                    ElseIf lsEmpresa = "3" Then
                        Me.cmb_empresa.SelectedValue = "DIUVA"
                    ElseIf lsEmpresa = "4" Then
                        Me.cmb_empresa.SelectedValue = "VINOTECA"
                    ElseIf lsEmpresa = "5" Then
                        Me.cmb_empresa.SelectedValue = "DIMAEXSA"
                    ElseIf lsEmpresa = "6" Then
                        Me.cmb_empresa.SelectedValue = "TECNO"
                    ElseIf lsEmpresa = "7" Then
                        Me.cmb_empresa.SelectedValue = "DIVINOS"
                    ElseIf lsEmpresa = "8" Then
                        Me.cmb_empresa.SelectedValue = "UMBRAL"
                    ElseIf lsEmpresa = "9" Then
                        Me.cmb_empresa.SelectedValue = "LOGISERV"
                    End If
                    Me.txtNumeroRequisicion.Text = Me.txtCodigoBarra.Text.Substring(1, 10)
                    buscarRequisicion()
                End If
            Catch ex As Exception

            End Try
            Me.txtCodigoBarra.SelectAll()
            Me.txtSerieReferencia.Focus()
        End If

    End Sub



    Private Sub txtCodigoBarra_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoBarra.TextChanged

    End Sub

    Private Sub btnCargarImagenes_Click(sender As Object, e As EventArgs)
        subirPDF("PDF")
    End Sub

    Private Sub txtNumeroReqIMG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroReqIMG.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarRequisicionIMG()
        End If
    End Sub



    Private Sub btnNuevoIMG_Click(sender As Object, e As EventArgs) Handles btnNuevoIMG.Click
        oDS.Tables("imagenes").Rows.Clear()
        Me.txtNumeroReqIMG.Text = String.Empty
        Me.lblCorrelativoIMG.Text = String.Empty
        Me.txtMontoIMG.Text = 0
    End Sub

    Private Sub btnGuardarIMG_Click(sender As Object, e As EventArgs) Handles btnGuardarIMG.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Otrans As New Transaccional.Conexion("SCM")
            Dim clsGen As New ClasesGenerales.General

            Try
                Otrans.abrir()
                Me.guardarImagenes(Otrans, clsGen, Me.lblCorrelativoIMG.Text)

            Catch ex As Exception
            Finally
                Otrans.close()
                Otrans = Nothing

            End Try

        End If

    End Sub


    Private Sub btnBuscarIMG_Click(sender As Object, e As EventArgs) Handles btnBuscarIMG.Click
        subirPDF("imagenes")
    End Sub



    Private Sub btnBuscarFEL_Click(sender As Object, e As EventArgs) Handles btnBuscarFEL.Click
        Dim dt As DataTable
        dt = buscarFEL(txtNumeroReferencia.Text)
        If dt.Rows.Count() > 0 Then
            With dt.Rows(0)
                Me.txtNumeroFEL.Text = .Item("numero").ToString
                Me.txtSerieFEL.Text = .Item("serie").ToString
                Me.txtMontoFEL.Text = .Item("total").ToString
                Me.txtpdfLink.Text = .Item("pdf_link").ToString

                Me.dtpFechaFEL.Value = .Item("fecha")
            End With
            If dt.Rows(0).Item("nitcertificador").ToString.Equals("12521337") Then
                Me.txtpdfLink.Text = "https://report.feel.com.gt/ingfacereport/ingfacereport_documento?uuid=" & dt.Rows(0).Item("AutSat").ToString
            End If
        End If
    End Sub

    Private Function buscarFEL(psNumeroFel As String) As DataTable
        Dim clsGEN As New ClasesGenerales.General
        Dim dt As New DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_sel_um_fel_documento_compras_numero '" & psNumeroFel & "'"
            dt = clsGEN.selectQuery("RegionalDBintOut", lsSQL)

        Catch ex As Exception

        Finally
            clsGEN = Nothing
        End Try
        Return dt
    End Function

    Private Sub btnVerFel_Click(sender As Object, e As EventArgs) Handles btnVerFel.Click
        Dim url As String = Me.txtpdfLink.Text

        Try
            Process.Start(url)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        imprimirRecepcionPDF(cmb_empresa.Text, Me.lblNumero.Text)


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        recibir_unafactura_multipes_ordenes()
    End Sub


    Private Sub recibir_unafactura_multipes_ordenes()
        Dim dt As DataTable
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("SCM")
        Try
            Otrans.open()
            lsSQL = "pa_sel_um_requisicionr_proximo_numero '" & Me.cmb_empresa.Text & "'"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows


                lsSQL = "pa_ins_um_requisicionr '" & Me.cmb_empresa.Text & "'," & dt.Rows(0).Item("numero_control") & ",'" &
                                txtNumeroRequisicion.Text.PadLeft(10, "0") & "','" &
                                Me.txtSerieReferencia.Text & "','" & Me.txtNumeroReferencia.Text & "','" & Me.dtpFechaReferencia.Value.ToString("dd/MM/yyyy") & "'," & Me.txtMontoReferencia.Text & ",'" &
                                gs_usuario & "','" &
                                Me.txtEntregaReferencia.Text & "'"

                If Me.txtSerieFEL.Text.Length > 0 Then

                    lsSQL = "pa_ins_um_requisicionr '" & Me.cmb_empresa.Text & "'," & dt.Rows(0).Item("numero_control") & ",'" &
                                        txtNumeroRequisicion.Text.PadLeft(10, "0") & "','" &
                                        Me.txtSerieFEL.Text & "','" & Me.txtNumeroFEL.Text & "','" & Me.dtpFechaFEL.Value.ToString("dd/MM/yyyy") & "'," & Me.txtMontoFEL.Text & ",'" &
                                        gs_usuario & "','" &
                                        Me.txtEntregaReferencia.Text & "'"
                End If


                Otrans.Ingresa(lsSQL)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show(Otrans.descripcion_error)
                End If

            Next

            Me.lblNumero.Text = dt.Rows(0).Item("numero_control")
            '(c) 20230426 deben ser multipes 
            'imprimirRecepcion(cmb_empresa.Text, dt.Rows(0).Item("numero_control"))





        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

    End Sub

    Private Sub txtConsultaBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtConsultaBuscar.TextChanged

    End Sub

    Private Sub txtNumeroReferencia_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroReferencia.TextChanged

    End Sub

    Private Sub txtConsultaBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConsultaBuscar.KeyPress

        Try



            If e.KeyChar = Chr(13) Then
                Dim dt As DataTable
                dt = buscarFEL(Me.txtConsultaBuscar.Text)
                If dt.Rows.Count() > 0 Then
                    With dt.Rows(0)

                        Me.txtConsultaSerie.Text = .Item("serie").ToString
                        Me.txtConsultaMonto.Text = .Item("total").ToString
                        Me.txtConsultaRuta.Text = .Item("pdf_link").ToString

                        Me.dtpConsultaFecha.Value = .Item("fecha")
                    End With
                    'If dt.Rows(0).Item("nitcertificador").ToString.Equals("12521337") Then
                    '    Me.txtpdfLink.Text = "https://report.feel.com.gt/ingfacereport/ingfacereport_documento?uuid=" & dt.Rows(0).Item("AutSat").ToString
                    'End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnConsultaVer_Click(sender As Object, e As EventArgs) Handles btnConsultaVer.Click
        Dim url As String = Me.txtConsultaRuta.Text

        Try
            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub
End Class