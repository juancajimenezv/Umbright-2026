Public Class frm_recepcion_control_transporte
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_guia As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_piloto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_liberar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents panel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_observaciones As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_recepcion_control_transporte))
        Me.txt_guia = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.txt_piloto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_tipos = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_liberar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.panel2 = New System.Windows.Forms.StatusBarPanel
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_observaciones = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_guia
        '
        Me.txt_guia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_guia.Location = New System.Drawing.Point(112, 36)
        Me.txt_guia.Name = "txt_guia"
        Me.txt_guia.Size = New System.Drawing.Size(120, 20)
        Me.txt_guia.TabIndex = 2
        Me.txt_guia.Text = ""
        '
        'DataGrid1
        '
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGrid1.CaptionText = "Documentos En Guia"
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(2, 121)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(694, 384)
        Me.DataGrid1.TabIndex = 4
        Me.DataGrid1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero Guia"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(240, 36)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(104, 20)
        Me.txt_fecha.TabIndex = 4
        Me.txt_fecha.Text = ""
        '
        'txt_piloto
        '
        Me.txt_piloto.Location = New System.Drawing.Point(112, 58)
        Me.txt_piloto.Name = "txt_piloto"
        Me.txt_piloto.ReadOnly = True
        Me.txt_piloto.Size = New System.Drawing.Size(232, 20)
        Me.txt_piloto.TabIndex = 5
        Me.txt_piloto.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Piloto"
        '
        'cmb_tipos
        '
        Me.cmb_tipos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tipos.Location = New System.Drawing.Point(112, 11)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(232, 21)
        Me.cmb_tipos.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tipo Guia"
        '
        'cmb_liberar
        '
        Me.cmb_liberar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_liberar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmb_liberar.ImageIndex = 0
        Me.cmb_liberar.ImageList = Me.ImageList1
        Me.cmb_liberar.Location = New System.Drawing.Point(608, 16)
        Me.cmb_liberar.Name = "cmb_liberar"
        Me.cmb_liberar.Size = New System.Drawing.Size(80, 56)
        Me.cmb_liberar.TabIndex = 5
        Me.cmb_liberar.Text = "&Actualizar"
        Me.cmb_liberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageIndex = 1
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(528, 16)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(80, 56)
        Me.btn_nuevo.TabIndex = 10
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 511)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.panel2})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(696, 22)
        Me.StatusBar1.TabIndex = 11
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Width = 336
        '
        'panel2
        '
        Me.panel2.Width = 344
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Observaciones"
        '
        'txt_observaciones
        '
        Me.txt_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_observaciones.Location = New System.Drawing.Point(112, 80)
        Me.txt_observaciones.Multiline = True
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_observaciones.Size = New System.Drawing.Size(568, 40)
        Me.txt_observaciones.TabIndex = 3
        Me.txt_observaciones.Text = ""
        '
        'frm_recepcion_control_transporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(696, 533)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.cmb_liberar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_tipos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_piloto)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.txt_guia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_observaciones)
        Me.Name = "frm_recepcion_control_transporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. Recepcion Control de Transporte .::"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim pdataset As New DataSet

    Private Sub frm_quitar_facturas_guia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
        Crear_Esquema()
    End Sub

    Private Sub LlenarCombo()

        Dim ldt_table As New DataTable

        Dim ls_sqlScript As String

        Dim oTransaccion As New Transaccional.Conexion("flexline")
        Try
            oTransaccion.open()

            ls_sqlScript = "pa_sel_um_tipodocumento '" & gs_empresa & "','Despacho (v)'"
            ldt_table = oTransaccion.Obtiene(ls_sqlScript)
            ldt_table.TableName = "tipos"
            pdataset.Tables.Add(ldt_table.Copy)

            Me.cmb_tipos.DisplayMember = "tipoDocto"
            Me.cmb_tipos.ValueMember = "tipoDocto"
            Me.cmb_tipos.DataSource = ldt_table


        Catch ex As Exception
        Finally
            oTransaccion.close()
            oTransaccion = Nothing

        End Try

    End Sub

    Private Sub txt_guia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_guia.LostFocus
        Dim ls_SqlScript As String
        Dim otabla As DataTable
        Dim clGen As New ClasesGenerales.General


        If Me.txt_guia.Text.Length > 0 Then
            Dim oTransaccion As New Transaccional.Conexion("flexline")
            Try
                oTransaccion.open()

                Me.txt_guia.Text = Me.txt_guia.Text.PadLeft(10, "0")
                ls_SqlScript = "pa_sel_um_documento_relacion_detalle '" & Me.cmb_tipos.Text & "','" & gs_empresa & "','" & Me.txt_guia.Text & "'"
                otabla = oTransaccion.Obtiene(ls_SqlScript)

                If oTransaccion.Codigo_error = 0 Then
                    Try
                        pdataset.Reset()
                        Crear_Esquema()
                    Catch ex As Exception
                    End Try

                    otabla.TableName = "guia_liquidador"
                    pdataset.Tables.Add(otabla.Copy)

                    Me.DataGrid1.DataSource = otabla

                    Me.txt_fecha.Text = otabla.Rows(0).Item("FECHA_GUIA").ToString
                    Me.txt_piloto.Text = otabla.Rows(0).Item("PILOTO").ToString
                    Me.txt_observaciones.Text = otabla.Rows(0).Item("Comentario3").ToString

                    clGen.Alinea_Grid(otabla, Me.DataGrid1, otabla.TableName, 4, 200, 40, False, True, "", True, "")

                    Me.DataGrid1.Refresh()

                    'Muevo el ultimo registro para que tome la estructura que deseo

                    Me.Refresh()
                    Me.panel2.Text = "Total de Documentos .:: " & otabla.Rows.Count.ToString
                Else
                    MessageBox.Show(oTransaccion.descripcion_error)
                End If

            Catch ex As Exception
                MessageBox.Show("Guia No Existe, Verique el Numero", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                oTransaccion.close()
                oTransaccion = Nothing
            End Try
        End If
        clGen = Nothing
    End Sub

    Private Sub Crear_Esquema()

        Dim dt As New DataTable("guia_liquidador_copia")

        dt.Columns.Add(New DataColumn("comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("totalingreso", GetType(Double)))
        dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))

        pdataset.Tables.Add(dt.Copy)
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Limpiar_Forma()
    End Sub
    Private Sub Limpiar_Forma()
        pdataset.Reset()
        Crear_Esquema()
        Me.txt_fecha.Text = ""
        Me.txt_guia.Text = ""
        Me.txt_piloto.Text = ""
        Me.txt_observaciones.Text = ""
        Me.Refresh()
        Me.DataGrid1.DataSource = pdataset.Tables("guia_liquidador")
        Me.txt_guia.ReadOnly = False
        Me.txt_guia.Focus()
    End Sub
    Private Sub cmb_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_liberar.Click
        'Liberar_Documentos()
        Actualizar_Documentos_Guia()
        Limpiar_Forma()
    End Sub

    Private Sub Actualizar_Documentos_Guia()
        Dim dr As DataRow
        Dim ls_sqlscript As String
        Dim oTrans As Transaccional.Conexion

        If pdataset.Tables("guia_liquidador").Rows.Count > 0 Then
            oTrans = New Transaccional.Conexion("flexline")

            Try
                oTrans.open()

                For Each dr In pdataset.Tables("guia_liquidador").Rows
                    ls_sqlscript = "pa_upd_um_gen_log_documento_tracking '" & gs_empresa & "','" & dr.Item("tipo") & "','" & _
                                                      dr.Item("numero") & "',NULL,NULL,'" & gs_usuario & "'"
                    oTrans.Actualiza(ls_sqlscript)
                    If oTrans.Codigo_error > 0 Then
                        MessageBox.Show(oTrans.descripcion_error)
                    End If
                Next

                ls_sqlscript = "pa_upd_um_documento_comentario '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_guia.Text & "',NULL,NULL,'" & Me.txt_observaciones.Text & "'"
                oTrans.Actualiza(ls_sqlscript)
                MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
            Finally
                oTrans.close()
                oTrans = Nothing
            End Try
        End If
    End Sub

    Private Sub txt_guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_guia.TextChanged

    End Sub
End Class
