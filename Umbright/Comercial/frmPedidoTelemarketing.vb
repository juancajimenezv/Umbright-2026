Public Class frmPedidoTelemarketing

    'Dim sEmpresaVende As String 'DM/CODICASA/DIUVA
    Dim sCodigoClienteCompra As String ''Codigo de Cliente Vinoteca en Las Empresas \ 2968550 
    Dim dtMovimientos As DataTable


    Private Sub obtenerParametros()
        sCodigoClienteCompra = "29685509"
    End Sub


    Private Function generarPedido_Umbright(ByVal psEmpresaVende As String, ByVal dtvDetalle As DataView) As Boolean
        Dim lsSQL As String
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dt, dtCliente As DataTable
        Dim numero_pedido As String
        Dim precio_unitario As Double

        Try

            Otrans.open()
            myOtrans.open()
            dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & psEmpresaVende & "','CLIENTE','" & sCodigoClienteCompra & "'")

            ''Guardar 

            lsSQL = "call pa_ins_um_mov_pedidos_encabezado_tekne ('" & _
                     psEmpresaVende & "','" & Now.ToString("ddMMyyyyHHmmss") & "','" & _
                     sCodigoClienteCompra & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," & _
                     "0,0,'" & _
                    DateTime.Parse(Now.ToString).ToString("yyyy-MM-dd HH:mm") & "','" & _
                    DateTime.Parse(Today.ToString).ToString("yyyy-MM-dd") & "','"

            lsSQL += "1900-01-01','"

            'lsSQL += "Orden de Compra No. " & drEncabezado.Item("numero") & " " & drEncabezado("comentario1").ToString & " Facturar de CD_CANASTAS','" & _
            lsSQL += "Facturar de CD_CANASTAS  traslado a vinoteca pedido no.  CARGAR A CD_CANASTAS en Vinoteca" & Me.txtNumero.Text & "','" & _
                    gs_usuario.ToString & "',0,'" & _
                    dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" & _
                    Now.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL,'"

            'Catch ex As Exception
            lsSQL += "','')"
            'End Try


            myOtrans.Ingresa(lsSQL)

            If myOtrans.Codigo_error = 0 Then
                dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                numero_pedido = dt.Rows(0).Item("newid").ToString

                For Each drv As DataRowView In dtvDetalle

                    dt = oFlex.Obtener_Precio_Final(psEmpresaVende, drv.Item("producto"), sCodigoClienteCompra)
                    Try
                        precio_unitario = dt.Rows(0).Item("valor")
                    Catch ex As Exception
                        precio_unitario = 0
                    End Try

                    lsSQL = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," & _
                                      drv.Item("Linea") & ",'" & drv.Item("producto") & "'," & _
                                      drv.Item("cantidad") & "," & precio_unitario & "," & _
                                      precio_unitario * drv.Item("cantidad") & ")"

                    myOtrans.Ingresa(lsSQL)
                    If myOtrans.Codigo_error > 0 Then
                        'lbExitoso = False
                    End If
                Next
            End If

            lsSQL = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
            myOtrans.Actualiza(lsSQL)


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
    End Function


    Private Function llenarInformacion(ByVal ods As DataSet, ByVal pdr As DataRow) As Boolean
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim drAux As DataRow
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            'lsSQL = "pa_var_um_documentod '" & psEmpresa & "','SALIDA DE PRODUCTO INVENTARIO','0004000072'"
            lsSQL = "pa_var_um_documentod '" & pdr("Empresa").ToString & "','" & pdr.Item("TipoDocto").ToString & "','" & pdr.Item("Numero") & "'"
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                drAux = ods.Tables("pedido").NewRow
                drAux.Item("producto") = dr.Item("producto")
                drAux.Item("cantidad") = dr.Item("cantidad")
                drAux.Item("linea") = dr.Item("linea")
                ods.Tables("pedido").Rows.Add(drAux)
            Next


            Return True
        Catch ex As Exception
            Return False
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Function

    Private Sub crearEstructura(ByVal ods As DataSet)
        Dim dt2 As DataTable
        dt2 = New DataTable("pedido")
        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("cantidad", GetType(String)))
        dt2.Columns.Add(New DataColumn("linea", GetType(String)))
        ods.Tables.Add(dt2.Copy)

    End Sub


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click, Button1.Click

        Dim ods As New DataSet
        crearEstructura(ods)
        For Each dr As DataRow In Me.dtMovimientos.Rows
            ods.Tables("pedido").Rows.Clear()
            If llenarInformacion(ods, dr) Then
                If Me.generarPedido_Umbright(dr.Item("Empresa"), ods.Tables("pedido").DefaultView) Then
                    MessageBox.Show("Se Creo Pedido en " & dr.Item("Empresa").ToString, " Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Next


        'obtnerInformacion()
        'Me.generarPedido_Umbright()
    End Sub

    Private Sub buscarDocumentos()
        Dim lsSQL As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Otrans.open()
            lsSQL = "pa_var_um_dw_log_traslados_canastas '" & Me.cmbTipoDocumento.Text & "','" & Me.txtNumero.Text & "'"
            Me.dtMovimientos = Otrans.Obtiene(lsSQL)
            Me.DataGridView1.DataSource = dtMovimientos
            clsGen.Alinear_GridView(dtMovimientos, Me.DataGridView1, ",empresa,tipodocto,fecha,numero,procesado,", "", "", "", "", "", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub frmPedidoTelemarketing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obtenerParametros()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress, txtComentario.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txtNumero.Text = Me.txtNumero.Text.PadLeft(10, "0")
            buscarDocumentos()

        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged, txtComentario.TextChanged

    End Sub
End Class