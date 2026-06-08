Public Class frm_int_asociar_solicitud
    Inherits System.Windows.Forms.Form
    Public pdt As DataTable
    Friend WithEvents dg_pedido As System.Windows.Forms.DataGridView
    Friend WithEvents dg_producto_dua As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotalDI As System.Windows.Forms.Label
    Dim ds_asociacion As DataSet

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
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_iva As System.Windows.Forms.Label
    Friend WithEvents lbl_daiv As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_int_asociar_solicitud))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btn_Guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_iva = New System.Windows.Forms.Label
        Me.lbl_daiv = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_total = New System.Windows.Forms.Label
        Me.dg_pedido = New System.Windows.Forms.DataGridView
        Me.dg_producto_dua = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTotalDI = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        CType(Me.dg_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_producto_dua, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Guardar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.ForeColor = System.Drawing.Color.White
        Me.btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Guardar.ImageIndex = 0
        Me.btn_Guardar.ImageList = Me.ImageList1
        Me.btn_Guardar.Location = New System.Drawing.Point(47, 22)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(72, 64)
        Me.btn_Guardar.TabIndex = 2
        Me.btn_Guardar.Text = "Guardar"
        Me.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Floppy-64.png")
        '
        'txt_nombre
        '
        Me.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre.Location = New System.Drawing.Point(94, 55)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(256, 22)
        Me.txt_nombre.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nombre"
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Enabled = False
        Me.txt_numero.ForeColor = System.Drawing.Color.Maroon
        Me.txt_numero.Location = New System.Drawing.Point(94, 26)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(64, 22)
        Me.txt_numero.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Numero"
        '
        'lbl_iva
        '
        Me.lbl_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_iva.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_iva.Location = New System.Drawing.Point(512, 42)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_iva.Size = New System.Drawing.Size(80, 16)
        Me.lbl_iva.TabIndex = 11
        Me.lbl_iva.Text = "0"
        '
        'lbl_daiv
        '
        Me.lbl_daiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_daiv.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_daiv.Location = New System.Drawing.Point(504, 26)
        Me.lbl_daiv.Name = "lbl_daiv"
        Me.lbl_daiv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_daiv.Size = New System.Drawing.Size(88, 16)
        Me.lbl_daiv.TabIndex = 8
        Me.lbl_daiv.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(432, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total IVA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(432, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Total Dai"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(432, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Total"
        '
        'lbl_total
        '
        Me.lbl_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_total.Location = New System.Drawing.Point(512, 61)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_total.Size = New System.Drawing.Size(80, 16)
        Me.lbl_total.TabIndex = 11
        Me.lbl_total.Text = "0"
        '
        'dg_pedido
        '
        Me.dg_pedido.AllowUserToAddRows = False
        Me.dg_pedido.AllowUserToDeleteRows = False
        Me.dg_pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_pedido.DefaultCellStyle = DataGridViewCellStyle1
        Me.dg_pedido.Location = New System.Drawing.Point(6, 13)
        Me.dg_pedido.Name = "dg_pedido"
        Me.dg_pedido.ReadOnly = True
        Me.dg_pedido.RowHeadersWidth = 25
        Me.dg_pedido.Size = New System.Drawing.Size(1068, 226)
        Me.dg_pedido.TabIndex = 13
        '
        'dg_producto_dua
        '
        Me.dg_producto_dua.AllowUserToAddRows = False
        Me.dg_producto_dua.AllowUserToDeleteRows = False
        Me.dg_producto_dua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_producto_dua.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_producto_dua.Location = New System.Drawing.Point(6, 245)
        Me.dg_producto_dua.Name = "dg_producto_dua"
        Me.dg_producto_dua.RowHeadersWidth = 25
        Me.dg_producto_dua.Size = New System.Drawing.Size(1068, 199)
        Me.dg_producto_dua.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_numero)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_nombre)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbl_iva)
        Me.GroupBox1.Controls.Add(Me.lbl_total)
        Me.GroupBox1.Controls.Add(Me.lblTotalDI)
        Me.GroupBox1.Controls.Add(Me.lbl_daiv)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 100)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(654, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Total DI's"
        '
        'lblTotalDI
        '
        Me.lblTotalDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDI.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalDI.Location = New System.Drawing.Point(726, 29)
        Me.lblTotalDI.Name = "lblTotalDI"
        Me.lblTotalDI.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTotalDI.Size = New System.Drawing.Size(88, 16)
        Me.lblTotalDI.TabIndex = 8
        Me.lblTotalDI.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_Guardar)
        Me.GroupBox2.Location = New System.Drawing.Point(931, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 100)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dg_producto_dua)
        Me.GroupBox3.Controls.Add(Me.dg_pedido)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 122)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1083, 452)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        '
        'frm_int_asociar_solicitud
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1101, 578)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_int_asociar_solicitud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. SCM Internaciones | Asociar Solicitud con DUA .::"
        CType(Me.dg_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_producto_dua, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Crear_Estructura()
        ds_asociacion = New DataSet

        Dim dt As New DataTable("detalle_dua")

        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("dua", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("cantidad_trasladar", GetType(Integer)))
        dt.Columns.Add(New DataColumn("asociar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("saldo_cajas", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo_unidades", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha_vencimiento_dua", GetType(Date)))
        dt.Columns.Add(New DataColumn("fecha_vencimiento_producto", GetType(Date)))
        dt.Columns.Add(New DataColumn("observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("fob", GetType(Double)))
        dt.Columns.Add(New DataColumn("dai", GetType(Double)))
        dt.Columns.Add(New DataColumn("iva", GetType(Double)))
        dt.Columns.Add(New DataColumn("fobunitario", GetType(Double)))
        dt.Columns.Add(New DataColumn("daiunitario", GetType(Double)))
        'dt.Columns.Add(New DataColumn("foblinea", GetType(Double)))
        ' dt.Columns.Add(New DataColumn("dailinea", GetType(Double)))
        'dt.Columns.Add(New DataColumn("ivalinea", GetType(Double)))

        ds_asociacion.Tables.Add(dt.Copy)

    End Sub

    Private Sub Obtener_Existencia_DA()
        Dim drv As DataRowView
        Dim dr, dr_aux As DataRow
        Dim otrans As New Transaccional.Conexion("scm")
        Dim dt As DataTable
        Dim lsSQL As String


        Try
            otrans.open()
            For Each drv In pdt.DefaultView

                drv.Item("fob") = 0

                lsSQL = "pa_sel_um_vs_detalle_dua '" & gs_empresa & "','" & drv.Item("producto") & "',1"

                dt = otrans.Obtiene(lsSQL)

                For Each dr_aux In dt.Rows

                    dr = ds_asociacion.Tables("detalle_dua").NewRow

                    dr.Item("producto") = drv.Item("producto")
                    dr.Item("dua") = dr_aux.Item("no_dua")

                    'If dt.Rows.Count = 1 Then
                    '    dr.Item("asociar") = True
                    'Else
                    dr.Item("asociar") = False
                    'End If

                    dr.Item("saldo_cajas") = dr_aux.Item("saldo_bultos") '/ drv.Item("uxc")
                    dr.Item("saldo_unidades") = dr_aux.Item("saldo_unidades")
                    dr.Item("observaciones") = dr_aux.Item("observaciones")
                    dr.Item("fecha_vencimiento_dua") = dr_aux.Item("fecha_vence_dua")
                    dr.Item("fecha_vencimiento_producto") = dr_aux.Item("fecha_vence_prod")
                    dr.Item("fob") = 0
                    dr.Item("dai") = 0
                    dr.Item("iva") = 0

                    ds_asociacion.Tables("detalle_dua").Rows.Add(dr)
                Next

                ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & drv.Item("producto") & "'"
                ds_asociacion.Tables("detalle_dua").DefaultView.Sort = "fecha_vencimiento_producto, fecha_vencimiento_dua"

                'Dim itraslado As Integer = drv.Item("pedido")
                'drv.Item("dua") = String.Empty
                'For Each drv2 As DataRowView In ds_asociacion.Tables("detalle_dua").DefaultView
                '    If drv2.Item("saldo_cajas") >= itraslado Then
                '        drv2.Item("cantidad_trasladar") = itraslado
                '    Else
                '        drv2.Item("cantidad_trasladar") = drv2.Item("saldo_cajas")
                '    End If
                '    drv.Item("dua") = drv.Item("dua").ToString.Trim & IIf(drv.Item("dua").ToString.Length > 0, ",", "") & drv2.Item("dua").ToString.Trim
                '    itraslado -= drv2.Item("saldo_cajas")
                '    drv2.Item("asociar") = True
                '    If itraslado <= 0 Then
                '        Exit For
                '    End If
                'Next

            Next

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        'hacerResumen()
        'obtenerdai()
        LlenarFOB()
        
        Me.dg_producto_dua.DataSource = ds_asociacion.Tables("detalle_dua")


        Colorear_Detalle()
        Mostrar_Productos()
    End Sub

    Private Sub LlenarFOB()
        Dim otransFlex As New Transaccional.Conexion("FlexLine")
        Dim lfob, ldaiq, liva As Double
        Dim lsSQL As String
        Dim dt As DataTable


        Try
            otransFlex.open()

            ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = ""

            For Each drv2 As DataRowView In ds_asociacion.Tables("detalle_dua").DefaultView

                'Obtener Productos de la Dua
                lsSQL = "pa_sel_um_documentod '" & gs_empresa & "','INGRESO DE MERCADERIA DEPOSITO ADUANERO','" & _
                            drv2.Item("dua").ToString.Replace("-", "").Trim.Replace("FPA", "").Trim.Replace(" ", "").Trim.PadLeft(10, "0") & "'"
                dt = otransFlex.Obtiene(lsSQL)

                dt.DefaultView.RowFilter = "PRODUCTO  = '" & drv2.Item("producto") & "'"

                If dt.DefaultView.Count = 1 Then
                    With dt.DefaultView(0)

                        'Fob Total
                        lfob = (.Item("SubTotalIngreso") / .Item("Cantidad")) * .Item("factoralt")
                        drv2.Item("fobunitario") = lfob '* drv2.Item("cantidad_trasladar")
                        ldaiq = 0

                        'Try
                        '    drv2.Item("fob") = lfob * drv2.Item("cantidad_trasladar")
                        ldaiq = (lfob * (.Item("dai") / 100)) '* drv2.Item("cantidad_trasladar")
                        'Catch ex As Exception
                        'End Try
                        drv2.Item("daiunitario") = ldaiq
                        drv2.Item("fob") = 0
                        drv2.Item("dai") = 0
                        drv2.Item("iva") = 0

                        'Try
                        '    liva = (((lfob * drv2.Item("cantidad_trasladar"))) + (lfob * (.Item("dai") / 100))) * 0.12
                        'Catch ex As Exception
                        ' liva = 0
                        'End Try
                        'drv2.Item("ivalinea") = liva

                    End With
                End If

            Next



        Catch ex As Exception
        Finally
            otransFlex.close()
            otransFlex = Nothing
        End Try


      


    End Sub

    Private Sub hacerResumen()
        ' Dim otransFlex As New Transaccional.Conexion("FlexLine")
        Dim lfob, ldaiq, liva As Double
        Dim lsSQL As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General

     
        lfob = 0
        ldaiq = 0
        liva = 0
        dt = ds_asociacion.Tables("detalle_dua").Copy
        'dt = clsGen.ValoresDistinto(ds_asociacion.Tables("detalle_dua").DefaultView.ToTable, "dua".Split(","))

        pdt.DefaultView.RowFilter = "agregar = true"
        For Each drv As DataRowView In pdt.DefaultView
            If drv.Item("producto") = "" Then

            End If

            Try
                lfob = ds_asociacion.Tables("detalle_dua").Compute("Sum(fob)", "producto = '" & drv.Item("producto") & "' and asociar = true")
                drv.Item("fob") = lfob
            Catch ex As Exception
            End Try

            Try
                ldaiq = ds_asociacion.Tables("detalle_dua").Compute("Sum(dai)", "producto = '" & drv.Item("producto") & "' and asociar = true")
                drv.Item("dai") = ldaiq
            Catch ex As Exception
            End Try

            Try
                liva = ds_asociacion.Tables("detalle_dua").Compute("Sum(iva)", "producto = '" & drv.Item("producto") & "' and asociar = true")
                drv.Item("iva") = liva
            Catch ex As Exception
            End Try

            drv.Item("dua") = String.Empty
            dt.DefaultView.RowFilter = "producto = '" & drv.Item("producto") & "' and asociar = true"
            For Each drv2 As DataRowView In dt.DefaultView
                drv.Item("dua") = drv.Item("dua").ToString.Trim & IIf(drv.Item("dua").ToString.Length > 0, ",", "") & drv2.Item("dua")
            Next

        Next

        Try
            ldaiq = pdt.Compute("sum(dai)", "dai>0")
            Me.lbl_daiv.Text = ldaiq
            liva = pdt.Compute("sum(iva)", "iva>0")
            Me.lbl_iva.Text = liva
            Me.lbl_total.Text = ldaiq + liva



            'ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = "asociar = true"
            'dt = clsGen.ValoresDistinto(ds_asociacion.Tables("detalle_dua").DefaultView.ToTable, "dua".Split(","))
            'Me.lblTotalDI.Text = dt.Rows.Count

            clsGen = Nothing
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Colorear_Pedido()
        Dim clsgen As New ClasesGenerales.General
        'clsgen.Alinea_Grid(pdt, Me.dg_pedido, pdt.TableName, -1, 200, 0, False, True, "proveedor,producto,glosa,traslado,fob,daiV,iva,Dua", True, "")
        clsgen.Alinear_GridView(pdt, dg_pedido, ",proveedor,producto,glosa,pedido,fob,dai,iva,Dua,", "", "", "", "", "", "", True, True, 250, 0)

        clsgen = Nothing
    End Sub

    Private Sub Mostrar_Productos()
        Try
            Dim nrow As Integer
            nrow = Me.dg_pedido.CurrentCell.RowIndex

            Detalle_Productos(nrow)

            If nrow > -1 And nrow < 5 Then
                Colorear_Pedido()
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Detalle_Productos(ByVal pnRow As Integer)
        Dim ls_resultado As String


        ls_resultado = Me.dg_pedido.Item("producto", pnRow).Value
        ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = "producto = '" & ls_resultado & "'"

    End Sub

 

    Private Sub Colorear_Detalle()
        Dim clsgen As New ClasesGenerales.General
        'clsgen.Alinea_Grid(ds_asociacion.Tables("detalle_dua"), Me.dg_producto_dua, ds_asociacion.Tables("detalle_dua").TableName, -1, 250, 0, True, True, "", True, "")
        clsgen.Alinear_GridView(ds_asociacion.Tables("detalle_dua"), dg_producto_dua, "", "", "", "", "", "", "", True, True, 250, 0)

        clsgen = Nothing
    End Sub


    Private Sub prepararPedido()

        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim lbContinuar As Boolean = False

        Try
            ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True"

            dt = ClsGen.ValoresDistinto(ds_asociacion.Tables("detalle_dua").DefaultView.ToTable, "dua".Split(","))

            If dt.Rows.Count > 1 Then
                If MessageBox.Show("Se Generaran " & dt.Rows.Count & " DI, Esta Seguro de Continuar", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    lbContinuar = True
                End If
            ElseIf dt.Rows.Count = 1 Then
                lbContinuar = True
            End If



        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

        If lbContinuar Then
            guardarPedido(dt)
        End If
    End Sub


    Private Sub guardarPedido(ByVal dtDuas As DataTable)
        Dim ls_sql As String
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim oTransFlex As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim drv, drv_aux As DataRowView
        Dim ldaiq, liva, lfob As Double
        Dim ltotal_daiq, ltotal_iva As Double
        ldaiq = 0
        liva = 0
        lfob = 0
        ltotal_daiq = 0
        ltotal_iva = 0


        Try
            oTrans.open()
            oTransFlex.open()


            For Each dr As DataRow In dtDuas.Rows

                ls_sql = "pa_ins_um_int_pedido_encabezado '" & gs_empresa & "','" & Me.txt_nombre.Text & "','" & gs_usuario & "'," & _
                            Double.Parse(Me.lbl_daiv.Text) & "," & Double.Parse(Me.lbl_iva.Text)
                oTrans.Ingresa(ls_sql)

                If oTrans.Codigo_error = 0 Then
                    dt = oTrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    Me.txt_numero.Text = dt.Rows(0).Item("newid").ToString
                    ltotal_daiq = 0
                    ltotal_iva = 0
                End If



                If Me.txt_numero.Text.Trim.Length > 0 Then

                    'Inicializo los estados
                    ls_sql = "pa_ins_um_int_pedido_estado " & Me.txt_numero.Text & ",0,'" & gs_usuario & "',''"
                    oTrans.Ingresa(ls_sql)


                    ldaiq = 0
                    liva = 0
                    lfob = 0

                    ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = _
                        "asociar = True and dua = '" & dr.Item("dua") & "'"


                    'Agregar Asociaciones con Duas
                    If ds_asociacion.Tables("detalle_dua").DefaultView.Count > 0 Then

                        Dim sproducto As String = ""
                        Dim ldcantidad As Double = 0
                        liva = 0
                        ldaiq = 0

                        For Each drv_aux In ds_asociacion.Tables("detalle_dua").DefaultView

                            ls_sql = "pa_ins_um_int_pedido_detalle_dua " & Me.txt_numero.Text & ",'" & drv_aux.Item("producto") & "','" & _
                                     drv_aux.Item("dua") & "'," & drv_aux.Item("cantidad_trasladar")
                            oTrans.Ingresa(ls_sql)

                            liva += drv_aux("iva")
                            ldaiq += drv_aux("dai")
                            ldcantidad += drv_aux("cantidad_trasladar")


                            ltotal_daiq += ldaiq
                            ltotal_iva += liva

                            If sproducto <> drv_aux.Item("producto") Then
                                sproducto = drv_aux.Item("producto")
                                ls_sql = "pa_ins_um_int_pedido_detalle " & Me.txt_numero.Text & ",'" & sproducto & "'," & ldcantidad & _
                                                                    "," & ldaiq & "," & liva
                                oTrans.Ingresa(ls_sql)
                                liva = 0
                                ldaiq = 0
                                ldcantidad = 0
                            End If

                        Next
                    End If
                    ls_sql = "pa_upd_um_int_pedido_encabezado " & Me.txt_numero.Text & ",NULL," & ltotal_daiq.ToString & "," & ltotal_iva
                    oTrans.Actualiza(ls_sql)

                    guardarAviso()

                End If
            Next

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            oTransFlex.close()
            oTransFlex = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub guardarAviso()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim clsGen As New ClasesGenerales.General

        Dim lsSQL As String
        Dim dt As DataTable
        Dim dtCorreo As DataTable
        Dim scuentas As String = ""
        Try

            myOtrans.open()
            lsSQL = "call pa_sel_um_seg_usuario_aviso_sistema (10)" '1= Ingreso de Dua OC
            dt = myOtrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows

                'If dr.Item("validar_marca").ToString = "1" Then
                '    dt2.DefaultView.RowFilter = "texto4 = '" & dr.Item("usuario").ToString & "'"
                '    If dt2.DefaultView.Count > 0 Then guardarAviso = True

                'ElseIf dr.Item("validar_empresa").ToString = "1" Then
                '    dtUsuarioEmpresa.DefaultView.RowFilter = "usuario = '" & dr.Item("usuario").ToString & "'"
                '    If dtUsuarioEmpresa.DefaultView.Count > 0 Then guardarAviso = True

                'Else
                '    guardarAviso = True
                'End If

                'If guardarAviso() Then
                clsGen.guardarAviso(dr.Item("usuario").ToString, "Umbright", "Solicitud No " &
                                      Me.txt_numero.Text & "  " &
                                      Me.txt_nombre.Text, 1)
                'guardarAviso = False
                'End If

                dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & dr.Item("usuario").ToString & "'")
                If dtCorreo.Rows.Count > 0 Then
                    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                    scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                End If
            Next



            If scuentas.ToString.Length > 0 Then
                enviarCorreo(scuentas)
            End If

        Catch ex As Exception

        Finally
            myOtrans.close()
            myOtrans = Nothing
            clsGen = Nothing
        End Try


    End Sub

    Private Sub enviarCorreo(sCuentas As String)


        Dim sBody As String
        Dim clsGen As New ClasesGenerales.General
        Dim sRemitente As String = "lgs1@logiservicios.com"
        Dim snombreRemitente As String = "LGS1"
        'Dim scuentas As String = ""
        Dim sSubject As String = ""
        Dim ldFechaDocto As Date

        Try




            Dim iCount As Integer = 0

            sSubject = "Internaciones " & Me.txt_numero.Text & "  " & Me.txt_nombre.Text ' Me.cmbTipoDocto.SelectedValue.ToString & "-" & Me.txtNumero.Text


            sBody = "<br>"
            'sBody = sBody & "Se les Informa que se ha ingresado a " & Me.txtBodega.Text.ToUpper & " lo siguiente " + "<br>"
            sBody = sBody & "Seguimiento de Internaciones <br>"
            sBody = sBody & " <br>"
            sBody = sBody & Me.txt_numero.Text & "  " & Me.txt_nombre.Text
            'sBody = sBody & "Proveedor " & Me.txtProveedor.Text & "<br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & "Adjunto se envia el documento de Ingreso <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            sBody = sBody & " <br>"
            'If Me.txtComentario4.Text.Length > 0 Then
            '    sBody = sBody & " Comentarios " & Me.txtComentario4.Text
            'End If




            Try
                'Dim dtBU As DataTable
                'Dim dtCorreo As DataTable
                'dtBU = clsGen.selectQuery("FlexLine", "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmbTipoDocto.SelectedValue.ToString & "','" & Me.txtNumero.Text & "'")
                'ldFechaDocto = dtBU.Rows(0).Item("fecha_docto")
                'dtBU = clsGen.ValoresDistinto(dtBU, "analisisproducto17".Split(","))
                'For Each dr As DataRow In dtBU.Rows
                '    '' Debo obtener las personas que tienen permisos para esa unidad de negocio
                '    Dim dtUsuarioBU As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_menu_opcion_empresa_empresa null,null, '" & dr.Item("analisisproducto17").ToString & "','" & gs_empresa & "'")
                '    For Each drBU As DataRow In dtUsuarioBU.Rows
                '        dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & drBU.Item("usuario").ToString & "'")
                '        If dtCorreo.Rows.Count > 0 Then
                '            If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                '            scuentas = scuentas & dtCorreo.Rows(0).Item("correo").ToString
                '        End If
                '    Next

                'Next
                '''Correos por empresa
                'dtCorreo = clsGen.selectQuery("FlexLine", "pa_sel_um_gen_tabcod null, 'gen_correo_internaci', '" & gs_empresa & "'")
                'For Each dr As DataRow In dtCorreo.Rows
                '    If scuentas.ToString.Length > 0 Then scuentas = scuentas & ","
                '    scuentas = scuentas & dr.Item("descripcion").ToString
                'Next



            Catch ex As Exception

            End Try




            'scuentas = "coscal@umbral.com.gt, chernandez@logiservicios.com"
            'Dim lsRuta As String = generarPDF(ldFechaDocto.ToString("yyyyMM"))

            clsGen.enviarcorreo(sRemitente, snombreRemitente, sCuentas, sSubject, sBody, "")

            'Ruta En Servidor

            'Dim lsRutaServidor As String = "\\" & clsGen.Obtener_XMLConfig("servidor_alterno_" & clsGen.Obtener_XMLConfig("ubicacion", False), False) & "\flexline$\" &
            '            gs_empresa & "\" & ldFechaDocto.ToString("yyyyMM")


            'Try
            '    If Not Directory.Exists(lsRutaServidor) Then
            '        Directory.CreateDirectory(lsRutaServidor)
            '    End If
            'Catch ex As Exception

            'End Try

            'lsRutaServidor &= "\" & Me.cmbTipoDocto.SelectedValue.ToString.Replace(" ", "_") & "_" & Me.txtNumero.Text & ".pdf"

            'clsGen.Copiar_Archivo(lsRuta, lsRutaServidor, True)

        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try

    End Sub


    Private Sub Modificar_Pedido()

        Dim drv, drv_aux As DataRowView
        Dim ls_sql As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim berror As Boolean = False

        Try
            otrans.open()

            ls_sql = "pa_del_um_int_pedido_detalle_dua " & Me.txt_numero.Text
            otrans.Elimina(ls_sql)

            For Each drv In pdt.DefaultView

                ds_asociacion.Tables("detalle_dua").DefaultView.RowFilter = "asociar = True and producto = '" & drv.Item("producto") & "'"
                'Agregar Asociaciones con Duas
                If ds_asociacion.Tables("detalle_dua").DefaultView.Count > 0 Then

                    For Each drv_aux In ds_asociacion.Tables("detalle_dua").DefaultView

                        ls_sql = "pa_ins_um_int_pedido_detalle_dua " & Me.txt_numero.Text & ",'" & drv.Item("producto") & "','" & _
                                 drv_aux.Item("dua") & "'," & drv.Item("traslado")
                        otrans.Ingresa(ls_sql)
                        If otrans.Codigo_error > 0 Then
                            MessageBox.Show(otrans.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            berror = True
                        End If

                    Next
                End If
            Next
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

        If berror = False Then
            MessageBox.Show("Procesos Finalizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Procesos Finalizado con Errores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Recorrer_pedido()
        Try

                Dim nrow, nrowold As Integer
            nrowold = Me.dg_pedido.CurrentRow.Index

            For nrow = 0 To pdt.DefaultView.Count - 1
                Detalle_Productos(nrow)
            Next

        Catch ex As Exception

        End Try


    End Sub

    Private Sub aplicar_producto(ByVal sproducto As String, ByVal sdua As String, ByVal icantidad As Integer, ByVal bagregar As Boolean)


        For Each dr As DataRow In ds_asociacion.Tables("detalle_dua").Rows
            If dr.Item("producto").ToString = sproducto And dr.Item("dua") = sdua Then
                dr.Item("asociar") = bagregar
                If dr.Item("saldo_cajas") < icantidad Then icantidad = dr.Item("saldo_cajas")


                dr.Item("cantidad_trasladar") = icantidad
                Dim lfob As Double = Val(dr.Item("fobunitario").ToString)

                Dim ldaiq As Double = 0
                Dim liva As Double = 0

                Try
                    dr.Item("fob") = lfob * dr.Item("cantidad_trasladar")
                    'ldaiq = (lfob * (.Item("dai") / 100)) * drv2.Item("cantidad_trasladar")
                    ldaiq = dr.Item("daiunitario") * dr.Item("cantidad_trasladar")
                Catch ex As Exception
                End Try
                dr.Item("dai") = ldaiq

                Try
                    liva = (((lfob * dr.Item("cantidad_trasladar"))) + dr.Item("daiunitario")) * 0.12
                Catch ex As Exception
                    liva = 0
                End Try
                dr.Item("iva") = liva
                Exit For

            End If
        Next

        hacerResumen()
        'Me.dg_producto_dua.Item("cantidad_trasladar", rowIndex).Value = Me.dg_pedido.Item("pedido", dg_pedido.CurrentRow.Index).Value
        'Me.dg_producto_dua.Item("fob", rowIndex).Value = Me.dg_producto_dua.Item("fobunitario", Me.dg_producto_dua.CurrentRow.Index).Value * Me.dg_producto_dua.Item("cantidad_trasladar", Me.dg_producto_dua.CurrentRow.Index).Value


    End Sub

    Private Sub int_asociar_solicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pdt.DefaultView.RowFilter = "agregar = True"
        Crear_Estructura()


        Try
            pdt.Columns.Add(New DataColumn("Dua", GetType(String), "          "))
        Catch ex As Exception
        End Try
        Obtener_Existencia_DA()

        'Asignar_Pedido_Dua()

        Me.dg_pedido.DataSource = pdt
        Colorear_Pedido()
        Recorrer_pedido()
        Mostrar_Productos()
        '  Me.hacerResumen()
    End Sub

    Private Sub btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Guardar.Click
        If Me.btn_Guardar.Text = "Guardar" Then
            Me.prepararPedido()
        Else
            Modificar_Pedido()
        End If
        Colorear_Pedido()
    End Sub

    Private Sub lbl_daiv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_daiv.TextChanged, lblTotalDI.TextChanged
        lbl_daiv.Text = Format(Convert.ToDecimal(lbl_daiv.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub lbl_iva_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_iva.TextChanged
        lbl_iva.Text = Format(Convert.ToDecimal(lbl_iva.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub lbl_total_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_total.TextChanged
        lbl_total.Text = Format(Convert.ToDecimal(lbl_total.Text), "###,###,##0.00").ToString
    End Sub

    Private Sub dg_pedido_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg_pedido.CurrentCellChanged
        'con un click muestro el detalle del pedido

        'Asignar_Pedido_Dua()




    End Sub


    Private Sub dg_producto_dua_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_producto_dua.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dg_producto_dua.Rows(rowIndex)
                If (",asociar,").IndexOf(dg_producto_dua.Columns(colIndex).Name.ToLower) > -1 Then
                    Dim ncantidad As Integer = -99
                    Dim clickasociar As Boolean = dg_producto_dua.Columns(colIndex).Name.ToLower.Equals("asociar")
                    'Me.dgv_detalle.Item("valor_sugerido", rowIndex).Value = Me.dgv_detalle.Item("pedido", rowIndex).Value * Me.dgv_detalle.Item("fob", rowIndex).Value


                    If dg_producto_dua.Columns(colIndex).Name.ToLower.Equals("asociar") Then
                        If dg_producto_dua.Item(colIndex, rowIndex).Value = True Then
                            Me.aplicar_producto(dg_producto_dua.Item("producto", rowIndex).Value, dg_producto_dua.Item("dua", rowIndex).Value, Me.dg_pedido.Item("pedido", dg_pedido.CurrentRow.Index).Value, True)
                        Else
                            Me.aplicar_producto(dg_producto_dua.Item("producto", rowIndex).Value, dg_producto_dua.Item("dua", rowIndex).Value, 0, False)
                            'Me.dg_producto_dua.Item("cantidad_trasladar", rowIndex).Value = Me.dg_pedido.Item("pedido", dg_pedido.CurrentRow.Index).Value
                            'Me.dg_producto_dua.Item("fob", rowIndex).Value = Me.dg_producto_dua.Item("fobunitario", Me.dg_producto_dua.CurrentRow.Index).Value * Me.dg_producto_dua.Item("cantidad_trasladar", Me.dg_producto_dua.CurrentRow.Index).Value
                            'Me.dg_producto_dua.Item("cantidad_trasladar", rowIndex).Value = 0
                            'Me.dg_producto_dua.Item("fob", rowIndex).Value = 0
                        End If
                        'ncantidad = dg_producto_dua.Item(colIndex, rowIndex).Value
                        'Me.hacerResumen()

                    End If

                    ' Me.AplicarProducto(dg_producto_dua.Item("empresa", rowIndex).Value, Me.dgv_detalle.Item("producto", rowIndex).Value, dgv_detalle.Columns(colIndex).Name.ToLower, ncantidad, clickagregar)

                    dg_producto_dua.CurrentCell = dg_producto_dua.Item(colIndex, rowIndex)

                End If
            End If


        Catch ex As Exception


        End Try

    End Sub

    Private Sub dg_pedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_pedido.CellContentClick

    End Sub

    Private Sub dg_producto_dua_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_producto_dua.CellContentClick

    End Sub

    Private Sub dg_pedido_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_pedido.MouseClick
        Me.hacerResumen()
        Mostrar_Productos()

    End Sub
End Class
