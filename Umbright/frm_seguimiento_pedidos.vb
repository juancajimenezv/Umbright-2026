Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop
Imports CRAXDRT
Public Class frm_seguimiento_pedidos

    Dim ods1 As New DataSet


    Private Sub crear_estructura()

        Dim dt1 As DataTable

        dt1 = New DataTable("lista")
        ods1 = New DataSet




        dt1.Columns.Add(New DataColumn("numero_flex", GetType(String)))
        dt1.Columns.Add(New DataColumn("forma_pago", GetType(String)))
        dt1.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt1.Columns.Add(New DataColumn("operacion", GetType(String)))
        dt1.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt1.Columns.Add(New DataColumn("razonsocial", GetType(String)))
        dt1.Columns.Add(New DataColumn("vendedor", GetType(String)))
        dt1.Columns.Add(New DataColumn("origen", GetType(String)))


        ods1.Tables.Add(dt1)
        Me.dgv_pedidos.DataSource = ods1.Tables("lista")
    End Sub

    Private Sub buscar_informacion()
        Dim myoTrans As New Transaccional.Conexion_mysql("onBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL, lsSql_, ls_sql, ls_sqls As String
        Dim dtPedidosFlexAprobados, dtPedidosFlex As DataTable
        Dim dt, dt1, dt2, dt3 As DataTable
        Dim draux As DataRow
        Dim total As Integer
        Dim fechai, fechaf, fecha_pedido As String
        Dim longitud As String

        ods1.Tables("lista").Rows.Clear()

        Try
            myoTrans.open()
            Otrans.open()




            fechai = Me.dtp_fecha_inicio.Value.ToString("yyyy/MM/dd").Replace("/", "-") & " 00:00:00"
            fechaf = Me.dtp_fecha_final.Value.ToString("yyyy/MM/dd").Replace("/", "-") & " 23:59:00"


            lsSQL = "select * from documento d " & _
                    " Inner Join ctacte c on d.empresa = c.empresa and d.cliente = c.ctacte and c.tipoctacte = 'cliente' " & _
                    "where  d.fecha between '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "' and '" & Me.dtp_fecha_final.Value.ToString("dd/MM/yyyy") & "' and d.tipodocto in ('pedido al credito','pedido al contado','pedido al credito xe','pedido al contado xe')"
            dtPedidosFlex = Otrans.Obtiene(lsSQL)


            For Each dr1 As DataRow In dtPedidosFlex.Rows
                draux = ods1.Tables("lista").NewRow

                draux.Item("numero_flex") = dr1.Item("numero")
                draux.Item("forma_pago") = dr1.Item("tipodocto")
                draux.Item("fecha") = dr1.Item("fechaumodif")
                draux.Item("operacion") = "3.GrabadoFlex"
                draux.Item("cliente") = dr1.Item("cliente")
                draux.Item("razonsocial") = dr1.Item("razonsocial")
                draux.Item("vendedor") = dr1.Item("vendedor")
                Try
                    draux.Item("origen") = dr1.Item("comentario1").ToString.Substring(0, 8)
                Catch ex As Exception
                End Try


                ods1.Tables("lista").Rows.Add(draux)
            Next




            lsSQL = "select * from documento d " & _
                    " Inner Join gen_log_documento gl on d.empresa = gl.empresa and d.tipodocto = gl.tipodocto and d.numero = gl.numero  and gl.estado = 'S'" & _
                    " Inner Join ctacte c on d.empresa = c.empresa and d.cliente = c.ctacte and c.tipoctacte = 'cliente' " & _
                    "where  d.fecha between '" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "' and '" & Me.dtp_fecha_final.Value.ToString("dd/MM/yyyy") & "' and d.tipodocto in ('pedido al credito','pedido al contado','pedido al credito xe','pedido al contado xe')"
            dtPedidosFlexAprobados = Otrans.Obtiene(lsSQL)


            For Each dr1 As DataRow In dtPedidosFlexAprobados.Rows
                draux = ods1.Tables("lista").NewRow

                draux.Item("numero_flex") = dr1.Item("numero")
                draux.Item("forma_pago") = dr1.Item("tipodocto")
                draux.Item("fecha") = dr1.Item("fechaumodif")
                draux.Item("operacion") = "4.Aprobacion"
                draux.Item("cliente") = dr1.Item("cliente")
                draux.Item("razonsocial") = dr1.Item("razonsocial")
                draux.Item("vendedor") = dr1.Item("vendedor")

                ods1.Tables("lista").Rows.Add(draux)
            Next




            '    lsSQL = "SELECT a.numero_pedido,a.numero_flex,a.forma_pago,a.fecha_pedido,a.ctacte,a.fecha_proceso,b.cod_tipo_usuario,b.nombre,c.razonsocial FROM mov_pedidos_encabezado a " & _
            '    " inner join seg_usuario b on a.usuario_grabo=b.usuario " & _
            '    " inner join  mov_cliente c on a.ctacte=c.ctacte and a.empresa=c.empresa" & _
            '" where a.fecha_pedido between '" & fechai & "' and '" & fechaf & "'   and a.empresa='" & gs_empresa & "' order by a.fecha_pedido asc"
            lsSQL = "SELECT a.numero_pedido,a.numero_flex,a.forma_pago,a.fecha_pedido,a.ctacte,a.fecha_proceso,b.cod_tipo_usuario,b.nombre,c.razonsocial FROM mov_pedidos_encabezado a " & _
                " inner join seg_usuario b on a.usuario_grabo=b.usuario " & _
                " inner join  mov_cliente c on a.ctacte=c.ctacte and a.empresa=c.empresa" & _
                " where a.fecha_pedido between '" & fechai & "' and '" & fechaf & "'  order by a.fecha_pedido asc"
            dt = myoTrans.Obtiene(lsSQL)
            'ds.Tables("productos").Rows.Clear()
            'Me.dgv_pedidos.DataSource = Nothing

            If dt.Rows.Count > 0 Then
              

                For Each dr As DataRow In dt.Rows
                    '6 hacer concatenacion de fecha pedido
                    If dr.Item("cod_tipo_usuario").ToString = 6 Then

                        'longitud = dr.Item("numero_pedido").ToString
                        'longitud = Convert.ToInt32(dr.Item("numero_pedido").ToString)

                        If dr.Item("numero_pedido").ToString.Length = 7 Then
                            fecha_pedido = dr.Item("numero_pedido").ToString.Substring(1, 2) & ":" & dr.Item("numero_pedido").ToString.Substring(3, 2) & ":" & dr.Item("numero_pedido").ToString.Substring(5, 2)
                        Else
                            fecha_pedido = dr.Item("numero_pedido").ToString.Substring(2, 2) & ":" & dr.Item("numero_pedido").ToString.Substring(4, 2) & ":" & dr.Item("numero_pedido").ToString.Substring(6, 2)
                        End If




                        draux = ods1.Tables("lista").NewRow
                        draux.Item("numero_flex") = dr.Item("numero_flex")
                        draux.Item("forma_pago") = dr.Item("forma_pago")
                        draux.Item("fecha") = dr.Item("fecha_pedido").ToString.Substring(0, 10) & " " & fecha_pedido
                        draux.Item("operacion") = "1.Grabo pedido"
                        draux.Item("cliente") = dr.Item("ctacte")
                        draux.Item("razonsocial") = dr.Item("razonsocial")
                        draux.Item("vendedor") = dr.Item("nombre")
                        ods1.Tables("lista").Rows.Add(draux)
                    Else

                        draux = ods1.Tables("lista").NewRow
                        draux.Item("numero_flex") = dr.Item("numero_flex")
                        draux.Item("forma_pago") = dr.Item("forma_pago")
                        draux.Item("fecha") = dr.Item("fecha_pedido")
                        draux.Item("operacion") = "1.Grabo pedido"
                        draux.Item("cliente") = dr.Item("ctacte")
                        draux.Item("razonsocial") = dr.Item("razonsocial")
                        draux.Item("vendedor") = dr.Item("nombre")
                        ods1.Tables("lista").Rows.Add(draux)



                    End If
                    
                    draux = ods1.Tables("lista").NewRow
                    draux.Item("numero_flex") = dr.Item("numero_flex")
                    draux.Item("forma_pago") = dr.Item("forma_pago")
                    draux.Item("fecha") = dr.Item("fecha_proceso")
                    draux.Item("operacion") = "2.Sincronizo"
                    draux.Item("cliente") = dr.Item("ctacte")
                    draux.Item("razonsocial") = dr.Item("razonsocial")
                    draux.Item("vendedor") = dr.Item("nombre")
                    ods1.Tables("lista").Rows.Add(draux)

                Next



                'lsSql_ = "select * from documento where numero='" & dr.Item("numero_flex") & "' and cliente='" & dr.Item("ctacte") & "' and tipodocto in ('pedido al credito','pedido al contado','pedido al credito xe','pedido al contado xe') and empresa='" & gs_empresa & "'"
                'dt1 = Otrans.Obtiene(lsSql_)




                'If dt1.Rows.Count > 0 Then
                '    total = dt1.Rows.Count + total

                For Each dr As DataRow In dtPedidosFlex.Rows


                    ls_sql = "select distinct a.empresa, a.tipodocto,b.numero,b.fechamodif,b.fechaumodif,b.cliente, b.vendedor from documentod a" & _
                            " inner join documento b on a.empresa = b.empresa and a.tipodocto = b.tipodocto and a.correlativo=b.correlativo" & _
                            " where a.correlativoorigen='" & dr.Item("correlativo").ToString & "' and b.cliente='" & dr.Item("cliente").ToString & "'" & _
                            " and a.empresa='" & dr.Item("empresa").ToString & "'"
                    dt2 = Otrans.Obtiene(ls_sql)
                    If dt2.Rows.Count > 0 Then
                        For Each dr1 As DataRow In dt2.Rows
                            draux = ods1.Tables("lista").NewRow
                            draux.Item("numero_flex") = dr.Item("numero")
                            draux.Item("forma_pago") = dr1.Item("tipodocto")
                            draux.Item("fecha") = dr1.Item("fechaumodif")
                            draux.Item("operacion") = "5.facturacion"
                            draux.Item("cliente") = dr1.Item("cliente")
                            draux.Item("razonsocial") = dr.Item("razonsocial")
                            draux.Item("vendedor") = dr1.Item("vendedor")

                            ods1.Tables("lista").Rows.Add(draux)



                            ls_sqls = "select * from gen_log_documento_tracking " & _
                            " where numero='" & dr1.Item("numero").ToString & "' and empresa='" & dr1.Item("empresa").ToString & "' and tipodocto='" & dr1.Item("tipodocto").ToString & "'"
                            dt3 = Otrans.Obtiene(ls_sqls)

                            If dt3.Rows.Count > 0 Then

                                For Each dr2 As DataRow In dt3.Rows
                                    draux = ods1.Tables("lista").NewRow
                                    draux.Item("numero_flex") = dr2.Item("numero")
                                    draux.Item("forma_pago") = dr2.Item("tipodocto")
                                    draux.Item("fecha") = dr2.Item("fecha_impresion_picking")
                                    draux.Item("operacion") = "6.picking"
                                    draux.Item("cliente") = dr.Item("cliente")
                                    draux.Item("razonsocial") = dr.Item("razonsocial")
                                    draux.Item("vendedor") = dr.Item("vendedor")

                                    ods1.Tables("lista").Rows.Add(draux)
                                Next
                                'Else

                                '    draux = ods1.Tables("lista").NewRow
                                '    draux.Item("numero_flex") = dr.Item("numero")
                                '    draux.Item("forma_pago") = ""
                                '    draux.Item("fecha") = Date.Now

                                '    draux.Item("operacion") = "No Picking"
                                '    draux.Item("cliente") = ""

                                '    ods1.Tables("lista").Rows.Add(draux)




                            End If
                        Next

                    Else

                        'draux = ods1.Tables("lista").NewRow
                        'draux.Item("numero_flex") = dr.Item("numero_flex")
                        'draux.Item("forma_pago") = ""
                        'draux.Item("fecha") = Date.Now

                        'draux.Item("operacion") = "No Facturaron"
                        'draux.Item("cliente") = ""

                        'ods1.Tables("lista").Rows.Add(draux)

                        'draux = ods1.Tables("lista").NewRow
                        'draux.Item("numero_flex") = dr.Item("numero_flex")
                        'draux.Item("forma_pago") = ""
                        'draux.Item("fecha") = Date.Now

                        'draux.Item("operacion") = "No Picking"
                        'draux.Item("cliente") = ""

                        'ods1.Tables("lista").Rows.Add(draux)




                    End If





                    ' End If

                Next




                'clsGen.Alinear_GridView(ods1.Tables("lista"), Me.dgv_pedidos, "", "", ",numero_flex,forma_pago,fecha,operacion,", ",,", "", ",numero_flex=50,forma_pago=100,fecha=100,operacion=100,", "", True, True, 200, 0)



            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Problemas Al Cargar la OC", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Otrans.close()
            Otrans = Nothing

            myoTrans.close()
            myoTrans = Nothing
            clsGen = Nothing

        End Try
    End Sub



    
    Private Sub exportar()

        DataTableToExcel(ods1.Tables(0).DefaultView.ToTable)

    End Sub

    Public Sub DataTableToExcel(ByVal pDataTable As DataTable)

        Dim vFileName As String '= Path.GetTempFileName()
        vFileName = Path.GetTempFileName()
        FileOpen(1, vFileName, OpenMode.Output)
        Dim sb As String = ""

        Dim dc As DataColumn
        For Each dc In pDataTable.Columns
            sb &= dc.Caption & Microsoft.VisualBasic.ControlChars.Tab
        Next
        PrintLine(1, sb)
        Dim i As Integer = 0
        Dim dr As DataRow
        For Each dr In pDataTable.Rows
            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If Not IsDBNull(dr(i)) Then
                    sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                Else
                    sb &= Microsoft.VisualBasic.ControlChars.Tab
                End If
                i += 1
            Next
            PrintLine(1, sb)
        Next
        FileClose(1)
        TextToExcel(vFileName)
    End Sub

    Public Sub TextToExcel(ByVal pFileName As String)
        Dim vFormato As Excel.XlRangeAutoFormat
        Dim Exc As Excel.Application = New Excel.Application
        Exc.Workbooks.OpenText(pFileName, , , , Excel.XlTextQualifier.xlTextQualifierNone, , True)
        Dim Wb As Excel.Workbook = Exc.ActiveWorkbook
        Dim Ws As Excel.Worksheet = CType(Wb.ActiveSheet, Excel.Worksheet)
        'Se le indica el formato al que queremos exportarlo
        Dim valor As Integer = 10
        If valor > -1 Then
            Select Case (valor)
                Case 10 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1
            End Select
            Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count)).AutoFormat(vFormato)
            pFileName = Path.GetTempFileName.Replace("tmp", "xls")
            File.Delete(pFileName)
            Exc.ActiveWorkbook.SaveAs(pFileName, Excel.XlTextQualifier.xlTextQualifierNone - 1)
        End If
        Exc.Quit()
        Ws = Nothing
        Wb = Nothing
        Exc = Nothing
        GC.Collect()
        If valor > -1 Then
            Dim p As System.Diagnostics.Process = New System.Diagnostics.Process
            p.EnableRaisingEvents = False
            System.Diagnostics.Process.Start(pFileName)
        End If
    End Sub

    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar.Click
        buscar_informacion()
        exportar()



    End Sub

    Private Sub frm_seguimiento_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructura()

    End Sub
End Class