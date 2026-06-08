Public Class Frm_Facturas_Analisis
    Dim ods As DataSet
    Dim dta As DataTable
    'Dim gs_usuario As String = "admin"
    'Dim gs_empresa As String = "DMARTE1"

    Private Sub Frm_Facturas_Analisis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_Grabar.Enabled = False
        crea_estructura()
        Combo()
    End Sub

    Private Sub crea_estructura()
        ods = New DataSet
        dta = New DataTable("Facts")

        dta.Columns.Add(New DataColumn("Numero", GetType(String)))
        dta.Columns.Add(New DataColumn("Linea", GetType(Integer)))
        dta.Columns.Add(New DataColumn("Producto", GetType(String)))
        dta.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dta.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
        dta.Columns.Add(New DataColumn("CCosto", GetType(String)))
        dta.Columns.Add(New DataColumn("Ap", GetType(String)))
        dta.Columns.Add(New DataColumn("Marca", GetType(String)))
        dta.Columns.Add(New DataColumn("Rubro", GetType(String)))

        dta.PrimaryKey = New DataColumn() {dta.Columns(0), dta.Columns(1), dta.Columns(2), dta.Columns(3)}
        ods.Tables.Add(dta)
        Me.dgv_Detalle.DataSource = ods.Tables("Facts")

    End Sub

    Private Sub Combo()
        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet
        Dim ls_SqlScript As String
        Dim clsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("FLEXLINE")

        Try
            otrans.open()
            ls_SqlScript = "pa_vb_Factura_Tipo '" & gs_empresa & "'"

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "Doctos"
            Me.cb_Tipo.DisplayMember = "TipoDocto"
            Me.cb_Tipo.ValueMember = "TipoDocto"
            Me.cb_Tipo.DataSource = ldt_table.DefaultView

        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub tb_Numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Numero.KeyPress
        If e.KeyChar = Chr(13) Then

            If tb_Numero.Text.Trim.Length > 0 Then
                Enmascara()
            Else
                MsgBox("Debe Ingresar Numero de Factura", MsgBoxStyle.Critical, "Numero")
                tb_Numero.Focus()
            End If
        End If
    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Enmascara()
    End Sub

    Private Sub Enmascara()
        Dim tamaño As Integer
        Dim tamañot As Integer

        Try
            tamaño = (10 - Len(tb_Numero.Text)) + Len(tb_Numero.Text)
            tb_Numero.Text = "0000000000" + tb_Numero.Text
            tamañot = Len(tb_Numero.Text)
            tb_Numero.Text = Mid(tb_Numero.Text, tamañot - tamaño + 1)
            Carga()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Carga()
        Dim otrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_vb_Factura_Costo_Muestra '" & gs_empresa & "','" & cb_Tipo.Text & "','" & tb_Numero.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            dta.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = dta.NewRow
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("Linea") = dr.Item("Linea")
                dr2.Item("Producto") = dr.Item("Producto")
                dr2.Item("Descripcion") = dr.Item("Descripcion")
                dr2.Item("Cantidad") = dr.Item("Cantidad")
                dr2.Item("Ccosto") = dr.Item("Ccosto")
                dr2.Item("Ap") = dr.Item("Ap")
                dr2.Item("Marca") = dr.Item("Marca")
                dr2.Item("Rubro") = dr.Item("Rubro")
                dta.Rows.Add(dr2)

            Next

            Me.dgv_Detalle.DataSource = dta    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(dta, Me.dgv_Detalle, ",Numero,Linea,Producto,Descripcion,Cantidad,Ccosto,Ap,Marca,Rubro,", ",", ",Numero,Linea,Producto,Descripcion,Cantidad,", "", "", "", "", True, True, 275, 0)

            cb_Tipo.Enabled = False
            tb_Numero.Enabled = False
            btn_Grabar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        If cb_Tipo.Text.Length > 0 Then
            If tb_Numero.Text.Trim.Length > 0 Then
                Grabar()
                Nuevo()
            Else
                MsgBox("Debe Ingresar Numero", MsgBoxStyle.Critical, "Numero")
                tb_Numero.Focus()
            End If
        Else
            MsgBox("Debe Seleccionar Documento", MsgBoxStyle.Critical, "Documento")
        End If

    End Sub

    Private Sub Grabar()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String

        Try
            Otrans.open()
            dt = Me.dgv_Detalle.DataSource

            For Each drv As DataRowView In dt.DefaultView

                ls_sql = "pa_vb_Factura_Costo_Actualiza '" & gs_empresa & "','" & cb_Tipo.Text & "','" & drv.Item("Numero").ToString & "','" & drv.Item("Linea").ToString & "','" & drv.Item("Producto").ToString & "','" & _
                drv.Item("Ccosto").ToString & "','" & drv.Item("Ap").ToString & "','" & drv.Item("Marca").ToString & "','" & drv.Item("Rubro").ToString & "'"
                Otrans.Ingresa(ls_sql)

            Next
            dt.DefaultView.RowFilter = ""
            MsgBox("Actualizado Correctamente", MsgBoxStyle.Information, "Grabado")
        Catch ex As Exception
            MsgBox("Error al Grabar")
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        tb_Numero.Text = ""
        dgv_Detalle.DataSource = Nothing
        cb_Tipo.Enabled = True
        tb_Numero.Enabled = True
        btn_Grabar.Enabled = False
        crea_estructura()
        tb_Numero.Focus()
    End Sub
End Class