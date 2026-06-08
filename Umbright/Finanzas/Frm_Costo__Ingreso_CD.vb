Public Class Frm_Costo__Ingreso_CD

    Inherits System.Windows.Forms.Form
    Dim oTransaccion As Transaccional.Conexion
    Dim ls_SqlScript As String
    Dim ls_SqlScript2 As String
    Dim _dtProductos As DataTable
    Dim pds_Dataset As New DataSet
    Dim pdataset As New DataSet
    'Dim gs_empresa As String = "DMARTE1"
    Dim dtRecibos As DataTable

    Private Sub Frm_Costo__Ingreso_CD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        ComboBox()
    End Sub
    Private Sub CreaTabla()

        _dtProductos = New DataTable("Tmp_Productos")

        _dtProductos.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Fecha", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Producto", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
        _dtProductos.Columns.Add(New DataColumn("Precio", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Costo", GetType(Double)))
        _dtProductos.Columns.Add(New DataColumn("Cup", GetType(Double)))
        _dtProductos.Columns.Add(New DataColumn("PrecioAjustado", GetType(Double)))
        _dtProductos.Columns.Add(New DataColumn("Linea", GetType(Integer)))

    End Sub

    Private Sub ComboBox()
        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet

        oTransaccion = New Transaccional.Conexion("FLEXLINE")
        oTransaccion.open()

        ls_SqlScript = "spa_Docto_IngresoCD '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "TpDocto"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_TipoDocto.DisplayMember = "TipoDocto"
        Me.cb_TipoDocto.ValueMember = "TipoDocto"
        Me.cb_TipoDocto.DataSource = ldt_table


    End Sub


    Private Sub btn_Ejecutar_Click(sender As Object, e As EventArgs) Handles btn_Ejecutar.Click
        Ejecuta()
    End Sub


    Private Sub Ejecuta()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_detalle_IngresoCD '" & gs_empresa & "','" & Me.cb_TipoDocto.Text & "','" & Me.tb_Numero.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos


            _dtProductos.Rows.Clear()
            For Each dr As DataRow In dt.Rows

                Label4.Text = dr.Item("Fecha")

                dr2 = _dtProductos.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("TipoDocto") = dr.Item("TipoDocto")
                dr2.Item("Fecha") = dr.Item("Fecha")
                dr2.Item("Producto") = dr.Item("Producto")
                dr2.Item("Descripcion") = dr.Item("Descripcion")
                dr2.Item("Cantidad") = dr.Item("Cantidad")
                dr2.Item("Precio") = dr.Item("Precio")
                dr2.Item("Costo") = dr.Item("Costo")
                dr2.Item("Cup") = dr.Item("Cup")
                dr2.Item("PrecioAjustado") = dr.Item("PrecioAjustado")
                dr2.Item("Linea") = dr.Item("Linea")

                _dtProductos.Rows.Add(dr2)

            Next

            Me.dgv_Detalle.DataSource = _dtProductos    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtProductos, Me.dgv_Detalle, ",Producto,Descripcion,Cantidad,Costo,", ",Empresa,TipoDocto,Fecha,Cup,PrecioAjustado,Linea,", ",Producto,Descripcion,Cantidad,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub Actualiza()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable


        If tb_Numero.Text = "" Then
            MsgBox("No hay Información, Verifique")
            Exit Sub
        End If
        If MessageBox.Show("¿Esta Accion Actualizara los Costos?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Try
            Otrans.open()   'abre conexion

            dt = Me.dgv_Detalle.DataSource

            For Each drv As DataRowView In dt.DefaultView

                ls_sql = "spa_Actualiza_IngresoCD '" & drv.Item("Empresa") & "','" & drv.Item("TipoDocto") & "','" & tb_Numero.Text & "','" & drv.Item("Producto") & "'," & drv.Item("Costo") & "," & drv.Item("Linea")
                Otrans.Actualiza(ls_sql)

            Next
            dt.DefaultView.RowFilter = ""

            MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        Actualiza()
        Reporte()
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Me.dgv_Detalle.DataSource = ""
        _dtProductos.Rows.Clear()
        Label4.Text = "01/01/1900"
        Me.tb_Numero.Text = ""
        Me.tb_Numero.Focus()
    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Nuevo()
    End Sub


    Private Sub Reporte()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(0), pm_valores_consolidado(2) As String
        Dim pm_parametros(0) As String
        Dim pm_conexion(0) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt


        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataserver")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\"
            path_reporte = path_reporte & gs_empresa
            'Dmarte1()
            path_reporte = path_reporte & "\Prorrateos al Centro Distribucion.rpt"

            pm_parametros(0) = "Numero"
            pm_valores(0) = tb_Numero.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub btn_Imprimir_Click(sender As Object, e As EventArgs) Handles btn_Imprimir.Click
        Reporte()
    End Sub

    Private Sub btn_Dai_Click(sender As Object, e As EventArgs) Handles btn_Dai.Click
        Dim frm_LlamaDai As New Frm_Cambio_Dai
        frm_LlamaDai.ShowDialog()
    End Sub

    Private Sub dgv_Detalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Detalle.CellContentClick

    End Sub

    Private Sub dgv_Detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv_Detalle.DataError
        MessageBox.Show("Ingresó un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
End Class