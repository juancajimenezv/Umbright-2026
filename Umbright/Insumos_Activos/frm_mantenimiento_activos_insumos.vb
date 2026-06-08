Imports System.Text.RegularExpressions

Public Class frm_mantenimiento_activos_insumos
    Public insumos As Boolean = False
    Public ds_insumos As New DataSet

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")

        otrans.open()

        Try


            ls_sql = "call pa_sel_um_act_marca ()"
            dt = otrans.Obtiene(ls_sql)

            Me.cmb_marca.DataSource = dt
            Me.cmb_marca.DisplayMember = "descripcion"
            Me.cmb_marca.ValueMember = "cod_marca"

            ls_sql = "call pa_sel_um_act_marca_modelo (null)"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "marca_modelo"
            ds_insumos.Tables.Add(dt.Copy)

            ds_insumos.Tables("marca_modelo").DefaultView.RowFilter = "cod_marca = " & Me.cmb_marca.SelectedValue.ToString
            Me.cmb_modelo.DataSource = ds_insumos.Tables("marca_modelo").DefaultView
            Me.cmb_modelo.DisplayMember = "descripcion"
            Me.cmb_modelo.ValueMember = "cod_marca_modelo"

            ls_sql = "call pa_sel_um_act_categoria ()"
            dt = otrans.Obtiene(ls_sql)

            If insumos Then
                dt.DefaultView.RowFilter = "cod_categoria = 1"
            Else
                dt.DefaultView.RowFilter = "cod_categoria <> 1"
            End If


            Me.cmb_categoria.DataSource = dt.DefaultView
            Me.cmb_categoria.DisplayMember = "descripcion"
            Me.cmb_categoria.ValueMember = "cod_categoria"





            ls_sql = "call pa_sel_um_act_tipo_producto (null)"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "tipos"
            ds_insumos.Tables.Add(dt.Copy)
            ds_insumos.Tables("tipos").DefaultView.RowFilter = "cod_categoria = " & Me.cmb_categoria.SelectedValue.ToString

            Me.cmb_tipos.DataSource = ds_insumos.Tables("tipos").DefaultView
            Me.cmb_tipos.DisplayMember = "descripcion"
            Me.cmb_tipos.ValueMember = "cod_tipo_producto"


            ls_sql = "call pa_var_um_act_marca_modelo()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_marca_modelo"
            ds_insumos.Tables.Add(dt.Copy)

            ls_sql = "call pa_sel_um_act_software ()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_software"
            ds_insumos.Tables.Add(dt.Copy)

            ls_sql = "call pa_sel_um_act_caracteristica ()"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "m_caracteristica"
            ds_insumos.Tables.Add(dt.Copy)

            Me.cmb_opciones.Items.Add("categoria")
            Me.cmb_opciones.Items.Add("tipo")
            Me.cmb_opciones.Items.Add("codigo")
            Me.cmb_opciones.Items.Add("marca")
            Me.cmb_opciones.Items.Add("modelo")
            Me.cmb_opciones.Items.Add("usuario_actual")

            Me.cmb_operadores.Items.Add("like")
            Me.cmb_operadores.Items.Add("=")
            Me.cmb_operadores.Items.Add(">")
            Me.cmb_operadores.Items.Add("<")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub crear_estructura()
        Dim dt As New DataTable("modelos_aplicados")

        dt.Columns.Add(New DataColumn("marca_modelo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("unidades", GetType(Integer)))
        ds_insumos.Tables.Add(dt.Copy)

        dt = New DataTable("software_equipo")
        dt.Columns.Add(New DataColumn("cod_software", GetType(Integer)))
        dt.Columns.Add(New DataColumn("licencia", GetType(String)))
        ds_insumos.Tables.Add(dt.Copy)

        dt = New DataTable("caracteristicas_equipo")
        dt.Columns.Add(New DataColumn("cod_caracteristica", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        ds_insumos.Tables.Add(dt.Copy)

        Me.dg_insumos_asociados.DataSource = ds_insumos.Tables("modelos_aplicados")
        Me.dg_software.DataSource = ds_insumos.Tables("software_equipo")
        Me.dg_caracteristicas.DataSource = ds_insumos.Tables("caracteristicas_equipo")




        Try
            Combo_Modelos_Aplicados()
            Combo_software_equipo()
            Combo_caracteristicas_equipo()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Combo_Modelos_Aplicados()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "modelos_aplicados"

        Dim dt As DataTable = ds_insumos.Tables("telefono_cliente")
        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "marca_modelo"
        ComboTextCol.HeaderText = "Modelo que Aplica"
        ComboTextCol.Width = 150
        ComboTextCol.ColumnComboBox.DataSource = ds_insumos.Tables("m_marca_modelo").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_marca_modelo"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight
        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5

        tableStyle.GridColumnStyles.Add(ComboTextCol)


        Dim TextCol As New ClasesGenerales.DataGridColoredTextBoxColumn

        TextCol.MappingName = "unidades"
        TextCol.HeaderText = "Unidades"
        TextCol.Width = 100
        TextCol.ReadOnly = True

        tableStyle.GridColumnStyles.Add(TextCol)

        Me.dg_insumos_asociados.TableStyles.Clear()
        Me.dg_insumos_asociados.TableStyles.Add(tableStyle)

    End Sub

    Private Sub Combo_software_equipo()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "software_equipo"


        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "cod_software"
        ComboTextCol.HeaderText = "Software"
        ComboTextCol.Width = 125
        ComboTextCol.ColumnComboBox.DropDownWidth = 200
        ComboTextCol.ColumnComboBox.DataSource = ds_insumos.Tables("m_software").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_software"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight
        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5

        tableStyle.GridColumnStyles.Add(ComboTextCol)


        Dim TextCol As New ClasesGenerales.DataGridColoredTextBoxColumn

        TextCol.MappingName = "licencia"
        TextCol.HeaderText = "Licencia"
        TextCol.Width = 150
        'TextCol.ReadOnly = False

        tableStyle.GridColumnStyles.Add(TextCol)

        Me.dg_software.TableStyles.Clear()
        Me.dg_software.TableStyles.Add(tableStyle)

    End Sub

    Private Sub Combo_caracteristicas_equipo()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "caracteristicas_equipo"


        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "cod_caracteristica"
        ComboTextCol.HeaderText = "Caracteristica"
        ComboTextCol.Width = 100
        ComboTextCol.ColumnComboBox.DataSource = ds_insumos.Tables("m_caracteristica").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_caracteristica"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight
        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5

        tableStyle.GridColumnStyles.Add(ComboTextCol)


        Dim TextCol As New ClasesGenerales.DataGridColoredTextBoxColumn

        TextCol.MappingName = "descripcion"
        TextCol.HeaderText = "Descripcion"
        TextCol.Width = 150
        'TextCol.ReadOnly = False

        tableStyle.GridColumnStyles.Add(TextCol)

        Me.dg_caracteristicas.TableStyles.Clear()
        Me.dg_caracteristicas.TableStyles.Add(tableStyle)

    End Sub



    Private Sub Personalizar_Vista()
        If insumos Then
            Me.gb_marca_modelo.Visible = False
            Me.dg_software.Visible = False
            Me.dg_caracteristicas.Visible = False
            Me.lbl_caracteristicas.Visible = False
            Me.lbl_software.Visible = False
            Me.dg_insumos_asociados.Location = New Point(115, 157)
            Me.lbl_modelos.Location = New Point(3, 157)
        Else
            Me.dg_insumos_asociados.Visible = False
            Me.lbl_modelos.Visible = False
            Me.Text = "::. Mantenimiento de Activos .::"
        End If

    End Sub

    Private Sub Guardar_Informacion()
        Dim ls_sql As String

        Dim dt As New DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try

            If Me.chk_generar.CheckState = CheckState.Checked Then
                ''Debo Generar El Correlativo
                ls_sql = "call pa_var_um_act_producto_correlativo (" & _
                            Me.cmb_categoria.SelectedValue.ToString & ")"

                dt = otrans.Obtiene(ls_sql)
                If dt.Rows(0).Item("numero").ToString.Length = 7 Then
                    ls_sql = dt.Rows(0).Item("numero").ToString.Substring(3, 4) + 1
                    Me.txt_codigo.Text = dt.Rows(0).Item("numero").ToString.Substring(0, 3)
                ElseIf dt.Rows(0).Item("numero").ToString.Length = 10 Then
                    ls_sql = dt.Rows(0).Item("numero").ToString.Substring(6, 4) + 1
                    Me.txt_codigo.Text = dt.Rows(0).Item("numero").ToString.Substring(0, 6)
                Else
                    ls_sql = dt.Rows(0).Item("numero") + 1
                    Me.txt_codigo.Text = Me.cmb_categoria.Text.ToString.Substring(0, 3).ToUpper
                End If


                Me.txt_codigo.Text &= ls_sql.ToString.PadLeft(4, "0")

            End If

            ls_sql = "call pa_ins_um_act_producto ('" & Me.txt_codigo.Text & "','" & _
                    Me.txt_descripcion.Text & "'," & Me.cmb_tipos.SelectedValue.ToString & "," & _
                    Me.cmb_categoria.SelectedValue.ToString & ",'" & _
                    Me.txt_serie.Text & "','" & _
                    Me.txt_imei.Text & "'," & _
                    Me.txt_minimo.Text & ","

            If Me.cmb_marca.Text.Trim.Length > 0 Then
                ls_sql &= Me.cmb_modelo.SelectedValue.ToString & ",'"
            Else
                ls_sql &= "null,'"
            End If

            ls_sql = ls_sql & gs_usuario & "'," & txtPrecio.Text & ")"

            otrans.Ingresa(ls_sql)
            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                dt = otrans.Obtiene("SELECT @@IDENTITY AS NewID")

                If insumos Then
                    Actualizar_modelos_relacionados(dt.Rows(0).Item("newid").ToString)
                Else
                    Actualizar_software(dt.Rows(0).Item("newid").ToString)
                    Actualizar_Caracteristicas(dt.Rows(0).Item("newid").ToString)
                    ''todo lo que no es insumo debe empezar con una unidad para ya no hacer ingreso
                    ''(c)140809
                    ''todos debe estar asignados al usuario
                    ls_sql = "call pa_upd_um_act_producto_existencia (" & dt.Rows(0).Item("newid").ToString & ",1)"
                    otrans.Actualiza(ls_sql)
                End If


                MessageBox.Show("Informacion Ingresada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.btn_guardar.Text = "Actualizar"
        End Try

    End Sub

    Private Sub Actualizar_modelos_relacionados(ByVal cod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_del_um_act_producto_modelo (" & cod_producto.ToString & ")"
            otrans.Elimina(ls_sql)

            For Each dr In ds_insumos.Tables("modelos_aplicados").Rows
                ls_sql = "call pa_ins_um_act_producto_modelo (" & cod_producto.ToString & "," & _
                         dr.Item("marca_modelo").ToString & ")"

                otrans.Ingresa(ls_sql)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Actualizar_software(ByVal cod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_del_um_act_producto_software (" & cod_producto.ToString & ")"
            otrans.Elimina(ls_sql)

            For Each dr In ds_insumos.Tables("software_equipo").Rows
                ls_sql = "call pa_ins_um_act_producto_software (" & cod_producto.ToString & "," & _
                         dr.Item("cod_software").ToString & ",'" & dr.Item("licencia").ToString & "')"

                otrans.Ingresa(ls_sql)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Actualizar_Caracteristicas(ByVal cod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_del_um_act_producto_caracteristica (" & cod_producto.ToString & ")"
            otrans.Elimina(ls_sql)

            For Each dr In ds_insumos.Tables("caracteristicas_equipo").Rows
                ls_sql = "call pa_ins_um_act_producto_caracteristica (" & cod_producto.ToString & "," & _
                         dr.Item("cod_caracteristica").ToString & ",'" & dr.Item("descripcion").ToString & "')"
                otrans.Ingresa(ls_sql)
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Modificar_Informacion()
        Dim ls_sql As String

        Dim dt As New DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ls_sql = "call pa_upd_um_act_producto (" & Me.lbl_codigo.Text & ",'" & Me.txt_codigo.Text & "','" & _
                    Me.txt_descripcion.Text & "'," & Me.cmb_tipos.SelectedValue.ToString & "," & _
                    Me.cmb_categoria.SelectedValue.ToString & ",'" & _
                    Me.txt_serie.Text & "','" & _
                    Me.txt_imei.Text & "'," & _
                    Me.txt_minimo.Text & ","

            If Me.cmb_marca.Text.Trim.Length > 0 Then
                ls_sql &= Me.cmb_modelo.SelectedValue.ToString & ",'"
            Else
                ls_sql &= "null,'"
            End If

            ls_sql &= gs_usuario & "'," & txtPrecio.Text & ")"

            otrans.Actualiza(ls_sql)
            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                If Not insumos Then
                    Actualizar_software(Me.lbl_codigo.Text)
                    Actualizar_Caracteristicas(Me.lbl_codigo.Text)
                Else
                    Actualizar_modelos_relacionados(Me.lbl_codigo.Text)
                End If
                MessageBox.Show("Informacion Ingresada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Llenar_Grid()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim clsgen As New ClasesGenerales.General

        Try
            ds_insumos.Tables.Remove("listado_activos")
        Catch ex As Exception
        End Try

        ls_sql = "call pa_sel_um_act_producto (null)"
        Try
            otrans.open()

            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "listado_activos"
            ds_insumos.Tables.Add(dt.Copy)

            If insumos Then
                ds_insumos.Tables("listado_activos").DefaultView.RowFilter = "cod_categoria = 1"
            Else
                ds_insumos.Tables("listado_activos").DefaultView.RowFilter = "cod_categoria <> 1"
            End If

            Me.dgv_listado.DataSource = ds_insumos.Tables("listado_activos").DefaultView

            clsgen.Alinear_GridView(dt, Me.dgv_listado, ",categoria,tipo,codigo,descripcion,modelos_aplica,serie,marca,modelo,existencia,imei,usuario_actual,", "", "", "", True, True, 150, 0)


            'ls_sql = "call pa_sel_um_act_movimiento ()"
            'dt = otrans.Obtiene(ls_sql)
            'dt.TableName = "listado_movimientos"
            'ds_insumos.Tables.Add(dt.Copy)

            'Me.dgv_listado_movimientos.DataSource = ds_insumos.Tables("listado_movimientos")
            'clsgen.Alinear_GridView(dt, Me.dgv_listado_movimientos, ",cod_movimiento,tipo_movimiento,observaciones,usuario_solicito,fecha_movimiento,", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            clsgen = Nothing
        End Try
    End Sub

    Private Sub filtrar_marcas()
        Try
            ds_insumos.Tables("marca_modelo").DefaultView.RowFilter = "cod_marca = " & Me.cmb_marca.SelectedValue.ToString
        Catch ex As Exception
            ds_insumos.Tables("marca_modelo").DefaultView.RowFilter = "cod_marca = 0"

        End Try
    End Sub

    Private Sub llenar_registro(ByVal _pcod_producto As Short, ByVal _pdt As DataTable)
        Limpiar_Forma()

        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow

        dt = _pdt.Copy

        dt.DefaultView.RowFilter = "cod_producto = " & _pcod_producto

        Me.cmb_marca.Text = ""
        dr = dt.DefaultView(0).Row
        Me.txt_serie.Text = dr.Item("serie").ToString
        Me.txt_codigo.Text = dr.Item("codigo")
        Me.txt_descripcion.Text = dr.Item("descripcion").ToString
        Me.txt_imei.Text = dr.Item("imei").ToString
        Me.txt_existencia.Text = dr.Item("existencia")
        Me.txt_minimo.Text = dr.Item("minimo")
        Me.txtPrecio.Text = dr.Item("precio")

        Me.cmb_categoria.SelectedValue = dr.Item("cod_categoria")

        ds_insumos.Tables("tipos").DefaultView.RowFilter = "cod_categoria = " & Me.cmb_categoria.SelectedValue.ToString

        Me.cmb_marca.SelectedValue = dr.Item("cod_marca")
        filtrar_marcas()

        Me.cmb_tipos.SelectedValue = dr.Item("cod_tipo_producto")
        Me.cmb_modelo.SelectedValue = dr.Item("cod_marca_modelo")
        Me.ToolStripStatusLabel1.Text = "Usuario Grabo .: " & dr.Item("usuario_grabo") & " " & dr.Item("fecha_grabo")
        Me.ToolStripStatusLabel2.Text = "Usuario Modifico .: " & dr.Item("usuario_modifico") & " " & dr.Item("fecha_modifico")

        Try

            otrans.open()
            ls_sql = "call pa_sel_um_act_producto_modelo (" & _pcod_producto.ToString & ")"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows

                dr_aux = ds_insumos.Tables("modelos_aplicados").NewRow
                dr_aux.Item("marca_modelo") = dr.Item("cod_marca_modelo")
                ds_insumos.Tables("modelos_aplicados").Rows.Add(dr_aux)
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If insumos Then
            Mostrar_Unidades_Modelo()
        Else
            Mostrar_Caracteristicas(_pcod_producto)
            Mostrar_Software(_pcod_producto)
        End If
    End Sub

    Private Sub Mostrar_Unidades_Modelo()
        Dim dr As DataRow
        Try

            For Each dr In ds_insumos.Tables("modelos_aplicados").Rows

                ds_insumos.Tables("m_marca_modelo").DefaultView.RowFilter = "cod_marca_modelo = " & dr.Item("marca_modelo")
                If ds_insumos.Tables("m_marca_modelo").DefaultView.Count > 0 Then
                    dr.Item("unidades") = ds_insumos.Tables("m_marca_modelo").DefaultView(0).Item("unidades")
                End If

            Next
        Catch ex As Exception
        Finally
            ds_insumos.Tables("m_marca_modelo").DefaultView.RowFilter = ""

        End Try

    End Sub

    ''Debo Mostrar Las Caracteristicas
    Private Sub Mostrar_Caracteristicas(ByVal _pcod_producto As Integer)

        Dim ls_sql As String
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ds_insumos.Tables("caracteristicas_equipo").Rows.Clear()
            ls_sql = "call pa_sel_um_act_producto_caracteristica (" & _pcod_producto.ToString & ")"
            dt = otrans.Obtiene(ls_sql)


            For Each dr_aux In dt.Rows
                dr = ds_insumos.Tables("caracteristicas_equipo").NewRow
                dr.Item("cod_caracteristica") = dr_aux.Item("cod_caracteristica")
                dr.Item("descripcion") = dr_aux.Item("descripcion").ToString

                ds_insumos.Tables("caracteristicas_equipo").Rows.Add(dr)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Mostrar_Software(ByVal _pcod_producto As Integer)
        Dim ls_sql As String
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        otrans.open()

        Try
            ds_insumos.Tables("software_equipo").Rows.Clear()
            ls_sql = "call pa_sel_um_act_producto_software (" & _pcod_producto.ToString & ")"
            dt = otrans.Obtiene(ls_sql)


            For Each dr_aux In dt.Rows
                dr = ds_insumos.Tables("software_equipo").NewRow
                dr.Item("cod_software") = dr_aux.Item("cod_software")
                dr.Item("licencia") = dr_aux.Item("licencia").ToString

                ds_insumos.Tables("software_equipo").Rows.Add(dr)

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Limpiar_Forma()
        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_serie.Text = ""
        Me.btn_guardar.Text = "Guardar"
        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
        Me.txt_existencia.Text = 0
        Me.txt_minimo.Text = 0
        Me.txt_serie.Text = ""
        Me.txt_imei.Text = ""
        Me.txtPrecio.Text = 0
        Me.cmb_marca.SelectedValue = 0
        Me.cmb_tipos.SelectedValue = 0
        Me.cmb_categoria.SelectedValue = 0
        Me.cmb_modelo.SelectedValue = 0
        ds_insumos.Tables("modelos_aplicados").Rows.Clear()
        ds_insumos.Tables("software_equipo").Rows.Clear()
        ds_insumos.Tables("caracteristicas_equipo").Rows.Clear()


    End Sub

    Private Sub frm_mantenimiento_activos_insumos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Personalizar_Vista()
        crear_estructura()
        Llenar_Grid()
    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriasToolStripMenuItem.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_categoria"
        oform.Text = oform.Text & " Categorias"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub TiposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposToolStripMenuItem.Click
        Dim oform As New frm_mantenimiento_modelos
        oform.nombre_tabla = "act_tipo_producto"
        oform.nombre_maestro = "act_categoria"
        oform.Text = oform.Text & " Tipos de Productos"
        oform.cmb_tabla.Visible = True
        oform.Label3.Visible = True
        oform.Mostrar_Unidades = False
        oform.llenar_combo()
        oform.ShowDialog(Me)
        oform.Dispose()

    End Sub

    Private Sub MarcasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcasToolStripMenuItem.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_marca"
        oform.Text = oform.Text & " Marcas"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub ModelosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModelosToolStripMenuItem.Click
        Dim oform As New frm_mantenimiento_modelos
        oform.nombre_tabla = "act_marca_modelo"
        oform.nombre_maestro = "act_marca"
        oform.Text = oform.Text & " Marcas & Modelos"
        oform.cmb_tabla.Visible = True
        oform.Label3.Visible = True
        oform.llenar_combo()
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txtPrecio.Text.Length = 0 Then txtPrecio.Text = "0"
        If Me.btn_guardar.Text = "Guardar" Then
            Guardar_Informacion()
        Else
            Modificar_Informacion()
        End If
        Llenar_Grid()
    End Sub

    Private Sub cmb_marca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_marca.SelectedIndexChanged

    End Sub

    Private Sub cmb_marca_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_marca.SelectionChangeCommitted
        filtrar_marcas()
    End Sub



    Private Sub dgv_listado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listado.DoubleClick
        Dim nrow As Integer = Me.dgv_listado.CurrentCell.RowIndex

        Me.lbl_codigo.Text = Me.dgv_listado.Item("cod_producto", nrow).Value
        llenar_registro(Me.lbl_codigo.Text, ds_insumos.Tables("listado_activos"))

        Me.btn_guardar.Text = "Actualizar"
        Me.TabControl1.SelectedTab() = Me.TabPage1
    End Sub

    Private Sub btn_nuevos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevos.Click
        Me.Limpiar_Forma()
        Me.TabControl1.SelectedTab() = Me.TabPage1
    End Sub

    Private Sub SoftwareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoftwareToolStripMenuItem.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_software"
        oform.Text = oform.Text & " Software"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub CaracteristicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaracteristicasToolStripMenuItem.Click
        Dim oform As New frm_mantenimiento
        oform.nombre_tabla = "act_caracteristica"
        oform.Text = oform.Text & " Caracteristicas"
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub dgv_listado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listado.CellContentClick

    End Sub

    Private Sub cmb_categoria_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_categoria.LostFocus

        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmb_categoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_categoria.SelectedIndexChanged

    End Sub

    Private Sub cmb_categoria_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_categoria.SelectionChangeCommitted
        ds_insumos.Tables("tipos").DefaultView.RowFilter = "cod_categoria = " & Me.cmb_categoria.SelectedValue.ToString
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim ls_filtro As String
            Dim ClsGen As New ClasesGenerales.General
            Try
                If Me.TextBox1.Text.Length = 0 Then
                    ls_filtro = ""
                Else
                    ls_filtro = ClsGen.Armar_Filtro(Me.cmb_opciones.Text, "", "", Me.TextBox1.Text, "", "", Me.cmb_operadores.Text, "", "", "", "")
                End If

                If insumos Then
                    ds_insumos.Tables("listado_activos").DefaultView.RowFilter = "cod_categoria = 1 and " & ls_filtro
                Else
                    ds_insumos.Tables("listado_activos").DefaultView.RowFilter = "cod_categoria <> 1 and " & ls_filtro
                End If

            Catch ex As Exception
            Finally
                ClsGen = Nothing
            End Try

        End If
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim rex As Regex = New Regex("^[0-9]*[.]{0,1}[0-9]{0,1}$")
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar.ToString() = "." Or e.KeyChar = CChar(ChrW(Keys.Back))) Then
            If (txtPrecio.Text.Trim() <> "") Then
                If (rex.IsMatch(txtPrecio.Text) = False And e.KeyChar <> CChar(ChrW(Keys.Back))) Then
                    e.Handled = True
                    ' MessageBox.Show("You are Not Allowed To Enter More then 2 Decimal!!")
                Else

                End If
            End If

        Else
            e.Handled = True
        End If
    End Sub


    Private Sub txtPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecio.TextChanged

    End Sub
End Class