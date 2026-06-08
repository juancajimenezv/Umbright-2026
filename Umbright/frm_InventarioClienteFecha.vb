Public Class frm_InventarioClienteFecha
    Inherits System.Windows.Forms.Form
    Dim oTransaccion As Transaccional.Conexion
    Dim ls_SqlScript As String
    Dim oTabla1 As DataTable
    Dim newcurrentrow, newcurrentcol, oldcurrentrow, oldcurrentcol As Integer
    Private okToValidate As Boolean
    Private okToValidate2 As Boolean = True
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Dim pds_Dataset As New DataSet

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
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents txt_CodCliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_producto As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_InventarioCliente))
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.txt_CodCliente = New System.Windows.Forms.TextBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_producto = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_buscar_producto = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(11, 168)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(500, 333)
        Me.DataGrid1.TabIndex = 0
        '
        'cmb_empresa
        '
        Me.cmb_empresa.Enabled = False
        Me.cmb_empresa.Location = New System.Drawing.Point(80, 8)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(232, 24)
        Me.cmb_empresa.TabIndex = 1
        Me.cmb_empresa.TabStop = False
        Me.cmb_empresa.Visible = False
        '
        'txt_CodCliente
        '
        Me.txt_CodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CodCliente.Location = New System.Drawing.Point(80, 40)
        Me.txt_CodCliente.Name = "txt_CodCliente"
        Me.txt_CodCliente.Size = New System.Drawing.Size(80, 20)
        Me.txt_CodCliente.TabIndex = 2
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.Location = New System.Drawing.Point(159, 40)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(24, 20)
        Me.btn_buscar.TabIndex = 3
        Me.btn_buscar.Text = "..."
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'txt_cliente
        '
        Me.txt_cliente.Location = New System.Drawing.Point(200, 39)
        Me.txt_cliente.Multiline = True
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_cliente.Size = New System.Drawing.Size(311, 58)
        Me.txt_cliente.TabIndex = 4
        Me.txt_cliente.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Empresa"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cliente"
        '
        'txt_cod_producto
        '
        Me.txt_cod_producto.Location = New System.Drawing.Point(80, 103)
        Me.txt_cod_producto.Name = "txt_cod_producto"
        Me.txt_cod_producto.Size = New System.Drawing.Size(80, 22)
        Me.txt_cod_producto.TabIndex = 10
        Me.txt_cod_producto.Visible = False
        '
        'txt_producto
        '
        Me.txt_producto.Location = New System.Drawing.Point(200, 103)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.ReadOnly = True
        Me.txt_producto.Size = New System.Drawing.Size(278, 22)
        Me.txt_producto.TabIndex = 11
        Me.txt_producto.TabStop = False
        Me.txt_producto.Visible = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(32, 103)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(48, 22)
        Me.txt_cantidad.TabIndex = 12
        Me.txt_cantidad.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Producto"
        Me.Label3.Visible = False
        '
        'btn_buscar_producto
        '
        Me.btn_buscar_producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar_producto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_producto.ForeColor = System.Drawing.Color.White
        Me.btn_buscar_producto.Location = New System.Drawing.Point(159, 103)
        Me.btn_buscar_producto.Name = "btn_buscar_producto"
        Me.btn_buscar_producto.Size = New System.Drawing.Size(24, 22)
        Me.btn_buscar_producto.TabIndex = 15
        Me.btn_buscar_producto.Text = "..."
        Me.btn_buscar_producto.UseVisualStyleBackColor = False
        Me.btn_buscar_producto.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "clear.png")
        Me.ImageList1.Images.SetKeyName(1, "Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(2, "personal-information.png")
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.ImageIndex = 1
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(536, 167)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 77)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "&Grabar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.ImageIndex = 0
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(536, 265)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 77)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "&Limpiar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.ImageIndex = 2
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(536, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(93, 89)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Informacion Cliente"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'frm_InventarioCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(641, 513)
        Me.Controls.Add(Me.txt_cod_producto)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btn_buscar_producto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.txt_producto)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txt_CodCliente)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_InventarioCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inventario Cliente"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frm_InventarioCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '    LlenarCombo()
        'Generar_Informacion_Inventario()
        'Crear_Esquema()

        generar_informacion_general()

    End Sub

    Private Sub copiar_inventario_cliente()
        Dim dr As DataRow
        Dim i, ii As Integer

        For i = 0 To pds_Dataset.Tables("sysgold_inventario_cliente").Rows.Count - 1
            dr = pds_Dataset.Tables("detalle").NewRow()
            For ii = 0 To 2
                dr(ii) = pds_Dataset.Tables("sysgold_inventario_cliente").Rows(i)(ii)
            Next
            pds_Dataset.Tables("detalle").Rows.Add(dr)
        Next

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

        Me.cmb_empresa.DisplayMember = "EMPRESA"
        Me.cmb_empresa.ValueMember = "CODIGO"
        Me.cmb_empresa.DataSource = ldt_table

        oTransaccion.close()

    End Sub

    Private Sub Buscar_Cliente()
        'Dim clGen As New ClasesGenerales.General
        Dim oTable As New DataTable


        Try
            pds_Dataset.Tables.Remove("clientes_flexline")
            'Generar_Informacion_Inventario()
            'Crear_Esquema()


        Catch ex As Exception

        End Try

        newcurrentrow = -1
        newcurrentcol = -1
        okToValidate = True

        If Me.txt_CodCliente.Text.Length > 0 Then
            oTransaccion = New Transaccional.Conexion("flexline")
            oTransaccion.open()
            ls_SqlScript = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & Me.txt_CodCliente.Text.Trim & "'"
            oTable = oTransaccion.Obtiene(ls_SqlScript)
            oTable.TableName = "clientes_flexline"

            pds_Dataset.Tables.Add(oTable.Copy)

            If oTable.Rows.Count = 0 Then
                MessageBox.Show("Cliente No Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'Me.DataGrid1.DataSource = oTable
                Me.txt_cliente.Text = oTable.Rows(0).Item("RazonSocial") & "/" & oTable.Rows(0).Item("giro")
                Me.txt_cod_producto.Focus()
            End If

            oTransaccion.close()

            'clGen = Nothing

        End If

    End Sub

    Private Sub txt_CodEjecutivo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_CodCliente.LostFocus
        Buscar_Cliente()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Generar_Informacion_Inventario()
    End Sub

    Private Sub Generar_Informacion_Inventario()
        Try
            pds_Dataset.Tables.Remove("sysgold_inventario_cliente")
        Catch ex As Exception

        End Try

        oTransaccion = New Transaccional.Conexion("Umbright_Movil")
        oTransaccion.open()

        ls_SqlScript = "pa_sel_um_cliinvne_articulo '" & Me.txt_CodCliente.Text.Trim & pds_Dataset.Tables("empresas").Rows(0)("codigo") & "'"
        oTabla1 = oTransaccion.Obtiene(ls_SqlScript)
        oTabla1.TableName = "sysgold_inventario_cliente"
        pds_Dataset.Tables.Add(oTabla1.Copy)

        oTransaccion.close()
    End Sub

    Private Sub generar_informacion_general()
        Dim ls_tipo As String
        Dim ldt_table As DataTable

        Dim oTrans = New Transaccional.Conexion("flexline")
        oTrans.open()

        ls_SqlScript = "pa_sel_um_producto '" & gs_empresa & "',NULL"
        oTabla1 = oTrans.Obtiene(ls_SqlScript)
        oTabla1.TableName = "producto"
        pds_Dataset.Tables.Add(oTabla1.Copy)

        ls_SqlScript = "pa_sel_um_gen_tabcod null,'SYSGOLD_EMPRESA','" & gs_empresa & "'"
        ldt_table = oTrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "empresas"
        pds_Dataset.Tables.Add(ldt_table.Copy)

        ls_tipo = "SYSGOLD_EJECUTIVOS"
        ls_SqlScript = "pa_sel_um_gen_tabcod NULL,'" & ls_tipo & "','" & gs_empresa & "'"
        oTabla1 = oTrans.Obtiene(ls_SqlScript)
        oTabla1.TableName = "sysgold_ejecutivos"
        pds_Dataset.Tables.Add(oTabla1.Copy)

        oTrans.close()
        oTrans = Nothing
        Crear_Esquema()
    End Sub

    Private Sub txt_cod_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_producto.LostFocus
        If Me.txt_cod_producto.Text.Length > 0 Then

            If Buscar_Producto(Me.txt_producto.Text) Then
                Me.txt_producto.Text = pds_Dataset.Tables("producto").DefaultView(0)("GLOSA")
                Me.txt_cantidad.Focus()
            Else
                Me.txt_producto.Text = ""
                Me.txt_cod_producto.Text = ""
                Me.txt_cod_producto.Focus()
            End If
        End If
    End Sub

    Private Function Buscar_Producto(ByVal producto As String) As Boolean
        'Consultar el producto dentro del dataset
        'Dim producto As String

        'If Me.txt_cod_producto.Text.Length > 0 Then
        Try
            '   producto = txt_cod_producto.Text
            pds_Dataset.Tables("producto").DefaultView.RowFilter = "PRODUCTO = '" & producto & "'"


            Return True
        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Return False
        End Try
        'End If
    End Function

    Private Sub Crear_Esquema()
        Dim clGen As New ClasesGenerales.General
        Dim dt As New DataTable("detalle")

        dt.Columns.Add(New DataColumn("Codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Existencia", GetType(Integer)))
        pds_Dataset.Tables.Add(dt.Copy)


        Me.DataGrid1.DataSource = pds_Dataset.Tables("detalle")
        clGen.Alinea_Grid(dt, Me.DataGrid1, dt.TableName, -1, 200, 60, False, False, "", True, "")

        clGen = Nothing

    End Sub

    Private Sub Ingresar_A_Esquema()
        Dim dr As DataRow

        dr = pds_Dataset.Tables("detalle").NewRow()

        dr("Codigo") = Me.txt_cod_producto.Text
        dr("Descripcion") = Me.txt_producto.Text
        dr("Existencia") = Int32.Parse(Me.txt_cantidad.Text)

        pds_Dataset.Tables("detalle").Rows.Add(dr)
    End Sub

    Private Sub txt_cantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.LostFocus
        Dim li_valor As Integer
        If Me.txt_producto.Text.Length > 0 And Me.txt_cod_producto.Text.Length > 0 And Me.txt_cantidad.Text.Length > 0 Then

            Try
                li_valor = Int32.Parse(Me.txt_cantidad.Text)
                If li_valor < 0 Then
                    MessageBox.Show("No Ingresar valores Negativos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txt_cantidad.Text = ""
                    Me.txt_producto.Focus()
                Else

                    pds_Dataset.Tables("detalle").DefaultView.RowFilter = "Codigo = '" & txt_cod_producto.Text & "'"

                    If pds_Dataset.Tables("detalle").DefaultView.Count = 0 Then
                        Ingresar_A_Esquema()
                    Else
                        Modificar_Esquema()
                    End If
                    Me.txt_CodCliente.Enabled = False
                    Me.txt_cantidad.Text = ""
                    Me.txt_cod_producto.Text = ""
                    Me.txt_producto.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show("Debe Ingresar Datos Numericos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txt_cantidad.Text = ""
                Me.txt_cantidad.Focus()
            End Try
        End If
        Me.txt_cod_producto.Focus()

        pds_Dataset.Tables("detalle").DefaultView.RowFilter = ""
    End Sub

    Private Sub Modificar_Esquema()
        pds_Dataset.Tables("detalle").DefaultView(0)("Existencia") = Int32.Parse(Me.txt_cantidad.Text)
    End Sub

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Limpiar_Forma()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ofila As DataRow
        Dim otabla As DataTable
        Dim ls_inv_articulo, ls_inv_asesor, ls_inv_cliente As String
        Dim li_inv_existencia As Integer
        Dim ls_ejecutivo As String


        Try
            Me.txt_producto.Text = ""
            Me.txt_producto.Visible = True
            If pds_Dataset.Tables("detalle").Rows.Count > 0 Then
                ls_ejecutivo = pds_Dataset.Tables("clientes_flexline").Rows(0).Item("ejecutivo")
                pds_Dataset.Tables("sysgold_ejecutivos").DefaultView.RowFilter = "DESCRIPCION = '" & ls_ejecutivo & "'"

                'ls_inv_asesor = pds_Dataset.Tables("sysgold_ejecutivos").DefaultView(0)("codigo") & cmb_empresa.SelectedValue
                ls_inv_asesor = pds_Dataset.Tables("sysgold_ejecutivos").DefaultView(0)("codigo") & pds_Dataset.Tables("empresas").Rows(0).Item("codigo")
                oTransaccion = New Transaccional.Conexion("Umbright_movil")
                oTransaccion.open()

                Try
                    otabla = pds_Dataset.Tables("detalle")
                    For Each ofila In otabla.Rows

                        'ls_inv_cliente = Me.txt_CodCliente.Text.Trim & cmb_empresa.SelectedValue
                        'ls_inv_articulo = ofila.Item("Codigo") & cmb_empresa.SelectedValue
                        ls_inv_cliente = Me.txt_CodCliente.Text.Trim & pds_Dataset.Tables("empresas").Rows(0).Item("codigo")
                        ls_inv_articulo = ofila.Item("Codigo") & pds_Dataset.Tables("empresas").Rows(0).Item("codigo")
                        li_inv_existencia = ofila.Item("Existencia")

                        ls_SqlScript = "pa_ins_um_cliinven '" & ls_inv_cliente & "','" & _
                                        ls_inv_asesor & "','" & ls_inv_articulo & "'," & _
                                        li_inv_existencia.ToString()

                        oTransaccion.Ingresa(ls_SqlScript)
                        Me.txt_producto.Text = "Actualizando " & ls_inv_articulo
                    Next
                    Me.txt_producto.Text = ""
                    MessageBox.Show("Informacion Actualiza Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar_Forma()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                Me.txt_producto.Text = ""
                Me.txt_producto.Visible = False
                oTransaccion.close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Limpiar_Forma()
        Try
            pds_Dataset.Tables.Remove("sysgold_inventario_cliente")
            pds_Dataset.Tables.Remove("clientes_flexline")
            pds_Dataset.Tables("detalle").Rows.Clear()
        Catch ex As Exception
        End Try
        Me.txt_CodCliente.Text = ""
        Me.txt_cliente.Text = ""
        Me.txt_CodCliente.Enabled = True
        Me.txt_cod_producto.Text = ""
        Me.txt_producto.Text = ""
        Me.txt_cantidad.Text = ""
        Me.txt_CodCliente.Focus()
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged

        newcurrentrow = DataGrid1.CurrentCell.RowNumber
        newcurrentcol = DataGrid1.CurrentCell.ColumnNumber

        Dim ls_codigo As String = String.Empty
        Try
            ls_codigo = DataGrid1(oldcurrentrow, 0).ToString()
        Catch ex As Exception
        End Try

        If okToValidate And Not DatoValido(oldcurrentrow, oldcurrentcol, ls_codigo) Then
            MessageBox.Show("Ingreso Un Valor Invalido")
            okToValidate = False
            If oldcurrentcol = 1 Then 'La Validacion  del codigo del producto la hago en el nombre del producto
                DataGrid1.CurrentCell = New DataGridCell(oldcurrentrow, oldcurrentcol - 1)
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

    End Sub

    Public Function DatoValido(ByVal row As Integer, ByVal col As Integer, ByVal newText As String) As Boolean
        Dim returnValue As Boolean = True
        Dim clgen As New ClasesGenerales.General
        Try
            If col = 1 Then
                returnValue = Buscar_Producto(newText)
                If returnValue Then

                    Me.txt_producto.Text = pds_Dataset.Tables("producto").DefaultView(0)("GLOSA")

                    DataGrid1.Item(row, 1) = Me.txt_producto.Text
                    '                    Me.DataGrid1.Refresh()


                    returnValue = Es_Unico(pds_Dataset.Tables("detalle").TableName, _
                                            pds_Dataset.Tables("detalle"), _
                                            "codigo", DataGrid1(row, 0))


                End If

            End If

            If col = 0 And (row > 0 And row < 4) Then
                clgen.Alinea_Grid(pds_Dataset.Tables("detalle"), Me.DataGrid1, pds_Dataset.Tables("detalle").TableName, -1, 300, 60, False, False, "", True, "")
            End If
        Catch ex As Exception
            returnValue = False

        End Try

        Return returnValue
    End Function

    Private Function Es_Unico(ByVal TableName As String, _
                               ByVal SourceTable As DataTable, _
                               ByVal FieldName As String, _
                               ByVal DatoActual As String) As Boolean


        Dim ReturnValue As Boolean = True
        Dim dt As New DataTable(TableName)
        Dim nveces As Integer = 0

        dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)

        Dim dr As DataRow

        For Each dr In SourceTable.Select("", FieldName)
            If ColumnEqual(DatoActual, dr(FieldName)) Then
                ReturnValue = False
            End If
            'If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
            '    LastValue = dr(FieldName)
            '    dt.Rows.Add(New Object() {LastValue})
            'End If
        Next
        'If Not ds Is Nothing Then ds.Tables.Add(dt)
        'Return dt
        Return ReturnValue
    End Function

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        '
        ' Compares two values to determine if they are equal. Also compares DBNULL.Value.
        '
        ' NOTE: If your DataTable contains object fields, you must extend this
        ' function to handle the fields in a meaningful way if you intend to group on them.
        '
        If A Is DBNull.Value And B Is DBNull.Value Then Return True ' Both are DBNull.Value.
        If A Is DBNull.Value Or B Is DBNull.Value Then Return False ' Only one is DBNull.Value.
        Return A = B                                                ' Value type standard comparison
    End Function

    Private Sub btn_buscar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_producto.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        frm_busqueda.parametros = "producto,glosa,familia"
        frm_busqueda.nombre_vista = "v_um_producto_busqueda"
        'frm_busqueda.procedimiento_almacenado = "pa_sel_um_producto"
        frm_busqueda.lista_campos = "producto, glosa,tipoproducto,familia,subfamilia,tipo,subtipo,precioventa "
        frm_busqueda.ShowDialog(Me)

        Me.txt_cod_producto.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        Buscar_Producto(Me.txt_cod_producto.Text)
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        'frm_busqueda.ps_parametros_fijos = "'" & Me.cmb_empresa.Text.Trim & "',"
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo"
        frm_busqueda.lista_campos = "CtaCte, RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente "
        'frm_busqueda.procedimiento_almacenado = "pa_sel_um_cliente_busqueda"
        frm_busqueda.ShowDialog(Me)

        Me.txt_CodCliente.Text = frm_busqueda.resultado
        frm_busqueda = Nothing
        Buscar_Cliente()
    End Sub

    Private Sub btn_generar_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim clgen As New ClasesGenerales.General

        Generar_Informacion_Inventario()
        copiar_inventario_cliente()
        clgen.Alinea_Grid(pds_Dataset.Tables("detalle"), Me.DataGrid1, pds_Dataset.Tables("detalle").TableName, -1, 300, 60, False, False, "", True, "")

    End Sub
    'Para solo darle enter en el DataGrid de la generacion del formulario
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function 'ProcessCmdKey 


End Class
