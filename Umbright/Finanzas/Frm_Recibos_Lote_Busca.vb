Public Class Frm_Recibos_Lote_Busca
    Public Empresa As String = ""
    Public Lote As String = ""
    Public Fecha As String = ""
    Public Recibo As String = ""
    Public TipoDocto As String = ""
    Public FechaDoc As String = ""
    Public Numero As String = ""
    Public Cliente As String = ""
    Public RazonSocial As String = ""
    Public MontoOrigen As String = ""
    Public TipoCobro As String = ""
    Public Monto As String = ""
    Public Banco As String = ""
    Public NumeroDocto As String = ""
    Public Estado As String = ""
    Dim _dtDetalle As DataTable
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "ROOT"

    Private Sub Frm_Recibos_Lote_Busca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Crea_Tabla()
        Llena_Detalle()
    End Sub


    Private Sub Crea_Tabla()
        _dtDetalle = New DataTable("Tmp_Detalle")

        _dtDetalle.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Lote", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtDetalle.Columns.Add(New DataColumn("Recibo", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("FechaDoc", GetType(Date)))
        _dtDetalle.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Cliente", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("MontoOrigen", GetType(Double)))
        _dtDetalle.Columns.Add(New DataColumn("TipoCobro", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Monto", GetType(Double)))
        _dtDetalle.Columns.Add(New DataColumn("Banco", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("NumeroDocto", GetType(String)))
        _dtDetalle.Columns.Add(New DataColumn("Estado", GetType(String)))

    End Sub

    Private Sub Llena_Detalle()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Detalle '" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtDetalle.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtDetalle.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Lote") = dr.Item("Lote")
                dr2.Item("Fecha") = dr.Item("Fecha")
                dr2.Item("Recibo") = dr.Item("Recibo")
                dr2.Item("TipoDocto") = dr.Item("TipoDocto")
                dr2.Item("FechaDoc") = dr.Item("FechaDoc")
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("Cliente") = dr.Item("Cliente")
                dr2.Item("RazonSocial") = dr.Item("RazonSocial")
                dr2.Item("MontoOrigen") = dr.Item("MontoOrigen")
                dr2.Item("TipoCobro") = dr.Item("TipoCobro")
                dr2.Item("Monto") = dr.Item("Monto")
                dr2.Item("Banco") = dr.Item("Banco")
                dr2.Item("NumeroDocto") = dr.Item("NumeroDocto")
                dr2.Item("Estado") = dr.Item("Estado")
                _dtDetalle.Rows.Add(dr2)

            Next

            Me.dgv_Lotes.DataSource = _dtDetalle    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtDetalle, Me.dgv_Lotes, ",Lote,Fecha,Recibo,TipoDocto,Numero,Cliente,RazonSocial,TipoCobro,Monto,", ",Empresa,FechaDocto,Estado,MontoOrigen,Banco,NumeroDocto,", ",Lote,Fecha,Recibo,TipoDocto,Numero,Cliente,RazonSocial,TipoCobro,Monto,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_Lotes_DoubleClick(sender As Object, e As EventArgs) Handles dgv_Lotes.DoubleClick
        Dim nFila As Integer

        Try
            nFila = Me.dgv_Lotes.CurrentRow.Index

            If nFila >= 0 Then

                Me.Lote = Me.dgv_Lotes.Item("Lote", nFila).Value
                Me.Fecha = Me.dgv_Lotes.Item("Fecha", nFila).Value
                Me.Recibo = Me.dgv_Lotes.Item("Recibo", nFila).Value
                Me.TipoDocto = Me.dgv_Lotes.Item("TipoDocto", nFila).Value
                Me.FechaDoc = Me.dgv_Lotes.Item("FechaDoc", nFila).Value
                Me.Numero = Me.dgv_Lotes.Item("Numero", nFila).Value
                Me.Cliente = Me.dgv_Lotes.Item("Cliente", nFila).Value
                Me.RazonSocial = Me.dgv_Lotes.Item("RazonSocial", nFila).Value
                Me.MontoOrigen = Me.dgv_Lotes.Item("MontoOrigen", nFila).Value
                Me.TipoCobro = Me.dgv_Lotes.Item("TipoCobro", nFila).Value
                Me.Monto = Me.dgv_Lotes.Item("Monto", nFila).Value
                Me.Banco = Me.dgv_Lotes.Item("Banco", nFila).Value
                Me.NumeroDocto = Me.dgv_Lotes.Item("NumeroDocto", nFila).Value
                Me.Estado = Me.dgv_Lotes.Item("Estado", nFila).Value
            Else
                MsgBox("No Existen Lotes Para Seleccionar", MsgBoxStyle.Information, "Verifique")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Lote = ""
            Fecha = ""
            Recibo = ""
            TipoDocto = ""
            FechaDoc = ""
            Numero = ""
            Cliente = ""
            RazonSocial = ""
            MontoOrigen = ""
            TipoCobro = ""
            Monto = ""
            Banco = ""
            NumeroDocto = ""
            Estado = ""



        End Try



        Me.Close()
    End Sub

End Class