Public Class frm_asociar_ES_documentos
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_liberar As System.Windows.Forms.Button
    Friend WithEvents cmb_tipoDocto As System.Windows.Forms.ComboBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents lbl_vigencia As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_salida_cd As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_asociar_ES_documentos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_tipoDocto = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_liberar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lbl_vigencia = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_salida_cd = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tipo Documento"
        '
        'cmb_tipoDocto
        '
        Me.cmb_tipoDocto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tipoDocto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipoDocto.DropDownWidth = 300
        Me.cmb_tipoDocto.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tipoDocto.Location = New System.Drawing.Point(112, 8)
        Me.cmb_tipoDocto.Name = "cmb_tipoDocto"
        Me.cmb_tipoDocto.Size = New System.Drawing.Size(248, 23)
        Me.cmb_tipoDocto.TabIndex = 6
        Me.cmb_tipoDocto.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Numero"
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(112, 36)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(104, 21)
        Me.txt_numero.TabIndex = 9
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.CaptionText = "Detalle "
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(6, 120)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(736, 336)
        Me.DataGrid1.TabIndex = 10
        Me.DataGrid1.TabStop = False
        '
        'txt_cliente
        '
        Me.txt_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cliente.Location = New System.Drawing.Point(112, 78)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(368, 21)
        Me.txt_cliente.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Glosa"
        '
        'txt_fecha
        '
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(280, 36)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(78, 21)
        Me.txt_fecha.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(232, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
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
        Me.btn_liberar.Location = New System.Drawing.Point(648, 8)
        Me.btn_liberar.Name = "btn_liberar"
        Me.btn_liberar.Size = New System.Drawing.Size(80, 56)
        Me.btn_liberar.TabIndex = 16
        Me.btn_liberar.Text = "&Asociar"
        Me.btn_liberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_liberar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "revert-to-saved-ltr.png")
        '
        'lbl_vigencia
        '
        Me.lbl_vigencia.AutoSize = True
        Me.lbl_vigencia.Location = New System.Drawing.Point(368, 12)
        Me.lbl_vigencia.Name = "lbl_vigencia"
        Me.lbl_vigencia.Size = New System.Drawing.Size(0, 15)
        Me.lbl_vigencia.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkRed
        Me.Label6.Location = New System.Drawing.Point(8, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "No. Salida CD"
        '
        'txt_salida_cd
        '
        Me.txt_salida_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_salida_cd.Location = New System.Drawing.Point(112, 57)
        Me.txt_salida_cd.Name = "txt_salida_cd"
        Me.txt_salida_cd.Size = New System.Drawing.Size(104, 21)
        Me.txt_salida_cd.TabIndex = 20
        '
        'frm_asociar_ES_documentos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(744, 462)
        Me.Controls.Add(Me.txt_salida_cd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl_vigencia)
        Me.Controls.Add(Me.btn_liberar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.txt_numero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_tipoDocto)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_asociar_ES_documentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asociar Entradas/Salidas de Inventarios"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frm_consignaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
        Me.Limpiar_pantalla()
    End Sub

    Private Sub LlenarCombo()

        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet

        oTransaccion = New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_SqlScript = "pa_sel_um_tipodocumento '" & gs_empresa & "','Entrada (i)'"
        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "tipodocto"

        l_Dataset.Tables.Add(ldt_table.Copy)
        l_Dataset.Tables("tipodocto").DefaultView.RowFilter = "tipoDocto like '%ENTRADA%'"

        Me.cmb_tipoDocto.DisplayMember = "tipoDocto"
        Me.cmb_tipoDocto.ValueMember = "tipoDocto"
        Me.cmb_tipoDocto.DataSource = l_Dataset.Tables("tipodocto")

        oTransaccion.close()
        oTransaccion = Nothing
    End Sub

    Private Sub txt_numero_consignacion_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.LostFocus


        If Me.txt_numero.Text.Length > 0 Then
            Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")
            hacer_busqueda()

        End If
    End Sub
    Private Sub Limpiar_pantalla()
        Me.lbl_vigencia.Text = ""
        Me.DataGrid1.DataSource = Nothing
        Me.txt_numero.Text = ""
        Me.txt_cliente.Text = ""
        Me.txt_fecha.Text = ""
        Me.txt_salida_cd.Text = ""
    End Sub

    Private Sub hacer_busqueda()
        Dim otabla As DataTable
        Dim clGen As New ClasesGenerales.General
        oTransaccion = New Transaccional.Conexion("flexline")
        Me.lbl_vigencia.Text = ""

        Try


            oTransaccion.open()

            ls_SqlScript = "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmb_tipoDocto.Text & "','" & Me.txt_numero.Text & "'"
            otabla = oTransaccion.Obtiene(ls_SqlScript)

            If oTransaccion.Codigo_error = 0 Then
                If otabla.Rows(0).Item("vigencia") <> "A" Then
                    otabla.TableName = "detalle"
                    oTransaccion.close()

                    Me.DataGrid1.DataSource = otabla

                    clGen.Alinea_Grid(otabla, Me.DataGrid1, otabla.TableName, 3, 200, 50, False, True, ",Producto,glosa,_unidades,_valores", True, "")
                    Me.txt_fecha.Text = otabla.Rows(0).Item("fecha")

                    Me.txt_cliente.Text = otabla.Rows(0).Item("glosa_docto")
                    Me.txt_salida_cd.Text = otabla.Rows(0).Item("referenciaExterna")
                Else
                    MessageBox.Show("El Documento Esta ANULADO", "Vigencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.lbl_vigencia.Text = "Anulado"
                End If
            End If

        Catch ex As Exception
            If Me.txt_numero.Text.Length > 0 Then
                MessageBox.Show("Problema Con la Busqueda, Verifique El Numero", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Me.txt_fecha.Text = ""
            Me.txt_cliente.Text = ""


        Finally
            Me.Refresh()
        End Try
        oTransaccion = Nothing
    End Sub

    Private Sub btn_liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_liberar.Click
        Dim otabla As New DataTable
        oTransaccion = New Transaccional.Conexion("flexline")


        If Me.lbl_vigencia.Text.Length = 0 Then
            If Me.txt_salida_cd.Text.Length > 0 And Me.txt_numero.Text.Length > 0 Then
                If MessageBox.Show("Esta Seguro de Asociar Este Documento", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'pa_upd_um_documento_vigencia()
                    ls_SqlScript = "pa_upd_um_documento_fecha_vcto '" & gs_empresa & "','" & _
                                    Me.cmb_tipoDocto.Text & "','" & Me.txt_numero.Text & "', NULL,'" & _
                                    gs_usuario & "','" & Me.txt_salida_cd.Text & "'"

                    oTransaccion.open()
                    oTransaccion.Actualiza(ls_SqlScript)
                    If oTransaccion.Codigo_error > 0 Then
                        MessageBox.Show(oTransaccion.descripcion_error)
                    Else
                        MessageBox.Show("Actualizacion Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txt_numero.Text = ""
                    End If
                    oTransaccion.close()
                End If
            End If
        Else
            MessageBox.Show("Este Documento No se Puede Actualizar Por que esta ANULADO", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        oTransaccion = Nothing
        Me.Limpiar_pantalla()
    End Sub


    Private Sub txt_salida_cd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_salida_cd.LostFocus
        Me.txt_salida_cd.Text = Me.txt_salida_cd.Text.PadLeft(10, "0")
    End Sub
End Class
