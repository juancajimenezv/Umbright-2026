Imports System.Data.OleDb

Public Class frmCargasBI

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Procesar_Excel()

    End Sub
    Private Sub Procesar_Excel()
        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel()
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados(), encabezados_completo As String


        Dim icount As Integer

        Try
            Me.OFD.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"
            Me.OFD.FileName = ""
            Me.OFD.ShowDialog()

            snombre_archivo = Me.OFD.FileName
            Oaut.pNombreArchivo = snombre_archivo


            Label1.Text = Now()

            Dim dt As DataTable = fImport(snombre_archivo, snombre_archivo.Split(".")(1))

            Label2.Text = Now()

            Label4.Text = "Numero de Registros  " & dt.Rows.Count

            Label3.Text = "Numero de Columnas Tabla " & Me.dgvColumnas.RowCount.ToString & " Carga " & Me.dgvPrevia.ColumnCount.ToString


        Catch ex As Exception
        Finally
            'Oaut.Cerrar_libro()
            Oaut = Nothing
        End Try

    End Sub

    Public Function fImport(sPath As String, sExt As String) As DataTable
        Dim sCn As String = ""
        'llenar el dataset
        Dim ds As New DataSet()
        Dim dt As New DataTable()

        Try
            Dim hoja As String = "Carga"
            Dim Conex As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=Excel 12.0;")

            Dim CmdOle As New OleDbCommand()

            CmdOle.Connection = Conex
            CmdOle.CommandType = CommandType.Text
            CmdOle.CommandText = "SELECT * FROM [" + hoja + "$A1:AE25000]"

            Dim AdaptadorOle As New OleDbDataAdapter(CmdOle.CommandText, Conex)


            AdaptadorOle.Fill(dt)
            'dt.Columns.Add(New DataColumn("producto", GetType(String)))
            'dt.Columns.Add(New DataColumn("glosa", GetType(String)))
            'dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
            'dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            'dt.Columns.Add(New DataColumn("giro", GetType(String)))
            'dt.Columns.Add(New DataColumn("mercaderista", GetType(String)))

            'For Each dr As DataRow In dt.Rows
            '    If dr.Item("storename").ToString.Length = 0 Then
            '        dr.Delete()
            '    End If
            'Next
            'dt.AcceptChanges()
            'Try
            '    llenarProducto(dt)
            'Catch ex As Exception

            'End Try

            Me.dgvPrevia.DataSource = dt

            '_dtregistros = dt.Copy

            'llenar dataset con datos de Excel
        Catch ex As Exception
            Dim clsgen As New ClasesGenerales.General
            clsgen.Escribir_Log(ex.ToString)
            clsgen.Escribir_Log(ex.Message)
            clsgen = Nothing
        End Try
        Return dt
    End Function

    Private Sub llenarEstructura()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            dt = clsGen.selectQuery("DWH", "pa_var_um_estructura_" & Me.cmbTabla.Text)
            Me.dgvColumnas.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvColumnas, ",column_name,type_name,precision,", "", "", "", ",column_name=nombre,type_name=tipo,", "", "", True, True, 200, 0)


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Sub guardar()
        If Me.cmbTabla.Text = "bi_producto" Then
            guardar_biProducto()
        End If

    End Sub

    Private Sub guardar_biProducto()
        Dim otrans As New Transaccional.Conexion("DWH")
        Dim lsSQL As String

        Try
            otrans.open()



        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try


    End Sub

    Private Sub frmCargasBI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LlenarCombo()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTabla.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTabla.SelectionChangeCommitted
        'MessageBox.Show("Cargar Estructura de tabla")
        llenarEstructura()
        Me.dgvPrevia.DataSource = Nothing
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()

    End Sub
End Class