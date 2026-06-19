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

    Public Sub New()
        hora = New DateTime()
    End Sub

    Public Sub asignarPicking(ByVal numPedidos As Integer)
        asignarPickingToPicker(numPedidos)
    End Sub


    Private Sub getPickers()
        pickers = New ArrayList()
        sql = "pa_sel_um_pickers_disponibles "
        Dim newPicker As Picker
        Dim num_card As String
        Dim empresas As New ArrayList
        Dim numEmpresas As Integer
        Dim dtaux2 As DataTable
        Dim dtPickersDisponibles As DataTable
        Dim dtUltimosPicker As DataTable
        Try
            
            oTrans.open()
            dtPickersDisponibles = oTrans.Obtiene(sql) 'dt


            sql = "pa_sel_um_pickearon_ultimo"
            dtUltimosPicker = oTrans.Obtiene(sql) 'dtaux2
            For Each dr As DataRow In dtPickersDisponibles.Rows
                empresas = New ArrayList
                Try
                    num_card = dr.Item("num_card")
                    Dim dtaux As DataTable
                    sql = "pa_sel_um_empresa_picker_asignado '" & num_card & "'"
                    dtaux = oTrans.Obtiene(sql)
                    For Each draux As DataRow In dtaux.Rows
                        empresas.Add(draux.Item("empresa"))
                    Next
                    newPicker = New Picker(dr.Item("nombre").ToString, empresas)
                    pickers.Add(newPicker)
                    dtaux = Nothing

                Catch ex As Exception
                End Try

            Next

            Dim auxArrayList As New ArrayList
            Dim nombrePicking As String
            Dim nombreAnterior As String
            For Each draux As DataRow In dtUltimosPicker.Rows 'Ultimos Pickers

                For Each aPicker As Picker In pickers 'pickers son pickers disponibles
                    nombrePicking = draux.Item("nombre_picking").ToString 'Obtiene el nombre del ultimo picker
                    If (nombrePicking.Length > 20) Then nombrePicking = nombrePicking.Substring(0, 20)

                    nombreAnterior = aPicker.getNombre
                    If (nombreAnterior.Length > 20) Then nombreAnterior = nombreAnterior.Substring(0, 20)

                    If (nombreAnterior.Equals(nombrePicking)) Then 'Valido que sea el mismo picker
                        auxArrayList.Add(pickers.IndexOf(aPicker)) 'Se Agrega el picker al Array
                        Exit For
                    End If
                Next

            Next

            'auxArrayList.Sort()
            Dim auxPicker As Picker
            Dim offset As Integer = 0
            Dim pickers2 As New ArrayList

            For i As Integer = 0 To pickers.Count - 1
                If (pickers.Item(i).getnombre().Equals("OFICINA")) Then
                    pickers2.Add(pickers.Item(i))
                End If
            Next

            For i As Integer = 0 To pickers.Count - 1
                If (auxArrayList.IndexOf(i) < 0) Then
                    If Not (pickers.Item(i).getnombre().Equals("OFICINA")) Then
                        pickers2.Add(pickers.Item(i))
                    End If
                End If
            Next
            For Each indice As Integer In auxArrayList
                If Not (pickers.Item(indice).getnombre().Equals("OFICINA")) Then
                    pickers2.Add(pickers.Item(indice))
                End If
            Next

            pickers = pickers2
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
            'If dr.Item("texto").ToString.ToLower = "cd_central" Then ' gs_usuario.ToLower Or 
            '    dr.Item("texto1").ToString.ToLower = gs_usuario.ToLower Or _
            'gi_tipo_usuario = 1 Then

            sql = "pa_var_um_facturas_picking_completo '" & hora.Now.Date.AddDays(-5).ToString("dd/MM/yyyy").ToString & "','" & hora.Now.Date.AddDays(2).ToString("dd/MM/yyyy").ToString & "','" & _
                        dr.Item("CODIGO").ToString & "','" & dr.Item("empresa") & "', 5"

            dt = oTrans.Obtiene(sql)
            If dt.Rows.Count > 0 Then
                For Each dr2 As DataRow In dt.Rows
                    Try
                        If (Not dr2.Item("empresa").Equals("ALAMSA")) Then
                            documentosPicking.Add(New documentoPicking(dr2.Item("empresa").ToString, dr2.Item("tipodocto").ToString, dr2.Item("numero").ToString, dr2.Item("correlativo").ToString, dr2.Item("fecha").ToString, dr2.Item("Cliente").ToString))
                        End If

                    Catch ex As Exception
                    End Try
                Next
            End If
            'End If
        Next
        oTrans.close()
    End Sub


    Private Sub asignarPickingToPicker(ByVal numPedidos As Integer)
        Dim numDocumentosPicking As Integer
        Dim pickerActual As Integer = 0

        Dim auxInt As Integer = 0
        getPickers()  ''Array de Pickers
        getPickingPendientes() 'Array de Documentos
        Dim cuatro As Integer
        numDocumentosPicking = documentosPicking.Count
        Dim longitud As Integer = 3
        Dim indice As Integer
        Dim empresas As New ArrayList
        Dim encontro As Boolean = False
        Dim limite As Integer = 0
        Dim documentoOficinaIndice As New ArrayList

        Dim ncontadorVecesWhile As Integer = 0
        Dim ncontadorVecesFor As Integer = 0
        While (numDocumentosPicking > auxInt)
            ncontadorVecesWhile += 1

            If ncontadorVecesWhile > 500 Then Exit While

            ncontadorVecesFor = 0
            For Each aPicker As Picker In pickers

                If ncontadorVecesFor > 500 Then Exit For

                If (aPicker.getNombre.Equals("OFICINATMEP")) Then
                    For Each Documento As documentoPicking In documentosPicking
                        sql = "pa_var_um_cliente_empresa_picking '" & Documento.getEmpresa & _
                        "','" & Documento.getCtacte & "','10000000'"
                        Try
                            dt = New DataTable
                            oTrans.open()
                            dt = oTrans.Obtiene(sql)
                        Catch ex As Exception
                        Finally
                            oTrans.close()
                        End Try
                        If dt.Rows.Count > 0 Then
                            'Vamos a guardar los indices
                            indice = documentosPicking.IndexOf(Documento)
                            documentoOficinaIndice.Add(indice)

                        End If
                    Next
                    Dim offset As Integer = 0
                    For Each ind As Integer In documentoOficinaIndice
                        ind = ind - offset
                        documentosPicking.Item(ind).setPicker("OFICINA")
                        documentosPickingAsignados.Add(documentosPicking(ind))
                        documentosPicking.RemoveAt(ind)
                        offset += 1
                        auxInt += 1
                    Next


                Else
                    cuatro = 0

                    If (documentosPicking.Count <= longitud) Then
                        longitud = documentosPicking.Count - 1
                    End If
                    empresas = aPicker.getEmpresas()

                    For i As Integer = 0 To longitud

                        For Each Documento As documentoPicking In documentosPicking
                            If aPicker.getIndexOf(Documento.getEmpresa()) >= 0 Then
                                ' indice = aPicker.getIndexOf(Documento.getEmpresa())
                                indice = documentosPicking.IndexOf(Documento)
                                encontro = True
                                Exit For
                            End If
                        Next
                        If (encontro) Then
                            documentosPicking.Item(indice).setPicker(aPicker.getNombre)
                            documentosPickingAsignados.Add(documentosPicking(indice))
                            documentosPicking.RemoveAt(indice)

                            auxInt += 1
                            cuatro += 1
                            encontro = False
                        End If
                        ' indice = Abs(longitud - i)

                        If (auxInt >= numDocumentosPicking) Then
                            Exit For
                        End If
                    Next

                    If (auxInt >= numDocumentosPicking) Then
                        Exit For
                    End If
                End If
                If (limite > 100) Then
                    auxInt = numDocumentosPicking
                    Exit For
                End If
                limite += 1
            Next


        End While

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
        Private empresa, tipodocto, numero, correlativo, fecha, picker, ctacte As String
        Public Sub New(ByVal empresa As String, ByVal tipodcto As String, ByVal numero As String, ByVal correlativo As String, ByVal fecha As String, ByVal ctacte As String)
            Me.empresa = empresa
            Me.tipodocto = tipodcto
            Me.numero = numero
            Me.correlativo = correlativo
            Me.fecha = fecha
            Me.ctacte = ctacte
            Me.picker = Nothing
        End Sub
        Public Sub setPicker(ByVal picker As String)
            Me.picker = picker
        End Sub
        Public Function getCtacte() As String
            Return ctacte
        End Function
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
        Private empresas As ArrayList
        Public Sub New(ByVal nombre As String)
            Me.nombre = nombre
            Me.empresa = ""
        End Sub
        Public Sub New(ByVal nombre As String, ByVal empresa As String)
            Me.nombre = nombre
            Me.empresa = empresa
        End Sub

        Public Sub New(ByVal nombre As String, ByVal empresas As ArrayList)
            Me.nombre = nombre
            Me.empresas = empresas
        End Sub

        Public Function getEmpresas() As ArrayList
            Return empresas
        End Function

        Public Function getEmpresasValue(ByVal i As Integer) As String
            Return empresas.Item(i)
        End Function

        Public Function getIndexOf(ByVal s As String) As Integer
            Return empresas.IndexOf(s)
        End Function
        Public Function getEmpresasLenght() As Integer
            Return empresas.Count
        End Function

        Public Function getNombre() As String
            Return nombre
        End Function

        Public Function getEmpresa() As String
            Return empresa
        End Function

    End Class
End Class

