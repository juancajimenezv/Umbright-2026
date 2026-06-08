Public Class Frm_Actualizacion_Codigos_Busca
    Public Empresa As String = ""
    Public Producto As String = ""
    Public Descripcion As String = ""
    Public TipoProducto As String = ""
    Public Familia As String = ""
    Public Proveedor As String = ""
    Public Marca As String = ""
    Public Procedencia As String = ""
    Public UxC As String = ""
    Public Bu As String = ""
    Public Registro As String = ""
    Public FechaVcto As String = ""

    'Dim gs_empresa As String = "DIUVA"
    'Dim gs_usuario As String = "basturias"

    Private Sub Frm_Actualizacion_Codigos_Busca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Busca_Codigos()
    End Sub

    Private Sub Busca_Codigos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Actualizacion_Productos_Bum '" & gs_empresa & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)
            dgv_BuscaProductos.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_BuscaProductos_DoubleClick(sender As Object, e As EventArgs) Handles dgv_BuscaProductos.DoubleClick
        Dim nFila As Integer

        Try
            nFila = Me.dgv_BuscaProductos.CurrentRow.Index

            Me.Empresa = Me.dgv_BuscaProductos.Item("Empresa", nFila).Value
            Me.Producto = Me.dgv_BuscaProductos.Item("Producto", nFila).Value
            Me.Descripcion = Me.dgv_BuscaProductos.Item("Descripcion", nFila).Value
            Me.TipoProducto = Me.dgv_BuscaProductos.Item("TipoProducto", nFila).Value
            Me.Familia = Me.dgv_BuscaProductos.Item("Familia", nFila).Value
            Me.Proveedor = Me.dgv_BuscaProductos.Item("Proveedor", nFila).Value
            Me.Marca = Me.dgv_BuscaProductos.Item("Marca", nFila).Value
            Me.Procedencia = Me.dgv_BuscaProductos.Item("Procedencia", nFila).Value
            Me.UxC = Me.dgv_BuscaProductos.Item("UxC", nFila).Value
            Me.Bu = Me.dgv_BuscaProductos.Item("Bu", nFila).Value
            Me.Registro = Me.dgv_BuscaProductos.Item("Registro_Sanitario", nFila).Value
            Me.FechaVcto = Me.dgv_BuscaProductos.Item("FechaVence", nFila).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Empresa = ""
            Producto = ""
            Descripcion = ""
            Familia = ""
            Proveedor = ""
            Marca = ""
            Procedencia = ""
            UxC = ""
            Bu = ""
            Registro = ""
            FechaVcto = ""
        End Try
        Me.Close()
    End Sub
End Class