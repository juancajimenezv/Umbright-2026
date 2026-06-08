Imports AutomatizacionUmbright
Public Class frm_scm_ver_pedidos
    Inherits System.Windows.Forms.Form
    Public ds_informacion_productos As DataSet
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Dim pi_meses_adicionales As Short = 0
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
    Friend WithEvents lbl_ubicacion As System.Windows.Forms.Label
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents cmb_pantalla As System.Windows.Forms.ComboBox
    Friend WithEvents btn_abrir As System.Windows.Forms.Button
    Friend WithEvents dg_resumen As System.Windows.Forms.DataGrid
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents dg_resumen_gral As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_ver_pedidos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmb_pantalla = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dg_resumen = New System.Windows.Forms.DataGrid
        Me.btn_abrir = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.lbl_ubicacion = New System.Windows.Forms.Label
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.lbl_proveedor = New System.Windows.Forms.Label
        Me.dg_resumen_gral = New System.Windows.Forms.DataGrid
        Me.dgv_detalle = New System.Windows.Forms.DataGridView
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_resumen_gral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_pantalla
        '
        Me.cmb_pantalla.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_pantalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_pantalla.Location = New System.Drawing.Point(703, 32)
        Me.cmb_pantalla.Name = "cmb_pantalla"
        Me.cmb_pantalla.Size = New System.Drawing.Size(208, 21)
        Me.cmb_pantalla.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(703, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pantalla"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 2
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(916, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 62)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Definir Pantalla"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        '
        'dg_resumen
        '
        Me.dg_resumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_resumen.CaptionVisible = False
        Me.dg_resumen.DataMember = ""
        Me.dg_resumen.Font = New System.Drawing.Font("Arial", 6.75!)
        Me.dg_resumen.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_resumen.Location = New System.Drawing.Point(0, 488)
        Me.dg_resumen.Name = "dg_resumen"
        Me.dg_resumen.ReadOnly = True
        Me.dg_resumen.Size = New System.Drawing.Size(992, 99)
        Me.dg_resumen.TabIndex = 4
        '
        'btn_abrir
        '
        Me.btn_abrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_abrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_abrir.ImageIndex = 0
        Me.btn_abrir.ImageList = Me.ImageList1
        Me.btn_abrir.Location = New System.Drawing.Point(461, 2)
        Me.btn_abrir.Name = "btn_abrir"
        Me.btn_abrir.Size = New System.Drawing.Size(75, 62)
        Me.btn_abrir.TabIndex = 5
        Me.btn_abrir.Text = "Abrir"
        Me.btn_abrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn_exportar
        '
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.ImageIndex = 1
        Me.btn_exportar.ImageList = Me.ImageList1
        Me.btn_exportar.Location = New System.Drawing.Point(536, 2)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(75, 62)
        Me.btn_exportar.TabIndex = 5
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Location = New System.Drawing.Point(608, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 56)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Button2"
        Me.Button4.Visible = False
        '
        'lbl_ubicacion
        '
        Me.lbl_ubicacion.AutoSize = True
        Me.lbl_ubicacion.BackColor = System.Drawing.Color.PapayaWhip
        Me.lbl_ubicacion.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ubicacion.Location = New System.Drawing.Point(0, 24)
        Me.lbl_ubicacion.Name = "lbl_ubicacion"
        Me.lbl_ubicacion.Size = New System.Drawing.Size(65, 24)
        Me.lbl_ubicacion.TabIndex = 8
        Me.lbl_ubicacion.Text = "Origen"
        '
        'txt_producto
        '
        Me.txt_producto.BackColor = System.Drawing.Color.PeachPuff
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_producto.ForeColor = System.Drawing.Color.Black
        Me.txt_producto.Location = New System.Drawing.Point(0, 52)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(456, 23)
        Me.txt_producto.TabIndex = 6
        Me.txt_producto.Text = "Producto"
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.BackColor = System.Drawing.Color.PapayaWhip
        Me.lbl_proveedor.Font = New System.Drawing.Font("Trebuchet MS", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_proveedor.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_proveedor.Location = New System.Drawing.Point(0, 0)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(105, 26)
        Me.lbl_proveedor.TabIndex = 7
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'dg_resumen_gral
        '
        Me.dg_resumen_gral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_resumen_gral.CaptionVisible = False
        Me.dg_resumen_gral.DataMember = ""
        Me.dg_resumen_gral.Font = New System.Drawing.Font("Arial", 6.75!)
        Me.dg_resumen_gral.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_resumen_gral.Location = New System.Drawing.Point(0, 588)
        Me.dg_resumen_gral.Name = "dg_resumen_gral"
        Me.dg_resumen_gral.ReadOnly = True
        Me.dg_resumen_gral.Size = New System.Drawing.Size(992, 58)
        Me.dg_resumen_gral.TabIndex = 4
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_detalle.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_detalle.Location = New System.Drawing.Point(0, 81)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(991, 401)
        Me.dgv_detalle.TabIndex = 9
        '
        'frm_scm_ver_pedidos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(992, 645)
        Me.Controls.Add(Me.dgv_detalle)
        Me.Controls.Add(Me.lbl_ubicacion)
        Me.Controls.Add(Me.txt_producto)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.btn_abrir)
        Me.Controls.Add(Me.dg_resumen)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_pantalla)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.dg_resumen_gral)
        Me.Name = "frm_scm_ver_pedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. SCM - Consolidacion de Pedidos .::"
        CType(Me.dg_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_resumen_gral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oform As New frm_scm_definicion_pantalla
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
        Llenar_Maestros()
        Colorear_Detalle()
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

    Private Sub Colorear_Grid_Resumen()
        Dim clGenerales As New ClasesGenerales.General

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = ds_informacion_productos.Tables("Resumen").TableName

        Dim dc As DataColumn

        Dim nombre_tipo As String
        Dim i As Short = -1
        Dim iaux As Short

        For Each col As DataColumn In ds_informacion_productos.Tables("Resumen").Columns
            i = i + 1
            If i > -1 Then
                Dim gridCol As ClasesGenerales.FormattableTextBoxColumn = New ClasesGenerales.FormattableTextBoxColumn
                gridCol.MappingName = col.ColumnName

                dc = ds_informacion_productos.Tables("Resumen").Columns(i)

                Try
                    nombre_tipo = dc.DataType.ToString
                Catch ex As Exception
                    nombre_tipo = ""
                End Try



                Select Case col.ColumnName.ToLower
                    Case "producto", "glosa", "pareto", "estatus", "uxc", "fob", "full", "cajasxlayer", "cajasxpallet", "agregar"
                        gridCol.Width = 0
                    Case Else
                        If nombre_tipo = "System.Decimal" Then
                            gridCol.Format = "n"
                            gridCol.Alignment = HorizontalAlignment.Right
                            gridCol.Width = 60
                        ElseIf nombre_tipo = "System.Int32" Then
                            gridCol.Format = "###,###,##0."
                            gridCol.Alignment = HorizontalAlignment.Right
                            gridCol.Width = 60
                        ElseIf nombre_tipo = "System.Int16" Then
                            gridCol.Format = "###,###,##0."
                            gridCol.Alignment = HorizontalAlignment.Right
                            gridCol.Width = 40
                        Else
                            gridCol.Width = clGenerales.tamaño_maximo_campo(ds_informacion_productos.Tables("Resumen"), " ", col.ColumnName, Me.dg_resumen, 200, 0)
                        End If
                End Select

                gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
                gridCol.NullText = ""
                'AddHandler gridCol.SetCellFormat, AddressOf Me.FormatGridRow
                For iaux = 1 To 11
                    If col.ColumnName.ToLower.IndexOf(iaux.ToString.PadLeft(2, "0")) > 0 Then
                        gridCol.HeaderText = gridCol.HeaderText.Trim.Replace("+" & iaux.ToString.PadLeft(2, "0"), " " & Now.AddMonths(iaux + pi_meses_adicionales).ToString("MMMM"))
                    End If
                Next

                If gridCol.HeaderText.ToLower = "ppto" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                ElseIf gridCol.HeaderText.ToLower = "transito" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                ElseIf gridCol.HeaderText.ToLower = "saldo" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                ElseIf gridCol.HeaderText.ToLower = "Cobertura" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                End If


                tableStyle.AlternatingBackColor = Color.WhiteSmoke
                tableStyle.GridColumnStyles.Add(gridCol)

            End If
        Next

        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Arial", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray
        tableStyle.AlternatingBackColor = Color.WhiteSmoke
        tableStyle.RowHeaderWidth = 5

        Me.dg_resumen.TableStyles.Clear()
        Me.dg_resumen.TableStyles.Add(tableStyle)

    End Sub

    Private Sub Colorear_Grid_Resumen_General()
        Dim clGenerales As New ClasesGenerales.General

        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = ds_informacion_productos.Tables("Resumen_General").TableName

        Dim dc As DataColumn

        Dim nombre_tipo As String
        Dim i As Short = -1
        Dim iaux As Short

        For Each col As DataColumn In ds_informacion_productos.Tables("Resumen_General").Columns
            i = i + 1
            If i > -1 Then
                Dim gridCol As ClasesGenerales.FormattableTextBoxColumn = New ClasesGenerales.FormattableTextBoxColumn
                gridCol.MappingName = col.ColumnName

                dc = ds_informacion_productos.Tables("Resumen").Columns(i)

                Try
                    nombre_tipo = dc.DataType.ToString
                Catch ex As Exception
                    nombre_tipo = ""
                End Try



                Select Case col.ColumnName.ToLower
                    Case "proveedor", "procedencia", "producto", "glosa", "pareto", "estatus", "uxc", "fob", "full", "cajasxlayer", "cajasxpallet", "agregar"
                        gridCol.Width = 0
                    Case Else
                        If nombre_tipo = "System.Decimal" Then
                            gridCol.Format = "n"
                            gridCol.Alignment = HorizontalAlignment.Right
                            gridCol.Width = 60
                        ElseIf nombre_tipo = "System.Int32" Then
                            gridCol.Format = "###,###,##0."
                            gridCol.Alignment = HorizontalAlignment.Right
                            gridCol.Width = 60
                        ElseIf nombre_tipo = "System.Int16" Then
                            gridCol.Format = "###,###,##0."
                            gridCol.Alignment = HorizontalAlignment.Right
                            gridCol.Width = 40
                        Else
                            gridCol.Width = clGenerales.tamaño_maximo_campo(ds_informacion_productos.Tables("Resumen_General"), " ", col.ColumnName, Me.dg_resumen_gral, 200, 0)
                        End If
                End Select

                gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
                gridCol.NullText = ""
                'AddHandler gridCol.SetCellFormat, AddressOf Me.FormatGridRow
                For iaux = 1 To 11
                    If col.ColumnName.ToLower.IndexOf(iaux.ToString.PadLeft(2, "0")) > 0 Then
                        gridCol.HeaderText = gridCol.HeaderText.Trim.Replace("+" & iaux.ToString.PadLeft(2, "0"), " " & Now.AddMonths(iaux + pi_meses_adicionales).ToString("MMMM"))
                    End If
                Next

                If gridCol.HeaderText.ToLower = "ppto" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                ElseIf gridCol.HeaderText.ToLower = "transito" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                ElseIf gridCol.HeaderText.ToLower = "saldo" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                ElseIf gridCol.HeaderText.ToLower = "Cobertura" Then
                    gridCol.HeaderText = gridCol.HeaderText & " " & Now.AddMonths(pi_meses_adicionales).ToString("MMMM")
                End If


                tableStyle.AlternatingBackColor = Color.WhiteSmoke
                tableStyle.GridColumnStyles.Add(gridCol)

            End If
        Next

        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Arial", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray
        tableStyle.AlternatingBackColor = Color.WhiteSmoke
        tableStyle.RowHeaderWidth = 5

        Me.dg_resumen_gral.TableStyles.Clear()
        Me.dg_resumen_gral.TableStyles.Add(tableStyle)

    End Sub

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

    Private Sub Colorear_Detalle()
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_columnas_ocultar, ls_columnas_fijas As String
        Dim pGenerarTodasLasEmpresas As Boolean = True
        Dim piSemanas As Integer = 4

        Try

            ls_columnas_ocultar = String.Empty
            If Not pGenerarTodasLasEmpresas Then ls_columnas_ocultar = ",empresa"
            ls_columnas_ocultar += ",marca,diario_cajas,pareto,estatus,cd_cajas,cdx_cajas,da_cajas,sugerido_proveedor,min_cajas,max_cajas,tiene_compra,"
            ls_columnas_fijas = String.Empty

            ClsGen.Alinear_GridView(ds_informacion_productos.Tables("detalle_productos"), Me.dgv_detalle, "", ls_columnas_ocultar, "", "", "", ls_columnas_fijas, "", True, True, 250, 0)
            For Each dc As DataGridViewColumn In Me.dgv_detalle.Columns
                If dc.Name.ToLower.StartsWith("cober") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    dc.Width = 50
                ElseIf dc.Name.ToLower.StartsWith("suger") Then
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    If piSemanas > 0 Then
                        Try
                            If dc.Name.IndexOf("+") > 0 Then
                                If Val(dc.Name.Split("+")(1)) < piSemanas Then
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
                End If

                If dc.Name.ToLower.IndexOf("+") > 0 Then
                    dc.HeaderText = dc.HeaderText.Substring(0, dc.HeaderText.IndexOf("+")) + " Sem " + _
                                 DatePart(DateInterval.WeekOfYear, Today.AddDays(7 * dc.HeaderText.Substring(dc.HeaderText.IndexOf("+") + 1, 2))).ToString
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

    Private Sub frm_scm_ver_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds_informacion_productos = New DataSet
        Llenar_Maestros()
        Llenar_combos()
    End Sub

    Private Sub btn_Abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abrir.Click
        Me.dgv_detalle.DataSource = Nothing
        Me.dg_resumen.DataSource = Nothing
        Me.dg_resumen_gral.DataSource = Nothing
        Me.dgv_detalle.Refresh()
        Me.Refresh()

        ds_informacion_productos = New DataSet

        Dim oform As New frm_scm_obtiene_informacion(ds_informacion_productos)
        oform.ShowDialog()

        Me.lbl_proveedor.Text = ""
        oform = Nothing

        Llenar_Maestros()

        Me.dgv_detalle.DataSource = ds_informacion_productos.Tables("detalle_productos")

        Me.dg_resumen.DataSource = ds_informacion_productos.Tables("resumen")
        Me.dg_resumen_gral.DataSource = ds_informacion_productos.Tables("resumen_general")

        pi_meses_adicionales = IIf(ds_informacion_productos.Tables("scm_parametros_generales").Rows(0).Item("incluir_mes_actual_proyeccion") = True, 0, 1)


        Colorear_Detalle()
        'Posicionar_Origen()
        Colorear_Grid_Resumen()
        Colorear_Grid_Resumen_General()

    End Sub

    'Private Sub cmb_pantalla_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_pantalla.SelectionChangeCommitted
    '    Colorear_Grid()
    'End Sub

    'Private Sub dg_detalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Posicionar_Origen()
    'End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click

        Dim scampos As String = ""
        Dim Oaut As New AutomatizacionUmbright.exportar_excel
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

    Private Sub cmb_pantalla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_pantalla.SelectedIndexChanged

    End Sub
    Private Sub FormatGridRow(ByVal sender As Object, ByVal e As ClasesGenerales.DataGridFormatCellEventArgs)

        'Dim discontinued As Boolean = CBool(IIf(e.Column <> 0, Me.dg_detalle(e.Row, 0), e.CurrentCellValue)) 'TODO: For performance reasons this should be changed to nested IF statements
        Dim a As String
        Dim scolnombre As String

        Dim nrow As Integer

        Try
            a = e.CurrentCellValue
            scolnombre = e.ColumnName


            If scolnombre.ToLower.StartsWith("cober") Then

                If a <= 1 Then
                    e.BackBrush = Brushes.Yellow
                    e.ForeBrush = Brushes.Red
                ElseIf a > 1 And a <= 3.1 Then
                    e.BackBrush = Brushes.ForestGreen
                    'e.ForeBrush = Brushes.Blue
                ElseIf a > 3.1 Then
                    e.BackBrush = Brushes.Red
                    e.ForeBrush = Brushes.White
                End If

                nrow = e.Row
                'nrow = Me.dg_detalle.Item(nrow, 11)
            ElseIf e.Column <> -1 Then
                e.ForeBrush = Brushes.Black
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)

        Try
            Dim data As DataRowView
            Dim value As Boolean
            'Dim value2 As String

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value = data("agregar")
            'value2 = data("cantidad")


            If value = True Then
                e.RowColor = Color.Blue
                'ElseIf value <> value2 Then
                '   e.RowColor = Color.Chocolate
            End If

        Catch ex As Exception
        End Try

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

End Class
