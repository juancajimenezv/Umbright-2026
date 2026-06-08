Imports System.Text

Public Class frm_facturacion_autoconsumo


    Dim pds_Dataset As New DataSet
    Dim Ods As New DataSet
    Dim ds As New DataSet
    Dim dt As DataTable
    Dim dt_productos As New DataTable
    Dim oTransaccion As Transaccional.Conexion
    Dim ls_SqlScript As String
    Dim sql_st As String = String.Empty
    'Dim ds_cliente_faccosto As New DataSet
    Dim pbvalida_documento As Boolean = False
    Dim valida_producto As Boolean = False
    Dim ls_filtro_original As String = String.Empty
    Dim ccosto As String = ""
    Dim marca As String = ""
    Dim gasto As String = ""
    Dim nroww As Integer = 0
    Dim con_marca As Boolean = False
    Dim con_item As Boolean = False
    Dim con_ccosto As Boolean = False
    Public psTipo As String = String.Empty
    Public psTipoEspecifico As String

    Private Sub btn_ayuda_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_producto.Click
        Dim cod_producto As String = String.Empty
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "producto,glosa,tipoproducto,familia"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        frm_busqueda.lista_campos = "producto, glosa,  tipoproducto, familia, subfamilia, tipo, vigente"
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
            validacion_producto()
            If valida_producto Then
                buscar_producto(cod_producto)
            End If

        End If

    End Sub

    Private Sub limpiar_linea()
        Me.txt_precio.Text = 0
        Me.txt_cantidad_producto.Text = 0
        Me.txt_descripcion.Text = ""
        Me.txt_cod_producto.SelectAll()

    End Sub

    Private Sub buscar_producto(ByVal codigo_prod As String)
        Dim rTrans As New Transaccional.Conexion("flexline")
        Dim dt_flex As New DataTable
        Dim dt_flex_ As New DataTable
        Dim clsGen As New ClasesGenerales.General

        rTrans.open()

        Try
            sql_st = "pa_sel_um_producto '" & gs_empresa & "', '" & codigo_prod & "'"
            dt_flex = rTrans.Obtiene(sql_st)

            If dt_flex.Rows.Count = 1 Then
                sql_st = "pa_sel_um_listaprecio_costo '" & gs_empresa & "', '" & codigo_prod & "'"
                dt_flex_ = rTrans.Obtiene(sql_st)
                txt_cod_producto.Text = codigo_prod


                txt_descripcion.Text = dt_flex.Rows(0)("glosa")
                Me.txt_cantidad_producto.Focus()
                If dt_flex_.Rows.Count > 0 Then
                    Me.txt_precio.Text = dt_flex_.Rows(0)("valor")
                Else
                    Me.txt_precio.Text = 0
                    MessageBox.Show("El producto no se encuentra en la lista de precios, Favor realizar la verificacion.", "Precio no Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_descripcion.Text = ""
                    Me.txt_cod_producto.Focus()

                    Me.txt_cod_producto.SelectAll()
                    

                End If

                If tiene_permisos("mco_facturacion_costo_marca") Then



                    '' Para Bodega, buscar la Marca
                    sql_st = "pa_var_um_marca_facturacion_costo '" & gs_empresa & "', '" & codigo_prod & "'"
                    dt_flex = rTrans.Obtiene(sql_st)
                    dt_flex = clsGen.ValoresDistinto(dt_flex, "cod_marca,descripcion".Split(","))
                    If dt_flex.Rows.Count = 1 Then
                        Me.txt_cod_marca.Text = dt_flex.Rows(0).Item("cod_marca")
                    ElseIf dt_flex.Rows.Count > 1 Then
                        Dim oform As New frm_resultado
                        dt_flex = clsGen.ValoresDistinto(dt_flex, "cod_marca,descripcion".Split(","))
                        oform.dgv_resultado.DataSource = dt_flex
                        oform.ShowDialog()
                        oform.Dispose()
                        oform = Nothing
                        Me.txt_cod_marca.Text = dt_flex.Rows(0).Item("cod_marca")
                    ElseIf dt_flex.Rows.Count = 0 Then
                    End If
                End If




            Else
                MessageBox.Show("No se encontró el producto solicitado vuelva a intentarlo.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                limpiar_linea()

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

    Private Sub limpia_descripciones()
        Me.txt_descripcion.Text = ""
        Me.txt_precio.Text = ""
        Me.txt_cantidad_producto.Text = ""
        Me.txt_centro_costo.Text = ""
        Me.txt_cod_marca.Text = ""
        Me.txt_gasto.Text = ""
        Me.txt_comentario.Text = ""
        Me.txt_cod_producto.Focus()
        Me.txt_cod_producto.SelectAll()

    End Sub

    Private Sub validacion_producto()
        If Me.txt_no_docto.Text = "0000000000" Then
            valida_producto = True
            Exit Sub
        End If


        Try
            Dim Utrans As New Transaccional.Conexion("flexline")
            Dim ls_sql As String
            Dim dt, dt2 As DataTable
            Dim draux As DataRow
            Dim drr As DataRow
            Dim clsGen As New ClasesGenerales.General

            Try
                Utrans.open()
                ls_sql = "pa_var_um_factuacion_costo_validacion '" & gs_empresa & "','" & Me.txt_cod_producto.Text.Trim & "','" & Me.txt_no_docto.Text.Trim & "','" & Me.txt_cod_cliente.Text.Trim & "'"
                dt = Utrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    valida_producto = True
                ElseIf dt.Rows.Count > 0 And dt.Rows(0).Item("estado") = 4 Then
                    valida_producto = True

                Else
                    MessageBox.Show("El producto ya se encuentra en Facturacion al Costo, Favor hacer la verificacion", "Duplicidad de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    limpia_descripciones()
                    valida_producto = False
                End If

            Catch ex As Exception
                MessageBox.Show("Se produjo el siguiente error al cargar el detalle del documento:" & vbCrLf & ex.Message)
            Finally
                Utrans.close()
                Utrans = Nothing
                clsGen = Nothing
            End Try
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txt_cod_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cod_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            If txt_cod_producto.Text.Trim.Length > 0 Then

                validacion_producto()
                If valida_producto Then
                    buscar_producto(txt_cod_producto.Text)
                End If
            End If
        End If

    End Sub

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

    Private Sub Buscar_Cliente()
        Dim oTable As New DataTable


        Try
            pds_Dataset.Tables.Remove("clientes_flexline")
        Catch ex As Exception

        End Try
        If Me.txt_cod_cliente.Text.Length > 0 Then
            oTransaccion = New Transaccional.Conexion("flexline")
            oTransaccion.open()
            ls_SqlScript = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & Me.txt_cod_cliente.Text.Trim & "'"
            oTable = oTransaccion.Obtiene(ls_SqlScript)
            oTable.TableName = "clientes_flexline"
            pds_Dataset.Tables.Add(oTable.Copy)
            Me.txt_no_docto.Focus()

            If oTable.Rows.Count = 0 Then
                MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_nombre_cliente.Text = ""
                Me.txt_direccion.Text = ""
                Me.txt_no_docto.Focus()

            Else
                Me.txt_nombre_cliente.Text = oTable.Rows(0).Item("RazonSocial") & "/" & oTable.Rows(0).Item("giro")
                Me.txt_direccion.Text = oTable.Rows(0).Item("Direccion")

            End If
            oTransaccion.close()

            Dim dr As DataRow
            Try

                Dim dt As DataTable

                ds.Tables("direccion_entrega").Rows.Clear()
                dr = ds.Tables("direccion_entrega").NewRow


                dt = Ods.Tables("cod_cliente").Copy
                dt.DefaultView.RowFilter = "codigo = " & Me.cmb_cliente_faccosto.SelectedValue
                dr.Item("direccion") = dt.DefaultView(0).Item("texto")
                ds.Tables("direccion_entrega").Rows.Add(dr)
                Me.cmbDireccionEntrega.Text = dt.DefaultView(0).Item("texto")

                'dr =
                'otabla.TableName = "cod_cliente"
                'ds_cliente_faccosto.Tables.Add(otabla.Copy)

                'ds_cliente_faccosto.Tables.Add(otabla.Copy)
            Catch ex As Exception

            End Try



            Dim flexCrud As New FlexLine_CRUD.CRM_Dynamics
            Try
                oTable = flexCrud.getDireccionesClientes(Me.txt_cod_cliente.Text)
                oTable.DefaultView.RowFilter = "TipoDireccion = 'Entrega'"
                If oTable.DefaultView.Count = 0 Then
                    oTable.DefaultView.RowFilter = "TipoDireccion = 'Fiscal'"
                End If

                For Each drv As DataRowView In oTable.DefaultView
                    dr = ds.Tables("direccion_entrega").NewRow
                    dr.Item("direccion") = drv.Item("direccion")
                    ds.Tables("direccion_entrega").Rows.Add(dr)


                Next

            Catch ex As Exception

            Finally
                flexCrud = Nothing
            End Try
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

    Private Sub Ingreso_Nuevo()
        Dim icount As Integer
        Me.txt_actividad.Text = ""
        Me.txt_observaciones.Text = ""
        Me.Nup_porc_empresa.Value = 0
        Me.Nup_porc_proveedor.Value = 0
        Me.dtp_fecha_memo.Value = Today
        '  Me.lbl_numero_memo.Text = 0

        Me.txt_usuario_opera_memo.Text = gs_nombre_usuario
        ' Me.lbl_empresa.Text = gs_empresa
        Me.dtp_fecha_inicio_memo.Value = Today
        Me.dtp_fecha_final_memo.Value = Today
        Me.dtp_hora_inicio.Text = "06:00:00"
        Me.dtp_hora_final.Text = "23:59:59"
        ' newcurrentrow = -1
        '  Ods.Tables("listaprecio").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"
        Ods.Tables("solicitantes").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"
        ' Ods.Tables("clientes").Clear()
        ' Ods.Tables("productos").Clear()
        Me.GB_dirigido_a.Enabled = True
        Me.Gb_informacion_solicitud.Enabled = True
        Me.gb_productos.Enabled = True
        Me.cmb_solicitantes.Enabled = True
        Me.chk_ubicaciones.Enabled = True
        Me.chk_ataque.Enabled = True
        Me.chk_ataque.CheckState = CheckState.Unchecked

        ''Limpiar_ubicaciones
        For icount = 0 To Me.chk_ubicaciones.Items.Count - 1
            Me.chk_ubicaciones.SetItemChecked(icount, False)
        Next
        Me.lbl.Text = ""
        Me.dg_clientes.DataSource = Ods.Tables("clientes")
        Ods.Tables("estados").DefaultView.RowFilter = "cod_estado = 1"

        Me.cmb_lista_precios.Enabled = True
        Me.chk_todos_los_clientes.Enabled = True
        Me.btn_clientes.Enabled = True
        Me.dg_clientes.ReadOnly = False

        Me.dg_productos.ReadOnly = False
        Me.pbvalida_documento = False

        If gs_empresa = "CODICASA" Then
            Me.lbl_pro.Visible = True
            Me.txt_comentario.Visible = True
        Else
            Me.lbl_pro.Visible = False
            Me.txt_comentario.Visible = False
        End If


        If gs_empresa = "DMARTE1" Or gs_empresa = "ALAMSA" Then
            Me.cmb_rubro.Visible = False
            Me.Label38.Visible = False
            Me.btn_agregar.Location = New Point(707, 29)
        ElseIf gs_empresa = "CODICASA" Then
            'Me.btn_agregar.Location = New Point(707, 29)
            Me.cmb_rubro.Visible = True
        Else
            Me.cmb_rubro.Visible = True
            Me.btn_agregar.Location = New Point(847, 30)


        End If

        Me.cmbCanal.Visible = False
        Me.lblCanal.Visible = False

        filtrar_bodegas_facturar()
        'CustomizarForma()

    End Sub

    Private Sub CustomizarForma()
        If psTipo.ToLower.IndexOf("degustacion") > 0 Then
            Me.gbClienteFinal.Visible = False
            psTipoEspecifico = "Degustacion"
        ElseIf psTipo.ToLower.IndexOf("muestras") > 0 Then
            Me.gbClienteFinal.Visible = False
            psTipoEspecifico = "Muestras"
        ElseIf psTipo.ToLower.IndexOf("destruccion") > 0 Then
            Me.gbClienteFinal.Visible = False
            psTipoEspecifico = "Destruccion"
        ElseIf psTipo.ToLower.IndexOf("bonificacion") > 0 Then
            Me.gbClienteFinal.Visible = True
            psTipoEspecifico = "Bonificacion"
        End If

    End Sub

    Private Sub Aplicar_Filtro_Estados()
        Dim ls_filtro As String = ""
        'ls_filtro = "cod_estado in (1,3,5,7,20,21"
        ls_filtro = "cod_estado in (1,4,5,7,20,21"

        If tiene_permisos("mco_rechazar_facturacion_costo") Then
            ls_filtro += ",22"
        End If
        ls_filtro += ")"
        Ods.Tables("estados").DefaultView.RowFilter = ls_filtro
    End Sub

    Private Sub llenar_combos()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String
        Dim otabla As DataTable
        Dim ClsGen As New ClasesGenerales.General


        Try

            otrans.open()


            'If gs_empresa.ToUpper = "VINOTECA" Then
            lsSQL = "pa_sel_um_gen_cod_faccosto '" & gs_empresa & "'"
            otabla = otrans.Obtiene(lsSQL)
            'Else
            '    lsSQL = "pa_sel_um_gen_tabcod null,'gen_fact_costo','" & gs_empresa & "'"
            '    otabla = otrans.Obtiene(lsSQL)
            '    otabla.DefaultView.RowFilter = "texto like '%" & psTipoEspecifico & "%'"
            'End If


            otabla.TableName = "cod_cliente"
            Ods.Tables.Add(otabla.Copy)
            Me.cmb_cliente_faccosto.DisplayMember = "descripcion"
            Me.cmb_cliente_faccosto.ValueMember = "codigo"
            Me.cmb_cliente_faccosto.DataSource = Ods.Tables("cod_cliente").DefaultView



            Me.txt_usuario_opera_memo.Text = gs_nombre_usuario

            lsSQL = "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa  null,null,'mco_solicita_facturacion_costo','" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "solicitantes"
            Ods.Tables.Add(dt.Copy)

            Me.cmb_solicitantes.DataSource = Ods.Tables("solicitantes")
            Me.cmb_solicitantes.ValueMember = "usuario"
            Me.cmb_solicitantes.DisplayMember = "nombre"



            ' lsSQL = "CALL pa_sel_um_pg_estados_fc (12)"
            lsSQL = "pa_sel_um_gen_fc_estados"

            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "estados"
            Ods.Tables.Add(dt.Copy)
            Aplicar_Filtro_Estados()

            Me.cmb_estado_solicitud.DataSource = Ods.Tables("estados").DefaultView
            Me.cmb_estado_solicitud.ValueMember = "cod_estado"
            Me.cmb_estado_solicitud.DisplayMember = "estado"




            'INICIO RUBROS
            lsSQL = "pa_sel_um_gen_tabcod_Rubro '" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)
            Me.cmb_rubro.DataSource = dt
            Me.cmb_rubro.ValueMember = "codigo"
            Me.cmb_rubro.DisplayMember = "codigo"
            'FIN RUBROS


            'INICIO ccosto
            lsSQL = "pa_sel_um_gen_tabcod NULL,'CON_CCOSTO','" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "CON_CCOSTO"
            Ods.Tables.Add(dt.Copy)
            'FIN ccosto


            'Inicio marca
            lsSQL = "pa_sel_um_gen_tabcod NULL,'CON_MARCA','" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "CON_MARCA"
            Ods.Tables.Add(dt.Copy)
            'FIN ccosto

            'Inicio GASTO
            lsSQL = "pa_sel_um_gen_tabcod NULL,'CON_A&P','" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "CON_ITEM"
            Ods.Tables.Add(dt.Copy)
            'FIN GASTO


            '(c) 20241129

            lsSQL = "pa_var_um_canales"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "canales"
            Ods.Tables.Add(dt.Copy)

            Me.cmbCanal.DataSource = Ods.Tables("canales").DefaultView
            Me.cmbCanal.ValueMember = "texto4"
            Me.cmbCanal.DisplayMember = "texto4"


            '(c) 20250610


            lsSQL = "exec pa_um_sel_sg_usuario_empresas_tekne_av '" & gs_empresa & "','" & gs_cuenta_usuario & "','Ventas_BodegaPedido'"
            dt = ClsGen.selectQuery("RegionalDBintOut", lsSQL)
            dt.TableName = "bodegas_facturar"

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron Bodegas para Facturar, Favor Verificar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Ods.Tables.Add(dt.Copy)

            Me.cmbBodega.DataSource = Ods.Tables("bodegas_facturar").DefaultView
            Me.cmbBodega.ValueMember = "ValueComboBox"
            Me.cmbBodega.DisplayMember = "ValueComboBox"



        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Function buscar_documento() As Boolean

        Me.txt_direccion.Text = Me.cmbDireccionEntrega.Text
        Me.txt_no_docto.Text = Me.txt_no_docto.Text.Trim.PadLeft(10, "0000000000")
        If Me.txt_no_docto.Text = "0000000000" Then Exit Function

        Try
            Dim Utrans As New Transaccional.Conexion("flexline")
            Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
            Dim ls_sql As String
            Dim dt, dt2 As DataTable
            Dim draux As DataRow
            Dim drr As DataRow
            Dim clsGen As New ClasesGenerales.General




            Try
                Utrans.open()
                myOtrans.open()


                ls_sql = "pa_sel_um_documento_devolucion '" & gs_empresa & "',NULL, '" & Me.txt_no_docto.Text & "','" & Me.txt_cod_cliente.Text.Trim & "'"
                dt = Utrans.Obtiene(ls_sql)

                If dt.Rows.Count > 0 Then
                    Me.txt_direccion.Text = dt.Rows(0).Item("Direccion")
                    pbvalida_documento = True
                    Me.txt_direccion.Visible = True
                    Me.cmbDireccionEntrega.Visible = False
                Else
                    MessageBox.Show("No se encontró el Documento solicitado vuelva a intentarlo.", "Documento no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txt_no_docto.Text = "0000000000"
                    Me.txt_no_docto.SelectAll()
                    pbvalida_documento = False
                    Me.txt_direccion.Visible = False
                    Me.cmbDireccionEntrega.Visible = True
                End If

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

    Private Sub crearEstructura()
        Dim dt As New DataTable


        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Precio", GetType(Double)))
        dt.Columns.Add(New DataColumn("Centro_Costo", GetType(String)))
        dt.Columns.Add(New DataColumn("dCosto", GetType(String)))
        dt.Columns.Add(New DataColumn("Cod_Marca", GetType(String)))
        dt.Columns.Add(New DataColumn("dMarca", GetType(String)))
        dt.Columns.Add(New DataColumn("Gasto", GetType(String)))
        dt.Columns.Add(New DataColumn("dGasto", GetType(String)))
        dt.Columns.Add(New DataColumn("Rubro", GetType(String)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("Estado", GetType(String)))
        dt.Columns.Add(New DataColumn("gerente", GetType(String)))
        dt.Columns.Add(New DataColumn("bu", GetType(String)))


        dt.TableName = "productos"

        If ds.Tables.Contains("productos") Then ds.Tables.Remove("productos")
        ds.Tables.Add(dt.Copy)

        dt = New DataTable
        dt.TableName = "direccion_entrega"
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        ds.Tables.Add(dt.Copy)


        Me.cmbDireccionEntrega.DataSource = ds.Tables("direccion_entrega")
        Me.cmbDireccionEntrega.ValueMember = "direccion"
        Me.cmbDireccionEntrega.DisplayMember = "direccion"

    End Sub

    Public Sub Imprimir_Ordenes_pdf()
        Dim path_reporte As String
        Dim pm_valores(0) As String
        Dim pm_parametros(0) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte()
            path_reporte += "Direccion Comercial\factura_autoconsumo.rpt"
            pm_parametros(0) = "@Codfactura"


            pm_valores(0) = nroww


            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                           pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                           False, True, "PDF", False, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing


        End Try


    End Sub

    Private Sub frm_facturacion_costo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CustomizarForma()
        crearEstructura()
        llenar_combos()
        Ingreso_Nuevo()
        Llenar_Solicitudes()



    End Sub

    Private Sub txt_no_docto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_no_docto.Leave
        ' Me.txt_no_docto.Text = Microsoft.VisualBasic.Right("0000000000" & Me.txt_no_docto.Text, 10)
    End Sub

    Private Sub txt_no_docto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_no_docto.LostFocus
        ' Me.txt_no_docto.Text = Microsoft.VisualBasic.Right("0000000000" & Me.txt_no_docto.Text, 10)
        'If Me.txt_nombre_cliente.Text.Length > 0 Then
        '    buscar_documento()
        'End If


    End Sub


    Private Sub txt_no_docto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_no_docto.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidarDocumento.Click
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try

            oTrans.open()
            'lsSQL = "Select numero,fecha,proveedor,fechavcto,total,vigencia,comentario1 from documento  Where " & _
            '        "tipodocto = 'CONFIRMACION PROVEEDOR' and porcentajeasignado = 0 and vigencia <> 'A' and empresa = '" & gs_empresa & "' " & _
            '        "order by fecha"
            'dt = oTrans.Obtiene(lsSQL)
            lsSQL = "pa_sel_um_documento_devolucion '" & gs_empresa & "',NULL, '" & Me.txt_no_docto.Text.Trim & "','" & Me.txt_cod_cliente.Text.Trim & "'"
            dt = oTrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                Dim oform As New frm_resultado
                oform.Text = "::. Detalle Factura .::"
                oform.dgv_resultado.DataSource = dt
                ClsGen.Alinear_GridView(dt, oform.dgv_resultado, ",empresa, tipodocto,numero,producto,glosa,cant,fecha,", "", "", "", ",cant=CANTIDAD,", "", "", False, True, 250, 0)

                oform.ShowDialog()

                oform.Dispose()
                oform = Nothing
                pbvalida_documento = True

            Else
                pbvalida_documento = False
                MessageBox.Show("No se encontró el Documento solicitado vuelva a intentarlo.", "Documento no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub txt_unidades_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_producto.LostFocus
        Try
            Me.txt_cantidad_producto.Text = Int32.Parse(Me.txt_cantidad_producto.Text)
            If Double.Parse(Me.txt_cantidad_producto.Text.ToString) < 0 Then
                Me.txt_cantidad_producto.Text = 0
                Me.txt_cantidad_producto.Focus()
            End If

        Catch ex As Exception
            Me.txt_cantidad_producto.Text = 0
        Finally

        End Try
    End Sub

    Private Sub Agregar_Producto()
        Dim clsGen As New ClasesGenerales.General
        Dim rubro As String = ""
        Try
            Dim dr, drr, ddr2, dr_aux As DataRow
            Dim pi_row As Integer

            Try

                For Each dr In ds.Tables("productos").Rows
                    If dr.Item("producto") = Me.txt_cod_producto.Text Then
                        dr.Delete()
                    End If
                Next

            Catch ex As Exception
            End Try

            If gs_empresa = "DMARTE1" Then
                rubro = Me.txt_centro_costo.Text.Trim
            Else
                rubro = Me.cmb_rubro.Text
            End If

            If gs_empresa = "ALAMSA" Then
                rubro = 5
            End If
            dr_aux = ds.Tables("productos").NewRow
            dr_aux.Item("Producto") = Me.txt_cod_producto.Text
            dr_aux.Item("Glosa") = Me.txt_descripcion.Text
            dr_aux.Item("Cantidad") = Me.txt_cantidad_producto.Text.Trim
            dr_aux.Item("Precio") = Me.txt_precio.Text.Trim
            dr_aux.Item("Centro_Costo") = Me.txt_centro_costo.Text.Trim
            dr_aux.Item("Cod_Marca") = Me.txt_cod_marca.Text.Trim
            dr_aux.Item("Gasto") = Me.txt_gasto.Text.Trim
            dr_aux.Item("Rubro") = rubro.Trim 'Me.cmb_rubro.Text.Trim
            dr_aux.Item("Comentario") = Me.txt_comentario.Text.Trim
            dr_aux.Item("Estado") = 1
            dr_aux.Item("dMarca") = Me.descripcion_item("CON_MARCA")
            dr_aux.Item("dCosto") = Me.descripcion_item("CON_CCOSTO")
            dr_aux.Item("dGasto") = Me.descripcion_item("CON_ITEM")
            ds.Tables("productos").Rows.Add(dr_aux)

            Me.dgv_devolucion.DataSource = ds.Tables("productos")
            '            clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgv_devolucion, " ,Producto,Glosa,Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,Estado,", ",Estado,", ",Producto,Glosa,Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,Estado,", ",Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Estado,", ",,", ",Producto=95,Glosa=250,Cantidad=75,Precio=75,Centro_Costo=75,Cod_Marca=75,Gasto=75,Rubro=75,Comentario=75,Estado=75,", "", True, True, 250, 0)

            If gs_empresa <> "CODICASA" Then
                clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgv_devolucion, ",Producto,Glosa,Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,dCosto,dGasto,dMarca,", ",Estado,", ",Producto,Glosa,Cantidad,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,Estado,", ",Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Estado,", ",,", ",cantidad=60,centro_costo=50,cod_marca=50,gasto=50,dGasto=100,dCosto=100,dmarca=100Comentario=95,", "", True, True, 200, 0)
            Else
                clsGen.Alinear_GridView(ds.Tables("productos"), Me.dgv_devolucion, ",Producto,Glosa,Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,dCosto,dGasto,dMarca,", ",Estado,", ",Producto,Glosa,Cantidad,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,Estado,", ",Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Estado,dGasto,", ",,", ",cantidad=60,centro_costo=50,cod_marca=50,gasto=50,dGasto=100,dCosto=100,dmarca=100,Comentario=95,", "", True, True, 200, 0)
            End If

            limpiarCampos()


        Catch ex As Exception
            clsGen = Nothing
        End Try

    End Sub

    Private Sub limpiarCampos()
        Me.txt_cod_producto.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_cantidad_producto.Text = ""
        Me.txt_cod_marca.Text = ""
        Me.txt_centro_costo.Text = ""
        Me.txt_gasto.Text = ""
        Me.txt_precio.Text = ""
        Me.txt_comentario.Text = ""
        Me.cmb_rubro.SelectedIndex = -1

        Me.cmbCanal.Visible = False
        Me.lblCanal.Visible = False

        Me.txt_cod_producto.Focus()
    End Sub

    Private Sub valida_agregar()
        If Me.txt_descripcion.Text.Length > 0 And Me.txt_cod_producto.Text.Length > 0 And Val(Me.txt_cantidad_producto.Text) > 0 And Val(Me.txt_precio.Text) > 0 Then
            If gs_empresa = "CODICASA" And Me.txt_comentario.Text.Trim.Length > 0 Then
                Agregar_Producto()
            ElseIf gs_empresa <> "CODICASA" Then
                Agregar_Producto()
            Else
                MessageBox.Show("No se puede Agregar Debe Agregar Porcentaje, Favor Hacer La Verficacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Else
            MessageBox.Show("No se puede Agregar, Favor Hacer La Verficacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        If Me.txt_cod_cliente.Text.ToString.Substring(0, 4).Equals(Me.cmb_cliente_faccosto.SelectedValue.ToString.Substring(0, 4)) Then
            If Me.lblCanal.Visible = False Then
                MessageBox.Show("Por Favor Indique el Canal Asignado a Esta Solicitud", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.lblCanal.Visible = True
                Me.cmbCanal.Visible = True

            End If

        End If

    End Sub

    Private Sub verifica_documentos()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            Dim ccosto As String = ""
            Dim marca As String = ""
            Dim gasto As String = ""
            dt = clsGen.ValoresDistinto(dgv_devolucion.DataSource, "Centro_Costo".Split(","))
            For Each dr As DataRow In dt.Rows
                Me.ccosto += dr.Item("Centro_Costo") & "-"
            Next

            dt = clsGen.ValoresDistinto(dgv_devolucion.DataSource, "Cod_Marca".Split(","))
            For Each dr As DataRow In dt.Rows
                Me.marca += dr.Item("Cod_Marca") & "-"
            Next

            dt = clsGen.ValoresDistinto(dgv_devolucion.DataSource, "Gasto".Split(","))
            For Each dr As DataRow In dt.Rows
                Me.gasto += dr.Item("Gasto") & "-"
            Next



        Catch ex As Exception
            clsGen = Nothing
        End Try

    End Sub

    Private Function pasa_validaciones() As Boolean



        If con_ccosto Then
            'Return True
        Else
            MessageBox.Show("El Centro de Costo Ingresado es Incorrecto.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txt_centro_costo.Focus()
            Me.txt_centro_costo.SelectAll()
            Return False

        End If

        If con_marca Then
            'Return True
        Else
            MessageBox.Show("La Marcar Ingresada es Incorrecta.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txt_cod_marca.Focus()
            Me.txt_centro_costo.SelectAll()
            Return False

        End If

        If con_item Then
            'Return True
        Else
            MessageBox.Show("El Gasto Ingresado es Incorrecto.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txt_gasto.Focus()
            Me.txt_centro_costo.SelectAll()
            Return False
        End If

        Return True
    End Function

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Not pasa_validaciones() Then
            Exit Sub
        Else
            valida_agregar()

        End If



    End Sub

    Private Sub txt_cod_marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cod_marca.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.valida_agregar()
        End If
    End Sub

    Private Function validar_datos() As Boolean
        Dim Valido As Boolean = True
        Dim nproductos As Integer = 0
        Dim clsGen As New ClasesGenerales.General

        Try
            nproductos = Me.dgv_devolucion.Rows.Count
            If (Me.Nempresa.Value + Me.Nproveedor.Value) > 100 Then
                MessageBox.Show("Los Porcentajes Asignados deben Sumar 100", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Valido = False
            ElseIf nproductos > 0 Then
                Valido = True
            Else
                Valido = False
            End If

            'If gs_empresa.ToLower = "codicasa" Then
            If (Me.Nempresa.Value + Me.Nproveedor.Value) = 0 Then
                MessageBox.Show("Los Porcentajes Asignados deben Sumar 100", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Nempresa.Focus()
                Valido = False
            End If
            'End If


            If Me.lbl_estado_actual.Text.ToLower.IndexOf("aprobac") > 0 And _
                (Me.cmb_estado_solicitud.SelectedValue = 5 Or Me.cmb_estado_solicitud.SelectedValue = 21) Then

                Dim dt As DataTable
                dt = ds.Tables("productos")
                Dim dtUnicos As DataTable = clsGen.ValoresDistinto(dt, "gerente".Split(","))
                Dim dtBU As DataTable = clsGen.ValoresDistinto(dt, "bu".Split(","))

                'If dtUnicos.Rows.Count = 1 And 
                If tiene_permisos("mco_administrar_facturacion_costo") Then
                    Valido = True
                Else
                    If dtBU.Rows.Count = 1 Then
                        If tiene_permisos(dtBU.Rows(0).Item("BU")) Then
                            ''Agregar validacion por nombre de equipo
                            If gs_usuario.ToLower.Equals(gs_nombre_equipo.ToLower) Or gs_nombre_equipo.ToLower.StartsWith("vcit") Or gs_nombre_equipo.ToLower.StartsWith("rd") Then
                                Valido = True
                            Else
                                Valido = False
                                MessageBox.Show("Solo Puede Autorizar En el Equipo de " & gs_usuario, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        Else
                            MessageBox.Show("Esta Solicitud Solo Puede Ser Aprobada pora el BU de la Marca", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Valido = False
                        End If

                        ds.Tables("productos").DefaultView.RowFilter = ""
                    Else 'Multiples BUM
                        MessageBox.Show("Esta Solicitud Tiene Productos de Multiples BUM" & Chr(13) & _
                                        "            No se Puede Procesar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Valido = False
                        ds.Tables("productos").DefaultView.RowFilter = ""
                    End If

                End If 'Administrar Facturacion Costo
            End If 'Verificar Estado Aprobacion



            If Me.cmb_solicitantes.SelectedValue.ToString = "" Then
                MessageBox.Show("Debe Agregar Solicitante", "Verificacion")
                Valido = False
            End If

            If Me.cmbDireccionEntrega.SelectedValue.ToString.StartsWith("CD") Then
                If MessageBox.Show("Esta Seguro que esta solicitud la recogen en... " & Me.cmbDireccionEntrega.SelectedValue.ToString, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Valido = False
                End If

            End If

            If Me.cmbBodega.SelectedValue.ToString = "" Then
                MessageBox.Show("Debe Seleccionar una Bodega de Facturacion", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Valido = False
            End If



        Catch ex As Exception
            nproductos = 0
            Valido = False
        End Try
        Return Valido


    End Function

    Private Function validar_solicitudNueva() As Boolean
        Dim Valido As Boolean = True
        Dim nproductos As Integer = 0
        Dim clsGen As New ClasesGenerales.General

        Try
            nproductos = Me.dgv_devolucion.Rows.Count
            If (Me.Nempresa.Value + Me.Nproveedor.Value) > 100 Then
                MessageBox.Show("Los Porcentajes Asignados deben Sumar 100", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Valido = False
            ElseIf nproductos > 0 Then
                Valido = True
            Else
                Valido = False
            End If

            'If gs_empresa.ToLower = "codicasa" Then
            If (Me.Nempresa.Value + Me.Nproveedor.Value) = 0 Then
                MessageBox.Show("Los Porcentajes Asignados deben Sumar 100", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Nempresa.Focus()
                Valido = False
            End If
            'End If

            If Me.gbClienteFinal.Visible = True Then
                If Me.txt_nombre_cliente.TextLength = 0 Then
                    MessageBox.Show("Debe Seleccionar Cliente Valido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Valido = False
                End If
                'If Me.pbvalida_documento = False Then
                '    MessageBox.Show("Documento Asociado No Es Valido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Valido = False
                'End If
            End If



            If Me.cmb_solicitantes.SelectedValue.ToString = "" Then
                MessageBox.Show("Debe Agregar Solicitante", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Valido = False
            End If

            

        Catch ex As Exception
            nproductos = 0
            Valido = False
        End Try
        Return Valido


    End Function


    Private Sub guardar_solicitud()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim liCod_Pedido As Integer
        Dim lsNumeroSolicitud As String
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim lbExitoso As Boolean = True
        Dim total As Double = 0
        Dim fecha As String = ""

        Try
            Otrans.open()

            'ls_sql = "pa_var_um_fc_encabezado_correlativo '" & gs_empresa & "'"
                    ls_sql = "pa_var_um_autoconsumo_encabezado_correlativo '" & gs_empresa & "'" '(c) 20230426
            dt = Otrans.Obtiene(ls_sql)
            lsNumeroSolicitud = dt.Rows(0).Item("nuevo_numero").ToString()
            ' txt_cod_producto.Text.Replace("'", "")
            'ls_sql = "pa_ins_um_fc_encabezadoP '" & gs_empresa & "','" & Me.cmb_cliente_faccosto.SelectedValue.ToString.Trim 

            ls_sql = "pa_ins_um_factura_autoconsumo_encabezado '" & gs_empresa & "','" & Me.cmb_cliente_faccosto.SelectedValue.ToString.Trim &
                "'," & dt.Rows(0).Item("nuevo_numero").ToString() & ",'" & IIf(Me.txt_nombre_cliente.Text.Length > 0, Me.txt_cod_cliente.Text.Trim, Me.cmb_cliente_faccosto.SelectedValue.ToString.Trim) & "','" &
                gs_usuario & "','" & Me.cmb_solicitantes.SelectedValue.ToString & "','" &
                Me.txt_observaciones.Text.Trim.Replace("'", "").Replace("’", "") & "','" & Me.txt_no_docto.Text.Trim & "','" & Me.dtp_fecha_entrega.Value.ToString("dd-MM-yyyy") & "',NULL,NULL,NULL," & Me.Nempresa.Value.ToString & "," & Me.Nproveedor.Value.ToString & "," & IIf(Me.chk_transporte.Checked = True, 1, 0) &
                 ",'" & Me.cmbDireccionEntrega.SelectedValue.ToString & "','" &
                IIf(Me.cmbCanal.Visible = True, Me.cmbCanal.SelectedValue.ToString, "") & "','" &
                Me.cmbBodega.SelectedValue.ToString & "'"

            '(c) 20250610 Agregue bodega de facturacion

            '",'" & IIf(Me.txt_direccion.Visible = True, Me.txt_direccion.Text, Me.cmbDireccionEntrega.SelectedValue.ToString) & "','" &

            Otrans.Ingresa(ls_sql)


            If Otrans.Codigo_error = 0 Then
                dt = Otrans.Obtiene("SELECT @@IDENTITY AS NewID")
                liCod_Pedido = dt.Rows(0).Item("newid").ToString
                Dim LineaLocal As Integer = 0

                For Each dr In ds.Tables("productos").Rows
                    LineaLocal += 1

                    ls_sql = "pa_ins_um_factura_autoconsumo_detalle " & liCod_Pedido & "," &
                            "'" & dr.Item("Producto").ToString & "'," & dr.Item("Precio").ToString & "," & dr.Item("Cantidad").ToString & ",'" & dr.Item("Centro_Costo").ToString & "','" &
                            dr.Item("Cod_Marca") & "','" & dr.Item("Gasto") & "','" & dr.Item("comentario") & "','" & dr.Item("rubro") & "'"
                    Otrans.Ingresa(ls_sql)
                    If Otrans.Codigo_error > 0 Then lbExitoso = False
                Next
                Guardar_estado_Facturacion_Costo(liCod_Pedido, 4)

                ''Generar Aviso al BU que debe aprobar la solicitud
                'ls_sql = "pa_sel_um_mov_fc_detalle " & liCod_Pedido
                'dt = Otrans.Obtiene(ls_sql)
                'If dt.Rows(0).Item("descripcionCC").ToString.IndexOf("") > 0 Then
                '    dt = clsGen.ValoresDistinto(dt, "gerente_marca".Split(","))
                '    For Each dr In dt.Rows
                '        clsGen.guardarAviso(dr.Item("gerente_marca").ToString, "Umbrigth", "Se Ingreso la Solicitud de Facturacion al Costo En " & gs_empresa.ToUpper & " No. " & lsNumeroSolicitud, 32)
                '    Next

                'End If

                MessageBox.Show("Proceso Guardado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                If Otrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                    lbExitoso = True
                Else
                    lbExitoso = False
                End If
            End If

        Catch ex As Exception
            lbExitoso = False
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub limpiar_pantalla()
        Me.pbvalida_documento = False
        Me.txt_no_docto.Text = ""
        Me.txt_cod_cliente.Text = ""
        Me.txt_nombre_cliente.Text = ""
        Me.txt_direccion.Text = ""
        Me.txt_observaciones.Text = ""

        Me.txt_cod_producto.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_cantidad_producto.Text = ""
        Me.txt_cod_marca.Text = ""
        Me.txt_centro_costo.Text = ""
        Me.txt_gasto.Text = ""
        Me.txt_precio.Text = ""
        Me.txt_cod_cliente.Enabled = True
        Me.btn_buscar_producto.Enabled = True
        Me.lbl_numero_solicitud.Text = 0
        Me.dtp_fecha_memo.Text = Today.Now
        Me.dtp_fecha_entrega.Text = Today.Now
        Me.lbl_estado_actual.Text = ""
        Me.Nempresa.Value = 0
        Me.Nproveedor.Value = 0
        Me.chk_transporte.Checked = False

        Me.gbProductos.Enabled = True
        Me.cmb_cliente_faccosto.Enabled = True
        Me.txt_no_docto.Enabled = True
        Me.btnValidarDocumento.Enabled = True
        Dim ccosto As String = ""
        Dim marca As String = ""
        Dim gasto As String = ""

        Me.btn_grabar.Visible = True
        Me.cmb_estado_solicitud.Enabled = True

        Ods.Tables("solicitantes").DefaultView.RowFilter = "empresa = '" & gs_empresa & "'"

        Ods.Tables("estados").DefaultView.RowFilter = "cod_estado = 1"
        Me.cmb_solicitantes.Enabled = True

        cmb_solicitantes.SelectedIndex = -1

        Try
            Me.dgv_devolucion.DataSource = Nothing
            ds.Tables("productos").Rows.Clear()

        Catch ex As Exception
        End Try

        Try
            crearEstructura()
            Me.cmb_rubro.SelectedIndex = -1

            ' crearEstructura_devolucion()
        Catch ex As Exception
        End Try

        Try
            Me.lblCanal.Visible = False
            Me.cmbCanal.Visible = False
        Catch ex As Exception

        End Try

        Try
            'Me.cmbDireccionEntrega.DataSource = Nothing

            ds.Tables("direccion_entrega").Rows.Clear()
        Catch ex As Exception

        End Try

        filtrar_bodegas_facturar()

    End Sub


    Private Sub Llenar_Solicitudes_legacy()
        Dim ls_Sql, ls_filtro As String
        Dim dt, dt2 As DataTable
        Dim dr As DataRow
        ' Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General

        Try
            ls_filtro = ""

            'myOtrans.open()
            Otrans.open()



            '    'Si Aprueba memos solo le muestro aquellos que estan solicitados
            '    If tiene_permisos("mco_aprobar_facturacion_costo") Then
            '        ls_filtro += IIf(ls_filtro.Length > 0, " OR ", "(") & "cod_estado > 0"
            '    End If


            '    'Si Opera en Flex solo le muestro aquellos que ya estan aprobados
            '    If tiene_permisos("mco_operar_facturacion_costo_sistema") Then
            '        ls_filtro += IIf(ls_filtro.Length > 0, " OR ", IIf(ls_filtro.ToLower.IndexOf("(") >= 0, "", "(")) & "cod_estado = 6"
            '    End If


            '    If tiene_permisos("mco_solicita_facturacion_costo") Then
            '        If ls_filtro.Length > 0 Then
            '            ls_filtro += ")"
            '        Else
            '            'Si solo tiene acceso a Ingresar Nuevos Memos solo le muestro lo que ha grabado y q esten pendientes de Aprobar
            '            ls_filtro = "(empresa = '" & gs_empresa & "' and cod_estado < 4 and usuario_grabo = '" & gs_usuario & "'"
            '        End If
            '    End If
            'End If
            ls_Sql = " pa_var_um_mov_fc_encabezado_listado null,null,'" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_Sql)
            dt.TableName = "listado"

            If Ods.Tables.Contains("listado") Then
                Ods.Tables.Remove("listado")
            End If
            Ods.Tables.Add(dt.Copy)

            'o ve logistica o ve todo
            'Me.chkVerTodo.Visible = False
            'If tiene_permisos("mco_facturacion_costo_logistica") Then
            '    If gs_empresa = "DMARTE1" Then
            '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo = 19"
            '    ElseIf gs_empresa = "CODICASA" Then
            '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo = 22"
            '    ElseIf gs_empresa = "DIUVA" Then
            '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo = 23"
            '    End If
            '    Me.chkVerTodo.Visible = True
            'End If

            If tiene_permisos("mco_facturacion_costo_verTodo") Then
                Ods.Tables("listado").DefaultView.RowFilter = "centro_costo <> 0"
                'Else
                '    If gs_empresa = "DMARTE1" Then
                '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo <> 19"
                '    ElseIf gs_empresa = "CODICASA" Then
                '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo <> 22"
                '    ElseIf gs_empresa = "DIUVA" Then
                '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo <> 23"
                '    End If
            End If

            Me.dgvListadoLegacy.DataSource = Ods.Tables("listado").DefaultView 'dt3
            ClsGen.Alinear_GridView(dt, dgvListadoLegacy, ",numero,fecha_grabo,_estado,solicitante,observaciones,usuario_grabo,usuario_aprobo,fecha_aprobo,", "", "", "", "", "", "", False, True, 250, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
            ls_filtro_original = ls_filtro

        End Try


    End Sub

    Private Sub Llenar_Solicitudes()
        Dim ls_Sql, ls_filtro As String
        Dim dt, dt2 As DataTable
        Dim dr As DataRow

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General

        Try
            ls_filtro = ""


            Otrans.open()


            ls_Sql = " pa_var_um_mov_autoconsumo_encabezado_listado null,null,'" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_Sql)
            dt.TableName = "listado"

            If Ods.Tables.Contains("listado") Then
                Ods.Tables.Remove("listado")
            End If
            Ods.Tables.Add(dt.Copy)


            If tiene_permisos("mco_facturacion_costo_verTodo") Then
                Ods.Tables("listado").DefaultView.RowFilter = "centro_costo <> 0"
            End If

            Me.dgv_listado.DataSource = Ods.Tables("listado").DefaultView 'dt3
            ClsGen.Alinear_GridView(dt, dgv_listado, ",numero,fecha_grabo,_estado,solicitante,observaciones,usuario_grabo,usuario_aprobo,fecha_aprobo,centro_costo,ctacte_fc,direccion_entrega,canal,bodega,", "", "", "", "", "", "", False, True, 250, 0)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
            ls_filtro_original = ls_filtro

        End Try


    End Sub

    Private Sub Mostrar_Solicitud()
        Dim nrow As Integer
        Dim drv As DataRowView
        Dim ls As String
        Dim icount As Integer
        Dim dt As DataTable

        Try
            limpiarCampos()

            nrow = Me.dgv_listado.CurrentRow.Index()
            dt = Ods.Tables("listado").Copy

            dt.DefaultView.RowFilter = "cod_factura = " & Me.dgv_listado.Item("cod_factura", nrow).Value

            drv = dt.DefaultView(0)
            nroww = Me.dgv_listado.Item("cod_factura", nrow).Value

            Me.cmb_cliente_faccosto.SelectedValue = drv.Item("ctacte_fc").ToString
            Me.txt_cod_cliente.Text = drv.Item("ctacte_final").ToString
            Me.txt_observaciones.Text = drv.Item("observaciones").ToString
            Me.txt_usuario_opera_memo.Text = drv.Item("nombre_usuario_grabo").ToString
            Me.cmb_solicitantes.SelectedValue = drv.Item("usuario_solicito").ToString
            Me.txt_no_docto.Text = drv.Item("nodocto")
            Me.dtp_fecha_memo.Text = drv.Item("fecha_grabo").ToString
            Me.dtp_fecha_entrega.Text = drv.Item("fecha_entrega").ToString
            Me.lbl_numero_solicitud.Text = drv.Item("numero").ToString

            Try
                If drv.Item("estadotransporte").ToString > 0 Then
                    Me.chk_transporte.Checked = True
                Else
                    Me.chk_transporte.Checked = False

                End If

            Catch ex As Exception
                Me.chk_transporte.Checked = False
            End Try

            Buscar_Cliente()

            Me.cmb_cliente_faccosto.Enabled = False
            Me.btn_buscar_producto.Enabled = False
            Me.txt_cod_cliente.Enabled = False
            Me.txt_no_docto.Enabled = False

            Me.TabControl1.SelectedTab = Me.TabPage1

            Try
                Me.Nempresa.Value = drv.Item("porcentaje_empresa")
                Me.Nproveedor.Value = drv.Item("porcentaje_proveedor")

            Catch ex As Exception
                Me.Nempresa.Value = 0
                Me.Nproveedor.Value = 0
            End Try


            Try
                Me.cmbDireccionEntrega.SelectedValue = drv.Item("direccion_entrega").ToString
            Catch ex As Exception

            End Try

            Try
                Me.cmbCanal.Text = drv.Item("canal").ToString
            Catch ex As Exception

            End Try

            Try
                Me.cmb_cliente_faccosto.SelectedValue = drv.Item("ctacte_fc").ToString
                Me.cmb_cliente_faccosto.Text = drv.Item("ctacte_fc")
            Catch ex As Exception

            End Try




            '  Me.cmb_lista_precios.SelectedValue = drv.Item("lista_precios").ToString
            ' Me.cmb_lista_precios.Text = drv.Item("lista_precios").ToString


            Me.cmb_estado_solicitud.SelectedValue = drv.Item("cod_estado").ToString
            '  Me.Nup_porc_empresa.Value = drv.Item("porcentaje_empresa").ToString
            '  Me.Nup_porc_proveedor.Value = drv.Item("porcentaje_proveedor").ToString
            ' Me.txt_correlativo.Text = ""
            '  Me.txt_mensaje.Text = drv.Item("comentario").ToString


            Me.btn_grabar.Visible = True
            Me.cmb_estado_solicitud.Enabled = True

            ' Me.gbProductos.Enabled = False


            If drv.Item("cod_estado").ToString > 2 Then

                'Me.GB_dirigido_a.Enabled = True
                'Me.cmb_lista_precios.Enabled = False
                'Me.chk_todos_los_clientes.Enabled = False
                Me.btn_clientes.Enabled = False
                'Me.dg_clientes.ReadOnly = True

                'Me.Gb_informacion_solicitud.Enabled = False
                'Me.gb_productos.Enabled = True
                Me.dg_productos.ReadOnly = True

                Me.cmb_solicitantes.Enabled = False

                If drv.Item("cod_estado").ToString > 5 Then
                    Me.btn_grabar.Visible = False
                    Me.cmb_estado_solicitud.Enabled = False
                End If
            Else


                Me.GB_dirigido_a.Enabled = True
                Me.gb_productos.Enabled = True
                Me.Gb_informacion_solicitud.Enabled = True

                Me.cmb_lista_precios.Enabled = True
                Me.chk_todos_los_clientes.Enabled = True
                Me.btn_clientes.Enabled = True
                Me.dg_clientes.ReadOnly = False

                Me.dg_productos.ReadOnly = False
                Me.chk_ubicaciones.Enabled = True


            End If

            ' Me.chk_ataque.CheckState = IIf(drv.Item("ataque_contrabando").ToString = 1, CheckState.Checked, CheckState.Unchecked)
            Me.lbl_estado_actual.Text = drv.Item("_estado").ToString
            Me.lbl_estado_actual.Visible = True

            Me.Aplicar_filtro_Estados_Proximo(drv.Item("cod_estado").ToString)
            Me.cmb_estado_solicitud.SelectedValue = drv.Item("cod_estado").ToString
            If drv.Item("cod_estado").ToString = 20 Then
                ' Buscar_Memo_Flex()
            End If

            If drv.Item("canal").ToString.Length > 0 Then
                Me.lblCanal.Visible = True
                Me.cmbCanal.Visible = True
                Me.cmbCanal.SelectedValue = drv.Item("canal").ToString
            End If

            Me.cmbBodega.SelectedValue = drv.Item("bodega").ToString


        Catch ex As Exception
        Finally

        End Try
        Mostrar_Productos(drv.Item("cod_factura").ToString)





    End Sub

    Private Sub Mostrar_Productos(ByVal cod_factura As Integer)
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sqls As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Try

            Try
                Me.dgv_devolucion.DataSource = Nothing
                ds.Tables("productos").Rows.Clear()
            Catch ex As Exception

            End Try

            Otrans.open()

            ls_sqls = " pa_sel_um_mov_factura_autoconsumo_detalle " & cod_factura & ""
            dt = Otrans.Obtiene(ls_sqls)

            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows
                    dr_aux = ds.Tables("productos").NewRow
                    dr_aux.Item("Producto") = dr.Item("producto")
                    dr_aux.Item("Glosa") = dr.Item("descripcion")
                    dr_aux.Item("Cantidad") = dr.Item("cantidad")
                    dr_aux.Item("Precio") = dr.Item("Precio")
                    dr_aux.Item("Centro_Costo") = dr.Item("centro_costo")
                    dr_aux.Item("dCosto") = dr.Item("descripcioncc")
                    dr_aux.Item("Cod_Marca") = dr.Item("marca")
                    dr_aux.Item("dmarca") = dr.Item("descripcionmarca")
                    dr_aux.Item("Gasto") = dr.Item("gasto_conta")
                    dr_aux.Item("dGasto") = dr.Item("descripciongc")
                    dr_aux.Item("Rubro") = dr.Item("rubro")
                    dr_aux.Item("Comentario") = dr.Item("comentario")
                    dr_aux.Item("Estado") = 1
                    dr_aux.Item("gerente") = dr.Item("gerente_marca")
                    dr_aux.Item("BU") = dr.Item("BU")


                    'If (dr.Item("centro_costo").ToString = "19" And gs_empresa = "DMARTE1") Or _
                    '    (dr.Item("centro_costo").ToString = "22" And gs_empresa = "CODICASA") Or _
                    '    (dr.Item("centro_costo").ToString = "23" And gs_empresa = "DIUVA") Then
                    '    dr_aux.Item("gerente") = "HGARCIA"
                    'End If
                    ds.Tables("productos").Rows.Add(dr_aux)

                Next

                If Me.lbl_estado_actual.Text.ToLower.IndexOf("aprobac") > 0 Then

                    Me.lbl_estado_actual.Text += " POR"
                    dt = clsgen.ValoresDistinto(ds.Tables("productos"), "gerente".Split(","))
                    For Each dr In dt.Rows
                        Me.lbl_estado_actual.Text += " " + dr.Item("gerente").ToString.ToUpper
                    Next

                End If

                Me.dgv_devolucion.DataSource = ds.Tables("productos")
                'clsgen.Alinear_GridView(ds.Tables("productos_devolucion"), Me.dgv_devolucion, " ,Producto,Glosa,Cantidad,Centro_Costo,Cod_Marca,Gasto,", ",Estado,", ", Producto,Glosa,Cantidad,Centro_Costo,Cod_Marca,Gasto,", ",cantidad,preciou,total,", ",tipodocto=TIPODOCTO,nodocto=NUMERO,producto=PRODUCTO,glosa=GLOSA,cantidad=CANTIDAD,preciou=PRECIO,total=TOTAL,motivo=MOTIVO,", ",producto=75,cantidad=70,nodocto=70,preciou=60,", "", True, True, 250, 0)
                If gs_empresa <> "CODICASA" Then
                    clsgen.Alinear_GridView(ds.Tables("productos"), Me.dgv_devolucion, ",Producto,Glosa,Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,dCosto,dGasto,dMarca,BU,", ",Estado,", ",Producto,Glosa,Cantidad,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,Estado,", ",Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Estado,", ",,", ",cantidad=60,centro_costo=50,cod_marca=50,gasto=50,dGasto=100,dCosto=100,dmarca=100Comentario=95,", "", True, True, 200, 0)
                Else
                    clsgen.Alinear_GridView(ds.Tables("productos"), Me.dgv_devolucion, ",Producto,Glosa,Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,dCosto,dGasto,dMarca,BU,", ",Estado,", ",Producto,Glosa,Cantidad,Centro_Costo,Cod_Marca,Gasto,Rubro,Comentario,Estado,", ",Cantidad,Precio,Centro_Costo,Cod_Marca,Gasto,Rubro,Estado,dGasto,", ",,", ",cantidad=60,centro_costo=50,cod_marca=50,gasto=50,dGasto=100,dCosto=100,dmarca=100,Comentario=95,", "", True, True, 200, 0)
                End If

            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub Aplicar_filtro_Estados_Proximo(ByVal estado_actual As Integer)
        Dim ls_filtro As String
        If estado_actual < 20 Then
            estado_actual += 1
        Else
            estado_actual = 0
        End If
        ls_filtro = "cod_estado in (" & estado_actual & ",20,21"
        If estado_actual < 20 Then
            estado_actual -= 2
            ls_filtro += "," & estado_actual.ToString
        End If
        If tiene_permisos("mco_rechazar_facturacion_costo") Then
            ls_filtro += ",22"
        End If
        ls_filtro += ")"
        If Me.cmb_estado_solicitud.SelectedValue = 4 Then
            Ods.Tables("estados").DefaultView.RowFilter = " cod_estado in (4,5,20,21,3,22)"
        Else
            Ods.Tables("estados").DefaultView.RowFilter = ls_filtro
        End If


    End Sub
    Private Sub Guardar_Estado_Memo_Rechazado(ByVal _pcod_memo As Integer, ByVal _pcod_estado As Integer, ByVal _motivo As String)

        Dim ls_sql As String
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Try

            Otrans.open()
            If _pcod_estado < 2 Then
                _pcod_estado = 2
            End If
            ls_sql = " pa_upd_um_mov_fc_encabezado_estado_rechazado " & _pcod_memo.ToString & "," & _pcod_estado.ToString & _
                                                                    ",' " & _motivo & "'"
            Otrans.Actualiza(ls_sql)

        Catch ex As Exception

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_estado_Facturacion_Costo(ByVal _pcod_memo As Integer, ByVal _pcod_estado As Integer)
        ' Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim ls_sql2 As String

        Try
            Otrans.open()

            If _pcod_estado = 3 Then
                ls_sql = "pa_upd_um_mov_facturacion_autoconsumo_encabezado_reviso " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
            ElseIf _pcod_estado = 5 Then
                ls_sql = "pa_upd_um_mov_facturacion_autoconsumo_encabezado_autorizo " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
            ElseIf _pcod_estado = 7 Then
                ls_sql = "pa_upd_um_mov_facturacion_autoconsumo_encabezado_opero_flex " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
            ElseIf _pcod_estado = 20 Then
                ls_sql = "pa_upd_um_mov_facturacion_autoconsumo_encabezado_opero_flex " & _pcod_memo.ToString & ",'" & gs_usuario & "'"
                Otrans.Actualiza(ls_sql)
                ls_sql = "pa_upd_um_mov_facturacion_autoconsumo_encabezado_estado " & _pcod_memo.ToString & "," & _pcod_estado.ToString & ""
            Else
                ls_sql = "pa_upd_um_mov_facturacion_autoconsumo_encabezado_estado " & _pcod_memo.ToString & "," & _pcod_estado.ToString & ""
                ' MessageBox.Show("Proceso Actualizado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Otrans.Actualiza(ls_sql)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Function Guardar_Cambios() As Boolean
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim icod_empresa As Short = 0
        Dim icorrelativo As Integer = 0
        Dim nrow As Integer
        Dim lexito As Boolean = True
        Dim icount As Integer = 0
        Dim ls_ubicaciones As String = ""
        Dim dr As DataRow
        Dim linealocal As Integer = 0


        Try
            Otrans.open()



            nrow = Me.dgv_listado.CurrentRow.Index()

            ls_sql = "pa_upd_um_mov_facturacion_autoconsumo_encabezado " & Me.dgv_listado.Item("cod_factura", nrow).Value & ",'" & gs_usuario & "','" &
                      Me.dtp_fecha_entrega.Value.ToString("dd-MM-yyyy") & " 00:00:00','" & Me.txt_observaciones.Text.Trim.Replace("'", "") & "',NULL,NULL,NULL," & Me.Nempresa.Value & "," & Me.Nproveedor.Value & "," & IIf(Me.chk_transporte.Checked = True, 1, 0)

            Otrans.Actualiza(ls_sql)

            If Otrans.Codigo_error > 0 Then
                lexito = False
            Else
                If Me.cmb_estado_solicitud.SelectedValue.ToString <> 21 Then  'Si es Anulacion ya no Modifico los detalles


                    ls_sql = "pa_del_um_mov_facturacion_autoconsumo_detalle_productos " & Me.dgv_listado.Item("cod_factura", nrow).Value & ""
                    Otrans.Elimina(ls_sql)


                    For Each dr In ds.Tables("productos").Rows
                        linealocal += 1


                        ls_sql = "pa_ins_um_facturacion_autoconsumo_detalle " & Me.dgv_listado.Item("cod_factura", nrow).Value & "," &
                          "'" & dr.Item("Producto").ToString & "'," & dr.Item("Precio").ToString & "," & dr.Item("Cantidad").ToString & ",'" & dr.Item("Centro_Costo").ToString & "','" &
                          dr.Item("Cod_Marca") & "','" & dr.Item("Gasto") & "','" & dr.Item("comentario") & "','" & dr.Item("rubro") & "'"
                        Otrans.Ingresa(ls_sql)
                        If Otrans.Codigo_error > 0 Then lexito = False
                    Next



                End If

            End If

            If Not lexito Then
                MessageBox.Show("La Actualizacion Genero Errores", "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Guardar Cambios")
            lexito = False
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



        If Not lexito Then
            MessageBox.Show("La Actualizacion Genero Errores", "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            '     MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return lexito
    End Function

    Private Sub Modificar_SolicitudCosto()
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql, comentario As String
        Dim nrow As Integer

        comentario = ""
        Try
            Otrans.open()


            nrow = Me.dgv_listado.CurrentRow.Index()

            ls_sql = "pa_var_um_mov_autoconsumo_encabezado_listado NULL," & Me.dgv_listado.Item("cod_factura", nrow).Value & ",'" & gs_empresa & "'"


            dt = Otrans.Obtiene(ls_sql)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        dr = dt.Rows(0)
        If Val(dr.Item("cod_estado").ToString) > 4 Then
            MessageBox.Show("Este Documento No Se Puede Modificar", "Atencion !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            If Me.cmb_estado_solicitud.SelectedValue.ToString = 21 Then 'Anular Solicitud
                'Int32.Parse(Me.cmb_estado_memo.SelectedValue.ToString) = Int32.Parse(dr.Item("cod_estado").ToString) Or 

                ''La Solicitud de FacCosto lo pueden anular siempre y cuando no este operado en flex
                If tiene_permisos("mco_anular_facturacion_costo") Or _
                    tiene_permisos("mer_administrador_memos") Then
                    If dr.Item("cod_estado").ToString <> 20 Then
                        Guardar_Estado_Memo_Rechazado(Me.dgv_listado.Item("cod_factura", nrow).Value, 21, " Anulado " & gs_usuario & " " & Now.ToString("ddMMyyyHHmm")) ''Lo Pongo Anulado
                        MessageBox.Show("Este Documnto Ha Sido Anulado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Este Documento no se puede Anular", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("No Tiene Permisos Suficientes Para Anular Documentos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            ElseIf Me.cmb_estado_solicitud.SelectedValue.ToString = 22 Then 'Rechazar Solicitud
                If tiene_permisos("mco_rechazar_facturacion_costo") Or _
                tiene_permisos("mer_administrar_memos") Then
                    If dr.Item("cod_estado").ToString < 5 Then
                        comentario = InputBox("Indique Cual es el Motivo del Rechazo", "Rechazo de Facturacion al Costo")
                        If comentario.ToString.Length > 0 Then
                            comentario = gs_usuario & " -- " & comentario.Trim
                            Guardar_Estado_Memo_Rechazado(Me.dgv_listado.Item("cod_factura", nrow).Value, dr.Item("cod_estado").ToString - 3, comentario)
                            MessageBox.Show("El Documento Fue Regresado Al Estado Anterior", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Debe Indicar el Motivo del Rechazo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    MessageBox.Show("Su Usuario No Tiene Permisos Para RECHAZAR Documentos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ''Valido Pemisos para Revisado

            ElseIf validar_datos() Then
                ''Si el Memo No ha sido autorizado, puedo hacerle cambios
                If Me.cmb_estado_solicitud.SelectedValue.ToString < 5 Then
                    If dr.Item("usuario_grabo").ToString = gs_usuario Then
                        If Guardar_Cambios() = False Then
                            Exit Sub
                        Else
                            MessageBox.Show("Las Modificaciones Fueron  Guardadas Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Llenar_Solicitudes()
                            Me.TabControl1.SelectedTab = Me.TabPage2
                        End If
                    Else
                        MessageBox.Show("Solo El Usuario Que Grabo Puede Modificar La Solicitud", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

                If Me.cmb_estado_solicitud.SelectedValue.ToString = 3 Then
                    ''Valido que el estado sea el correcto
                    If dr.Item("cod_estado").ToString = 2 Then
                        If tiene_permisos("mco_revisa_facturacion_costo") Or _
                            tiene_permisos("mer_administrar_memos") Then
                            If MessageBox.Show("Desea Agregar Comentario", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                comentario = InputBox("Ingrese Comentarios", "Comentarios")
                                comentario = IIf(comentario.Trim.Length > 0, "Revision " & comentario.Trim & Chr(13), "")
                            End If
                            Guardar_Estado_Memo_Rechazado(Me.dgv_listado.Item("cod_factura", nrow).Value, Me.cmb_estado_solicitud.SelectedValue.ToString, comentario)
                            Guardar_estado_Facturacion_Costo(Me.dgv_listado.Item("cod_factura", nrow).Value, Me.cmb_estado_solicitud.SelectedValue.ToString)
                            Guardar_estado_Facturacion_Costo(Me.dgv_listado.Item("cod_factura", nrow).Value, 4) ''Lo Pongo en Espera de Aprobacion
                            MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Su Usuario No Tiene Permisos Para Aprobar Facturacion al Costo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Solo Se Puede Revisar Facturas al Costo" & Chr(13) & " El estado Actual Es " & dr.Item("_estado"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ''Valido Permisos Para Operar en Aprobado
                ElseIf Me.cmb_estado_solicitud.SelectedValue.ToString = 5 Then
                    ''Valido que el estado sea el correcto
                    If dr.Item("cod_estado").ToString = 4 Then
                        If tiene_permisos("mco_aprobar_facturacion_costo") Or _
                            tiene_permisos("mer_administrar_memos") Then

                            If dr.Item("usuario_reviso").ToString = gs_usuario And _
                                Not tiene_permisos("mer_administrar_memos") Then
                                MessageBox.Show("El Usuario que Revisa No puede ser el que AUTORIZA", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                If MessageBox.Show("Desea Agregar Comentario", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    comentario = InputBox("Ingrese Comentarios", "Comentarios")
                                    comentario = IIf(comentario.Length > 0, "Aprobacion " & comentario.Trim & Chr(13), "")
                                End If
                                Guardar_Estado_Memo_Rechazado(Me.dgv_listado.Item("cod_factura", nrow).Value, Me.cmb_estado_solicitud.SelectedValue.ToString, comentario)
                                Guardar_estado_Facturacion_Costo(Me.dgv_listado.Item("cod_factura", nrow).Value, Me.cmb_estado_solicitud.SelectedValue.ToString)
                                Guardar_estado_Facturacion_Costo(Me.dgv_listado.Item("cod_factura", nrow).Value, 6) ''Lo Pongo en Espera de Operacion Flex
                                MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Else
                            MessageBox.Show("Su Usuario No Tiene Permisos Para Aprobar Facturacion al Costo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Solo Se Puede Aprobar Documentos Revisados" & Chr(13) & " El estado Actual Es " & dr.Item("_estado"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ''Valido Permisos Para Operar en Flex
                End If
            End If

        Catch ex As Exception
            ' If Me.cmb_estado_memo.SelectedValue.ToString < 3 Then
            If Guardar_Cambios() = False Then
                Exit Sub
            Else
                MessageBox.Show("Las Modificaciones Fueron  Guardadas Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Llenar_Solicitudes()
                Me.TabControl1.SelectedTab = Me.TabPage2
            End If
            '  End If

        End Try

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        Dim estado As Integer
        Try




            Try
                estado = Me.cmb_estado_solicitud.SelectedValue.ToString
            Catch ex As Exception

            End Try
            If Int32.Parse(Me.lbl_numero_solicitud.Text) > 0 Then
                '  Me.valida_documento = True

                If validar_datos() Then
                    If MessageBox.Show("Esta Seguro de Actualizar Esta Solicitud", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        verifica_documentos()
                        Modificar_SolicitudCosto()
                        limpiar_pantalla()
                        Llenar_Solicitudes()
                    End If
                Else
                    MessageBox.Show("No se puede Guardar Cambios, Favor Hacer la Verificacion", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else ''Si es Solicitud Nueva

                If validar_datos() Then
                    If validar_solicitudNueva() Then
                        If MessageBox.Show("Esta Seguro de Guardar Esta Solicitud", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            verifica_documentos()
                            guardar_solicitud()
                            limpiar_pantalla()
                            Llenar_Solicitudes()
                        End If
                    End If
                Else
                    MessageBox.Show("No se puede Guardar Cambios, Favor Hacer la Verificacion", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                End If

        Catch ex As Exception

        End Try




    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.limpiar_pantalla()

    End Sub


    Private Sub dgv_listado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado.DoubleClick
        Aplicar_Filtro_Estados()
        Mostrar_Solicitud()

    End Sub


    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Imprimir_Ordenes_pdf()
    End Sub

    Private Sub txt_cod_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cliente.LostFocus
        Buscar_Cliente()


        If Me.txt_nombre_cliente.Text.Trim.Length > 0 Then
            Me.txt_cod_cliente.Enabled = False
            Me.btn_buscar_producto.Enabled = False
        Else
            Me.txt_cod_cliente.Enabled = True
            Me.btn_buscar_producto.Enabled = True
        End If
    End Sub


  
    Private Sub dgv_listado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listado.CellContentClick

    End Sub

    Private Function descripcion_item(ByVal parametro As String) As String
        Dim lsDescripcion As String = ""
        Try
            If parametro = "CON_CCOSTO" Then
                Ods.Tables(parametro).DefaultView.RowFilter = "empresa = '" & gs_empresa & "' and CODIGO='" & Me.txt_centro_costo.Text.Trim & "'"
                If Ods.Tables(parametro).DefaultView.Count = 1 Then lsDescripcion = Ods.Tables(parametro).DefaultView(0).Item("descripcion")
            ElseIf parametro = "CON_MARCA" Then
                Ods.Tables(parametro).DefaultView.RowFilter = "empresa = '" & gs_empresa & "' and CODIGO='" & Me.txt_cod_marca.Text.Trim & "'"
                If Ods.Tables(parametro).DefaultView.Count = 1 Then lsDescripcion = Ods.Tables(parametro).DefaultView(0).Item("descripcion")
            ElseIf parametro = "CON_ITEM" Then
                Ods.Tables(parametro).DefaultView.RowFilter = "empresa = '" & gs_empresa & "' and CODIGO='" & Me.txt_gasto.Text.Trim & "'"
                If Ods.Tables(parametro).DefaultView.Count = 1 Then lsDescripcion = Ods.Tables(parametro).DefaultView(0).Item("descripcion")
            End If


        Catch ex As Exception

        End Try

        Return lsDescripcion


    End Function

    Private Sub filtrar_busqueda(ByVal parametro As String)
        Try
            If parametro = "CON_CCOSTO" Then
                Ods.Tables(parametro).DefaultView.RowFilter = "empresa = '" & gs_empresa & "' and CODIGO='" & Me.txt_centro_costo.Text.Trim & "'"
                If Ods.Tables(parametro).DefaultView.Count = 0 Then
                    ' MessageBox.Show("El Centro de Costo No Existe.", "Verificar Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    con_ccosto = False
                Else

                    con_ccosto = True
                End If
            ElseIf parametro = "CON_MARCA" Then
                Ods.Tables(parametro).DefaultView.RowFilter = "empresa = '" & gs_empresa & "' and CODIGO='" & Me.txt_cod_marca.Text.Trim & "'"
                If Ods.Tables(parametro).DefaultView.Count = 0 Then
                    ' MessageBox.Show("La Marca No Existe.", "Verificar Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    con_marca = False
                Else
                    con_marca = True

                End If
            ElseIf parametro = "CON_ITEM" Then
               

                Ods.Tables(parametro).DefaultView.RowFilter = "empresa = '" & gs_empresa & "' and CODIGO='" & Me.txt_gasto.Text.Trim & "'"
                If Ods.Tables(parametro).DefaultView.Count = 0 Then
                    'MessageBox.Show("El Codigo de Gasto No Existe.", "Verificar Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    con_item = False
                Else
                    con_item = True
                    '  Me.txt_gasto.Focus()
                End If

            End If


        Catch ex As Exception

        End Try
      


    End Sub

    Private Sub txt_centro_costo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_centro_costo.LostFocus
        If Me.txt_centro_costo.Text.Trim.Length > 0 Then
            filtrar_busqueda("CON_CCOSTO")
        End If
    End Sub

   

    Private Sub txt_cod_marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_marca.LostFocus
        If Me.txt_centro_costo.Text.Trim.Length > 0 Then
            filtrar_busqueda("CON_MARCA")
        End If
    End Sub

    Private Sub txt_cod_marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_marca.TextChanged

    End Sub

    Private Sub txt_gasto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_gasto.LostFocus
        If Me.txt_centro_costo.Text.Trim.Length > 0 Then
            filtrar_busqueda("CON_ITEM")
        End If
    End Sub

    Private Sub txt_gasto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_gasto.TextChanged

    End Sub

    Private Sub txt_centro_costo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_centro_costo.TextChanged

    End Sub

    Private Sub txt_cantidad_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_producto.TextChanged

    End Sub

    Private Sub txt_cod_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_producto.TextChanged

    End Sub

    Private Sub chkVerTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVerTodo.CheckedChanged
        'If chkVerTodo.CheckState = CheckState.Checked Then
        '    If gs_empresa = "DMARTE1" Then
        '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo = 19"
        '    ElseIf gs_empresa = "CODICASA" Then
        '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo = 22"
        '    ElseIf gs_empresa = "DIUVA" Then
        '        Ods.Tables("listado").DefaultView.RowFilter = "centro_costo = 23"
        '    End If
        'Else
        '    Ods.Tables("listado").DefaultView.RowFilter = ""
        'End If

    End Sub

    Private Sub txt_observaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_observaciones.TextChanged

    End Sub

    Private Sub cmb_cliente_faccosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_cliente_faccosto.SelectedIndexChanged

    End Sub

    Private Sub txt_buscar1_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar1.TextChanged

    End Sub

    Private Sub txt_cod_cliente_TextChanged(sender As Object, e As EventArgs) Handles txt_cod_cliente.TextChanged

    End Sub

    Private Sub dgv_listado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listado.CellDoubleClick

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnObtenerLegacy.Click
        Llenar_Solicitudes_legacy()
    End Sub

    Private Sub txt_no_docto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_no_docto.KeyPress
        If e.KeyChar = Chr(13) Then
            ' Me.valida_agregar()
            If Me.txt_nombre_cliente.Text.Length > 0 Then
                buscar_documento()
            End If

        End If
    End Sub

    Private Sub cmb_cliente_faccosto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_cliente_faccosto.SelectedValueChanged
        filtrar_bodegas_facturar()
    End Sub

    Private Sub filtrar_bodegas_facturar()
        Try


            Dim lsBodega As String

            lsBodega = Me.cmb_cliente_faccosto.SelectedValue.ToString

            For Each dr As DataRow In Ods.Tables("cod_cliente").Rows
                If dr.Item("codigo").ToString = lsBodega Then

                    Ods.Tables("bodegas_facturar").DefaultView.RowFilter = "DisplayCombobox = '" & dr.Item("texto1") & "'"


                    Exit For
                End If
            Next




            'MessageBox.Show("La Bodega Seleccionada es: " & lsBodega, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try
    End Sub
End Class

