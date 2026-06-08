Public Class frm_liquidacionPiloto_Finanzas
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
    Friend WithEvents dgDocumentos As System.Windows.Forms.DataGrid
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_guia As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_piloto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_liberar As System.Windows.Forms.Button
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAuxiliar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChequeador As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txt_guia = New System.Windows.Forms.TextBox
        Me.dgDocumentos = New System.Windows.Forms.DataGrid
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.txt_piloto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_tipos = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_liberar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.txtEmpresa = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtVehiculo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAuxiliar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtChequeador = New System.Windows.Forms.TextBox
        Me.txtRuta = New System.Windows.Forms.TextBox
        CType(Me.dgDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_guia
        '
        Me.txt_guia.Location = New System.Drawing.Point(112, 28)
        Me.txt_guia.Name = "txt_guia"
        Me.txt_guia.Size = New System.Drawing.Size(120, 20)
        Me.txt_guia.TabIndex = 0
        '
        'dgDocumentos
        '
        Me.dgDocumentos.CaptionText = "Documentos En Guia"
        Me.dgDocumentos.DataMember = ""
        Me.dgDocumentos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDocumentos.Location = New System.Drawing.Point(8, 122)
        Me.dgDocumentos.Name = "dgDocumentos"
        Me.dgDocumentos.Size = New System.Drawing.Size(696, 248)
        Me.dgDocumentos.TabIndex = 1
        Me.dgDocumentos.TabStop = False
        '
        'DataGrid2
        '
        Me.DataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.DataGrid2.CaptionForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.CaptionText = "Documentos A Liberar"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(8, 376)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.Size = New System.Drawing.Size(696, 112)
        Me.DataGrid2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero Guia"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(395, 28)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(104, 20)
        Me.txt_fecha.TabIndex = 4
        '
        'txt_piloto
        '
        Me.txt_piloto.Location = New System.Drawing.Point(112, 48)
        Me.txt_piloto.Name = "txt_piloto"
        Me.txt_piloto.ReadOnly = True
        Me.txt_piloto.Size = New System.Drawing.Size(232, 20)
        Me.txt_piloto.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Piloto"
        '
        'cmb_tipos
        '
        Me.cmb_tipos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tipos.Location = New System.Drawing.Point(112, 4)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(232, 21)
        Me.cmb_tipos.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 8)
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
        Me.cmb_liberar.Size = New System.Drawing.Size(96, 36)
        Me.cmb_liberar.TabIndex = 9
        Me.cmb_liberar.Text = "&Actualizar"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.Location = New System.Drawing.Point(576, 8)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(96, 34)
        Me.btn_nuevo.TabIndex = 10
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(240, 28)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(104, 20)
        Me.txtEmpresa.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Vehiculo"
        '
        'txtVehiculo
        '
        Me.txtVehiculo.Location = New System.Drawing.Point(112, 70)
        Me.txtVehiculo.Name = "txtVehiculo"
        Me.txtVehiculo.ReadOnly = True
        Me.txtVehiculo.Size = New System.Drawing.Size(232, 20)
        Me.txtVehiculo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Auxiliar"
        '
        'txtAuxiliar
        '
        Me.txtAuxiliar.Location = New System.Drawing.Point(112, 92)
        Me.txtAuxiliar.Name = "txtAuxiliar"
        Me.txtAuxiliar.ReadOnly = True
        Me.txtAuxiliar.Size = New System.Drawing.Size(232, 20)
        Me.txtAuxiliar.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(360, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Ruta"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(360, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cheq"
        '
        'txtChequeador
        '
        Me.txtChequeador.Location = New System.Drawing.Point(395, 48)
        Me.txtChequeador.Name = "txtChequeador"
        Me.txtChequeador.ReadOnly = True
        Me.txtChequeador.Size = New System.Drawing.Size(156, 20)
        Me.txtChequeador.TabIndex = 5
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(395, 71)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(156, 20)
        Me.txtRuta.TabIndex = 5
        '
        'frm_liquidacionPiloto_Finanzas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(704, 502)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.cmb_liberar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_tipos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAuxiliar)
        Me.Controls.Add(Me.txtVehiculo)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.txtChequeador)
        Me.Controls.Add(Me.txt_piloto)
        Me.Controls.Add(Me.txtEmpresa)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.txt_guia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.dgDocumentos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Name = "frm_liquidacionPiloto_Finanzas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liberar Facturas de Guia"
        CType(Me.dgDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim pdataset As New DataSet
    Dim lempresa As String = gs_empresa
    Private Sub frm_quitar_facturas_guia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
        Crear_Esquema()
    End Sub
    Private Sub LlenarCombo()

        Dim ldt_table As New DataTable

        Dim lsSQL As String

        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()


        'ls_sqlScript = "pa_sel_um_tipodocumento '" & gs_empresa & "','Despacho (v)'"
        lsSQL = "pa_sel_um_gen_tabcod NULL,'GEN_EMPRESA','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(lsSQL)
        ldt_table.TableName = "empresa"
        pdataset.Tables.Add(ldt_table.Copy)

        lsSQL = "pa_sel_um_gen_tabcod NULL,'GEN_TIPOGUIA',NULL"
        ldt_table = oTransaccion.Obtiene(lsSQL)
        ldt_table.TableName = "tipos"
        pdataset.Tables.Add(ldt_table.Copy)

        Me.cmb_tipos.DisplayMember = "DESCRIPCION"
        Me.cmb_tipos.ValueMember = "DESCRIPCION"
        Me.cmb_tipos.DataSource = ldt_table

        oTransaccion.close()
    End Sub

    Private Sub txt_guia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_guia.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim ls_SqlScript As String
            Dim otabla As DataTable
            Dim dt As DataTable
            Dim clGen As New ClasesGenerales.General

            If Me.txt_guia.Text.Length = 12 Then
                lempresa = Me.txt_guia.Text.Substring(0, 1)
                Me.txt_guia.Text = Me.txt_guia.Text.Substring(1, 10)
                pdataset.Tables("empresa").DefaultView.RowFilter = "codigo = '0" & lempresa & "'"
                If pdataset.Tables("empresa").DefaultView.Count = 1 Then lempresa = pdataset.Tables("empresa").DefaultView(0)("Descripcion").ToString
            End If





            If Me.txt_guia.Text.Length > 0 Then
                Dim oTransaccion As New Transaccional.Conexion("flexline")
                Try
                    oTransaccion.open()

                    Me.txt_guia.Text = Me.txt_guia.Text.PadLeft(10, "0")
                    ls_SqlScript = "pa_sel_um_documento_relacion_detalle '" & Me.cmb_tipos.Text & "','" & lempresa & "','" & Me.txt_guia.Text & "'"
                    otabla = oTransaccion.Obtiene(ls_SqlScript)

                    If oTransaccion.Codigo_error = 0 Then
                        Try
                            'pdataset.Reset()
                            'Crear_Esquema()
                            pdataset.Tables("guia_liquidador_copia").Rows.Clear()

                        Catch ex As Exception
                        End Try

                        otabla.TableName = "guia_liquidador"
                        'For Each dr As DataRow In otabla.Rows
                        '    dr.Item("Comentario") = "L"
                        'Next
                        If pdataset.Tables.Contains("guia_liquidador") Then pdataset.Tables.Remove("guia_liquidador")
                        pdataset.Tables.Add(otabla.Copy)

                        Me.dgDocumentos.DataSource = otabla
                        Me.dgDocumentos.CaptionText = "Documentos en Guia " & otabla.Rows.Count

                        Me.txt_fecha.Text = otabla.Rows(0).Item("FECHA_GUIA")
                        Me.txt_piloto.Text = otabla.Rows(0).Item("PILOTO").ToString
                        Me.txtAuxiliar.Text = otabla.Rows(0).Item("Auxiliar").ToString
                        Me.txtVehiculo.Text = otabla.Rows(0).Item("Vehiculo").ToString
                        Me.txtChequeador.Text = otabla.Rows(0).Item("Chequeador").ToString
                        Me.txtRuta.Text = otabla.Rows(0).Item("ruta").ToString
                        Me.txtEmpresa.Text = lempresa

                        clGen.Alinea_Grid(otabla, Me.dgDocumentos, otabla.TableName, 4, 200, 40, False, True, "", True, "")


                        Me.dgDocumentos.Refresh()
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

            'If pdataset.Tables("guia_liquidador").Rows.Count > 0 Then

            '    If MessageBox.Show("Desea Procesar la Liquidacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        'Liberar_Documentos()
            '        Actualizar_Documentos_Guia()
            '        Limpiar_Forma()
            '    End If
            'End If
        End If

    End Sub

    Private Sub txt_guia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_guia.LostFocus

    End Sub


    Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumentos.DoubleClick

        Dim li_row_number As Integer

        li_row_number = Me.dgDocumentos.CurrentCell.RowNumber
        Mover_registro_a_copia(li_row_number)

    End Sub
    Private Sub Mover_registro_a_copia(ByVal pi_numero_registro As Integer)
        Dim dgtbc As DataGridTextBoxColumn
        Dim clGen As New ClasesGenerales.General
        Dim dr As DataRow
        Dim ls_resultado As String

        ls_resultado = Me.dgDocumentos.Item(pi_numero_registro, 2)

        pdataset.Tables("guia_liquidador").DefaultView.RowFilter = "numero = '" & ls_resultado & "'"

        'Le saco copia al registro a eliminar
        dr = pdataset.Tables("guia_liquidador_copia").NewRow()

        dr("empresa") = pdataset.Tables("guia_liquidador").DefaultView(0)("empresa")
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

        Me.dgDocumentos.DataSource = pdataset.Tables("guia_liquidador")
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

        dt.Columns.Add(New DataColumn("empresa", GetType(String)))
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
        'pdataset.Reset()
        'Crear_Esquema()
        pdataset.Tables("guia_liquidador_copia").Rows.Clear()
        pdataset.Tables("guia_liquidador").Rows.Clear()
        Me.txt_fecha.Text = ""
        Me.txt_guia.Text = ""
        Me.txt_piloto.Text = ""
        Me.txtAuxiliar.Text = ""
        Me.txtVehiculo.Text = ""
        Me.txtChequeador.Text = String.Empty
        Me.txtRuta.Text = String.Empty
        Me.txtEmpresa.Text = String.Empty

        Me.Refresh()
        Me.dgDocumentos.DataSource = pdataset.Tables("guia_liquidador")
        Me.dgDocumentos.CaptionText = "Documentos en Guia "
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
                    ls_sqlscript = "pa_upd_um_documentod_guia '" & dr.Item("Empresa").ToString & "','" & dr.Item("tipo").ToString & "','" & _
                                    dr.Item("numero").ToString & "','" & Me.txt_guia.Text & "','" & Me.cmb_tipos.Text & "','" & _
                                    dr.Item("comentario").ToString & "','" & gs_usuario & "'"
                    oTrans.Actualiza(ls_sqlscript)
                    If oTrans.Codigo_error > 0 Then
                        MessageBox.Show(oTrans.descripcion_error)
                    End If
                Catch ex As Exception
                    ' MessageBox.Show(ex.Message)
                End Try

            Next
            oTrans.close()
            oTrans = Nothing
            MessageBox.Show("Proceso Finalizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Me.dgDocumentos.DataSource = pdataset.Tables("guia_liquidador")
        Me.DataGrid2.DataSource = pdataset.Tables("guia_liquidador_copia")

        Me.txt_guia.ReadOnly = True
    End Sub



    Private Sub txt_guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_guia.TextChanged

    End Sub
End Class
