Imports System.Text

Public Class frm_ejecuta_sp
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
    Friend WithEvents btn_ejecutar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_proceso As System.Windows.Forms.ComboBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ejecuta_sp))
        Me.btn_ejecutar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.cmb_proceso = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btn_ejecutar
        '
        Me.btn_ejecutar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_ejecutar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ejecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ejecutar.ForeColor = System.Drawing.Color.White
        Me.btn_ejecutar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ejecutar.ImageIndex = 0
        Me.btn_ejecutar.ImageList = Me.ImageList1
        Me.btn_ejecutar.Location = New System.Drawing.Point(320, 16)
        Me.btn_ejecutar.Name = "btn_ejecutar"
        Me.btn_ejecutar.Size = New System.Drawing.Size(80, 64)
        Me.btn_ejecutar.TabIndex = 0
        Me.btn_ejecutar.Text = "&Ejecutar"
        Me.btn_ejecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ejecutar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "running_process.png")
        Me.ImageList1.Images.SetKeyName(1, "clear.png")
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.ImageIndex = 1
        Me.btn_limpiar.ImageList = Me.ImageList1
        Me.btn_limpiar.Location = New System.Drawing.Point(320, 96)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(80, 64)
        Me.btn_limpiar.TabIndex = 1
        Me.btn_limpiar.Text = "&Limpiar"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'cmb_proceso
        '
        Me.cmb_proceso.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_proceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_proceso.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_proceso.Location = New System.Drawing.Point(104, 16)
        Me.cmb_proceso.Name = "cmb_proceso"
        Me.cmb_proceso.Size = New System.Drawing.Size(200, 24)
        Me.cmb_proceso.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nombre Proceso"
        '
        'frm_ejecuta_sp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(416, 430)
        Me.Controls.Add(Me.cmb_proceso)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.btn_ejecutar)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ejecuta_sp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Ejecutar Proceso .::"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim oPanel As New Panel
    Dim ds_parametros As New DataSet
    Dim nombre_sp As String
    Public administrador As Boolean = False

    Private Sub frm_ejecuta_sp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oPanel.Location = New Point(20, 50)
        oPanel.Size = New Size(283, 370)
        oPanel.BorderStyle = BorderStyle.Fixed3D
        oPanel.AutoScroll = True
        oPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Controls.Add(oPanel)

        generar_datos()
    End Sub

    Private Sub generar_datos()
        Dim ldt_table As New DataTable
        Dim ls_SqlScript As String
        Dim otransaccion As Transaccional.Conexion

        otransaccion = New Transaccional.Conexion("flexline")
        otransaccion.open()

        If administrador Then
            ls_SqlScript = "pa_sel_um_sg_usuario_sp NULL,'" & gs_empresa & "'"
        Else
            ls_SqlScript = "pa_sel_um_sg_usuario_sp '" & gs_usuario & "','" & gs_empresa & "'"
        End If

        ldt_table = otransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "parametros"
        ds_parametros.Tables.Add(ldt_table.Copy)

        Me.cmb_proceso.DisplayMember = "descripcion_sp"
        Me.cmb_proceso.ValueMember = "nombre_sp"
        Me.cmb_proceso.DataSource = ldt_table

        otransaccion.close()
        otransaccion = Nothing
    End Sub

    Private Function muestra_parametros(ByVal ds_data As DataSet) As Boolean
        Try
            Dim control As New Object
            Dim posiciony As Integer
            Dim aumentary As Integer = 10

            If ds_data.Tables("datos").Rows.Count <= 0 Then
                Return False
            End If

            With ds_data.Tables("datos")

                For ii As Integer = 0 To .Rows.Count - 1
                    If .Rows(ii)("PROCEDURE_OWNER").ToString.ToLower = "flexline" And .Rows(ii)("COLUMN_NAME").ToString.ToLower <> "@return_value" Then
                        Select Case .Rows(ii)("TYPE_NAME").ToString.ToUpper
                            Case "INT", "BIGINT", "SMALLINT", "TINYINT"
                                control = New TextBox
                                control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                            Case "DECIMAL", "NUMERIC"
                                control = New TextBox
                                control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                            Case "DATETIME", "SMALLDATETIME"
                                control = New DateTimePicker
                                control.Value = Now
                                control.Format = DateTimePickerFormat.Short
                                control.Size = New System.Drawing.Size(96, 20)
                            Case "CHAR", "VARCHAR", "TEXT"
                                If .Rows(ii)("COLUMN_NAME").ToString.ToLower.IndexOf("fecha") < 0 Then
                                    If .Rows(ii)("COLUMN_NAME").ToString.ToLower.IndexOf("empresa") < 0 Then
                                        control = New TextBox
                                        control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                                    Else
                                        control = New TextBox
                                        control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                                        control.Enabled = False
                                        control.Visible = False
                                        control.Text = gs_empresa
                                        aumentary -= 40
                                    End If
                                Else
                                    control = New DateTimePicker
                                    control.Value = Now
                                    control.Format = DateTimePickerFormat.Short
                                    control.Size = New System.Drawing.Size(100, 20)
                                End If
                            Case "NCHAR", "NVARCHAR", "NTEXT"
                                control = New TextBox
                                control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                            Case Else
                                control = New TextBox
                                control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                        End Select

                        control.Tag = .Rows(ii)("TYPE_NAME").ToString.ToUpper
                        control.Name = "parametro_" & .Rows(ii)("COLUMN_NAME").ToString.Replace("@", "")
                        control.Location = New System.Drawing.Point(150, (25 * posiciony) + aumentary)
                        control.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        oPanel.Controls.Add(control)
                        control = Nothing

                        Dim label As New Label
                        label.Tag = "label"
                        label.Name = "label_" & .Rows(ii)("COLUMN_NAME").ToString.Replace("@", "")

                        If .Rows(ii)("COLUMN_NAME").ToString.ToLower.IndexOf("empresa") < 0 Then
                            label.Text = .Rows(ii)("COLUMN_NAME").ToString.Replace("@", "").Replace("_", " ")
                        Else
                            label.Text = ""
                        End If

                        label.Location = New System.Drawing.Point(20, (25 * posiciony) + aumentary)
                        label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        label.AutoSize = True

                        oPanel.Controls.Add(label)
                        label = Nothing

                        aumentary += 25
                    End If
                Next
            End With

            Return True
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error al mostrar los parámetros:  " & ex.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Private Sub obtener_datos()
        Try
            Dim ldt_table As New DataTable
            Dim ls_SqlScript As String
            Dim otransaccion As Transaccional.Conexion

            If ds_parametros.Tables.Contains("datos") Then ds_parametros.Tables.Remove("datos")

            otransaccion = New Transaccional.Conexion("flexline")
            otransaccion.open()

            ls_SqlScript = "sp_sproc_columns " & nombre_sp
            ldt_table = otransaccion.Obtiene(ls_SqlScript)
            ldt_table.TableName = "datos"
            ds_parametros.Tables.Add(ldt_table.Copy)

            otransaccion.close()
            otransaccion = Nothing
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        cmb_proceso.Text = String.Empty
        cmb_proceso.SelectedIndex = -1
        oPanel.Controls.Clear()
    End Sub

    Private Function parametros() As String
        Dim sb_parametros As New StringBuilder
        Try
            For ii As Integer = 0 To oPanel.Controls.Count - 1
                Select Case oPanel.Controls(ii).Tag.ToString.ToUpper
                    Case "INT", "BIGINT", "SMALLINT", "TINYINT"
                        If ii > 0 Then sb_parametros.Append(", ") Else sb_parametros.Append("")
                        sb_parametros.Append(oPanel.Controls(ii).Text)
                    Case "DECIMAL", "NUMERIC"
                        If ii > 0 Then sb_parametros.Append(", ") Else sb_parametros.Append("")
                        sb_parametros.Append(oPanel.Controls(ii).Text)
                    Case "DATETIME", "SMALLDATETIME"
                        If ii > 0 Then sb_parametros.Append(", ") Else sb_parametros.Append("")
                        sb_parametros.Append("'").Append(oPanel.Controls(ii).Text).Append("'")
                    Case "CHAR", "VARCHAR", "TEXT"
                        If ii > 0 Then sb_parametros.Append(", ") Else sb_parametros.Append("")
                        sb_parametros.Append("'").Append(oPanel.Controls(ii).Text).Append("'")
                    Case "NCHAR", "NVARCHAR", "NTEXT"
                        If ii > 0 Then sb_parametros.Append(", ") Else sb_parametros.Append("")
                        sb_parametros.Append("'").Append(oPanel.Controls(ii).Text).Append("'")
                    Case "LABEL"
                        sb_parametros.Append("")
                    Case Else
                        If ii > 0 Then sb_parametros.Append(", ") Else sb_parametros.Append("")
                        sb_parametros.Append("'").Append(oPanel.Controls(ii).Text).Append("'")
                End Select
            Next
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error!!", MessageBoxButtons.OK)
        End Try

        Return sb_parametros.ToString
    End Function

    Private Sub btn_ejecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ejecutar.Click
        If MessageBox.Show("¿Está seguro de ejecutar el proceso?", "Ejecución de Proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Dim ls_SqlScript As String
            Dim ldt_table As New DataTable
            Dim otransaccion As Transaccional.Conexion

            otransaccion = New Transaccional.Conexion("flexline")
            otransaccion.open()

            ls_SqlScript = nombre_sp & " " & parametros()
            otransaccion.Actualiza(ls_SqlScript)

            otransaccion.close()
            otransaccion = Nothing

            MessageBox.Show("Se ejecuto el proceso correctamente.", "Ejecución Completa", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error al ejecutar el proceso: " & ex.Message, "Error!!!", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub cmb_proceso_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_proceso.SelectionChangeCommitted
        Dim mRow() As DataRow = ds_parametros.Tables("parametros").Select("descripcion_sp = '" & cmb_proceso.Text & "' ")
        oPanel.Controls.Clear()

        nombre_sp = mRow(0)("nombre_sp")
        obtener_datos()

        If Not muestra_parametros(ds_parametros) Then
            oPanel = Nothing
        End If
    End Sub
End Class