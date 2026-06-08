Public Class Frm_Buscar_Suspendidos
    Public Ficha As String = ""
    Public Nombre As String = ""
    Public Area As String = ""
    Public Departamento As String = ""
    Public Cargo As String = ""
    Public Fecha_Ingreso As String = ""
    Public Jefe As String = ""
    Public Motivo As String = ""
    Public FechaInicio As String = ""
    Public FechaFinal As String = ""
    Public FechaAccidente As String = ""
    Public FechaAlta As String = ""
    Public CausaDiagnostico As String = ""

    Dim _dtEmpleados As DataTable
    'Dim gs_Empresa As String = "LOGISERV"

    Private Sub Frm_Buscar_Suspendidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        Llena_Suspendidos()
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
        _dtEmpleados.Columns.Add(New DataColumn("Motivo", GetType(String)))
        _dtEmpleados.Columns.Add(New DataColumn("FechaInicio", GetType(Date)))
        _dtEmpleados.Columns.Add(New DataColumn("FechaFinal", GetType(Date)))
        _dtEmpleados.Columns.Add(New DataColumn("FechaAccidente", GetType(Date)))
        _dtEmpleados.Columns.Add(New DataColumn("FechaAlta", GetType(Date)))
        _dtEmpleados.Columns.Add(New DataColumn("CausaDiagnostico", GetType(String)))
    End Sub

    Private Sub Llena_Suspendidos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "select Empresa,Ficha,Nombre,Area,Departamento,Cargo,Fecha_Ingreso,Jefe_Inmediato,Motivo,FechaAccidente,FechaAlta,FechaInicio,FechaFinal,CausaDiagnostico from flexline.PER_CONTROL_SUSPENSION where empresa='" & gs_Empresa & "' and " & _
                "Fechainicio <= cast(Convert(Char(10), getdate(),103) as datetime)" ' and FechaFinal >= cast(Convert(Char(10), getdate(),103) as datetime)"
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
                dr2.Item("Motivo") = dr.Item("Motivo")
                dr2.Item("FechaAccidente") = dr.Item("FechaAccidente")
                dr2.Item("FechaAlta") = dr.Item("FechaAlta")
                dr2.Item("FechaInicio") = dr.Item("FechaInicio")
                dr2.Item("FechaFinal") = dr.Item("FechaFinal")
                dr2.Item("CausaDiagnostico") = dr.Item("CausaDiagnostico")
                _dtEmpleados.Rows.Add(dr2)

            Next

            Me.dgv_Busca_Suspendidos.DataSource = _dtEmpleados    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtEmpleados, Me.dgv_Busca_Suspendidos, ",Ficha,Nombre,Area,Departamento,Cargo,Fecha_Ingreso,Jefe_Inmediato,Motivo,FechaInicio,FechaFinal,", ",Empresa,FechaAccidente,FechaAlta,CausaDiagnostico", ",Ficha,Nombre,Area,Departamento,Cargo,Fecha_Ingreso,Jefe_Inmediato,Motivo,FechaInicio,FechaFinal,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub dgv_Busca_Suspendidos_DoubleClick(sender As Object, e As EventArgs) Handles dgv_Busca_Suspendidos.DoubleClick
        Dim nFila As Integer

        Try
            nFila = Me.dgv_Busca_Suspendidos.CurrentRow.Index

            Me.Ficha = Me.dgv_Busca_Suspendidos.Item("Ficha", nFila).Value
            Me.Nombre = Me.dgv_Busca_Suspendidos.Item("Nombre", nFila).Value

            Me.Area = Me.dgv_Busca_Suspendidos.Item("Area", nFila).Value
            Me.Departamento = Me.dgv_Busca_Suspendidos.Item("Departamento", nFila).Value
            Me.Cargo = Me.dgv_Busca_Suspendidos.Item("Cargo", nFila).Value
            Me.Fecha_Ingreso = Me.dgv_Busca_Suspendidos.Item("Fecha_Ingreso", nFila).Value
            Me.Jefe = Me.dgv_Busca_Suspendidos.Item("Jefe_Inmediato", nFila).Value
            Me.Motivo = Me.dgv_Busca_Suspendidos.Item("Motivo", nFila).Value

            Me.FechaAccidente = Me.dgv_Busca_Suspendidos.Item("FechaAccidente", nFila).Value
            Me.FechaAlta = Me.dgv_Busca_Suspendidos.Item("FechaAlta", nFila).Value

            Me.FechaInicio = Me.dgv_Busca_Suspendidos.Item("FechaInicio", nFila).Value
            Me.FechaFinal = Me.dgv_Busca_Suspendidos.Item("FechaFinal", nFila).Value


            Me.CausaDiagnostico = Me.dgv_Busca_Suspendidos.Item("CausaDiagnostico", nFila).Value


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Ficha = ""
            Me.Nombre = ""
            Me.Area = ""
            Me.Departamento = ""
            Me.Cargo = ""
            Me.Fecha_Ingreso = ""
            Me.Jefe = ""
            Me.Motivo = ""
            Me.FechaInicio = ""
            Me.FechaFinal = ""
            Me.FechaAccidente = ""
            Me.FechaAlta = ""
            Me.CausaDiagnostico = ""

        End Try

        Me.Close()
    End Sub
End Class