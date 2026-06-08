Imports System.Text

Public Class frm_convierte_ordencompra
    Inherits System.Windows.Forms.Form
    Dim ods As New DataSet
    Dim sql_st As String = String.Empty
    Dim dr_aux As DataRow
    Dim dt As DataTable



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
    'Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    'Friend WithEvents btn_ejecutar As System.Windows.Forms.Button
    'Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents cmb_proceso As System.Windows.Forms.ComboBox
    'Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    'Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_convierte_ordencompra))
        Me.btn_ejecutar = New System.Windows.Forms.Button
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.cmb_tipodocto = New System.Windows.Forms.ComboBox
        Me.lbl_tipodocto = New System.Windows.Forms.Label
        Me.lbl_numero = New System.Windows.Forms.Label
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_ejecutar
        '
        Me.btn_ejecutar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ejecutar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ejecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ejecutar.ForeColor = System.Drawing.Color.White
        Me.btn_ejecutar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ejecutar.ImageIndex = 1
        Me.btn_ejecutar.ImageList = Me.ImageList2
        Me.btn_ejecutar.Location = New System.Drawing.Point(364, 6)
        Me.btn_ejecutar.Name = "btn_ejecutar"
        Me.btn_ejecutar.Size = New System.Drawing.Size(80, 64)
        Me.btn_ejecutar.TabIndex = 0
        Me.btn_ejecutar.Text = "&Guardar"
        Me.btn_ejecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ejecutar.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "3.png")
        Me.ImageList2.Images.SetKeyName(1, "Floppy-64.png")
        Me.ImageList2.Images.SetKeyName(2, "DeleteRed.png")
        Me.ImageList2.Images.SetKeyName(3, "print_48.png")
        Me.ImageList2.Images.SetKeyName(4, "127.png")
        Me.ImageList2.Images.SetKeyName(5, "Refresh48.png")
        Me.ImageList2.Images.SetKeyName(6, "2.png")
        Me.ImageList2.Images.SetKeyName(7, "clear.png")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "running_process.png")
        Me.ImageList1.Images.SetKeyName(1, "clear.png")
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.ImageIndex = 1
        Me.btn_limpiar.ImageList = Me.ImageList1
        Me.btn_limpiar.Location = New System.Drawing.Point(451, 6)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(80, 64)
        Me.btn_limpiar.TabIndex = 1
        Me.btn_limpiar.Text = "&Limpiar"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'cmb_tipodocto
        '
        Me.cmb_tipodocto.FormattingEnabled = True
        Me.cmb_tipodocto.Location = New System.Drawing.Point(132, 16)
        Me.cmb_tipodocto.Name = "cmb_tipodocto"
        Me.cmb_tipodocto.Size = New System.Drawing.Size(198, 21)
        Me.cmb_tipodocto.TabIndex = 2
        '
        'lbl_tipodocto
        '
        Me.lbl_tipodocto.AutoSize = True
        Me.lbl_tipodocto.Location = New System.Drawing.Point(40, 16)
        Me.lbl_tipodocto.Name = "lbl_tipodocto"
        Me.lbl_tipodocto.Size = New System.Drawing.Size(86, 13)
        Me.lbl_tipodocto.TabIndex = 3
        Me.lbl_tipodocto.Text = "Tipo Documento"
        '
        'lbl_numero
        '
        Me.lbl_numero.AutoSize = True
        Me.lbl_numero.Location = New System.Drawing.Point(44, 40)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(44, 13)
        Me.lbl_numero.TabIndex = 4
        Me.lbl_numero.Text = "Numero"
        '
        'txt_numero
        '
        Me.txt_numero.Location = New System.Drawing.Point(133, 38)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(197, 20)
        Me.txt_numero.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 86)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(520, 324)
        Me.DataGridView1.TabIndex = 6
        '
        'frm_convierte_ordencompra
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(544, 430)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txt_numero)
        Me.Controls.Add(Me.lbl_numero)
        Me.Controls.Add(Me.lbl_tipodocto)
        Me.Controls.Add(Me.cmb_tipodocto)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.btn_ejecutar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_convierte_ordencompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Convierte Orden / Compra .::"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim oPanel As New Panel
    Dim ds_parametros As New DataSet
    Dim nombre_sp As String
    Public administrador As Boolean = False

    Private Sub frm_ejecuta_sp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mostrar_informacion()
        generar_parametros()
        generar_datos()
    End Sub
    Private Sub mostrar_informacion()
        Dim mRow() As DataRow
        oPanel.Controls.Clear()

        nombre_sp = "spa_Convierte_FO_factura_face"
        obtener_datos()


    End Sub

    Private Sub generar_datos()
        Dim ldt_table As New DataTable
        Dim ls_SqlScript As String
        Dim otransaccion As Transaccional.Conexion

        otransaccion = New Transaccional.Conexion("flexline")
        otransaccion.open()

        If administrador Then
            ls_SqlScript = "pa_sel_um_sg_usuario_sp NULL,'" & gs_empresa & "'"
        Else
            ls_SqlScript = "pa_sel_um_sg_usuario_sp '" & gs_usuario & "','" & gs_empresa & "'"
        End If

        ldt_table = otransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "parametros"
        ds_parametros.Tables.Add(ldt_table.Copy)

  

        otransaccion.close()
        otransaccion = Nothing
    End Sub
    Private Sub obtener_datos()
        Try
            Dim ldt_table As New DataTable
            Dim ls_SqlScript As String
            Dim otransaccion As Transaccional.Conexion

            If ds_parametros.Tables.Contains("datos") Then ds_parametros.Tables.Remove("datos")

            otransaccion = New Transaccional.Conexion("flexline")
            otransaccion.open()

            ls_SqlScript = "sp_sproc_columns " & nombre_sp
            ldt_table = otransaccion.Obtiene(ls_SqlScript)
            ldt_table.TableName = "datos"
            ds_parametros.Tables.Add(ldt_table.Copy)

            otransaccion.close()
            otransaccion = Nothing
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Me.txt_numero.Text = ""
        Me.DataGridView1.DataSource = ""
        Me.cmb_tipodocto.Controls.Clear()
    End Sub


    Private Sub btn_ejecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ejecutar.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            If MessageBox.Show("¿Está seguro de ejecutar el proceso?", "Ejecución de Proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Try
                Dim ls_SqlScript As String
                Dim ldt_table As New DataTable
                Dim otransaccion As Transaccional.Conexion

                otransaccion = New Transaccional.Conexion("flexline")
                otransaccion.open()

                ls_SqlScript = nombre_sp & " '" & gs_empresa & "' , '" & Me.cmb_tipodocto.Text.Trim & "', '" & Me.txt_numero.Text.Trim & "'"
                otransaccion.Actualiza(ls_SqlScript)

                otransaccion.close()
                otransaccion = Nothing

                Limpiar()

                MessageBox.Show("Se ejecuto el proceso correctamente.", "Ejecución Completa", MessageBoxButtons.OK)

            Catch ex As Exception
                MessageBox.Show("Se produjo el siguiente error al ejecutar el proceso: " & ex.Message, "Error!!!", MessageBoxButtons.OK)


            End Try
        End If

    End Sub
    Private Sub Limpiar()
        Me.txt_numero.Text = ""
        Me.DataGridView1.DataSource = ""
        Me.cmb_tipodocto.Controls.Clear()
    End Sub
    Private Sub generar_parametros()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try
            otrans.open()
            dt = otrans.Obtiene("select * from flexline.gen_tabcod where tipo='CON_TIPDOC' and descripcion like '%Factura serie%'  OR DESCRIPCION ='FACE-63-FEA-001'and empresa = '" & gs_empresa & "'")
            dt = clsGen.ValoresDistinto(dt, "descripcion".Split(","))

            Me.cmb_tipodocto.DataSource = dt
            Me.cmb_tipodocto.ValueMember = "descripcion"
            Me.cmb_tipodocto.DisplayMember = "descripcion"


        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
    End Sub


    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
        If e.KeyChar = Chr(13) Then
            If txt_numero.Text.Trim.Length > 0 Then mostrar_detalle(txt_numero.Text) '(txt_numero.Text)
        End If
    End Sub
    Private Sub mostrar_detalle(ByVal Numero As String)
        Dim clGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt2 As DataTable
      

        Try
            Otrans.open()

            If ods.Tables.Contains("detalle") Then ods.Tables("detalle").Rows.Clear()
            Me.Crear_estructura()

            Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")
            sql_st = "pa_sel_um_documento_detalle '" & Me.cmb_tipodocto.Text.Trim & "' , '" & gs_empresa & "', '" & Me.txt_numero.Text.Trim & "'"
            dt = Otrans.Obtiene(sql_st)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No exise este Numero de Factura Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                Dim dr_aux As DataRow

                For Each dr As DataRow In dt.Rows


                    dr_aux = ods.Tables("detalle").NewRow
                    dr_aux.Item("fecha") = dr.Item("fecha")
                    dr_aux.Item("razonSocial") = dr.Item("razonSocial")
                    dr_aux.Item("cantidadasignada") = dr.Item("cantidadasignada")
                    dr_aux.Item("cantidad") = dr.Item("cantidad")
                    dr_aux.Item("producto") = dr.Item("producto")
                    dr_aux.Item("glosa") = dr.Item("glosa")
                    dr_aux.Item("vigencia") = dr.Item("vigencia")
                    dr_aux.Item("lote") = dr.Item("lote")
                    dr_aux.Item("fechavcto") = dr.Item("fechavcto")

                    ods.Tables("detalle").Rows.Add(dr_aux)

                Next


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing


        End Try

        clGen.Alinear_GridView(dt, Me.DataGridView1, ",producto,glosa,cantidad,lote,fechavcto,vigencia,", ",fecha,razonsocial,cantidadasignada,", "", "", "", "", "", True, True, 250, 0)

        clGen = Nothing

    End Sub
    Private Sub Crear_estructura()
        Dim dt As DataTable
        ods = New DataSet
        dt = New DataTable("detalle")


        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidadasignada", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        dt.Columns.Add(New DataColumn("lote", GetType(String)))
        dt.Columns.Add(New DataColumn("fechavcto", GetType(String)))
        dt.Columns.Add(New DataColumn("vigencia", GetType(String)))

        ods.Tables.Add(dt)
        Me.DataGridView1.DataSource = ods.Tables("Detalle")
    End Sub


    

    Private Sub txt_numero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub cmb_tipodocto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipodocto.SelectedIndexChanged

    End Sub
End Class