Public Class frm_liberar_ppto_cliente
    Inherits System.Windows.Forms.Form

    Public liberar_Producto As Boolean = False

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
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents cmb_periodos As System.Windows.Forms.ComboBox
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_liberar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cliente As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_liberar_ppto_cliente))
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.cmb_periodos = New System.Windows.Forms.ComboBox
        Me.txt_vendedor = New System.Windows.Forms.TextBox
        Me.lbl_cliente = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.btn_liberar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_codigo
        '
        Me.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo.Location = New System.Drawing.Point(88, 24)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.TabIndex = 1
        Me.txt_codigo.Text = ""
        '
        'txt_nombre
        '
        Me.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre.Location = New System.Drawing.Point(192, 24)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.ReadOnly = True
        Me.txt_nombre.Size = New System.Drawing.Size(272, 20)
        Me.txt_nombre.TabIndex = 2
        Me.txt_nombre.Text = ""
        '
        'cmb_periodos
        '
        Me.cmb_periodos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_periodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_periodos.DropDownWidth = 125
        Me.cmb_periodos.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_periodos.Location = New System.Drawing.Point(88, 112)
        Me.cmb_periodos.Name = "cmb_periodos"
        Me.cmb_periodos.Size = New System.Drawing.Size(96, 21)
        Me.cmb_periodos.TabIndex = 3
        '
        'txt_vendedor
        '
        Me.txt_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vendedor.Location = New System.Drawing.Point(88, 38)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.ReadOnly = True
        Me.txt_vendedor.Size = New System.Drawing.Size(376, 20)
        Me.txt_vendedor.TabIndex = 4
        Me.txt_vendedor.Text = ""
        '
        'lbl_cliente
        '
        Me.lbl_cliente.Location = New System.Drawing.Point(0, 24)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(80, 23)
        Me.lbl_cliente.TabIndex = 5
        Me.lbl_cliente.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Vendedor"
        '
        'btn_buscar
        '
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Location = New System.Drawing.Point(472, 24)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(24, 24)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "..."
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_liberar
        '
        Me.btn_liberar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_liberar.Image = CType(resources.GetObject("btn_liberar.Image"), System.Drawing.Image)
        Me.btn_liberar.Location = New System.Drawing.Point(352, 128)
        Me.btn_liberar.Name = "btn_liberar"
        Me.btn_liberar.Size = New System.Drawing.Size(80, 56)
        Me.btn_liberar.TabIndex = 7
        Me.btn_liberar.Text = "Liberar"
        Me.btn_liberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(2, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Periodo"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Direccion"
        '
        'txt_direccion
        '
        Me.txt_direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_direccion.Location = New System.Drawing.Point(88, 14)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.ReadOnly = True
        Me.txt_direccion.Size = New System.Drawing.Size(376, 20)
        Me.txt_direccion.TabIndex = 4
        Me.txt_direccion.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_direccion)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 64)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'frm_liberar_ppto_cliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 189)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_liberar)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.cmb_periodos)
        Me.Name = "frm_liberar_ppto_cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Liberar Presupuesto de Cliente .::"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Periodos_Utilizados()
        Dim otrans As New Transaccional.Conexion("Umbral")
        Dim ls_sql As String
        Dim dt As DataTable

        If Me.txt_codigo.Text.Length > 0 Then
            Try
                otrans.open()
                ls_sql = "pa_sel_um_integracion_cliente_periodos '" & gs_empresa & "'"
                If liberar_Producto Then
                    ls_sql += ",null,'" & Me.txt_codigo.Text.Trim & "'"
                Else
                    ls_sql += ",'" & Me.txt_codigo.Text.Trim & "',null"
                End If
                '                ls_sql = "pa_sel_um_integracion_cliente_periodos '" & gs_empresa & "','" & Me.txt_codigo.Text.Trim & "'"
                dt = otrans.Obtiene(ls_sql)
                Me.cmb_periodos.DataSource = dt
                Me.cmb_periodos.ValueMember = "periodo"
                Me.cmb_periodos.ValueMember = "periodo"

            Catch ex As Exception
            Finally
                otrans.close()

            End Try
        End If
        otrans = Nothing
    End Sub

    Private Sub Buscar_Cliente()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        If Me.txt_codigo.Text.Length > 0 Then
            Try
                otrans.open()
                ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & Me.txt_codigo.Text.Trim & "'"

                dt = otrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar_Pantalla()
                Else
                    Me.txt_nombre.Text = dt.Rows(0).Item("nombre_cliente") 'dt.Rows(0).Item("RazonSocial") & "/" & dt.Rows(0).Item("giro")
                    Me.txt_vendedor.Text = dt.Rows(0).Item("Ejecutivo")
                    Me.txt_direccion.Text = dt.Rows(0).Item("Direccion").ToString
                End If

            Catch ex As Exception
                Limpiar_Pantalla()
            Finally
                otrans.close()
            End Try
        Else
            Limpiar_Pantalla()
        End If

        otrans = Nothing
        Periodos_Utilizados()

    End Sub

    Private Sub Buscar_Producto()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        If Me.txt_codigo.Text.Length > 0 Then
            Try
                otrans.open()
                ls_sql = "pa_sel_um_producto '" & gs_empresa & "','" & Me.txt_codigo.Text.Trim & "'"

                dt = otrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar_Pantalla()
                Else
                    Me.txt_nombre.Text = dt.Rows(0).Item("glosa") 'dt.Rows(0).Item("RazonSocial") & "/" & dt.Rows(0).Item("giro")
                    'Me.txt_vendedor.Text = dt.Rows(0).Item("Ejecutivo")
                    'Me.txt_direccion.Text = dt.Rows(0).Item("Direccion").ToString
                End If

            Catch ex As Exception
                Limpiar_Pantalla()
            Finally
                otrans.close()
            End Try
        Else
            Limpiar_Pantalla()
        End If

        otrans = Nothing
        Periodos_Utilizados()
    End Sub

    Private Sub Limpiar_Pantalla()
        Me.txt_nombre.Text = ""
        Me.txt_vendedor.Text = ""
        Me.txt_codigo.Text = ""
        Me.txt_direccion.Text = ""
    End Sub

    Private Sub Consultar_Cliente()
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm_busqueda.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente "
        frm_busqueda.ShowDialog(Me)

        Me.txt_codigo.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        Buscar_Cliente()
    End Sub

    Private Sub Consultar_Productos()
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "producto,glosa,tipoproducto,familia"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        frm_busqueda.lista_campos = "producto, glosa, tipoproducto, familia, subfamilia, tipo "
        frm_busqueda.txt_buscar1.Focus()
        frm_busqueda.ShowDialog(Me)

        Me.txt_codigo.Text = frm_busqueda.resultado
        frm_busqueda.Dispose()
        frm_busqueda = Nothing

        Buscar_Producto()
    End Sub

    Private Sub Eliminar_Periodo_Cliente()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("umbral")

        If Me.txt_codigo.Text.Length > 0 Then
            Try
                otrans.open()
                ls_sql = "pa_del_um_integracion_cliente_periodo '" & gs_empresa & "','" & Me.txt_codigo.Text & "','" & Me.cmb_periodos.SelectedValue & "'"
                dt = otrans.Obtiene(ls_sql)
                If otrans.Codigo_error = 0 Then
                    MessageBox.Show("Se Elimino el Periodo Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Periodos_Utilizados()
                End If
            Catch ex As Exception
            Finally
                otrans.close()
            End Try
        Else

        End If
        otrans = Nothing
    End Sub


    Private Sub Eliminar_Periodo_Producto()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("umbral")

        If Me.txt_codigo.Text.Length > 0 Then
            Try
                otrans.open()
                ls_sql = "pa_del_um_integracion_producto_periodo '" & gs_empresa & "','" & Me.txt_codigo.Text & "','" & Me.cmb_periodos.SelectedValue & "'"
                dt = otrans.Obtiene(ls_sql)
                If otrans.Codigo_error = 0 Then
                    MessageBox.Show("Se Elimino el Periodo Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Periodos_Utilizados()
                End If
            Catch ex As Exception
            Finally
                otrans.close()
            End Try
        Else

        End If
        otrans = Nothing
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        If liberar_Producto Then
            Consultar_Productos()
        Else
            Consultar_Cliente()
        End If

    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        If liberar_Producto Then
            Buscar_Producto()
        Else
            Buscar_Cliente()
        End If

    End Sub

    Private Sub btn_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_liberar.Click
        If MessageBox.Show("Esta Seguro de Eliminar Este Presupuesto", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            If liberar_Producto Then
                Eliminar_Periodo_Producto()
            Else
                Eliminar_Periodo_Cliente()

            End If
            'Eliminar_Periodo()
        End If
    End Sub

    Private Sub Customizar_Formulario_Producto()
        Me.lbl_cliente.Text = "Producto"
        Me.GroupBox1.Visible = False
        Me.Text = ":: Liberar Presupuesto De Producto ::"
    End Sub

    Private Sub frm_liberar_ppto_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If liberar_Producto Then
            Customizar_Formulario_Producto()
        End If

    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub
End Class
