Public Class frm_impresoras1
    Dim ods As New DataSet
    Dim oDataSet As New DataSet

    Private Sub frm_impresoras1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        estructura()
        impresoras_disponibles()

    End Sub


    Private Sub estructura()
        Dim dt As DataTable
        ods = New DataSet
        dt = New DataTable("Encabezado")
        dt.Columns.Add(New DataColumn("IMPRESORAS_DISPONIBLES", GetType(String)))
        ods.Tables.Add(dt)
        Me.dgv_impresoras_disponibles.DataSource = ods.Tables("Encabezado")
        Dim cls2 As New ClasesGenerales.General
        cls2.Alinear_GridView(ods.Tables("Encabezado"), Me.dgv_impresoras_disponibles, "", "", "", "", True, True, 250, 0)

    End Sub

    Private Sub impresoras_disponibles()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt As DataTable
        oTrans = New Transaccional.Conexion("flexline")


        Dim ls_sqltxt As String
        oDataSet = New DataSet


        ls_sqltxt = "Pa_sel_um_impresoras_disponibles "
        Try
            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "Encabezado"
            dgv_impresoras_disponibles.DataSource = oTabla
            'oDataSet.Tables.Add(oTabla.Copy)




        Catch ex As Exception

        End Try
    End Sub


    Private Sub ActualizarImpresora()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String = String.Empty

        Try
            Otrans.open()
            ls_sql = "pa_upd_mov_impresoras '" & Me.cmb_empresa.Text & "','" & Me.cmb_tipoDocto.Text & "','" & Me.cmb_impresoras.Text & "','" & Me.txt_impresora_actual.Text & "'"
            Otrans.Actualiza(ls_sql)

            If Otrans.Codigo_error = 0 Then
                MessageBox.Show("Informacion Actualizada Con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(Otrans.descripcion_error)
            End If
        Catch ex As Exception

        End Try




    End Sub
    Private Sub ImpresoraActual()



        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_impresora '" & Me.cmb_empresa.Text & "', '" & Me.cmb_tipoDocto.Text & "'"
            dt = Otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                Me.txt_impresora_actual.Text = dt.Rows(0)("texto").ToString

            End If



        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub
    Private Sub tipodocumento()
        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim dt As DataTable
        Try

            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_tipodocto_gen_impresion'" & Me.cmb_empresa.Text & "'")

            Me.cmb_tipoDocto.DataSource = dt
            Me.cmb_tipoDocto.ValueMember = "NEMOTECNICO"
            Me.cmb_tipoDocto.DisplayMember = "NEMOTECNICO"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Private Sub Impresoras()

        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim dt1 As DataTable

        Try

            Otrans.open()
            dt1 = Otrans.Obtiene("pa_sel_um_gen_impresoras")
            Me.cmb_impresoras.DataSource = dt1
            Me.cmb_impresoras.ValueMember = "texto3"
            Me.cmb_impresoras.DisplayMember = "texto3"
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub cmb_tipoDocto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipoDocto.SelectedIndexChanged
        ImpresoraActual()
    End Sub



    Private Sub cmb_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresa.SelectedIndexChanged



        tipodocumento()
        Impresoras()
    End Sub

    Private Sub empresa_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub empresa_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmb_empresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_empresa.SelectedValueChanged
     

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_aplicar_Click(sender As Object, e As EventArgs) Handles btn_aplicar.Click
        ActualizarImpresora()
    End Sub

End Class