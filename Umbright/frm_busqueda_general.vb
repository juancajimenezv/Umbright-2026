Public Class frm_busqueda_general
    Inherits System.Windows.Forms.Form
    Private ps_nombre_vista As String = ""
    Private ps_procedimiento_almacenado As String

    Public ps_parametros_fijos As String
    Public lista_parametros As String
    Public lista_campos As String
    Public seleccion_multiple As Boolean = False
    Private po_parametros As Array
    Public conectar As String = String.Empty

    Public resultado As String
    Public dt As DataTable
    Public nombre_corto, ruta_logistica, cta_cte, razon_social, retorna, retorna2, clasificacion, segmento, motivoconsumo, subCanal As String
    Public toco As Boolean = False
    Friend WithEvents btn_ncorto As System.Windows.Forms.Button
    Friend WithEvents btn_rutaLogistica As System.Windows.Forms.Button
    Friend WithEvents dgv_listadoclientes As System.Windows.Forms.DataGridView


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
    Friend WithEvents cmb_valor3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_valor2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_valor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_buscar3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar1 As System.Windows.Forms.TextBox
    Friend WithEvents dg_buscar As System.Windows.Forms.DataGrid
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_log1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_log2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_seleccion_multipe As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmb_valor3 = New System.Windows.Forms.ComboBox
        Me.cmb_valor2 = New System.Windows.Forms.ComboBox
        Me.cmb_valor1 = New System.Windows.Forms.ComboBox
        Me.cmb_3 = New System.Windows.Forms.ComboBox
        Me.cmb_2 = New System.Windows.Forms.ComboBox
        Me.cmb_1 = New System.Windows.Forms.ComboBox
        Me.txt_buscar3 = New System.Windows.Forms.TextBox
        Me.txt_buscar2 = New System.Windows.Forms.TextBox
        Me.txt_buscar1 = New System.Windows.Forms.TextBox
        Me.dg_buscar = New System.Windows.Forms.DataGrid
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.cmb_log1 = New System.Windows.Forms.ComboBox
        Me.cmb_log2 = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_seleccion_multipe = New System.Windows.Forms.Button
        Me.btn_ncorto = New System.Windows.Forms.Button
        Me.dgv_listadoclientes = New System.Windows.Forms.DataGridView
        Me.btn_rutaLogistica = New System.Windows.Forms.Button
        CType(Me.dg_buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_listadoclientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_valor3
        '
        Me.cmb_valor3.Location = New System.Drawing.Point(192, 64)
        Me.cmb_valor3.Name = "cmb_valor3"
        Me.cmb_valor3.Size = New System.Drawing.Size(104, 23)
        Me.cmb_valor3.TabIndex = 16
        Me.cmb_valor3.Visible = False
        '
        'cmb_valor2
        '
        Me.cmb_valor2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor2.DropDownWidth = 150
        Me.cmb_valor2.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor2.Location = New System.Drawing.Point(24, 40)
        Me.cmb_valor2.Name = "cmb_valor2"
        Me.cmb_valor2.Size = New System.Drawing.Size(104, 23)
        Me.cmb_valor2.TabIndex = 14
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Location = New System.Drawing.Point(24, 16)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(104, 23)
        Me.cmb_valor1.TabIndex = 10
        '
        'cmb_3
        '
        Me.cmb_3.Location = New System.Drawing.Point(136, 64)
        Me.cmb_3.Name = "cmb_3"
        Me.cmb_3.Size = New System.Drawing.Size(40, 23)
        Me.cmb_3.TabIndex = 17
        Me.cmb_3.Visible = False
        '
        'cmb_2
        '
        Me.cmb_2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_2.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_2.Location = New System.Drawing.Point(128, 40)
        Me.cmb_2.Name = "cmb_2"
        Me.cmb_2.Size = New System.Drawing.Size(55, 23)
        Me.cmb_2.TabIndex = 15
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Location = New System.Drawing.Point(128, 16)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(55, 23)
        Me.cmb_1.TabIndex = 11
        '
        'txt_buscar3
        '
        Me.txt_buscar3.Location = New System.Drawing.Point(176, 64)
        Me.txt_buscar3.Name = "txt_buscar3"
        Me.txt_buscar3.Size = New System.Drawing.Size(288, 21)
        Me.txt_buscar3.TabIndex = 19
        Me.txt_buscar3.Visible = False
        '
        'txt_buscar2
        '
        Me.txt_buscar2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_buscar2.Location = New System.Drawing.Point(184, 41)
        Me.txt_buscar2.Name = "txt_buscar2"
        Me.txt_buscar2.Size = New System.Drawing.Size(296, 21)
        Me.txt_buscar2.TabIndex = 16
        '
        'txt_buscar1
        '
        Me.txt_buscar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_buscar1.Location = New System.Drawing.Point(184, 17)
        Me.txt_buscar1.Name = "txt_buscar1"
        Me.txt_buscar1.Size = New System.Drawing.Size(296, 21)
        Me.txt_buscar1.TabIndex = 12
        '
        'dg_buscar
        '
        Me.dg_buscar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_buscar.CaptionVisible = False
        Me.dg_buscar.DataMember = ""
        Me.dg_buscar.FlatMode = True
        Me.dg_buscar.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_buscar.Location = New System.Drawing.Point(8, 139)
        Me.dg_buscar.Name = "dg_buscar"
        Me.dg_buscar.ReadOnly = True
        Me.dg_buscar.Size = New System.Drawing.Size(258, 335)
        Me.dg_buscar.TabIndex = 30
        Me.dg_buscar.Visible = False
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.White
        Me.Btn_Aceptar.Location = New System.Drawing.Point(160, 68)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Aceptar.TabIndex = 21
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = False
        Me.Btn_Aceptar.Visible = False
        '
        'cmb_log1
        '
        Me.cmb_log1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_log1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_log1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_log1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_log1.Items.AddRange(New Object() {"And", "Or"})
        Me.cmb_log1.Location = New System.Drawing.Point(480, 16)
        Me.cmb_log1.Name = "cmb_log1"
        Me.cmb_log1.Size = New System.Drawing.Size(48, 23)
        Me.cmb_log1.TabIndex = 13
        '
        'cmb_log2
        '
        Me.cmb_log2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_log2.Location = New System.Drawing.Point(480, 40)
        Me.cmb_log2.Name = "cmb_log2"
        Me.cmb_log2.Size = New System.Drawing.Size(48, 23)
        Me.cmb_log2.TabIndex = 23
        Me.cmb_log2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_seleccion_multipe)
        Me.GroupBox1.Controls.Add(Me.Btn_Aceptar)
        Me.GroupBox1.Controls.Add(Me.cmb_log1)
        Me.GroupBox1.Controls.Add(Me.cmb_log2)
        Me.GroupBox1.Controls.Add(Me.cmb_valor3)
        Me.GroupBox1.Controls.Add(Me.cmb_valor2)
        Me.GroupBox1.Controls.Add(Me.cmb_valor1)
        Me.GroupBox1.Controls.Add(Me.cmb_3)
        Me.GroupBox1.Controls.Add(Me.cmb_2)
        Me.GroupBox1.Controls.Add(Me.cmb_1)
        Me.GroupBox1.Controls.Add(Me.txt_buscar3)
        Me.GroupBox1.Controls.Add(Me.txt_buscar2)
        Me.GroupBox1.Controls.Add(Me.txt_buscar1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 96)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'btn_seleccion_multipe
        '
        Me.btn_seleccion_multipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_seleccion_multipe.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_seleccion_multipe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_seleccion_multipe.ForeColor = System.Drawing.Color.White
        Me.btn_seleccion_multipe.Location = New System.Drawing.Point(32, 68)
        Me.btn_seleccion_multipe.Name = "btn_seleccion_multipe"
        Me.btn_seleccion_multipe.Size = New System.Drawing.Size(120, 23)
        Me.btn_seleccion_multipe.TabIndex = 21
        Me.btn_seleccion_multipe.Text = "Seleccionar Todos"
        Me.btn_seleccion_multipe.UseVisualStyleBackColor = False
        Me.btn_seleccion_multipe.Visible = False
        '
        'btn_ncorto
        '
        Me.btn_ncorto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ncorto.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ncorto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ncorto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ncorto.ForeColor = System.Drawing.Color.White
        Me.btn_ncorto.Location = New System.Drawing.Point(465, 108)
        Me.btn_ncorto.Name = "btn_ncorto"
        Me.btn_ncorto.Size = New System.Drawing.Size(95, 25)
        Me.btn_ncorto.TabIndex = 33
        Me.btn_ncorto.Text = "Nombre Corto"
        Me.btn_ncorto.UseVisualStyleBackColor = False
        Me.btn_ncorto.Visible = False
        '
        'dgv_listadoclientes
        '
        Me.dgv_listadoclientes.AllowUserToAddRows = False
        Me.dgv_listadoclientes.AllowUserToDeleteRows = False
        Me.dgv_listadoclientes.AllowUserToOrderColumns = True
        Me.dgv_listadoclientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_listadoclientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listadoclientes.Location = New System.Drawing.Point(8, 139)
        Me.dgv_listadoclientes.Name = "dgv_listadoclientes"
        Me.dgv_listadoclientes.ReadOnly = True
        Me.dgv_listadoclientes.RowHeadersWidth = 25
        Me.dgv_listadoclientes.Size = New System.Drawing.Size(552, 335)
        Me.dgv_listadoclientes.TabIndex = 34
        '
        'btn_rutaLogistica
        '
        Me.btn_rutaLogistica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_rutaLogistica.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_rutaLogistica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_rutaLogistica.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_rutaLogistica.ForeColor = System.Drawing.Color.White
        Me.btn_rutaLogistica.Location = New System.Drawing.Point(364, 108)
        Me.btn_rutaLogistica.Name = "btn_rutaLogistica"
        Me.btn_rutaLogistica.Size = New System.Drawing.Size(95, 25)
        Me.btn_rutaLogistica.TabIndex = 35
        Me.btn_rutaLogistica.Text = "Ruta Logistica"
        Me.btn_rutaLogistica.UseVisualStyleBackColor = False
        Me.btn_rutaLogistica.Visible = False
        '
        'frm_busqueda_general
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(572, 480)
        Me.Controls.Add(Me.btn_rutaLogistica)
        Me.Controls.Add(Me.dgv_listadoclientes)
        Me.Controls.Add(Me.btn_ncorto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_buscar)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_busqueda_general"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda"
        CType(Me.dg_buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_listadoclientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub actualizar_datos_rutaLogistica()

        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("Flexline")
        Try
            oTrans.open()
            ls_sql = "pa_upd_um_ctacteRutaLogistica '" & gs_empresa & "','" & cta_cte & " ','" & razon_social & "','" & retorna2 & "'"
            oTrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try




    End Sub
   

    Private Sub busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarcombos_operadores()

        'If tiene_permisos("mco_asignarRutaLogistica") Then
        '    Me.btn_rutaLogistica.Visible = True

        'Else
        '    Me.btn_rutaLogistica.Visible = False
        'End If

    End Sub

    Private Sub txt_buscar1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_buscar1.KeyDown

    End Sub

    Private Sub txt_buscar1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar1.KeyPress
        If e.KeyChar = Chr(13) Then
            If ps_nombre_vista.Length > 0 Then
                If conectar = String.Empty Then
                    hacer_busqueda_vista()
                Else
                    hacer_busqueda_vista(conectar)
                End If
            Else
                hacer_busqueda_sp()
            End If
        End If
    End Sub

    Public WriteOnly Property procedimiento_almacenado() As String

        Set(ByVal Value As String)
            ps_procedimiento_almacenado = Value
        End Set
    End Property

   

    Public WriteOnly Property nombre_vista() As String

        Set(ByVal Value As String)
            ps_nombre_vista = Value
        End Set
    End Property

    Public WriteOnly Property parametros() As String
        Set(ByVal Value As String)
            Dim lo_listaopciones As Array
            Dim lo_opcion As Object
            lo_listaopciones = Value.Split(",")
            For Each lo_opcion In lo_listaopciones
                Me.cmb_valor1.Items.Add(lo_opcion)
                Me.cmb_valor2.Items.Add(lo_opcion)
                Me.cmb_valor3.Items.Add(lo_opcion)
            Next
            Me.cmb_valor1.Text = Me.cmb_valor1.Items(0)
            po_parametros = lo_listaopciones
        End Set
    End Property

    Public WriteOnly Property parametros_fijos() As String
        Set(ByVal Value As String)
            ps_parametros_fijos = Value
        End Set
    End Property

    Private Sub llenarcombos_operadores()
        Me.cmb_1.Items.Add("=")
        Me.cmb_1.Items.Add(">")
        Me.cmb_1.Items.Add("<")
        Me.cmb_1.Items.Add("like")
        Me.cmb_1.Text = Me.cmb_1.Items(3)

        Me.cmb_2.Items.Add("=")
        Me.cmb_2.Items.Add(">")
        Me.cmb_2.Items.Add("<")
        Me.cmb_2.Items.Add("like")
        Me.cmb_2.Text = Me.cmb_2.Items(3)

    End Sub

    Private Sub hacer_busqueda_sp()
        Dim i As Integer
        Dim ls_parametros As String
        Dim oTransaccion As Transaccional.Conexion
        Dim ls_Script As String
        Dim otabla As DataTable
        Dim clGeneral As New ClasesGenerales.General

        ls_parametros = ""
        If Me.txt_buscar1.Text.Length = 0 Then
            For i = 0 To Me.cmb_valor1.Items.Count - 1
                ls_parametros = ls_parametros & IIf(i = 0, "", ",")
                ls_parametros = ls_parametros & "null"
            Next
        Else
            i = Me.cmb_valor1.Items.Count
            For i = 0 To Me.cmb_valor1.Items.Count - 1
                ls_parametros = ls_parametros & IIf(i = 0, "", ",")

                If Me.cmb_valor1.Items(i) = Me.cmb_valor1.Text Then
                    ls_parametros = ls_parametros & Me.txt_buscar1.Text.Trim
                Else
                    ls_parametros = ls_parametros & "null"
                End If
            Next
        End If

        oTransaccion = New Transaccional.Conexion("flexline")
        oTransaccion.open()
        ls_Script = ps_procedimiento_almacenado & " " & ps_parametros_fijos & ls_parametros

        Try
            otabla = oTransaccion.Obtiene(ls_Script)
            otabla.TableName = "tabla1"
            Me.dg_buscar.DataSource = otabla

            Dim estilo As New DataGridTableStyle
            estilo.MappingName = "tabla1"

            Dim nombrecolumna As String
            For i = 0 To otabla.Columns.Count() - 1
                nombrecolumna = otabla.Columns(i).ColumnName
                Dim column As New DataGridTextBoxColumn
                With column
                    .Width = clGeneral.tamaño_maximo_campo(otabla, " ", nombrecolumna, dg_buscar, 150, 50)
                    .MappingName = nombrecolumna.Trim
                    .HeaderText = nombrecolumna.Trim
                End With
                estilo.GridColumnStyles.Add(column)
            Next
            Me.dg_buscar.TableStyles.Clear()
            Me.dg_buscar.TableStyles.Add(estilo)
        Finally

        End Try
        oTransaccion.close()
        oTransaccion = Nothing
        clGeneral = Nothing
    End Sub

    Private Sub dg_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_buscar.Click
        Dim li_row_number As Integer

        li_row_number = Me.dg_buscar.CurrentCell.RowNumber
        resultado = Me.dg_buscar.Item(li_row_number, 0)

    End Sub

    Private Sub dg_buscar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_buscar.DoubleClick
        Dim li_row_number As Integer

        li_row_number = Me.dg_buscar.CurrentCell.RowNumber
        resultado = Me.dg_buscar.Item(li_row_number, 0)

        Me.Close()

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim li_row_number As Integer

            li_row_number = Me.dg_buscar.CurrentCell.RowNumber
            resultado = Me.dg_buscar.Item(li_row_number, 0)
        Catch ex As Exception
            resultado = ""
        End Try

        Me.Close()
    End Sub

    Public Sub hacer_busqueda_vista(Optional ByVal conexion As String = "flexline")
        Dim ls_parametros As String
        Dim oTransaccion As Transaccional.Conexion
        Dim ls_Script As String
        Dim clGeneral As New ClasesGenerales.General

        ls_parametros = ""

        If Me.txt_buscar1.Text.Length > 0 Then
            ls_parametros = ls_parametros & " " & Me.cmb_valor1.Text & " " & _
                            Me.cmb_1.Text & " '" & IIf(Me.cmb_1.Text = "like", "%", "") & Me.txt_buscar1.Text & IIf(Me.cmb_1.Text = "like", "%", "") & "'"

            If Me.txt_buscar2.Text.Length > 0 Then
                ls_parametros = ls_parametros & " " & Me.cmb_log1.Text & " " & _
                 Me.cmb_valor2.Text & " " & _
                 Me.cmb_2.Text & " '" & IIf(Me.cmb_2.Text = "like", "%", "") & Me.txt_buscar2.Text & IIf(Me.cmb_1.Text = "like", "%", "") & "'"

            End If

            oTransaccion = New Transaccional.Conexion(conexion)
            oTransaccion.open()
            If conexion = "flexline" Then
                ls_Script = "Select " & Me.lista_campos & " From " & ps_nombre_vista & " Where " & ps_parametros_fijos & " (" & ls_parametros & ")"
            Else
                ls_Script = "Select " & Me.lista_campos & " From " & ps_nombre_vista & " Where " & ps_parametros_fijos & " (" & ls_parametros & ")"
            End If


            Try
                dt = oTransaccion.Obtiene(ls_Script)
                Me.dgv_listadoclientes.DataSource = dt

                If Me.btn_ncorto.Visible = True And Me.btn_ncorto.Visible = True Then
                    clGeneral.Alinear_GridView(dt, Me.dgv_listadoclientes, ",CtaCte,CodLegal,RazonSocial,Giro,Tipo,Ejecutivo,CodPago,Vigencia_Cliente,direccion,telefono,contacto,ListaPrecio,NombreCorto,SubCanal,RutaLogistica,Clasificacion,Segmento,MotivoConsumo,idctacte,", "", "", "", "", ",CtaCte=50,CodLegal=65,RazonSocial=150,Giro=100,Tipo=90,Ejecutivo=80,CodPago=50,Vigencia_Cliente=75,direccion=100,telefono=60,contacto=55,ListaPrecio=70,NombreCorto=85,RutaLogistica=85,Clasificacion=85,Segmento=85,MotivoConsumo=85,", "", True, True, 250, 10)
                ElseIf Me.btn_ncorto.Visible = True Then
                    clGeneral.Alinear_GridView(dt, Me.dgv_listadoclientes, ",CtaCte,CodLegal,RazonSocial,Giro,Tipo,Ejecutivo,CodPago,Vigencia_Cliente,direccion,telefono,contacto,ListaPrecio,NombreCorto,,SubCanal,Clasificacion,Segmento,MotivoConsumo,idctacte,", "", "", "", "", ",CtaCte=50,CodLegal=65,RazonSocial=150,Giro=100,Tipo=90,Ejecutivo=80,CodPago=50,Vigencia_Cliente=75,direccion=100,telefono=60,contacto=55,ListaPrecio=70,NombreCorto=85,Clasificacion=85,Segmento=85,MotivoConsumo=85,", "", True, True, 250, 10)

                ElseIf Me.btn_rutaLogistica.Visible = True Then
                    clGeneral.Alinear_GridView(dt, Me.dgv_listadoclientes, ",CtaCte,CodLegal,RazonSocial,Giro,Tipo,Ejecutivo,CodPago,Vigencia_Cliente,direccion,telefono,contacto,ListaPrecio,RutaLogistica,", "", "", "", "", ",CtaCte=50,CodLegal=65,RazonSocial=150,Giro=100,Tipo=90,Ejecutivo=80,CodPago=50,Vigencia_Cliente=75,direccion=100,telefono=60,contacto=55,ListaPrecio=70,RutaLogistica=85,", "", True, True, 250, 10)
                Else
                    clGeneral.Alinear_GridView(dt, Me.dgv_listadoclientes, "", "", "", "", "", "", "", True, True, 250, 10)
                End If

                Me.dgv_listadoclientes.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 6.5)

            Catch ex As Exception
            Finally
            End Try
            oTransaccion.close()
            oTransaccion = Nothing
            clGeneral = Nothing
        End If
    End Sub

    Private Sub txt_buscar2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar2.KeyPress
        If e.KeyChar = Chr(13) Then
            If ps_nombre_vista.Length > 0 Then
                If conectar = String.Empty Then
                    hacer_busqueda_vista()
                Else
                    hacer_busqueda_vista(conectar)
                End If

            Else
                hacer_busqueda_sp()
            End If
        End If
    End Sub

    Private Sub btn_seleccion_multipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seleccion_multipe.Click
        Dim dr As DataRow

        For Each dr In dt.Rows
            dr.Item("agregar") = True
        Next

    End Sub



    Private Sub btn_ncorto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ncorto.Click

        'Try
        '    If cta_cte <> "" And razon_social.ToString <> "" And toco = True Then
        '        retorna = InputBox("Ingrese Nombre Corto:", "Modificacion", nombre_corto)
        '        If nombre_corto = retorna Or retorna = "" Then
        '        Else
        '            If MessageBox.Show("Esta Seguro de Aplicar Cambio ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '                If ps_nombre_vista.Length > 0 Then
        '                    If conectar = String.Empty Then
        '                        hacer_busqueda_vista()
        '                    Else
        '                        hacer_busqueda_vista(conectar)
        '                    End If
        '                Else
        '                    hacer_busqueda_sp()
        '                End If
        '                MessageBox.Show("Actualizacion fue realizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


        '            End If

        '        End If
        '    End If
        '    cta_cte = 0
        '    razon_social = ""
        '    toco = False

        'Catch ex As Exception

        'End Try
        If Me.toco Then
            Dim frm_nombre As New frm_nombre_corto
            frm_nombre.Pcta_cte = Me.cta_cte
            frm_nombre.Prazon_social = Me.razon_social
            frm_nombre.txt_nombre_corto.Text = Me.nombre_corto
            frm_nombre.txt_clasificacion.Text = Me.clasificacion
            frm_nombre.txt_segmento.Text = Me.segmento
            frm_nombre.txt_motivo_consumo.Text = Me.motivoconsumo
            frm_nombre.txtSubCanal.Text = Me.subcanal
            frm_nombre.ShowDialog(Me)
            frm_nombre.Dispose()
            frm_nombre = Nothing
            Me.toco = False
            'If ps_nombre_vista.Length > 0 Then
            '    If conectar = String.Empty Then
            '        hacer_busqueda_vista()
            '    Else
            '        hacer_busqueda_vista(conectar)
            '    End If
            'Else
            '    hacer_busqueda_sp()
            'End If


            End If
       



    End Sub


    Private Sub dgv_listadoclientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listadoclientes.Click
        Dim dr As DataRow
        Dim nRow As Integer

        toco = True

        Try
            nRow = Me.dgv_listadoclientes.CurrentCell.RowIndex
            cta_cte = Me.dgv_listadoclientes.Item(0, nRow).Value.ToString
            razon_social = Me.dgv_listadoclientes.Item("CtaCte", nRow).Value.ToString
            nombre_corto = Me.dgv_listadoclientes.Item("NombreCorto", nRow).Value.ToString
            ruta_logistica = Me.dgv_listadoclientes.Item("RutaLogistica", nRow).Value.ToString
            clasificacion = Me.dgv_listadoclientes.Item("clasificacion", nRow).Value.ToString
            segmento = Me.dgv_listadoclientes.Item("segmento", nRow).Value.ToString
            motivoconsumo = Me.dgv_listadoclientes.Item("motivoconsumo", nRow).Value.ToString
            subCanal = Me.dgv_listadoclientes.Item("subcanal", nRow).Value.ToString



        Catch ex As Exception

        End Try


    End Sub




    Private Sub dgv_listadoclientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_listadoclientes.DoubleClick


        Dim dr As DataRow
        Dim nRow As Integer


        Try
            nRow = Me.dgv_listadoclientes.CurrentCell.RowIndex
            resultado = Me.dgv_listadoclientes.Item(0, nRow).Value.ToString
        Catch ex As Exception
            resultado = ""
        End Try

        Me.Close()
    End Sub


    

    Private Sub btn_rutaLogistica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rutaLogistica.Click
        Try
            If cta_cte <> "" And toco = True Then
                Dim frm_busqueda_direcciones As New frm_ruta_logisitca

                frm_busqueda_direcciones.Text = "Asignacion Ruta Logistica .::"
                frm_busqueda_direcciones.ctacteDirecciones = cta_cte
                frm_busqueda_direcciones.ShowDialog()

            End If
            cta_cte = 0
            razon_social = ""
            toco = False

        Catch ex As Exception

        End Try


        'Dim oform As New frm_ruta_logisitca
        'oform.ShowDialog()


      
        'frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        ''frm_busqueda.ps_parametros_fijos = "'" & Me.cmb_empresa.Text.Trim & "',"
        'frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        'frm_busqueda.lista_campos = "CtaCte, CodLegal,RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente, direccion, telefono, contacto, ListaPrecio,NombreCorto,RutaLogistica"
        ''frm_busqueda.procedimiento_almacenado = "pa_sel_um_cliente_busqueda"
        'frm_busqueda.dg_buscar.ReadOnly = True
        'frm_busqueda.Size = New System.Drawing.Size(812, 520)
        '' frm_busqueda.dg_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ''frm_busqueda.dgv_listadoclientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(1, Byte))
        'If tiene_permisos("mc_busqueda_clientes_nc") Then
        '    frm_busqueda.btn_ncorto.Visible = True
        'Else
        '    frm_busqueda.btn_ncorto.Visible = False

        'End If




    End Sub

  
    Private Sub dgv_listadoclientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_listadoclientes.CellContentClick

    End Sub

    Private Sub txt_buscar1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar1.TextChanged

    End Sub
End Class


