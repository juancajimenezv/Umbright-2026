Public Class Form6
    Dim Ods As DataSet
    Dim gs_empresa As String = "LOGISERV"

    Private Sub inicializarTablas()
        Dim Otrans As New Transaccional.Conexion("Flexline")

        Dim ls_sql As String
        Dim dt As DataTable
        Try
            Otrans.open()

            Ods = New DataSet

            ls_sql = "Select distinct CODIGO from gen_tabcod " & _
                                    " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.FAMILIA' " & _
                                    " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " & _
                                    " UNION select distinct Familia from Producto where empresa='" & gs_empresa & "'  order by 1 "
            'ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.FAMILIA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_Familia"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "Select distinct CODIGO from gen_tabcod " & _
                    " WHERE empresa = '" & gs_empresa & "' and Tipo = 'PRODUCTO.SUBFAMILIA' " & _
                    " and coalesce(tipo, '') <> ''  and isnull(vigencia, '') <> 'N' " & _
                    " UNION select distinct SubFamilia from Producto where empresa='" & gs_empresa & "'  order by 1 "

            '            ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.SUBFAMILIA','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_SubFamilia"
            Ods.Tables.Add(dt.Copy)

            'hace falta tipo producto


            ls_sql = "pa_sel_um_gen_tabcod null,'PRODUCTO.TIPO','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_tipo"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "Select distinct(unidad) as Codigo from producto where empresa = '" & gs_empresa & " ' and validastock = 'S' order by 1"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_unidad_medida"
            Ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_gen_tabcod null,'GEN_TIPOPRODUCTO','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "cat_tipo2"
            Ods.Tables.Add(dt.Copy)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub
    Private Sub Llenar_Combos()
        Dim ls_sql, lssql As String
        Dim dta, dt As New DataTable
        Dim dse As New DataSet
        Dim Otrans As New Transaccional.Conexion("Flexline")

        Try

        cmb_familia.DataSource = Ods.Tables("cat_familia")
        cmb_familia.DisplayMember = "CODIGO"
        cmb_familia.ValueMember = "CODIGO"

        cmb_proveedor.DataSource = Ods.Tables("cat_Subfamilia")
        cmb_proveedor.DisplayMember = "Codigo"
        cmb_proveedor.ValueMember = "CODIGO"

        cmb_tipo_producto.DataSource = Ods.Tables("cat_tipo")
        cmb_tipo_producto.DisplayMember = "Codigo"
        cmb_tipo_producto.ValueMember = "CODIGO"

        cmb_unidad_medida.DataSource = Ods.Tables("cat_unidad_medida")
        cmb_unidad_medida.ValueMember = "Codigo"
        cmb_unidad_medida.DisplayMember = "CODIGO"

        cmb_tipo2.DataSource = Ods.Tables("cat_tipo2")
        cmb_tipo2.DisplayMember = "Codigo"
        cmb_tipo2.ValueMember = "CODIGO"

            Otrans.open()

            ''ls_sql = "pa_vb_Codigo_Producto_3pl_Grupo "
            'ls_sql = "select distinct familia from flexline.producto where empresa='logiserv' and VALIDASTOCK='s' and vigente='s' and (familia not in ('','servicios') or familia is not null)"
            'dt = Otrans.Obtiene(ls_sql)
            'dt.TableName = "gp1"
            'dse.Tables.Add(dt.Copy)

            'Me.cmb_ani.DisplayMember = "familia"
            'Me.cmb_ani.ValueMember = "familia"
            'Me.cmb_ani.DataSource = dt

            lssql = "select distinct familia Codigo from flexline.producto where empresa='logiserv' and VALIDASTOCK='s' and vigente='s' and (familia not in ('','servicios') or familia is not null)"
            dt = Otrans.Obtiene(lsSQL)
            dt.TableName = "fami"
            Me.cmb_Grupo.DisplayMember = "Codigo"
            Me.cmb_Grupo.ValueMember = "Codigo"
            Me.cmb_Grupo.DataSource = dt

            ls_sql = "select distinct Procedencia from flexline.producto where empresa='" & gs_empresa & "' and procedencia is not null order by Procedencia"
            dta = Otrans.Obtiene(ls_sql)
            dta.TableName = "proc"
            dse.Tables.Add(dta.Copy)

            Me.cb_Procedencia.DisplayMember = "Procedencia"
            Me.cb_Procedencia.ValueMember = "Procedencia"
            Me.cb_Procedencia.DataSource = dta

            ls_sql = "select distinct UnidadAlt from flexline.producto where empresa='" & gs_empresa & "' and unidadalt is not null order by UnidadAlt"
            dta = Otrans.Obtiene(ls_sql)
            dta.TableName = "uAlt"
            dse.Tables.Add(dta.Copy)

            Me.cmb_Alternativa.DisplayMember = "UnidadAlt"
            Me.cmb_Alternativa.ValueMember = "UnidadAlt"
            Me.cmb_Alternativa.DataSource = dta

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        cmb_Grupo.Focus()

    End Sub

    Private Sub buscabarra2()

        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String

        Dim lsSQL1 As String
        Dim lsSQL2 As String
        Dim lsSQL3 As String
        Dim lsSQL4 As String
        Try
            otrans.open()
            dt = otrans.Obtiene("pa_sel_um_prodcodbarra '" & gs_empresa & "',null,'2','" & Me.txt_subtipo.Text & "'")


            If txt_glosa.Text = "" Then
                MessageBox.Show("Debe ingresar descripcion para el producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                lsSQL1 = "pa_ins_um_producto_anixter '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & Me.txt_glosa.Text & "','" & Me.cmb_tipo2.Text & "','" & Me.cmb_familia.Text & "','" & Me.cmb_proveedor.Text & "' ,'" & Me.cmb_tipo_producto.Text & "' ,'" & Me.txt_subtipo.Text & "' ,'S','" & Me.cmb_unidad_medida.Text & "','" & nud_Decimales.Value & "','" & cb_Procedencia.Text & "','" &
                   tb_Factor.Text & "','" & nud_DecimalesAlt.Value & "','" & IIf(ckb_Serie.Checked = True, "S", "N") & "','" & IIf(ckb_Lote.Checked = True, "S", "N") & "','" & IIf(ckb_FechaVcto.Checked = True, "S", "N") & "','" & IIf(ckb_ValidaStock.Checked = True, "S", "N") & "','" & IIf(ckb_Costea.Checked = True, "S", "N") & "','" & IIf(ckb_Iva.Checked = True, "1", "0") & "',.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,.0,'" & tb_Peso.Text & "','" & tb_Volumen.Text & "','" &
                   tb_cla_volumen.Text & "','" & tb_cla_Peso.Text & "','" & tb_cla_CajasxTar.Text & "','" & tb_cla_CajasxCam.Text & "','" &
                   tb_cla_CmasxTar.Text & "','" & Me.dtFecha.Text & "','" & gs_usuario & "'"
                otrans.Ingresa(lsSQL1)

                lsSQL2 = "pa_ins_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & Me.txt_producto.Text & "','" & Me.cmb_unidad_medida.Text & "',1,1,1,' '"
                otrans.Ingresa(lsSQL2)

                lsSQL3 = "pa_ins_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_subtipo.Text & "','" & Me.txt_producto.Text & "','" & Me.cmb_unidad_medida.Text & "',1,2,1,' '"
                otrans.Ingresa(lsSQL3)

                lsSQL4 = "pa_ins_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_codtesa.Text & "','" & Me.txt_producto.Text & "','" & Me.cmb_unidad_medida.Text & "',1,4,1,' '"
                otrans.Ingresa(lsSQL4)

                If tb_Codigo_Cliente.Text.Length > 0 Then
                    Guarda_Codigo_Cliente()
                End If

                MessageBox.Show("Producto Grabado Exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("El código de barra ya esta asignado para otro producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub Actualiza()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String

        Dim lsSQL1 As String
        Dim lsSQL2 As String
        Dim lsSQL3 As String
        Try
            otrans.open()

            If txt_glosa.Text = "" Then
                MessageBox.Show("Debe ingresar descripcion para el producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_glosa.Focus()

            Else

                lsSQL1 = "pa_ins_um_producto_anixter_Actualiza '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & Me.txt_glosa.Text & "','" & Me.cmb_tipo2.Text & "','" & Me.cmb_familia.Text & "','" & Me.cmb_proveedor.Text & "' ,'" & Me.cmb_tipo_producto.Text & "' ,'" & Me.txt_subtipo.Text & "' ,'" & nud_Decimales.Value & "','" & cb_Procedencia.Text & "','" &
                   nud_DecimalesAlt.Value & "','" & IIf(ckb_ValidaStock.Checked = True, "S", "N") & "','" & IIf(ckb_Costea.Checked = True, "S", "N") & "','" & IIf(ckb_Iva.Checked = True, "1", "0") & "','" & tb_Peso.Text & "','" & tb_Volumen.Text & "','" &
                   tb_cla_volumen.Text & "','" & tb_cla_Peso.Text & "','" & tb_cla_CajasxTar.Text & "','" & tb_cla_CajasxCam.Text & "','" &
                   tb_cla_CmasxTar.Text & "','" & gs_usuario & "'"
                otrans.Ingresa(lsSQL1)

                lsSQL2 = "pa_upd_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & Me.txt_codtesa.Text & "'," & 4
                otrans.Actualiza(lsSQL2)

                If tb_Codigo_Cliente.Text.Length > 0 Then
                    Actualiza_Codigo_Cliente()
                End If


                MessageBox.Show("Producto Actualizado Exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub buscarproducto()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_prod '" & gs_empresa & "', '" & Me.txt_producto.Text & "'"
            dt = Otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then

                Me.cmb_Grupo.Enabled = False
                Me.txt_producto.Enabled = False
                Me.txt_glosa.Text = dt.Rows(0)("glosa").ToString
                Me.cmb_tipo2.Text = dt.Rows(0)("tipoproducto").ToString

                Me.cmb_familia.Text = dt.Rows(0)("familia").ToString
                Me.cmb_proveedor.Text = dt.Rows(0)("subfamilia").ToString
                Me.cmb_tipo_producto.Text = dt.Rows(0)("tipo").ToString
                Me.txt_subtipo.Text = dt.Rows(0)("subtipo").ToString
                Me.cb_Procedencia.Text = dt.Rows(0)("Procedencia").ToString

                Me.cmb_unidad_medida.Text = dt.Rows(0)("unidad").ToString
                Me.cmb_unidad_medida.Enabled = False
                Me.nud_Decimales.Value = dt.Rows(0)("Decimales").ToString
                Me.cmb_Alternativa.Text = dt.Rows(0)("UnidadAlt").ToString
                Me.cmb_Alternativa.Enabled = False
                Me.nud_DecimalesAlt.Value = dt.Rows(0)("DecimalesAlt").ToString
                Me.tb_Factor.Text = dt.Rows(0)("FactorAlt").ToString
                Me.tb_Factor.Enabled = False
                Me.tb_Peso.Text = dt.Rows(0)("Peso").ToString
                Me.tb_Volumen.Text = dt.Rows(0)("Volumen").ToString

                Me.ckb_Iva.Checked = dt.Rows(0)("Iva").ToString
                Me.ckb_Lote.Checked = dt.Rows(0)("Lote").ToString
                Me.ckb_Lote.Enabled = False
                Me.ckb_Serie.Checked = dt.Rows(0)("Serie").ToString
                Me.ckb_Serie.Enabled = False
                Me.ckb_FechaVcto.Checked = dt.Rows(0)("FechaVcto").ToString
                Me.ckb_FechaVcto.Enabled = False
                Me.ckb_Costea.Checked = dt.Rows(0)("Costeable").ToString
                Me.ckb_ValidaStock.Checked = dt.Rows(0)("ValidaStock").ToString

                Me.tb_cla_volumen.Text = dt.Rows(0)("VolumenM3").ToString()
                Me.tb_cla_Peso.Text = dt.Rows(0)("PesoKg").ToString()
                Me.tb_cla_CajasxTar.Text = dt.Rows(0)("CajasxTar").ToString()
                Me.tb_cla_CajasxCam.Text = dt.Rows(0)("CajasxCam").ToString()
                Me.tb_cla_CmasxTar.Text = dt.Rows(0)("CamasxTar").ToString()

                Me.btn_guardar.Text = "Actualizar"


            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub
    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmb_tipo_producto.Text = ""
        inicializarTablas()
        Llenar_Combos()
        cmb_Grupo.Focus()

    End Sub

    Private Sub limpiar()
        'cmb_ani.Text = String.Empty
        txt_producto.Text = String.Empty
        txt_glosa.Text = String.Empty
        txt_subtipo.Text = String.Empty
        cmb_familia.Text = String.Empty
        cmb_proveedor.Text = String.Empty
        cmb_tipo_producto.Text = String.Empty
        cmb_tipo2.Text = String.Empty

        cmb_unidad_medida.Text = String.Empty
        txt_glosa.ReadOnly = False
        cb_Procedencia.Text = String.Empty

        cmb_Alternativa.Text = String.Empty
        nud_DecimalesAlt.Value = 0
        nud_Decimales.Value = 0
        tb_Factor.Text = "0"
        tb_Peso.Text = "0"
        tb_Volumen.Text = "0"
        ckb_Iva.Checked = False
        ckb_Lote.Checked = False
        ckb_Serie.Checked = False
        ckb_FechaVcto.Checked = False
        ckb_Costea.Checked = False
        ckb_ValidaStock.Checked = False
        tb_cla_volumen.Text = String.Empty
        tb_cla_Peso.Text = String.Empty
        tb_cla_CajasxTar.Text = String.Empty
        tb_cla_CajasxCam.Text = String.Empty
        tb_cla_CmasxTar.Text = String.Empty
        cmb_Grupo.Enabled = True
        txt_producto.Enabled = True
        btn_guardar.Text = "Guardar"
    End Sub
    
    Private Sub validar()
        If txt_glosa.Text = "" Then
            MessageBox.Show("Debe ingresar descripcion para el producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        If cmb_tipo2.Text = "" Then
            MessageBox.Show("Debe ingresar el Tipo de producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If cmb_familia.Text = "" Then
            MessageBox.Show("Debe ingresar familia del producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If cmb_proveedor.Text = "" Then
            MessageBox.Show("Debe ingresar proveedor del producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If cmb_tipo_producto.Text = "" Then
            MessageBox.Show("Debe ingresar la marca del producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If txt_subtipo.Text = "" Then
            MessageBox.Show("Debe ingresar subtipo del producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If cmb_unidad_medida.Text = "" Then
            MessageBox.Show("Debe ingresar unidad de medida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If btn_guardar.Text = "Guardar" Then
            buscabarra2()
            limpiar()
        Else
            Actualiza()
            limpiar()
        End If

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
    End Sub

    Private Sub txt_producto_LostFocus(sender As Object, e As EventArgs) Handles txt_producto.LostFocus
        buscarproducto()
        txt_glosa.Focus()
    End Sub

    Private Sub cmb_ani_SelectedIndexChanged(sender As Object, e As EventArgs)
        txt_producto.Focus()
    End Sub

    Private Sub cmb_ani_SelectedValueChanged(sender As Object, e As EventArgs)
        limpiar()
        Asigna_codigo()
        txt_producto.Focus()
    End Sub

    Private Sub Asigna_codigo()
        Dim dt As New DataTable
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()

        ls_SqlScript = "flexline.pa_vb_Codigo_Producto_3pl_Asigna_Correlativo '" & cmb_Grupo.Text & "'"
        dt = otrans.Obtiene(ls_SqlScript)  'obtiene o ejecuta el procedimiento para extraer los datos

        txt_producto.Text = dt.Rows(0).Item("Producto")
        txt_producto.Focus()

        'ldt_table = otrans.Obtiene(ls_SqlScript)
        'ldt_table.TableName = "Estado"
        'l_Dataset.Tables.Add(ldt_table.Copy)

        'Me.cb_FormasPago.DisplayMember = "Codigo"
        'Me.cb_FormasPago.ValueMember = "Codigo"
        'Me.cb_FormasPago.DataSource = ldt_table
    End Sub

    Private Sub Guarda_Codigo_Cliente()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String

        Dim lsSQL1 As String
        Dim lsSQL2 As String
        Dim lsSQL3 As String

        Try
            otrans.open()
            lsSQL2 = "pa_ins_um_prodcodbarra '" & gs_empresa & "','" & tb_Codigo_Cliente.Text & "','" & Me.txt_producto.Text & "','" & Me.cmb_unidad_medida.Text & "',1,4,1,' '"
            otrans.Ingresa(lsSQL2)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub


    Private Sub Actualiza_Codigo_Cliente()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim lsSQL As String

        Dim lsSQL1 As String
        Dim lsSQL2 As String
        Dim lsSQL3 As String

        Try
            otrans.open()
            lsSQL2 = "pa_upd_um_prodcodbarra '" & gs_empresa & "','" & Me.txt_producto.Text & "','" & tb_Codigo_Cliente.Text & "',4"
            otrans.Ingresa(lsSQL2)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub
End Class