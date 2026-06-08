Public Class Frm_Cancela_Facturas_Con_Notas
    Inherits System.Windows.Forms.Form
    Dim _dtFacturas As DataTable
    Dim oTransaccion As Transaccional.Conexion
    'Dim gs_empresa As String = "DMARTE1"
    'Dim gs_usuario As String = "ACASUY"
    Dim TipoDocto, Numero, Cliente As String


    Private Sub Frm_Cancela_Facturas_Con_Notas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        Vacio()
    End Sub


    Private Sub CreaTabla()
        _dtFacturas = New DataTable("Tmp_Facturas")
        _dtFacturas.Columns.Add(New DataColumn("Tipo_Documento", GetType(String)))
        _dtFacturas.Columns.Add(New DataColumn("Referencia", GetType(String)))
        _dtFacturas.Columns.Add(New DataColumn("Saldo", GetType(Double)))
        _dtFacturas.Columns.Add(New DataColumn("Cliente", GetType(String)))
        _dtFacturas.Columns.Add(New DataColumn("RazonSocial", GetType(String)))

        '_dtDepositos = New DataTable("Tmp_Depositos")
        '_dtDepositos.Columns.Add(New DataColumn("Deposito", GetType(String)))
        '_dtDepositos.Columns.Add(New DataColumn("TipoPago", GetType(String)))
        '_dtDepositos.Columns.Add(New DataColumn("Monto", GetType(Double)))


        '_dtMovimientos = New DataTable("Tmp_Movimientos")
        '_dtMovimientos.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        '_dtMovimientos.Columns.Add(New DataColumn("Monto", GetType(Double)))
        '_dtMovimientos.Columns.Add(New DataColumn("CtaCte", GetType(String)))

        '_dtCorrelativo = New DataTable("Tmp_Correlativo")
        '_dtCorrelativo.Columns.Add(New DataColumn("Correlativo", GetType(Integer)))

    End Sub

    Private Sub Vacio()

        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion
            lsSQL = "pa_vb_Balance_Unisuper_Vacio "
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            Me.dgv_Facturas.DataSource = dt    'Despliega el resultado del procedimiento en un Grid
            Me.dgv_Cancelacion.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Genera_Facturas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion
            lsSQL = "pa_Notas_Credito_Unisuper '" & gs_empresa & "','" & dtp_Fecha.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            ' _dtFacturas.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtFacturas.NewRow
                dr2.Item("Tipo_Documento") = dr.Item("Tipo_Documento")
                dr2.Item("Referencia") = dr.Item("Referencia")
                dr2.Item("Saldo") = dr.Item("Saldo")
                dr2.Item("Cliente") = dr.Item("Cliente")
                dr2.Item("RazonSocial") = dr.Item("RazonSocial")

                _dtFacturas.Rows.Add(dr2)
            Next

            Me.dgv_Facturas.DataSource = _dtFacturas    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtFacturas, Me.dgv_Facturas, ",Tipo_documento,Referencia,Saldo,Cliente,RazonSocial,", ",,", ",Tipo_Documento,Referencia,Saldo,Cliente,RazonSocial,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Ejecuta_Click(sender As Object, e As EventArgs) Handles btn_Ejecuta.Click
        ReiniciaIdentidad()
        Genera_Facturas()
        cb_TipoDocto.Enabled = True
        btn_Ejecuta.Enabled = True
        tb_Numero.Enabled = True
        cargacombo()

    End Sub

    Private Sub cargacombo()
        Dim ls_SqlScript As String
        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet

        Try
            oTransaccion = New Transaccional.Conexion("flexline")
            oTransaccion.open()

            ls_SqlScript = "pa_vb_Balance_Unisper_TipoDocto '" & gs_empresa & "'"

            ldt_table = oTransaccion.Obtiene(ls_SqlScript)
            ldt_table.TableName = "TpDocto"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_TipoDocto.DisplayMember = "Tipo_Documento"
            Me.cb_TipoDocto.ValueMember = "Tipo_Documento"
            Me.cb_TipoDocto.DataSource = ldt_table

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            oTransaccion.close()
            oTransaccion = Nothing
        End Try

        
    End Sub

    Private Sub cb_TipoDocto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_TipoDocto.SelectedValueChanged
        tb_Numero.Focus()
    End Sub

    Private Sub tb_Numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Numero.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca_Factura()
        End If
    End Sub

    Private Sub Busca_Factura()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_vb_Balance_Unisuper_Factura '" & gs_empresa & "','" & cb_TipoDocto.Text & "','" & tb_Numero.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            cb_Grupo.Enabled = False
            cb_TipoDocto.Enabled = False
            btn_Ejecuta.Enabled = False
            tb_Numero.Enabled = False

            If dt.Rows.Count > 0 Then
                Me.lb_Cliente.Text = dt.Rows(0)("Cliente").ToString & " - " & dt.Rows(0)("RazonSocial").ToString
                Me.lb_Monto.Text = Format(dt.Rows(0)("Saldo"), "#,###,##0.00")
                'dt.Rows(0)("Nombre").ToString = Nothing Then
            Else

                MsgBox("Documento No Existe", MsgBoxStyle.Critical, tb_Numero.Text)
                Me.lb_Cliente.Text = "Cliente"
                Me.lb_Monto.Text = "Saldo"
                cb_TipoDocto.Enabled = True
                btn_Ejecuta.Enabled = True
                tb_Numero.Enabled = True
                tb_Numero.Focus()
                tb_Numero.SelectAll()
            End If

        Catch ex As Exception
            MsgBox("Documento No Existe, Verifique", MsgBoxStyle.Critical, tb_Numero.Text)

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub tb_Nuevo_Click(sender As Object, e As EventArgs) Handles tb_Nuevo.Click
        Nuevo()

    End Sub

    Private Sub Limpia()
        tb_Numero.Text = ""
        tb_BuscaNumero.Text = ""
        lb_Saldo.Text = "0.00"
        cb_TipoDocto.Enabled = True
        tb_Numero.Enabled = True
        dgv_Cancelacion.DataSource = Nothing
        tb_Numero.Focus()
    End Sub

    Private Sub Nuevo()
        tb_Numero.Text = ""
        tb_BuscaNumero.Text = ""
        lb_Cliente.Text = "Cliente"
        lb_Monto.Text = "Saldo"
        lb_Saldo.Text = "0.00"
        dgv_Facturas.DataSource = Nothing
        dgv_Cancelacion.DataSource = Nothing
        cb_Grupo.Enabled = True
        btn_Ejecuta.Enabled = True
        ReiniciaIdentidad()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Baja_Factura()
    End Sub

    Private Sub Baja_Factura()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()    'abre conexion
            lsSQL = "pa_vb_Balance_Unisuper_Cancelacion '" & gs_empresa & "','" & cb_TipoDocto.Text & "','" & tb_Numero.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            Me.dgv_Cancelacion.DataSource = dt
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_Facturas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgv_Facturas.MouseDoubleClick
        TipoDocto = dgv_Facturas.CurrentRow.Cells(0).Value.ToString()
        Numero = dgv_Facturas.CurrentRow.Cells(1).Value.ToString()
        Cliente = dgv_Facturas.CurrentRow.Cells(3).Value.ToString()
        Baja_Notas()
        dgv_Facturas.Rows.Remove(dgv_Facturas.CurrentRow)
    End Sub

    Private Sub Baja_Notas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()    'abre conexion
            lsSQL = "pa_vb_Balance_Unisuper_Cancelacion '" & gs_empresa & "','" & TipoDocto & "','" & Numero & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            Me.dgv_Cancelacion.DataSource = dt
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub ReiniciaIdentidad()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Try
            Utrans.open()
            ls_sql = "TRUNCATE TABLE Balance_Unisuper_Cancelacion" 'DBCC CHECKIDENT (Balance_Unisuper_Cancelacion, RESEED,0) "
            Utrans.Obtiene(ls_sql)
        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado ", MsgBoxStyle.Critical, "Error")
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub
    Private Sub Total()
        Dim ntotal As Double
        Dim dt As DataTable
        ' Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            '    Otrans.open()   'abre conexion
            dt = Me.dgv_Cancelacion.DataSource

            If dgv_Cancelacion.Rows.Count > 0 Then
                ntotal = dt.Compute("sum(Saldo)", "Saldo<>0")
                Me.lb_Saldo.Text = Format(ntotal, "###,##0.00")
            Else
                'Me.dgv_Cancelacion.DataSource.ToString = Nothing Then
                ntotal = 0
                Me.lb_Saldo.Text = "0.00"
    
            End If

            

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tb_BuscaNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_BuscaNumero.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca_Numero()
        End If

    End Sub

    Private Sub Busca_Numero()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()    'abre conexion
            lsSQL = "pa_Balance_Unisuper_Busca '" & gs_empresa & "','%" & tb_BuscaNumero.Text & "%'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            Me.dgv_Facturas.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_Cancelacion_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Cancelacion.CellValueChanged
        Total()
    End Sub

    Private Sub btn_Actualiza_Click(sender As Object, e As EventArgs) Handles btn_Actualiza.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Correlativo As Integer

        If MessageBox.Show("¿Se Actualizará a Contabilidad?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Correlativo = InputBox("Ingrese Numero de Poliza", "Correlativo", "0")

        If Not IsNumeric(Correlativo) Or Correlativo < 0 Then
            MsgBox("Debe Ingresar Correlativo Valido", MsgBoxStyle.Critical, "Error")
            btn_Actualiza.Focus()
        Else



            Try

                Otrans.open()   'abre conexion
                dt = Me.dgv_Cancelacion.DataSource

                For Each drv As DataRowView In dt.DefaultView

                    ls_sql = "pa_Balance_Unisuper_Actualiza '" & gs_empresa & "','" & dtp_Fecha.Text & "','" & Correlativo & "','" & drv.Item("Tipo_Documento") & "','" & drv.Item("Referencia") & "','" & drv.Item("Cliente") & "','" & drv.Item("RazonSocial") & "','" & drv.Item("Saldo") & "','" & gs_usuario & "'"
                    Otrans.Actualiza(ls_sql)

                Next
                ls_sql = "pa_Balance_Unisuper_Actualiza2 '" & gs_empresa & "','" & dtp_Fecha.Text & "','" & Correlativo & "','" & gs_usuario & "'"
                Otrans.Actualiza(ls_sql)

                dt.DefaultView.RowFilter = ""
                MsgBox("Poliza Creada Satisfactoriamente", MsgBoxStyle.Information, "Verifique")
                Limpia()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Otrans.close()
                Otrans = Nothing

            End Try
        End If
    End Sub

    Private Sub dgv_Cancelacion_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_Cancelacion.RowsRemoved
        Total()
    End Sub
End Class