Public Class Frm_Actualizacion_Codigos
    Dim _dtProductos As DataTable
    Dim _dtFact As DataTable
    'Dim gs_empresa As String = "DIUVA"
    'Dim gs_usuario As String = "basturias"

    Private Sub Frm_Actualizacion_Codigos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        gb_Replicar.Enabled = False
        tb_Producto.Focus()
    End Sub

    Private Sub CreaTabla()

        _dtProductos = New DataTable("TmpProd")

        _dtProductos.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Producto", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Glosa", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("TipoProducto", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Familia", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Marca", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Procedencia", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Unidad_Negocio", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("UxC", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("Registro_Sanitario", GetType(String)))
        _dtProductos.Columns.Add(New DataColumn("FechaVence", GetType(Date)))

        _dtFact = New DataTable("Tmp_Fact")

        _dtFact.Columns.Add(New DataColumn("Tipodocto", GetType(String)))
        _dtFact.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtFact.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtFact.Columns.Add(New DataColumn("Total", GetType(Double)))

    End Sub

    Private Sub Carga_Producto()
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim ls_SqlScript As String
        Dim ls_SqlScript2 As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()

        ls_SqlScript = "spa_Actualizacion_Productos '" & gs_empresa & "','" & tb_Producto.Text & "'"
        dt = otrans.Obtiene(ls_SqlScript)

        ls_SqlScript2 = " select Glosa, TipoProducto, Familia, Proveedor, Marca, Procedencia, Unidad_Negocio, UxC, Registro_Sanitario, FechaVence from SCM.flexline.Actualiza_Prod_Datos where empresa='" & gs_empresa & "' and producto='" & tb_Producto.Text & "'"
        dt2 = otrans.Obtiene(ls_SqlScript2)

        If dt2.Rows.Count > 0 Then

        lb_Descripcion.Text = dt2.Rows(0).Item("Glosa")
        lb_TipoProd.Text = dt2.Rows(0).Item("TipoProducto")
        lb_Familia.Text = dt2.Rows(0).Item("Familia")
        lb_Proveedor.Text = dt2.Rows(0).Item("Proveedor")
        lb_Marca.Text = dt2.Rows(0).Item("Marca")
        lb_Procedencia.Text = dt2.Rows(0).Item("Procedencia")
        lb_Un.Text = dt2.Rows(0).Item("Unidad_Negocio")
        lb_Uxc.Text = dt2.Rows(0).Item("UxC")
        lb_Registro.Text = dt2.Rows(0).Item("Registro_Sanitario")
            lb_Vence.Text = dt2.Rows(0).Item("FechaVence")
            tb_Producto.Enabled = False
        Else
            MsgBox("Codigo de Producto No Existe!!", MsgBoxStyle.Critical, "Código Invalido")
            tb_Producto.Focus()
            tb_Producto.SelectAll()
        End If
    End Sub

    Private Sub tb_Producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Producto.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Carga_Producto()
                Existencias()
                Memos()
                Consignas()
                Precios()
                Presupuestos()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        
    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        lb_Descripcion.Text = "Descripcion"
        lb_TipoProd.Text = "Tipo Producto"
        lb_Familia.Text = "Familia"
        lb_Proveedor.Text = "Proveedor"
        lb_Marca.Text = "Marca"
        lb_Procedencia.Text = "Procedencia"
        lb_Un.Text = "Unidad_Negocio"
        lb_Uxc.Text = "U x C"
        lb_Registro.Text = "Registro"
        lb_Vence.Text = "Vence"

        dgv_Consignaciones.DataSource = Nothing
        dgv_Existencias.DataSource = Nothing
        dgv_Memos.DataSource = Nothing
        dgv_Precios.DataSource = Nothing
        dgv_Presupuestos.DataSource = Nothing

        tb_CodigoNuevo.Text = ""
        nud_Uxc.Value = 0
        gb_Replicar.Enabled = False

        tb_Producto.Text = ""
        tb_Producto.Enabled = True
        tb_Producto.Focus()

    End Sub

    Private Sub Existencias()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "select Bodega, Saldo from SCM.flexline.Actualiza_Prod_Existencia where empresa='" & gs_empresa & "' and producto='" & tb_Producto.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            dgv_Existencias.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Memos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "select Ctacte, Precio, FechaI, FechaF, Numero, ListaPrecio  from SCM.flexline.Actualiza_Prod_Memos where ctacte != '' and empresa='" & gs_empresa & "' and producto='" & tb_Producto.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            dgv_Memos.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Consignas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "select Tipodocto, Fecha, Numero, Cliente, Bodega, Saldo from SCM.flexline.Actualiza_Prod_Consignas where empresa='" & gs_empresa & "' and producto='" & tb_Producto.Text & "'"
            dt = otrans.Obtiene(lsSQL)
            dgv_Consignaciones.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Precios()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "select Nombre, Valor from SCM.flexline.Actualiza_Prod_Precio where empresa='" & gs_empresa & "' and producto='" & tb_Producto.Text & "'"
            dt = otrans.Obtiene(lsSQL)
            dgv_Precios.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Presupuestos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "select Periodo, Compras, Comercial, Diferencia from SCM.flexline.Actualiza_Prod_Ppto where empresa='" & gs_empresa & "' and producto='" & tb_Producto.Text & "'"
            dt = otrans.Obtiene(lsSQL)
            dgv_Presupuestos.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btn_Replicar_Click(sender As Object, e As EventArgs) Handles btn_Replicar.Click
        If MsgBox("Seguro de Replicar el Codigo de Producto?", MsgBoxStyle.YesNo, "Replicar") = MsgBoxResult.Yes Then
            Replicar()
        End If
    End Sub

    Private Sub Replicar()
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()

        ls_SqlScript = "spa_Actualizacion_Productos_Asigna '" & gs_empresa & "','" & tb_Producto.Text & "'"
        dt = otrans.Obtiene(ls_SqlScript)

        tb_CodigoNuevo.Text = dt.Rows(0).Item("Producto")
        tb_CodigoNuevo.Enabled = False
        gb_Replicar.Enabled = True
        tb_CodigoNuevo.Focus()

    End Sub

    Private Sub btn_Generar_Click(sender As Object, e As EventArgs) Handles btn_Generar.Click
        If MsgBox("Seguro De Crear Código de Producto: " & tb_CodigoNuevo.Text & " Con las Unidades Por Caja: " & nud_Uxc.Value & ", Con Base al: " & tb_Producto.Text & " - " & lb_Descripcion.Text & "?", MsgBoxStyle.YesNo, "Generar") = MsgBoxResult.Yes Then
            ' MsgBox("Codigo de Producto Replicado!!", MsgBoxStyle.Information, "Verifique")
            Crea_Producto()
            Nuevo()
        Else
            Nuevo()
        End If
    End Sub

    Private Sub Crea_Producto()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()
            MsgBox("Se Creará el Código de producto: " & tb_CodigoNuevo.Text & " con base al código: " & tb_Producto.Text, MsgBoxStyle.Information, "Codigo de Producto")
            MsgBox("Se Creará un Documento de Salida con el codigo Anterior de producto", MsgBoxStyle.Information, "Creación Salida")
            MsgBox("Se Creará un Documento de Entreda con el Código Nuevo de Producto", MsgBoxStyle.Information, "Creación Entrada")
            MsgBox("Se finalizarán los Memos Promocionales al Codigo Anterior y se iniciarán al codigo Nuevo, con la misma fecha de vencimiento")
            MsgBox("El Presupuesto De Compras y Comercial se deja a cero el codigo anterior, y se agrega apartir del periodo al nuevo codigo")

            'lsSQL = "spa_Actualizacion_Productos_Crea '" & gs_empresa & "','" & tb_Producto.Text & "','" & tb_CodigoNuevo.Text & "','" & nud_Uxc.Value & "'"
            'dt = otrans.Obtiene(lsSQL)
            MsgBox("Creado Satisfactoriamente, Favor de Verificar!!", MsgBoxStyle.Information, "Nuevo Código Creado")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Buscar_Productos()
    End Sub

    Private Sub Buscar_Productos()
        Dim oform As New Frm_Actualizacion_Codigos_Busca
        oform.ShowDialog()

        lb_Descripcion.Text = oform.Descripcion.ToString
        lb_TipoProd.Text = oform.TipoProducto.ToString
        lb_Familia.Text = oform.Familia.ToString
        lb_Proveedor.Text = oform.Proveedor.ToString
        lb_Marca.Text = oform.Marca.ToString
        lb_Procedencia.Text = oform.Procedencia.ToString
        lb_Un.Text = oform.Bu.ToString
        lb_Uxc.Text = oform.UxC.ToString
        lb_Registro.Text = oform.Registro.ToString
        lb_Vence.Text = oform.FechaVcto.ToString
        tb_Producto.Text = oform.Producto.ToString
        tb_Producto.Enabled = False

        Existencias()
        Memos()
        Consignas()
        Precios()
        Presupuestos()

    End Sub
End Class
