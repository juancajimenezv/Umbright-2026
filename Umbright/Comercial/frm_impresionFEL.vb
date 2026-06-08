Public Class frm_impresionFEL
    Inherits System.Windows.Forms.Form

    Dim ds_guia As New DataSet
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Dim ptipo_guia As String = ""
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dg_detalle_guia As System.Windows.Forms.DataGrid
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_impresionFEL))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmb_tipos = New System.Windows.Forms.ComboBox()
        Me.txt_numero = New System.Windows.Forms.TextBox()
        Me.dg_detalle_guia = New System.Windows.Forms.DataGrid()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_detalle_guia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(862, 525)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.StatusBar1)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cmbEmpresa)
        Me.TabPage1.Controls.Add(Me.cmb_tipos)
        Me.TabPage1.Controls.Add(Me.txt_numero)
        Me.TabPage1.Controls.Add(Me.dg_detalle_guia)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(854, 496)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Reimpresion - FEL"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_Imprimir)
        Me.GroupBox1.Location = New System.Drawing.Point(562, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 111)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 1
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(21, 21)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(80, 72)
        Me.btn_nuevo.TabIndex = 7
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "7.png")
        Me.ImageList1.Images.SetKeyName(1, "3.png")
        Me.ImageList1.Images.SetKeyName(2, "Checked_Shield_Green.png")
        Me.ImageList1.Images.SetKeyName(3, "print_48.png")
        Me.ImageList1.Images.SetKeyName(4, "Floppy-64.png")
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Imprimir.ImageIndex = 3
        Me.btn_Imprimir.ImageList = Me.ImageList1
        Me.btn_Imprimir.Location = New System.Drawing.Point(107, 21)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(80, 72)
        Me.btn_Imprimir.TabIndex = 23
        Me.btn_Imprimir.Text = "Imprimir"
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Imprimir.UseVisualStyleBackColor = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 474)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel2, Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(854, 22)
        Me.StatusBar1.TabIndex = 32
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 738
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 99
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(29, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 16)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Docto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(365, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Numero"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.DropDownWidth = 175
        Me.cmbEmpresa.Location = New System.Drawing.Point(95, 87)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(94, 24)
        Me.cmbEmpresa.TabIndex = 10
        '
        'cmb_tipos
        '
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.DropDownWidth = 175
        Me.cmb_tipos.Location = New System.Drawing.Point(243, 88)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(116, 24)
        Me.cmb_tipos.TabIndex = 10
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(424, 89)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(81, 22)
        Me.txt_numero.TabIndex = 11
        '
        'dg_detalle_guia
        '
        Me.dg_detalle_guia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_detalle_guia.CaptionVisible = False
        Me.dg_detalle_guia.DataMember = ""
        Me.dg_detalle_guia.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_detalle_guia.Location = New System.Drawing.Point(8, 118)
        Me.dg_detalle_guia.Name = "dg_detalle_guia"
        Me.dg_detalle_guia.Size = New System.Drawing.Size(838, 326)
        Me.dg_detalle_guia.TabIndex = 0
        '
        'frm_impresionFEL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(862, 525)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_impresionFEL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Control de Transporte"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_detalle_guia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Combos()
        Dim ls_sql As String
        Dim tipos_doctos(1) As String
        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_sql = "pa_sel_um_gen_parametros_sistema"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        'tipos_doctos = ldt_table.Rows(0).Item("documentos_control_transporte").ToString.Split(",")

        tipos_doctos = "FEL,FEL AL COSTO".Split(",")
        Me.cmb_tipos.Items.AddRange(tipos_doctos)






        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_TIPOGUIA',NULL"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ptipo_guia = ldt_table.Rows(0).Item("descripcion").ToString





        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "empresa"

        Me.cmbEmpresa.DisplayMember = "descripcion"
        Me.cmbEmpresa.ValueMember = "descripcion"
        Me.cmbEmpresa.DataSource = ldt_table


        oTransaccion.close()
        oTransaccion = Nothing
    End Sub

    Private Sub Crear_Estructura()
        Dim dt As New DataTable("detalle_guia")

        dt.Columns.Add(New DataColumn("picker", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_docto", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("comentario_factura", GetType(String)))
        'dt.Columns.Add(New DataColumn("distancia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
        ds_guia.Tables.Add(dt.Copy)
    End Sub

    Private Sub Colorear_Grid()
        Dim clsGen As New ClasesGenerales.General
        Me.dg_detalle_guia.DataSource = ds_guia.Tables("detalle_guia")
        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = "detalle_guia"


        For Each col As DataColumn In ds_guia.Tables("detalle_guia").Columns

            Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
            gridCol.MappingName = col.ColumnName

            Select Case col.ColumnName.ToLower
                Case "picker"
                    gridCol.Width = 0
                Case "monto", "peso"
                    gridCol.Format = "n"
                    gridCol.Alignment = HorizontalAlignment.Right
                Case Else
                    gridCol.Width = clsGen.tamaño_maximo_campo(ds_guia.Tables("detalle_guia"), " ", col.ColumnName, Me.dg_detalle_guia, 200, 0)
            End Select

            gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
            gridCol.NullText = ""
            AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
            tableStyle.GridColumnStyles.Add(gridCol)
        Next

        tableStyle.RowHeaderWidth = 5
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray

        Me.dg_detalle_guia.TableStyles.Clear()
        Me.dg_detalle_guia.TableStyles.Add(tableStyle)
    End Sub



    Private Sub frm_control_transporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Crear_Estructura()
        Colorear_Grid()
    End Sub

    Private Sub Buscar_Factura()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dr, dr_aux As DataRow

        otrans.open()

        Try


            If Me.cmb_tipos.Text.ToString.ToLower.StartsWith("devolu") Then

                ls_sql = "pa_sel_um_devolucion '" & Me.cmbEmpresa.SelectedValue & "'," & Me.txt_numero.Text
                dt = otrans.Obtiene(ls_sql)
                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                Else
                    If Es_Unico("detalle_guia", ds_guia.Tables("detalle_guia"), "numero", Me.txt_numero.Text) Then

                        dr = dt.Rows(0)
                        dr_aux = ds_guia.Tables("detalle_guia").NewRow
                        dr_aux.Item("tipo_docto") = "Devolucion"
                        dr_aux.Item("numero") = dr.Item("correlativo")
                        dr_aux.Item("nombre") = dr.Item("nombre_cliente")
                        dr_aux.Item("monto") = 0 'dr.Item("total")
                        dr_aux.Item("peso") = 0 'dr.Item("peso")
                        dr_aux.Item("picker") = "" 'dr.Item("picker")
                        dr_aux.Item("comentario_factura") = dr.Item("comentarios")
                        'dr_aux.Item("distancia") = Me.txtDistancia.Text
                        dr_aux.Item("empresa") = Me.cmbEmpresa.SelectedValue

                        ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)
                        Colorear_Grid()
                        Recalcular_Totales(ds_guia.Tables("detalle_guia"))
                        Me.dg_detalle_guia.CurrentRowIndex = ds_guia.Tables("detalle_guia").Rows.Count - 1
                    Else
                        MessageBox.Show("Numero ya Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else ''Es Otro Tipo de Documento diferente a Devolucion
                Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")
                ls_sql = "pa_var_um_documento_control_transporte '" & Me.cmbEmpresa.SelectedValue & "','" &
                                Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"

                dt = otrans.Obtiene(ls_sql)

                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                Else
                    If dt.Rows.Count > 0 Then
                        'If dt.Rows(0).Item("porcentajeAsignado") > 0 Or
                        '    dt.Rows(0).Item("numero_temporal").ToString.Trim.Length > 0 Then
                        '    MessageBox.Show("Factura Asignada En Otro Control " &
                        '    IIf(dt.Rows(0).Item("numero_temporal").ToString.Trim.Length > 0, " Temporal No. " & dt.Rows(0).Item("numero_temporal").ToString, " "),
                        '    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        'Else
                        'Verificar Picker
                        'If dt.Rows(0).Item("picker").ToString = "SIN PICKER" Then
                        '     MessageBox.Show("Esta Factura No ha Sido Pickeada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        '  End If

                        If Es_Unico("detalle_guia", ds_guia.Tables("detalle_guia"), "numero", Me.txt_numero.Text) Then

                            dr = dt.Rows(0)



                            ''(c) 20160606 Validar que no sea Interempresas
                            '' then 'CD_CENTRAL'
                            ''  then 'CD_TELEMERCADEO'
                            ') then 'WINE_SOCIETY'
                            'If Not Me.cmb_ruta.Text.StartsWith("OFICI") Then
                            '        If dr.Item("ctacte") = "2968550" Or
                            '            dr.Item("ctacte") = "29685512" Or
                            '            dr.Item("ctacte") = "29685511" Then

                            '            MessageBox.Show("Factura InterEmpresa No puede Asignarse A Control", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            '            Exit Try
                            '        End If
                            '    End If


                            dr_aux = ds_guia.Tables("detalle_guia").NewRow
                            dr_aux.Item("tipo_docto") = dr.Item("tipodocto")
                            dr_aux.Item("numero") = dr.Item("numero")
                            dr_aux.Item("nombre") = dr.Item("nombre_cliente")
                            dr_aux.Item("monto") = dr.Item("total")
                            dr_aux.Item("peso") = dr.Item("peso")
                            dr_aux.Item("picker") = dr.Item("picker")
                            dr_aux.Item("comentario_factura") = dr.Item("comentario1")


                            dr_aux.Item("empresa") = Me.cmbEmpresa.SelectedValue

                            ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)
                            Colorear_Grid()
                            Recalcular_Totales(ds_guia.Tables("detalle_guia"))
                            Me.dg_detalle_guia.CurrentRowIndex = ds_guia.Tables("detalle_guia").Rows.Count - 1
                        Else
                            MessageBox.Show("Numero ya Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                    'Else
                    'MessageBox.Show("Documento No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                End If 'codigo_error
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            Me.txt_numero.Focus()
            Me.txt_numero.SelectAll()

        End Try

    End Sub

    Private Sub Recalcular_Totales(ByVal dt As DataTable)
        'Totaliza la cotizacion
        'Private Sub totalizar(ByVal otabla As DataTable)
        Dim dr As DataRow
        Dim total, total_peso As Double

        total = 0
        total_peso = 0
        Try

            For Each dr In dt.Rows
                total = total + dr.Item("monto")
                total_peso = total_peso + dr.Item("peso")
            Next
        Catch ex As Exception
        Finally

            Try
                Me.StatusBarPanel1.Text = "Documentos " & ds_guia.Tables("detalle_guia").Rows.Count.ToString
            Catch ex As Exception
            End Try
        End Try

    End Sub

    Private Sub Recalcular_Totales(ByVal dt As DataTable, ByVal psEmpresa As String)
        'Totaliza la cotizacion
        'Private Sub totalizar(ByVal otabla As DataTable)
        Dim dr As DataRow
        Dim total, total_peso As Double

        total = 0
        total_peso = 0
        Try

            For Each dr In dt.Rows
                If dr.Item("empresa").ToString.ToLower.Equals(psEmpresa.ToLower) Then

                    total = total + dr.Item("monto")
                    total_peso = total_peso + dr.Item("peso")
                End If
            Next
        Catch ex As Exception
        Finally

            Try
                Me.StatusBarPanel1.Text = "Documentos " & ds_guia.Tables("detalle_guia").Rows.Count.ToString
            Catch ex As Exception
            End Try
        End Try

    End Sub

    Private Function Es_Unico(ByVal TableName As String,
                              ByVal SourceTable As DataTable,
                              ByVal FieldName As String,
                              ByVal DatoActual As String) As Boolean


        Dim ReturnValue As Boolean = True
        Dim dt As New DataTable(TableName)
        Dim nveces As Integer = 0

        dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)


        For Each dr As DataRow In SourceTable.Select("", FieldName)
            If ColumnEqual(DatoActual, dr(FieldName)) Then
                ReturnValue = False
            End If
            'If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
            '   LastValue = dr(FieldName)
            '    dt.Rows.Add(New Object() {LastValue})
            'End If
        Next
        'If Not ds Is Nothing Then ds.Tables.Add(dt)
        'Return dt
        Return ReturnValue
    End Function

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        '
        ' Compares two values to determine if they are equal. Also compares DBNULL.Value.
        '
        ' NOTE: If your DataTable contains object fields, you must extend this
        ' function to handle the fields in a meaningful way if you intend to group on them.
        '
        If A Is DBNull.Value And B Is DBNull.Value Then Return True ' Both are DBNull.Value.
        If A Is DBNull.Value Or B Is DBNull.Value Then Return False ' Only one is DBNull.Value.
        Return A = B                                                ' Value type standard comparison
    End Function




    'Private Sub Mostrar_registro(ByVal prownumber As Integer, ByVal pnumero As String)
    '    Dim ls_sql As String
    '    Dim dt As DataTable
    '    Dim dr, dr_aux As DataRow
    '    Dim drv As DataRowView

    '    Dim otrans As New Transaccional.Conexion("flexline")

    '    otrans.open()

    '    Try
    '        ds_guia.Tables("detalle_guia").Rows.Clear()

    '        ls_sql = "pa_sel_um_gen_control_transporte_detalle_temporal '" & gs_empresa & "','" & pnumero & "'"
    '        dt = otrans.Obtiene(ls_sql)

    '        For Each dr In dt.Rows

    '            dr_aux = ds_guia.Tables("detalle_guia").NewRow

    '            dr_aux.Item("tipo_docto") = dr.Item("tipodoctoOrigen")
    '            dr_aux.Item("numero") = dr.Item("numeroOrigen")
    '            dr_aux.Item("nombre") = dr.Item("nombre_cliente")
    '            dr_aux.Item("monto") = dr.Item("total")
    '            dr_aux.Item("peso") = dr.Item("peso")
    '            dr_aux.Item("comentario_factura") = dr.Item("comentario1")
    '            dr_aux.Item("distancia") = dr.Item("distancia")
    '            dr_aux.Item("empresa") = dr.Item("empresa")
    '            ds_guia.Tables("detalle_guia").Rows.Add(dr_aux)

    '        Next

    '        ds_guia.Tables("pendientes_aprobacion").DefaultView.RowFilter = "numero = '" & Me.dg_controles_pendientes.Item(prownumber, 2) & "'"
    '        drv = ds_guia.Tables("pendientes_aprobacion").DefaultView(0)
    '        Me.cmb_ruta.SelectedValue = drv.Item("ruta")
    '        Me.dtp_fecha_control.Text = drv.Item("fecha")
    '        Me.dtp_fecha_vcto.Value = drv.Item("fechaVcto")
    '        Me.lbl_numero.Text = drv.Item("numero")
    '        Me.txt_observaciones.Text = drv.Item("comentario1")
    '        Me.chkTiempoExtra.CheckState = IIf(drv.Item("tiempoExtra") = "SI", CheckState.Checked, CheckState.Unchecked)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        otrans.close()
    '        otrans = Nothing
    '        Colorear_Grid()
    '        Recalcular_Totales(ds_guia.Tables("detalle_guia"))

    '    End Try

    'End Sub

    Private Sub Limpiar_Pantalla()
        ds_guia.Tables("detalle_guia").Rows.Clear()

        Recalcular_Totales(ds_guia.Tables("detalle_guia"))
        'Me.lblFechaSalida.Visible = False
        'Me.dtpFechaSalida.Visible = False
    End Sub

    'Private Sub Aprobar_Control()

    '    Dim ls_sql, nombre_chequeador As String
    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    Dim icount As Integer = 0
    '    Dim otrans As New Transaccional.Conexion("flexline")
    '    Dim llimpiar_pantalla As Boolean = False

    '    Try
    '        otrans.open()
    '        'Hacer Validaciones
    '        ls_sql = "pa_sel_um_gen_control_transporte_temporal '" & gs_empresa & "','" & Me.lbl_numero.Text & "'"
    '        dt = otrans.Obtiene(ls_sql)
    '        If dt.Rows.Count > 0 Then
    '            If dt.Rows(0).Item("estado") = False Then

    '                'Quien fue el Chequeador
    '                Dim oform As New frm_pickeador
    '                oform.Text = "Seleccione Chequeador"
    '                oform.Llenar_Combo_Chequeador()
    '                oform.ShowDialog(Me)
    '                nombre_chequeador = oform.cmb_nombre_picker.Text
    '                oform.Dispose()



    '                'Tomar toda la informacion de los controles
    '                'tengo que traer el correlativo
    '                If nombre_chequeador.Trim.Length > 5 Then


    '                    ls_sql = "pa_var_um_detalle_documento_control_transporte '" & gs_empresa & "','" & ptipo_guia & "','" & Me.lbl_numero.Text & "'"
    '                    dt = otrans.Obtiene(ls_sql)

    '                    For Each dr In dt.Rows
    '                        icount = icount + 1
    '                        ls_sql = "pa_ins_um_detalle_control_transporte '" &
    '                                  gs_empresa & "','" & ptipo_guia & "'," & dr.Item("correlativoControl").ToString.Trim & "," &
    '                                  icount.ToString.Trim & ",'" & dr.Item("producto").ToString & "'," &
    '                                  dr.Item("cantidad").ToString & "," & dr.Item("precio").ToString & "," &
    '                                  dr.Item("SubTotal").ToString & "," & dr.Item("neto").ToString & "," &
    '                                  dr.Item("Costo").ToString & "," & dr.Item("Total").ToString & "," &
    '                                  dr.Item("PrecioAjustado").ToString & ",'" & dr.Item("UnidadIngreso").ToString & "'," &
    '                                  dr.Item("CantidadIngreso").ToString & "," & dr.Item("PrecioIngreso").ToString & "," &
    '                                  dr.Item("SubTotalIngreso").ToString & "," & dr.Item("NetoIngreso").ToString & "," &
    '                                  dr.Item("TotalIngreso").ToString & ",'" & dr.Item("tipoDoctoOriginal").ToString & "'," &
    '                                  dr.Item("CorrelativoOriginal").ToString & "," & dr.Item("SecuenciaOriginal").ToString & ",'" &
    '                                  dr.Item("fechaEntregaOriginal").ToString & "','" & dr.Item("fecha").ToString & "'," &
    '                                  dr.Item("CUP").ToString & ",'" & dr.Item("ubicacion").ToString & "','" &
    '                                  dr.Item("ubicacion2").ToString & "'," & dr.Item("PrecioBimoneda").ToString & "," &
    '                                  dr.Item("SubTotalBimoneda").ToString & "," & dr.Item("NetoBimoneda").ToString & "," &
    '                                  dr.Item("TotalBimoneda").ToString & "," & dr.Item("PrecioListaP").ToString & ",'" &
    '                                  dr.Item("FechaVigenciaLp").ToString & "'"

    '                        otrans.Ingresa(ls_sql)
    '                        If otrans.Codigo_error > 0 Then
    '                            MessageBox.Show(otrans.descripcion_error)
    '                        End If

    '                    Next

    '                    'Actualizo Estado de Control
    '                    ls_sql = "pa_upd_um_gen_control_transporte_temporal '" & gs_empresa & "','" & ptipo_guia & "','" &
    '                              Me.lbl_numero.Text & "',1"
    '                    otrans.Actualiza(ls_sql)

    '                    'Actualizo Chequeador
    '                    ls_sql = "pa_upd_um_control_transporte  '" & gs_empresa & "','" & ptipo_guia & "','" &
    '                            Me.lbl_numero.Text & "','" & nombre_chequeador & "',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" &
    '                            Me.dtpFechaSalida.Text & "',NULL,'" &
    '                            IIf(Me.chkTiempoExtra.CheckState = CheckState.Checked, "SI", "NO") & "'" &
    '                            ",'" & gs_usuario & "'"


    '                    otrans.Actualiza(ls_sql)


    '                    'Genero Documentov
    '                    ls_sql = "pa_ins_um_documentov '" & gs_empresa & "','" & ptipo_guia & "'," &
    '                            dt.Rows(0).Item("correlativocontrol").ToString & "," &
    '                            Double.Parse(Me.txt_monto.Text) & ",12"

    '                    otrans.Ingresa(ls_sql)


    '                    MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    llimpiar_pantalla = True
    '                Else
    '                    MessageBox.Show("Debe Seleccionar un Chequeador Valido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                End If
    '            End If
    '        Else
    '            MessageBox.Show("Este Control ya ha sido Procesado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        otrans.close()
    '        otrans = Nothing
    '    End Try
    '    If llimpiar_pantalla Then
    '        Limpiar_Pantalla()
    '        Llenar_Pendientes_Aprobacion()
    '    End If
    'End Sub

    Private Sub txt_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            Buscar_Factura()

        End If
    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)
        Try
            Dim data As DataRowView
            Dim value2 As String

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value2 = data("picker").ToString

            If value2.Trim.ToLower = "sin picker" Then
                e.RowColor = Color.Red
            End If


        Catch ex As Exception
        End Try
    End Sub


    Private Sub imprimirFEL()

        Dim clsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt = New Automatizar.Reportes_CraxDrt(gs_empresa)
        Oaut.pnNumeroCopias = 1

        Try

            Dim lsDirectorio As String



            Dim pm_valores(3), pm_valores_consolidado(2) As String
            Dim pm_parametros(3) As String
            Dim pm_conexion(3) As String

            pm_conexion = clsGen.Parametros_Conexion("")
            Dim ppath_reporte As String = clsGen.Path_Reporte
            '023:

            'ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas codicasa.rpt"

            pm_parametros(0) = "empresa"
            pm_parametros(1) = "tipodocto"
            pm_parametros(2) = "numero"
            pm_parametros(3) = "user_name"




            'For Each dr As DataRow In ds_guia.Tables("detalle_guia").Rows
            Try


                For Each drv As DataRowView In ds_guia.Tables("detalle_guia").DefaultView



                    lsDirectorio = "c:\temp\" & drv.Item("empresa").ToString & "\" & drv.Item("tipo_docto").ToString & "_" & drv.Item("numero").ToString & ".pdf"

                    ppath_reporte = clsGen.Path_Reporte
                        ppath_reporte = ppath_reporte & "Finanzas\Facturacion\Guatefacturas "
                    ppath_reporte += drv.Item("empresa").ToString + " "
                    ppath_reporte += drv.Item("tipo_docto").ToString
                    ppath_reporte += ".rpt"

                    pm_valores(0) = drv.Item("empresa").ToString
                    pm_valores(1) = drv.Item("tipo_docto").ToString
                    pm_valores(2) = drv.Item("numero").ToString
                    pm_valores(3) = gs_usuario & "    --- COPIA ---"

                    _reporte_generico_clase(ppath_reporte, pm_parametros, pm_valores,
                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                        True, True, "PDF", False, lsDirectorio, True, 1)



                Next

                Catch ex As Exception
        Finally
            Oaut = Nothing
            clsGen = Nothing
        End Try



        Catch ex As Exception

            End Try
    End Sub




    Private Sub dg_detalle_guia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dg_detalle_guia.Validating
        Recalcular_Totales(ds_guia.Tables("detalle_guia"))
    End Sub






    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click

        For Each dr As DataRow In ds_guia.Tables("detalle_guia").Rows
            Try

                imprimirFEL()
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Limpiar_Pantalla()
    End Sub

    Private Sub btn_aprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Aprobar_Control()
    End Sub






    Private Sub txt_numero_TextChanged(sender As Object, e As EventArgs) Handles txt_numero.TextChanged

    End Sub

    Private Sub txtDistancia_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_numero_RegionChanged(sender As Object, e As EventArgs) Handles txt_numero.RegionChanged

    End Sub
End Class

