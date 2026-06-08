Public Class frm_scm_AsignarOrigen
    Dim dtProductos As New DataTable

    Private Sub crearEstructura()
        dtProductos.Columns.Add(New DataColumn("producto", GetType(String)))
        dtProductos.Columns.Add(New DataColumn("glosa", GetType(String)))
        dtProductos.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dtProductos.Columns.Add(New DataColumn("marca", GetType(String)))
        dtProductos.Columns.Add(New DataColumn("origenAnterior", GetType(String)))
        dtProductos.Columns("producto").Unique = True

    End Sub

    Private Sub llenarCombo()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()


            lsSQL = "pa_sel_um_prv_proveedor '" & gs_empresa & "'"

            dt = otrans.Obtiene(lsSQL)
            dt = clsGen.ValoresDistinto(dt, "origen".Split(","))
            'dt.TableName = "origenes"


            Me.cmbOrigen.DataSource = dt
            Me.cmbOrigen.DisplayMember = "origen"
            Me.cmbOrigen.ValueMember = "origen"


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub alinearGrid()

        Dim clsGen As New ClasesGenerales.General

        Try
            clsGen.Alinear_GridView(dtProductos, Me.dgvProductos, "", "", ",glosa,proveedor,marca,origenanterior", "", "", "", "", True, True, 200, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

    Private Function buscarProducto(ByVal pcodigo As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As New DataTable
        Dim lsSQL As String


        Try
            Otrans.open()
            lsSQL = "pa_sel_um_producto '" & gs_empresa & "','" & pcodigo & "'"
            dt = Otrans.Obtiene(lsSQL)
        
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return dt
    End Function

    Private Sub guardarCambios()
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String = String.Empty

        Try
            Otrans.open()
            For Each dr As DataRow In dtProductos.Rows
                lsSQL = "pa_upd_inv_producto_origen '" & gs_empresa & "','" & dr.Item("producto") & "','" & Me.cmbOrigen.Text & "'"
                Otrans.Actualiza(lsSQL)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show(Otrans.descripcion_error, "Guardar Cambios")
                End If
            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub frm_scm_AsignarOrigen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        llenarCombo()
        dgvProductos.DataSource = dtProductos
        alinearGrid()
    End Sub



    Private Sub dgvProductos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        'Dim therow As DataGridViewRow

        Dim c As Control = Me.dgvProductos.EditingControl

        Dim dt As DataTable
        If c.Text = "+" Then
            'Levantar la busqueda
            Dim frm_busqueda As New frm_busqueda_general
            frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
            frm_busqueda.parametros = "glosa,producto,tipoproducto,familia"
            frm_busqueda.nombre_vista = "v_um_producto_busqueda"
            frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
            frm_busqueda.txt_buscar1.Focus()
            frm_busqueda.ShowDialog(Me)

            c.Text = frm_busqueda.resultado
            frm_busqueda.Dispose()
            frm_busqueda = Nothing
            dt = BuscarProducto(c.Text)
        Else
            dt = BuscarProducto(c.Text)
        End If
        If dt.Rows.Count = 1 Then
            'Validar Que No Exista en el grid

            Me.dgvProductos.Item("producto", e.RowIndex).Value = dt.Rows(0).Item("producto").ToString
            Me.dgvProductos.Item("glosa", e.RowIndex).Value = dt.Rows(0).Item("Glosa").ToString
            Me.dgvProductos.Item("proveedor", e.RowIndex).Value = dt.Rows(0).Item("subfamilia").ToString
            Me.dgvProductos.Item("marca", e.RowIndex).Value = dt.Rows(0).Item("tipo").ToString
            Me.dgvProductos.Item("origenAnterior", e.RowIndex).Value = dt.Rows(0).Item("AnalisisProducto4").ToString
            alinearGrid()
            Me.cmbOrigen.Enabled = False
        Else
            If c.Text.Length > 1 Then
                MessageBox.Show("Producto No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvProductos.Item("producto", e.RowIndex).Value = ""
                Me.dgvProductos.Item("glosa", e.RowIndex).Value = ""
                ' Me.dgvProductos.Item(e.ColumnIndex - 1, e.RowIndex).Value = ""
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If MessageBox.Show("Esta Seguro de Limpiar La Informacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dtProductos.Rows.Clear()
            cmbOrigen.Enabled = True
            alinearGrid()
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Le Va a Cambiar Origen a " & dtProductos.Rows.Count & " Producto(s)" & Chr(13) & "Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            guardarCambios()
        End If
    End Sub
End Class