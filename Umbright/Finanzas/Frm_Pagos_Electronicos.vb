
Imports System.Data.SqlClient

Public Class Frm_Pagos_Electronicos
    Dim _dtPagosElectronicos As DataTable
    Dim _dtPagosElectronicos2 As DataTable
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "ROOT"


    Private Sub Frm_Pagos_Electronicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ToolStripStatusLabel1.Text = gs_empresa
        ToolStripStatusLabel2.Text = gs_usuario

        Me.dtp_Fech_Inicial.Value = Today
        Me.dtp_Fecha_Final.Value = Today

        CreaTabla()
    End Sub
    Private Sub CreaTabla()

        _dtPagosElectronicos = New DataTable("Tmp_PagosElectronicos")

        _dtPagosElectronicos.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("TipoComprobante", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("NroComprobante", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Documento", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("FechaVcto", GetType(Date)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Monto", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Monto2", GetType(Double)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Banco", GetType(String)))
        _dtPagosElectronicos.Columns.Add(New DataColumn("Seleccion", GetType(Boolean)))
        _dtPagosElectronicos.PrimaryKey = New DataColumn() {_dtPagosElectronicos.Columns(0), _dtPagosElectronicos.Columns(4), _dtPagosElectronicos.Columns(6), _dtPagosElectronicos.Columns(7)}

        '   dgv_Seleccion.DataSource = _dtPagosElectronicos
        dgv_Seleccionar.DataSource = _dtPagosElectronicos



        _dtPagosElectronicos2 = New DataTable("Tmp_PagosElectronicos2")

        _dtPagosElectronicos2.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("TipoComprobante", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("NroComprobante", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Documento", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("FechaVcto", GetType(Date)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Monto", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Monto2", GetType(Double)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Banco", GetType(String)))
        _dtPagosElectronicos2.Columns.Add(New DataColumn("Seleccion", GetType(Boolean)))
        '        _dtPagosElectronicos2.PrimaryKey = New DataColumn() {_dtPagosElectronicos2.Columns(0), _dtPagosElectronicos2.Columns(4), _dtPagosElectronicos2.Columns(6), _dtPagosElectronicos2.Columns(7)}

        dgv_Seleccion.DataSource = _dtPagosElectronicos2


    End Sub
    Private Sub SeleccionaObligaciones()

        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_um_PagosElectronicos '" & gs_empresa & "','" & Me.dtp_Fech_Inicial.Value & "','" & Me.dtp_Fecha_Final.Value & "','" & txt_proveedor.Text & "'" 'Me.tb_FechaFinal.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtPagosElectronicos.Rows.Clear()
            For Each dr As DataRow In dt.Rows

                dr2 = _dtPagosElectronicos.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Fecha") = dr.Item("Fecha")
                dr2.Item("TipoComprobante") = dr.Item("TipoComprobante")
                dr2.Item("NroComprobante") = dr.Item("NroComprobante")
                dr2.Item("Proveedor") = dr.Item("Proveedor")
                dr2.Item("RazonSocial") = dr.Item("RazonSocial")
                dr2.Item("Documento") = dr.Item("Documento")
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("FechaVcto") = dr.Item("FechaVcto")
                dr2.Item("Monto") = dr.Item("Monto")
                dr2.Item("Monto2") = dr.Item("Monto")
                dr2.Item("Banco") = dr.Item("Banco")
                dr2.Item("Seleccion") = 0

                _dtPagosElectronicos.Rows.Add(dr2)

            Next

            Me.dgv_Seleccionar.DataSource = _dtPagosElectronicos    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtPagosElectronicos, Me.dgv_Seleccionar, "", ",Empresa,Monto2,", ",Fecha,TipoComprobante,NroComprobante,Proveedor,RazonSocial,Documento,Numero,FechaVcto,Monto,Banco,", "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub b_Genera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_Genera.Click
        SeleccionaObligaciones()
    End Sub
    Private Sub AsignaPagosBi()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        If MessageBox.Show("¿Se Procesará Un Lote Para BI?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Try

            Otrans.open()   'abre conexion
            dt = Me.dgv_Seleccion.DataSource

            For Each drv As DataRowView In dt.DefaultView
                If drv.Item("Seleccion") = True Then
                    ls_sql = "exec spa_um_PagosBi '" & drv.Item("Empresa") & "','" & drv.Item("Proveedor") & "','" & drv.Item("Documento") & "','" & drv.Item("Numero") & "','" & gs_usuario & "'"
                    Otrans.Actualiza(ls_sql)

                Else
                End If
            Next
            dt.DefaultView.RowFilter = ""
            'MessageBox.Show("Se Presentará Una Pantalla de Verificación !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
            AbrePagosBi()
        End Try
    End Sub
    Private Sub AsignaPagosOtros()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        If MessageBox.Show("¿Se procerá un Lote para ACH?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Try
            Otrans.open()   'abre conexion
            dt = Me.dgv_Seleccion.DataSource
            For Each drv As DataRowView In dt.DefaultView
                If drv.Item("Seleccion") = True Then
                    ls_sql = "exec spa_um_PagosOtros '" & drv.Item("Empresa") & "','" & drv.Item("Proveedor") & "','" & drv.Item("Documento") & "','" & drv.Item("Numero") & "','" & gs_usuario & "'"
                    Otrans.Actualiza(ls_sql)

                Else
                End If
            Next
            dt.DefaultView.RowFilter = ""
            'MessageBox.Show("Se Presentará Una Pantalla de Verificación !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
            AbrePagoAch()
        End Try

    End Sub

    Private Sub b_PagosBi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_PagosBi.Click
        AsignaPagosBi()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AsignaPagosOtros()
    End Sub

    Private Sub Limpia()

        lb_Sumatoria.Text = "0.00"
        Me.dgv_Seleccion.DataSource = ""
        Me.dgv_Seleccionar.DataSource = ""

        _dtPagosElectronicos.Rows.Clear()


    End Sub
    Private Sub AbrePagosBi()
        Dim oform As New Frm_PagosBI

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
        Me.dgv_Seleccion.DataSource = ""

    End Sub
    Private Sub AbrePagoAch()
        Dim oform2 As New Frm_PagosOtros

        oform2.ShowDialog()
        oform2.Dispose()
        oform2 = Nothing
        Me.dgv_Seleccion.DataSource = ""

    End Sub
    Private Sub Informe()

        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Jefatura\Informe de Pago a Proveedores Locales.rpt"
            pm_parametros(0) = "empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "Lote"
            pm_valores(1) = tb_Lote.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                    False, False, "PDF", True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub b_Informe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_Informe.Click
        Informe()
    End Sub

    Private Sub dgv_Seleccionar_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_Seleccionar.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_Seleccionar.Rows(rowIndex)

                '  If dgv_Seleccion.Columns(colIndex).Name.ToLower.StartsWith("sugerido") Then
                'If Me.dgv_Seleccion.Item(colIndex, rowIndex).Value.ToString > 0 Then
                'Me.dgv_Seleccion.Item(colIndex, rowIndex).Style.BackColor = Color.LightSalmon
                'End If
                'End If
                '   If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("agregar") > -1 Then
                If Me.dgv_Seleccionar.Item("TipoComprobante", rowIndex).Value = "ANTICIPOS POR LIQUIDAR" Then
                    Me.dgv_Seleccionar.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red

                ElseIf Me.dgv_Seleccionar.Item("Seleccion", rowIndex).Value = True Then
                    Me.dgv_Seleccionar.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                    '   sumardatos()
                Else
                    Me.dgv_Seleccionar.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If

                'End If
                'If dgv_Seleccion.Columns(colIndex).Name.ToLower.IndexOf("transi") > -1 Then
                'If Me.dgv_Seleccion.Item(colIndex, rowIndex).Value.ToString > 0 Then
                'Me.dgv_Seleccion.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                'End If
                'End If

            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub sumardatos()
        Dim ntotal As Double
        Dim dt As DataTable

        Try
            dt = Me.dgv_Seleccion.DataSource

            ntotal = dt.Compute("sum(Monto2)", "Seleccion=true")
            Me.lb_Sumatoria.Text = Format(ntotal, "###,###,##0.00")

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub tb_Busca_Proveedor_TextChanged(sender As Object, e As EventArgs) Handles tb_Busca_Proveedor.TextChanged
        If tb_Busca_Proveedor.Text.Trim.Length >= 2 Then
            ObtenerFacturasPorProveedor()
        End If

    End Sub

    Private Sub ObtenerFacturasPorProveedor()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim sql As String
        Dim clsGen As New ClasesGenerales.General
        Dim dr2 As DataRow

        Otrans.open()

        Try
            sql = "EXEC pa_um_PagosElectronicos_numero '" & gs_empresa & "','" & dtp_Fech_Inicial.Value & "','" & dtp_Fecha_Final.Value & "','" & Me.tb_Busca_Proveedor.Text.Trim & "'"
            dt = Otrans.Obtiene(sql)
            Me.dgv_Seleccionar.DataSource = dt

            _dtPagosElectronicos.Rows.Clear()
            For Each dr As DataRow In dt.Rows

                dr2 = _dtPagosElectronicos.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Fecha") = dr.Item("Fecha")
                dr2.Item("TipoComprobante") = dr.Item("TipoComprobante")
                dr2.Item("NroComprobante") = dr.Item("NroComprobante")
                dr2.Item("Proveedor") = dr.Item("Proveedor")
                dr2.Item("RazonSocial") = dr.Item("RazonSocial")
                dr2.Item("Documento") = dr.Item("Documento")
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("FechaVcto") = dr.Item("FechaVcto")
                dr2.Item("Monto") = dr.Item("Monto")
                dr2.Item("Monto2") = dr.Item("Monto")
                dr2.Item("Banco") = dr.Item("Banco")
                dr2.Item("Seleccion") = 0

                _dtPagosElectronicos.Rows.Add(dr2)

            Next

            Me.dgv_Seleccionar.DataSource = _dtPagosElectronicos    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtPagosElectronicos, Me.dgv_Seleccionar, "", ",Empresa,Monto2,", ",Fecha,TipoComprobante,NroComprobante,Proveedor,RazonSocial,Documento,Numero,FechaVcto,Monto,Banco,", "", "", "", "", True, True, 200, 0)

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub


    Private Sub btn_EliminaLote_Click(sender As Object, e As EventArgs) Handles btn_EliminaLote.Click
        If MessageBox.Show("Desea Eliminar Lote?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        elimina_lote()

    End Sub

    Private Sub elimina_lote()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String


        Try

            Otrans.open()   'abre conexion

            ls_sql = "exec pa_del_um_elimina_lote_pago '" & gs_empresa & "','" & tb_Lote.Text & "'"
            Otrans.Actualiza(ls_sql)


            MessageBox.Show("Lote Eliminado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub btnAgrega_Click(sender As Object, e As EventArgs) Handles btnAgrega.Click
        Try
            '        Recorrer las filas del primer DataGridView
            For Each fila As DataGridViewRow In dgv_Seleccionar.Rows

                ' Evitar copiar la fila nueva (la vacía al final) 
                If Not fila.IsNewRow Then

                    If Convert.ToBoolean(fila.Cells("seleccion").Value) = True Then
                        Dim nuevaFila As DataRow = _dtPagosElectronicos2.NewRow()

                        For i As Integer = 0 To _dtPagosElectronicos2.Columns.Count - 1
                            nuevaFila(i) = fila.Cells(i).Value
                        Next
                        _dtPagosElectronicos2.Rows.Add(nuevaFila)
                    End If
                End If
                sumardatos()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub btnQuita_Click(sender As Object, e As EventArgs) Handles btnQuita.Click
        MessageBox.Show("Si Necesita Quitar una Factura Solo DesAsignela Por Favor !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub dgv_Seleccion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Seleccion.CellClick
        sumardatos()
    End Sub
End Class