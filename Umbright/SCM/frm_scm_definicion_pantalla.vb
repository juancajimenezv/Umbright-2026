Public Class frm_scm_definicion_pantalla
    Inherits System.Windows.Forms.Form
    Dim Ods As New DataSet

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
    Friend WithEvents txt_nombre_pantalla As System.Windows.Forms.TextBox
    Friend WithEvents dg_columnas As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents dg_pantallas As System.Windows.Forms.DataGrid
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.dg_columnas = New System.Windows.Forms.DataGrid
        Me.txt_nombre_pantalla = New System.Windows.Forms.TextBox
        Me.dg_pantallas = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_nuevo = New System.Windows.Forms.Button
        CType(Me.dg_columnas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_pantallas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_columnas
        '
        Me.dg_columnas.CaptionVisible = False
        Me.dg_columnas.DataMember = ""
        Me.dg_columnas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_columnas.Location = New System.Drawing.Point(280, 56)
        Me.dg_columnas.Name = "dg_columnas"
        Me.dg_columnas.Size = New System.Drawing.Size(280, 440)
        Me.dg_columnas.TabIndex = 0
        '
        'txt_nombre_pantalla
        '
        Me.txt_nombre_pantalla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_pantalla.Location = New System.Drawing.Point(63, 11)
        Me.txt_nombre_pantalla.Name = "txt_nombre_pantalla"
        Me.txt_nombre_pantalla.Size = New System.Drawing.Size(289, 20)
        Me.txt_nombre_pantalla.TabIndex = 2
        '
        'dg_pantallas
        '
        Me.dg_pantallas.CaptionVisible = False
        Me.dg_pantallas.DataMember = ""
        Me.dg_pantallas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_pantallas.Location = New System.Drawing.Point(8, 56)
        Me.dg_pantallas.Name = "dg_pantallas"
        Me.dg_pantallas.ReadOnly = True
        Me.dg_pantallas.Size = New System.Drawing.Size(256, 440)
        Me.dg_pantallas.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nombre"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ForeColor = System.Drawing.Color.White
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImageList = Me.ImageList1
        Me.btn_guardar.Location = New System.Drawing.Point(496, 0)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(64, 56)
        Me.btn_guardar.TabIndex = 3
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.ForeColor = System.Drawing.Color.White
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.ImageList = Me.ImageList1
        Me.btn_nuevo.Location = New System.Drawing.Point(432, 0)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(64, 56)
        Me.btn_nuevo.TabIndex = 3
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'frm_scm_definicion_pantalla
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(568, 509)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_nombre_pantalla)
        Me.Controls.Add(Me.dg_pantallas)
        Me.Controls.Add(Me.dg_columnas)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Name = "frm_scm_definicion_pantalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. SCM - Definicion de Pantallas .::"
        CType(Me.dg_columnas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_pantallas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Crear_Estructuras()
        Dim icount As Short
        Dim sname As String


        Dim oCompras As New Compras.SCM(Ods)
        Try
            oCompras.Crear_Estructura()

        Catch ex As Exception
        Finally
            oCompras = Nothing

        End Try

        'Dim dt As New DataTable("campos_detalle")

        'dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("procedencia", GetType(String)))
        'dt.Columns.Add(New DataColumn("producto", GetType(String)))
        'dt.Columns.Add(New DataColumn("glosa", GetType(String)))
        'dt.Columns.Add(New DataColumn("pareto", GetType(String)))
        'dt.Columns.Add(New DataColumn("estatus", GetType(String)))
        'dt.Columns.Add(New DataColumn("uxc", GetType(Short)))
        'dt.Columns.Add(New DataColumn("fob", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("pedido_sugerido", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("valor_sugerido", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
        'dt.Columns.Add(New DataColumn("min_cajas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("max_cajas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("diario_cajas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("cd_cajas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("cdx_cajas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("da_cajas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("ppto", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("transito", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("cobertura", GetType(Decimal)))
        'For icount = 1 To 11
        '    sname = "ppto+" & icount.ToString.PadLeft(2, "0")
        '    dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        '    sname = "transito+" & icount.ToString.PadLeft(2, "0")
        '    dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        '    sname = "saldo+" & icount.ToString.PadLeft(2, "0")
        '    dt.Columns.Add(New DataColumn(sname, GetType(Integer)))
        '    sname = "cobertura+" & icount.ToString.PadLeft(2, "0")
        '    dt.Columns.Add(New DataColumn(sname, GetType(Decimal)))
        'Next
        'dt.Columns.Add(New DataColumn("full", GetType(String)))
        'dt.Columns.Add(New DataColumn("cajasxlayer", GetType(Short)))
        'dt.Columns.Add(New DataColumn("cajasxpallet", GetType(Short)))
        'dt.Columns.Add(New DataColumn("sugerido_anterior", GetType(Integer)))

        'Ods.Tables.Add(dt.Copy)
        'dt.TableName = "Resumen"
        'Ods.Tables.Add(dt.Copy)


        Dim dt As New DataTable("columnas")
        dt.Columns.Add(New DataColumn("Mostrar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Nombre_Columna", GetType(String)))

        Ods.Tables.Add(dt.Copy)

    End Sub

    Private Sub Llenar_Informacion()
        Dim odc As DataColumn
        Dim dr As DataRow
        Dim ClsGen As New ClasesGenerales.General

        'For Each odc In Ods.Tables("campos_detalle").Columns

        '    dr = Ods.Tables("columnas").NewRow
        '    dr.Item("Mostrar") = False
        '    dr.Item("Nombre_Columna") = odc.ColumnName
        '    Ods.Tables("Columnas").Rows.Add(dr)
        'Next

        For Each odc In Ods.Tables("detalle_productos").Columns

            If odc.ColumnName = "min_cajas" Then
                odc.ColumnName = "min_cajas"
            End If
            dr = Ods.Tables("columnas").NewRow
            dr.Item("Mostrar") = False
            dr.Item("Nombre_Columna") = odc.ColumnName
            Ods.Tables("Columnas").Rows.Add(dr)
        Next



        Me.dg_columnas.DataSource = Ods.Tables("Columnas")
        ClsGen.Alinea_Grid(Ods.Tables("columnas"), Me.dg_columnas, Ods.Tables("columnas").TableName, -1, 250, 0, False, True, "", True, "")
        ClsGen = Nothing
    End Sub

    Private Sub Mostrar_Pantallas()

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String

        Try
            otrans.open()
            ls_sql = "pa_sel_um_scm_definicion_pantalla"
            dt = otrans.Obtiene(ls_sql)
            dt.TableName = "pantallas"

            If Ods.Tables.IndexOf("pantallas") >= 0 Then
                Ods.Tables.Remove("pantallas")
            End If
            Ods.Tables.Add(dt.Copy)

            Me.dg_pantallas.DataSource = Ods.Tables("pantallas")

            ClsGen.Alinea_Grid(Ods.Tables("pantallas"), Me.dg_pantallas, Ods.Tables("pantallas").TableName, -1, 250, 0, False, True, "nombre_pantalla", True, "")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            ClsGen = Nothing
        End Try

    End Sub

    Private Sub Mostrar_Informacion()
        Dim nrow As Integer
        Dim snombre, scampos As String
        Dim dt As DataTable
        Dim dr As DataRow

        Try
            Limpiar_Pantalla()

            nrow = Me.dg_pantallas.CurrentCell.RowNumber
            snombre = Me.dg_pantallas.Item(nrow, 0)

            Me.txt_nombre_pantalla.Text = snombre

            dt = Ods.Tables("pantallas").Copy

            dt.DefaultView.RowFilter = "nombre_pantalla = '" & snombre & "'"

            If dt.DefaultView.Count > 0 Then
                scampos = dt.DefaultView(0).Item("campos")
                For Each dr In Ods.Tables("columnas").Rows
                    If scampos.IndexOf(dr.Item("Nombre_Columna").ToString) >= 0 Then
                        dr.Item("Mostrar") = True
                    End If
                Next
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Guardar_Informacion()
        Dim ls_sql As String
        Dim scampos As String = ""
        Dim drv As DataRowView
        Dim Otrans As New Transaccional.Conexion("SCM")

        Try
            Otrans.open()
            Ods.Tables("Columnas").DefaultView.RowFilter = "Mostrar = True"

            For Each drv In Ods.Tables("Columnas").DefaultView
                scampos = scampos & drv.Item("Nombre_Columna").ToString & ","
            Next

            If scampos.Length > 0 Then
                ls_sql = "pa_ins_um_scm_definicion_pantalla '" & Me.txt_nombre_pantalla.Text & "','" & scampos & "'"
                Otrans.Ingresa(ls_sql)
                If Otrans.Codigo_error = 0 Then
                    MessageBox.Show("Informacion Ingresada Con Exito")
                End If
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            Ods.Tables("Columnas").DefaultView.RowFilter = ""
        End Try
        Mostrar_Pantallas()
        Mostrar_Informacion()

    End Sub

    Private Sub Limpiar_Pantalla()
        Dim dr As DataRow
        Me.txt_nombre_pantalla.Text = ""

        For Each dr In Ods.Tables("columnas").Rows
            dr.Item("Mostrar") = False
        Next

    End Sub

    Private Sub frm_scm_definicion_pantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_Estructuras()
        Llenar_Informacion()
        Mostrar_Pantallas()
        Mostrar_Informacion()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Guardar_Informacion()
    End Sub

    Private Sub dg_pantallas_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_pantallas.CurrentCellChanged

        Mostrar_Informacion()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Limpiar_Pantalla()
    End Sub

End Class
