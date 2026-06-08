Imports System.Text

Public Class Frm_Carga_Precios_Costo
    Dim encabezados_seleccionados As String = ""
    Dim _dtregistros As DataTable
    Dim _dtListaPrecio As DataTable

    Private Sub crearEstructura()

        _dtListaPrecio = New DataTable("tmp_listaprecios")

        _dtListaPrecio.Columns.Add(New DataColumn("Producto", GetType(String)))
        _dtListaPrecio.Columns.Add(New DataColumn("Glosa", GetType(String)))
        _dtListaPrecio.Columns.Add(New DataColumn("valor", GetType(Double)))
        _dtListaPrecio.PrimaryKey = New DataColumn() {_dtListaPrecio.Columns(0)}

    End Sub
    Private Sub ImportarExcel()

        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel() 'Oaut son clases
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados() As String

        Try
            Me.OFD_Listas.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"    'OFD es la funcion de buscar y abrir el archivo de excel
            Me.OFD_Listas.FileName = ""
            Me.OFD_Listas.ShowDialog()

            snombre_archivo = Me.OFD_Listas.FileName
            Oaut.pNombreArchivo = snombre_archivo

            hojas_encabezados = Oaut.Obtener_Hojas
            If hojas_encabezados.Length > 1 Then
                Oaut2.Llenar_Combo_Vector(hojas_encabezados)
                Oaut2.Text = "Seleccion de Hoja"
                Oaut2.StartPosition = FormStartPosition.CenterParent
                Oaut2.ShowDialog()
                Oaut.pNombreHoja = Oaut2._selectedValue.ToString
                Oaut2 = Nothing
            Else
                Oaut.pNombreHoja = hojas_encabezados(0)
            End If

            hojas_encabezados = Oaut.obtenerEncabezados

            Dim listaencabezado As New StringBuilder
            For Each encabezado As String In hojas_encabezados
                If Not encabezado Is Nothing Then listaencabezado.Append("," & encabezado)
            Next
            encabezados_seleccionados = listaencabezado.ToString

            Oaut.pNombreColumnas = encabezados_seleccionados

            _dtregistros = Oaut.obtener_registros_nombres()

        Catch ex As Exception
        Finally
            Oaut.Cerrar_libro()
            Oaut = Nothing
        End Try
    End Sub
    Private Sub llenarLista()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            otrans.open()       'abre conexion
            dt = _dtregistros   'Asigna a dt la tabla _dregistros 
            Me.dgv_Importados.DataSource = dt    'asigna el resultado de la variable dt al Grid

            '   lista en el grid los campos necesarios
            clsGen.Alinear_GridView(dt, Me.dgv_Importados, "", "", ",Producto,Glosa,Valor,", "", True, True, 250, 0)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
        MsgBox("Verifique Los Datos Importados!! ")
    End Sub

    Private Sub Importar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Importar.Click
        crearEstructura()
        ImportarExcel()
        llenarLista()
        InsertaLP_Temp()

    End Sub

    Private Sub InsertaLP_Temp() ' actualiza la lista de precios en flexline
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        
        Try
            Otrans.open()   'abre conexion
            dt = _dtregistros   'Asigna a dt los datos de la tabla temporal

            For Each drv As DataRowView In dt.DefaultView

                ls_sql = "spa_insertaLP_Temp '" & gs_empresa & "','" & gs_usuario & "','" & "QUETZALES" & _
                "','" & drv.Item("producto") & "','" & "NOMBRE_PRODUCTO" & "','" & drv.Item("valor") & "'" 'drv.Item("glosa") & "','" & drv.Item("valor") & "'"
                Otrans.Actualiza(ls_sql)

            Next
            dt.DefaultView.RowFilter = ""

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub btn_Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Procesar.Click
        If MessageBox.Show("Este Proceso Actualizara los Precios y Creara un informe de Productos a Descartar - No tiene Reversion!! ", "PRECAUCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        ActualizaListaD()
        Inserta_Bajas()
        ListaBajas()
        MsgBox(" La Actualizacion ha Finalizado Existosamente.. ")
    End Sub

    Private Sub ActualizaListaD()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        
        Try
            otrans.open()
            lsSQL = "spa_insertaListaP '" & gs_empresa & "','" & gs_usuario & "'"  'asigna el procedimiento y valores a lsSql
            otrans.Actualiza(lsSQL)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Inserta_Bajas() ' Inserta en la tabla temporal los productos que no seran descartados
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        
        Try
            Otrans.open()   'abre conexion
            dt = _dtregistros   'Asigna a dt los datos de la tabla temporal

            For Each drv As DataRowView In dt.DefaultView

                ls_sql = "spa_Productos_bajas '" & gs_empresa & "','" & drv.Item("Producto") & "'"
                Otrans.Actualiza(ls_sql)
            Next
            dt.DefaultView.RowFilter = ""

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub ListaBajas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "select * from temp_bajas " 'asigna los valores de la tabla a lsSql
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            Me.dgv_Descartar.DataSource = dt    'Despliega el resultado del procedimiento en un Grid

            clsGen.Alinear_GridView(dt, Me.dgv_Descartar, "", ",Empresa,", ",Producto,Glosa,Estado,", "", True, True, 275, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub Descarta_Bajas() ' Inserta en la tabla temporal los productos que no seran descartados
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        
        Try
            Otrans.open()   'abre conexion
            dt = _dtregistros   'Asigna a dt los datos de la tabla temporal

            For Each drv As DataRowView In dt.DefaultView
                ls_sql = "spa_BorraBajas '" & gs_empresa & "','" & gs_usuario & "'"
                Otrans.Actualiza(ls_sql)

            Next
            dt.DefaultView.RowFilter = ""

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub
    Private Sub btn_Descartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Descartar.Click
        If MessageBox.Show(" Este Proceso Descartara los Productos!! ", "PRECAUCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Descarta_Bajas()
        ListaBajas()
        MsgBox("Proceso Finalizado, Revise Productos y Precios En Flexline")
    End Sub
    Private Sub Limpiar()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsSQL2 As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "delete from flexline.temp_listaprecios where empresa='" & gs_empresa & "'"  'asigna los valores de la tabla a lsSql
            lsSQL2 = "delete from flexline.temp_bajas where empresa='" & gs_empresa & "'" 'asigna los valores de la tabla a lsSql
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            dt = otrans.Obtiene(lsSQL2)
            _dtListaPrecio.Rows.Clear()
            Me.dgv_Importados.DataSource() = ""
            Me.dgv_Descartar.DataSource() = ""

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar.Click
        Limpiar()
        ListaBajas()
    End Sub

    Private Sub Carga_Listas_Precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub
    Private Sub EnviaXela()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String

        Try
            otrans.open()
            lsSQL = "spa_EnviaXelaLp '" & gs_empresa & "','" & gs_usuario & "'"  'asigna el procedimiento y valores a lsSql
            otrans.Actualiza(lsSQL)
            MsgBox(" EL Envio ha Finalizado Existosamente.. ")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Enviar.Click
        If MessageBox.Show(" Esta Seguro De Enviar a Xela? !! ", "PRECAUCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        EnviaXela()
        Limpiar()
    End Sub

End Class
