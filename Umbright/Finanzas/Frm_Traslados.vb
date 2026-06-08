Public Class Frm_Traslados
    Dim Otrans As New Transaccional.Conexion("flexline")
    Dim dt As DataTable
    Dim dt2 As DataTable

    Private Sub Frm_Traslados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tipodocto()
        tipoface()


    End Sub





    Private Sub Exportar_reporte(tipodocto As String, numero As String, proveedor As String, empresa As String)
        Dim path_reporte As String
        Dim pm_valores(4) As String
        Dim pm_parametros(4) As String


        Dim nrow, npedido As Integer
        Dim pm_conexion(2) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            pm_conexion = ClsGen.Parametros_Conexion("vdataserver")


            path_reporte = ClsGen.Path_Reporte()

            path_reporte += "\Logistica\Bodega\Impresion de Compras.rpt"
            pm_parametros(0) = "@empresa"
            pm_valores(0) = empresa
            pm_parametros(1) = "@Tipodocto"
            pm_valores(1) = tipodocto
            pm_parametros(2) = "@Numero"
            pm_valores(2) = numero
            pm_parametros(3) = "@Proveedor"
            pm_valores(3) = proveedor

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                          False, False, "PDF", True, "", True, 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tipodocto()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim dt2 As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_tipodocto_traslados")

            Me.cmb_tipodocto.DataSource = dt
            Me.cmb_tipodocto.ValueMember = "tipoDocto"
            Me.cmb_tipodocto.DisplayMember = "tipoDocto"

            dt2 = Otrans.Obtiene("pa_sel_um_tipodocto_traslados")

            Me.cmb_tipo_compra.DataSource = dt2
            Me.cmb_tipo_compra.ValueMember = "tipo"
            Me.cmb_tipo_compra.DisplayMember = "tipo"



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try






    End Sub

    Private Sub tipoface()
        Dim Otrans As New Transaccional.Conexion("flexline")

        Dim dt2 As DataTable
        Try
            Otrans.open()


            dt2 = Otrans.Obtiene("PA_SEL_FACE_DE_COMPRAS")

            Me.cmb_tipo_compra.DataSource = dt2
            Me.cmb_tipo_compra.ValueMember = "descripcion"
            Me.cmb_tipo_compra.DisplayMember = "descripcion"



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try






    End Sub



    Private Sub limpiar()
        Me.cmb_tipodocto.Text = String.Empty
        Me.txt_numero.Text = String.Empty
        Me.txt_numero_final.Text = String.Empty
        Me.txt_anio.Text = String.Empty
        Me.txt_posiciones.Text = String.Empty
        Me.txt_cte.Text = String.Empty
        Me.txt_vendedor.Text = String.Empty
        Me.txt_empresa.Text = String.Empty
        Me.cmb_bodega.Text = ""
        Me.txt_proveedor.Text = String.Empty
        Me.txt_empresa_proveedor.Text = String.Empty
        Me.txtSerieFEL.Text = String.Empty
        Me.TxtNumeroFel.Text = String.Empty

    End Sub

    Private Sub BuscaFactura()



        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim dt2 As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_documento_traslado '" & gs_empresa & "' ,'" & Me.cmb_tipodocto.Text & "','" & Me.txt_numero.Text & "' ")
            dt2 = Otrans.Obtiene("pa_sel_um_proveedor_interempresa '" & gs_empresa & "' ,'" & Me.cmb_tipodocto.Text & "','" & Me.txt_numero.Text & "' ")
            If dt.Rows.Count > 0 Then

                Me.txt_vendedor.Text = dt.Rows(0)("vendedor").ToString
                Me.txt_cte.Text = dt.Rows(0)("Cliente").ToString
                Me.txt_empresa_proveedor.Text = dt.Rows(0)("empresa").ToString
                Me.txt_empresa.Text = dt.Rows(0)("descripcion").ToString

                'dt2 = Otrans.Obtiene("pa_sel_um_proveedor_interempresa '" & gs_empresa & "' ,'" & Me.cmb_tipodocto.Text & "','" & Me.txt_numero.Text & "' ")

                If Me.cmb_tipodocto.Text = "FEL" Then
                    Me.txtSerieFEL.Text = dt.Rows(0)("serieFEL").ToString
                    Me.TxtNumeroFel.Text = dt.Rows(0)("numeroFEL").ToString
                    '  dt2 = Otrans.Obtiene("pa_sel_um_proveedor_interempresa '" & gs_empresa & "' ,'" & Me.cmb_tipodocto.Text & "','" & Me.TxtNumeroFel.Text.PadLeft(12, "0") & "' ")
                End If

                If dt2.Rows.Count > 0 Then
                    Me.txt_proveedor.Text = dt2.Rows(0)("codigo").ToString
                End If



            Else
                    MessageBox.Show("Factura No Aplica Traslado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' limpiar()

            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub VerificarTraslado()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            Otrans.open()
            If Me.cmb_tipodocto.Text = "FEL" Then
                lsSQL = "pa_sel_um_FaceDe_Compras '" & Me.cmb_tipo_compra.Text & "', '" & Me.txt_empresa.Text & "' ,'" & Me.TxtNumeroFel.Text.PadLeft(12, "0") & "', '" & Me.txt_proveedor.Text & "' "
            Else
                lsSQL = "pa_sel_um_FaceDe_Compras '" & Me.cmb_tipo_compra.Text & "', '" & Me.txt_empresa.Text & "' ,'" & Me.txt_numero.Text & "', '" & Me.txt_proveedor.Text & "' "
            End If
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                Me.btn_traslado.Enabled = False
                If MessageBox.Show("Ya existe el traslado,¿Desea Imprimir el Documento?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    ''Exportar_reporte(Me.cmb_tipo_compra.Text, Me.txt_numero.Text.Trim, Me.txt_proveedor.Text.Trim, Me.txt_empresa.Text.Trim)
                    If Me.cmb_tipodocto.Text = "FEL" Then
                        Exportar_reporte(Me.cmb_tipo_compra.Text, Me.TxtNumeroFel.Text.PadLeft(12, "0"), Me.txt_proveedor.Text.Trim, Me.txt_empresa.Text.Trim)
                    Else
                        Exportar_reporte(Me.cmb_tipo_compra.Text, txt_numero.Text.Trim, Me.txt_proveedor.Text.Trim, Me.txt_empresa.Text.Trim)
                    End If
                Else
                        limpiar()
                    Me.btn_traslado.Enabled = True
                End If



            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub ValidaBodega()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_bodega_traslado '" & Me.txt_empresa.Text & "' ")

            If dt.Rows.Count > 0 Then
                Me.cmb_bodega.DataSource = dt
                Me.cmb_bodega.ValueMember = "codigo"
                Me.cmb_bodega.DisplayMember = "codigo"
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Numero()
        Try


            If cmb_tipodocto.Text <> "FACTURA SERIE A" And cmb_tipodocto.Text <> "FEL" Then


                Dim valor As String = txt_numero_final.Text.Substring(0, 2)
                txt_anio.Text = valor
                txt_posiciones.Text = txt_numero_final.Text.Substring(2)
                txt_numero.Text = valor + txt_posiciones.Text.PadLeft(10, "0")

            Else

                txt_numero.Text = txt_numero_final.Text.PadLeft(10, "0")

            End If
        Catch ex As Exception

        End Try

        'txt_num_fac2.Visible = True
        'txt_num_fac.Visible = False

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_bodega.SelectedIndexChanged

    End Sub

    Private Sub txt_numero_final_LostFocus(sender As Object, e As EventArgs) Handles txt_numero_final.LostFocus
        Numero()
        Me.txt_numero.Visible = True
        Me.txt_numero_final.Visible = False
        BuscaFactura()



        VerificarTraslado()

        ValidaBodega()
        Me.cmb_bodega.Focus()

    End Sub

    Private Sub txt_numero_final_TextChanged(sender As Object, e As EventArgs) Handles txt_numero_final.TextChanged

    End Sub

    Private Sub cmb_tipodocto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipodocto.SelectedIndexChanged
        txt_numero_final.Focus()

    End Sub






    Private Sub txt_cte_TextChanged(sender As Object, e As EventArgs) Handles txt_cte.TextChanged


    End Sub

    Private Sub txt_numero_LostFocus(sender As Object, e As EventArgs) Handles txt_numero.LostFocus

    End Sub

    Private Sub txt_numero_TextChanged(sender As Object, e As EventArgs) Handles txt_numero.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
        Me.txt_numero_final.Visible = True
        Me.txt_numero.Visible = False
        Me.btn_traslado.Enabled = True
    End Sub
    Private Sub traslado()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As String
        Dim lsql As String
        Try
            Otrans.open()

            lsql = "spa_Convierte_FactVtas_Compras '" & gs_empresa & "','" & Me.cmb_tipodocto.Text & "','" & Me.txt_numero.Text & "','" & Me.cmb_bodega.Text & "','" & gs_usuario & "' "
            Otrans.Ingresa(lsql)
            MessageBox.Show("Traslado Generado Satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub validar()
        If cmb_tipodocto.Text = "" Then
            MessageBox.Show("Debe Ingresar Tipo de Documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmb_tipodocto.Focus()

        ElseIf txt_numero_final.Text = "" Then
            MessageBox.Show("Debe Ingresar No. de Documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_numero.Focus()

        ElseIf cmb_bodega.Text = "" Then
            MessageBox.Show("Debe Ingresar Bodega", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmb_bodega.Focus()


        Else

            If MessageBox.Show("¿Desea Realizar el traslado?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                traslado()
                If Me.cmb_tipodocto.Text = "FEL" Then
                    Exportar_reporte(Me.cmb_tipo_compra.Text, "00" + txt_numero.Text.Trim, Me.txt_proveedor.Text.Trim, Me.txt_empresa.Text.Trim)
                Else
                    Exportar_reporte(Me.cmb_tipo_compra.Text, txt_numero.Text.Trim, Me.txt_proveedor.Text.Trim, Me.txt_empresa.Text.Trim)
                End If

            Else
                limpiar()
            End If

        End If
    End Sub
    Private Sub ProcesoTraslado()
      
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_traslado.Click

        validar()
      

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class