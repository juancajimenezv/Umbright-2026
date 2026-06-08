Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmMantenedorPrecios

    Dim valida_producto As Boolean = True
    Dim Ods As New DataSet
    Dim pidSolicitud As Integer
    Dim encabezados_seleccionados As String = String.Empty
    Dim _dtregistros As DataTable
    Dim _dtListaPrecio As DataTable


    Private Sub crearEstructrura()
        Dim dt As New DataTable("detalle")

        dt.Columns.Add(New DataColumn("BU", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("ListaPrecio", GetType(String)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(Date)))
        dt.Columns.Add(New DataColumn("precio_anterior", GetType(Double)))
        dt.Columns.Add(New DataColumn("precio_nuevo", GetType(Double)))
        dt.Columns.Add(New DataColumn("modificado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("precio_cantidad", GetType(Double)))


        Dim uniqueConstraint As UniqueConstraint
        uniqueConstraint = New UniqueConstraint(New DataColumn() {dt.Columns("producto"), dt.Columns("ListaPrecio")})
        dt.Constraints.Add(uniqueConstraint)

        Ods.Tables.Add(dt.Copy)
    End Sub

    Private Sub ProcesarExcel()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim oflex As New Umbral_Flex.productos
        Dim dt_flex As New DataTable
        Dim dtPrecio As New DataTable
        Dim dtListas As New DataTable
        Dim drAux As DataRow
        Dim lbesnuevo As Boolean = True

        Try
            Otrans.open()

            dtListas = Otrans.Obtiene("pa_var_um_listaPrecio_listado '" & gs_empresa & "'")

            For Each dr As DataRow In _dtregistros.Rows

                dtListas.DefaultView.RowFilter = "lisprecio = '" & dr.Item("lista").ToString & "'"
                If dtListas.DefaultView.Count > 0 Then

                    lsSQL = "pa_sel_um_producto '" & gs_empresa & "', '" & dr.Item("codigo").ToString & "'"
                    dt_flex = Otrans.Obtiene(lsSQL)
                    If dt_flex.Rows.Count = 1 Then


                        'txt_cod_producto.Text = codigo_prod
                        'txtGlosa.Text = dt_flex.Rows(0)("glosa").ToString
                        'Me.lblBU.Text = dt_flex.Rows(0)("BU").ToString


                        dtPrecio = oflex.Obtener_Precio_Final(gs_empresa, dr.Item("codigo"), "", dtListas.DefaultView(0).Item("lisprecio").ToString)
                        'If dtPrecio.Rows.Count > 0 Then
                        '    Me.txtPrecioAnterior.Text = dtPrecio.Rows(0).Item("valor")
                        '    Me.txtPrecioNuevo.Text = "0"
                        '    Me.txtPrecioNuevo.Focus()
                        'End If
                        If dr.Item("precio") <> 0 Then

                            For Each dr2 As DataRow In Ods.Tables("detalle").Rows
                                If dr2.Item("producto") = dr.Item("codigo") And dr2.Item("listaprecio") = dr.Item("Lista") Then
                                    dr2.Item("precio_nuevo") = dr.Item("precio")
                                    lbesnuevo = False
                                    Exit For
                                End If
                            Next

                            If lbesnuevo Then
                                drAux = Ods.Tables("detalle").NewRow
                                drAux.Item("BU") = dt_flex.Rows(0)("BU")
                                drAux.Item("producto") = dr.Item("codigo")
                                drAux.Item("glosa") = dt_flex.Rows(0)("glosa").ToString
                                drAux.Item("listaprecio") = dr.Item("Lista")

                                Try
                                    drAux.Item("vigencia") = dtListas.DefaultView(0).Item("fec_final")
                                Catch ex As Exception

                                End Try
                                Try
                                    If dtPrecio.Rows.Count > 0 Then
                                        drAux.Item("precio_anterior") = dtPrecio.Rows(0).Item("valor")
                                    Else
                                        drAux.Item("precio_anterior") = 0
                                    End If
                                Catch ex As Exception

                                End Try

                                drAux.Item("precio_nuevo") = dr.Item("precio")
                                Ods.Tables("detalle").Rows.Add(drAux)
                            End If
                            lbesnuevo = True
                        End If ''Lleva Precio

                    Else
                        MessageBox.Show("El producto " & dr.Item("Codigo") & " No Existe ", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If 'Verifica Producto
                Else
                    If MessageBox.Show("No Existe la Lista de Precios " & dr.Item("lista").ToString & " Desea Continuar ?", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If

                End If ''Verifica Lista de Precios




            Next
            Me.dgvProductos.DataSource = Ods.Tables("detalle")
            Me.alinearGridProductos()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub
  
    Private Sub cargarExcel()
        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel() 'Oaut son clases
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados() As String

        Try
            Me.ofd.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"    'OFD es la funcion de buscar y abrir el archivo de excel
            Me.ofd.FileName = ""
            Me.ofd.ShowDialog()

            snombre_archivo = Me.ofd.FileName
            Oaut.pNombreArchivo = snombre_archivo

            hojas_encabezados = Oaut.Obtener_Hojas
            If hojas_encabezados.Length > 1 Then
                Oaut2.Llenar_Combo_Vector(hojas_encabezados)
                Oaut2.Text = "Seleccion de Hoja"
                Oaut2.StartPosition = FormStartPosition.CenterParent
                Oaut2.ShowDialog()
                Oaut.pNombreHoja = Oaut2._selectedValue.ToString
                Oaut2 = Nothing
            Else
                Oaut.pNombreHoja = hojas_encabezados(0)
            End If

            hojas_encabezados = Oaut.obtenerEncabezados

            Dim listaencabezado As New StringBuilder
            For Each encabezado As String In hojas_encabezados
                If Not encabezado Is Nothing Then listaencabezado.Append("," & encabezado)
            Next
            encabezados_seleccionados = listaencabezado.ToString

            Oaut.pNombreColumnas = encabezados_seleccionados

            _dtregistros = Oaut.obtener_registros_nombres()

        Catch ex As Exception
        Finally
            Oaut.Cerrar_libro()
            Oaut = Nothing
            Me.ProcesarExcel()
        End Try
    End Sub

    Private Sub llenarListas()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            lsSQL = "pa_sel_um_listaprecio_activa '" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "listas"
            Ods.Tables.Add(dt.Copy)

            Me.cmbListaPrecios.DataSource = dt
            Me.cmbListaPrecios.ValueMember = "lisprecio"
            Me.cmbListaPrecios.DisplayMember = "lisprecio"

            lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa null,null,'mer_solicita_cambio_precios','" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "solicitantes"
            Ods.Tables.Add(dt.Copy)

            Me.cmbSolicitante.DataSource = Ods.Tables("solicitantes")
            Me.cmbSolicitante.DisplayMember = "nombre"
            Me.cmbSolicitante.ValueMember = "usuario"

            lsSQL = "scm.flexline.pa_sel_um_v_pg_estados 5"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "estados"

            Ods.Tables.Add(dt.Copy)

            Me.cmbEstado.DataSource = Ods.Tables("estados")
            Me.cmbEstado.ValueMember = "cod_estado"
            Me.cmbEstado.DisplayMember = "estado"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub buscar_producto(ByVal codigo_prod As String)
        Dim rTrans As New Transaccional.Conexion("flexline")
        Dim oflex As New Umbral_Flex.productos
        Dim dt_flex As New DataTable
        Dim dtPrecio As New DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim drAux As DataRow

        rTrans.open()

        Try
            lsSQL = "pa_sel_um_producto '" & gs_empresa & "', '" & codigo_prod & "'"
            dt_flex = rTrans.Obtiene(lsSQL)

            If dt_flex.Rows.Count = 1 Then

                txt_cod_producto.Text = codigo_prod
                txtGlosa.Text = dt_flex.Rows(0)("glosa").ToString
                Me.lblBU.Text = dt_flex.Rows(0)("BU").ToString
                If Me.chk_todaslasListas.CheckState = CheckState.Unchecked Then
                    dtPrecio = oflex.Obtener_Precio_Final(gs_empresa, codigo_prod, "", Me.cmbListaPrecios.SelectedValue)
                    If dtPrecio.Rows.Count > 0 Then
                        Me.txtPrecioAnterior.Text = dtPrecio.Rows(0).Item("valor")
                        Me.txtPrecioNuevo.Text = "0"

                        Try
                            Me.txtCantidadAnterior.Text = dtPrecio.Rows(0).Item("cantidad")
                            Me.txtCantidad_PrecioAnterior.Text = dtPrecio.Rows(0).Item("valorc")

                        Catch ex As Exception

                        End Try


                        Me.txtPrecioNuevo.Focus()
                    End If

                Else

                    Dim oform As New frmMantenedorProductosLista
                    oform.psProducto = codigo_prod
                    oform.psGlosa = Me.txtGlosa.Text
                    oform.dtListas = Ods.Tables("listas")
                    oform.ShowDialog()
                    If oform.pbAplicar Then
                        Dim lbesnuevo As Boolean = True
                        For Each dr As DataRow In oform.ods.Tables("precios").Rows
                            Try

                                If dr.Item("precio_nuevo") <> 0 Then

                                    For Each dr2 As DataRow In Ods.Tables("detalle").Rows
                                        If dr2.Item("producto") = Me.txt_cod_producto.Text And dr2.Item("listaprecio") = dr.Item("ListaPrecio") Then
                                            dr2.Item("precio_nuevo") = dr.Item("precio_nuevo")
                                            lbesnuevo = False
                                            Exit For
                                        End If
                                    Next

                                    If lbesnuevo Then
                                        drAux = Ods.Tables("detalle").NewRow
                                        drAux.Item("BU") = dt_flex.Rows(0)("BU")
                                        drAux.Item("producto") = codigo_prod
                                        drAux.Item("glosa") = Me.txtGlosa.Text
                                        drAux.Item("listaprecio") = dr.Item("ListaPrecio")
                                        drAux.Item("vigencia") = dr.Item("vigencia")
                                        drAux.Item("precio_anterior") = dr.Item("precio_anterior")
                                        drAux.Item("precio_nuevo") = dr.Item("precio_nuevo")
                                        Ods.Tables("detalle").Rows.Add(drAux)
                                    End If
                                    lbesnuevo = True
                                End If
                            Catch ex As Exception

                            End Try

                        Next
                    End If
                    oform.Dispose()
                End If

                Me.dgvProductos.DataSource = Ods.Tables("detalle")
                clsGen.Alinear_GridView(Ods.Tables("detalle"), Me.dgvProductos, ",bu,producto,glosa,listaprecio,precio_anterior,precio_nuevo,vigencia,", "", ",bu,producto,glosa,listaprecio,precio_anterior,vigencia,", "", "", "", "", True, True, 250, 0)

            Else
                MessageBox.Show("No se encontró el producto solicitado vuelva a intentarlo.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                limpiarLinea()

                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message)
        Finally
            rTrans.close()
            rTrans = Nothing
            clsGen = Nothing

        End Try

    End Sub

    Private Sub limpiarLinea()

        Me.txtGlosa.Text = String.Empty
        Me.txt_cod_producto.Text = String.Empty
        Me.txtPrecioNuevo.Text = String.Empty
        Me.txtPrecioAnterior.Text = "0"
        Me.txt_cod_producto.SelectAll()
        Me.lblBU.Text = String.Empty

    End Sub

    Private Sub grabarSolicitud()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim iCodSolicitud As Integer
        Dim dt As DataTable
        Dim lbproceso As Boolean = True

        Try


            Otrans.open()
            lsSQL = "scm.flexline.pa_var_um_producto_solicitud_precio '" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)

            Me.lblNumero.Text = dt.Rows(0).Item("numero").ToString
            lsSQL = "scm.flexline.pa_ins_um_producto_solicitud_precio '" & gs_empresa & "'," & dt.Rows(0).Item("numero").ToString & ",'" & _
                     Me.txtComentarios.Text & "','" & Me.dtFechaCambios.Value & "','" & gs_usuario & "','" & _
            Me.cmbSolicitante.SelectedValue & "'"

            Otrans.Ingresa(lsSQL)
            If Otrans.Codigo_error = 0 Then
                dt = Otrans.Obtiene("SELECT @@IDENTITY AS NewID")
                iCodSolicitud = dt.Rows(0).Item("newid").ToString

                'Grabar estado guardado
                lsSQL = "scm.flexline.pa_ins_um_producto_solicitud_precio_estado " & iCodSolicitud & ",10,'" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)

                For Each dr As DataRow In Ods.Tables("detalle").Rows
                    lsSQL = "scm.flexline.pa_ins_um_producto_solicitud_precio_detalle " & _
                        iCodSolicitud & ",'" & dr.Item("producto").ToString & "','" & _
                        dr.Item("listaprecio").ToString & "'," & _
                        dr.Item("precio_nuevo").ToString & "," & _
                        dr.Item("precio_anterior")

                    Otrans.Ingresa(lsSQL)
                    If Otrans.Codigo_error > 0 Then
                        lbproceso = False
                    End If

                Next
                'Grabar estado pendiente de aprobacion
                lsSQL = "scm.flexline.pa_ins_um_producto_solicitud_precio_estado " & iCodSolicitud & ",20,'" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)

            Else
                lbproceso = False
            End If

            If lbproceso = False Then
                'Debo Eliminar la Solicitud

            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        If lbproceso Then
            MessageBox.Show("La Solicitud se Proceso Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            nuevaSolicitud()
            Me.llenarListado()
        Else
            MessageBox.Show("Problemas Para Procesar la Solicitud", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub llenarListado()

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Otrans.open()
            dt = Otrans.Obtiene("scm.flexline.pa_var_um_producto_solicitud_precio_listado '" & gs_empresa & "'")
            Me.dgvListado.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.dgvListado, "", ",id_solicitud,estado,", "", "", ",d_estado=estado,", "", "", True, True, 250, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing


        End Try

    End Sub

    Private Sub mostrarSolicitud(ByVal idSolicitud As Integer)
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable
        Dim drAux As DataRow

        nuevaSolicitud() 'Limpiar la Pantalla
        Me.pidSolicitud = 0
        Try
            Otrans.open()

            Me.pidSolicitud = idSolicitud

            lsSQL = "scm.flexline.pa_sel_um_producto_solicitud_precio " & idSolicitud
            dt = Otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then

                Me.lblNumero.Text = dt.Rows(0).Item("numero_solicitud")
                Me.lblEstado.Text = dt.Rows(0).Item("d_estado")
                Me.txtComentarios.Text = dt.Rows(0).Item("comentarios")
                Me.cmbSolicitante.SelectedValue = dt.Rows(0).Item("usuario_solicito")
                Me.dtFechaCambios.Value = dt.Rows(0).Item("fecha_aplicar")
                Me.txtOperador.Text = dt.Rows(0).Item("usuario_grabo")
                Me.txtFechaGrabo.Text = dt.Rows(0).Item("fecha_grabo")
                Me.btn_grabar.Text = "Modificar"
                Me.cmbSolicitante.Enabled = False


                If dt.Rows(0).Item("estado") = 20 Then
                    Ods.Tables("estados").DefaultView.RowFilter = "cod_estado in (30,90)"
                ElseIf dt.Rows(0).Item("estado") >= 40 Then
                    Me.cmbEstado.Visible = False
                    Me.btn_grabar.Enabled = False
                End If


                lsSQL = "scm.flexline.pa_sel_um_producto_solicitud_precio_detalle " & idSolicitud
                dt = Otrans.Obtiene(lsSQL)
                For Each dr As DataRow In dt.Rows

                    drAux = Ods.Tables("detalle").NewRow
                    drAux.Item("BU") = dr.Item("BU")
                    drAux.Item("producto") = dr.Item("producto")
                    drAux.Item("glosa") = dr.Item("glosa")
                    drAux.Item("listaprecio") = dr.Item("ListaPrecio")
                    drAux.Item("vigencia") = dr.Item("vigencia")
                    drAux.Item("precio_anterior") = dr.Item("precio_anterior")
                    drAux.Item("precio_nuevo") = dr.Item("precio_nuevo")
                    drAux.Item("modificado") = 0
                    Ods.Tables("detalle").Rows.Add(drAux)
                Next

                Me.dgvProductos.DataSource = Ods.Tables("detalle")
                alinearGridProductos()
                Me.TabControl1.SelectedTab = Me.TabPage1
            End If



        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    Private Sub nuevaSolicitud()
        Ods.Tables("estados").DefaultView.RowFilter = "cod_estado=10"
        Me.txtOperador.Text = gs_nombre_usuario
        Me.txtFechaGrabo.Text = Now
        Me.txtComentarios.Text = ""
        Me.btn_grabar.Text = "Guardar"
        Me.lblNumero.Text = "0000"
        Me.txtComentarios.Text = String.Empty
        Me.Ods.Tables("detalle").Rows.Clear()
        Me.cmbSolicitante.Enabled = True
        Me.lblEstado.Text = String.Empty
        Me.cmbEstado.Visible = True
        Me.btn_grabar.Enabled = True
    End Sub


    Private Sub alinearGridProductos()
        Dim clsGen As New ClasesGenerales.General
        clsGen.Alinear_GridView(Ods.Tables("detalle"), Me.dgvProductos, ",bu,producto,glosa,listaprecio,precio_anterior,precio_nuevo,vigencia,", "", ",bu,producto,glosa,listaprecio,precio_anterior,vigencia,", "", "", "", "", True, True, 250, 0)
        clsGen = Nothing
    End Sub

    Private Function validarBUM() As Boolean

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Dim lbValido As Boolean = True

        Try

            ''(c) 20200429 Si es administrador puede aprobar
            If gi_tipo_usuario = 1 Then
                lbValido = True


            Else


                Otrans.open()
                lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa 16,'" & Me.cmbSolicitante.SelectedValue & "',null,'" & gs_empresa & "'"
                dt = Otrans.Obtiene(lsSQL)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.RowFilter = "cod_sub_menu = 40"
                    Dim dtBU As DataTable = Ods.Tables("detalle").Copy
                    dtBU = clsGen.ValoresDistinto(dtBU, "bu".Split(","))
                    For Each dr As DataRow In dtBU.Rows
                        dt.DefaultView.RowFilter = "descripcion = '" & dr.Item("bu").ToString.ToUpper & "'"
                        If dt.DefaultView.Count = 0 Then
                            MessageBox.Show("Hay Productos Que No Pertenecen a Unidad de Negocio", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            lbValido = False
                            Exit For
                        End If
                    Next


                Else
                    'Para Vinoteca Cambia por que es mediante Lista de Precios Gabriela(Premium) Juan Carlos (Directo)
                    MessageBox.Show("El Solicitante No Tiene BU Asignada", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbValido = False
                End If
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return lbValido
    End Function

    Private Function validarBUMAprueba() As Boolean

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Dim lbValido As Boolean = True

        Try
            If gi_tipo_usuario = 1 Then 'administrador
                Return lbValido
            End If
            Otrans.open()
            lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa 16,'" & gs_usuario & "',null,'" & gs_empresa & "'"
            dt = Otrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.RowFilter = "cod_sub_menu = 40"
                Dim dtBU As DataTable = Ods.Tables("detalle").Copy
                dtBU = clsGen.ValoresDistinto(dtBU, "bu".Split(","))
                For Each dr As DataRow In dtBU.Rows
                    dt.DefaultView.RowFilter = "descripcion = '" & dr.Item("bu").ToString.ToUpper & "'"
                    If dt.DefaultView.Count = 0 Then
                        MessageBox.Show("Hay Productos Que No Puede Aprobar Por Unidad de Negocio", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        lbValido = False
                        Exit For
                    End If
                Next


            Else
                'Para Vinoteca Cambia por que es mediante Lista de Precios Gabriela(Premium) Juan Carlos (Directo)
                MessageBox.Show("El Solicitante No Tiene BU Asignada", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lbValido = False
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return lbValido
    End Function


    Private Sub cambiarestado()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String

        Try
            Otrans.open()


            If Me.cmbEstado.SelectedValue = 30 Then

                lsSQL = "scm.flexline.pa_ins_um_producto_solicitud_precio_estado " & Me.pidSolicitud & "," & Me.cmbEstado.SelectedValue & ",'" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)

                lsSQL = "scm.flexline.pa_ins_um_producto_solicitud_precio_estado " & Me.pidSolicitud & ",40,'" & gs_usuario & "'"
                Otrans.Ingresa(lsSQL)

                procesarCambiosPrecios(Me.pidSolicitud)
                'Procesar Cambio Definitivo
                '(c) 20200910


                MessageBox.Show("Solicitud Aprobada Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.nuevaSolicitud()
                Me.llenarListado()
            End If
            'Grabar estado pendiente de aprobacion

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub


    Private Sub procesarCambiosPrecios(ByVal pIdSolicitud As Integer)
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sinc As New Sincronizacion.Productos("")
        Dim lsSQL As String
        Dim dt, dtSolicitudes As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim dtprecios As DataTable
        Try




            Otrans.open()

            ''Creo La Estructura para Los Productos Nuevos
            lsSQL = "pa_var_um_listaprecioD 'DMARTE1', ''"
            Dim dt_info As DataTable = Otrans.Obtiene(lsSQL)


            lsSQL = "scm..pa_var_um_producto_solicitud_precio_procesable"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows
                If dr.Item("id_solicitud") = pIdSolicitud Then
                    If dr.Item("dias_para_procesar") <= 1 Then


                        If dr.Item("precioOriginal") > 0 Then


                            lsSQL = "pa_upd_um_precio_producto_listaPrecioD '" & dr.Item("empresa") & "', " &
                                                       dr.Item("idlisprecio") & ", " & dr.Item("precio_nuevo") &
                                                       ", '" & dr.Item("producto") & "','" & dr.Item("usuario_solicito") & "','" & "Solicitud No. " & dr.Item("numero_solicitud") & "'"
                            Otrans.Actualiza(lsSQL)
                            If Otrans.Codigo_error = 0 Then
                                lsSQL = "scm..pa_upd_um_precio_producto_detalle_operado " & dr.Item("id_solicitud") & ",'" & dr.Item("producto") & "'"
                                Otrans.Actualiza(lsSQL)
                                Otrans.Escribir_Log(lsSQL)
                            End If
                            '(c) 20230831 Actualizar en la nube

                            Try
                                lsSQL = "pa_upd_um_precio_producto_listaPrecioD '" & dr.Item("empresa") & "', " &
                                          dr.Item("idlisprecio") & ", " & dr.Item("precio_nuevo") &
                                          ", '" & dr.Item("producto") & "','" & dr.Item("usuario_solicito") & "','" & "Solicitud No. " & dr.Item("numero_solicitud") & "'"
                                clsGen.insertQuery("RegionalDBintOut", lsSQL)
                            Catch ex As Exception

                            End Try
                        Else

                            Try

                                'se debe Insertar
                                dt_info.Rows.Clear()

                                Dim mNewRow As DataRow = dt_info.NewRow

                                mNewRow("Empresa") = dr.Item("empresa")
                                mNewRow("IdLisPrecio") = dr.Item("idlisprecio")
                                mNewRow("Producto") = dr.Item("producto")
                                mNewRow("Valor") = dr.Item("precio_nuevo")
                                mNewRow("Moneda") = dato_listaPrecioD("moneda", dr.Item("idlisprecio"), dr.Item("empresa"))
                                mNewRow("lisPrecio") = dr.Item("listaprecio")
                                mNewRow("PorcMaxDesc") = 0.0
                                mNewRow("Intervalo") = 0.0
                                mNewRow("PorcentajeInt") = 0.0
                                mNewRow("Cantidad") = 0.0
                                mNewRow("Tipo") = ""
                                mNewRow("ValorC") = 0.0
                                mNewRow("FechaVigencia") = CType(dato_listaPrecioD("FechaVigencia", dr.Item("idlisprecio"), dr.Item("empresa")), DateTime)
                                mNewRow("fec_final") = CType(dato_listaPrecioD("fec_final", dr.Item("idlisprecio"), dr.Item("empresa")), DateTime)
                                mNewRow("Origen") = "Solicitud No. " & dr.Item("numero_solicitud")
                                mNewRow("ValorOrigen") = 0.0
                                mNewRow("ValorPOrigen") = 0.0
                                mNewRow("UserModif") = dr.Item("usuario_solicito")
                                mNewRow("FechaModif") = Now
                                mNewRow("Efecto") = ""
                                mNewRow("PorcMaxDesc1") = 0.0
                                mNewRow("PorcMaxDesc2") = 0.0
                                mNewRow("PorcMaxDesc3") = 0.0
                                mNewRow("PorcMaxDesc4") = 0.0
                                mNewRow("PorcMaxDesc5") = 0.0

                                dt_info.Rows.Add(mNewRow)
                                sinc.Actualizar_ProductoPrecio(dt_info, False)
                                If sinc.codigo_error = 0 Then
                                    lsSQL = "scm..pa_upd_um_precio_producto_detalle_operado " & dr.Item("id_solicitud") & ",'" & dr.Item("producto") & "'"
                                    Otrans.Actualiza(lsSQL)

                                End If
                            Catch ex As Exception

                            End Try

                        End If 'precio Original

                    End If  ''Dias Para Procesar
                End If
            Next

            'dtSolicitudes = clsGen.ValoresDistinto(dt, "id_solicitud".Split(","))
            'For Each dr As DataRow In dtSolicitudes.Rows
            lsSQL = "scm..pa_upd_um_producto_solicitud_precio_operado " & pIdSolicitud & ",'" & gs_usuario & "'"
            Otrans.Actualiza(lsSQL)
                'Next

                sinc.Cerrar()
            sinc = Nothing

            Try
                dt.DefaultView.RowFilter = "id_solicitud = " & pIdSolicitud
                With dt.DefaultView(0)
                    clsGen.enviarMensajeTeams(.Item("Cuenta Office").ToString, "Aplicación Cambio de Precios",
                                              "La Solicitud No. " & .Item("numero_solicitud") & " de la Empresa " &
                                              .Item("Empresa").ToString & " fue procesada en el sistema")
                End With
            Catch ex As Exception

            End Try
            'Return True
        Catch ex As Exception
            'Return False
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Function dato_listaPrecioD(ByVal columna As String, ByVal codigo_lista As Integer, ByVal psEmpresa As String) As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_datos_lista_precioD '" & psEmpresa & "', " & codigo_lista
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(columna).ToString
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return True
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Function
    Private Sub frmMantenedorPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtFechaCambios.Value = Today.AddDays(1)

        Me.crearEstructrura()
        Me.llenarListas()
        Me.llenarListado()
        nuevaSolicitud()

    End Sub

    Private Sub txt_cod_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cod_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            If txt_cod_producto.Text.Trim.Length > 0 Then

                If valida_producto Then
                    buscar_producto(txt_cod_producto.Text)
                End If
            End If
        End If
    End Sub

    Private Sub txtGlosa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGlosa.TextChanged

    End Sub

    Private Sub dgvProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub

    Private Sub dgvProductos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvProductos.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                'therow = Me.dgvProductos.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If

                If Me.dgvProductos.Columns(colIndex).Name.ToLower = "precio_nuevo" Then
                    If Me.dgvProductos.Item("precio_nuevo", e.RowIndex).Value > 0 And _
                        Val(Me.dgvProductos.Item("precio_nuevo", e.RowIndex).Value.ToString) < Val(Me.dgvProductos.Item("precio_anterior", e.RowIndex).Value.ToString) Then
                        Me.dgvProductos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.LightSalmon
                    ElseIf Val(Me.dgvProductos.Item("precio_nuevo", e.RowIndex).Value) < 0 Then
                        Me.dgvProductos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.Tomato
                    Else
                        Me.dgvProductos.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.White
                    End If
                    Me.dgvProductos.Item("modificado", e.RowIndex).Value = 1

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click



        If Ods.Tables("detalle").Rows.Count > 0 Then
            If validarBUM() Then
                If Me.btn_grabar.Text.ToString.ToLower.StartsWith("guar") Then
                    If MessageBox.Show("Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        Me.btn_grabar.Text = "Modificar"
                        grabarSolicitud()
                    End If
                ElseIf Me.btn_grabar.Text.ToString.ToLower.StartsWith("modi") Then
                    If Me.validarBUMAprueba Then ''Cuando Aprueba debe definir que el usuario que aprueba tenga permisos para la Marca
                        If MessageBox.Show("Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            cambiarestado()
                        End If

                        'Modificar Solicitud

                    End If

                End If
            End If
        End If

    End Sub

    Private Sub dgvListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        mostrarSolicitud(Me.dgvListado.Item("id_solicitud", e.RowIndex).Value)
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        nuevaSolicitud()
    End Sub

    Private Sub dgvProductos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgvProductos.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvProductos.Columns(colIndex).Name.ToLower = "precio_nuevo" Then
                    therow.DefaultCellStyle.BackColor = Color.Yellow
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub



    Private Sub dgvProductos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProductos.DataError
        MessageBox.Show("Ingreso un Valor Invalido", "Verificacion", MessageBoxButtons.OK)
    End Sub

    Private Sub txt_cod_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_producto.TextChanged

    End Sub

    Private Sub txtPrecioNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioNuevo.KeyPress
        If e.KeyChar = Chr(13) Then
            Try
                If Val(txtPrecioNuevo.Text) <> 0 Then
                    Dim lbEsnuevo As Boolean = True
                    Ods.Tables("listas").DefaultView.RowFilter = "lisprecio = '" & Me.cmbListaPrecios.Text & "'"

                    For Each dr As DataRow In Ods.Tables("detalle").Rows
                        If dr.Item("producto") = Me.txt_cod_producto.Text And dr.Item("listaprecio") = Me.cmbListaPrecios.Text Then
                            dr.Item("precio_nuevo") = Me.txtPrecioNuevo.Text
                            lbEsnuevo = False
                            Exit For
                        End If
                    Next

                    If lbEsnuevo Then


                        Dim draux As DataRow

                        draux = Ods.Tables("detalle").NewRow
                        draux.Item("BU") = Me.lblBU.Text
                        draux.Item("producto") = Me.txt_cod_producto.Text
                        draux.Item("glosa") = Me.txtGlosa.Text
                        draux.Item("listaprecio") = Me.cmbListaPrecios.Text
                        Try
                            draux.Item("vigencia") = Ods.Tables("listas").DefaultView(0).Item("fec_final")
                        Catch ex As Exception
                            draux.Item("vigencia") = Today 'debo buscar
                        End Try

                        Try
                            draux.Item("precio_anterior") = Me.txtPrecioAnterior.Text
                        Catch ex As Exception
                            draux.Item("precio_anterior") = 0
                        End Try


                        draux.Item("precio_nuevo") = Me.txtPrecioNuevo.Text

                        Try
                            draux.Item("cantidad") = Me.txtPrecioNuevo.Text
                            draux.Item("preciocantidad") = Me.txtPrecioNuevo.Text
                        Catch ex As Exception

                        End Try
                        Ods.Tables("detalle").Rows.Add(draux)
                    End If
                    limpiarLinea()
                    Me.txt_cod_producto.Focus()
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub cmbListaPrecios_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbListaPrecios.SelectionChangeCommitted
        limpiarLinea()
    End Sub

    Private Sub txtPrecioAnterior_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioAnterior.TextChanged
        Try
            Me.txtPrecioAnterior.Text = Format(Convert.ToDecimal(txtPrecioAnterior.Text), "###,###,##0.00").ToString
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        Try

            Dim cod_producto As String = String.Empty
            Dim frm_busqueda As New frm_busqueda_general

            frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and validastock = 's' and vigente = 's' and "
            frm_busqueda.parametros = "glosa,producto,tipoproducto"
            frm_busqueda.nombre_vista = "producto"
            frm_busqueda.lista_campos = "producto,glosa,tipoproducto,familia, subfamilia,tipo,AnalisisProducto17 as BU "
            frm_busqueda.txt_buscar1.Focus()

            frm_busqueda.txt_buscar1.Focus()
            frm_busqueda.dg_buscar.ReadOnly = False
            frm_busqueda.btn_seleccion_multipe.Visible = False
            frm_busqueda.Btn_Aceptar.Visible = False
            frm_busqueda.ShowDialog(Me)

            cod_producto = frm_busqueda.resultado

            frm_busqueda.Dispose()
            frm_busqueda = Nothing

            If cod_producto <> Nothing Then
                Me.txt_cod_producto.Text = cod_producto

                buscar_producto(Me.txt_cod_producto.Text)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrecioNuevo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioNuevo.TextChanged

    End Sub

    Private Sub dgvListado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub

    Private Sub btnCargarXLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarXLS.Click
        Me.cargarExcel()
    End Sub

    Private Sub btnXLSHorizontal_Click(sender As Object, e As EventArgs) Handles btnXLSHorizontal.Click
        Me.cargarExcel_Horizontal
    End Sub


    Private Sub cargarExcel_Horizontal()
        Dim snombre_archivo As String

        Dim Oaut As New Automatizar.importar_excel() 'Oaut son clases
        Dim Oaut2 As New Automatizar.frm_lista
        Dim hojas_encabezados() As String

        Try
            Me.ofd.Filter = "Todos Los Archivos de Excel (*.xls,*.xl*)|*.xl*"    'OFD es la funcion de buscar y abrir el archivo de excel
            Me.ofd.FileName = ""
            Me.ofd.ShowDialog()

            snombre_archivo = Me.ofd.FileName
            Oaut.pNombreArchivo = snombre_archivo

            hojas_encabezados = Oaut.Obtener_Hojas


            If hojas_encabezados.Length > 1 Then
                Oaut2.Llenar_Combo_Vector(hojas_encabezados)
                Oaut2.Text = "Seleccion de Hoja"
                Oaut2.StartPosition = FormStartPosition.CenterParent
                Oaut2.ShowDialog()
                Oaut.pNombreHoja = Oaut2._selectedValue.ToString
                Oaut2 = Nothing
            Else
                Oaut.pNombreHoja = hojas_encabezados(0)
            End If




            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim range As Excel.Range

            ' Crear una instancia de Excel y abrir el archivo Oaut.pNombreHoja
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(snombre_archivo) ' Reemplaza con la ruta de tu archivo

            ' Establecer la hoja de trabajo que deseas leer
            xlWorkSheet = xlWorkBook.Sheets(Oaut.pNombreHoja) ' Reemplaza "Sheet1" con el nombre de tu hoja

            ' Obtener el rango de datos utilizado en la hoja de trabajo
            range = xlWorkSheet.UsedRange

            ' Obtener las dimensiones del rango
            Dim rowCount As Integer = range.Rows.Count
            Dim colCount As Integer = range.Columns.Count

            ' Variables para almacenar datos de código, producto y valores
            'Dim codigoData(rowCount - 1) As String
            'Dim productosData(rowCount - 1) As String
            'Dim directoData(rowCount - 1) As String
            'Dim paquetesData(rowCount - 1) As String
            'Dim comprasData(rowCount - 1) As String
            'Dim costosData(rowCount - 1) As String

            '' Leer y transponer los datos
            'For r As Integer = 1 To rowCount
            '    codigoData(r - 1) = range.Cells(r, 1).Value ' Columna de código (A en Excel)
            '    productosData(r - 1) = range.Cells(r, 2).Value ' Columna de productos (B en Excel)
            '    directoData(r - 1) = range.Cells(r, 3).Value ' Columna de directo (C en Excel)
            '    paquetesData(r - 1) = range.Cells(r, 4).Value ' Columna de paquetes (D en Excel)
            '    comprasData(r - 1) = range.Cells(r, 5).Value ' Columna de compras (E en Excel)
            '    costosData(r - 1) = range.Cells(r, 6).Value ' Columna de costos (F en Excel)
            'Next


            Oaut.Cerrar_libro()
            Oaut = Nothing

            Me.dgvProductos.DataSource = Ods.Tables("detalle")
            'Me.alinearGridProductos()

            Dim drAux As DataRow

            For r As Integer = 2 To rowCount
                Try


                    For c As Integer = 3 To colCount
                        Try


                            drAux = Ods.Tables("detalle").NewRow
                            drAux.Item("BU") = "BU"
                            drAux.Item("producto") = range.Cells(r, 1).Value
                            drAux.Item("glosa") = range.Cells(r, 2).Value
                            drAux.Item("listaprecio") = range.Cells(1, c).Value
                            drAux.Item("precio_nuevo") = range.Cells(r, c).Value
                            Ods.Tables("detalle").Rows.Add(drAux)
                        Catch ex As Exception
                            Exit For
                        End Try
                    Next
                Catch ex As Exception

                End Try
            Next

            ' Cerrar Excel
            xlWorkBook.Close()
            xlApp.Quit()

            ' Liberar recursos
            ReleaseObject(xlApp)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlWorkSheet)

            Dim clsGen As New ClasesGenerales.General
            Dim dtListas As DataTable
            Dim dt_Flex As DataTable
            Dim dtPrecio As DataTable
            Dim dtUnicos As DataTable
            Dim oflex As New Umbral_Flex.productos
            Dim lsSQL As String
            Dim lproductosConError As Boolean = False
            dtListas = clsGen.selectQuery("FlexLine", "pa_var_um_listaPrecio_listado '" & gs_empresa & "'")

            For Each dr As DataRow In Ods.Tables("detalle").Rows
                dtListas.DefaultView.RowFilter = "lisprecio = '" & dr.Item("listaprecio").ToString & "'"
                If dtListas.DefaultView.Count > 0 Then

                    lsSQL = "pa_sel_um_producto '" & gs_empresa & "', '" & dr.Item("producto").ToString & "'"
                    dt_Flex = clsGen.selectQuery("FlexLine", lsSQL)
                    If dt_flex.Rows.Count = 1 Then

                        dtPrecio = oflex.Obtener_Precio_Final(gs_empresa, dr.Item("producto"), "", dtListas.DefaultView(0).Item("lisprecio").ToString)

                        If dr.Item("precio_nuevo") <> 0 Then
                            dr.Item("BU") = dt_Flex.Rows(0)("BU")
                            dr.Item("glosa") = dt_Flex.Rows(0)("glosa").ToString

                            Try
                                dr.Item("vigencia") = dtListas.DefaultView(0).Item("fec_final")
                            Catch ex As Exception
                            End Try
                            Try
                                If dtPrecio.Rows.Count > 0 Then
                                    dr.Item("precio_anterior") = dtPrecio.Rows(0).Item("valor")
                                Else
                                    dr.Item("precio_anterior") = 0
                                End If
                            Catch ex As Exception
                            End Try

                        End If ''Lleva Precio
                    Else
                        'MessageBox.Show("El producto " & dr.Item("producto") & " No Existe ", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lproductosConError = True
                        dr.Item("BU") = "-NO EXISTE PRODUCTO-"
                        dr.Item("glosa") = "-NO EXISTE-"


                    End If 'Verifica Producto
                Else
                    lproductosConError = True
                    dr.Item("BU") = "-NO EXISTE LISTA PRECIOS-"
                    'If MessageBox.Show("No Existe la Lista de Precios " & dr.Item("lista").ToString & " Desea Continuar ?", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    '    Exit Sub
                    'End If

                End If ''Verifica Lista de Precios
            Next
            'dtUnicos = clsGen.ValoresDistinto(Ods.Tables("detalle"), "producto,glosa,listaprecio".Split(","))
            If lproductosConError Then
                Me.btn_grabar.Enabled = False
                MessageBox.Show("Existen Productos con Error, Verifique previo a continuar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            MessageBox.Show(ex.Message)
        Finally
            'Oaut.Cerrar_libro()
            'Oaut = Nothing
            'Me.ProcesarExcel()
        End Try
    End Sub
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub
End Class