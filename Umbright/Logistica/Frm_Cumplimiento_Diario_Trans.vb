Public Class Frm_Cumplimiento_Diario_Trans
    Dim dtGuias As DataTable
    Dim ods As DataSet

    Private Sub CreaTabla()
        ods = New DataSet
        dtGuias = New DataTable("dt_Guias")

        dtGuias.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("Guia", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("Documento", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("Numero", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("Transporte", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("Piloto", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("CtaCte", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("Entregado", GetType(Integer)))
        dtGuias.Columns.Add(New DataColumn("Motivo", GetType(String)))
        dtGuias.Columns.Add(New DataColumn("Comentario", GetType(String)))

        Me.dgv_Detalle.DataSource = ods.Tables("dt_Guias")
        'dtGuias.PrimaryKey = New DataColumn() {_dtPagosElectronicos.Columns(0), _dtPagosElectronicos.Columns(4), _dtPagosElectronicos.Columns(6), _dtPagosElectronicos.Columns(7)}
    End Sub

    Private Sub btn_Consultar_Click(sender As Object, e As EventArgs) Handles btn_Consultar.Click
        Busca_Guia()
    End Sub

    Private Sub Guia()
        Dim tamaño As Integer
        Dim tamañot As Integer

        tamaño = (10 - Len(tb_Guia.Text)) + Len(tb_Guia.Text)
        tb_Guia.Text = "0000000000" + tb_Guia.Text
        tamañot = Len(tb_Guia.Text)
        tb_Guia.Text = Mid(tb_Guia.Text, tamañot - tamaño + 1)
        Busca_Guia()

    End Sub

    Private Sub tb_Guia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Guia.KeyPress
        If e.KeyChar = Chr(13) Then
            Guia()
            Busca_Guia()
        End If
    End Sub

    Private Sub Busca_Guia()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr2 As DataRow
        Dim ls_sql As String
        Dim Entregado As Boolean = False

        Try
            Otrans.open()

            ls_sql = "pa_vb_Cumplimiento_Diario '" & tb_Guia.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            'Me.dgv_Detalle.DataSource = dt
            dtGuias.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = dtGuias.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Guia") = dr.Item("Guia")
                dr2.Item("Documento") = dr.Item("Documento")
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("Transporte") = dr.Item("Transporte")
                dr2.Item("Piloto") = dr.Item("Piloto")
                dr2.Item("CtaCte") = dr.Item("CtaCte")
                dr2.Item("RazonSocial") = dr.Item("RazonSocial")
                dr2.Item("Entregado") = dr.Item("Entregado")
                dr2.Item("Motivo") = dr.Item("Motivo")
                dr2.Item("Comentario") = dr.Item("Comentario")
                dtGuias.Rows.Add(dr2)
            Next

            Me.dgv_Detalle.DataSource = dtGuias    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(dtGuias, Me.dgv_Detalle, "", "", ",Empresa,Guia,Documento,Numero,Transporte,Piloto,CtaCte,RazonSocial,", "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
            MsgBox("Error al Buscar, No Existe Guia")
            Limpiar()
        End Try

    End Sub

    Private Sub Frm_Cumplimiento_Diario_Trans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
    End Sub

    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try

            Otrans.open()   'abre conexion
            dt = Me.dgv_Detalle.DataSource

            For Each drv As DataRowView In dt.DefaultView

                ls_sql = "pa_vb_Cumplimiento_Diario_Actualiza '" & drv.Item("Empresa") & "','" & drv.Item("Guia") & "','" & drv.Item("Documento") & "','" & drv.Item("Numero") & "','" & drv.Item("Entregado") & "','" & drv.Item("Motivo") & "','" & drv.Item("Comentario") & "'"
                Otrans.Actualiza(ls_sql)

            Next
            dt.DefaultView.RowFilter = ""
            MessageBox.Show("Actualización Satisfactoria !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Limpiar()
        Catch ex As Exception
            MsgBox("Problemas al Actualizar", MsgBoxStyle.Critical, "Actualizar")
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub Limpiar()
        Me.dgv_Detalle.DataSource = ""
        tb_Guia.Text = ""
        tb_Guia.Focus()
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpiar()
    End Sub
End Class

