Public Class frm_maq_asignacion_ordenes
    Inherits System.Windows.Forms.Form

    Dim Ods As DataSet
    Dim Odt As DataTable
    Dim cargo As Boolean = False

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
    Friend WithEvents dg_ordenes_pendientes As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_inicio_venta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio_produccion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_final_produccion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_estado As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_maq_asignacion_ordenes))
        Me.dg_ordenes_pendientes = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_observaciones = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.dtp_fecha_inicio_produccion = New System.Windows.Forms.DateTimePicker
        Me.btn_actualizar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dtp_fecha_final_produccion = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtp_fecha_inicio_venta = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_estado = New System.Windows.Forms.TextBox
        CType(Me.dg_ordenes_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_ordenes_pendientes
        '
        Me.dg_ordenes_pendientes.CaptionVisible = False
        Me.dg_ordenes_pendientes.DataMember = ""
        Me.dg_ordenes_pendientes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_ordenes_pendientes.Location = New System.Drawing.Point(8, 143)
        Me.dg_ordenes_pendientes.Name = "dg_ordenes_pendientes"
        Me.dg_ordenes_pendientes.ReadOnly = True
        Me.dg_ordenes_pendientes.Size = New System.Drawing.Size(784, 257)
        Me.dg_ordenes_pendientes.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_observaciones)
        Me.GroupBox1.Controls.Add(Me.txt_cantidad)
        Me.GroupBox1.Controls.Add(Me.txt_producto)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_inicio_produccion)
        Me.GroupBox1.Controls.Add(Me.btn_actualizar)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_final_produccion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_inicio_venta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_estado)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 129)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion de Orden"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(360, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Comentario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Producto"
        '
        'txt_observaciones
        '
        Me.txt_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_observaciones.Location = New System.Drawing.Point(440, 24)
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.ReadOnly = True
        Me.txt_observaciones.Size = New System.Drawing.Size(240, 22)
        Me.txt_observaciones.TabIndex = 5
        '
        'txt_cantidad
        '
        Me.txt_cantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad.Location = New System.Drawing.Point(72, 48)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.ReadOnly = True
        Me.txt_cantidad.Size = New System.Drawing.Size(100, 22)
        Me.txt_cantidad.TabIndex = 4
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Location = New System.Drawing.Point(72, 24)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.ReadOnly = True
        Me.txt_producto.Size = New System.Drawing.Size(272, 22)
        Me.txt_producto.TabIndex = 3
        '
        'dtp_fecha_inicio_produccion
        '
        Me.dtp_fecha_inicio_produccion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_produccion.Location = New System.Drawing.Point(161, 72)
        Me.dtp_fecha_inicio_produccion.Name = "dtp_fecha_inicio_produccion"
        Me.dtp_fecha_inicio_produccion.Size = New System.Drawing.Size(88, 22)
        Me.dtp_fecha_inicio_produccion.TabIndex = 1
        '
        'btn_actualizar
        '
        Me.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_actualizar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ForeColor = System.Drawing.Color.White
        Me.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_actualizar.ImageIndex = 0
        Me.btn_actualizar.ImageList = Me.ImageList1
        Me.btn_actualizar.Location = New System.Drawing.Point(696, 16)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(80, 64)
        Me.btn_actualizar.TabIndex = 0
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_actualizar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        '
        'dtp_fecha_final_produccion
        '
        Me.dtp_fecha_final_produccion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_final_produccion.Location = New System.Drawing.Point(161, 96)
        Me.dtp_fecha_final_produccion.Name = "dtp_fecha_final_produccion"
        Me.dtp_fecha_final_produccion.Size = New System.Drawing.Size(88, 22)
        Me.dtp_fecha_final_produccion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Inicio Produccion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha Final Produccion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cantidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(360, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Inicio Venta"
        '
        'dtp_fecha_inicio_venta
        '
        Me.dtp_fecha_inicio_venta.Enabled = False
        Me.dtp_fecha_inicio_venta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_venta.Location = New System.Drawing.Point(440, 48)
        Me.dtp_fecha_inicio_venta.Name = "dtp_fecha_inicio_venta"
        Me.dtp_fecha_inicio_venta.Size = New System.Drawing.Size(88, 22)
        Me.dtp_fecha_inicio_venta.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(360, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Estado"
        '
        'txt_estado
        '
        Me.txt_estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_estado.Location = New System.Drawing.Point(440, 72)
        Me.txt_estado.Name = "txt_estado"
        Me.txt_estado.ReadOnly = True
        Me.txt_estado.Size = New System.Drawing.Size(100, 22)
        Me.txt_estado.TabIndex = 4
        '
        'frm_maq_asignacion_ordenes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 413)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_ordenes_pendientes)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_maq_asignacion_ordenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Maquila - Asignacion de Ordenes .::"
        CType(Me.dg_ordenes_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Rom 6:23  Porque la paga del pecado es muerte, pero la dádiva de Dios es vida eterna en Cristo Jesús Señor nuestro. 
    Private Sub Llenar_Informacion()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try
            Ods = New DataSet
            myOtrans.open()
            ls_sql = "call pa_var_um_maq_orden_produccion_pendientes ('" & gs_empresa & "')"
            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "op_pendientes"
            Ods.Tables.Add(dt.Copy)
            Me.dg_ordenes_pendientes.DataSource = dt
            ClsGen.Alinea_Grid(dt, Me.dg_ordenes_pendientes, dt.TableName, -1, 150, 20, False, True, "", True, "")

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try


        Odt = Ods.Tables("op_pendientes").Copy()
        Dim dr As DataRow
        dr = Odt.NewRow()
        Odt.Rows.Add(dr)

    End Sub

    Private Sub Crear_Bindings()
        Me.txt_producto.DataBindings.Add("text", Odt, "nombre_producto")
        Me.txt_observaciones.DataBindings.Add("text", Odt, "observaciones")
        Me.txt_cantidad.DataBindings.Add("text", Odt, "cantidad")
        Me.txt_estado.DataBindings.Add("text", Odt, "estado")

        Try
            Me.dtp_fecha_inicio_venta.DataBindings.Add("text", Odt, "fecha_inicio_venta")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Me.dtp_fecha_final_produccion.DataBindings.Add("text", Odt, "fecha_final_produccion")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Me.dtp_fecha_inicio_produccion.DataBindings.Add("text", Odt, "fecha_inicio_produccion")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Mostrar_Detalle_Orden()
        Dim nrow As Integer
        Dim dt As DataTable
        nrow = Me.dg_ordenes_pendientes.CurrentRowIndex

        dt = Ods.Tables("op_pendientes").Copy

        dt.DefaultView.RowFilter = "cod_produccion = " & Me.dg_ordenes_pendientes.Item(nrow, 4)
        Odt.Rows.Clear()
        Odt.ImportRow(dt.DefaultView(0).Row)

    End Sub

    Private Sub Actualizar_Informacion()
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Try
            myOtrans.open()
            ls_sql = "call pa_upd_um_maq_orden_produccion (" & Odt.Rows(0).Item("cod_produccion").ToString & ",'" & _
                    Me.dtp_fecha_inicio_produccion.Value.ToString("yyyy-MM-dd") & _
                    "','" & Me.dtp_fecha_final_produccion.Value.ToString("yyyy-MM-dd") & "','" & gs_usuario & "',2)"

            myOtrans.Actualiza(ls_sql)

            If myOtrans.Codigo_error = 0 Then
                MessageBox.Show("Se actualizaron correctamente las fechas de producción.", "Actualización correcta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Se produjo un error al alctualizar la fecha de producción por favor vuelva a intentarlo.", "Error en Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
    End Sub

    Private Sub frm_maq_asignacion_ordenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Informacion()
        Crear_Bindings()
    End Sub

    Private Sub dg_ordenes_pendientes_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_ordenes_pendientes.CurrentCellChanged
        Mostrar_Detalle_Orden()
    End Sub

    Private Function pasa_validaciones() As Boolean


        If dtp_fecha_final_produccion.Value.Date < dtp_fecha_inicio_produccion.Value.Date Then
            MessageBox.Show("La fecha final no puede ser menor a la fecha inical de producción.", "Error en Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtp_fecha_final_produccion.Focus()
            Return False
        End If

        '(c)20151007 Se quito a solicitud de arodas por indicaciones de hbonilla
        'If dtp_fecha_final_produccion.Value.Date > dtp_fecha_inicio_venta.Value.Date Then
        '    MessageBox.Show("La fecha final no puede ser mayor a la fecha de incio de venta.", "Error en Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    dtp_fecha_final_produccion.Focus()
        '    Return False
        'End If

        If dtp_fecha_inicio_produccion.Value.Date > dtp_fecha_final_produccion.Value.Date Then
            MessageBox.Show("La fecha inicio no puede ser mayor a la fecha final de produccion.", "Error en Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtp_fecha_inicio_produccion.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If Not cargo Then Exit Sub
        If Not pasa_validaciones() Then Exit Sub

        Actualizar_Informacion()
    End Sub

    Private Sub frm_maq_asignacion_ordenes_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cargo = True
    End Sub
End Class
