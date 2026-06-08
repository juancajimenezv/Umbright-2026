Imports System.Text

Public Class frm_dua
    Dim ds_datos As New DataSet
    Dim estilo As New DataGridTableStyle
    Dim sql_st As String = String.Empty
    Dim dt As DataTable
    Dim dt_productos As New DataTable
    Dim nuevo As Boolean = False
    Dim no_oc As String = String.Empty
    Dim idRow As Integer
    Dim p_cantidad As Double

    Private Sub actualiza_lista_dua()
        Dim clGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("scm")

        Try
            Otrans.open()
            If ds_datos.Tables.Contains("dt_lista") Then ds_datos.Tables.Remove("dt_lista")

            sql_st = "pa_sel_um_da_lista_dua '" & gs_empresa & "'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_lista"
            ds_datos.Tables.Add(dt.Copy)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


        dgv_lista_ingresos.DataSource = ds_datos.Tables("dt_lista")
        dgv_lista_ingresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        clGen.Alinear_GridView(ds_datos.Tables("dt_lista"), dgv_lista_ingresos, "", "", "", "", "", "", "", True, True, 250, 0)
        clGen = Nothing
    End Sub


    Private Sub realizarBusqueda()
        Dim lsSQL As String
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General


        Try
            oTrans.open()

            If ds_datos.Tables.Contains("dt_lista") Then ds_datos.Tables.Remove("dt_lista")

            lsSQL = "pa_sel_um_da_lista_dua_filtro '" & gs_empresa & "'"
            If Me.cmbFiltro.SelectedItem.ToString.Trim.StartsWith("dua") Then
                lsSQL += ", '%" & Me.txtBuscar.Text & "%',null"
            End If

            If Not Me.cmbFiltro.SelectedItem.ToString.Trim.StartsWith("dua") Then
                lsSQL += ",null, '%" & Me.txtBuscar.Text & "%'"
            End If

            dt = oTrans.Obtiene(lsSQL)
            dt.TableName = "dt_lista"
            ds_datos.Tables.Add(dt.Copy)

            dgv_lista_ingresos.DataSource = ds_datos.Tables("dt_lista")
            dgv_lista_ingresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
            clsGen.Alinear_GridView(ds_datos.Tables("dt_lista"), dgv_lista_ingresos, "", "", "", "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub nuevo_dua()
        nuevo = True
        txt_numero.Text = String.Empty
        txt_numero.Enabled = True
        txt_oc.Text = String.Empty
        btn_borrar.Enabled = False
        txt_total_bultos.Text = String.Empty
        cmb_aduana.Text = String.Empty
        cmb_aduana.SelectedIndex = -1
        cb_bodega.Text = String.Empty
        cb_bodega.SelectedIndex = -1
        cb_recibido.Text = String.Empty
        cb_recibido.SelectedIndex = -1
        txt_contenedor.Text = String.Empty
        cb_cosecha.Checked = False
        cb_vence.Checked = False
        txt_facturas.Text = String.Empty
        txt_no_ingreso.Text = String.Empty

        dtp_fecha.Value = Now.Date
        dtp_fecha_vence_doc.Value = (Now.Date.AddYears(1)).AddDays(-1)
        cb_bodega.SelectedIndex = -1
        btn_agregar.ImageIndex = 4 : btn_agregar.Text = "Agregar producto"
        nuevo_producto()

        ds_datos.Tables("dt_detalle").Rows.Clear()

        btn_grabar.Text = "Guardar"
        btn_grabar.ImageIndex = 1
    End Sub

    Private Sub crear_estructuras()
        Dim clGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("scm")

        Try
            Otrans.open()
            ds_datos = New DataSet

            If ds_datos.Tables.Contains("dt_bodegas") Then ds_datos.Tables.Remove("dt_bodegas")
            If ds_datos.Tables.Contains("dt_detalle") Then ds_datos.Tables.Remove("dt_detalle")
            If ds_datos.Tables.Contains("dt_lista") Then ds_datos.Tables.Remove("dt_lista")
            If ds_datos.Tables.Contains("dt_usuarios") Then ds_datos.Tables.Remove("dt_usuarios")
            If ds_datos.Tables.Contains("dt_aduanas") Then ds_datos.Tables.Remove("dt_aduanas")

            sql_st = "pa_sel_um_bodegas '" & gs_empresa & "'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_bodegas"
            ds_datos.Tables.Add(dt.Copy)

            sql_st = "pa_sel_um_da_detalle_dua '" & gs_empresa & "','00000'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_detalle"
            ds_datos.Tables.Add(dt.Copy)

            'sql_st = "pa_sel_um_da_lista_dua '" & gs_empresa & "'"
            'dt = Otrans.Obtiene(sql_st)
            'dt.TableName = "dt_lista"
            'ds_datos.Tables.Add(dt.Copy)

            sql_st = "pa_sel_um_codigos_genericos null, 'USUARIO_RECIBE'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_usuarios"
            ds_datos.Tables.Add(dt.Copy)

            sql_st = "pa_sel_um_codigos_genericos null, 'ADUANAS'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_aduanas"
            ds_datos.Tables.Add(dt.Copy)

            sql_st = "pa_sel_um_codigos_genericos null, 'MOTIVO_DAÑO'"
            dt = Otrans.Obtiene(sql_st)
            dt.TableName = "dt_motivo"
            ds_datos.Tables.Add(dt.Copy)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


        cb_bodega.ValueMember = "codigo"
        cb_bodega.DisplayMember = "descripcion"
        cb_bodega.DataSource = ds_datos.Tables("dt_bodegas")

        cb_recibido.ValueMember = "codigo"
        cb_recibido.DisplayMember = "descripcion"
        cb_recibido.DataSource = ds_datos.Tables("dt_usuarios")

        cmb_aduana.ValueMember = "codigo"
        cmb_aduana.DisplayMember = "descripcion"
        cmb_aduana.DataSource = ds_datos.Tables("dt_aduanas")

        cmb_razon_daño.ValueMember = "codigo"
        cmb_razon_daño.DisplayMember = "descripcion"
        cmb_razon_daño.DataSource = ds_datos.Tables("dt_motivo")

        'dgv_lista_ingresos.DataSource = ds_datos.Tables("dt_lista")
        'dgv_lista_ingresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        'clGen.Alinear_GridView(ds_datos.Tables("dt_lista"), dgv_lista_ingresos, "", "", "", "", "", "", "", True, True, 250, 0)

        dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
        dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

        clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

        clGen = Nothing
    End Sub

    Private Sub frm_dua_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructuras()
        nuevo_dua()
    End Sub

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

        If cod_producto<> Nothing  Then buscar_producto(cod_producto)
    End Sub

    Private Sub buscar_producto(ByVal codigo_prod As String)
        Dim rTrans As New Transaccional.Conexion("flexline")
        Dim dt_flex As New DataTable
        Dim dRow() As DataRow

        rTrans.open()

        Try
            sql_st = "pa_sel_um_producto '" & gs_empresa & "', '" & codigo_prod & "'"
            dt_flex = rTrans.Obtiene(sql_st)

            If dt_flex.Rows.Count = 1 Then
                txt_cod_producto.Text = codigo_prod
                txt_descripcion.Text = dt_flex.Rows(0)("glosa")
                Label15.Text = "Proveedor:  " & dt_flex.Rows(0)("subfamilia")
                Me.Text = "::. Mantenedor de Ingresos (DUA) | Proveedor: " & dt_flex.Rows(0)("subfamilia") & " .:: "

                If dt_flex.Rows.Count = 1 Then
                    sql_st = "pa_sel_um_prodcodbarra '" & gs_empresa & "', '" & Me.txt_cod_producto.Text & "'"
                    dt = rTrans.Obtiene(sql_st)

                    dRow = dt.Select("linea = 3")

                    If dRow.Length <= 0 Then
                        txt_cod_barras.Text = String.Empty
                    Else
                        txt_cod_barras.Text = dRow(0)("codbarra")
                    End If

                    dRow = dt.Select("linea = 4")

                    If dRow.Length <= 0 Then
                        txt_cod_provee.Text = String.Empty
                    Else
                        txt_cod_provee.Text = dRow(0)("codbarra")
                    End If
                Else
                    txt_cod_barras.Text = String.Empty
                End If
            Else
                MessageBox.Show("No se encontró el producto solicitado vuelva a intentarlo.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                rTrans.close()
                rTrans = Nothing
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message)
        Finally
            rTrans.close()
            rTrans = Nothing
        End Try


        'Dim Utrans As New Transaccional.Conexion_mysql("onBase")
        Dim dTrans As New Transaccional.Conexion("scm")
        'Utrans.open()
        dTrans.open()

        Try
            sql_st = "call pa_sel_um_inv_producto (NULL, '" & gs_empresa & "', '" & codigo_prod & "')"
            'Dim producto As DataTable = Utrans.Obtiene(sql_st)

            'If producto.Rows.Count = 1 Then
            '                txt_r_sanitario.Text = IIf(IsDBNull(producto.Rows(0)("registro_sanitario")), "", producto.Rows(0)("registro_sanitario"))
            txt_r_sanitario.Text = IIf(IsDBNull(dt_flex.Rows(0)("registro_sanitario")), "", dt_flex.Rows(0)("registro_sanitario"))

            If IsDate(dt_flex.Rows(0)("vencimiento_registro_sanitario")) Then
                Dim fecha As Date

                sql_st = "pa_sel_um_codigos_genericos null, 'TIEMPO_VENCE_REG_SANITARIO'"
                dt = dTrans.Obtiene(sql_st)

                Select Case dt.Rows(0)("codigo")
                    Case "DIA"
                        fecha = Now.Date.AddDays(CInt(Val(dt.Rows(0)("DESCRIPCION"))))
                    Case "MES"
                        fecha = Now.Date.AddMonths(CInt(Val(dt.Rows(0)("DESCRIPCION"))))
                    Case "AÑO"
                        fecha = Now.Date.AddYears(CInt(Val(dt.Rows(0)("DESCRIPCION"))))
                End Select

                If CDate(dt_flex.Rows(0)("vencimiento_registro_sanitario")).Date <= fecha And _
                CDate(dt_flex.Rows(0)("vencimiento_registro_sanitario")).Date > Now.Date Then
                    MessageBox.Show("El regitro sanitario de este producto " & _
                                        "esta proximo a vencer. " & vbCrLf & "Vence el " & _
                                        CDate(dt_flex.Rows(0)("vencimiento_registro_sanitario")).Date.ToShortDateString, _
                                        "Registro Proximo a vencer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf CDate(dt_flex.Rows(0)("vencimiento_registro_sanitario")).Date < Now.Date Then
                    MessageBox.Show("El registro sanitario de este producto esta vencido.", "Registro Sanitario Vencido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_r_sanitario.Text = String.Empty
                End If
            Else
                MessageBox.Show("Este producto no tiene registro sanitario.", "Error de Registro", MessageBoxButtons.OK)
            End If
            'Else
            'MessageBox.Show("Este producto no tiene registro sanitario.", "Error de Registro", MessageBoxButtons.OK)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'Utrans.close()
            'Utrans = Nothing

            dTrans.close()
            dTrans = Nothing
        End Try
    End Sub

    Private Function pasa_validaciones() As Boolean
        If Val(txt_bultos.Text.Trim) = 0 And Val(txt_unidades.Text.Trim) > 0 Then
            MessageBox.Show("Existe un problema entre los bultos y las unidades ya que los bultos esta a cero la unidad tambien debe ser cero.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_unidades.Focus()
            Return False
        End If

        If txt_numero.Text.Trim.Length <= 0 Then
            MessageBox.Show("Primero debe asignar un número de ingreso para poder agregar productos.", "Número de Ingreso.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_numero.Focus()
            Return False
        End If

        If Val(txt_bultos.Text.Trim) < 0 Then
            MessageBox.Show("El valor que ingreso para los bultos es incorrecto.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_bultos.Focus()
            Return False
        End If

        If Val(txt_unidades.Text.Trim) < 0 Then
            MessageBox.Show("El valor que ingreso para las unidades es incorrecto.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_unidades.Focus()
            Return False
        End If

        If cb_vence.Checked Then
            If dtp_vence_producto.Value.Date <= Now.Date Then
                MessageBox.Show("La fecha del vencimiento de producto es menor a la fecha actual.", "Fecha invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtp_vence_producto.Focus()
                Return True
            End If
        End If

        If cb_cosecha.Checked Then
            If dtp_produccion.Value > dtp_fecha.Value.Date.Year Then
                MessageBox.Show("El año de la cosecha no puede ser mayor a la fecha del documento.", "Fecha invalida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtp_produccion.Focus()
                Return False
            End If
        End If

        If txt_cod_barras.Text.Trim.Length <= 0 Then
            MessageBox.Show("Aún no ha ingresado el código de barras para este producto.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_cod_barras.Focus()
            Return False
        End If

        If txt_lote.Text.Trim.Length <= 0 And txt_bultos.Text.Trim.Length > 0 Then
            MessageBox.Show("El lote del producto es requerimiento indispensable.", "Valor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_lote.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub txt_cod_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_producto.LostFocus
        If txt_cod_producto.Text.Trim.Length > 0 Then
            buscar_producto(txt_cod_producto.Text)
            txt_bultos.Focus()
        End If
    End Sub

    Private Sub txt_cod_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_producto.TextChanged
        txt_cod_barras.Text = String.Empty
        txt_r_sanitario.Text = String.Empty
        txt_descripcion.Text = String.Empty
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        nuevo_dua()
        btn_borrar.Enabled = False
        txt_numero.Focus()
    End Sub

    Private Function actualiza_producto() As Boolean
        Try
            With ds_datos.Tables("dt_detalle")

                ds_datos.Tables("dt_detalle").Rows(idRow)("producto") = txt_cod_producto.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("codigo_barra") = txt_cod_barras.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("descripcion") = txt_descripcion.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("bultos") = txt_bultos.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("unidades") = txt_unidades.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("estanteria") = txt_estanteria.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("nivel") = txt_niveles.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("pasillo") = txt_pasillo.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("tramo") = txt_tramo.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("empresa") = gs_empresa
                ds_datos.Tables("dt_detalle").Rows(idRow)("saldo") = 0
                If cb_vence.Checked Then ds_datos.Tables("dt_detalle").Rows(idRow)("fecha_venc") = dtp_vence_producto.Value.Date
                ds_datos.Tables("dt_detalle").Rows(idRow)("observaciones") = txt_observaciones.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("saldo_bultos") = 0
                ds_datos.Tables("dt_detalle").Rows(idRow)("vence") = IIf(cb_vence.Checked, "S", "N")
                ds_datos.Tables("dt_detalle").Rows(idRow)("proveedor") = Mid(Label15.Text.Replace("'", ""), 13)
                ds_datos.Tables("dt_detalle").Rows(idRow)("Bodega") = cb_bodega.ValueMember
                ds_datos.Tables("dt_detalle").Rows(idRow)("Registro") = txt_r_sanitario.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("lote") = txt_lote.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("bacth") = txt_batch.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("pc") = txt_pc.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("unidades_malas") = txt_dañadas.Text.Replace("'", "")
                ds_datos.Tables("dt_detalle").Rows(idRow)("motivo_daño") = cmb_razon_daño.Text
                ds_datos.Tables("dt_detalle").Rows(idRow)("origen") = txtOrigen.Text

                If cb_cosecha.Checked Then ds_datos.Tables("dt_detalle").Rows(idRow)("produccion") = dtp_produccion.Value

            End With

            dgv_detalle.DataSource = Nothing
            dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
            Dim clGen As New ClasesGenerales.General
            clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)
            clGen = Nothing
        Catch ex As Exception
            Return False
        End Try

        nuevo_producto()
        Return True
    End Function

    Private Function crea_producto() As Boolean
        If ds_datos.Tables("dt_detalle").Compute("count(producto)", "producto = '" & txt_cod_producto.Text & "' and lote = '" & txt_lote.Text & "'") > 0 Then
            If MessageBox.Show("La combinación [Producto Lote]  ya esta en el detalle de este documento." & vbCrLf & _
                            "Por lo cual no se puede agregar." & vbCrLf & vbCrLf & _
                            "¿Desea Modificarlo?", "Error al crear producto", MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Return actualiza_producto()
            Else
                Return False
            End If

        End If

        Try
            Dim mNewRow As DataRow = ds_datos.Tables("dt_detalle").NewRow

            mNewRow("producto") = txt_cod_producto.Text.Replace("'", "")
            mNewRow("codigo_barra") = txt_cod_barras.Text.Replace("'", "")
            mNewRow("descripcion") = txt_descripcion.Text.Replace("'", "")
            mNewRow("bultos") = Val(txt_bultos.Text)
            mNewRow("unidades") = Val(txt_unidades.Text)
            mNewRow("estanteria") = txt_estanteria.Text.Replace("'", "")
            mNewRow("nivel") = txt_niveles.Text.Replace("'", "")
            mNewRow("pasillo") = txt_pasillo.Text.Replace("'", "")
            mNewRow("tramo") = txt_tramo.Text.Replace("'", "")
            mNewRow("empresa") = gs_empresa
            mNewRow("saldo") = 0

            If cb_vence.Checked Then mNewRow("fecha_venc") = dtp_vence_producto.Value.Date

            mNewRow("observaciones") = txt_observaciones.Text.Replace("'", "")
            mNewRow("saldo_bultos") = 0
            mNewRow("vence") = IIf(cb_vence.Checked, "S", "N")
            mNewRow("proveedor") = Mid(Label15.Text, 13)
            mNewRow("Bodega") = cb_bodega.Text.Replace("'", "")
            mNewRow("Registro") = txt_r_sanitario.Text.Replace("'", "")
            mNewRow("lote") = txt_lote.Text.Replace("'", "")
            mNewRow("bacth") = txt_batch.Text.Replace("'", "")
            mNewRow("pc") = txt_pc.Text.Replace("'", "")
            mNewRow("unidades_malas") = Val(txt_dañadas.Text)
            mNewRow("motivo_daño") = cmb_razon_daño.Text
            mNewRow("origen") = Me.txtOrigen.Text

            If cb_cosecha.Checked Then mNewRow("produccion") = dtp_produccion.Value

            ds_datos.Tables("dt_detalle").Rows.Add(mNewRow)

            Dim clGen As New ClasesGenerales.General
            clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)
            clGen = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        nuevo_producto()
        Return True
    End Function

    Private Function total_bultos() As Double
        Try
            Return ds_datos.Tables("dt_detalle").Compute("sum(bultos)", "1 = 1").ToString
        Catch ex As Exception

        End Try

    End Function

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Not pasa_validaciones() Then Exit Sub

        If btn_agregar.Tag.ToString = "NUEVO" Then
            If crea_producto() Then btn_agregar.Tag = "NUEVO" : btn_agregar.ImageIndex = 4 : btn_agregar.Text = "Agregar producto"
        Else
            If actualiza_producto() Then btn_agregar.Tag = "NUEVO" : btn_agregar.ImageIndex = 4 : btn_agregar.Text = "Agregar producto"
        End If

        txt_total_bultos.Text = total_bultos()

        verifica_unidades()
        txt_cod_producto.Focus()
    End Sub

    Private Sub nuevo_producto()
        txt_cod_producto.Text = String.Empty
        txt_cod_barras.Text = String.Empty
        txt_cod_provee.Text = String.Empty
        txt_descripcion.Text = String.Empty
        txt_bultos.Text = String.Empty
        txt_unidades.Text = String.Empty
        txt_dañadas.Text = String.Empty
        txt_cod_barras.Text = String.Empty
        cb_cosecha.Checked = False
        dtp_produccion.Value = Year(Now)

        txt_pc.Text = String.Empty
        txt_pc.SelectedIndex = -1
        txt_niveles.Text = String.Empty
        txt_tramo.Text = String.Empty
        txt_estanteria.Text = String.Empty
        txt_pasillo.Text = String.Empty

        cb_vence.Checked = False
        dtp_vence_producto.Value = Now.Date
        txt_lote.Text = String.Empty
        txt_batch.Text = String.Empty
        txt_r_sanitario.Text = String.Empty
        txtOrigen.Text = String.Empty

        cmb_razon_daño.SelectedIndex = -1

        txt_observaciones.Text = String.Empty
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Imprimir_Dua(txt_numero.Text)
    End Sub

    Private Sub Imprimir_Dua(ByVal numero_dua As String)
        Dim pm_valores(3) As String
        Dim pm_parametros(3) As String
        Dim path_reporte As String

        pm_parametros(0) = "Empresa"
        pm_parametros(1) = "noDUA"
        pm_valores(0) = gs_empresa
        pm_valores(1) = numero_dua

        path_reporte = "\\DataServer\FlexlineServidor\FlexlineERP\Reportes Alianza\Compras e Importaciones\DA\informe de recepcion de mercancia.rpt"
        _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "vDATASERVER", "SCM", "flexline", "flexline", False, False, "PDF")
    End Sub

    Sub _reporte_generico_clase(ByVal path_reporte As String, ByVal pm_parametros As Array, ByVal pm_valores As Array, _
    ByVal _pServidor As String, ByVal _pBase_datos As String, ByVal _pUsuario As String, ByVal _ppwd As String, _
    ByVal pexportar As Boolean, ByVal imprimir As Boolean, ByVal _ptipo_exportar As String)

        Dim Oaut As New Automatizar.Reportes_CraxDrt(gs_empresa)

        Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, _pServidor, _pBase_datos, _pUsuario, _ppwd, pexportar, imprimir, _ptipo_exportar, False)

        If Oaut.Descripcion_Error.Length > 0 Then
            MessageBox.Show(Oaut.Descripcion_Error)
        End If

        Oaut.finalizar()
        Oaut = Nothing
    End Sub

    Private Sub dgv_lista_ingresos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_lista_ingresos.DoubleClick
        Dim rowActual As Integer = dgv_lista_ingresos.CurrentRow.Index
        Dim sDua As String = dgv_lista_ingresos.Item("no_orden", rowActual).Value.ToString
        nuevo_dua()

        nuevo = False
        btn_borrar.Enabled = True
        If seleccionar_dua(sDua) Then
            TabControl1.SelectedTab = TabPage1

            btn_grabar.Text = "Modificar"
            btn_grabar.ImageIndex = 6
        End If
    End Sub

    Private Function seleccionar_dua(ByVal numero As String) As Boolean
        Try
            Dim mRow() As DataRow = ds_datos.Tables("dt_lista").Select("No_Orden = '" & numero & "'")


            If mRow.Length > 0 Then
                txt_oc.Text = mRow(0)("orden_compra").ToString
                buscar_oc()
                txt_numero.Text = mRow(0)("no_orden").ToString
                dtp_fecha.Value = CDate(mRow(0)("Fecha")).Date
                dtp_fecha_vence_doc.Value = CDate(mRow(0)("Fecha_vencimiento")).Date

                For ii As Integer = 0 To cb_bodega.Items.Count - 1
                    cb_bodega.SelectedIndex = ii

                    If cb_bodega.Text = mRow(0)("bodega").ToString Then Exit For
                Next

                cmb_aduana.Text = mRow(0)("aduana").ToString
                txt_facturas.Text = mRow(0)("facturas").ToString
                txt_total_bultos.Text = mRow(0)("total_bultos").ToString
                txt_no_ingreso.Text = mRow(0)("no_ingreso").ToString
                cb_recibido.Text = mRow(0)("recibida_por").ToString
                txt_contenedor.Text = mRow(0)("contenedor").ToString

                Dim clGen As New ClasesGenerales.General
                Dim Otrans As New Transaccional.Conexion("scm")

                Try
                    Otrans.open()
                    If ds_datos.Tables.Contains("dt_detalle") Then ds_datos.Tables.Remove("dt_detalle")

                    sql_st = "pa_sel_um_da_detalle_dua '" & gs_empresa & "', '" & numero & "'"
                    dt = Otrans.Obtiene(sql_st)
                    dt.TableName = "dt_detalle"
                    ds_datos.Tables.Add(dt.Copy)

                    sql_st = "pa_var_um_movimientos_dua '" & gs_empresa & "', '" & numero & "'"
                    dt = Otrans.Obtiene(sql_st)

                    If Val(dt.Rows(0)("veces").ToString) > 0 Then
                        btn_grabar.Enabled = False
                        btn_borrar.Enabled = False
                    Else
                        btn_grabar.Enabled = True
                        btn_borrar.Enabled = True
                    End If

                Catch ex As Exception
                Finally
                    Otrans.close()
                    Otrans = Nothing
                End Try

                dgv_detalle.DataSource = ds_datos.Tables("dt_detalle")
                dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

                clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)

                clGen = Nothing
            Else
                MessageBox.Show("No se encontro el número de orden seleccionado.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        End Try

        Return True
    End Function

    Private Sub guardarAvisos()

        Dim myOtrans As New Transaccional.Conexion_mysql("Umbright")
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dt, dt2, dt3, dtUsuarioEmpresa As DataTable
        Dim lsSQL As String
        Dim ClsGen As New ClasesGenerales.General
        Dim guardarAviso As Boolean = False

        Try
            Otrans.open()
            myOtrans.open()
            lsSQL = "pa_sel_um_gen_tabcod '" & ds_datos.Tables("dt_detalle").Rows(0)("proveedor").ToString & _
                        "','CON_PROVEE','" & gs_empresa & "'"
            dt2 = Otrans.Obtiene(lsSQL)

            lsSQL = "pa_sel_um_sg_usuario_empresa null,'" & gs_empresa & "'"
            dtUsuarioEmpresa = Otrans.Obtiene(lsSQL)

            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(1)" '1= Ingreso de Dua OC
            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                If dr.Item("validar_marca").ToString = "1" Then
                    dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                    If dt2.DefaultView.Count > 0 Then guardarAviso = True

                ElseIf dr.Item("validar_empresa").ToString = "1" Then
                    dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                    If dtUsuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True

                Else
                    guardarAviso = True
                End If

                If guardarAviso Then
                    ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Ingreso Dua " & _
                                          Me.txt_numero.Text & " del Proveedor " & _
                                          ds_datos.Tables("dt_detalle").Rows(0)("proveedor").ToString, 1)
                    guardarAviso = False
                End If
            Next


            ''Avisos Para Codigos de Barra Diferentes
            lsSQL = "scm.flexline.pa_var_um_da_dua_detalle_barras_diferentes '" & gs_empresa & "','" & Me.txt_numero.Text & "'"
            dt3 = Otrans.Obtiene(lsSQL)
            If dt3.Rows.Count > 0 Then
                lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(6)" '6= Cambia algun codigo de barra
                dt = myOtrans.Obtiene(lsSQL)


                guardaraviso = False

                For Each dr3 As DataRow In dt3.Rows

                    For Each dr As DataRow In dt.Rows
                        If dr.Item("validar_marca").ToString = "1" Then
                            dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                            If dt2.DefaultView.Count > 0 Then guardarAviso = True

                        ElseIf dr.Item("validar_empresa").ToString = "1" Then

                            dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                            If dtUsuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True

                        Else

                            guardarAviso = True
                        End If


                        If guardarAviso Then

                            ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Producto " & _
                                        dr3.Item("producto").ToString & "-" & dr3.Item("Glosa").ToString & _
                                        " del Codigo " & dr3.Item("codigo_actual").ToString & " al " & _
                                        dr3.Item("codigo_nuevo").ToString, 6)
                            guardarAviso = False

                        End If
                    Next
                Next
            End If

            ''Generar Avisos Registro Sanitario

            lsSQL = "scm.flexline.pa_var_um_da_dua_detalle_registros_sanitarios '" & gs_empresa & "','" & Me.txt_numero.Text & "'"
            dt3 = Otrans.Obtiene(lsSQL)

            If dt3.Rows.Count > 0 Then
                lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema(17)" '17= Registros Sanitarios
                dt = myOtrans.Obtiene(lsSQL)



                For Each dr3 As DataRow In dt3.Rows

                    guardarAviso = False
                    Dim lsMensaje As String
                    lsMensaje = "El Producto " & dr3.Item("producto").ToString.Trim & "-" & dr3.Item("glosa").ToString.Trim

                    If dr3.Item("registro").ToString.Length = 0 Then
                        guardarAviso = True
                        lsMensaje += " No tiene Registro Sanitario, Ingreso en la Dua " & Me.txt_numero.Text
                    Else
                        If dr3.Item("Fecha_vencimiento").ToString.Length = 0 Then
                            guardarAviso = True
                            lsMensaje += " No tiene Fecha de Vencimiento, Ingreso en la Dua " & Me.txt_numero.Text
                        Else
                            Try
                                If CDate(dr3.Item("Fecha_vencimiento")).Date < Today() Then
                                    guardarAviso = True
                                    lsMensaje += " El Registro Ya Vencio, Ingreso en la Dua " & Me.txt_numero.Text
                                ElseIf CDate(dr3.Item("Fecha_vencimiento")).Date < Today().AddMonths(3) Then
                                    guardarAviso = True
                                    lsMensaje += " El Registro Esta Por Vencer, Ingreso en la Dua " & Me.txt_numero.Text
                                End If
                            Catch ex As Exception
                                guardarAviso = True
                                lsMensaje += " Problemas con la Fecha, Ingreso en la Dua " & Me.txt_numero.Text

                            End Try

                        End If
                    End If


                    If guardarAviso Then

                        For Each dr As DataRow In dt.Rows
                            If dr.Item("validar_marca").ToString = "1" Then
                                dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                                If dt2.DefaultView.Count > 0 Then guardarAviso = True

                            ElseIf dr.Item("validar_empresa").ToString = "1" Then

                                dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                                If dtUsuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True
                            End If


                            If guardarAviso Then

                                ClsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", lsMensaje, 17)
                                guardarAviso = False
                            End If
                        Next
                    End If

                Next
            End If




           
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        Dim Utrans As New Transaccional.Conexion("scm")
        Utrans.open()
        Try
            Dim cuenta_bultos As Integer = ds_datos.Tables("dt_detalle").Compute("count(bultos)", "bultos = 0")
            If cmb_aduana.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no a seleccionado la aduana.", "Error", MessageBoxButtons.OK)
                cmb_aduana.Focus()
                Exit Sub
            End If

            If total_bultos() <= 0 Then
                MessageBox.Show("No se puede grabar un documento con total de bultos 0.", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If

            If cuenta_bultos > 0 Then
                If MessageBox.Show("Existe" & IIf(cuenta_bultos > 1, "n ", " ") & cuenta_bultos & " producto" & IIf(cuenta_bultos > 1, "s ", " ") & _
                                "con un total de bultos '0'." & vbCrLf & "¿Desea continual con la grabación?", "Bultos a cero '0'", MessageBoxButtons.YesNo, _
                                MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            If dtp_fecha_vence_doc.Value.Date <= dtp_fecha.Value.Date Then
                MessageBox.Show("La fecha del vencimiento de documento no puede ser igual o menor a la fecha del documento.", "Fecha invalida", MessageBoxButtons.OK)
                dtp_fecha_vence_doc.Focus()
                Exit Sub
            End If

            For ii As Integer = 0 To ds_datos.Tables("dt_detalle").Rows.Count - 1
                If ds_datos.Tables("dt_detalle").Rows(ii)("bultos") = 0 And ds_datos.Tables("dt_detalle").Rows(ii)("unidades") > 0 Then
                    MessageBox.Show("No se puede grabar la DUA porque existen productos con unidades que el valor de bultos es cero (0)", "Error en Bultos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            If cb_recibido.Text.Trim.Length <= 0 Then
                MessageBox.Show("Aún no ha seleccionado quíen recibió la DUA.", "Receptor DUA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cb_recibido.Focus()
                Exit Sub
            End If

            If MessageBox.Show("¿Desea guardar este ingreso?", "Guardar Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

            With ds_datos.Tables("dt_detalle")
                Dim sb_registro As New StringBuilder

                For ii As Integer = 0 To ds_datos.Tables("dt_detalle").Rows.Count - 1
                    sb_registro = New StringBuilder

                    If btn_grabar.Text.ToUpper = "GUARDAR" Then
                        sb_registro.Append("pa_ins_um_da_dua  ")
                    Else
                        sb_registro.Append("pa_upd_um_da_dua  ")
                    End If

                    sb_registro.Append("'").Append(txt_numero.Text).Append("', '")
                    sb_registro.Append(txt_oc.Text).Append("', ")
                    sb_registro.Append(Val(txt_total_bultos.Text)).Append(", '")
                    sb_registro.Append(dtp_fecha.Value.Date.ToShortDateString).Append("', '")
                    sb_registro.Append(dtp_fecha_vence_doc.Value.Date.ToShortDateString)
                    sb_registro.Append("', '").Append(gs_usuario).Append("', '")
                    sb_registro.Append(gs_empresa).Append("', '")
                    sb_registro.Append(cb_bodega.SelectedValue)
                    sb_registro.Append("', ").Append(ii + 1).Append(", '")
                    sb_registro.Append(.Rows(ii)("producto")).Append("', '")
                    sb_registro.Append(.Rows(ii)("codigo_barra")).Append("', ")
                    If .Rows(ii)("vence") = "S" Then sb_registro.Append("'").Append(CDate(.Rows(ii)("fecha_venc")).ToShortDateString).Append("', ") Else sb_registro.Append("NULL, ")
                    ' If cb_vence.Checked Then sb_registro.Append("'").Append(CDate(.Rows(ii)("fecha_venc")).ToShortDateString).Append("', ") Else sb_registro.Append("NULL, ")
                    sb_registro.Append("'").Append(.Rows(ii)("descripcion")).Append("', ")
                    sb_registro.Append(.Rows(ii)("bultos")).Append(", ")
                    sb_registro.Append(.Rows(ii)("unidades")).Append(", '")
                    sb_registro.Append(.Rows(ii)("estanteria")).Append("', '")
                    sb_registro.Append(.Rows(ii)("nivel")).Append("', '")
                    sb_registro.Append(.Rows(ii)("pasillo")).Append("', '")
                    sb_registro.Append(.Rows(ii)("tramo")).Append("', ")
                    sb_registro.Append(.Rows(ii)("saldo")).Append(", '")
                    sb_registro.Append(.Rows(ii)("observaciones")).Append("', ")
                    sb_registro.Append(.Rows(ii)("saldo_bultos")).Append(", '")
                    sb_registro.Append(.Rows(ii)("vence")).Append("', '")
                    sb_registro.Append(.Rows(ii)("proveedor")).Append("', '")
                    sb_registro.Append(.Rows(ii)("registro")).Append("', '")
                    sb_registro.Append(.Rows(ii)("lote")).Append("', '")
                    sb_registro.Append(.Rows(ii)("bacth")).Append("', '")
                    sb_registro.Append(.Rows(ii)("pc")).Append("', ")
                    sb_registro.Append(.Rows(ii)("unidades_malas")).Append(", ")
                    Try
                        'If cb_cosecha.Checked Then sb_registro.Append("'").Append(.Rows(ii)("produccion")).Append("', ") Else sb_registro.Append("NULL, ")
                        If .Rows(ii)("produccion").ToString.Length > 1 Then
                            sb_registro.Append("'").Append(.Rows(ii)("produccion")).Append("', ")
                        Else
                            sb_registro.Append("NULL, ")
                        End If

                    Catch ex As Exception
                        sb_registro.Append("NULL, ")
                    End Try

                    sb_registro.Append("'").Append(cmb_aduana.Text).Append("', ")
                    sb_registro.Append("'").Append(txt_contenedor.Text).Append("', ")
                    sb_registro.Append("'").Append(cb_recibido.Text).Append("','")
                    sb_registro.Append(.Rows(ii)("motivo_daño")).Append("','")
                    sb_registro.Append(txt_facturas.Text.Trim).Append("', ")
                    sb_registro.Append(Val(txt_no_ingreso.Text)).Append(",'")
                    sb_registro.Append(.Rows(ii)("origen")).Append("'")

                    Utrans.Ingresa(sb_registro.ToString)

                    If Utrans.Codigo_error <> 0 Then
                        MessageBox.Show(sb_registro.ToString & vbCrLf & vbCrLf & vbCrLf & Utrans.descripcion_error)
                        Exit Sub
                    End If
                Next
            End With

            If MessageBox.Show("Ingreso guardado satisfactoriamente." & vbCrLf & "¿Desea imprimirla?", "Guardando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Imprimir_Dua(txt_numero.Text)
            End If
            If btn_grabar.Text.ToUpper = "GUARDAR" Then guardarAvisos()

            nuevo_dua()
            actualiza_lista_dua()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try

    End Sub

    Private Sub btn_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_borrar.Click
        If MessageBox.Show("¿Realmente desea eliminar este ingreso?", "Eliminar ingreso", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim Utrans As New Transaccional.Conexion("scm")
        Try
            Utrans.open()

            sql_st = "pa_del_um_da_dua '" & gs_empresa & "','" & txt_numero.Text & "'"
            Utrans.Elimina(sql_st)

            nuevo_dua()
            btn_borrar.Enabled = False
            actualiza_lista_dua()
        Catch ex As Exception
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub dgv_detalle_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_detalle.DoubleClick
        Try
            idRow = dgv_detalle.CurrentRow.Index

            Dim producto As String = dgv_detalle.Item("producto", dgv_detalle.CurrentRow.Index).Value.ToString

            Dim mNewRow() As DataRow = ds_datos.Tables("dt_detalle").Select("producto = '" & producto & "'")

            nuevo_producto()

            txt_cod_producto.Text = mNewRow(0)("producto").ToString
            txt_cod_barras.Text = mNewRow(0)("codigo_barra").ToString
            txt_descripcion.Text = mNewRow(0)("descripcion").ToString
            txt_bultos.Text = mNewRow(0)("bultos").ToString
            txt_unidades.Text = mNewRow(0)("unidades").ToString
            txt_estanteria.Text = mNewRow(0)("estanteria").ToString
            txt_niveles.Text = mNewRow(0)("nivel").ToString
            txt_pasillo.Text = mNewRow(0)("pasillo").ToString
            txt_tramo.Text = mNewRow(0)("tramo").ToString
            gs_empresa = mNewRow(0)("empresa").ToString
            Label15.Text = "Proveedor:  " & mNewRow(0)("proveedor")
            Me.Text = "::. Mantenedor de Ingresos (DUA) | Proveedor: " & mNewRow(0)("proveedor") & " .:: "

            If mNewRow(0)("fecha_venc").ToString.Trim.Length > 0 Then
                dtp_vence_producto.Value = mNewRow(0)("fecha_venc").ToString
                cb_vence.Checked = True
            Else
                cb_vence.Checked = False
            End If

            If Val(mNewRow(0)("produccion").ToString) <> 0 Then
                dtp_produccion.Value = mNewRow(0)("produccion").ToString
                cb_cosecha.Checked = True
            Else
                cb_cosecha.Checked = False
            End If

            txt_observaciones.Text = mNewRow(0)("observaciones").ToString
            txt_r_sanitario.Text = mNewRow(0)("Registro").ToString
            txt_lote.Text = mNewRow(0)("lote").ToString
            txt_batch.Text = mNewRow(0)("bacth").ToString
            txt_pc.Text = mNewRow(0)("pc").ToString
            txt_dañadas.Text = mNewRow(0)("unidades_malas").ToString
            Me.txtOrigen.Text = mNewRow(0)("origen").ToString

            For ii As Integer = 0 To cmb_razon_daño.Items.Count - 1
                cmb_razon_daño.SelectedIndex = ii

                    If cmb_razon_daño.Text.Trim = mNewRow(0)("motivo_daño").ToString Then Exit For

                If ii = cmb_razon_daño.Items.Count - 1 Then cmb_razon_daño.SelectedIndex = -1
            Next

            btn_agregar.Tag = "EDICION"
            btn_agregar.ImageIndex = 5
            btn_agregar.Text = "Actualizar Datos"

            txt_total_bultos.Text = total_bultos()

            buscar_producto(mNewRow(0)("producto").ToString)

        Catch ex As Exception
            MessageBox.Show("Se produjo un error al obtener el producto por favor intentelo de nuevo. " & _
                            vbCrLf & " ----------------------" & vbCrLf & "Error:" & vbCrLf & ex.Message, _
                            "Error Al Retraer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btn_ayuda_oc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda_oc.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "numero,fecha,proveedor"
        frm_busqueda.nombre_vista = "vi_ordencompras_dua"
        frm_busqueda.lista_campos = "numero, fecha, proveedor, unidades, valor"
        frm_busqueda.txt_buscar1.Focus()

        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.dg_buscar.ReadOnly = False
        frm_busqueda.btn_seleccion_multipe.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = False
        frm_busqueda.ShowDialog(Me)

        no_oc = frm_busqueda.resultado

        txt_oc.Text = no_oc

        frm_busqueda.Dispose()
        frm_busqueda = Nothing
    End Sub

    Private Function buscar_oc() As Boolean
        If txt_oc.Text = "0000000000" Then Exit Function

        Try
            Dim Utrans As New Transaccional.Conexion("flexline")

            Try
                Utrans.open()

                sql_st = "pa_sel_um_documento '" & gs_empresa & "', 'ORDEN DE COMPRA', '" & txt_oc.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 And dt.Rows.Count <= 1 Then
                    dtp_fecha.Value = Now.Date
                Else
                    MessageBox.Show("El número de Orden de Compra ingresado no Existe.", "Error en número", MessageBoxButtons.OK)
                    Return False
                End If

                sql_st = "pa_sel_um_documento_detalle_proveedor_dua 'CONFIRMACION PROVEEDOR', '" & gs_empresa & "', '" & txt_oc.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 Then
                    ds_datos.Tables("dt_detalle").Rows.Clear()

                    Label15.Text = "Proveedor:  " & dt.Rows(0)("razonSocial")

                    Me.Text = "::. Mantenedor de Ingresos (DUA) | Proveedor: " & dt.Rows(0)("razonSocial") & " .:: "

                    For ii As Integer = 0 To dt.Rows.Count - 1
                        Dim mNewRow As DataRow = ds_datos.Tables("dt_detalle").NewRow

                        mNewRow("producto") = dt.Rows(ii)("producto")
                        mNewRow("codigo_barra") = dt.Rows(ii)("codigobarra")
                        mNewRow("descripcion") = dt.Rows(ii)("glosa")
                        mNewRow("bultos") = 0
                        mNewRow("unidades") = dt.Rows(ii)("cantidad")
                        mNewRow("estanteria") = String.Empty
                        mNewRow("nivel") = String.Empty
                        mNewRow("pasillo") = String.Empty
                        mNewRow("tramo") = String.Empty
                        mNewRow("empresa") = gs_empresa
                        mNewRow("saldo") = 0
                        mNewRow("fecha_venc") = dt.Rows(ii)("fechavcto")
                        mNewRow("observaciones") = String.Empty
                        mNewRow("saldo_bultos") = 0
                        mNewRow("vence") = "S"
                        mNewRow("proveedor") = dt.Rows(ii)("razonSocial")
                        mNewRow("Bodega") = cb_bodega.Text
                        mNewRow("Registro") = String.Empty
                        mNewRow("lote") = String.Empty
                        mNewRow("bacth") = String.Empty
                        mNewRow("pc") = String.Empty
                        mNewRow("unidades_malas") = 0

                        ds_datos.Tables("dt_detalle").Rows.Add(mNewRow)
                    Next

                    dt_productos = ds_datos.Tables("dt_detalle").Copy

                    Dim clGen As New ClasesGenerales.General
                    clGen.Alinear_GridView(ds_datos.Tables("dt_detalle"), dgv_detalle, "", "", "", "", "", "", "", True, True, 250, 0)
                    clGen = Nothing

                Else
                    MessageBox.Show("El número de Orden de Compra ingresado no Existe.", "Error en número", MessageBoxButtons.OK)
                    Return False
                End If

            Catch ex As Exception
                MessageBox.Show("Se produjo el siguiente error al cargar el detalle de la OC:" & vbCrLf & ex.Message)
            Finally
                Utrans.close()
                Utrans = Nothing
            End Try
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub txt_oc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_oc.TextChanged
        If txt_oc.Text.Trim.Length = 10 And txt_numero.Text.Trim.Length > 0 Then buscar_oc()
    End Sub

    Private Sub dtp_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha.ValueChanged
        dtp_fecha_vence_doc.Value = (dtp_fecha.Value.Date.AddYears(1)).AddDays(-1)
    End Sub

    Private Sub dgv_detalle_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_detalle.CellFormatting
        Dim drv As DataRowView
        If e.ColumnIndex = 6 Then e.Value = 0
        Try
            If e.RowIndex >= 0 Then

                If e.RowIndex <= ds_datos.Tables("dt_detalle").Rows.Count - 1 Then

                    drv = ds_datos.Tables("dt_detalle").DefaultView.Item(e.RowIndex)

                    If drv.Item("lote").ToString.Trim.Length <= 0 And drv.Item("bultos").ToString.Trim.Length > 0 Then

                        e.CellStyle.BackColor = Color.Yellow

                    Else

                        If txt_oc.Text <> "0000000000" And dt_productos.Rows.Count > 0 Then

                            If dt_productos.Compute("count(producto)", "producto = '" & dgv_detalle.Item("producto", e.RowIndex).Value.ToString & "'") > 0 Then

                                If ds_datos.Tables("dt_detalle").Compute("sum(unidades)", "producto = '" & dgv_detalle.Item("producto", e.RowIndex).Value.ToString & "'") - dt_productos.Compute("sum(unidades)", "producto = '" & dgv_detalle.Item("producto", e.RowIndex).Value.ToString & "'") <> 0 Then

                                    Dim diferencia As Integer = ds_datos.Tables("dt_detalle").Compute("sum(unidades)", "producto = '" & dgv_detalle.Item("producto", e.RowIndex).Value.ToString & "'") - dt_productos.Compute("sum(unidades)", "producto = '" & dgv_detalle.Item("producto", e.RowIndex).Value.ToString & "'")

                                    If e.ColumnIndex = 6 Then e.Value = diferencia

                                    e.CellStyle.BackColor = Color.Salmon
                                Else

                                    If drv.Item("registro").ToString.Trim.Length <= 0 Then
                                        dgv_detalle.Item("Registro", e.RowIndex).Style.BackColor = Color.Brown
                                    Else
                                        e.CellStyle.BackColor = Color.White
                                    End If
                                End If
                            End If
                        Else
                            If drv.Item("registro").ToString.Trim.Length <= 0 Then
                                dgv_detalle.Item("Registro", e.RowIndex).Style.BackColor = Color.Brown
                            Else
                                e.CellStyle.BackColor = Color.White
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_numero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.TextChanged
        If txt_numero.Text.Trim.Length > 0 Then
            btn_ayuda_oc.Enabled = True
        Else
            btn_ayuda_oc.Enabled = False
        End If
    End Sub

    Private Sub cb_cosecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cosecha.CheckedChanged
        If cb_cosecha.Checked Then
            dtp_produccion.Enabled = True
        Else
            dtp_produccion.Enabled = False
        End If
    End Sub

    Private Sub cb_vence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_vence.CheckedChanged
        If cb_vence.Checked Then
            dtp_vence_producto.Enabled = True
        Else
            dtp_vence_producto.Enabled = False
        End If
    End Sub

    Private Sub frm_dua_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txt_numero.Focus()
    End Sub

    Private Sub verifica_unidades()
        If txt_oc.Text = "0000000000" Then Exit Sub

        If dgv_detalle.Item("producto", idRow).Value.ToString.Trim <> txt_cod_producto.Text.Trim Then Exit Sub

        Dim diferencia As Double = ds_datos.Tables("dt_detalle").Compute("sum(unidades)", "producto = '" & dgv_detalle.Item("producto", idRow).Value.ToString & "'") - dt_productos.Compute("sum(unidades)", "producto = '" & dgv_detalle.Item("producto", idRow).Value.ToString & "'")
        If diferencia > 0 Then
            MessageBox.Show("Se estan ingresando " & diferencia & " unidad" & IIf(diferencia > 1, "es ", " ") & _
                            "más de la cantidad que tiene la orden de Compra.", "Diferencia en unidades", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf diferencia < 0 Then
            MessageBox.Show("Se estan ingresando " & diferencia * -1 & " unidad" & IIf(diferencia * -1 > 1, "es ", " ") & _
                            "menos de la cantidad que tiene la orden de Compra.", "Diferencia en unidades", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txt_oc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_oc.Leave
        txt_oc.Text = Microsoft.VisualBasic.Right("0000000000" & txt_oc.Text, 10)
    End Sub

    Private Sub dgv_detalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_detalle.KeyDown

        idRow = dgv_detalle.CurrentCell.RowIndex

        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("¿Está Seguro de elimiar esta línea?", "Eliminar Línea", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Sub

            ds_datos.Tables("dt_detalle").Rows(idRow).Delete()
        End If
    End Sub

    Private Sub txt_bultos_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_bultos.Leave
        txt_bultos.Text = Val(txt_bultos.Text)
    End Sub

    Private Sub txt_unidades_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_unidades.Leave
        txt_unidades.Text = Val(txt_unidades.Text)
    End Sub

    Private Sub txt_dañadas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dañadas.Leave
        txt_dañadas.Text = Val(txt_dañadas.Text)
    End Sub

    Private Sub limpia_info_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles limpia_info.Click
        nuevo_producto()
    End Sub

    Private Sub txt_dañadas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dañadas.TextChanged
        If Val(txt_dañadas.Text) = 0 Then
            cmb_razon_daño.SelectedIndex = -1
            cmb_razon_daño.Enabled = False
        Else
            cmb_razon_daño.Enabled = True
        End If
    End Sub

    Private Sub txt_numero_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.Leave
        If Not nuevo Then Exit Sub
        Dim Utrans As New Transaccional.Conexion("scm")

        If txt_numero.Text.Trim.Length > 0 Then
            Try
                Utrans.open()

                sql_st = "pa_var_um_numero_dua '" & gs_empresa & "','" & txt_numero.Text & "'"
                dt = Utrans.Obtiene(sql_st)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("La DUA No. " & txt_numero.Text & " ya existe en la base de datos." & vbCrLf & "Por favor verifique su número.", "Error de Número.", MessageBoxButtons.OK)
                    txt_numero.Text = String.Empty
                    txt_numero.Focus()
                Else
                    txt_numero.Enabled = False
                    txt_numero.BackColor = Color.White
                End If

            Catch ex As Exception
            Finally
                Utrans.close()
                Utrans = Nothing
            End Try
        End If
    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub txt_r_sanitario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_r_sanitario.TextChanged

    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.txtBuscar.Text.Length > 0 Then
                realizarBusqueda()
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub dgv_lista_ingresos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_lista_ingresos.CellContentClick

    End Sub
End Class

