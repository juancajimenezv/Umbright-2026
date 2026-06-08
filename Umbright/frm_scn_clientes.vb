Public Class frm_scn_clientes
    Inherits System.Windows.Forms.Form
    Dim ds_clientes As DataSet

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
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_tienda As System.Windows.Forms.ComboBox
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents dg_clientes_casa_matriz As System.Windows.Forms.DataGrid
    Friend WithEvents lbl_marcar_todos As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_tipo_actualizacion As System.Windows.Forms.ComboBox
    Friend WithEvents dg_clientes_trasladar As System.Windows.Forms.DataGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents clb_tienda As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_scn_clientes))
        Me.cmb_tienda = New System.Windows.Forms.ComboBox
        Me.dg_clientes_casa_matriz = New System.Windows.Forms.DataGrid
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.dg_clientes_trasladar = New System.Windows.Forms.DataGrid
        Me.btn_generar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_marcar_todos = New System.Windows.Forms.Label
        Me.cmb_tipo_actualizacion = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.clb_tienda = New System.Windows.Forms.CheckedListBox
        CType(Me.dg_clientes_casa_matriz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_clientes_trasladar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_tienda
        '
        Me.cmb_tienda.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tienda.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tienda.Location = New System.Drawing.Point(80, 16)
        Me.cmb_tienda.Name = "cmb_tienda"
        Me.cmb_tienda.Size = New System.Drawing.Size(272, 21)
        Me.cmb_tienda.TabIndex = 0
        '
        'dg_clientes_casa_matriz
        '
        Me.dg_clientes_casa_matriz.CaptionVisible = False
        Me.dg_clientes_casa_matriz.DataMember = ""
        Me.dg_clientes_casa_matriz.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_clientes_casa_matriz.Location = New System.Drawing.Point(8, 112)
        Me.dg_clientes_casa_matriz.Name = "dg_clientes_casa_matriz"
        Me.dg_clientes_casa_matriz.Size = New System.Drawing.Size(840, 256)
        Me.dg_clientes_casa_matriz.TabIndex = 1
        '
        'txt_cliente
        '
        Me.txt_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cliente.Location = New System.Drawing.Point(80, 40)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.Size = New System.Drawing.Size(104, 20)
        Me.txt_cliente.TabIndex = 2
        Me.txt_cliente.Text = ""
        '
        'dg_clientes_trasladar
        '
        Me.dg_clientes_trasladar.CaptionVisible = False
        Me.dg_clientes_trasladar.DataMember = ""
        Me.dg_clientes_trasladar.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_clientes_trasladar.Location = New System.Drawing.Point(8, 384)
        Me.dg_clientes_trasladar.Name = "dg_clientes_trasladar"
        Me.dg_clientes_trasladar.Size = New System.Drawing.Size(840, 120)
        Me.dg_clientes_trasladar.TabIndex = 3
        '
        'btn_generar
        '
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 1
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(376, 9)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 56)
        Me.btn_generar.TabIndex = 4
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_generar)
        Me.GroupBox1.Controls.Add(Me.txt_cliente)
        Me.GroupBox1.Controls.Add(Me.cmb_tienda)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_tipo_actualizacion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(464, 88)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tienda"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Cliente"
        '
        'lbl_marcar_todos
        '
        Me.lbl_marcar_todos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_marcar_todos.Location = New System.Drawing.Point(8, 90)
        Me.lbl_marcar_todos.Name = "lbl_marcar_todos"
        Me.lbl_marcar_todos.Size = New System.Drawing.Size(160, 16)
        Me.lbl_marcar_todos.TabIndex = 6
        Me.lbl_marcar_todos.Text = "Marcar/Desmarcar Todos"
        '
        'cmb_tipo_actualizacion
        '
        Me.cmb_tipo_actualizacion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tipo_actualizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_actualizacion.DropDownWidth = 150
        Me.cmb_tipo_actualizacion.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tipo_actualizacion.Items.AddRange(New Object() {"Completa", "Solo Envio", "Solo Recepcion"})
        Me.cmb_tipo_actualizacion.Location = New System.Drawing.Point(80, 63)
        Me.cmb_tipo_actualizacion.Name = "cmb_tipo_actualizacion"
        Me.cmb_tipo_actualizacion.Size = New System.Drawing.Size(272, 21)
        Me.cmb_tipo_actualizacion.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tipo"
        '
        'btn_actualizar
        '
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_actualizar.ImageIndex = 0
        Me.btn_actualizar.ImageList = Me.ImageList1
        Me.btn_actualizar.Location = New System.Drawing.Point(288, 14)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(75, 56)
        Me.btn_actualizar.TabIndex = 4
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.clb_tienda)
        Me.GroupBox2.Controls.Add(Me.btn_actualizar)
        Me.GroupBox2.Location = New System.Drawing.Point(480, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 96)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Actualizacion"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 11)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Clientes Actualizados"
        '
        'clb_tienda
        '
        Me.clb_tienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clb_tienda.CheckOnClick = True
        Me.clb_tienda.Location = New System.Drawing.Point(6, 14)
        Me.clb_tienda.Name = "clb_tienda"
        Me.clb_tienda.Size = New System.Drawing.Size(274, 77)
        Me.clb_tienda.TabIndex = 10
        '
        'frm_scn_clientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(856, 509)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbl_marcar_todos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_clientes_trasladar)
        Me.Controls.Add(Me.dg_clientes_casa_matriz)
        Me.Name = "frm_scn_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Sincronizacion de Clientes .::"
        CType(Me.dg_clientes_casa_matriz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_clientes_trasladar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Crear_Estructura()
        Dim dt As New DataTable("clientes")
        dt.Columns.Add(New DataColumn("agregar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("codlegal", GetType(String)))
        dt.Columns.Add(New DataColumn("razonsocial", GetType(String)))
        dt.Columns.Add(New DataColumn("giro", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("dvigencia", GetType(String)))
        dt.Columns.Add(New DataColumn("limitecredito", GetType(Double)))
        dt.Columns.Add(New DataColumn("condpago", GetType(String)))
        dt.Columns.Add(New DataColumn("RetrasoCredito", GetType(Integer)))
        dt.Columns.Add(New DataColumn("comentario1", GetType(String)))
        dt.Columns.Add(New DataColumn("Ejecutivo", GetType(String)))
        dt.Columns.Add(New DataColumn("ListaPrecio", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))
        ds_clientes.Tables.Add(dt.Copy)

        dt.TableName = "clientes_sucursal"
        ds_clientes.Tables.Add(dt.Copy)
    End Sub

    Private Sub Inicializar()
        Dim ls_sql As String
        ds_clientes = New DataSet

        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")


        Try
            Otrans.open()
            ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_LOCALES','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "gen_locales"
            ds_clientes.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Crear_Estructura()
    End Sub

    Private Sub Llenar_Combos()

        Dim dt, dt2 As DataTable

        Try
            dt = ds_clientes.Tables("gen_locales").Copy
            Me.cmb_tienda.DataSource = dt
            Me.cmb_tienda.DisplayMember = "DESCRIPCION"
            Me.cmb_tienda.ValueMember = "TEXTO5"

            dt2 = dt.Copy
            Me.clb_tienda.DataSource = dt2
            Me.clb_tienda.DisplayMember = "DESCRIPCION"
            Me.clb_tienda.ValueMember = "CODIGO"

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub Llenar_Clientes()

        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            otrans.open()
            ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE',NULL,'" & Me.cmb_tienda.SelectedValue & "'"
            dt = otrans.Obtiene(ls_sql)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        Asociar_Clientes(dt)

    End Sub

    Private Sub Asociar_Clientes(ByVal dt As DataTable)
        Dim dr, dr_aux As DataRow

        Me.dg_clientes_casa_matriz.DataSource = Nothing

        If ds_clientes.Tables.Contains("clientes") Then
            ds_clientes.Tables("clientes").Clear()
        End If


        For Each dr In dt.Rows
            dr_aux = ds_clientes.Tables("clientes").NewRow

            dr_aux.Item("agregar") = False
            dr_aux.Item("ctacte") = dr.Item("ctacte")
            dr_aux.Item("codlegal") = dr.Item("codlegal")
            dr_aux.Item("razonsocial") = dr.Item("razonsocial")
            dr_aux.Item("giro") = dr.Item("giro")
            dr_aux.Item("tipo") = dr.Item("tipo")
            dr_aux.Item("dvigencia") = dr.Item("vigencia_cliente")
            dr_aux.Item("limitecredito") = dr.Item("limitecredito")
            dr_aux.Item("condpago") = dr.Item("condpago")
            dr_aux.Item("vigencia") = dr.Item("vigencia")
            dr_aux.Item("retrasocredito") = dr.Item("retrasocredito")
            dr_aux.Item("comentario1") = dr.Item("comentario1")
            dr_aux.Item("ejecutivo") = dr.Item("ejecutivo")
            dr_aux.Item("listaprecio") = dr.Item("listaprecio")
            dr_aux.Item("direccion") = dr.Item("direccion")

            ds_clientes.Tables("clientes").Rows.Add(dr_aux)
        Next

        Colorear_Grid()
    End Sub

    Private Sub Colorear_Grid()
        Dim clGenerales As New ClasesGenerales.General
        Me.dg_clientes_casa_matriz.DataSource = ds_clientes.Tables("clientes")
        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "clientes"

        For Each col As DataColumn In ds_clientes.Tables("clientes").Columns
            If col.ColumnName.ToLower <> "agregar" Then

                Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
                gridCol.MappingName = col.ColumnName

                Select Case col.ColumnName.ToLower
                    Case "cod_empresa", "serie", "fecha_impresion", "area", "picker"
                        gridCol.Width = 0
                    Case "fecha"
                        gridCol.Width = 70
                    Case "limitecredito"
                        gridCol.Width = clGenerales.tamaño_maximo_campo(ds_clientes.Tables("clientes"), " ", col.ColumnName, Me.dg_clientes_casa_matriz, 200, 0)
                        gridCol.Format = "n"
                        gridCol.Alignment = HorizontalAlignment.Right
                    Case Else
                        gridCol.Width = clGenerales.tamaño_maximo_campo(ds_clientes.Tables("clientes"), " ", col.ColumnName, Me.dg_clientes_casa_matriz, 150, 0)
                End Select
                gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
                gridCol.NullText = ""
                gridCol.ReadOnly = True
                AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor

                tableStyle.GridColumnStyles.Add(gridCol)
            Else
                Dim mydatacol As New ClasesGenerales.DataGridCheckBox(col.ColumnName, 60, _
                                        HorizontalAlignment.Center, _
                                        False, "Agregar", _
                                        String.Empty, False, True, _
                                        False, String.Empty)
                tableStyle.GridColumnStyles.Add(mydatacol)
            End If
        Next
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray
        tableStyle.RowHeaderWidth = 5
        tableStyle.AlternatingBackColor = Color.WhiteSmoke

        Me.dg_clientes_casa_matriz.TableStyles.Clear()
        Me.dg_clientes_casa_matriz.TableStyles.Add(tableStyle)

    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value As Integer

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value = data("agregar")


            If value Then
                e.RowColor = Color.Orange
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Actualizar_Completo(ByVal stienda As String, ByVal soriginal As String)

        Dim drv As DataRowView
        Dim dr As DataRow
        ds_clientes.Tables("clientes").DefaultView.RowFilter = "agregar = " & True

        Dim Sinc As New sincronizacion.Clientes(stienda)
        Try

            For Each drv In ds_clientes.Tables("clientes").DefaultView
                Sinc.Obtener_Cliente(gs_empresa, "'" & drv.Item("CtaCte").ToString & "'")

                If Sinc.dt.Rows.Count > 0 Then
                    dr = Sinc.dt.Rows(0)

                    'Recibe Informacion
                    If stienda = soriginal Then 'Solo se Recibe Informacion del Lugar Original del Cliente
                        If dr.Item("razonsocial") <> drv.Item("razonsocial") Or _
                                dr.Item("giro") <> drv.Item("giro") Or _
                                dr.Item("direccion") <> drv.Item("direccion") Then

                            If Me.cmb_tipo_actualizacion.Text = "Completa" Or _
                                Me.cmb_tipo_actualizacion.Text = "Solo Recepcion" Then

                                Sinc.Actualizar_Cliente(3, gs_empresa, drv, dr)

                                Agregar_Actualizaciones(drv)
                            End If

                        End If
                    End If

                    'Envia Informacion
                    If Double.Parse(dr.Item("limitecredito").ToString) <> Double.Parse(drv.Item("limitecredito").ToString) Or _
                            dr.Item("vigencia").ToString <> drv.Item("vigencia").ToString Or _
                            dr.Item("condpago").ToString <> drv.Item("condpago").ToString Or _
                            Double.Parse(dr.Item("RetrasoCredito").ToString) <> Double.Parse(drv.Item("RetrasoCredito").ToString) Or _
                            dr.Item("comentario1").ToString <> drv.Item("comentario1").ToString Or _
                            dr.Item("Ejecutivo").ToString <> drv.Item("Ejecutivo").ToString Or _
                            dr.Item("listaprecio").ToString <> drv.Item("listaprecio").ToString Then


                        If Me.cmb_tipo_actualizacion.Text = "Completa" Or _
                                     Me.cmb_tipo_actualizacion.Text = "Solo Envio" Then

                            Sinc.Actualizar_Cliente(2, gs_empresa, drv, dr)
                            Agregar_Actualizaciones(drv)
                        End If

                    End If

                Else
                    MessageBox.Show("El Cliente " & drv.Item("ctacte") & " " & drv.Item("razonsocial") & " No Existe En " & stienda, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Sinc.Cerrar()
            Sinc = Nothing
        End Try

        ds_clientes.Tables("clientes").DefaultView.RowFilter = ""
        If ds_clientes.Tables("clientes_sucursal").Rows.Count = 0 Then
            MessageBox.Show("No Existen Cambios para Trasladar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.dg_clientes_trasladar.DataSource = ds_clientes.Tables("clientes_sucursal")
        End If

    End Sub



    Private Sub Agregar_Actualizaciones(ByVal drv As DataRowView)
        Dim dr_aux As DataRow

        dr_aux = ds_clientes.Tables("clientes_sucursal").NewRow

        dr_aux.Item("agregar") = False
        dr_aux.Item("ctacte") = drv.Item("ctacte")
        dr_aux.Item("codlegal") = drv.Item("codlegal")
        dr_aux.Item("razonsocial") = drv.Item("razonsocial")
        dr_aux.Item("giro") = drv.Item("giro")
        dr_aux.Item("tipo") = drv.Item("tipo")
        'dr_aux.Item("dvigencia") = drv.Item("vigencia_cliente")
        dr_aux.Item("limitecredito") = drv.Item("limitecredito")
        dr_aux.Item("condpago") = drv.Item("condpago")
        dr_aux.Item("vigencia") = drv.Item("vigencia")
        dr_aux.Item("retrasocredito") = drv.Item("retrasocredito")
        dr_aux.Item("comentario1") = drv.Item("comentario1")
        dr_aux.Item("direccion") = drv.Item("direccion")

        ds_clientes.Tables("clientes_sucursal").Rows.Add(dr_aux)
    End Sub

    Private Sub frm_scn_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializar()
        Llenar_Combos()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Llenar_Clientes()
    End Sub

    Private Sub txt_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cliente.KeyPress
        Dim drv As DataRowView
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            ds_clientes.Tables("clientes").DefaultView.RowFilter = "ctacte = '" & Me.txt_cliente.Text & "'"
            If ds_clientes.Tables("clientes").DefaultView.Count = 1 Then
                drv = ds_clientes.Tables("clientes").DefaultView(0)
                drv.Item("agregar") = True
            End If
            ds_clientes.Tables("clientes").DefaultView.RowFilter = ""
            Me.txt_cliente.SelectAll()
        End If

    End Sub

    Private Sub lbl_marcar_todos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_marcar_todos.Click
        Dim dr As DataRow
        For Each dr In ds_clientes.Tables("clientes").Rows
            dr.Item("agregar") = Not dr.Item("agregar")
        Next
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        Dim ls_tienda As String

        ds_clientes.Tables("gen_locales").DefaultView.RowFilter = "TEXTO5 = '" & Me.cmb_tienda.SelectedValue & "'"

        ls_tienda = ds_clientes.Tables("gen_locales").DefaultView(0).Item("CODIGO")

        Dim icount As Integer

        If MessageBox.Show("Esta Seguro de Realizar Esta Actualizacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For icount = 0 To Me.clb_tienda.Items.Count() - 1
                If Me.clb_tienda.GetItemChecked(icount) Then
                    'Dar de alta usuario reporte
                    'MessageBox.Show(clb_tienda.Items(icount)("CODIGO"))
                    Actualizar_Completo(clb_tienda.Items(icount)("CODIGO"), ls_tienda)


                End If
            Next
        End If
    End Sub
End Class
