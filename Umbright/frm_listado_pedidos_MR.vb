Public Class frm_listado_pedidos_MR
    Inherits System.Windows.Forms.Form

    Dim Ods As DataSet
    Public tipo_listado As Integer = 1 '1=listado mr, 2=listado Oc

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents dg_encabezado As System.Windows.Forms.DataGrid
    Friend WithEvents dg_detalle As System.Windows.Forms.DataGrid
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_denegar As System.Windows.Forms.Button
    Friend WithEvents btn_refrescar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_listado_pedidos_MR))
        Me.dg_encabezado = New System.Windows.Forms.DataGrid
        Me.dg_detalle = New System.Windows.Forms.DataGrid
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_denegar = New System.Windows.Forms.Button
        Me.btn_refrescar = New System.Windows.Forms.Button
        CType(Me.dg_encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_encabezado
        '
        Me.dg_encabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dg_encabezado.CaptionVisible = False
        Me.dg_encabezado.DataMember = ""
        Me.dg_encabezado.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_encabezado.Location = New System.Drawing.Point(0, 8)
        Me.dg_encabezado.Name = "dg_encabezado"
        Me.dg_encabezado.ReadOnly = True
        Me.dg_encabezado.Size = New System.Drawing.Size(646, 205)
        Me.dg_encabezado.TabIndex = 0
        '
        'dg_detalle
        '
        Me.dg_detalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dg_detalle.CaptionText = "Detalle de Pedido"
        Me.dg_detalle.DataMember = ""
        Me.dg_detalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle.Location = New System.Drawing.Point(0, 224)
        Me.dg_detalle.Name = "dg_detalle"
        Me.dg_detalle.ReadOnly = True
        Me.dg_detalle.Size = New System.Drawing.Size(648, 248)
        Me.dg_detalle.TabIndex = 1
        '
        'btn_actualizar
        '
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_actualizar.ImageIndex = 0
        Me.btn_actualizar.ImageList = Me.ImageList1
        Me.btn_actualizar.Location = New System.Drawing.Point(664, 8)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(72, 64)
        Me.btn_actualizar.TabIndex = 2
        Me.btn_actualizar.Text = "Aprobar"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(40, 40)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btn_denegar
        '
        Me.btn_denegar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_denegar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_denegar.ImageIndex = 1
        Me.btn_denegar.ImageList = Me.ImageList1
        Me.btn_denegar.Location = New System.Drawing.Point(664, 72)
        Me.btn_denegar.Name = "btn_denegar"
        Me.btn_denegar.Size = New System.Drawing.Size(72, 64)
        Me.btn_denegar.TabIndex = 2
        Me.btn_denegar.Text = "Denegar"
        Me.btn_denegar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn_refrescar
        '
        Me.btn_refrescar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_refrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_refrescar.ImageIndex = 2
        Me.btn_refrescar.ImageList = Me.ImageList1
        Me.btn_refrescar.Location = New System.Drawing.Point(664, 136)
        Me.btn_refrescar.Name = "btn_refrescar"
        Me.btn_refrescar.Size = New System.Drawing.Size(72, 64)
        Me.btn_refrescar.TabIndex = 3
        Me.btn_refrescar.Text = "Actualizar"
        Me.btn_refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frm_listado_pedidos_MR
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(736, 477)
        Me.Controls.Add(Me.btn_refrescar)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.dg_detalle)
        Me.Controls.Add(Me.dg_encabezado)
        Me.Controls.Add(Me.btn_denegar)
        Me.Name = "frm_listado_pedidos_MR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Pedidos Pendientes MR ::"
        CType(Me.dg_encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Customizar_Forma()
        If tipo_listado = 2 Then
            Me.Text = ":: Ordenes de Compra Pendientes ::"
        End If
    End Sub

    Private Sub Llenar_Informacion_OC()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            Otrans.open()
            Ods = New DataSet

            ls_sql = "pa_var_um_encabezado_orden_compra_pendiente '" & gs_empresa & "','ORDEN/COMPRA'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "Encabezado"
            If Ods.Tables.Contains(dt.TableName) Then
                Ods.Tables.Remove(dt.TableName)
            End If
            Ods.Tables.Add(dt.Copy)
            Me.dg_encabezado.DataSource = Nothing
            Me.dg_encabezado.DataSource = Ods.Tables("Encabezado")

            ls_sql = "pa_var_um_detalle_orden_compra_pendiente '" & gs_empresa & "','ORDEN/COMPRA'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "Detalle"
            If Ods.Tables.Contains(dt.TableName) Then
                Ods.Tables.Remove(dt.TableName)
            End If
            Ods.Tables.Add(dt.Copy)
            Me.dg_detalle.DataSource = Nothing
            Me.dg_detalle.DataSource = Ods.Tables("Detalle")

            ClsGen.Alinea_Grid(Ods.Tables("Encabezado"), Me.dg_encabezado, -1, 250, 50, True, True, "", True, "")
            ClsGen.Alinea_Grid(Ods.Tables("Detalle"), Me.dg_detalle, -1, 250, 0, False, True, ",numero,producto,glosa,cantidad,unidadingreso,precio_unitario,neto,", True, "")

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Llenar_Informacion()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Ods = New DataSet
            otrans.open()

            ls_sql = "call pa_var_um_bbj_mayorista_encabezado_pendientes (NULL,NULL)"
            dt = otrans.Obtiene(ls_sql)
            If Ods.Tables.Contains("encabezado") Then
                Ods.Tables.Remove("encabezado")
            End If
            dt.TableName = "encabezado"

            Ods.Tables.Add(dt.Copy)
            Me.dg_encabezado.DataSource = Ods.Tables("encabezado")

            ls_sql = "call pa_var_um_bbj_mayorista_detalle_pendientes (NULL,NULL)"
            dt = otrans.Obtiene(ls_sql)

            If Ods.Tables.Contains("detalle") Then
                Ods.Tables.Remove("detalle")
            End If

            dt.TableName = "detalle"

            Ods.Tables.Add(dt.Copy)

            Me.dg_detalle.DataSource = Ods.Tables("detalle").DefaultView

            clsgen.Alinea_Grid(Ods.Tables("encabezado"), Me.dg_encabezado, Ods.Tables("encabezado").TableName, -1, 250, 0, True, True, "", True, "")
            clsgen.Alinea_Grid(Ods.Tables("detalle"), Me.dg_detalle, Ods.Tables("detalle").TableName, -1, 250, 0, True, True, "", True, "")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Filtrar_detalle()
        Try

            Dim nrow As Integer
            nrow = Me.dg_encabezado.CurrentCell.RowNumber

            Ods.Tables("detalle").DefaultView.RowFilter = "cod_movimiento = " & Me.dg_encabezado.Item(nrow, 0)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Filtrar_Detalle_OC()
        Try

            Dim nrow As Integer
            nrow = Me.dg_encabezado.CurrentCell.RowNumber

            Ods.Tables("detalle").DefaultView.RowFilter = "correlativo = " & Me.dg_encabezado.Item(nrow, 0)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Aprobar_Pedido()

        Try

            Dim nrow As Integer
            nrow = Me.dg_encabezado.CurrentCell.RowNumber
            Dim _comentario As String

            _comentario = InputBox("Comentario Para Pedido", "Aprobacion de Pedidos")

            Hacer_Pedido_Clase(Me.dg_encabezado.Item(nrow, 1).ToString, Me.dg_encabezado.Item(nrow, 3).ToString, _comentario)
        Catch ex As Exception
        Finally
            Llenar_Informacion()

        End Try

    End Sub

    Private Sub Aprobar_OC()
        Dim nrow As Integer
        nrow = Me.dg_encabezado.CurrentCell.RowNumber
        Dim _comentario As String
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim lexitoso As Boolean = True


        Try
            otrans.open()
            _comentario = InputBox("Comentario Para Orden de Compra", "Aprobacion de Orden de Compra")

            ls_sql = "pa_upd_um_documento_estado '" & Me.dg_encabezado.Item(nrow, 1) & "','" & _
                        Me.dg_encabezado.Item(nrow, 2) & "','" & _
                        Me.dg_encabezado.Item(nrow, 3) & "','" & _
                        Me.dg_encabezado.Item(nrow, 6) & " " & _comentario & "','S','" & gs_usuario & "'"


            otrans.Actualiza(ls_sql)

            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Proceso Realizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lexitoso = True
            Else
                MessageBox.Show(otrans.descripcion_error)
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        If lexitoso Then
            Llenar_Informacion_OC()
        End If

    End Sub


    Private Sub Hacer_Pedido_Clase(ByVal _pcliente As Integer, ByVal _ppedido As Integer, ByVal _pcomentario As String)
        ''Esdras 8:22 La mano de nuestro Dios es propicia para con todos los 
        ''            que le buscan, mas su poder y su ira contra todos los 
        ''            que le abandonan.
        Dim Oflex As New umbral_flex.Pedidos
        Dim OProductos As New umbral_flex.productos
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim MyOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As ClasesGenerales.MR

        Dim dr, ofila As DataRow
        Dim dt As DataTable
        Dim li_linea As Integer = 0
        Dim ls_pedido_generado As Integer = 0
        Dim condiciones As String()
        Dim ls_dcomentario1, ls_sql, pcliente_flex As String

        Try

            MyOtrans.open()
            Otrans.open()

            ls_sql = "call pa_sel_um_crm_cliente_flex (" & _pcliente & ",NULL,2)"
            dt = MyOtrans.Obtiene(ls_sql)
            pcliente_flex = dt.Rows(0).Item("codigo_flex")

            ls_sql = "call pa_var_um_bbj_mayorista_encabezado_pendientes (" & _ppedido.ToString & "," & _pcliente.ToString & ")"
            dt = MyOtrans.Obtiene(ls_sql)
            dt.TableName = "pedido_encabezado"

            If Ods.Tables.Contains("pedido_encabezado") Then
                Ods.Tables.Remove("pedido_encabezado")
            End If
            Ods.Tables.Add(dt.Copy)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Este Pedido Ya Fue Aprobado", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If


            ls_sql = "call pa_var_um_bbj_mayorista_detalle_pendientes (" & _ppedido & "," & _pcliente.ToString & ")"
            dt = MyOtrans.Obtiene(ls_sql)
            dt.TableName = "pedido_detalle"
            If Ods.Tables.Contains("pedido_detalle") Then
                Ods.Tables.Remove("pedido_detalle")
            End If
            Ods.Tables.Add(dt.Copy)



            ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & pcliente_flex & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_clientes"

            If Ods.Tables.Contains("flexline_clientes") Then
                Ods.Tables.Remove("flexline_clentes")
            End If
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_gen_tabcod '01','CONFIG.IMPUESTO','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_impuesto"

            If Ods.Tables.Contains("flexline_impuesto") Then
                Ods.Tables.Remove("flexline_impuesto")
            End If
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_gen_tabcod NULL,'SYSGOLD_CONDICIONES','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_condiciones"

            If Ods.Tables.Contains("flexline_condiciones") Then
                Ods.Tables.Remove("flexline_condiciones")
            End If
            Ods.Tables.Add(dt.Copy)



            Dim pd_total_pedido As Double = Ods.Tables("pedido_encabezado").Rows(0).Item("total")

            Oflex.Limpiar_Datos()


            ''filtrando informacion de las condiciones de pago
            Ods.Tables("flexline_condiciones").DefaultView.RowFilter = "DESCRIPCION = '" & Ods.Tables("flexline_clientes").Rows(0).Item("CondPago").ToString & "'"
            'odataset.Tables("flexline_condiciones").DefaultView.RowFilter = "DESCRIPCION = '" & Me.cmb_forma_pago.SelectedValue & "'"

            ''Encabezado
            dr = Oflex.ods.Tables("encabezado").NewRow

            dr.Item("empresa") = gs_empresa
            dr.Item("tipodocto") = Ods.Tables("flexline_condiciones").DefaultView(0).Item("texto").ToString ' odataset.Tables("flexline_condiciones").DefaultView(0).Item("texto")
            dr.Item("numero") = ""
            dr.Item("fecha") = Today
            dr.Item("codigo") = Ods.Tables("flexline_clientes").Rows(0).Item("ctacte") 'odataset.Tables("flexline_clientes").Rows(0).Item("ctacte")
            dr.Item("vendedor") = Ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo") '  odataset.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
            condiciones = Ods.Tables("flexline_condiciones").DefaultView(0).Item("VALOR1").ToString.Split(".")
            dr.Item("diascredito") = condiciones(0).ToString
            dr.Item("listaprecio") = Ods.Tables("flexline_clientes").Rows(0).Item("listaPrecio").ToString 'odataset.Tables("detalle_cotizacion").Rows(0)("lista_precios").ToString()
            'If odataset.Tables("detalle_cotizacion").Rows(0)("dar_precio_paquete").ToString = 1 Then
            '   ps_lista_paquete = odataset.Tables("detalle_cotizacion").Rows(0)("lista_precios").ToString()
            'End If
            dr.Item("total") = pd_total_pedido
            dr.Item("factor") = Ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
            dr.Item("aprobacion") = Ods.Tables("flexline_condiciones").DefaultView(0).Item("texto2")
            dr.Item("periodo") = Trim(Format(Now, "yyyy") + Format(Now, "MM"))
            dr.Item("direccion") = Ods.Tables("flexline_clientes").Rows(0).Item("direccion").ToString
            dr.Item("ciudad") = Ods.Tables("flexline_clientes").Rows(0).Item("ciudad").ToString
            dr.Item("comuna") = Ods.Tables("flexline_clientes").Rows(0).Item("comuna").ToString
            dr.Item("pais") = Ods.Tables("flexline_clientes").Rows(0).Item("pais").ToString
            dr.Item("contacto") = Ods.Tables("flexline_clientes").Rows(0).Item("contacto").ToString


            ls_dcomentario1 = "PDA-MR " & Ods.Tables("pedido_encabezado").Rows(0).Item("observaciones")

            'ls_dcomentario1 += " PRUEBA IT  *** NO FACTURAR **** "
            ls_dcomentario1 += " " & _pcomentario

            dr.Item("comentario1") = ls_dcomentario1
            dr.Item("usuario") = gs_usuario 'odataset.Tables("detalle_cotizacion").Rows(0)("usuario").ToString
            dr.Item("AnalisisE3") = "30/12/1899"


            Oflex.ods.Tables("encabezado").Rows.Add(dr)

            ''Documentop
            dr = Oflex.ods.Tables("documentop").NewRow

            dr.Item("codigopago") = Ods.Tables("flexline_clientes").Rows(0).Item("CondPago")
            dr.Item("diascredito") = condiciones(0).ToString
            dr.Item("total") = pd_total_pedido
            dr.Item("cuenta") = Ods.Tables("flexline_condiciones").DefaultView(0).Item("texto1")
            dr.Item("fecha") = Today
            Oflex.ods.Tables("documentop").Rows.Add(dr)

            ''DocumentoV
            dr = Oflex.ods.Tables("documentov").NewRow
            dr.Item("total") = pd_total_pedido
            dr.Item("factor") = Ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
            Oflex.ods.Tables("documentov").Rows.Add(dr)

            pd_total_pedido = 0
            ''DocumentoD
            For Each ofila In Ods.Tables("pedido_detalle").Rows

                li_linea = li_linea + 1
                dr = Oflex.ods.Tables("detalle").NewRow
                dr.Item("secuencia") = li_linea
                dr.Item("producto") = ofila.Item("cod_flex")
                dr.Item("cantidad") = ofila.Item("cantidad")

                dr.Item("diascredito") = condiciones(0).ToString
                dr.Item("factor") = Ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
                dr.Item("fecha") = Today
                dr.Item("costo") = 0
                dr.Item("linea") = li_linea

                ' ls_sql = "pa_sel_um_listaprecioD '" & ps_empresa & "','" & ofila.Item("cod_flex") & "','" & Ods.Tables("flexline_clientes").Rows(0).Item("listaPrecio").ToString & "'"
                ' dt = Otrans.Obtiene(ls_sql)


                '(c) 140509 el precio de oferta o el de lista Tomar los precios reales
                dt = OProductos.Obtener_Precio_Final(gs_empresa, ofila.Item("cod_flex"), Ods.Tables("flexline_clientes").Rows(0).Item("ctacte").ToString, Ods.Tables("flexline_clientes").Rows(0).Item("listaPrecio").ToString)


                '(c) tomo el precio que tiene asignado en la lista de precios
                If dt.Rows.Count > 0 Then
                    dr.Item("precio") = dt.Rows(0).Item("valor") ''ofila.Item("precio")
                    dr.Item("total") = dt.Rows(0).Item("valor") * ofila.Item("cantidad") 'ofila.Item("subtotal")
                Else
                    dr.Item("precio") = 0 ''dt.Rows(0).Item("valor") ''ofila.Item("precio")
                    dr.Item("total") = 0 ''dt.Rows(0).Item("valor") * ofila.Item("cantidad") 'ofila.Item("subtotal")
                End If

                Oflex.ods.Tables("detalle").Rows.Add(dr)
                pd_total_pedido += dr.Item("total")
            Next
            Oflex.ods.Tables("encabezado").Rows(0).Item("total") = pd_total_pedido
            Oflex.ods.Tables("documentop").Rows(0).Item("total") = pd_total_pedido
            Oflex.ods.Tables("documentov").Rows(0).Item("total") = pd_total_pedido


            Otrans.close()

            ls_pedido_generado = Oflex.Guardar_PedidoBasico()

            If ls_pedido_generado > 0 Then

                MyOtrans.open()
                ls_sql = "call pa_upd_um_bbj_mayorista_encabezado_movimiento (" & _ppedido.ToString & "," & _pcliente.ToString & "," & _
                        "3,2,'" & Oflex.ods.Tables("encabezado").Rows(0).Item("Numero") & _
                    "','" & Ods.Tables("pedido_encabezado").Rows(0).Item("observaciones").ToString & Ods.Tables("flexline_condiciones").DefaultView(0).Item("texto").ToString & "-" & ls_pedido_generado & _
                    "',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" & Today.ToString("yyyy-MM-dd HH:mm") & "')"

                MyOtrans.Actualiza(ls_sql)
                MyOtrans.close()
                MyOtrans = Nothing

                Try
                    ClsGen = New ClasesGenerales.MR(_pcliente.ToString, 1)
                    Dim _asunto, _mensaje1, _mensaje2, _mensaje3 As String
                    Dim icount As Integer
                    _mensaje1 = ""
                    _mensaje2 = vbCrLf
                    _mensaje3 = vbCrLf
                    _asunto = "Aprobacion de Pedido " & Ods.Tables("pedido_encabezado").Rows(0).Item("correlativo").ToString & "  " & Ods.Tables("pedido_encabezado").Rows(0).Item("observaciones").ToString
                    _mensaje1 = "Numero de Pedido Codicasa " & Oflex.ods.Tables("encabezado").Rows(0).Item("tipodocto") & " "
                    _mensaje1 += Oflex.ods.Tables("encabezado").Rows(0).Item("numero") & vbCrLf
                    _mensaje1 += "Fecha de Aprobacion: " & Now.ToString("dd/MM/yyyy HH:mm") & ", Usuario: " & gs_usuario & vbCrLf
                    _mensaje1 += "Total: " & pd_total_pedido.ToString & vbCrLf
                    _mensaje1 += "***IMPORTANTE *** Este pedido esta pendiente de aprobacion crediticia y de verificacion de existencias **** " & vbCrLf
                    _mensaje1 += "Producto".PadRight(12, " ") & " " & "Descripcion".PadRight(50, " ") & " " & "Cant".PadRight(10, " ") & _
                                 " " & "Precio".PadRight(10, " ") & " " & "Total".PadRight(10, " ") & vbCrLf

                    For Each dr In Oflex.ods.Tables("detalle").Rows
                        If dr.Item("linea").ToString < 15 Then
                            _mensaje1 += dr.Item("producto").ToString.PadRight(12, " ")
                            _mensaje1 += " "
                            dt = OProductos.Obtener_Producto(gs_empresa, dr.Item("producto").ToString)
                            If dt.Rows.Count = 1 Then
                                _mensaje1 += dt.Rows(0).Item("glosa").ToString.PadRight(50, " ").Substring(0, 49) ''Debo buscar la descripcion
                            End If
                            _mensaje1 += " "
                            _mensaje1 += dr.Item("cantidad").ToString.PadRight(10, " ")
                            _mensaje1 += " "
                            _mensaje1 += dr.Item("precio").ToString.PadRight(10, " ")
                            _mensaje1 += " "
                            _mensaje1 += dr.Item("total").ToString.PadRight(10, " ")
                            _mensaje1 += vbCrLf
                        ElseIf dr.Item("linea").ToString < 30 Then
                            _mensaje2 += dr.Item("producto").ToString.PadRight(12, " ")
                            _mensaje2 += " "
                            dt = OProductos.Obtener_Producto(gs_empresa, dr.Item("producto").ToString)
                            If dt.Rows.Count = 1 Then
                                _mensaje2 += dt.Rows(0).Item("glosa").ToString.PadRight(50, " ").Substring(0, 49) ''Debo buscar la descripcion
                            End If
                            _mensaje2 += " "
                            _mensaje2 += dr.Item("cantidad").ToString.PadRight(10, " ")
                            _mensaje2 += " "
                            _mensaje2 += dr.Item("precio").ToString.PadRight(10, " ")
                            _mensaje2 += " "
                            _mensaje2 += dr.Item("total").ToString.PadRight(10, " ")
                            _mensaje2 += vbCrLf
                        Else
                            _mensaje3 += dr.Item("producto").ToString.PadRight(12, " ")
                            _mensaje3 += " "
                            dt = OProductos.Obtener_Producto(gs_empresa, dr.Item("producto").ToString)
                            If dt.Rows.Count = 1 Then
                                _mensaje3 += dt.Rows(0).Item("glosa").ToString.PadRight(50, " ").Substring(0, 49) ''Debo buscar la descripcion
                            End If
                            _mensaje3 += " "
                            _mensaje3 += dr.Item("cantidad").ToString.PadRight(10, " ")
                            _mensaje3 += " "
                            _mensaje3 += dr.Item("precio").ToString.PadRight(10, " ")
                            _mensaje3 += " "
                            _mensaje3 += dr.Item("total").ToString.PadRight(10, " ")
                            _mensaje3 += vbCrLf
                        End If

                    Next

                    If ClsGen.Enviar_Mensaje_CDC_MR(_asunto, Now.ToString("dd-MM-yyyy"), _mensaje1, _mensaje2, _mensaje3, gs_usuario, 1) Then
                        '                        MessageBox.Show("Mensaje Generado Con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        '                       MessageBox.Show("Se Generaron Errores ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                Finally

                End Try


                MessageBox.Show("Pedido Generado con Exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Else
                MessageBox.Show("No se ha Podido Guardar El Pedido, Vuelva a Intentarlo  " & Oflex.serror.ToString, "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            Oflex = Nothing
            ClsGen = Nothing
            OProductos.close()
            OProductos = Nothing

        End Try
    End Sub


    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        Dim nrow As Integer
        nrow = Me.dg_encabezado.CurrentCell.RowNumber
        Try

            If tipo_listado = 1 Then
                If MessageBox.Show("Esta Seguro de Aprobar Este Pedido", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Aprobar_Pedido()
                End If
            ElseIf tipo_listado = 2 Then
                If MessageBox.Show("Esta Seguro de Aprobar Esta Orden de Compra " & Chr(13) & Me.dg_encabezado.Item(nrow, 3).ToString, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Aprobar_OC()
                End If
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Denegar_Pedido()
        ''Actualizar cotizacion
        '' le cambio estado a 2 = Procesada
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim nrow As Integer
        nrow = Me.dg_encabezado.CurrentCell.RowNumber

        Try
            myOtrans.open()
            ls_sql = InputBox("Por Que Motivo Se Deniega el Pedido", "Motivo")
            If ls_sql.Length > 0 Then
                ls_sql = "call pa_upd_um_bbj_mayorista_encabezado_movimiento (" & Me.dg_encabezado.Item(nrow, 3).ToString.ToString & "," & _
                                Me.dg_encabezado.Item(nrow, 1).ToString & "," & _
                                            "3,3,NULL,'" & Me.dg_encabezado.Item(nrow, 6).ToString.Trim & " -- Denegado Por " & ls_sql & "',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" & gs_usuario & "',NULL)"
                myOtrans.Actualiza(ls_sql)
            Else
                MessageBox.Show("Debe Ingresar Motivo", "Falte de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Llenar_Informacion()
        End Try
    End Sub

    Private Sub Denegar_OC()
        Dim nrow As Integer
        nrow = Me.dg_encabezado.CurrentCell.RowNumber
        Dim _comentario As String
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim lexitoso As Boolean = False


        Try
            otrans.open()
            _comentario = InputBox("Ingrese el Motivo de Rechazo de Orden de Compra", "Rechazar de Orden de Compra")

            ls_sql = "pa_upd_um_documento_estado '" & Me.dg_encabezado.Item(nrow, 1) & "','" & _
                        Me.dg_encabezado.Item(nrow, 2) & "','" & _
                        Me.dg_encabezado.Item(nrow, 3) & "','" & _
                        Me.dg_encabezado.Item(nrow, 6) & " " & _comentario & "','N','" & gs_usuario & "'"


            otrans.Actualiza(ls_sql)

            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Proceso Realizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lexitoso = True
            Else
                MessageBox.Show(otrans.descripcion_error)
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If lexitoso Then
            Llenar_Informacion_OC()
        End If

    End Sub

    Private Function Buscar_Producto(ByVal _producto As String) As String
        Dim descripcion As String = ""
        Dim oTrans As New Transaccional.Conexion("FlexLine")

        Try
            oTrans.abrir()

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try

        Return descripcion
    End Function


    Private Sub frm_listado_pedidos_MR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If tipo_listado = 1 Then
            Llenar_Informacion()
            Filtrar_detalle()
        ElseIf tipo_listado = 2 Then
            Customizar_Forma()
            Llenar_Informacion_OC()
            Filtrar_Detalle_OC()
        End If
    End Sub


    Private Sub dg_encabezado_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_encabezado.CurrentCellChanged
        If tipo_listado = 1 Then
            Filtrar_detalle()
        ElseIf tipo_listado = 2 Then
            Filtrar_Detalle_OC()
        End If
    End Sub

    Private Sub btn_denegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_denegar.Click
        Dim nrow As Integer
        nrow = Me.dg_encabezado.CurrentCell.RowNumber
        Try
            If tipo_listado = 1 Then
                If MessageBox.Show("Esta Seguro de Denegar Este Pedido", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Denegar_Pedido()
                    Llenar_Informacion()
                End If
            ElseIf tipo_listado = 2 Then
                If MessageBox.Show("Esta Seguro de Denegar Esta Orden de Compra " & Chr(13) & Me.dg_encabezado.Item(nrow, 3).ToString, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Denegar_OC()
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refrescar.Click
        If tipo_listado = 1 Then
            Llenar_Informacion()
            Filtrar_detalle()
        ElseIf tipo_listado = 2 Then
            Customizar_Forma()
            Llenar_Informacion_OC()
            Filtrar_Detalle_OC()
        End If
    End Sub


End Class
