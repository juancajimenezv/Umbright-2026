Imports System.Data
Imports System.Data.OleDb

Public Class frmCargaInformacionWalmart

    Dim encabezados_seleccionados As String = String.Empty
    Dim _dtregistros As DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Procesar_Excel()

    End Sub


    Public Function fImport(sPath As String, sExt As String) As DataTable
        Dim sCn As String = ""
        'llenar el dataset
        Dim ds As New DataSet()
        Dim dt As New DataTable()

        Try
            Dim hoja As String = "Hoja1"
            Dim Conex As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties=Excel 12.0;")

            Dim CmdOle As New OleDbCommand()

            CmdOle.Connection = Conex
            CmdOle.CommandType = CommandType.Text
            CmdOle.CommandText = "SELECT * FROM [" + hoja + "$A1:AE25000]"

            Dim AdaptadorOle As New OleDbDataAdapter(CmdOle.CommandText, Conex)


            AdaptadorOle.Fill(dt)
            dt.Columns.Add(New DataColumn("producto", GetType(String)))
            dt.Columns.Add(New DataColumn("glosa", GetType(String)))
            dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
            dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            dt.Columns.Add(New DataColumn("giro", GetType(String)))
            dt.Columns.Add(New DataColumn("mercaderista", GetType(String)))
            Try

                For Each dr As DataRow In dt.Rows
                    If dr.Item("storename").ToString.Length = 0 Then
                        dr.Delete()
                    End If
                Next
                dt.AcceptChanges()
            Catch ex As Exception

            End Try

            Try
                llenarProducto(dt)
            Catch ex As Exception

            End Try

            Me.DataGridView1.DataSource = dt

            _dtregistros = dt.Copy

            'llenar dataset con datos de Excel
        Catch ex As Exception
            Dim clsgen As New ClasesGenerales.General
            clsgen.Escribir_Log(ex.ToString)
            clsgen.Escribir_Log(ex.Message)
            clsgen = Nothing
        End Try
        Return dt
    End Function

    Private Sub llenarProducto(ByVal pdt As DataTable)

        Dim dt As DataTable = pdt.Copy
        Dim dtProductos As DataTable
        Dim dtEdiClientes As DataTable
        Dim dtClientes As DataTable
        Dim dtMercaderistas As DataTable
        Dim clsGen As New ClasesGenerales.General

        dt = clsGen.ValoresDistinto(pdt, "itemnbr".Split(","))

        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")


        Try
            myOtrans.open()

            For Each dr As DataRow In dt.Rows
                Try
                    dtProductos = clsGen.selectQuery("FlexLine", "pa_var_um_prodcodbarra_glosa '" & gs_empresa & "',null,null,'" & dr.Item("itemnbr").ToString.PadLeft(9, "0") & "'")

                    If dtProductos.Rows.Count > 0 Then

                        pdt.DefaultView.RowFilter = "itemnbr = '" & dr.Item("itemnbr").ToString & "'"
                        For Each drv As DataRowView In pdt.DefaultView
                            drv.Item("producto") = dtProductos.Rows(0).Item("producto").ToString
                            drv.Item("glosa") = dtProductos.Rows(0).Item("glosa").ToString
                            drv.Item("proveedor") = dtProductos.Rows(0).Item("subfamilia").ToString
                        Next

                    End If
                Catch ex As Exception

                End Try
            Next

            dtMercaderistas = clsGen.selectQuery("dwh", "pa_sel_um_mercaderista_cliente_proveedor '" & gs_empresa & "'")
            dtClientes = clsGen.selectQuery("flexline", "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE'")
            dtEdiClientes = myOtrans.Obtiene("call pa_sel_um_edi_cliente ('" & gs_empresa & "')")
            dt = clsGen.ValoresDistinto(pdt, "StoreNbr".Split(","))
            For Each dr As DataRow In dt.Rows
                dtEdiClientes.DefaultView.RowFilter = "store_number = " & dr.Item("StoreNbr")
                If dtEdiClientes.DefaultView.Count > 0 Then
                    pdt.DefaultView.RowFilter = "StoreNbr = '" & dr.Item("StoreNbr").ToString & "'"
                    For Each drv As DataRowView In pdt.DefaultView
                        drv.Item("ctacte") = dtEdiClientes.DefaultView(0).Item("ctacte").ToString
                        dtClientes.DefaultView.RowFilter = "ctacte = '" & dtEdiClientes.DefaultView(0).Item("ctacte").ToString & "'"

                        If dtClientes.DefaultView.Count > 0 Then
                            drv.Item("giro") = dtClientes.DefaultView(0).Item("nombre_cliente").ToString
                        End If

                    Next

                End If
            Next

            For Each dr As DataRow In pdt.Rows
                dtMercaderistas.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte") & "' and proveedor = '" & dr.Item("proveedor") & "'"
                If dtMercaderistas.DefaultView.Count > 0 Then
                    dr.Item("mercaderista") = dtMercaderistas.DefaultView(0).Item("mercaderista")
                Else
                    dtMercaderistas.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte") & "'"
                    If dtMercaderistas.DefaultView.Count > 0 Then
                        dr.Item("mercaderista") = dtMercaderistas.DefaultView(0).Item("mercaderista")
                    End If
                End If

            Next


        Catch ex As Exception
        Finally
            pdt.DefaultView.RowFilter = ""
            pdt.DefaultView.RowFilter = "itemnbr <> ''"
            myOtrans.close()
            myOtrans = Nothing
        End Try

  

    End Sub

    Private Sub Procesar_Excel()
        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel()
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados(), encabezados_completo As String


        Dim icount As Integer

        Try
            Me.OFD_Productos.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"
            Me.OFD_Productos.FileName = ""
            Me.OFD_Productos.ShowDialog()

            snombre_archivo = Me.OFD_Productos.FileName
            Oaut.pNombreArchivo = snombre_archivo


            Label1.Text = Now()

            Dim dt As DataTable = fImport(snombre_archivo, snombre_archivo.Split(".")(1))

            Label2.Text = Now()

            Label4.Text = "Numero de Registros  " & dt.Rows.Count

            'hojas_encabezados = Oaut.Obtener_Hojas
            'If hojas_encabezados.Length > 1 Then
            '    Oaut2.Llenar_Combo_Vector(hojas_encabezados)
            '    Oaut2.Text = "Seleccion de Hoja"
            '    Oaut2.StartPosition = FormStartPosition.CenterParent
            '    Oaut2.ShowDialog()
            '    Oaut.pNombreHoja = Oaut2._selectedValue.ToString
            '    Oaut2 = Nothing
            'Else
            '    Oaut.pNombreHoja = hojas_encabezados(0)
            'End If

            'hojas_encabezados = Oaut.obtenerEncabezados


            'Dim oform As New frm_columnas

            'oform.clb_Columnas.Items.AddRange(hojas_encabezados)
            'For icount = 0 To oform.clb_Columnas.Items.Count - 1
            '    If oform.clb_Columnas.Items.Item(icount).ToString.ToLower.StartsWith("prod") Then
            '        oform.clb_Columnas.Items.Item(icount) += " "
            '        oform.clb_Columnas.SetItemChecked(icount, True)
            '    ElseIf oform.clb_Columnas.Items.Item(icount).ToString.ToLower.StartsWith("desc") Then
            '        oform.clb_Columnas.Items.Item(icount) += " "
            '        oform.clb_Columnas.SetItemChecked(icount, True)
            '    Else
            '        oform.clb_Columnas.Items.Item(icount) += " " & giPeriodo.ToString & _
            '                    Obtener_numero_mes(oform.clb_Columnas.Items.Item(icount).ToString).ToString.PadLeft(2, "0")
            '        oform.clb_Columnas.SetItemChecked(icount, True)

            '    End If
            'Next

            'oform.ShowDialog()
            'encabezados_completo = String.Empty

            'oform.clb_Columnas.SetItemChecked(0, True)
            'oform.clb_Columnas.SetItemChecked(1, True)
            'For icount = 0 To oform.clb_Columnas.Items.Count - 1
            '    encabezados_completo += "," & oform.clb_Columnas.Items.Item(icount).ToString.Substring(0, oform.clb_Columnas.Items(icount).ToString.IndexOf(" "))
            '    If oform.clb_Columnas.GetItemChecked(icount) = True Then
            '        encabezados_seleccionados += "," & oform.clb_Columnas.Items.Item(icount).ToString.Substring(0, oform.clb_Columnas.Items(icount).ToString.IndexOf(" "))
            '    End If
            'Next
            'oform = Nothing



            '' Oaut.pNombreColumnas = encabezados_seleccionados
            'Oaut.pNombreColumnas = encabezados_completo
            'Label1.Text = Now()

            '_dtregistros = Oaut.obtener_registros_nombres()

            'Label2.Text = Now()
            Me.DataGridView1.DataSource = dt
        Catch ex As Exception
        Finally
            'Oaut.Cerrar_libro()
            Oaut = Nothing
        End Try

    End Sub


    Private Sub guardarInformacion()
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String


        Try
            For Each dr As DataRow In _dtregistros.Rows
                lsSQL = "pa_ins_um_retail_link '" & gs_empresa & "','" & Me.dtpFechaCarga.Value.ToString("dd/MM/yyyy") & "','" & _
                        gs_usuario & "','" & _
                        dr.Item(0) & "','" & _
                        dr.Item(1) & "','" & _
                        dr.Item(2) & "','" & _
                        dr.Item(3) & "'," & _
                        dr.Item(4) & ",'" & _
                        dr.Item(5) & "','" & _
                        dr.Item(6) & "','" & _
                        dr.Item(7) & "','" & _
                        dr.Item(8) & "'," & _
                        dr.Item(9) & ",'" & _
                        dr.Item(10) & "'," & _
                        dr.Item(11) & "," & _
                        dr.Item(12) & "," & _
                        dr.Item(13) & "," & _
                        dr.Item(14) & "," & _
                        dr.Item(15) & "," & _
                        dr.Item(16) & ",'" & _
                        dr.Item(17) & "','" & _
                        dr.Item(18) & "','" & _
                        dr.Item("glosa") & "','" & _
                        dr.Item("ctacte") & "','" & _
                 dr.Item("giro") & "','" & _
                 dr.Item("mercaderista").ToString & "'"

                clsGen.insertQuery("dwh", lsSQL)


                '@Pitem_nbr		As	nvarchar(50), 0
                '@Pvendor_stk_nbr	AS	nvarchar(50),1
                '@Pbrand_desc		AS	nvarchar(255),2
                '@Psigning_desc		AS	nvarchar(255),3
                '@Pvnpk_qty			AS	numeric,4
                '@Pupc				AS	nvarchar(255),5
                '@Pitem_status		AS	nvarchar(50),6
                '@Pitem_type			AS	nvarchar(50),7
                '@Pfinancial_rpt_code	AS	nvarchar(50),8
                '@Pstore_nbr			AS	numeric,9
                '@Pstore_name		AS	nvarchar(255),10
                '@Pcurr_str_on_hand_qty	AS	numeric,11
                '@Ppos_qty			AS	numeric,12
                '@Punit_cost			AS	numeric,13
                '@Punit_retail		AS	numeric,14
                '@Pcurr_str_on_order_qty	AS	numeric,15
                '@Pvendor_nbr_dept	AS	numeric, 16
                '@Pcountry_code		AS	nvarchar(50), 17
                '@Pproducto			AS	nvarchar(50), 18
                '@Pglosa				AS	nvarchar(255),19
                '@Pctacte			AS	nvarchar(50),20
                '@Pgiro				AS	nvarchar(255)21


            Next

            MessageBox.Show("Informacion Cargada Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try
    End Sub

    Private Function diaValido() As Boolean
        Dim lbdiaValido As Boolean = True

        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            dt = clsGen.selectQuery("dwh", lsSQL)
            If dt.Rows.Count = 0 Then
                lbdiaValido = True

            End If
        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

        Return lbdiaValido
    End Function
    Private Sub frmCargaInformacionWalmart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If diaValido Then
                guardarInformacion()
            Else
                MessageBox.Show("")
            End If
        End If
    End Sub
End Class