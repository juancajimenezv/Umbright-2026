
Public Class frm_maq_proceso_produccion
    Inherits System.Windows.Forms.Form

    Dim Ods As DataSet
    Dim Odt As DataTable

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_observaciones As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_barras As System.Windows.Forms.TextBox
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_cantidad_operada As System.Windows.Forms.TextBox
    Friend WithEvents txt_avance As System.Windows.Forms.TextBox
    Friend WithEvents dg_avance_diario As System.Windows.Forms.DataGrid


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_maq_proceso_produccion))
        Me.dg_ordenes_pendientes = New System.Windows.Forms.DataGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_observaciones = New System.Windows.Forms.TextBox()
        Me.txt_producto = New System.Windows.Forms.TextBox()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_codigo_barras = New System.Windows.Forms.TextBox()
        Me.dg_avance_diario = New System.Windows.Forms.DataGrid()
        Me.txt_avance = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_cantidad_operada = New System.Windows.Forms.TextBox()
        CType(Me.dg_ordenes_pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg_avance_diario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_ordenes_pendientes
        '
        Me.dg_ordenes_pendientes.CaptionVisible = False
        Me.dg_ordenes_pendientes.DataMember = ""
        Me.dg_ordenes_pendientes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_ordenes_pendientes.Location = New System.Drawing.Point(8, 110)
        Me.dg_ordenes_pendientes.Name = "dg_ordenes_pendientes"
        Me.dg_ordenes_pendientes.ReadOnly = True
        Me.dg_ordenes_pendientes.Size = New System.Drawing.Size(784, 178)
        Me.dg_ordenes_pendientes.TabIndex = 0
        Me.dg_ordenes_pendientes.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_observaciones)
        Me.GroupBox1.Controls.Add(Me.txt_producto)
        Me.GroupBox1.Controls.Add(Me.txt_cantidad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 53)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion de Orden"
        '
        'txt_observaciones
        '
        Me.txt_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_observaciones.Location = New System.Drawing.Point(336, 22)
        Me.txt_observaciones.Name = "txt_observaciones"
        Me.txt_observaciones.Size = New System.Drawing.Size(288, 22)
        Me.txt_observaciones.TabIndex = 5
        Me.txt_observaciones.TabStop = False
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Location = New System.Drawing.Point(72, 22)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(256, 22)
        Me.txt_producto.TabIndex = 3
        Me.txt_producto.TabStop = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad.Location = New System.Drawing.Point(696, 22)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(80, 22)
        Me.txt_cantidad.TabIndex = 5
        Me.txt_cantidad.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Producto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(632, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Solicitado"
        '
        'txt_codigo_barras
        '
        Me.txt_codigo_barras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_barras.Location = New System.Drawing.Point(660, 16)
        Me.txt_codigo_barras.Name = "txt_codigo_barras"
        Me.txt_codigo_barras.Size = New System.Drawing.Size(112, 22)
        Me.txt_codigo_barras.TabIndex = 3
        Me.txt_codigo_barras.Visible = False
        '
        'dg_avance_diario
        '
        Me.dg_avance_diario.CaptionVisible = False
        Me.dg_avance_diario.DataMember = ""
        Me.dg_avance_diario.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_avance_diario.Location = New System.Drawing.Point(8, 294)
        Me.dg_avance_diario.Name = "dg_avance_diario"
        Me.dg_avance_diario.ReadOnly = True
        Me.dg_avance_diario.Size = New System.Drawing.Size(784, 197)
        Me.dg_avance_diario.TabIndex = 2
        Me.dg_avance_diario.TabStop = False
        '
        'txt_avance
        '
        Me.txt_avance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_avance.Location = New System.Drawing.Point(452, 16)
        Me.txt_avance.Name = "txt_avance"
        Me.txt_avance.ReadOnly = True
        Me.txt_avance.Size = New System.Drawing.Size(80, 22)
        Me.txt_avance.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(348, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Total Maquilado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cantidad"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_cantidad_operada)
        Me.GroupBox2.Controls.Add(Me.txt_codigo_barras)
        Me.GroupBox2.Controls.Add(Me.txt_avance)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(784, 47)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'txt_cantidad_operada
        '
        Me.txt_cantidad_operada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad_operada.Location = New System.Drawing.Point(76, 16)
        Me.txt_cantidad_operada.Name = "txt_cantidad_operada"
        Me.txt_cantidad_operada.Size = New System.Drawing.Size(100, 22)
        Me.txt_cantidad_operada.TabIndex = 7
        Me.txt_cantidad_operada.Text = "1"
        '
        'frm_maq_proceso_produccion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 503)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dg_avance_diario)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dg_ordenes_pendientes)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_maq_proceso_produccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Maquila - Proceso de Produccion .::"
        CType(Me.dg_ordenes_pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg_avance_diario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Rom 6:23  Porque la paga del pecado es muerte, 
    'pero la dádiva de Dios es vida eterna en Cristo Jesús Señor nuestro. 
    Private Sub Ordenes_Pendientes()

        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow

        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General

        Try

            'myOtrans.open()
            ls_sql = "pa_var_um_maq_orden_produccion_pendientes '" & gs_empresa & "'"
            'dt = myOtrans.Obtiene(ls_sql)
            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            dt.TableName = "op_pendientes"

            If Ods.Tables.IndexOf("op_pendientes") >= 0 Then
                Ods.Tables.Remove("op_pendientes")
            End If

            Ods.Tables.Add(dt.Copy)
            Me.dg_ordenes_pendientes.DataSource = dt
            ClsGen.Alinea_Grid(dt, Me.dg_ordenes_pendientes, dt.TableName, -1, 150, 20, False, True, "", True, "")

            Odt = Ods.Tables("op_pendientes").Copy()
            dr = Odt.NewRow()
            Odt.Rows.Add(dr)

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Llenar_Informacion()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Ods = New DataSet
        Ordenes_Pendientes()

        Try

            Otrans.open()
            ls_sql = "pa_var_um_ProdReceta '" & gs_empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "packs"
            If Ods.Tables.Contains("packs") Then
                Ods.Tables.Remove("packs")
            End If
            Ods.Tables.Add(dt.Copy)


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Crear_Bindings()
        Me.txt_producto.DataBindings.Add("text", Odt, "nombre_producto")
        Me.txt_observaciones.DataBindings.Add("text", Odt, "observaciones")
        Me.txt_cantidad.DataBindings.Add("text", Odt, "cantidad")
    End Sub

    Private Sub Mostrar_Detalle_Orden()
        Dim nrow As Integer
        Dim dt As DataTable
        nrow = Me.dg_ordenes_pendientes.CurrentRowIndex

        Try

            dt = Ods.Tables("op_pendientes").Copy

            dt.DefaultView.RowFilter = "cod_produccion = " & Me.dg_ordenes_pendientes.Item(nrow, 4)


            Odt.Rows.Clear()
            Odt.ImportRow(dt.DefaultView(0).Row)
            Me.txt_producto.Text = Odt.Rows(0).Item("nombre_producto")
            Me.txt_observaciones.Text = Odt.Rows(0).Item("observaciones")
            Me.txt_cantidad.Text = Odt.Rows(0).Item("cantidad")

            Ods.Tables("packs").DefaultView.RowFilter = "Producto = '" & Odt.Rows(0).Item("cod_flex") & "'"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Actualizar_Avance()
        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try


            ls_sql = "pa_ins_um_maq_orden_produccion_avance " & Odt.Rows(0).Item("cod_produccion") & "," &
                    Me.txt_cantidad_operada.Text & ",'" & gs_usuario & "'"

            ClsGen.insertQuery("Corporativo", ls_sql)


            ls_sql = "pa_upd_um_maq_orden_produccion_estado " & Odt.Rows(0).Item("cod_produccion") & ",3"
            ClsGen.insertQuery("Corporativo", ls_sql)


        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Cerrar_Orden_Produccion()
        Dim ls_sql As String

        Dim ClsGen As New ClasesGenerales.General

        Try


            ls_sql = "pa_upd_um_maq_orden_produccion_estado " & Odt.Rows(0).Item("cod_produccion") & ",4"
            ClsGen.insertQuery("Corporativo", ls_sql)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
            Ordenes_Pendientes()
        End Try

    End Sub

    Private Function Verificar_Informacion()
        Dim ls_codigo_barra As String = Ods.Tables("packs").DefaultView(0).Item("codbarra").ToString
        If ls_codigo_barra = Me.txt_codigo_barras.Text Then
            Return True
        Else
            MessageBox.Show("Este Codigo No Corresponde al Producto de La Orden", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
    End Function

    Private Sub Mostrar_Avance()
        Dim ls_sql As String
        Dim dt As DataTable
        Dim LlenarInformacion As Boolean = False
        Dim clsGen As New ClasesGenerales.General

        Try


            ls_sql = "pa_sel_um_maq_orden_produccion_avance " & Odt.Rows(0).Item("cod_produccion")


            dt = clsGen.selectQuery("Corporativo", ls_sql)
            If dt.Rows.Count > 0 Then
                Me.txt_avance.Text = dt.Rows(0).Item("Cantidad").ToString

                If Int32.Parse(Me.txt_avance.Text) >= Int32.Parse(Me.txt_cantidad.Text) Then
                    Cerrar_Orden_Produccion()
                    LlenarInformacion = True
                End If
            End If

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
        If LlenarInformacion Then
            Llenar_Informacion()
            Mostrar_Detalle_Orden()
        End If
    End Sub

    Private Sub Mostrar_Avance_Diario()
        Dim ls_sql As String
        Dim dt As DataTable
        'Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General


        Try
            'myOtrans.open()

            ls_sql = "pa_sel_um_maq_orden_produccion_avance_diario"

            dt = ClsGen.selectQuery("Corporativo", ls_sql)
            Me.dg_avance_diario.DataSource = dt
            ClsGen.Alinea_Grid(dt, Me.dg_avance_diario, dt.TableName, -1, 250, 0, False, True, "", True, "")

        Catch ex As Exception
        Finally
            'myOtrans.close()
            'myOtrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub frm_maq_asignacion_ordenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Informacion()
        Mostrar_Detalle_Orden()
        Mostrar_Avance_Diario()
    End Sub

    Private Sub dg_ordenes_pendientes_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_ordenes_pendientes.CurrentCellChanged
        txt_avance.Text = String.Empty
        txt_cantidad.Text = String.Empty
        txt_cantidad_operada.Text = String.Empty

        Mostrar_Detalle_Orden()
        Mostrar_Avance()
    End Sub

    Private Sub txt_avance_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_avance.GotFocus
        Me.txt_codigo_barras.SelectAll()
        Me.txt_codigo_barras.Focus()
    End Sub

    Private Sub txt_cantidad_operada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_operada.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txt_cantidad_operada.Text) <= 0 Then
                MessageBox.Show("la cantidad no puede ser negativa ni igual a cero (0).", "Error en cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_cantidad_operada.Focus()
                Exit Sub
            End If

            If Val(txt_cantidad_operada.Text) + Val(txt_avance.Text) > Val(txt_cantidad.Text) Then
                MessageBox.Show("La suma de la Cantidad más el Total Maquilado no puede exeder lo Solicitado", "Error en cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_cantidad_operada.Focus()
                Exit Sub
            End If


            Actualizar_Avance()
            Mostrar_Avance()
            Mostrar_Avance_Diario()

            txt_cantidad_operada.Text = "1"
        End If
    End Sub

    Private Sub txt_cantidad_operada_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_operada.TextChanged

    End Sub
End Class
