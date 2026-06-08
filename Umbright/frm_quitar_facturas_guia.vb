Public Class frm_quitar_facturas_guia
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
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_guia As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_piloto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_liberar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txt_guia = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.txt_piloto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_tipos = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_liberar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_guia
        '
        Me.txt_guia.Location = New System.Drawing.Point(112, 40)
        Me.txt_guia.Name = "txt_guia"
        Me.txt_guia.Size = New System.Drawing.Size(120, 20)
        Me.txt_guia.TabIndex = 0
        Me.txt_guia.Text = ""
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Documentos En Guia"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 96)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(696, 248)
        Me.DataGrid1.TabIndex = 1
        Me.DataGrid1.TabStop = False
        '
        'DataGrid2
        '
        Me.DataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.DataGrid2.CaptionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.CaptionText = "Documentos A Liberar"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(8, 352)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(696, 136)
        Me.DataGrid2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero Guia"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(240, 40)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(104, 20)
        Me.txt_fecha.TabIndex = 4
        Me.txt_fecha.Text = ""
        '
        'txt_piloto
        '
        Me.txt_piloto.Location = New System.Drawing.Point(112, 64)
        Me.txt_piloto.Name = "txt_piloto"
        Me.txt_piloto.ReadOnly = True
        Me.txt_piloto.Size = New System.Drawing.Size(232, 20)
        Me.txt_piloto.TabIndex = 5
        Me.txt_piloto.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
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
        Me.cmb_tipos.TabIndex = 7
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
        Me.cmb_liberar.Location = New System.Drawing.Point(576, 48)
        Me.cmb_liberar.Name = "cmb_liberar"
        Me.cmb_liberar.Size = New System.Drawing.Size(96, 24)
        Me.cmb_liberar.TabIndex = 9
        Me.cmb_liberar.Text = "&Actualizar"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Location = New System.Drawing.Point(576, 8)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(96, 23)
        Me.btn_nuevo.TabIndex = 10
        Me.btn_nuevo.Text = "&Nuevo"
        '
        'frm_quitar_facturas_guia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 502)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.cmb_liberar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_tipos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_piloto)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.txt_guia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "frm_quitar_facturas_guia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liberar Facturas de Guia"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
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
        oTransaccion.open()


        'ls_sqlScript = "pa_sel_um_tipodocumento '" & gs_empresa & "','Despacho (v)'"
        ls_sqlScript = "pa_sel_um_gen_tabcod NULL,'GEN_TIPOGUIA',NULL"
        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "tipos"
        pdataset.Tables.Add(ldt_table.Copy)

        Me.cmb_tipos.DisplayMember = "DESCRIPCION"
        Me.cmb_tipos.ValueMember = "DESCRIPCION"
        Me.cmb_tipos.DataSource = ldt_table

        oTransaccion.close()
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

                    Me.txt_fecha.Text = otabla.Rows(0).Item("FECHA_GUIA")
                    Me.txt_piloto.Text = otabla.Rows(0).Item("PILOTO")

                    clGen.Alinea_Grid(otabla, Me.DataGrid1, otabla.TableName, 4, 200, 40, False, True, "", True, "")

                    'dgtbc = DataGrid1.TableStyles(0).GridColumnStyles(4)
                    'If Not (dgtbc Is Nothing) Then
                    '    dgtbc.Format = "n"  ' 0r "#.000" f3 Or c4;
                    'End If

                    Me.DataGrid1.Refresh()
                    Me.DataGrid2.Refresh()

                    'Muevo el ultimo registro para que tome la estructura que deseo
                    Mover_registro_a_copia(otabla.Rows.Count - 1)
                    'Regreso el registro que movi previamente
                    DataGrid2_DoubleClick(sender, e)

                    Me.Refresh()
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


    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick

        Dim li_row_number As Integer

        li_row_number = Me.DataGrid1.CurrentCell.RowNumber
        Mover_registro_A_copia(li_row_number)

    End Sub
    Private Sub Mover_registro_a_copia(ByVal pi_numero_registro As Integer)
        Dim dgtbc As DataGridTextBoxColumn
        Dim clGen As New ClasesGenerales.General
        Dim dr As DataRow
        Dim ls_resultado As String

        ls_resultado = Me.DataGrid1.Item(pi_numero_registro, 2)

        pdataset.Tables("guia_liquidador").DefaultView.RowFilter = "numero = '" & ls_resultado & "'"

        'Le saco copia al registro a eliminar
        dr = pdataset.Tables("guia_liquidador_copia").NewRow()

        dr("comentario") = pdataset.Tables("guia_liquidador").DefaultView(0)("comentario")
        dr("tipo") = pdataset.Tables("guia_liquidador").DefaultView(0)("tipo")
        dr("numero") = pdataset.Tables("guia_liquidador").DefaultView(0)("numero")
        dr("fecha") = pdataset.Tables("guia_liquidador").DefaultView(0)("fecha")
        dr("totalingreso") = pdataset.Tables("guia_liquidador").DefaultView(0)("totalingreso")
        dr("cod_cliente") = pdataset.Tables("guia_liquidador").DefaultView(0)("cod_cliente")
        dr("nombre") = pdataset.Tables("guia_liquidador").DefaultView(0)("nombre")

        pdataset.Tables("guia_liquidador_copia").Rows.Add(dr)

        pdataset.Tables("guia_liquidador").DefaultView.Delete(0)
        pdataset.Tables("guia_liquidador").DefaultView.RowFilter = " "

        Me.DataGrid1.DataSource = pdataset.Tables("guia_liquidador")
        Me.DataGrid2.DataSource = pdataset.Tables("guia_liquidador_copia")

        If pdataset.Tables("guia_liquidador_copia").Rows.Count > 0 Then
            clGen.Alinea_Grid(pdataset.Tables("guia_liquidador_copia"), Me.DataGrid2, "guia_liquidador_copia", -1, 200, 40, False, True, "", True, "")

            dgtbc = DataGrid2.TableStyles(0).GridColumnStyles(4)
            If Not (dgtbc Is Nothing) Then
                dgtbc.Format = "n"  ' 0r "#.000" f3 Or c4;
            End If
        End If
        Me.txt_guia.ReadOnly = True

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
        Me.Refresh()
        Me.DataGrid1.DataSource = pdataset.Tables("guia_liquidador")
        Me.txt_guia.ReadOnly = False
        Me.txt_guia.Focus()
    End Sub
    Private Sub cmb_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_liberar.Click
        Liberar_Documentos()
        Actualizar_Documentos_Guia()
        Limpiar_Forma()
    End Sub
    Private Sub Actualizar_Documentos_Guia()
        Dim i As Integer
        Dim dr As DataRow
        Dim ls_sqlscript As String
        Dim oTrans As Transaccional.Conexion

        If pdataset.Tables("guia_liquidador").Rows.Count > 0 Then
            oTrans = New Transaccional.Conexion("flexline")
            oTrans.open()

            For i = 0 To pdataset.Tables("guia_liquidador").Rows.Count - 1
                Try
                    dr = pdataset.Tables("guia_liquidador").Rows(i)
                    ls_sqlscript = "pa_upd_um_documentod_guia '" & gs_empresa & "','" & dr.Item("tipo") & "','" & _
                                    dr.Item("numero") & "','" & Me.txt_guia.Text & "','" & Me.cmb_tipos.Text & "','" & _
                                    dr.Item("comentario") & "','" & gs_usuario & "'"
                    oTrans.Actualiza(ls_sqlscript)
                    If oTrans.Codigo_error > 0 Then
                        MessageBox.Show(oTrans.descripcion_error)
                    End If
                Catch ex As Exception
                    ' MessageBox.Show(ex.Message)
                End Try

            Next
            oTrans.close()
        End If
    End Sub
    Private Sub Liberar_Documentos()
        Dim i As Integer
        Dim ls_sqlscript As String
        Dim dr As DataRow
        Dim oTrans As New Transaccional.Conexion("flexline")

        Try
            oTrans.open()


            If pdataset.Tables("guia_liquidador_copia").Rows.Count > 0 Then
                If MessageBox.Show("Se Liberaran " & pdataset.Tables("guia_liquidador_copia").Rows.Count & _
                                    " documentos, Desea Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    

                    For i = 0 To pdataset.Tables("guia_liquidador_copia").Rows.Count - 1
                        dr = pdataset.Tables("guia_liquidador_copia").Rows(i)
                        ls_sqlscript = "pa_del_um_documentod_guia '" & gs_empresa & "','" & dr.Item("tipo") & "','" & _
                                        dr.Item("numero") & "','" & Me.txt_guia.Text & "','" & Me.cmb_tipos.Text & "','" & _
                                        dr.Item("comentario") & "','" & gs_usuario & "'"
                        oTrans.Elimina(ls_sqlscript)
                        If oTrans.Codigo_error > 0 Then
                            MessageBox.Show(oTrans.descripcion_error)
                        End If
                    Next

                End If
            Else
                'MessageBox.Show("No Hay Documentos Para Liberar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
    End Sub
    Private Sub DataGrid2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid2.DoubleClick
        Dim li_row_number As Integer
        Dim ls_resultado As String

        li_row_number = Me.DataGrid2.CurrentCell.RowNumber
        ls_resultado = Me.DataGrid2.Item(li_row_number, 2)

        Dim dr As DataRow

        pdataset.Tables("guia_liquidador_copia").DefaultView.RowFilter = "numero = '" & ls_resultado & "'"

        'Le saco copia al registro a eliminar
        dr = pdataset.Tables("guia_liquidador").NewRow()

        dr("comentario") = pdataset.Tables("guia_liquidador_copia").DefaultView(0)("comentario")
        dr("tipo") = pdataset.Tables("guia_liquidador_copia").DefaultView(0)("tipo")
        dr("numero") = pdataset.Tables("guia_liquidador_copia").DefaultView(0)("numero")
        dr("fecha") = pdataset.Tables("guia_liquidador_copia").DefaultView(0)("fecha")
        dr("totalingreso") = pdataset.Tables("guia_liquidador_copia").DefaultView(0)("totalingreso")
        dr("cod_cliente") = pdataset.Tables("guia_liquidador_copia").DefaultView(0)("cod_cliente")
        dr("nombre") = pdataset.Tables("guia_liquidador_copia").DefaultView(0)("nombre")
        pdataset.Tables("guia_liquidador").Rows.Add(dr)

        pdataset.Tables("guia_liquidador_copia").DefaultView.Delete(0)
        pdataset.Tables("guia_liquidador_copia").DefaultView.RowFilter = " "
        Me.DataGrid1.DataSource = pdataset.Tables("guia_liquidador")
        Me.DataGrid2.DataSource = pdataset.Tables("guia_liquidador_copia")

        Me.txt_guia.ReadOnly = True
    End Sub



End Class
