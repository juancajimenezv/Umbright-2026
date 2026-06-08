Public Class frm_gen_tabcod
    Inherits System.Windows.Forms.Form
    Public gen_tipo As String
    Friend WithEvents dgvlistado As System.Windows.Forms.DataGridView
    Public Codigo As String



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
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_placas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_placas As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_gen_tabcod))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_placas = New System.Windows.Forms.TextBox
        Me.lbl_placas = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgvlistado = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvlistado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(372, 277)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btn_guardar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.txt_tipo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_codigo)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txt_descripcion)
        Me.TabPage1.Controls.Add(Me.txt_placas)
        Me.TabPage1.Controls.Add(Me.lbl_placas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(364, 251)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Definicion"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 1
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(190, 27)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 64)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "3.png")
        Me.ImageList1.Images.SetKeyName(1, "Floppy-64.png")
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 0
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(101, 27)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 64)
        Me.btn_nuevo.TabIndex = 6
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'txt_tipo
        '
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.Enabled = False
        Me.txt_tipo.Location = New System.Drawing.Point(99, 132)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.Size = New System.Drawing.Size(246, 20)
        Me.txt_tipo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo"
        '
        'txt_codigo
        '
        Me.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo.Location = New System.Drawing.Point(99, 156)
        Me.txt_codigo.MaxLength = 20
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(64, 20)
        Me.txt_codigo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descripcion"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(99, 180)
        Me.txt_descripcion.MaxLength = 75
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(246, 20)
        Me.txt_descripcion.TabIndex = 5
        '
        'txt_placas
        '
        Me.txt_placas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_placas.Location = New System.Drawing.Point(99, 204)
        Me.txt_placas.MaxLength = 50
        Me.txt_placas.Name = "txt_placas"
        Me.txt_placas.Size = New System.Drawing.Size(246, 20)
        Me.txt_placas.TabIndex = 5
        '
        'lbl_placas
        '
        Me.lbl_placas.Location = New System.Drawing.Point(19, 204)
        Me.lbl_placas.Name = "lbl_placas"
        Me.lbl_placas.Size = New System.Drawing.Size(72, 16)
        Me.lbl_placas.TabIndex = 2
        Me.lbl_placas.Text = "Placas"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvlistado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(364, 251)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado"
        '
        'dgvlistado
        '
        Me.dgvlistado.AllowUserToAddRows = False
        Me.dgvlistado.AllowUserToDeleteRows = False
        Me.dgvlistado.AllowUserToResizeColumns = False
        Me.dgvlistado.AllowUserToResizeRows = False
        Me.dgvlistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlistado.Location = New System.Drawing.Point(3, 3)
        Me.dgvlistado.Name = "dgvlistado"
        Me.dgvlistado.ReadOnly = True
        Me.dgvlistado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvlistado.Size = New System.Drawing.Size(361, 245)
        Me.dgvlistado.TabIndex = 1
        '
        'frm_gen_tabcod
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(372, 277)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_gen_tabcod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Mantenimiento de Codigos .::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvlistado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Llenar_Grid()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_gen_tabcod NULL,'" & gen_tipo & "','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "piloto"
            dt.DefaultView.RowFilter = "vigencia <> 'N'"
            Me.dgvlistado.DataSource = dt.DefaultView
            'ClsGen.Alinea_Grid(dt, Me.DataGrid1, -1, 250, 0, False, True, ",codigo,descripcion,texto,", True, ",codigo,descripcion,texto,")
            ClsGen.Alinear_GridView(dt, Me.dgvlistado, ",codigo,descripcion,texto,", "", "", "", "", "", "", True, True, 250, 0)
            'Me.cmb_vehiculo.DisplayMember = "CODIGO"
            'Me.cmb_vehiculo.ValueMember = "CODIGO"
            'Me.cmb_vehiculo.DataSource = ldt_table.DefaultView

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing

        End Try


    End Sub

    Private Sub Proceso_Guardar()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")



        Try
            Otrans.open()
            ls_sql = "pa_sel_um_gen_tabcod '" & Me.txt_codigo.Text & "','" & gen_tipo & "','" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("Este Codigo Ya Esta Registrado en la BD", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ls_sql = "pa_ins_um_gen_tabcod '" & gs_empresa & "','" &
                                        gen_tipo & "','" &
                                        Me.txt_codigo.Text & "','" &
                                        Me.txt_codigo.Text & "','" &
                                        Me.txt_descripcion.Text & "','" &
                                        IIf(gen_tipo.ToLower.StartsWith("gen_vehi"), Me.txt_placas.Text,
                                         IIf(gen_tipo.ToLower.StartsWith("producto.tipo"), "ACTIVO", "")) &
                                        "','','','','','',0,0,0,0,0,'S','','','','',''"
                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error = 0 Then
                    MessageBox.Show("Informacion Ingresada Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If gen_tipo.ToLower.Equals("producto.tipo") Then
                        ls_sql = "pa_ins_um_gen_tabcod '" & gs_empresa & "','" &
                        "CON_MARCA" & "','" &
                        Me.txt_codigo.Text & "','" &
                        Me.txt_codigo.Text & "','" &
                        Me.txt_descripcion.Text & "','" &
                        IIf(gen_tipo.ToLower.StartsWith("gen_vehi"), Me.txt_placas.Text, "") &
                        "','','','','','',0,0,0,0,0,'S','','','','',''"
                        Otrans.Ingresa(ls_sql)
                    End If

                Else
                    MessageBox.Show("Problemas al Guardar " & Otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub frm_gen_tabcod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txt_tipo.Text = gen_tipo
        If gen_tipo.ToLower.StartsWith("gen_vehic") Then
            Me.lbl_placas.Visible = True
            Me.txt_placas.Visible = True
        Else
            Me.lbl_placas.Visible = False
            Me.txt_placas.Visible = False
        End If

        Llenar_Grid()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If MessageBox.Show("Esta Seguro de Guardar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Proceso_Guardar()
            Llenar_Grid()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.txt_codigo.Text = ""
        Me.txt_descripcion.Text = ""
    End Sub

 
    Private Sub dgvlistado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvlistado.CellContentClick

    End Sub
End Class
