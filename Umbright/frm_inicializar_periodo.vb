Public Class frm_inicializar_periodo
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
    Friend WithEvents cmb_periodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_empresa As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_inicializar_periodo))
        Me.cmb_periodo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_generar = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lbl_empresa = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'cmb_periodo
        '
        Me.cmb_periodo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_periodo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_periodo.Location = New System.Drawing.Point(134, 58)
        Me.cmb_periodo.Name = "cmb_periodo"
        Me.cmb_periodo.Size = New System.Drawing.Size(121, 24)
        Me.cmb_periodo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(38, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Periodo"
        '
        'btn_generar
        '
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 0
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(96, 101)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(96, 72)
        Me.btn_generar.TabIndex = 2
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 189)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(264, 24)
        Me.ProgressBar1.Step = 5
        Me.ProgressBar1.TabIndex = 3
        '
        'lbl_empresa
        '
        Me.lbl_empresa.Font = New System.Drawing.Font("Arial", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_empresa.Location = New System.Drawing.Point(0, 21)
        Me.lbl_empresa.Name = "lbl_empresa"
        Me.lbl_empresa.Size = New System.Drawing.Size(288, 23)
        Me.lbl_empresa.TabIndex = 4
        Me.lbl_empresa.Text = "empresa"
        Me.lbl_empresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Empresa"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "running_process.png")
        '
        'frm_inicializar_periodo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(288, 225)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_empresa)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_periodo)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_inicializar_periodo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicializar Periodo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Llenar_Combos()
        Dim ls_sql As String

        Dim otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        ls_sql = "pa_sel_um_gen_tabcod null,'CONFIG.PERIODO','" & gs_empresa & "'"

        Try
            otrans.open()
            dt = otrans.Obtiene(ls_sql)
            dt.DefaultView.Sort = "valor5 desc"
            Me.cmb_periodo.DataSource = dt
            Me.cmb_periodo.ValueMember = "CODIGO"
            Me.cmb_periodo.DisplayMember = "CODIGO"

            Me.cmb_periodo.SelectedValue = Now.AddMonths(-1).Year.ToString & Now.AddMonths(-1).Month.ToString.PadLeft(2, "0")
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub

    Private Sub Generar_Informacion()
        Dim i As Integer
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ls_sql As String
        Dim lerror As Boolean = False

        Try
            For i = 1 To 7
                Me.ProgressBar1.Value = i * 5
            Next

            ls_sql = "sp_datos '" & gs_empresa & "','" & Me.cmb_periodo.SelectedValue.ToString & "'"

            otrans.open()
            otrans.Actualiza(ls_sql)
            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error)
                lerror = True
            End If

            If gs_empresa = "CODICASA" Then
                ls_sql = "sp_datos_codicasa '" & Me.cmb_periodo.SelectedValue.ToString & "'"

                otrans.Actualiza(ls_sql)
                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                    lerror = True
                End If
            End If

            For i = 8 To 13
                Me.ProgressBar1.Value = i * 5
            Next

            ls_sql = "sp_con_datos_resultado '" & gs_empresa & "','" & Me.cmb_periodo.SelectedValue.ToString & "'"
            otrans.Actualiza(ls_sql)
            If otrans.Codigo_error > 0 Then
                MessageBox.Show(otrans.descripcion_error)
                lerror = True
            End If

            For i = 14 To 20
                Me.ProgressBar1.Value = i * 5
            Next

            If gs_empresa = "ALAMSA" Then
                ls_sql = "SP_CON_DATOS_ERCONSOL_ALA '" & Me.cmb_periodo.SelectedValue.ToString & "'"
                otrans.Actualiza(ls_sql)

                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                    lerror = True
                End If

                ls_sql = "SP_CON_DATOS_MANUFACT '" & Me.cmb_periodo.SelectedValue.ToString & "'"
                otrans.Actualiza(ls_sql)

                If otrans.Codigo_error > 0 Then
                    MessageBox.Show(otrans.descripcion_error)
                    lerror = True
                End If

            End If

            'ls_sql = "sp_con_datos '" & gs_empresa & "','" & Me.cmb_periodo.SelectedValue.ToString & "'"


            'otrans.open()
            'otrans.Actualiza(ls_sql)
            'If otrans.Codigo_error > 0 Then
            '    MessageBox.Show(otrans.descripcion_error)
            'End If



            'ls_sql = "SP_CON_DATOS_BALANCE '" & gs_empresa & "','" & Me.cmb_periodo.SelectedValue.ToString & "'"
            'otrans.Actualiza(ls_sql)
            'If otrans.Codigo_error > 0 Then
            '    MessageBox.Show(otrans.descripcion_error)
            'End If

            'ls_sql = "SP_CON_DATOS_Gastos '" & gs_empresa & "','" & Me.cmb_periodo.SelectedValue.ToString & "'"
            'otrans.Actualiza(ls_sql)
            'If otrans.Codigo_error > 0 Then
            '    MessageBox.Show(otrans.descripcion_error)
            'End If


            'ls_sql = "SP_CON_DATOS_Margen '" & gs_empresa & "','" & Me.cmb_periodo.SelectedValue.ToString & "'"
            'otrans.Actualiza(ls_sql)
            'If otrans.Codigo_error > 0 Then
            '    MessageBox.Show(otrans.descripcion_error)
            'End If

            'ls_sql = "SP_CON_DATOS_Resultado '" & gs_empresa & "','" & Me.cmb_periodo.SelectedValue.ToString & "'"
            'otrans.Actualiza(ls_sql)


            'For i = 16 To 20
            '    Me.ProgressBar1.Value = i * 5
            'Next

            If lerror = True Then
                MessageBox.Show("Proceso Finalizado con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Actualizacion Realizada con Exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try


    End Sub

    Private Sub frm_inicializar_periodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl_empresa.Text = gs_empresa
        Llenar_Combos()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click

        If MessageBox.Show("Este Proceso Inicializara los Datos para" & Chr(13) & _
                           "       " & gs_empresa & "    Periodo " & Me.cmb_periodo.SelectedValue & Chr(13) & _
                           "        Esta Seguro de Continuar", "Confirmacion", _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Generar_Informacion()
        End If



    End Sub
End Class
