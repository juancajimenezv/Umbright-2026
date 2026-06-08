Public Class Frm_Devoluciones
    Dim pds_Dataset As New DataSet
    Dim oTransaccion As Transaccional.Conexion
    Dim ls_SqlScript As String
    Dim oTabla1 As DataTable
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Private okToValidate As Boolean
    Private okToValidate2 As Boolean = True
    Dim ds As New DataSet
    Dim lbExitoso As Boolean = True

    Dim pi_devolucion As String = ""
    Dim estado As Boolean = False
    Dim Ods As New DataSet
    Dim tipodocto As String = String.Empty
    Dim preciou As Double = 0
    Dim lote As String = String.Empty
    Dim fechavcto As String = String.Empty
    Dim sgdetalleSerie As String = String.Empty
    Dim giSecuencia As Integer = 0

    Private Sub Buscar_Cliente()
        Dim oTable As New DataTable


        Try
            pds_Dataset.Tables.Remove("clientes_flexline")
        Catch ex As Exception

        End Try


        newcurrentrow = -1
        newcurrentcol = -1
        okToValidate = True


        If Me.txt_cod_cliente.Text.Length > 0 Then
            oTransaccion = New Transaccional.Conexion("flexline")
            oTransaccion.open()
            ls_SqlScript = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & Me.txt_cod_cliente.Text.Trim & "'"
            oTable = oTransaccion.Obtiene(ls_SqlScript)
            oTable.TableName = "clientes_flexline"
            pds_Dataset.Tables.Add(oTable.Copy)

            If oTable.Rows.Count = 0 Then
                MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_nombre_cliente.Text = ""
                Me.txt_vendedor.Text = ""
                Me.txt_nit.Text = ""
                Me.txt_direccion.Text = ""
                Me.txt_cod_cliente.Focus()

            Else
                Me.txt_nombre_cliente.Text = oTable.Rows(0).Item("RazonSocial") & "/" & oTable.Rows(0).Item("giro")
                Me.txt_vendedor.Text = oTable.Rows(0).Item("Ejecutivo")
                Me.txt_nit.Text = oTable.Rows(0).Item("CodLegal")
                Me.txt_direccion.Text = oTable.Rows(0).Item("Direccion")
                Me.txt_lista_Precios.Text = oTable.Rows(0).Item("ListaPrecio")
                'Me.cmbTipoDocto.Focus()
                Me.cmbEntrega.Focus()

            End If
            oTransaccion.close()
        End If

    End Sub

    Private Sub llenarCombos()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim otabla As DataTable


        Try
            otrans.open()
            Me.cmbTipoDocto.DataSource = dt

            lsSQL = "pa_sel_um_gen_motivo_devolucion "
            otabla = otrans.Obtiene(lsSQL)
            otabla.TableName = "motivos"
            Ods.Tables.Add(otabla.Copy)

            Me.cmb_motivo.DataSource = Ods.Tables("motivos")
            Me.cmb_motivo.ValueMember = "codigo"
            Me.cmb_motivo.DisplayMember = "descripcion"

            'For Each dr As DataRow In otabla.Rows
            '    Dim draux As DataRow = ds.Tables("tipo_unidad").NewRow
            '    draux.Item("MOTIVO") = dr.Item("descripcion")
            '    ds.Tables("tipo_unidad").Rows.Add(draux)
            'Next



            lsSQL = "pa_sel_um_gen_tabcod_BodegaDevolucion "
            otabla = otrans.Obtiene(lsSQL)
            otabla.TableName = "bodegas"
            Ods.Tables.Add(otabla.Copy)


            'For Each dr As DataRow In otabla.Rows
            '    Dim draux As DataRow = ds.Tables("tipo_bodega").NewRow
            '    draux.Item("BODEGA") = dr.Item("descripcion")
            '    ds.Tables("tipo_bodega").Rows.Add(draux)
            'Next


            Me.cmb_bodega.DataSource = Ods.Tables("bodegas")
            Me.cmb_bodega.ValueMember = "descripcion"
            Me.cmb_bodega.DisplayMember = "descripcion"

            lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa null,null,'mco_solicita_devoluciones','" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "solicitantes"
            Ods.Tables.Add(dt.Copy)

            Me.cmb_solicitantes.DataSource = Ods.Tables("solicitantes")
            Me.cmb_solicitantes.ValueMember = "usuario"
            Me.cmb_solicitantes.DisplayMember = "nombre"

            Ods.Tables("solicitantes").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"

            Me.txt_usuario_opera_memo.Text = gs_nombre_usuario

            Me.cmb_motivo.SelectedIndex = -1
            Me.cmb_bodega.SelectedIndex = -1

            Dim otrans2 As New Transaccional.Conexion("SCM")
            otrans2.open()
            lsSQL = "pa_sel_um_v_pg_estados 4"
            dt = otrans2.Obtiene(lsSQL)
            dt.TableName = "estados"

            Ods.Tables.Add(dt.Copy)

            Me.cmb_estado_devolucion.DataSource = dt
            Me.cmb_estado_devolucion.ValueMember = "cod_estado"
            Me.cmb_estado_devolucion.DisplayMember = "estado"

        Catch ex As Exception
        Finally

            otrans.close()


            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Function buscar_documento() As Boolean

        If Me.txt_NoDocto.Text = "0000000000" Then
            ds.Tables("productos").Rows.Clear()
            Exit Function
        End If


        Try
            Dim Utrans As New Transaccional.Conexion("flexline")

            Dim ls_sql As String
            Dim dt, dt2 As DataTable
            Dim draux As DataRow
            Dim drr As DataRow
            Dim clsGen As New ClasesGenerales.General

            Try
                Me.dgv_liquidacion.DataSource = Nothing
                ds.Tables("productos").Rows.Clear()
            Catch ex As Exception

            End Try



            Try
                Utrans.open()


                ls_sql = "pa_sel_um_documento_devolucion '" & gs_empresa & "',NULL, '" &
                    IIf(Me.nupAnioFACE.Value > 0, Me.nupAnioFACE.Value.ToString, "") & Me.txt_NoDocto.Text.Trim & "','" & Me.txt_cod_cliente.Text.Trim & "'"
                dt = Utrans.Obtiene(ls_sql)

                For Each dr As DataRow In dt.Rows
                    draux = ds.Tables("productos").NewRow
                    Me.dtpFechaDocumento.Value = dr.Item("fecha")

                    ls_sql = "pa_sel_um_devolucion_verificacion '" & gs_empresa & "','" & Me.txt_NoDocto.Text.Trim & "','" & dt.Rows(0).Item("tipodocto") & "','" & Me.txt_cod_cliente.Text.Trim & "','" & dr.Item("producto") & " '"
                    dt2 = Utrans.Obtiene(ls_sql)

                    If dt2.Rows.Count > 0 Then ' el producto ya se encuentra con devolucion y se podra actualizar solo si no esta aprobada la devolucion
                        If dt2.Rows(0).Item("estado").ToString = "2" Then
                            draux.Item("estado") = 0

                        ElseIf dt2.Rows(0).Item("estado").ToString = "1" Then
                            draux.Item("estado") = 1
                        Else
                            draux.Item("estado") = 0

                        End If

                    Else
                        draux.Item("estado") = 0
                    End If



                    draux.Item("producto") = dr.Item("producto")
                    draux.Item("glosa") = dr.Item("glosa")
                    draux.Item("cantidad") = dr.Item("cantidad")
                    draux.Item("MOTIVO") = ""
                    draux.Item("BODEGA") = ""
                    draux.Item("devolucion") = 0
                    draux.Item("total") = 0
                    If ds.Tables("productos_devolucion").Rows.Count > 0 Then
                        For Each drr In ds.Tables("productos_devolucion").Rows
                            If dr.Item("producto") = drr.Item("producto") And dr.Item("tipodocto") = drr.Item("tipodocto") And dr.Item("numero") = drr.Item("nodocto") And draux.Item("estado") = 0 Then
                                draux.Item("MOTIVO") = drr.Item("MOTIVO")
                                draux.Item("BODEGA") = "" 'drr.Item("BODEGA")
                                draux.Item("devolucion") = drr.Item("cantidad")
                                draux.Item("total") = drr.Item("total")
                                draux.Item("estado") = 2
                                Exit For
                            End If

                            If dr.Item("producto") = drr.Item("producto") And dr.Item("tipodocto") = drr.Item("tipodocto") And dr.Item("numero") = drr.Item("nodocto") And draux.Item("estado") = 1 Then
                                draux.Item("MOTIVO") = ""
                                draux.Item("BODEGA") = ""
                                draux.Item("devolucion") = 0
                                draux.Item("total") = 0

                                Exit For
                            End If


                        Next
                    End If
                    'draux.Item("devolucion") = 0
                    draux.Item("preciou") = dr.Item("precio")
                    '  draux.Item("total") = 0
                    draux.Item("tipodocto") = dr.Item("tipodocto")
                    draux.Item("nodocto") = dr.Item("numero")
                    draux.Item("lote") = dr.Item("lote")
                    If dr.Item("fechavcto").ToString = "1900-01-01 00:00:00" Or dr.Item("fechavcto").ToString = "1900/01/01 00:00:00" Or dr.Item("fechavcto").ToString = "01/01/1900 00:00:00" Then
                        draux.Item("fechavcto") = ""
                    Else
                        draux.Item("fechavcto") = dr.Item("fechavcto")
                    End If
                    draux.Item("secuencia") = dr.Item("secuencia")
                    draux.Item("serie") = dr.Item("serie")
                    draux.Item("serie_producto") = dr.Item("serie_producto")
                    ds.Tables("productos").Rows.Add(draux)
                Next

                Me.dgv_liquidacion.DataSource = ds.Tables("productos")

                clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgv_liquidacion, ",producto,glosa,cantidad,preciou,lote,fechavcto,serie,", ",tipodocto,nodocto,estado,", ",producto,glosa,cantidad,preciou,", ",cantidad,preciou,", ",producto=PRODUCTO,glosa=GLOSA,cantidad=CANTIDAD,preciou=PRECIO,lote=LOTE,fechavcto=FECHAVCTO,serie=Añada,", ",producto=75,glosa=400,", ",,", True, True, 250, 0)

            Catch ex As Exception
                MessageBox.Show("Se produjo el siguiente error al cargar el detalle del documento:" & vbCrLf & ex.Message)
            Finally
                Utrans.close()
                Utrans = Nothing
                clsGen = Nothing
            End Try
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub txt_cod_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cod_cliente.KeyPress
        If e.KeyChar = Chr(13) Then
            Buscar_Cliente()
        End If

        If Me.txt_nombre_cliente.Text.Trim.Length > 0 Then
            Me.txt_cod_cliente.Enabled = False
            Me.btn_buscar_producto.Enabled = False
        Else
            Me.txt_cod_cliente.Enabled = True
            Me.btn_buscar_producto.Enabled = True
        End If
    End Sub

    Private Sub btn_buscar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_producto.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm_busqueda.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente "
        frm_busqueda.ShowDialog(Me)

        Me.txt_cod_cliente.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        Buscar_Cliente()
    End Sub

    Private Sub crearEstructura()
        Dim dt As New DataTable


        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("devolucion", GetType(Double)))
        dt.Columns.Add(New DataColumn("MOTIVO", GetType(String)))
        dt.Columns.Add(New DataColumn("BODEGA", GetType(String)))
        dt.Columns.Add(New DataColumn("preciou", GetType(Double)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("nodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("lote", GetType(String)))
        dt.Columns.Add(New DataColumn("fechavcto", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("secuencia", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("serie_producto", GetType(String)))


        dt.TableName = "productos"

        If ds.Tables.Contains("productos") Then ds.Tables.Remove("productos")
        ds.Tables.Add(dt.Copy)

        dt.TableName = "productos_moc"
        If ds.Tables.Contains("productos_moc") Then ds.Tables.Remove("productos_moc")
        ds.Tables.Add(dt.Copy)


        dt = New DataTable("tipo_unidad")
        dt.Columns.Add(New DataColumn("motivo", GetType(String)))

        If Not ds.Tables.Contains("tipo_unidad") Then ds.Tables.Add(dt.Copy)

        dt = New DataTable("tipo_bodega")
        dt.Columns.Add(New DataColumn("bodega", GetType(String)))

        If Not ds.Tables.Contains("tipo_bodega") Then ds.Tables.Add(dt.Copy)
        Me.cmbTipoDocto.Text = "FACTURA"



    End Sub

    Private Sub crearEstructura_devolucion()
        Dim dt, dt2 As New DataTable

        dt.Columns.Add(New DataColumn("tipodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("nodocto", GetType(String)))
        dt.Columns.Add(New DataColumn("fechadocto", GetType(Date)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("preciou", GetType(Double)))
        dt.Columns.Add(New DataColumn("total", GetType(Double)))
        dt.Columns.Add(New DataColumn("MOTIVO", GetType(String)))
        dt.Columns.Add(New DataColumn("BODEGA", GetType(String)))
        dt.Columns.Add(New DataColumn("cod_motivo", GetType(String)))
        dt.Columns.Add(New DataColumn("lote", GetType(String)))
        dt.Columns.Add(New DataColumn("fechavcto", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidadFactura", GetType(Integer)))
        dt.Columns.Add(New DataColumn("secuencia", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("serie_producto", GetType(String)))


        dt.TableName = "productos_devolucion"

        If ds.Tables.Contains("productos_devolucion") Then ds.Tables.Remove("productos_devolucion")
        ds.Tables.Add(dt.Copy)

        dt2.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt2.Columns.Add(New DataColumn("Codigo", GetType(String)))
        dt2.Columns.Add(New DataColumn("Estado", GetType(String)))
        dt2.Columns.Add(New DataColumn("Ctacte", GetType(String)))
        dt2.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
        dt2.Columns.Add(New DataColumn("usuario_solicito", GetType(String)))
        dt2.Columns.Add(New DataColumn("usuario_solicitoD", GetType(String)))
        dt2.Columns.Add(New DataColumn("Total", GetType(Double)))
        dt2.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        dt2.Columns.Add(New DataColumn("usuario_aprobo", GetType(String)))
        dt2.Columns.Add(New DataColumn("fecha_aprobo", GetType(Date)))
        dt2.Columns.Add(New DataColumn("Observaciones", GetType(String)))
        dt2.Columns.Add(New DataColumn("Codestado", GetType(String)))
        dt2.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt2.Columns.Add(New DataColumn("BUM_Asignado", GetType(String)))
        dt2.Columns.Add(New DataColumn("estadotransporte", GetType(String)))
        dt2.Columns.Add(New DataColumn("fecha_transporte", GetType(Date)))
        dt2.Columns.Add(New DataColumn("fecha_rechazo", GetType(Date)))
        dt2.Columns.Add(New DataColumn("motivo_rechazo", GetType(String)))
        dt2.Columns.Add(New DataColumn("forma_entrega", GetType(String)))
        dt2.Columns.Add(New DataColumn("vale", GetType(String)))


        dt2.TableName = "listado_devolucion"

        If ds.Tables.Contains("listado_devolucion") Then ds.Tables.Remove("listado_devolucion")
        ds.Tables.Add(dt2.Copy)

    End Sub

    Private Sub valida_agregar()
        Dim pmotivo As Integer = 0
        Dim ptotal As Integer = 0

        'ds.Tables("productos").
        '        ls_sql = "call pa_sel_um_mov_devolucion_detalle_documentos ('" & gs_empresa & "','"

        ds.Tables("productos").DefaultView.RowFilter = " TOTAL>0  and MOTIVO='' "
        pmotivo = ds.Tables("productos").DefaultView.Count
        ds.Tables("productos").DefaultView.RowFilter = ""
        ds.Tables("productos").DefaultView.RowFilter = " TOTAL>0 "
        ptotal = ds.Tables("productos").DefaultView.Count
        ds.Tables("productos").DefaultView.RowFilter = ""

        If pmotivo = 0 And ptotal > 0 Then
            Agregar_Producto()
        ElseIf ptotal = 0 Then
            MessageBox.Show("No Exiten Productos Para Agregar, Favor Hacer La Verficacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            MessageBox.Show("Existen [" & pmotivo & "] Productos que No Tienen Asignado Motivo de Devolucion, Favor Hacer La Verficacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If


    End Sub

    Private Sub verifica_documentos()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Me.txt_cantidad_facturas.Text = ""
        Try
            dt = clsGen.ValoresDistinto(dgv_devolucion.DataSource, "nodocto".Split(","))
            For Each dr As DataRow In dt.Rows
                Me.txt_cantidad_facturas.Text += dr.Item("nodocto") & "-"
            Next

            Me.lbl_cantidad_productos.Text = Me.dgv_devolucion.Rows.Count
            Try
                Me.lbl_total_devolucion.Text = ds.Tables("productos_devolucion").Compute("sum(total)", "total>0")
            Catch ex As Exception
                Me.lbl_total_devolucion.Text = 0
            End Try


        Catch ex As Exception
            clsGen = Nothing
        End Try

    End Sub

    Private Sub guardar_devolucion()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim liCod_Pedido As Integer
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim lbExitoso As Boolean = True
        Dim total As Double = 0
        Dim fecha As String = ""
        Dim dts As DataTable
        Dim dtt As DataTable
        Dim dtAvisos As DataTable
        Dim nodoctos As String = ""
        Dim dta As DataTable

        Try

            Utrans.open()
            dt = clsgen.ValoresDistinto(Me.dgv_devolucion.DataSource, "bodega".Split(","))
            If dt.Rows.Count > 0 Then

                For Each drs As DataRow In dt.Rows
                    ds.Tables("productos_devolucion").DefaultView.RowFilter = " BODEGA = '" & drs.Item("bodega") & "'"
                    dts = ds.Tables("productos_devolucion").DefaultView.ToTable
                    If dts.Rows.Count > 0 Then

                        total = dts.Compute("sum(total)", "total>0")

                        ls_sql = "pa_var_um_mov_devolucion_encabezado_correlativo '" & gs_empresa & "'"
                        dta = Utrans.Obtiene(ls_sql)

                        dtt = clsgen.ValoresDistinto(dts, "nodocto".Split(","))
                        nodoctos = ""

                        For Each drdoctos As DataRow In dtt.Rows
                            nodoctos += drdoctos.Item("nodocto") & "-"
                        Next

                        ls_sql = "pa_ins_um_mov_devolucion_encabezado '" & gs_empresa & "','" &
                                Me.txt_cod_cliente.Text.Trim & "'," & total & "," & dts.Rows.Count & ",'" &
                                Me.txt_observaciones.Text.Trim.Replace("'", "") & "','" & gs_usuario & "',0,'" &
                                nodoctos & "'," & dta.Rows(0).Item("nuevo_numero").ToString() & ",'" &
                                Me.cmb_solicitantes.SelectedValue.ToString & "'," &
                                IIf(Me.cmbEntrega.Text.ToLower.StartsWith("recoge"), "1", "0") & ",'" &
                                Me.cmbEntrega.Text & "','" & Me.txtVale.Text.Trim & "'"

                        Utrans.Ingresa(ls_sql)

                        If Utrans.Codigo_error = 0 Then
                            dt = Utrans.Obtiene("SELECT @@IDENTITY AS NewID")
                            liCod_Pedido = dt.Rows(0).Item("newid").ToString
                            Dim LineaLocal As Integer = 0

                            For Each dr In dts.Rows
                                LineaLocal += 1
                                If dr.Item("fechavcto").ToString.Length > 0 Then
                                    fecha = Date.Parse(dr.Item("fechavcto").ToString).ToString("dd/MM/yyyy")
                                Else
                                    fecha = " "
                                End If

                                ls_sql = "pa_ins_um_mov_devolucion_detalle " & liCod_Pedido & "," &
                                        "'" & dr.Item("tipodocto").ToString & "','" & dr.Item("nodocto").ToString & "'," & LineaLocal & ",'" & dr.Item("producto").ToString & "'," &
                                        dr.Item("Cantidad") & "," & dr.Item("preciou") & "," & Format(Convert.ToDouble(dr.Item("total").ToString), "########0.00").ToString & ",'" &
                                        dr.Item("cod_motivo").ToString & "','" & dr.Item("lote").ToString & "','" & fecha & "','" & dr.Item("bodega") & "'," & dr.Item("secuencia") & ",'" &
                                        dr.Item("serie").ToString & "'"
                                Utrans.Ingresa(ls_sql)
                                If Utrans.Codigo_error > 0 Then lbExitoso = False
                            Next

                            ''Crear Avisos
                            Try

                                ls_sql = "pa_var_um_devolucion_marca '" & gs_empresa & "'," & dta.Rows(0).Item("nuevo_numero").ToString()
                                dtAvisos = Utrans.Obtiene(ls_sql)
                                If dtAvisos.Rows.Count > 0 Then
                                    For Each dr In dtAvisos.Rows
                                        'clsgen.guardarAviso(dr.Item("bum_aprueba").ToString, "Umbright", "Se Grabo Una Devolucion En " & gs_empresa.ToUpper & " No. " & dta.Rows(0).Item("nuevo_numero").ToString, 27)
                                        Try
                                            enviarCorreo(dr.Item("bum_aprueba").ToString, dta.Rows(0).Item("nuevo_numero").ToString)
                                        Catch ex As Exception

                                        End Try


                                    Next

                                End If
                            Catch ex As Exception

                            End Try


                        Else
                            If Utrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                lbExitoso = True

                            Else
                                lbExitoso = False
                            End If
                        End If

                    End If


                    ds.Tables("productos_devolucion").DefaultView.RowFilter = ""

                Next

                'If Me.chk_recogera.Checked = False Then
                '    MessageBox.Show("El Solicitante Debe Hacer La Entrega Fisica del Producto!!!!", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
                MessageBox.Show("Proceso Guardado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            lbExitoso = False
        Finally
            Utrans.close()
            Utrans = Nothing
            clsgen = Nothing

        End Try

    End Sub

    Private Sub enviarCorreo(usuario_bum As String, numero_devolucion As String)


        Dim sBody As String
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "notificacion@umbralcorp.com"
        Dim snombreRemitente As String = "Notificaciones Umbral"
        Dim scuentas As String = ""
        Dim sSubject As String = ""
        Dim ldFechaDocto As Date

        Try




            Dim iCount As Integer = 0

            'sSubject = Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text
            sSubject = "Devolucion Pendiente Aprobar " & numero_devolucion & " en " & gs_empresa

            sBody = "<br>"
            sBody = sBody & "Se le Informa que se ha ingresado una Devolucion  " ' & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
            'sBody = sBody & Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text & "<br>"
            'sBody = sBody & "Proveedor " & Me.txtProveedor.Text & "<br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & "Cliente: " & Me.txt_nombre_cliente.Text & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            'If Me.txtComentario4.Text.Length > 0 Then
            'sBody = sBody & " Comentarios " & Me.txtComentario4.Text
            'End If




            Try
                Dim dtBU As DataTable
                Dim dtCorreo As DataTable
                'dtBU = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmbTipoDocto.SelectedValue.ToString & "','" & Me.txtNumero.Text & "'")
                ' ldFechaDocto = dtBU.Rows(0).Item("fecha_docto")
                '  dtBU = clsGen.ValoresDistinto(dtBU, "analisisproducto17".Split(","))
                '   For Each dr As DataRow In dtBU.Rows
                '' Debo obtener las personas que tienen permisos para esa unidad de negocio
                'Dim dtUsuarioBU As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null, '" & dr.Item("analisisproducto17").ToString & "','" & gs_empresa & "'")
                'For Each drBU As DataRow In dtUsuarioBU.Rows
                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & usuario_bum & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If

                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & gs_usuario & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If


                '    Next

                'Next
                ''Correos por empresa
                'dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod null, 'gen_correo_internaci', '" & gs_empresa & "'")
                'For Each dr As DataRow In dtCorreo.Rows
                ' If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                ' scuentas = scuentas & dr.Item("descripcion").ToString
                ' Next



            Catch ex As Exception
                clsGen.Escribir_Log(ex.Message)

            End Try




            'scuentas = "coscal@umbral.com.gt, chernandez@logiservicios.com"
            'Dim lsRuta As String = generarPDF(ldFechaDocto.ToString("yyyyMM"))

            clsGen.enviarcorreo(sRemitente, snombreRemitente, scuentas, sSubject, sBody, "")

            'Ruta En Servidor

            'Dim lsRutaServidor As String = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" &
            ' gs_empresa & "\" & ldFechaDocto.ToString("yyyyMM")


            Try
                '    If Not Directory.Exists(lsRutaServidor) Then
                '   Directory.CreateDirectory(lsRutaServidor)
                '  End If
            Catch ex As Exception

            End Try

            ' lsRutaServidor &= "\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"

            'clsGen.Copiar_Archivo(lsRuta, lsRutaServidor, True)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub actualizar_devolucion()

        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim liCod_Pedido As Integer
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim lbExitoso As Boolean = True
        Dim total As Double = 0
        Dim entra As Boolean = False
        Dim fecha As String = ""

        Try
            Utrans.open()
            total = ds.Tables("productos_devolucion").Compute("sum(total)", "total>0")

            ls_sql = "pa_var_um_mov_devolucion_encabezado_correlativo '" & gs_empresa & "'"
            dt = Utrans.Obtiene(ls_sql)

            'If Me.chk_recogera.Checked = False Then
            '    MessageBox.Show("El Solicitante Debe Hacer La Entrega Fisica del Producto!!!!", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If

            If Me.cmb_estado_devolucion.SelectedValue = 20 Then
                'If Me.cmb_estado_memo.SelectedItem.ToString.StartsWith("Apr") Then 'APROBAR 1
                If tiene_permisos("mco_devoluciones_aprobar") Then

                    'Verificar Marcas para Autorizacion por Marcas
                    If validarMarcas() Then
                        If validarDevoluciones() Then
                            ls_sql = "pa_upd_um_mov_devolucion_encabezado_estado_apruebaP " & pi_devolucion & ",'" & Me.txt_observaciones.Text.Trim & "','" & gs_usuario & "',1," &
                                    IIf(Me.cmbEntrega.Text.ToLower.StartsWith("recoge"), "1", "0")

                            Utrans.Actualiza(ls_sql)
                            entra = True
                            MessageBox.Show("Proceso Actualizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Else
                        MessageBox.Show("No Tiene Permisos Para Aprobar No Hay Marcas Asociadas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        entra = True
                    End If
                Else
                    MessageBox.Show("No Tiene Permisos Para Aprobar Devoluciones", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    entra = True
                End If
            ElseIf Me.cmb_estado_devolucion.SelectedValue = 100 Then

                '    If Me.cmb_estado_memo.SelectedItem.ToString.StartsWith("Anu") Then 'ANULAR 2
                If tiene_permisos("mco_devoluciones_anular") Then
                    If Me.txtFechaTransporte.Text.Trim.Length = 0 Then
                        ls_sql = "pa_upd_um_mov_devolucion_encabezado_estado_anulaP " & pi_devolucion & ",'" & Me.txt_observaciones.Text.Trim & "','" & gs_usuario & "',2"
                        Utrans.Actualiza(ls_sql)
                        entra = True
                        MessageBox.Show("Proceso Actualizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        entra = True
                        MessageBox.Show("Esta Devolucion No Se Puede Anular, Ya Esta Procesada Por Transportes", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    MessageBox.Show("No Tiene Permisos Para Anular Devoluciones", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    entra = True
                End If
            ElseIf Me.cmb_estado_devolucion.SelectedValue = 80 Then 'Rechazado BUM

                'If Me.cmb_estado_memo.SelectedItem.ToString.ToLower.StartsWith("rech") And estado = False Then 'RECHAZAR 4
                If tiene_permisos("mco_devoluciones_rechazarBUM") Then
                    Dim lsRechazo As String = InputBox("Motivo de Rechazo", "Rechazo")
                    ls_sql = "pa_upd_um_mov_devolucion_encabezado_rechazoBUM " & pi_devolucion & ",'" & lsRechazo & "','" & gs_usuario & "',4"
                    Utrans.Actualiza(ls_sql)
                    entra = True
                    MessageBox.Show("Proceso Actualizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No Tiene Permisos Para Rechazar Devoluciones", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    entra = True
                End If
            ElseIf Me.cmb_estado_devolucion.SelectedValue = 90 Then

                'If Me.cmb_estado_memo.SelectedItem.ToString.ToLower.StartsWith("rech") And estado = False Then 'RECHAZAR 4
                If tiene_permisos("mco_devoluciones_rechazar") Then
                    Dim lsRechazo As String = InputBox("Motivo de Rechazo", "Rechazo")
                    ls_sql = "pa_upd_um_mov_devolucion_encabezado_rechazo " & pi_devolucion & ",'" & lsRechazo & "','" & gs_usuario & "',4"
                    Utrans.Actualiza(ls_sql)
                    entra = True
                    MessageBox.Show("Proceso Actualizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No Tiene Permisos Para Rechazar Devoluciones", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    entra = True
                End If

            End If


            If Me.cmb_estado_devolucion.SelectedValue = 10 And tiene_permisos("mco_devoluciones_actualizar") Then
                ls_sql = "pa_sel_um_mov_devolucion '" & gs_empresa & "'," & pi_devolucion
                dt = Utrans.Obtiene(ls_sql)
                If dt.Rows(0).Item("usuario_grabo").ToString.ToLower.Equals(gs_usuario.ToLower) Then
                    'And gs_usuario = gs_usuario Then
                    If MessageBox.Show("Esta Seguro de Modificar Esta Devolucion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If validarDevoluciones() Then
                            ls_sql = "pa_upd_um_mov_devolucion_encabezadoP " & pi_devolucion & "," & total & "," & Me.dgv_devolucion.Rows.Count & ",'" & Me.txt_observaciones.Text.Trim & "','" & gs_usuario & "','" & Me.txt_cantidad_facturas.Text & "'," &
                                    IIf(Me.cmbEntrega.Text.ToLower.StartsWith("recoge"), "1", "0") &
                                    "," & Me.cmb_estado_devolucion.SelectedValue
                            'IIf(Me.hk_recogera.Checked = True, 1, 0)
                            Utrans.Actualiza(ls_sql)

                            If Utrans.Codigo_error = 0 Then
                                Dim LineaLocal As Integer = 0

                                ls_sql = "pa_del_um_mov_devolucion_detalle " & pi_devolucion & ""
                                Utrans.Elimina(ls_sql)

                                For Each dr In ds.Tables("productos_devolucion").Rows
                                    LineaLocal += 1
                                    If dr.Item("fechavcto").ToString.Length > 0 Then
                                        fecha = Date.Parse(dr.Item("fechavcto").ToString).ToString("dd/MM/yyyy")
                                    Else
                                        fecha = " "
                                    End If

                                    ls_sql = "pa_ins_um_mov_devolucion_detalle " & pi_devolucion & "," &
                                            "'" & dr.Item("tipodocto").ToString & "','" & dr.Item("nodocto").ToString & "'," & LineaLocal & ",'" & dr.Item("producto").ToString & "'," &
                                            dr.Item("Cantidad") & "," & dr.Item("preciou") & "," & Format(Convert.ToDouble(dr.Item("total").ToString), "########0.00").ToString & ",'" & dr.Item("cod_motivo").ToString & "','" & dr.Item("lote").ToString & "','" & fecha & "','" & dr.Item("bodega") & "'"
                                    Utrans.Ingresa(ls_sql)
                                    If Utrans.Codigo_error > 0 Then lbExitoso = False
                                Next
                                MessageBox.Show("Proceso Actualizado con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                If Utrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                    lbExitoso = True
                                Else
                                    lbExitoso = False
                                End If
                            End If 'utrans error
                        End If 'pasa devoluciones
                    End If 'esta seguro
                Else
                    MessageBox.Show("Solo El Usuario Que Grabo Puede Modificar", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If 'usuario grabo
            End If
        Catch ex As Exception
            lbExitoso = False
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try


    End Sub

    Private Function validarDevoluciones()
        ''Verificar Devoluciones dentro de las solicitudes

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL, lsDevoluciones As String
        Dim dt As DataTable
        Dim nCantidad As Integer
        Dim lbSindevoluciones As Boolean = True

        Try
            Otrans.open()

            For Each dr As DataRow In ds.Tables("productos_devolucion").Rows

                lsSQL = "pa_var_um_devolucion_validacion '" & gs_empresa & "','" & Me.txt_cod_cliente.Text & "','" &
                     dr.Item("tipodocto").ToString & "','" & dr.Item("nodocto").ToString & "','" & dr.Item("producto").ToString & "'," &
                    IIf(dr.Item("lote").ToString.Trim.Length > 0, "'" & dr.Item("lote") & "'", "null")

                dt = Otrans.Obtiene(lsSQL)
                If dt.Rows.Count > 0 Then
                    nCantidad = dt.Compute("sum(cantidad)", "cantidad>0")
                    If dr.Item("cantidadFactura") >= nCantidad + dr.Item("cantidad") Then
                    Else
                        lsDevoluciones = String.Empty
                        For Each dr2 As DataRow In dt.Rows
                            lsDevoluciones = dr2.Item("correlativo").ToString & ", "

                        Next

                        MessageBox.Show("El Producto " + dr.Item("Producto") + " SobrePasa la Cantidad Facturada " + Chr(13) &
                            "Esta Asignado en La(s) Devolucion(es) " & lsDevoluciones, "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lbSindevoluciones = False
                    End If
                End If
            Next
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

        Return lbSindevoluciones
    End Function

    Private Function validarMarcas() As Boolean
        Dim lbMarcasValidas As Boolean = False
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            Otrans.open()
            lsSQL = "pa_var_um_devolucion_marca '" & gs_empresa & "'," & Me.lbl_cod_devolucion.Text.Trim
            dt = Otrans.Obtiene(lsSQL)
            dt.DefaultView.RowFilter = "bum_aprueba = '" & gs_usuario & "'"
            If dt.DefaultView.Count > 0 Then
                lbMarcasValidas = True
            ElseIf tiene_permisos("mco_devoluciones_administrar") Then
                lbMarcasValidas = True
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return lbMarcasValidas
    End Function

    Private Sub llenar_informacion()
        Dim ls_sqls As String
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim clsgen As New ClasesGenerales.General
        Dim Utrans As New Transaccional.Conexion("flexline")


        Try

            Try
                Me.dgv_listado_liquidaciones.DataSource = Nothing
                ds.Tables("listado_devolucion").Rows.Clear()
            Catch ex As Exception
            End Try

            Utrans.open()
            If tiene_permisos("mco_devoluciones_operar") Or tiene_permisos("mco_devoluciones_aprobar") Then
                ls_sqls = "pa_sel_um_devolucion_encabezado_listado '" & gs_empresa & "',0,'" & Me.dtpFiltroFechaInicio.Value & "','" & Me.dtpFiltroFechaFinal.Value & "'"
                Me.btn_guardar.Visible = True
                Me.btn_agrega_producto.Visible = True
            End If




            If tiene_permisos("mco_devoluciones_rechazar") Then
                Me.btn_guardar.Visible = True
            End If


            If tiene_permisos("mco_devoluciones_imprimir") Then
                Me.btn_imprimir.Visible = True
            Else
                Me.btn_imprimir.Visible = False
            End If

            If gi_tipo_usuario = 1 Then
                ls_sqls = "pa_sel_um_devolucion_encabezado_listado_gen '" & gs_empresa & "','" & Me.dtpFiltroFechaInicio.Value & "','" & Me.dtpFiltroFechaFinal.Value & "'"
            End If

            If ls_sqls <> Nothing Then
                dt = Utrans.Obtiene(ls_sqls)
            End If

            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    dr_aux = ds.Tables("listado_devolucion").NewRow
                    dr_aux.Item("Numero") = dr.Item("cod_devolucion")
                    dr_aux.Item("Codigo") = dr.Item("correlativo")
                    dr_aux.Item("Estado") = dr.Item("estadod")

                    dr_aux.Item("Ctacte") = dr.Item("ctacte")
                    dr_aux.Item("Razon_Social") = dr.Item("razonSocial")
                    dr_aux.Item("usuario_solicito") = dr.Item("usuario_solicito1")
                    dr_aux.Item("usuario_solicitoD") = dr.Item("usuario_solicito")
                    dr_aux.Item("Total") = dr.Item("total_devolucion")
                    dr_aux.Item("Fecha") = dr.Item("fecha_devolucion")
                    dr_aux.Item("usuario_aprobo") = dr.Item("usuario_aprobo")
                    dr_aux.Item("fecha_aprobo") = dr.Item("fecha_aprobacion")
                    dr_aux.Item("Observaciones") = dr.Item("comentarios")
                    dr_aux.Item("CodEstado") = dr.Item("estado")
                    dr_aux.Item("usuario_grabo") = dr.Item("usuario_grabod")
                    dr_aux.Item("estadotransporte") = dr.Item("estadotransporte")
                    dr_aux.Item("forma_entrega") = dr.Item("forma_entrega")
                    Try
                        dr_aux.Item("fecha_rechazo") = dr.Item("fecha_rechazo_transporte")
                    Catch ex As Exception
                    End Try

                    dr_aux.Item("motivo_rechazo") = dr.Item("motivo_rechazo_transporte").ToString

                    Try
                        dr_aux.Item("fecha_transporte") = dr.Item("fecha_asigna_ruta")
                    Catch ex As Exception
                    End Try

                    dr_aux.Item("vale") = dr.Item("vale").ToString
                    dr_aux.Item("BUM_Asignado") = dr.Item("BUM_Aprueba").ToString
                    ds.Tables("listado_devolucion").Rows.Add(dr_aux)
                Next

                Me.dgv_listado_liquidaciones.DataSource = ds.Tables("listado_devolucion")
                clsgen.Alinear_GridView(ds.Tables("listado_devolucion"), Me.dgv_listado_liquidaciones,
                    ",Numero,Codigo,Estado,Ctacte,Razon_Social,Total,Fecha,Observaciones,CodEstado,usuario_solicito,usuario_aprobo,usuario_grabo,estadotransporte,fecha_rechazo,motivo_rechazo,bum_asignado,", ",Numero,usuario_solicitoD,CodEstado,estadotransporte,", ", Numero,Estado,Ctacte,Razon_Social,Total,Fecha,Observaciones,Usuario_solicito,usuario_aprobo,usuario_grabo,", ",Total,", ",Codigo=Numero,", "", "", True, True, 200, 0)


            End If
        Catch ex As Exception
        Finally
            Utrans.close()
            Utrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub mostrarDevolucion()
        Dim pi_row As Integer
        Dim clsgen As New ClasesGenerales.General

        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim ls_sqls As String
        Dim dt, dt2 As DataTable
        Dim dr, dr_aux As DataRow
        Dim drv As DataRowView

        Me.btnValidar.Visible = False
        Me.btnLiberar.Visible = False
        Me.btnSalida.Visible = False

        Ods.Tables("motivos").DefaultView.RowFilter = ""
        pi_devolucion = ""
        pi_row = Me.dgv_listado_liquidaciones.CurrentRow.Index()
        pi_devolucion = Me.dgv_listado_liquidaciones.Item("codigo", pi_row).Value
        Me.lbl_cod_devolucion.Text = pi_devolucion
        Me.lbl_cod_devolucion.Visible = True
        'Me.lbl_devolucion.Visible = True
        pi_devolucion = Me.dgv_listado_liquidaciones.Item("numero", pi_row).Value
        Me.dtp_fecha_memo.Text = Me.dgv_listado_liquidaciones.Item("fecha", pi_row).Value
        Me.lbl_numero_devolucion.Text = Me.dgv_listado_liquidaciones.Item("Codigo", pi_row).Value
        Me.lblEstadoActual.Text = Me.dgv_listado_liquidaciones.Item("estado", pi_row).Value
        Me.txtVale.Text = Me.dgv_listado_liquidaciones.Item("vale", pi_row).Value

        estado = False
        Me.cmbEntrega.Enabled = False

        Me.txt_usuario_opera_memo.Text = Me.dgv_listado_liquidaciones.Item("usuario_grabo", pi_row).Value
        Me.cmb_solicitantes.SelectedValue = Me.dgv_listado_liquidaciones.Item("usuario_solicitoD", pi_row).Value

        Try
            Me.dgv_devolucion.DataSource = Nothing
            ds.Tables("productos_devolucion").Rows.Clear()
            ds.Tables("productos").Rows.Clear()
            Me.txt_NoDocto.Text = ""

        Catch ex As Exception

        End Try

        Try
            Me.cmbEntrega.Text = Me.dgv_listado_liquidaciones.Item("forma_entrega", pi_row).Value
            'Me.lblEntregaSolicitante.Visible = False
            'If Me.dgv_listado_liquidaciones.Item("estadotransporte", pi_row).Value > 0 Then
            'Me.chk_recogera.Checked = True
            'Else
            'Me.chk_recogera.Checked = False
            'Me.lblEntregaSolicitante.Visible = True
            'End If
        Catch ex As Exception
            'Me.chk_recogera.Checked = False
        End Try


        Try

            Utrans.open()

            ls_sqls = "pa_sel_um_mov_devolucion '" & gs_empresa & "'," & Me.dgv_listado_liquidaciones.Item("Numero", pi_row).Value & ""
            dt = Utrans.Obtiene(ls_sqls)

            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows

                    dr_aux = ds.Tables("productos_devolucion").NewRow
                    dr_aux.Item("tipodocto") = dr.Item("tipodocto")
                    dr_aux.Item("nodocto") = dr.Item("nodocto")
                    Try
                        dr_aux.Item("fechadocto") = dr.Item("fecha_docto")
                        'dt.Columns.Add(New DataColumn("fechadocto", GetType(Date)))
                    Catch ex As Exception

                    End Try
                    dr_aux.Item("producto") = dr.Item("producto")
                    dr_aux.Item("glosa") = dr.Item("glosa")
                    dr_aux.Item("cantidad") = dr.Item("cantidad")
                    dr_aux.Item("preciou") = dr.Item("precio")
                    dr_aux.Item("total") = dr.Item("total_linea")
                    dr_aux.Item("motivo") = dr.Item("motivo")
                    dr_aux.Item("bodega") = dr.Item("bodega")
                    dr_aux.Item("cod_motivo") = dr.Item("cod_motivo")
                    dr_aux.Item("lote") = dr.Item("lote")


                    If dr.Item("fechavcto").ToString = "1900-01-01 00:00:00" Or dr.Item("fechavcto").ToString = "1900/01/01 00:00:00" Or dr.Item("fechavcto").ToString = "01/01/1900 00:00:00" Then
                        dr_aux.Item("fechavcto") = ""
                    Else
                        dr_aux.Item("fechavcto") = dr.Item("fechavcto")
                    End If

                    Try


                        ls_sqls = "pa_sel_um_documento_detalle '" + dr.Item("tipodocto").ToString & "','" & gs_empresa & "','" & dr.Item("nodocto").ToString & "'"
                        dt2 = Utrans.Obtiene(ls_sqls)
                        dt2.DefaultView.RowFilter = "producto = '" & dr.Item("producto") & "' and secuencia = " & dr.Item("secuenciaOrigen")
                        dt2 = dt2.DefaultView.ToTable
                        If dt2.Rows.Count > 0 Then
                            dr_aux.Item("cantidadFactura") = dt2.Rows(0).Item("cantidad")

                        End If

                    Catch ex As Exception
                        dr_aux.Item("cantidadFactura") = 0

                    End Try



                    dr_aux("serie") = dr.Item("serie")
                    ds.Tables("productos_devolucion").Rows.Add(dr_aux)

                Next

                Me.dgv_devolucion.DataSource = ds.Tables("productos_devolucion")
                clsgen.Alinear_GridView(ds.Tables("productos_devolucion"), Me.dgv_devolucion, " ,tipodocto,nodocto,fechadocto,producto,glosa,cantidad,preciou,total,motivo,bodega,cod_motivo,lote,fechavcto,", ",cod_motivo,", ",tipodocto,nodocto,producto,glosa,cantidad,preciou,total,motivo,bodega,", ",cantidad,preciou,total,", ",tipodocto=TIPODOCTO,nodocto=NUMERO,fechadocto=FECHA FAC,producto=PRODUCTO,glosa=GLOSA,cantidad=CANTIDAD,preciou=PRECIO,total=TOTAL,motivo=MOTIVO,bodega=BODEGA,lote=LOTE,fechavcto=FECHAVCTO,", ",producto=75,cantidad=70,nodocto=70,preciou=60,", "", True, True, 250, 0)
                Me.txt_cantidad_facturas.Text = dt.Rows(0).Item("documentos")
                Me.txt_observaciones.Text = dt.Rows(0).Item("comentarios")
                Me.txt_cod_cliente.Text = dt.Rows(0).Item("ctacte")
                Me.lbl_cantidad_productos.Text = Me.dgv_devolucion.Rows.Count
                Me.lbl_total_devolucion.Text = ds.Tables("productos_devolucion").Compute("sum(total)", "total>0")
                Buscar_Cliente()

                ''validar si esta disponible para modificar o anular

                Me.lbl_estado.Visible = True
                Me.cmb_estado_devolucion.Visible = True
                Me.btn_guardar.Text = "Actualizar"

                Me.lblAprobacion.Visible = False
                Me.txtAprobado.Visible = False
                Me.txtFechaAprobacion.Visible = False
                Me.lblFechaAprobacion.Visible = False
                Me.txtFechaTransporte.Visible = False
                Me.dtpFechaDocumento.Visible = False
                Me.lblFechaAprobacion.Text = "Fec Transporte"
                Me.lblAprobacion.Text = "Aprobado Por"


                'If ds.Tables("listado_devolucion").Rows(pi_row).Item("estado") = "Aprobado" Then
                If Me.dgv_listado_liquidaciones.Item("estado", pi_row).Value = "Aprobado" Then
                    Me.cmb_estado_devolucion.Text = "Pendiente Aprobacion"
                    Me.cmb_estado_devolucion.Enabled = True
                    Me.btn_guardar.Visible = True
                    Me.lbl_nodocto.Visible = False
                    Me.txt_NoDocto.Visible = False
                    Me.lblAprobacion.Visible = True
                    Me.txtAprobado.Visible = True
                    Me.txtFechaAprobacion.Visible = True
                    Me.lblFechaAprobacion.Visible = True
                    Me.txtFechaTransporte.Visible = True
                    Me.txtAprobado.Text = Me.dgv_listado_liquidaciones.Item("usuario_aprobo", pi_row).Value
                    Me.txtFechaAprobacion.Text = Me.dgv_listado_liquidaciones.Item("fecha_aprobo", pi_row).Value

                    If Me.txt_cod_cliente.Text.StartsWith("2968550") Then
                        Me.btnValidar.Visible = True
                        If tiene_permisos("mco_devolucion_operarsalida") Then
                            Me.btnSalida.Visible = True
                        End If
                    End If

                    If tiene_permisos("mfi_LiberarProductos_Facturas") Then
                        Me.btnLiberar.Visible = True
                    End If

                    Try
                        Me.txtFechaTransporte.Text = Me.dgv_listado_liquidaciones.Item("fecha_transporte", pi_row).Value
                    Catch ex As Exception
                    End Try

                    Me.cmb_estado_devolucion.Text = ""

                ElseIf Me.dgv_listado_liquidaciones.Item("estado", pi_row).Value = "Pendiente de Aprobacion" Then
                    Me.cmb_estado_devolucion.Text = "Pendiente de Aprobacion"
                    Me.cmb_estado_devolucion.Enabled = True
                    Me.btn_guardar.Visible = True
                    Me.txt_NoDocto.Visible = True
                    Me.btn_guardar.Text = "Actualizar"

                ElseIf Me.dgv_listado_liquidaciones.Item("estado", pi_row).Value = "Anulado" Then
                    Me.cmb_estado_devolucion.Text = "Anulado"
                    Me.cmb_estado_devolucion.Enabled = False
                    Me.btn_guardar.Visible = False
                    Me.txt_NoDocto.Visible = False

                ElseIf Me.dgv_listado_liquidaciones.Item("estado", pi_row).Value = "Asignacion de Transporte" Then
                    Me.cmb_estado_devolucion.Text = "Asignacion de Transporte"
                    Me.cmb_estado_devolucion.Enabled = False
                    Me.btn_guardar.Visible = False
                    Me.txt_NoDocto.Visible = False


                ElseIf Me.dgv_listado_liquidaciones.Item("estado", pi_row).Value = "Revisado" Then
                    Me.cmb_estado_devolucion.Text = "Revisado"
                    Me.cmb_estado_devolucion.Enabled = True
                    Me.btn_guardar.Visible = False
                    Me.txt_NoDocto.Visible = False



                ElseIf Me.dgv_listado_liquidaciones.Item("estado", pi_row).Value.ToString.ToLower.StartsWith("rechazado") Then
                    'Me.cmb_estado_memo.Text = "Pendiente de Aprobacion"
                    Me.cmb_estado_devolucion.SelectedValue = 10
                    Me.cmb_estado_devolucion.Enabled = False
                    Me.btn_guardar.Visible = True
                    Me.txt_NoDocto.Visible = True
                    Me.lblAprobacion.Visible = True
                    Me.lblAprobacion.Text = "Motivo de Rechazo"
                    Me.lblFechaAprobacion.Visible = True
                    Me.lblFechaAprobacion.Text = Me.dgv_listado_liquidaciones.Item("motivo_rechazo", pi_row).Value
                    estado = True

                End If
                Me.TabControl1.SelectedTab = Me.TabPage1
            End If
        Catch ex As Exception
        Finally
            Utrans.close()
            Utrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub limpiar_pantalla()
        Me.lbl_estado.Visible = False
        Me.cmb_estado_devolucion.Visible = False
        Me.txt_cod_cliente.Text = ""
        Me.txt_nit.Text = ""
        Me.txt_nombre_cliente.Text = ""
        Me.txt_direccion.Text = ""
        Me.txt_vendedor.Text = ""
        Me.txt_lista_Precios.Text = ""
        Me.txt_NoDocto.Text = ""
        Me.txt_cantidad_facturas.Text = ""
        Me.txt_observaciones.Text = ""
        Me.btn_guardar.Text = "Guardar"
        Me.txt_cod_cliente.Enabled = True
        Me.lbl_cantidad_productos.Text = ""
        Me.lbl_total_devolucion.Text = ""
        Me.lblEstadoActual.Text = String.Empty
        Me.btn_buscar_producto.Enabled = True
        Me.lbl_cod_devolucion.Text = ""
        Me.lbl_cod_devolucion.Visible = False
        'Me.lbl_devolucion.Visible = False
        Me.cmb_solicitantes.Enabled = True
        Me.lbl_numero_devolucion.Text = 0
        Me.lbl_nodocto.Visible = True
        Me.dtpFechaDocumento.Visible = True
        Me.lblAprobacion.Visible = False
        Me.txtAprobado.Visible = False
        Me.txtFechaAprobacion.Visible = False
        Me.lblFechaAprobacion.Visible = False
        Me.txtFechaTransporte.Visible = False
        Me.btnValidar.Visible = False
        Me.btnLiberar.Visible = False
        Me.btnSalida.Visible = False
        Me.txtVale.Text = String.Empty


        'Me.lblEntregaSolicitante.Visible = False
        Me.lblFechaAprobacion.Text = "Fec Transporte"
        Me.lblAprobacion.Text = "Aprobado Por"
        Me.cmbEntrega.Enabled = True
        Me.cmbEntrega.Text = String.Empty

        Me.txt_usuario_opera_memo.Text = gs_nombre_usuario
        estado = False
        Ods.Tables("solicitantes").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"
        cmb_solicitantes.SelectedIndex = -1


        Me.cmb_estado_devolucion.Text = ""

        If tiene_permisos("mco_devoluciones_operar") Or tiene_permisos("mco_devoluciones_aprobar") Or tiene_permisos("mco_devoluciones_actualizar") Then
            Me.btn_guardar.Visible = True
            Me.txt_NoDocto.Visible = True

        End If

        Try
            Me.dgv_liquidacion.DataSource = Nothing
            ds.Tables("productos").Rows.Clear()

        Catch ex As Exception

        End Try

        Try
            Me.dgv_devolucion.DataSource = Nothing
            ds.Tables("productos_devolucion").Rows.Clear()

        Catch ex As Exception

        End Try
        limpiar_campos()
        Try
            crearEstructura()
            ' crearEstructura_devolucion()
        Catch ex As Exception

        End Try
        Ods.Tables("motivos").DefaultView.RowFilter = "substring(codigo,1,1) = 'D'"

    End Sub

    Public Sub Imprimir_Ordenes_pdf()
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(4) As String
        Dim ClsGen As New ClasesGenerales.General
        'Dim oflex As New Umbral_Flex.guateFacturas(gs_empresa)
        Try


            pm_conexion = ClsGen.Parametros_Conexion("VDataServer")
            path_reporte = ClsGen.Path_Reporte()
            path_reporte += "Direccion Comercial\Devoluciones.rpt"

            pm_parametros(0) = "@Pempresa"
            pm_parametros(1) = "@Pcod_devolucion"

            pm_valores(0) = gs_empresa
            pm_valores(1) = pi_devolucion

            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
            '               pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
            '               False, True, "PDF", False, "", True)



            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                          False, True, "PDF", False, "", True, 1, gs_empresa, "")

        Catch ex As Exception
            ClsGen.Escribir_Log("Imprimir Ordenes Pdf " & ex.ToString)
            ClsGen.Escribir_Log("Imprimir Ordenes Pdf " & ex.Message)
        Finally
            ClsGen = Nothing


        End Try


    End Sub

    Private Sub actualizar_estado()

        Dim Utrans As New Transaccional.Conexion("flexline")


        Dim liCod_Pedido As Integer
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim lbExitoso As Boolean = True
        Dim total As Double = 0

        Try
            Utrans.open()
            ls_sql = "pa_upd_um_mov_devolucion_encabezado_estado " & pi_devolucion & ",'" & Me.txt_observaciones.Text.Trim & "','" & gs_usuario & "',3"
            Utrans.Actualiza(ls_sql)

        Catch ex As Exception
            lbExitoso = False
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub Agregar_Producto()
        Dim clsGen As New ClasesGenerales.General

        Try
            Dim dr, drr, ddr2, dr_aux As DataRow
            Dim pi_row As Integer

            Try

                For Each dr In ds.Tables("productos_devolucion").Rows

                    If dr.Item("producto") = Me.txt_cod_producto.Text.Trim And dr.Item("tipodocto") = Me.tipodocto And dr.Item("nodocto") = Me.txt_NoDocto.Text.Trim Then ' ddr2.Item("producto") And dr.Item("tipodocto") = ddr2.Item("tipodocto") And dr.Item("nodocto") = ddr2.Item("nodocto") Then
                        dr.Delete()
                        Exit For
                    End If


                Next


                ' Next
            Catch ex As Exception
            End Try

            dr_aux = ds.Tables("productos_devolucion").NewRow
            dr_aux.Item("tipodocto") = Me.tipodocto 'drr.Item("tipodocto")
            dr_aux.Item("nodocto") = IIf(Me.nupAnioFACE.Value > 0, Me.nupAnioFACE.Value.ToString, "") & Me.txt_NoDocto.Text.Trim 'drr.Item("nodocto")
            dr_aux.Item("fechadocto") = Me.dtpFechaDocumento.Value
            dr_aux.Item("producto") = Me.txt_cod_producto.Text.Trim 'drr.Item("producto")
            dr_aux.Item("glosa") = Me.txt_descripcion.Text.Trim 'drr.Item("glosa")
            dr_aux.Item("cantidad") = Me.txt_cantidadDevolver.Text.Trim ' drr.Item("devolucion")
            dr_aux.Item("preciou") = Me.preciou ' drr.Item("preciou")
            dr_aux.Item("total") = Me.txt_cantidadDevolver.Text * Me.preciou 'drr.Item("total")
            dr_aux.Item("motivo") = Me.cmb_motivo.Text 'drr.Item("motivo")
            dr_aux.Item("bodega") = Me.cmb_bodega.Text  'drr.Item("motivo")



            dr_aux.Item("cod_motivo") = Me.cmb_motivo.SelectedValue.ToString   'Ods.Tables("motivos").DefaultView(0).Item("CODIGO")
            If Me.lote <> Me.txtLoteProducto.Text Then MessageBox.Show("La Informacion del Lote Cambio, Verifique que sea el Correcto", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Question)

            Try
                If Me.txtLoteProducto.Text.Trim.Length > 0 Then
                    dr_aux.Item("lote") = Me.txtLoteProducto.Text 'drr.Item("lote")
                    dr_aux.Item("fechavcto") = Me.dtpFechaVctoProducto.Value 'drr.Item("fechavcto")
                Else
                    dr_aux.Item("lote") = ""
                End If

            Catch ex As Exception
            End Try

            dr_aux.Item("cantidadFactura") = Me.txt_cantidadFactura.Text
            dr_aux.Item("secuencia") = giSecuencia
            dr_aux.Item("Serie") = Me.txtSerie.Text

            ds.Tables("productos_devolucion").Rows.Add(dr_aux)

            'Next

            Me.dgv_devolucion.DataSource = ds.Tables("productos_devolucion")
            clsGen.Alinear_GridView(ds.Tables("productos_devolucion"), Me.dgv_devolucion, " ,tipodocto,nodocto,fechadocto,producto,glosa,cantidad,preciou,total,motivo,bodega,cod_motivo,lote,fechavcto,serie,", ",cod_motivo,", ",tipodocto,nodocto,producto,glosa,cantidad,preciou,total,motivo,serie,", ",cantidad,preciou,total,", ",tipodocto=TIPODOCTO,nodocto=NUMERO,fechadocto=FECHA FAC,producto=PRODUCTO,glosa=GLOSA,cantidad=CANTIDAD,preciou=PRECIO,total=TOTAL,motivo=MOTIVO,bodega=BODEGA,lote=LOTE,fechavcto=FECHAVCTO,serie=añada,", ",producto=75,cantidad=70,nodocto=70,preciou=60,", "", True, True, 250, 0)
            ds.Tables("productos").DefaultView.RowFilter = ""


            For Each dr In ds.Tables("productos").Rows
                If dr.Item("Producto") = Me.txt_cod_producto.Text.Trim Then
                    dr.Item("estado") = 2
                    Exit For


                End If
            Next

        Catch ex As Exception
            clsGen = Nothing
        End Try

    End Sub


    'Private Sub verificacion_general()
    '    Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
    '    Dim Utrans As New Transaccional.Conexion("flexline")
    '    Dim liCod_Pedido As Integer
    '    Dim ls_sql As String
    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    Dim lbExitoso As Boolean = True
    '    Dim total As Double = 0

    '    Try
    '        myOtrans.open()
    '        Utrans.open()

    '        ls_sql = "call pa_sel_um_mov_cliente_devoluciones ('" & gs_empresa & "','" & Me.txt_cod_cliente.Text.Trim & "')"
    '        dt = myOtrans.Obtiene(ls_sql)
    '        If dt.Rows.Count = 0 Then
    '            ls_sql = "call pa_ins_um_mov_cliente ('" & gs_empresa & "','" & Me.txt_cod_cliente.Text.Trim & "','" & Me.txt_nombre_cliente.Text & "','" & Me.txt_direccion.Text & "','" & Me.txt_vendedor.Text & "')"
    '            myOtrans.Ingresa(ls_sql)
    '        End If


    '        For Each dr In ds.Tables("productos_devolucion").Rows

    '            ls_sql = "call pa_sel_um_mov_producto ('" & gs_empresa & "','" & dr.Item("producto") & "')"
    '            dt = myOtrans.Obtiene(ls_sql)
    '            If dt.Rows.Count = 0 Then

    '                ls_sql = "pa_sel_um_mov_producto '" & gs_empresa & "','" & dr.Item("producto") & "'"
    '                dt = Utrans.Obtiene(ls_sql)
    '                If dt.Rows.Count > 0 Then
    '                    ls_sql = "call pa_ins_um_mov_producto (' " & gs_empresa & "','" & dt.Rows(0).Item("producto") & "','" & dt.Rows(0).Item("golsa") & "')"
    '                    myOtrans.Ingresa(ls_sql)
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception
    '        lbExitoso = False
    '    Finally
    '        myOtrans.close()
    '        myOtrans = Nothing
    '        Utrans.close()
    '        Utrans = Nothing
    '    End Try

    'End Sub
    Private Sub Frm_Devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        crearEstructura_devolucion()

        Try
            Me.dtpFiltroFechaInicio.Value = "01/" & Month(Today.AddMonths(-1)) & "/" & Year(Today.AddMonths(-1))
        Catch ex As Exception

        End Try
        llenarCombos()
        llenar_informacion()
    End Sub
    Private Sub txt_NoDocto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_NoDocto.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.txt_NoDocto.Text = Microsoft.VisualBasic.Right("0000000000" & Me.txt_NoDocto.Text, 10)
            buscar_documento()
        End If
    End Sub

    Private Sub txt_NoDocto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_NoDocto.KeyUp

    End Sub
    Private Sub txt_NoDocto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_NoDocto.Leave
        Me.txt_NoDocto.Text = Microsoft.VisualBasic.Right("0000000000" & Me.txt_NoDocto.Text, 10)
    End Sub


    Private Sub dgv_liquidacion_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_liquidacion.CellPainting


        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try

            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_liquidacion.Rows(rowIndex)
                If Me.dgv_liquidacion.Item("Estado", e.RowIndex).Value = "0" Then
                    therow.DefaultCellStyle.BackColor = Color.White  '.PaleGreen   'LightGreen
                ElseIf Me.dgv_liquidacion.Item("Estado", e.RowIndex).Value = "1" Then
                    therow.DefaultCellStyle.BackColor = Color.Tomato

                ElseIf Me.dgv_liquidacion.Item("Estado", e.RowIndex).Value = "2" Then
                    therow.DefaultCellStyle.BackColor = Color.Gold
                    'ElseIf Me.dgv_liquidacion.Item("Aplica", e.RowIndex).Value = False And Me.dgv_liquidacion.Item("Lo tiene", e.RowIndex).Value = False Then
                    '    therow.DefaultCellStyle.BackColor = Color.White

                End If
                'If Me.dgv_control.Item("Aplica", e.RowIndex).Value = False Then
                '    Me.dgv_control.Item("Lo tiene", e.RowIndex).ReadOnly = True
                'Else
                '    Me.dgv_control.Item("Lo tiene", e.RowIndex).ReadOnly = False
                'End If
                'If Me.dgv_control.Item("Aplica", e.RowIndex).Value = False And Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = True Then
                '    Me.dgv_control.Item("Lo tiene", e.RowIndex).Value = 0
                '    therow.DefaultCellStyle.BackColor = Color.White
                'End If




            End If




        Catch ex As Exception
        End Try
        'Dim colIndex As Integer = e.ColumnIndex
        'Dim rowIndex As Integer = e.RowIndex
        'Dim therow As DataGridViewRow


        'Try
        '    If colIndex > -1 And rowIndex > -1 Then
        '        therow = Me.dgv_devolucion.Rows(rowIndex)

        '        If dgv_devolucion.Columns(colIndex).Name.ToLower.IndexOf("estado") > -1 Then
        '            If dgv_devolucion.Item(colIndex, rowIndex).Value.ToString.ToLower = "1" Then
        '                Me.dgv_devolucion.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
        '            Else
        '                Me.dgv_devolucion.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Yellow


        '            End If
        '        End If

        '    End If

        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub dgv_liquidacion_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_liquidacion.CellValueChanged
        Try
            detalle_pedido(Me.dgv_liquidacion.CurrentRow.Index)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub dgv_devolucion_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_devolucion.UserDeletedRow
        verifica_documentos()
    End Sub

    Private Sub dgv_devolucion_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgv_devolucion.UserDeletingRow
        verifica_documentos()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If Me.dgv_devolucion.Rows.Count > 0 And Me.txt_cod_cliente.Text.Trim.Length > 0 Then
            If MessageBox.Show("Esta seguro de Guardar Cambios ", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If Me.btn_guardar.Text = "Guardar" Then
                    If Me.cmbEntrega.Text.Trim.Length > 0 Then
                        If validarDevoluciones() Then
                            guardar_devolucion()
                            limpiar_pantalla()
                            llenar_informacion()
                        End If
                    Else
                        MessageBox.Show("Debe Seleccion Modo de Entrega de la Devolucion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cmbEntrega.Focus()
                    End If
                Else
                    actualizar_devolucion()
                    limpiar_pantalla()
                    llenar_informacion()
                End If

            End If
        Else
            MessageBox.Show("No se puede Guardar Cambios, Favor Hacer la Verificacion", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub dgv_listado_liquidaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado_liquidaciones.DoubleClick
        mostrarDevolucion()

        If Me.txt_nombre_cliente.Text.Trim.Length > 0 Then
            Me.txt_cod_cliente.Enabled = False
            Me.btn_buscar_producto.Enabled = False
            Me.cmb_solicitantes.Enabled = False
        Else
            Me.txt_cod_cliente.Enabled = True
            Me.btn_buscar_producto.Enabled = True
            Me.cmb_solicitantes.Enabled = True
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar_pantalla()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Imprimir_Ordenes_pdf()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        valida_agregar()
        verifica_documentos()
    End Sub

    Private Sub dgv_devolucion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dgv_devolucion.Validating
        verifica_documentos()
    End Sub
    Private Sub lbl_total_devolucion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_total_devolucion.TextChanged
        Try
            Me.lbl_total_devolucion.Text = Format(Convert.ToDecimal(lbl_total_devolucion.Text), "###,###,##0.00").ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub detalle_pedido(ByVal pirow As Integer)
        Try
            Me.tipodocto = Me.dgv_liquidacion.Item("tipodocto", pirow).Value
            Me.preciou = Me.dgv_liquidacion.Item("preciou", pirow).Value
            Try
                Me.lote = Me.dgv_liquidacion.Item("lote", pirow).Value
                Me.fechavcto = Me.dgv_liquidacion.Item("fechavcto", pirow).Value
            Catch ex As Exception
            End Try

            Try
                Me.sgdetalleSerie = Me.dgv_liquidacion.Item("serie", pirow).Value
            Catch ex As Exception

            End Try
            Me.txt_cod_producto.Text = Me.dgv_liquidacion.Item("producto", pirow).Value
            Me.txt_descripcion.Text = Me.dgv_liquidacion.Item("glosa", pirow).Value
            Me.txt_cantidadFactura.Text = Me.dgv_liquidacion.Item("cantidad", pirow).Value
            Me.txt_cantidadDevolver.Text = Me.dgv_liquidacion.Item("devolucion", pirow).Value
            Me.txtLoteProducto.Visible = False
            Me.dtpFechaVctoProducto.Visible = False
            Me.lblLote.Visible = False
            Me.lblFechaVcto.Visible = False
            Me.txtLoteProducto.Text = ""
            Me.dtpFechaVctoProducto.Value = Today
            If Me.dgv_liquidacion.Item("lote", pirow).Value.ToString.Length > 0 Then

                Me.txtLoteProducto.Visible = True
                Me.dtpFechaVctoProducto.Visible = True
                Me.lblLote.Visible = True
                Me.lblFechaVcto.Visible = True
                Try
                    Me.txtLoteProducto.Text = Me.dgv_liquidacion.Item("lote", pirow).Value
                Catch ex As Exception

                End Try

                Try
                    Me.dtpFechaVctoProducto.Value = Me.dgv_liquidacion.Item("fechaVCTO", pirow).Value
                Catch ex As Exception

                End Try
            End If


            Me.txtSerie.Visible = False
            Me.lblSerie.Visible = False
            Me.txtSerie.ReadOnly = True
            ''Verificar que el producto Maneja Serie
            If Me.dgv_liquidacion.Item("serie_producto", pirow).Value.ToString.ToUpper.Equals("S") Then

                Me.txtSerie.Visible = True
                Me.lblSerie.Visible = True
                Me.txtSerie.ReadOnly = False
                Me.txtSerie.Text = Me.dgv_liquidacion.Item("serie", pirow).Value
            End If

            giSecuencia = Me.dgv_liquidacion.Item("secuencia", pirow).Value
            Me.cmb_motivo.SelectedIndex = -1
            Me.cmb_bodega.SelectedIndex = -1
            ' Me.txt_cantidadDevolver.Focus()


        Catch ex As Exception

        End Try



    End Sub
    Private Sub dgv_liquidacion_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_liquidacion.CurrentCellChanged
        Try
            detalle_pedido(Me.dgv_liquidacion.CurrentRow.Index)

        Catch ex As Exception

        End Try
    End Sub
    Function validar_campos() As Boolean
        If Me.txt_NoDocto.Text.Trim.Length > 0 Then

            If Me.txt_cantidadDevolver.Text.Trim.Length > 0 Then
            Else
                MessageBox.Show("Ingrese Cantidad a Devolver", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txt_cantidadDevolver.Focus()
                Return False

            End If

            If Val(Me.txt_cantidadDevolver.Text) > Val(Me.txt_cantidadFactura.Text) Then
                MessageBox.Show("La Cantidad a Devolver No Puede Ser Mayor a la Facturada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txt_cantidadDevolver.Focus()
                Return False
            End If

            If Val(Me.txt_cantidadDevolver.Text) <= 0 Then
                MessageBox.Show("Ingresa Cantidad a Devolver", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txt_cantidadDevolver.Focus()
                Return False
            End If

            If Me.cmb_motivo.SelectedIndex < 0 Then
                MessageBox.Show("Seleccione un Motivo a Devolver", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.cmb_motivo.Focus()
                Return False
            End If

            If Me.cmb_bodega.SelectedIndex < 0 Then
                MessageBox.Show("Seleccione Bodega a Devolver", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.cmb_bodega.Focus()
                Return False
            End If

            If Me.dgv_liquidacion.Rows.Count > 0 Then
            Else
                MessageBox.Show("No Existen Productos a Devolver", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            '(c) 20151208
            If Me.txtSerie.Visible = True Then
                If Me.txtSerie.Text.Trim.Length = 0 Then
                    MessageBox.Show("Este Producto Maneja Añada, Por Favor Ingresar la Informacion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                'Si la factura tiene añada, no deben cambiarla
                If Me.sgdetalleSerie.Trim.Length > 0 Then
                    If Not Me.sgdetalleSerie.Trim.ToString.Equals(Me.txtSerie.Text.Trim.ToString) Then
                        MessageBox.Show("La Añada Que Ingreso Es Diferente A La Facturada", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False

                    End If

                End If

            End If
        Else
            MessageBox.Show("Ingrese Informacion Correcta.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True

    End Function
    Private Sub limpiar_campos()
        Me.txt_cod_producto.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_cantidadDevolver.Text = ""
        Me.txt_cantidadFactura.Text = ""
        Me.txtSerie.Text = ""
        Me.cmb_motivo.SelectedIndex = -1
        Me.cmb_bodega.SelectedIndex = -1

    End Sub

    Private Sub Mostrar_Manual()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ls_sql, ls_rutamanual As String


        Dim proceso As New Process
        ls_sql = "pa_sel_um_gen_parametros_sistema"
        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            ls_rutamanual = dt.Rows(0).Item("path_manuales").ToString.Trim
            ls_rutamanual += "devoluciones.pdf"

            proceso.Start(ls_rutamanual)



        Catch ex As Exception
        Finally
            proceso = Nothing
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btn_agrega_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agrega_producto.Click
        If validar_campos() Then
            Agregar_Producto()
            verifica_documentos()
            limpiar_campos()


        End If

    End Sub

    Private Sub txt_cantidadDevolver_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidadDevolver.LostFocus
        Try
            Me.txt_cantidadDevolver.Text = Int32.Parse(Me.txt_cantidadDevolver.Text)
            If Double.Parse(Me.txt_cantidadDevolver.Text.ToString) < 0 Then
                Me.txt_cantidadDevolver.Text = 0
                Me.txt_cantidadDevolver.Focus()
            End If

        Catch ex As Exception
            Me.txt_cantidadDevolver.Text = 0
        Finally

        End Try
    End Sub


    Private Sub txt_NoDocto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NoDocto.TextChanged

    End Sub

    Private Sub dgv_listado_liquidaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listado_liquidaciones.CellContentClick

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub txt_cod_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_cliente.TextChanged

    End Sub

    Private Sub dgv_liquidacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_liquidacion.CellContentClick

    End Sub

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
        Mostrar_Manual()
    End Sub

    Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            Otrans.open()
            lsSQL = "spa_ValidaStockCD_Vnt " & pi_devolucion
            dt = Otrans.Obtiene(lsSQL)

            If dt.Rows.Count Then
                Dim oform As New frm_resultado
                oform.dgv_resultado.DataSource = dt
                clsGen.Alinear_GridView(dt, oform.dgv_resultado, ",producto,descripcion,cantidad,existenciacd,accion,", "", "", "", "", "", "", True, True, 150, 0)
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing

            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberar.Click
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            dt = clsGen.ValoresDistinto(ds.Tables("productos_devolucion"), "tipodocto,nodocto".Split(","))

            For Each dr As DataRow In dt.Rows
                'MessageBox.Show(dr.Item("nodocto"))
                lsSQL = "pa_upd_um_documento_cantidad_asignada_total '" & gs_empresa & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("nodocto").ToString & "'"
                Otrans.Actualiza(lsSQL)

                lsSQL = "pa_var_um_documento_detalle_liberar '" & dr.Item("tipodocto").ToString & "','" & gs_empresa & "','" & dr.Item("nodocto").ToString & "'"
                dt2 = Otrans.Obtiene(lsSQL)

                ds.Tables("productos_devolucion").DefaultView.RowFilter = "tipodocto = '" & dr.Item("tipodocto").ToString & "' and nodocto = '" & dr.Item("nodocto").ToString & "'"
                For Each drv As DataRowView In ds.Tables("productos_devolucion").DefaultView

                    dt2.DefaultView.RowFilter = "tipodocto = '" & drv.Item("tipodocto").ToString & "' and numero = '" & drv.Item("nodocto") & "' and producto = '" & drv.Item("producto") & "'"

                    For Each drv2 As DataRowView In dt2.DefaultView
                        lsSQL = "pa_upd_um_documentod_asignado '" & gs_empresa & "','" & drv2.Item("tipodocto").ToString & "'," & _
                                drv2.Item("correlativo") & ",'" & drv2.Item("producto").ToString & "'," & _
                                drv2.Item("secuencia") & ",'" & gs_usuario & "'"
                        Otrans.Actualiza(lsSQL)
                    Next
                Next
            Next

            ds.Tables("productos_devolucion").DefaultView.RowFilter = ""
            MessageBox.Show("Liberacion de Documentos Finalizada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub btnSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalida.Click
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim lsSQL As String

        Try
            Otrans.open()

            If MessageBox.Show("Esta Seguro de Operar la Salida", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'lsSQL = spa_Transforma_Dev_En_Salidas @Empresa varchar(20), @Usuario varchar(20), @Devolucion int
                lsSQL = "spa_Transforma_Dev_En_Salidas '" & gs_empresa & "','" & gs_usuario & "'," & Me.lbl_numero_devolucion.Text
                Otrans.Ingresa(lsSQL)
                If Otrans.Codigo_error = 0 Then
                    MessageBox.Show("Salida Opera Correctamente", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Problemas con la Salida " & Otrans.descripcion_error, "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                '@Empresa varchar(20), @Usuario varchar(20), @Devolucion int
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.llenar_informacion()
    End Sub


    Private Sub dgv_liquidacion_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgv_liquidacion.DataBindingComplete

    End Sub
End Class