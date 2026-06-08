Public Class frm_pedidosElSalvador
    ''1. Establecer Existencias DA/CD Central DIUVA
    ''2. Establecer Existencia de Divinos
    ''2. Establecer Presupuesto para 4 Meses
    ''3. Establecer Disponibilidad Real
    ''4. Establecer Presupuesto Divinos 2 Meses
    ''5. Establecer Cantidad a Reservar

    Dim oDS As New DataSet()

    Private Sub crearEstructura()
        Dim dt As New DataTable("pedido")

        '        Inventario Divinos	Presupuesto Divinos (2 Meses)	Sugerido 1.5 Meses	Inventario DA	Inventario CD DIUVA	Presupuesto DIUVA 4 Meses	Disponible	Despacho	Solicitud Divinos

        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("codigoSV", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("uxc", GetType(String)))
        dt.Columns.Add(New DataColumn("inventario_divinos", GetType(Double)))
        dt.Columns.Add(New DataColumn("Presupuesto_Divinos", GetType(Double)))
        dt.Columns.Add(New DataColumn("Presupuesto_Divinos+01", GetType(Double)))
        dt.Columns.Add(New DataColumn("Sugerido", GetType(Double))) '1.5 Meses
        dt.Columns.Add(New DataColumn("Inventario_DA", GetType(Double)))
        dt.Columns.Add(New DataColumn("Inventario_CD", GetType(Double)))
        dt.Columns.Add(New DataColumn("Presupuesto_DiUva", GetType(Double))) '4 Meses
        dt.Columns.Add(New DataColumn("Presupuesto_DiUva+01", GetType(Double))) '4 Meses
        dt.Columns.Add(New DataColumn("Presupuesto_DiUva+02", GetType(Double))) '4 Meses
        dt.Columns.Add(New DataColumn("Presupuesto_DiUva+03", GetType(Double))) '4 Meses
        dt.Columns.Add(New DataColumn("Disponible", GetType(Double)))
        dt.Columns.Add(New DataColumn("Despacho", GetType(Double)))
        ods.Tables.Add(dt.Copy)
    End Sub


    Private Sub llenarProductos()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim drAux As DataRow

        Try
            otrans.open()
            dt = otrans.Obtiene("pa_var_um_producto_divinos")

            For Each dr As DataRow In dt.Rows
                drAux = oDS.Tables("pedido").NewRow
                drAux.Item("codigo") = dr.Item("CodigoGT")
                drAux.Item("codigoSV") = dr.Item("CodigoSV")
                drAux.Item("glosa") = dr.Item("glosa")
                drAux.Item("uxc") = dr.Item("uxc")
                drAux.Item("inventario_divinos") = 0
                drAux.Item("presupuesto_divinos") = 0
                drAux.Item("presupuesto_divinos+01") = 0
                drAux.Item("inventario_DA") = 0
                drAux.Item("inventario_CD") = 0


                For iCount As Integer = 0 To 3
                    Dim nDias As Integer = iCount * 30
                    Dim sCampo As String

                    If dt.DefaultView.Count > 0 Then
                        sCampo = "presupuesto_diuva"
                        If iCount > 0 Then sCampo += "+" & iCount.ToString.PadLeft(2, "0")

                        drAux.Item(sCampo) = 0
                    End If
                Next
 
                oDS.Tables("pedido").Rows.Add(drAux)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub llenarInventariosGT()
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()
            'lsSQL = "pa_var_um_existencias_producto 'DIUVA',null,'DA_CENTRAL'"
            'dt = Otrans.Obtiene(lsSQL)
            'For Each dr As DataRow In oDS.Tables("pedido").Rows
            '    dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo").ToString & "'"
            '    If dt.DefaultView.Count > 0 Then
            '        dr.Item("Inventario_DA") = dt.DefaultView(0).Item("Existencia") / dr.Item("uxc")
            '    End If
            'Next




            lsSQL = "scm.flexline.pa_sel_um_vs_detalle_dua 'DIUVA',null,1"
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In oDS.Tables("pedido").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo").ToString & "'"
                For Each drv As DataRowView In dt.DefaultView
                    dr.Item("inventario_da") = dr.Item("inventario_da") + drv.Item("saldo_bultos")
                Next
            Next


            lsSQL = "pa_var_um_existencias_producto 'DIUVA',null,'CD_CENTRAL'"
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In oDS.Tables("pedido").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo").ToString & "'"
                If dt.DefaultView.Count > 0 Then
                    dr.Item("Inventario_CD") = dt.DefaultView(0).Item("Existencia") / dr.Item("uxc")
                End If
            Next

            lsSQL = "pa_var_um_existencias_producto 'DIVINOS',null,'CD_CENTRAL'"
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In oDS.Tables("pedido").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigoSV").ToString & "'"
                If dt.DefaultView.Count > 0 Then
                    dr.Item("Inventario_divinos") = dt.DefaultView(0).Item("Existencia") / dr.Item("uxc")
                End If
            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub llenarPresupuesto()
        Dim Otrans As New Transaccional.Conexion("Umbralsa")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_ppt_presupuesto_general 'DIVINOS'," & Today.ToString("yyyyMM")
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In oDS.Tables("pedido").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo").ToString & "'"
                If dt.DefaultView.Count > 0 Then
                    dr.Item("presupuesto_divinos") = dt.DefaultView(0).Item("cantidad") / dr.Item("uxc")
                End If
            Next

            lsSQL = "pa_sel_um_ppt_presupuesto_general 'DIVINOS'," & Today.AddDays(30).ToString("yyyyMM")
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In oDS.Tables("pedido").Rows
                dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo").ToString & "'"
                If dt.DefaultView.Count > 0 Then
                    dr.Item("presupuesto_divinos+01") = dt.DefaultView(0).Item("cantidad") / dr.Item("uxc")
                End If
            Next


            For iCount As Integer = 0 To 3
                Dim nDias As Integer = iCount * 30
                Dim sCampo As String
                lsSQL = "pa_sel_um_ppt_presupuesto_general 'DIUVA'," & Today.AddDays(nDias).ToString("yyyyMM")
                dt = Otrans.Obtiene(lsSQL)
                For Each dr As DataRow In oDS.Tables("pedido").Rows
                    dt.DefaultView.RowFilter = "producto = '" & dr.Item("codigo").ToString & "'"
                    If dt.DefaultView.Count > 0 Then
                        sCampo = "presupuesto_diuva"
                        If iCount > 0 Then sCampo += "+" & iCount.ToString.PadLeft(2, "0")

                        dr.Item(sCampo) = dt.DefaultView(0).Item("cantidad") / dr.Item("uxc")
                    End If
                Next
            Next
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub totalizar()

        Dim dDisponible, dSugerido, dDespacho As Double
        For Each dr As DataRow In oDS.Tables("pedido").Rows
            dDisponible = 0

            Try
                dDisponible = dr.Item("inventario_da") + dr.Item("inventario_cd") - _
                            dr.Item("presupuesto_diuva") - dr.Item("presupuesto_diuva+01") - dr.Item("presupuesto_diuva+02") - dr.Item("presupuesto_diuva+03")
                If dDisponible < 0 Then dDisponible = 0

                dr.Item("disponible") = dDisponible

                dSugerido = (dr.Item("presupuesto_divinos") + (dr.Item("presupuesto_divinos+01") / 2)) - dr.Item("inventario_divinos")
                If dSugerido < 0 Then dSugerido = 0
                dr.Item("Sugerido") = dSugerido
                If dDisponible >= dSugerido Then
                    dDespacho = dSugerido
                ElseIf dDisponible > 0 Then
                    dDespacho = dDisponible
                Else
                    dDespacho = 0
                End If
                'dDespacho = dDisponible - dSugerido

                If dDespacho < 0 Then dDespacho = 0
                dr.Item("Despacho") = dDespacho


            Catch ex As Exception

            End Try

        Next
    End Sub

    Private Sub frm_pedidosElSalvador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        




    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        crearEstructura()
        llenarProductos()
        llenarInventariosGT()
        llenarPresupuesto()
        totalizar()
        Dim clsGen As New ClasesGenerales.General
        Me.DataGridView1.DataSource = oDS.Tables("pedido")
        clsGen.Alinear_GridView(oDS.Tables("pedido"), Me.DataGridView1, "", "", "", "", "", ",presupuesto_diuva=0,presupuesto_diuva+01=0,presupuesto_diuva+02=0,presupuesto_diuva+03=0,", "", True, True, 250, 0)
        clsGen = Nothing
    End Sub
End Class