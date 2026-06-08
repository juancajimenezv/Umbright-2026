Imports System.IO
Public Class frm_maq_etiquetas_materiales
    Inherits System.Windows.Forms.Form
    Dim Ods As DataSet
    Dim simagen1, simagen2 As String
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents btn_ayuda As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_total_costo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Dim ls_codigo As String
    Dim Pcorrelativo As Integer
    Dim Pproducto As String = ""




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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dg_detalle_pack_insumos As System.Windows.Forms.DataGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_maq_etiquetas_materiales))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dg_detalle_pack_insumos = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.btn_ayuda = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_total_costo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dg_detalle_pack_insumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "pack.png")
        Me.ImageList1.Images.SetKeyName(2, "pack2.png")
        Me.ImageList1.Images.SetKeyName(3, "3.png")
        Me.ImageList1.Images.SetKeyName(4, "grafica1.png")
        '
        'dg_detalle_pack_insumos
        '
        Me.dg_detalle_pack_insumos.CaptionVisible = False
        Me.dg_detalle_pack_insumos.DataMember = ""
        Me.dg_detalle_pack_insumos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_detalle_pack_insumos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_pack_insumos.Location = New System.Drawing.Point(9, 125)
        Me.dg_detalle_pack_insumos.Name = "dg_detalle_pack_insumos"
        Me.dg_detalle_pack_insumos.Size = New System.Drawing.Size(530, 135)
        Me.dg_detalle_pack_insumos.TabIndex = 38
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.txt_descripcion)
        Me.GroupBox1.Controls.Add(Me.txt_producto)
        Me.GroupBox1.Controls.Add(Me.btn_ayuda)
        Me.GroupBox1.Controls.Add(Me.dg_detalle_pack_insumos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_total_costo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 288)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Materiales Auxiliares"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.Location = New System.Drawing.Point(464, 21)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 53
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(112, 50)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(427, 22)
        Me.txt_descripcion.TabIndex = 50
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_producto.Location = New System.Drawing.Point(112, 23)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(88, 22)
        Me.txt_producto.TabIndex = 48
        '
        'btn_ayuda
        '
        Me.btn_ayuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ayuda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ayuda.ForeColor = System.Drawing.Color.White
        Me.btn_ayuda.Location = New System.Drawing.Point(206, 23)
        Me.btn_ayuda.Name = "btn_ayuda"
        Me.btn_ayuda.Size = New System.Drawing.Size(26, 22)
        Me.btn_ayuda.TabIndex = 49
        Me.btn_ayuda.Text = "..."
        Me.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ayuda.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Producto"
        '
        'txt_total_costo
        '
        Me.txt_total_costo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_costo.Location = New System.Drawing.Point(419, 97)
        Me.txt_total_costo.Name = "txt_total_costo"
        Me.txt_total_costo.ReadOnly = True
        Me.txt_total_costo.Size = New System.Drawing.Size(120, 22)
        Me.txt_total_costo.TabIndex = 47
        Me.txt_total_costo.TabStop = False
        Me.txt_total_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(336, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Total Costo:"
        '
        'frm_maq_etiquetas_materiales
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(619, 312)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Name = "frm_maq_etiquetas_materiales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Maquilas .::"
        CType(Me.dg_detalle_pack_insumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Packs_Activos()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim clsgen As New ClasesGenerales.General

        Try
            Ods = New DataSet
            Otrans.open()

            If Ods.Tables.Contains("packs") Then Ods.Tables.Remove("packs")
            If Ods.Tables.Contains("detalle_packs") Then Ods.Tables.Remove("detalle_packs")
            If Ods.Tables.Contains("detalle_onbase_packs") Then Ods.Tables.Remove("detalle_onbase_packs")
            If Ods.Tables.Contains("mpacks_insumos") Then Ods.Tables.Remove("mpacks_insumos")
            If Ods.Tables.Contains("mdetalle_packs_insumos") Then Ods.Tables.Remove("mdetalle_packs_insumos")

            ls_sql = "pa_var_um_ProdReceta '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "packs"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "pa_var_um_ProdReceta_detalle '" & gs_empresa & "',0"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "detalle_packs"
            Ods.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally

        End Try

        'Informacion de detalle packs
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            myOtrans.open()

            ls_sql = "pa_sel_um_maq_materiales"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "mpacks_insumos"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "CALL pa_sel_um_sg_usuario_busqueda('" & gs_usuario & "')"
            dt = myOtrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            clsgen = Nothing
        End Try


    End Sub
    Private Sub Crear_Estructura_Insumos()

        Dim dt As New DataTable("insumos_pack")

        dt.Columns.Add(New DataColumn("cod_insumo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Especificaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("costo", GetType(Decimal)))

        Ods.Tables.Add(dt.Copy)
        Me.dg_detalle_pack_insumos.DataSource = Ods.Tables("insumos_pack")
        combo_datagrid_insumos()

    End Sub

    Private Sub combo_datagrid_insumos()

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "insumos_pack"

        Dim dt As DataTable = Ods.Tables("insumos_pack")
        Dim ComboTextCol As New ClasesGenerales.DataGridComboBoxColumn

        ComboTextCol.MappingName = "cod_insumo"
        ComboTextCol.HeaderText = "Tipo "
        ComboTextCol.Width = 100
        ComboTextCol.ColumnComboBox.DataSource = Ods.Tables("mpacks_insumos").DefaultView
        ComboTextCol.ColumnComboBox.DisplayMember = "descripcion"
        ComboTextCol.ColumnComboBox.ValueMember = "cod_insumo"
        ComboTextCol.ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComboTextCol.ColumnComboBox.ForeColor = System.Drawing.Color.DarkRed
        ComboTextCol.ColumnComboBox.BackColor = System.Drawing.SystemColors.ControlLight

        tableStyle.PreferredRowHeight = ComboTextCol.ColumnComboBox.Height + 2
        tableStyle.RowHeaderWidth = 5
        tableStyle.GridColumnStyles.Add(ComboTextCol)

        Dim TextCol As New DataGridTextBoxColumn
        TextCol.MappingName = dt.Columns(1).ColumnName
        TextCol.HeaderText = "Especificaciones"
        TextCol.Width = 180
        tableStyle.GridColumnStyles.Add(TextCol)

        Dim TextCol2 As New DataGridTextBoxColumn
        TextCol2.MappingName = dt.Columns(2).ColumnName
        TextCol2.HeaderText = "costo"
        TextCol2.Format = "N4"
        TextCol2.Width = 110
        TextCol2.Alignment = HorizontalAlignment.Right
        tableStyle.GridColumnStyles.Add(TextCol2)

        Me.dg_detalle_pack_insumos.TableStyles.Clear()
        Me.dg_detalle_pack_insumos.TableStyles.Add(tableStyle)

    End Sub

    'Muestro todas las Op pendientes
    Private Sub buscarProducto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim Otrans_ As New Transaccional.Conexion("SCM")
        Dim dt, dt2 As DataTable

        Try
            otrans.open()
            Otrans_.open()
            dt = otrans.Obtiene("pa_var_um_producto '" & gs_empresa & "','" & Me.txt_producto.Text & "'")

            dt2 = Otrans_.Obtiene("pa_sel_um_maq_materiales '" & gs_empresa & "','" & Me.txt_producto.Text & "'")


            dt2.TableName = "mdetalle_packs_insumos"

            If Ods.Tables.Contains("insumos_pack") Then
                Ods.Tables("insumos_pack").Clear()
            End If


            If Ods.Tables.Contains("mdetalle_packs_insumos") Then
                Ods.Tables.Remove("mdetalle_packs_insumos")
            End If

            Ods.Tables.Add(dt2.Copy)

            Me.dg_detalle_pack_insumos.DataSource = Ods.Tables("insumos_pack")
            Me.dg_detalle_pack_insumos.Refresh()

            Dim dr As DataRow

            For Each drv As DataRowView In Ods.Tables("mdetalle_packs_insumos").DefaultView
                dr = Ods.Tables("insumos_pack").NewRow
                dr.Item("cod_insumo") = drv.Item("cod_insumo")
                dr.Item("Especificaciones") = drv.Item("observaciones")
                dr.Item("costo") = drv.Item("costo")
                Ods.Tables("insumos_pack").Rows.Add(dr)
            Next


            '''

            If dt.Rows.Count > 0 Then
                Me.txt_descripcion.Text = dt.Rows(0)("glosa")

            End If

            If dt2.Rows.Count > 0 Then
                Pcorrelativo = dt2.Rows(0)("correlativo")
                Pproducto = dt.Rows(0)("producto")
            End If

            If dt2.Rows.Count > 0 Then
                Me.btn_guardar.Text = "Actualizar"

            Else
                Me.btn_guardar.Text = "Guardar"
            End If
            Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
            txt_total_costo.Text = Format(suma, "##,###,##0.0000")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Otrans_.close()
            Otrans_ = Nothing

        End Try
    End Sub
    Private Sub frm_maq_etiquetas_materiales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Packs_Activos()
        Crear_Estructura_Insumos()
    End Sub

    Sub InicializarBarra(ByRef NombreBarraRelleno As Panel, ByVal PosicionBarra As String)
        ' Valores de PosicionBarra
        ' H = Horizontal; V(Vertical)
        If PosicionBarra.ToUpper = "H" Then
            NombreBarraRelleno.Width = 0
        ElseIf PosicionBarra = "V" Then
            NombreBarraRelleno.Height = 0
        End If
    End Sub

    Sub ActualizarBarra(ByRef NombreBarraRelleno As Panel, ByRef NombreBarraBase As Panel, _
             ByVal PuntoInicio As String, ByVal Valor As Integer)
        ' Valores de PuntoInicio
        ' R(Right) = de derecha a izquierda ; L(Left) = de izquierda a derecha ; 
        ' T(Top) = de arriba a abajo ; B(Bottom) = de abajo a arriba

        'variable que sirve para guardar el valor de la unidad en la barra de progreso
        Dim Unidad As Decimal

        If PuntoInicio.ToUpper = "R" Or PuntoInicio.ToUpper = "L" Then
            'guardo el valor de la unidad de la barra de relleno
            Unidad = NombreBarraBase.Width / 100
        Else
            If PuntoInicio.ToUpper = "T" Or PuntoInicio.ToUpper = "B" Then
                'guardo el valor de la unidad de la barra de relleno
                Unidad = NombreBarraBase.Height / 100
            End If
        End If
        Select Case PuntoInicio
            Case "R" 'de derecha a izquierda
                NombreBarraRelleno.Left = NombreBarraBase.Width - (Unidad * Valor)
                NombreBarraRelleno.Width = Unidad * Valor
            Case "L" 'de izquierda a derecha
                NombreBarraRelleno.Width() = NombreBarraRelleno.Left + (Unidad * Valor)
            Case "T" 'de arriba a abajo
                NombreBarraRelleno.Height() = NombreBarraRelleno.Top + (Unidad * Valor)
            Case "B" 'de abajo a arriba
                NombreBarraRelleno.Top = NombreBarraBase.Height - (Unidad * Valor)
                NombreBarraRelleno.Height() = Unidad * Valor
            Case Else
                MessageBox.Show("El valor del parámetro PuntoInicio no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub



    Private Sub dg_detalle_pack_insumos_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg_detalle_pack_insumos.CurrentCellChanged
        If dg_detalle_pack_insumos.CurrentRowIndex < 0 Then Exit Sub

        Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
        txt_total_costo.Text = Format(suma, "##,###,##0.0000")
    End Sub

    Private Sub tb_detalle_pack_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_total_costo.Text = String.Empty

        If dg_detalle_pack_insumos.CurrentRowIndex <= 0 Then Exit Sub

        Dim suma As Decimal = Val(Ods.Tables("insumos_pack").Compute("sum(costo)", "1=1").ToString)
        txt_total_costo.Text = Format(suma, "##,###,##0.0000")
    End Sub

    Private Sub btn_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ayuda.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "glosa,producto"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        frm_busqueda.lista_campos = "producto, glosa "
        frm_busqueda.cmb_2.Visible = False
        frm_busqueda.cmb_log1.Visible = False
        frm_busqueda.txt_buscar2.Visible = False
        frm_busqueda.cmb_valor2.Visible = False
        frm_busqueda.Btn_Aceptar.Visible = True
        frm_busqueda.txt_buscar1.Text = Me.txt_producto.Text
        frm_busqueda.txt_buscar1.Focus()
        'frm_busqueda.pConexion = "FlexLine"
        frm_busqueda.ShowDialog(Me)
        ls_codigo = frm_busqueda.resultado
        frm_busqueda.Dispose()
        frm_busqueda = Nothing
        Me.txt_producto.Text = ls_codigo

        buscarProducto()
    End Sub

    Private Sub txt_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.buscarProducto()

        End If
    End Sub

    Private Sub Actualiza_Materiales(ByVal _pcod_producto As Integer)

        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim especificaciones As String = ""


        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim Otrans_ As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()
            Otrans_.open()
            ls_sql = "pa_del_um_detalle_materiales '" & gs_empresa & "'," & Pcorrelativo & ",'" & _pcod_producto & "'"
            Otrans_.Elimina(ls_sql)
            If Otrans_.Codigo_error = 0 Then
                'Inserto Los Insumos utilizados en los packs
                For Each dr In Ods.Tables("insumos_pack").Rows
                    ls_sql = "pa_sel_um_maq_tipo_material " & dr.Item("cod_insumo")
                    dt = Otrans_.Obtiene(ls_sql)

                    If dr.Item("Especificaciones").ToString.Length > 0 Then
                        especificaciones = dr.Item("Especificaciones")
                    Else
                        especificaciones = "NULL"
                    End If
                    ls_sql = "pa_ins_um_maq_detalle_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & dt.Rows(0).Item("nemotecnico") & _
                            "'," & dr.Item("costo").ToString & ", " & especificaciones
                    Otrans_.Ingresa(ls_sql)
                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next
                ls_sql = "pa_upd_maq_detalle_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & Pproducto & "'," & Me.txt_total_costo.Text & ",'" & gs_usuario & "'"
                Otrans_.Actualiza(ls_sql)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Otrans.close()
            Otrans = Nothing
            Otrans_.close()
            Otrans_ = Nothing
        End Try
    End Sub



    Private Sub Guarda_Materiales(ByVal _pcod_producto As Integer)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim dt As DataTable
        Dim especificaciones As String = ""
        Dim Otrans As New Transaccional.Conexion("Flexline")
        Dim Otrans_ As New Transaccional.Conexion("SCM")
        Try
            Otrans.open()
            Otrans_.open()
            ls_sql = "pa_sel_um_maq_encabezado_materiales_numero '" & gs_empresa & "'"
            dt = Otrans_.Obtiene(ls_sql)

            ls_sql = "pa_ins_maq_encabezado_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & Pproducto & "'," & Me.txt_total_costo.Text & ",'" & gs_usuario & "'"
            Otrans_.Actualiza(ls_sql)
            'Inserto Los Insumos utilizados en los packs
            For Each dr In Ods.Tables("insumos_pack").Rows
                If dr.Item("Especificaciones").ToString.Length > 0 Then
                    especificaciones = dr.Item("Especificaciones")
                Else
                    especificaciones = "NULL"
                End If
                ls_sql = "pa_ins_um_maq_detalle_material '" & gs_empresa & "'," & Pcorrelativo & ",'" & dt.Rows(0).Item("nemotecnico") & _
                        "'," & dr.Item("costo").ToString & ", " & especificaciones
                Otrans_.Ingresa(ls_sql)
                If Otrans.Codigo_error > 0 Then
                    MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error al guardar el detalle del material.", "Error en  detalle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Otrans.close()
            Otrans = Nothing
            Otrans_.close()
            Otrans_ = Nothing
        End Try
    End Sub


    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If Me.btn_guardar.Text = "Guardar" Then
            Guarda_Materiales(Trim(Me.txt_producto.Text))
        Else
            Actualiza_Materiales(Trim(Me.txt_producto.Text))
        End If
    End Sub

    Private Sub txt_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_producto.TextChanged

    End Sub

    Private Sub txt_total_costo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_costo.TextChanged

    End Sub
End Class
