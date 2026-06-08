Imports System.Collections
Imports System.Math
Class asignarUsuarioPicking
    Private pickers As New ArrayList()
    Private documentosPicking As New ArrayList()
    Private documentosPickingAsignados As New ArrayList()
    Private oTrans As New Transaccional.Conexion("flexline")
    Private sql As String
    Private dt As New DataTable
    Private hora, hora2 As DateTime
    Dim ds_picking As New DataSet

    Public Sub New()
        hora = New DateTime()
    End Sub

    Public Sub asignarPicking(ByVal numPedidos As Integer)
        asignarPickingToPicker(numPedidos)
    End Sub
    Private Sub getPickers()
        sql = "pa_sel_um_pickers_disponibles 'LUNES'"
        Dim newPicker As Picker
        Try
            oTrans.open()
            dt = oTrans.Obtiene(sql)
            For Each dr As DataRow In dt.Rows
                Try
                    newPicker = New Picker(dr.Item("nombre").ToString, dr.Item("empresa").ToString)
                    pickers.Add(newPicker)
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        Finally
            oTrans.close()
        End Try
    End Sub
    Public Sub getPickingPendientes()
        Dim dtaux As DataTable
        oTrans.open()
        sql = "pa_sel_um_gen_tabcod null,'GEN_DOCTO_PICKING',null"
        dtaux = oTrans.Obtiene(sql)
        Dim newDocumentoPicking As documentoPicking

        For Each dr As DataRow In dtaux.Rows
            If dr.Item("texto").ToString.ToLower = gs_usuario.ToLower Or _
                dr.Item("texto1").ToString.ToLower = gs_usuario.ToLower Or _
                gi_tipo_usuario = 1 Then

                sql = "pa_var_um_facturas_picking_completo '" & hora.Now.Date.AddDays(-5).ToString("dd/MM/yyyy").ToString & "','" & hora.Now.Date.ToString("dd/MM/yyyy").ToString & "','" & _
                            dr.Item("CODIGO").ToString & "','" & dr.Item("empresa") & "', 5"

                dt = oTrans.Obtiene(sql)
                If dt.Rows.Count > 0 Then
                    For Each dr2 As DataRow In dt.Rows
                        Try
                            documentosPicking.Add(New documentoPicking(dr2.Item("empresa").ToString, dr2.Item("tipodocto").ToString, dr2.Item("numero").ToString, dr2.Item("correlativo").ToString, dr2.Item("fecha").ToString))
                        Catch ex As Exception
                        End Try
                    Next
                End If
            End If
        Next
        oTrans.close()
    End Sub
    Private Sub asignarPickingToPicker(ByVal numPedidos As Integer)
        Dim numDocumentosPicking As Integer
        Dim pickerActual As Integer = 0

        Dim auxInt As Integer = 0
        getPickers()
        getPickingPendientes()

        numDocumentosPicking = documentosPicking.Count
        Dim longitud As Integer = 3
        Dim indice As Integer
        For Each aPicker As Picker In pickers
            If (documentosPicking.Count <= longitud) Then
                longitud = documentosPicking.Count - 1
            End If
            For i As Integer = 0 To longitud
                indice = abs(longitud - i)
                documentosPicking.Item(indice).setPicker(aPicker.getNombre)
                documentosPickingAsignados.Add(documentosPicking(indice))
                documentosPicking.RemoveAt(indice)

                auxInt += 1
                If (auxInt >= numDocumentosPicking) Then
                    Exit For
                End If
            Next

            If (auxInt >= numDocumentosPicking) Then
                Exit For
            End If
        Next

        guardarAsignacionesPicking()

    End Sub
    Private Sub guardarAsignacionesPicking()
        ' empresa, tipodocto, numero, picker
        For Each documento As documentoPicking In documentosPickingAsignados
            sql = "pa_ins_um_asignar_documento_picking '" & documento.getEmpresa & "','" & _
            documento.getTipoDocto & "','" & documento.getNumero & "','" & documento.getPicker & "'"
            Try
                oTrans.open()
                oTrans.Ingresa(sql)
            Catch ex As Exception
            Finally
                oTrans.close()
            End Try
        Next
    End Sub

    

    Private Class documentoPicking
        Private empresa, tipodocto, numero, correlativo, fecha, picker As String
        Public Sub New(ByVal empresa As String, ByVal tipodcto As String, ByVal numero As String, ByVal correlativo As String, ByVal fecha As String)
            Me.empresa = empresa
            Me.tipodocto = tipodcto
            Me.numero = numero
            Me.correlativo = correlativo
            Me.fecha = fecha
            Me.picker = Nothing
        End Sub
        Public Sub setPicker(ByVal picker As String)
            Me.picker = picker
        End Sub

        Public Function getPicker() As String
            Return picker
        End Function

        Public Function getEmpresa() As String
            Return empresa
        End Function

        Public Function getTipoDocto() As String
            Return tipodocto
        End Function

        Public Function getNumero() As String
            Return numero
        End Function

        Public Function getCorrelativo() As String
            Return correlativo
        End Function

        Public Function getFecha() As String
            Return fecha
        End Function

    End Class

    Private Class Picker
        Private nombre As String
        Private empresa As String

        Public Sub New(ByVal nombre As String, ByVal empresa As String)
            Me.nombre = nombre
            Me.empresa = empresa
        End Sub

        Public Function getNombre() As String
            Return nombre
        End Function

        Public Function getEmpresa() As String
            Return empresa
        End Function

    End Class
End Class

