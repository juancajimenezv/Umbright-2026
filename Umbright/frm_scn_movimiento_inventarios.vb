Imports System.IO
Public Class frm_scn_movimiento_inventarios
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_piloto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_factura As System.Windows.Forms.TextBox
    Friend WithEvents txt_codcliente As System.Windows.Forms.TextBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_liberar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_locales As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SBP_panel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SBP_panelMedio As System.Windows.Forms.StatusBarPanel
    Friend WithEvents txt_glosa As System.Windows.Forms.TextBox
    Friend WithEvents SBP_Panel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents btnObtener As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scn_movimiento_inventarios))
        Me.txt_factura = New System.Windows.Forms.TextBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_piloto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_tipos = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_codcliente = New System.Windows.Forms.TextBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.SBP_panel1 = New System.Windows.Forms.StatusBarPanel()
        Me.SBP_panelMedio = New System.Windows.Forms.StatusBarPanel()
        Me.SBP_Panel3 = New System.Windows.Forms.StatusBarPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_liberar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmb_locales = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnObtener = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.txt_glosa = New System.Windows.Forms.TextBox()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SBP_panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SBP_panelMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SBP_Panel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_factura
        '
        Me.txt_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_factura.Location = New System.Drawing.Point(293, 44)
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.Size = New System.Drawing.Size(107, 20)
        Me.txt_factura.TabIndex = 0
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Productos en Factura"
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 174)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(748, 306)
        Me.DataGrid1.TabIndex = 1
        Me.DataGrid1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(248, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero"
        '
        'txt_fecha
        '
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(72, 141)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(72, 20)
        Me.txt_fecha.TabIndex = 4
        Me.txt_fecha.TabStop = False
        '
        'txt_piloto
        '
        Me.txt_piloto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_piloto.Location = New System.Drawing.Point(152, 100)
        Me.txt_piloto.Multiline = True
        Me.txt_piloto.Name = "txt_piloto"
        Me.txt_piloto.ReadOnly = True
        Me.txt_piloto.Size = New System.Drawing.Size(248, 40)
        Me.txt_piloto.TabIndex = 5
        Me.txt_piloto.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cliente"
        '
        'cmb_tipos
        '
        Me.cmb_tipos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tipos.Location = New System.Drawing.Point(72, 18)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(328, 21)
        Me.cmb_tipos.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tipo Docto"
        '
        'txt_codcliente
        '
        Me.txt_codcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codcliente.Location = New System.Drawing.Point(72, 99)
        Me.txt_codcliente.Name = "txt_codcliente"
        Me.txt_codcliente.ReadOnly = True
        Me.txt_codcliente.Size = New System.Drawing.Size(72, 20)
        Me.txt_codcliente.TabIndex = 11
        Me.txt_codcliente.TabStop = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 480)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SBP_panel1, Me.SBP_panelMedio, Me.SBP_Panel3})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(768, 22)
        Me.StatusBar1.TabIndex = 13
        '
        'SBP_panel1
        '
        Me.SBP_panel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.SBP_panel1.Name = "SBP_panel1"
        Me.SBP_panel1.Width = 250
        '
        'SBP_panelMedio
        '
        Me.SBP_panelMedio.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.SBP_panelMedio.Name = "SBP_panelMedio"
        Me.SBP_panelMedio.Width = 250
        '
        'SBP_Panel3
        '
        Me.SBP_Panel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.SBP_Panel3.Name = "SBP_Panel3"
        Me.SBP_Panel3.Width = 250
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_liberar)
        Me.GroupBox2.Controls.Add(Me.cmb_locales)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(417, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(287, 65)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destino"
        '
        'btn_liberar
        '
        Me.btn_liberar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_liberar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_liberar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_liberar.ForeColor = System.Drawing.Color.White
        Me.btn_liberar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_liberar.ImageIndex = 0
        Me.btn_liberar.ImageList = Me.ImageList1
        Me.btn_liberar.Location = New System.Drawing.Point(206, 7)
        Me.btn_liberar.Name = "btn_liberar"
        Me.btn_liberar.Size = New System.Drawing.Size(75, 56)
        Me.btn_liberar.TabIndex = 4
        Me.btn_liberar.Text = "Actualizar"
        Me.btn_liberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_liberar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'cmb_locales
        '
        Me.cmb_locales.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_locales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_locales.DropDownWidth = 180
        Me.cmb_locales.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_locales.Items.AddRange(New Object() {"Completa", "Solo Envio", "Solo Recepcion"})
        Me.cmb_locales.Location = New System.Drawing.Point(42, 24)
        Me.cmb_locales.Name = "cmb_locales"
        Me.cmb_locales.Size = New System.Drawing.Size(158, 21)
        Me.cmb_locales.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tienda"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_factura)
        Me.GroupBox1.Controls.Add(Me.txt_fecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_codcliente)
        Me.GroupBox1.Controls.Add(Me.btnObtener)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbProveedor)
        Me.GroupBox1.Controls.Add(Me.cmb_tipos)
        Me.GroupBox1.Controls.Add(Me.txt_piloto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_glosa)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 168)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion a Sincronizar"
        '
        'btnObtener
        '
        Me.btnObtener.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnObtener.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnObtener.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObtener.ForeColor = System.Drawing.Color.White
        Me.btnObtener.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnObtener.Location = New System.Drawing.Point(293, 66)
        Me.btnObtener.Name = "btnObtener"
        Me.btnObtener.Size = New System.Drawing.Size(107, 27)
        Me.btnObtener.TabIndex = 4
        Me.btnObtener.Text = "Obtener"
        Me.btnObtener.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnObtener.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Proveedor"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbProveedor.Location = New System.Drawing.Point(72, 46)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(176, 21)
        Me.cmbProveedor.TabIndex = 7
        '
        'txt_glosa
        '
        Me.txt_glosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_glosa.Location = New System.Drawing.Point(152, 141)
        Me.txt_glosa.Name = "txt_glosa"
        Me.txt_glosa.ReadOnly = True
        Me.txt_glosa.Size = New System.Drawing.Size(248, 20)
        Me.txt_glosa.TabIndex = 4
        Me.txt_glosa.TabStop = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.ImageIndex = 1
        Me.btn_limpiar.ImageList = Me.ImageList1
        Me.btn_limpiar.Location = New System.Drawing.Point(622, 69)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(75, 58)
        Me.btn_limpiar.TabIndex = 4
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'frm_scn_movimiento_inventarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(768, 502)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Name = "frm_scn_movimiento_inventarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Sincronizacion de Movimientos de Inventarios .::"
        Me.TopMost = True
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SBP_panel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SBP_panelMedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SBP_Panel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim pdataset As New DataSet
    Dim dt_detalle_documento As DataTable
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Private okToValidate As Boolean
    Private okToValidate2 As Boolean = True

    Private Sub LlenarCombo()

        Dim ls_sqlScript As String


        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")


        Try
            oTransaccion.open()

            'ls_sqlScript = "pa_sel_um_tipodocumento '" & gs_empresa & "',NULL"

            ls_sqlScript = "pa_sel_um_tipodocumento_usuario '" & gs_empresa & "',NULL,NULL,'" & gs_usuario & "'"

            ldt_table = oTransaccion.Obtiene(ls_sqlScript)
            ldt_table.TableName = "tipos"
            pdataset.Tables.Add(ldt_table.Copy)

            'ldt_table.DefaultView.RowFilter = " tipodocto like '%SALIDA BODEGA CD%'"
            Me.cmb_tipos.DisplayMember = "tipoDocto"
            Me.cmb_tipos.ValueMember = "tipoDocto"
            Me.cmb_tipos.DataSource = ldt_table

            If gs_empresa = "VINOTECA" Then ''Cambio solicitado para que solo los dueños de las salas envien a sus tiendas (c) 28012015
                ls_sqlScript = "pa_sel_um_usuario_bodega '" & gs_empresa & "','SOLICITUD O/COMPRA','" & gs_usuario & "'"
                ldt_table = oTransaccion.Obtiene(ls_sqlScript)
                Me.cmb_locales.DataSource = ldt_table
                Me.cmb_locales.DisplayMember = "ubicacion"
                Me.cmb_locales.ValueMember = "bodega"

            Else

                ls_sqlScript = "pa_sel_um_gen_tabcod NULL,'GEN_LOCALES','" & gs_empresa & "'"
                ldt_table = oTransaccion.Obtiene(ls_sqlScript)
                ldt_table.TableName = "gen_locales"
                pdataset.Tables.Add(ldt_table.Copy)

                Me.cmb_locales.DataSource = ldt_table
                Me.cmb_locales.DisplayMember = "DESCRIPCION"
                Me.cmb_locales.ValueMember = "CODIGO"
            End If
        Catch ex As Exception
        Finally
            oTransaccion.close()
            oTransaccion = Nothing

        End Try
    End Sub

    Private Sub frm_quitar_facturas_guia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
    End Sub

    Private Sub Buscar_Documento()
        Dim ls_Sql As String
        Dim dt, dtaux As DataTable

        Dim clGen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")

        Try
            oTrans.open()

            Me.txt_factura.ReadOnly = True
            Me.cmb_tipos.Enabled = False
            If Me.cmb_tipos.Text.ToLower.StartsWith("face") Or Me.cmb_tipos.Text.ToLower.StartsWith("fel") Then

            Else
                Me.txt_factura.Text = Me.txt_factura.Text.PadLeft(10, "0")
            End If

            ls_Sql = "pa_sel_um_documentod_tiendas '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'"
            dt = oTrans.Obtiene(ls_Sql)
            ls_Sql = ""
            dt_detalle_documento = dt

            Try
                If dt.Rows.Count > 0 Then
                    dtaux = clGen.ValoresDistinto(dt, "razonSocial".Split(","))

                    Me.cmbProveedor.DataSource = dtaux
                    Me.cmbProveedor.DisplayMember = "razonSocial"
                    Me.cmbProveedor.ValueMember = "razonSocial"

                    'If dtaux.Rows.Count > 1 Then
                    '    Dim oform As New ClasesGenerales.frm_seleccionar_opcion
                    '    oform.cmb_listado.DataSource = dtaux

                    '    oform.cmb_listado.DisplayMember = "razonSocial"
                    '    oform.cmb_listado.ValueMember = "razonSocial"
                    '    oform.Text = "Seleccione un Proveedor"
                    '    oform.ShowDialog()
                    '    ls_Sql = oform.cmb_listado.SelectedValue
                    '    oform.Dispose()
                    '    oform = Nothing
                    '    dt.DefaultView.RowFilter = "razonSocial = '" & ls_Sql & "'"
                    '    dt = dt.DefaultView.ToTable

                    'End If
                End If

            Catch ex As Exception

            End Try

            Try
                pdataset.Reset()
            Catch ex As Exception
            End Try

            dt.TableName = "detalle_documento"
            pdataset.Tables.Add(dt.Copy)
            If Me.cmbProveedor.Visible = False Then


                Dim dr As DataRow = dt.Rows(0)

                Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")
                Me.SBP_Panel3.Text = "Numero de Lineas .: " & dt.Rows.Count.ToString
                Me.SBP_panelMedio.Text = "Unidades = " & dt.Compute("sum(_unidades)", "_unidades > 0")

                Me.txt_fecha.Text = dt.Rows(0).Item("FECHA")
                clGen.Alinea_Grid(pdataset.Tables("detalle_documento"), Me.DataGrid1, pdataset.Tables("detalle_documento").TableName, -1, 300, 40, False, True, ",Producto,glosa,_unidades, _valores", True, "")

                ls_Sql = "pa_var_um_documento '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
                dt = oTrans.Obtiene(ls_Sql)
                dt.TableName = "encabezado_documento"
                pdataset.Tables.Add(dt.Copy)
                Me.txt_codcliente.Text = dt.Rows(0).Item("cliente")
                Me.txt_piloto.Text = dt.Rows(0).Item("razonsocial").ToString.Trim
                If Me.txt_codcliente.Text.Length = 0 Then
                    Me.txt_codcliente.Text = dr.Item("proveedor").ToString
                    Me.txt_piloto.Text = dr.Item("razonSocial").ToString
                End If
                Me.txt_glosa.Text = dt.Rows(0).Item("glosa")
                Me.SBP_panel1.Text = "Usuario Grabo .:: " & dt.Rows(0).Item("UsuarioModif")

                'Obtengo DocumentoV
                ls_Sql = "pa_var_um_documentov '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
                dt = oTrans.Obtiene(ls_Sql)
                dt.TableName = "documentov"
                pdataset.Tables.Add(dt.Copy)

                'Obtengo DocumentoP
                ls_Sql = "pa_var_um_documentop '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
                dt = oTrans.Obtiene(ls_Sql)
                dt.TableName = "documentop"
                pdataset.Tables.Add(dt.Copy)
            End If


            If Me.cmb_tipos.Text = "SALIDA DE BODEGA" Or Me.cmb_tipos.Text = "SALIDA DE BODEGA CD" Or Me.cmb_tipos.Text = "SALIDA BODEGA CD" Then


                Dim dr As DataRow = dt.Rows(0)

                Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")
                Me.SBP_Panel3.Text = "Numero de Lineas .: " & dt.Rows.Count.ToString
                Me.SBP_panelMedio.Text = "Unidades = " & dt.Compute("sum(_unidades)", "_unidades > 0")

                Me.txt_fecha.Text = dt.Rows(0).Item("FECHA")
                clGen.Alinea_Grid(pdataset.Tables("detalle_documento"), Me.DataGrid1, pdataset.Tables("detalle_documento").TableName, -1, 300, 40, False, True, ",Producto,glosa,_unidades, _valores", True, "")

                ls_Sql = "pa_var_um_documento '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
                dt = oTrans.Obtiene(ls_Sql)
                dt.TableName = "encabezado_documento"
                pdataset.Tables.Add(dt.Copy)
                Me.txt_codcliente.Text = dt.Rows(0).Item("cliente")
                Me.txt_piloto.Text = dt.Rows(0).Item("razonsocial").ToString.Trim
                If Me.txt_codcliente.Text.Length = 0 Then
                    Me.txt_codcliente.Text = dr.Item("proveedor").ToString
                    Me.txt_piloto.Text = dr.Item("razonSocial").ToString
                End If
                Me.txt_glosa.Text = dt.Rows(0).Item("glosa")
                Me.SBP_panel1.Text = "Usuario Grabo .:: " & dt.Rows(0).Item("UsuarioModif")

                'Obtengo DocumentoV
                ls_Sql = "pa_var_um_documentov '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
                dt = oTrans.Obtiene(ls_Sql)
                dt.TableName = "documentov"
                pdataset.Tables.Add(dt.Copy)

                'Obtengo DocumentoP
                ls_Sql = "pa_var_um_documentop '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
                dt = oTrans.Obtiene(ls_Sql)
                dt.TableName = "documentop"
                pdataset.Tables.Add(dt.Copy)
            End If

        Catch ex As Exception
            MessageBox.Show("Problemas En Busqueda", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmb_tipos.Enabled = True
            Me.txt_factura.ReadOnly = False
        Finally
            oTrans.close()
            oTrans = Nothing
            clGen = Nothing
        End Try

    End Sub

    Private Sub obtenerInformacionFactura()

        Dim dt As DataTable = pdataset.Tables("detalle_documento")
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("FlexLine")

        If pdataset.Tables.IndexOf("encabezado_documento") > 0 Then
            pdataset.Tables.Remove("encabezado_documento")
        End If
        If pdataset.Tables.IndexOf("documentov") > 0 Then
            pdataset.Tables.Remove("documentov")
        End If
        If pdataset.Tables.IndexOf("documentop") > 0 Then
            pdataset.Tables.Remove("documentop")
        End If

        Try


            oTrans.open()


            dt.DefaultView.RowFilter = "razonSocial = '" & Me.cmbProveedor.SelectedValue.ToString & "'"
            dt = dt.DefaultView.ToTable
            Dim dr As DataRow = dt.Rows(0)

            Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")

            dt_detalle_documento = dt



            Me.SBP_Panel3.Text = "Numero de Lineas .: " & dt.Rows.Count.ToString
            Me.SBP_panelMedio.Text = "Unidades = " & dt.Compute("sum(_unidades)", "_unidades > 0")

            Me.txt_fecha.Text = dt.Rows(0).Item("FECHA")
            clsGen.Alinea_Grid(pdataset.Tables("detalle_documento"), Me.DataGrid1, pdataset.Tables("detalle_documento").TableName, -1, 300, 40, False, True, ",Producto,glosa,_unidades, _valores", True, "")

            lsSQL = "pa_var_um_documento '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
            dt = oTrans.Obtiene(lsSQL)
            dt.TableName = "encabezado_documento"
            pdataset.Tables.Add(dt.Copy)
            Me.txt_codcliente.Text = dt.Rows(0).Item("cliente")
            Me.txt_piloto.Text = dt.Rows(0).Item("razonsocial").ToString.Trim
            If Me.txt_codcliente.Text.Length = 0 Then
                Me.txt_codcliente.Text = dr.Item("proveedor").ToString
                Me.txt_piloto.Text = dr.Item("razonSocial").ToString
            End If
            Me.txt_glosa.Text = dt.Rows(0).Item("glosa")
            Me.SBP_panel1.Text = "Usuario Grabo .:: " & dt.Rows(0).Item("UsuarioModif")

            'Obtengo DocumentoV
            lsSQL = "pa_var_um_documentov '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
            dt = oTrans.Obtiene(lsSQL)
            dt.TableName = "documentov"
            pdataset.Tables.Add(dt.Copy)

            'Obtengo DocumentoP
            lsSQL = "pa_var_um_documentop '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "'," & dr.Item("correlativo")
            dt = oTrans.Obtiene(lsSQL)
            dt.TableName = "documentop"
            pdataset.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            clsGen = Nothing
            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub

    Private Sub txt_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_factura.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.txt_factura.Text.Length > 0 Then
                Buscar_Documento()
            End If
        End If
    End Sub


    Private Sub txt_guia_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura.LostFocus

    End Sub

    Private Sub Limpiar_Forma()
        pdataset.Reset()
        Me.cmb_tipos.Enabled = True
        Me.txt_fecha.Text = ""
        Me.txt_factura.Text = ""
        Me.txt_piloto.Text = ""
        Me.txt_codcliente.Text = ""
        Me.txt_glosa.Text = ""
        Me.cmbProveedor.DataSource = Nothing

        Me.Refresh()
        Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")
        Me.txt_factura.ReadOnly = False
        Me.txt_factura.Focus()
    End Sub


    Private Sub Mover_Archivos_Receive_Mr_Red(psLocal As String)
        Dim clsGen As New ClasesGenerales.General

        Dim Archivos As String()
        Dim Ruta_Archivos As String
        Dim strDir As String
        Dim ArchivoDestino As String
        Dim dt As DataTable
        Dim lsSQL As String
        Dim drv As DataRowView



        Dim lsRutaRed As String
        Dim archivosXML As String()
        Try




            lsRutaRed = "\\172.19.1.100\c$\FTP\" & psLocal & "\Receive\"
            Ruta_Archivos = "c:\aplicaciones\kiosco\" & psLocal & "\Receive"
            archivosXML = Directory.GetFiles(Ruta_Archivos, "*.xml")

            For Each archivoXML As String In archivosXML
                clsGen.Escribir_Log("Upload " & archivoXML)
                If Not clsGen.Mover_Archivo(archivoXML, lsRutaRed & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1)) Then
                    clsGen.Escribir_Log("No se Pudo Mover hacia " & lsRutaRed & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
                End If

                'clsGen.Escribir_Log("Upload " & archivoXML)
            Next


        Catch ex As Exception
            clsGen.Escribir_Log("Upload " & ex.ToString)
            clsGen.Escribir_Log("Upload " & ex.Message)

        End Try
        clsGen = Nothing
    End Sub


    Private Sub Enviar_Documento()

        If Me.cmb_locales.SelectedValue.ToString.IndexOf("KC") > 0 Then 'Kioskos que 

            Try


                Dim odsEnvio As New DataSet("Envio")
                odsEnvio.Tables.Add(dt_detalle_documento.Copy)
                odsEnvio.Tables.Add(pdataset.Tables("documentov").Copy)
                odsEnvio.Tables.Add(pdataset.Tables("documentop").Copy)

                odsEnvio.Tables.Add(pdataset.Tables("encabezado_documento").Copy)

                Dim lsRuta As String = "c:\aplicaciones\kiosco\" & Me.cmb_locales.SelectedValue.ToString & "\Receive\" &
                    pdataset.Tables("encabezado_documento").Rows(0).Item("tipodocto").ToString & "_" &
                    pdataset.Tables("encabezado_documento").Rows(0).Item("numero").ToString & ".xml"

                odsEnvio.WriteXml(lsRuta, XmlWriteMode.WriteSchema)

                ''Enviar por FTP
                Mover_Archivos_Receive_Mr_Red(Me.cmb_locales.SelectedValue.ToString.ToLower)

            Catch ex As Exception

            End Try



        Else

            '' (c) 20210616 no permitir la sincronizacion de documentos mayores a 45 dias
            '' todas las tiendas a excepcion de zona 14 y zona 10 Marvin indicará cuando

            Dim lbContinuar As Boolean = False
            If gs_empresa = "VINOTECA" Then
                ' If pdataset.Tables("encabezado_documento").Rows(0).Item("Bodega").ToString.PadLeft(4) = "SV10" Or
                'If pdataset.Tables("encabezado_documento").Rows(0).Item("Bodega").ToString.PadLeft(4) = "SV14" Then
                'lbContinuar = True
                'Else

                If pdataset.Tables("encabezado_documento").Rows(0).Item("fecha") > Today.AddDays(-45) Then
                        lbContinuar = True
                    Else
                        MessageBox.Show("No se Pueden Sincronizar Documentos Mayores a 45 Dias", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                'End If
            Else
                lbContinuar = True
            End If


            If lbContinuar Then



                Dim oScn As New Sincronizacion.Documentos(Me.cmb_locales.SelectedValue)
                Try
                    If oScn.codigo_error > 0 Then
                        MessageBox.Show(oScn.descripcion_error, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        MessageBox.Show("Se Calendariza la Sincronización, Recibira un Aviso en TEAMS cuando se procese", "Programacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '


                    Else

                        oScn.Enviar_Documento_Tienda(gs_empresa, pdataset.Tables("encabezado_documento").Rows(0),
                                             dt_detalle_documento, pdataset.Tables("documentov"), pdataset.Tables("documentop"), "", True)

                        If oScn.codigo_error > 0 Then
                            MessageBox.Show(oScn.descripcion_error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else

                            ''Enviar ctacte
                            ''(c) 20211022
                            Try
                                Dim clsGen As New ClasesGenerales.General
                                Dim oSincclientes As New Sincronizacion.Clientes(Me.cmb_locales.SelectedValue)

                                oSincclientes.Obtener_Ctacte(gs_empresa, Me.txt_codcliente.Text, "PROVEEDOR")
                                If oSincclientes.dt.Rows.Count = 0 Then
                                    ''Necesito enviar proveedor

                                    Dim dtCliente, dtClienteDirecciones, dtClienteGentabcod As DataTable
                                    Dim lsSQL As String
                                    lsSQL = "pa_var_um_ctacte_traslado '" & gs_empresa & "','PROVEEDOR','" & Me.txt_codcliente.Text & "'"
                                    dtCliente = clsGen.selectQuery("FlexLine", lsSQL)
                                    lsSQL = "pa_var_um_ctactedirecciones_traslado '" & gs_empresa & "','PROVEEDOR','" & Me.txt_codcliente.Text & "'"
                                    dtClienteDirecciones = clsGen.selectQuery("FlexLine", lsSQL)
                                    lsSQL = "pa_var_um_ctactegentabcod_traslado '" & gs_empresa & "','PROVEEDOR','" & Me.txt_codcliente.Text & "'"
                                    dtClienteGentabcod = clsGen.selectQuery("FlexLine", lsSQL)
                                    oSincclientes.envia_ctacte(dtCliente.Rows(0), dtClienteDirecciones, dtClienteGentabcod)

                                    clsGen = Nothing
                                    oSincclientes = Nothing
                                End If

                            Catch ex As Exception

                            End Try



                            MessageBox.Show("Sincronizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Limpiar_Forma()
                        End If
                    End If

                Catch ex As Exception
                Finally
                    oScn.Cerrar()
                    oScn = Nothing
                End Try
            End If
        End If
    End Sub

    Private Sub cmb_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_liberar.Click
        If MessageBox.Show("Esta Seguro De Enviar Este Documento", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Enviar_Documento()
        End If

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Limpiar_Forma()
    End Sub

    Private Sub txt_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura.TextChanged

    End Sub

    Private Sub cmb_tipos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipos.SelectedIndexChanged

    End Sub

    Private Sub cmb_tipos_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_tipos.SelectionChangeCommitted
        'Try

        '    If Me.cmb_tipos.SelectedValue.ToString.ToLower.LastIndexOf("fact") > -1 Then
        '        Me.cmbProveedor.Visible = True
        '        Me.btnObtener.Visible = True
        '    Else
        '        Me.cmbProveedor.Visible = False
        '        Me.btnObtener.Visible = False

        '    End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub btnObtener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtener.Click
        obtenerInformacionFactura()
    End Sub

    Private Sub cmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedor.SelectedIndexChanged

    End Sub
End Class
