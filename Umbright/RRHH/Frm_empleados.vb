Public Class Frm_empleados
    Public Ficha As String = ""
    Public Nombre As String = ""
    Public Area As String = ""
    Public Departamento As String = ""
    Public Cargo As String = ""
    Public Fecha_Ingreso As String = ""
    Public Jefe As String = ""
    Public Sexo As String = ""
    Public PrimerNombre As String = ""
    Public SegundoNombre As String = ""
    Public PrimerApellido As String = ""
    Public SegundoApellido As String = ""
    Public Fecha_Nac As String = ""
    Public Nit As String = ""
    Public Estado As String = ""
    Public Igss As String = ""
    Public Licencia As String = ""
    Public Direccion As String = ""
    Public Telefono As String = ""
    Public Depto As String = ""
    Public Municipio As String = ""
    Public Pais As String = ""
    Public FechaInicio As String = ""
    Public Sueldo As Double

    Dim _dtEmpleados As DataTable
    'Dim gs_Empresa As String = "UMBRAL"

    Private Sub Frm_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        Llena_Empleados()
    End Sub


    Private Sub CreaTabla()
        _dtEmpleados = New DataTable("Tmp_Empleados")

        _dtEmpleados.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtEmpleados.Columns.Add(New DataColumn("Ficha", GetType(String)))
        _dtEmpleados.Columns.Add(New DataColumn("Nombre", GetType(String)))
        _dtEmpleados.Columns.Add(New DataColumn("Area", GetType(String)))
        _dtEmpleados.Columns.Add(New DataColumn("Departamento", GetType(String)))
        _dtEmpleados.Columns.Add(New DataColumn("Cargo", GetType(String)))
        _dtEmpleados.Columns.Add(New DataColumn("Fecha_Ingreso", GetType(Date)))
        _dtEmpleados.Columns.Add(New DataColumn("Jefe_Inmediato", GetType(String)))
        
    End Sub

    Private Sub Llena_Empleados()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Control_Suspension_Empleados '" & gs_Empresa & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtEmpleados.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtEmpleados.NewRow
                dr2.Item("Empresa") = dr.Item("Empresa")
                dr2.Item("Ficha") = dr.Item("Ficha")
                dr2.Item("Nombre") = dr.Item("Nombre")
                dr2.Item("Area") = dr.Item("Area")
                dr2.Item("Departamento") = dr.Item("Departamento")
                dr2.Item("Cargo") = dr.Item("Cargo")
                dr2.Item("Fecha_Ingreso") = dr.Item("Fecha_Ingreso")
                dr2.Item("Jefe_Inmediato") = dr.Item("Jefe_Inmediato")

                _dtEmpleados.Rows.Add(dr2)

            Next

            Me.dgv_empleados.DataSource = _dtEmpleados    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtEmpleados, Me.dgv_empleados, ",Ficha,Nombre,Area,Departamento,Cargo,Fecha_Ingreso,Jefe_Inmediato,", ",Empresa,", ",Ficha,Nombre,Area,Departamento,Cargo,Fecha_Ingreso,Jefe_Inmediato,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_empleados_DoubleClick(sender As Object, e As EventArgs) Handles dgv_empleados.DoubleClick
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow
        Dim nFila As Integer

        Try
            nFila = Me.dgv_empleados.CurrentRow.Index

            Me.Ficha = Me.dgv_empleados.Item("Ficha", nFila).Value
            Me.Nombre = Me.dgv_empleados.Item("Nombre", nFila).Value

            Me.Area = Me.dgv_empleados.Item("Area", nFila).Value
            Me.Departamento = Me.dgv_empleados.Item("Departamento", nFila).Value
            Me.Cargo = Me.dgv_empleados.Item("Cargo", nFila).Value
            Me.Fecha_Ingreso = Me.dgv_empleados.Item("Fecha_Ingreso", nFila).Value
            Me.Jefe = Me.dgv_empleados.Item("Jefe_Inmediato", nFila).Value

            otrans.open()
            lsSQL = "pa_vb_Empleados '" & gs_Empresa & "','" & Me.dgv_empleados.Item("Ficha", nFila).Value & "'"
            dt = otrans.Obtiene(lsSQL)

            Sexo = dt.Rows(0)("Sexo").ToString
            PrimerNombre = dt.Rows(0)("PrimerNombre").ToString
            PrimerApellido = dt.Rows(0)("PrimerApellido").ToString
            SegundoApellido = dt.Rows(0)("SegundoApellido").ToString
            Fecha_Nac = dt.Rows(0)("FECHA_NACIMIENTO").ToString
            Nit = dt.Rows(0)("Nit").ToString
            Estado = dt.Rows(0)("ESTADO_CIVIL").ToString
            Igss = dt.Rows(0)("Igss").ToString
            Licencia = dt.Rows(0)("Licencia").ToString
            Direccion = dt.Rows(0)("DIRECCION").ToString
            Telefono = dt.Rows(0)("TELEFONO").ToString()
            Depto = dt.Rows(0)("Depto").ToString
            Municipio = dt.Rows(0)("Municipio").ToString
            Pais = dt.Rows(0)("Pais").ToString
            FechaInicio = dt.Rows(0)("FechaInicio").ToString
            Sueldo = dt.Rows(0)("Sueldo").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Ficha = ""
            Me.Nombre = ""
            Me.Area = ""
            Me.Departamento = ""
            Me.Cargo = ""
            Me.Jefe = ""

            Me.PrimerNombre = ""

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

        Me.Close()
    End Sub

   
End Class