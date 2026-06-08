Public Class frm_busqueda_general_mysql
    Inherits System.Windows.Forms.Form
    Private ps_nombre_vista As String = ""
    Private ps_procedimiento_almacenado As String
    Public ps_parametros_fijos As String
    Public lista_parametros As String
    Public lista_campos As String
    Private po_parametros As Array

    Public resultado As String

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
        CType(Me.dg_buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_valor3
        '
        Me.cmb_valor3.Location = New System.Drawing.Point(8, 64)
        Me.cmb_valor3.Name = "cmb_valor3"
        Me.cmb_valor3.Size = New System.Drawing.Size(104, 21)
        Me.cmb_valor3.TabIndex = 10
        Me.cmb_valor3.Visible = False
        '
        'cmb_valor2
        '
        Me.cmb_valor2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor2.DropDownWidth = 150
        Me.cmb_valor2.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor2.Location = New System.Drawing.Point(8, 40)
        Me.cmb_valor2.Name = "cmb_valor2"
        Me.cmb_valor2.Size = New System.Drawing.Size(104, 21)
        Me.cmb_valor2.TabIndex = 6
        '
        'cmb_valor1
        '
        Me.cmb_valor1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_valor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valor1.DropDownWidth = 150
        Me.cmb_valor1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_valor1.Location = New System.Drawing.Point(8, 16)
        Me.cmb_valor1.Name = "cmb_valor1"
        Me.cmb_valor1.Size = New System.Drawing.Size(104, 21)
        Me.cmb_valor1.TabIndex = 2
        '
        'cmb_3
        '
        Me.cmb_3.Location = New System.Drawing.Point(112, 64)
        Me.cmb_3.Name = "cmb_3"
        Me.cmb_3.Size = New System.Drawing.Size(40, 21)
        Me.cmb_3.TabIndex = 11
        Me.cmb_3.Visible = False
        '
        'cmb_2
        '
        Me.cmb_2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_2.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_2.Location = New System.Drawing.Point(112, 40)
        Me.cmb_2.Name = "cmb_2"
        Me.cmb_2.Size = New System.Drawing.Size(40, 21)
        Me.cmb_2.TabIndex = 7
        '
        'cmb_1
        '
        Me.cmb_1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_1.DropDownWidth = 50
        Me.cmb_1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_1.Location = New System.Drawing.Point(112, 16)
        Me.cmb_1.Name = "cmb_1"
        Me.cmb_1.Size = New System.Drawing.Size(40, 21)
        Me.cmb_1.TabIndex = 3
        '
        'txt_buscar3
        '
        Me.txt_buscar3.Location = New System.Drawing.Point(152, 64)
        Me.txt_buscar3.Name = "txt_buscar3"
        Me.txt_buscar3.Size = New System.Drawing.Size(288, 20)
        Me.txt_buscar3.TabIndex = 12
        Me.txt_buscar3.Visible = False
        '
        'txt_buscar2
        '
        Me.txt_buscar2.Location = New System.Drawing.Point(152, 40)
        Me.txt_buscar2.Name = "txt_buscar2"
        Me.txt_buscar2.Size = New System.Drawing.Size(288, 20)
        Me.txt_buscar2.TabIndex = 8
        '
        'txt_buscar1
        '
        Me.txt_buscar1.Location = New System.Drawing.Point(152, 16)
        Me.txt_buscar1.Name = "txt_buscar1"
        Me.txt_buscar1.Size = New System.Drawing.Size(288, 20)
        Me.txt_buscar1.TabIndex = 4
        '
        'dg_buscar
        '
        Me.dg_buscar.DataMember = ""
        Me.dg_buscar.FlatMode = True
        Me.dg_buscar.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_buscar.Location = New System.Drawing.Point(8, 96)
        Me.dg_buscar.Name = "dg_buscar"
        Me.dg_buscar.Size = New System.Drawing.Size(544, 296)
        Me.dg_buscar.TabIndex = 12
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.ForeColor = System.Drawing.Color.White
        Me.Btn_Aceptar.Location = New System.Drawing.Point(477, 72)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Aceptar.TabIndex = 21
        Me.Btn_Aceptar.Text = "Aceptar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = False
        '
        'cmb_log1
        '
        Me.cmb_log1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_log1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_log1.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_log1.Items.AddRange(New Object() {"And", "Or"})
        Me.cmb_log1.Location = New System.Drawing.Point(441, 16)
        Me.cmb_log1.Name = "cmb_log1"
        Me.cmb_log1.Size = New System.Drawing.Size(48, 21)
        Me.cmb_log1.TabIndex = 5
        '
        'cmb_log2
        '
        Me.cmb_log2.Location = New System.Drawing.Point(441, 40)
        Me.cmb_log2.Name = "cmb_log2"
        Me.cmb_log2.Size = New System.Drawing.Size(48, 21)
        Me.cmb_log2.TabIndex = 9
        Me.cmb_log2.Visible = False
        '
        'frm_busqueda_general_mysql
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(560, 414)
        Me.Controls.Add(Me.cmb_log2)
        Me.Controls.Add(Me.cmb_log1)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.cmb_valor3)
        Me.Controls.Add(Me.cmb_valor2)
        Me.Controls.Add(Me.cmb_valor1)
        Me.Controls.Add(Me.cmb_3)
        Me.Controls.Add(Me.cmb_2)
        Me.Controls.Add(Me.cmb_1)
        Me.Controls.Add(Me.txt_buscar3)
        Me.Controls.Add(Me.txt_buscar2)
        Me.Controls.Add(Me.txt_buscar1)
        Me.Controls.Add(Me.dg_buscar)
        Me.Name = "frm_busqueda_general_mysql"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Busqueda"
        CType(Me.dg_buscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarcombos_operadores()
    End Sub

    Private Sub txt_buscar1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar1.KeyPress
        If e.KeyChar = Chr(13) Then
            If ps_nombre_vista.Length > 0 Then
                hacer_busqueda_vista()
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

    Public Sub llenarcombos_operadores()


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
        Dim oTransaccion As Transaccional.Conexion_mysql
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

        oTransaccion = New Transaccional.Conexion_mysql("OnBase")
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
        clGeneral = Nothing
    End Sub

    Private Sub dg_buscar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_buscar.DoubleClick
        Dim li_row_number As Integer

        li_row_number = Me.dg_buscar.CurrentCell.RowNumber
        resultado = Me.dg_buscar.Item(li_row_number, 0).ToString

        Me.Close()

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Dim li_row_number As Integer

        li_row_number = Me.dg_buscar.CurrentCell.RowNumber
        resultado = Me.dg_buscar.Item(li_row_number, 0)

        Me.Close()
    End Sub
    Public Sub hacer_busqueda_vista()

        Dim ls_parametros As String
        Dim oTransaccion As Transaccional.Conexion_mysql
        Dim ls_Script As String
        Dim otabla As DataTable
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

            oTransaccion = New Transaccional.Conexion_mysql("OnBase")
            oTransaccion.open()
            ls_Script = "Select " & Me.lista_campos & " From " & ps_nombre_vista & " Where " & ps_parametros_fijos & " (" & ls_parametros & ")"

            Try
                otabla = oTransaccion.Obtiene(ls_Script)
                otabla.TableName = "tabla1"
                Me.dg_buscar.DataSource = otabla

                clGeneral.Alinea_Grid(otabla, Me.dg_buscar, otabla.TableName(), -1, 150, 40, True, False, "", True, "")

            Finally

            End Try
            oTransaccion.close()
            clGeneral = Nothing
        End If
    End Sub

    Private Sub txt_buscar2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar2.KeyPress
        If e.KeyChar = Chr(13) Then
            If ps_nombre_vista.Length > 0 Then
                hacer_busqueda_vista()
            Else
                hacer_busqueda_sp()
            End If
        End If
    End Sub

End Class


