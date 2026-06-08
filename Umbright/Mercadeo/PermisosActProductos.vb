Imports System.Data
Imports System.Collections.Generic

' Helper compartido entre Individual y Masiva.
' Carga los permisos del usuario para las sub-opciones 'mer_actProd_<columna>'
' y permite consultar empresas/columnas con permiso.
Public Module PermisosActProductos

    ' empresa -> conjunto de columnas permitidas
    Private Dim_Permisos As Dictionary(Of String, HashSet(Of String))

    Public Sub Cargar()
        Dim_Permisos = New Dictionary(Of String, HashSet(Of String))
        Dim clsGen As New ClasesGenerales.General
        Try
            Dim sql As String =
                "SELECT ump.empresa, " &
                "       SUBSTRING(mo.nombre_opcion, LEN('mer_actProd_')+1, 100) AS col " &
                "  FROM flexline.sg_usuario_menu_opcion_empresa ump " &
                "  JOIN flexline.sg_menu_opcion mo ON mo.cod_opcion = ump.cod_opcion " &
                " WHERE ump.usuario = '" & gs_usuario.Replace("'", "''") & "' " &
                "   AND mo.nombre_opcion LIKE 'mer_actProd_%' " &
                "   AND mo.estado = 1"
            Dim dt As DataTable = clsGen.selectQuery("FlexLine", sql)
            For Each r As DataRow In dt.Rows
                Dim emp As String = r("empresa").ToString().Trim()
                Dim col As String = r("col").ToString().Trim().ToLower()
                If Not Dim_Permisos.ContainsKey(emp) Then Dim_Permisos.Add(emp, New HashSet(Of String))
                Dim_Permisos(emp).Add(col)
            Next
        Catch
        Finally
            clsGen = Nothing
        End Try
    End Sub

    ' Admin (gi_tipo_usuario = 1) tiene permiso total
    Public Function TienePermiso(emp As String, col As String) As Boolean
        If gi_tipo_usuario = 1 Then Return True
        If Dim_Permisos Is Nothing Then Return False
        If Not Dim_Permisos.ContainsKey(emp) Then Return False
        Return Dim_Permisos(emp).Contains(col.ToLower())
    End Function

    ' Empresas donde el usuario tiene al menos un permiso. Nothing = admin (todas)
    Public Function EmpresasConPermiso() As HashSet(Of String)
        If gi_tipo_usuario = 1 Then Return Nothing
        Dim s As New HashSet(Of String)
        If Dim_Permisos IsNot Nothing Then
            For Each kv As KeyValuePair(Of String, HashSet(Of String)) In Dim_Permisos
                s.Add(kv.Key)
            Next
        End If
        Return s
    End Function

    ' Columnas con permiso en la empresa dada. Nothing = admin (todas)
    Public Function ColumnasConPermiso(emp As String) As HashSet(Of String)
        If gi_tipo_usuario = 1 Then Return Nothing
        If Dim_Permisos IsNot Nothing AndAlso Dim_Permisos.ContainsKey(emp) Then Return Dim_Permisos(emp)
        Return New HashSet(Of String)
    End Function

    ' True si el usuario tiene permiso para esta columna en alguna empresa (para mostrar/ocultar UI global)
    Public Function ColumnaUsadaEnAlguna(col As String) As Boolean
        If gi_tipo_usuario = 1 Then Return True
        If Dim_Permisos Is Nothing Then Return False
        For Each kv As KeyValuePair(Of String, HashSet(Of String)) In Dim_Permisos
            If kv.Value.Contains(col.ToLower()) Then Return True
        Next
        Return False
    End Function

End Module
