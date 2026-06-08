Public Class Frm_Cajas_Chicas_Detalle_M
    Public Empresa As String = ""
    Public Lote As String = ""
    Public Estado As String = ""
    Public Fecha As String = ""
    Public TipoDocto As String = ""
    Public Numero As String = ""
    Public Monto As String = ""
    Public Usuario As String = ""

    Dim _dtDetalle As DataTable
    ' Dim gs_empresa As String = "UMBRAL"

    Private Sub Frm_Cajas_Chicas_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Crea_Tabla()
        Llena_Detalle()
    End Sub

    Private Sub Crea_Tabla()
        Try
            _dtDetalle = New DataTable("Tmp_Detalle")

            _dtDetalle.Columns.Add(New DataColumn("Empresa", GetType(String)))
            _dtDetalle.Columns.Add(New DataColumn("Lote", GetType(String)))
            _dtDetalle.Columns.Add(New DataColumn("Estado", GetType(Integer)))
            _dtDetalle.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
            _dtDetalle.Columns.Add(New DataColumn("Fecha", GetType(Date)))
            _dtDetalle.Columns.Add(New DataColumn("Numero", GetType(String)))
            _dtDetalle.Columns.Add(New DataColumn("Proveedor", GetType(String)))
            _dtDetalle.Columns.Add(New DataColumn("Responsable", GetType(String)))
            _dtDetalle.Columns.Add(New DataColumn("Monto", GetType(Double)))
            _dtDetalle.Columns.Add(New DataColumn("Usuario", GetType(String)))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Llena_Detalle()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Cajas_Chicas_Detalle_M '" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            dgv_Detalle.DataSource = dt
            '_dtDetalle.Rows.Clear()
            'For Each dr As DataRow In dt.Rows
            '    dr2 = _dtDetalle.NewRow
            '    dr2.Item("Empresa") = dr.Item("Empresa")
            '    dr2.Item("Lote") = dr.Item("Lote")
            '    dr2.Item("TipoDocto") = dr.Item("TipoDocto")
            '    dr2.Item("Fecha") = dr.Item("Fecha")
            '    dr2.Item("Numero") = dr.Item("Numero")
            '    dr2.Item("Monto") = dr.Item("Monto")
            '    dr2.Item("Usuario") = dr.Item("Usuario")

            'Next

            'Me.dgv_Detalle.DataSource = _dtDetalle    'Despliega el resultado del procedimiento en un Grid
            'clsGen.Alinear_GridView(_dtDetalle, Me.dgv_Detalle, ",Lote,TipoDocto, Fecha,Numero,Monto,Usuario,", ",Empresa,", ",Lote,TipoDocto,Numero,Monto,Usuario,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub dgv_Detalle_DoubleClick(sender As Object, e As EventArgs) Handles dgv_Detalle.DoubleClick
        Dim nFila As Integer

        Try
            nFila = Me.dgv_Detalle.CurrentRow.Index

            If nFila > -1 Then

                Me.Lote = Me.dgv_Detalle.Item("Lote", nFila).Value
                Me.Estado = Me.dgv_Detalle.Item("Estado", nFila).Value
                Me.TipoDocto = Me.dgv_Detalle.Item("TipoDocto", nFila).Value
                Me.Fecha = Me.dgv_Detalle.Item("Fecha", nFila).Value
                Me.Numero = Me.dgv_Detalle.Item("Numero", nFila).Value
                Me.Monto = Me.dgv_Detalle.Item("Monto", nFila).Value
                Me.Usuario = Me.dgv_Detalle.Item("Usuario", nFila).Value
            Else
                MsgBox("No Existen Lotes Para Seleccionar", MsgBoxStyle.Information, "Verifique")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Lote = ""
            Estado = ""
            Fecha = ""
            TipoDocto = ""
            Numero = ""
            Monto = ""
            Usuario = ""

        End Try

        Me.Close()
    End Sub

    Private Sub txtLote_TextChanged(sender As Object, e As EventArgs) Handles txtLote.TextChanged
        buscar
    End Sub
    Private Sub Buscar()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim sql As String

        otrans.open()
        Try
            sql = "pa_sel_um_busca_caja_chica_m'" & gs_empresa & "','" & txtLote.Text & "'"
            dt = otrans.Obtiene(sql)

            Me.dgv_Detalle.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

End Class