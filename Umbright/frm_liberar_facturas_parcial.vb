Public Class frm_liberar_factura_parcial
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
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_piloto As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_liberar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents txt_factura As System.Windows.Forms.TextBox
    Friend WithEvents txt_codcliente As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txt_factura = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.txt_piloto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_tipos = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_liberar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.txt_codcliente = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_factura
        '
        Me.txt_factura.Location = New System.Drawing.Point(112, 40)
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.Size = New System.Drawing.Size(120, 20)
        Me.txt_factura.TabIndex = 0
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Productos en Factura"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 96)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(680, 384)
        Me.DataGrid1.TabIndex = 1
        Me.DataGrid1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero Factura"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(240, 40)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(104, 20)
        Me.txt_fecha.TabIndex = 4
        '
        'txt_piloto
        '
        Me.txt_piloto.Location = New System.Drawing.Point(240, 64)
        Me.txt_piloto.Name = "txt_piloto"
        Me.txt_piloto.ReadOnly = True
        Me.txt_piloto.Size = New System.Drawing.Size(272, 20)
        Me.txt_piloto.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cliente"
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
        Me.Label3.Size = New System.Drawing.Size(72, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tipo Doco"
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
        'txt_codcliente
        '
        Me.txt_codcliente.Location = New System.Drawing.Point(112, 64)
        Me.txt_codcliente.Name = "txt_codcliente"
        Me.txt_codcliente.ReadOnly = True
        Me.txt_codcliente.Size = New System.Drawing.Size(120, 20)
        Me.txt_codcliente.TabIndex = 11
        '
        'frm_liberar_factura_parcial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 502)
        Me.Controls.Add(Me.txt_codcliente)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.cmb_liberar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_tipos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_piloto)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.txt_factura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "frm_liberar_factura_parcial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liberar Parcialmente Facturas "
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim pdataset As New DataSet
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Private okToValidate As Boolean
    Private okToValidate2 As Boolean = True

    Private Sub LlenarCombo()

        Dim ls_sqlScript As String

        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_sqlScript = "pa_sel_um_tipodocumento '" & gs_empresa & "',NULL"
        ldt_table = oTransaccion.Obtiene(ls_sqlScript)
        ldt_table.TableName = "tipos"
        pdataset.Tables.Add(ldt_table.Copy)

        ldt_table.DefaultView.RowFilter = " tipodocto like '%FAC%' Or tipodocto like '%FEL%'"
        Me.cmb_tipos.DisplayMember = "tipoDocto"
        Me.cmb_tipos.ValueMember = "tipoDocto"
        Me.cmb_tipos.DataSource = ldt_table

        oTransaccion.close()
        oTransaccion = Nothing
    End Sub

    Private Sub frm_quitar_facturas_guia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
    End Sub

    Private Sub txt_guia_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura.LostFocus
        Dim ls_SqlScript As String
        Dim dgtbc As DataGridTextBoxColumn
        Dim otabla As DataTable
        Dim clGen As New ClasesGenerales.General
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        If Me.txt_factura.Text.Length > 0 Then
            Try
                newcurrentrow = -1
                newcurrentcol = -1
                okToValidate = True
                Me.txt_factura.ReadOnly = True
                Me.cmb_tipos.Enabled = False

                Me.txt_factura.Text = Me.txt_factura.Text.PadLeft(10, "0")
                ls_SqlScript = "pa_var_um_documento_detalle_liberar '" & Me.cmb_tipos.Text & "','" & gs_empresa & "','" & Me.txt_factura.Text & "'"
                otabla = oTransaccion.Obtiene(ls_SqlScript)
                Try
                    pdataset.Reset()
                Catch ex As Exception
                End Try
                otabla.TableName = "detalle_documento"
                pdataset.Tables.Add(otabla.Copy)

                Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")

                Me.txt_fecha.Text = otabla.Rows(0).Item("FECHA")
                Me.txt_piloto.Text = otabla.Rows(0).Item("razonsocial")
                Me.txt_codcliente.Text = otabla.Rows(0).Item("cliente")
                clGen.Alinea_Grid(pdataset.Tables("detalle_documento"), Me.DataGrid1, pdataset.Tables("detalle_documento").TableName, 2, 300, 40, False, True, "", True, "")


                dgtbc = DataGrid1.TableStyles(0).GridColumnStyles(0)
                If Not (dgtbc Is Nothing) Then
                    dgtbc.Format = "#"  ' 0r "#.000" f3 Or c4;
                End If

                dgtbc = DataGrid1.TableStyles(0).GridColumnStyles(1)
                If Not (dgtbc Is Nothing) Then
                    dgtbc.Format = "#"  ' 0r "#.000" f3 Or c4;
                End If

                Me.DataGrid1.Refresh()
                Me.Refresh()

            Catch ex As Exception
                MessageBox.Show("Documento No Existe, Verique el Numero", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmb_tipos.Enabled = True
                Me.txt_factura.ReadOnly = False
            Finally
                oTransaccion.close()
                oTransaccion = Nothing
            End Try

        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Limpiar_Forma()
    End Sub

    Private Sub Limpiar_Forma()
        pdataset.Reset()
        Me.cmb_tipos.Enabled = True
        Me.txt_fecha.Text = ""
        Me.txt_factura.Text = ""
        Me.txt_piloto.Text = ""
        Me.Refresh()
        Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")
        Me.txt_factura.ReadOnly = False
        Me.txt_factura.Focus()
    End Sub

    Private Sub cmb_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_liberar.Click
        'Liberar_Documentos()
        Actualizar_documento()
        Limpiar_Forma()
    End Sub

    Private Sub Actualizar_documento()
        Dim ls_Sql As String
        Dim drw As DataRowView
        Dim otabla As DataTable
        Dim oTrans As New Transaccional.Conexion("flexline")

        Try
            oTrans.open()

            otabla = pdataset.Tables("detalle_documento").Copy
            otabla.DefaultView.RowFilter = "cantidad <> cantidadasignada"

            If otabla.DefaultView.Count > 0 Then
                If MessageBox.Show("Esta Seguro de Liberar los Productos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    For Each drw In otabla.DefaultView(0).DataView
                        ls_Sql = "pa_upd_um_consignaciones '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_factura.Text & "','" &
                                        drw("producto") &
                                         "'," & drw("cantidad") - drw("cantidadasignada") & "," & drw("secuencia")

                        oTrans.Elimina(ls_Sql)
                        If oTrans.Codigo_error > 0 Then
                            MessageBox.Show(oTrans.descripcion_error)
                        End If
                    Next
                    MessageBox.Show("Actualizacion Existosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No Hay Valores Para Liberar ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            oTrans.close()
            oTrans = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Public Function DatoValido(ByVal row As Integer, ByVal col As Integer) As Boolean
        Dim returnValue As Boolean = True
        Dim clgen As New ClasesGenerales.General
        Try

            If col = 1 Then

                ' returnValue = False
                'And (row > 0 And row < 4) Then
                '    clgen.Alinea_Grid(pds_Dataset.Tables("detalle"), Me.DataGrid1, pds_Dataset.Tables("detalle").TableName, -1, 300, 60, False)
            End If
            If col = 0 Then
                If Me.DataGrid1(row, col) > Me.DataGrid1(row, col + 1) Or Me.DataGrid1(row, col) < 0 Then
                    'If newText > ls_valor Then
                    Me.DataGrid1(row, col) = Me.DataGrid1(row, col + 1)
                    returnValue = False
                End If
            End If
        Catch ex As Exception
            'returnValue = True

        End Try

        Return returnValue

    End Function

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        newcurrentrow = DataGrid1.CurrentCell.RowNumber
        newcurrentcol = DataGrid1.CurrentCell.ColumnNumber


        '        Me.txt_cod_producto.Text = ls_codigo

        If okToValidate And Not DatoValido(oldcurrentrow, oldcurrentcol) Then

            okToValidate = False
            If oldcurrentcol = 1 Then 'La Validacion  del codigo del producto la hago en el nombre del producto
                DataGrid1.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 1)
                MessageBox.Show("Ingreso Un Valor Invalido")
            Else
                DataGrid1.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol)
            End If
            okToValidate = True
        Else
            oldcurrentrow = newcurrentrow
            oldcurrentcol = newcurrentcol
            If newcurrentcol = 1 Then
                SendKeys.Send("{Tab}")
            End If
        End If
        If newcurrentcol = 2 Then
            SendKeys.Send("{Tab}")
        End If
        If newcurrentcol = 3 Then
            SendKeys.Send("{Tab}")
        End If
    End Sub



    Private Sub txt_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura.TextChanged

    End Sub
End Class
