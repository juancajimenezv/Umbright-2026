Public Class frm_mantenimiento
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
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents cmb_tabla As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tabcontrol1 As System.Windows.Forms.TabControl
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tabcontrol1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_tabla = New System.Windows.Forms.ComboBox
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.tabcontrol1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabcontrol1
        '
        Me.tabcontrol1.Controls.Add(Me.TabPage1)
        Me.tabcontrol1.Controls.Add(Me.TabPage2)
        Me.tabcontrol1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabcontrol1.Location = New System.Drawing.Point(8, 8)
        Me.tabcontrol1.Name = "tabcontrol1"
        Me.tabcontrol1.SelectedIndex = 0
        Me.tabcontrol1.Size = New System.Drawing.Size(440, 272)
        Me.tabcontrol1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmb_tabla)
        Me.TabPage1.Controls.Add(Me.btn_grabar)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_descripcion)
        Me.TabPage1.Controls.Add(Me.txt_codigo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(432, 246)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tabla"
        Me.Label3.Visible = False
        '
        'cmb_tabla
        '
        Me.cmb_tabla.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tabla.DropDownWidth = 200
        Me.cmb_tabla.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tabla.Location = New System.Drawing.Point(80, 16)
        Me.cmb_tabla.Name = "cmb_tabla"
        Me.cmb_tabla.Size = New System.Drawing.Size(96, 21)
        Me.cmb_tabla.TabIndex = 5
        Me.cmb_tabla.Visible = False
        '
        'btn_grabar
        '
        Me.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_grabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.Location = New System.Drawing.Point(120, 152)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(112, 24)
        Me.btn_grabar.TabIndex = 4
        Me.btn_grabar.Text = "Guardar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Codigo"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Location = New System.Drawing.Point(80, 80)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(312, 21)
        Me.txt_descripcion.TabIndex = 1
        Me.txt_descripcion.Text = ""
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(80, 48)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.ReadOnly = True
        Me.txt_codigo.Size = New System.Drawing.Size(80, 21)
        Me.txt_codigo.TabIndex = 0
        Me.txt_codigo.TabStop = False
        Me.txt_codigo.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage2.Controls.Add(Me.btn_eliminar)
        Me.TabPage2.Controls.Add(Me.btn_nuevo)
        Me.TabPage2.Controls.Add(Me.DataGrid1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(432, 246)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_eliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Location = New System.Drawing.Point(352, 64)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.TabIndex = 2
        Me.btn_eliminar.Text = "Eliminar"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Location = New System.Drawing.Point(352, 24)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "Nuevo"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 16)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(312, 224)
        Me.DataGrid1.TabIndex = 0
        '
        'frm_mantenimiento
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 294)
        Me.Controls.Add(Me.tabcontrol1)
        Me.Name = "frm_mantenimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimientos"
        Me.tabcontrol1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public nombre_tabla As String
    Public nombre_maestro As String = ""

    Private Sub frm_mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_seguridad()
        llenar_grid()
        Me.tabcontrol1.SelectedTab = Me.TabPage2

    End Sub

    Public Sub llenar_combo()
        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim clgen As New ClasesGenerales.General
        Dim nombre_sp As String

        Try
            nombre_sp = "call pa_sel_um_" & nombre_maestro

            otrans.open()
            otabla = otrans.Obtiene(nombre_sp)

            Me.cmb_tabla.DataSource = otabla
            Me.cmb_tabla.ValueMember = otabla.Columns(0).ColumnName '"cod_tabla"
            Me.cmb_tabla.DisplayMember = otabla.Columns(1).ColumnName  '"descripcion"
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub llenar_grid()
        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")
        Dim clgen As New ClasesGenerales.General
        Dim nombre_sp As String

        Try
            nombre_sp = "call pa_sel_um_" & nombre_tabla
            If nombre_maestro.Length > 0 Then
                nombre_sp = nombre_sp & "(null)"
            End If
            otrans.open()
            otabla = otrans.Obtiene(nombre_sp)

            Me.DataGrid1.DataSource = otabla
            clgen.Alinea_Grid(otabla, Me.DataGrid1, otabla.TableName, -1, 200, 0, True, False, "", True, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        clgen = Nothing

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.tabcontrol1.SelectedTab = Me.TabPage1
        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
        Me.btn_grabar.Text = "Guardar"

    End Sub

    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
        Dim li_row_number As Integer


        li_row_number = Me.DataGrid1.CurrentCell.RowNumber()
        Me.txt_codigo.Text = Me.DataGrid1.Item(li_row_number, 0).ToString
        Me.txt_descripcion.Text = Me.DataGrid1.Item(li_row_number, 1)

        If nombre_maestro.Length > 0 Then
            Me.cmb_tabla.Text = Me.DataGrid1.Item(li_row_number, 2)
        End If
        Me.tabcontrol1.SelectedTab = Me.TabPage1
        Me.btn_grabar.Text = "Actualizar"

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        Dim otrans As New Transaccional.Conexion_mysql("onBase")

        Dim nombre_sp As String
        otrans.open()

        If btn_grabar.Text = "Guardar" Then
            ''Registro Nuevo
            If Me.nombre_maestro.Length = 0 Then
                nombre_sp = "call pa_ins_um_" & nombre_tabla & " ('" & Me.txt_descripcion.Text & "')"
            Else
                nombre_sp = "call pa_ins_um_" & nombre_tabla & " (" & Me.cmb_tabla.SelectedValue.ToString & " ,'" & Me.txt_descripcion.Text & "')"
            End If
            otrans.Ingresa(nombre_sp)
        Else
            ''Registro Existente

            If Me.nombre_maestro.Length = 0 Then
                nombre_sp = "call pa_upd_um_" & nombre_tabla & " (" & Me.txt_codigo.Text & ", '" & Me.txt_descripcion.Text & "')"
            Else
                nombre_sp = "call pa_upd_um_" & nombre_tabla & " (" & Me.cmb_tabla.SelectedValue.ToString & "," & Me.txt_codigo.Text & ", '" & Me.txt_descripcion.Text & "')"
            End If

            otrans.Actualiza(nombre_sp)
        End If

        If otrans.Codigo_error > 0 Then
            MessageBox.Show(otrans.descripcion_error)
        Else
            MessageBox.Show("Proceso Existoso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        otrans.close()
        otrans = Nothing

        llenar_grid()
        Me.tabcontrol1.SelectedTab = Me.TabPage2
        Me.txt_codigo.ReadOnly = True
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim otrans As New Transaccional.Conexion_mysql("onBase")

        Dim nombre_sp As String

        Dim li_row_number As Integer
        Dim resultado As String

        li_row_number = Me.DataGrid1.CurrentCell.RowNumber()
        resultado = Me.DataGrid1.Item(li_row_number, 0).ToString & "-" & Me.DataGrid1.Item(li_row_number, 1)


        If MessageBox.Show("Esta Seguro de Eliminar " & resultado, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                otrans.open()
                nombre_sp = "call pa_del_um_" & nombre_tabla & " (" & Me.DataGrid1.Item(li_row_number, 0).ToString & ")"
                otrans.Elimina(nombre_sp)
                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Eliminacion Satisfactoria", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                otrans.close()
                otrans = Nothing

                llenar_grid()
                Me.tabcontrol1.SelectedTab = Me.TabPage2
            End Try

        End If

    End Sub
    Private Sub aplicar_seguridad()

        ''If ps_permisos.IndexOf("W", 0, ps_permisos.Length) < 0 Then
        ''    Me.btn_grabar.Visible = False
        ''    Me.btn_nuevo.Visible = False

        ''End If

        ''If ps_permisos.IndexOf("D", 0, ps_permisos.Length) < 0 Then
        ''    Me.btn_eliminar.Visible = False
        ''End If

    End Sub


End Class
