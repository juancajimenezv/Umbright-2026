Public Class frm_int_parametros
    Inherits System.Windows.Forms.Form
    Dim ds_parametros As New DataSet

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_min_cajas As System.Windows.Forms.TextBox
    Friend WithEvents txt_max_cajas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txt_empresa As System.Windows.Forms.TextBox
    Friend WithEvents dg_pareto As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDiasProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtDiasDUA As System.Windows.Forms.TextBox
    Friend WithEvents txt_lead_time As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_int_parametros))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_lead_time = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_min_cajas = New System.Windows.Forms.TextBox
        Me.txt_max_cajas = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txt_empresa = New System.Windows.Forms.TextBox
        Me.dg_pareto = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtDiasDUA = New System.Windows.Forms.TextBox
        Me.txtDiasProducto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.dg_pareto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lead Time"
        '
        'txt_lead_time
        '
        Me.txt_lead_time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lead_time.Location = New System.Drawing.Point(103, 44)
        Me.txt_lead_time.Name = "txt_lead_time"
        Me.txt_lead_time.Size = New System.Drawing.Size(105, 22)
        Me.txt_lead_time.TabIndex = 1
        Me.txt_lead_time.Text = "0"
        Me.txt_lead_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Dias Inventario CD"
        '
        'txt_min_cajas
        '
        Me.txt_min_cajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_min_cajas.Location = New System.Drawing.Point(103, 71)
        Me.txt_min_cajas.Name = "txt_min_cajas"
        Me.txt_min_cajas.Size = New System.Drawing.Size(105, 22)
        Me.txt_min_cajas.TabIndex = 5
        Me.txt_min_cajas.Text = "0"
        Me.txt_min_cajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_max_cajas
        '
        Me.txt_max_cajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_max_cajas.Location = New System.Drawing.Point(331, 71)
        Me.txt_max_cajas.Name = "txt_max_cajas"
        Me.txt_max_cajas.Size = New System.Drawing.Size(90, 22)
        Me.txt_max_cajas.TabIndex = 4
        Me.txt_max_cajas.Text = "0"
        Me.txt_max_cajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "% Min Cajas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(220, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Porc. Max Cajas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Empresa"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageIndex = 0
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(11, 26)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(74, 64)
        Me.btn_guardar.TabIndex = 10
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        '
        'txt_empresa
        '
        Me.txt_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_empresa.Location = New System.Drawing.Point(103, 18)
        Me.txt_empresa.Name = "txt_empresa"
        Me.txt_empresa.ReadOnly = True
        Me.txt_empresa.Size = New System.Drawing.Size(105, 22)
        Me.txt_empresa.TabIndex = 11
        '
        'dg_pareto
        '
        Me.dg_pareto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_pareto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_pareto.Location = New System.Drawing.Point(3, 18)
        Me.dg_pareto.Name = "dg_pareto"
        Me.dg_pareto.Size = New System.Drawing.Size(538, 185)
        Me.dg_pareto.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_empresa)
        Me.GroupBox1.Controls.Add(Me.txt_lead_time)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDiasProducto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDiasDUA)
        Me.GroupBox1.Controls.Add(Me.txt_min_cajas)
        Me.GroupBox1.Controls.Add(Me.txt_max_cajas)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 161)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dg_pareto)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 171)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(544, 206)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_guardar)
        Me.GroupBox3.Location = New System.Drawing.Point(460, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(96, 113)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        '
        'txtDiasDUA
        '
        Me.txtDiasDUA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiasDUA.Location = New System.Drawing.Point(331, 125)
        Me.txtDiasDUA.Name = "txtDiasDUA"
        Me.txtDiasDUA.Size = New System.Drawing.Size(90, 22)
        Me.txtDiasDUA.TabIndex = 4
        Me.txtDiasDUA.Text = "0"
        Me.txtDiasDUA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiasProducto
        '
        Me.txtDiasProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiasProducto.Location = New System.Drawing.Point(331, 100)
        Me.txtDiasProducto.Name = "txtDiasProducto"
        Me.txtDiasProducto.Size = New System.Drawing.Size(90, 22)
        Me.txtDiasProducto.TabIndex = 5
        Me.txtDiasProducto.Text = "0"
        Me.txtDiasProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(221, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Dias Alerta Vencimiento Producto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(191, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Dias Alerta Vencimiento DUA"
        '
        'frm_int_parametros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(570, 385)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_int_parametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Parametros Internaciones .::"
        CType(Me.dg_pareto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Crear_Estructura()
        Dim dt As New DataTable("pareto")

        dt.Columns.Add(New DataColumn("pareto", GetType(String)))
        dt.Columns.Add(New DataColumn("dias_minimos", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("dias_maximos", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("%_Maximo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("%_Minimo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("is", GetType(Short)))
        dt.Columns.Add(New DataColumn("fc", GetType(Short)))
        dt.Columns.Add(New DataColumn("%_Var_LT", GetType(Short)))
        ds_parametros.Tables.Add(dt.Copy)
        Me.dg_pareto.DataSource = ds_parametros.Tables("pareto")

    End Sub

    Private Sub Llenar_Informacion()
        Dim ls_sql As String
        Dim clsgen As New ClasesGenerales.General
        Dim dr, dr_aux As DataRow
        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("scm")

        Try
            oTrans.open()


            ls_sql = "pa_sel_um_int_pareto '" & gs_empresa & "'"
            dt = oTrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                dr_aux = ds_parametros.Tables("pareto").NewRow
                dr_aux.Item("pareto") = dr.Item("pareto")
                dr_aux.Item("dias_minimos") = dr.Item("dias_minimo_cd")
                dr_aux.Item("dias_maximos") = dr.Item("dias_maximo_cd")
                dr_aux.Item("%_maximo") = dr.Item("porcentaje_maximo")
                dr_aux.Item("%_minimo") = dr.Item("porcentaje_minimo")
                dr_aux.Item("is") = dr.Item("inventario_seguridad")
                dr_aux.Item("fc") = dr.Item("frecuencia_compra")
                dr_aux.Item("%_Var_LT") = dr.Item("porcentaje_variable_lead_time")

                ds_parametros.Tables("pareto").Rows.Add(dr_aux)
            Next

            ls_sql = "pa_sel_um_int_parametros_generales '" & gs_empresa & "'"
            dt = oTrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                Me.txt_lead_time.Text = dt.Rows(0).Item("lead_time")
                Me.txt_max_cajas.Text = dt.Rows(0).Item("porcentaje_maximo")
                Me.txt_min_cajas.Text = dt.Rows(0).Item("porcentaje_minimo")
            End If

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try



        Me.txt_empresa.Text = gs_empresa


        'Alineo Grid de Pareto
        'clsgen.Alinea_Grid(ds_parametros.Tables("pareto"), Me.dg_pareto, ds_parametros.Tables("pareto").TableName, -1, 250, 50, False, True, "", False, "")
        clsgen.Alinear_GridView(ds_parametros.Tables("pareto"), dg_pareto, "", "", "", "", "", "", "", True, True, 250, 0)
        clsgen = Nothing
    End Sub

    Private Sub Guardar_Parametros()
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("scm")

        Try
            otrans.open()
            ls_sql = "pa_del_um_int_parametros_generales '" & gs_empresa & "'"
            otrans.Elimina(ls_sql)

            ls_sql = "pa_ins_um_int_parametros_generales '" & gs_empresa & "'," & _
                    Me.txt_lead_time.Text & "," & _
                    Me.txt_min_cajas.Text & "," & Me.txt_max_cajas.Text & "," & _
                    Me.txtDiasProducto.Text & "," & Me.txtDiasDUA.Text


            otrans.Ingresa(ls_sql)

            MessageBox.Show("Parametros Actualizados Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_Paretos()
        Dim dr As DataRow
        Dim otrans As New Transaccional.Conexion("scm")
        Dim ls_sql As String

        Try
            otrans.open()
            If ds_parametros.Tables("pareto").Rows.Count > -1 Then
                'borro los paretos uno a uno
                ls_sql = "pa_del_um_int_pareto '" & gs_empresa & "'"
                otrans.Elimina(ls_sql)

                For Each dr In ds_parametros.Tables("pareto").Rows

                    ls_sql = "pa_ins_um_int_pareto '" & gs_empresa & "','" & _
                                dr.Item("pareto").ToString & "'," & _
                                dr.Item("dias_minimos") & "," & _
                                dr.Item("dias_maximos") & "," & _
                                dr.Item("%_maximo") & "," & _
                                dr.Item("%_minimo") & "," & _
                                dr.Item("is") & "," & _
                                dr.Item("fc") & "," & _
                                dr.Item("%_Var_LT")

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

    Private Sub frm_int_mantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Llenar_Informacion()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Guardar_Parametros()
        Guardar_Paretos()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiasDUA.TextChanged

    End Sub
End Class
