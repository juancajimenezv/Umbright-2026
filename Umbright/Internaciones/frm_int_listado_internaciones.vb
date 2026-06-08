Public Class frm_int_listado_internaciones
    Inherits System.Windows.Forms.Form
    Dim ds_internaciones As New DataSet

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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents txt_comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_estados As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dg_internaciones As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents chkOperadasCD As System.Windows.Forms.CheckBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_int_listado_internaciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txt_comentarios = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_estados = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_editar = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.dg_internaciones = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dg_detalle = New System.Windows.Forms.DataGridView
        Me.chkOperadasCD = New System.Windows.Forms.CheckBox
        CType(Me.dg_internaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_actualizar
        '
        Me.btn_actualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_actualizar.ForeColor = System.Drawing.Color.White
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_actualizar.ImageIndex = 3
        Me.btn_actualizar.ImageList = Me.ImageList1
        Me.btn_actualizar.Location = New System.Drawing.Point(252, 11)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(75, 64)
        Me.btn_actualizar.TabIndex = 2
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_actualizar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "print_48.png")
        Me.ImageList1.Images.SetKeyName(1, "revert-to-saved-ltr.png")
        Me.ImageList1.Images.SetKeyName(2, "2.png")
        Me.ImageList1.Images.SetKeyName(3, "reload.png")
        Me.ImageList1.Images.SetKeyName(4, "export.png")
        '
        'txt_comentarios
        '
        Me.txt_comentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_comentarios.Location = New System.Drawing.Point(97, 25)
        Me.txt_comentarios.Name = "txt_comentarios"
        Me.txt_comentarios.Size = New System.Drawing.Size(409, 22)
        Me.txt_comentarios.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Comentarios"
        '
        'cmb_estados
        '
        Me.cmb_estados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_estados.DropDownWidth = 160
        Me.cmb_estados.Location = New System.Drawing.Point(97, 53)
        Me.cmb_estados.Name = "cmb_estados"
        Me.cmb_estados.Size = New System.Drawing.Size(144, 24)
        Me.cmb_estados.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Estado"
        '
        'btn_editar
        '
        Me.btn_editar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_editar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_editar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.ForeColor = System.Drawing.Color.White
        Me.btn_editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_editar.ImageIndex = 2
        Me.btn_editar.ImageList = Me.ImageList1
        Me.btn_editar.Location = New System.Drawing.Point(171, 13)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(75, 64)
        Me.btn_editar.TabIndex = 2
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_editar.UseVisualStyleBackColor = False
        Me.btn_editar.Visible = False
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exportar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.White
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.ImageIndex = 1
        Me.btn_exportar.ImageList = Me.ImageList1
        Me.btn_exportar.Location = New System.Drawing.Point(90, 12)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(75, 64)
        Me.btn_exportar.TabIndex = 2
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.ImageIndex = 0
        Me.btn_imprimir.ImageList = Me.ImageList1
        Me.btn_imprimir.Location = New System.Drawing.Point(10, 11)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(75, 64)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'dg_internaciones
        '
        Me.dg_internaciones.AllowUserToAddRows = False
        Me.dg_internaciones.AllowUserToDeleteRows = False
        Me.dg_internaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_internaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_internaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_internaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_internaciones.Location = New System.Drawing.Point(12, 102)
        Me.dg_internaciones.Name = "dg_internaciones"
        Me.dg_internaciones.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_internaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg_internaciones.RowHeadersWidth = 25
        Me.dg_internaciones.Size = New System.Drawing.Size(1067, 255)
        Me.dg_internaciones.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.chkOperadasCD)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_comentarios)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_estados)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 84)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.btn_actualizar)
        Me.GroupBox2.Controls.Add(Me.btn_imprimir)
        Me.GroupBox2.Controls.Add(Me.btn_exportar)
        Me.GroupBox2.Controls.Add(Me.btn_editar)
        Me.GroupBox2.Location = New System.Drawing.Point(565, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 84)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'dg_detalle
        '
        Me.dg_detalle.AllowUserToAddRows = False
        Me.dg_detalle.AllowUserToDeleteRows = False
        Me.dg_detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dg_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_detalle.DefaultCellStyle = DataGridViewCellStyle5
        Me.dg_detalle.Location = New System.Drawing.Point(12, 363)
        Me.dg_detalle.Name = "dg_detalle"
        Me.dg_detalle.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_detalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dg_detalle.RowHeadersWidth = 25
        Me.dg_detalle.Size = New System.Drawing.Size(1067, 214)
        Me.dg_detalle.TabIndex = 10
        '
        'chkOperadasCD
        '
        Me.chkOperadasCD.AutoSize = True
        Me.chkOperadasCD.Location = New System.Drawing.Point(307, 56)
        Me.chkOperadasCD.Name = "chkOperadasCD"
        Me.chkOperadasCD.Size = New System.Drawing.Size(140, 20)
        Me.chkOperadasCD.TabIndex = 7
        Me.chkOperadasCD.Text = "Ver Operada en CD"
        Me.chkOperadasCD.UseVisualStyleBackColor = True
        Me.chkOperadasCD.Visible = False
        '
        'frm_int_listado_internaciones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1082, 589)
        Me.Controls.Add(Me.dg_detalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_internaciones)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_int_listado_internaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. SCM Internaciones | Internaciones en Transito .::"
        CType(Me.dg_internaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dg_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Combos()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String

        Dim clsgen As New ClasesGenerales.General

        Try
            otrans.open()
            ls_sql = "pa_sel_um_v_pg_estados 1"
            dt = otrans.Obtiene(ls_sql)
            Me.cmb_estados.DataSource = dt
            Me.cmb_estados.ValueMember = "cod_estado"
            Me.cmb_estados.DisplayMember = "estado"
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub


    Private Sub aplicarFiltro()
        Dim lsFiltro As String = String.Empty

        If gi_tipo_usuario = 1 Or gi_tipo_usuario = 2 Then
            lsFiltro = "estado <> 5"
            'Si revisa memos solo le muestro aquellos que estan solicitados
            Me.chkOperadasCD.Visible = True
        Else

            If tiene_permisos("mci_int_estado_inicilizada") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", "(") & "estado = 0"
            If tiene_permisos("mci_int_estado_aprobadaDA") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 1"
            If tiene_permisos("mci_int_estado_preparacionPoliza") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 2"
            If tiene_permisos("mci_int_estado_PolizaPagada") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 3"
            If tiene_permisos("mci_int_estado_TrasladoCD") Then lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 4"
            If tiene_permisos("mci_int_estado_OperadaCD") Then
                lsFiltro += IIf(lsFiltro.Length > 0, " OR ", IIf(lsFiltro.ToLower.IndexOf("(") >= 0, "", "(")) & "estado = 5"
                Me.chkOperadasCD.Visible = True
            End If
            lsFiltro += IIf(lsFiltro.ToLower.IndexOf("(") >= 0, ")", "")
        End If

        ds_internaciones.Tables("internaciones_pendientes").DefaultView.RowFilter = lsFiltro

    End Sub
    Private Sub Llenar_Internaciones_pendientes()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim ls_sql As String
        Dim dr As DataRow

        Dim clsgen As New ClasesGenerales.General
        Dim clsDias As New ClasesGenerales.DiasHabiles

        Try
            otrans.open()

            If ds_internaciones.Tables.IndexOf("internaciones_pendientes") > -1 Then
                ds_internaciones.Tables.Remove("internaciones_pendientes")
            End If

            If ds_internaciones.Tables.IndexOf("internaciones_detalle") > -1 Then
                ds_internaciones.Tables.Remove("internaciones_detalle")
            End If

            If ds_internaciones.Tables.IndexOf("internaciones_dua") > -1 Then
                ds_internaciones.Tables.Remove("internaciones_dua")
            End If

            ls_sql = "pa_var_um_int_pedido_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_pendientes"
            ds_internaciones.Tables.Add(dt.Copy)
            Me.dg_internaciones.DataSource = ds_internaciones.Tables("internaciones_pendientes")

            ls_sql = "pa_sel_um_int_pedido_detalle_pendientes"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "internaciones_detalle"
            ds_internaciones.Tables.Add(dt.Copy)
            Me.dg_detalle.DataSource = ds_internaciones.Tables("internaciones_detalle")

            'ls_sql = "pa_sel_um_int_pedido_detalle_dua_pendientes"
            'dt = otrans.Obtiene(ls_sql)
            'dt.TableName = "internaciones_dua"
            'ds_internaciones.Tables.Add(dt.Copy)
            'Me.dg_detalle_dua.DataSource = ds_internaciones.Tables("internaciones_dua")



            aplicarFiltro()


            For Each drv As DataRowView In ds_internaciones.Tables("internaciones_pendientes").DefaultView
                drv.Item("dias_tramite") = clsDias.Obtener_DiasHabiles(gs_empresa, Date.Parse(drv.Item("fecha").ToString), Today).ToString
            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If ds_internaciones.Tables.Contains("internaciones_pendientes") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_pendientes"), dg_internaciones, "", ",estado,", "", "", "", ",cod_pedido=30,", "", True, True, 200, 0)
        If ds_internaciones.Tables.Contains("internaciones_detalle") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", "", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 200, 0)
        'If ds_internaciones.Tables.Contains("internaciones_dua") Then clsgen.Alinear_GridView(ds_internaciones.Tables("internaciones_dua"), dg_detalle_dua, "", "", "", "", "", ",cod_pedido=40,dua=80,", "", True, True, 200, 0)
        clsgen = Nothing
    End Sub

    Private Sub Actualizar_Estado(ByVal npedido As Integer, ByVal nestado As Integer)
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim dr As DataRow
        Dim lbProcesarEstado As Boolean = False


        Try
            otrans.open()
            'Verificamos que este en el mismo estado
            ls_sql = "pa_var_um_int_pedido_pendientes " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)
            dr = dt.Rows(0)
            If Me.cmb_estados.SelectedValue < Int32.Parse(dr.Item("estado").ToString) Or _
                Me.cmb_estados.SelectedValue > Int32.Parse(dr.Item("estado").ToString) + 1 Then

                If Me.cmb_estados.SelectedValue = 10 Then
                    lbProcesarEstado = True
                Else
                    MessageBox.Show("No Puede Asignar Estado " & Me.cmb_estados.Text & " A este Pedido")
                End If
            Else
                lbProcesarEstado = True
            End If


            If lbProcesarEstado Then

                ls_sql = "pa_ins_um_int_pedido_estado " & npedido.ToString & "," & Me.cmb_estados.SelectedValue & ",'" & _
                        gs_usuario & "','" & Me.txt_comentarios.Text.Trim & "'"
                If otrans.Ingresa(ls_sql) Then
                    If Me.cmb_estados.SelectedValue <> Int32.Parse(dr.Item("estado").ToString) Then guardarAviso(npedido, Me.cmb_estados.SelectedValue)



                    MessageBox.Show("Actualizacion Exitosa !!!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Llenar_Internaciones_pendientes()
                End If
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub guardarAviso(ByVal ipedido As Integer, ByVal iestado As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable
        Dim scuentas As String = ""

        Try
            If iestado > 10 Then Exit Sub

            If iestado = 1 Then iestado = 11
            If iestado = 2 Then iestado = 12


            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (" & iestado.ToString & ")" '1= Ingreso de Dua OC
            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                'If dr.Item("validar_marca").ToString = "1" Then
                '    dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                '    If dt2.DefaultView.Count > 0 Then guardarAviso = True

                'ElseIf dr.Item("validar_empresa").ToString = "1" Then
                '    dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                '    If dtUsuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True

                'Else
                '    guardarAviso = True
                'End If

                'If guardarAviso() Then
                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Solicitud No " &
                                      ipedido.ToString & "  " & Me.cmb_estados.Text & " " &
                                      Me.txt_comentarios.Text.Trim, 1)
                'guardarAviso = False
                'End If

                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & dr.Item("usuario").ToString & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If
            Next



            If scuentas.ToString.Length > 0 Then
                enviarCorreo(scuentas)
            End If
        Catch ex As Exception

            clsGen.
        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing
        End Try


    End Sub

    Private Sub enviarCorreo(sCuentas As String)


        Dim sBody As String
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "lgs1@logiservicios.com"
        Dim snombreRemitente As String = "LGS1"
        'Dim scuentas As String = ""
        Dim sSubject As String = ""
        Dim ldFechaDocto As Date

        Try




            Dim iCount As Integer = 0

            sSubject = "Internaciones " & pedido.ToString & "  " & Me.cmb_estados.Text ' Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text


            sBody = "<br>"
            'sBody = sBody & "Se les Informa que se ha ingresado a " & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
            sBody = sBody & "Seguimiento de Internaciones <br>"
            sBody = sBody & " <br>"
            sBody = sBody & ipedido.ToString & "  " & Me.cmb_estados.Text & " " & Me.txt_comentarios.Text.Trim
            'sBody = sBody & "Proveedor " & Me.txtProveedor.Text & "<br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & "Adjunto se envia el documento de Ingreso <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            'If Me.txtComentario4.Text.Length > 0 Then
            '    sBody = sBody & " Comentarios " & Me.txtComentario4.Text
            'End If




            Try
                'Dim dtBU As DataTable
                'Dim dtCorreo As DataTable
                'dtBU = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmbTipoDocto.SelectedValue.ToString & "','" & Me.txtNumero.Text & "'")
                'ldFechaDocto = dtBU.Rows(0).Item("fecha_docto")
                'dtBU = clsGen.ValoresDistinto(dtBU, "analisisproducto17".Split(","))
                'For Each dr As DataRow In dtBU.Rows
                '    '' Debo obtener las personas que tienen permisos para esa unidad de negocio
                '    Dim dtUsuarioBU As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null, '" & dr.Item("analisisproducto17").ToString & "','" & gs_empresa & "'")
                '    For Each drBU As DataRow In dtUsuarioBU.Rows
                '        dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & drBU.Item("usuario").ToString & "'")
                '        If dtCorreo.Rows.Count > 0 Then
                '            If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                '            scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                '        End If
                '    Next

                'Next
                '''Correos por empresa
                'dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod null, 'gen_correo_internaci', '" & gs_empresa & "'")
                'For Each dr As DataRow In dtCorreo.Rows
                '    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                '    scuentas = scuentas & dr.Item("descripcion").ToString
                'Next



            Catch ex As Exception

            End Try




            'scuentas = "coscal@umbral.com.gt, chernandez@logiservicios.com"
            'Dim lsRuta As String = generarPDF(ldFechaDocto.ToString("yyyyMM"))

            clsGen.enviarcorreo(sRemitente, snombreRemitente, sCuentas, sSubject, sBody, "")

            'Ruta En Servidor

            'Dim lsRutaServidor As String = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" &
            '            gs_empresa & "\" & ldFechaDocto.ToString("yyyyMM")


            'Try
            '    If Not Directory.Exists(lsRutaServidor) Then
            '        Directory.CreateDirectory(lsRutaServidor)
            '    End If
            'Catch ex As Exception

            'End Try

            'lsRutaServidor &= "\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"

            'clsGen.Copiar_Archivo(lsRuta, lsRutaServidor, True)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub



    Private Sub Editar_Detalle_Pedido_Dua(ByVal npedido As Integer, ByVal snombre As String)

        Dim ls_sql As String
        Dim oform As New frm_int_asociar_solicitud
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim dt As New DataTable

        Try
            otrans.open()
            ls_sql = "pa_var_um_int_pedido_detalle_dua " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try


        oform.pdt = dt
        oform.txt_numero.Text = npedido
        oform.txt_nombre.Text = snombre
        oform.btn_Guardar.Text = "Modificar"
        oform.txt_nombre.ReadOnly = True
        oform.lbl_daiv.Visible = False
        oform.lbl_iva.Visible = False

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    'Mostrar los productos en los diferentes grids
    Private Sub Mostrar_Productos()

        Dim nrow, npedido As Integer
        Dim clsGen As New ClasesGenerales.General

        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString

            ds_internaciones.Tables("internaciones_detalle").DefaultView.RowFilter = "cod_pedido = " & npedido
            'ds_internaciones.Tables("internaciones_dua").DefaultView.RowFilter = "cod_pedido = " & npedido
            clsGen.Alinear_GridView(ds_internaciones.Tables("internaciones_detalle"), dg_detalle, "", "", "", "", "", ",cod_pedido=30,cantidad=40,", "", True, True, 200, 0)
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub

    Private Sub Exportar_Pedido()
        Dim nrow, npedido As Integer
        Dim ls_sql As String

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim Oaut As New Automatizar.exportar_excel

        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString

            otrans.open()
            ls_sql = "pa_var_um_int_pedido_detalle_dua " & npedido.ToString
            dt = otrans.Obtiene(ls_sql)


            Oaut.nAgregar_Filas = 2
            Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}}
            Oaut.ocultar_columnas = ",proveedor,agregar,"
            Oaut.Nombre_Columnas = ",,,Traslado CJ"
            Oaut.sEncabezado = "Solicitud de Traslado del DA"
            Oaut.sTitulo = "Solicitud No. " & npedido.ToString
            Oaut.DataTableToExcel(dt)
            Oaut = Nothing




        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Imprimir_Pedido()

        Dim path_reporte As String
        Dim pm_valores(0) As String
        Dim pm_parametros(0) As String
        Dim nrow, npedido As Integer

        Try
            nrow = Me.dg_internaciones.CurrentCell.RowIndex
            npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString

            path_reporte = "\\dataserver\FlexlineServidor\FlexlineERP\Reportes Alianza\Compras e Importaciones\pedido_internaciones.rpt"
            pm_parametros(0) = "@Pcod_pedido"
            pm_valores(0) = npedido

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "DATASERVER", "BDflexline", "flexline", "flexline", False, True, "PDF", False, "", True)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub frm_int_listado_internaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combos()
        Llenar_Internaciones_pendientes()
        Mostrar_Productos()
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click

        Dim nrow, npedido, nestado As Integer

        nrow = Me.dg_internaciones.CurrentCell.RowIndex
        npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString
        nestado = Me.dg_internaciones.Item(4, nrow).Value.ToString

        If MessageBox.Show("Esta Seguro de Cambiar Estado a Pedido No. " & npedido.ToString, "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Actualizar_Estado(npedido, nestado)
        End If
    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click

        Dim nrow, npedido, nestado As Integer
        Dim snombre As String

        nrow = Me.dg_internaciones.CurrentCell.RowIndex
        npedido = Me.dg_internaciones.Item(0, nrow).Value.ToString
        nestado = Me.dg_internaciones.Item(4, nrow).Value.ToString
        snombre = Me.dg_internaciones.Item(3, nrow).Value.ToString

        If nestado > 0 Then
            MessageBox.Show("Este Pedido No Se Puede Editar Por que Ya fue Aprobado en el DA", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.Editar_Detalle_Pedido_Dua(npedido, snombre)
        End If
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar_Pedido()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Imprimir_Pedido()
    End Sub

    Private Sub dg_internaciones_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg_internaciones.CurrentCellChanged
        Mostrar_Productos()
    End Sub

    Private Sub chkOperadasCD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOperadasCD.CheckedChanged
        aplicarFiltro()
    End Sub
End Class
