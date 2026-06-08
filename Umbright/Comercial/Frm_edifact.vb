Imports System.IO
'Imports Indy.Sockets.FTP

Public Class Frm_edifact
    Inherits System.Windows.Forms.Form
    Dim pdataset As New DataSet
    Public lenvio_factura As Boolean = False
    Public leface As Boolean = False

    'Dim lftp As New Indy.Sockets.FTP

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipos As System.Windows.Forms.ComboBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents SVD_Guardar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txt_status As System.Windows.Forms.TextBox
    Friend WithEvents lbl_proveedor_cliente As System.Windows.Forms.Label
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents lbl_direccion As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_tipos = New System.Windows.Forms.ComboBox
        Me.lbl_proveedor_cliente = New System.Windows.Forms.Label
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.txt_numero = New System.Windows.Forms.TextBox
        Me.lbl_numero = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_generar = New System.Windows.Forms.Button
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.lbl_direccion = New System.Windows.Forms.Label
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.SVD_Guardar = New System.Windows.Forms.SaveFileDialog
        Me.txt_status = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Detalle"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(11, 105)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(656, 368)
        Me.DataGrid1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Tipo Documento"
        '
        'cmb_tipos
        '
        Me.cmb_tipos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipos.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_tipos.Location = New System.Drawing.Point(104, 3)
        Me.cmb_tipos.Name = "cmb_tipos"
        Me.cmb_tipos.Size = New System.Drawing.Size(232, 21)
        Me.cmb_tipos.TabIndex = 6
        '
        'lbl_proveedor_cliente
        '
        Me.lbl_proveedor_cliente.Location = New System.Drawing.Point(8, 59)
        Me.lbl_proveedor_cliente.Name = "lbl_proveedor_cliente"
        Me.lbl_proveedor_cliente.Size = New System.Drawing.Size(64, 23)
        Me.lbl_proveedor_cliente.TabIndex = 13
        Me.lbl_proveedor_cliente.Text = "Proveedor"
        '
        'txt_proveedor
        '
        Me.txt_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_proveedor.Location = New System.Drawing.Point(104, 52)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(368, 21)
        Me.txt_proveedor.TabIndex = 12
        Me.txt_proveedor.TabStop = False
        '
        'txt_fecha
        '
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(368, 25)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(104, 21)
        Me.txt_fecha.TabIndex = 11
        Me.txt_fecha.TabStop = False
        '
        'txt_numero
        '
        Me.txt_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero.Location = New System.Drawing.Point(104, 28)
        Me.txt_numero.Name = "txt_numero"
        Me.txt_numero.Size = New System.Drawing.Size(120, 21)
        Me.txt_numero.TabIndex = 1
        '
        'lbl_numero
        '
        Me.lbl_numero.Location = New System.Drawing.Point(8, 35)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(88, 23)
        Me.lbl_numero.TabIndex = 10
        Me.lbl_numero.Text = "Numero Orden"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(305, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Fecha"
        '
        'btn_generar
        '
        Me.btn_generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar.Location = New System.Drawing.Point(552, 56)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(96, 24)
        Me.btn_generar.TabIndex = 3
        Me.btn_generar.Text = "Generar EdiFact"
        '
        'txt_direccion
        '
        Me.txt_direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_direccion.Location = New System.Drawing.Point(104, 78)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.ReadOnly = True
        Me.txt_direccion.Size = New System.Drawing.Size(368, 21)
        Me.txt_direccion.TabIndex = 18
        Me.txt_direccion.TabStop = False
        '
        'lbl_direccion
        '
        Me.lbl_direccion.Location = New System.Drawing.Point(8, 80)
        Me.lbl_direccion.Name = "lbl_direccion"
        Me.lbl_direccion.Size = New System.Drawing.Size(80, 23)
        Me.lbl_direccion.TabIndex = 19
        Me.lbl_direccion.Text = "Direccion"
        '
        'btn_limpiar
        '
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.Location = New System.Drawing.Point(552, 24)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(96, 23)
        Me.btn_limpiar.TabIndex = 5
        Me.btn_limpiar.Text = "Limpiar"
        '
        'txt_status
        '
        Me.txt_status.Location = New System.Drawing.Point(80, 504)
        Me.txt_status.Name = "txt_status"
        Me.txt_status.Size = New System.Drawing.Size(464, 21)
        Me.txt_status.TabIndex = 24
        Me.txt_status.Text = "TextBox1"
        '
        'Frm_edifact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(674, 477)
        Me.Controls.Add(Me.txt_status)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.lbl_direccion)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_tipos)
        Me.Controls.Add(Me.lbl_proveedor_cliente)
        Me.Controls.Add(Me.txt_proveedor)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.txt_numero)
        Me.Controls.Add(Me.lbl_numero)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_edifact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Traslado a EdiFact"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub LlenarCombo()

        Dim ls_sqlScript As String

        Dim ldt_table As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_sqlScript = "pa_sel_um_tipodocumento '" & gs_empresa & "',NULL"
        ldt_table = oTransaccion.Obtiene(ls_sqlScript)
        ldt_table.TableName = "tipos"
        pdataset.Tables.Add(ldt_table.Copy)

        If lenvio_factura Then
            ldt_table.DefaultView.RowFilter = " tipodocto like '%FACTURA%'"
        ElseIf leface Then
            ldt_table.DefaultView.RowFilter = " tipodocto like '%FACTURA%' Or tipodocto like '%DE CREDITO%' or tipodocto like '%DE DEBITO%'"
        Else
            ldt_table.DefaultView.RowFilter = " tipodocto like '%ORDEN%'"
        End If

        Me.cmb_tipos.DisplayMember = "tipoDocto"
        Me.cmb_tipos.ValueMember = "tipoDocto"
        Me.cmb_tipos.DataSource = ldt_table

        oTransaccion.close()
    End Sub

    Private Sub Hacer_Busqueda()
        Dim ls_Sql As String
        Dim dgtbc As DataGridTextBoxColumn
        Dim otabla As DataTable
        Dim clGen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        oTrans.open()

        If Me.txt_numero.Text.Length > 0 Then
            Try
                Me.txt_numero.ReadOnly = True
                Me.cmb_tipos.Enabled = False

                Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")
                ls_Sql = "pa_sel_var_encabezado_orden_compra'" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"
                otabla = oTrans.Obtiene(ls_Sql)
                Try
                    pdataset.Reset()
                Catch ex As Exception
                End Try
                otabla.TableName = "encabezado_documento"
                pdataset.Tables.Add(otabla.Copy)


                Me.txt_fecha.Text = otabla.Rows(0).Item("FECHA")
                Me.txt_proveedor.Text = otabla.Rows(0).Item("razonsocial")
                Me.txt_direccion.Text = otabla.Rows(0).Item("direccion")
                If otabla.Rows.Count > 0 Then
                    ls_Sql = "pa_sel_var_detalle_orden_compra'" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"
                    otabla = oTrans.Obtiene(ls_Sql)
                    If oTrans.Codigo_error = 0 Then
                        otabla.TableName = "detalle_documento"
                        pdataset.Tables.Add(otabla.Copy)
                        Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")

                        clGen.Alinea_Grid(pdataset.Tables("detalle_documento"), Me.DataGrid1, pdataset.Tables("detalle_documento").TableName, 0, 300, 0, False, True, "", True, "")
                    End If

                End If




                dgtbc = DataGrid1.TableStyles(0).GridColumnStyles(3)
                If Not (dgtbc Is Nothing) Then
                    dgtbc.Format = "#"  ' 0r "#.000" f3 Or c4;
                End If

                Dim i As Integer
                For i = 4 To 6
                    dgtbc = DataGrid1.TableStyles(0).GridColumnStyles(i)
                    If Not (dgtbc Is Nothing) Then
                        dgtbc.Format = "n"  ' 0r "#.000" f3 Or c4;
                    End If
                Next
                Me.DataGrid1.Refresh()
                Me.Refresh()

            Catch ex As Exception
                MessageBox.Show("No Existe Orden, Verique el Numero", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmb_tipos.Enabled = True
                Me.txt_numero.ReadOnly = False
            Finally
                oTrans.close()
                oTrans = Nothing
            End Try

        End If
    End Sub

    Private Sub Hacer_Busqueda_Factura()
        Dim ls_Sql As String
        Dim otabla As DataTable
        Dim clGen As New ClasesGenerales.General
        Dim oTrans As New Transaccional.Conexion("flexline")
        oTrans.open()


        Try
            If Me.txt_numero.Text.Length > 0 Then
                Me.txt_numero.ReadOnly = True
                Me.cmb_tipos.Enabled = False

                Me.txt_numero.Text = Me.txt_numero.Text.PadLeft(10, "0")
                ls_Sql = "pa_sel_um_documento_detalle'" & Me.cmb_tipos.Text & "','" & gs_empresa & "','" & Me.txt_numero.Text & "'"
                otabla = oTrans.Obtiene(ls_Sql)
                Try
                    pdataset.Reset()
                Catch ex As Exception
                End Try
                otabla.TableName = "encabezado_documento"
                pdataset.Tables.Add(otabla.Copy)


                Me.txt_fecha.Text = otabla.Rows(0).Item("FECHA")
                Me.txt_proveedor.Text = otabla.Rows(0).Item("razonsocial")
                ' Me.txt_direccion.Text = otabla.Rows(0).Item("direccion")
                If otabla.Rows.Count > 0 Then
                    ls_Sql = "pa_sel_um_documentod '" & gs_empresa & "','" & Me.cmb_tipos.Text & "','" & Me.txt_numero.Text & "'"
                    otabla = oTrans.Obtiene(ls_Sql)
                    If oTrans.Codigo_error = 0 Then
                        otabla.TableName = "detalle_documento"
                        pdataset.Tables.Add(otabla.Copy)
                        Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")

                        clGen.Alinea_Grid(pdataset.Tables("detalle_documento"), Me.DataGrid1, pdataset.Tables("detalle_documento").TableName, -1, 300, 0, False, True, ",producto,glosa,_unidades,_valores", True, "")
                        Me.txt_direccion.Text = otabla.Rows(0).Item("total_docto").ToString
                    End If

                End If

                Me.DataGrid1.Refresh()
                Me.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show("No Existe Factura, Verique el Numero", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmb_tipos.Enabled = True
            Me.txt_numero.ReadOnly = False
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try


    End Sub

    Private Sub Customizar_Forma()
        If lenvio_factura Then
            Me.lbl_numero.Text = "No. de Factura"
            Me.lbl_proveedor_cliente.Text = "Cliente"
            Me.lbl_direccion.Text = "Total"
            Me.txt_direccion.AutoSize = True
            Me.btn_generar.Text = "Generar Envio"
        ElseIf leface Then
            Me.btn_generar.Text = "Generar Eface"
            Me.lbl_numero.Text = "No. de Factura"
            Me.lbl_proveedor_cliente.Text = "Cliente"
            Me.lbl_direccion.Text = "Total"
            Me.txt_direccion.AutoSize = True
        End If

    End Sub

    Private Sub Enviar_Factura()

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim dt As DataTable
        Dim snombre_archivo As String
        Dim ls_sql As String

        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones(null)"
            dt = myOtrans.Obtiene(ls_sql)

            dt.DefaultView.RowFilter = "cod_flex = '" & pdataset.Tables("encabezado_documento").Rows(0).Item("cliente").ToString & "'"
            If dt.DefaultView.Count > 0 Then
                snombre_archivo = "c:\aplicaciones\log\" & Me.txt_numero.Text & ".txt"
                Generar_Txt(snombre_archivo)
                Subir_FTP_Factura(snombre_archivo, dt.DefaultView(0))
            Else
                MessageBox.Show("Este Cliente No Esta Configurado Para Estos Envios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Enviar_Factura")
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Sub

    'Private Sub Enviar_Eface_Automatizada()
    '    Dim Oaut As New Automatizar.Eface(gs_empresa)
    '    Dim nombre_archivo As String = "c:\temp\" & gs_empresa & Me.txt_numero.Text & Now.ToString("ddMMyyyyhhmmss") & ".txt"
    '    Dim icount As Integer
    '    Dim inicial As Integer



    '    Try
    '        inicial = Me.txt_numero.Text

    '        For icount = inicial - 100 To inicial
    '            Oaut.Enviar_Eface(Me.cmb_tipos.Text, icount.ToString.PadLeft(10, "0"), nombre_archivo)
    '        Next

    '        'Oaut.Enviar_Eface(Me.cmb_tipos.Text, Me.txt_numero.Text, nombre_archivo)
    '    Catch ex As Exception
    '    Finally
    '        Oaut = Nothing
    '    End Try
    'End Sub

    'Private Sub Enviar_Eface()
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim Otrans As New Transaccional.Conexion("FlexLine")
    '    Dim lexito As Boolean
    '    Dim _archivo As String = "c:\temp\" & "eface.txt"
    '    Dim linea, ls_sql As String
    '    Dim dt As DataTable
    '    Dim dr, dr_aux As DataRow
    '    Dim liunidades As Integer
    '    Dim ldpreciounitario, ldmonto, ldvolumen, ldiva, ldpreciosugerido, ldimpuestodistribucion, ldporcimpuestodistribucion As Double
    '    Dim ldtotallineas, ldtotaldescuentos, ldtotalsindescuentos, ldtotalimpuestos, ldtotalfactura, ldtotalimpuestodistribucion, ldtotaliva As Double
    '    Dim ldmontoimpuesto As Double

    '    Try
    '        Otrans.open()
    '        ls_sql = "pa_sel_um_tipodocumento '" & gs_empresa & "',NULL,'" & Me.cmb_tipos.Text & "'"
    '        dt = Otrans.Obtiene(ls_sql)

    '        linea = "</ INICIO >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "</ DATOS CFD ********************************************************************** >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "No Autorización                : 12345"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Fecha Autorización             : 20/10/2008"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Tipo                           : FACE, NCE, NDE"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Serie                          : " & dt.Rows(0).Item("SerieDocto").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Folio                          : " & Me.txt_numero.Text
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Estado                         : ORIGINAL"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Numero de Factura              : " & Me.txt_numero.Text
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Fecha Factura                  : " & Me.txt_fecha.Text
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "</ DATOS FISCALES EMISOR ********************************************************** >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

    '        ls_sql = "pa_var_um_per_empresa '" & gs_empresa & "'"
    '        dt = Otrans.Obtiene(ls_sql)
    '        dr = dt.Rows(0)

    '        linea = "Razon Social                   : " & dr.Item("razon_social").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "NIT                            : " & dr.Item("Rut").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "GLN Emisor                     : N/A"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Pais                           : GT"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Municipio                      : GT"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Lenguaje                       : ES"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Departamento                   : GT"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Calle                          : " & dr.Item("direccion").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "</ DATOS FISCALES RECEPTOR ******************************************************** >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

    '        dr = pdataset.Tables("encabezado_documento").Rows(0)

    '        ls_sql = "pa_sel_um_ctacte '" & gs_empresa & "','CLIENTE','" & dr.Item("cliente").ToString & "'"
    '        dt = Otrans.Obtiene(ls_sql)
    '        dr = dt.Rows(0)
    '        linea = "Razon Social                   : " & dr.Item("razonsocial").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "NIT                            : " & dr.Item("CodLegal").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "GLN Receptor                   : N/A" & "Analisis del Cliente"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Pais                           : " & dr.Item("pais").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Municipio                      : " & dr.Item("comuna").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Lenguaje                       : ES"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Departamento                   : " & dr.Item("estado").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Direccion                      : " & dr.Item("direccion").ToString
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "</ DETALLES *********************************************************************** >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "CODIGO                    DESCRIPCIÓN PRODUCTO                                        U. MEDIDA        CANTIDAD         MEDIDA     PRECIO UNITARIO        MONTO             FECHA ENTREGA         TIPO IMPUESTO   MONTO APLICAR IMP    MONTO IMPUESTO    PORCENTAJE IMPUESTO    PRECIO SUGERIDO  IMPUESTO DISTRIBUCION"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)

    '        ls_sql = "pa_sel_um_gen_tabcod '01','CONFIG.IMPUESTO','" & gs_empresa & "'"
    '        dt = Otrans.Obtiene(ls_sql)
    '        dr_aux = dt.Rows(0)
    '        ldiva = dr_aux.Item("valor1")
    '        ldtotallineas = 0
    '        ldtotaldescuentos = 0
    '        ldtotalsindescuentos = 0
    '        ldtotalimpuestos = 0
    '        ldtotalimpuestodistribucion = 0
    '        ldtotaliva = 0

    '        For Each dr In pdataset.Tables("detalle_documento").Rows

    '            liunidades = dr.Item("_unidades")
    '            ldpreciounitario = dr.Item("precio")
    '            ldmonto = dr.Item("total") + dr.Item("impuesto")
    '            ldvolumen = dr.Item("volumen")
    '            ldimpuestodistribucion = dr.Item("impdist")
    '            ldtotalfactura = dr.Item("total_docto")


    '            ls_sql = "pa_sel_um_gen_tabcod '" & dr.Item("tipoproducto") & "','imp_distrib','" & gs_empresa & "'"
    '            dt = Otrans.Obtiene(ls_sql)


    '            Try
    '                ldporcimpuestodistribucion = dt.Rows(0).Item("valor1")
    '            Catch ex As Exception
    '                ldporcimpuestodistribucion = 0
    '            End Try


    '            ldpreciosugerido = dr.Item("precioventa") * (1 + ldporcimpuestodistribucion) * (1 + (ldiva / 100))
    '            ldtotallineas += (dr.Item("_unidades") * dr.Item("precio")) / (1 + (ldiva / 100))
    '            ldtotaldescuentos += (dr.Item("_unidades") * dr.Item("precio") * dr.Item("PorcentajeDR")) / 100 / (1 + (ldiva / 100))
    '            ldtotalimpuestos += dr.Item("impuesto")
    '            ldtotalimpuestodistribucion += ldimpuestodistribucion

    '            ldmontoimpuesto = dr.Item("impuesto")
    '            ldtotaliva += ldmontoimpuesto

    '            linea = ""
    '            linea += dr.Item("producto").ToString.PadRight(20, " ") & _
    '                    dr.Item("glosa").ToString.PadRight(70, " ") & _
    '                    dr.Item("unidad").ToString.PadRight(15, " ") & _
    '                    liunidades.ToString("G").PadRight(15, " ") & _
    '                    ldvolumen.ToString("G5").PadRight(5, "0") & _
    '                    Space(10) & _
    '                    ldpreciounitario.ToString("F6").PadRight(20, " ") & _
    '                    ldmonto.ToString("F6").PadRight(18, " ") & _
    '                    dr.Item("fecha").ToString.PadRight(24, " ") & _
    '                    "IVA".ToString.PadRight(18, " ") & _
    '                    "100".ToString.PadRight(21, " ") & _
    '                    ldmontoimpuesto.ToString("F6").PadRight(18, " ") & _
    '                    ldiva.ToString("F6").PadRight(18, " ") & _
    '                    ldpreciosugerido.ToString("F6").PadRight(23, " ") & _
    '                   ldimpuestodistribucion.ToString("F6").PadRight(20, " ")

    '            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        Next

    '        linea = "< FIN DETALLE />"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "</ TOTALES ************************************************************************ >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Total Lineas                   : " & ldtotallineas.ToString("F6").PadLeft(20, " ")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Total Descuentos               : " & ldtotaldescuentos.ToString("F6").PadLeft(20, " ")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Total Sin Impuestos            : " & (ldtotalfactura / (1 + (ldiva / 100))).ToString("F6").PadLeft(20, " ")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Total Impuestos                : " & ldtotalimpuestos.ToString("F6").PadLeft(20, " ")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Total Impuestos                : " & ldtotalimpuestos.ToString("F6").PadLeft(20, " ")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Valor Pagar                    : " & ldtotalfactura.ToString("F6").PadLeft(20, " ")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Moneda                         : " & "QTZ".PadLeft(20, " ")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "</ IMPUESTOS ********************************************************************** >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "               TIPO    PORCENTAJE        MONTO"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Impuesto1       IVA        " & ldiva.ToString("F0").PadRight(10, " ") & ldtotaliva.ToString("F")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "Impuesto2       IMPDIST    " & Space(10) & ldtotalimpuestodistribucion.ToString("F")
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '        linea = "</ FIN DOCUMENTO >"
    '        lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
    '    Catch ex As Exception


    '    Finally
    '        ClsGen = Nothing
    '        Otrans.close()
    '        Otrans = Nothing

    '    End Try



    'End Sub

    Private Sub Generar_Txt(ByVal _archivo As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim drv As DataRowView
        Dim linea As String
        Dim lexito As Boolean = True

        Try
            linea = "|" & Me.txt_numero.Text & "|" & Me.txt_fecha.Text & "|0|1|" & Double.Parse(Me.txt_direccion.Text).ToString("###0.00") & "|"
            linea += pdataset.Tables("detalle_documento").Rows.Count.ToString & "|"
            linea += Me.cmb_tipos.Text & "---" & pdataset.Tables("detalle_documento").Rows(0).Item("comentario1")
            lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            pdataset.Tables("detalle_documento").DefaultView.Sort = "Secuencia"
            For Each drv In pdataset.Tables("detalle_documento").DefaultView
                linea = ""
                linea = "|" & Me.txt_numero.Text & "|" & drv.Item("Producto") & "|"
                linea += Double.Parse(drv.Item("_unidades")).ToString("###0.00") & "|"
                linea += Double.Parse((drv.Item("_valores") / drv.Item("_unidades")).ToString).ToString("###0.00") & "|"
                linea += drv.Item("Secuencia").ToString
                lexito = ClsGen.Escribir_texto(_archivo, linea & vbCrLf)
            Next
        Catch ex As Exception
            lexito = False
            MessageBox.Show(ex.Message)
        Finally
            If Not lexito Then
                ClsGen.Eliminar_Archivo(_archivo)
            End If
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Subir_FTP_Factura(ByVal _archivo As String, ByVal _drv As DataRowView)
        Dim propiedades(2) As String



        '        propiedades = otabla.Rows(0).Item("ftp_gerber").ToString.Split(",")
        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Copy and paste the code below into a VB WebForm or WinForm
        '  application and then do the following:
        '
        '       1).  From within the ASP.NET or WinForm app set a
        '            reference to the FTP.dll and BitOperators.dll
        '            files.
        '       2).  At the top of the application code file 
        '            (E.g WebForm1.aspx.vb or Form1.vb) type in
        '               Imports FTP
        '       3).  Compile the application and run.
        '       4).  Have fun.

        'Protected Sub TestFTP()
        Dim ff As FTP.clsFTP

        Try
            '        '-------------------------------------------
            '        ' OPTION 1
            '        ' --------
            '        '
            '        ' Create an instance of the FTP Class.
            Me.txt_status.Text = "Creando la Instancia"
            ff = New FTP.clsFTP


            ' Setup the appropriate properties.
            ff.RemoteHost = _drv.Item("host") '"gtmailmarketing.com"
            ff.RemoteUser = _drv.Item("usuario")  '"gerber@gtmailmarketing.com"
            ff.RemotePassword = _drv.Item("password") '"gerber"
            '        '-------------------------------------------

            '        '-------------------------------------------
            '        ' OPTION 2
            '        ' --------
            '        '  Pass the values into the constructor 
            '        '  instead.  These can be overridden by simply
            '        '  setting the appropriate properties on the
            '        '  instance of the clsFTP Class.
            '        ff = New clsFTP("microsoft", _
            '                        ".", _
            '                        "ftpuser", _
            '                        "password", _
            '                        21)

            '        ' Attempt to log into the FTP Server.
            'Me.txt_status.Text = "Conectando"
            If (ff.Login()) Then
                '            '
                '            ' Move the to Area1\Section1\Subby1\ directory.
                ff.ChangeDirectory(_drv.Item("carpeta_recibir").ToString)
                'ff.ChangeDirectory("Section1")

                'ff.CreateDirectory("Subby1")
                'ff.ChangeDirectory("Subby1")
                ff.SetBinaryMode(True)

                '            ' Upload a file.
                'Me.txt_status.Text = "Transfiriendo"
                ff.UploadFile(_archivo)

                '            ' Download a file.
                '            'ff.DownloadFile("secureapps.pdf", "d:\general\secureapps.pdf")

                '            ' Remove a file from the FTP Site.
                '            If (ff.DeleteFile("secureapps.pdf")) Then
                '                Response.Write("File has been removed from FTP Site")
                '                'MessageBox.Show("File has been removed from FTP Site")
                '            Else
                '                Response.Write("Unable to remove file from FTP Site.  Message from server: " & ff.MessageString & "<br>")
                '                'MessageBox.Show("Unable to remove file from FTP Site")
                '            End If

                '            ' Rename a file on the FTP Site.
                '            'If (ff.RenameFile("secureapps.pdf", "newapp.pdf")) Then
                '            '    Response.Write("File has been renamed")
                '            '    MessageBox.Show("File has been renamed")
                '            'End If

                '            'ff.ChangeDirectory("..")
                '            'If (ff.RemoveDirectory("Subby1")) Then
                '            '    Response.Write("Directory has been removed<br>")
                '            '    ' MessageBox.Show("Directory has been removed")
                '            'Else
                '            '    Response.Write("Unable to remove the directory.  Message from server: " & ff.MessageString & "<br>")
                '            '    ' MessageBox.Show("Unable to remove the directory.")
                '            'End If
            End If
            ' Me.txt_status.Text = "Finalizado Exitosamente"
            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As System.Exception            '        

            'Messagebox.Show(ex.Message)
            'MessageBox.show("Message from FTP Server was: " & ff.MessageString)
            'Me.txt_status.Text = ex.Message & "  " & ff.MessageString
            MsgBox(ex.Message)
            MsgBox("Message from FTP Server was: " & ff.MessageString)
        Finally
            '        '
            '        ' Always close down the connection to ensure that
            '        '  there are no "stray" Fido's Fetching data.  In
            '        '  other words, no stray/limbo/not-in-use FTP
            '        '  connections.
            ff.CloseConnection()
        End Try

        'statusBar1.Text=string.Format("Logging into {0} ..", txtHost.Text);


    End Sub


    Private Sub Frm_edifact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
        Customizar_Forma()
    End Sub


    Private Sub txt_numero_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.LostFocus
        If lenvio_factura Then
            Hacer_Busqueda_Factura()
        ElseIf leface Then
            Hacer_Busqueda_Factura()
        Else
            Hacer_Busqueda()
        End If
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Limpiar_Forma()
    End Sub

    Private Sub Limpiar_Forma()
        pdataset.Reset()
        Me.cmb_tipos.Enabled = True
        Me.txt_fecha.Text = ""
        Me.txt_numero.Text = ""
        Me.txt_proveedor.Text = ""
        Me.txt_direccion.Text = ""
        Me.Refresh()
        Me.DataGrid1.DataSource = pdataset.Tables("detalle_documento")
        Me.txt_numero.ReadOnly = False
        Me.txt_numero.Focus()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        If lenvio_factura Then
            Enviar_Factura()
        ElseIf leface Then
            'Enviar_Eface_Automatizada()

        Else

            Dim dr As DataRow
            Dim hacerenvio As Boolean = True

            For Each dr In pdataset.Tables("detalle_documento").Rows
                If dr.Item("ean").ToString.Length = 0 Then
                    MessageBox.Show("Producto " & dr.Item("glosa") & " Sin Codigo de Barras", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    hacerenvio = False
                End If
            Next
            If hacerenvio Then
                Me.SVD_Guardar.Filter = "Edi files (*.edi)|*.edi"
                Me.SVD_Guardar.ShowDialog()
                If Me.SVD_Guardar.FileName.Length > 0 Then
                    Hacer_Envio()
                End If
            Else
                MessageBox.Show("No se Hara el Envio, Por que Hay Productos Sin Codigo de Barras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Hacer_Envio()
        '2Th 3:3  Pero fiel es el Señor quien os fortalecerá y protegerá del maligno. 

        Dim linea As String
        Dim icount As Integer
        Dim i_segmentos As Integer

        Dim dr, drc As DataRow
        Dim dte, otabla As DataTable
        dte = pdataset.Tables("encabezado_documento")

        Dim otrans As New Transaccional.Conexion_mysql("OnBase")
        otrans.open()
        otabla = otrans.Obtiene("call pa_var_um_edi_correlativos('gerber')")
        otrans.close()
        otrans = Nothing

        drc = otabla.Rows(0)
        Try


            'Cabecera del Intercambio
            linea = "UNB+UNOA:2+CODICASA:ZZ+GERBERCR:ZZ+" & Format(Now, "yyMMdd") & ":" & Now.ToLongTimeString.Replace(":", "").Substring(0, 4) & "+" & _
            drc("correlativo").ToString
            Escribir_Archivo(linea)


            'Cabecera del Mensaje
            linea = "UNH+" & drc("correlativo").ToString.Trim & "+ORDERS:D:96A:UN"
            Escribir_Archivo(linea)

            'Inicio del Mensaje
            linea = "BGM+220+" & Int32.Parse(Me.txt_numero.Text).ToString.Trim & "+9"
            Escribir_Archivo(linea)


            'Fecha de Orden de Compra
            linea = "DTM+137:" & Format(Date.Parse(dte.Rows(0)("fecha").ToString), "yyyyMMdd") & ":102"
            Escribir_Archivo(linea)

            'Fecha de Entrega
            linea = "DTM+002:" & Format(Date.Parse(dte.Rows(0)("fechavcto").ToString), "yyyyMMdd") & ":102"
            Escribir_Archivo(linea)

            linea = "FTX+PUR+++"
            Escribir_Archivo(linea)

            linea = "RFF+CT:" & Int32.Parse(Me.txt_numero.Text).ToString
            Escribir_Archivo(linea)

            'Nombre a quien se Factura
            linea = "NAD+IV+020:92+" & "CODICASA "
            Escribir_Archivo(linea)

            'Informacion de Proveedor
            linea = "NAD+SU+89:92+" & dte.Rows(0)("direccion") & ":+" & dte.Rows(0)("razonsocial") & "++++11570"
            Escribir_Archivo(linea)

            'Informacion Nuestra
            linea = "NAD+ST+2100015:92+" & "4ta. Calle 0-74 Zona 13, Pamplona, Guatemala, C.A" & ":+" & "CODICASA" & "++++" & "1145"
            Escribir_Archivo(linea)

            'Informacion Transportista
            linea = "NAD+CA+++++++"
            Escribir_Archivo(linea)

            'Terminos de pago
            linea = "PAT+22++5:3:D:0"
            Escribir_Archivo(linea)

            linea = "ALC+A"
            Escribir_Archivo(linea)

            linea = "PCD+12:0"
            Escribir_Archivo(linea)

            icount = 0
            For Each dr In pdataset.Tables("detalle_documento").Rows
                icount = icount + 1
                linea = "LIN+" & icount.ToString & "++" & dr.Item("ean") & ":UN" 'Identificacion del producto con ean
                Escribir_Archivo(linea)

                linea = "PIA+5+:SA+:IN+:GB" 'En todas las lineas va lo mismo
                Escribir_Archivo(linea)

                linea = "IMD+++:::" & dr.Item("glosa").ToString.Trim 'descripcion del producto
                Escribir_Archivo(linea)

                linea = "QTY+21:" & Format(Convert.ToDecimal(dr.Item("cantidad").ToString), "#0.00").ToString & ":CJ" 'cantidad
                Escribir_Archivo(linea)

                linea = "MOA+203:" & Format(Convert.ToDecimal(dr.Item("neto").ToString), "#0.00").ToString 'precio total por linea
                Escribir_Archivo(linea)

                linea = "PRI+AAF:" & Format(Convert.ToDecimal(dr.Item("precio_unitario").ToString), "#0.00").ToString 'precio unitario por linea
                Escribir_Archivo(linea)

                linea = "RFF+CS" 'En todas las lineas va lo mismo
                Escribir_Archivo(linea)

                linea = "DTM+ZZZ:000" 'En todas las lineas va lo mismo
                Escribir_Archivo(linea)

                linea = "PAC+" & IIf(dr.Item("unidadalt") = dr.Item("unidadingreso"), Format(Convert.ToDecimal(dr.Item("factor_alterno").ToString), "#").ToString, "+") & "++"
                Escribir_Archivo(linea)

                linea = "ALC+A" 'En Todas la Lineas va lo mismo
                Escribir_Archivo(linea)

                linea = "QTY+192:0" 'En Todas las Lineas va lo mismo
                Escribir_Archivo(linea)

                linea = "PCD+12:0.0000" 'En Todas las Lineas va lo mismo
                Escribir_Archivo(linea)
            Next

            'Separar Detalle de Resumen
            linea = "UNS+S"
            Escribir_Archivo(linea)

            'No de Lineas
            linea = "CNT+2:" & icount.ToString
            Escribir_Archivo(linea)

            i_segmentos = 15 + (12 * icount) + 3
            '
            linea = "UNT+" & i_segmentos.ToString & "+" & drc("correlativo").ToString
            Escribir_Archivo(linea)

            'fin del mensaje
            linea = "UNZ+1+" & drc("correlativo").ToString
            Escribir_Archivo(linea)
            ' MessageBox.Show("Archivo Generado Satisfactoriamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            otrans = New Transaccional.Conexion_mysql("OnBase")
            otrans.open()

            linea = "call pa_ins_um_edi_transmisiones (" & drc("correlativo").ToString & "," & drc("cod_configuracion").ToString & ",'" & _
                     Me.txt_numero.Text & "'," & icount.ToString & ",'" & gs_usuario & "')"

            otrans.Ingresa(linea)
            otrans.close()
            otrans = Nothing

            Subir_FTP()
        Catch ex As Exception
            MessageBox.Show("Se Generaron los Siguientes Errores " & ex.Message)
        End Try

    End Sub

    Public Sub Escribir_Archivo(ByVal strsql As String)
        Dim myStreamWriter As StreamWriter
        '     Dim bytes As Long
        myStreamWriter = File.AppendText(Me.SVD_Guardar.FileName)
        '        bytes = myStreamWriter.BaseStream.Length
        'cuando el tamaño sobrepasa 1MB elimino el archivo
        '  If bytes > (1024 * 1024) Then
        ' Try
        ' myStreamWriter.Close()
        ' File.Delete("c:\log.txt")
        'myStreamWriter = File.AppendText("c:\log.txt")
        'Catch ex As Exception
        'End Try
        'End If

        ' Write the entire contents of the txtFileText text box
        '   to the StreamWriter in one shot.
        myStreamWriter.Write(Trim(strsql) + "'" + vbCrLf)
        ' Flush the stream to ensure everything is flushed
        myStreamWriter.Flush()
        myStreamWriter.Close()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Private Sub Subir_FTP()
        Dim propiedades(2) As String

        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion_mysql("onBase")


        otrans.open()
        otabla = otrans.Obtiene("call pa_sel_um_edi_configuraciones('gerber')")
        otrans.close()
        otrans = Nothing


        '        propiedades = otabla.Rows(0).Item("ftp_gerber").ToString.Split(",")
        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Copy and paste the code below into a VB WebForm or WinForm
        '  application and then do the following:
        '
        '       1).  From within the ASP.NET or WinForm app set a
        '            reference to the FTP.dll and BitOperators.dll
        '            files.
        '       2).  At the top of the application code file 
        '            (E.g WebForm1.aspx.vb or Form1.vb) type in
        '               Imports FTP
        '       3).  Compile the application and run.
        '       4).  Have fun.

        'Protected Sub TestFTP()
        Dim ff As FTP.clsFTP

        Try
            '        '-------------------------------------------
            '        ' OPTION 1
            '        ' --------
            '        '
            '        ' Create an instance of the FTP Class.
            Me.txt_status.Text = "Creando la Instancia"
            ff = New FTP.clsFTP


            ' Setup the appropriate properties.
            ff.RemoteHost = otabla.Rows(0)("host") '"gtmailmarketing.com"
            ff.RemoteUser = otabla.Rows(0)("usuario")  '"gerber@gtmailmarketing.com"
            ff.RemotePassword = otabla.Rows(0)("password") '"gerber"
            '        '-------------------------------------------

            '        '-------------------------------------------
            '        ' OPTION 2
            '        ' --------
            '        '  Pass the values into the constructor 
            '        '  instead.  These can be overridden by simply
            '        '  setting the appropriate properties on the
            '        '  instance of the clsFTP Class.
            '        ff = New clsFTP("microsoft", _
            '                        ".", _
            '                        "ftpuser", _
            '                        "password", _
            '                        21)

            '        ' Attempt to log into the FTP Server.
            Me.txt_status.Text = "Conectando"
            If (ff.Login()) Then
                '            '
                '            ' Move the to Area1\Section1\Subby1\ directory.
                ff.ChangeDirectory(otabla.Rows(0)("Carpeta").ToString)
                'ff.ChangeDirectory("Section1")

                'ff.CreateDirectory("Subby1")
                'ff.ChangeDirectory("Subby1")
                ff.SetBinaryMode(True)

                '            ' Upload a file.
                Me.txt_status.Text = "Transfiriendo"
                ff.UploadFile(Me.SVD_Guardar.FileName)

                '            ' Download a file.
                '            'ff.DownloadFile("secureapps.pdf", "d:\general\secureapps.pdf")

                '            ' Remove a file from the FTP Site.
                '            If (ff.DeleteFile("secureapps.pdf")) Then
                '                Response.Write("File has been removed from FTP Site")
                '                'MessageBox.Show("File has been removed from FTP Site")
                '            Else
                '                Response.Write("Unable to remove file from FTP Site.  Message from server: " & ff.MessageString & "<br>")
                '                'MessageBox.Show("Unable to remove file from FTP Site")
                '            End If

                '            ' Rename a file on the FTP Site.
                '            'If (ff.RenameFile("secureapps.pdf", "newapp.pdf")) Then
                '            '    Response.Write("File has been renamed")
                '            '    MessageBox.Show("File has been renamed")
                '            'End If

                '            'ff.ChangeDirectory("..")
                '            'If (ff.RemoveDirectory("Subby1")) Then
                '            '    Response.Write("Directory has been removed<br>")
                '            '    ' MessageBox.Show("Directory has been removed")
                '            'Else
                '            '    Response.Write("Unable to remove the directory.  Message from server: " & ff.MessageString & "<br>")
                '            '    ' MessageBox.Show("Unable to remove the directory.")
                '            'End If
            End If
            Me.txt_status.Text = "Finalizado Exitosamente"
            MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As System.Exception            '        

            'Messagebox.Show(ex.Message)
            'MessageBox.show("Message from FTP Server was: " & ff.MessageString)
            Me.txt_status.Text = ex.Message & "  " & ff.MessageString
            MsgBox(ex.Message)
            MsgBox("Message from FTP Server was: " & ff.MessageString)
        Finally
            '        '
            '        ' Always close down the connection to ensure that
            '        '  there are no "stray" Fido's Fetching data.  In
            '        '  other words, no stray/limbo/not-in-use FTP
            '        '  connections.
            ff.CloseConnection()
        End Try

        'statusBar1.Text=string.Format("Logging into {0} ..", txtHost.Text);


    End Sub

    Private Sub txt_numero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero.TextChanged

    End Sub

   
End Class
