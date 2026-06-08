Imports System.Management
Imports System.IO
Imports System.Net
Imports Microsoft.Office.Interop
Imports System.Text
Imports External
Public Class frm_pedidos_pendientes
    Inherits System.Windows.Forms.Form
    Dim oDataSet As New DataSet
    Dim ods As DataSet
    Friend WithEvents btnAprobarBatch As Button
    Friend WithEvents ImageList1 As ImageList
    Dim ods_listado As DataSet

    Private Sub crear_estructura()
        Dim dt2 As DataTable


        ods_listado = New DataSet
        dt2 = New DataTable("listado")
        dt2.Columns.Add(New DataColumn("producto", GetType(String)))
        dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt2.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt2.Columns.Add(New DataColumn("stockminimo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("stockmaximo", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Existencia", GetType(String)))
        dt2.Columns.Add(New DataColumn("ExistenciaCD", GetType(String)))
        dt2.Columns.Add(New DataColumn("Sugerido", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Sugerido_original", GetType(Integer)))
        dt2.Columns.Add(New DataColumn("Comprar", GetType(Boolean)))
        dt2.Columns.Add(New DataColumn("valor", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt2.Columns.Add(New DataColumn("grupo", GetType(Integer)))
        ods_listado.Tables.Add(dt2)
    End Sub
    Private Sub crear_estructura_auxiliar()
        Dim ls_sql As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dt As DataTable

        Try
            Otrans.open()
            If Not ods.Tables.Contains("documento") Then

                ls_sql = "pa_var_um_documento_traslado_fecha '" & gs_empresa & "',NULL,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)

                dt.TableName = "documento"
                If ods.Tables.Contains("documento") Then
                    ods.Tables.Remove("documento")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documento").Rows.Clear()
            End If


            ''documentod
            If Not ods.Tables.Contains("documentod") Then
                ls_sql = "pa_var_um_documentod_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentod"
                If ods.Tables.Contains("documentod") Then
                    ods.Tables.Remove("documentod")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentod").Rows.Clear()
            End If


            ''documentov
            If Not ods.Tables.Contains("documentov") Then
                ls_sql = "pa_var_um_documentov_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentov"
                If ods.Tables.Contains("documentov") Then
                    ods.Tables.Remove("documentov")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentov").Rows.Clear()
            End If

            ''documentop
            If Not ods.Tables.Contains("documentop") Then
                ls_sql = "pa_var_um_documentop_traslado_fecha '" & gs_empresa & "',null,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentop"
                If ods.Tables.Contains("documentop") Then
                    ods.Tables.Remove("documentop")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentop").Rows.Clear()
            End If

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub

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
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btn_Estado_Cuenta As System.Windows.Forms.Button
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents txt_comentario As System.Windows.Forms.TextBox
    Friend WithEvents cmb_estados As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_comentarios_cliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_total_pedido As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_condicion As System.Windows.Forms.TextBox
    Friend WithEvents txt_vigencia_cliente As System.Windows.Forms.TextBox
    Friend WithEvents dgv_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_limite_credito As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pedidos_pendientes))
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_final = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Btn_Estado_Cuenta = New System.Windows.Forms.Button()
        Me.txt_comentario = New System.Windows.Forms.TextBox()
        Me.cmb_estados = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_comentarios_cliente = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAprobarBatch = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_condicion = New System.Windows.Forms.TextBox()
        Me.txt_vigencia_cliente = New System.Windows.Forms.TextBox()
        Me.txt_limite_credito = New System.Windows.Forms.TextBox()
        Me.txt_total_pedido = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgv_detalle = New System.Windows.Forms.DataGridView()
        Me.dgv_pedidos = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(56, 8)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fecha_inicio.TabIndex = 2
        '
        'dtp_fecha_final
        '
        Me.dtp_fecha_final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final.Location = New System.Drawing.Point(184, 8)
        Me.dtp_fecha_final.Name = "dtp_fecha_final"
        Me.dtp_fecha_final.Size = New System.Drawing.Size(88, 21)
        Me.dtp_fecha_final.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Del"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(160, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Al"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Buscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Buscar.ForeColor = System.Drawing.Color.White
        Me.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Buscar.ImageKey = "Smart-FTP-icon.png"
        Me.Btn_Buscar.ImageList = Me.ImageList1
        Me.Btn_Buscar.Location = New System.Drawing.Point(296, 8)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(98, 39)
        Me.Btn_Buscar.TabIndex = 6
        Me.Btn_Buscar.Text = "Buscar"
        Me.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Text-Edit-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "Smart-FTP-icon.png")
        Me.ImageList1.Images.SetKeyName(2, "refresh.jpg")
        Me.ImageList1.Images.SetKeyName(3, "1286295506_Process-Accept.png")
        Me.ImageList1.Images.SetKeyName(4, "printer_48.png")
        Me.ImageList1.Images.SetKeyName(5, "cut_from_page.ico")
        '
        'Btn_Estado_Cuenta
        '
        Me.Btn_Estado_Cuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Estado_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Estado_Cuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Estado_Cuenta.ForeColor = System.Drawing.Color.White
        Me.Btn_Estado_Cuenta.Location = New System.Drawing.Point(799, 1)
        Me.Btn_Estado_Cuenta.Name = "Btn_Estado_Cuenta"
        Me.Btn_Estado_Cuenta.Size = New System.Drawing.Size(105, 51)
        Me.Btn_Estado_Cuenta.TabIndex = 7
        Me.Btn_Estado_Cuenta.Text = "Est. de Cuenta Individual"
        Me.Btn_Estado_Cuenta.UseVisualStyleBackColor = False
        '
        'txt_comentario
        '
        Me.txt_comentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_comentario.Location = New System.Drawing.Point(72, 40)
        Me.txt_comentario.Multiline = True
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentario.Size = New System.Drawing.Size(376, 72)
        Me.txt_comentario.TabIndex = 8
        '
        'cmb_estados
        '
        Me.cmb_estados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb_estados.DisplayMember = "cds"
        Me.cmb_estados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estados.Location = New System.Drawing.Point(72, 16)
        Me.cmb_estados.Name = "cmb_estados"
        Me.cmb_estados.Size = New System.Drawing.Size(304, 21)
        Me.cmb_estados.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Resolucion"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Guardar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Guardar.ForeColor = System.Drawing.Color.White
        Me.Btn_Guardar.Location = New System.Drawing.Point(482, 16)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Guardar.TabIndex = 11
        Me.Btn_Guardar.Text = "Aceptar"
        Me.Btn_Guardar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(8, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Comentario Pedido"
        '
        'txt_comentarios_cliente
        '
        Me.txt_comentarios_cliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_comentarios_cliente.Location = New System.Drawing.Point(72, 64)
        Me.txt_comentarios_cliente.Multiline = True
        Me.txt_comentarios_cliente.Name = "txt_comentarios_cliente"
        Me.txt_comentarios_cliente.ReadOnly = True
        Me.txt_comentarios_cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_comentarios_cliente.Size = New System.Drawing.Size(272, 72)
        Me.txt_comentarios_cliente.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(8, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Comentario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnAprobarBatch)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_comentario)
        Me.GroupBox1.Controls.Add(Me.cmb_estados)
        Me.GroupBox1.Controls.Add(Me.Btn_Guardar)
        Me.GroupBox1.Location = New System.Drawing.Point(366, 472)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 120)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'btnAprobarBatch
        '
        Me.btnAprobarBatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAprobarBatch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAprobarBatch.ForeColor = System.Drawing.Color.White
        Me.btnAprobarBatch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAprobarBatch.ImageIndex = 2
        Me.btnAprobarBatch.ImageList = Me.ImageList1
        Me.btnAprobarBatch.Location = New System.Drawing.Point(464, 45)
        Me.btnAprobarBatch.Name = "btnAprobarBatch"
        Me.btnAprobarBatch.Size = New System.Drawing.Size(88, 67)
        Me.btnAprobarBatch.TabIndex = 13
        Me.btnAprobarBatch.Text = "Aprobar Batch"
        Me.btnAprobarBatch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAprobarBatch.UseVisualStyleBackColor = False
        Me.btnAprobarBatch.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_condicion)
        Me.GroupBox2.Controls.Add(Me.txt_vigencia_cliente)
        Me.GroupBox2.Controls.Add(Me.txt_limite_credito)
        Me.GroupBox2.Controls.Add(Me.txt_comentarios_cliente)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(8, 448)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 144)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion de Cliente"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Condicion"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Lim. Credito"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(176, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Vigencia"
        '
        'txt_condicion
        '
        Me.txt_condicion.Location = New System.Drawing.Point(72, 40)
        Me.txt_condicion.Name = "txt_condicion"
        Me.txt_condicion.ReadOnly = True
        Me.txt_condicion.Size = New System.Drawing.Size(272, 21)
        Me.txt_condicion.TabIndex = 17
        '
        'txt_vigencia_cliente
        '
        Me.txt_vigencia_cliente.Location = New System.Drawing.Point(264, 14)
        Me.txt_vigencia_cliente.Name = "txt_vigencia_cliente"
        Me.txt_vigencia_cliente.ReadOnly = True
        Me.txt_vigencia_cliente.Size = New System.Drawing.Size(80, 21)
        Me.txt_vigencia_cliente.TabIndex = 16
        '
        'txt_limite_credito
        '
        Me.txt_limite_credito.Location = New System.Drawing.Point(72, 16)
        Me.txt_limite_credito.Name = "txt_limite_credito"
        Me.txt_limite_credito.ReadOnly = True
        Me.txt_limite_credito.Size = New System.Drawing.Size(80, 21)
        Me.txt_limite_credito.TabIndex = 15
        Me.txt_limite_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_pedido
        '
        Me.txt_total_pedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_pedido.Location = New System.Drawing.Point(833, 448)
        Me.txt_total_pedido.Name = "txt_total_pedido"
        Me.txt_total_pedido.ReadOnly = True
        Me.txt_total_pedido.Size = New System.Drawing.Size(120, 21)
        Me.txt_total_pedido.TabIndex = 17
        Me.txt_total_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(729, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Total de Pedido"
        '
        'dgv_detalle
        '
        Me.dgv_detalle.AllowUserToAddRows = False
        Me.dgv_detalle.AllowUserToDeleteRows = False
        Me.dgv_detalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalle.Location = New System.Drawing.Point(4, 277)
        Me.dgv_detalle.Name = "dgv_detalle"
        Me.dgv_detalle.ReadOnly = True
        Me.dgv_detalle.RowHeadersWidth = 20
        Me.dgv_detalle.Size = New System.Drawing.Size(949, 164)
        Me.dgv_detalle.TabIndex = 19
        '
        'dgv_pedidos
        '
        Me.dgv_pedidos.AllowUserToAddRows = False
        Me.dgv_pedidos.AllowUserToDeleteRows = False
        Me.dgv_pedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedidos.Location = New System.Drawing.Point(4, 53)
        Me.dgv_pedidos.Name = "dgv_pedidos"
        Me.dgv_pedidos.ReadOnly = True
        Me.dgv_pedidos.RowHeadersWidth = 25
        Me.dgv_pedidos.Size = New System.Drawing.Size(949, 222)
        Me.dgv_pedidos.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(650, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 51)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Est. de Cuenta Corporativo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frm_pedidos_pendientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(962, 598)
        Me.Controls.Add(Me.dgv_pedidos)
        Me.Controls.Add(Me.dgv_detalle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_total_pedido)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Btn_Estado_Cuenta)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_fecha_final)
        Me.Controls.Add(Me.dtp_fecha_inicio)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_pedidos_pendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pedidos Pendientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar.Click
        Pedidos_Pendientes()
        Crear_Bindings()
    End Sub


    Private Sub Pedidos_Pendientes()
        Dim oTrans As Transaccional.Conexion
        Dim clGen As New ClasesGenerales.General
        Dim oTabla As DataTable
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim ls_filtro As String


        Dim ls_sqltxt As String
        oDataSet = New DataSet
        Limpiar_Bindings()

        ls_sqltxt = "pa_var_um_pedidos_pendientes_aprobacion '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'"

        oTrans = New Transaccional.Conexion("flexline")

        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "pedidos"
            oDataSet.Tables.Add(oTabla.Copy)


            ''Armar_Filtro
            ls_sqltxt = "pa_sel_um_gen_tabcod NULL,'GEN_LIBERADOR_PEDIDO',NULL"
            dt = oTrans.Obtiene(ls_sqltxt)

            dt.DefaultView.RowFilter = "CODIGO = '" & gs_usuario & "'"
            ls_filtro = ""
            For Each drv In dt.DefaultView
                ls_filtro += IIf(ls_filtro.Length > 0, " OR ", "") & "(Empresa = '" & drv.Item("EMPRESA") & "' AND (AnalisisCtaCte6 = '" & drv.Item("TEXTO") & "' "
                If drv.Item("TEXTO1").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte6 = '" & drv.Item("TEXTO1") & "'"
                If drv.Item("TEXTO2").ToString.Length > 0 Then ls_filtro += " OR  AnalisisCtaCte6 = '" & drv.Item("TEXTO2") & "'"
                ls_filtro += "))"
            Next

            oDataSet.Tables("pedidos").DefaultView.RowFilter = ls_filtro
            Me.dgv_pedidos.DataSource = oDataSet.Tables("pedidos").DefaultView
            'clGen.Alinea_Grid(oDataSet.Tables("pedidos"), Me.dg_pedidos, oDataSet.Tables("pedidos").TableName, 3, 150, 0, False, True, "")
            clGen.Alinear_GridView(oDataSet.Tables("pedidos"), dgv_pedidos, "", ",limitecredito,vigencia_cliente,comentario_cliente,aprobacion,", "", "", "", "", "", True, True, 150, 0)
            'Me.Colorear_Grid()

            ls_sqltxt = "pa_var_um_detalle_pedidos_pendientes '" & Me.dtp_fecha_inicio.Text & "','" & Me.dtp_fecha_final.Text & "'"
            oTabla = oTrans.Obtiene(ls_sqltxt)
            oTabla.TableName = "detalle_pedidos"

            oDataSet.Tables.Add(oTabla.Copy)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        oTrans.close()
        oTrans = Nothing
        clGen = Nothing

        Try
            detalle_pedido(0)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub detalle_pedido(ByVal pi_RowNumber As Integer)

        'Dim ls_resultado As String
        Dim clgen As New ClasesGenerales.General

        'ls_resultado = Me.dg_pedidos.Item(pi_RowNumber, 3)

        oDataSet.Tables("detalle_pedidos").DefaultView.RowFilter = "numero = '" & dgv_pedidos.Item("numero", pi_RowNumber).Value &
                                                             "' and tipodocto  = '" &
                                                            dgv_pedidos.Item("tipodocto", pi_RowNumber).Value &
                                                            "' and empresa = '" & dgv_pedidos.Item("empresa", pi_RowNumber).Value & "'"

        Me.dgv_detalle.DataSource = oDataSet.Tables("detalle_pedidos")
        Me.dgv_pedidos.Refresh()

        clgen.Alinear_GridView(oDataSet.Tables("detalle_pedidos"), dgv_detalle, "", "", "", "", "", "", "", True, True, 200, 0)



        clgen = Nothing

    End Sub

    Private Sub generar_estado_de_cuenta(ByVal ps_codigo_cliente As String, ByVal ps_empresa As String)


        Dim path_reporte As String

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim fecha2 As String
        Dim dt As DataTable

        Dim fecha As Date
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            pm_conexion = ClsGen.Parametros_Conexion("VDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            Otrans.open()


            ''Aplico Seguridad
            ''Levanto el estado de cuenta
            ''Cargo el Reporte
            fecha = Format(Today, "d")
            fecha2 = fecha.ToShortDateString


            ReDim pm_parametros(3)
            ReDim pm_valores(3)
            pm_parametros(0) = "@cliente"
            pm_parametros(1) = "@empresa"
            pm_parametros(2) = "@fechaf"
            pm_valores(2) = fecha2
            pm_valores(0) = ps_codigo_cliente
            pm_valores(1) = ps_empresa


            ls_sql = "pa_sel_um_gen_tabcod null,'GEN_ESTADO_CTA','" & ps_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            Otrans.close()
            Otrans = Nothing

            If dt.Rows.Count = 1 Then

                path_reporte += dt.Rows(0).Item("Descripcion").ToString.Trim &
                                dt.Rows(0).Item("nemotecnico").ToString.Trim



            End If

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                        False, False, "PDF", True, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub generar_estado_de_cuentaCorporativo(ByVal ps_codigo_cliente As String, ByVal ps_empresa As String)


        Dim path_reporte As String

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim fecha2 As String
        Dim dt As DataTable

        Dim fecha As Date
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            pm_conexion = ClsGen.Parametros_Conexion("VDATASERVER")
            path_reporte = ClsGen.Path_Reporte()
            Otrans.open()


            ''Aplico Seguridad
            ''Levanto el estado de cuenta
            ''Cargo el Reporte
            fecha = Format(Today, "d")
            fecha2 = fecha.ToShortDateString


            ReDim pm_parametros(2)
            ReDim pm_valores(2)
            pm_parametros(0) = "@cliente"
            pm_parametros(1) = "@fechaf"
            pm_valores(1) = fecha2
            pm_valores(0) = ps_codigo_cliente



            ls_sql = "pa_sel_um_gen_tabcod null,'GEN_ESTADO_CTA','" & ps_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            Otrans.close()
            Otrans = Nothing

            If dt.Rows.Count = 1 Then

                path_reporte += dt.Rows(0).Item("Texto").ToString.Trim &
                                dt.Rows(0).Item("Texto2").ToString.Trim &
                                dt.Rows(0).Item("nemotecnico").ToString.Trim()



            End If

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                        False, False, "PDF", True, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub generar_estado_de_cuenta_Consignaciones(ByVal ps_codigo_cliente As String, ByVal ps_empresa As String)


        Dim path_reporte As String

        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim fecha2 As String
        Dim dt As DataTable
        Dim fecha As Date
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            otrans.open()
            pm_conexion = ClsGen.Parametros_Conexion("")
            path_reporte = ClsGen.Path_Reporte()


            ''Aplico Seguridad
            ''Levanto el estado de cuenta
            ''Cargo el Reporte
            fecha = Format(Today, "d")
            fecha2 = fecha.ToShortDateString

            'If ps_empresa = "DMARTE1" Or _
            '   ps_empresa = "CODICASA" Or _
            '   ps_empresa = "ALAMSA" Then
            ReDim pm_parametros(4)
            ReDim pm_valores(4)
            pm_parametros(0) = "Analisis"
            pm_parametros(2) = "cliente"
            pm_parametros(3) = "@empresa"
            pm_parametros(1) = "@fechaf"
            pm_valores(0) = "RESUMIDO"
            pm_valores(1) = fecha2
            pm_valores(2) = ps_codigo_cliente & "," & ps_codigo_cliente
            pm_valores(3) = ps_empresa

            ls_sql = "pa_sel_um_gen_tabcod null,'GEN_ESTADO_CTA','" & ps_empresa & "'"
            dt = otrans.Obtiene(ls_sql)
            otrans.close()
            otrans = Nothing

            If dt.Rows.Count = 1 Then

                path_reporte += dt.Rows(0).Item("texto").ToString.Trim &
                                dt.Rows(0).Item("texto1").ToString.Trim



            End If

            'Else
            '    pm_parametros(0) = "a la fecha"
            '    pm_parametros(1) = "cliente"
            '    pm_valores(0) = fecha2
            '    pm_valores(1) = ps_codigo_cliente

            'End If

            ' path_reporte += "Finanzas\Creditos\Jefatura\Balance de Antiguedad Consignaciones por Cliente.rpt"


            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                                        pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                        False, False, "PDF", False, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Function fdMontoMaximoAprobacion_empresa(ByVal psEmpresa As String) As Decimal
        Dim dt As DataTable
        Dim lsSQL As String
        Dim clsGen As New ClasesGenerales.General


        Dim ldMontoMaximoAprobacion As Decimal = 0.0D

        Try
            lsSQL = "pa_var_um_sg_usuario_monto_maximo_aprobacion '" & psEmpresa & "','" & gs_usuario & "'"
            dt = clsGen.selectQuery("FlexLine", lsSQL)
            ldMontoMaximoAprobacion = dt.Rows(0).Item("monto_maximo_aprobacion").ToString
            If Not IsNumeric(ldMontoMaximoAprobacion) Then
                ldMontoMaximoAprobacion = 0.0D
            End If
        Catch ex As System.Data.SqlClient.SqlException
            'MessageBox.Show("Error al obtener el monto maximo de aprobacion: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ldMontoMaximoAprobacion = 0.0D
        Catch ex As Exception

        End Try



        Return ldMontoMaximoAprobacion

    End Function


    Private Sub Guardar_Cambios()

        Dim li_row_number As Integer
        Dim ls_sql As String
        Dim HacerEnvio As Boolean = False
        Dim dtCorreo As DataTable
        Dim sNumero, sTipodocto, sEmpresa As String
        Dim dr As DataRow

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General

        Dim dtAvisos As DataTable
        li_row_number = Me.dgv_pedidos.CurrentRow.Index

        Dim lsEmpresa, lsTipodocto, lsNumero As String
        Dim ldMontoMaximoAprobacion As Decimal = fdMontoMaximoAprobacion_empresa(dgv_pedidos.Item("empresa", li_row_number).Value)

        Try


            If Double.Parse(Me.txt_total_pedido.Text) > ldMontoMaximoAprobacion Then
                MessageBox.Show("El Pedido Supera El Monto Maximo de Aprobación Asignado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Catch ex As Exception

        End Try


        Try



            otrans.open()

            sTipodocto = dgv_pedidos.Item("tipodocto", li_row_number).Value
            sNumero = dgv_pedidos.Item("numero", li_row_number).Value
            sEmpresa = dgv_pedidos.Item("empresa", li_row_number).Value

            dt = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & sEmpresa & "','" & sTipodocto & "','" & sNumero & "'")

            'Validar estado del pedido
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)

                If dr.Item("Aprobacion").ToString <> dgv_pedidos.Item("status_pedido", li_row_number).Value Then
                    MessageBox.Show("El Pedido Fue Actualizado Por Otro Usuario", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If


            ls_sql = "pa_sel_um_ctacte '" & dgv_pedidos.Item("empresa", li_row_number).Value & "','CLIENTE','" &
                                        dgv_pedidos.Item("cliente", li_row_number).Value & "'"
            dt = otrans.Obtiene(ls_sql)



            ls_sql = "pa_upd_um_documento_estado '" & dgv_pedidos.Item("empresa", li_row_number).Value & "','" &
                            dgv_pedidos.Item("tipodocto", li_row_number).Value & "','" &
                            dgv_pedidos.Item("numero", li_row_number).Value & "','" &
                            Me.txt_comentario.Text & "','" & Me.cmb_estados.SelectedValue & "','" & gs_usuario & "'"

            otrans.Actualiza(ls_sql)
            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Proceso Realizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If Me.cmb_estados.SelectedValue = "S" Then  '--And dt.Rows(0).Item("Analisisctacte6").ToString.Length = 0 And
                    If dgv_pedidos.Item("fecha", li_row_number).Value <> Today Then

                        enviarAvisoTeams(dgv_pedidos.Item("empresa", li_row_number).Value,
                                                              dgv_pedidos.Item("tipodocto", li_row_number).Value,
                                                              dgv_pedidos.Item("numero", li_row_number).Value,
                                                              dgv_pedidos.Item("ctacte", li_row_number).Value,
                                                              dgv_pedidos.Item("RazonSocial", li_row_number).Value,
                                                              dgv_pedidos.Item("fecha", li_row_number).Value, clsGen.Obtener_XMLConfig("correo_facturacion_gt", False),
                                                              "Aprobación de Pedido de Dia(s) Anterior(es)", Me.txt_comentario.Text)
                    End If

                    Dim lsSQL As String = "pa_sel_um_gen_tabcod '" & dgv_pedidos.Item("vendedor", li_row_number).Value.ToString & "','GEN_VENDEDOR','" &
                            dgv_pedidos.Item("empresa", li_row_number).Value.ToString & "'"
                    dtAvisos = clsGen.selectQuery("FlexLine", lsSQL)

                    If dtAvisos.Rows.Count > 0 Then
                        enviarAvisoTeams(dgv_pedidos.Item("empresa", li_row_number).Value,
                                                                  dgv_pedidos.Item("tipodocto", li_row_number).Value,
                                                                  dgv_pedidos.Item("numero", li_row_number).Value,
                                                                  dgv_pedidos.Item("ctacte", li_row_number).Value,
                                                                  dgv_pedidos.Item("RazonSocial", li_row_number).Value,
                                                                  dgv_pedidos.Item("fecha", li_row_number).Value, dtAvisos.Rows(0).Item("texto2").ToString,
                                                                  "Aprobación de Pedido", Me.txt_comentario.Text)
                    End If

                    'Validar la facturación automatica

                    '(c) 20250408 Facturación Automatica
                    Try
                        '  If Hour(Now()) > 4 And Hour(Now()) < 20 Then

                        Dim dtValidacion, dtaux As DataTable
                            Dim oSinc As New Sincronizacion.Recepcion_Informacion_PDA
                            lsEmpresa = dgv_pedidos.Item("empresa", li_row_number).Value
                            lsTipodocto = dgv_pedidos.Item("tipodocto", li_row_number).Value
                            lsNumero = dgv_pedidos.Item("numero", li_row_number).Value

                            If (lsEmpresa = "DMARTE1" Or
                             lsEmpresa = "DIUVA" Or
                             lsEmpresa = "CODICASA") Then



                                dtValidacion = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & lsEmpresa & "','" & lsTipodocto & "','" & lsNumero & "'")
                                If dtValidacion.Rows.Count > 0 Then

                                    If dtValidacion.Rows(0).Item("facturar_pedido_automatico").ToString.ToUpper = "S" Then


                                        dtValidacion = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & lsEmpresa & "','" & lsTipodocto & "','" & lsNumero & "'")
                                        If dtValidacion.Rows.Count > 0 Then

                                            If dtValidacion.Rows(0).Item("facturar_pedido_automatico").ToString.ToUpper = "S" Then


                                                With dtValidacion.Rows(0)
                                                    lsSQL = "pa_ins_um_documento_aprobacion '" &
                                                        .Item("empresa").ToString & "','" &
                                                        .Item("tipodocto").ToString & "'," &
                                                        .Item("correlativo") & ",'" &
                                                        .Item("numero").ToString & "','" & gs_usuario & "','Aprobaciones Umbright'"
                                                End With
                                                clsGen.insertQuery("SCM", lsSQL)

                                            End If
                                        End If

                                    End If
                                End If

                            End If
                        ' End If



                    Catch ex As Exception

                    End Try


                ElseIf Me.cmb_estados.SelectedValue = "N" Then
                    Dim lsSQL As String = "pa_sel_um_gen_tabcod '" & dgv_pedidos.Item("vendedor", li_row_number).Value.ToString & "','GEN_VENDEDOR','" &
dgv_pedidos.Item("empresa", li_row_number).Value.ToString & "'"
                    dtAvisos = clsGen.selectQuery("FlexLine", lsSQL)


                    If dtAvisos.Rows.Count > 0 Then
                        enviarAvisoTeams(dgv_pedidos.Item("empresa", li_row_number).Value,
                                dgv_pedidos.Item("tipodocto", li_row_number).Value,
                                dgv_pedidos.Item("numero", li_row_number).Value,
                                dgv_pedidos.Item("ctacte", li_row_number).Value,
                                dgv_pedidos.Item("RazonSocial", li_row_number).Value,
                                dgv_pedidos.Item("fecha", li_row_number).Value, dtAvisos.Rows(0).Item("texto2").ToString,
                                "Rechazo de Pedido", Me.txt_comentario.Text)
                    End If
                End If
            Else
                MessageBox.Show(otrans.descripcion_error)
                HacerEnvio = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            Me.txt_comentario.Text = ""
            otrans.close()
            otrans = Nothing
            clsGen = Nothing

            Me.Pedidos_Pendientes()
            Crear_Bindings()
        End Try

    End Sub


    Private Sub AplicarCambios(psEmpresa As String, psTipodocto As String, psNumero As String, pdrEncabezado As DataRow)


        Dim ls_sql As String
        Dim HacerEnvio As Boolean = False
        Dim dtCorreo As DataTable
        Dim scuentas As String

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General

        Dim dtAvisos As DataTable

        Dim ldMontoMaximoAprobacion As Decimal = fdMontoMaximoAprobacion_empresa(psEmpresa)
        '(c) 20250705 Debo Obtener el Documento Actual




        Try


            If Double.Parse(pdrEncabezado.Item("total")) > ldMontoMaximoAprobacion Then
                MessageBox.Show("El Pedido " & psTipodocto & "-" & psNumero & "Supera El Monto Maximo de Aprobación Asignado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Catch ex As Exception

        End Try


        Try



            otrans.open()

            ls_sql = "pa_sel_um_ctacte '" & psEmpresa & "','CLIENTE','" &
                                        pdrEncabezado.Item("cliente").ToString & "'"
            dt = otrans.Obtiene(ls_sql)


            If Me.cmb_estados.SelectedValue = "S" Then  '--And dt.Rows(0).Item("Analisisctacte6").ToString.Length = 0 And
                ls_sql = "pa_upd_um_documento_estado '" & psEmpresa & "','" &
                         psTipodocto & "','" &
                          psNumero & "','" &
                          pdrEncabezado.Item("Comentario1").ToString.Split("***")(0) & "','" & Me.cmb_estados.SelectedValue & "','" & gs_usuario & "'"

                otrans.Actualiza(ls_sql)
                If otrans.Codigo_error = 0 Then
                    MessageBox.Show("Pedido " & psTipodocto & "-" & psNumero & " Proceso Realizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


                If pdrEncabezado.Item("fecha") <> Today Then

                    enviarAvisoTeams(psEmpresa,
                                                          psTipodocto,
                                                          psNumero,
                                                          pdrEncabezado.Item("cliente").ToString,
                                                          pdrEncabezado.Item("razonSocial").ToString,
                                                          pdrEncabezado.Item("fecha"), clsGen.Obtener_XMLConfig("correo_facturacion_gt", False),
                                                          "Aprobación de Pedido de Dia(s) Anterior(es)", pdrEncabezado.Item("Comentario1").ToString.Split("***")(0))
                End If

                Dim lsSQL As String = "pa_sel_um_gen_tabcod '" & pdrEncabezado.Item("vendedor").ToString & "','GEN_VENDEDOR','" &
                        psEmpresa & "'"
                dtAvisos = clsGen.selectQuery("FlexLine", lsSQL)

                If dtAvisos.Rows.Count > 0 Then
                    enviarAvisoTeams(psEmpresa,
                                               psTipodocto,
                                               psNumero,
                                               pdrEncabezado.Item("cliente").ToString,
                                               pdrEncabezado.Item("razonSocial").ToString,
                                               pdrEncabezado.Item("fecha"), dtAvisos.Rows(0).Item("texto2").ToString,
                                               "Aprobación de Pedido", pdrEncabezado.Item("Comentario1").ToString.Split("***")(0))
                End If

                'Validar la facturación automatica

                '(c) 20250408 Facturación Automatica
                '(c) 20250705 Se Debe mover el procesode facturación automática a este punto, 



                Try

                    '(c) 20250731 por eficiencia se mandará a una tabla que almacene los pedidos pendientes de 



                    'If Hour(Now()) > 4 And Hour(Now()) < 20 Then

                    Dim dtValidacion, dtaux As DataTable
                        'Dim oSinc As New Sincronizacion.Recepcion_Informacion_PDA


                        If (psEmpresa = "DMARTE1" Or
                         psEmpresa = "DIUVA" Or
                         psEmpresa = "CODICASA") Then



                            dtValidacion = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & psEmpresa & "','" & psTipodocto & "','" & psNumero & "'")
                            If dtValidacion.Rows.Count > 0 Then

                                If dtValidacion.Rows(0).Item("facturar_pedido_automatico").ToString.ToUpper = "S" Then


                                    With dtValidacion.Rows(0)
                                    lsSQL = "pa_ins_um_documento_aprobacion '" &
                                            .Item("empresa").ToString & "','" &
                                            .Item("tipodocto").ToString & "'," &
                                            .Item("correlativo") & ",'" &
                                            .Item("numero").ToString & "','" & gs_usuario & "','Aprobaciones Umbright'"
                                End With
                                    clsGen.insertQuery("SCM", lsSQL)




                                    '(c) 20220809
                                    'Dim slCedi As String = dtValidacion.Rows(0).Item("Cedi").ToString
                                    'Dim lsBodega As String

                                    'If slCedi.Length = 0 Then
                                    '    lsBodega = "CD_CENTRAL"
                                    'Else
                                    '    dtaux = Nothing

                                    '    dtaux = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod '" & slCedi & "','GEN_LOCALES','" & psEmpresa & "'")
                                    '    If dtaux.Rows.Count = 1 Then
                                    '        lsBodega = dtaux.Rows(0).Item("descripcion").ToString
                                    '    Else
                                    '        'Problema con los cedis
                                    '        'MessageBox.Show("Problemas con informacion para CEDI", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                    '        Exit Try
                                    '    End If
                                    'End If


                                    ''(c) 20250319 
                                    'Dim lsUsuariograbo As String = "ROOT"
                                    ''Try
                                    ''    lsUsuariograbo = clsGen.Obtener_XMLConfig("usuario_facturacion_automatico", False).ToString.ToUpper '"CARANA"
                                    ''Catch ex As Exception

                                    ''End Try
                                    ''If lsUsuariograbo.Length = 0 Then
                                    ''    lsUsuariograbo = "ROOT"
                                    ''End If

                                    'oSinc.generarPedidoFACEAutomatico_cedi(psEmpresa,
                                    '                                psTipodocto,
                                    '                                psNumero, lsBodega,
                                    '                                slCedi, lsUsuariograbo, "frm_pedidos_pendientes")





                                End If

                            End If
                        End If
                    'End If



                Catch ex As Exception

                End Try


            ElseIf Me.cmb_estados.SelectedValue = "N" Then

                ls_sql = "pa_upd_um_documento_estado '" & psEmpresa & "','" &
                         psTipodocto & "','" &
                          psNumero & "','" &
                          pdrEncabezado.Item("Comentario1").ToString & "','" & Me.cmb_estados.SelectedValue & "','" & gs_usuario & "'"

                otrans.Actualiza(ls_sql)
                If otrans.Codigo_error = 0 Then
                    MessageBox.Show("Pedido " & psTipodocto & "-" & psNumero & " Proceso Realizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


                Dim lsSQL As String = "pa_sel_um_gen_tabcod '" & pdrEncabezado.Item("vendedor").ToString & "','GEN_VENDEDOR','" &
                        psEmpresa & "'"
                    dtAvisos = clsGen.selectQuery("FlexLine", lsSQL)


                    If dtAvisos.Rows.Count > 0 Then
                        enviarAvisoTeams(psEmpresa,
                                                   psTipodocto,
                                                   psNumero,
                                                   pdrEncabezado.Item("cliente").ToString,
                                                   pdrEncabezado.Item("razonSocial").ToString,
                                                   pdrEncabezado.Item("fecha"), dtAvisos.Rows(0).Item("texto2").ToString,
                                "Rechazo de Pedido", Me.txt_comentario.Text)
                    End If
                End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            Me.txt_comentario.Text = ""
            otrans.close()
            otrans = Nothing
            clsGen = Nothing

            'Me.Pedidos_Pendientes()
            'Crear_Bindings()
        End Try

    End Sub


    Private Sub enviarAvisoTeams(psEmpresa As String, psTipoDocto As String, psNumero As String, psCtate As String, psRazonSocial As String, psFecha As String, psEmail As String, psMotivo As String, psComentario As String)

        Dim clsGen As New ClasesGenerales.General


        Try


            Dim varMensajeAEnviar As String = "Empresa : " & psEmpresa & "|" &
                "Tipo    : " & psTipoDocto & "|" &
                "Numero  : " & psNumero & "|" &
                "Cliente : " & psCtate & "-" & psRazonSocial & "|" &
                "Fecha   :" & psFecha & "|" &
                "Comentario :" & psComentario


            System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) 'TLS 1.2
            Dim request As WebRequest
            'request = WebRequest.Create("https://prod-104.westus.logic.azure.com:443/workflows/69578584d24848b086a7c919d4e0ecee/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=FaR-fLzV2fSMPPC3V37cMpbTpN593jqCJI9mY4W_Um8")

            request = WebRequest.Create("https://prod-126.westus.logic.azure.com:443/workflows/088f16a4366242fd8b9ada9a1606672d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dRClJKvja9MDGmRM5w94hvNSzgvGsSvD-zrK6lPU9lc")
            Dim response As WebResponse
            Dim postData As String = "
            {
              ""Correo"": """ & psEmail & """,
              ""Motivo"": """ & psMotivo & """,
              ""Mensaje_a_enviar"": """ & varMensajeAEnviar & """
            }"
            Dim data As Byte() = Encoding.UTF8.GetBytes(postData)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.ContentLength = data.Length
            Dim stream As Stream = request.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()
            response = request.GetResponse()
            Dim sr As New StreamReader(response.GetResponseStream())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub enviarcorreo(psCuentaCorreo As String, psUsuarioActual As String, psSubject As String, sdatosPedidos As String)




        Dim sta_mer As String
        Dim nrow As Integer
        Dim Message As New System.Net.Mail.MailMessage()
        Dim SMTP1 As New System.Net.Mail.SmtpClient
        Dim ls_sql As String
        Dim sBody As String = String.Empty
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Message = New System.Net.Mail.MailMessage()
            'Dim adjuntar As New Net.Mail.Attachment(ruta)
            SMTP1 = New System.Net.Mail.SmtpClient
            'config. para Outlook
            SMTP1.Port = 587
            SMTP1.Host = "smtp.office365.com" 'servidor de correo outlook
            SMTP1.EnableSsl = True





            Dim iCount As Integer = 0

            sBody = "<tr></tr><tr>"
            sBody = sBody & "Buen dia:  " &
            sBody = sBody & "</tr>"
            sBody = sBody & "<tr> "
            sBody = sBody & "</tr>"
            sBody = sBody & "<tr>"
            sBody = sBody & "Se Informa que se han Aprobado Pedidos"

            ' dt = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & psUsuarioActual & "'")

            Try
                '    sBody = sBody & StrConv(dt.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase)
            Catch ex As Exception
            End Try

            sBody = sBody & "</tr>"
            sBody = sBody & "<table><font size=2>"
            ' For Each dr As DataRow In pdtPedidos.Rows
            Try


                iCount += 1
                sBody = sBody & "<tr>"
                'sBody = sBody & "<td>Buen Dia </td>"
                'sBody = sBody & "</tr>"

                'sBody = sBody & "<td>Empresa</td>"
                sBody = sBody & "<td>Empresa  " & sdatosPedidos.Split("|")(0) & "</td>"
                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"
                sBody = sBody & "<td>Fecha " & sdatosPedidos.Split("|")(1) & "</td>"
                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"

                sBody = sBody & "<td>Cliente " & sdatosPedidos.Split("|")(2) & "</td>"
                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"

                sBody = sBody & "</tr>"
                sBody = sBody & "<tr>"
                sBody = sBody & "</tr>"


            Catch ex As Exception


            Finally
            End Try
            'Next
            sBody = sBody & "</table>"

            'l_srv_salida.Credentials = New System.Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv");

            dt = clsGen.selectQuery("SCM", "pa_var_um_credenciales_notificacion")
            ''SMTP1.Credentials = New Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv")
            'SMTP1.Credentials = New Net.NetworkCredential("eduardo.gatica@umbralcorp.com", "vrrzjvqsbwdhnmzv")
            SMTP1.Credentials = New Net.NetworkCredential(dt.Rows(0).Item("mail").ToString, dt.Rows(0).Item("pwd").ToString)

            Message.[To].Add(psCuentaCorreo)
            'Message.[To].Add("coscal@umbral.com.gt")
            Message.From = New System.Net.Mail.MailAddress("notificacion@umbralcorp.com", "Notificaciones Umbral", System.Text.Encoding.UTF8) 'Quien envía el e-mail
            Message.Subject = psSubject
            Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
            Message.Body = sBody

            Message.BodyEncoding = System.Text.Encoding.UTF8
            Message.Priority = System.Net.Mail.MailPriority.Normal
            Message.IsBodyHtml = True
            'Message.Attachments.Add(adjuntar)

            SMTP1.Send(Message)

        Catch ex As Exception
            clsGen.Escribir_Log(ex.ToString)
        Finally
            Message = Nothing
            SMTP1 = Nothing
            clsGen = Nothing
        End Try

    End Sub


    ''Envia Pedido Aprobado a la Tienda deseada
    Private Sub Enviar_Pedido(ByVal ptienda As String, ByVal pempresa As String, ByVal ptipodocto As String, ByVal pnumero As String)

        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim Sinc As New Sincronizacion.Documentos(ptienda)
        Dim Ods As New DataSet
        Dim dt As DataTable

        Dim ls_sql As String
        Dim ls_dtipodocto As String

        Try
            Otrans.open()


            ls_sql = "pa_sel_um_gen_tabcod '" & ptienda & "','GEN_LOCALES'"
            dt = Otrans.Obtiene(ls_sql)

            ''Le Agrego el resto del nombre al pedido
            ls_dtipodocto = ptipodocto & " " & dt.Rows(0).Item("TEXTO1").ToString

            ls_sql = "pa_sel_um_documentod '" & pempresa & "','" & ptipodocto & "','" & pnumero & "'"
            dt = Otrans.Obtiene(ls_sql)


            dt.TableName = "detalle_documento"
            Ods.Tables.Add(dt.Copy)


            ls_sql = "pa_var_um_documento '" & pempresa & "','" & ptipodocto & "','" & pnumero & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "encabezado_documento"
            Ods.Tables.Add(dt.Copy)

            'Obtengo DocumentoV
            ls_sql = "pa_var_um_documentov '" & pempresa & "','" & ptipodocto & "','" & pnumero & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentov"
            Ods.Tables.Add(dt.Copy)

            'Obtengo DocumentoP
            ls_sql = "pa_var_um_documentop '" & pempresa & "','" & ptipodocto & "','" & pnumero & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            Ods.Tables.Add(dt.Copy)

            Sinc.Enviar_Documento(pempresa,
                                Ods.Tables("encabezado_documento").Rows(0),
                                Ods.Tables("detalle_documento"),
                                Ods.Tables("documentov"),
                                Ods.Tables("documentop"),
                                ls_dtipodocto, False)


            If Not Sinc.HayErrores Then

                ''Inserto la Linea Inicial del Pedido
                ls_sql = "pa_ins_um_gen_log_documento '" & pempresa & "','" & ls_dtipodocto & "','" & pnumero & "','" & gs_usuario & "','" & Me.cmb_estados.SelectedValue.ToString & "'"
                Otrans.Actualiza(ls_sql)

                ''Si no Hubieron Errores Anulo el pedido
                ls_sql = "pa_upd_um_documento_estado '" & pempresa & "','" &
                                    ptipodocto & "','" &
                                    pnumero & "','" &
                                    Ods.Tables("encabezado_documento").Rows(0).Item("Comentario1").ToString & "','A','" &
                                     gs_usuario & "','Enviado a Tienda'"
                Otrans.Actualiza(ls_sql)
                MessageBox.Show("Pedido Enviado a Tienda", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ''Debo Regresar el pedido a su estado, por haber errores de transmision
                ls_sql = "pa_upd_um_documento_estado '" & pempresa & "','" &
                                    ptipodocto & "','" &
                                    pnumero & "','" &
                                    Ods.Tables("encabezado_documento").Rows(0).Item("Comentario1").ToString & "','P','" &
                                     gs_usuario & "'"
                Otrans.Actualiza(ls_sql)
                MessageBox.Show("El Pedido No Se Ha podido Enviar a la Tienda " & Chr(13) & Sinc.descripcion_error, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If



        Catch ex As Exception
            MessageBox.Show("Enviar Pedido " & ex.Message)
        Finally
            Sinc.Cerrar()
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub


    Private Sub frm_pedidos_pendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtp_fecha_inicio.Text = "01/" & Month(Now()).ToString & "/" & Year(Now())
        ods = New DataSet
        Llenar_Combos()
        Pedidos_Pendientes()
        Crear_Bindings()
        crear_estructura()
        validarpermisos()
    End Sub

    Private Sub validarpermisos()

        Me.btnAprobarBatch.Visible = False
        If tiene_permisos("mfr_cr_aprobacion_batch") Then
            Me.btnAprobarBatch.Visible = True
        End If

    End Sub

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        ls_sql = "pa_sel_um_gen_tabcod NULL,'IT_VIGENCIA','DMARTE1'"
        otrans.open()
        otabla = otrans.Obtiene(ls_sql)
        otrans.close()

        Me.cmb_estados.DataSource = otabla
        Me.cmb_estados.DisplayMember = "DESCRIPCION"
        Me.cmb_estados.ValueMember = "CODIGO"

        otrans = Nothing

    End Sub

    Private Sub Crear_Bindings()
        Me.txt_total_pedido.DataBindings.Add("text", oDataSet.Tables("pedidos").DefaultView, "total")
        Me.txt_comentario.DataBindings.Add("text", oDataSet.Tables("pedidos").DefaultView, "comentario1")
        Me.txt_comentarios_cliente.DataBindings.Add("text", oDataSet.Tables("pedidos").DefaultView, "Comentario_Cliente")
        Me.txt_condicion.DataBindings.Add("text", oDataSet.Tables("pedidos").DefaultView, "CondPago")
        Me.txt_limite_credito.DataBindings.Add("text", oDataSet.Tables("pedidos").DefaultView, "limitecredito")
        Me.txt_vigencia_cliente.DataBindings.Add("text", oDataSet.Tables("pedidos").DefaultView, "vigencia_cliente")
        Me.cmb_estados.DataBindings.Add("SelectedValue", oDataSet.Tables("pedidos").DefaultView, "Aprobacion")
    End Sub

    Private Sub Limpiar_Bindings()
        Try
            Me.txt_total_pedido.DataBindings.Clear()
            Me.txt_comentario.DataBindings.Clear()
            Me.txt_comentarios_cliente.DataBindings.Clear()
            Me.txt_condicion.DataBindings.Clear()
            Me.txt_limite_credito.DataBindings.Clear()
            Me.txt_vigencia_cliente.DataBindings.Clear()
            Me.cmb_estados.DataBindings.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Estado_Cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estado_Cuenta.Click
        'Generar Estado de Cta
        Dim li_row_number As Integer
        ' Dim ls_codigo_cliente As String
        Try
            li_row_number = Me.dgv_pedidos.CurrentRow.Index
            '          ls_codigo_cliente = Me.dg_pedidos.Item(li_row_number, 7)
            If dgv_pedidos.Item("tipodocto", li_row_number).Value = "SOLICITUD CONSIGNACION" Then

                generar_estado_de_cuenta(dgv_pedidos.Item("cliente", li_row_number).Value, dgv_pedidos.Item("empresa", li_row_number).Value)
                If MessageBox.Show("Desea Generar el Estado de Cuenta de Consignaciones?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    generar_estado_de_cuenta_Consignaciones(dgv_pedidos.Item("cliente", li_row_number).Value, dgv_pedidos.Item("empresa", li_row_number).Value)
                End If



            Else
                generar_estado_de_cuenta(dgv_pedidos.Item("cliente", li_row_number).Value, dgv_pedidos.Item("empresa", li_row_number).Value)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_total_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_pedido.TextChanged

        Try
            txt_total_pedido.Text = Format(Convert.ToDecimal(txt_total_pedido.Text), "###,###,##0.00").ToString
        Catch ex As Exception

        End Try
    End Sub



    Private Sub txt_limite_credito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_limite_credito.TextChanged
        Try
            txt_limite_credito.Text = Format(Convert.ToDecimal(txt_limite_credito.Text), "###,###,##0.00").ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        'If Me.txt_comentario.Text.Substring(0, 3) = "PDA" Then
        If MessageBox.Show("Confirma el Cambio de Estado del Pedido?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim li_row_number As Integer
            li_row_number = Me.dgv_pedidos.CurrentRow.Index

            'Dim lsEmpresa, lsTipodocto, lsNumero As String
            'Dim ldMontoMaximoAprobacion As Decimal = fdMontoMaximoAprobacion_empresa(dgv_pedidos.Item("empresa", li_row_number).Value)
            Guardar_Cambios() 'dgv_pedidos.Item("empresa", li_row_number).Value)
            'AplicarCambios(dgv_pedidos.Item("empresa", li_row_number).Value, dgv_pedidos.Item("tipodocto", li_row_number).Value, dgv_pedidos.Item("numero", li_row_number).Value, dgv_pedidos.Item("cliente", li_row_number).Value)

        End If

        'Else
        '   MessageBox.Show("El Comentario Debe Llevar la Palabra PDA", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub




    Private Sub dgv_pedidos_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv_pedidos.CellPainting

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgv_pedidos.Rows(rowIndex)

                ' If dgv_pedidos.Columns(colIndex).Name.ToLower.IndexOf("status_pedido") > -1 Then
                If Me.dgv_pedidos.Item("status_pedido", rowIndex).Value.ToString = "N" Then
                    Me.dgv_pedidos.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
                'End If


            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgv_pedidos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_pedidos.CurrentCellChanged
        Try
            detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_pedidos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_pedidos.MouseClick
        Try
            detalle_pedido(Me.dgv_pedidos.CurrentRow.Index)

        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_pedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_pedidos.CellContentClick

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Generar Estado de Cta
        Dim li_row_number As Integer
        ' Dim ls_codigo_cliente As String
        Try
            li_row_number = Me.dgv_pedidos.CurrentRow.Index
            '          ls_codigo_cliente = Me.dg_pedidos.Item(li_row_number, 7)

            If dgv_pedidos.Item("empresa", li_row_number).Value = "DIVINOS" Or dgv_pedidos.Item("empresa", li_row_number).Value = "VINOTECAHN" Then
                generar_estado_de_cuenta(dgv_pedidos.Item("cliente", li_row_number).Value, dgv_pedidos.Item("empresa", li_row_number).Value)


            Else
                generar_estado_de_cuentaCorporativo(dgv_pedidos.Item("cliente", li_row_number).Value, dgv_pedidos.Item("empresa", li_row_number).Value)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_detalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detalle.CellContentClick

    End Sub

    Private Sub btnAprobarBatch_Click(sender As Object, e As EventArgs) Handles btnAprobarBatch.Click
        If Me.cmb_estados.SelectedValue = "S" Then
            If MessageBox.Show("Confirma el Proceso de Aprobación de Pedidos en Batch? Hacia " & Me.cmb_estados.Text, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                AprobarBatchPedidos()
            End If
        End If
    End Sub


    Private Sub AprobarBatchPedidos()
        Dim iSelectedRow As Integer
        Dim sTipodocto, sEmpresa, sNumero, lsBodega, slCedi As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim slistaPrecios As String
        Dim dr As DataRow

        Try

            iSelectedRow = Me.dgv_pedidos.Rows.GetRowCount(DataGridViewElementStates.Selected)

            For i As Integer = 0 To iSelectedRow


                slCedi = String.Empty

                sTipodocto = Me.dgv_pedidos.Item("tipodocto", Me.dgv_pedidos.SelectedRows(i).Index).Value.ToString
                sNumero = Me.dgv_pedidos.Item("numero", Me.dgv_pedidos.SelectedRows(i).Index).Value.ToString
                sEmpresa = Me.dgv_pedidos.Item("empresa", Me.dgv_pedidos.SelectedRows(i).Index).Value.ToString

                dt = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & sEmpresa & "','" & sTipodocto & "','" & sNumero & "'")

                'Validar estado del pedido
                If dt.Rows.Count > 0 Then

                    dr = dt.Rows(0)


                    '(c) 20250709 Validar si el Pedido sigue teniendo el estado de Pendiente


                    If dr.Item("Aprobacion").ToString <> "S" Then
                        'MessageBox.Show("El Pedido " & sNumero & " No Esta en Estado Pendiente", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'Exit For

                        AplicarCambios(sEmpresa, sTipodocto, sNumero, dr)
                    Else

                        MessageBox.Show("El Pedido " & sNumero & " Ya esta Aprobado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    End If
                End If
            Next






        Catch ex As Exception

        End Try
    End Sub

End Class