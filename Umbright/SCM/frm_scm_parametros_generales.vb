Public Class frm_scm_parametros_generales
    Inherits System.Windows.Forms.Form
    Dim ds_parametros As DataSet

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
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dg_pareto As System.Windows.Forms.DataGrid
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_no_meses As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chk_mes_actual As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_min_cajas As System.Windows.Forms.TextBox
    Friend WithEvents txt_max_cajas As System.Windows.Forms.TextBox
    Private WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_lista_precio As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_scm_parametros_generales))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.chk_mes_actual = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_no_meses = New System.Windows.Forms.TextBox
        Me.txt_min_cajas = New System.Windows.Forms.TextBox
        Me.txt_max_cajas = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dg_pareto = New System.Windows.Forms.DataGrid
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_lista_precio = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_pareto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(368, 240)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.chk_mes_actual)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_no_meses)
        Me.TabPage1.Controls.Add(Me.txt_min_cajas)
        Me.TabPage1.Controls.Add(Me.txt_max_cajas)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txt_lista_precio)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(360, 214)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Parametros"
        '
        'chk_mes_actual
        '
        Me.chk_mes_actual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_mes_actual.Location = New System.Drawing.Point(8, 110)
        Me.chk_mes_actual.Name = "chk_mes_actual"
        Me.chk_mes_actual.Size = New System.Drawing.Size(144, 24)
        Me.chk_mes_actual.TabIndex = 3
        Me.chk_mes_actual.Text = "Incluir Mes Actual"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No. Meses Proyeccion"
        '
        'txt_no_meses
        '
        Me.txt_no_meses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_no_meses.Location = New System.Drawing.Point(136, 16)
        Me.txt_no_meses.Name = "txt_no_meses"
        Me.txt_no_meses.Size = New System.Drawing.Size(64, 20)
        Me.txt_no_meses.TabIndex = 0
        Me.txt_no_meses.Text = "3"
        Me.txt_no_meses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_min_cajas
        '
        Me.txt_min_cajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_min_cajas.Location = New System.Drawing.Point(136, 40)
        Me.txt_min_cajas.Name = "txt_min_cajas"
        Me.txt_min_cajas.Size = New System.Drawing.Size(64, 20)
        Me.txt_min_cajas.TabIndex = 0
        Me.txt_min_cajas.Text = "50"
        Me.txt_min_cajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_max_cajas
        '
        Me.txt_max_cajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_max_cajas.Location = New System.Drawing.Point(136, 64)
        Me.txt_max_cajas.Name = "txt_max_cajas"
        Me.txt_max_cajas.Size = New System.Drawing.Size(64, 20)
        Me.txt_max_cajas.TabIndex = 0
        Me.txt_max_cajas.Text = "50"
        Me.txt_max_cajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Porc. Min Cajas"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Porc. Max Cajas"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabPage2.Controls.Add(Me.dg_pareto)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(360, 214)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Definicion Pareto"
        '
        'dg_pareto
        '
        Me.dg_pareto.CaptionVisible = False
        Me.dg_pareto.DataMember = ""
        Me.dg_pareto.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_pareto.Location = New System.Drawing.Point(6, 5)
        Me.dg_pareto.Name = "dg_pareto"
        Me.dg_pareto.Size = New System.Drawing.Size(352, 208)
        Me.dg_pareto.TabIndex = 0
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(373, 8)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(72, 56)
        Me.btn_guardar.TabIndex = 1
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Lista de Precios"
        '
        'txt_lista_precio
        '
        Me.txt_lista_precio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lista_precio.Location = New System.Drawing.Point(136, 136)
        Me.txt_lista_precio.Name = "txt_lista_precio"
        Me.txt_lista_precio.Size = New System.Drawing.Size(112, 20)
        Me.txt_lista_precio.TabIndex = 0
        Me.txt_lista_precio.Text = ""
        '
        'frm_scm_parametros_generales
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(448, 245)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_scm_parametros_generales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. SCM - Parametros Generales .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_pareto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Crear_Estructura()
        Dim dt As New DataTable("pareto")

        dt.Columns.Add(New DataColumn("pareto", GetType(String)))
        dt.Columns.Add(New DataColumn("%_Maximo_LT", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("%_Minimo_LT", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("%_pareto", GetType(Decimal)))
        ds_parametros.Tables.Add(dt.Copy)
        Me.dg_pareto.DataSource = ds_parametros.Tables("pareto")

    End Sub

    Private Sub inicializar()
        ds_parametros = New DataSet
    End Sub

    Private Sub Llenar_Informacion()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("scm")
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim clsgen As New ClasesGenerales.General

        Try
            otrans.open()
            ls_sql = "pa_sel_um_pg_pareto"
            dt = otrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                dr_aux = ds_parametros.Tables("pareto").NewRow
                dr_aux.Item("pareto") = dr.Item("pareto")
                dr_aux.Item("%_maximo_lt") = dr.Item("porcentaje_maximo_lead_time")
                dr_aux.Item("%_minimo_lt") = dr.Item("porcentaje_minimo_lead_time")
                dr_aux.Item("%_pareto") = dr.Item("porcentaje")
                ds_parametros.Tables("pareto").Rows.Add(dr_aux)
            Next

            ls_sql = "pa_sel_um_scm_parametros_generales"
            dt = otrans.Obtiene(ls_sql)
            Me.txt_no_meses.Text = dt.Rows(0).Item("meses_proyeccion").ToString
            Me.chk_mes_actual.Checked = dt.Rows(0).Item("incluir_mes_actual_proyeccion")
            Me.txt_max_cajas.Text = dt.Rows(0).Item("porcentaje_min_cajas")
            Me.txt_min_cajas.Text = dt.Rows(0).Item("porcentaje_max_cajas")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        clsgen.Alinea_Grid(ds_parametros.Tables("pareto"), Me.dg_pareto, ds_parametros.Tables("pareto").TableName, -1, 250, 50, False, True, "", False, "")
        clsgen = Nothing

    End Sub

    Private Sub Guardar_Paretos()
        Dim dr As DataRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("scm")
        Dim ls_sql As String

        Try
            otrans.open()
            If ds_parametros.Tables("pareto").Rows.Count > -1 Then
                'borro los paretos uno a uno
                ls_sql = "pa_sel_um_pg_pareto "
                dt = otrans.Obtiene(ls_sql)
                For Each dr In dt.Rows
                    ls_sql = "pa_del_um_pg_pareto '" & dr.Item("pareto").ToString & "'"
                    otrans.Elimina(ls_sql)
                Next

                For Each dr In ds_parametros.Tables("pareto").Rows

                    ls_sql = "pa_ins_um_pg_pareto '" & _
                                dr.Item("pareto").ToString & "'," & _
                                dr.Item("%_maximo_lt") & "," & _
                                dr.Item("%_minimo_lt") & "," & _
                                dr.Item("%_pareto")

                    otrans.Ingresa(ls_sql)
                    If otrans.Codigo_error > 0 Then
                        MessageBox.Show(otrans.descripcion_error)
                    End If
                Next
            Else
                MessageBox.Show("No Puede Dejar Vacio los Paretos", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        
    End Sub

    Private Sub Guardar_Parametros()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("scm")

        Try
            otrans.open()
            ls_sql = "pa_del_um_scm_parametros_generales -1"
            otrans.Elimina(ls_sql)

            ls_sql = "pa_ins_um_scm_parametros_generales " & Me.txt_no_meses.Text & "," & _
                    IIf(Me.chk_mes_actual.CheckState = CheckState.Checked, 1, 0) & "," & _
                    Me.txt_min_cajas.Text & "," & Me.txt_max_cajas.Text & ",'" & Me.txt_lista_precio.Text & "'"
            otrans.Ingresa(ls_sql)

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub frm_scm_parametros_generales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializar()
        Crear_Estructura()
        Llenar_Informacion()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Guardar_Paretos()
        Guardar_Parametros()
        MessageBox.Show("Proceso Finalizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
