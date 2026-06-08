Public Class frmAnularDocumentosFEL
    Private Sub frmAnularDocumentosFEL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos
    End Sub

    Private Sub llenarCombos()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            lsSQL = "pa_sel_um_tipodocumentoseg_umbright '" & gs_empresa & "','" & gs_usuario & "','A'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)

            Me.cmbTipoDocumento.DataSource = dt
            Me.cmbTipoDocumento.DisplayMember = "TipoDocto"
            Me.cmbTipoDocumento.ValueMember = "TipoDocto"



        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try



    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General


        Try
            Me.lblhoraconsulta.Text = "15"
            Me.Timer1.Interval = 1000
            Me.Timer1.Start()


            lsSQL = "pa_var_um_documento '" & gs_empresa & "','" & Me.cmbTipoDocumento.SelectedValue & "','" & Me.txtNumero.Text & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)

            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    Me.txtCtaCte.Text = .Item("idctacte")
                    Me.txtRazonSocial.Text = .Item("razonsocial")
                    Me.txtGlosa.Text = .Item("glosa")
                    Me.txtComentario.Text = .Item("comentario1")
                    Me.txtFecha.Text = .Item("fecha")
                    Me.txtPeriodo.Text = .Item("periodolibro")
                    Me.txtVigente.Text = .Item("vigencia")
                    Me.txtAprobacion.Text = .Item("Aprobacion")
                    Me.txtTipoComprobante.Text = .Item("tipocomprobante")
                    Me.txtNumeroComprobante.Text = .Item("Nrocomprobante")
                    Me.txtCantidadAsgnada.Text = .Item("PorcentajeAsignado")
                    Me.txtFactorMonto.Text = .Item("factormonto")



                End With
            End If


            lsSQL = "pa_sel_um_documento_detalle '" & Me.cmbTipoDocumento.SelectedValue & "','" & gs_empresa & "','" & Me.txtNumero.Text & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            Me.dgvProductos.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvProductos, ",producto,glosa,secuencia,cantidad,lote,fechavcto,", "", "", "", "", "", ",producto,glosa,secuencia,cantidad,lote,fechavcto,", True, True, 250, 0)


            'Picking
            lsSQL = "pa_var_um_impresion_picking '" & gs_empresa & "','" &
                    Me.cmbTipoDocumento.SelectedValue & "','" &
                    Me.txtNumero.Text & "'"

            dt = clsGen.selectQuery("FlexLine", lsSQL)
            Me.dgvPicking.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvPicking, ",tipo_documento,numero,fecha_impresion,nombre_picker", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        'Reglas
        '1 No se puede si, es de un periodo cerrado
        '2 no se puede si esta centralizada
        '3 no se puede si tiene documentos posteriores
        '4 no se puede si no se encuentra el documento en infile




        Dim clsGen As New ClasesGenerales.General

        Try
            If MessageBox.Show("Esta Seguro de Anular este documento", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If Me.txtNumeroComprobante.Text.Length > 0 Then
                    MessageBox.Show("No se puede anular el documento, esta centralizado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.txtVigente.Text.ToUpper.Equals("A") Then
                    MessageBox.Show("No se puede anular el documento, el documento ya esta anulado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else




                End If


            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim nval As Double = Double.Parse(Me.lblhoraconsulta.Text)
        nval = nval - 1
        Me.lblhoraconsulta.Text = nval
    End Sub
End Class