Public Class frm_mensajeria_mr
    Inherits System.Windows.Forms.Form
    Dim ods As DataSet
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dg_entrada As System.Windows.Forms.DataGrid
    Friend WithEvents dg_salida As System.Windows.Forms.DataGrid
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_asunto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_mayorista As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_leido As System.Windows.Forms.Button
    Friend WithEvents btn_enviar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents rtxt_mensaje As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_mensajeria_mr))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.rtxt_mensaje = New System.Windows.Forms.RichTextBox
        Me.lbl_numero = New System.Windows.Forms.Label
        Me.btn_leido = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_enviar = New System.Windows.Forms.Button
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker
        Me.txt_asunto = New System.Windows.Forms.TextBox
        Me.cmb_mayorista = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dg_entrada = New System.Windows.Forms.DataGrid
        Me.dg_salida = New System.Windows.Forms.DataGrid
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_entrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_salida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(856, 480)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage1.Controls.Add(Me.rtxt_mensaje)
        Me.TabPage1.Controls.Add(Me.lbl_numero)
        Me.TabPage1.Controls.Add(Me.btn_leido)
        Me.TabPage1.Controls.Add(Me.btn_enviar)
        Me.TabPage1.Controls.Add(Me.dtp_fecha)
        Me.TabPage1.Controls.Add(Me.txt_asunto)
        Me.TabPage1.Controls.Add(Me.cmb_mayorista)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(848, 454)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle Mensaje"
        '
        'rtxt_mensaje
        '
        Me.rtxt_mensaje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtxt_mensaje.BackColor = System.Drawing.Color.Linen
        Me.rtxt_mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtxt_mensaje.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxt_mensaje.Location = New System.Drawing.Point(64, 104)
        Me.rtxt_mensaje.Name = "rtxt_mensaje"
        Me.rtxt_mensaje.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtxt_mensaje.Size = New System.Drawing.Size(680, 344)
        Me.rtxt_mensaje.TabIndex = 4
        Me.rtxt_mensaje.Text = ""
        '
        'lbl_numero
        '
        Me.lbl_numero.Location = New System.Drawing.Point(472, 24)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.TabIndex = 7
        Me.lbl_numero.Visible = False
        '
        'btn_leido
        '
        Me.btn_leido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_leido.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_leido.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_leido.ImageIndex = 0
        Me.btn_leido.ImageList = Me.ImageList1
        Me.btn_leido.Location = New System.Drawing.Point(752, 8)
        Me.btn_leido.Name = "btn_leido"
        Me.btn_leido.Size = New System.Drawing.Size(75, 56)
        Me.btn_leido.TabIndex = 5
        Me.btn_leido.Text = "Leido"
        Me.btn_leido.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_leido.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btn_enviar
        '
        Me.btn_enviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_enviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_enviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_enviar.ImageIndex = 1
        Me.btn_enviar.ImageList = Me.ImageList1
        Me.btn_enviar.Location = New System.Drawing.Point(752, 120)
        Me.btn_enviar.Name = "btn_enviar"
        Me.btn_enviar.Size = New System.Drawing.Size(75, 56)
        Me.btn_enviar.TabIndex = 7
        Me.btn_enviar.Text = "Enviar"
        Me.btn_enviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtp_fecha.Location = New System.Drawing.Point(64, 48)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(96, 20)
        Me.dtp_fecha.TabIndex = 2
        '
        'txt_asunto
        '
        Me.txt_asunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_asunto.Location = New System.Drawing.Point(64, 72)
        Me.txt_asunto.Name = "txt_asunto"
        Me.txt_asunto.Size = New System.Drawing.Size(680, 20)
        Me.txt_asunto.TabIndex = 3
        Me.txt_asunto.Text = ""
        '
        'cmb_mayorista
        '
        Me.cmb_mayorista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_mayorista.Location = New System.Drawing.Point(64, 24)
        Me.cmb_mayorista.Name = "cmb_mayorista"
        Me.cmb_mayorista.Size = New System.Drawing.Size(320, 21)
        Me.cmb_mayorista.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mayorista"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Asunto"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Mensaje"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 2
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(752, 64)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 56)
        Me.btn_nuevo.TabIndex = 6
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dg_entrada)
        Me.TabPage2.Controls.Add(Me.dg_salida)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(848, 454)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bandeja Entrada-Salida"
        '
        'dg_entrada
        '
        Me.dg_entrada.CaptionText = "Mensajes Recibidos"
        Me.dg_entrada.DataMember = ""
        Me.dg_entrada.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_entrada.Location = New System.Drawing.Point(8, 16)
        Me.dg_entrada.Name = "dg_entrada"
        Me.dg_entrada.Size = New System.Drawing.Size(832, 216)
        Me.dg_entrada.TabIndex = 0
        '
        'dg_salida
        '
        Me.dg_salida.CaptionText = "Mensajes Enviados"
        Me.dg_salida.DataMember = ""
        Me.dg_salida.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_salida.Location = New System.Drawing.Point(16, 248)
        Me.dg_salida.Name = "dg_salida"
        Me.dg_salida.Size = New System.Drawing.Size(824, 200)
        Me.dg_salida.TabIndex = 0
        '
        'frm_mensajeria_mr
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(864, 494)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_mensajeria_mr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Mensajeria MR ::"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_entrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_salida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Crear_Estructura()
        Dim dt As DataTable

        Ods = New DataSet

        dt = New DataTable("entrada")
        dt.Columns.Add(New DataColumn("nombre_mr", GetType(String)))
        dt.Columns.Add(New DataColumn("cod_mensaje", GetType(String)))
        dt.Columns.Add(New DataColumn("importancia", GetType(String)))
        dt.Columns.Add(New DataColumn("asunto", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_envio", GetType(String)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_grabo", GetType(String)))
        dt.Columns.Add(New DataColumn("operado", GetType(String)))
        dt.Columns.Add(New DataColumn("cod_cliente", GetType(Integer)))

        Ods.Tables.Add(dt.Copy)
        dt.TableName = "salida"
        Ods.Tables.Add(dt.Copy)


    End Sub

    Private Sub Llenar_Informacion()
        Dim myoTrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr, draux As DataRow
        Dim ls_sql As String

        Try
            myoTrans.open()

            ls_sql = "call pa_sel_um_bbj_mayorista_mensajeria (NULL)"
            dt = myoTrans.Obtiene(ls_sql)

            ods.Tables("salida").Rows.Clear()
            ods.Tables("entrada").Rows.Clear()


            For Each dr In dt.Rows

                If dr.Item("operado").ToString = 0 Or dr.Item("operado").ToString = 1 Then
                    If dr.Item("envio_recepcion").ToString = 1 Then
                        draux = ods.Tables("salida").NewRow
                    Else
                        draux = ods.Tables("entrada").NewRow
                    End If

                    draux.Item("cod_mensaje") = dr.Item("cod_mensaje").ToString
                    draux.Item("importancia") = dr.Item("importancia").ToString
                    draux.Item("asunto") = dr.Item("asunto").ToString
                    draux.Item("fecha_envio") = dr.Item("fecha_envio").ToString
                    draux.Item("observaciones") = dr.Item("observaciones").ToString
                    draux.Item("fecha_grabo") = dr.Item("fecha_grabo").ToString
                    draux.Item("usuario_grabo") = dr.Item("usuario_grabo").ToString
                    draux.Item("operado") = dr.Item("operado").ToString
                    draux.Item("nombre_mr") = dr.Item("nombre").ToString
                    draux.Item("cod_cliente") = dr.Item("cod_cliente").ToString

                    If dr.Item("envio_recepcion").ToString = 1 Then
                        ods.Tables("salida").Rows.Add(draux)
                    Else
                        ods.Tables("entrada").Rows.Add(draux)

                    End If


                End If
            Next

            Me.dg_entrada.DataSource = ods.Tables("entrada")
            Me.dg_salida.DataSource = ods.Tables("salida")
            Colorear_Grid(ods.Tables("entrada"))
            Colorear_Grid(ods.Tables("salida"))

        Catch ex As Exception
        Finally
            myoTrans.close()
            myoTrans = Nothing
            clsgen = Nothing
        End Try

    End Sub

    Private Sub Colorear_Grid(ByVal pdt As DataTable)
        Dim clsGen As New ClasesGenerales.General
        Dim tableStyle As New DataGridTableStyle
        tableStyle.MappingName = pdt.TableName
        Dim nombre_tipo As String

        For Each col As DataColumn In pdt.Columns

            Dim gridCol As ClasesGenerales.DataGridColoredTextBoxColumn = New ClasesGenerales.DataGridColoredTextBoxColumn
            gridCol.MappingName = col.ColumnName

            Try
                nombre_tipo = col.DataType.ToString
            Catch ex As Exception
                nombre_tipo = ""
            End Try

            gridCol.Width = clsGen.tamaño_maximo_campo(pdt, " ", col.ColumnName, Me.dg_entrada, 255, 0)

            If nombre_tipo = "System.Decimal" Then
                gridCol.Format = "n"
                gridCol.Alignment = HorizontalAlignment.Right
            End If
            If nombre_tipo = "System.DateTime" Then
                gridCol.Width = 95
            End If
            If col.ColumnName <> "operado" Then
                gridCol.ReadOnly = True
            End If
            If col.ColumnName.ToString.ToLower = "cod_mensaje" Then
                gridCol.Width = 0
            ElseIf col.ColumnName.ToString.ToLower = "operado" Then
                gridCol.Width = 0
            ElseIf col.ColumnName.ToString.ToLower = "importancia" Then
                gridCol.Width = 0
            ElseIf col.ColumnName.ToString.ToLower = "cod_cliente" Then
                gridCol.Width = 0
            End If


            gridCol.HeaderText = col.ColumnName.Trim.Replace("_", " ")
            gridCol.NullText = ""
            AddHandler gridCol.GetForeColor, AddressOf Me.GetForeColor
            tableStyle.GridColumnStyles.Add(gridCol)
        Next

        ' clsGen.Alinea_Grid(Ods.Tables("mensajes"), Me.dg_mensajes, Ods.Tables("mensajes").TableName, -1, 225, 60, False, False, "", False, "cod_producto,producto,existencia,precio,total,minimo")
        tableStyle.RowHeaderWidth = 5
        tableStyle.HeaderForeColor = Color.Black
        tableStyle.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        tableStyle.GridLineColor = Color.LightGray

        If pdt.TableName.ToString.ToLower = "entrada" Then
            Me.dg_entrada.TableStyles.Clear()
            Me.dg_entrada.TableStyles.Add(tableStyle)
        Else
            Me.dg_salida.TableStyles.Clear()
            Me.dg_salida.TableStyles.Add(tableStyle)

        End If


    End Sub

    Private Sub GetForeColor(ByVal sender As Object, ByVal e As ClasesGenerales.RowColorEventArgs)

        Try
            Dim data As DataRowView
            Dim value As String

            data = CType(e.Source.List.Item(e.RowIndex), DataRowView)
            value = data("operado")

            If value = 1 Then
                e.RowColor = Color.Blue
            Else
                e.RowColor = Color.Red
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Llenar_Combos()
        Dim myoTrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable
        Dim ls_sql As String

        Try

            myoTrans.open()
            ls_sql = "call pa_sel_um_bbj_mayorista (null)"
            dt = myoTrans.Obtiene(ls_sql)

            Me.cmb_mayorista.DataSource = dt
            Me.cmb_mayorista.ValueMember = "cod_cliente"
            Me.cmb_mayorista.DisplayMember = "nombre"

        Catch ex As Exception
        Finally
            myoTrans.close()
            myoTrans = Nothing

        End Try


    End Sub
    Private Sub Mostrar_Mensaje_Recibido()
        '        Me.btn_guardar.Enabled = False

        Dim nRow As Integer

        Try

            nRow = Me.dg_entrada.CurrentCell.RowNumber
            Me.lbl_numero.Text = Me.dg_entrada.Item(nRow, 1)
            Me.txt_asunto.Text = Me.dg_entrada.Item(nRow, 3)
            Me.dtp_fecha.Text = Me.dg_entrada.Item(nRow, 4)
            Me.rtxt_mensaje.Text = Me.dg_entrada.Item(nRow, 5)
            Me.cmb_mayorista.SelectedValue = Me.dg_entrada.Item(nRow, 9)

            Me.btn_leido.Visible = True
            Me.btn_enviar.Visible = False
            Me.TabControl1.SelectedTab = Me.TabPage1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mostrar_Mensaje_Enviado()
        Dim nRow As Integer

        Try

            nRow = Me.dg_salida.CurrentCell.RowNumber
            Me.lbl_numero.Text = Me.dg_salida.Item(nRow, 1)
            Me.txt_asunto.Text = Me.dg_salida.Item(nRow, 3)
            Me.dtp_fecha.Text = Me.dg_salida.Item(nRow, 4)
            Me.rtxt_mensaje.Text = Me.dg_salida.Item(nRow, 5)
            Me.cmb_mayorista.SelectedValue = Me.dg_salida.Item(nRow, 9)

            Me.btn_leido.Visible = False
            Me.btn_enviar.Visible = False
            Me.TabControl1.SelectedTab = Me.TabPage1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Marcar_Mensaje_Leido()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String

        Try
            myOtrans.open()
            ls_sql = "call pa_upd_um_bbj_mayorista_mensajeria (" & Me.cmb_mayorista.SelectedValue.ToString & "," & Me.lbl_numero.Text & ")"
            myOtrans.Actualiza(ls_sql)
            If myOtrans.Codigo_error = 0 Then
                MessageBox.Show("Mensaje Leido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("La Actualizacion Genero Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Sub

    Private Sub Enviar_Mensaje()
        Dim ClsGen As ClasesGenerales.MR

        Try


            ClsGen = New ClasesGenerales.MR(Me.cmb_mayorista.SelectedValue.ToString, 1)
            If ClsGen.Enviar_Mensaje_CDC_MR(Me.txt_asunto.Text, Me.dtp_fecha.Text, Me.rtxt_mensaje.Text, "", "", gs_usuario, 1) Then



                MessageBox.Show("Mensaje Generado Con Exito ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btn_enviar.Enabled = False
            Else
                MessageBox.Show("Se Generaron Errores ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)


            End If


        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub
    Private Sub frm_mensajeria_mr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructura()
        Llenar_Combos()
        Llenar_Informacion()
    End Sub

    Private Sub dg_entrada_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_entrada.Navigate

    End Sub

    Private Sub dg_entrada_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_entrada.DoubleClick
        Mostrar_Mensaje_Recibido()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.btn_leido.Visible = False
        Me.btn_enviar.Visible = True
        Me.btn_enviar.Enabled = True
        Me.txt_asunto.Text = ""
        Me.rtxt_mensaje.Text = ""
        Me.dtp_fecha.Enabled = True
        Me.cmb_mayorista.Enabled = True

    End Sub

    Private Sub btn_leido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_leido.Click
        Marcar_Mensaje_Leido()
        Llenar_Informacion()
    End Sub

    Private Sub btn_enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click
        Enviar_Mensaje()
        Llenar_Informacion()
    End Sub


    Private Sub dg_salida_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_salida.DoubleClick
        Mostrar_Mensaje_Enviado()
    End Sub
End Class
