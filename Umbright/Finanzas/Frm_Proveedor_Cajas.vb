Public Class Frm_Proveedor_Cajas

    Public CtaCte As String = ""
    Public Nombre As String = ""
    
    Dim _dtProveedor As DataTable
    'Dim gs_Empresa As String = "LOGISERV"

    Private Sub Frm_Proveedor_Cajas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        Llena_Empleados()
    End Sub

    Private Sub CreaTabla()
        _dtProveedor = New DataTable("Tmp_Proveedores")

        _dtProveedor.Columns.Add(New DataColumn("CtaCte", GetType(String)))
        _dtProveedor.Columns.Add(New DataColumn("RazonSocial", GetType(String)))

    End Sub

    Private Sub Llena_Empleados()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "select CtaCte,RazonSocial from ctacte where empresa='" & gs_Empresa & "' and tipoctacte='proveedor' and vigencia='S' ORDER BY CTACTE"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtProveedor.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtProveedor.NewRow
                dr2.Item("CtaCte") = dr.Item("CtaCte")
                dr2.Item("RazonSocial") = dr.Item("RazonSocial")
                
                _dtProveedor.Rows.Add(dr2)

            Next

            Me.dgv_Proveedores.DataSource = _dtProveedor    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtProveedor, Me.dgv_Proveedores, ",CtaCte,RazonSocial,", ",,", ",CtaCte,RazonSocial,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub dgv_Proveedores_DoubleClick(sender As Object, e As EventArgs) Handles dgv_Proveedores.DoubleClick
        Dim nFila As Integer

        Try
            nFila = Me.dgv_Proveedores.CurrentRow.Index

            Me.CtaCte = Me.dgv_Proveedores.Item("CtaCte", nFila).Value
            Me.Nombre = Me.dgv_Proveedores.Item("RazonSocial", nFila).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.CtaCte = ""
            Me.Nombre = ""

        End Try

        Me.Close()
    End Sub
End Class