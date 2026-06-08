Public Class frm_consignaciones
    Inherits System.Windows.Forms.Form
    Dim oTransaccion As Transaccional.Conexion
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Dim ls_SqlScript As String

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
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents txt_numero_consignacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_liberar As System.Windows.Forms.Button
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consignaciones))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_numero_consignacion = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_liberar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGrid2 = New System.Windows.Forms.DataGrid
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Empresa"
        Me.Label1.Visible = False
        '
        'cmb_empresa
        '
        Me.cmb_empresa.Enabled = False
        Me.cmb_empresa.Location = New System.Drawing.Point(130, 8)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(273, 23)
        Me.cmb_empresa.TabIndex = 6
        Me.cmb_empresa.TabStop = False
        Me.cmb_empresa.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "No. Consignacion"
        '
        'txt_numero_consignacion
        '
        Me.txt_numero_consignacion.Location = New System.Drawing.Point(130, 36)
        Me.txt_numero_consignacion.Name = "txt_numero_consignacion"
        Me.txt_numero_consignacion.Size = New System.Drawing.Size(100, 21)
        Me.txt_numero_consignacion.TabIndex = 9
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.DataGrid1.CaptionText = "Detalle "
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 96)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(728, 200)
        Me.DataGrid1.TabIndex = 10
        Me.DataGrid1.TabStop = False
        '
        'txt_cod_cliente
        '
        Me.txt_cod_cliente.Location = New System.Drawing.Point(130, 64)
        Me.txt_cod_cliente.Name = "txt_cod_cliente"
        Me.txt_cod_cliente.ReadOnly = True
        Me.txt_cod_cliente.Size = New System.Drawing.Size(100, 21)
        Me.txt_cod_cliente.TabIndex = 11
        '
        'txt_cliente
        '
        Me.txt_cliente.Location = New System.Drawing.Point(236, 64)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(264, 21)
        Me.txt_cliente.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Cliente"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(303, 36)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(100, 21)
        Me.txt_fecha.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(246, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Fecha"
        '
        'btn_liberar
        '
        Me.btn_liberar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_liberar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_liberar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_liberar.ForeColor = System.Drawing.Color.White
        Me.btn_liberar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_liberar.ImageIndex = 0
        Me.btn_liberar.ImageList = Me.ImageList1
        Me.btn_liberar.Location = New System.Drawing.Point(660, 8)
        Me.btn_liberar.Name = "btn_liberar"
        Me.btn_liberar.Size = New System.Drawing.Size(76, 62)
        Me.btn_liberar.TabIndex = 16
        Me.btn_liberar.Text = "&Liberar"
        Me.btn_liberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_liberar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "acceso true.png")
        '
        'DataGrid2
        '
        Me.DataGrid2.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.DataGrid2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid2.BackColor = System.Drawing.Color.DarkGray
        Me.DataGrid2.CaptionBackColor = System.Drawing.Color.Silver
        Me.DataGrid2.CaptionFont = New System.Drawing.Font("Verdana", 10.0!)
        Me.DataGrid2.CaptionForeColor = System.Drawing.Color.Navy
        Me.DataGrid2.CaptionText = "Saldos"
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.ForeColor = System.Drawing.Color.Black
        Me.DataGrid2.GridLineColor = System.Drawing.Color.Black
        Me.DataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGrid2.HeaderBackColor = System.Drawing.Color.Silver
        Me.DataGrid2.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid2.LinkColor = System.Drawing.Color.Navy
        Me.DataGrid2.Location = New System.Drawing.Point(8, 304)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.ParentRowsBackColor = System.Drawing.Color.White
        Me.DataGrid2.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid2.ReadOnly = True
        Me.DataGrid2.SelectionBackColor = System.Drawing.Color.Navy
        Me.DataGrid2.SelectionForeColor = System.Drawing.Color.White
        Me.DataGrid2.Size = New System.Drawing.Size(728, 144)
        Me.DataGrid2.TabIndex = 17
        '
        'frm_consignaciones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(744, 462)
        Me.Controls.Add(Me.DataGrid2)
        Me.Controls.Add(Me.btn_liberar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.txt_cod_cliente)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.txt_numero_consignacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_consignaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liberar Consignaciones"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frm_consignaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
    End Sub

    Private Sub LlenarCombo()

        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet

        oTransaccion = New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_SqlScript = "pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA','" & gs_empresa & "'"
        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "empresas"

        l_Dataset.Tables.Add(ldt_table.Copy)
        'l_Dataset.Tables("empresas").DefaultView.RowFilter = "EMPRESA = '" & gs_empresa & "'"

        Me.cmb_empresa.DisplayMember = "EMPRESA"
        Me.cmb_empresa.ValueMember = "CODIGO"
        Me.cmb_empresa.DataSource = ldt_table

        oTransaccion.close()

    End Sub
    Private Sub txt_numero_consignacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_consignacion.LostFocus


        If Me.txt_numero_consignacion.Text.Length > 0 Then
            Me.txt_numero_consignacion.Text = Me.txt_numero_consignacion.Text.PadLeft(10, "0")
            hacer_busqueda()

        End If
    End Sub

    Private Sub hacer_busqueda()
        Dim otabla As DataTable
        Dim clGen As New ClasesGenerales.General

        Try

            oTransaccion = New Transaccional.Conexion("flexline")
            oTransaccion.open()

            ls_SqlScript = "pa_sel_um_consignaciones_saldos '" & Me.txt_numero_consignacion.Text & "','" & gs_empresa & "'"
            otabla = oTransaccion.Obtiene(ls_SqlScript)
            otabla.TableName = "detalle_saldos"

            Me.DataGrid2.DataSource = otabla
            clGen.Alinea_Grid(otabla, Me.DataGrid2, otabla.TableName, 3, 200, 50, False, True, "", True, "")


            Me.DataGrid2.Refresh()




            ls_SqlScript = "pa_sel_um_consignaciones '" & Me.txt_numero_consignacion.Text & "','" & gs_empresa & "'"
            otabla = oTransaccion.Obtiene(ls_SqlScript)
            otabla.TableName = "detalle"
            oTransaccion.close()

            Me.DataGrid1.DataSource = otabla


            clGen.Alinea_Grid(otabla, Me.DataGrid1, otabla.TableName, 3, 200, 50, False, True, "", True, "")
            Me.txt_fecha.Text = otabla.Rows(0).Item("con_fecha")
            Me.txt_cod_cliente.Text = otabla.Rows(0).Item("con_cliente")
            Me.txt_cliente.Text = otabla.Rows(0).Item("RazonSocial")
            Me.txt_fecha.Focus()


        Catch ex As Exception
            If Me.txt_numero_consignacion.Text.Length > 0 Then
                MessageBox.Show("Problema Con la Busqueda, Verifique El Numero", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Me.txt_fecha.Text = ""
            Me.txt_cod_cliente.Text = ""
            Me.txt_cliente.Text = ""


        Finally
            Me.Refresh()
        End Try
    End Sub
    Private Sub Maquilla_Grid(ByVal otabla As DataTable, ByVal oDataGrid As DataGrid, ByVal ps_nombretabla As String)
        Dim estilo As New DataGridTableStyle
        Dim i As Integer
        Dim clGenerales As New ClasesGenerales.General
        estilo.MappingName = ps_nombretabla

        Dim nombrecolumna As String
        For i = 0 To otabla.Columns.Count() - 1
            If i > 3 Then
                nombrecolumna = otabla.Columns(i).ColumnName
                Dim column As New DataGridTextBoxColumn
                With column
                    .Width = clGenerales.tamaño_maximo_campo(otabla, " ", nombrecolumna, oDataGrid, 200, 50)
                    .MappingName = nombrecolumna.Trim
                    .HeaderText = nombrecolumna.Trim
                End With
                estilo.GridColumnStyles.Add(column)
            End If
        Next

        oDataGrid.TableStyles.Clear()
        oDataGrid.TableStyles.Add(estilo)

        clGenerales = Nothing

    End Sub

    Private Sub btn_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_liberar.Click
        Dim otabla As DataTable
        Dim i As Integer
        oTransaccion = New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_SqlScript = "pa_sel_um_consignaciones_saldos '" & Me.txt_numero_consignacion.Text & "','" & gs_empresa & "'"
        otabla = oTransaccion.Obtiene(ls_SqlScript)
        otabla.TableName = "saldos"

        otabla.DefaultView.RowFilter = "Saldo > 0"

        If otabla.DefaultView.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Liberar la Consignacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                otabla.DefaultView.RowFilter = " "
                For i = 0 To otabla.Rows.Count() - 1
                    If otabla.Rows(i).Item("Saldo") > 0 Then
                        ls_SqlScript = "pa_upd_um_consignaciones '" & gs_empresa & "','CONSIGNACIONES','" & Me.txt_numero_consignacion.Text & "','" & _
                                       otabla.Rows(i).Item("con_producto") & "'," & otabla.Rows(i).Item("Saldo")
                        oTransaccion.Elimina(ls_SqlScript)
                        If oTransaccion.Codigo_error > 0 Then
                            MessageBox.Show(oTransaccion.descripcion_error)
                        End If
                    End If
                Next
                MessageBox.Show("Actualizacion Existosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txt_numero_consignacion.Text = ""
                hacer_busqueda()

                Me.Show()
            End If
        Else
            MessageBox.Show("No Hay Saldo Para Liberar la Consignacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        oTransaccion.close()
    End Sub


End Class
