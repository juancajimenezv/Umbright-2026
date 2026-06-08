Imports AutomatizacionUmbright
Imports System.Text

Public Class frm_scm_ver_pedidos
    Inherits System.Windows.Forms.Form
    Public ds_informacion_productos As DataSet
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Dim pi_meses_adicionales As Short = 0
    Dim pfechaCalculo As DateTime
    Dim pnSemanas As Integer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents dgv_resumen As System.Windows.Forms.DataGridView
    Dim psColumnasOcultas As String
    Dim columnasOcultas As String = String.Empty
    Friend WithEvents rtxtComentarios As System.Windows.Forms.RichTextBox
    Dim nFrozen As Integer = 0
    Dim nCodigoPedido As Integer = 0
    Friend WithEvents chk_filtro As System.Windows.Forms.CheckBox
    Dim sComentarioOriginal As String


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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmb_pantalla As System.Windows.Forms.ComboBox
    Friend WithEvents btn_abrir As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_ver_pedidos))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmb_pantalla = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_abrir = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.dgv_detalle = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgv_resumen = New System.Windows.Forms.DataGridView
        Me.rtxtComentarios = New System.Windows.Forms.RichTextBox
        Me.chk_filtro = New System.Windows.Forms.CheckBox
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_pantalla
        '
        Me.cmb_pantalla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_pantalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_pantalla.Location = New System.Drawing.Point(817, 32)
        Me.cmb_pantalla.Name = "cmb_pantalla"
        Me.cmb_pantalla.Size = New System.Drawing.Size(174, 21)
        Me.cmb_pantalla.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(813, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pantalla"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 2
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(706, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 62)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Definir Pantalla"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        '
        'btn_abrir
        '
        Me.btn_abrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_abrir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_abrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_abrir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_abrir.ForeColor = System.Drawing.Color.White
        Me.btn_abrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_abrir.ImageIndex = 0
        Me.btn_abrir.ImageList = Me.ImageList1
        Me.btn_abrir.Location = New System.Drawing.Point(558, 2)
        Me.btn_abrir.Name = "btn_abrir"
        Me.btn_abrir.Size = New System.Drawing.Size(75, 62)
        Me.btn_abrir.TabIndex = 5
        Me.btn_abrir.Text = "Abrir"
        Me.btn_abrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_abrir.UseVisualStyleBackColor = False
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.White
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.ImageIndex = 1
        Me.btn_exportar.ImageList = Me.ImageList1
        Me.btn_exportar.Location = New System.Drawing.Point(632, 2)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(75, 62)
        Me.btn_exportar.TabIndex = 5
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Location = New System.Drawing.Point(795, 36)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 62)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Button2"
        Me.Button4.Visible = False
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.AllowUserToOrderColumns = True
        Me.dgv_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_detalle.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_detalle.Location = New System.Drawing.Point(0, 104)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(991, 434)
        Me.dgv_detalle.TabIndex = 9
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'dgv_resumen
        '
        Me.dgv_resumen.AllowUserToAddRows = False
        Me.dgv_resumen.AllowUserToDeleteRows = False
        Me.dgv_resumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_resumen.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_resumen.Location = New System.Drawing.Point(0, 544)
        Me.dgv_resumen.Name = "dgv_resumen"
        Me.dgv_resumen.ReadOnly = True
        Me.dgv_resumen.RowHeadersWidth = 25
        Me.dgv_resumen.Size = New System.Drawing.Size(991, 98)
        Me.dgv_resumen.TabIndex = 11
        '
        'rtxtComentarios
        '
        Me.rtxtComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtxtComentarios.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxtComentarios.Location = New System.Drawing.Point(0, 2)
        Me.rtxtComentarios.Name = "rtxtComentarios"
        Me.rtxtComentarios.ReadOnly = True
        Me.rtxtComentarios.Size = New System.Drawing.Size(474, 96)
        Me.rtxtComentarios.TabIndex = 13
        Me.rtxtComentarios.Text = ""
        '
        'chk_filtro
        '
        Me.chk_filtro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_filtro.Location = New System.Drawing.Point(480, 81)
        Me.chk_filtro.Name = "chk_filtro"
        Me.chk_filtro.Size = New System.Drawing.Size(161, 17)
        Me.chk_filtro.TabIndex = 14
        Me.chk_filtro.Text = "Ver Todos Los Productos"
        Me.chk_filtro.UseVisualStyleBackColor = True
        '
        'frm_scm_ver_pedidos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(992, 645)
        Me.Controls.Add(Me.chk_filtro)
        Me.Controls.Add(Me.rtxtComentarios)
        Me.Controls.Add(Me.dgv_detalle)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgv_resumen)
        Me.Controls.Add(Me.btn_abrir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.cmb_pantalla)
        Me.Controls.Add(Me.Button4)
        Me.Name = "frm_scm_ver_pedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. SCM - Consolidacion de Pedidos .::"
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oform As New frm_scm_definicion_pantalla
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
        Llenar_Maestros()
        Colorear_Detalle(String.Empty)
        Llenar_combos()
    End Sub

    Private Sub Llenar_Maestros()

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String

        Try
            otrans.open()
            ls_sql = "pa_sel_um_scm_definicion_pantalla"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "pantallas"

            If ds_informacion_productos.Tables.IndexOf("pantallas") >= 0 Then
                ds_informacion_productos.Tables.Remove("pantallas")
            End If
            ds_informacion_productos.Tables.Add(dt.Copy)


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Llenar_combos()
        Me.cmb_pantalla.DataSource = ds_informacion_productos.Tables("pantallas")
        Me.cmb_pantalla.ValueMember = "nombre_pantalla"
        Me.cmb_pantalla.DisplayMember = "nombre_pantalla"
    End Sub

    'Private Sub Colorear_Grid_Resumen()
    '    Dim clGenerales As New ClasesGenerales.General

    '    Dim tableStyle As New DataGridTableStyle
    '    tableStyle.MappingName = ds_informacion_productos.Tables("Resumen").TableName

    '    Dim dc As DataColumn

    '    Dim nombre_tipo As String
    '    Dim i As Short = -1
    '    Dim iaux As Short

    '    For Each col As DataColumn In ds_informacion_productos.Tables("Resumen").Columns
    '        i = i + 1
    '        If i > -1 Then
    '            Dim gridCol As ClasesGenerales.FormattableTextBoxColumn = New ClasesGenerales.FormattableTextBoxColumn
    '            gridCol.MappingName = col.ColumnName

    '            dc = ds_informacion_productos.Tables("Resumen").Columns(i)

    '            Try
    '                nombre_tipo = dc.DataType.ToString
    '            Catch ex As Exception
    '                nombre_tipo = ""
    '            End Try



    '            Select Case col.ColumnName.ToLower
    '                Case "producto", "glosa", "pareto", "estatus", "uxc", "fob", "full", "cajasxlayer", "cajasxpallet", "agregar"
    '                    gridCol.Width = 0
    '                Case Else
    '                    If nombre_tipo = "System.Decimal" Then
    '                        gridCol.Format = "n"
    '                        gridCol.Alignment = HorizontalAlignment.Right
    '                        gridCol.Width = 60
    '                    ElseIf nombre_tipo = "System.Int32" Then
    '                        gridCol.Format = "###,###,##0."
    '                        gridCol.Alignment = HorizontalAlignment.Right
    '                        gridCol.Width = 60
    '                    ElseIf nombre_tipo = "System.Int16" Then
    '                        gridCol.Format = "###,###,##0."
    '                        gridCol.Alignment = HorizontalAlignment.Right
    '                        gridCol.Width = 40
    '                    Else
    '                        gridCol.Width = clGenerales.tamaño_maximo_campo(ds_informacion_productos.Tables("Resumen"), " ", col.ColumnName, Me.dg_resumen, 200, 0)
    '                    End If
    '            End Select

    '            gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
    '            gridCol.NullText = ""
    '            'AddHandler gridCol.SetCellFormat, AddressOf Me.FormatGridRow
    '            For iaux = 1 To 11
    '                If col.ColumnName.ToLower.IndexOf(iaux.ToString.PadLeft(2, "0")) > 0 Then
    '                    gridCol.HeaderText = gridCol.HeaderText.Trim.Replace("+" & iaux.ToString.PadLeft(2, "0"), " " & Now.AddMonths(iaux + pi_meses_adicionales).ToString("MMMM"))
    '                End If
    '            Next

    '            If gridCol.HeaderText.ToLower = "ppto" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            ElseIf gridCol.HeaderText.ToLower = "transito" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            ElseIf gridCol.HeaderText.ToLower = "saldo" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            ElseIf gridCol.HeaderText.ToLower = "Cobertura" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            End If


    '            tableStyle.AlternatingBackColor = Color.WhiteSmoke
    '            tableStyle.GridColumnStyles.Add(gridCol)

    '        End If
    '    Next

    '    tableStyle.HeaderForeColor = Color.Black
    '    tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Arial", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
    '    tableStyle.GridLineColor = Color.LightGray
    '    tableStyle.AlternatingBackColor = Color.WhiteSmoke
    '    tableStyle.RowHeaderWidth = 5

    '    Me.dg_resumen.TableStyles.Clear()
    '    Me.dg_resumen.TableStyles.Add(tableStyle)

    'End Sub

    'Private Sub Colorear_Grid_Resumen_General()
    '    Dim clGenerales As New ClasesGenerales.General

    '    Dim tableStyle As New DataGridTableStyle
    '    tableStyle.MappingName = ds_informacion_productos.Tables("Resumen_General").TableName

    '    Dim dc As DataColumn

    '    Dim nombre_tipo As String
    '    Dim i As Short = -1
    '    Dim iaux As Short

    '    For Each col As DataColumn In ds_informacion_productos.Tables("Resumen_General").Columns
    '        i = i + 1
    '        If i > -1 Then
    '            Dim gridCol As ClasesGenerales.FormattableTextBoxColumn = New ClasesGenerales.FormattableTextBoxColumn
    '            gridCol.MappingName = col.ColumnName

    '            dc = ds_informacion_productos.Tables("Resumen").Columns(i)

    '            Try
    '                nombre_tipo = dc.DataType.ToString
    '            Catch ex As Exception
    '                nombre_tipo = ""
    '            End Try



    '            Select Case col.ColumnName.ToLower
    '                Case "proveedor", "procedencia", "producto", "glosa", "pareto", "estatus", "uxc", "fob", "full", "cajasxlayer", "cajasxpallet", "agregar"
    '                    gridCol.Width = 0
    '                Case Else
    '                    If nombre_tipo = "System.Decimal" Then
    '                        gridCol.Format = "n"
    '                        gridCol.Alignment = HorizontalAlignment.Right
    '                        gridCol.Width = 60
    '                    ElseIf nombre_tipo = "System.Int32" Then
    '                        gridCol.Format = "###,###,##0."
    '                        gridCol.Alignment = HorizontalAlignment.Right
    '                        gridCol.Width = 60
    '                    ElseIf nombre_tipo = "System.Int16" Then
    '                        gridCol.Format = "###,###,##0."
    '                        gridCol.Alignment = HorizontalAlignment.Right
    '                        gridCol.Width = 40
    '                    Else
    '                        gridCol.Width = clGenerales.tamaño_maximo_campo(ds_informacion_productos.Tables("Resumen_General"), " ", col.ColumnName, Me.dg_resumen_gral, 200, 0)
    '                    End If
    '            End Select

    '            gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
    '            gridCol.NullText = ""
    '            'AddHandler gridCol.SetCellFormat, AddressOf Me.FormatGridRow
    '            For iaux = 1 To 11
    '                If col.ColumnName.ToLower.IndexOf(iaux.ToString.PadLeft(2, "0")) > 0 Then
    '                    gridCol.HeaderText = gridCol.HeaderText.Trim.Replace("+" & iaux.ToString.PadLeft(2, "0"), " " & Now.AddMonths(iaux + pi_meses_adicionales).ToString("MMMM"))
    '                End If
    '            Next

    '            If gridCol.HeaderText.ToLower = "ppto" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            ElseIf gridCol.HeaderText.ToLower = "transito" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            ElseIf gridCol.HeaderText.ToLower = "saldo" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            ElseIf gridCol.HeaderText.ToLower = "Cobertura" Then
    '                gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '            End If


    '            tableStyle.AlternatingBackColor = Color.WhiteSmoke
    '            tableStyle.GridColumnStyles.Add(gridCol)

    '        End If
    '    Next

    '    tableStyle.HeaderForeColor = Color.Black
    '    tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Arial", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
    '    tableStyle.GridLineColor = Color.LightGray
    '    tableStyle.AlternatingBackColor = Color.WhiteSmoke
    '    tableStyle.RowHeaderWidth = 5

    '    Me.dg_resumen_gral.TableStyles.Clear()
    '    Me.dg_resumen_gral.TableStyles.Add(tableStyle)

    'End Sub


    'Private Sub Colorear_Grid()

    '    Dim scampos As String = ""

    '    Try
    '        ds_informacion_productos.Tables("pantallas").DefaultView.RowFilter = "nombre_pantalla = '" & Me.cmb_pantalla.SelectedValue & "'"
    '        scampos = ds_informacion_productos.Tables("pantallas").DefaultView(0).Item("campos")
    '    Catch ex As Exception
    '    Finally
    '        ds_informacion_productos.Tables("pantallas").DefaultView.RowFilter = ""
    '    End Try


    '    Try
    '        Dim clGenerales As New ClasesGenerales.General
    '        Dim tableStyle As New DataGridTableStyle
    '        tableStyle.MappingName = ds_informacion_productos.Tables("detalle_productos").TableName

    '        Dim dc As DataColumn

    '        Dim nombre_tipo As String
    '        Dim i As Short = -1
    '        Dim iaux As Short

    '        For Each col As DataColumn In ds_informacion_productos.Tables("detalle_productos").Columns
    '            i = i + 1


    '            If i > -1 Then
    '                If scampos.IndexOf(col.ColumnName) >= 0 Then

    '                    If col.ColumnName.ToLower = "agregar" Then

    '                        Dim gridcol As New ClasesGenerales.DataGridCheckBox(col.ColumnName, 60, _
    '                                           HorizontalAlignment.Center, _
    '                                           False, "Agregar", _
    '                                           String.Empty, False, True, _
    '                                           False, String.Empty)
    '                        'AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
    '                        tableStyle.GridColumnStyles.Add(gridcol)


    '                    Else
    '                        Dim gridCol As ClasesGenerales.FormattableTextBoxColumn = New ClasesGenerales.FormattableTextBoxColumn
    '                        gridCol.MappingName = col.ColumnName

    '                        dc = ds_informacion_productos.Tables("detalle_productos").Columns(i)

    '                        Try
    '                            nombre_tipo = dc.DataType.ToString
    '                        Catch ex As Exception
    '                            nombre_tipo = ""
    '                        End Try



    '                        Select Case col.ColumnName.ToLower
    '                            Case "sugerido_anterior", "proveedor"
    '                                gridCol.Width = 0
    '                            Case "fecha"
    '                                gridCol.Width = 70
    '                            Case "total"
    '                                gridCol.Format = "n"
    '                                gridCol.Alignment = HorizontalAlignment.Right
    '                            Case Else
    '                                If nombre_tipo = "System.Decimal" Then
    '                                    gridCol.Format = "n"
    '                                    gridCol.Alignment = HorizontalAlignment.Right
    '                                    gridCol.Width = 60
    '                                ElseIf nombre_tipo = "System.Int32" Then
    '                                    gridCol.Format = "###,###,##0."
    '                                    gridCol.Alignment = HorizontalAlignment.Right
    '                                    gridCol.Width = 60
    '                                ElseIf nombre_tipo = "System.Int16" Then
    '                                    gridCol.Format = "###,###,##0."
    '                                    gridCol.Alignment = HorizontalAlignment.Right
    '                                    gridCol.Width = 40
    '                                Else
    '                                    gridCol.Width = clGenerales.tamaño_maximo_campo(ds_informacion_productos.Tables("detalle_productos"), " ", col.ColumnName, Me.dg_detalle, 200, 0)
    '                                End If
    '                        End Select

    '                        'If i = 0 Then
    '                        '    gridcol.Width = 0
    '                        'End If
    '                        If col.ColumnName <> "pedido_sugerido" Then
    '                            gridCol.ReadOnly = True
    '                        End If
    '                        gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
    '                        gridCol.NullText = ""
    '                        AddHandler gridCol.SetCellFormat, AddressOf Me.FormatGridRow
    '                        AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor

    '                        For iaux = 1 To 11
    '                            If col.ColumnName.ToLower.IndexOf(iaux.ToString.PadLeft(2, "0")) > 0 Then
    '                                gridCol.HeaderText = gridCol.HeaderText.Trim.Replace("+" & iaux.ToString.PadLeft(2, "0"), " " & Now.AddMonths(iaux + pi_meses_adicionales).ToString("MMMM"))
    '                            End If
    '                        Next

    '                        If gridCol.HeaderText.ToLower = "ppto" Then
    '                            gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '                        ElseIf gridCol.HeaderText.ToLower = "transito" Then
    '                            gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '                        ElseIf gridCol.HeaderText.ToLower = "saldo" Then
    '                            gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '                        ElseIf gridCol.HeaderText.ToLower = "Cobertura" Then
    '                            gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
    '                        End If


    '                        tableStyle.GridColumnStyles.Add(gridCol)

    '                    End If
    '                End If
    '            End If ' > -1
    '        Next

    '        tableStyle.HeaderForeColor = Color.Black
    '        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Arial", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
    '        tableStyle.GridLineColor = Color.LightGray
    '        tableStyle.AlternatingBackColor = Color.WhiteSmoke
    '        tableStyle.RowHeaderWidth = 5

    '        Me.dg_detalle.TableStyles.Clear()
    '        Me.dg_detalle.TableStyles.Add(tableStyle)

    '    Catch ex As Exception
    '    End Try

    'End Sub

    Private Sub Colorear_Detalle(ByVal pscamposMostrar As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim ls_columnas_fijas As String
        Dim pGenerarTodasLasEmpresas As Boolean = True


        Try

            dt = ClsGen.ValoresDistinto(ds_informacion_productos.Tables("detalle_productos"), "empresa".Split(","))
            If dt.Rows.Count = 1 Then psColumnasOcultas += ",empresa"
            dt = ClsGen.ValoresDistinto(ds_informacion_productos.Tables("detalle_productos"), "proveedor".Split(","))
            If dt.Rows.Count = 1 Then psColumnasOcultas += ",proveedor"
            'If Not pGenerarTodasLasEmpresas Then psColumnasOcultas = ",empresa"
            psColumnasOcultas += ",marca,diario_cajas,estatus,sugerido_proveedor,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,calculos,"
            ls_columnas_fijas = ",existencia=50,"

            ls_columnas_fijas = String.Empty

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("detalle_productos"), Me.dgv_detalle, pscamposMostrar, psColumnasOcultas, "", "", ",max_cajas=cuanto,min_cajas=cuando,", ls_columnas_fijas, "", True, True, 250, 0)
            For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns
                dc.ReadOnly = True
                If dc.Name.ToLower.StartsWith("cober") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    dc.Width = 50
                ElseIf dc.Name.ToLower.StartsWith("suger") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    If pnSemanas > 0 Then
                        Try
                            If dc.Name.IndexOf("+") > 0 Then
                                If Val(dc.Name.Split("+")(1)) < pnSemanas Then
                                    dc.Width = 70
                                Else
                                    dc.Visible = False
                                End If
                            Else
                                dc.Width = 70
                            End If
                        Catch ex As Exception
                            dc.Width = 70
                        End Try

                    End If
                ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("trans") Or dc.Name.ToLower = "pedido" Then
                    dc.DefaultCellStyle.Format = "n0"
                ElseIf dc.Name.StartsWith("cd_") Or dc.Name.StartsWith("da_") Or dc.Name.StartsWith("cdx_") Or dc.Name.StartsWith("internaci") Or dc.Name.ToLower = "uxc" Or dc.Name.ToLower = "pareto" Then
                    dc.Width = 30
                    dc.DefaultCellStyle.Format = "n0"
                End If


                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    dc.ToolTipText = pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2)).ToString("dd-MMM-yyyy")
                    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " + _
                                 DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString
                ElseIf dc.Name.ToLower.StartsWith("trans") Then
                    dc.ToolTipText = pfechaCalculo.ToString("dd-MMM-yyyy")
                End If

                If dc.Name.ToLower.StartsWith("pedido") Or dc.Name.ToLower.StartsWith("agre") Then
                    dc.ReadOnly = False
                End If

                If dc.Name.ToLower.Equals("producto") Then
                    dc.Visible = True
                End If



            Next



        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub


    'Private Sub FormatGridRow(ByVal sender As Object, ByVal e As ClasesGenerales.DataGridFormatCellEventArgs)

    '    'Dim discontinued As Boolean = CBool(IIf(e.Column <> 0, Me.dg_detalle(e.Row, 0), e.CurrentCellValue)) 'TODO: For performance reasons this should be changed to nested IF statements
    '    Dim a As String
    '    Dim nombrecolumna As String
    '    Dim nrow As Integer

    '    Try
    '        nombrecolumna = e.ColumnName
    '        a = e.CurrentCellValue


    '        'If e.Column = 18 Or e.Column = 22 Or _
    '        '      e.Column = 26 Or e.Column = 30 Or _
    '        '      e.Column = 34 Or e.Column = 38 Or _
    '        '      e.Column = 42 Or e.Column = 46 Or _
    '        '      e.Column = 50 Or e.Column = 54 Or _
    '        '      e.Column = 58 Or e.Column = 62 Then
    '        If nombrecolumna.ToLower.StartsWith("cober") Then

    '            If a <= 1 Then
    '                e.BackBrush = Brushes.Yellow
    '                e.ForeBrush = Brushes.Red
    '            ElseIf a > 1 And a <= 3.1 Then
    '                e.BackBrush = Brushes.ForestGreen
    '                'e.ForeBrush = Brushes.Blue
    '            ElseIf a > 3.1 Then
    '                e.BackBrush = Brushes.Red
    '                e.ForeBrush = Brushes.White
    '            End If

    '            nrow = e.Row
    '            nrow = Me.dg_detalle.Item(nrow, 11)
    '        ElseIf e.Column <> -1 Then
    '            e.ForeBrush = Brushes.Black
    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)

    '    Try
    '        Dim data As DataRowView
    '        Dim value As Boolean
    '        'Dim value2 As String

    '        data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
    '        value = data("agregar")
    '        'value2 = data("cantidad")


    '        If value = True Then
    '            e.RowColor = Color.Blue
    '            'ElseIf value <> value2 Then
    '            '   e.RowColor = Color.Chocolate
    '        End If

    '    Catch ex As Exception
    '    End Try

    'End Sub

    'Private Sub Posicionar_Origen()
    '    Dim irow As Integer

    '    irow = Me.dg_detalle.CurrentCell.RowNumber
    '    Try
    '        Me.lbl_proveedor.Text = Me.dg_detalle.Item(irow, 0).ToString
    '        Me.lbl_ubicacion.Text = Me.dg_detalle.Item(irow, 1).ToString
    '        Me.txt_producto.Text = Me.dg_detalle.Item(irow, 3).ToString


    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub mostrarDerivados()
        Dim ocompras As New Compras.SCM(ds_informacion_productos)


        Try
            ocompras.Empresa = dgv_detalle.Item("empresa", Me.dgv_detalle.CurrentRow.Index).Value
            ocompras.mostrarDerivados(dgv_detalle.Item("producto", Me.dgv_detalle.CurrentRow.Index).Value, _
                                      dgv_detalle.Item("glosa", dgv_detalle.CurrentRow.Index).Value)
        Catch ex As Exception
        Finally
            ocompras = Nothing

        End Try
        'Dim oform As New frm_resultado
        'Dim clsGen As New ClasesGenerales.General

        'Try
        '    oform.Text = "Productos Derivados de " + dgv_detalle.Item("producto", Me.dgv_detalle.CurrentRow.Index).Value + "--" + dgv_detalle.Item("glosa", dgv_detalle.CurrentRow.Index).Value


        '    ds_informacion_productos.Tables("derivados").DefaultView.RowFilter = "producto_padre = '" & dgv_detalle.Item("producto", dgv_detalle.CurrentRow.Index).Value & "'"
        '    oform.dgv_resultado.DataSource = ds_informacion_productos.Tables("derivados")
        '    Dim lcolumnasmostrar As String = ",empresa,producto,glosa,unidades,existencia,"

        '    clsGen.Alinear_GridView(ds_informacion_productos.Tables("derivados"), oform.dgv_resultado, lcolumnasmostrar, "", "", "", ",existencia=existencia_unidades,", "", ",empresa,producto,glosa,unidades,", True, True, 250, 0)

        '    For Each dc As DataGridViewColumn In oform.dgv_resultado.Columns
        '        If dc.Name.ToLower = "unidades" Then
        '            dc.DefaultCellStyle.Format = "n4"
        '        End If
        '    Next
        '    With oform.dgv_resultado
        '        .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        '    End With
        '    oform.ShowDialog()
        '    oform.Dispose()
        '    oform = Nothing

        'Catch ex As Exception
        'Finally
        '    oform = Nothing
        'End Try

    End Sub

    Private Sub mostrarPresupuesto()
        Dim oCompras As New Compras.SCM(ds_informacion_productos)



        Try
            Dim nrow As Integer = Me.dgv_detalle.CurrentRow.Index


            'lssql = "pa_sel_um_ppt_presupuesto_general '" & Me.dgv_detalle.Item("empresa", nrow).Value & "',null,'" & _
            '                                        Me.dgv_detalle.Item("producto", nrow).Value & "'"
            oCompras.Empresa = Me.dgv_detalle.Item("empresa", nrow).Value
            oCompras.mostrarPresupuesto(Me.dgv_detalle.Item("producto", nrow).Value, True)


        Catch ex As Exception
        Finally
            oCompras = Nothing

        End Try

    End Sub

    Private Sub generarVentas()

        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim therow As DataGridViewRow

        Try


            therow = Me.dgv_detalle.CurrentRow
            oCompras.Empresa = dgv_detalle.Item("empresa", therow.Index).Value
            oCompras.mostrarVentas(dgv_detalle.Item("producto", therow.Index).Value, _
                                    dgv_detalle.Item("glosa", therow.Index).Value, True)


        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try


    End Sub

    Private Sub graficarSeleccion()

        Dim selectedCellCount As Integer = _
                            Me.dgv_detalle.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount > 0 Then



            Dim i, nrow As Integer
            Dim ncolumn As Integer = -1
            Dim coberturas, saldos As Double(,)

            Dim nombre_productos As String()
            Dim periodos As String()


            ReDim nombre_productos(selectedCellCount - 1)

            ReDim coberturas(7, 20)
            ReDim saldos(7, 20)


            ReDim periodos(20)



            If selectedCellCount > 6 Then
                MessageBox.Show("El Maximo Para Graficar es 6", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For i = 0 To selectedCellCount - 1

                nrow = dgv_detalle.SelectedCells(i).RowIndex

                nombre_productos(i) = dgv_detalle.Item("glosa", dgv_detalle.SelectedCells(i).RowIndex).Value.ToString
                saldos(7, 0) = Me.dgv_detalle.Item("pv_inv_maximo", nrow).Value.ToString
                coberturas(i, 0) = Me.dgv_detalle.Item("cobertura", nrow).Value.ToString
                periodos(0) = pfechaCalculo.ToString("dd-MMM-yyyy")
                saldos(i, 0) = Me.dgv_detalle.Item("Saldo", nrow).Value.ToString

                For icount As Integer = 1 To 20
                    coberturas(i, icount) = Me.dgv_detalle.Item("cobertura+" + icount.ToString.PadLeft(2, "0"), nrow).Value.ToString
                    saldos(i, icount) = Me.dgv_detalle.Item("saldo+" + icount.ToString.PadLeft(2, "0"), nrow).Value.ToString
                    periodos(icount) = Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).HeaderText.Replace("cobertura", "")
                    If icount Mod 4 = 0 Then
                        periodos(icount) = Me.dgv_detalle.Columns("cobertura+" + icount.ToString.PadLeft(2, "0")).ToolTipText
                    End If
                    coberturas(6, icount) = 0
                    saldos(7, icount) = Me.dgv_detalle.Item("pv_inv_maximo", nrow).Value.ToString
                Next


            Next i


            Dim ileadtime As Integer = Me.dgv_detalle.Item("pv_lead_time_total", nrow).Value.ToString

            periodos(ileadtime) = "**" & periodos(ileadtime)


            Dim ocompras As New Compras.SCM

            Try
                ocompras.mostrarGrafica(selectedCellCount, coberturas, saldos, nombre_productos, periodos, "Cobertura Semanas", "Existencias Cajas", 21)
            Catch ex As Exception
            Finally
                ocompras = Nothing
            End Try

        End If



    End Sub

    Private Sub agregarComentario()


        Dim scomentario As String = String.Empty
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Try
            Otrans.open()
            scomentario = InputBox("Ingrese Comentario de Pedido", "Comentarios")
            If scomentario.Length > 75 Or scomentario.Length = 0 Then
                MessageBox.Show("Problemas con el Comentario " & IIf(scomentario.Length = 0, " ", " Sobrepaso los 75 Caracteres"), "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Try
            End If

            lsSQL = "pa_ins_um_inv_pedido_comentarios " & nCodigoPedido & ",'" & gs_usuario & "','" & scomentario & "'"
            Otrans.Ingresa(lsSQL)

            If Otrans.Codigo_error > 0 Then
                MessageBox.Show("Problemas al Ingresar el Comentario", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Comentario Ingresado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            llenarComentarios()
        End Try



    End Sub

    Private Sub OcultarColumna(ByVal EsSemana As Boolean, ByVal nombre_campo As String)
        Dim icount As Integer
        'Dim saux As String = MenuItem.Text.Split("'")(1)
        'columnasOcultas += "," + MenuItem.Text.Split(" ")(1)
        If nombre_campo.Length = 0 Then Exit Sub

        Try

            If EsSemana Then
                For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                    If dc.HeaderText.ToLower.IndexOf(" " & nombre_campo.ToLower) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                        icount += 1
                        dc.Visible = False
                        '        columnasOcultas = columnasOcultas.Replace("," & saux, "")
                    End If
                    If icount = 4 Then
                        Exit For
                    End If
                Next
            Else
                Me.dgv_detalle.Columns(nombre_campo).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.dgv_detalle.Columns(nombre_campo).Visible = False


            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Me.ContextMenuStrip1.Items.Clear()
        Try
            Me.ContextMenuStrip1.Items.Add("Inmovilizar Paneles '" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Movilizar Paneles ", Nothing, AddressOf ToolStripMenuItem_Click)
            'If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.ToLower.StartsWith("glosa") Then
            Dim nrow As Integer = Me.dgv_detalle.CurrentRow.Index
            If Me.dgv_detalle.Item("glosa", nrow).Value.ToString.StartsWith("**") Then
                Me.ContextMenuStrip1.Items.Add("Ver Derivados ", Nothing, AddressOf ToolStripMenuItem_Click)
            End If
            'End If

            Me.ContextMenuStrip1.Items.Add("Ver Ventas", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items(Me.ContextMenuStrip1.Items.Count - 1).ForeColor = Color.Blue
            Me.ContextMenuStrip1.Items.Add("Ver Presupuesto Mensual", Nothing, AddressOf ToolStripMenuItem_Click)

            Me.ContextMenuStrip1.Items.Add("Graficar", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items(Me.ContextMenuStrip1.Items.Count - 1).ForeColor = Color.Brown

            If Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name.IndexOf("+") > 0 Then
                Me.ContextMenuStrip1.Items.Add("Ocultar Semana'" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText.Split(" ")(2) & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            End If
            Me.ContextMenuStrip1.Items.Add("Ocultar Columna '" & Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).HeaderText & "'", Nothing, AddressOf ToolStripMenuItem_Click)
            Me.ContextMenuStrip1.Items.Add("Agregar Comentario ", Nothing, AddressOf ToolStripMenuItem_Click)

            If columnasOcultas.Length > 0 Then
                For Each saux As String In columnasOcultas.Split(",")
                    If saux.Length > 0 Then
                        Me.ContextMenuStrip1.Items.Add("Mostrar Columna '" & saux & "'", Nothing, AddressOf ToolStripMenuItem_Click)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        Try
            If menuItem IsNot Nothing Then
                'Tell the user which menu item they just clicked.

                If menuItem.Text.ToLower.StartsWith("ocultar co") Then
                    columnasOcultas += "," + Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Name
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Visible = False
                ElseIf menuItem.Text.ToLower.StartsWith("ocultar sem") Then
                    Dim saux As String = menuItem.Text.Split("'")(1)
                    columnasOcultas += "," + menuItem.Text.Split(" ")(1)

                    OcultarColumna(True, saux)
                    'For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                    '    If dc.HeaderText.ToLower.IndexOf(" " & saux.ToLower) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                    '        icount += 1
                    '        dc.Visible = False
                    '        '        columnasOcultas = columnasOcultas.Replace("," & saux, "")
                    '    End If
                    '    If icount = 4 Then
                    '        Exit For
                    '    End If
                    'Next



                    '             ods.Tables("productos").DefaultView.RowFilter = filtro_actual
                ElseIf menuItem.Text.ToLower.StartsWith("inmovi") Then
                    Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Frozen = True
                    nFrozen = Me.dgv_detalle.CurrentCell.ColumnIndex

                ElseIf menuItem.Text.ToLower.StartsWith("mostrar") Then
                    Dim saux As String = menuItem.Text.Split("'")(1)
                    If saux.ToLower.StartsWith("semana") Then

                        For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                            If dc.HeaderText.LastIndexOf(menuItem.Text.Split("'")(2)) > 0 And dc.HeaderText.IndexOf("sugerido") = -1 Then
                                dc.Visible = True
                                columnasOcultas = columnasOcultas.Replace("," & "Semana'" & menuItem.Text.Split("'")(2) & "'", "")
                            End If
                        Next
                    Else


                        For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns

                            If dc.Name.ToLower = saux.ToLower Then
                                dc.Visible = True
                                columnasOcultas = columnasOcultas.Replace("," & saux, "")
                            End If
                        Next
                    End If

                ElseIf menuItem.Text.ToLower.StartsWith("ver d") Then
                    mostrarDerivados()
                ElseIf menuItem.Text.ToLower.StartsWith("ver v") Then
                    generarVentas()
                ElseIf menuItem.Text.ToLower.StartsWith("ver p") Then
                    mostrarPresupuesto()
                ElseIf menuItem.Text.ToLower.StartsWith("grafi") Then
                    graficarSeleccion()
                ElseIf menuItem.Text.ToLower.StartsWith("agregar com") Then
                    agregarComentario()
                Else

                    For iaux As Integer = 1 To nFrozen
                        Me.dgv_detalle.Columns(iaux).Frozen = False
                    Next
                    'Me.dgv_detalle.Columns(Me.dgv_detalle.CurrentCell.ColumnIndex).Frozen = False


                    'menuItem.Text.Replace("Filtrar ", " ")
                    'Dim nombre_supervisor As String = menuItem.Text.Replace("Filtrar ", "")
                    'MessageBox.Show("The " & nombre_supervisor & " item was just selected.")
                    '            ods.Tables("productos").DefaultView.RowFilter = filtro_actual & " and supervisor = '" & nombre_supervisor & "'"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarComentarios()

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim lsSQL As String

        Try
            Otrans.open()
            Me.rtxtComentarios.Text = sComentarioOriginal
            lsSQL = "pa_sel_um_inv_pedido_comentario " & nCodigoPedido
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                Me.rtxtComentarios.AppendText(dr.Item("fecha_grabo").ToString & " " & dr.Item("usuario_grabo").ToString & " " & dr.Item("comentario").ToString & vbCrLf)
            Next


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub frm_scm_ver_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds_informacion_productos = New DataSet
        Llenar_Maestros()
        Llenar_combos()
    End Sub

    Private Sub btn_Abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abrir.Click
        Me.dgv_detalle.DataSource = Nothing
        Me.dgv_detalle.Refresh()
        Me.Refresh()


        ds_informacion_productos = New DataSet

        Dim oform As New frm_scm_obtiene_informacion(ds_informacion_productos)
        oform.ShowDialog()

        pnSemanas = oform.pnSemanas
        pfechaCalculo = oform.pFechaCalculo
        psColumnasOcultas = oform.psColumnasOcultas
        sComentarioOriginal = "Fecha de Calculo: " & pfechaCalculo & "  Fecha Aprox. Ingreso "
        nCodigoPedido = oform.pnumeroPedido


        Try
            pi_meses_adicionales = ds_informacion_productos.Tables("detalle_productos").Rows(0)("pv_lead_time_total")
            sComentarioOriginal += pfechaCalculo.AddDays(7 * pi_meses_adicionales)
            sComentarioOriginal += " Sem " + DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * pi_meses_adicionales)).ToString
            pi_meses_adicionales = 0
        Catch ex As Exception

        End Try

        sComentarioOriginal += vbCrLf
        sComentarioOriginal += oform.psComentarios + vbCrLf


        oform = Nothing

        Llenar_Maestros()




        Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")

        'pi_meses_adicionales = IIf(ds_informacion_productos.Tables("scm_parametros_generales").Rows(0).Item("incluir_mes_actual_proyeccion") = True, 0, 1)
        If ds_informacion_productos.Tables("detalle_productos").Rows.Count > 0 Then
            Colorear_Detalle(String.Empty)
        Recargar_Resumen()
        llenarComentarios()

        columnasOcultas = psColumnasOcultas

        If columnasOcultas.Length > 0 Then
            For Each scolumna As String In columnasOcultas.Split(",")

                OcultarColumna(False, scolumna)
            Next
        End If
            Me.chk_filtro.Checked = True
        End If

        'Posicionar_Origen()
        'Colorear_Grid_Resumen()
        'Colorear_Grid_Resumen_General()

    End Sub

    Private Sub Recargar_Resumen()

        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Try
            oCompras.generarResumen()

        Catch ex As Exception
        Finally
            oCompras = Nothing
        End Try
        Me.dgv_resumen.DataSource = ds_informacion_productos.Tables("resumen")
        ds_informacion_productos.Tables("Resumen").DefaultView.RowFilter = ""
        Colorear_Resumen()


    End Sub

    Private Sub Colorear_Resumen()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String

        Try

            ls_columnas_ocultar = String.Empty
            'If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
            ls_columnas_ocultar += ",marca,fob,existencia,glosa,producto,pareto,uxc,agregar,diario_cajas,estatus,cd_cajas,cdx_cajas,da_cajas,sugerido_proveedor,min_cajas,max_cajas,tiene_compra,sugerido_anterior,pv_ciclo_compra,pv_margen_seguridad,full,cajasxpallet,cajasxlayer,calculos,"
            ls_columnas_fijas = String.Empty

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("Resumen"), Me.dgv_resumen, "", ls_columnas_ocultar, "", "", ",valor_sugerido=valor_pedido,", ls_columnas_fijas, ",proveedor,procedencia,pedido,valor_sugerido,peso,volumen,", True, True, 250, 0)
            For Each dc As DataGridViewColumn In Me.dgv_resumen.Columns
                dc.ReadOnly = True
                If dc.Name.ToLower.StartsWith("cober") Then
                    'dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    'dc.Width = 50
                    dc.Visible = False
                ElseIf dc.Name.ToLower.StartsWith("suger") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    If pnSemanas > 0 Then
                        Try
                            If dc.Name.IndexOf("+") > 0 Then
                                If Val(dc.Name.Split("+")(1)) < pnSemanas Then
                                    dc.Width = 70
                                Else
                                    dc.Visible = False
                                End If
                            Else
                                dc.Width = 70
                            End If
                        Catch ex As Exception
                            dc.Width = 70
                        End Try

                    End If


                ElseIf dc.Name.ToLower.StartsWith("teoric") Then
                    dc.Visible = False
                ElseIf dc.Name.IndexOf("+") > 0 Then
                    dc.Visible = False

                End If

                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " + _
                                 DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub
    'Private Sub cmb_pantalla_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_pantalla.SelectionChangeCommitted
    '    Colorear_Grid()
    'End Sub

    'Private Sub dg_detalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Posicionar_Origen()
    'End Sub

    Private Sub modificarPresupuestoProducto(ByVal sempresa As String, ByVal sproducto As String, ByVal dporcentaje As Double)

        For Each dr As DataRow In ds_informacion_productos.Tables("detalle_productos").Rows
            If dr.Item("empresa") = sempresa And dr.Item("producto") = sproducto Then


                dr.Item("ppto") = dr.Item("ppto") + (dr.Item("ppto") * (dporcentaje / 100))
                For icount As Integer = 1 To 52
                    dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) = dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) + (dr.Item("ppto+" & icount.ToString.PadLeft(2, "00")) * (dporcentaje / 100))
                Next
                Exit For
            End If

        Next
    End Sub

    Private Function transitoProductoSemana(ByVal psEmpresa As String, ByVal psProducto As String, ByVal psemana As Integer) As DataTable

        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2, dtfinal As DataTable
        Dim draux As DataRow
        Dim ls_sql, sencabezado As String
        sencabezado = String.Empty
        Dim lbmultiples As Boolean = False

        Try
            otrans.open()
            ls_sql = "pa_var_um_transito_productos_semana_producto '" & psEmpresa & "','" & psProducto & "'," & DatePart(DateInterval.WeekOfYear, Date.Parse(psemana)) & "," & Date.Parse(psemana).Year
            dt = otrans.Obtiene(ls_sql)
            For Each dr As DataRow In dt.Rows
                ls_sql = "pa_var_um_transito_productos_orden '" & psEmpresa & "','" & dr.Item("numero") & "'"
                '  If sencabezado.Length > 0 Then sencabezado += Chr(13)
                'sencabezado += "::No. Orden " & dr.Item("numero") & " -- Fecha " & dr.Item("fecha")
                dt2 = otrans.Obtiene(ls_sql)
                If dtfinal Is Nothing Then
                    dtfinal = dt2.Copy
                Else
                    lbmultiples = True
                    For Each draux2 As DataRow In dt2.Rows


                        draux = dtfinal.NewRow
                        For Each dc As DataColumn In dtfinal.Columns
                            draux.Item(dc.ColumnName) = draux2.Item(dc.ColumnName)
                        Next
                        dtfinal.Rows.Add(draux)
                    Next
                End If


            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return dtfinal

    End Function

    Private Sub AplicarProducto(ByVal psEmpresa As String, ByVal psProducto As String, ByVal pscolumnaCambio As String, ByVal ncantidad As Integer, ByVal clickAgregar As Boolean)
        Dim dr As DataRow
        Dim smes_actual As String
        Dim oCompras As New Compras.SCM(ds_informacion_productos)
        Dim dt As DataTable
        Dim ldporcentajeAjuste As Double = 0
        'Dim dsugerido() As Double
        'ReDim dsugerido(pnSemanas)


        Try
            Me.Cursor = Cursors.WaitCursor


            'dt = ds_informacion_productos.Tables("calculo_original").Copy
            'dt.TableName = "copia"
            For Each dr In ds_informacion_productos.Tables("detalle_productos").Rows
                If dr.Item("producto").ToString.Equals(psProducto) And dr.Item("empresa").ToString.Equals(psEmpresa) Then
                    ds_informacion_productos.Tables("calculo_original").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"


                    'For iaux As Integer = 0 To pnSemanas - 1
                    '    smes_actual = "sugerido"
                    '    If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
                    '    dsugerido(iaux) = dr.Item(smes_actual)
                    'Next
                    Dim lbagregar As Boolean = dr.Item("agregar")

                    Dim ldpedido As Double = IIf(ncantidad = -99, dr.Item("pedido"), ncantidad)
                    Dim itransito As Integer = 0
                    ldporcentajeAjuste = dr.Item("porcentaje_ajuste")
                    Dim ldLeadTime As Double = dr.Item("pv_lead_time_total")
                    For Each dc As DataColumn In ds_informacion_productos.Tables("detalle_productos").Columns
                        dr.Item(dc.ColumnName) = ds_informacion_productos.Tables("calculo_original").DefaultView(0)(dc.ColumnName)
                    Next

                    dr.Item("porcentaje_ajuste") = ldporcentajeAjuste

                    If pscolumnaCambio.Equals("porcentaje_ajuste") Then
                        modificarPresupuestoProducto(dr.Item("empresa"), dr.Item("producto"), dr.Item("porcentaje_ajuste"))
                    Else
                        If Not lbagregar Then
                            dr.Item("pedido") = 0
                        End If

                        Dim ileadtime As Integer = dr.Item("pv_lead_time_total")
                        dt = Me.transitoProductoSemana(dr.Item("empresa"), dr.Item("producto"), DatePart(DateInterval.WeekOfYear, pfechaCalculo.AddDays(ileadtime * 7)))
                        'pa_var_um_transito_productos_semana_producto()
                        Try
                            'If dt.Rows.Count > 0 Then
                            itransito = dt.Compute("cajas", "cajas>0")
                            'End If
                        Catch ex As Exception
                        End Try

                        smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                        dr.Item(smes_actual) = itransito 'dr.Item(smes_actual) + dr.Item("pedido")



                        dr.Item("agregar") = lbagregar



                        If dr.Item("Agregar").ToString.ToLower = "true" Then
                            dr.Item("Agregar") = "True"
                            dr.Item("pedido") = IIf(clickAgregar, dr.Item("pedido"), ldpedido)
                            'Dim ileadtime As Integer = dr.Item("pv_lead_time_total")
                            If dr.Item("pedido") = 0 Then
                                For iaux As Integer = 0 To pnSemanas - 1
                                    smes_actual = "sugerido"
                                    If iaux > 0 Then smes_actual += "+" + iaux.ToString.PadLeft(2, "0")
                                    If dr.Item(smes_actual) > 0 Then
                                        dr.Item("pedido") = dr.Item(smes_actual)
                                        Exit For

                                    End If
                                    'dr.Item(smes_actual) = dsugerido(iaux)
                                Next
                            End If

                            smes_actual = "transito+" & Integer.Parse(ileadtime).ToString.PadLeft(2, "0")
                            dr.Item(smes_actual) = dr.Item(smes_actual) + dr.Item("pedido")

                        End If

                        dr.Item("valor_sugerido") = dr.Item("pedido") * dr.Item("fob")
                        dr.Item("peso_total") = dr.Item("pedido") * dr.Item("peso")
                        dr.Item("volumen_total") = dr.Item("pedido") * dr.Item("pedido")

                    End If

                    Exit For

                End If
            Next

            oCompras.Generar_SaldosyCoberturasProducto(psProducto)
            If pscolumnaCambio.Equals("porcentaje_ajuste") Or pscolumnaCambio.Equals("pv_lead_time_total") Then
                For iaux As Integer = 0 To pnSemanas
                    If pscolumnaCambio.Equals("porcentaje_ajuste") Then
                        oCompras.Minimos_MaximosProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
                    End If
                    oCompras.generarPedidoSugeridoProducto(psEmpresa, psProducto, iaux, IIf(iaux = 0, True, False))
                Next
            End If

            Recargar_Resumen()
        Catch ex As Exception
        Finally
            oCompras = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub aplicarFiltro()
        Dim lsfiltro As New StringBuilder
        lsfiltro.Append(String.Empty)


        If Not chk_filtro.CheckState = CheckState.Checked Then
            lsfiltro.Append("tiene_compra = true")
        End If

        'Try
        '    If cmbProveedor.Visible = True Then
        '        If Not cmbProveedor.SelectedItem.StartsWith("-") Then
        '            If lsfiltro.ToString.Length > 0 Then lsfiltro.Append(" and ")
        '            lsfiltro.Append("proveedor = '" & cmbProveedor.SelectedItem & "'")
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try

        'Try
        '    If cmbOrigen.Visible = True Then
        '        If Not cmbOrigen.SelectedItem.StartsWith("-") Then
        '            If lsfiltro.ToString.Length > 0 Then lsfiltro.Append(" and ")
        '            lsfiltro.Append("procedencia = '" & cmbOrigen.SelectedItem & "'")
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try

        ds_informacion_productos.Tables("detalle_productos").DefaultView.RowFilter = lsfiltro.ToString



    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click

        Dim scampos As String = ""
        Dim Oaut As New Automatizar.exportar_excel
        Dim col As DataColumn

        Try
            ds_informacion_productos.Tables("pantallas").DefaultView.RowFilter = "nombre_pantalla = '" & Me.cmb_pantalla.SelectedValue & "'"
            scampos = ds_informacion_productos.Tables("pantallas").DefaultView(0).Item("campos")
        Catch ex As Exception
        End Try


        Oaut.ocultar_columnas = ","
        Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}, {4, 2}}

        Oaut.Nombre_Columnas = "" ',,,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"

        For Each col In ds_informacion_productos.Tables("detalle_productos").Columns
            If scampos.IndexOf(col.ColumnName & ",") >= 0 Then

                Dim gridCol As New ClasesGenerales.FormattableTextBoxColumn

                '            For iaux = 1 To 11
                '                  If col.ColumnName.ToLower.IndexOf(iaux.ToString.PadLeft(2, "0")) > 0 Then
                '          Oaut.Nombre_Columnas = Oaut.Nombre_Columnas & _
                '                         col.ColumnName.Trim.Replace("+" & iaux.ToString.PadLeft(2, "0"), " " & Now.AddMonths(iaux + pi_meses_adicionales).ToString("MMMM")) & ","
                'gridCol.HeaderText.Trim.Replace("+" & iaux.ToString.PadLeft(2, "0"), " " & Now.AddMonths(iaux + pi_meses_adicionales).ToString("MMMM")) & ","
                '                 End If
                '           Next

                If col.ColumnName.ToLower = "ppto" Then
                    '                Oaut.Nombre_Columnas = Oaut.Nombre_Columnas & _
                    '                         col.ColumnName.Trim & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM") & ","
                ElseIf col.ColumnName.ToLower = "transito" Then
                    '               Oaut.Nombre_Columnas = Oaut.Nombre_Columnas & _
                    '                           col.ColumnName.Trim & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM") & ","
                ElseIf col.ColumnName.ToLower = "saldo" Then
                    '             Oaut.Nombre_Columnas = Oaut.Nombre_Columnas & _
                    '                           col.ColumnName.Trim & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM") & ","
                ElseIf col.ColumnName.ToLower = "cobertura" Then
                    '           Oaut.Nombre_Columnas = Oaut.Nombre_Columnas & _
                    '                        col.ColumnName.Trim & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM") & ","
                End If
            Else
                Oaut.ocultar_columnas = Oaut.ocultar_columnas & col.ColumnName & ","
            End If
        Next
        Oaut.nAgregar_Filas = 2
        Oaut.DataTableToExcel(ds_informacion_productos.Tables("detalle_productos"))
        Oaut = Nothing
    End Sub

    Private Sub dgv_detalle_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_detalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)

                If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("sugerido") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightSalmon
                    End If
                End If
                If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("agregar") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value = True Then
                        Me.dgv_detalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                    End If

                End If
                If dgv_detalle.Columns(colIndex).Name.ToLower.IndexOf("transi") > -1 Then
                    If Me.dgv_detalle.Item(colIndex, rowIndex).Value.ToString > 0 Then
                        Me.dgv_detalle.Item(colIndex, rowIndex).Style.BackColor = Color.LightGreen
                    End If
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmb_pantalla_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_pantalla.SelectionChangeCommitted

        Dim dt As DataTable = ds_informacion_productos.Tables("pantallas").Copy
        dt.DefaultView.RowFilter = "nombre_pantalla = '" & cmb_pantalla.SelectedValue.ToString & "'"
        Colorear_Detalle(dt.DefaultView(0)("campos"))


    End Sub

    Private Sub dgv_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub chk_filtro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_filtro.CheckedChanged
        aplicarFiltro()
    End Sub

    Private Sub dgv_detalle_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalle.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_detalle.Rows(rowIndex)
                If (",pedido,agregar,porcentaje_ajuste,").IndexOf(dgv_detalle.Columns(colIndex).Name.ToLower) > -1 Then
                    Dim ncantidad As Integer = -99
                    Dim clickagregar As Boolean = dgv_detalle.Columns(colIndex).Name.ToLower.Equals("agregar")

                    If dgv_detalle.Columns(colIndex).Name.ToLower.Equals("pedido") Then
                        ncantidad = dgv_detalle.Item(colIndex, rowIndex).Value
                    End If


                    Me.AplicarProducto(Me.dgv_detalle.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value, dgv_detalle.Columns(colIndex).Name.ToLower, ncantidad, clickagregar)

                    dgv_detalle.CurrentCell = dgv_detalle.Item(colIndex, rowIndex)

                End If
            End If


        Catch ex As Exception


        End Try
    End Sub



End Class
