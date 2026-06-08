Public Class frm_seleccionar_opcion
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
    Public WithEvents cmb_listado As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_opcion As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_seleccionar_opcion))
        Me.cmb_listado = New System.Windows.Forms.ComboBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.lbl_opcion = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmb_listado
        '
        Me.cmb_listado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_listado.DropDownWidth = 300
        Me.cmb_listado.Location = New System.Drawing.Point(72, 19)
        Me.cmb_listado.Name = "cmb_listado"
        Me.cmb_listado.Size = New System.Drawing.Size(256, 21)
        Me.cmb_listado.TabIndex = 0
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
        'lbl_opcion
        '
        Me.lbl_opcion.Location = New System.Drawing.Point(7, 20)
        Me.lbl_opcion.Name = "lbl_opcion"
        Me.lbl_opcion.Size = New System.Drawing.Size(57, 16)
        Me.lbl_opcion.TabIndex = 2
        Me.lbl_opcion.Text = "Opciones"
        '
        'frm_pickeador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 61)
        Me.Controls.Add(Me.lbl_opcion)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.cmb_listado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_pickeador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccione su Opcion"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public psempresa As String

    Public Sub Llenar_Combo_Chequeador()
        Dim dt As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()
        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_CHEQUEADOR','" & psempresa & "'"
        dt = otrans.Obtiene(ls_sql)

        otrans.close()

        Me.cmb_listado.DisplayMember = "DESCRIPCION"
        Me.cmb_listado.ValueMember = "DESCRIPCION"
        Me.cmb_listado.DataSource = dt

    End Sub

    Public Sub Llenar_Combo()

        Dim dt As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()
        ls_sql = "pa_sel_um_gen_tabcod NULL,'GEN_PICKER',NULL"
        dt = otrans.Obtiene(ls_sql)

        otrans.close()

        Me.cmb_listado.DisplayMember = "DESCRIPCION"
        Me.cmb_listado.ValueMember = "DESCRIPCION"
        Me.cmb_listado.DataSource = dt

    End Sub

    Public Sub Llenar_Combo_reportes()
        Me.cmb_listado.Items.Add("Flujo de Facturacion al CD")
        Me.cmb_listado.Items.Add("Flujo de Facturacion al CD Rango")
        Me.cmb_listado.Items.Add("Picking Diario")

    End Sub

    Public Sub Llenar_Combo_exportar(ByVal tipos As String)
        If tipos.LastIndexOf("X") > -1 Or _
                tipos.LastIndexOf("*") > -1 Then
            Me.cmb_listado.Items.Add("Excel")
        End If
        If tipos.LastIndexOf("P") > -1 Or _
                tipos.LastIndexOf("*") > -1 Then
            Me.cmb_listado.Items.Add("PDF")
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


        Me.cmb_listado.DataSource = dt
        Me.cmb_listado.DisplayMember = "descripcion"
        Me.cmb_listado.ValueMember = "cod_categoria"

    End Sub

    Public Sub Llenar_Combo_Ubicaciones_Fisicas()
        Dim dt As DataTable
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()
        ls_sql = "pa_sel_um_gen_tabcod null,'GEN_UBICACION'"
        dt = otrans.Obtiene(ls_sql)

        otrans.close()

        Me.cmb_listado.DataSource = dt
        Me.cmb_listado.DisplayMember = "CODIGO"
        Me.cmb_listado.ValueMember = "CODIGO"


    End Sub

    Public Sub Llenar_ComboString(ByVal tipos As String)
        Me.cmb_listado.Items.AddRange(tipos.Split(","))
        'If tipos.LastIndexOf("X") > -1 Or _
        '        tipos.LastIndexOf("*") > -1 Then
        '    Me.cmb_listado.Items.Add("Excel")
        'End If
        'If tipos.LastIndexOf("P") > -1 Or _
        '        tipos.LastIndexOf("*") > -1 Then
        '    Me.cmb_listado.Items.Add("PDF")
        'End If
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Me.Close()
    End Sub

    Private Sub frm_pickeador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
