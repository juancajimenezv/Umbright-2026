Public Class frm_pickeador_TMK
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
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_nombre_picker As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_pickeador))
        Me.cmb_nombre_picker = New System.Windows.Forms.ComboBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmb_nombre_picker
        '
        Me.cmb_nombre_picker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nombre_picker.DropDownWidth = 300
        Me.cmb_nombre_picker.Location = New System.Drawing.Point(72, 19)
        Me.cmb_nombre_picker.Name = "cmb_nombre_picker"
        Me.cmb_nombre_picker.Size = New System.Drawing.Size(256, 21)
        Me.cmb_nombre_picker.TabIndex = 0
        '
        'btn_aceptar
        '
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar.Location = New System.Drawing.Point(336, 2)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(72, 56)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre"
        '
        'frm_pickeador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 61)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.cmb_nombre_picker)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_pickeador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccione su Nombre"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Llenar_Combo_Chequeador()
        Dim dt As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()
        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_CHEQUEADOR_TMK','" & gs_empresa & "'"
        dt = otrans.Obtiene(ls_sql)

        otrans.close()

        Me.cmb_nombre_picker.DisplayMember = "DESCRIPCION"
        Me.cmb_nombre_picker.ValueMember = "DESCRIPCION"
        Me.cmb_nombre_picker.DataSource = dt

    End Sub

    Public Sub Llenar_Combo()

        Dim dt As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()
        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_PICKER',NULL"
        dt = otrans.Obtiene(ls_sql)

        otrans.close()

        Me.cmb_nombre_picker.DisplayMember = "DESCRIPCION"
        Me.cmb_nombre_picker.ValueMember = "DESCRIPCION"
        Me.cmb_nombre_picker.DataSource = dt

    End Sub

    Public Sub Llenar_Combo_reportes()
        Me.cmb_nombre_picker.Items.Add("Flujo de Facturacion al CD")
        Me.cmb_nombre_picker.Items.Add("Flujo de Facturacion al CD Rango")
        Me.cmb_nombre_picker.Items.Add("Picking Diario")

    End Sub

    Public Sub Llenar_Combo_exportar(ByVal tipos As String)
        If tipos.LastIndexOf("X") > -1 Or
                tipos.LastIndexOf("*") > -1 Then
            Me.cmb_nombre_picker.Items.Add("Excel")
        End If
        If tipos.LastIndexOf("P") > -1 Or
                tipos.LastIndexOf("*") > -1 Then
            Me.cmb_nombre_picker.Items.Add("PDF")
        End If
    End Sub

    Public Sub Llenar_Combo_Tipos_Activos()
        Dim dt As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion_mysql("OnBase")
        otrans.open()
        ls_sql = "call pa_sel_um_act_categoria ()"
        dt = otrans.Obtiene(ls_sql)

        otrans.close()


        Me.cmb_nombre_picker.DataSource = dt
        Me.cmb_nombre_picker.DisplayMember = "descripcion"
        Me.cmb_nombre_picker.ValueMember = "cod_categoria"

    End Sub

    Public Sub Llenar_Combo_Ubicaciones_Fisicas()
        Dim dt As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()
        ls_sql = "pa_sel_um_gen_tabcod null,'GEN_UBICACION'"
        dt = otrans.Obtiene(ls_sql)

        otrans.close()

        Me.cmb_nombre_picker.DataSource = dt
        Me.cmb_nombre_picker.DisplayMember = "CODIGO"
        Me.cmb_nombre_picker.ValueMember = "CODIGO"


    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Me.Close()
    End Sub

    Private Sub frm_pickeador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
