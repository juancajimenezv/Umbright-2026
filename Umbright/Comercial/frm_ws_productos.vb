
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ws_productos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtp_mes = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_año = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_producto = New System.Windows.Forms.TextBox()
        Me.btn_buscar_producto = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbClub = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.btn_guardar_orden_produccion = New System.Windows.Forms.Button()
        Me.btn_nuevo_orden_produccion = New System.Windows.Forms.Button()
        Me.dgv_ws_productos = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_ws_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp_mes
        '
        Me.dtp_mes.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_mes.CustomFormat = "MMMM"
        Me.dtp_mes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_mes.Location = New System.Drawing.Point(69, 50)
        Me.dtp_mes.Name = "dtp_mes"
        Me.dtp_mes.ShowUpDown = True
        Me.dtp_mes.Size = New System.Drawing.Size(91, 20)
        Me.dtp_mes.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Año"
        '
        'dtp_año
        '
        Me.dtp_año.CustomFormat = "yyyy"
        Me.dtp_año.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_año.Location = New System.Drawing.Point(69, 75)
        Me.dtp_año.Name = "dtp_año"
        Me.dtp_año.ShowUpDown = True
        Me.dtp_año.Size = New System.Drawing.Size(91, 20)
        Me.dtp_año.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Producto"
        '
        'txt_producto
        '
        Me.txt_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_producto.Location = New System.Drawing.Point(69, 108)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(76, 20)
        Me.txt_producto.TabIndex = 5
        '
        'btn_buscar_producto
        '
        Me.btn_buscar_producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_buscar_producto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar_producto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_producto.ForeColor = System.Drawing.Color.White
        Me.btn_buscar_producto.Location = New System.Drawing.Point(151, 105)
        Me.btn_buscar_producto.Name = "btn_buscar_producto"
        Me.btn_buscar_producto.Size = New System.Drawing.Size(26, 22)
        Me.btn_buscar_producto.TabIndex = 6
        Me.btn_buscar_producto.Text = "..."
        Me.btn_buscar_producto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar_producto.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbClub)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_buscar_producto)
        Me.GroupBox1.Controls.Add(Me.dtp_mes)
        Me.GroupBox1.Controls.Add(Me.txtGlosa)
        Me.GroupBox1.Controls.Add(Me.txt_producto)
        Me.GroupBox1.Controls.Add(Me.dtp_año)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(373, 171)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'cmbClub
        '
        Me.cmbClub.FormattingEnabled = True
        Me.cmbClub.Location = New System.Drawing.Point(69, 20)
        Me.cmbClub.Name = "cmbClub"
        Me.cmbClub.Size = New System.Drawing.Size(121, 21)
        Me.cmbClub.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Club"
        '
        'txtGlosa
        '
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.Location = New System.Drawing.Point(183, 108)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(187, 20)
        Me.txtGlosa.TabIndex = 5
        '
        'btn_guardar_orden_produccion
        '
        Me.btn_guardar_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_guardar_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_orden_produccion.ImageIndex = 0
        Me.btn_guardar_orden_produccion.Location = New System.Drawing.Point(17, 77)
        Me.btn_guardar_orden_produccion.Name = "btn_guardar_orden_produccion"
        Me.btn_guardar_orden_produccion.Size = New System.Drawing.Size(92, 56)
        Me.btn_guardar_orden_produccion.TabIndex = 13
        Me.btn_guardar_orden_produccion.Text = "Guardar"
        Me.btn_guardar_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_orden_produccion.UseVisualStyleBackColor = False
        '
        'btn_nuevo_orden_produccion
        '
        Me.btn_nuevo_orden_produccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo_orden_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo_orden_produccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_orden_produccion.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo_orden_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo_orden_produccion.ImageIndex = 3
        Me.btn_nuevo_orden_produccion.Location = New System.Drawing.Point(17, 11)
        Me.btn_nuevo_orden_produccion.Name = "btn_nuevo_orden_produccion"
        Me.btn_nuevo_orden_produccion.Size = New System.Drawing.Size(92, 60)
        Me.btn_nuevo_orden_produccion.TabIndex = 14
        Me.btn_nuevo_orden_produccion.Text = "Nuevo"
        Me.btn_nuevo_orden_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo_orden_produccion.UseVisualStyleBackColor = False
        '
        'dgv_ws_productos
        '
        Me.dgv_ws_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ws_productos.Location = New System.Drawing.Point(12, 215)
        Me.dgv_ws_productos.Name = "dgv_ws_productos"
        Me.dgv_ws_productos.RowHeadersWidth = 20
        Me.dgv_ws_productos.Size = New System.Drawing.Size(618, 150)
        Me.dgv_ws_productos.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_nuevo_orden_produccion)
        Me.GroupBox2.Controls.Add(Me.btn_guardar_orden_produccion)
        Me.GroupBox2.Location = New System.Drawing.Point(391, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(124, 160)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'frm_ws_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(634, 377)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgv_ws_productos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_ws_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos Mes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_ws_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtp_mes As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_año As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_producto As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo_orden_produccion As System.Windows.Forms.Button
    Friend WithEvents dgv_ws_productos As System.Windows.Forms.DataGridView
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents cmbClub As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

    Private Sub btn_nuevo_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_orden_produccion.Click
        limpiar_datos()
        actualizar()

    End Sub


    Private Sub llenarCombos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            Otrans.open()


            lsSQL = "scm.flexline.pa_sel_um_ws_club"
            dt = Otrans.Obtiene(lsSQL)
            Me.cmbClub.DataSource = dt
            Me.cmbClub.ValueMember = "cod_club"
            Me.cmbClub.DisplayMember = "descripcion"

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub btn_guardar_orden_produccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_orden_produccion.Click
        If Me.dtp_mes.Text <> "" And Me.dtp_año.Text <> "" And Me.txt_producto.Text <> "" Then
            If MessageBox.Show("Esta seguro de Guardar este producto ", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardar_producto_ws()
                limpiar_datos()
                actualizar()


            End If
        Else
            MessageBox.Show("Debe ingresar Mes, Año y Producto", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub guardar_producto_ws()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            otrans.open()
            ls_sql = "pa_sel_um_ws_producto_mes " & dtp_mes.Value.Month & ",'" & dtp_año.Text & "'," & Me.cmbClub.SelectedValue
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count = 0 Then
                ls_sql = "pa_ins_um_ws_producto_mes '" & gs_empresa & "','" & dtp_mes.Value.Month & "','" & dtp_año.Text & "','" & txt_producto.Text & "','" & gs_usuario & "'," & Me.cmbClub.SelectedValue
                otrans.Ingresa(ls_sql)

            Else
                MessageBox.Show("ERROR: El producto con el mes y año indicado ya existe")

            End If



        Catch ex As Exception
            MessageBox.Show("ERROR:  ", ex.Message)

        Finally
            otrans.close()

        End Try

    End Sub

    Private Sub buscarproducto(ByVal codigo_prod As String)
        Dim rTrans As New Transaccional.Conexion("flexline")
        Dim dt_flex As New DataTable
        Dim dt_flex_ As New DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        rTrans.open()

        Try
            lsSQL = "pa_sel_um_producto '" & gs_empresa & "', '" & codigo_prod & "'"
            dt_flex = rTrans.Obtiene(lsSQL)

            If dt_flex.Rows.Count = 1 Then
  

                txtGlosa.Text = dt_flex.Rows(0)("glosa")

               






            Else
                MessageBox.Show("No se encontró el producto solicitado vuelva a intentarlo.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message)
        Finally
            rTrans.close()
            rTrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub frm_ws_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        limpiar_datos()
        actualizar()

    End Sub

    Private Sub btn_buscar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_producto.Click
        'Dim oform As New frm_busqueda_producto
        'oform.ShowDialog()

        'txt_producto.Text = oform.producto

    End Sub

    Private Sub limpiar_datos()
        txt_producto.Text = ""

    End Sub

    Private Sub actualizar()
        Dim trans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General

        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            trans.open()
            ls_sql = "pa_sel_um_ws_producto_mes"
            dt = trans.Obtiene(ls_sql)
            dt.TableName = "ws_productos_mes"

            dgv_ws_productos.DataSource = dt
            ClsGen.Alinear_GridView(dt, dgv_ws_productos, "", "", "", "", False, True, 255, 0)


        Catch ex As Exception

        Finally
            trans.close()

        End Try

    End Sub

    Private Sub eliminar()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ls_sql, producto, mes, año As String

        producto = Trim(dgv_ws_productos.Item("producto", dgv_ws_productos.CurrentRow.Index).Value.ToString)
        mes = Trim(dgv_ws_productos.Item("mes", dgv_ws_productos.CurrentRow.Index).Value.ToString)
        año = Trim(dgv_ws_productos.Item("año", dgv_ws_productos.CurrentRow.Index).Value.ToString)


        Try
            otrans.open()
            ls_sql = "pa_del_um_ws_producto_mes '" & gs_empresa & "','" & mes & "','" & año & "','" & producto & "'"
            otrans.Elimina(ls_sql)

            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Producto eliminado correctamente")
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR: ", ex.Message)

        Finally
            otrans.close()

        End Try

    End Sub

    Private Sub dgv_ws_productos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_ws_productos.KeyDown
        If e.KeyCode = Keys.Delete Then

            If MessageBox.Show("Esta seguro de Eliminar el producto " & txt_producto.Text & "?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                eliminar()
                actualizar()

            End If

        End If

    End Sub

    Private Sub dgv_ws_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_ws_productos.CellContentClick

    End Sub

    Private Sub txt_producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_producto.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarproducto(Me.txt_producto.Text)
        End If
    End Sub

    Private Sub txt_producto_TextChanged(sender As Object, e As EventArgs) Handles txt_producto.TextChanged

    End Sub
End Class
