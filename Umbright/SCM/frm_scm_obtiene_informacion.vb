Public Class frm_scm_obtiene_informacion
    Inherits System.Windows.Forms.Form
    Dim ds_preparacion As DataSet
    Dim pi_meses_adicionales As Short = 0
    Dim pi_lead_time As Short
    Public pFechaCalculo As DateTime
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public pmes_proceso, psNombreCalculo As String
    Public pnSemanas As Integer = 0
    Public psColumnasOcultas As String = String.Empty
    Public psComentarios As String = String.Empty
    Friend WithEvents btnCambiarEstado As System.Windows.Forms.Button
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnAprobacion As System.Windows.Forms.Button
    Friend WithEvents txt_filtro As TextBox
    Friend WithEvents cmb_operadores As ComboBox
    Friend WithEvents cmb_campos As ComboBox
    Public pnumeroPedido As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef ds_anterior As Object)
        MyBase.New()
        ds_preparacion = ds_anterior
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
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_scm_obtiene_informacion))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAprobacion = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnCambiarEstado = New System.Windows.Forms.Button()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.txt_filtro = New System.Windows.Forms.TextBox()
        Me.cmb_operadores = New System.Windows.Forms.ComboBox()
        Me.cmb_campos = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_generar
        '
        Me.btn_generar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_generar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ForeColor = System.Drawing.Color.White
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_generar.ImageIndex = 2
        Me.btn_generar.ImageList = Me.ImageList1
        Me.btn_generar.Location = New System.Drawing.Point(415, 54)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(80, 64)
        Me.btn_generar.TabIndex = 17
        Me.btn_generar.Text = "Obtener"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_generar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.DimGray
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "1273602134_exchange.png")
        Me.ImageList1.Images.SetKeyName(4, "01EXCEL116.bmp")
        Me.ImageList1.Images.SetKeyName(5, "aprobar2.jpg")
        '
        'btnAprobacion
        '
        Me.btnAprobacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAprobacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnAprobacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAprobacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAprobacion.ForeColor = System.Drawing.Color.White
        Me.btnAprobacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAprobacion.ImageIndex = 5
        Me.btnAprobacion.ImageList = Me.ImageList1
        Me.btnAprobacion.Location = New System.Drawing.Point(415, 284)
        Me.btnAprobacion.Name = "btnAprobacion"
        Me.btnAprobacion.Size = New System.Drawing.Size(80, 74)
        Me.btnAprobacion.TabIndex = 17
        Me.btnAprobacion.Text = "Aprobado Tesoreria"
        Me.btnAprobacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnAprobacion, "Iniciar con el Seguimiento de Pedido")
        Me.btnAprobacion.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(1, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(408, 430)
        Me.DataGridView1.TabIndex = 18
        '
        'btnCambiarEstado
        '
        Me.btnCambiarEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCambiarEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCambiarEstado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarEstado.ForeColor = System.Drawing.Color.White
        Me.btnCambiarEstado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCambiarEstado.ImageIndex = 3
        Me.btnCambiarEstado.ImageList = Me.ImageList1
        Me.btnCambiarEstado.Location = New System.Drawing.Point(415, 124)
        Me.btnCambiarEstado.Name = "btnCambiarEstado"
        Me.btnCambiarEstado.Size = New System.Drawing.Size(80, 74)
        Me.btnCambiarEstado.TabIndex = 17
        Me.btnCambiarEstado.Text = "Cambiar Estado"
        Me.btnCambiarEstado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCambiarEstado.UseVisualStyleBackColor = False
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(61, 1)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(314, 21)
        Me.cmbEstado.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-2, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Estado"
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.ForeColor = System.Drawing.Color.White
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportar.ImageIndex = 4
        Me.btnExportar.ImageList = Me.ImageList1
        Me.btnExportar.Location = New System.Drawing.Point(415, 204)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(80, 74)
        Me.btnExportar.TabIndex = 17
        Me.btnExportar.Text = "Generar OC"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.UseVisualStyleBackColor = False
        '
        'txt_filtro
        '
        Me.txt_filtro.Location = New System.Drawing.Point(173, 27)
        Me.txt_filtro.Name = "txt_filtro"
        Me.txt_filtro.Size = New System.Drawing.Size(202, 20)
        Me.txt_filtro.TabIndex = 21
        '
        'cmb_operadores
        '
        Me.cmb_operadores.DisplayMember = "like"
        Me.cmb_operadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_operadores.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_operadores.FormattingEnabled = True
        Me.cmb_operadores.Items.AddRange(New Object() {"=", ">", "<", "like"})
        Me.cmb_operadores.Location = New System.Drawing.Point(108, 28)
        Me.cmb_operadores.Name = "cmb_operadores"
        Me.cmb_operadores.Size = New System.Drawing.Size(56, 21)
        Me.cmb_operadores.TabIndex = 23
        Me.cmb_operadores.ValueMember = "like"
        '
        'cmb_campos
        '
        Me.cmb_campos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_campos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_campos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_campos.FormattingEnabled = True
        Me.cmb_campos.Items.AddRange(New Object() {"empresa", "nombre_calculo"})
        Me.cmb_campos.Location = New System.Drawing.Point(1, 27)
        Me.cmb_campos.Name = "cmb_campos"
        Me.cmb_campos.Size = New System.Drawing.Size(100, 21)
        Me.cmb_campos.TabIndex = 22
        '
        'frm_scm_obtiene_informacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(496, 485)
        Me.Controls.Add(Me.cmb_operadores)
        Me.Controls.Add(Me.cmb_campos)
        Me.Controls.Add(Me.txt_filtro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnAprobacion)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnCambiarEstado)
        Me.Controls.Add(Me.btn_generar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_scm_obtiene_informacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "::. SCM - Obtiene Informacion .::"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Llenar_Maestros()
        Dim ls_sql As String

        Dim dt As DataTable
        Dim oTrans As New Transaccional.Conexion("scm")
        Try
            oTrans.open()
            ''Parametros Generales
            'ls_sql = "pa_sel_um_scm_parametros_generales"
            'dt = oTrans.Obtiene(ls_sql)
            'dt.TableName = "scm_parametros_generales"
            'ds_preparacion.Tables.Add(dt.Copy)

            '''Proveedores
            'ls_sql = "pa_sel_um_prv_frecuencia_compra '" & gs_empresa & "'"
            'dt = oTrans.Obtiene(ls_sql)
            'dt.TableName = "prv_frecuencia_compra"
            'ds_preparacion.Tables.Add(dt.Copy)

            'ls_sql = "pa_sel_um_prv_dias_inventario_minimo '" & gs_empresa & "'"
            'dt = oTrans.Obtiene(ls_sql)
            'dt.TableName = "prv_dias_inventario_minimo"
            'ds_preparacion.Tables.Add(dt.Copy)

            'ls_sql = "pa_sel_um_pg_pareto "
            'dt = oTrans.Obtiene(ls_sql)
            'dt.TableName = "pg_pareto"
            'ds_preparacion.Tables.Add(dt.Copy)


            'ls_sql = "pa_sel_um_prv_proveedor '" & gs_empresa & "'"
            'dt = oTrans.Obtiene(ls_sql)
            'dt.TableName = "prv_proveedor"
            'ds_preparacion.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_v_pg_estados 2"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "pg_estados"
            ds_preparacion.Tables.Add(dt.Copy)


            'pi_meses_adicionales = IIf(ds_preparacion.Tables("scm_parametros_generales").Rows(0).Item("incluir_mes_actual_proyeccion") = True, 0, 1)

            Me.cmbEstado.DataSource = dt
            Me.cmbEstado.ValueMember = "cod_estado"
            Me.cmbEstado.DisplayMember = "estado"
        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing


        End Try
    End Sub

    Private Sub Llenar_Calculos_Previos()
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable


        Try
            Otrans.open()
            ls_sql = "pa_var_um_inv_pedido_encabezado"
            dt = Otrans.Obtiene(ls_sql)

            If Not tiene_permisos("mci_scm_administrar") Then ''cuando no sea administrador solo puede ver los que estan para revision
                Me.cmbEstado.SelectedValue = 1
                dt.DefaultView.RowFilter = "estado = 1" 'revision
                dt = dt.DefaultView.ToTable
            End If

            dt.TableName = "calculos_previos"

            If ds_preparacion.Tables.Contains("calculos_previos") Then ds_preparacion.Tables.Remove("calculos_previos")

            ds_preparacion.Tables.Add(dt.Copy)

            ds_preparacion.Tables("calculos_previos").DefaultView.RowFilter = "estado = " & Me.cmbEstado.SelectedValue

            Me.DataGridView1.DataSource = ds_preparacion.Tables("calculos_previos").DefaultView 'ds_preparacion.Tables("calculos_previos")
            ClsGen.Alinear_GridView(ds_preparacion.Tables("calculos_previos"), Me.DataGridView1, ",cod_calculo,agregar,empresa,nombre_calculo,usuario_grabo,fecha_grabo,", "", ",empresa,nombre_calculo,usuario_grabo,fecha_grabo,", "", "", "", "", False, True, 250, 0)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try


    End Sub

    Private Function crearEstructuraExportar() As DataTable
        Dim dt1 As New DataTable

        dt1.Columns.Add(New DataColumn("proveedor", GetType(String)))
        dt1.Columns.Add(New DataColumn("codigo_flex", GetType(String)))
        dt1.Columns.Add(New DataColumn("procedencia", GetType(String)))
        dt1.Columns.Add(New DataColumn("descripcion_producto", GetType(String)))
        dt1.Columns.Add(New DataColumn("unidades_caja", GetType(String)))
        dt1.Columns.Add(New DataColumn("fob_caja", GetType(Double)))
        dt1.Columns.Add(New DataColumn("pedido_caja", GetType(Integer)))
        dt1.Columns.Add(New DataColumn("pedido_unidades", GetType(Integer)))
        dt1.Columns.Add(New DataColumn("fob_total", GetType(Double)))
        dt1.Columns.Add(New DataColumn("numero_registro_sanitario", GetType(String)))
        dt1.Columns.Add(New DataColumn("fecha_registro_sanitario", GetType(DateTime)))

        Return dt1
    End Function

    Private Sub Crear_Estructuras()
        Dim oCompras As New Compras.SCM(ds_preparacion)
        Try

            oCompras.Crear_Estructura()

        Catch ex As Exception
        Finally
            oCompras = Nothing

        End Try
    End Sub

    ''Obtener Ultimo Calculo

    Private Sub Obtener_Calculos()
        Dim dt, dt2 As DataTable
        Dim dv As DataView
        Dim draux As DataRow
        Dim ClsGen As New ClasesGenerales.General

        dv = Me.DataGridView1.DataSource
        dt = dv.ToTable
        Dim lcontinuar As Boolean = False

        'Dim drv As DataRowView

        dt.DefaultView.RowFilter = "Agregar = True"
        If dt.DefaultView.Count > 1 Then
            If MessageBox.Show("Esta Seguro de Agrupar los Calculos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lcontinuar = True

            End If
        ElseIf dt.DefaultView.Count = 1 Then
            lcontinuar = True

        End If



        If lcontinuar Then

            For Each drv As DataRowView In dt.DefaultView

                Dim ods As New DataSet
                ods.ReadXml("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\compras$\" & drv.Item("nombre_calculo").ToString.Trim & ".xml")

                dt2 = ods.Tables("detalle_productos").Copy
                dt2.TableName = "detalle_productos"
                '(c) si hay mas de una seleccion
                If lcontinuar Then
                    If ds_preparacion.Tables.Contains("detalle_productos") Then ds_preparacion.Tables.Remove("detalle_productos")
                    lcontinuar = False
                    ds_preparacion.Tables.Add(dt2.Copy)

                    If ds_preparacion.Tables.Contains("derivados") Then ds_preparacion.Tables.Remove("derivados")
                    dt2 = ods.Tables("derivados").Copy
                    ds_preparacion.Tables.Add(dt2.Copy)

                    Try

                        If ds_preparacion.Tables.Contains("presupuesto_mensual") Then ds_preparacion.Tables.Remove("presupuesto_mensual")
                        dt2 = ods.Tables("presupuesto_mensual").Copy
                        ds_preparacion.Tables.Add(dt2.Copy)


                    Catch ex As Exception

                    End Try
                    Try
                        If ds_preparacion.Tables.Contains("existencias") Then ds_preparacion.Tables.Remove("existencias")
                        dt2 = ods.Tables("existencias").Copy
                        ds_preparacion.Tables.Add(dt2.Copy)

                    Catch ex As Exception

                    End Try

                    Try
                        If ds_preparacion.Tables.Contains("presupuesto") Then ds_preparacion.Tables.Remove("presupuesto")
                        dt2 = ods.Tables("presupuesto").Copy
                        ds_preparacion.Tables.Add(dt2.Copy)

                    Catch ex As Exception

                    End Try

                    Try
                        If ds_preparacion.Tables.Contains("transitos") Then ds_preparacion.Tables.Remove("transitos")
                        dt2 = ods.Tables("transitos").Copy
                        ds_preparacion.Tables.Add(dt2.Copy)


                    Catch ex As Exception

                    End Try


                    Try
                        If ds_preparacion.Tables.Contains("existenciasLote") Then ds_preparacion.Tables.Remove("existenciasLote")
                        dt2 = ods.Tables("existenciasLote").Copy
                        ds_preparacion.Tables.Add(dt2.Copy)


                    Catch ex As Exception

                    End Try

                    Try
                        If ds_preparacion.Tables.Contains("existenciasSerie") Then ds_preparacion.Tables.Remove("existenciasSerie")
                        dt2 = ods.Tables("existenciasSerie").Copy
                        ds_preparacion.Tables.Add(dt2.Copy)





                    Catch ex As Exception

                    End Try


                    'ds.Tables.Add(ds_informacion_productos.Tables("presupuesto").Copy)
                    'ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_derivado").Copy)
                    'ds.Tables.Add(ds_informacion_productos.Tables("presupuesto_mensual").Copy)
                Else
                    For Each dr As DataRow In dt2.Rows
                        draux = ds_preparacion.Tables("detalle_productos").NewRow
                        For Each dc As DataColumn In dt2.Columns
                            draux(dc.ColumnName) = dr(dc.ColumnName)
                        Next
                        ds_preparacion.Tables("detalle_productos").Rows.Add(draux)
                    Next

                End If

                If pnSemanas < drv.Item("Semanas_Calculo") Then
                    pnSemanas = drv.Item("Semanas_Calculo")
                End If
                pFechaCalculo = drv.Item("fecha_grabo")
                psColumnasOcultas = drv.Item("Columnas_Ocultas").ToString
                psComentarios = drv.Item("comentarios").ToString
                pnumeroPedido = drv.Item("cod_calculo")
                psNombreCalculo = drv.Item("nombre_calculo").ToString.Trim

                dt2 = ds_preparacion.Tables("detalle_productos").Copy
                dt2.TableName = "calculo_original"
                If ds_preparacion.Tables.Contains("calculo_original") Then ds_preparacion.Tables.Remove("calculo_original")
                ds_preparacion.Tables.Add(dt2.Copy)

                'dt2 = ds_preparacion.Tables("detalle_productos").Copy
                'dt2.TableName = "calculo_original"
                'If ds_preparacion.Tables.Contains("calculo_original") Then ds_preparacion.Tables.Remove("calculo_original")
                'ds_preparacion.Tables.Add(dt2.Copy)

                'dt2.TableName = "detalle_productos"



            Next


        End If


        ClsGen = Nothing

    End Sub

    Private Sub cambiarEstados()
        Dim clsgen As New ClasesGenerales.frm_seleccionar_opcion
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim estados As String = String.Empty
        Dim lsSQL As String

        Try
            Otrans.open()
            For Each dr As DataRow In ds_preparacion.Tables("pg_estados").Rows
                estados += IIf(estados.Length > 0, ",", "") & dr.Item("estado")
            Next
            clsgen.Llenar_ComboString(estados)
            clsgen.ShowDialog()
            estados = clsgen.cmb_listado.SelectedItem
            clsgen.Dispose()
            Dim dt As DataTable
            dt = ds_preparacion.Tables("pg_estados").Copy
            dt.DefaultView.RowFilter = "estado = '" & estados & "'"

            ds_preparacion.Tables("calculos_previos").DefaultView.RowFilter = "agregar = true and estado = " & Me.cmbEstado.SelectedValue
            For Each drv As DataRowView In ds_preparacion.Tables("calculos_previos").DefaultView
                lsSQL = "pa_upd_um_inv_pedido_encabezado " & drv.Item("cod_calculo") & "," & dt.DefaultView(0)("cod_estado") & ",'" & gs_usuario & "'"
                Otrans.Actualiza(lsSQL)
            Next
            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            clsgen = Nothing
        End Try

    End Sub

    Private Sub VerificarSeguridad()
        Me.btnCambiarEstado.Visible = tiene_permisos("mci_scm_cambiar_estado_calculos")
        Me.btnAprobacion.Visible = tiene_permisos("mci_scm_aprobacion_tesoreria")
    End Sub


    Private Sub exportar()
        Dim dtControl, dt2 As DataTable
        Dim dv As DataView
        Dim dr_aux, dr As DataRow
        Dim ClsGen As New ClasesGenerales.General
        Dim ods2 As DataSet

        dv = Me.DataGridView1.DataSource
        dt2 = dv.ToTable
        Dim lcontinuar As Boolean = False
        dtControl = crearEstructuraExportar()
        Dim lsNombreCalculo, lsComentarios As String
        'ods1.Tables("control").Rows.Clear()
        'Dim drv As DataRowView
        lsNombreCalculo = String.Empty
        lsComentarios = String.Empty
        Dim pnumeroPedido As Integer

        dt2.DefaultView.RowFilter = "Agregar = True"
        If dt2.DefaultView.Count > 1 Then
            If MessageBox.Show("Esta Seguro de Agrupar los Calculos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lcontinuar = True

            End If
        ElseIf dt2.DefaultView.Count = 1 Then
            lcontinuar = True

        End If



        If lcontinuar Then

            For Each drv As DataRowView In dt2.DefaultView

                Dim ods As New DataSet

                ods.ReadXml("\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\compras$\" & drv.Item("nombre_calculo").ToString.Trim & ".xml")

                If lsNombreCalculo.Length > 0 Then
                    lsNombreCalculo &= ","
                End If
                lsNombreCalculo = lsNombreCalculo & drv.Item("nombre_calculo").ToString.Trim

                For Each dr In ods.Tables("detalle_productos").Rows
                    Try
                        If dr.Item("agregar") = True Then
                            dr_aux = dtControl.NewRow
                            dr_aux.Item("proveedor") = dr.Item("proveedor").ToString
                            dr_aux.Item("codigo_flex") = dr.Item("producto").ToString
                            dr_aux.Item("descripcion_producto") = dr.Item("glosa").ToString
                            dr_aux.Item("procedencia") = dr.Item("procedencia").ToString
                            dr_aux.Item("unidades_caja") = dr.Item("uxc").ToString
                            dr_aux.Item("fob_caja") = dr.Item("fob").ToString
                            Dim scantidad As String = Math.Round(Double.Parse(dr.Item("pedido").ToString))
                            dr_aux.Item("pedido_caja") = Integer.Parse(scantidad)
                            dr_aux.Item("pedido_unidades") = Integer.Parse(scantidad) * dr.Item("uxc")
                            dr_aux.Item("fob_total") = dr.Item("valor_sugerido").ToString
                            Try


                                dr_aux.Item("numero_registro_sanitario") = dr.Item("numero_registro").ToString
                                dr_aux.Item("fecha_registro_sanitario") = dr.Item("fecha_registro")
                            Catch ex As Exception

                            End Try


                            dtControl.Rows.Add(dr_aux)
                        End If
                    Catch ex As Exception
                    End Try
                Next
                pnumeroPedido = drv.Item("cod_calculo")

                If lsComentarios.Length > 0 Then
                    lsComentarios &= ","
                End If
                lsComentarios = llenarComentarios(pnumeroPedido)

            Next

            Dim Oaut As New Automatizar.exportar_excel
            Oaut.ocultar_columnas = ",cod_pro,"
            Oaut.Texto_Columnas = New Integer(,) {{1, 2}, {2, 2}, {3, 2}}

            Oaut.Nombre_Columnas = "," ',,,,,,,Pedido Sugerido,,Minimo Cajas,Maximo Cajas,,,," 'Ppto mes+1,transito mes+1,Saldo mes+1,Cobertura mes + 1"


            Oaut.nAgregar_Filas = 2
            Try
                Oaut.sgPiePagina = lsComentarios
            Catch ex As Exception

            End Try
            Oaut.sTitulo = lsNombreCalculo
            Oaut.DataTableToExcel(dtControl)
            Oaut = Nothing


        End If


        ClsGen = Nothing



    End Sub

    Private Function llenarComentarios(pnCodigoPedido As Integer) As String

        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim dt As DataTable
        Dim lsSQL As String
        Dim lSComentarios As String

        Try
            Otrans.open()
            lSComentarios = String.Empty 'sComentarioOriginal
            lsSQL = "pa_sel_um_inv_pedido_comentario " & pnCodigoPedido
            dt = Otrans.Obtiene(lsSQL)
            For Each dr As DataRow In dt.Rows
                lSComentarios += dr.Item("fecha_grabo").ToString & " " & dr.Item("usuario_grabo").ToString & " " & dr.Item("comentario").ToString & vbCrLf
            Next


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return lSComentarios
    End Function

    Private Sub frm_scm_preparacion_informacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VerificarSeguridad()
        Llenar_Maestros()
        Crear_Estructuras()
        Llenar_Calculos_Previos()
    End Sub


    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Obtener_Calculos()
        Me.Close()
    End Sub


    Private Sub cmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            ds_preparacion.Tables("calculos_previos").DefaultView.RowFilter = "estado = " & Me.cmbEstado.SelectedValue

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarEstado.Click

        ds_preparacion.Tables("calculos_previos").DefaultView.RowFilter = "agregar = true and estado = " & Me.cmbEstado.SelectedValue
        If ds_preparacion.Tables("calculos_previos").DefaultView.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Cambiar Estado ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cambiarEstados()
            End If

        End If



        Me.Llenar_Calculos_Previos()

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        exportar()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_filtro.TextChanged

    End Sub

    Private Sub btnAprobacion_Click(sender As Object, e As EventArgs) Handles btnAprobacion.Click
        Dim nRow As Integer

        Try
            nRow = Me.DataGridView1.CurrentCell.RowIndex
            If MessageBox.Show("Esta Seguro de Aprobar El Pedido " & Me.DataGridView1.Item("nombre_calculo", nRow).Value,
                               "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim oform As New frm_scm_aprobacion_tesoreria
                oform.giNumeroPedido = Me.DataGridView1.Item("cod_calculo", nRow).Value
                oform.gslEmpresa = Me.DataGridView1.Item("empresa", nRow).Value
                oform.txtEmpresaPedido.Text = Me.DataGridView1.Item("empresa", nRow).Value
                oform.txtNumeroPedido.Text = Me.DataGridView1.Item("cod_calculo", nRow).Value
                oform.txtObservacionesPedido.Text = Me.DataGridView1.Item("nombre_calculo", nRow).Value

                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_filtro.KeyPress
        If e.KeyChar = Chr(13) Then
            hacer_filtro()
        End If
    End Sub
    Private Sub hacer_filtro()
        Dim clsgen As New ClasesGenerales.General

        Dim ls_filtro As String
        ls_filtro = clsgen.Armar_Filtro(Me.cmb_campos.Text,
                                        "", "",
                Me.txt_filtro.Text, "", "",
                Me.cmb_operadores.Text, "", "",
                "", "")

        clsgen = Nothing

        If ls_filtro.Length > 0 Then
            ds_preparacion.Tables("calculos_previos").DefaultView.RowFilter = "estado = " & Me.cmbEstado.SelectedValue & " And " & ls_filtro

        Else
            ds_preparacion.Tables("calculos_previos").DefaultView.RowFilter = "estado = " & Me.cmbEstado.SelectedValue

        End If



    End Sub
End Class
