Imports System.IO
Imports System.Text
Public Class frmRecepcionFacturas


    Dim ods As New DataSet

    Private Sub crearEstructura()
        Dim dt As DataTable

        dt = New DataTable("detalle")
        dt.Columns.Add(New DataColumn("recibido", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        'dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentarios", GetType(String)))
        dt.Columns.Add(New DataColumn("linea", GetType(Integer)))

        ods.Tables.Add(dt.Copy)

        Me.dgvDetalle.DataSource = ods.Tables("detalle")




    End Sub



    Private Sub MostrarLote(ByVal piNumeroLote As Integer)
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim drAux As DataRow
        Dim lsSQL As String

        Try
            ods.Tables("detalle").Rows.Clear()
            Me.lblNumero.Text = piNumeroLote


            Otrans.abrir()
            lsSQL = "pa_sel_um_gen_log_traslada_documento " & piNumeroLote
            dt = Otrans.Obtiene(lsSQL)




            For Each dr As DataRow In dt.Rows
                drAux = ods.Tables("detalle").NewRow
                drAux("recibido") = False
                drAux("empresa") = dr.Item("empresa")
                drAux("tipodocto") = dr.Item("tipodocto")
                drAux("numero") = dr.Item("numero")
                drAux("razonSocial") = dr.Item("razonSocial")
                drAux("Comentarios") = dr.Item("comentario1")
                drAux("linea") = 1
                ods.Tables("detalle").Rows.Add(drAux)
            Next


            Me.dgvDetalle.DataSource = ods.Tables("detalle")
            clsGen.Alinear_GridView(ods.Tables("detalle"), Me.dgvDetalle, "", ",linea,", ",empresa,numero,razonsocial,", "", ",razonSocial=Proveedor,", "", "", True, True, 250, 0)
            Me.TabControl1.SelectedTab = Me.TabPage1

            Me.lblTotal.Text = ods.Tables("detalle").Rows.Count
            Me.lblusuariotraslada.Text = dt.Rows(0).Item("usuario_traslada").ToString
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub llenarListado()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim lsfiltro As String = ""

        Try
            Otrans.open()


            Try
                lsSQL = "pa_var_um_gen_log_traslada_documento_lote " '& Me.cmbOrigen.Text.Trim
                dt = Otrans.Obtiene(lsSQL)

                If gi_tipo_usuario = 1 Then
                    lblOrigen.Text = "ADMINISTRADOR"
                ElseIf tiene_permisos("mlo_recepcion_facturas_transporte") Then
                    lsfiltro = "destino = 'TRANSPORTE'"
                    lblOrigen.Text = "TRANSPORTE"
                ElseIf tiene_permisos("mlo_recepcion_facturas_cd") Then
                    lsfiltro = "destino = 'BODEGA'"
                    lblOrigen.Text = "BODEGA"
                ElseIf tiene_permisos("mlo_recepcion_facturas_caja") Then
                    lsfiltro = "destino = 'CAJA'"
                    lblOrigen.Text = "CAJA"
                ElseIf tiene_permisos("mlo_recepcion_facturas_xela") Then
                    lsfiltro = "destino = 'Bodega Xela'"
                    lblOrigen.Text = "Bodega Xela"
                ElseIf tiene_permisos("mlo_recepcion_facturas_antigua") Then
                    lsfiltro = "destino = 'Bodega Antigua'"
                    lblOrigen.Text = "Bodega Antigua"
                ElseIf tiene_permisos("mlo_recepcion_facturas_oriente") Then
                    lsfiltro = "destino = 'Bodega Oriente'"
                    lblOrigen.Text = "Bodega Oriente"
                Else
                    lsfiltro = "destino = 'NOTHING'"
                End If

                dt.DefaultView.RowFilter = lsfiltro
                dt = dt.DefaultView.ToTable


            Catch ex As Exception

            End Try

            Me.dgvListado.DataSource = dt
            clsGen.Alinear_GridView(dt, dgvListado, "", "", "", "", "", "", "", False, True, 250, 0)


            lsSQL = "pa_var_um_codigo_empresa_barra"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "empresa"
            ods.Tables.Add(dt.Copy)



            lsSQL = "flexline.pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'"
            dt = Otrans.Obtiene(lsSQL)


            Me.cmdEmpresa.DisplayMember = "empresa"
            Me.cmdEmpresa.ValueMember = "empresa"
            Me.cmdEmpresa.DataSource = dt

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub grabarRecepcion()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            Otrans.open()



            For Each dr As DataRow In ods.Tables("detalle").Rows

                lsSQL = "pa_upd_um_Gen_Log_Traslada_Documento '" & dr.Item("Empresa").ToString & "','" & dr.Item("tipodocto").ToString & "','" &
                        dr.Item("numero").ToString & "'," & Me.lblNumero.Text & ",'" & gs_usuario & "',"
                If dr.Item("recibido") = True Then
                    lsSQL += "1"
                Else
                    lsSQL += "0"
                End If
                Otrans.Escribir_Log(lsSQL)
                Otrans.Actualiza(lsSQL)


            Next



            enviarCorreo_html(ods.Tables("detalle"))
            MessageBox.Show("Proceso Finalizado Exitosamente, Se Generará Correo de Confirmación", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.llenarListado()
            Me.lblNumero.Text = String.Empty
            Me.lblpendientes.Text = String.Empty
            Me.lblRecibidos.Text = String.Empty
            Me.lblTotal.Text = String.Empty
            ods.Tables("detalle").Rows.Clear()


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub


    Private Sub enviarCorreo_html(pdt As DataTable)



        Dim sbBody As New StringBuilder
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "lgs1@logiservicios.com"
        Dim snombreRemitente As String = "LS1"
        Dim scuentas As String = ""
        Dim sSubject As String = ""

        Dim lsSQL As String

        Try




            Dim iCount As Integer = 0

            sSubject = "Recepción Facturas Lote " & Me.lblNumero.Text


            sbBody.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")

            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<tr><td colspan='20'>Informe de Recepcion de Documentos en " & lblOrigen.Text & "</td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Recibido por </strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + gs_nombre_usuario + "</td></tr>")


            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Fecha</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + Today + "</td></tr>")

            sbBody.AppendLine("<td><strong>Equipo</strong></td>")
            sbBody.AppendLine("<td  style='text-align: Left;'>" + gs_nombre_equipo + "</td></tr>")



            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Total Documentos</strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + Me.lblTotal.Text + "</td></tr>")

            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Recibidos</strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + Me.lblRecibidos.Text + "</td></tr>")
            sbBody.AppendLine("<tr>")
            sbBody.AppendLine("<td><strong>Rechazados</strong></td>")
            sbBody.AppendLine("<td   style='text-align: Left;'>" + Me.lblpendientes.Text + "</td></tr>")


            'sbBody.AppendLine("<tr>")
            'sbBody.AppendLine("<td><strong>Proveedor</strong></td>")
            'sbBody.AppendLine("<td style='text-align: Left;'>" + Me.txtProveedor.Text + "</td></tr>")


            'sbBody.AppendLine("<tr>")
            'sbBody.AppendLine("<td><strong>Bodega</strong></td>")
            'sbBody.AppendLine("<td  style='text-align: Left;'>" + Me.txtBodega.Text + "</td></tr>")

            'If Me.txtComentario4.Text.Length > 0 Then


            '    sbBody.AppendLine("<tr>")
            '    sbBody.AppendLine("<td><strong>Comentarios</strong></td>")
            '    sbBody.AppendLine("<td  style='text-align: Left;'>" + Me.txtComentario4.Text + "</td></tr>")

            'End If
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")




            Try

                Dim dt3 As DataTable
                If lblOrigen.Text.Equals("TRANSPORTE") Or
                    lblOrigen.Text.Equals("BODEGA") Or
                    lblOrigen.Text.Equals("CAJA") Then
                    scuentas = clsGen.Obtener_XMLConfig("correo_facturacion_GT", False)

                Else

                    lsSQL = "pa_sel_um_sg_usuario_email '" & Me.lblusuariotraslada.Text & "'"
                    dt3 = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt3.Rows.Count > 0 Then
                        scuentas = dt3.Rows(0).Item("correo").ToString
                    End If
                End If


                If scuentas.ToString.Length > 0 Then scuentas += ","
                scuentas += gs_cuenta_usuario

                'Correo Auditoria
                lsSQL = "pa_sel_um_sg_usuario_email 'asaravia'"
                dt3 = clsGen.selectQuery("FlexLine", lsSQL)
                If dt3.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas += ","
                    scuentas += dt3.Rows(0).Item("correo").ToString
                End If

            Catch ex As Exception

            End Try









            sbBody.AppendLine("<table style:'width:100%; cellpadding:0px; cellspacing:0px;'>")

            sbBody.AppendLine("<tr style='background-color:#560000; color:white;'>")
            sbBody.AppendLine("<td>No.</td><td>estado</td><td>empresa</td><td>documento</td><td>cliente</td></tr>")
            iCount = 0

            pdt.DefaultView.Sort = "recibido"
            For Each drLinea As DataRowView In pdt.DefaultView
                iCount += 1

                sbBody.AppendLine("<tr>")
                sbBody.AppendLine("<td>" & iCount & "</td>")
                If drLinea.Item("recibido") = True Then
                    sbBody.AppendLine("<td>Recibido</td>")
                Else
                    sbBody.AppendLine("<td><strong>Rechazado</strong></td>")
                End If

                sbBody.AppendLine("<td>" & drLinea.Item("empresa").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("tipodocto").ToString & "-" & drLinea.Item("numero").ToString & "</td>")
                sbBody.AppendLine("<td>" & drLinea.Item("razonSocial").ToString & "</td>")
                sbBody.AppendLine("</tr>")
            Next



            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'></td></tr>")
            sbBody.AppendLine("<tr><td colspan='20'>** NO RESPONDA A ESTE CORREO **</td></tr>")







            clsGen.enviarcorreo_html(scuentas, sSubject, sbBody.ToString, "", "", sRemitente, snombreRemitente)



        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub frmRequisicionRecepcionCreditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarListado()
        'llenarLote(1)
    End Sub


    Private Sub dgvListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        MostrarLote(dgvListado.Item("Lote", e.RowIndex).Value)

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        calcular()

        If MessageBox.Show("Esta Seguro de Guardar Esta Recepcion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            grabarRecepcion()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenarListado()
    End Sub



    Private Sub cmbOrigen_SelectedValueChanged(sender As Object, e As EventArgs)
        Me.dgvListado.DataSource = Nothing
    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles txtBarraFactura.TextChanged

    End Sub

    Private Sub leerFacturaBarra()


        Dim lsEmpresa As String
        Dim lsNumero As String
        Dim lbEncontrado As Boolean = False

        Try
            If Me.txtBarraFactura.Text.Length > 10 Then


                If Me.txtBarraFactura.Text.Length = 12 Then Me.txtBarraFactura.Text = "0" & Me.txtBarraFactura.Text

                ods.Tables("empresa").DefaultView.RowFilter = "codigo = '" & Me.txtBarraFactura.Text.Substring(0, 2) & "'"

                lsEmpresa = ods.Tables("empresa").DefaultView(0).Item("empresa")

                Me.cmdEmpresa.SelectedItem = lsEmpresa


                lsNumero = ("00" & Me.txtBarraFactura.Text.Substring(4, 8)).PadLeft(10)
            Else
                lsEmpresa = Me.cmdEmpresa.SelectedValue
                Me.txtBarraFactura.Text = Me.txtBarraFactura.Text.PadLeft(10, "0")
                lsNumero = Me.txtBarraFactura.Text
            End If

            For Each dr As DataRow In ods.Tables("detalle").Rows
                If dr.Item("empresa") = lsEmpresa And
                    dr.Item("numero") = lsNumero Then

                    dr.Item("recibido") = True
                    lbEncontrado = True
                    Exit For
                End If
            Next

            If Not lbEncontrado Then
                MessageBox.Show("Documento No Pertenece al Lote", "Por Favor Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Me.txtBarraFactura.SelectAll()
            calcular()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub calcular()
        Me.lblRecibidos.Text = "0"
        Me.lblpendientes.Text = "0"
        Try

            Me.lblpendientes.Text = ods.Tables("detalle").Compute("sum(linea)", "recibido=false")
        Catch ex As Exception

        End Try

        Try
            Me.lblRecibidos.Text = ods.Tables("detalle").Compute("sum(linea)", "recibido=true")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarraFactura.KeyPress
        If e.KeyChar = Chr(13) Then
            leerFacturaBarra()


        End If
    End Sub

    Private Sub dgvDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick

    End Sub

    Private Sub dgvDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvDetalle.Rows(rowIndex)

                If Me.dgvDetalle.Item("recibido", rowIndex).Value = True Then

                    'If Me.dgv_encabezado.Item("ControlTemporal", rowIndex).Value.ToString.Length = 10 Then
                    ' Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green
                    ' ElseIf Me.dgv_encabezado.Item("dias", rowIndex).Value < 1 Then
                    'Me.dgv_encabezado.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                    'ElseIf Me.dgv_encabezado.Item("dias", rowIndex).Value < 3 Then
                    Me.dgvDetalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                    '  End If
                Else
                    Me.dgvDetalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBarraFactura_QueryAccessibilityHelp(sender As Object, e As QueryAccessibilityHelpEventArgs) Handles txtBarraFactura.QueryAccessibilityHelp

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If MessageBox.Show("Esta Seguro de Continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.TabControl1.SelectedTab = Me.TabPage2
        End If
    End Sub
End Class