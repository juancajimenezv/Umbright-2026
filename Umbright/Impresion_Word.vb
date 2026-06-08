Imports Microsoft.Office.Interop
Module Impresion_Word

    Public Sub Imprimir_entrega(ByVal pnumero_entrega As Integer)
        Dim array(1) As String
        Dim ls_sql As String
        Dim icount As Integer

        Dim dr As DataRow
        Dim otabla As DataTable
        Dim otrans As Transaccional.Conexion_mysql

        Dim WordApp As New Word.ApplicationClass

        Dim fileName As Object

        Try
            otrans = New Transaccional.Conexion_mysql("onBase")
            otrans.open()

            ls_sql = "call pa_sel_um_pg_parametros_sistema"
            otabla = otrans.Obtiene(ls_sql)
            fileName = otabla.Rows(0)("path_cotizacion")
            fileName = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\it\Entrega de Celulares.dot"

            ls_sql = "call pa_var_um_act_movimiento_detalle (" & pnumero_entrega & ")"
            otabla = otrans.Obtiene(ls_sql)

            otrans.close()
            otrans = Nothing

            Dim adoc As Word.Document = WordApp.Documents.Add(fileName)

            'array = Split(FormatDateTime(Me.txt_fecha.Text, DateFormat.LongDate), ",")

            'adoc.Bookmarks.Item("numero_cotizacion").Range.Text = Me.lbl_numero.Text
            adoc.Bookmarks.Item("fecha").Range.Text = otabla.Rows(0)("fecha_movimiento")
            adoc.Bookmarks.Item("usuario_recibe").Range.Text = StrConv(otabla.Rows(0)("nombre"), VbStrConv.ProperCase)
            adoc.Bookmarks.Item("empresa_usuario").Range.Text = StrConv(otabla.Rows(0)("empresa").ToString, VbStrConv.ProperCase) & "/" & StrConv(otabla.Rows(0)("ubicacion"), VbStrConv.ProperCase)
            adoc.Bookmarks.Item("txt_ubicacion").Range.Text = StrConv(otabla.Rows(0)("ubicacion"), VbStrConv.ProperCase)  'StrConv(otabla.Rows(0)("nombre"), VbStrConv.ProperCase)
            adoc.Bookmarks.Item("txt_empresa").Range.Text = StrConv(otabla.Rows(0)("empresa").ToString, VbStrConv.ProperCase)
            adoc.Bookmarks.Item("observaciones").Range.Text = otabla.Rows(0)("observaciones").ToString
            adoc.Bookmarks.Item("observaciones2").Range.Text = otabla.Rows(0)("observaciones2").ToString
            adoc.Bookmarks.Item("observaciones3").Range.Text = otabla.Rows(0)("observaciones3").ToString
            adoc.Bookmarks.Item("observaciones4").Range.Text = otabla.Rows(0)("observaciones4").ToString

            For icount = 1 To otabla.Rows.Count
                adoc.Tables.Item(1).Rows.Add(adoc.Tables.Item(1).Cell(2, 4))
            Next

            'If Me.chk_precio_paquete.CheckState = CheckState.Checked Then
            'adoc.Tables.Item(1).Rows.Add(adoc.Tables.Item(1).Cell(2, 4))
            'End If

            icount = 2
            For Each dr In otabla.Rows
                adoc.Tables.Item(1).Cell(icount, 1).Range.InsertAfter(dr.Item("cantidad"))
                adoc.Tables.Item(1).Cell(icount, 2).Range.InsertAfter(dr.Item("tipo_producto").ToString & " " & dr.Item("descripcion_producto").ToString)
                adoc.Tables.Item(1).Cell(icount, 3).Range.InsertAfter(dr.Item("marca"))
                adoc.Tables.Item(1).Cell(icount, 4).Range.InsertAfter(dr.Item("modelo"))
                'adoc.Tables.Item(1).Cell(icount, 5).Range.InsertAfter(dr.Item("serie"))
                adoc.Tables.Item(1).Cell(icount, 5).Range.InsertAfter(dr.Item("imei"))

                icount = icount + 1
            Next

            'adoc.Tables.Item(1).Cell(icount, 1).Range.InsertAfter("TOTAL")
            'adoc.Tables.Item(1).Cell(icount, 1).Range.Bold = True
            'adoc.Tables.Item(1).Cell(icount, 4).Range.InsertAfter(Me.lbl_total.Text)
            'adoc.Tables.Item(1).Cell(icount, 4).Range.Bold = True

            'If Me.chk_precio_paquete.CheckState = CheckState.Checked Then
            '    adoc.Tables.Item(1).Cell(icount + 1, 1).Range.InsertAfter("TOTAL CON DESCUENTO")
            '    adoc.Tables.Item(1).Cell(icount + 1, 1).Range.Bold = True
            '    adoc.Tables.Item(1).Cell(icount + 1, 4).Range.InsertAfter(Me.lbl_total_desc.Text)
            '    adoc.Tables.Item(1).Cell(icount + 1, 4).Range.Bold = True

            'End If
            adoc.Bookmarks.Item("txt_usuario").Range.Text = StrConv(otabla.Rows(0)("nombre"), VbStrConv.ProperCase)
            'adoc.Bookmarks.Item("txt_empresa").Range.Text = StrConv(otabla.Rows(0)("ubicacion"), VbStrConv.ProperCase)
            'adoc.Bookmarks.Item("email_ejecutivo").Range.Text = otabla.Rows(0)("email_ejecutivo")
            'adoc.Bookmarks.Item("telefono_ejecutivo").Range.Text = otabla.Rows(0)("telefono_ejecutivo")
            'adoc.Bookmarks.Item("nombre_mes").Range.Text = Format(Convert.ToDateTime(Me.txt_fecha.Text), "MMMM")

            WordApp.Visible = True

            adoc.Activate()
            adoc = Nothing
            WordApp = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        otrans = Nothing
    End Sub

    Public Sub Imprimir_Recepcion(ByVal pnumero_entrega As Integer)
        Dim array(1) As String
        Dim ls_sql As String
        Dim icount As Integer

        Dim dr As DataRow
        Dim otabla As DataTable
        Dim otrans As Transaccional.Conexion_mysql

        Dim WordApp As New Word.ApplicationClass
        Dim fileName As Object

        Try
            otrans = New Transaccional.Conexion_mysql("onBase")
            otrans.open()

            ls_sql = "call pa_sel_um_pg_parametros_sistema"
            otabla = otrans.Obtiene(ls_sql)
            fileName = otabla.Rows(0)("path_cotizacion")
            fileName = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\it\Recepcion de Equipo.dot"

            ls_sql = "call pa_var_um_act_movimiento_detalle (" & pnumero_entrega & ")"
            otabla = otrans.Obtiene(ls_sql)

            otrans.close()
            otrans = Nothing

            Dim adoc As Word.Document = WordApp.Documents.Add(fileName)

            adoc.Bookmarks.Item("txt_fecha").Range.Text = otabla.Rows(0)("fecha_movimiento")
            adoc.Bookmarks.Item("txt_usuario_entrega").Range.Text = StrConv(otabla.Rows(0)("nombre"), VbStrConv.ProperCase)
            adoc.Bookmarks.Item("txt_empresa_usuario").Range.Text = StrConv(otabla.Rows(0)("ubicacion"), VbStrConv.ProperCase)
            adoc.Bookmarks.Item("txt_observaciones").Range.Text = otabla.Rows(0)("observaciones")

            For icount = 1 To otabla.Rows.Count
                adoc.Tables.Item(1).Rows.Add(adoc.Tables.Item(1).Cell(2, 4))
            Next

            icount = 2
            For Each dr In otabla.Rows
                adoc.Tables.Item(1).Cell(icount, 1).Range.InsertAfter(dr.Item("cantidad"))
                adoc.Tables.Item(1).Cell(icount, 2).Range.InsertAfter(dr.Item("descripcion_producto"))
                adoc.Tables.Item(1).Cell(icount, 3).Range.InsertAfter(dr.Item("marca"))
                adoc.Tables.Item(1).Cell(icount, 4).Range.InsertAfter(dr.Item("modelo"))
                adoc.Tables.Item(1).Cell(icount, 5).Range.InsertAfter(dr.Item("serie"))
                adoc.Tables.Item(1).Cell(icount, 6).Range.InsertAfter(dr.Item("imei"))

                icount = icount + 1
            Next

            adoc.Bookmarks.Item("txt_usuario").Range.Text = StrConv(otabla.Rows(0)("nombre"), VbStrConv.ProperCase)
            adoc.Bookmarks.Item("txt_empresa").Range.Text = StrConv(otabla.Rows(0)("ubicacion"), VbStrConv.ProperCase)

            WordApp.Visible = True

            adoc.Activate()
            adoc = Nothing
            WordApp = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        otrans = Nothing

    End Sub

End Module
