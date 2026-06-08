Imports System.Data
Imports System.Data.SQLite
Imports System.IO
Imports System.Math
Imports System.Net
Imports System.Threading
Imports Umbral_Flex






Public Class frm_sincronizacion
    Inherits System.Windows.Forms.Form

    Dim dtprocesos As DataTable
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblVersion As Label
    Dim ods4 As New DataSet
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
    Friend WithEvents cmb_salir As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_sincronizacion))
        Me.cmb_salir = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'cmb_salir
        '
        Me.cmb_salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmb_salir.Location = New System.Drawing.Point(171, 230)
        Me.cmb_salir.Name = "cmb_salir"
        Me.cmb_salir.Size = New System.Drawing.Size(75, 23)
        Me.cmb_salir.TabIndex = 1
        Me.cmb_salir.Text = "&Salir"
        '
        'lbl
        '
        Me.lbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl.Location = New System.Drawing.Point(8, 8)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(264, 106)
        Me.lbl.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(83, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Reanudar"
        '
        'Timer1
        '
        Me.Timer1.Interval = 100000
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(5, 192)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(39, 13)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Label1"
        '
        'frm_sincronizacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 265)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cmb_salir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_sincronizacion"
        Me.Text = ":: Obtener Informacion ::"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub Crear_Estructura()
        dtprocesos = New DataTable
    End Sub



    Private Function CrearTablas()

        Dim oTransCE As New Transaccional.Conexion_CE("mv_Umbright_Mobile")
        Try
            'oTransCE.Compactar_Base_de_Datos()
            oTransCE.abrir()
            oTransCE.Ingresa("create table mov_encuesta(empresa nvarchar(25), " &
                                             "cod_encuesta int, nombre_encuesta nvarchar(50),descripcion nvarchar(100), " &
                                             "fecha_inicio datetime, fecha_final datetime )")


            oTransCE.Ingresa("create table mov_encuesta_usuario(empresa nvarchar(25), " &
                                             "cod_encuesta int, usuario nvarchar(50))")

            oTransCE.Ingresa("create table mov_encuesta_modelo_encabezado(empresa nvarchar(25), " &
                                 "cod_encuesta int, descripcion nvarchar(50), " &
                                 "label_valor1 nvarchar(50), label_valor2 nvarchar(50), label_valor3 nvarchar(50), " &
                                 "label_valor4 nvarchar(50), label_valor5 nvarchar(50))")


            oTransCE.Ingresa("create table mov_encuesta_modelo_detalle(empresa nvarchar(25), " &
                                 "cod_encuesta int, cod_pregunta int, descripcion nvarchar(50), cod_tipo_pregunta int)")


            oTransCE.Ingresa("create table mov_encuesta_modelo_detalle_alternativa(empresa nvarchar(25), " &
                                 "cod_encuesta int, cod_pregunta int,  cod_alternativa int, descripcion nvarchar(50))")



            oTransCE.Ingresa("create table mov_encuesta_resultado_encabezado(empresa nvarchar(25), " &
                                 "cod_encuesta int, cod_resultado int, usuario_grabo nvarchar(25), fecha_usuario_grabo datetime, " &
                                 "resultado1 nvarchar(50), resultado2 nvarchar(50), resultado3 nvarchar(50), " &
                                 "resultado4 nvarchar(50), resultado5 nvarchar(50), estado int)")

            oTransCE.Ingresa("create table mov_encuesta_resultado_detalle_alternativa(empresa nvarchar(25), " &
                                 "cod_encuesta int, cod_resultado int, cod_pregunta int,  cod_alternativa int, resultado nvarchar(50))")






        Catch ex As Exception
        Finally
            oTransCE.cerrar()
            oTransCE = Nothing
        End Try
        Return True
    End Function



    Private Sub Obtener_Pedidos_Tekne_Mobile_SE()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "tipo = 'Tekne Mobile Standard Edition'"

            For Each drv In dt.DefaultView
                ObtenerPedidos_Tekne_Vendedor(drv, dt.DefaultView)
                Exit For
            Next

            ls_sql = "call pa_upd_um_pg_procesos_isf (7)"
            myOtrans.Actualiza(ls_sql)

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_MySysgold " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub


    Private Sub Obtener_Pedidos_Tekne_Mobile_tekne()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "tipo = 'Tekne Mobile Enterprise'"

            For Each drv In dt.DefaultView
                ObtenerPedidos_Tekne_Vendedor_SitioTekne(drv, dt.DefaultView)
                Exit For
            Next

            dt.DefaultView.RowFilter = "tipo = 'Tekne Mobile Standard Edition'"

            For Each drv In dt.DefaultView
                ObtenerPedidos_Tekne_Vendedor_SitioTekne(drv, dt.DefaultView)
                Exit For
            Next


            'ls_sql = "call pa_upd_um_pg_procesos_isf (7)"
            'myOtrans.Actualiza(ls_sql)

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_MySysgold " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Obtener_informacion_transporte_mobile()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "tipo = 'Tekne Mobile Enterprise Transporte'"


            For Each drv In dt.DefaultView
                ObtenerPedidos_Tekne_Vendedor(drv, dt.DefaultView)
                Exit For
            Next

            ls_sql = "call pa_upd_um_pg_procesos_isf (7)"
            myOtrans.Actualiza(ls_sql)

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_MySysgold " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Obtener_informacion_transporte_mobile_tekne()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "tipo = 'Tekne Mobile Enterprise Transporte'"


            For Each drv In dt.DefaultView
                ObtenerPedidos_Tekne_Vendedor_SitioTekne(drv, dt.DefaultView)
                Exit For
            Next

            ls_sql = "call pa_upd_um_pg_procesos_isf (7)"
            myOtrans.Actualiza(ls_sql)

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_MySysgold " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub procesarCambiosPrecios(ByVal piCodProceso As Integer)
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim sinc As New Sincronizacion.Productos("")
        Dim lsSQL As String
        Dim dt, dtSolicitudes As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try

            Otrans.open()

            ''Creo La Estructura para Los Productos Nuevos
            lsSQL = "pa_var_um_listaprecioD 'DMARTE1', ''"
            Dim dt_info As DataTable = Otrans.Obtiene(lsSQL)

            lsSQL = "scm..pa_var_um_producto_solicitud_precio_procesable"
            dt = Otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows
                If dr.Item("dias_para_procesar") <= 1 Then

                    If dr.Item("precioOriginal") > 0 Then


                        lsSQL = "pa_upd_um_precio_producto_listaPrecioD '" & dr.Item("empresa") & "', " &
                                                   dr.Item("idlisprecio") & ", " & dr.Item("precio_nuevo") &
                                                   ", '" & dr.Item("producto") & "','" & dr.Item("usuario_solicito") & "','" & "Solicitud No. " & dr.Item("numero_solicitud") & "'"
                        Otrans.Actualiza(lsSQL)
                        If Otrans.Codigo_error = 0 Then
                            lsSQL = "scm..pa_upd_um_precio_producto_detalle_operado " & dr.Item("id_solicitud") & ",'" & dr.Item("producto") & "'"
                            Otrans.Actualiza(lsSQL)
                            Otrans.Escribir_Log(lsSQL)
                        End If
                    Else

                        Try

                            'se debe Insertar
                            dt_info.Rows.Clear()

                            Dim mNewRow As DataRow = dt_info.NewRow

                            mNewRow("Empresa") = dr.Item("empresa")
                            mNewRow("IdLisPrecio") = dr.Item("idlisprecio")
                            mNewRow("Producto") = dr.Item("producto")
                            mNewRow("Valor") = dr.Item("precio_nuevo")
                            mNewRow("Moneda") = dato_listaPrecioD("moneda", dr.Item("idlisprecio"), dr.Item("empresa"))
                            mNewRow("lisPrecio") = dr.Item("listaprecio")
                            mNewRow("PorcMaxDesc") = 0.0
                            mNewRow("Intervalo") = 0.0
                            mNewRow("PorcentajeInt") = 0.0
                            mNewRow("Cantidad") = 0.0
                            mNewRow("Tipo") = ""
                            mNewRow("ValorC") = 0.0
                            mNewRow("FechaVigencia") = CType(dato_listaPrecioD("FechaVigencia", dr.Item("idlisprecio"), dr.Item("empresa")), DateTime)
                            mNewRow("fec_final") = CType(dato_listaPrecioD("fec_final", dr.Item("idlisprecio"), dr.Item("empresa")), DateTime)
                            mNewRow("Origen") = "Solicitud No. " & dr.Item("numero_solicitud")
                            mNewRow("ValorOrigen") = 0.0
                            mNewRow("ValorPOrigen") = 0.0
                            mNewRow("UserModif") = dr.Item("usuario_solicito")
                            mNewRow("FechaModif") = Now
                            mNewRow("Efecto") = ""
                            mNewRow("PorcMaxDesc1") = 0.0
                            mNewRow("PorcMaxDesc2") = 0.0
                            mNewRow("PorcMaxDesc3") = 0.0
                            mNewRow("PorcMaxDesc4") = 0.0
                            mNewRow("PorcMaxDesc5") = 0.0

                            dt_info.Rows.Add(mNewRow)
                            sinc.Actualizar_ProductoPrecio(dt_info, False)
                            If sinc.codigo_error = 0 Then
                                lsSQL = "scm..pa_upd_um_precio_producto_detalle_operado " & dr.Item("id_solicitud") & ",'" & dr.Item("producto") & "'"
                                Otrans.Actualiza(lsSQL)

                            End If
                        Catch ex As Exception

                        End Try

                    End If 'precio Original

                End If  ''Dias Para Procesar
            Next

            dtSolicitudes = clsGen.ValoresDistinto(dt, "id_solicitud".Split(","))
            For Each dr As DataRow In dtSolicitudes.Rows
                lsSQL = "scm..pa_upd_um_producto_solicitud_precio_operado " & dr.Item("id_solicitud") & ",'ADMIN_ISF'"
                Otrans.Actualiza(lsSQL)
            Next

            sinc.Cerrar()
            sinc = Nothing

            clsGen.Escribir_Log("Finaliza Revision de Precios")
            'Return True
        Catch ex As Exception
            'Return False
        Finally
            Otrans.close()
            Otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Function dato_listaPrecioD(ByVal columna As String, ByVal codigo_lista As Integer, ByVal psEmpresa As String) As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_datos_lista_precioD '" & psEmpresa & "', " & codigo_lista
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(columna).ToString
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return True
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Function



    Private Sub procesarDevolucionesyRechazos(ByVal piCodProceso As Integer)
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt, dtaux As DataTable
        Dim clsGen As New ClasesGenerales.General

        Try
            otrans.open()
            myOtrans.open()
            dt = otrans.Obtiene("scm..pa_var_um_devolucion_recepcion")
            'dtaux = clsGen.ValoresDistinto(dt, "empresa,numero".Split(","))


            For Each dr As DataRow In dt.Rows

                'dt.DefaultView.RowFilter = "cod_devolucion = " & dr.Item("cod_devolucion")
                'dt.DefaultView.Sort = "linea"
                'dtFactura = otrans.Obtiene("pa_var_um_documento '" & dt.DefaultView(0).Item("empresa") & "','" & dt.DefaultView(0).Item("tipodocto") & "','" & dt.DefaultView(0).Item("nodocto") & "'")
                'ProcesaDevolucion(dt.DefaultView.ToTable, dtFactura, otrans)

                Try
                    If dr.Item("operado_isf").ToString.Length = 0 Then

                        dt = otrans.Obtiene("pa_var_um_devolucion " & dr.Item("numero"))
                        'ProcesaDevolucion(dt, otrans)
                    End If
                Catch ex As Exception

                End Try
            Next


            dt = otrans.Obtiene("scm..pa_var_um_rechazo_procesar")
            dtaux = clsGen.ValoresDistinto(dt, "empresa,tipodocto,numero".Split(","))
            For Each dr As DataRow In dtaux.Rows
                ' dtFactura = otrans.Obtiene("pa_var_um_documento '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("nodocto") & "'")
                Try
                    dt = otrans.Obtiene("scm..pa_var_um_rechazod  '" & dr.Item("empresa") & "','" & dr.Item("tipodocto") & "','" & dr.Item("numero") & "'")
                    'ProcesaRechazo(dt, otrans)
                Catch ex As Exception
                End Try
                'Liberar Documento Previo
                'Envio a Tiendas (No Enviar)
                'Cambiar Estado
            Next

            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & piCodProceso.ToString & ")")
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Sub


    'Private Function ProcesaRechazo(ByVal dt As DataTable, ByVal Otrans As Transaccional.Conexion) As Boolean


    '    Dim Oflex As New Umbral_Flex.Pedidos(False, True)

    '    Oflex.Validar_Totales = False


    '    Dim osinc As New Sincronizacion.Recepcion_Informacion_PDA()

    '    Dim dr, ofila As DataRow
    '    Dim li_linea As Integer = 0
    '    Dim ls_pedido_generado As Integer = 0
    '    Dim s_empresa As String = String.Empty
    '    Dim proceso_exitoso As Boolean = False
    '    Dim pd_total_pedido As Double = 0
    '    Dim forma_pago As String = String.Empty
    '    Dim sTipoDocto As String
    '    Dim drEncabezado As DataRow
    '    Dim ods As New DataSet
    '    Dim lsSQL As String

    '    drEncabezado = dt.Rows(0)
    '    s_empresa = drEncabezado.Item("empresa").ToString

    '    If s_empresa = "DMARTE1" Then
    '        sTipoDocto = "DEVOLUCIONES MERCADERIA"
    '    ElseIf s_empresa = "CODICASA" Then
    '        sTipoDocto = "DEVOLUCION DE MERCADERIA"
    '    ElseIf s_empresa = "DIUVA" Then
    '        sTipoDocto = "DEVOLUCION DE MERCADERIA"
    '    ElseIf s_empresa = "VINOTECA" Then
    '        sTipoDocto = "DEVOLUCION DE MERCADERIA"
    '    End If
    '    'forma_pago = drEncabezado.Item("forma_pago").ToString

    '    osinc.Llenar_Auxiliares(ods, drEncabezado.Item("ctacte"), s_empresa)
    '    osinc = Nothing

    '    dr = Oflex.ods.Tables("encabezado").NewRow
    '    ' pd_total_pedido = drEncabezado.Item("total_devolucion").ToString

    '    dr.Item("Empresa") = s_empresa
    '    dr.Item("tipodocto") = sTipoDocto
    '    dr.Item("correlativo") = 0
    '    dr.Item("CtaCte") = String.Empty
    '    dr.Item("numero") = ""
    '    dr.Item("fecha") = Today.ToString("dd-MM-yyyy")
    '    dr.Item("proveedor") = String.Empty
    '    dr.Item("cliente") = drEncabezado.Item("ctacte")
    '    dr.Item("bodega") = drEncabezado.Item("bodega")
    '    dr.Item("bodega2") = String.Empty
    '    dr.Item("local") = String.Empty
    '    dr.Item("comprador") = String.Empty
    '    dr.Item("vendedor") = ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
    '    dr.Item("CentroCosto") = String.Empty
    '    dr.Item("fechaVcto") = "01/01/1900"
    '    dr.Item("listaPrecio") = drEncabezado.Item("listaprecio").ToString
    '    'dr.Item("Analisis") = "piloto"
    '    dr.Item("Zona") = String.Empty
    '    dr.Item("tipocta") = "VEHICULO PENDIENTE"
    '    dr.Item("moneda") = ods.Tables("flexline_configuracion").Rows(0).Item("texto")
    '    dr.Item("paridad") = 1
    '    dr.Item("neto") = 0
    '    dr.Item("subtotal") = 0
    '    dr.Item("total") = pd_total_pedido
    '    dr.Item("NetoIngreso") = 0
    '    dr.Item("SubTotalIngreso") = 0
    '    dr.Item("TotalIngreso") = 0
    '    dr.Item("centraliza") = String.Empty
    '    dr.Item("valoriza") = String.Empty
    '    dr.Item("costeo") = String.Empty
    '    dr.Item("aprobacion") = "P" '(c) A partir del 02 de Mayo 2014
    '    dr.Item("TipoComprobante") = String.Empty
    '    dr.Item("PeriodoLibro") = Today.ToString("yyyyMM")
    '    dr.Item("FactorMonto") = 0
    '    dr.Item("TipoCtaCte") = "CLIENTE"
    '    dr.Item("IdCtaCte") = drEncabezado.Item("ctacte")
    '    dr.Item("Glosa") = drEncabezado.Item("TipoDoctoFactura") & "-" & drEncabezado.Item("NumeroFactura") 'Validar Glosa
    '    dr.Item("comentario1") = drEncabezado.Item("comentario1").ToString
    '    dr.Item("comentario2") = String.Empty
    '    dr.Item("vigencia") = "S"
    '    dr.Item("Emitido") = "N"
    '    dr.Item("PorcentajeAsignado") = 0
    '    dr.Item("direccion") = drEncabezado.Item("direccion").ToString
    '    dr.Item("ciudad") = String.Empty
    '    dr.Item("comuna") = String.Empty
    '    dr.Item("EstadoDir") = String.Empty
    '    dr.Item("pais") = String.Empty
    '    dr.Item("contacto") = String.Empty
    '    dr.Item("FechaModif") = Now
    '    dr.Item("FechaUModif") = Now
    '    dr.Item("UsuarioModif") = "Admin"
    '    dr.Item("Hora") = Now.ToString("HH:mm:ss")
    '    dr.Item("NetoBimoneda") = 0
    '    dr.Item("SubTotalBimoneda") = 0
    '    dr.Item("TotalBimoneda") = 0
    '    dr.Item("ParidadBimoneda") = 1
    '    dr.Item("AnalisisE1") = String.Empty
    '    dr.Item("AnalisisE2") = String.Empty
    '    dr.Item("AnalisisE3") = String.Empty
    '    dr.Item("UsuarioAprueba") = String.Empty
    '    dr.Item("referenciaexterna") = "0" 'drEncabezado.Item("correlativo") //Rechazos No Aplica

    '    Try
    '        Dim dtPiloto As DataTable
    '        dtPiloto = Otrans.Obtiene("pa_var_um_documento_guia_transporte  '" & s_empresa & "','" & drEncabezado.Item("TipoDoctoFactura") & "','" & drEncabezado.Item("NumeroFactura") & "'")

    '        If dtPiloto.Rows.Count > 0 Then
    '            dr.Item("Analisis") = dtPiloto.Rows(0).Item("piloto")
    '            dr.Item("TipoCta") = dtPiloto.Rows(0).Item("TipoCta")
    '        End If
    '    Catch ex As Exception

    '    End Try





    '    Oflex.ods.Tables("encabezado").Rows.Add(dr)


    '    ''DocumentoV
    '    '  dr = Oflex.ods.Tables("documentov").NewRow
    '    ' dr.Item("total") = pd_total_pedido
    '    'dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
    '    'Oflex.ods.Tables("documentov").Rows.Add(dr)



    '    'lsSQL = "pa_var_um_devolucion_factura_producto " & dt.Rows(0).Item("cod_devolucion")
    '    '    Dim dtDetalle As DataTable
    '    '     dtDetalle = Otrans.Obtiene(lsSQL)


    '    '      Dim drv As DataRowView
    '    Dim iCount As Integer = 0

    '    Dim ldSubTotal As Double = 0
    '    ''DocumentoD
    '    For Each ofila In dt.Rows
    '        '            dtDetalle.DefaultView.RowFilter = "numero = '" & ofila.Item("numero") & "' and  producto ='" & ofila.Item("producto") & "' and lote = '" & ofila.Item("lote") & "'"
    '        '           drv = dtDetalle.DefaultView(0)

    '        iCount += 1
    '        dr = Oflex.ods.Tables("detalle").NewRow

    '        dr.Item("Empresa") = s_empresa
    '        dr.Item("tipodocto") = sTipoDocto
    '        dr.Item("Secuencia") = iCount 'ofila.Item("secuenciaFactura") 'iCount
    '        dr.Item("Linea") = iCount 'ofila.Item("secuenciaFactura") 'iCount
    '        dr.Item("Producto") = ofila.Item("productoRechazo")
    '        dr.Item("Cantidad") = ofila.Item("cantidadRechazo")
    '        dr.Item("Precio") = ofila.Item("precioFactura") ''Precio de La factura Original
    '        dr.Item("PorcentajeDr") = ofila.Item("PorcentajeDRFactura")
    '        dr.Item("SubTotal") = dr.Item("cantidad") * dr.Item("precio")
    '        dr.Item("Impuesto") = 0
    '        dr.Item("Neto") = dr.Item("SubTotal")
    '        dr.Item("DRGlobal") = 0
    '        Try
    '            dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
    '        Catch ex As Exception
    '            dr.Item("Costo") = 0
    '        End Try
    '        'dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
    '        dr.Item("Total") = dr.Item("Neto")
    '        dr.Item("PrecioAjustado") = dr.Item("precio")
    '        dr.Item("UnidadIngreso") = "UN"
    '        dr.Item("CantidadIngreso") = ofila.Item("cantidadRechazo")
    '        dr.Item("PrecioIngreso") = dr.Item("precio")
    '        dr.Item("SubTotalIngreso") = dr.Item("Total")
    '        dr.Item("ImpuestoIngreso") = 0
    '        dr.Item("NetoIngreso") = dr.Item("SubTotalIngreso")
    '        dr.Item("DRGlobalIngreso") = 0
    '        dr.Item("TotalIngreso") = dr.Item("Total")
    '        dr.Item("Lote") = ofila.Item("lote")
    '        dr.Item("fechavcto") = ofila.Item("fechavcto")
    '        dr.Item("TipoDoctoOrigen") = ofila.Item("TipoDoctoFactura")
    '        dr.Item("CorrelativoOrigen") = ofila.Item("correlativoFactura")
    '        dr.Item("SecuenciaOrigen") = ofila.Item("secuenciaFactura")
    '        dr.Item("Bodega") = ofila.Item("bodega")
    '        dr.Item("FactorInventario") = 1
    '        dr.Item("FechaEntrega") = Today
    '        dr.Item("CantidadAsignada") = 0
    '        dr.Item("Fecha") = Today
    '        dr.Item("comentario") = String.Empty
    '        dr.Item("Vigente") = "S"

    '        dr.Item("CUP") = dr.Item("costo")
    '        dr.Item("Ubicacion") = "PRINCIPAL"
    '        dr.Item("Ubicacion2") = "PRINCIPAL"
    '        dr.Item("cuenta") = String.Empty
    '        dr.Item("FactorImpto") = 1
    '        dr.Item("PrecioBimoneda") = dr.Item("precio")
    '        dr.Item("SubTotalBimoneda") = dr.Item("subtotal")
    '        dr.Item("ImpuestoBimoneda") = 0
    '        dr.Item("NetoBimoneda") = dr.Item("Neto")
    '        dr.Item("DrGlobalBimoneda") = 0
    '        dr.Item("TotalBimoneda") = dr.Item("Total")
    '        dr.Item("PrecioListaP") = ofila.Item("precioListaP")
    '        dr.Item("UniMedDynamic") = 0 'dr.Item("cantidad")
    '        dr.Item("FechaVigenciaLp") = ofila.Item("FechaVigenciaLp")
    '        dr.Item("LoteDestino") = String.Empty
    '        dr.Item("SerieDestino") = String.Empty
    '        dr.Item("ProdAlias") = String.Empty
    '        dr.Item("DoctoOrigenVal") = "S"
    '        dr.Item("MontoAsignado") = 0
    '        dr.Item("Aux_Valor13") = ofila.Item("cod_motivo")

    '        dr.Item("ValPorcentajeDr1") = 0
    '        dr.Item("ValPorcentajeDr2") = 0
    '        dr.Item("ValPorcentajeDr3") = 0
    '        dr.Item("ValPorcentajeDr4") = 0
    '        dr.Item("ValPorcentajeDr5") = 0
    '        dr.Item("ValPorcentajeDr1Ingreso") = 0
    '        dr.Item("ValPorcentajeDr2Ingreso") = 0
    '        dr.Item("ValPorcentajeDr3Ingreso") = 0
    '        dr.Item("ValPorcentajeDr4Ingreso") = 0
    '        dr.Item("ValPorcentajeDr5Ingreso") = 0
    '        dr.Item("ValPorcentajeDr1Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr2Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr3Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr4Bimoneda") = 0
    '        dr.Item("ValPorcentajeDr5Bimoneda") = 0

    '        Oflex.ods.Tables("detalle").Rows.Add(dr)
    '        ldSubTotal = ldSubTotal + dr.Item("SubTotal")
    '    Next

    '    Try

    '        Oflex.ods.Tables("encabezado").Rows(0).Item("total") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("totalIngreso") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("totalBimoneda") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("neto") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("netoIngreso") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("netoBimoneda") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotal") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalIngreso") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalBimoneda") = ldSubTotal / 1.12


    '    Catch ex As Exception

    '    End Try
    '    ls_pedido_generado = Oflex.Guardar_Documento()


    '    If ls_pedido_generado > 0 Then
    '        proceso_exitoso = True
    '        Otrans.Actualiza("scm..pa_upd_um_rechazo_procesado '" & dr.Item("empresa") & "','" & drEncabezado.Item("tipodoctoRechazo") & "','" & drEncabezado.Item("numeroRechazo") & "','" & ls_pedido_generado & "'")

    '        For Each dr2 As DataRow In Oflex.ods.Tables("detalle").Rows
    '            lsSQL = "pa_upd_um_documentod_asignado_sinControlTransporte '" & dr.Item("empresa") & "','" & dr.Item("tipodoctoOrigen") & "'," &
    '                    dr2.Item("correlativoOrigen") & ",'" & dr2.Item("producto") & "'," & dr2.Item("secuenciaOrigen") & ",'AdminISF'"

    '            Otrans.Actualiza(lsSQL)
    '        Next
    '        Otrans.Actualiza("pa_upd_um_tipodocumento_correlativo '" & dr.Item("empresa") & "','" & sTipoDocto & "'")

    '        Dim dtAux As DataTable
    '        dtAux = Otrans.Obtiene("scm..pa_var_um_rechazo_parcial_total '" & drEncabezado.Item("empresa").ToString & "','" & drEncabezado.Item("TipoDoctoFactura") & "','" & drEncabezado.Item("numeroFactura") & "','" & sTipoDocto & "'")
    '        Dim diferencia As Double = 0
    '        Dim lsDescripcionRechazo As String = String.Empty
    '        For Each dr2 As DataRow In dtAux.Rows
    '            diferencia += dr2.Item("diferencia")
    '            If dr2.Item("descripcionRechazo").ToString.Length > 0 Then
    '                lsDescripcionRechazo = dr2.Item("descripcionRechazo").ToString
    '            End If
    '        Next


    '        lsDescripcionRechazo = "Rechazo " & IIf(diferencia > 0, "Parcial", "Total") & " De Factura No. " & drEncabezado.Item("numeroFactura") & " " & lsDescripcionRechazo
    '        lsSQL = "scm..pa_upd_um_documento_rechazo '" & drEncabezado.Item("empresa").ToString & "','" & sTipoDocto & "'," & ls_pedido_generado & ",'" & lsDescripcionRechazo & "'"
    '        Otrans.Actualiza(lsSQL)

    '        'pNumeroPedido = Oflex.ods.Tables("encabezado").Rows(0).Item("numero")
    '        'pTipoDocumento = Oflex.ods.Tables("encabezado").Rows(0).Item("TipoDocto")
    '    End If

    '    Oflex = Nothing

    '    Return proceso_exitoso
    'End Function

    ''Private Function ProcesaDevolucion(ByVal dt As DataTable, ByVal Otrans As Transaccional.Conexion)

    '    Dim Oflex As New Umbral_Flex.Pedidos(False, True)

    '    Oflex.Validar_Totales = False


    '    Dim osinc As New Sincronizacion.Recepcion_Informacion_PDA()

    '    Dim dr, ofila As DataRow
    '    Dim li_linea As Integer = 0
    '    Dim ls_pedido_generado As Integer = 0
    '    Dim s_empresa As String = String.Empty
    '    Dim proceso_exitoso As Boolean = False
    '    Dim pd_total_pedido As Double = 0
    '    Dim forma_pago As String = String.Empty
    '    Dim drEncabezado As DataRow
    '    Dim ods As New DataSet
    '    Dim lsSQL As String
    '    Dim sTipoDocto As String

    '    drEncabezado = dt.Rows(0)
    '    s_empresa = drEncabezado.Item("empresa").ToString

    '    If s_empresa = "DMARTE1" Then
    '        sTipoDocto = "DEVOLUCIONES MERCADERIA"
    '    ElseIf s_empresa = "CODICASA" Then
    '        sTipoDocto = "DEVOLUCION DE MERCADERIA"
    '    ElseIf s_empresa = "DIUVA" Then
    '        sTipoDocto = "DEVOLUCION DE MERCADERIA"
    '    ElseIf s_empresa = "VINOTECA" Then
    '        sTipoDocto = "DEVOLUCION DE MERCADERIA"
    '    End If
    '    'forma_pago = drEncabezado.Item("forma_pago").ToString



    '    'forma_pago = drEncabezado.Item("forma_pago").ToString

    '    osinc.Llenar_Auxiliares(ods, drEncabezado.Item("ctacte"), s_empresa)
    '    osinc = Nothing

    '    dr = Oflex.ods.Tables("encabezado").NewRow
    '    pd_total_pedido = drEncabezado.Item("total_devolucion").ToString

    '    dr.Item("Empresa") = s_empresa
    '    dr.Item("tipodocto") = sTipoDocto
    '    dr.Item("correlativo") = 0
    '    dr.Item("CtaCte") = String.Empty
    '    dr.Item("numero") = ""
    '    dr.Item("fecha") = Today.ToString("dd-MM-yyyy")
    '    dr.Item("proveedor") = String.Empty
    '    dr.Item("cliente") = drEncabezado.Item("ctacte")
    '    dr.Item("bodega") = String.Empty 'drEncabezado.Item("bodega") '' debe traerlo el detalle
    '    dr.Item("bodega2") = String.Empty
    '    dr.Item("local") = String.Empty
    '    dr.Item("comprador") = String.Empty
    '    dr.Item("vendedor") = ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
    '    dr.Item("CentroCosto") = String.Empty
    '    dr.Item("fechaVcto") = "01/01/1900"
    '    dr.Item("listaPrecio") = String.Empty 'drEncabezado.Item("listaprecio").ToString ''Se tomara de las facturas
    '    dr.Item("Analisis") = "PILOTO PENDIENTE"
    '    dr.Item("Zona") = String.Empty
    '    dr.Item("tipocta") = "VEHICULO PENDIENTE"
    '    dr.Item("moneda") = ods.Tables("flexline_configuracion").Rows(0).Item("texto")
    '    dr.Item("paridad") = 1
    '    dr.Item("neto") = 0
    '    dr.Item("subtotal") = 0
    '    dr.Item("total") = pd_total_pedido
    '    dr.Item("NetoIngreso") = 0
    '    dr.Item("SubTotalIngreso") = 0
    '    dr.Item("TotalIngreso") = 0
    '    dr.Item("centraliza") = String.Empty
    '    dr.Item("valoriza") = String.Empty
    '    dr.Item("costeo") = String.Empty
    '    dr.Item("aprobacion") = "S" '(c) A partir del 02 de Mayo
    '    dr.Item("TipoComprobante") = String.Empty
    '    dr.Item("PeriodoLibro") = Today.ToString("yyyyMM")
    '    dr.Item("FactorMonto") = 0
    '    dr.Item("TipoCtaCte") = "CLIENTE"
    '    dr.Item("IdCtaCte") = drEncabezado.Item("ctacte")
    '    dr.Item("Glosa") = "Devolucion No. " & drEncabezado.Item("correlativo") 'drEncabezado.Item("TipoDoctoFactura") & "-" & drEncabezado.Item("NumeroFactura") 'Validar Glosa
    '    dr.Item("comentario1") = String.Empty 'drEncabezado.Item("comentario1").ToString
    '    dr.Item("comentario2") = String.Empty
    '    dr.Item("vigencia") = "S"
    '    dr.Item("Emitido") = "N"
    '    dr.Item("PorcentajeAsignado") = 0
    '    dr.Item("direccion") = drEncabezado.Item("direccion").ToString
    '    dr.Item("ciudad") = String.Empty
    '    dr.Item("comuna") = String.Empty
    '    dr.Item("EstadoDir") = String.Empty
    '    dr.Item("pais") = String.Empty
    '    dr.Item("contacto") = String.Empty
    '    dr.Item("FechaModif") = Now
    '    dr.Item("FechaUModif") = Now
    '    dr.Item("UsuarioModif") = "ISF"
    '    dr.Item("Hora") = Now.ToString("HH:mm:ss")
    '    dr.Item("NetoBimoneda") = 0
    '    dr.Item("SubTotalBimoneda") = 0
    '    dr.Item("TotalBimoneda") = 0
    '    dr.Item("ParidadBimoneda") = 0
    '    dr.Item("AnalisisE1") = String.Empty
    '    dr.Item("AnalisisE2") = String.Empty
    '    dr.Item("AnalisisE3") = String.Empty
    '    dr.Item("UsuarioAprueba") = String.Empty
    '    dr.Item("referenciaExterna") = 0






    '    Oflex.ods.Tables("encabezado").Rows.Add(dr)


    '    ' ''DocumentoV
    '    'dr = Oflex.ods.Tables("documentov").NewRow
    '    'dr.Item("total") = pd_total_pedido
    '    'dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
    '    'Oflex.ods.Tables("documentov").Rows.Add(dr)


    '    ''Documento Original siempre trae mas de 1 factura
    '    lsSQL = "pa_var_um_devolucion_factura_producto " & dt.Rows(0).Item("cod_devolucion")
    '    Dim dtDetalle As DataTable
    '    dtDetalle = Otrans.Obtiene(lsSQL)

    '    If dtDetalle.Rows.Count > 0 Then
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("ListaPrecio") = dtDetalle.Rows(0).Item("ListaPrecio")
    '        'En las Devoluciones la Bodega debe venir de la solicitud
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("Bodega") = dtDetalle.Rows(0).Item("bodega_devolucion")
    '        If dtDetalle.Rows(0).Item("tipodocto").ToString.ToUpper.StartsWith("CONSIG") Then
    '            sTipoDocto = "DEVOLUCION DE CONSIGNACIONES"
    '            Oflex.ods.Tables("encabezado").Rows(0).Item("tipodocto") = sTipoDocto
    '            Oflex.ods.Tables("encabezado").Rows(0).Item("bodega") = "CONSIGNACIONES"
    '            Oflex.ods.Tables("encabezado").Rows(0).Item("Bodega2") = dtDetalle.Rows(0).Item("bodega_devolucion")
    '        End If
    '    End If


    '    Dim drv As DataRowView
    '    Dim iCount As Integer = 0
    '    Dim ldSubTotal As Double = 0

    '    ''DocumentoD
    '    For Each ofila In dtDetalle.Rows
    '        'dtDetalle.DefaultView.RowFilter = "numero = '" & ofila.Item("nodocto") & "' and  producto ='" & ofila.Item("producto") & "' and lote = '" & ofila.Item("lote") & "'"
    '        'drv = dtDetalle.DefaultView(0)

    '        If ofila.Item("secuenciaFactura") > 0 Then


    '            iCount += 1
    '            dr = Oflex.ods.Tables("detalle").NewRow

    '            dr.Item("Empresa") = s_empresa
    '            dr.Item("tipodocto") = sTipoDocto
    '            dr.Item("Secuencia") = iCount
    '            dr.Item("Linea") = iCount
    '            dr.Item("Producto") = ofila.Item("producto")
    '            dr.Item("Cantidad") = ofila.Item("cantidad")
    '            dr.Item("Precio") = ofila.Item("precioFactura") ''Precio de La factura Original
    '            dr.Item("PorcentajeDr") = ofila.Item("PorcentajeDRFactura")
    '            dr.Item("SubTotal") = dr.Item("cantidad") * dr.Item("precio")
    '            dr.Item("Impuesto") = 0
    '            dr.Item("Neto") = dr.Item("SubTotal")
    '            dr.Item("DRGlobal") = 0
    '            dr.Item("Costo") = ofila.Item("costoBodega")  'Es el costo de la tabla ProdBodegas
    '            dr.Item("Total") = dr.Item("Neto")
    '            dr.Item("PrecioAjustado") = dr.Item("precio")
    '            dr.Item("UnidadIngreso") = "UN"
    '            dr.Item("CantidadIngreso") = ofila.Item("cantidad")
    '            dr.Item("PrecioIngreso") = dr.Item("precio")
    '            dr.Item("SubTotalIngreso") = dr.Item("Total")
    '            dr.Item("ImpuestoIngreso") = 0
    '            dr.Item("NetoIngreso") = dr.Item("SubTotalIngreso")
    '            dr.Item("DRGlobalIngreso") = 0
    '            dr.Item("TotalIngreso") = dr.Item("Total")
    '            dr.Item("Lote") = ofila.Item("lote")
    '            dr.Item("fechavcto") = ofila.Item("fechavcto")
    '            dr.Item("TipoDoctoOrigen") = ofila.Item("TipoDoctoFactura")
    '            dr.Item("CorrelativoOrigen") = ofila.Item("correlativoFactura")
    '            dr.Item("SecuenciaOrigen") = ofila.Item("secuenciaFactura")
    '            dr.Item("Bodega") = Oflex.ods.Tables("encabezado").Rows(0).Item("bodega") 'ofila.Item("bodega")
    '            dr.Item("FactorInventario") = -1
    '            dr.Item("FechaEntrega") = Today
    '            dr.Item("CantidadAsignada") = 0
    '            dr.Item("Fecha") = Today
    '            dr.Item("comentario") = String.Empty
    '            dr.Item("Vigente") = "S"
    '            dr.Item("CUP") = dr.Item("costo")
    '            dr.Item("Ubicacion") = "PRINCIPAL"

    '            dr.Item("cuenta") = String.Empty
    '            'If sTipoDocto != "DEVOLUCION DE CONSIGNACIONES" Then
    '            dr.Item("FactorImpto") = 1
    '            dr.Item("Ubicacion2") = "PRINCIPAL"
    '            dr.Item("DoctoOrigenVal") = "S"
    '            'End If


    '            dr.Item("PrecioBimoneda") = dr.Item("precio")
    '            dr.Item("SubTotalBimoneda") = dr.Item("subtotal")
    '            dr.Item("ImpuestoBimoneda") = 0
    '            dr.Item("NetoBimoneda") = dr.Item("Neto")
    '            dr.Item("DrGlobalBimoneda") = 0
    '            dr.Item("TotalBimoneda") = dr.Item("Total")
    '            dr.Item("PrecioListaP") = ofila.Item("precioListaP")
    '            If sTipoDocto <> "DEVOLUCION DE CONSIGNACIONES" Then
    '                dr.Item("UniMedDynamic") = dr.Item("cantidad")
    '            Else
    '                dr.Item("UniMedDynamic") = 0
    '            End If
    '            dr.Item("FechaVigenciaLp") = ofila.Item("FechaVigenciaLp")
    '            dr.Item("LoteDestino") = String.Empty
    '            dr.Item("SerieDestino") = String.Empty
    '            dr.Item("ProdAlias") = String.Empty

    '            dr.Item("MontoAsignado") = 0
    '            dr.Item("Aux_Valor13") = ofila.Item("cod_motivo") 'Este dato solo es para rechazos

    '            dr.Item("ValPorcentajeDr1") = 0
    '            dr.Item("ValPorcentajeDr2") = 0
    '            dr.Item("ValPorcentajeDr3") = 0
    '            dr.Item("ValPorcentajeDr4") = 0
    '            dr.Item("ValPorcentajeDr5") = 0
    '            dr.Item("ValPorcentajeDr1Ingreso") = 0
    '            dr.Item("ValPorcentajeDr2Ingreso") = 0
    '            dr.Item("ValPorcentajeDr3Ingreso") = 0
    '            dr.Item("ValPorcentajeDr4Ingreso") = 0
    '            dr.Item("ValPorcentajeDr5Ingreso") = 0
    '            dr.Item("ValPorcentajeDr1Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr2Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr3Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr4Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr5Bimoneda") = 0

    '            Oflex.ods.Tables("detalle").Rows.Add(dr)
    '            ldSubTotal = ldSubTotal + dr.Item("SubTotal")
    '        End If
    '    Next

    '    Try

    '        Oflex.ods.Tables("encabezado").Rows(0).Item("total") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("totalIngreso") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("totalBimoneda") = ldSubTotal
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("neto") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("netoIngreso") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("netoBimoneda") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotal") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalIngreso") = ldSubTotal / 1.12
    '        Oflex.ods.Tables("encabezado").Rows(0).Item("subtotalBimoneda") = ldSubTotal / 1.12

    '    Catch ex As Exception

    '    End Try


    '    'Proceso para devoluciones de Consignaciones


    '    If sTipoDocto = "DEVOLUCION DE CONSIGNACIONES" Then
    '        Dim dtAux As DataTable = Oflex.ods.Tables("detalle").Copy
    '        ''DocumentoD
    '        For Each ofila2 As DataRow In dtAux.Rows
    '            'dtDetalle.DefaultView.RowFilter = "numero = '" & ofila.Item("nodocto") & "' and  producto ='" & ofila.Item("producto") & "' and lote = '" & ofila.Item("lote") & "'"
    '            'drv = dtDetalle.DefaultView(0)

    '            'If ofila.Item("secuenciaFactura") > 0 Then


    '            iCount += 1
    '            dr = Oflex.ods.Tables("detalle").NewRow

    '            dr.Item("Empresa") = s_empresa
    '            dr.Item("tipodocto") = sTipoDocto
    '            dr.Item("Secuencia") = ofila2.Item("Secuencia") * -1
    '            dr.Item("Linea") = ofila2.Item("Linea") * -1
    '            dr.Item("Producto") = ofila2.Item("producto")
    '            dr.Item("Cantidad") = ofila2.Item("cantidad") * -1
    '            dr.Item("Precio") = ofila2.Item("precio") ''Precio de La factura Original
    '            dr.Item("PorcentajeDr") = ofila2.Item("PorcentajeDr")
    '            dr.Item("SubTotal") = ofila2.Item("Subtotal") * -1 'dr.Item("cantidad") * dr.Item("precio")
    '            dr.Item("Impuesto") = 0
    '            dr.Item("Neto") = ofila2.Item("Neto") * -1 'dr.Item("SubTotal")
    '            dr.Item("DRGlobal") = 0
    '            dr.Item("Costo") = ofila2.Item("Costo")  'Es el costo de la tabla ProdBodegas
    '            dr.Item("Total") = ofila2.Item("Total") * -1 'dr.Item("Neto")
    '            dr.Item("PrecioAjustado") = ofila2.Item("PrecioAjustado") 'dr.Item("precio")
    '            dr.Item("UnidadIngreso") = "UN"
    '            dr.Item("CantidadIngreso") = ofila2.Item("CantidadIngreso") * -1 ' ofila.Item("cantidad")
    '            dr.Item("PrecioIngreso") = ofila2.Item("PrecioIngreso") 'dr.Item("precio")
    '            dr.Item("SubTotalIngreso") = ofila2.Item("SubtotalIngreso") * -1 'dr.Item("Total")
    '            dr.Item("ImpuestoIngreso") = 0
    '            dr.Item("NetoIngreso") = ofila2.Item("NetoIngreso") * -1 'dr.Item("SubTotalIngreso")
    '            dr.Item("DRGlobalIngreso") = 0
    '            dr.Item("TotalIngreso") = ofila2.Item("TotalIngreso") * -1 'dr.Item("Total")
    '            dr.Item("Lote") = ofila2.Item("lote")
    '            dr.Item("fechavcto") = ofila2.Item("fechavcto")
    '            dr.Item("TipoDoctoOrigen") = "" 'ofila.Item("TipoDoctoFactura")
    '            dr.Item("CorrelativoOrigen") = 0 'ofila.Item("correlativoFactura")
    '            dr.Item("SecuenciaOrigen") = 0 'ofila.Item("secuenciaFactura")
    '            dr.Item("Bodega") = Oflex.ods.Tables("encabezado").Rows(0).Item("bodega2") 'ofila.Item("bodega")
    '            dr.Item("FactorInventario") = -1
    '            dr.Item("FechaEntrega") = Today
    '            dr.Item("CantidadAsignada") = 0
    '            dr.Item("Fecha") = Today
    '            dr.Item("comentario") = String.Empty
    '            dr.Item("Vigente") = "S"
    '            dr.Item("CUP") = dr.Item("costo")
    '            dr.Item("Ubicacion") = "PRINCIPAL"
    '            dr.Item("Ubicacion2") = "PRINCIPAL"
    '            dr.Item("cuenta") = String.Empty
    '            dr.Item("FactorImpto") = 1
    '            dr.Item("PrecioBimoneda") = ofila2.Item("PrecioBimoneda") * -1 'dr.Item("precio")
    '            dr.Item("SubTotalBimoneda") = ofila2.Item("SubTotalBimoneda") * -1 'dr.Item("subtotal")
    '            dr.Item("ImpuestoBimoneda") = 0
    '            dr.Item("NetoBimoneda") = ofila2.Item("NetoBimoneda") * -1 'dr.Item("Neto")
    '            dr.Item("DrGlobalBimoneda") = 0
    '            dr.Item("TotalBimoneda") = ofila2.Item("TotalBimoneda") * -1 'dr.Item("Total")
    '            dr.Item("PrecioListaP") = ofila2.Item("precioListaP")
    '            dr.Item("UniMedDynamic") = 0 'dr.Item("cantidad")
    '            dr.Item("FechaVigenciaLp") = ofila2.Item("FechaVigenciaLp")
    '            dr.Item("LoteDestino") = String.Empty
    '            dr.Item("SerieDestino") = String.Empty
    '            dr.Item("ProdAlias") = String.Empty
    '            dr.Item("DoctoOrigenVal") = "S"
    '            dr.Item("MontoAsignado") = 0
    '            dr.Item("Aux_Valor13") = ofila2.Item("Aux_Valor13")

    '            dr.Item("ValPorcentajeDr1") = 0
    '            dr.Item("ValPorcentajeDr2") = 0
    '            dr.Item("ValPorcentajeDr3") = 0
    '            dr.Item("ValPorcentajeDr4") = 0
    '            dr.Item("ValPorcentajeDr5") = 0
    '            dr.Item("ValPorcentajeDr1Ingreso") = 0
    '            dr.Item("ValPorcentajeDr2Ingreso") = 0
    '            dr.Item("ValPorcentajeDr3Ingreso") = 0
    '            dr.Item("ValPorcentajeDr4Ingreso") = 0
    '            dr.Item("ValPorcentajeDr5Ingreso") = 0
    '            dr.Item("ValPorcentajeDr1Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr2Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr3Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr4Bimoneda") = 0
    '            dr.Item("ValPorcentajeDr5Bimoneda") = 0

    '            Oflex.ods.Tables("detalle").Rows.Add(dr)
    '            'ldSubTotal = ldSubTotal + dr.Item("SubTotal")

    '        Next
    '    End If

    '    ls_pedido_generado = Oflex.Guardar_Documento()


    '    If ls_pedido_generado > 0 Then
    '        proceso_exitoso = True
    '        'pNumeroPedido = Oflex.ods.Tables("encabezado").Rows(0).Item("numero")
    '        'pTipoDocumento = Oflex.ods.Tables("encabezado").Rows(0).Item("TipoDocto")
    '        proceso_exitoso = True
    '        '            Otrans.Actualiza("scm..pa_upd_um_rechazo_procesado '" & dr.Item("empresa") & "','" & drEncabezado.Item("tipodoctoRechazo") & "','" & drEncabezado.Item("numeroRechazo") & "','" & ls_pedido_generado & "'")
    '        lsSQL = "scm..pa_upd_um_devolucion_recepcion '" & drEncabezado.Item("empresa") & "'," & drEncabezado.Item("cod_devolucion")
    '        Otrans.Actualiza(lsSQL)

    '        For Each dr2 As DataRow In Oflex.ods.Tables("detalle").Rows
    '            lsSQL = "pa_upd_um_documentod_asignado_sinControlTransporte '" & dr.Item("empresa") & "','" & dr.Item("tipodoctoOrigen") & "'," &
    '                    dr2.Item("correlativoOrigen") & ",'" & dr2.Item("producto") & "'," & dr2.Item("secuenciaOrigen") & ",'Admin_ISF'"

    '            Otrans.Actualiza(lsSQL)
    '        Next

    '        Otrans.Actualiza("pa_upd_um_tipodocumento_correlativo '" & dr.Item("empresa") & "','" & sTipoDocto & "'")

    '        Dim dtNumeros As DataTable
    '        Dim lsDescripcionDevolucion As String = "Devolucion No. " & drEncabezado.Item("correlativo")

    '        Dim clsGen As New ClasesGenerales.General

    '        dtNumeros = clsGen.ValoresDistinto(dtDetalle, "tipodocto,numero".Split(","))
    '        For Each dr2 As DataRow In dtNumeros.Rows
    '            lsDescripcionDevolucion = lsDescripcionDevolucion & " " & dr2.Item("tipodocto").ToString & "-" & dr2.Item("numero")
    '        Next

    '        'lsDescripcionRechazo = "Rechazo " & IIf(diferencia > 0, "Parcial", "Total") & " De Factura No. " & drEncabezado.Item("numeroFactura") & " " & lsDescripcionRechazo
    '        lsSQL = "scm..pa_upd_um_documento_rechazo '" & drEncabezado.Item("empresa").ToString & "','" & sTipoDocto & "'," & ls_pedido_generado & ",'" & lsDescripcionDevolucion & "'"
    '        Otrans.Actualiza(lsSQL)
    '        Otrans.Escribir_Log(lsSQL)
    '    End If

    '    Oflex = Nothing

    '    Return proceso_exitoso




    'End Function

    Private Sub revision_facturacion_autoconsumo()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim ls_sql As String
        Dim dt, dt2, dt3 As DataTable
        Dim numero_pedido As Integer

        Try
            Otrans.open()
            cOtrans.open()

            'ls_sql = "pa_var_um_factuacion_costo_traslado"
            ls_sql = "pa_var_um_facturacion_autoconsumo_traslado" '(c) 20230428
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Dim Correlativo As Integer = 0
                For Each dr As DataRow In dt.Rows
                    Try

                        Correlativo += 1
                        ls_sql = "pa_sel_um_listaprecio_facturacion_autoconsumo_traslado '" & dr.Item("empresa") & "'"
                        dt3 = Otrans.Obtiene(ls_sql)

                        'ls_sql = "pa_ins_um_mov_pedidos_encabezado '" & dr.Item("empresa") & "','" &
                        'Now.ToString("ddMMyyyyHHmmss") & Correlativo & "','" & dr.Item("ctacte_fc") & "','CREDITO 30 DIAS',0,0,'" &
                        'Now.ToString("dd-MM-yyyy") & "','" & Now.ToString("dd-MM-yyyy") & "','" &
                        '    "SOLICITUD NO. " & dr.Item("numero") & " " & dr.Item("observaciones") & "','" & dr.Item("usuario_grabo") & "',0,'" & dt3.Rows(0).Item("lisprecio") & "',''"

                        ls_sql = "pa_ins_um_mov_pedidos_encabezado '" & dr.Item("empresa") & "','" &
                        Now.ToString("yy") & dr.Item("numero").ToString.PadLeft(8, "0") & "','" & dr.Item("ctacte_fc") & "','CREDITO 30 DIAS',0,0,'" &
                        Now.ToString("dd-MM-yyyy") & "','" & Now.ToString("dd-MM-yyyy") & "','" &
                            "SOLICITUD NO. " & dr.Item("numero") & " " & dr.Item("observaciones") & "','" & dr.Item("usuario_grabo") & "',0,'" & dt3.Rows(0).Item("lisprecio") & "',''"

                        cOtrans.Ingresa(ls_sql)
                        If cOtrans.Codigo_error = 0 Then
                            dt = cOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                            numero_pedido = dt.Rows(0).Item("newid").ToString

                            'ls_sql = "pa_var_um_facturacion_costod_traslado " & dr.Item("cod_factura")
                            ls_sql = "pa_var_um_facturacion_autoconsumo_detalle_traslado " & dr.Item("cod_factura")

                            dt2 = Otrans.Obtiene(ls_sql)

                            Dim LineaLocal As Integer = 0

                            For Each drrs As DataRow In dt2.Rows
                                LineaLocal += 1
                                ls_sql = "pa_ins_um_mov_pedidos_detalle_traslado " & numero_pedido & "," &
                                    LineaLocal & ",'" & drrs.Item("producto").ToString & "'," &
                                    drrs.Item("Cantidad") & "," & drrs.Item("precio") & "," &
                                    drrs.Item("Cantidad") * drrs.Item("precio") & ",'" & drrs.Item("marca") &
                                    "','" & drrs.Item("centro_costo") & "','" & drrs.Item("gasto_conta") & "','" &
                                    drrs.Item("rubro") & "','" & drrs.Item("comentario") & "'"
                                cOtrans.Ingresa(ls_sql)
                            Next

                            ls_sql = "pa_upd_mov_pedidos_encabezado_cell " & numero_pedido
                            cOtrans.Actualiza(ls_sql)
                            ls_sql = "pa_upd_facturacion_autoconsumo_traslado_estado '" & dr.Item("empresa") & "'," & dr.Item("cod_factura") & ",'" & numero_pedido & "'"
                            Otrans.Actualiza(ls_sql)
                        End If

                    Catch ex As Exception
                        Otrans.Escribir_Log(ex.ToString)
                    End Try
                Next
            End If

        Catch ex As Exception
            Otrans.Escribir_Log(ex.ToString)
        Finally
            cOtrans.close()
            cOtrans = Nothing
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub




    Private Sub replicaInformacion(ByVal iproceso As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Try

            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = "c:\aplicaciones\replicacion\replicacion.exe"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = "c:\aplicaciones\replicacion"

            proceso.Start()
            proceso = Nothing
            myOtrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & iproceso.ToString & ")")
            myOtrans.close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            myOtrans = Nothing
        End Try

    End Sub



    Private Sub memosPromocionales(ByVal iproceso As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Try

            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = "c:\aplicaciones\Memos\procesos Memos Promocionales.exe"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = "c:\aplicaciones\Memos"

            proceso.Start()
            proceso = Nothing
            myOtrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & iproceso.ToString & ")")
            myOtrans.close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            myOtrans = Nothing
        End Try

    End Sub


    Private Sub sincronizarInformacionPOS(ByVal iProceso As Integer)

        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Try

            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = "c:\aplicaciones\Sincronizacion POS\Procesos Traslados Tiendas.exe"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = "c:\aplicaciones\Sincronizacion POS"

            proceso.Start()
            proceso = Nothing
            myOtrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & iProceso.ToString & ")")
            myOtrans.close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            myOtrans = Nothing
        End Try





    End Sub

    Private Sub generarInformacionPOS(ByVal psEmpresa As String, ByVal psUbicacion As String, ByVal pdFecha As DateTime)
        Dim Otrans As Transaccional.Conexion
        Dim ClsGen As New ClasesGenerales.General

        Dim dt As DataTable
        Dim ls_sql As String
        Dim lgenerar_error As Boolean = False
        Dim oDs As New DataSet

        Try


            'abro la conexion al nuevo servidor
            Otrans = New Transaccional.Conexion("FlexLine" & psUbicacion)

            Otrans.open()

            ls_sql = "pa_var_um_documento_traslado_fecha  '" & psEmpresa & "',null,'" &
                         pdFecha.ToString("dd/MM/yyyy") & "','" & pdFecha.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documento"
            If oDs.Tables.Contains("documento") Then
                oDs.Tables.Remove("documento")
            End If
            oDs.Tables.Add(dt.Copy)

            ' Me.dgv_documentos.DataSource = dt
            ' ClsGen.Alinear_GridView(dt, Me.dgv_documentos, ",empresa,tipodocto,numero,fecha,vendedor,total,", "", "", "", True, True, 250, 0)



            ''documentod
            ls_sql = "pa_var_um_documentod_traslado_fecha '" & psEmpresa & "',null,'" &
                        pdFecha.ToString("dd/MM/yyyy") & "','" & pdFecha.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentod"
            If oDs.Tables.Contains("documentod") Then oDs.Tables.Remove("documentod")

            oDs.Tables.Add(dt.Copy)

            ''documentov
            ls_sql = "pa_var_um_documentov_traslado_fecha '" & psEmpresa & "',null,'" &
                        pdFecha.ToString("dd/MM/yyyy") & "','" & pdFecha.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentov"
            If oDs.Tables.Contains("documentov") Then oDs.Tables.Remove("documentov")

            oDs.Tables.Add(dt.Copy)

            ''documentop
            ls_sql = "pa_var_um_documentop_traslado_fecha '" & psEmpresa & "',null,'" &
                        pdFecha.ToString("dd/MM/yyyy") & "','" & pdFecha.ToString("dd/MM/yyyy") & "'"

            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "documentop"
            If oDs.Tables.Contains("documentop") Then oDs.Tables.Remove("documentop")

            oDs.Tables.Add(dt.Copy)

            ''Clientes
            ls_sql = "pa_var_um_ctacte_traslado_fecha '" & psEmpresa & "',null,'" &
                        pdFecha.ToString("dd/MM/yyyy") & "','" & pdFecha.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte"

            If oDs.Tables.Contains("ctacte") Then oDs.Tables.Remove("ctacte")

            oDs.Tables.Add(dt.Copy)

            ''Direcciones de Clientes
            ls_sql = "pa_var_um_ctacteDirecciones_traslado_fecha '" & psEmpresa & "',null,'" &
                    pdFecha.ToString("dd/MM/yyyy") & "','" & pdFecha.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_direcciones"
            If oDs.Tables.Contains("ctacte_direcciones") Then oDs.Tables.Remove("ctacte_direcciones")

            oDs.Tables.Add(dt.Copy)

            ''Direcciones de Clientes
            ls_sql = "pa_var_um_ctacteGenTabCod_traslado_fecha '" & psEmpresa & "',null,'" &
                        pdFecha.ToString("dd/MM/yyyy") & "','" & pdFecha.ToString("dd/MM/yyyy") & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "ctacte_gentabcod"

            If oDs.Tables.Contains("ctacte_gentabcod") Then oDs.Tables.Remove("ctacte_gentabcod")

            oDs.Tables.Add(dt.Copy)



            'Si el traslado es de el salvador se debe agregar 
            'la informacion de contabilidad
            'If dt.DefaultView(0).Item("nombre_bodega").ToString.ToLower = "es" Then
            '    ''C
            '    ls_sql = "pa_var_um_con_enccom_traslado_fecha '" & gs_empresa & "',null,'" & _
            '                Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "','" & Me.dtp_fecha_inicio.Value.ToString("dd/MM/yyyy") & "'"

            '    dt = Otrans.Obtiene(ls_sql)
            '    dt.TableName = "documentod"
            '    If ods.Tables.Contains("documentod") Then
            '        ods.Tables.Remove("documentod")
            '    End If
            '    ods.Tables.Add(dt.Copy)

            'End If

            'If oDs.Tables("Log").Rows.Count > 0 Then
            '    If MessageBox.Show("Desea Reiniciar el Log ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        oDs.Tables("Log").Rows.Clear()
            '    End If
            'End If

            'Agregar_Log(oDs.Tables("documento").Rows.Count.ToString & " Documentos Listos Para Procesar", "Ok")


            'dt.Columns.Add(New DataColumn("Hora", GetType(DateTime)))
            'dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            'dt.Columns.Add(New DataColumn("estado", GetType(String)))
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

        ProcesarInformacionPOS(oDs, psEmpresa)
        'Me.btn_procesar.Visible = True


    End Sub


    Private Sub ProcesarInformacionPOS(ByVal oDs As DataSet, ByVal psEmpresa As String)

        Dim Osinc As New Sincronizacion.Documentos("")
        Dim OSinc_Clientes As New Sincronizacion.Clientes("")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim HuboError As Boolean = False
        Dim ndoctoserror As Integer = 0
        'Dim cm As CurrencyManager

        'Dim Otrans As Transaccional.Conexion

        'Dim ls_sql As String
        Dim lgenerar_error As Boolean = False



        Try

            For Each dr In oDs.Tables("documento").Rows
                HuboError = False



                oDs.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                oDs.Tables("documentov").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                oDs.Tables("documentop").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString

                '             If dr.Item("tipodocto").ToString.ToLower.StartsWith("factura serie") Then
                Osinc.Enviar_Documento(psEmpresa, dr, oDs.Tables("documentod").DefaultView.ToTable, oDs.Tables("documentov").DefaultView.ToTable, oDs.Tables("documentop").DefaultView.ToTable, "", True)
                '                End If


                If Osinc.codigo_error > 0 Then
                    HuboError = True
                    ndoctoserror += 1
                Else
                    'If gs_empresa <> "VINOTECA" Then
                    '    ls_sql = "pa_upd_um_documento_cerrado '" & gs_empresa & "','" & dr.Item("tipodocto").ToString & "','" & dr.Item("numero") & "','" & gs_usuario & "'"
                    '    Otrans.Actualiza(ls_sql)
                    'End If

                End If

                'Agregar_Log(dr.Item("tipodocto").ToString & " " & dr.Item("numero") & IIf(HuboError, Osinc.descripcion_error, ""), _
                '                    IIf(HuboError, "Error", "Ok"))

                ' End If
            Next

            For Each dr In oDs.Tables("ctacte").Rows

                OSinc_Clientes.Obtener_Cliente(dr.Item("empresa"), dr.Item("ctacte"))

                If OSinc_Clientes.codigo_error = 0 Then

                    dt = OSinc_Clientes.dt

                    If dt.Rows.Count = 0 Then
                        oDs.Tables("ctacte_direcciones").DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte").ToString & "'"
                        oDs.Tables("ctacte_gentabcod").DefaultView.RowFilter = "codigo = '" & dr.Item("ctacte").ToString & "'"
                        OSinc_Clientes.Inserta_Clientes_Nuevos(dr, oDs.Tables("ctacte_direcciones").DefaultView.ToTable,
                                                            oDs.Tables("ctacte_gentabcod").DefaultView.ToTable)
                        If Osinc.codigo_error > 0 Then
                            HuboError = True
                        End If
                    End If
                End If

            Next



            'If ndoctoserror = 0 Then
            '    MessageBox.Show("Proceso Finalizado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Agregar_Log(oDs.Tables("documento").Rows.Count & " Documentos Procesados ", "Ok")
            '    Cerrar_Documentos_Sucursal()
            'Else
            '    MessageBox.Show("El Proceso Genero Errores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Agregar_Log(ndoctoserror.ToString & " Documentos Con Errores", _
            '                 IIf(ndoctoserror > 0, "Error", "Ok"))

            'End If
            'cm = CType(Me.BindingContext(Me.dgv_log.DataSource), CurrencyManager)
            'cm.Position = cm.Count - 1

        Catch ex As Exception
        Finally
            Osinc.Cerrar()
            Osinc = Nothing
            'If Not Otrans Is Nothing Then
            '    Otrans.close()
            '    Otrans = Nothing

            'End If
        End Try
    End Sub


    Private Sub generarInformacion(ByVal iproceso As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Try

            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = "c:\aplicaciones\generarInformacionTekne\generarInformacionTekne.exe"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = "c:\aplicaciones\generarInformacionTekne"

            proceso.Start()
            proceso = Nothing
            myOtrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & iproceso.ToString & ")")
            myOtrans.close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            myOtrans = Nothing
        End Try

    End Sub


#Region "Tekne"

    Private Sub GenerarInformacion_Tekne_Mobile_EE()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "tipo = 'Tekne Mobile Enterprise'"

            For Each drv In dt.DefaultView

                ClsGen.Escribir_Log("-------------------------------------")
                ClsGen.Escribir_Log("Inicia Proceso " & drv.Item("descripcion"))
                GeneraBDsqlite(drv.Item("descripcion"))
                'GeneraBDsqlite("eperez")
                'GeneraBDsqlite("jgutierrez")
                ' GeneraBDsqlite("mcruz")


                ClsGen.Escribir_Log("Finaliza Proceso " & drv.Item("descripcion"))

            Next

            'ls_sql = "call pa_upd_um_pg_procesos_isf (7)"
            ' myOtrans.Actualiza(ls_sql)

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Generar_Informacion_Tekne_Mobile_EE " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub GeneraBDsqlite(ByVal user As String)
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("Flexline")

        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dtproductos, dtUsuarios As DataTable
        Dim ls_sql As String
        Dim lsRuta As String


        Try


            myOtrans.open()
            Otrans.open()

            crearEstructura()

            dtUsuarios = myOtrans.Obtiene("CALL pa_sel_um_sg_usuario_todos()")
            dtUsuarios.DefaultView.RowFilter = "usuario = '" & user & "'"
            dtUsuarios = dtUsuarios.DefaultView.ToTable
            dtUsuarios = ClsGen.ValoresDistinto(dtUsuarios, "usuario,nombre,telefono,cod_usuario".Split(","))
            dtUsuarios.TableName = "usuarios"



            lsRuta = "C:\Aplicaciones\SQLITE\"
            ' lsRuta = "\\virtualcx\aplicaciones$\SQLITE\"

            'Copiar_EstructuraSQLITE(lsRuta)

            '---------------------inicio de declaracion global
            Dim SQLconnect As New SQLite.SQLiteConnection()

            SQLconnect.ConnectionString = "Data Source=C:\Aplicaciones\SQLITE\tekne.sqlite; Version=3; Synchronous=Full;"
            'SQLconnect.ConnectionString = "Data Source=C:\Aplicaciones\SQLITE\tekne.sqlite; New=False;Compress=True;"
            ' SQLconnect.ConnectionString = "Data Source=\\virtualcx\aplicaciones$\SQLITE\tekne.sqlite; Version=3; Synchronous=Full;"
            SQLconnect.Open()
            '-------------------------------fin de global


            Dim SQLcommand As New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete  from  inv_producto"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete  from  mov_cliente"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete  from  mov_cliente_documento"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_cliente_inventario"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_cliente_ruta"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_cliente_saldo"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_producto"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_producto_existencia"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_producto_foco"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_producto_oferta"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_producto_precio"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_venta"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from  pg_fecha"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from pg_fecha_control"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from pg_parametros"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from seg_usuario"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()







            '******************************modificacion 26/11/2013
            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_consignacion_saldo"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_consignacion_movimiento_historico"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_consignacion_conteo"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_consignacion_conteo_encabezado"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            '*****fin de modificacion 26/11/2013

            '*****Inicio de modificacion 14/02/2013
            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_encuesta_resultado_encabezado"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_producto_foco_guia"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_telefono"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "delete from mov_contacto"
            SQLcommand.ExecuteNonQuery()
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            '*****fin de modificacion 14/02/2013

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            ''------------------------------------------PRODUCTOS
            dtproductos = myOtrans.Obtiene("call pa_sel_um_mov_producto_cliente_tk('" & user & "')")

            For Each dr1 As DataRow In dtproductos.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_producto VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("producto") & "','" & dr1.Item("descripcion").ToString.Replace("'", " ") & "','','','','" & dr1.Item("analisis1") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            ''------------------------------------------FIN DE PRODUCTOS
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()














            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            ''------------------------------------------LISTAS DE PRECIOS
            Dim dt2 As DataTable
            dt2 = myOtrans.Obtiene("call pa_var_um_listaprecio_tk('" & user & "')")


            For Each dr1 As DataRow In dt2.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_producto_precio VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("producto") & "','" & dr1.Item("listaprecio") & "','" & dr1.Item("valor") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            ''------------------------------------------FIN LISTAS DE PRECIOS
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()




            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------RUTAS-----------------------------------
            dt = myOtrans.Obtiene("CALL pa_sel_um_mov_cliente_ruta_tk('" & user & "')") 'REVISADO 11/11/2013 16:32


            For Each dr1 As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_cliente_ruta VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("ruta") & "','','" & dr1.Item("frecuencia") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            '-------------------------------------------------FIN DE RUTAS-----------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()




            'SQLcommand = New SQLiteCommand("begin", SQLconnect)
            'SQLcommand.ExecuteNonQuery()
            ''-------------------------------------------------PRODUCTOS FOCOS-----------------------------------
            'dt = myOtrans.Obtiene("CALL pa_sel_um_mov_producto_foco_tk('" & user & "')")


            'For Each dr1 As DataRow In dt.Rows
            '    ' SQLcommand = SQLconnect.CreateCommand
            '    SQLcommand.CommandText = "INSERT INTO  mov_producto_foco VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("producto") & "','" & dr1.Item("ctacte") & "')"
            '    SQLcommand.ExecuteNonQuery()
            'Next
            ''-------------------------------------------------FIN DE PRODUCTOS FOCOS-----------------------------------
            'SQLcommand = New SQLiteCommand("end", SQLconnect)
            'SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '------------------------------------------------ HISTORIAL DE VENTA
            dtproductos = myOtrans.Obtiene("call pa_sel_um_mov_venta_tk('" & user & "')")

            For Each dr1 As DataRow In dtproductos.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_venta VALUES ('" & dr1.Item("empresa") &
                "','" & dr1.Item("ctacte") &
                "','" & dr1.Item("producto") &
                "','" & dr1.Item("bu") &
                "','" & dr1.Item("metau") &
                "','" & dr1.Item("metaq") &
                "','" & dr1.Item("ventau") &
                "','" & dr1.Item("ventaq") &
                "','" & dr1.Item("porcu") &
                "','" & dr1.Item("porcq") &
                "','" & dr1.Item("cu3") &
                "','" & dr1.Item("cu2") &
                "','" & dr1.Item("cu1") &
                "','" & dr1.Item("cq3") &
                "','" & dr1.Item("cq2") &
                "','" & dr1.Item("cq1") &
                "','" & dr1.Item("promu") &
                "','" & dr1.Item("promq") &
                "','" & dr1.Item("pedido_sugerido") &
                "','" & dr1.Item("visitas_mes") &
                "','" & dr1.Item("visitas_realizadas") &
                "','" & dr1.Item("visitas_pendientes") &
                "','" & dr1.Item("periodo") & "')"
                SQLcommand.ExecuteNonQuery()
            Next

            '------------------------------------------------FIN  HISTORIAL DE VENTA
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------GENERALIDADE DE PRODUCTOS-----------------------------------
            dtproductos = myOtrans.Obtiene("call pa_sel_um_inv_producto_tk()")


            For Each dr1 As DataRow In dtproductos.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO inv_producto VALUES ('" & dr1.Item("empresa") &
                "','" & dr1.Item("cod_flex") &
                "','" & dr1.Item("nombre_producto").ToString.Replace("'", " ") &
                "','" & dr1.Item("tipo").ToString.Replace("'", " ") &
                "','" & dr1.Item("familia").ToString.Replace("'", " ") &
                "','" & dr1.Item("proveedor").ToString.Replace("'", " ") &
                "','" & dr1.Item("marca").ToString.Replace("'", " ") &
                "','" & dr1.Item("subtipo").ToString.Replace("'", " ") &
                "','" & dr1.Item("pais").ToString.Replace("'", " ") &
                "','" & dr1.Item("cepa").ToString.Replace("'", " ") &
                "','" & dr1.Item("codigobarra").ToString.Replace("'", " ") &
                "','" & dr1.Item("generalidades").ToString.Replace("'", " ") &
                "','" & dr1.Item("imagen").ToString.Replace("'", " ") & "')"
                SQLcommand.ExecuteNonQuery()
            Next

            '-------------------------------------------------FIN DE GENERALIDADE DE PRODUCTOS-----------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------DOCUMENTOS PENDIENTES-----------------------------------

            dt = myOtrans.Obtiene("CALL pa_sel_um_mov_clientes_documentosPendientes_tk('" & user & "')")
            For Each dr1 As DataRow In dt.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_cliente_documento VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("tipo_docto") & "','" & dr1.Item("numero") & "','" & dr1.Item("fechavcto") & "','" & dr1.Item("saldo") & "',0)"
                SQLcommand.ExecuteNonQuery()
            Next

            '-------------------------------------------------DOCUMENTOS PENDIENTES-----------------------------------

            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-*--------------------------------------------------------------USUARIO PARAMETROS--------------------------------------
            ls_sql = "call pa_sel_um_seg_usuario_parametros_tk('" & user & "')"
            dt = myOtrans.Obtiene(ls_sql)

            For Each dr As DataRow In dt.Rows
                '               SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO pg_parametros VALUES ('" & dr.Item("direccion") & "','" & dr.Item("direccion_alterna") & "','" & dr.Item("lenguaje") & "','" & dr.Item("empresa") & "','','" & dr.Item("auto_envio") & "','" & dr.Item("activar_wifi") & "','" & dr.Item("carpeta") & "','" & dr.Item("carpeta_download") & "','" & dr.Item("carpeta_upload") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            '-*------------------------------------------------------------FIN DE USUARIO PARAMETROS--------------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-*--------------------------------------------------------------USUARIO--------------------------------------
            ls_sql = "call pa_sel_um_seg_usuario_tk('" & user & "')"
            dt = myOtrans.Obtiene(ls_sql)


            For Each dr As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO seg_usuario VALUES ('','" & dr.Item("cod_usuario") & "','" & dr.Item("usuario") & "','" & dr.Item("nombre") & "','" & dr.Item("clave") & "','','',0,'" & dr.Item("descripcion") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            '-*------------------------------------------------------------USUARIO--------------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-*--------------------------------------------------------------FECHAS--------------------------------------

            ls_sql = "call pa_sel_um_pg_fechas_tk()"
            dt = myOtrans.Obtiene(ls_sql)


            For Each dr As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO pg_fecha VALUES ('" & dr.Item("fecha") & "','" & dr.Item("dia") & "','" & dr.Item("frec2") & "','" & dr.Item("frec3") & "',0)"
                SQLcommand.ExecuteNonQuery()
            Next

            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            ' SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "UPDATE pg_fecha set estado=1 where fecha='" & Now.ToString("dd/MM/yyyy") & "'"
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            '-*------------------------------------------------------------FECHAS--------------------------------------
            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-*--------------------------------------------------------------FECHAS CONTROL--------------------------------------

            ls_sql = "call  pa_sel_um_pg_fechas_control_tk()"
            dt = myOtrans.Obtiene(ls_sql)

            SQLcommand.CommandText = "INSERT INTO pg_fecha_control VALUES ('" & dt.Rows(0).Item("total_dias_mes") & "','" & dt.Rows(1).Item("total_dias_mes") & "','" & dt.Rows(0).Item("total_dias_mes") - dt.Rows(1).Item("total_dias_mes") & "','" & Now.ToLongDateString & "','" & Now.ToString("yyyy-MM-dd") & "','')"
            SQLcommand.ExecuteNonQuery()

            '-*------------------------------------------------------------FECHAS CONTROL--------------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-*--------------------------------------------------------------MOV_CLIENTES--------------------------------------
            ls_sql = "call pa_sel_um_mov_cliente_tipo_usuario_tk(8,'" & user & "')"
            dt = myOtrans.Obtiene(ls_sql)


            For Each dr As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                Try
                    SQLcommand.CommandText = "INSERT INTO mov_cliente VALUES ('" & dr.Item("empresa") & "','" & dr.Item("ctacte") & "','','" & dr.Item("razonSocial") & "','" & dr.Item("listaprecio") & "','" & dr.Item("condpago") & "','" & dr.Item("direccion") & "','" & dr.Item("giro_negocio") & "','" & dr.Item("nombrecorto").ToString.Replace("'", " ").Trim & "','" & dr.Item("motivoconsumo") & "','" & dr.Item("nivelcliente") & "','" & dr.Item("categoria") & "','0')"
                    SQLcommand.ExecuteNonQuery()
                Catch ex As Exception

                End Try

            Next
            '-*------------------------------------------------------------FIN MOV_CLIENTES--------------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            tekneLlenarEstructuraConsignaciones(dtUsuarios)
            Me.tekeneLlenarEstructuraSaldos(dtUsuarios, dt)




            '----CAMBIOS  REALIZADOS 14-02-2014

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-*--------------------------------------------------------------MOV_CLIENTE_TELEFONO--------------------------------------

            For Each dr As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                Try
                    If dr.Item("telefono").ToString.Length > 0 Then
                        SQLcommand.CommandText = "INSERT INTO mov_telefono   VALUES ('" & dr.Item("empresa") & "','" & dr.Item("ctacte") & "','" & dr.Item("telefono") & "')"
                        SQLcommand.ExecuteNonQuery()
                    End If

                Catch ex As Exception

                End Try

            Next
            '-*------------------------------------------------------------FIN MOV_CLIENTES--------------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-*--------------------------------------------------------------MOV_CLIENTE_CONTACTO--------------------------------------
            ls_sql = "pa_sel_um_ctacte_contacto_tk '" & dtUsuarios.Rows(0).Item("nombre") & "' "
            dt = Otrans.Obtiene(ls_sql)


            For Each dr As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                Try
                    SQLcommand.CommandText = "INSERT INTO mov_contacto VALUES ('" & dr.Item("empresa") & "','" & dr.Item("ctacte") & "','" & dr.Item("contacto") & "')"
                    SQLcommand.ExecuteNonQuery()

                Catch ex As Exception

                End Try

            Next
            '-*------------------------------------------------------------FIN MOV_CLIENTE_CONTACTO--------------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------PRODUCTOS FOCOS GUIA-----------------------------------
            dt = myOtrans.Obtiene("CALL pa_sel_um_mov_producto_foco_guia_tk()")


            For Each dr1 As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO  mov_producto_foco_guia VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("giro") & "','" & dr1.Item("motivo_consumo") & "','" & dr1.Item("producto") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            '-------------------------------------------------FIN DE PRODUCTOS FOCOS GUIA-----------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------INCIDENCIAS-----------------------------------
            dt = myOtrans.Obtiene("CALL pa_sel_um_mov_encuesta_resultado_incidencia('" & user & "')")


            For Each dr1 As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                Try
                    SQLcommand.CommandText = "INSERT INTO  mov_encuesta_resultado_encabezado VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("cod_encuesta") & "','" & dr1.Item("cod_resultado") & "','" & dr1.Item("usuario_grabo") & "','" & DateTime.Parse(dr1.Item("fecha_grabo")).ToString("yyyy-MM-dd HH:mm:ss") & "','','','4','" & dr1.Item("cod_tipo_encuesta") & "','" & dr1.Item("resultado1") & "','','')"
                    SQLcommand.ExecuteNonQuery()
                Catch ex As Exception

                End Try

            Next
            '-------------------------------------------------FIN DE INCIDENCIAS-----------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------INCIDENCIAS DETALLE-----------------------------------
            dt = myOtrans.Obtiene("CALL pa_sel_um_mov_encuesta_resultado_incidencia_detalle('" & user & "')")


            For Each dr1 As DataRow In dt.Rows
                ' SQLcommand = SQLconnect.CreateCommand
                Try
                    SQLcommand.CommandText = "INSERT INTO  mov_encuesta_resultado_detalle_alternativa VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("cod_encuesta") & "','" & dr1.Item("cod_resultado") & "','" & dr1.Item("cod_pregunta") & "','" & dr1.Item("cod_alternativa") & "','" & dr1.Item("resultado") & "','')"
                    SQLcommand.ExecuteNonQuery()
                Catch ex As Exception

                End Try

            Next
            '-------------------------------------------------FIN DE INCIDENCIAS DETALLE-----------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()



            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '----------------------------------------- CONSIGNACIONES SALDOS
            dt = ods4.Tables("consignaciones_saldos")
            For Each dr1 As DataRow In dt.Rows
                SQLcommand.CommandText = "INSERT INTO mov_consignacion_saldo VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("producto") & "','" & dr1.Item("saldo") & "','" & dr1.Item("cantidad_aprobada") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            '------------------------------------------FIN CONSIGNACIONES SALDOS
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '----------------------------------------- CONSIGNACIONES MOVIMIENTOS HISTORICOS
            dt = ods4.Tables("consignaciones_movimientos_historicos")
            For Each dr1 As DataRow In dt.Rows
                SQLcommand.CommandText = "INSERT INTO mov_consignacion_movimiento_historico VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("producto") & "','" & dr1.Item("tipo") & "','" & dr1.Item("numero") & "','" & dr1.Item("fecha") & "','" & dr1.Item("cantidad") & "','" & dr1.Item("consignacion") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            '------------------------------------------FIN CONSIGNACIONES MOVIMIENTOS HISTORICOS
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '----------------------------------------- CONSIGNACIONES CONTEOS
            dt = ods4.Tables("consignaciones_conteos")
            For Each dr1 As DataRow In dt.Rows
                SQLcommand.CommandText = "INSERT INTO mov_consignacion_conteo VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("cod_conteo") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("producto") & "','" & dr1.Item("cantidad") & "','" & dr1.Item("fecha") & "')"
                SQLcommand.ExecuteNonQuery()
            Next
            '------------------------------------------FIN CONSIGNACIONES CONTEOS
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '----------------------------------------- CONSIGNACIONES CONTEOS ENCABEZADO
            dt = ods4.Tables("consignaciones_conteos_encabezado")
            For Each dr1 As DataRow In dt.Rows
                SQLcommand.CommandText = "INSERT INTO mov_consignacion_conteo_encabezado VALUES ('" & dr1.Item("cod_conteo") & "','" & dr1.Item("empresa") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("fecha") & "','" & dr1.Item("usuario_grabo") & "','" & dr1.Item("comentarios_factura") & "','" & dr1.Item("comentarios_reposicion") & "'," & IIf(dr1.Item("estado").ToString.Length > 0, dr1.Item("estado"), 0) & ")"
                SQLcommand.ExecuteNonQuery()
            Next
            '------------------------------------------FIN CONSIGNACIONES CONTEOS ENCABEZADO
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()

            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------SALDOS -----------------------------------


            dt = myOtrans.Obtiene("CALL pa_sel_um_mov_saldos_tk('" & user & "')")
            For Each dr1 As DataRow In dt.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_cliente_saldo VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("saldo_corriente") & "','" & dr1.Item("saldo1a30") & "','" & dr1.Item("saldo31a60") & "','" & dr1.Item("saldo61a90") & "','" & dr1.Item("saldo91a120") & "','" & dr1.Item("saldomas120") & "','" & dr1.Item("saldo_total") & "')"
                SQLcommand.ExecuteNonQuery()
            Next

            '-------------------------------------------------FIN DE SALDOS-----------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '----------------------------------------- PRODUCTO OFERTA
            Try
                dt = ods4.Tables("ProductoOferta").Copy

            Catch ex As Exception

            End Try

            'dt.TableName = "ProductoOferta"

            For Each dr1 As DataRow In dt.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_producto_oferta VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("producto") & "','" & dr1.Item("ctacte") & "','" & dr1.Item("precio") & "','','','" & dr1.Item("todos") & "','','" & dr1.Item("listaprecio") & "')"
                SQLcommand.ExecuteNonQuery()
            Next

            '------------------------------------------FIN PRODUCTO OFERTA
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            SQLcommand = New SQLiteCommand("begin", SQLconnect)
            SQLcommand.ExecuteNonQuery()
            '-------------------------------------------------EXISTENCIAS -----------------------------------


            dt = myOtrans.Obtiene("call pa_sel_um_mov_producto_existencia_tekne(7,'" & user & "')")
            For Each dr1 As DataRow In dt.Rows
                '  SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "INSERT INTO mov_producto_existencia VALUES ('" & dr1.Item("empresa") & "','" & dr1.Item("producto") & "','" & dr1.Item("bodega") & "','" & dr1.Item("existencia") & "')"
                SQLcommand.ExecuteNonQuery()
            Next

            '-------------------------------------------------FIN DE EXISTENCIAS-----------------------------------
            SQLcommand = New SQLiteCommand("end", SQLconnect)
            SQLcommand.ExecuteNonQuery()


            'dt = myOtrans.Obtiene("call pa_sel_um_mov_cliente_producto_distinto(6,null)")
            'dt.TableName = "producto_cliente"
            'dt.WriteXml(lsRuta & "producto_cliente.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "encuesta"
            'dt.WriteXml(lsRuta & "encuesta.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta_usuario where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "encuesta_usuario"
            'dt.WriteXml(lsRuta & "encuesta_usuario.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta_modelo_detalle where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "modelo_encuesta_detalle"
            'dt.WriteXml(lsRuta & "modelo_encuesta_detalle.xml", XmlWriteMode.WriteSchema)

            'dt = myOtrans.Obtiene("Select * from mov_encuesta_modelo_detalle_alternativa where empresa = 'dmarte1' or empresa = 'codicasa'")
            'dt.TableName = "modelo_encuesta_detalle_alternativa"
            'dt.WriteXml(lsRuta & "modelo_encuesta_detalle_alternativa.xml", XmlWriteMode.WriteSchema)


            ''Subir XML

            Try

                SQLcommand.Connection.Close()
                SQLcommand.Dispose()
                ' SQLcommand.Connection.Close()
                SQLconnect.Close()
                ' Me.Hide()


                Copiar_EstructuraSQLITEP(lsRuta, user)
                ls_sql = "call pa_sel_um_edi_configuracionesTK ('" & user & "')"
                dt = myOtrans.Obtiene(ls_sql)

                ls_sql = "call pa_sel_um_edi_configuraciones ('dmarte')"
                dt2 = myOtrans.Obtiene(ls_sql)



                ' Enviar_Informacion_Sitio_Tekne(lsRuta, dt, dt2)

            Catch ex As Exception
            Finally
                SQLconnect = Nothing

            End Try

            Try
                myOtrans.close()
                Otrans.close()


                ClsGen = Nothing
            Catch ex As Exception

            End Try



        Catch ex As Exception
            'Finally
            ' SQLcommand.Dispose()
            'SQLconnect.Close()

        Finally

        End Try




    End Sub



    Private Sub Copiar_EstructuraSQLITEP(ByVal ruta_archivos As String, ByVal usuario As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim archivos As String()
        Dim archivo As String

        Try

            'archivos = Directory.GetFiles(ruta_archivos & "Estructura\", "*.sqlite")
            archivos = Directory.GetFiles(ruta_archivos, "*.sqlite")

            For Each archivo In archivos
                If archivo.ToLower.IndexOf("sqlite") > 0 Then
                    'ClsGen.Eliminar_Archivo("C:\Aplicaciones\SQLITE\tekne.sqlite")
                    ClsGen.Copiar_Archivo(archivo, ruta_archivos & usuario & "\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1), True)
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Private Function tekeneLlenarEstructuraSaldos(ByVal dtUsuarios As DataTable, ByVal dtClientes As DataTable)
        Dim lsSQl As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        'Dim Otrans as New Transaccional.co
        Dim dt As DataTable
        Dim dtListas As DataTable
        Dim dr, dr_aux As DataRow
        Dim lbAgregar As Boolean
        Dim clsGen As New ClasesGenerales.General

        Dim ls_sql As String = ""

        Dim saldototal As String = "0"
        Dim saldocorriente As String = "0"
        Dim saldo1a30 As String = "0"
        Dim saldo31a60 As String = "0"
        Dim saldo61a90 As String = "0"
        Dim saldo91a120 As String = "0"
        Dim saldomas120 As String = "0"


        Try


            myOtrans.open()
            myOtrans.Obtiene("delete from mov_cliente_saldo")

            dtListas = clsGen.ValoresDistinto(dtClientes, "empresa,listaprecio".Split(","))

            For Each lsEmpresa As String In "DMARTE1,CODICASA,ALAMSA,DIUVA,VINOTECA".Split(",")


                For Each drUsuarios As DataRow In dtUsuarios.Rows
                    lsSQl = "call pa_sel_um_mov_cliente_documentos_pendientes_saldos ('" & lsEmpresa & "','" & drUsuarios.Item("nombre") & "')"
                    dt = myOtrans.Obtiene(lsSQl)


                    'If dr.Item("empresa") = drv_aux.Item("empresa") Then

                    Dim dtaux As DataTable = clsGen.ValoresDistinto(dt, "empresa,ctacte".Split(","))

                    For Each dr In dtaux.Rows
                        dt.DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "'"
                        If dt.DefaultView.Count > 0 Then

                            Dim ls_filtro As String
                            dr_aux = ods4.Tables("cliente_saldos").NewRow
                            dr_aux.Item("empresa") = dr.Item("Empresa")
                            dr_aux.Item("ctacte") = dr.Item("ctacte")

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' and dias_factura < 1"
                            dr_aux.Item("saldo_corriente") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 0 and dias_factura < 31)"
                            dr_aux.Item("saldo1a30") = dt.Compute("sum(saldo)", ls_filtro)
                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldocorriente = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldocorriente = 0
                            End If




                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 30 and dias_factura < 61)"
                            dr_aux.Item("saldo31a60") = dt.Compute("sum(saldo)", ls_filtro)

                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then

                                saldo1a30 = dt.Compute("sum(saldo)", ls_filtro)

                            Else
                                saldo1a30 = 0

                            End If



                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 60 and dias_factura < 91)"
                            dr_aux.Item("saldo61a90") = dt.Compute("sum(saldo)", ls_filtro)

                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldo31a60 = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldo31a60 = 0
                            End If






                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 90 and dias_factura < 121)"
                            dr_aux.Item("saldo91a120") = dt.Compute("sum(saldo)", ls_filtro)



                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldo61a90 = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldo61a90 = 0
                            End If


                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and dias_factura > 120 "
                            dr_aux.Item("saldomas120") = dt.Compute("sum(saldo)", ls_filtro)





                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldo91a120 = (dt.Compute("sum(saldo)", ls_filtro))
                            Else
                                saldo91a120 = 0
                            End If


                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and saldo <> 0"
                            dr_aux.Item("saldo_total") = dt.Compute("sum(saldo)", ls_filtro)


                            saldomas120 = 0


                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldototal = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldototal = 0
                            End If






                            ls_sql = "call pa_ins_documentosPendientes_saldos_tk ('" & dr.Item("Empresa") &
                            "','" & dr.Item("ctacte") & "'," & saldototal & "," & saldocorriente & "," & saldo1a30 & "," &
                            saldo31a60 & "," & saldo61a90 & "," & saldo91a120 & "," & saldomas120 & ")"

                            myOtrans.Ingresa(ls_sql)
                            ods4.Tables("cliente_saldos").Rows.Add(dr_aux)
                        End If
                    Next ''Clientes Saldos


                    'lsSQl = "call pa_sel_um_mov_cliente_documentos_pendientes ('" & lsEmpresa & "','" & drUsuarios.Item("nombre") & "')"
                    'dt = myOtrans.Obtiene(lsSQl)

                    'For Each dr In dt.Rows
                    '    If Math.Abs(Val(dr.Item("saldo").ToString)) >= 0.01 Then
                    '        dr_aux = ods4.Tables("cliente_documento").NewRow
                    '        dr_aux.Item("empresa") = dr.Item("empresa")
                    '        dr_aux.Item("ctacte") = dr.Item("ctacte")
                    '        dr_aux.Item("tipo_docto") = dr.Item("tipo_docto")
                    '        dr_aux.Item("numero") = dr.Item("numero")
                    '        dr_aux.Item("fecha") = dr.Item("fecha")
                    '        dr_aux.Item("saldo") = dr.Item("saldo")
                    '        ods4.Tables("cliente_documento").Rows.Add(dr_aux)
                    '    End If
                    'Next
                Next 'USUARIO


                ''Precios
                'lsSQl = "pa_var_um_listaPrecio '" & lsEmpresa & "'"
                ' dt = myOtrans.Obtiene("call pa_var_um_listaprecio_tekne()")

                'For Each dr In dt.Rows
                '    'Solo Agregara Productos Presupuestados
                '    dtListas.DefaultView.RowFilter = "empresa = '" & lsEmpresa & "' and listaprecio = '" & dr.Item("listaprecio") & "'"
                '    If dtListas.DefaultView.Count > 0 Then
                '        'If ls_listasdePrecios.IndexOf(dr.Item("lisprecio")) > 0 Then
                '        'If pOpciones.ToLower.IndexOf("pda_solo_productos_ppto") > -1 Then
                '        ''Solo productos Presupuestados
                '        'ods.Tables("presupuesto_cliente").DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and producto = '" & dr.Item("producto") & "'"
                '        'If ods.Tables("presupuesto_cliente").DefaultView.Count > 0 Then
                '        lbAgregar = True
                '    Else
                '        lbAgregar = False
                '    End If



                '    If lbAgregar Then
                '        dr_aux = ods4.Tables("ListaPrecio").NewRow
                '        dr_aux.Item("empresa") = dr.Item("Empresa")
                '        dr_aux.Item("producto") = dr.Item("producto")
                '        dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                '        dr_aux.Item("Valor") = dr.Item("valor")
                '        dr_aux.Item("FechaI") = dr.Item("fechaInicio")
                '        dr_aux.Item("FechaF") = dr.Item("fechaFinal")
                '        ods4.Tables("ListaPrecio").Rows.Add(dr_aux)
                '    End If
                '    lbAgregar = False

                'Next


                lsSQl = "call pa_sel_um_mov_productoOferta ('" & lsEmpresa & "')"
                dt = myOtrans.Obtiene(lsSQl)
                lbAgregar = False

                For Each dr In dt.Rows
                    dtListas.DefaultView.RowFilter = "empresa = '" & lsEmpresa & "' and listaprecio = '" & dr.Item("listaprecio") & "'"
                    If dtListas.DefaultView.Count > 0 Then
                        'If ls_listasdePrecios.IndexOf(dr.Item("listaprecio")) > 0 Then
                        ''Envio Solo productos que esten en la lista de precios
                        ' ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"
                        'If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then
                        If dr.Item("todos").ToString.ToLower.Equals("s") Then
                            lbAgregar = True
                        Else
                            dtClientes.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte") & "'"
                            If dtClientes.DefaultView.Count > 0 Then
                                lbAgregar = True
                            End If
                        End If
                        'End If

                        If lbAgregar Then
                            dr_aux = ods4.Tables("ProductoOferta").NewRow
                            dr_aux.Item("empresa") = dr.Item("empresa")
                            dr_aux.Item("producto") = dr.Item("producto")
                            dr_aux.Item("ctacte") = dr.Item("ctacte")
                            dr_aux.Item("Precio") = dr.Item("precio")
                            dr_aux.Item("FechaI") = dr.Item("fechainicio")
                            dr_aux.Item("FechaF") = dr.Item("fechafinal")
                            dr_aux.Item("Todos") = dr.Item("todos")
                            dr_aux.Item("Descripcion") = dr.Item("descripcion")
                            dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                            ods4.Tables("ProductoOferta").Rows.Add(dr_aux)
                            lbAgregar = False
                        End If
                    End If
                Next
            Next 'eMPRESA

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Function

    Private Function tekneLlenarEstructuraConsignaciones(ByVal dtUsuarios As DataTable) As Boolean

        ' Dim drv, drv2, drv_aux As DataRowView
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt_onbase, dt_historial, dt_conteos, dt_saldos, dt_conteos_encabezado As DataTable
        Dim dr, dr_aux As DataRow
        Dim ClsGen As New ClasesGenerales.General
        Dim lbexitoso As Boolean = True
        Dim dt_saldos_clientes As DataTable

        Try
            Otrans.open()
            myOtrans.open()

            Dim ps_usuario As String = String.Empty
            ' If pOpciones.ToLower.IndexOf("pda_consignaciones") > 0 Then
            'ls_sql = "pa_sel_um_gen_tabcod null,'SYSGOLD_EJECUTIVOS'"
            'dt_aux = Otrans.Obtiene(ls_sql)
            'dt_aux.DefaultView.RowFilter = "texto3  <> '" & ps_usuario & "'"


            For Each lsEmpresa As String In "DMARTE1,CODICASA,ALAMSA,DIUVA,VINOTECA".Split(",")

                For Each drUsuarios As DataRow In dtUsuarios.Rows
                    ' For Each drv_aux In dt_aux.DefaultView

                    '   If Not drv_aux.Item("Empresa").ToString.ToLower.Equals("dmarte1") Then

                    ls_sql = "pa_sel_um_consignaciones_saldos_cliente null,'" & lsEmpresa & "',null,'" & drUsuarios.Item("nombre").ToString & "'"
                    dt_saldos_clientes = Otrans.Obtiene(ls_sql)

                    'ods4.Tables("clientes_envio").Rows.Clear()
                    If dt_saldos_clientes.Rows.Count > 0 Then


                        For Each dr In dt_saldos_clientes.Rows
                            ods4.Tables("clientes_envio").DefaultView.RowFilter = "cod_cliente = '" & dr.Item("con_cliente") & "'"
                            If ods4.Tables("clientes_envio").DefaultView.Count = 0 Then
                                dr_aux = ods4.Tables("clientes_envio").NewRow
                                dr_aux.Item("Agregar") = True
                                dr_aux.Item("cod_cliente") = dr.Item("con_cliente")
                                dr_aux.Item("Razon_Social") = dr.Item("RazonSocial")
                                ods4.Tables("clientes_envio").Rows.Add(dr_aux)
                            End If
                        Next

                        ods4.Tables("clientes_envio").DefaultView.RowFilter = "agregar = true"

                        ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion (" & ClsGen.Codigo_Empresa_Onbase(lsEmpresa) & ",null,null)"
                        dt_onbase = myOtrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo (" & ClsGen.Codigo_Empresa_Onbase(lsEmpresa) & ",null,null)"
                        dt_conteos = myOtrans.Obtiene(ls_sql)

                        ls_sql = "call pa_sel_um_crm_cliente_producto_consignacion_conteo_encabezado (" & ClsGen.Codigo_Empresa_Onbase(lsEmpresa) & ",null)"
                        dt_conteos_encabezado = myOtrans.Obtiene(ls_sql)

                        ls_sql = "pa_sel_um_consignaciones null,'" & lsEmpresa & "',null,null,'" & drUsuarios.Item("nombre").ToString & "'"
                        dt_historial = Otrans.Obtiene(ls_sql)
                        ls_sql = "pa_sel_um_consignaciones_saldos null,'" & lsEmpresa & "',null,null,'" & drUsuarios.Item("nombre").ToString & "'"
                        dt_saldos = Otrans.Obtiene(ls_sql)



                        For Each drv As DataRowView In ods4.Tables("clientes_envio").DefaultView
                            'ls_sql = "pa_sel_um_consignaciones_saldos_cliente '" & drv.Item("cod_cliente") & "','" & drv_aux.Item("Empresa") & "',null,'" & drv_aux.Item("DESCRIPCION").ToString & "'"
                            'dt = Otrans.Obtiene(ls_sql)
                            dt_saldos_clientes.DefaultView.RowFilter = "con_empresa = '" & lsEmpresa & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                            For Each drv3 As DataRowView In dt_saldos_clientes.DefaultView

                                dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                                dr_aux.Item("empresa") = lsEmpresa
                                dr_aux.Item("ctacte") = drv3.Item("con_cliente")
                                dr_aux.Item("producto") = drv3.Item("con_producto")
                                dr_aux.Item("saldo") = drv3.Item("saldo")
                                dr_aux.Item("cantidad_aprobada") = 0

                                dt_onbase.DefaultView.RowFilter = "cod_cliente_flex = '" & drv3.Item("con_cliente") & "' and cod_producto_flex = '" & drv3.Item("con_producto") & "'"
                                If dt_onbase.DefaultView.Count > 0 Then
                                    dr_aux.Item("cantidad_aprobada") = dt_onbase.DefaultView(0)("cantidad_maxima").ToString
                                End If

                                ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                            Next



                            dt_historial.DefaultView.RowFilter = "con_empresa = '" & lsEmpresa & "' and con_cliente = '" & drv.Item("cod_cliente") & "'"
                            If dt_historial.DefaultView.Count > 0 Then
                                For Each drv2 As DataRowView In dt_historial.DefaultView

                                    dt_saldos.DefaultView.RowFilter = "con_cliente = '" & drv2.Item("con_cliente").ToString &
                                                                       "' and con_numero = '" & drv2.Item("con_numero").ToString &
                                                                       "' and con_producto = '" & drv2.Item("con_producto").ToString &
                                                                       "' and saldo > 0"

                                    If dt_saldos.DefaultView.Count > 0 Then
                                        dr_aux = ods4.Tables("consignaciones_movimientos_historicos").NewRow
                                        dr_aux.Item("empresa") = lsEmpresa
                                        dr_aux.Item("ctacte") = drv2.Item("con_cliente")
                                        dr_aux.Item("producto") = drv2.Item("con_producto")
                                        dr_aux.Item("tipo") = drv2.Item("fd_tipo")
                                        If drv2.Item("fd_tipo").ToString.ToLower.StartsWith("con") Then
                                            dr_aux.Item("numero") = drv2.Item("con_numero")
                                            dr_aux.Item("fecha") = drv2.Item("con_fecha")
                                            dr_aux.Item("Cantidad") = drv2.Item("con_cant")
                                        Else
                                            dr_aux.Item("numero") = drv2.Item("fd_numero")
                                            dr_aux.Item("fecha") = drv2.Item("fd_fecha")
                                            dr_aux.Item("Cantidad") = drv2.Item("fd_cantidad")
                                        End If
                                        dr_aux.Item("consignacion") = drv2.Item("con_numero")
                                        ods4.Tables("consignaciones_movimientos_historicos").Rows.Add(dr_aux)
                                    Else

                                    End If

                                Next
                            End If


                            dt_conteos.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                            If dt_conteos.DefaultView.Count > 0 Then
                                For Each drv2 As DataRowView In dt_conteos.DefaultView
                                    If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then
                                        dr_aux = ods4.Tables("consignaciones_conteos").NewRow
                                        dr_aux.Item("cod_conteo") = Val(drv2.Item("cod_conteo").ToString)
                                        dr_aux.Item("empresa") = lsEmpresa
                                        dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                        dr_aux.Item("producto") = drv2.Item("cod_producto_flex")
                                        dr_aux.Item("cantidad") = drv2.Item("conteo")
                                        dr_aux.Item("fecha") = drv2.Item("fecha")

                                        ods4.Tables("consignaciones_conteos").Rows.Add(dr_aux)
                                    End If
                                Next

                            End If


                            dt_conteos_encabezado.DefaultView.RowFilter = "cod_cliente_flex = '" & drv.Item("cod_cliente") & "'"
                            If dt_conteos_encabezado.DefaultView.Count > 0 Then
                                For Each drv2 As DataRowView In dt_conteos_encabezado.DefaultView
                                    If DateDiff(DateInterval.Day, Date.Parse(drv2.Item("fecha").ToString), Today) < 45 Then

                                        dr_aux = ods4.Tables("consignaciones_conteos_encabezado").NewRow
                                        dr_aux.Item("cod_conteo") = drv2.Item("cod_conteo").ToString
                                        dr_aux.Item("empresa") = lsEmpresa
                                        dr_aux.Item("ctacte") = drv2.Item("cod_cliente_flex")
                                        dr_aux.Item("fecha") = drv2.Item("fecha")
                                        dr_aux.Item("usuario_grabo") = drv2.Item("usuario_grabo").ToString
                                        ods4.Tables("consignaciones_conteos_encabezado").Rows.Add(dr_aux)
                                    End If
                                Next

                            End If

                        Next 'Clientes Envio
                    End If
                    ''Este proceso es para complementar los productos que no han tenido movimiento pero que tienen saldo
                    'For Each dr In dt_onbase.Rows
                    '    ods4.Tables("consignaciones_saldos").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' " & _
                    '            " and ctacte = '" & dr.Item("cod_cliente_flex") & "' and producto = '" & dr.Item("cod_producto_flex") & "'"
                    '    If ods4.Tables("consignaciones_saldos").DefaultView.Count = 0 Then
                    '        ods3.Tables("cliente").DefaultView.RowFilter = "empresa = '" & drv_aux.Item("empresa") & "' and ctacte = '" & dr.Item("cod_cliente_flex") & "'"
                    '        If ods3.Tables("cliente").DefaultView.Count > 0 Then 'Me aseguro que el cliente pertenezca al vendedor
                    '            dr_aux = ods4.Tables("consignaciones_saldos").NewRow
                    '            dr_aux.Item("empresa") = drv_aux.Item("Empresa")
                    '            dr_aux.Item("ctacte") = dr.Item("cod_cliente_flex")
                    '            dr_aux.Item("producto") = dr.Item("cod_producto_flex")
                    '            dr_aux.Item("saldo") = 0 ' Por que no hay saldo//drv3.Item("saldo")
                    '            dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
                    '            ods4.Tables("consignaciones_saldos").Rows.Add(dr_aux)
                    '        End If
                    '    End If
                    'Next
                    '(c) 0712 Se debe verificar que los clientes que no hayan tenido ningun movimiento y tenga productos aprobados tambien se envien

                    '  End If
                Next 'Usuarios
            Next 'Empresas a los que el usuario tiene acceso
            ' End If  ''Opciones


        Catch ex As Exception
            lbexitoso = False
        Finally
            oFlex.close()
            oFlex = Nothing
            Otrans.close()
            Otrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return lbexitoso

    End Function

    Public Sub crearEstructura()
        Dim dt As New DataTable









        dt = New DataTable("consignaciones_saldos")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cantidad_aprobada", GetType(Integer)))
        dt.TableName = "consignaciones_saldos"
        If ods4.Tables.Contains("consignaciones_saldos") Then ods4.Tables.Remove("consignaciones_saldos")
        ods4.Tables.Add(dt.Copy)







        dt = New DataTable("consignaciones_movimientos_historicos")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("consignacion", GetType(String)))

        dt.TableName = "consignaciones_movimientos_historicos"
        If ods4.Tables.Contains("consignaciones_movimientos_historicos") Then ods4.Tables.Remove("consignaciones_movimientos_historicos")
        ods4.Tables.Add(dt.Copy)



        dt = New DataTable("consignaciones_conteos")
        dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt.TableName = "consignaciones_conteos"
        If ods4.Tables.Contains("consignaciones_conteos") Then ods4.Tables.Remove("consignaciones_conteos")
        ods4.Tables.Add(dt.Copy)




        dt = New DataTable("consignaciones_conteos_encabezado")
        dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("comentarios_reposicion", GetType(String)))
        dt.Columns.Add(New DataColumn("comentarios_factura", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt.TableName = "consignaciones_conteos_encabezado"
        If ods4.Tables.Contains("consignaciones_conteos_encabezado") Then ods4.Tables.Remove("consignaciones_conteos_encabezado")
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("clientes_envio")
        dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
        dt.TableName = "clientes_envio"
        If ods4.Tables.Contains("clientes_envio") Then ods4.Tables.Remove("clientes_envio")
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("cliente_saldos")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("CtaCte", GetType(String))
        dt.Columns.Add("saldo_total", GetType(Double))
        dt.Columns.Add("saldo_corriente", GetType(Double))
        dt.Columns.Add("saldo1a30", GetType(Double))
        dt.Columns.Add("saldo31a60", GetType(Double))
        dt.Columns.Add("saldo61a90", GetType(Double))
        dt.Columns.Add("saldo91a120", GetType(Double))
        dt.Columns.Add("saldomas120", GetType(Double))
        dt.TableName = "cliente_saldos"
        If ods4.Tables.Contains("cliente_saldos") Then ods4.Tables.Remove("cliente_saldos")
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("cliente_documento")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("ctaCte", GetType(String))
        dt.Columns.Add("tipo_docto", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("fecha", GetType(DateTime))
        dt.Columns.Add("saldo", GetType(Double))
        dt.TableName = "cliente_documento"
        If ods4.Tables.Contains("cliente_documento") Then ods4.Tables.Remove("cliente_documento")
        ods4.Tables.Add(dt.Copy)


        dt = New DataTable("ListaPrecio")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("ListaPrecio", GetType(String))
        dt.Columns.Add("Valor", GetType(Double))
        dt.Columns.Add("FechaI", GetType(String))
        dt.Columns.Add("FechaF", GetType(String))
        dt.TableName = "ListaPrecio"
        If ods4.Tables.Contains("ListaPrecio") Then ods4.Tables.Remove("ListaPrecio")

        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("ProductoOferta")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("ctacte", GetType(String))
        dt.Columns.Add("Precio", GetType(Double))
        dt.Columns.Add("FechaI", GetType(String))
        dt.Columns.Add("FechaF", GetType(String))
        dt.Columns.Add("Todos", GetType(String))
        dt.Columns.Add("Descripcion", GetType(String))
        dt.Columns.Add("ListaPrecio", GetType(String))
        dt.TableName = "ProductoOferta"
        If ods4.Tables.Contains("ProductoOferta") Then ods4.Tables.Remove("ProductoOferta")
        ods4.Tables.Add(dt.Copy)



























        'dt = New DataTable("consignaciones_saldos")
        'dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        'dt.Columns.Add(New DataColumn("producto", GetType(String)))
        'dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("cantidad_aprobada", GetType(Integer)))


        'ods4.Tables.Add(dt.Copy)

        'dt = New DataTable("consignaciones_movimientos_historicos")
        'dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        'dt.Columns.Add(New DataColumn("producto", GetType(String)))
        'dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
        'dt.Columns.Add(New DataColumn("numero", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        'dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("consignacion", GetType(String)))
        'ods4.Tables.Add(dt.Copy)



        'dt = New DataTable("consignaciones_conteos")
        'dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        'dt.Columns.Add(New DataColumn("producto", GetType(String)))
        'dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        'dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        'ods4.Tables.Add(dt.Copy)

        'dt = New DataTable("consignaciones_conteos_encabezado")
        'dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        'dt.Columns.Add(New DataColumn("comentarios_reposicion", GetType(String)))
        'dt.Columns.Add(New DataColumn("comentarios_factura", GetType(String)))
        'dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        'ods4.Tables.Add(dt.Copy)

        'dt = New DataTable("clientes_envio")
        'dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
        'dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
        'ods4.Tables.Add(dt.Copy)

        'dt = New DataTable("cliente_saldos")
        'dt.Columns.Add("empresa", GetType(String))
        'dt.Columns.Add("CtaCte", GetType(String))
        'dt.Columns.Add("saldo_total", GetType(Double))
        'dt.Columns.Add("saldo_corriente", GetType(Double))
        'dt.Columns.Add("saldo1a30", GetType(Double))
        'dt.Columns.Add("saldo31a60", GetType(Double))
        'dt.Columns.Add("saldo61a90", GetType(Double))
        'dt.Columns.Add("saldo91a120", GetType(Double))
        'dt.Columns.Add("saldomas120", GetType(Double))
        'ods4.Tables.Add(dt.Copy)

        'dt = New DataTable("cliente_documento")
        'dt.Columns.Add("empresa", GetType(String))
        'dt.Columns.Add("ctaCte", GetType(String))
        'dt.Columns.Add("tipo_docto", GetType(String))
        'dt.Columns.Add("numero", GetType(String))
        'dt.Columns.Add("fecha", GetType(DateTime))
        'dt.Columns.Add("saldo", GetType(Double))
        'ods4.Tables.Add(dt.Copy)

        'dt = New DataTable("ListaPrecio")
        'dt.Columns.Add("empresa", GetType(String))
        'dt.Columns.Add("producto", GetType(String))
        'dt.Columns.Add("ListaPrecio", GetType(String))
        'dt.Columns.Add("Valor", GetType(Double))
        'dt.Columns.Add("FechaI", GetType(String))
        'dt.Columns.Add("FechaF", GetType(String))
        'ods4.Tables.Add(dt.Copy)

        'dt = New DataTable("ProductoOferta")
        'dt.Columns.Add("empresa", GetType(String))
        'dt.Columns.Add("producto", GetType(String))
        'dt.Columns.Add("ctacte", GetType(String))
        'dt.Columns.Add("Precio", GetType(Double))
        'dt.Columns.Add("FechaI", GetType(String))
        'dt.Columns.Add("FechaF", GetType(String))
        'dt.Columns.Add("Todos", GetType(String))
        'dt.Columns.Add("Descripcion", GetType(String))
        'dt.Columns.Add("ListaPrecio", GetType(String))
        'ods4.Tables.Add(dt.Copy)
    End Sub

    Public Sub crearEstructura(ByRef ods4 As DataSet)
        Dim dt As New DataTable




        dt = New DataTable("consignaciones_saldos")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cantidad_aprobada", GetType(Integer)))
        dt.TableName = "consignaciones_saldos"
        If ods4.Tables.Contains("consignaciones_saldos") Then ods4.Tables.Remove("consignaciones_saldos")
        ods4.Tables.Add(dt.Copy)







        dt = New DataTable("consignaciones_movimientos_historicos")
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("consignacion", GetType(String)))

        dt.TableName = "consignaciones_movimientos_historicos"
        If ods4.Tables.Contains("consignaciones_movimientos_historicos") Then ods4.Tables.Remove("consignaciones_movimientos_historicos")
        ods4.Tables.Add(dt.Copy)



        dt = New DataTable("consignaciones_conteos")
        dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("producto", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt.TableName = "consignaciones_conteos"
        If ods4.Tables.Contains("consignaciones_conteos") Then ods4.Tables.Remove("consignaciones_conteos")
        ods4.Tables.Add(dt.Copy)




        dt = New DataTable("consignaciones_conteos_encabezado")
        dt.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("comentarios_reposicion", GetType(String)))
        dt.Columns.Add(New DataColumn("comentarios_factura", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
        dt.TableName = "consignaciones_conteos_encabezado"
        If ods4.Tables.Contains("consignaciones_conteos_encabezado") Then ods4.Tables.Remove("consignaciones_conteos_encabezado")
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("clientes_envio")
        dt.Columns.Add(New DataColumn("Agregar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
        dt.TableName = "clientes_envio"
        If ods4.Tables.Contains("clientes_envio") Then ods4.Tables.Remove("clientes_envio")
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("cliente_saldos")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("CtaCte", GetType(String))
        dt.Columns.Add("saldo_total", GetType(Double))
        dt.Columns.Add("saldo_corriente", GetType(Double))
        dt.Columns.Add("saldo1a30", GetType(Double))
        dt.Columns.Add("saldo31a60", GetType(Double))
        dt.Columns.Add("saldo61a90", GetType(Double))
        dt.Columns.Add("saldo91a120", GetType(Double))
        dt.Columns.Add("saldomas120", GetType(Double))
        dt.TableName = "cliente_saldos"
        If ods4.Tables.Contains("cliente_saldos") Then ods4.Tables.Remove("cliente_saldos")
        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("cliente_documento")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("ctaCte", GetType(String))
        dt.Columns.Add("tipo_docto", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("fecha", GetType(DateTime))
        dt.Columns.Add("saldo", GetType(Double))
        dt.TableName = "cliente_documento"
        If ods4.Tables.Contains("cliente_documento") Then ods4.Tables.Remove("cliente_documento")
        ods4.Tables.Add(dt.Copy)


        dt = New DataTable("ListaPrecio")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("ListaPrecio", GetType(String))
        dt.Columns.Add("Valor", GetType(Double))
        dt.Columns.Add("FechaI", GetType(String))
        dt.Columns.Add("FechaF", GetType(String))
        dt.TableName = "ListaPrecio"
        If ods4.Tables.Contains("ListaPrecio") Then ods4.Tables.Remove("ListaPrecio")

        ods4.Tables.Add(dt.Copy)

        dt = New DataTable("ProductoOferta")
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("producto", GetType(String))
        dt.Columns.Add("ctacte", GetType(String))
        dt.Columns.Add("Precio", GetType(Double))
        dt.Columns.Add("FechaI", GetType(String))
        dt.Columns.Add("FechaF", GetType(String))
        dt.Columns.Add("Todos", GetType(String))
        dt.Columns.Add("Descripcion", GetType(String))
        dt.Columns.Add("ListaPrecio", GetType(String))
        dt.TableName = "ProductoOferta"
        If ods4.Tables.Contains("ProductoOferta") Then ods4.Tables.Remove("ProductoOferta")
        ods4.Tables.Add(dt.Copy)

    End Sub

    Private Function tekeneLlenarEstructuraSaldos(ByVal dtUsuarios As DataTable, ByVal dtClientes As DataTable, ByRef ods4 As DataSet)
        Dim lsSQl As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        'Dim Otrans as New Transaccional.co
        Dim dt As DataTable
        Dim dtListas As DataTable
        Dim dr, dr_aux As DataRow
        Dim lbAgregar As Boolean
        Dim clsGen As New ClasesGenerales.General

        Dim ls_sql As String = ""

        Dim saldototal As String = "0"
        Dim saldocorriente As String = "0"
        Dim saldo1a30 As String = "0"
        Dim saldo31a60 As String = "0"
        Dim saldo61a90 As String = "0"
        Dim saldo91a120 As String = "0"
        Dim saldomas120 As String = "0"


        Try


            myOtrans.open()
            myOtrans.Obtiene("delete from mov_cliente_saldo")

            dtListas = clsGen.ValoresDistinto(dtClientes, "empresa,listaprecio".Split(","))

            For Each lsEmpresa As String In "DMARTE1,CODICASA,ALAMSA,DIUVA,VINOTECA".Split(",")


                For Each drUsuarios As DataRow In dtUsuarios.Rows
                    lsSQl = "call pa_sel_um_mov_cliente_documentos_pendientes_saldos ('" & lsEmpresa & "','" & drUsuarios.Item("nombre") & "')"
                    dt = myOtrans.Obtiene(lsSQl)


                    'If dr.Item("empresa") = drv_aux.Item("empresa") Then

                    Dim dtaux As DataTable = clsGen.ValoresDistinto(dt, "empresa,ctacte".Split(","))

                    For Each dr In dtaux.Rows
                        dt.DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "'"
                        If dt.DefaultView.Count > 0 Then

                            Dim ls_filtro As String
                            dr_aux = ods4.Tables("cliente_saldos").NewRow
                            dr_aux.Item("empresa") = dr.Item("Empresa")
                            dr_aux.Item("ctacte") = dr.Item("ctacte")

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' and dias_factura < 1"
                            dr_aux.Item("saldo_corriente") = dt.Compute("sum(saldo)", ls_filtro)

                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 0 and dias_factura < 31)"
                            dr_aux.Item("saldo1a30") = dt.Compute("sum(saldo)", ls_filtro)
                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldocorriente = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldocorriente = 0
                            End If




                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 30 and dias_factura < 61)"
                            dr_aux.Item("saldo31a60") = dt.Compute("sum(saldo)", ls_filtro)

                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then

                                saldo1a30 = dt.Compute("sum(saldo)", ls_filtro)

                            Else
                                saldo1a30 = 0

                            End If



                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 60 and dias_factura < 91)"
                            dr_aux.Item("saldo61a90") = dt.Compute("sum(saldo)", ls_filtro)

                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldo31a60 = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldo31a60 = 0
                            End If






                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and (dias_factura > 90 and dias_factura < 121)"
                            dr_aux.Item("saldo91a120") = dt.Compute("sum(saldo)", ls_filtro)



                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldo61a90 = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldo61a90 = 0
                            End If


                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and dias_factura > 120 "
                            dr_aux.Item("saldomas120") = dt.Compute("sum(saldo)", ls_filtro)





                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldo91a120 = (dt.Compute("sum(saldo)", ls_filtro))
                            Else
                                saldo91a120 = 0
                            End If


                            ls_filtro = "empresa = '" & dr.Item("Empresa") & "' and ctacte = '" & dr.Item("ctacte").ToString & "' "
                            ls_filtro += "and saldo <> 0"
                            dr_aux.Item("saldo_total") = dt.Compute("sum(saldo)", ls_filtro)


                            saldomas120 = 0


                            If dt.Compute("sum(saldo)", ls_filtro).ToString.Length > 0 Then
                                saldototal = dt.Compute("sum(saldo)", ls_filtro)
                            Else
                                saldototal = 0
                            End If






                            ls_sql = "call pa_ins_documentosPendientes_saldos_tk ('" & dr.Item("Empresa") &
                            "','" & dr.Item("ctacte") & "'," & saldototal & "," & saldocorriente & "," & saldo1a30 & "," &
                            saldo31a60 & "," & saldo61a90 & "," & saldo91a120 & "," & saldomas120 & ")"

                            myOtrans.Ingresa(ls_sql)
                            ods4.Tables("cliente_saldos").Rows.Add(dr_aux)
                        End If
                    Next ''Clientes Saldos


                    'lsSQl = "call pa_sel_um_mov_cliente_documentos_pendientes ('" & lsEmpresa & "','" & drUsuarios.Item("nombre") & "')"
                    'dt = myOtrans.Obtiene(lsSQl)

                    'For Each dr In dt.Rows
                    '    If Math.Abs(Val(dr.Item("saldo").ToString)) >= 0.01 Then
                    '        dr_aux = ods4.Tables("cliente_documento").NewRow
                    '        dr_aux.Item("empresa") = dr.Item("empresa")
                    '        dr_aux.Item("ctacte") = dr.Item("ctacte")
                    '        dr_aux.Item("tipo_docto") = dr.Item("tipo_docto")
                    '        dr_aux.Item("numero") = dr.Item("numero")
                    '        dr_aux.Item("fecha") = dr.Item("fecha")
                    '        dr_aux.Item("saldo") = dr.Item("saldo")
                    '        ods4.Tables("cliente_documento").Rows.Add(dr_aux)
                    '    End If
                    'Next
                Next 'USUARIO


                ''Precios
                'lsSQl = "pa_var_um_listaPrecio '" & lsEmpresa & "'"
                ' dt = myOtrans.Obtiene("call pa_var_um_listaprecio_tekne()")

                'For Each dr In dt.Rows
                '    'Solo Agregara Productos Presupuestados
                '    dtListas.DefaultView.RowFilter = "empresa = '" & lsEmpresa & "' and listaprecio = '" & dr.Item("listaprecio") & "'"
                '    If dtListas.DefaultView.Count > 0 Then
                '        'If ls_listasdePrecios.IndexOf(dr.Item("lisprecio")) > 0 Then
                '        'If pOpciones.ToLower.IndexOf("pda_solo_productos_ppto") > -1 Then
                '        ''Solo productos Presupuestados
                '        'ods.Tables("presupuesto_cliente").DefaultView.RowFilter = "empresa = '" & dr.Item("Empresa") & "' and producto = '" & dr.Item("producto") & "'"
                '        'If ods.Tables("presupuesto_cliente").DefaultView.Count > 0 Then
                '        lbAgregar = True
                '    Else
                '        lbAgregar = False
                '    End If



                '    If lbAgregar Then
                '        dr_aux = ods4.Tables("ListaPrecio").NewRow
                '        dr_aux.Item("empresa") = dr.Item("Empresa")
                '        dr_aux.Item("producto") = dr.Item("producto")
                '        dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                '        dr_aux.Item("Valor") = dr.Item("valor")
                '        dr_aux.Item("FechaI") = dr.Item("fechaInicio")
                '        dr_aux.Item("FechaF") = dr.Item("fechaFinal")
                '        ods4.Tables("ListaPrecio").Rows.Add(dr_aux)
                '    End If
                '    lbAgregar = False

                'Next


                lsSQl = "call pa_sel_um_mov_productoOferta ('" & lsEmpresa & "')"
                dt = myOtrans.Obtiene(lsSQl)
                lbAgregar = False

                For Each dr In dt.Rows
                    dtListas.DefaultView.RowFilter = "empresa = '" & lsEmpresa & "' and listaprecio = '" & dr.Item("listaprecio") & "'"
                    If dtListas.DefaultView.Count > 0 Then
                        'If ls_listasdePrecios.IndexOf(dr.Item("listaprecio")) > 0 Then
                        ''Envio Solo productos que esten en la lista de precios
                        ' ods2.Tables("ListaPrecio").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa") & "' and producto = '" & dr.Item("producto").ToString & "'"
                        'If ods2.Tables("ListaPrecio").DefaultView.Count > 0 Then
                        If dr.Item("todos").ToString.ToLower.Equals("s") Then
                            lbAgregar = True
                        Else
                            dtClientes.DefaultView.RowFilter = "ctacte = '" & dr.Item("ctacte") & "'"
                            If dtClientes.DefaultView.Count > 0 Then
                                lbAgregar = True
                            End If
                        End If
                        'End If

                        If lbAgregar Then
                            dr_aux = ods4.Tables("ProductoOferta").NewRow
                            dr_aux.Item("empresa") = dr.Item("empresa")
                            dr_aux.Item("producto") = dr.Item("producto")
                            dr_aux.Item("ctacte") = dr.Item("ctacte")
                            dr_aux.Item("Precio") = dr.Item("precio")
                            dr_aux.Item("FechaI") = dr.Item("fechainicio")
                            dr_aux.Item("FechaF") = dr.Item("fechafinal")
                            dr_aux.Item("Todos") = dr.Item("todos")
                            dr_aux.Item("Descripcion") = dr.Item("descripcion")
                            dr_aux.Item("ListaPrecio") = dr.Item("ListaPrecio").ToString.ToUpper
                            ods4.Tables("ProductoOferta").Rows.Add(dr_aux)
                            lbAgregar = False
                        End If
                    End If
                Next
            Next 'eMPRESA

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Function

    Private Sub Copiar_EstructuraSQLITE(ByVal ruta_archivos As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim archivos As String()
        Dim archivo As String

        Try
            archivos = Directory.GetFiles(ruta_archivos & "Estructura\", "*.sqlite")

            For Each archivo In archivos
                If archivo.ToLower.IndexOf("sqlite") > 0 Then
                    ClsGen.Eliminar_Archivo("C:\Aplicaciones\SQLITE\tekne.sqlite")
                    ClsGen.Copiar_Archivo(archivo, ruta_archivos & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1), True)
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Copiar_EstructuraSQLiteProcesado(ByVal ruta_archivos As String, ByVal usuario As String)
        Dim ClsGen As New ClasesGenerales.General
        Dim archivos As String()
        Dim archivo As String

        Try

            'archivos = Directory.GetFiles(ruta_archivos & "Estructura\", "*.sqlite")
            archivos = Directory.GetFiles(ruta_archivos, "*.sqlite")

            For Each archivo In archivos
                If archivo.ToLower.IndexOf("sqlite") > 0 Then
                    'ClsGen.Eliminar_Archivo("C:\Aplicaciones\SQLITE\tekne.sqlite")
                    ClsGen.Copiar_Archivo(archivo, ruta_archivos & usuario & "\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1), True)
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub


    Private Sub Enviar_Informacion_Sitio_Tekne(ByVal psRuta As String, psUsuario As String)
        Dim ff As New FTP.clsFTP

        Dim archivos() As String
        '        Dim archivo As String
        '       Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General


        Try
            ClsGen.Escribir_Log("Enviando Informacion FTP Tekne  " & psUsuario)
            ff = New FTP.clsFTP


            ff.RemoteHost = "tekne.com.gt"
            ff.RemoteUser = "tecnosol"
            ff.RemotePassword = "Tecno@2011"

            'ff.RemoteHost = dataFtp.Rows(0).Item("host") 'drv.Item("host")
            'ff.RemoteUser = dataFtp.Rows(0).Item("usuario") 'drv.Item("usuario")
            'ff.RemotePassword = dataFtp.Rows(0).Item("password") ' drv.Item("password")



            If (ff.Login()) Then
                ff.ChangeDirectory("/public_html/tekne.com.gt/tekne/bd") 'drv.Item("carpeta").ToString)
                ff.ChangeDirectory(psUsuario)
                ff.SetBinaryMode(True)
                'Try
                'archivos = ff.GetFileList("*.txt")
                'Catch ex As Exception

                'End Try
                Dim dimension As String = ""
                'ff.UploadFile("C:\Aplicaciones\SQLITE\" & dataUser.Rows(0).Item("descripcion").ToString & "\tekne.sqlite")
                'dimension = getTamFile("C:\Aplicaciones\SQLITE\" & dataUser.Rows(0).Item("descripcion").ToString & "\tekne.sqlite")

                ClsGen.Escribir_Log("Subiendo Informacion FTP Tekne  " & psUsuario)
                ff.UploadFile(psRuta & psUsuario & "\tekne.sqlite")
                dimension = getTamFile(psRuta & psUsuario & "\tekne.sqlite")


                ClsGen.Escribir_Log("Tamaño de Archivo Enviado: " & dimension)
                ff.CloseConnection()
            End If

            ff = Nothing
        Catch ex As System.Exception            '        
            'ClsGen.Escribir_Log("Envio de Informacion Warning " & psUsuario)
            ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString & " -- " & ex.ToString)
        Finally

            ClsGen = Nothing
        End Try
    End Sub


    Public Function getTamFile(ByVal path As String) As String
        Dim fi As New FileInfo(path)
        If fi.Exists Then
            If (fi.Length / 1024) > 1024 Then
                Return Math.Round(((fi.Length / 1024) / 1024), 2).ToString() & " Mb"
            Else
                Return Math.Round((fi.Length / 1024), 2).ToString() & " Kb"
            End If
        Else
            Return String.Empty
        End If
    End Function



    Private Function Procesar_ConsignacionesTekne(ByVal archivoXML As String)
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Dim dFecha_Creacion_Archivo As DateTime
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim CodigoCliente As Integer
        Dim encabezado(), detalle(), linea() As String
        Dim precio_unitario As Double
        Dim lbExitoso As Boolean = True


        Try
            myOtrans.open()



            Try
                ods.Tables("encabezado_consignacion").Clear()
            Catch ex As Exception

            End Try
            ods.ReadXml(archivoXML)
            dr_encabezado = ods.Tables("encabezado").Rows(0)




            Dim Archivo As New FileInfo(archivoXML)
            dFecha_Creacion_Archivo = Archivo.CreationTime
            Dim codempresa As Integer = 0
            Dim codCliente As String = ""
            Dim fechaConteo As String = ""
            Dim UsuarioConteo As String = ""
            With dr_encabezado
                codempresa = 0
                codCliente = ""
                fechaConteo = ""
                UsuarioConteo = ""
                encabezado = .Item("encabezado_consignacion").ToString.Split("|")

                ''Guardar 



                If encabezado(0).ToString.ToUpper = "DMARTE1" Then
                    codempresa = 1
                End If
                If encabezado(0).ToString.ToUpper = "DIUVA" Then
                    codempresa = 6
                End If
                If encabezado(0).ToString.ToUpper = "VINOTECA" Then
                    codempresa = 7

                End If
                If encabezado(0).ToString.ToUpper = "CODICASA" Then
                    codempresa = 2

                End If

                codCliente = encabezado(2).ToString
                fechaConteo = encabezado(3).ToString
                UsuarioConteo = encabezado(6).ToString

                ls_sql = "call pa_ins_um_crm_cliente_producto_consignacion_conteo_encabezado (" &
                         codempresa & ",'" & encabezado(2).ToString & "','" &
                         encabezado(3).ToString & "','" & encabezado(5).ToString & "','" &
                         encabezado(4).ToString & "','" & encabezado(6).ToString & "')"


                myOtrans.Ingresa(ls_sql)

                If myOtrans.Codigo_error = 0 Then
                    dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString
                    For icount As Integer = 1 To 7

                        If .Item("detalle" & icount.ToString).ToString.Length > 0 Then
                            detalle = .Item("detalle" & icount.ToString).ToString.Split("$")
                        Else
                            detalle = Nothing
                        End If


                        If Not detalle Is Nothing Then


                            For Each lineas As String In detalle
                                linea = lineas.Split("|")
                                If linea.Length > 1 Then


                                    If linea(0).StartsWith(encabezado(0).ToString) Then
                                        ls_sql = "call pa_ins_um_crm_cliente_producto_consignacion_conteo    (" & codempresa & ",'" &
                                                         codCliente & "','" & linea(2).ToString & "','" &
                                                         fechaConteo & "'," & linea(3).ToString & ",0,'" &
                                                         UsuarioConteo & "'," & numero_pedido & ")"

                                        myOtrans.Ingresa(ls_sql)
                                        If myOtrans.Codigo_error > 0 Then
                                            lbExitoso = False
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next

                Else
                    If myOtrans.descripcion_error.ToLower.IndexOf("uplicate") > 0 Then
                        numero_pedido = 1 'No Permite Informacion Duplicada
                    End If



                End If
            End With
            If numero_pedido > 0 And lbExitoso Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
            End If


        Catch ex As Exception
        Finally

            myOtrans.close()
            myOtrans = Nothing

            ClsGen = Nothing
        End Try
        Return lbExitoso
    End Function


    Private Function Procesar_ConsignacionesTekneGestion(ByVal archivoXML As String)
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Corporativo")

        Dim dFecha_Creacion_Archivo As DateTime
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim CodigoCliente As Integer
        Dim encabezado(), detalle(), linea() As String
        Dim precio_unitario As Double
        Dim lbExitoso As Boolean = True


        Try
            Otrans.open()



            Try
                ods.Tables("encabezado_consignacion").Clear()
            Catch ex As Exception

            End Try
            ods.ReadXml(archivoXML)
            dr_encabezado = ods.Tables("encabezado").Rows(0)




            Dim Archivo As New FileInfo(archivoXML)
            dFecha_Creacion_Archivo = Archivo.CreationTime
            Dim codempresa As Integer = 0
            Dim codCliente As String = ""
            Dim fechaConteo As String = ""
            Dim UsuarioConteo As String = ""
            Dim iCantidadLineas As Integer = 0
            Dim iCantidadContada As Integer = 0

            With dr_encabezado
                codempresa = 0
                codCliente = ""
                fechaConteo = ""
                UsuarioConteo = ""
                encabezado = .Item("encabezado_consignacion").ToString.Split("|")

                ''Guardar 



                If encabezado(0).ToString.ToUpper = "DMARTE1" Then codempresa = 1
                If encabezado(0).ToString.ToUpper = "DIUVA" Then codempresa = 6
                If encabezado(0).ToString.ToUpper = "VINOTECA" Then codempresa = 7
                If encabezado(0).ToString.ToUpper = "CODICASA" Then codempresa = 2

                codCliente = encabezado(2).ToString
                fechaConteo = encabezado(3).ToString.Split("-")(2) + "-" + encabezado(3).ToString.Split("-")(1) + "-" + encabezado(3).ToString.Split("-")(0)

                UsuarioConteo = encabezado(6).ToString

                ls_sql = "pa_ins_um_mov_consignacion_conteo_encabezado " &
                         codempresa & ",'" & encabezado(2).ToString & "','" &
                         fechaConteo & "','" & encabezado(5).ToString & "','" &
                         encabezado(4).ToString & "','" & encabezado(6).ToString & "'"


                Otrans.Ingresa(ls_sql)

                If Otrans.Codigo_error = 0 Then
                    dt = Otrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString
                    For icount As Integer = 1 To 7

                        If .Item("detalle" & icount.ToString).ToString.Length > 0 Then
                            detalle = .Item("detalle" & icount.ToString).ToString.Split("$")
                        Else
                            detalle = Nothing
                        End If


                        If Not detalle Is Nothing Then


                            For Each lineas As String In detalle
                                linea = lineas.Split("|")
                                If linea.Length > 1 Then

                                    If linea(0).StartsWith(encabezado(0).ToString) Then
                                        ls_sql = "pa_ins_um_mov_consignacion_conteo_detalle    " & codempresa & ",'" &
                                                         codCliente & "','" & linea(2).ToString & "','" &
                                                         fechaConteo & "'," & linea(3).ToString & ",0,'" &
                                                         UsuarioConteo & "'," & numero_pedido

                                        Otrans.Ingresa(ls_sql)
                                        If Otrans.Codigo_error > 0 Then lbExitoso = False

                                        iCantidadLineas += 1
                                        iCantidadContada += linea(3)

                                    End If
                                End If
                            Next
                        End If
                    Next

                Else
                    If Otrans.descripcion_error.ToLower.IndexOf("uplicate") > 0 Then
                        numero_pedido = 1 'No Permite Informacion Duplicada
                    End If



                End If
            End With
            If numero_pedido > 0 And lbExitoso Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))


                'Dim psBody As String
                'psBody = "<td><tr></tr><tr>"
                'psBody = psBody & "Buen Dia "
                'psBody = psBody & "</tr><tr>Se ha recibo un conteo de Consignacion con la siguiente informacion"
                'psBody = psBody & "</tr><tr>"
                'psBody = psBody & "</tr><tr>Cliente " & codCliente
                'psBody = psBody & "</tr><tr>Cantidad de Productos Contados: " & iCantidadLineas.ToString
                'psBody = psBody & "</tr><tr>Unidades Contadas: " & iCantidadContada
                'psBody = psBody & "</tr></td>"
                'ClsGen.enviarcorreo("notificacion@umbralcorp.com", "Notificaciones Umbral", "carlos.oscal@umbralcorp.com, premium@vinoteca.com.gt", "Recepcion de Consignaciones", psBody, "", "")
            End If



        Catch ex As Exception
            ClsGen.Escribir_Log(ex.Message)
        Finally

            Otrans.close()
            Otrans = Nothing

            ClsGen = Nothing
        End Try
        Return lbExitoso
    End Function


#End Region
#Region "Procesar Conteos Fisicos"



    Private Sub obneterConteosFisicos()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "descripcion = 'conteos'"

            For Each drv In dt.DefaultView
                Obtener_Pedidos_Umbright_Mobile_Vendedor(drv)
            Next


        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_MySysgold " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub procesarRecepcionConteosFisicos()

        Dim ClsGen As New ClasesGenerales.General
        Dim OdsRecepcion As New DataSet
        Dim ruta_archivos As String
        Dim archivos As String()
        Dim archivo As String
        Dim eliminar_archivo As Boolean = False
        Try

            'ruta_archivos = "C:\Temp\Send\"
            ruta_archivos = "C:\Aplicaciones\Umbright Mobile EE\"
            archivos = Directory.GetFiles(ruta_archivos, "*.xml")

            For Each archivo In archivos
                OdsRecepcion.ReadXml(archivo)
                If OdsRecepcion.Tables.Count > 0 Then
                    If OdsRecepcion.Tables.Contains("producto_revision") Then
                        eliminar_archivo = Procesar_Barras(OdsRecepcion.Tables("producto_revision"))
                    End If

                    If OdsRecepcion.Tables.Contains("Conteo_fisico_encabezado") Then
                        eliminar_archivo = Procesar_Conteos(OdsRecepcion)
                    End If

                    If OdsRecepcion.Tables.Contains("Conteo_fisico_detalle") Then
                        eliminar_archivo = Procesar_detalle_Conteos(OdsRecepcion)

                    End If

                End If


                If eliminar_archivo Then
                    ClsGen.Mover_Archivo(archivo, ruta_archivos & "Log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))
                End If
                eliminar_archivo = False
            Next




        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try

    End Sub



    Private Function Procesar_Barras(ByVal _dt As DataTable) As Boolean

        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim clsGen As New ClasesGenerales.General
        Dim dr As DataRow
        Dim ls_sql As String
        Dim Proceso_Exitoso As Boolean = False

        Try
            myOtrans.open()
            For Each dr In _dt.Rows
                If dr.Item("codigocorrecto").ToString.ToLower <> "s" Then

                    ls_sql = "call pa_ins_um_inv_producto_verificacion_barras(" &
                        clsGen.Codigo_Empresa_Onbase(dr.Item("empresa")) & ",'" &
                        dr.Item("producto").ToString & "','" &
                        dr.Item("codigobarranuevo").ToString & "','" &
                        dr.Item("codigobarra").ToString & "')"

                    myOtrans.Ingresa(ls_sql)
                End If
            Next
            Proceso_Exitoso = True

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

        Return Proceso_Exitoso
    End Function

    Private Function Procesar_Conteos(ByVal _ods As DataSet) As Boolean
        Dim lbproceso_exitoso As Boolean = True
        Dim dr As DataRow
        Dim ls_sql, lsEncabezado As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")


        Try
            myOtrans.open()
            For Each dr In _ods.Tables("Conteo_fisico_encabezado").Rows


                Try

                    If dr.Item("dua").ToString.Trim.Length >= 0 Then
                        ls_sql = "call pa_ins_um_inv_producto_inventario_dua ('" &
                                dr.Item("empresa").ToString & "','" &
                                dr.Item("producto").ToString & "','" &
                                dr.Item("descripcion").ToString & "'," &
                                dr.Item("cod_conteo").ToString & ",'" &
                                dr.Item("usuario").ToString & "'," &
                                dr.Item("total").ToString & ",'" &
                                dr.Item("bodega").ToString & "','" &
                                dr.Item("lote").ToString & "','" &
                                dr.Item("fechavcto").ToString & "','" &
                                dr.Item("dua").ToString & "'"
                    End If


                Catch ex As Exception

                    ls_sql = "call pa_ins_um_inv_producto_inventario ('" &
                            dr.Item("empresa").ToString & "','" &
                            dr.Item("producto").ToString & "','" &
                            dr.Item("descripcion").ToString & "'," &
                            dr.Item("cod_conteo").ToString & ",'" &
                            dr.Item("usuario").ToString & "'," &
                            dr.Item("total").ToString & ",'" &
                            dr.Item("bodega").ToString & "'"

                Finally
                    ls_sql += ")"

                End Try



                myOtrans.Ingresa(ls_sql)


            Next
        Catch ex As Exception
            lbproceso_exitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
            'mostrar_Conteos()
        End Try
        Return lbproceso_exitoso

    End Function

    Private Function Procesar_detalle_Conteos(ByVal _ods As DataSet) As Boolean
        Dim lbproceso_exitoso As Boolean = True
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim oaut As New Umbral_Flex.productos

        Try

            myOtrans.open()
            For Each dr In _ods.Tables("conteo_fisico_detalle").Rows

                'ls_sql = "call pa_ins_um_inv_producto_inventario ('" & _
                '        dr.Item("empresa").ToString & "','" & _
                '        dr.Item("producto").ToString & "',''," & _
                '        dr.Item("cod_conteo").ToString & ",'" & _
                '        dr.Item("usuario").ToString & "'," & _
                '        dr.Item("total").ToString & ",'SVPC')"

                '  dt = oaut.Obtener_Existencias(dr.Item("producto").ToString, "CD_CENTRAL")

                ls_sql = "call pa_ins_um_inv_producto_inventario_detalle ('" &
                        dr.Item("empresa").ToString & "','" &
                        dr.Item("producto").ToString & "'," &
                        dr.Item("cod_conteo").ToString & ",'" &
                        dr.Item("usuario").ToString & "'," &
                        dr.Item("total").ToString & ",'" & dr.Item("bodega").ToString & "','" &
                        dr.Item("tipo").ToString & "','" &
                        dr.Item("lote").ToString & "','" &
                        dr.Item("FechaVcto").ToString & "','" &
                        dr.Item("dua").ToString & "','" &
                        DateTime.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "')"

                myOtrans.Ingresa(ls_sql)
                If myOtrans.Codigo_error > 0 Then
                    MessageBox.Show(myOtrans.descripcion_error)
                End If


            Next
        Catch ex As Exception
            lbproceso_exitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
            'mostrar_Conteos()
        End Try
        Return lbproceso_exitoso

    End Function

#End Region

#Region " Pedidos Sysgold FlexLine"

    Private Sub Realizar_Busqueda_SysGold()
        ' jehova es mi pastor nada me falta salmo 23
        Dim ls_pedido, ls_sql As String

        Dim oTransaccional As New Transaccional.Conexion("Sysgold")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim oTabla As DataTable
        Dim OSinc As New Sincronizacion.Pedidos_SysGold


        Try

            If oTransaccional.Codigo_error = 99 Then
                oTransaccional = Nothing
            Else
                oTransaccional.open()
            End If

            oTabla = oTransaccional.Obtiene("pa_sel_um_vis_encabezado_de_pedidos_procesables")

            oTransaccional.close()
            oTransaccional = Nothing
            Dim oFila As DataRow
            For Each oFila In oTabla.Rows
                Me.lbl.Items.Add("Inicio Proceso Pedido " & oFila.Item("ped_numero"))
                Me.lbl.Refresh()
                ls_pedido = oFila.Item("ped_numero")
                ''los pedidos normales son tipo SO

                If oFila.Item("tipo") = "SO" Then
                    Try
                        If Int64.Parse(oFila.Item("ped_docpda").ToString.Substring(6, oFila.Item("ped_docpda").ToString.Length - 6).ToString) > 0 Then
                            '                            Hacer_Traslado_Clase(ls_pedido)
                            OSinc.Hacer_Traslado_Pedidos_SysGold(ls_pedido)
                        End If

                    Catch ex As Exception
                    End Try
                Else
                    OSinc.Hacer_Traslado_Pedidos_SysGold_Oferta(ls_pedido)
                    'hacer_traslado_oferta(ls_pedido)
                End If
                Me.lbl.Items.Add("Finalizo Proceso Pedido " & Now)
                Me.lbl.Refresh()
            Next
            oTabla = Nothing
        Catch ex As Exception
        Finally

            Try
                myOtrans.open()
                ls_sql = "call pa_upd_um_pg_procesos_isf (1)"
                myOtrans.Actualiza(ls_sql)
            Catch ex As Exception
            Finally
                myOtrans.close()
                myOtrans = Nothing
            End Try
            OSinc = Nothing
        End Try

    End Sub

    'Private Sub Hacer_Traslado_Clase(ByVal numero_pedido As String)

    '    Dim Oflex As New umbral_flex.Pedidos
    '    Dim dr As DataRow

    '    Dim oTabla As DataTable
    '    Dim oTablaAux As DataTable
    '    Dim oFila As DataRow
    '    Dim ls_Query, ls_codigo, ls_sql As String
    '    Dim ls_dcodigo, ls_tipo, ls_dempresa As String
    '    Dim ls_daprobacion As String = ""
    '    Dim li_linea As Integer
    '    Dim lprocesar As Boolean = True

    '    Dim ldt_fecha_inicio, ldt_fecha_final As DateTime


    '    Dim oTransaccional As New Transaccional.Conexion("Sysgold")
    '    ldt_fecha_inicio = Now

    '    Try

    '        Dim oDataSet As New DataSet


    '        oTransaccional.open()

    '        ls_Query = "pa_sel_um_vis_encabezado_de_pedidos '" & numero_pedido & "'"
    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "sysgold_encabezado_pedido"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        ls_Query = "pa_sel_um_vis_detalle_de_pedido '" & numero_pedido & "'"
    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "sysgold_detalle_pedido"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        ls_Query = "pa_var_um_vis_detalle_de_pedido_total '" & numero_pedido & "'"
    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "sysgold_total_pedido"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        '' traigo informacion del cliente en sysgold
    '        ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_client")
    '        ls_Query = "pa_sel_um_clientes '" & Trim(ls_codigo) & "'"
    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "sysgold_clientes"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        oTransaccional.close()

    '        ''Me cambio se servidor y BD
    '        oTransaccional = New Transaccional.Conexion("Flexline")
    '        oTransaccional.open()

    '        '' traigo informacion de la empresa de flex
    '        ls_tipo = "SYSGOLD_EMPRESA"
    '        ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("empresa")
    '        ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "'"
    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "flexline_empresa"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        ls_dempresa = oDataSet.Tables("flexline_empresa").Rows(0).Item("descripcion")

    '        ''traigo informacion del impuesto
    '        ls_tipo = "CONFIG.IMPUESTO"
    '        ls_codigo = "01"
    '        ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"
    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "flexline_impuesto"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        ''traigo condicion del pedido
    '        ls_tipo = "SYSGOLD_CONDICIONES"
    '        ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("forpago")
    '        ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "flexline_condiciones"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        '' traigo nombre del ejecutivo
    '        ls_tipo = "SYSGOLD_EJECUTIVOS"
    '        ls_codigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_asesor")
    '        ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "flexline_ejecutivo"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        '' Traigo la Informacion del Cliente en flexline
    '        ls_dcodigo = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("cod_cliente")
    '        ls_Query = "pa_sel_um_ctacte '" & ls_dempresa & "','CLIENTE','" & ls_dcodigo & "'"

    '        oTabla = oTransaccional.Obtiene(ls_Query)
    '        oTabla.TableName = "flexline_clientes"
    '        oDataSet.Tables.Add(oTabla.Copy)

    '        ls_daprobacion = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto2")

    '        ''Verifico la aprobacion de los pedidos
    '        If Trim(ls_daprobacion) <> "S" Then

    '            Try
    '                ls_tipo = "SYSGOLD_GRUPOS"

    '                ls_codigo = oDataSet.Tables("sysgold_clientes").Rows(0).Item("subcanal")
    '                ls_Query = "pa_sel_um_gen_tabcod '" & ls_codigo & "','" & ls_tipo & "','" & ls_dempresa & "'"

    '                oTabla = oTransaccional.Obtiene(ls_Query)

    '                ls_daprobacion = oTabla.Rows(0).Item("texto1")
    '            Catch ex As Exception
    '            End Try
    '        End If


    '        Oflex.Limpiar_Datos()

    '        ''Encabezado
    '        dr = Oflex.ods.Tables("encabezado").NewRow

    '        dr.Item("empresa") = ls_dempresa
    '        dr.Item("tipodocto") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto").ToString
    '        dr.Item("numero") = Trim(Mid(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha"), 9, 2) + _
    '                            Mid(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha"), 4, 2) + _
    '                            oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("numero")).PadLeft(10, "0")
    '        dr.Item("fecha") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
    '        dr.Item("codigo") = oDataSet.Tables("flexline_clientes").Rows(0).Item("ctacte")
    '        dr.Item("vendedor") = oDataSet.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
    '        dr.Item("diascredito") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
    '        dr.Item("listaprecio") = oDataSet.Tables("flexline_clientes").Rows(0).Item("listaPrecio").ToString
    '        dr.Item("total") = oDataSet.Tables("sysgold_total_pedido").Rows(0).Item("total")
    '        dr.Item("factor") = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")
    '        dr.Item("aprobacion") = ls_daprobacion
    '        dr.Item("periodo") = Trim(Format(Now, "yyyy") + Format(Now, "MM"))
    '        dr.Item("direccion") = oDataSet.Tables("flexline_clientes").Rows(0).Item("direccion").ToString
    '        dr.Item("ciudad") = oDataSet.Tables("flexline_clientes").Rows(0).Item("ciudad").ToString
    '        dr.Item("comuna") = oDataSet.Tables("flexline_clientes").Rows(0).Item("comuna").ToString
    '        dr.Item("pais") = oDataSet.Tables("flexline_clientes").Rows(0).Item("pais").ToString
    '        dr.Item("contacto") = oDataSet.Tables("flexline_clientes").Rows(0).Item("pais").ToString
    '        dr.Item("comentario1") = "PDA - " & Replace(Trim(oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("observ")), "'", " ")
    '        dr.Item("usuario") = "PDA"

    '        Try
    '            If oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecen") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha") Then
    '                dr.Item("AnalisisE3") = "30/12/1899"
    '            Else
    '                dr.Item("AnalisisE3") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecen").ToString.Substring(0, 10)
    '            End If
    '        Catch ex As Exception
    '            dr.Item("AnalisisE3") = "30/12/1899"
    '        End Try


    '        Oflex.ods.Tables("encabezado").Rows.Add(dr)

    '        ''Documentop
    '        dr = Oflex.ods.Tables("documentop").NewRow

    '        dr.Item("codigopago") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("descripcion").ToString
    '        dr.Item("diascredito") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
    '        dr.Item("total") = oDataSet.Tables("sysgold_total_pedido").Rows(0).Item("total")
    '        dr.Item("cuenta") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("texto1")
    '        dr.Item("fecha") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
    '        Oflex.ods.Tables("documentop").Rows.Add(dr)

    '        ''DocumentoV
    '        dr = Oflex.ods.Tables("documentov").NewRow
    '        dr.Item("total") = oDataSet.Tables("sysgold_total_pedido").Rows(0).Item("total")
    '        dr.Item("factor") = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")
    '        Oflex.ods.Tables("documentov").Rows.Add(dr)

    '        ''DocumentoD
    '        For Each oFila In oDataSet.Tables("sysgold_detalle_pedido").Rows
    '            li_linea = li_linea + 1
    '            dr = Oflex.ods.Tables("detalle").NewRow
    '            dr.Item("secuencia") = oFila.Item("numitem")
    '            dr.Item("producto") = oFila.Item("cod_producto")
    '            dr.Item("cantidad") = oFila.Item("ped_cantid")
    '            dr.Item("precio") = oFila.Item("ped_valor")
    '            dr.Item("total") = oFila.Item("ped_base")
    '            dr.Item("diascredito") = oDataSet.Tables("flexline_condiciones").Rows(0).Item("valor1")
    '            dr.Item("factor") = oDataSet.Tables("flexline_impuesto").Rows(0).Item("valor1")
    '            dr.Item("fecha") = oDataSet.Tables("sysgold_encabezado_pedido").Rows(0).Item("ped_fecha")
    '            dr.Item("costo") = 0
    '            dr.Item("linea") = li_linea
    '            Oflex.ods.Tables("detalle").Rows.Add(dr)
    '        Next

    '        lprocesar = True
    '        'If oDataSet.Tables("flexline_clientes").Rows(0).Item("Analisisctacte6").ToString.Length > 0 Then

    '        '    ' MessageBox.Show("PEdidod Tienda")
    '        '    'lprocesar = False

    '        'End If
    '    Catch ex As Exception
    '    Finally



    '        If lprocesar Then

    '            If Oflex.Guardar_Pedido > 0 Then
    '                ldt_fecha_final = Now
    '                oTransaccional = New Transaccional.Conexion("Flexline")
    '                oTransaccional.open()
    '                ls_sql = "pa_ins_um_gen_log_isf '" & Oflex.ods.Tables("encabezado").Rows(0).Item("empresa") & "','" & _
    '                                    Oflex.ods.Tables("encabezado").Rows(0).Item("tipodocto") & "','" & _
    '                                    Oflex.ods.Tables("encabezado").Rows(0).Item("numero") & "','" & _
    '                                                ldt_fecha_inicio & "','" & ldt_fecha_final & "'"

    '                oTransaccional.Ingresa(ls_sql)

    '                ''Me cambio se servidor y BD
    '                ''elimino el documento en sysgold
    '                oTransaccional = New Transaccional.Conexion("Sysgold")
    '                oTransaccional.open()
    '                ls_Query = "pa_del_um_encabezado_detalle_de_pedidos '" & numero_pedido & "'"
    '                oTransaccional.Elimina(ls_Query)
    '            End If
    '        End If


    '        Oflex = Nothing

    '        oTransaccional.close()
    '        oTransaccional = Nothing
    '    End Try
    '    oTabla = Nothing
    '    oTablaAux = Nothing
    'End Sub



#End Region


#Region "Pedidos MR atravez de FTP"

    Private Sub Realizar_Busqueda_ftp_mr()
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Dim ff As New FTP.clsFTP
        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim archivos() As String
        Dim icount As Integer

        'Me.Reloj.Enabled = False



        Try
            myOtrans.open()
            ''Busco Especificamente con cliente divasa
            ls_sql = "call pa_sel_um_edi_configuraciones ('disevesa')"

            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = ""
            drv = dt.DefaultView(0)

            '        ' Create an instance of the FTP Class.
            'Me.txt_status.Text = "Creando la Instancia"
            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            ff.RemoteHost = drv.Item("host") '"gtmailmarketing.com"
            ff.RemoteUser = drv.Item("usuario")  '"gerber@gtmailmarketing.com"
            ff.RemotePassword = drv.Item("password") '"gerber"


            Me.lbl.Items.Add("FTP-Conectando")
            If (ff.Login()) Then
                ff.ChangeDirectory(drv.Item("Carpeta").ToString)

                ff.SetBinaryMode(True)

                Me.lbl.Items.Add("Transfiriendo")

                archivos = ff.GetFileList("")

                For icount = 0 To archivos.Length - 1
                    If archivos(icount).ToLower.IndexOf("xml") > 0 Then
                        If ff.RenameFile(archivos(icount).Trim, "_" & archivos(icount).Trim) Then
                            ff.DownloadFile("_" & archivos(icount).Trim, "c:\Aplicaciones\" & drv.Item("cod_cliente").ToString & "\Send\" & "_" & archivos(icount).Trim)

                            ff.DeleteFile("_" & archivos(icount).Trim)
                            ff.ChangeDirectory("Log")
                            ff.UploadFile("c:\Aplicaciones\" & drv.Item("cod_cliente").ToString & "\Send\_" & archivos(icount).Trim)

                            ff.ChangeDirectory("..")
                        End If
                    End If
                Next
            End If
            Me.lbl.Items.Add("FTP- Proceso Finalizado")
            ff.CloseConnection()
        Catch ex As System.Exception            '        

            Me.lbl.Items.Add(ex.Message)
            Me.lbl.Items.Add("Message from FTP Server was: " & ff.MessageString)
        Finally
            ff = Nothing
            ls_sql = "call pa_upd_um_pg_procesos_isf (2)"
            myOtrans.Actualiza(ls_sql)
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Procesar_Archivos_FTP_XML(drv)
    End Sub


    Private Sub Procesar_Archivos_FTP_XML(ByVal drv As DataRowView)
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Dim archivos As String()
        Dim archivo, Ruta_Archivos As String
        Dim clsgen As New ClasesGenerales.General
        Dim eliminar_archivo As Boolean = True
        Dim ods As DataSet
        Dim dr As DataRow



        Try
            myOtrans.open()
            Ruta_Archivos = "c:\Aplicaciones\" & drv.Item("cod_cliente").ToString & "\Send"
            archivos = Directory.GetFiles(Ruta_Archivos, "*.xml")
            If archivos.Length > 0 Then
                For Each archivo In archivos
                    ods = New DataSet
                    ods.ReadXml(archivo)

                    'MessageBox.Show(Ods.Tables.Count)
                    eliminar_archivo = True
                    If ods.Tables.Contains("clientes") Then
                        ods.Tables("clientes").Columns.Add(New DataColumn("cod_cliente_mayorista", GetType(Integer)))
                        'ods.Tables("clientes").Columns.Add(New DataColumn("direccion_zona", GetType(Integer)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("orden_visita", GetType(Integer)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("descuento", GetType(Integer)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("fecha_grabo", GetType(DateTime)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("cod_tipo_localidad_geo", GetType(Integer)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("cod_sucursal", GetType(Integer)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("direccion_colonia", GetType(String)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("usuario_modifico", GetType(String)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("fecha_modifico", GetType(DateTime)))
                        ods.Tables("clientes").Columns.Add(New DataColumn("predeterminado", GetType(Integer)))

                        ods.Tables("clientes").Constraints.Clear()

                        For Each dr In ods.Tables("clientes").Rows
                            dr.Item("cod_cliente_mayorista") = dr.Item("cod_cliente")
                            dr.Item("cod_cliente") = 5250
                            ' dr.Item("direccion_zona") = 0
                            dr.Item("orden_visita") = 0
                            dr.Item("descuento") = 0
                            dr.Item("usuario_grabo") = "Admin"
                            dr.Item("fecha_grabo") = Now
                            dr.Item("cod_tipo_localidad_geo") = 1
                            dr.Item("cod_sucursal") = 1
                            dr.Item("direccion_colonia") = dr.Item("direccion_localidad")
                            dr.Item("predeterminado") = 1
                            dr.Item("usuario_modifico") = "Admin"
                            dr.Item("fecha_modifico") = Now

                        Next



                        If Not Subir_Clientes_XML(ods.Tables("clientes"), ods.Tables("clientes")) Then
                            eliminar_archivo = False
                        End If
                    End If
                    If ods.Tables.Contains("productos1") Then
                        ods.Tables("productos").Columns.Add(New DataColumn("cod_cliente", GetType(Integer)))
                        ods.Tables("productos").Columns.Add(New DataColumn("cod_proveedor", GetType(Integer)))
                        ods.Tables("productos").Columns.Add(New DataColumn("cod_producto_mayorista", GetType(String)))
                        ods.Tables("productos").Columns.Add(New DataColumn("cod_producto_proveedor", GetType(String)))
                        ods.Tables("productos").Columns.Add(New DataColumn("precio_proveedor", GetType(Double)))
                        ods.Tables("productos").Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
                        ods.Tables("productos").Columns.Add(New DataColumn("fecha_grabo", GetType(DateTime)))
                        ods.Tables("productos").Columns.Add(New DataColumn("descuento_producto", GetType(Integer)))
                        ods.Tables("productos").Columns.Add(New DataColumn("minimo", GetType(Integer)))
                        ods.Tables("productos").Columns.Add(New DataColumn("usuario_modifico", GetType(String)))
                        ods.Tables("productos").Columns.Add(New DataColumn("fecha_modifico", GetType(DateTime)))

                        For Each dr In ods.Tables("productos").Rows
                            dr.Item("cod_cliente") = 5250
                            dr.Item("cod_proveedor") = 1
                            dr.Item("cod_producto_mayorista") = dr.Item("cod_producto_codicasa").ToString.Substring(dr.Item("cod_producto_codicasa").ToString.Length - 10, 10)
                            dr.Item("cod_producto_proveedor") = dr.Item("cod_producto_codicasa").ToString.Substring(dr.Item("cod_producto_codicasa").ToString.Length - 10, 10)
                            dr.Item("precio_proveedor") = dr.Item("precio_costo")
                            dr.Item("usuario_grabo") = "Admin"
                            dr.Item("fecha_grabo") = Now
                            dr.Item("usuario_modifico") = "Admin"
                            dr.Item("fecha_modifico") = Now
                            dr.Item("descuento_producto") = 0
                            dr.Item("minimo") = 0


                        Next

                        If Not Subir_Productos_Disponibles_XML(ods.Tables("productos")) Then
                            eliminar_archivo = False
                        End If
                    End If


                    If ods.Tables.Contains("encabezado_movimiento") Then

                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("correlativo", GetType(Integer)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("cod_cliente_mayorista", GetType(Integer)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("numero_externo", GetType(String)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("condicion_pago", GetType(String)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("cod_proveedor_mayorista", GetType(Integer)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("desc_producto", GetType(Double)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("desc_cliente", GetType(Double)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("fecha_grabo", GetType(DateTime)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("cod_movimiento", GetType(Integer)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("cod_vendedor", GetType(Integer)))
                        ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("cod_tipo_movimiento", GetType(Integer)))

                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("cod_movimiento", GetType(Integer)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("cantidad", GetType(Integer)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("cod_producto_mayorista", GetType(String)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("precio", GetType(Double)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("subtotal", GetType(Double)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("costo", GetType(Double)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("porc_desc_producto", GetType(Double)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("porc_desc_cliente", GetType(Double)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("total_desc_producto", GetType(Double)))
                        ods.Tables("detalle_movimiento").Columns.Add(New DataColumn("total_desc_cliente", GetType(Double)))



                        For Each dr In ods.Tables("encabezado_movimiento").Rows
                            dr.Item("cod_cliente_mayorista") = dr.Item("cod_cliente")
                            dr.Item("cod_cliente") = 5250
                            dr.Item("numero_externo") = dr.Item("numero").ToString
                            dr.Item("condicion_pago") = "Contado"
                            dr.Item("desc_producto") = dr.Item("total_descuento").ToString
                            dr.Item("desc_cliente") = 0
                            dr.Item("usuario_grabo") = "Admin"
                            dr.Item("fecha_grabo") = Now
                            dr.Item("cod_movimiento") = 0
                            dr.Item("cod_vendedor") = 1
                            dr.Item("cod_tipo_movimiento") = dr.Item("tipo_movimiento")
                            If validar_factura(dr.Item("cod_cliente"), dr.Item("numero"), dr.Item("tipo_movimiento"), dr.Item("cod_cliente_mayorista"), 1) Then
                                dr.Item("cod_movimiento") = CInt(dr.Item("numero").ToString.Substring(4, dr.Item("numero").ToString.Length - 4))
                                dr.Item("correlativo") = CInt(dr.Item("numero").ToString.Substring(4, dr.Item("numero").ToString.Length - 4))

                                ods.Tables("detalle_movimiento").DefaultView.RowFilter = "numero = '" & dr.Item("numero").ToString & "' and tipo_movimiento = " & dr.Item("tipo_movimiento")
                                For Each drv In ods.Tables("detalle_movimiento").DefaultView
                                    drv.Item("cod_movimiento") = dr.Item("cod_movimiento")
                                Next

                            Else
                                dr.Item("correlativo") = -1
                            End If

                        Next

                        ods.Tables("detalle_movimiento").DefaultView.RowFilter = ""

                        For Each dr In ods.Tables("detalle_movimiento").Rows
                            dr.Item("cantidad") = dr.Item("unidades")
                            dr.Item("cod_producto_mayorista") = dr.Item("cod_producto_codicasas").ToString.Substring(dr.Item("cod_producto_codicasas").ToString.Length - 10, 10)
                            dr.Item("precio") = dr.Item("precio_unitario")
                            dr.Item("subtotal") = dr.Item("sub_total")
                            dr.Item("costo") = 0
                            dr.Item("porc_desc_producto") = 0
                            dr.Item("porc_desc_cliente") = 0
                            dr.Item("total_desc_producto") = dr.Item("total_descuento")
                            dr.Item("total_desc_cliente") = 0
                        Next

                        If Not Subir_Movimientos_XML(ods) Then
                            eliminar_archivo = False
                        End If


                    End If

                    If ods.Tables.Contains("vendedores") Then
                        ods.Tables("vendedores").Columns.Add(New DataColumn("cod_cliente", GetType(Integer)))
                        ods.Tables("vendedores").Columns.Add(New DataColumn("cod_vendedor", GetType(Integer)))
                        ods.Tables("vendedores").Columns.Add(New DataColumn("nombre", GetType(String)))
                        ods.Tables("vendedores").Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
                        ods.Tables("vendedores").Columns.Add(New DataColumn("fecha_grabo", GetType(DateTime)))


                        For Each dr In ods.Tables("vendedores").Rows
                            dr.Item("cod_cliente") = 5250
                            dr.Item("cod_vendedor") = dr.Item("codigo_vendedor")
                            dr.Item("nombre") = dr.Item("nombre_vendedor")
                            dr.Item("usuario_grabo") = "Admin"
                            dr.Item("fecha_grabo") = Now
                        Next

                        If Not Subir_Vendedor_Alias_XML(ods.Tables("vendedores")) Then
                            eliminar_archivo = False
                        End If
                    End If

                    If eliminar_archivo Then
                        clsgen.Mover_Archivo(archivo, Ruta_Archivos & "\log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))
                    End If


                Next
            End If



        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try



    End Sub

    Private Sub Procesar_Archivos_FTP(ByVal drv As DataRowView)


        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim ls_sql As String
        Dim archivos As String()
        Dim archivo As String
        Dim clsgen As New ClasesGenerales.General


        Try
            myOtrans.open()
            archivos = Directory.GetFiles("C:\Aplicaciones\FTP", "*.txt")

            'archivoDestino = "c:\aplicaciones\" & _dr.Item("cod_cliente").ToString & "\send"


            ''Debo Procesar los archivos 
            If archivos.Length > 0 Then
                For Each archivo In archivos
                    If Procesar_Archivo_Texto(archivo, drv.Item("cod_cliente").ToString) Then
                        clsgen.Mover_Archivo(archivo, "c:\aplicaciones\FTP\log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))
                    End If
                Next
            End If

            ls_sql = "call pa_upd_um_pg_procesos_isf (2)"
            myOtrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub


    Function Procesar_Archivo_Texto(ByVal _Ruta_Archivo As String, ByVal _codigo_cliente As String) As Boolean
        Dim dt As DataTable
        Dim ncorrelativo, nmovimiento, nlineas As Integer
        Dim myotrans As New Transaccional.Conexion_mysql("onbase")
        Dim fs_archivo As StreamReader
        Dim linea, tipo_movimiento As String
        Dim ls_sql As String
        Dim datos As String()
        Dim svendedor, sruta, snombre, sdireccion, snit, scodigo, szona,
            scolonia, smunicipio, sdepartamento, spropietario, stelefono, ssecuencia As String
        Dim lbexitoso As Boolean = True
        Dim lnubicacion As Integer = 1

        If _Ruta_Archivo.ToUpper.IndexOf("H.") > 0 Then
            lnubicacion = 2
        ElseIf _Ruta_Archivo.ToUpper.IndexOf("S.") > 0 Then
            lnubicacion = 3
        End If


        Try
            myotrans.open()
            fs_archivo = System.IO.File.OpenText(_Ruta_Archivo)
            Do Until fs_archivo.Peek = -1

                linea = CStr(fs_archivo.ReadLine)

                ''Debo Interpretar esta Linea
                datos = linea.Split("|")
                'MessageBox.Show(datos.Length)
                ''Encabezado
                If datos.Length = 9 Then
                    ''Or _                   datos.Length = 8 Then
                    tipo_movimiento = datos(4)

                    If validar_factura(_codigo_cliente, datos(1), tipo_movimiento, IIf(tipo_movimiento = 3, 0, datos(3)), lnubicacion) Then
                        'tipo_movimiento = datos(4)
                        ls_sql = "call pa_var_um_bbj_mayorista_encabezado_movimiento_correlativo (" & _codigo_cliente & "," & tipo_movimiento & ")"
                        dt = myotrans.Obtiene(ls_sql)
                        ncorrelativo = dt.Rows(0).Item("nuevo_correlativo")

                        ls_sql = "call pa_ins_um_bbj_mayorista_encabezado_movimiento_FTP (" &
                                    ncorrelativo & "," & _codigo_cliente & "," & IIf(tipo_movimiento = 3, "0", datos(3)) & "," & tipo_movimiento & ",'" &
                                   Date.Parse(datos(2).ToString).ToString("yyyy-MM-dd") & "','Admin'," & Double.Parse(datos(5).ToString).ToString & "," &
                                    Double.Parse(datos(5).ToString).ToString & ",0,0,'" &
                                    datos(1) & "','" & datos(7) & "',NULL,NULL,NULL," & lnubicacion.ToString & ")"

                        myotrans.Ingresa(ls_sql)
                        If myotrans.Codigo_error > 0 Then
                            nmovimiento = 0
                            nlineas = 0
                            lbexitoso = False
                        Else
                            dt = myotrans.Obtiene("SELECT @@IDENTITY AS NewID")
                            nmovimiento = dt.Rows(0).Item("newid").ToString
                            nlineas = datos(6)
                        End If
                    Else
                        nmovimiento = 0
                        nlineas = 0
                    End If


                ElseIf datos.Length = 7 Then   'Detalle
                    If nmovimiento > 0 And nlineas > 0 Then
                        If Int64.Parse(datos(3).ToString) > 0 Then
                            nlineas -= 1
                            ls_sql = "call pa_ins_um_bbj_mayorista_detalle_movimiento_FTP (" & nmovimiento & "," &
                                     datos(3) & "," & datos(4) & "," & datos(5) & ",'" & datos(2).ToString.PadLeft(10, "0") & "',0)"

                            myotrans.Ingresa(ls_sql)
                        End If
                    End If

                ElseIf datos.Length = 17 Then   'Clientes
                    svendedor = datos(16)
                    sruta = datos(2)
                    ssecuencia = datos(3)
                    scodigo = datos(4)
                    snombre = datos(6)
                    spropietario = datos(5)
                    sdireccion = datos(7) '& ", " & datos(10) & ", " & datos(11)
                    smunicipio = datos(10).Substring(2, 2)
                    sdepartamento = datos(10).Substring(0, 2)
                    szona = IIf(datos(8).Length = 0, 0, datos(8))
                    scolonia = datos(9)
                    snit = datos(12)
                    stelefono = datos(13)
                    If scodigo = "50561" Then
                        scodigo = "50561"
                    End If

                    ls_sql = "call pa_ins_um_bbj_mayorista_cliente_FTP ( " & _codigo_cliente & "," & scodigo & ","

                    ls_sql = ls_sql & "1,'" & snit & "','" &
                             snombre & "','" &
                             spropietario & "'," &
                             sruta & "," &
                             svendedor & ",'" &
                             sdireccion & "'," & szona.ToString & ",'" &
                             scolonia & "'," & smunicipio & "," &
                             sdepartamento & ",1,'" &
                             stelefono & "',1,'" &
                             "'," & ssecuencia & ",'admin'," & lnubicacion.ToString & ")"

                    myotrans.Ingresa(ls_sql)
                    If myotrans.descripcion_error.ToString.ToLower.LastIndexOf("duplica") >= 0 Then
                        ls_sql = "call pa_upd_um_bbj_mayorista_cliente_FTP ( " & _codigo_cliente & "," & scodigo & ", "

                        ls_sql += "1,'" & snit & "','" &
                             snombre & "','" &
                             spropietario & "'," &
                             sruta & "," &
                             svendedor & ",'" &
                             sdireccion & "'," & szona.ToString & ",'" &
                             scolonia & "'," & smunicipio & "," &
                             sdepartamento & ",1,'" &
                             stelefono & "',1,'" &
                             "'," & ssecuencia & ",'admin')"

                        myotrans.Actualiza(ls_sql)

                    End If
                    ''ElseIf datos.Length = 13 Then
                    ''    svendedor = datos(12)
                    ''    sruta = datos(2)
                    ''    scodigo = datos(4)
                    ''    snombre = datos(6)
                    ''    spropietario = datos(5)
                    ''    sdireccion = datos(7) '& ", " & datos(10) & ", " & datos(11)
                    ''    szona = 0 'IIf(datos(8).Length = 0, 0, datos(8))
                    ''    scolonia = "" 'datos(9)
                    ''    snit = datos(8)
                    ''    stelefono = datos(9)

                    ''    ls_sql = "call pa_ins_um_bbj_mayorista_cliente ( " & _codigo_cliente & "," & scodigo & ","

                    ''    ls_sql = ls_sql & "1,'" & snit & "','" & _
                    ''             snombre & "','" & _
                    ''             spropietario & "'," & _
                    ''             sruta & "," & _
                    ''             svendedor & ",'" & _
                    ''             sdireccion & "'," & szona.ToString & ",'" & _
                    ''             scolonia & "',1," & _
                    ''              "1,1,'" & _
                    ''             stelefono & "',1,'" & _
                    ''             "','admin')"

                    ''    myotrans.Ingresa(ls_sql)

                End If

            Loop

            fs_archivo.Close()
        Catch ex As IO.FileNotFoundException
            MsgBox("No se ha encontrado el archivo")
        Finally
            myotrans.close()
            myotrans = Nothing
        End Try

        Return lbexitoso
    End Function

    Private Function validar_factura(ByVal _cliente_mayorista As String, ByVal _numero_documento As String, ByVal _tipo_documento As Integer, ByVal _codigo_cliente_mayorista As Integer, ByVal _ubicacion As Integer) As Boolean
        'Dim ls_sql As String
        'Dim bregresar As Boolean = True


        Dim ClsGenMr As New ClasesGenerales.MR(_cliente_mayorista, 1)
        Dim bregresar As Boolean = True
        Dim codigo_cliente_mayorista() As Integer
        Dim icount As Integer = 0

        Try
            bregresar = ClsGenMr.No_Existe_Numero_Externo(_numero_documento, _tipo_documento, "OnBase")
            codigo_cliente_mayorista = ClsGenMr._cliente_movimiento
            If Not bregresar Then
                bregresar = True
                For icount = 0 To codigo_cliente_mayorista.Length - 1
                    If codigo_cliente_mayorista(icount) = _codigo_cliente_mayorista Then
                        bregresar = False
                        Exit For
                    End If

                Next
                '              If codigo_cliente_mayorista <> _codigo_cliente_mayorista Then
                'bregresar = True
                'End If
            End If

        Catch ex As Exception
            bregresar = False
        Finally
            ClsGenMr = Nothing
        End Try


        ''Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        ''Dim dt As DataTable

        ''Try
        ''    myOtrans.open()
        ''    ls_sql = "call pa_var_um_bbj_mayorista_encabezado_movimiento_externo (" & _cliente_mayorista & ",'" & _numero_documento & "')"
        ''    dt = myOtrans.Obtiene(ls_sql)
        ''    If dt.Rows.Count > 0 Then
        ''        bregresar = False
        ''        '                If MessageBox.Show("Existen Movimientos con este Numero, Desea Continuar", "Cofirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        ''        '               bregresar = True
        ''        '          Else
        ''        '
        ''        '           End If
        ''        '
        ''    End If

        ''Catch ex As Exception
        ''Finally
        ''    myOtrans.close()
        ''    myOtrans = Nothing
        ''End Try

        Return bregresar

    End Function

#End Region


#Region "Busqueda  y Proceso de Archivos en los directorios de MR"

    Private Sub Realizar_Busqueda_Archivos_mr()
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            myOtrans.abrir()
            ls_sql = "call pa_sel_um_bbj_mayorista (null)"
            dt = myOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                If dr.Item("path_archivos").ToString.Length > 0 Then
                    Mover_Archivos_Send_Mr(dr)
                End If
            Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing


        End Try

    End Sub

    Private Sub Realizar_Busqueda_Archivos_Ruteo()
        Dim Otrans As New Transaccional.Conexion("FlexLineCDXCENTRAL")
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim ods As New DataSet
        Dim ls_archivo As String



        Try
            Otrans.open()
            myOtrans.open()
            ls_sql = "pa_var_um_ctacte_ruteo"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "clientes"
            ods.Tables.Add(dt.Copy)

            ls_sql = "pa_var_um_ventas_ruteo"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "encabezado_movimiento"
            ods.Tables.Add(dt.Copy)

            ls_sql = "pa_var_um_ventas_detalle_ruteo"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "detalle_movimiento"
            ods.Tables.Add(dt.Copy)


            ls_archivo = "c:\aplicaciones\2694\send\" & Now.ToString("ddMMyyyyhhmmss") & ".xml"
            ods.WriteXml(ls_archivo, XmlWriteMode.WriteSchema)

            ls_sql = "call pa_upd_um_pg_procesos_isf (2)"
            myOtrans.Actualiza(ls_sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub Mover_Archivos_Send_Mr(ByVal _dr As DataRow)
        Dim clsGen As New ClasesGenerales.General

        Dim Archivos As String()
        Dim Ruta_Archivos As String
        Dim strDir As String
        Dim archivoDestino As String

        Ruta_Archivos = _dr.Item("path_archivos").ToString & "send"

        Try
            Archivos = Directory.GetFiles(Ruta_Archivos, "*.*")

            archivoDestino = "c:\aplicaciones\" & _dr.Item("cod_cliente").ToString & "\send"

            For Each strDir In Archivos
                If clsGen.Copiar_Archivo(strDir, archivoDestino & "\" & strDir.Split("\").GetValue(strDir.Split("\").LongLength - 1), True) Then
                    clsGen.Mover_Archivo(strDir, Ruta_Archivos & "\log\" & strDir.Split("\").GetValue(strDir.Split("\").LongLength - 1))
                End If

            Next
        Catch ex As Exception
            '   MessageBox.Show(ex.Message)
        Finally
            clsGen = Nothing

        End Try



    End Sub

    Private Sub Obtener_Archivos_MR()
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Dim ff As New FTP.clsFTP
        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim archivosxml() As String
        Dim icount2 As Integer

        Try
            myOtrans.open()
            ''Busco Especificamente con cliente divasa
            ls_sql = "call pa_sel_um_edi_configuraciones ('dmarte')"

            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = ""
            drv = dt.DefaultView(0)

            ' Create an instance of the FTP Class.

            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            ff.RemoteHost = drv.Item("host")
            ff.RemoteUser = drv.Item("usuario")
            ff.RemotePassword = drv.Item("password")

            Me.lbl.Items.Add("FTP-Conectando")
            If (ff.Login()) Then
                'ff.ChangeDirectory(drv.Item("carpeta"))
                ff.ChangeDirectory("public_html/tekne/bd")
                ff.ChangeDirectory("15343")
                ff.ChangeDirectory("Send")

                ff.SetBinaryMode(True)

                Me.lbl.Items.Add("Transfiriendo")

                '                archivostxt = ff.GetFileList("fin*.txt")

                '                For icount = 0 To archivostxt.Length - 1


                For i As Integer = 0 To 2
                    Try

                        archivosxml = ff.GetFileList("*.xml")
                        For icount2 = 0 To archivosxml.Length - 1
                            If archivosxml(icount2).Length > 0 Then

                                If archivosxml(icount2).ToLower.IndexOf("xml") Then
                                    'And _                                archivosxml(icount2).ToLower.IndexOf(nombre_archivo) > -1 Then
                                    If ff.RenameFile(archivosxml(icount2).Trim, "_" & archivosxml(icount2).Trim) Then
                                        ff.DownloadFile("_" & archivosxml(icount2).Trim, "c:\Aplicaciones\mr\15343\Send\_" & archivosxml(icount2).Trim)
                                        ff.DeleteFile("_" & archivosxml(icount2).Trim)
                                    End If
                                End If
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Next

                For i As Integer = 0 To 2
                    Try

                        archivosxml = ff.GetFileList("*.cdc")
                        For icount2 = 0 To archivosxml.Length - 1
                            If archivosxml(icount2).Length > 0 Then

                                If archivosxml(icount2).ToLower.IndexOf("cdc") Then
                                    'And _                                archivosxml(icount2).ToLower.IndexOf(nombre_archivo) > -1 Then
                                    If ff.RenameFile(archivosxml(icount2).Trim, "_" & archivosxml(icount2).Trim) Then
                                        ff.DownloadFile("_" & archivosxml(icount2).Trim, "c:\Aplicaciones\mr\15343\Send\_" & archivosxml(icount2).Trim)
                                        ff.DeleteFile("_" & archivosxml(icount2).Trim)
                                    End If
                                End If
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Next


            End If
            Me.lbl.Items.Add("FTP- Proceso Finalizado")
            ff.CloseConnection()
        Catch ex As System.Exception            '        

            Me.lbl.Items.Add(ex.Message)
            Me.lbl.Items.Add("Message from FTP Server was: " & ff.MessageString)
        Finally

            ff = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub


    Private Sub Procesar_Archivos_Mr()
        Dim ods As New DataSet
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr As DataRow
        Dim ls_sql, Ruta_Archivos As String
        Dim Eliminar_Archivo As Boolean

        Dim Archivos As String()
        Dim Archivo As String




        Try
            myOtrans.abrir()
            ls_sql = "call pa_sel_um_bbj_mayorista (null)"
            dt = myOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                If dr.Item("path_archivos").ToString.Length > 0 Then
                    Ruta_Archivos = "c:\aplicaciones\mr\" & dr.Item("cod_cliente").ToString & "\send"
                    Archivos = Directory.GetFiles(Ruta_Archivos, "*.xml")
                    For Each Archivo In Archivos


                        ods = New DataSet
                        ods.ReadXml(Archivo)
                        'MessageBox.Show(Ods.Tables.Count)
                        Eliminar_Archivo = True

                        If ods.Tables.Count > 0 Then
                            If ods.Tables.Contains("proveedores") Then
                                If Not Subir_Proveedores_XML(ods.Tables("proveedores")) Then
                                    Eliminar_Archivo = False
                                End If
                            End If


                            If ods.Tables.Contains("clientes") Then
                                'If dr.Item("cod_cliente").ToString = 2694 Then
                                '    If Not Subir_Clientes_XML(ods.Tables("clientes"), ods.Tables("clientes")) Then
                                '        Eliminar_Archivo = False
                                '    End If
                                'Else


                                If ods.Tables.Contains("clientes_vendedores") Then
                                    If Not Subir_Clientes_XML(ods.Tables("clientes"), ods.Tables("clientes_vendedores")) Then
                                        Eliminar_Archivo = False
                                    End If
                                Else
                                    If Not Subir_Clientes_XML(ods.Tables("clientes"), ods.Tables("clientes")) Then
                                        Eliminar_Archivo = False
                                    End If
                                End If
                            End If


                            If ods.Tables.Contains("productos_disponibles") Then
                                If Not Subir_Productos_Disponibles_XML(ods.Tables("productos_disponibles")) Then
                                    Eliminar_Archivo = False
                                End If
                            End If
                            If ods.Tables.Contains("encabezado_movimiento") Then
                                If Not Subir_Movimientos_XML(ods) Then
                                    Eliminar_Archivo = False
                                End If
                            End If
                            If ods.Tables.Contains("rutas_alias") Then
                                If Not Subir_Ruta_Alias_XML(ods.Tables("rutas_alias")) Then
                                    Eliminar_Archivo = False
                                End If
                            End If
                            If ods.Tables.Contains("vendedores_alias") Then
                                If Not Subir_Vendedor_Alias_XML(ods.Tables("vendedores_alias")) Then
                                    Eliminar_Archivo = False
                                End If
                            End If


                            If ods.Tables.Contains("depositos") Then
                                Eliminar_Archivo = Subir_Depositos_XML(ods.Tables("depositos"))
                            End If

                            If ods.Tables.Contains("mensajeria") Then
                                Eliminar_Archivo = Subir_Mensajeria_XML(ods.Tables("mensajeria"))
                            End If
                        End If

                        If Eliminar_Archivo Then
                            clsgen.Mover_Archivo(Archivo, Ruta_Archivos & "\log\" & Archivo.Split("\").GetValue(Archivo.Split("\").LongLength - 1))
                        End If

                    Next


                End If
            Next
        Catch ex As Exception
        Finally
            ls_sql = "call pa_upd_um_pg_procesos_isf (3)"
            myOtrans.Actualiza(ls_sql)
            myOtrans.close()
            myOtrans = Nothing


        End Try

    End Sub

    Private Sub Procesar_Archivos_DAT()
        Dim ods As New DataSet
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim dr As DataRow
        Dim ls_sql, Ruta_Archivos As String
        'Dim Eliminar_Archivo As Boolean

        Dim Archivos As String()
        Dim Archivo As String




        Try
            myOtrans.abrir()
            ls_sql = "call pa_sel_um_bbj_mayorista (null)"
            dt = myOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                If dr.Item("path_archivos").ToString.Length > 0 Then
                    Ruta_Archivos = "c:\aplicaciones\" & dr.Item("cod_cliente").ToString & "\send"
                    Archivos = Directory.GetFiles(Ruta_Archivos, "*.dat")
                    If Archivos.Length < 10 Then
                        For Each Archivo In Archivos
                            If Subir_Linea_DAT(Archivo) Then
                                clsgen.Mover_Archivo(Archivo, Ruta_Archivos & "\log\" & Archivo.Split("\").GetValue(Archivo.Split("\").LongLength - 1))
                            End If
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Sub

    Function Subir_Movimientos_XML(ByVal _ods As DataSet) As Boolean
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt, dt2 As DataTable
        Dim dr, dr2 As DataRow
        Dim drv As DataRowView
        Dim ls_sql As String
        Dim nmovimiento As Integer
        Dim Resultado As Boolean = True
        Dim Modificacion As Boolean = False

        Try
            myOtrans.open()
            For Each dr In _ods.Tables("encabezado_movimiento").Rows

                nmovimiento = 0
                Modificacion = False
                Try
                    If dr.Item("usuario_modifico").ToString.Length > 0 Then
                        Modificacion = True
                    End If
                Catch ex As Exception
                    Modificacion = False

                End Try
                If Modificacion Then
                    'Modificacion = True
                    If dr.Item("estado") = 1 Then
                        'Pedido modificado
                        ''Elimino el Pedido y vuelvo a cargar la Informacion
                        ls_sql = "call pa_var_um_bbj_mayorista_encabezado_movimiento (" &
                                    dr.Item("correlativo").ToString & "," & dr.Item("cod_cliente").ToString & "," & dr.Item("cod_cliente_mayorista").ToString & "," &
                                dr.Item("cod_tipo_movimiento").ToString & ")"
                        dt = myOtrans.Obtiene(ls_sql)
                        If dt.Rows.Count > 0 Then
                            ls_sql = "call pa_sel_um_bbj_mayorista_detalle_movimiento (" & dt.Rows(0).Item("cod_movimiento").ToString & ")"
                            dt2 = myOtrans.Obtiene(ls_sql)
                            For Each dr2 In dt2.Rows
                                'Elimar el detalle

                                ls_sql = "call pa_del_um_bbj_mayorista_detalle_movimiento (" & dr2.Item("cod_movimiento").ToString & ",'" &
                                         dr2.Item("codigo").ToString & "')"
                                myOtrans.Elimina(ls_sql)
                                If myOtrans.Codigo_error > 0 Then
                                    Resultado = False
                                End If
                            Next

                            'Eliminar el encabezado
                            ls_sql = "call pa_del_um_bbj_mayorista_encabezado_movimiento (" & dt.Rows(0).Item("cod_movimiento").ToString & "," &
                                    dr.Item("correlativo").ToString & "," & dr.Item("cod_cliente").ToString & "," &
                                    dr.Item("cod_cliente_mayorista").ToString & "," &
                                    dr.Item("cod_tipo_movimiento").ToString & ")"
                            myOtrans.Elimina(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                Resultado = False
                            End If

                        End If
                    Else
                        ''Modificar Estado
                        ls_sql = "call pa_upd_um_bbj_mayorista_encabezado_movimiento (" & dr.Item("correlativo").ToString & "," &
                                dr.Item("cod_cliente").ToString & "," & dr.Item("cod_tipo_movimiento").ToString & "," &
                                dr.Item("estado").ToString & "," &
                                "NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" & dr.Item("usuario_modifico") & "','" &
                                Date.Parse(dr.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm") & "')"
                        myOtrans.Actualiza(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            Resultado = False
                        End If
                    End If

                End If

                If dr.Item("correlativo") > 0 Then


                    ls_sql = "call pa_ins_um_bbj_mayorista_encabezado_movimiento_XML ("


                    ls_sql += dr.Item("correlativo").ToString & "," & dr.Item("cod_cliente").ToString & "," & dr.Item("cod_cliente_mayorista").ToString & "," &
                                    dr.Item("cod_tipo_movimiento").ToString & ",'" &
                                    Date.Parse(dr.Item("fecha").ToString).ToString("yyyy-MM-dd") & "','" & dr.Item("usuario_grabo") & "'," & dr.Item("total").ToString & ",'" &
                                    dr.Item("numero_externo").ToString & "','" & dr.Item("observaciones") & "','" &
                                    dr.Item("condicion_pago").ToString & "'," &
                                    IIf(dr.Item("cod_proveedor_mayorista").ToString.Length = 0, "NULL", dr.Item("cod_proveedor_mayorista").ToString) & "," &
                                    dr.Item("estado").ToString & "," &
                                    dr.Item("subtotal").ToString & "," & dr.Item("desc_producto").ToString & "," &
                                    dr.Item("desc_cliente").ToString & ",'" &
                                    Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "'," &
                                    dr.Item("cod_movimiento").ToString & "," &
                                    IIf(dr.Item("cod_vendedor").ToString.Length = 0, "NULL", dr.Item("cod_vendedor").ToString) & "," &
                                    IIf(dr.Item("cod_tipo_devolucion").ToString.Length = 0, "NULL", dr.Item("cod_tipo_devolucion").ToString)

                    ls_sql += ")"


                    myOtrans.Ingresa(ls_sql)


                    If myOtrans.Codigo_error > 0 Then
                        If myOtrans.descripcion_error.IndexOf("Duplicate") > 0 Then
                            ''Reproceso y no lo pudo ingresar, si debe eliminar el archivo
                            Resultado = True
                        Else
                            Resultado = False
                        End If
                        nmovimiento = 0

                    Else
                        dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                        nmovimiento = dt.Rows(0).Item("newid").ToString

                        If Modificacion Then
                            ls_sql = "call pa_upd_um_bbj_mayorista_encabezado_movimiento (" & dr.Item("correlativo").ToString & "," &
                                   dr.Item("cod_cliente").ToString & "," & dr.Item("cod_tipo_movimiento").ToString & "," &
                                   dr.Item("estado").ToString & "," &
                                   "NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" & dr.Item("usuario_modifico") & "','" &
                                   Date.Parse(dr.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm") & "')"
                            myOtrans.Actualiza(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                Resultado = False
                            End If
                        End If
                    End If

                    If nmovimiento > 0 Then
                        _ods.Tables("detalle_movimiento").DefaultView.RowFilter = "cod_movimiento = " & dr.Item("cod_movimiento").ToString
                        For Each drv In _ods.Tables("detalle_movimiento").DefaultView
                            ls_sql = "call pa_ins_um_bbj_mayorista_detalle_movimiento_XML (" & nmovimiento.ToString & "," &
                                 drv.Item("cantidad").ToString & "," & drv.Item("precio").ToString & "," & drv.Item("linea").ToString & ",'" &
                                 drv.Item("cod_producto_mayorista").ToString & "'," & drv.Item("costo").ToString & "," & drv.Item("subtotal").ToString & "," &
                                 drv.Item("porc_desc_producto").ToString & "," & drv.Item("porc_desc_cliente").ToString & "," &
                                 drv.Item("total_desc_producto").ToString & "," & drv.Item("total_desc_cliente").ToString & "," &
                                 drv.Item("total").ToString & ")"
                            myOtrans.Ingresa(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                Resultado = False
                            End If

                        Next
                    End If
                End If ''correlativo > 0

            Next


        Catch ex As Exception

        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try


        Return Resultado
    End Function

    Function Subir_Productos_Disponibles_XML(ByVal _odt As DataTable) As Boolean

        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Resultado As Boolean = True
        Dim fecha_modifico As String

        Try
            myOtrans.open()
            For Each dr In _odt.Rows
                ''Primero debe verificar si existe
                ls_sql = "call pa_sel_um_bbj_mayorista_productos_disponibles (" & dr.Item("cod_cliente").ToString & ",'" &
                        dr.Item("cod_producto_mayorista").ToString & "')"
                dt = myOtrans.Obtiene(ls_sql)

                If dt.Rows.Count > 0 Then
                    Try

                        '' Si ya existe debo modificar

                        fecha_modifico = ""
                        Try
                            fecha_modifico = Date.Parse(dr.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm")
                        Catch ex As Exception
                            fecha_modifico = "1900-01-01"
                        End Try


                        ls_sql = "Call pa_upd_um_bbj_mayorista_productos_disponibles_XML (" & dr.Item("cod_cliente").ToString & "," &
                                dr.Item("cod_proveedor").ToString & ",'" & dr.Item("cod_producto_mayorista").ToString & "','" &
                                dr.Item("cod_producto_proveedor").ToString & "','" & dr.Item("descripcion").ToString & "'," &
                                dr.Item("precio_venta").ToString & "," & dr.Item("precio_proveedor").ToString & "," &
                                dr.Item("factor_alternativo").ToString & "," & dr.Item("descuento_producto").ToString & "," &
                                dr.Item("existencia").ToString & "," & dr.Item("minimo").ToString & ",'" & dr.Item("usuario_modifico").ToString & "','" &
                                fecha_modifico & "')"

                        myOtrans.Actualiza(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            Resultado = False
                        End If
                    Catch ex As Exception
                    End Try
                Else

                    ''Inserta Productos Nuevos
                    ls_sql = "Call pa_ins_um_bbj_mayorista_productos_disponibles_XML (" & dr.Item("cod_cliente").ToString & "," &
                            dr.Item("cod_proveedor").ToString & ",'" & dr.Item("cod_producto_mayorista").ToString & "','" &
                            dr.Item("cod_producto_proveedor").ToString & "','" & dr.Item("descripcion").ToString & "'," &
                            dr.Item("precio_venta").ToString & "," & dr.Item("precio_proveedor").ToString & "," &
                            dr.Item("factor_alternativo").ToString & "," & dr.Item("descuento_producto").ToString & "," &
                            dr.Item("existencia").ToString & "," & dr.Item("minimo").ToString & ",'" & dr.Item("usuario_grabo").ToString & "','" &
                            Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "')"

                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        Resultado = False
                    End If


                End If

            Next


        Catch ex As Exception
            Resultado = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return Resultado
    End Function

    Function Subir_Ruta_Alias_XML(ByVal _odt As DataTable) As Boolean

        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim ls_sql As String
        Dim Resultado As Boolean = True

        Try
            myOtrans.open()
            For Each dr In _odt.Rows
                ls_sql = "call pa_upd_um_bbj_mayorista_ruta_alias_XML (" & dr.Item("cod_cliente").ToString & "," &
                         dr.Item("cod_ruta").ToString & ",'" & dr.Item("descripcion").ToString & "','" &
                         dr.Item("usuario_grabo").ToString & "','" &
                         Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "')"
                myOtrans.Actualiza(ls_sql)
                If myOtrans.Codigo_error > 0 Then
                    Resultado = False
                End If

            Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return Resultado
    End Function

    Function Subir_Vendedor_Alias_XML(ByVal _odt As DataTable) As Boolean
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim ls_sql As String
        Dim Resultado As Boolean = True

        Try
            myOtrans.open()
            For Each dr In _odt.Rows
                ls_sql = "call pa_upd_um_bbj_mayorista_vendedor_alias_XML (" & dr.Item("cod_cliente").ToString & "," &
                         dr.Item("cod_vendedor").ToString & ",'" & dr.Item("nombre").ToString & "','" &
                         dr.Item("usuario_grabo").ToString & "','" &
                         Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "')"
                myOtrans.Actualiza(ls_sql)
                If myOtrans.Codigo_error > 0 Then
                    Resultado = False
                End If
            Next

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return Resultado
    End Function



    Function Subir_Clientes_XML(ByVal _odt As DataTable) As Boolean
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Resultado As Boolean = True

        Try
            myOtrans.open()
            For Each dr In _odt.Rows

                ''Primero debe verificar si existe
                ls_sql = "call pa_sel_um_bbj_mayorista_cliente (" & dr.Item("cod_cliente").ToString & "," &
                        dr.Item("cod_cliente_mayorista").ToString & ")"
                dt = myOtrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    If dr.Item("cod_tipo_cliente").ToString.Length = 0 Then
                        dr.Item("cod_tipo_cliente") = 1
                    End If

                    'If dr.Item("cod_vendedor").ToString.Length = 0 Then
                    '    dr.Item("cod_vendedor") = 1
                    'End If

                    '& dr.Item("cod_vendedor").ToString & 

                    ls_sql = "call pa_ins_um_bbj_mayorista_cliente_XML (" & dr.Item("cod_cliente").ToString & "," &
                       dr.Item("cod_cliente_mayorista").ToString & "," & dr.Item("cod_tipo_cliente").ToString & ",'" &
                        dr.Item("nit").ToString & "','" & dr.Item("nombre").ToString & "','" & dr.Item("propietario").ToString & "'," &
                        dr.Item("cod_ruta").ToString & ",1" & ",'" & dr.Item("direccion_calle").ToString & "'," &
                        dr.Item("direccion_zona").ToString & ",'" & dr.Item("direccion_colonia").ToString & "'," &
                        dr.Item("direccion_municipio").ToString & "," & dr.Item("direccion_departamento").ToString & "," &
                        dr.Item("direccion_pais").ToString & ",'" & dr.Item("telefono").ToString & "'," & dr.Item("estado").ToString & ",'" &
                        dr.Item("observaciones").ToString & "'," & dr.Item("orden_visita").ToString & "," & dr.Item("descuento").ToString & ",'" &
                        dr.Item("usuario_grabo").ToString & "','" & Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "'," &
                        dr.Item("cod_tipo_localidad_geo") & "," & dr.Item("cod_sucursal").ToString & ")"

                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        Resultado = False
                    End If


                Else
                    Try
                        If dr.Item("cod_tipo_cliente").ToString.Length = 0 Then
                            dr.Item("cod_tipo_cliente") = 1
                        End If

                        If dr.Item("cod_vendedor").ToString.Length = 0 Then
                            dr.Item("cod_vendedor") = 1
                        End If



                        ls_sql = "call pa_upd_um_bbj_mayorista_cliente_XML (" & dr.Item("cod_cliente").ToString & "," &
                           dr.Item("cod_cliente_mayorista").ToString & "," & dr.Item("cod_tipo_cliente").ToString & ",'" &
                            dr.Item("nit").ToString & "','" & dr.Item("nombre").ToString & "','" & dr.Item("propietario").ToString & "'," &
                            dr.Item("cod_ruta").ToString & "," & dr.Item("cod_vendedor").ToString & ",'" & dr.Item("direccion_calle").ToString.Replace("'", "") & "'," &
                            dr.Item("direccion_zona").ToString & ",'" & dr.Item("direccion_colonia").ToString & "'," &
                            dr.Item("direccion_municipio").ToString & "," & dr.Item("direccion_departamento").ToString & "," &
                            dr.Item("direccion_pais").ToString & ",'" & dr.Item("telefono").ToString & "'," & dr.Item("estado").ToString & ",'" &
                            dr.Item("observaciones").ToString & "'," & dr.Item("orden_visita").ToString & "," & dr.Item("descuento").ToString & ",'" &
                            dr.Item("usuario_modifico").ToString & "','" & Date.Parse(dr.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm") & "'," &
                            dr.Item("cod_tipo_localidad_geo").ToString & "," & dr.Item("cod_sucursal").ToString & ")"

                        myOtrans.Actualiza(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            Resultado = False
                        End If
                    Catch ex As Exception

                    End Try
                End If

            Next
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            Resultado = False
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try
        Return Resultado

    End Function


    Function Subir_Clientes_XML(ByVal _odt As DataTable, ByVal odt_vendedores As DataTable) As Boolean
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Resultado As Boolean = True

        Try

            Try
                If Not odt_vendedores.Columns.Contains("predeterminado") Then
                    'ods.Tables("encabezado_movimiento").Columns.Add(New DataColumn("correlativo", GetType(Integer)))
                    odt_vendedores.Columns.Add(New DataColumn("predeterminado", GetType(Integer)))

                    For Each dr In odt_vendedores.Rows
                        dr.Item("predeterminado") = 1

                    Next

                End If
            Catch ex As Exception

            End Try
            myOtrans.open()
            For Each dr In _odt.Rows

                ''Primero debe verificar si existe
                ls_sql = "call pa_sel_um_bbj_mayorista_cliente (" & dr.Item("cod_cliente").ToString & "," &
                        dr.Item("cod_cliente_mayorista").ToString & ")"
                dt = myOtrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    If dr.Item("cod_tipo_cliente").ToString.Length = 0 Then
                        dr.Item("cod_tipo_cliente") = 1
                    End If

                    If dr.Item("direccion_zona").ToString.Length = 0 Then
                        dr.Item("direccion_zona") = 0
                    End If

                    If dr.Item("cod_ruta").ToString.Length = 0 Then
                        dr.Item("cod_ruta") = 0
                    End If

                    ls_sql = "call pa_ins_um_bbj_mayorista_cliente_XML_temporal (" & dr.Item("cod_cliente").ToString & "," &
                       dr.Item("cod_cliente_mayorista").ToString & "," & dr.Item("cod_tipo_cliente").ToString & ",'" &
                        dr.Item("nit").ToString.Trim & "','" & dr.Item("nombre").ToString.Trim.Replace("'", " ") & "','" & dr.Item("propietario").ToString.Trim & "'," &
                        dr.Item("cod_ruta").ToString.Trim & ",'" & dr.Item("direccion_calle").ToString.Trim & "'," &
                        dr.Item("direccion_zona").ToString & ",'" & dr.Item("direccion_colonia").ToString & "'," &
                        Val(dr.Item("direccion_municipio").ToString) & "," & Val(dr.Item("direccion_departamento").ToString) & "," &
                        dr.Item("direccion_pais").ToString & ",'" & dr.Item("telefono").ToString.Trim & "'," & dr.Item("estado").ToString & ",'" &
                        dr.Item("observaciones").ToString & "'," & dr.Item("orden_visita").ToString & "," & dr.Item("descuento").ToString & ",'" &
                        dr.Item("usuario_grabo").ToString & "','" & Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "'," &
                        dr.Item("cod_tipo_localidad_geo") & "," & dr.Item("cod_sucursal").ToString & ")"

                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        Resultado = False
                    Else
                        Dim ls_filtro As String
                        ls_filtro = "cod_cliente = " & dr.Item("cod_cliente").ToString &
                                                            " and cod_sucursal = " & dr.Item("cod_sucursal").ToString &
                                                            " and cod_cliente_mayorista = " & dr.Item("cod_cliente_mayorista").ToString

                        odt_vendedores.DefaultView.RowFilter = ls_filtro


                        If odt_vendedores.DefaultView.Count > 0 Then
                            ls_sql = "call pa_del_um_bbj_mayorista_cliente_vendedor (" & dr.Item("cod_cliente").ToString & "," &
                                                             dr.Item("cod_sucursal").ToString & "," & dr.Item("cod_cliente_mayorista") & ")"

                            myOtrans.Elimina(ls_sql)

                        End If

                        For Each drv In odt_vendedores.DefaultView
                            ls_sql = "call pa_ins_um_bbj_mayorista_cliente_vendedor (" &
                                        drv.Item("cod_cliente").ToString & "," & drv.Item("cod_sucursal").ToString & "," &
                                        drv.Item("cod_cliente_mayorista").ToString & "," & drv.Item("cod_vendedor").ToString & "," &
                                        drv.Item("predeterminado").ToString & ")"
                            myOtrans.Ingresa(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                Resultado = False
                            End If

                        Next
                    End If


                Else
                    Try
                        If dr.Item("cod_tipo_cliente").ToString.Length = 0 Then
                            dr.Item("cod_tipo_cliente") = 1
                        End If
                        If dr.Item("direccion_zona").ToString.Length = 0 Then
                            dr.Item("direccion_zona") = 0
                        End If

                        If dr.Item("cod_ruta").ToString.Length = 0 Then
                            dr.Item("cod_ruta") = 0
                        End If

                        Try
                            ls_sql = "call pa_upd_um_bbj_mayorista_cliente_XML (" & dr.Item("cod_cliente").ToString & "," &
                                dr.Item("cod_cliente_mayorista").ToString & "," & dr.Item("cod_tipo_cliente").ToString & ",'" &
                                 dr.Item("nit").ToString.Trim & "','" & dr.Item("nombre").ToString.Trim & "','" & dr.Item("propietario").ToString.Trim & "'," &
                                 dr.Item("cod_ruta").ToString & ",'" & dr.Item("direccion_calle").ToString.Replace("'", "").Trim & "'," &
                                 dr.Item("direccion_zona").ToString & ",'" & dr.Item("direccion_colonia").ToString.Trim & "'," &
                                 dr.Item("direccion_municipio").ToString & "," & dr.Item("direccion_departamento").ToString & "," &
                                 dr.Item("direccion_pais").ToString & ",'" & dr.Item("telefono").ToString.Trim & "'," & dr.Item("estado").ToString & ",'" &
                                 dr.Item("observaciones").ToString.Trim & "'," & dr.Item("orden_visita").ToString & "," & dr.Item("descuento").ToString & ",'" &
                                 dr.Item("usuario_modifico").ToString & "','" & Date.Parse(dr.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm") & "'," &
                                 dr.Item("cod_tipo_localidad_geo").ToString & "," & dr.Item("cod_sucursal").ToString & ")"

                            myOtrans.Actualiza(ls_sql)
                            'If dr.Item("estado") = 2 Then
                            '    Resultado = True
                            'End If
                        Catch ex As Exception

                        End Try

                        If myOtrans.Codigo_error > 0 Then
                            Resultado = False
                        Else
                            odt_vendedores.DefaultView.RowFilter = "cod_cliente = " & dr.Item("cod_cliente").ToString &
                                            "and cod_sucursal = " & dr.Item("cod_sucursal").ToString &
                                            "and cod_cliente_mayorista = " & dr.Item("cod_cliente_mayorista").ToString


                            If odt_vendedores.DefaultView.Count > 0 Then
                                ls_sql = "call pa_del_um_bbj_mayorista_cliente_vendedor (" & dr.Item("cod_cliente").ToString & "," &
                                                                 dr.Item("cod_sucursal").ToString & "," & dr.Item("cod_cliente_mayorista") & ")"

                                myOtrans.Elimina(ls_sql)

                            End If

                            For Each drv In odt_vendedores.DefaultView
                                ls_sql = "call pa_ins_um_bbj_mayorista_cliente_vendedor (" &
                                            drv.Item("cod_cliente").ToString & "," & drv.Item("cod_sucursal").ToString & "," &
                                            drv.Item("cod_cliente_mayorista").ToString & "," & drv.Item("cod_vendedor").ToString & "," &
                                            drv.Item("predeterminado").ToString & ")"
                                myOtrans.Ingresa(ls_sql)
                                If myOtrans.Codigo_error > 0 Then
                                    Resultado = False
                                End If

                            Next
                        End If

                    Catch ex As Exception

                    End Try
                End If

            Next
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            Resultado = False
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try
        Return Resultado

    End Function

    Function Subir_Proveedores_XML(ByVal _odt As DataTable) As Boolean
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Resultado As Boolean = True

        Try
            myOtrans.open()
            For Each dr In _odt.Rows
                ''Primero debe verificar si existe
                ls_sql = "call pa_sel_um_bbj_mayorista_proveedor (" & dr.Item("cod_cliente").ToString & "," &
                        dr.Item("cod_proveedor_mayorista").ToString & ")"
                dt = myOtrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    ls_sql = "call pa_ins_um_bbj_mayorista_proveedor_XML (" & dr.Item("cod_cliente").ToString & "," &
                            dr.Item("cod_proveedor_mayorista").ToString & ",'" & dr.Item("nit").ToString & "','" &
                            dr.Item("nombre_proveedor").ToString & "','" & dr.Item("contacto").ToString & "','" &
                            dr.Item("telefono").ToString & "','" & dr.Item("observaciones").ToString & "','" &
                            dr.Item("direccion_calle").ToString & "'," & dr.Item("direccion_zona").ToString & ",'" &
                            dr.Item("direccion_colonia").ToString & "'," & dr.Item("direccion_municipio").ToString & "," &
                            dr.Item("direccion_departamento").ToString & "," & dr.Item("direccion_pais").ToString & ",'" &
                            dr.Item("usuario_grabo").ToString & "','" & Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "')"

                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        Resultado = False
                    End If

                Else
                    Try

                        ls_sql = "call pa_upd_um_bbj_mayorista_proveedor_XML (" & dr.Item("cod_cliente").ToString & "," &
                                dr.Item("cod_proveedor_mayorista").ToString & ",'" & dr.Item("nit").ToString & "','" &
                                dr.Item("nombre_proveedor").ToString & "','" & dr.Item("contacto").ToString & "','" &
                                dr.Item("telefono").ToString & "','" & dr.Item("observaciones").ToString & "','" &
                                dr.Item("direccion_calle").ToString & "'," & dr.Item("direccion_zona").ToString & ",'" &
                                dr.Item("direccion_colonia").ToString & "'," & dr.Item("direccion_municipio").ToString & "," &
                                dr.Item("direccion_departamento").ToString & "," & dr.Item("direccion_pais").ToString & ",'" &
                                dr.Item("usuario_modifico").ToString & "','" & Date.Parse(dr.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm") & "')"

                        myOtrans.Actualiza(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            Resultado = False
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Next


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try
        Return Resultado
    End Function

    Function Subir_Depositos_XML(ByVal _odt As DataTable) As Boolean
        Dim Resultado As Boolean = True
        Dim dr As DataRow
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dt As DataTable
        Dim ls_sql As String


        Try
            myOtrans.open()
            For Each dr In _odt.Rows
                ls_sql = "call pa_sel_um_bbj_mayorista_deposito (" & dr.Item("cod_cliente").ToString & "," &
                        dr.Item("cod_deposito").ToString & ")"
                dt = myOtrans.Obtiene(ls_sql)

                If dt.Rows.Count = 0 Then
                    ls_sql = "call pa_ins_um_bbj_mayorista_deposito_XML (" & dr.Item("cod_deposito").ToString & "," &
                            dr.Item("cod_cliente").ToString & ",'" & dr.Item("banco").ToString & "','" &
                            dr.Item("numero_boleta").ToString & "','" & Date.Parse(dr.Item("fecha").ToString).ToString("yyyy-MM-dd") & "'," &
                            dr.Item("valor").ToString & ",'" & dr.Item("observaciones").ToString & "','" &
                            dr.Item("usuario_grabo").ToString & "','" & Date.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd") & "')"

                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        Resultado = False
                    End If
                End If
            Next


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return Resultado
    End Function

    Function Subir_Linea_DAT(ByVal _Ruta_Archivo As String) As Boolean
        Dim fs_archivo As StreamReader
        Dim linea As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim bresultado As Boolean = True


        Try
            myOtrans.open()

            fs_archivo = System.IO.File.OpenText(_Ruta_Archivo)
            Do Until fs_archivo.Peek = -1
                linea = CStr(fs_archivo.ReadLine)
                myOtrans.Elimina(linea)
                If myOtrans.Codigo_error > 0 Then
                    bresultado = True
                End If
                fs_archivo.Close()
                Exit Do
            Loop

        Catch ex As Exception
            bresultado = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return bresultado
    End Function

    Function Subir_Mensajeria_XML(ByVal _dt As DataTable) As Boolean
        Dim Resultado As Boolean = True
        Dim dr As DataRow
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Dim ls_sql As String


        Try
            myOtrans.open()
            For Each dr In _dt.Rows

                ls_sql = "call pa_ins_um_bbj_mayorista_mensajeria_traslado (" & dr.Item("cod_cliente").ToString & ",'" &
                                    dr.Item("importancia").ToString & "','" & dr.Item("asunto").ToString & "','" &
                                    Date.Parse(dr.Item("fecha_envio").ToString).ToString("yyyy-MM-dd") & "','" &
                                    dr.Item("observaciones").ToString & "','" & dr.Item("usuario_grabo") & "'," & dr.Item("envio_recepcion") & "," &
                                    dr.Item("cod_mensaje") & ")"
                myOtrans.Ingresa(ls_sql)
            Next

        Catch ex As Exception
            Resultado = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return Resultado
    End Function

    Private Sub Actualizar_Estadisticas_MR()
        '(c)160109 Jos. 24:15 me and my house, we will serve the LORD
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim ls_sql As String
        Dim fecha_inicio_proceso As DateTime

        fecha_inicio_proceso = Today.AddDays(-Today.Day + 1).AddMonths(-1)


        Try
            myOtrans.open()

            ''Borrar e Insertar Cliente
            ls_sql = "call pa_del_um_t_clientes ()"
            myOtrans.Elimina(ls_sql)


            ls_sql = "call pa_ins_um_t_clientes ()"
            myOtrans.Ingresa(ls_sql)


            ''Borra e Inserta Productos
            ls_sql = "call pa_del_um_t_producto ()"
            myOtrans.Elimina(ls_sql)

            ls_sql = "call pa_ins_um_t_producto ()"
            myOtrans.Ingresa(ls_sql)

            ''Borra e Inserta Movimientos
            ls_sql = "call pa_del_um_t_movimientos ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Elimina(ls_sql)

            ls_sql = "call pa_ins_um_t_Movimientos ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Ingresa(ls_sql)

            ''Borra lo clientes y los inserta en la tabla t_datos, la tabla t_datos es el origen
            ''de los reportes MR
            ls_sql = "call pa_del_um_t_datos_inicial ()"
            myOtrans.Elimina(ls_sql)

            ls_sql = "call pa_ins_um_t_datos_inicial ()"
            myOtrans.Ingresa(ls_sql)

            ''elimina Inserta los movimiento en un rango de fechas determinadas en la taba t_datos
            ls_sql = "call pa_del_um_t_datos_movimientos ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Elimina(ls_sql)

            ls_sql = "call pa_ins_um_t_datos_movimientos ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Ingresa(ls_sql)

            ''Borra e Inserta los clientes efectivos(resumen) de un rango de fecha determinada en t_datos
            ls_sql = "call pa_del_um_t_datos_efectivos ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Elimina(ls_sql)

            ls_sql = "call pa_ins_um_t_datos_efectivos ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Ingresa(ls_sql)

            ''Borra e Inserta los clientes efectivos(resumen) de un rango de fecha determinada en t_datos
            ls_sql = "call pa_del_um_t_datos_efectivos_paso_7 ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Elimina(ls_sql)

            ls_sql = "call pa_ins_um_t_datos_efectivos_paso_7 ('" & fecha_inicio_proceso.ToString("yyyy-MM-dd") & "')"
            myOtrans.Ingresa(ls_sql)



        Catch ex As Exception
            ''Debo limpiar todo
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

    End Sub

#End Region


#Region "Envio de Archivos a Directorio Receive de MR"

    Private Sub Enviar_Archivos_mr()
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            myOtrans.abrir()
            ls_sql = "call pa_sel_um_bbj_mayorista (null)"
            dt = myOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                If dr.Item("path_archivos").ToString.Length > 10 Then
                    Generar_Informacion_MR(dr)
                End If
            Next

        Catch ex As Exception
        Finally

            ls_sql = "call pa_upd_um_pg_procesos_isf (4)"
            myOtrans.Actualiza(ls_sql)

            myOtrans.close()
            myOtrans = Nothing
        End Try
    End Sub

    Private Sub Generar_Informacion_MR(ByVal _dr As DataRow)

        Dim ls_sql, ls_archivo As String
        Dim iCount, ncol As Integer
        Dim dt, dt2, dt3, dt4 As DataTable
        Dim Ods As New DataSet
        Dim ocol As New DataColumn

        Dim dr, dr2, dr3 As DataRow
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            Otrans.open()
            myOtrans.open()
            ls_sql = "Call pa_sel_um_crm_cliente_flex (" & _dr.Item("cod_cliente").ToString & ", null, 2)"
            dt = myOtrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                For Each dr In dt.Rows

                    ls_sql = "pa_sel_um_ctacte 'CODICASA','CLIENTE','" & dr.Item("codigo_flex") & "'"
                    dt2 = Otrans.Obtiene(ls_sql)
                    If dt2.Rows(0).Item("Analisisctacte6").ToString.Length > 0 Then
                        Otrans.close()
                        Otrans = New Transaccional.Conexion("FlexLine" & dt2.Rows(0).Item("Analisisctacte6").ToString)
                        Otrans.open()
                    End If

                    ls_sql = "pa_var_um_documentos_cliente_tracking 'CODICASA','" & dr.Item("codigo_flex") & "'"
                    dt2 = Otrans.Obtiene(ls_sql)
                    For Each dr2 In dt2.Rows

                        ''todo va en el Detalle de Facturas
                        ls_sql = "pa_sel_um_documentod '" & dr2.Item("Empresa").ToString & "','" & dr2.Item("TipoDocto").ToString & "','" & dr2.Item("Numero").ToString & "'"
                        dt3 = Otrans.Obtiene(ls_sql)
                        If Not Ods.Tables.Contains("detalle_factura") Then
                            dt3.TableName = "detalle_factura"
                            ncol = dt3.Columns.Count - 1
                            dt4 = dt3.Copy
                            For Each ocol In dt4.Columns ' iCount = 0 To ncol
                                If ocol.ColumnName.ToLower = "empresa" Or
                                    ocol.ColumnName.ToLower = "tipodocto" Or
                                    ocol.ColumnName.ToLower = "correlativo" Or
                                    ocol.ColumnName.ToLower = "secuencia" Or
                                    ocol.ColumnName.ToLower = "producto" Or
                                    ocol.ColumnName.ToLower = "_unidades" Or
                                    ocol.ColumnName.ToLower = "glosa" Or
                                    ocol.ColumnName.ToLower = "total_docto" Or
                                    ocol.ColumnName.ToLower = "cliente" Or
                                    ocol.ColumnName.ToLower = "fecha_docto" Or
                                    ocol.ColumnName.ToLower = "comentario1" Or
                                    ocol.ColumnName.ToLower = "numero_docto" Or
                                    ocol.ColumnName.ToLower = "_valores" Then
                                Else
                                    iCount = dt3.Columns.IndexOf(ocol.ColumnName)
                                    dt3.Columns.RemoveAt(iCount)
                                End If
                            Next
                            Ods.Tables.Add(dt3.Copy)
                        Else
                            For Each dr3 In dt3.Rows
                                Ods.Tables("detalle_factura").ImportRow(dr3)
                            Next
                        End If
                    Next 'Documentos
                Next 'clientes flex
            End If
        Catch ex As Exception
            '     MessageBox.Show(ex.Message)
        Finally


        End Try

        ''Tipos de Clientes
        Try

            ls_sql = "call pa_var_um_bbj_mayorista_tipo_cliente_traslado ()"
            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "tipo_cliente"
            If dt.Rows.Count > 0 Then
                Ods.Tables.Add(dt.Copy)
            End If


        Finally

        End Try

        ''Mensajes
        Try

            ls_sql = "call pa_var_um_bbj_mayorista_mensajeria_traslado (" & _dr.Item("cod_cliente").ToString & ")"
            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "mensajeria"
            If dt.Rows.Count > 0 Then
                Ods.Tables.Add(dt.Copy)
                For Each dr In Ods.Tables("mensajeria").Rows
                    ls_sql = "call pa_upd_um_bbj_mayorista_mensajeria_traslado (" &
                        dr.Item("cod_cliente").ToString & "," &
                        dr.Item("cod_mensaje").ToString & "," &
                        dr.Item("envio_recepcion").ToString & ")"

                    myOtrans.Actualiza(ls_sql)
                Next
            End If


        Catch ex As Exception

        End Try

        ''Productos Aprobados

        Try
            ls_sql = "call pa_var_um_bbj_mayorista_productos_aprobados_traslado (" & _dr.Item("cod_cliente").ToString & ")"
            dt = myOtrans.Obtiene(ls_sql)
            dt.TableName = "productos_aprobados"
            If dt.Rows.Count > 0 Then
                Ods.Tables.Add(dt.Copy)
                For Each dr In Ods.Tables("productos_aprobados").Rows
                    ls_sql = "call pa_upd_um_bbj_mayorista_productos_aprobados_traslado (" &
                        dr.Item("cod_cliente").ToString & ",'" &
                        dr.Item("cod_flex").ToString & "')"
                    myOtrans.Actualiza(ls_sql)
                Next
            End If
        Catch ex As Exception

        End Try

        myOtrans.close()
        myOtrans = Nothing
        Otrans.close()
        Otrans = Nothing

        If Ods.Tables.Count > 0 Then
            ls_archivo = "c:\aplicaciones\" & _dr.Item("cod_cliente").ToString & "\receive\" & Now.ToString("ddMMyyyyhhmmss") & ".xml"
            Ods.WriteXml(ls_archivo, XmlWriteMode.WriteSchema)
        End If

        Mover_Archivos_Receive_Mr(_dr)

    End Sub

    Private Sub Mover_Archivos_Receive_Mr(ByVal _dr As DataRow)
        Dim clsGen As New ClasesGenerales.General

        Dim Archivos As String()
        Dim Ruta_Archivos As String
        Dim strDir As String
        Dim ArchivoDestino As String

        Ruta_Archivos = _dr.Item("path_archivos").ToString & "receive"
        Ruta_Archivos = "c:\aplicaciones\" & _dr.Item("cod_cliente").ToString & "\Receive"

        Try
            Archivos = Directory.GetFiles(Ruta_Archivos, "*.*")
            ArchivoDestino = _dr.Item("path_archivos").ToString & "Receive"

            For Each strDir In Archivos
                If clsGen.Copiar_Archivo(strDir, ArchivoDestino & "\" & strDir.Split("\").GetValue(strDir.Split("\").LongLength - 1), True) Then
                    clsGen.Mover_Archivo(strDir, Ruta_Archivos & "\log\" & strDir.Split("\").GetValue(strDir.Split("\").LongLength - 1))
                End If
            Next
        Catch ex As Exception
        Finally
            clsGen = Nothing
        End Try
    End Sub

#End Region

#Region "Memos Promocionales"

    Public Sub Procesar_Memos_Promocionales(ByVal _cod_proceso As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Oflex As New Umbral_Flex.Memos_Promocionales


        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr As DataRow


        Try
            myOtrans.open()
            ls_sql = "call pa_var_um_mmp_encabezado_listado (6,null,null)" '6=esperando operacion en flex
            dt = myOtrans.Obtiene(ls_sql)
            For Each dr In dt.Rows
                Oflex.Guardar_Memo_Flex(dr)
            Next

        Catch ex As Exception
        Finally
            ls_sql = "call pa_upd_um_pg_procesos_isf (" & _cod_proceso.ToString & ")"
            myOtrans.Actualiza(ls_sql)

            myOtrans.close()
            myOtrans = Nothing
            Oflex.Dispose()
            Oflex = Nothing
        End Try
    End Sub





#End Region


#Region "Pedidos Web Umbright Mobile"
    Private Sub Obtener_Pedidos_Web()
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Dim ff As New FTP.clsFTP
        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim archivos() As String
        Dim icount As Integer




        Try
            myOtrans.open()
            ''Busco Especificamente con cliente divasa
            ls_sql = "call pa_sel_um_edi_configuraciones ('dmarte')"

            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = ""
            drv = dt.DefaultView(0)

            '        ' Create an instance of the FTP Class.
            'Me.txt_status.Text = "Creando la Instancia"
            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            ff.RemoteHost = drv.Item("host") '"gtmailmarketing.com"
            ff.RemoteUser = drv.Item("usuario")  '"gerber@gtmailmarketing.com"
            ff.RemotePassword = drv.Item("password") '"gerber"
            '  drv.Item("Carpeta") = "dmarte-www"

            Me.lbl.Items.Add("FTP-Conectando")
            If (ff.Login()) Then
                ff.ChangeDirectory("dmarte-www")
                ff.ChangeDirectory("consulnet")
                ff.ChangeDirectory("ftp")

                ff.SetBinaryMode(True)

                Me.lbl.Items.Add("Transfiriendo")

                archivos = ff.GetFileList("")

                For icount = 0 To archivos.Length - 1
                    If archivos(icount).ToLower.IndexOf("xml") > 0 Then
                        If ff.RenameFile(archivos(icount).Trim, "_" & archivos(icount).Trim) Then
                            ff.DownloadFile("_" & archivos(icount).Trim, "c:\Aplicaciones\Web\" & "_" & archivos(icount).Trim)

                            ff.DeleteFile("_" & archivos(icount).Trim)
                            ff.ChangeDirectory("Log")
                            'ff.UploadFile("c:\Aplicaciones\Web\_" & archivos(icount).Trim)

                            ff.ChangeDirectory("..")
                        End If
                    End If
                Next
            End If
            Me.lbl.Items.Add("FTP- Proceso Finalizado")
        Catch ex As System.Exception            '        

            Me.lbl.Items.Add(ex.Message)
            Me.lbl.Items.Add("Message from FTP Server was: " & ff.MessageString)
        Finally
            ff.CloseConnection()
            ff = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try
    End Sub

    Private Sub Obtener_Pedidos_Tekne()
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Dim ff As New FTP.clsFTP
        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim archivosxml() As String
        Dim icount2 As Integer

        Try
            myOtrans.open()
            ''Busco Especificamente con cliente divasa
            ls_sql = "call pa_sel_um_edi_configuraciones ('dmarte')"

            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = ""
            drv = dt.DefaultView(0)

            ' Create an instance of the FTP Class.

            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            ff.RemoteHost = drv.Item("host")
            ff.RemoteUser = drv.Item("usuario")
            ff.RemotePassword = drv.Item("password")

            Me.lbl.Items.Add("FTP-Conectando")
            If (ff.Login()) Then
                ff.ChangeDirectory(drv.Item("carpeta"))
                ff.ChangeDirectory("tekne")


                ff.SetBinaryMode(True)

                Me.lbl.Items.Add("Transfiriendo")

                '                archivostxt = ff.GetFileList("fin*.txt")

                '                For icount = 0 To archivostxt.Length - 1


                For i As Integer = 0 To 6
                    Try

                        archivosxml = ff.GetFileList("*.xml")
                        For icount2 = 0 To archivosxml.Length - 1
                            If archivosxml(icount2).Length > 0 Then

                                If archivosxml(icount2).ToLower.IndexOf("xml") Then
                                    'And _                                archivosxml(icount2).ToLower.IndexOf(nombre_archivo) > -1 Then
                                    If ff.RenameFile(archivosxml(icount2).Trim, "_" & archivosxml(icount2).Trim) Then
                                        ff.DownloadFile("_" & archivosxml(icount2).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

                                        ff.DeleteFile("_" & archivosxml(icount2).Trim)
                                        'ff.ChangeDirectory("Log")
                                        'ff.UploadFile("c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

                                        'ff.ChangeDirectory("..")
                                    End If
                                End If
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Next

            End If
            Me.lbl.Items.Add("FTP- Proceso Finalizado")
            ff.CloseConnection()
        Catch ex As System.Exception            '        

            Me.lbl.Items.Add(ex.Message)
            Me.lbl.Items.Add("Message from FTP Server was: " & ff.MessageString)
        Finally

            ff = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub

    ''Tekne Tablets 15/11/2013
    ''Olopez
    Private Sub Obtener_Pedidos_Tekne_Mobile_EE()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "tipo = 'Tekne Mobile Enterprise'"

            For Each drv In dt.DefaultView
                ObtenerPedidos_Tekne_Vendedor(drv, dt.DefaultView)
                Exit For
            Next

            'ls_sql = "call pa_upd_um_pg_procesos_isf (7)"
            ' myOtrans.Actualiza(ls_sql)

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_Tekne_Mobile_EE " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Obtener_informacion_azzure()
        Dim Otrans As New Transaccional.Conexion("Azzure")

        Try
            Otrans.abrir()
            Dim dt As DataTable
            Dim dtDetalle As DataTable
            dt = Otrans.Obtiene("Select * from mov_pedidos_encabezado where estado = 1")
            For Each dr As DataRow In dt.Rows
                Otrans.Actualiza("Update mov_pedidos_encabezado set estado = 2 where cod_pedido = " & dr.Item("cod_pedido"))

                dtDetalle = Otrans.Obtiene("Select * from mov_pedidos_detalle where cod_pedido = " & dr.Item("cod_pedido"))
                For Each drdetalle As DataRow In dtDetalle.Rows


                Next





                Otrans.Actualiza("Update mov_pedidos_encabezado set estado = 3 where cod_pedido = " & dr.Item("cod_pedido"))


            Next


            MessageBox.Show(dt.Rows.Count)
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try



    End Sub


    Private Sub ObtenerPedidos_Tekne_Vendedor(ByVal drv As DataRowView, dtv As DataView)
        Dim ff As New FTP.clsFTP



        Dim archivos() As String
        Dim archivo As String
        Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General

        Dim ftpRemoteHost As String
        Dim ftpRemoteUser As String
        Dim ftpRemotePassword As String
        Dim ftpCarpetaInicial As String


        If dtv.Count > 0 Then
            ftpRemoteHost = dtv(0).Item("host")
            ftpRemoteUser = dtv(0).Item("usuario")
            ftpRemotePassword = dtv(0).Item("password")
            ftpCarpetaInicial = dtv(0).Item("carpeta")

            Try
                'ClsGen.Escribir_Log("Obtener Pedidos FTP Tekne  " & drv.Item("descripcion"))
                ff = New FTP.clsFTP

                ' Setup the appropriate properties.
                ff.RemoteHost = ftpRemoteHost
                ff.RemoteUser = ftpRemoteUser
                ff.RemotePassword = ftpRemotePassword



                If (ff.Login()) Then

                    For Each drvUsuario As DataRowView In dtv
                        Try


                            ClsGen.Escribir_Log("Obtener_Pedidos_Tekne_Vendedor  " & ftpCarpetaInicial & " " & drvUsuario.Item("descripcion"))

                            ff.ChangeDirectory(ftpCarpetaInicial)
                            ff.ChangeDirectory(drvUsuario.Item("descripcion").ToString)
                            ff.ChangeDirectory(drvUsuario.Item("carpeta_recibir").ToString)
                            ff.SetBinaryMode(True)


                            'Try
                            '    archivos = ff.GetFileList("*.txt")
                            'Catch ex As Exception

                            'End Try


                            'If archivos.Length > 0 Then  ''Verifico que Exista el Archivo .txt
                            '    For Each archivo In archivos
                            '        If archivo.Length > 0 Then
                            '            'Dim sfecha As String = archivo.Split("_")(1)
                            '            'Dim dfecha_sincronizacion As DateTime _
                            '            '    = DateTime.Parse(sfecha.Substring(6, 2) & "-" & sfecha.Substring(8, 2) & "-" & _
                            '            '    sfecha.Substring(10, 4) & " " & sfecha.Substring(4, 2) & ":" & _
                            '            '    sfecha.Substring(2, 2) & ":" & sfecha.Substring(0, 2))
                            '            'Guardar_Sincronizacion(drv.Item("usuario"), dfecha_sincronizacion, dfecha_sincronizacion, 1)


                            '            ff.DeleteFile(archivo.Trim)
                            '        End If
                            '    Next



                            archivos = ff.GetFileList("*.xml")
                            For icount = 0 To archivos.Length - 1
                                If archivos(icount).ToLower.IndexOf("xml") > 0 Then
                                    If archivos(icount).StartsWith("pedido_tekne_mr_") Then
                                        ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\MR\_" & archivos(icount).Trim)
                                    Else
                                        ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                    End If

                                    'If ff.RenameFile(archivos(icount).Trim, "_" & archivos(icount).Trim) Then (c)26032015 Ya no se carga el backup

                                    'ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                    'ff.DownloadFile("_" & archivos(icount).Trim, "\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                    ' ff.DownloadFile("_" & archivos(icount).Trim, "\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\Pruebas\_" & archivos(icount).Trim)


                                    ff.DeleteFile(archivos(icount).Trim)

                                    'ff.ChangeDirectory("..") (c)26032015 Ya no se carga el backup
                                    'ff.ChangeDirectory("Backup") (c)26032015 Ya no se carga el backup

                                    'ff.UploadFile("c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                    'ff.UploadFile("\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                    'ff.UploadFile("\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\Pruebas\_" & archivos(icount).Trim)


                                    'ff.ChangeDirectory("..")
                                    'ff.ChangeDirectory(drvUsuario.Item("carpeta_recibir").ToString)
                                    'End If
                                End If
                            Next
                            Try
                                ff.ChangeDirectory("..") 'Baja Carpeta Recibir
                                ff.ChangeDirectory("..") 'Baja Carpeta Usuario
                                ff.ChangeDirectory("..") 'Baja Carpeta Usuario
                                ff.ChangeDirectory("..") 'Baja Carpeta Usuario
                                ff.ChangeDirectory("..") 'Baja Carpeta Usuario


                            Catch ex As Exception
                            Catch ex As System.Exception
                            End Try

                            ' End If ''Existe Archivo .txt
                        Catch ex As Exception

                        End Try
                    Next
                End If

            Catch ex As System.Exception            '        
                ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString)
            Finally
                ClsGen.Escribir_Log("Cerrando Conexion FTP")
                ff.CloseConnection()
                ff = Nothing
                ClsGen = Nothing
            End Try
        End If
    End Sub


    Private Sub TestFTP()
        Dim ff As New FTP.clsFTP



        Dim archivos() As String
        Dim archivo As String
        Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General

        Dim ftpRemoteHost As String
        Dim ftpRemoteUser As String
        Dim ftpRemotePassword As String
        Dim ftpCarpetaInicial As String


        'If dtv.Count > 0 Then
        ftpRemoteHost = "aspebi4.sedeb2b.com"
        ftpRemoteUser = "26642514"
        ftpRemotePassword = "it1cmqsyv1"
        ftpCarpetaInicial = "in"

        Try
            'ClsGen.Escribir_Log("Obtener Pedidos FTP Tekne  " & drv.Item("descripcion"))
            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            ff.RemoteHost = ftpRemoteHost
            ff.RemoteUser = ftpRemoteUser
            ff.RemotePassword = ftpRemotePassword
            ff.RemotePort = 2021


            If (ff.Login()) Then

                '  For Each drvUsuario As DataRowView In dtv
                Try


                    '              ClsGen.Escribir_Log("Obtener_Pedidos_Tekne_Vendedor  " & ftpCarpetaInicial & " " & drvUsuario.Item("descripcion"))

                    ff.ChangeDirectory(ftpCarpetaInicial)
                    '                ff.ChangeDirectory(drvUsuario.Item("descripcion").ToString)
                    ff.ChangeDirectory("RETORNO_WM_66083885_26642514")
                    ff.SetBinaryMode(True)


                    'Try
                    '    archivos = ff.GetFileList("*.txt")
                    'Catch ex As Exception

                    'End Try


                    'If archivos.Length > 0 Then  ''Verifico que Exista el Archivo .txt
                    '    For Each archivo In archivos
                    '        If archivo.Length > 0 Then
                    '            'Dim sfecha As String = archivo.Split("_")(1)
                    '            'Dim dfecha_sincronizacion As DateTime _
                    '            '    = DateTime.Parse(sfecha.Substring(6, 2) & "-" & sfecha.Substring(8, 2) & "-" & _
                    '            '    sfecha.Substring(10, 4) & " " & sfecha.Substring(4, 2) & ":" & _
                    '            '    sfecha.Substring(2, 2) & ":" & sfecha.Substring(0, 2))
                    '            'Guardar_Sincronizacion(drv.Item("usuario"), dfecha_sincronizacion, dfecha_sincronizacion, 1)


                    '            ff.DeleteFile(archivo.Trim)
                    '        End If
                    '    Next



                    archivos = ff.GetFileList("*.xml")
                    For icount = 0 To archivos.Length - 1
                        If archivos(icount).ToLower.IndexOf("xml") > 0 Then
                            If archivos(icount).StartsWith("pedido_tekne_mr_") Then
                                ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\MR\_" & archivos(icount).Trim)
                            Else
                                'ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                ff.DownloadFile(archivos(icount).Trim, "c:\temp\Receive\_" & archivos(icount).Trim)
                            End If

                            'If ff.RenameFile(archivos(icount).Trim, "_" & archivos(icount).Trim) Then (c)26032015 Ya no se carga el backup

                            'ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                            'ff.DownloadFile("_" & archivos(icount).Trim, "\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                            ' ff.DownloadFile("_" & archivos(icount).Trim, "\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\Pruebas\_" & archivos(icount).Trim)


                            'ff.DeleteFile(archivos(icount).Trim)

                            'ff.ChangeDirectory("..") (c)26032015 Ya no se carga el backup
                            'ff.ChangeDirectory("Backup") (c)26032015 Ya no se carga el backup

                            'ff.UploadFile("c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                            'ff.UploadFile("\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                            'ff.UploadFile("\\virtualcx\aplicaciones$\Umbright Mobile SE\Receive\Pruebas\_" & archivos(icount).Trim)


                            'ff.ChangeDirectory("..")
                            'ff.ChangeDirectory(drvUsuario.Item("carpeta_recibir").ToString)
                            'End If
                        End If
                    Next
                    Try
                        ff.ChangeDirectory("..") 'Baja Carpeta Recibir
                        ff.ChangeDirectory("..") 'Baja Carpeta Usuario
                        ff.ChangeDirectory("..") 'Baja Carpeta Usuario
                        ff.ChangeDirectory("..") 'Baja Carpeta Usuario
                        ff.ChangeDirectory("..") 'Baja Carpeta Usuario


                    Catch ex As Exception
                    Catch ex As System.Exception
                    End Try

                    ' End If ''Existe Archivo .txt
                Catch ex As Exception

                End Try
                ' Next
            End If

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString)
        Finally
            ClsGen.Escribir_Log("Cerrando Conexion FTP")
            ff.CloseConnection()
            ff = Nothing
            ClsGen = Nothing
        End Try
        'End If
    End Sub


    Private Sub ObtenerPedidos_Tekne_Vendedor_SitioTekne(ByVal drv As DataRowView, ByVal dtv As DataView)
        Dim ff As New FTP.clsFTP



        Dim archivos() As String
        Dim archivo As String
        Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General

        Dim ftpRemoteHost As String
        Dim ftpRemoteUser As String
        Dim ftpRemotePassword As String
        Dim ftpCarpetaInicial As String


        Try

            If dtv.Count > 0 Then

                ftpRemoteHost = dtv(0).Item("host")
                ftpRemoteUser = dtv(0).Item("usuario")
                ftpRemotePassword = dtv(0).Item("password")
                ftpCarpetaInicial = dtv(0).Item("carpeta")
            End If

        Catch ex As Exception

        End Try

        ftpRemoteHost = "tekne.com.gt"
        ftpRemoteUser = "tecnosol"
        ftpRemotePassword = "Tecno@2011"
        'ftpRemotePassword = "Tecno@2016"
        ftpCarpetaInicial = "www/tekne.com.gt/tekne/general"




        Try
            ff = New FTP.clsFTP

            ff.RemoteHost = ftpRemoteHost
            ff.RemoteUser = ftpRemoteUser
            ff.RemotePassword = ftpRemotePassword

            For i As Integer = 1 To 10

                Try
                    If (ff.Login()) Then

                        For Each drvUsuario As DataRowView In dtv
                            Try

                                ClsGen.Escribir_Log("Obtener_Pedidos_Tekne_Vendedor " & ftpCarpetaInicial & " " & drvUsuario.Item("descripcion"))

                                ff.ChangeDirectory(ftpCarpetaInicial)
                                ff.ChangeDirectory(drvUsuario.Item("descripcion").ToString)
                                ff.ChangeDirectory(drvUsuario.Item("carpeta_recibir").ToString)
                                ff.SetBinaryMode(True)

                                archivos = ff.GetFileList("*.xml")
                                For icount = 0 To archivos.Length - 1
                                    Try

                                        If archivos(icount).ToLower.IndexOf("xml") > 0 Then


                                            If archivos(icount).StartsWith("pedido_tekne_mr_") Then
                                                ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\MR\_" & archivos(icount).Trim)
                                            Else
                                                ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                            End If

                                            'ff.DownloadFile(archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivos(icount).Trim)
                                            ff.DeleteFile(archivos(icount).Trim)
                                        End If
                                    Catch ex As Exception

                                    End Try

                                Next
                                ff.ChangeDirectory("..") 'Baja Carpeta Recibir
                                ff.ChangeDirectory("..") 'Baja Carpeta Usuario
                                '       End If ''Existe Archivo .txt
                            Catch ex As Exception
                                ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString)
                            End Try
                        Next


                        ff.CloseConnection()
                        Exit For
                    End If
                Catch ex As Exception

                End Try

            Next
        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString)
        Finally
            ClsGen.Escribir_Log("Cerrando Conexion FTP Vendedor Sitio TEKNE")

            ff = Nothing
            ClsGen = Nothing
        End Try
    End Sub


    Private Sub Obtener_Pedidos_Umbright_Mobile_SE()
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Dim ff As New FTP.clsFTP
        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim archivosxml() As String
        Dim icount2 As Integer

        Try
            myOtrans.open()
            ''Busco Especificamente con cliente divasa
            ls_sql = "call pa_sel_um_edi_configuraciones ('dmarte')"

            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = ""
            drv = dt.DefaultView(0)

            ' Create an instance of the FTP Class.

            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            ff.RemoteHost = drv.Item("host")
            ff.RemoteUser = drv.Item("usuario")
            ff.RemotePassword = drv.Item("password")

            Me.lbl.Items.Add("FTP-Conectando")
            If (ff.Login()) Then
                ff.ChangeDirectory(drv.Item("carpeta"))
                ff.ChangeDirectory("cell")


                ff.SetBinaryMode(True)

                Me.lbl.Items.Add("Transfiriendo")

                '                archivostxt = ff.GetFileList("fin*.txt")

                '                For icount = 0 To archivostxt.Length - 1


                For i As Integer = 0 To 6
                    Try

                        archivosxml = ff.GetFileList("*.xml")
                        For icount2 = 0 To archivosxml.Length - 1


                            If archivosxml(icount2).ToLower.IndexOf("xml") Then
                                'And _                                archivosxml(icount2).ToLower.IndexOf(nombre_archivo) > -1 Then
                                If ff.RenameFile(archivosxml(icount2).Trim, "_" & archivosxml(icount2).Trim) Then
                                    ff.DownloadFile("_" & archivosxml(icount2).Trim, "c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

                                    ff.DeleteFile("_" & archivosxml(icount2).Trim)
                                    'ff.ChangeDirectory("Log")
                                    'ff.UploadFile("c:\Aplicaciones\Umbright Mobile SE\Receive\_" & archivosxml(icount2).Trim)

                                    'ff.ChangeDirectory("..")
                                End If
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Next

            End If
            Me.lbl.Items.Add("FTP- Proceso Finalizado")
            ff.CloseConnection()
        Catch ex As System.Exception            '        

            Me.lbl.Items.Add(ex.Message)
            Me.lbl.Items.Add("Message from FTP Server was: " & ff.MessageString)
        Finally

            ff = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try

    End Sub

    Private Sub Obtener_Pedidos_Umbright_Mobile_EE()
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")

        Dim dt As DataTable
        Dim drv As DataRowView

        Dim ls_sql As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()
            ls_sql = "call pa_sel_um_edi_configuraciones (NULL)"
            dt = myOtrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "tipo = 'Umbright Mobile Enterprise'"

            For Each drv In dt.DefaultView
                Obtener_Pedidos_Umbright_Mobile_Vendedor(drv)
            Next

            ls_sql = "call pa_upd_um_pg_procesos_isf (7)"
            myOtrans.Actualiza(ls_sql)

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_MySysgold " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Obtener_Pedidos_Umbright_Mobile_Vendedor(ByVal drv As DataRowView)
        Dim ff As New FTP.clsFTP



        Dim archivos() As String
        Dim archivo As String
        Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General


        Try

            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            ff.RemoteHost = drv.Item("host")
            ff.RemoteUser = drv.Item("usuario")
            ff.RemotePassword = drv.Item("password")



            If (ff.Login()) Then
                ff.ChangeDirectory(drv.Item("carpeta_recibir").ToString)
                ' ff.ChangeDirectory("Download")
                ff.SetBinaryMode(True)



                archivos = ff.GetFileList("*.txt")
                If archivos.Length > 0 Then  ''Verifico que Exista el Archivo .txt
                    For Each archivo In archivos
                        If archivo.Length > 0 Then
                            'Dim sfecha As String = archivo.Split("_")(1)
                            'Dim dfecha_sincronizacion As DateTime _
                            '    = DateTime.Parse(sfecha.Substring(6, 2) & "-" & sfecha.Substring(8, 2) & "-" & _
                            '    sfecha.Substring(10, 4) & " " & sfecha.Substring(4, 2) & ":" & _
                            '    sfecha.Substring(2, 2) & ":" & sfecha.Substring(0, 2))
                            'Guardar_Sincronizacion(drv.Item("usuario"), dfecha_sincronizacion, dfecha_sincronizacion, 1)


                            ff.DeleteFile(archivos(0).Trim)
                        End If
                    Next



                    archivos = ff.GetFileList("*.xml")
                    For icount = 0 To archivos.Length - 1
                        If archivos(icount).ToLower.IndexOf("xml") > 0 Then
                            If ff.RenameFile(archivos(icount).Trim, "_" & archivos(icount).Trim) Then
                                ff.DownloadFile("_" & archivos(icount).Trim, "c:\Aplicaciones\Umbright Mobile EE\" & "_" & archivos(icount).Trim)

                                ff.DeleteFile("_" & archivos(icount).Trim)

                                ff.ChangeDirectory("..")
                                ff.ChangeDirectory("Backup")
                                '(c) 20170202 No debe subir informacion
                                'ff.UploadFile("c:\Aplicaciones\Umbright Mobile EE\_" & archivos(icount).Trim)

                                ff.ChangeDirectory("..")
                                ff.ChangeDirectory("upload")
                            End If
                        End If
                    Next
                End If ''Existe Archivo .txt
            End If

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener_Pedidos_Umbright_Mobile_Vendedor " & drv.Item("usuario").ToString & "--" & ex.Message)
            ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString)
        Finally
            ff.CloseConnection()
            ff = Nothing
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Guardar_Sincronizacion(ByVal usuario As String, ByVal fechai As DateTime, ByVal fechaf As DateTime, ByVal tipo As Integer, ByVal npedidos As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim ls_sql As String

        Try
            myOtrans.open()
            ls_sql = "call pa_ins_um_mov_sincronizacion ('" & usuario & "','" &
                            fechai.ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                            fechaf.ToString("yyyy-MM-dd HH:mm:ss") & "'," & tipo & "," & npedidos & ")"
            myOtrans.Ingresa(ls_sql)

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try


    End Sub


    Private Sub Generar_Pedidos_Umbright_Mobile()
        Dim oSinc As New Sincronizacion.Recepcion_Informacion_PDA


        Try
            '(c) 20240828 se ejecuta en otro proceso, para que se genere en paralelo

            'oSinc.Procesar_Pedidos_Umbright_Mobile_PowerStreet() 

            oSinc.revision_facturacion_autoconsumo()
            oSinc.Procesar_Pedidos_Umbright_Mobile_Gestion()
            oSinc.Procesar_Pedidos_Umbright_Mobile_Azzure()
            oSinc.Procesar_Pedidos_Umbright_Mobile_Cavas()
            oSinc.Procesar_Solicitud_Consignaciones_Azzure()
            'oSinc.Procesar_Conteo_Consignaciones_Azzure()


            '(c) 20240827 Conteo de Consignaciones



        Catch ex As Exception

        Finally
            oSinc = Nothing
        End Try



    End Sub


    Private Sub Procesar_Pedidos_Web(ByVal _tipo As String)
        Dim archivos As String()
        Dim archivo, Ruta_Archivos As String
        Dim ClsGen As New ClasesGenerales.General
        Dim eliminar_archivo As Boolean = True

        Try
            Ruta_Archivos = "c:\Aplicaciones\" & _tipo
            archivos = Directory.GetFiles(Ruta_Archivos, "*.xml")
            If archivos.Length > 0 Then
                For Each archivo In archivos
                    If _tipo.ToLower = "web" Then
                        eliminar_archivo = Procesar_Archivo_Web(archivo)
                    ElseIf _tipo.ToLower = "umbright mobile ee" Then ''Enterprise Edition PDA
                        eliminar_archivo = Procesar_Archivo_Umbright_Mobile_EE(archivo)
                    End If
                    If eliminar_archivo Then
                        ClsGen.Mover_Archivo(archivo, "c:\aplicaciones\" & _tipo & "\log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))
                    End If

                Next
            End If

        Catch ex As Exception
            ClsGen.Escribir_Log("Procesar_Pedidos_Web " & ex.Message)
        Finally
            ClsGen = Nothing
        End Try

    End Sub

    Private Function Procesar_Archivo_Web(ByVal nombre_archivo) As Boolean

        Dim ods As New DataSet
        Dim proceso_exitoso As Boolean = False
        Dim dr As DataRow

        Try
            ods.ReadXml(nombre_archivo)
            proceso_exitoso = Llenar_Estructura_Temporal_Web(ods)

            If ods.Tables.Contains("pedidos_encabezado") Then
                For Each dr In ods.Tables("pedidos_encabezado").Rows
                    proceso_exitoso = Hacer_Pedido_Clase_Web(ods, dr.Item("numero_pedido"), dr, "", "")
                Next
            End If


        Catch ex As Exception
        End Try

        Return proceso_exitoso
    End Function

    Private Function Procesar_Archivo_Umbright_Mobile_EE(ByVal nombre_archivo) As Boolean

        Dim ods As New DataSet
        Dim dr As DataRow
        Dim proceso_exitoso As Boolean = False
        Dim icount, icount2, iCount3, iCount4 As Integer
        Dim dFecha_Creacion_Archivo As DateTime
        Dim dfecha_creacion_sincronizacion As DateTime

        Try
            Dim Archivo As New FileInfo(nombre_archivo)
            dFecha_Creacion_Archivo = Archivo.CreationTime

            ''Cuando el usuario trata de hacer la sincronizacion
            ''el archivo genera informacion p.e._ 55 05 11 09 06 2010 seg,min,hour,dia,mes,año
            ''Esto significa q podriamos tener la fecha de creacion del archivo y la fecha de proceso
            Dim sfecha As String = nombre_archivo.ToString.Split("_")(2).Split(".")(0)
            If sfecha.Length = 14 Then
                '                dfecha_creacion_sincronizacion = DateTime.Parse(sfecha.Substring(7, 2) & "-" & sfecha.Substring(9, 2) & "-" & sfecha.Substring(11, 4))
                dfecha_creacion_sincronizacion = DateTime.Parse(sfecha.Substring(6, 2) & "-" & sfecha.Substring(8, 2) & "-" &
                                                sfecha.Substring(10, 4) & " " & sfecha.Substring(4, 2) & ":" &
                                                sfecha.Substring(2, 2) & ":" & sfecha.Substring(0, 2))
            Else
                Try
                    dfecha_creacion_sincronizacion = DateTime.Parse(sfecha.ToString.PadLeft(4))
                Catch ex As Exception

                End Try

            End If



            ods.ReadXml(nombre_archivo)
            If ods.Tables.Contains("pedidos_encabezado") Then
                'Dim dfecha_sincronizacion As DateTime _
                '    = DateTime.Parse(sfecha.Substring(6, 2) & "-" & sfecha.Substring(8, 2) & "-" & _
                '    sfecha.Substring(10, 4) & " " & sfecha.Substring(4, 2) & ":" & _
                '    sfecha.Substring(2, 2) & ":" & sfecha.Substring(0, 2))
                Guardar_Sincronizacion(ods.Tables("pedidos_encabezado").Rows(0).Item("usuario_grabo"), dfecha_creacion_sincronizacion, dfecha_creacion_sincronizacion, 1, ods.Tables("pedidos_encabezado").Rows.Count)
                For Each dr In ods.Tables("pedidos_encabezado").Rows
                    icount += 1
                    If Subir_Pedido_Temporal(ods, dr.Item("numero_pedido"), dr, dFecha_Creacion_Archivo) Then
                        icount2 += 1
                    End If
                Next
            End If

            If ods.Tables.Contains("consignaciones_conteos_encabezado") Then
                Guardar_Sincronizacion(ods.Tables("consignaciones_conteos_encabezado").Rows(0).Item("usuario_grabo"), dfecha_creacion_sincronizacion, dfecha_creacion_sincronizacion, 1, ods.Tables("consignaciones_conteos_encabezado").Rows.Count)

                For Each dr In ods.Tables("consignaciones_conteos_encabezado").Rows
                    iCount3 += 1
                    If Procesar_Conteos_Consignaciones(dr, ods.Tables("consignaciones_conteos")) Then
                        iCount4 += 1
                    End If
                Next

            End If

            If ods.Tables.Contains("gen_log_actividades") Then
                For Each dr In ods.Tables("gen_log_actividades").Rows
                    If Procesar_Log_Actividades(dr, ods.Tables("cli_noventa")) Then
                    End If
                Next
            End If


            If ods.Tables.Contains("inventario_cliente") Then
                If Procesar_Inventario_Cliente(ods.Tables("inventario_cliente")) Then
                End If
            End If

            If icount = icount2 And iCount3 = iCount4 Then proceso_exitoso = True


        Catch ex As Exception
        End Try

        Return proceso_exitoso
    End Function

    Private Function Subir_MarcacionNoEntregas_Transportes(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr, dr2, dr3, dr4, dr5 As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDatos(), lsDetalle1(), lsDetalle2(), lsDetalle3(), lsDetalle4() As String
        Dim huboerror As Boolean

        Try
            huboerror = False
            myOtrans.open()


            Try
                ods.Tables("noentregas").Clear()
            Catch ex As Exception

            End Try

            ods.ReadXml(psarchivoXML)

            Try
                dr = ods.Tables("noentregas").Rows(0)
                lsDetalle1 = dr.Item("detalle1").ToString.Split("$") ' & dr3.Item("detalle").ToString.Split("|") & dr4.Item("detalle").ToString.Split("|") & dr5.Item("detalle").ToString.Split("|")
                lsDetalle2 = dr.Item("detalle2").ToString.Split("$")
                lsDetalle3 = dr.Item("detalle3").ToString.Split("$")
                lsDetalle4 = dr4.Item("detalle4").ToString.Split("$")

            Catch ex As Exception
            End Try

            Dim copcion As String = ""
            For i As Integer = 0 To lsDetalle1.Length - 1
                If lsDetalle1(i).Length > 0 Then
                    lsSQL = "call pa_ins_um_mov_marcacion_noentrega_transporte ('" &
                                            lsDetalle1(i).Split("|")(0) & "','" & lsDetalle1(i).Split("|")(1) & "','" &
                                            lsDetalle1(i).Split("|")(2) & "','" &
                                            lsDetalle1(i).Split("|")(3) & "','" &
                                            lsDetalle1(i).Split("|")(4) & "','" &
                                            lsDetalle1(i).Split("|")(5) & "','" &
                                            lsDetalle1(i).Split("|")(6) & "','" &
                                            lsDetalle1(i).Split("|")(7) & "','" &
                                            lsDetalle1(i).Split("|")(8) & "')"
                    myOtrans.Ingresa(lsSQL)
                End If
            Next

            If Not huboerror Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Function

    Private Function Subir_MarcacionEntradaSalida_Transportes_marcacion(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr, dr2, dr3, dr4, dr5 As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDatos(), lsDetalle1(), lsDetalle2(), lsDetalle3(), lsDetalle4() As String
        Dim huboerror As Boolean

        Try
            huboerror = False
            myOtrans.open()


            Try
                ods.Tables("entradasalida").Clear()
            Catch ex As Exception

            End Try

            ods.ReadXml(psarchivoXML)

            Try
                dr = ods.Tables("marcacion").Rows(0)
            Catch ex As Exception

            End Try
            Try


                lsDetalle1 = dr.Item("detalle1").ToString.Split("$") ' & dr3.Item("detalle").ToString.Split("|") & dr4.Item("detalle").ToString.Split("|") & dr5.Item("detalle").ToString.Split("|")
                lsDetalle2 = dr.Item("detalle2").ToString.Split("$")
                lsDetalle3 = dr.Item("detalle3").ToString.Split("$")
                lsDetalle4 = dr.Item("detalle4").ToString.Split("$")

            Catch ex As Exception
            End Try

            Dim copcion As String = ""
            For i As Integer = 0 To lsDetalle1.Length - 1
                If lsDetalle1(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle1(i).Split("|")(0) & "','" & lsDetalle1(i).Split("|")(1) & "','" &
                                            lsDetalle1(i).Split("|")(2) & "','" &
                                            lsDetalle1(i).Split("|")(3) & "','" &
                                            lsDetalle1(i).Split("|")(4) & "','" &
                                            lsDetalle1(i).Split("|")(5) & "','" &
                                            lsDetalle1(i).Split("|")(6) & "','" &
                                            lsDetalle1(i).Split("|")(7) & "'," &
                                            lsDetalle1(i).Split("|")(8) & "," &
                                            lsDetalle1(i).Split("|")(9) & ",'" &
                                            lsDetalle1(i).Split("|")(10) & "','" &
                                            lsDetalle1(i).Split("|")(11) & "','" &
                                            lsDetalle1(i).Split("|")(12) & "','" &
                                           lsDetalle1(i).Split("|")(13).ToString &
                                            lsDetalle1(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle1(i).Split("|")(0) & "','" & lsDetalle1(i).Split("|")(1) & "','" &
                                                                    lsDetalle1(i).Split("|")(2) & "','" &
                                                                    lsDetalle1(i).Split("|")(3) & "','" &
                                                                    lsDetalle1(i).Split("|")(4) & "','" &
                                                                    lsDetalle1(i).Split("|")(5) & "','" &
                                                                    lsDetalle1(i).Split("|")(6) & "','" &
                                                                    lsDetalle1(i).Split("|")(7) & "'," &
                                                                    lsDetalle1(i).Split("|")(8) & "," &
                                                                    lsDetalle1(i).Split("|")(9) & ",'" &
                                                                    lsDetalle1(i).Split("|")(10) & "','" &
                                                                    lsDetalle1(i).Split("|")(11) & "','" &
                                                                    lsDetalle1(i).Split("|")(12) & "','" &
                                                                    lsDetalle1(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next

            copcion = String.Empty
            For i As Integer = 0 To lsDetalle2.Length - 1
                If lsDetalle2(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle2(i).Split("|")(0) & "','" & lsDetalle2(i).Split("|")(1) & "','" &
                                            lsDetalle2(i).Split("|")(2) & "','" &
                                            lsDetalle2(i).Split("|")(3) & "','" &
                                            lsDetalle2(i).Split("|")(4) & "','" &
                                            lsDetalle2(i).Split("|")(5) & "','" &
                                            lsDetalle2(i).Split("|")(6) & "','" &
                                            lsDetalle2(i).Split("|")(7) & "'," &
                                            lsDetalle2(i).Split("|")(8) & "," &
                                            lsDetalle2(i).Split("|")(9) & ",'" &
                                            lsDetalle2(i).Split("|")(10) & "','" &
                                            lsDetalle2(i).Split("|")(11) & "','" &
                                            lsDetalle2(i).Split("|")(12) & "','" &
                                           lsDetalle2(i).Split("|")(13).ToString &
                                            lsDetalle2(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle2(i).Split("|")(0) & "','" & lsDetalle2(i).Split("|")(1) & "','" &
                                                                    lsDetalle2(i).Split("|")(2) & "','" &
                                                                    lsDetalle2(i).Split("|")(3) & "','" &
                                                                    lsDetalle2(i).Split("|")(4) & "','" &
                                                                    lsDetalle2(i).Split("|")(5) & "','" &
                                                                    lsDetalle2(i).Split("|")(6) & "','" &
                                                                    lsDetalle2(i).Split("|")(7) & "'," &
                                                                    lsDetalle2(i).Split("|")(8) & "," &
                                                                    lsDetalle2(i).Split("|")(9) & ",'" &
                                                                    lsDetalle2(i).Split("|")(10) & "','" &
                                                                    lsDetalle2(i).Split("|")(11) & "','" &
                                                                    lsDetalle2(i).Split("|")(12) & "','" &
                                                                    lsDetalle2(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next


            copcion = String.Empty
            For i As Integer = 0 To lsDetalle3.Length - 1
                If lsDetalle3(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle3(i).Split("|")(0) & "','" & lsDetalle3(i).Split("|")(1) & "','" &
                                            lsDetalle3(i).Split("|")(2) & "','" &
                                            lsDetalle3(i).Split("|")(3) & "','" &
                                            lsDetalle3(i).Split("|")(4) & "','" &
                                            lsDetalle3(i).Split("|")(5) & "','" &
                                            lsDetalle3(i).Split("|")(6) & "','" &
                                            lsDetalle3(i).Split("|")(7) & "'," &
                                            lsDetalle3(i).Split("|")(8) & "," &
                                            lsDetalle3(i).Split("|")(9) & ",'" &
                                            lsDetalle3(i).Split("|")(10) & "','" &
                                            lsDetalle3(i).Split("|")(11) & "','" &
                                            lsDetalle3(i).Split("|")(12) & "','" &
                                           lsDetalle3(i).Split("|")(13).ToString &
                                            lsDetalle3(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle3(i).Split("|")(0) & "','" & lsDetalle3(i).Split("|")(1) & "','" &
                                                                    lsDetalle3(i).Split("|")(2) & "','" &
                                                                    lsDetalle3(i).Split("|")(3) & "','" &
                                                                    lsDetalle3(i).Split("|")(4) & "','" &
                                                                    lsDetalle3(i).Split("|")(5) & "','" &
                                                                    lsDetalle3(i).Split("|")(6) & "','" &
                                                                    lsDetalle3(i).Split("|")(7) & "'," &
                                                                    lsDetalle3(i).Split("|")(8) & "," &
                                                                    lsDetalle3(i).Split("|")(9) & ",'" &
                                                                    lsDetalle3(i).Split("|")(10) & "','" &
                                                                    lsDetalle3(i).Split("|")(11) & "','" &
                                                                    lsDetalle3(i).Split("|")(12) & "','" &
                                                                    lsDetalle3(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next


            copcion = String.Empty
            For i As Integer = 0 To lsDetalle4.Length - 1
                If lsDetalle4(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle4(i).Split("|")(0) & "','" & lsDetalle4(i).Split("|")(1) & "','" &
                                            lsDetalle4(i).Split("|")(2) & "','" &
                                            lsDetalle4(i).Split("|")(3) & "','" &
                                            lsDetalle4(i).Split("|")(4) & "','" &
                                            lsDetalle4(i).Split("|")(5) & "','" &
                                            lsDetalle4(i).Split("|")(6) & "','" &
                                            lsDetalle4(i).Split("|")(7) & "'," &
                                            lsDetalle4(i).Split("|")(8) & "," &
                                            lsDetalle4(i).Split("|")(9) & ",'" &
                                            lsDetalle4(i).Split("|")(10) & "','" &
                                            lsDetalle4(i).Split("|")(11) & "','" &
                                            lsDetalle4(i).Split("|")(12) & "','" &
                                           lsDetalle4(i).Split("|")(13).ToString &
                                            lsDetalle4(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle4(i).Split("|")(0) & "','" & lsDetalle4(i).Split("|")(1) & "','" &
                                                                    lsDetalle4(i).Split("|")(2) & "','" &
                                                                    lsDetalle4(i).Split("|")(3) & "','" &
                                                                    lsDetalle4(i).Split("|")(4) & "','" &
                                                                    lsDetalle4(i).Split("|")(5) & "','" &
                                                                    lsDetalle4(i).Split("|")(6) & "','" &
                                                                    lsDetalle4(i).Split("|")(7) & "'," &
                                                                    lsDetalle4(i).Split("|")(8) & "," &
                                                                    lsDetalle4(i).Split("|")(9) & ",'" &
                                                                    lsDetalle4(i).Split("|")(10) & "','" &
                                                                    lsDetalle4(i).Split("|")(11) & "','" &
                                                                    lsDetalle4(i).Split("|")(12) & "','" &
                                                                    lsDetalle4(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next

            If Not huboerror Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\Log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Function



    Private Function Subir_MarcacionEntradaSalida_Transportes(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr, dr2, dr3, dr4, dr5 As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDatos(), lsDetalle1(), lsDetalle2(), lsDetalle3(), lsDetalle4() As String
        Dim huboerror As Boolean

        Try
            huboerror = False
            myOtrans.open()


            Try
                ods.Tables("entradasalida").Clear()
            Catch ex As Exception

            End Try

            ods.ReadXml(psarchivoXML)

            Try
                dr = ods.Tables("entradasalida").Rows(0)
            Catch ex As Exception

            End Try
            Try


                lsDetalle1 = dr.Item("detalle1").ToString.Split("$") ' & dr3.Item("detalle").ToString.Split("|") & dr4.Item("detalle").ToString.Split("|") & dr5.Item("detalle").ToString.Split("|")
                lsDetalle2 = dr.Item("detalle2").ToString.Split("$")
                lsDetalle3 = dr.Item("detalle3").ToString.Split("$")
                lsDetalle4 = dr.Item("detalle4").ToString.Split("$")

            Catch ex As Exception
            End Try

            Dim copcion As String = ""
            For i As Integer = 0 To lsDetalle1.Length - 1
                If lsDetalle1(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle1(i).Split("|")(0) & "','" & lsDetalle1(i).Split("|")(1) & "','" &
                                            lsDetalle1(i).Split("|")(2) & "','" &
                                            lsDetalle1(i).Split("|")(3) & "','" &
                                            lsDetalle1(i).Split("|")(4) & "','" &
                                            lsDetalle1(i).Split("|")(5) & "','" &
                                            lsDetalle1(i).Split("|")(6) & "','" &
                                            lsDetalle1(i).Split("|")(7) & "'," &
                                            lsDetalle1(i).Split("|")(8) & "," &
                                            lsDetalle1(i).Split("|")(9) & ",'" &
                                            lsDetalle1(i).Split("|")(10) & "','" &
                                            lsDetalle1(i).Split("|")(11) & "','" &
                                            lsDetalle1(i).Split("|")(12) & "','" &
                                           lsDetalle1(i).Split("|")(13).ToString &
                                            lsDetalle1(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle1(i).Split("|")(0) & "','" & lsDetalle1(i).Split("|")(1) & "','" &
                                                                    lsDetalle1(i).Split("|")(2) & "','" &
                                                                    lsDetalle1(i).Split("|")(3) & "','" &
                                                                    lsDetalle1(i).Split("|")(4) & "','" &
                                                                    lsDetalle1(i).Split("|")(5) & "','" &
                                                                    lsDetalle1(i).Split("|")(6) & "','" &
                                                                    lsDetalle1(i).Split("|")(7) & "'," &
                                                                    lsDetalle1(i).Split("|")(8) & "," &
                                                                    lsDetalle1(i).Split("|")(9) & ",'" &
                                                                    lsDetalle1(i).Split("|")(10) & "','" &
                                                                    lsDetalle1(i).Split("|")(11) & "','" &
                                                                    lsDetalle1(i).Split("|")(12) & "','" &
                                                                    lsDetalle1(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next

            copcion = String.Empty
            For i As Integer = 0 To lsDetalle2.Length - 1
                If lsDetalle2(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle2(i).Split("|")(0) & "','" & lsDetalle2(i).Split("|")(1) & "','" &
                                            lsDetalle2(i).Split("|")(2) & "','" &
                                            lsDetalle2(i).Split("|")(3) & "','" &
                                            lsDetalle2(i).Split("|")(4) & "','" &
                                            lsDetalle2(i).Split("|")(5) & "','" &
                                            lsDetalle2(i).Split("|")(6) & "','" &
                                            lsDetalle2(i).Split("|")(7) & "'," &
                                            lsDetalle2(i).Split("|")(8) & "," &
                                            lsDetalle2(i).Split("|")(9) & ",'" &
                                            lsDetalle2(i).Split("|")(10) & "','" &
                                            lsDetalle2(i).Split("|")(11) & "','" &
                                            lsDetalle2(i).Split("|")(12) & "','" &
                                           lsDetalle2(i).Split("|")(13).ToString &
                                            lsDetalle2(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle2(i).Split("|")(0) & "','" & lsDetalle2(i).Split("|")(1) & "','" &
                                                                    lsDetalle2(i).Split("|")(2) & "','" &
                                                                    lsDetalle2(i).Split("|")(3) & "','" &
                                                                    lsDetalle2(i).Split("|")(4) & "','" &
                                                                    lsDetalle2(i).Split("|")(5) & "','" &
                                                                    lsDetalle2(i).Split("|")(6) & "','" &
                                                                    lsDetalle2(i).Split("|")(7) & "'," &
                                                                    lsDetalle2(i).Split("|")(8) & "," &
                                                                    lsDetalle2(i).Split("|")(9) & ",'" &
                                                                    lsDetalle2(i).Split("|")(10) & "','" &
                                                                    lsDetalle2(i).Split("|")(11) & "','" &
                                                                    lsDetalle2(i).Split("|")(12) & "','" &
                                                                    lsDetalle2(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next


            copcion = String.Empty
            For i As Integer = 0 To lsDetalle3.Length - 1
                If lsDetalle3(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle3(i).Split("|")(0) & "','" & lsDetalle3(i).Split("|")(1) & "','" &
                                            lsDetalle3(i).Split("|")(2) & "','" &
                                            lsDetalle3(i).Split("|")(3) & "','" &
                                            lsDetalle3(i).Split("|")(4) & "','" &
                                            lsDetalle3(i).Split("|")(5) & "','" &
                                            lsDetalle3(i).Split("|")(6) & "','" &
                                            lsDetalle3(i).Split("|")(7) & "'," &
                                            lsDetalle3(i).Split("|")(8) & "," &
                                            lsDetalle3(i).Split("|")(9) & ",'" &
                                            lsDetalle3(i).Split("|")(10) & "','" &
                                            lsDetalle3(i).Split("|")(11) & "','" &
                                            lsDetalle3(i).Split("|")(12) & "','" &
                                           lsDetalle3(i).Split("|")(13).ToString &
                                            lsDetalle3(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle3(i).Split("|")(0) & "','" & lsDetalle3(i).Split("|")(1) & "','" &
                                                                    lsDetalle3(i).Split("|")(2) & "','" &
                                                                    lsDetalle3(i).Split("|")(3) & "','" &
                                                                    lsDetalle3(i).Split("|")(4) & "','" &
                                                                    lsDetalle3(i).Split("|")(5) & "','" &
                                                                    lsDetalle3(i).Split("|")(6) & "','" &
                                                                    lsDetalle3(i).Split("|")(7) & "'," &
                                                                    lsDetalle3(i).Split("|")(8) & "," &
                                                                    lsDetalle3(i).Split("|")(9) & ",'" &
                                                                    lsDetalle3(i).Split("|")(10) & "','" &
                                                                    lsDetalle3(i).Split("|")(11) & "','" &
                                                                    lsDetalle3(i).Split("|")(12) & "','" &
                                                                    lsDetalle3(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next


            copcion = String.Empty
            For i As Integer = 0 To lsDetalle4.Length - 1
                If lsDetalle4(i).Length > 0 Then
                    Try
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                            lsDetalle4(i).Split("|")(0) & "','" & lsDetalle4(i).Split("|")(1) & "','" &
                                            lsDetalle4(i).Split("|")(2) & "','" &
                                            lsDetalle4(i).Split("|")(3) & "','" &
                                            lsDetalle4(i).Split("|")(4) & "','" &
                                            lsDetalle4(i).Split("|")(5) & "','" &
                                            lsDetalle4(i).Split("|")(6) & "','" &
                                            lsDetalle4(i).Split("|")(7) & "'," &
                                            lsDetalle4(i).Split("|")(8) & "," &
                                            lsDetalle4(i).Split("|")(9) & ",'" &
                                            lsDetalle4(i).Split("|")(10) & "','" &
                                            lsDetalle4(i).Split("|")(11) & "','" &
                                            lsDetalle4(i).Split("|")(12) & "','" &
                                           lsDetalle4(i).Split("|")(13).ToString &
                                            lsDetalle4(i).Split("|")(14) & "')"
                    Catch ex As Exception
                        lsSQL = "call pa_ins_um_mov_marcacion_entradasalida_transporte ('" &
                                                                    lsDetalle4(i).Split("|")(0) & "','" & lsDetalle4(i).Split("|")(1) & "','" &
                                                                    lsDetalle4(i).Split("|")(2) & "','" &
                                                                    lsDetalle4(i).Split("|")(3) & "','" &
                                                                    lsDetalle4(i).Split("|")(4) & "','" &
                                                                    lsDetalle4(i).Split("|")(5) & "','" &
                                                                    lsDetalle4(i).Split("|")(6) & "','" &
                                                                    lsDetalle4(i).Split("|")(7) & "'," &
                                                                    lsDetalle4(i).Split("|")(8) & "," &
                                                                    lsDetalle4(i).Split("|")(9) & ",'" &
                                                                    lsDetalle4(i).Split("|")(10) & "','" &
                                                                    lsDetalle4(i).Split("|")(11) & "','" &
                                                                    lsDetalle4(i).Split("|")(12) & "','" &
                                                                    lsDetalle4(i).Split("|")(13) & "')"
                    End Try

                    myOtrans.Ingresa(lsSQL)
                End If
            Next

            If Not huboerror Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\Log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Function

    Private Function Procesar_Archivo_Umbright_Mobile_SE() As Boolean

        Dim ods As New DataSet

        Dim proceso_exitoso As Boolean = False
        Dim Ruta_Archivos As String
        Dim ArchivosXML() As String
        Dim archivoXML As String
        Dim ClsGen As New ClasesGenerales.General


        Try
            Ruta_Archivos = "c:\Aplicaciones\Umbright Mobile SE\Receive\"

            ArchivosXML = Directory.GetFiles(Ruta_Archivos, "*.xml")
            ArchivosXML.Reverse(ArchivosXML)

            For Each archivoXML In ArchivosXML
                If archivoXML.ToLower.IndexOf("inventario") > -1 Then
                    'ClsGen.Escribir_Log("inventario")
                    'Subir_Inventario_Temporal_Celular(archivoXML) '(c) 10072014 No se utilizara mas
                ElseIf archivoXML.ToLower.IndexOf("noventa") > -1 Then
                    Subir_NoVenta_Temporal_Celular(archivoXML)
                ElseIf archivoXML.ToLower.IndexOf("encuesta") > -1 Then
                    If Not Subir_Encuesta_Temporal_Celular(archivoXML) Then
                        Subir_Encuesta_Temporal_CelularNube(archivoXML)
                    End If
                ElseIf archivoXML.ToLower.IndexOf("pedido_tekne") > -1 Then
                    'ClsGen.Escribir_Log("pedido_tekne")
                    Subir_Pedido_Temporal_Tekne(archivoXML)
                ElseIf archivoXML.ToLower.IndexOf("consignacion") > -1 Then
                    'ClsGen.Escribir_Log("consignacion")
                    'Me.Procesar_ConsignacionesTekne_old(archivoXML) 'Debe Almacenar la Informacion en vgestion '(c) 201906143
                    Me.Procesar_ConsignacionesTekneGestion(archivoXML)

                ElseIf archivoXML.ToLower.IndexOf("noentregas") > -1 Then 'Merchandising
                    Me.Subir_MarcacionNoEntregas_Transportes(archivoXML)

                ElseIf archivoXML.ToLower.IndexOf("entradasalida") > -1 Then 'Entradas/Salidas Transportes
                    Me.Subir_MarcacionEntradaSalida_Transportes(archivoXML)

                ElseIf archivoXML.ToLower.IndexOf("marcacion") > -1 Then
                    'ClsGen.Escribir_Log("Marcacion")
                    Me.Subir_MarcacionEntradaSalida_Transportes_marcacion(archivoXML)
                    Subir_MarcacionGps_Tiendas(archivoXML)
                ElseIf archivoXML.ToLower.IndexOf("dia") > -1 Then
                    'ClsGen.Escribir_Log("procesar dia")
                    Subir_Dia_MarcacionGps(archivoXML)
                ElseIf archivoXML.ToLower.IndexOf("visita") > -1 Then
                    'ClsGen.Escribir_Log("procesar dia")
                    Subir_Visita_Temporal_Celular(archivoXML)
                Else
                    'ClsGen.Escribir_Log("pedido temporal")
                    Subir_Pedido_Temporal_Celular(archivoXML)
                End If
            Next

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try

        Return proceso_exitoso
    End Function

    Private Function Subir_MarcacionGps_Tiendas(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr, dr2, dr3, dr4, dr5 As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDatos(), lsDetalle1(), lsDetalle2(), lsDetalle3(), lsDetalle4() As String
        Dim huboerror As Boolean

        Try
            huboerror = False
            myOtrans.open()


            Try
                ods.Tables("marcacion").Clear()
            Catch ex As Exception

            End Try

            ods.ReadXml(psarchivoXML)

            Try
                dr = ods.Tables("marcacion").Rows(0)
                lsDetalle1 = dr.Item("detalle1").ToString.Split("$") ' & dr3.Item("detalle").ToString.Split("|") & dr4.Item("detalle").ToString.Split("|") & dr5.Item("detalle").ToString.Split("|")
                lsDetalle2 = dr2.Item("detalle2").ToString.Split("$")
                lsDetalle3 = dr3.Item("detalle3").ToString.Split("$")
                lsDetalle4 = dr4.Item("detalle4").ToString.Split("$")

            Catch ex As Exception
            End Try

            Dim copcion As String = ""
            For i As Integer = 0 To lsDetalle1.Length - 1
                If lsDetalle1(i).Length > 0 Then
                    lsSQL = "call pa_ins_um_mov_marcacion_merchandising ('" &
                                            lsDetalle1(i).Split("|")(0) & "','" & lsDetalle1(i).Split("|")(1) & "','" &
                                            lsDetalle1(i).Split("|")(2) & "','" &
                                            lsDetalle1(i).Split("|")(3) & "','" &
                                            lsDetalle1(i).Split("|")(4) & "','" &
                                            lsDetalle1(i).Split("|")(5) & "','" &
                                            lsDetalle1(i).Split("|")(6) & "')"
                    myOtrans.Ingresa(lsSQL)
                End If
            Next

            If Not huboerror Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Function

    Private Function Subir_Dia_MarcacionGps(ByVal psarchivoXML As String)


        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDetalle1(), lsDetalle2(), lsDetalle4() As String
        Dim huboerror As Boolean
        Dim latitud As String = ""
        Dim longitud As String = ""
        Dim fecha As String = ""
        Dim usuario As String = ""

        Try
            huboerror = False
            myOtrans.open()

            Try

                Dim objReader As New StreamReader(psarchivoXML)
                Dim sLine As String = ""
                Dim arrText As New ArrayList()

                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        arrText.Add(sLine)
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()



                For Each sLine In arrText
                    Try

                        lsDetalle1 = sLine.ToString.Split(",")
                        lsDetalle2 = lsDetalle1(0).ToString.Split("$")
                        latitud = lsDetalle2(1).ToString.Substring(4)
                        longitud = lsDetalle1(1).ToString.Substring(5)
                        fecha = lsDetalle1(2).ToString.Substring(5).Replace("/", "-")
                        lsDetalle4 = psarchivoXML.ToString.Split("\")
                        lsDetalle4 = lsDetalle4(4).ToString.Split("_")
                        'lsDetalle4 = lsDetalle4(6).ToString.Split("_")
                        ' usuario = lsDetalle4(1).ToString
                        usuario = lsDetalle4(2).ToString


                        If latitud.ToString.Length > 0 Then


                            lsSQL = "call pa_ins_um_mov_marcacion_posicionamiento('" & usuario.ToLower & "','" & fecha & "','" & latitud & "','" & longitud & "','','')"
                            myOtrans.Ingresa(lsSQL)

                        End If
                    Catch ex As Exception
                        ClsGen.Escribir_Log("1. " & ex.ToString)
                        ClsGen.Escribir_Log("1. " & ex.Message)

                    End Try
                Next

            Catch ex As Exception
                ClsGen.Escribir_Log("2. " & ex.ToString)
                ClsGen.Escribir_Log("2. " & ex.Message)
            End Try




            If Not huboerror Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\_" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
            ClsGen.Escribir_Log("3. " & ex.ToString)
            ClsGen.Escribir_Log("3. " & ex.Message)
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return True
    End Function

    Private Function Llenar_Estructura_Temporal_Web(ByRef ods As DataSet) As Boolean
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim icount As Integer = 0


        Try


            If Not ods.Tables.Contains("pedidos_encabezado") Then
                dt = New DataTable("pedidos_encabezado")
                dt.Columns.Add(New DataColumn("empresa", GetType(String)))
                dt.Columns.Add(New DataColumn("numero_pedido", GetType(String)))
                dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
                dt.Columns.Add(New DataColumn("forma_pago", GetType(String)))
                dt.Columns.Add(New DataColumn("total_pedido", GetType(Double)))
                dt.Columns.Add(New DataColumn("total_lineas", GetType(Integer)))
                dt.Columns.Add(New DataColumn("fecha_pedido", GetType(DateTime)))
                dt.Columns.Add(New DataColumn("hora_pedido", GetType(String)))
                dt.Columns.Add(New DataColumn("fecha_entrega", GetType(DateTime)))
                dt.Columns.Add(New DataColumn("comentarios", GetType(String)))
                dt.Columns.Add(New DataColumn("usuario_grabo", GetType(String)))
                dt.Columns.Add(New DataColumn("estado", GetType(Integer)))
                dt.Columns.Add(New DataColumn("listaprecio", GetType(String)))

                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("pedidos_encabezado").Rows.Clear()
            End If

            If Not ods.Tables.Contains("pedidos_detalle") Then
                dt = New DataTable("pedidos_detalle")
                dt.Columns.Add(New DataColumn("numero_pedido", GetType(String)))
                dt.Columns.Add(New DataColumn("linea", GetType(Integer)))
                dt.Columns.Add(New DataColumn("producto", GetType(String)))
                dt.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt.Columns.Add(New DataColumn("precio", GetType(Double)))
                dt.Columns.Add(New DataColumn("total_linea", GetType(Double)))
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("pedidos_detalle").Rows.Clear()
            End If

            For Each dr In ods.Tables("Encabezado").Rows
                dr_aux = ods.Tables("pedidos_encabezado").NewRow
                dr_aux.Item("empresa") = "DMARTE1"
                dr_aux.Item("numero_pedido") = dr.Item("no_pedido").ToString
                dr_aux.Item("ctacte") = dr.Item("cliente").ToString

                If dr.Item("formapago").ToString.ToLower.StartsWith("contado") Then
                    dr_aux.Item("forma_pago") = dr.Item("formapago").ToString
                Else
                    dr_aux.Item("forma_pago") = ""
                End If

                dr_aux.Item("total_pedido") = dr.Item("total_pedido").ToString
                dr_aux.Item("total_lineas") = dr.Item("no_lineas").ToString
                dr_aux.Item("fecha_pedido") = dr.Item("fecha_creacion").ToString
                dr_aux.Item("hora_pedido") = DateTime.Parse(dr.Item("fecha_creacion").ToString).ToString("HH:mm")
                dr_aux.Item("fecha_entrega") = "01/01/1900"
                dr_aux.Item("comentarios") = "Web **Prueba IT ** " & dr.Item("comentarios").ToString & " " & dr.Item("ip").ToString
                dr_aux.Item("usuario_grabo") = "IsfWeb"
                dr_aux.Item("listaprecio") = dr.Item("listaprecios").ToString
                ods.Tables("pedidos_encabezado").Rows.Add(dr_aux)
            Next

            For Each dr In ods.Tables("Detalle").Rows
                icount += 1
                dr_aux = ods.Tables("pedidos_detalle").NewRow
                dr_aux.Item("numero_pedido") = ods.Tables("pedidos_encabezado").Rows(0).Item("numero_pedido").ToString
                dr_aux.Item("linea") = icount
                dr_aux.Item("producto") = dr.Item("cod_producto").ToString
                dr_aux.Item("cantidad") = dr.Item("cantidad").ToString
                dr_aux.Item("precio") = dr.Item("precio").ToString
                dr_aux.Item("total_linea") = dr.Item("total_linea").ToString
                ods.Tables("pedidos_detalle").Rows.Add(dr_aux)
            Next



        Catch ex As Exception
        Finally


        End Try


    End Function

    Private Sub Subir_Visita_Temporal_Celular(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr As DataRow
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim lsDatos() As String

        Try

            ods.ReadXml(psarchivoXML)
            dr = ods.Tables("motivo").Rows(0)
            lsDatos = dr.Item("detalle").ToString.Split("|")



            myOtrans.open()
            ls_sql = "call pa_ins_um_mov_log_visita ('" &
                    lsDatos(0).ToUpper & "','" &
                    lsDatos(1) & "','" &
                    lsDatos(2) & "','" &
                    lsDatos(2) & "',"
            ls_sql += "1,NULL,',"
            ls_sql += lsDatos(7) & "',null,"
            ls_sql += "'" & lsDatos(5) & "',"
            ls_sql += "'" & lsDatos(9).Substring(0, 5)
            ls_sql += "')"







            myOtrans.Ingresa(ls_sql)
            If myOtrans.Codigo_error = 0 Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
    End Sub


    Private Sub Subir_NoVenta_Temporal_Celular(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr As DataRow
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim lsDatos() As String

        Try

            ods.ReadXml(psarchivoXML)
            dr = ods.Tables("motivo").Rows(0)
            lsDatos = dr.Item("detalle").ToString.Split("|")



            myOtrans.open()
            ls_sql = "call pa_ins_um_mov_log_visita ('" &
                    lsDatos(0).ToUpper & "','" &
                    lsDatos(1) & "','" &
                    lsDatos(5) & "','" &
                    lsDatos(5) & "',"
            ls_sql += "2,NULL,'',"
            ls_sql += lsDatos(4) & ","
            ls_sql += "'" & lsDatos(2) & "','')"




            myOtrans.Ingresa(ls_sql)
            If myOtrans.Codigo_error = 0 Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try
    End Sub

    Private Function Subir_Inventario_Temporal_Celular(ByVal archivoXML As String)
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow


        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        '        Dim oSysgold As New Transaccional.Conexion("sysgold")


        Dim oSysgold As New Transaccional.Conexion("Umbright_Movil")



        Dim dtCliente, dtEjecutivos As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim encabezado(), detalle(), linea() As String

        Dim lbExitoso As Boolean = True
        Dim sCodigoEmpresa As String


        Try
            oSysgold.open()
            myOtrans.open()
            Otrans.open()
            ods.ReadXml(archivoXML)
            dr_encabezado = ods.Tables("encabezado").Rows(0)


            With dr_encabezado
                encabezado = .Item("encabezado_pedido").ToString.Split("|")

                dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & encabezado(0) & "','CLIENTE','" & encabezado(2) & "'")


                ls_sql = "pa_sel_um_gen_tabcod NULL,'SYSGOLD_EJECUTIVOS','" & encabezado(0) & "'"
                dtEjecutivos = Otrans.Obtiene(ls_sql)

                dtEjecutivos.DefaultView.RowFilter = "DESCRIPCION = '" & dtCliente.Rows(0).Item("ejecutivo") & "'"

                sCodigoEmpresa = encabezado(0).ToUpper.Substring(0, 3)
                Dim ls_inv_asesor As String = dtEjecutivos.DefaultView(0)("codigo") & sCodigoEmpresa

                For icount As Integer = 1 To 9

                    If .Item("detalle" & icount.ToString).ToString.Length > 0 Then
                        detalle = .Item("detalle" & icount.ToString).ToString.Split(":")
                    Else
                        detalle = Nothing
                    End If

                    If Not detalle Is Nothing Then
                        For Each lineas As String In detalle
                            linea = lineas.Split("|")
                            If linea.Length > 1 Then
                                ls_sql = "pa_ins_um_cliinven '" & linea(0) & sCodigoEmpresa & "','" &
                                                ls_inv_asesor & "','" & linea(1) & sCodigoEmpresa & "'," &
                                                linea(2).ToString()

                                oSysgold.Ingresa(ls_sql)
                                If oSysgold.Codigo_error > 0 Then
                                    lbExitoso = False
                                End If
                                ls_sql = "call pa_ins_um_mov_inventario_cliente ('" & encabezado(0) & "','" &
                                            encabezado(2) & "','" & linea(1) & "'," & linea(2) & ",'" & encabezado(1) & "')"
                                myOtrans.Ingresa(ls_sql)

                            End If
                        Next
                    End If
                Next

            End With
            If lbExitoso Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
            End If


        Catch ex As Exception
        Finally
            oFlex.close()
            oFlex = Nothing
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            oSysgold.close()
            oSysgold = Nothing
            ClsGen = Nothing
        End Try
        Return lbExitoso
    End Function

    Private Function subirPedidoCanastas()
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt, dtEmpresa, dtOrden As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dFecha_Creacion_Archivo As DateTime
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim CodigoCliente As Integer
        Dim encabezado(), detalle(), linea() As String
        Dim precio_unitario As Double
        Dim lbExitoso As Boolean = True


        Try
            myOtrans.open()
            Otrans.open()
            dtOrden = myOtrans.Obtiene("Select * from maq_orden where estado = 1")
            dtEmpresa = ClsGen.ValoresDistinto(dtOrden, "empresa_vende,cod_cliente_compra,numero_traslado".Split(","))

            For Each dr As DataRow In dtEmpresa.Rows
                Dim bencabezado As Boolean = True
                numero_pedido = -1
                Dim nlinea As Integer = 0
                dtOrden.DefaultView.RowFilter = "empresa_vende='" & dr.Item("empresa_vende").ToString & "' and cod_cliente_compra='" & dr.Item("cod_cliente_compra").ToString & "' and numero_traslado = " & dr.Item("numero_traslado")

                For Each drv As DataRowView In dtOrden.DefaultView
                    If bencabezado Then
                        dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & drv.Item("empresa_vende").ToString & "','CLIENTE','" & drv.Item("cod_cliente_compra").ToString & "'")
                        CodigoCliente = dr.Item("cod_cliente_compra").ToString

                        ls_sql = "call pa_ins_um_mov_pedidos_encabezado ('" &
                                 drv.Item("empresa_vende").ToString.ToUpper & "','" & drv.Item("numero_traslado").ToString & "','" &
                                 drv.Item("cod_cliente_compra").ToString & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                                  "0,0,'" &
                                  Now.ToString("yyyy-MM-dd HH:mm") & "','" &
                                  Now.ToString("yyyy-MM-dd") & "','"

                        ls_sql += "1900-01-01','"

                        ls_sql += drv.Item("comentarios").ToString & "','" &
                                "ADMIN" & "',1,'" &
                                dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                                Now.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL)"

                        myOtrans.Ingresa(ls_sql)

                        If myOtrans.Codigo_error = 0 Then
                            dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                            numero_pedido = dt.Rows(0).Item("newid").ToString
                            bencabezado = False
                        End If
                    End If

                    If numero_pedido > 0 Then

                        nlinea += 1
                        dt = oFlex.Obtener_Precio_Final(drv.Item("empresa_vende").ToString.ToUpper, drv.Item("producto").ToString, CodigoCliente)
                        Try
                            precio_unitario = dt.Rows(0).Item("valor")
                        Catch ex As Exception
                            precio_unitario = 0
                        End Try

                        ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," &
                                          nlinea & ",'" & drv.Item("producto").ToString & "'," &
                                          drv.Item("cantidad").ToString & "," & precio_unitario & "," &
                                          precio_unitario * drv.Item("cantidad") & ")"

                        myOtrans.Ingresa(ls_sql)
                        If myOtrans.Codigo_error > 0 Then
                            lbExitoso = False
                        End If


                    End If

                Next
                If numero_pedido > 0 Then
                    ls_sql = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
                    myOtrans.Actualiza(ls_sql)
                    ls_sql = "call pa_upd_maq_orden (" & dr.Item("empresa_vende").ToString & "','" &
                         dr.Item("cod_cliente_compra").ToString & "'," & dr.Item("numero_traslado") & ")"



                    'ls_sql = "Update maq_orden  set estado = 2 where empresa_vende='" & _
                    '     dr.Item("empresa_vende").ToString & "' and cod_cliente_compra='" & _
                    '     dr.Item("cod_cliente_compra").ToString & "' and numero_traslado = " & dr.Item("numero_traslado")
                    myOtrans.Actualiza(ls_sql)
                End If

            Next

            'ods.ReadXml(archivoXML)


        Catch ex As Exception
        Finally
            oFlex.close()
            oFlex = Nothing
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
        Return lbExitoso
    End Function


    Private Function Subir_Pedido_Temporal_Celular(ByVal archivoXML As String)
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dFecha_Creacion_Archivo As DateTime
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim CodigoCliente As Integer
        Dim encabezado(), detalle(), linea() As String
        Dim precio_unitario As Double
        Dim lbExitoso As Boolean = True


        Try
            myOtrans.open()
            Otrans.open()
            ods.ReadXml(archivoXML)
            dr_encabezado = ods.Tables("encabezado").Rows(0)




            Dim Archivo As New FileInfo(archivoXML)
            dFecha_Creacion_Archivo = Archivo.CreationTime


            With dr_encabezado

                encabezado = .Item("encabezado_pedido").ToString.Split("|")


                dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & encabezado(2) & "','CLIENTE','" & encabezado(1) & "'")
                CodigoCliente = encabezado(1)

                Guardar_Sincronizacion(encabezado(3), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), 1, 1)

                ''Guardar 
                ls_sql = "call pa_ins_um_mov_pedidos_encabezado ('" &
                         encabezado(2).ToString.ToUpper & "','" & encabezado(0).ToString & "','" &
                         encabezado(1).ToString & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                         "0,0,'" &
                        DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm") & "','" &
                        DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd") & "','"

                ls_sql += "1900-01-01','"

                ls_sql += "Cell " & encabezado(4).Replace("ENT", " Entregar ").Replace("OC", "Orden de Compra ") & "','" &
                        encabezado(3).ToString & "',1,'" &
                        dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                        dFecha_Creacion_Archivo.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL)"


                myOtrans.Ingresa(ls_sql)

                If myOtrans.Codigo_error = 0 Then
                    dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString
                    For icount As Integer = 1 To 8

                        If .Item("detalle" & icount.ToString).ToString.Length > 0 Then
                            detalle = .Item("detalle" & icount.ToString).ToString.Split(":")
                        Else
                            detalle = Nothing
                        End If


                        If Not detalle Is Nothing Then


                            For Each lineas As String In detalle
                                linea = lineas.Split("|")
                                If linea.Length > 1 Then
                                    dt = oFlex.Obtener_Precio_Final(linea(4), linea(1), CodigoCliente)
                                    Try
                                        precio_unitario = dt.Rows(0).Item("valor")
                                    Catch ex As Exception
                                        precio_unitario = 0
                                    End Try
                                    If linea(0).StartsWith(encabezado(0).ToString) Then
                                        ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," &
                                                          linea(3) & ",'" & linea(1).ToString & "'," &
                                                          linea(2) & "," & precio_unitario & "," &
                                                          precio_unitario * linea(2) & ")"

                                        myOtrans.Ingresa(ls_sql)
                                        If myOtrans.Codigo_error > 0 Then
                                            lbExitoso = False
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next


                    ls_sql = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
                    myOtrans.Actualiza(ls_sql)


                    'Guardar_LogVisita_Umbright_EE(encabezado(2).ToString.ToUpper, encabezado(3).ToString,
                    'encabezado(1).ToString, encabezado(0).ToString, DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"),
                    'm'yOtrans)

                End If
            End With
            If numero_pedido > 0 And lbExitoso Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
            End If


        Catch ex As Exception
        Finally
            oFlex.close()
            oFlex = Nothing
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
        Return lbExitoso
    End Function

    Private Function Subir_Pedido_Temporal_Tekne(ByVal archivoXML As String)
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dFechaPedido As DateTime
        Dim dFecha_Creacion_Archivo As DateTime
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim CodigoCliente As String
        Dim encabezado(), detalle(), linea() As String
        Dim precio_unitario As Double
        Dim lbExitoso As Boolean = True
        Dim sEmpresa As String

        Try
            myOtrans.open()
            Otrans.open()
            ods.ReadXml(archivoXML)
            dr_encabezado = ods.Tables("encabezado").Rows(0)

            Dim Archivo As New FileInfo(archivoXML)
            dFecha_Creacion_Archivo = Archivo.CreationTime
            Dim FormaPago As String = ""


            With dr_encabezado

                encabezado = .Item("encabezado_pedido").ToString.Split("|")

                sEmpresa = encabezado(0)
                If sEmpresa = "EURO" Then sEmpresa = "LOGISERV"


                dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & sEmpresa & "','CLIENTE','" & encabezado(2) & "'")
                CodigoCliente = encabezado(2)

                Try
                    FormaPago = encabezado(10).ToString
                Catch ex As Exception
                    FormaPago = dtCliente.Rows(0).Item("Condpago").ToString
                End Try

                Guardar_Sincronizacion(encabezado(6), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), 1, 1)

                ls_sql = encabezado(3)
                If encabezado(1).Length = 7 Then
                    ls_sql &= " " & encabezado(1).ToString.Substring(1, 2) & ":" & encabezado(1).ToString.Substring(3, 2)

                Else
                    ls_sql &= " " & encabezado(1).ToString.Substring(2, 2) & ":" & encabezado(1).ToString.Substring(4, 2)
                End If




                dFechaPedido = ls_sql

                '(c) 20151110 Cuando el usuario que graba viene con numeros se debe
                'validar que el pedido no haya llegado previamente


                Dim lbPedidoNuevo As Boolean = True
                Try
                    If IsNumeric(encabezado(6).ToString) Then
                        'Si el usuario viene con numeros verificar que no exista el pedido previo
                        Dim lsSQL As String = "call pa_var_um_mov_pedidos_encabezado_numero ('" &
                            sEmpresa & "','" & encabezado(1).ToString & "','" &
                             encabezado(2).ToString & "')"
                        Dim dtPedido As DataTable = myOtrans.Obtiene(lsSQL)
                        If dtPedido.Rows.Count > 0 Then
                            If dtPedido.Rows(0).Item("comentarios").ToString.ToLower.Equals("tekne " & encabezado(4).ToString.ToLower) Then
                                lbPedidoNuevo = False
                                numero_pedido = 1 'Le envio 1 para que limpie el historial
                            End If
                        End If

                    End If

                Catch ex As Exception

                End Try


                If lbPedidoNuevo Then
                    ''Guardar     ///dtCliente.Rows(0).Item("Condpago").ToString
                    ls_sql = "call pa_ins_um_mov_pedidos_encabezado_tekne ('" &
                             sEmpresa & "','" & encabezado(1).ToString & "','" &
                             encabezado(2).ToString & "','" & FormaPago & "'," &
                             "0,0,'" &
                            DateTime.Parse(dFechaPedido.ToString).ToString("yyyy-MM-dd HH:mm") & "','" &
                            DateTime.Parse(dFechaPedido.ToString).ToString("yyyy-MM-dd") & "','"


                    ls_sql += "1900-01-01','"

                    'ls_sql += "tekne " & encabezado(4).Replace("ENT", " Entregar ").Replace("OC", "Orden de Compra ") & "','" & _
                    ls_sql += "tekne " & encabezado(4).ToString & "','" &
                            encabezado(6).ToString.ToLower & "',1,'" &
                            dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                            dFecha_Creacion_Archivo.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL,'"

                    Try
                        ls_sql += encabezado(8).ToString & "','" & encabezado(9).ToString & "')"
                    Catch ex As Exception
                        ls_sql += "','')"
                    End Try


                    myOtrans.Ingresa(ls_sql)

                    If myOtrans.Codigo_error = 0 Then
                        dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                        numero_pedido = dt.Rows(0).Item("newid").ToString

                        For icount As Integer = 1 To 7
                            If .Item("detalle" & icount.ToString).ToString.Length > 0 Then
                                detalle = .Item("detalle" & icount.ToString).ToString.Split("$")
                            Else
                                detalle = Nothing
                            End If


                            If Not detalle Is Nothing Then
                                For Each lineas As String In detalle
                                    linea = lineas.Split("|")
                                    If linea.Length > 1 Then
                                        dt = oFlex.Obtener_Precio_Final(sEmpresa, linea(2), CodigoCliente)
                                        Try
                                            precio_unitario = dt.Rows(0).Item("valor")
                                        Catch ex As Exception
                                            precio_unitario = 0
                                        End Try
                                        If linea(0).StartsWith(encabezado(0).ToString) Then
                                            ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," &
                                                              linea(4) & ",'" & linea(2).ToString & "'," &
                                                              linea(3) & "," & precio_unitario & "," &
                                                              precio_unitario * linea(3) & ")"

                                            myOtrans.Ingresa(ls_sql)
                                            If myOtrans.Codigo_error > 0 Then
                                                lbExitoso = False
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        Next


                        ls_sql = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
                        myOtrans.Actualiza(ls_sql)

                        'Guardar_LogVisita_Umbright_EE(sEmpresa.ToUpper, encabezado(6).ToString,
                        ' encabezado(2).ToString, encabezado(1).ToString, DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"),
                        ' myOtrans)

                    Else
                        If myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                            numero_pedido = 99
                            lbExitoso = True

                        End If
                    End If
                End If 'Pedido Nuevo
            End With

            If numero_pedido > 0 And lbExitoso Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
            End If


        Catch ex As Exception
        Finally
            oFlex.close()
            oFlex = Nothing
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
        Return lbExitoso

    End Function
    Private Function Subir_Pedido_Temporal_TekneOld10032014(ByVal archivoXML As String)
        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dFecha_Creacion_Archivo As DateTime
        Dim dFechaPedido As DateTime
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General
        Dim CodigoCliente As Integer
        Dim encabezado(), detalle(), linea() As String
        Dim precio_unitario As Double
        Dim lbExitoso As Boolean = True


        Try
            myOtrans.open()
            Otrans.open()
            ods.ReadXml(archivoXML)
            dr_encabezado = ods.Tables("encabezado").Rows(0)




            Dim Archivo As New FileInfo(archivoXML)
            dFecha_Creacion_Archivo = Archivo.CreationTime


            With dr_encabezado

                encabezado = .Item("encabezado_pedido").ToString.Split("|")


                dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & encabezado(0) & "','CLIENTE','" & encabezado(2) & "'")
                CodigoCliente = encabezado(2)
                ls_sql = encabezado(3)
                If encabezado(1).Length = 7 Then
                    ls_sql &= " " & encabezado(1).ToString.Substring(1, 2) & ":" & encabezado(1).ToString.Substring(3, 2)

                Else
                    ls_sql &= " " & encabezado(1).ToString.Substring(2, 2) & ":" & encabezado(1).ToString.Substring(4, 2)
                End If




                dFechaPedido = ls_sql

                Guardar_Sincronizacion(encabezado(6), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"), 1, 1)

                ''Guardar 
                ls_sql = "call pa_ins_um_mov_pedidos_encabezado_tekne ('" &
                         encabezado(0).ToString.ToUpper & "','" & encabezado(1).ToString & "','" &
                         encabezado(2).ToString & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                         "0,0,'" &
                        DateTime.Parse(dFechaPedido.ToString).ToString("yyyy-MM-dd HH:mm") & "','" &
                        DateTime.Parse(dFechaPedido.ToString).ToString("yyyy-MM-dd") & "','"

                ls_sql += "1900-01-01','"

                ls_sql += "tekne " & encabezado(4).Replace("ENT", " Entregar ").Replace("OC", "Orden de Compra ") & "','" &
                        encabezado(6).ToString & "',1,'" &
                        dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                        dFecha_Creacion_Archivo.ToString("yyyy-MM-dd HH:mm:ss") & "',NULL,'"

                Try
                    ls_sql += encabezado(8).ToString & "','" & encabezado(9).ToString & "')"
                Catch ex As Exception
                    ls_sql += "','')"
                End Try


                myOtrans.Ingresa(ls_sql)

                If myOtrans.Codigo_error = 0 Then
                    dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString

                    For icount As Integer = 1 To 7
                        If .Item("detalle" & icount.ToString).ToString.Length > 0 Then
                            detalle = .Item("detalle" & icount.ToString).ToString.Split("$")
                        Else
                            detalle = Nothing
                        End If


                        If Not detalle Is Nothing Then
                            For Each lineas As String In detalle
                                linea = lineas.Split("|")
                                If linea.Length > 1 Then
                                    dt = oFlex.Obtener_Precio_Final(linea(0), linea(2), CodigoCliente)
                                    Try
                                        precio_unitario = dt.Rows(0).Item("valor")
                                    Catch ex As Exception
                                        precio_unitario = 0
                                    End Try
                                    If linea(0).StartsWith(encabezado(0).ToString) Then
                                        ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & numero_pedido & "," &
                                                          linea(4) & ",'" & linea(2).ToString & "'," &
                                                          linea(3) & "," & precio_unitario & "," &
                                                          precio_unitario * linea(3) & ")"

                                        myOtrans.Ingresa(ls_sql)
                                        If myOtrans.Codigo_error > 0 Then
                                            lbExitoso = False
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next


                    ls_sql = "call pa_upd_mov_pedidos_encabezado_cell (" & numero_pedido & ")"
                    myOtrans.Actualiza(ls_sql)

                    'Guardar_LogVisita_Umbright_EE(encabezado(0).ToString.ToUpper, encabezado(6).ToString,
                    'encabezado(2).ToString, encabezado(1).ToString, DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm:ss"),
                    'myOtrans)

                Else
                    If myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                        numero_pedido = 99
                        lbExitoso = True

                    End If
                End If
            End With

            If numero_pedido > 0 And lbExitoso Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
            End If


        Catch ex As Exception
        Finally
            oFlex.close()
            oFlex = Nothing
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
        Return lbExitoso

    End Function

    Private Function Subir_Encabezado_Temporal_Celular(ByVal archivoXML As String, ByRef CodigoCliente As String) As Integer

        Dim ods As New DataSet
        Dim dr_encabezado As DataRow
        Dim numero_pedido As Integer = -1
        Dim dt As DataTable
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dFecha_Creacion_Archivo As DateTime
        Dim dtCliente As DataTable
        Dim ClsGen As New ClasesGenerales.General



        Try
            myOtrans.open()
            Otrans.open()
            ods.ReadXml(archivoXML)
            dr_encabezado = ods.Tables("encabezado").Rows(0)




            Dim Archivo As New FileInfo(archivoXML)
            dFecha_Creacion_Archivo = Archivo.CreationTime

            With dr_encabezado
                dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & .Item("empresa") & "','CLIENTE','" & .Item("codigo_cliente") & "'")
                CodigoCliente = .Item("codigo_cliente").ToString

                ls_sql = "call pa_ins_um_mov_pedidos_encabezado ('" &
                         .Item("empresa").ToString.ToUpper & "','" & .Item("numero_pedido").ToString & "','" &
                         .Item("codigo_cliente").ToString & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                         "0,0,'" &
                        DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd HH:mm") & "','" &
                        DateTime.Parse(dFecha_Creacion_Archivo.ToString).ToString("yyyy-MM-dd") & "','"

                ls_sql += "1900-01-01','"

                ls_sql += .Item("comentarios").ToString.Replace("|", " ") & " Prueba IT**','" &
                        .Item("usuario_grabo").ToString & "',1,'" &
                        dtCliente.Rows(0).Item("ListaPrecio").ToString & "','" &
                        dFecha_Creacion_Archivo.ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                        .Item("direccion_entrega").ToString & "')"
                ''31/03/11 '(c) se Agrego la Direccion de Entrega

                myOtrans.Ingresa(ls_sql)

                If myOtrans.Codigo_error = 0 Then
                    dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString
                End If
            End With
            If numero_pedido > 0 Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Celular\Receive\log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
            End If


        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try
        Return numero_pedido
    End Function

    Private Function Subir_Detalle_Temporal_Celular(ByVal archivoXML As String, ByVal CodigoPedido As Integer, ByVal CodigoCliente As String, ByVal NumeroPedido As String) As Boolean
        Dim dr As DataRow
        Dim ls_sql As String
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim lbExitoso As Boolean = False
        Dim Ods As New DataSet
        Dim precio_unitario As Double = 0
        Dim dt As DataTable
        Dim ClsGen As New ClasesGenerales.General


        Try
            myOtrans.open()

            Ods.ReadXml(archivoXML)
            dr = Ods.Tables("detalle").Rows(0)

            dt = oFlex.Obtener_Precio_Final(dr.Item("Empresa"), dr.Item("producto"), CodigoCliente)
            Try
                precio_unitario = dt.Rows(0).Item("valor")
            Catch ex As Exception
                precio_unitario = 0
            End Try


            ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & CodigoPedido & "," &
                   dr.Item("Linea") & ",'" & dr.Item("producto").ToString & "'," &
                   dr.Item("Cantidad") & "," & precio_unitario & "," &
                   precio_unitario * dr.Item("Cantidad") & ")"

            myOtrans.Ingresa(ls_sql)
            If myOtrans.Codigo_error > 0 Then
                lbExitoso = False
            Else
                lbExitoso = True
                ls_sql = "call pa_upd_mov_pedidos_encabezado_cell (" & CodigoPedido & ")"
                myOtrans.Actualiza(ls_sql)
            End If
            If lbExitoso Then
                ClsGen.Mover_Archivo(archivoXML, "c:\aplicaciones\Celular\Receive\Log\" & archivoXML.Split("\").GetValue(archivoXML.Split("\").LongLength - 1))
            End If
        Catch ex As Exception
            lbExitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
            oFlex.close()
            oFlex = Nothing
        End Try

        Return lbExitoso
    End Function

    Private Function Subir_Encuesta_Temporal_Celular(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDatos(), lsDetalle() As String
        Dim huboerror, procesado As Boolean
        procesado = False

        Try
            huboerror = False
            myOtrans.open()

            ods.ReadXml(psarchivoXML)
            dr = ods.Tables("motivo").Rows(0)

            lsDatos = dr.Item("encabezado").ToString.Split("|")
            lsDetalle = dr.Item("detalle").ToString.Split("|")
            lsSQL = "call pa_var_um_mov_encuesta_resultado_encabezado_numero ('" &
                    lsDatos(0).Split("_")(0) & "'," & lsDatos(0).Split("_")(1) & ")"
            dt = myOtrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                lsSQL = "call pa_ins_um_mov_resultado_encuesta_encabezado ('" &
                    lsDatos(0).Split("_")(0) & "'," & lsDatos(0).Split("_")(1) & "," &
                    dt.Rows(0).Item("nuevo_numero").ToString & ",'" &
                    lsDatos(1) & "','" &
                    lsDatos(2) & "')"
                myOtrans.Ingresa(lsSQL)
                If myOtrans.Codigo_error = 0 Then
                    If lsDatos.Length > 3 Then
                        lsSQL = "call pa_upd_um_mov_resultado_encuesta_encabezado_gps ('" &
                                lsDatos(0).Split("_")(0) & "'," & lsDatos(0).Split("_")(1) & "," &
                                dt.Rows(0).Item("nuevo_numero").ToString & ",'" &
                                lsDatos(3).Split(",")(0) & "','" &
                                lsDatos(3).Split(",")(1) & "')"
                        myOtrans.Actualiza(lsSQL)
                    End If


                    For i As Integer = 0 To lsDetalle.Length - 1
                        If lsDetalle(i).Length > 0 Then


                            lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa ('" &
                                 lsDatos(0).Split("_")(0) & "'," & lsDatos(0).Split("_")(1) & "," &
                                 dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                 lsDetalle(i).Split(",")(0).Split("=")(1) & ","
                            If lsDetalle(i).Split(",")(1).Split("=")(1) = "99" Then
                                lsSQL += "1,'" & lsDetalle(i).Split(",")(2) & "')"
                            Else
                                lsSQL += lsDetalle(i).Split(",")(1).Split("=")(1) & ",NULL)"
                            End If

                            myOtrans.Ingresa(lsSQL)
                            If myOtrans.Codigo_error > 0 Then
                                If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                    huboerror = True
                                End If
                            End If
                        End If

                    Next
                Else
                    huboerror = True

                End If

            End If

            If Not huboerror Then
                procesado = True
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try



        Return procesado

    End Function

    Private Function Subir_Encuesta_Temporal_CelularNube(ByVal psarchivoXML As String)


        'lopez hurtarte

        Dim ods As New DataSet
        Dim dr, dr2, dr3, dr4, dr5 As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDatos(), lsDetalle1(), lsDetalle2(), lsDetalle3(), lsDetalle4() As String
        Dim huboerror As Boolean
        Dim CodTipoEncuesta As Integer = 0

        Try
            huboerror = False
            myOtrans.open()


            Try

                ods.Tables("detalle").Clear()
                ods.Tables("motivo").Clear()
                ods.Tables("encuesta").Clear()



            Catch ex As Exception

            End Try

            ods.ReadXml(psarchivoXML)
            ' dr = ods.Tables("motivo").Rows(0)

            Try
                dr = ods.Tables("motivo").Rows(0)
                dr2 = ods.Tables("detalle").Rows(0)
                dr3 = ods.Tables("detalle").Rows(1)
                dr4 = ods.Tables("detalle").Rows(2)
                dr5 = ods.Tables("detalle").Rows(3)

                lsDatos = dr.Item("encabezado").ToString.Split("|")
                lsDetalle1 = dr2.Item("detalle_text").ToString.Split("$") ' & dr3.Item("detalle").ToString.Split("|") & dr4.Item("detalle").ToString.Split("|") & dr5.Item("detalle").ToString.Split("|")
                lsDetalle2 = dr3.Item("detalle_text").ToString.Split("$")
                lsDetalle3 = dr4.Item("detalle_text").ToString.Split("$")
                lsDetalle4 = dr5.Item("detalle_text").ToString.Split("$")

            Catch ex As Exception
            End Try

            Dim copcion As String = ""



            'Actualiza Incidencia
            If lsDatos(8).ToString = 3 And lsDatos(9).ToString = 2 Then
                CodTipoEncuesta = Val(lsDatos(8))
                lsSQL = "call pa_upd_um_mov_resultado_encuesta_encabezado_incidencia_tk('" &
                   lsDatos(0) & "'," & lsDatos(1) & "," & lsDatos(2) & ",'" & lsDatos(7) & "','" & lsDatos(10) & "'," & CodTipoEncuesta & ")"
                dt = myOtrans.Obtiene(lsSQL)

            End If


            'Inserta Incidencias
            If lsDatos(8).ToString = 3 And lsDatos(9).ToString = 1 Then


                lsSQL = "call pa_var_um_mov_encuesta_resultado_encabezado_numero ('" &
                   lsDatos(0) & "'," & lsDatos(1) & ")"
                dt = myOtrans.Obtiene(lsSQL)
                If dt.Rows.Count > 0 Then
                    CodTipoEncuesta = Val(lsDatos(8))
                    lsSQL = "call pa_ins_um_mov_resultado_encuesta_encabezado_tk ('" &
                        lsDatos(0) & "'," & lsDatos(1) & "," &
                        dt.Rows(0).Item("nuevo_numero").ToString & ",'" &
                        lsDatos(3) & "','" & lsDatos(7) & "','" & lsDatos(9) & "','" &
                        lsDatos(4) & "'," & lsDatos(8) & ",'" & lsDatos(10) & "')"
                    myOtrans.Ingresa(lsSQL)
                    If myOtrans.Codigo_error = 0 Then



                        For i As Integer = 0 To lsDetalle1.Length - 1
                            If lsDetalle1(i).Length > 0 Then



                                lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa_tk ('" &
                                     lsDatos(0) & "'," & lsDatos(1) & "," &
                                     dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                     IIf(lsDetalle1(i).Split("|")(3) = 89, lsDetalle1(i).Split("|")(4), lsDetalle1(i).Split("|")(3)) & "," & lsDetalle1(i).Split("|")(4) & ",'" & lsDetalle1(i).Split("|")(5) & "'," & CodTipoEncuesta & ")"
                                myOtrans.Ingresa(lsSQL)
                                If myOtrans.Codigo_error > 0 Then
                                    If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                        huboerror = True
                                    End If
                                End If
                            End If

                        Next
                    End If

                End If

            End If











            'Inserta Encuestas de Ejecucion y Participacion
            If lsDatos(8).ToString = 4 Or lsDatos(8).ToString = 5 Then

                lsSQL = "call pa_var_um_mov_encuesta_resultado_encabezado_numero ('" &
                   lsDatos(0) & "'," & lsDatos(1) & ")"
                dt = myOtrans.Obtiene(lsSQL)
                If dt.Rows.Count > 0 Then
                    CodTipoEncuesta = Val(lsDatos(8))
                    lsSQL = "call pa_ins_um_mov_resultado_encuesta_encabezado_tk ('" &
                        lsDatos(0) & "'," & lsDatos(1) & "," &
                        dt.Rows(0).Item("nuevo_numero").ToString & ",'" &
                        lsDatos(3) & "','" & lsDatos(7) & "','" & lsDatos(9) & "','" &
                        lsDatos(4) & "'," & lsDatos(8) & ",NULL)"
                    myOtrans.Ingresa(lsSQL)
                    If myOtrans.Codigo_error = 0 Then
                        If lsDatos.Length > 3 Then
                            lsSQL = "call pa_upd_um_mov_resultado_encuesta_encabezado_gps ('" &
                                    lsDatos(0) & "'," & lsDatos(1) & "," &
                                    dt.Rows(0).Item("nuevo_numero").ToString & ",'" &
                                    lsDatos(5) & "','" &
                                    lsDatos(6) & "')"
                            myOtrans.Actualiza(lsSQL)
                        End If


                        For i As Integer = 0 To lsDetalle1.Length - 1
                            If lsDetalle1(i).Length > 0 Then

                                If lsDetalle1(i).Split("|")(3) = 89 Then copcion = 0

                                lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa_tk ('" &
                                     lsDatos(0) & "'," & lsDatos(1) & "," &
                                     dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                     IIf(lsDetalle1(i).Split("|")(3) = 89, lsDetalle1(i).Split("|")(4), lsDetalle1(i).Split("|")(3)) & "," & lsDetalle1(i).Split("|")(4) & ",'" & lsDetalle1(i).Split("|")(5) & "'," & CodTipoEncuesta & ")"
                                myOtrans.Ingresa(lsSQL)
                                If myOtrans.Codigo_error > 0 Then
                                    If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                        huboerror = True
                                    End If
                                End If
                            End If

                        Next




                        For i2 As Integer = 0 To lsDetalle2.Length - 1
                            If lsDetalle2(i2).Length > 0 Then
                                If lsDetalle2(i2).Split("|")(3) = 89 Then copcion = 0

                                lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa_tk ('" &
                                     lsDatos(0) & "'," & lsDatos(1) & "," &
                                     dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                    IIf(lsDetalle2(i2).Split("|")(3) = 89, lsDetalle2(i2).Split("|")(4), lsDetalle2(i2).Split("|")(3)) & "," & lsDetalle2(i2).Split("|")(4) & ",'" & lsDetalle2(i2).Split("|")(5) & "'," & CodTipoEncuesta & ")"
                                'lsDetalle2(i2).Split("|")(3) & "," & lsDetalle2(i2).Split("|")(4) & ",'" & lsDetalle2(i2).Split("|")(5) & "')"
                                myOtrans.Ingresa(lsSQL)
                                If myOtrans.Codigo_error > 0 Then
                                    If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                        huboerror = True
                                    End If
                                End If
                            End If

                        Next

                        For i3 As Integer = 0 To lsDetalle3.Length - 1
                            If lsDetalle3(i3).Length > 0 Then
                                If lsDetalle3(i3).Split("|")(3) = 89 Then copcion = 0

                                lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa_tk ('" &
                                     lsDatos(0) & "'," & lsDatos(1) & "," &
                                     dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                       IIf(lsDetalle3(i3).Split("|")(3) = 89, lsDetalle3(i3).Split("|")(4), lsDetalle3(i3).Split("|")(3)) & "," & lsDetalle3(i3).Split("|")(4) & ",'" & lsDetalle3(i3).Split("|")(5) & "'," & CodTipoEncuesta & ")"
                                '  lsDetalle3(i3).Split("|")(3) & "," & lsDetalle3(i3).Split("|")(4) & ",'" & lsDetalle3(i3).Split("|")(5) & "')"

                                myOtrans.Ingresa(lsSQL)
                                If myOtrans.Codigo_error > 0 Then
                                    If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                        huboerror = True
                                    End If
                                End If
                            End If
                        Next


                        For i4 As Integer = 0 To lsDetalle4.Length - 1



                            If lsDetalle4(i4).Length > 0 Then
                                If lsDetalle4(i4).Split("|")(3) = 89 Then
                                    copcion = 0
                                End If

                                lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa_tk ('" &
                                  lsDatos(0) & "'," & lsDatos(1) & "," &
                                  dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                  IIf(lsDetalle4(i4).Split("|")(3) = 89, lsDetalle4(i4).Split("|")(4), lsDetalle4(i4).Split("|")(3)) & "," & lsDetalle4(i4).Split("|")(4) & ",'" & lsDetalle4(i4).Split("|")(5) & "'," & CodTipoEncuesta & ")"
                                'lsDetalle4(i4).Split("|")(3) & "," & lsDetalle4(i4).Split("|")(4) & ",'" & lsDetalle4(i4).Split("|")(5) & "')"

                                myOtrans.Ingresa(lsSQL)
                                If myOtrans.Codigo_error > 0 Then
                                    If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                        huboerror = True
                                    End If
                                End If
                            End If

                        Next
                    Else
                        huboerror = True

                    End If

                End If

            End If

            If Not huboerror Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Function

    Private Function Subir_Encuesta_Temporal_CelularNubeOld10032014(ByVal psarchivoXML As String)

        Dim ods As New DataSet
        Dim dr, dr2, dr3, dr4, dr5 As DataRow
        Dim dt As DataTable
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsDatos(), lsDetalle1(), lsDetalle2(), lsDetalle3(), lsDetalle4() As String
        Dim huboerror As Boolean

        Try
            huboerror = False
            myOtrans.open()


            Try

                ods.Tables("detalle").Clear()
                ods.Tables("motivo").Clear()
                ods.Tables("encuesta").Clear()



            Catch ex As Exception

            End Try

            ods.ReadXml(psarchivoXML)
            ' dr = ods.Tables("motivo").Rows(0)

            Try
                dr = ods.Tables("motivo").Rows(0)
                dr2 = ods.Tables("detalle").Rows(0)
                dr3 = ods.Tables("detalle").Rows(1)
                dr4 = ods.Tables("detalle").Rows(2)
                dr5 = ods.Tables("detalle").Rows(3)

                lsDatos = dr.Item("encabezado").ToString.Split("|")
                lsDetalle1 = dr2.Item("detalle_text").ToString.Split("$") ' & dr3.Item("detalle").ToString.Split("|") & dr4.Item("detalle").ToString.Split("|") & dr5.Item("detalle").ToString.Split("|")
                lsDetalle2 = dr3.Item("detalle_text").ToString.Split("$")
                lsDetalle3 = dr4.Item("detalle_text").ToString.Split("$")
                lsDetalle4 = dr5.Item("detalle_text").ToString.Split("$")

            Catch ex As Exception
            End Try

            Dim copcion As String = ""

            lsSQL = "call pa_var_um_mov_encuesta_resultado_encabezado_numero ('" &
                    lsDatos(0) & "'," & lsDatos(1) & ")"
            dt = myOtrans.Obtiene(lsSQL)
            If dt.Rows.Count > 0 Then
                lsSQL = "call pa_ins_um_mov_resultado_encuesta_encabezado ('" &
                    lsDatos(0) & "'," & lsDatos(1) & "," &
                    dt.Rows(0).Item("nuevo_numero").ToString & ",'" &
                    lsDatos(3) & "','" &
                    lsDatos(4) & "')"
                myOtrans.Ingresa(lsSQL)
                If myOtrans.Codigo_error = 0 Then
                    If lsDatos.Length > 3 Then
                        lsSQL = "call pa_upd_um_mov_resultado_encuesta_encabezado_gps ('" &
                                lsDatos(0) & "'," & lsDatos(1) & "," &
                                dt.Rows(0).Item("nuevo_numero").ToString & ",'" &
                                lsDatos(5) & "','" &
                                lsDatos(6) & "')"
                        myOtrans.Actualiza(lsSQL)
                    End If


                    For i As Integer = 0 To lsDetalle1.Length - 1
                        If lsDetalle1(i).Length > 0 Then

                            If lsDetalle1(i).Split("|")(3) = 89 Then copcion = 0

                            lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa ('" &
                                 lsDatos(0) & "'," & lsDatos(1) & "," &
                                 dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                IIf(lsDetalle1(i).Split("|")(3) = 89, lsDetalle1(i).Split("|")(4), lsDetalle1(i).Split("|")(3)) & "," & lsDetalle1(i).Split("|")(4) & ",'" & lsDetalle1(i).Split("|")(5) & "')"
                            myOtrans.Ingresa(lsSQL)
                            If myOtrans.Codigo_error > 0 Then
                                If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                    huboerror = True
                                End If
                            End If
                        End If

                    Next




                    For i2 As Integer = 0 To lsDetalle2.Length - 1
                        If lsDetalle2(i2).Length > 0 Then
                            If lsDetalle2(i2).Split("|")(3) = 89 Then copcion = 0

                            lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa ('" &
                                 lsDatos(0) & "'," & lsDatos(1) & "," &
                                 dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                IIf(lsDetalle2(i2).Split("|")(3) = 89, lsDetalle2(i2).Split("|")(4), lsDetalle2(i2).Split("|")(3)) & "," & lsDetalle2(i2).Split("|")(4) & ",'" & lsDetalle2(i2).Split("|")(5) & "')"
                            'lsDetalle2(i2).Split("|")(3) & "," & lsDetalle2(i2).Split("|")(4) & ",'" & lsDetalle2(i2).Split("|")(5) & "')"
                            myOtrans.Ingresa(lsSQL)
                            If myOtrans.Codigo_error > 0 Then
                                If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                    huboerror = True
                                End If
                            End If
                        End If

                    Next

                    For i3 As Integer = 0 To lsDetalle3.Length - 1
                        If lsDetalle3(i3).Length > 0 Then
                            If lsDetalle3(i3).Split("|")(3) = 89 Then copcion = 0

                            lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa ('" &
                                 lsDatos(0) & "'," & lsDatos(1) & "," &
                                 dt.Rows(0).Item("nuevo_numero").ToString & "," &
                                   IIf(lsDetalle3(i3).Split("|")(3) = 89, lsDetalle3(i3).Split("|")(4), lsDetalle3(i3).Split("|")(3)) & "," & lsDetalle3(i3).Split("|")(4) & ",'" & lsDetalle3(i3).Split("|")(5) & "')"
                            '  lsDetalle3(i3).Split("|")(3) & "," & lsDetalle3(i3).Split("|")(4) & ",'" & lsDetalle3(i3).Split("|")(5) & "')"

                            myOtrans.Ingresa(lsSQL)
                            If myOtrans.Codigo_error > 0 Then
                                If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                    huboerror = True
                                End If
                            End If
                        End If
                    Next


                    For i4 As Integer = 0 To lsDetalle4.Length - 1
                        If lsDetalle4(i4).Length > 0 Then
                            If lsDetalle4(i4).Split("|")(3) = 89 Then
                                copcion = 0
                            End If

                            lsSQL = "call pa_ins_um_mov_resultado_encuesta_detalle_alternativa ('" &
                              lsDatos(0) & "'," & lsDatos(1) & "," &
                              dt.Rows(0).Item("nuevo_numero").ToString & "," &
                              IIf(lsDetalle4(i4).Split("|")(3) = 89, lsDetalle4(i4).Split("|")(4), lsDetalle4(i4).Split("|")(3)) & "," & lsDetalle4(i4).Split("|")(4) & ",'" & lsDetalle4(i4).Split("|")(5) & "')"
                            'lsDetalle4(i4).Split("|")(3) & "," & lsDetalle4(i4).Split("|")(4) & ",'" & lsDetalle4(i4).Split("|")(5) & "')"

                            myOtrans.Ingresa(lsSQL)
                            If myOtrans.Codigo_error > 0 Then
                                If Not myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                                    huboerror = True
                                End If
                            End If
                        End If

                    Next
                Else
                    huboerror = True

                End If

            End If

            If Not huboerror Then
                ClsGen.Mover_Archivo(psarchivoXML, "c:\aplicaciones\Umbright Mobile SE\Receive\log\" & psarchivoXML.Split("\").GetValue(psarchivoXML.Split("\").LongLength - 1))
            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


    End Function

    Private Function Subir_Pedido_Temporal(ByVal ods As DataSet, ByVal _NumeroPedido As String,
                ByVal dr_encabezado As DataRow, ByVal pdfecha_sincronizacion As DateTime) As Boolean
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")

        Dim ls_sql As String
        Dim dt As DataTable
        Dim liCod_Pedido As Integer
        Dim lbExitoso As Boolean = True

        Try
            myOtrans.open()

            With dr_encabezado
                ls_sql = "call pa_ins_um_mov_pedidos_encabezado ('" &
                        .Item("empresa").ToString & "','" & .Item("numero_pedido").ToString & "','" &
                        .Item("ctacte").ToString & "','" & .Item("forma_pago").ToString & "'," &
                        .Item("total_pedido").ToString & "," & .Item("total_lineas").ToString & ",'" &
                        DateTime.Parse(.Item("fecha_pedido").ToString).ToString("yyyy-MM-dd HH:mm") & "','" &
                        DateTime.Parse(.Item("fecha_entrega").ToString).ToString("yyyy-MM-dd") & "','"
                If Not .Item("fecha_modifico") Is System.DBNull.Value Then


                    ls_sql += DateTime.Parse(.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm")
                Else
                    ls_sql += "1900-01-01"
                End If
                ls_sql += "','"

                ls_sql += .Item("comentarios").ToString & "','" &
                        .Item("usuario_grabo").ToString & "'," &
                        .Item("estado").ToString & ",'" &
                        .Item("ListaPrecio").ToString & "','" &
                        pdfecha_sincronizacion.ToString("yyyy-MM-dd HH:mm:ss") & "',"

                Try
                    ls_sql += "'" & .Item("direccion_entrega").ToString.PadRight(100, " ").Substring(0, 100).Trim & "'"
                Catch ex As Exception
                    ls_sql += "NULL"
                End Try

                ls_sql += ")"

                '31/03/2011 Se Agrego Direccion de Entrega

                myOtrans.Ingresa(ls_sql)

                If myOtrans.Codigo_error = 0 Then
                    dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    liCod_Pedido = dt.Rows(0).Item("newid").ToString

                    ods.Tables("pedidos_detalle").DefaultView.RowFilter = "numero_pedido = '" & dr_encabezado.Item("numero_pedido") & "'"
                    ods.Tables("pedidos_detalle").DefaultView.Sort = "Linea"

                    Dim LineaLocal As Integer = 0
                    For Each drv As DataRowView In ods.Tables("pedidos_detalle").DefaultView
                        If drv.Item("numero_pedido") = dr_encabezado.Item("numero_pedido") Then
                            LineaLocal += 1
                            ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & liCod_Pedido & "," &
                                    LineaLocal & ",'" & drv.Item("producto").ToString & "'," &
                                    drv.Item("Cantidad") & "," & drv.Item("precio") & "," &
                                    drv.Item("total_linea") & ")"
                            myOtrans.Ingresa(ls_sql)
                            If myOtrans.Codigo_error > 0 Then
                                lbExitoso = False
                            End If
                        End If

                    Next
                Else
                    If myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                        lbExitoso = True
                    Else
                        lbExitoso = False
                    End If

                End If
            End With

        Catch ex As Exception
            lbExitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try

        Return lbExitoso
    End Function

    Private Function Hacer_Pedido_Clase_Web(ByVal ods As DataSet, ByVal _NumeroPedido As String, ByVal dr_encabezado As DataRow,
                    ByRef pNumeroPedido As String, ByRef pTipoDocumento As String) As Boolean
        ''Esdras 8:22 La mano de nuestro Dios es propicia para con todos los 
        ''            que le buscan, mas su poder y su ira contra todos los 
        ''            que le abandonan.
        Dim Oflex As New Umbral_Flex.Pedidos
        Dim dr, ofila As DataRow
        Dim li_linea As Integer = 0
        Dim ls_pedido_generado As Integer = 0
        Dim condiciones As String()
        Dim s_empresa As String = ""
        Dim proceso_exitoso As Boolean = False
        Dim pd_total_pedido As Double = 0
        Dim forma_pago As String = ""




        Oflex.Limpiar_Datos()
        s_empresa = dr_encabezado.Item("empresa").ToString
        forma_pago = dr_encabezado.Item("forma_pago").ToString

        Llenar_Auxiliares(ods, dr_encabezado.Item("ctacte"), s_empresa)
        If dr_encabezado.Item("forma_pago").ToString.Length = 0 Then
            forma_pago = ods.Tables("FlexLine_Clientes").Rows(0).Item("CondPago")
        End If


        ''filtrando informacion de las condiciones de pago
        ods.Tables("flexline_condiciones").DefaultView.RowFilter = "DESCRIPCION = '" & forma_pago & "'"

        ''Encabezado
        dr = Oflex.ods.Tables("encabezado").NewRow

        dr.Item("empresa") = s_empresa
        dr.Item("tipodocto") = ods.Tables("flexline_condiciones").DefaultView(0).Item("texto")
        dr.Item("numero") = ""
        dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
        dr.Item("codigo") = ods.Tables("flexline_clientes").Rows(0).Item("ctacte")
        dr.Item("vendedor") = ods.Tables("flexline_clientes").Rows(0).Item("ejecutivo")
        condiciones = ods.Tables("flexline_condiciones").DefaultView(0).Item("VALOR1").ToString.Split(".")
        dr.Item("diascredito") = condiciones(0).ToString
        dr.Item("listaprecio") = dr_encabezado.Item("listaprecios").ToString
        pd_total_pedido = dr_encabezado.Item("total_pedido").ToString
        dr.Item("total") = pd_total_pedido
        dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
        dr.Item("aprobacion") = ods.Tables("flexline_condiciones").DefaultView(0).Item("texto2")
        dr.Item("periodo") = Trim(Date.Parse(dr.Item("fecha").ToString).ToString("yyyy") + Date.Parse(dr.Item("fecha").ToString).ToString("MM"))
        dr.Item("direccion") = ods.Tables("flexline_clientes").Rows(0).Item("direccion").ToString
        dr.Item("ciudad") = ods.Tables("flexline_clientes").Rows(0).Item("ciudad").ToString
        dr.Item("comuna") = ods.Tables("flexline_clientes").Rows(0).Item("comuna").ToString
        dr.Item("pais") = ods.Tables("flexline_clientes").Rows(0).Item("pais").ToString
        dr.Item("contacto") = ods.Tables("flexline_clientes").Rows(0).Item("pais").ToString
        dr.Item("comentario1") = "PDA-" & dr_encabezado.Item("comentarios").ToString
        dr.Item("usuario") = dr_encabezado.Item("usuario_grabo").ToString

        dr.Item("AnalisisE3") = Date.Parse(dr_encabezado.Item("fecha_entrega").ToString).ToString("dd/MM/yyyy")



        Oflex.ods.Tables("encabezado").Rows.Add(dr)

        ''Documentop
        dr = Oflex.ods.Tables("documentop").NewRow

        dr.Item("codigopago") = forma_pago
        dr.Item("diascredito") = condiciones(0).ToString
        dr.Item("total") = pd_total_pedido
        dr.Item("cuenta") = ods.Tables("flexline_condiciones").DefaultView(0).Item("texto1")
        dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
        Oflex.ods.Tables("documentop").Rows.Add(dr)

        ''DocumentoV
        dr = Oflex.ods.Tables("documentov").NewRow
        dr.Item("total") = pd_total_pedido
        dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
        Oflex.ods.Tables("documentov").Rows.Add(dr)

        ''DocumentoD
        For Each ofila In ods.Tables("pedidos_detalle").Rows
            'li_linea = li_linea + 1
            If ofila.Item("cod_pedido") = dr_encabezado.Item("cod_pedido") Then


                dr = Oflex.ods.Tables("detalle").NewRow
                dr.Item("secuencia") = ofila.Item("linea")
                dr.Item("producto") = ofila.Item("cod_producto_flex")
                dr.Item("cantidad") = ofila.Item("cantidad")


                dr.Item("precio") = ofila.Item("precio")
                dr.Item("total") = ofila.Item("total_linea")

                dr.Item("diascredito") = condiciones(0).ToString
                dr.Item("factor") = ods.Tables("flexline_impuesto").Rows(0).Item("valor1")
                dr.Item("fecha") = Date.Parse(dr_encabezado("fecha_pedido").ToString).ToString("dd-MM-yyyy")
                dr.Item("costo") = 0
                dr.Item("linea") = ofila.Item("linea")

                Oflex.ods.Tables("detalle").Rows.Add(dr)
            End If
        Next



        ls_pedido_generado = Oflex.Guardar_PedidoBasico()

        If ls_pedido_generado > 0 Then
            proceso_exitoso = True
            pNumeroPedido = Oflex.ods.Tables("encabezado").Rows(0).Item("numero")
            pTipoDocumento = Oflex.ods.Tables("encabezado").Rows(0).Item("TipoDocto")
        End If

        Oflex = Nothing

        Return proceso_exitoso
    End Function


    Private Sub Llenar_Auxiliares(ByRef ods As DataSet, ByVal _codigo_cliente As String, ByVal _empresa As String)
        Dim ls_sql As String
        Dim dt As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Try
            Otrans.open()
            ls_sql = "pa_sel_um_gen_tabcod NULL,'SYSGOLD_CONDICIONES','" & _empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_condiciones"
            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_ctacte '" & _empresa & "','CLIENTE','" & _codigo_cliente & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_clientes"
            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)

            ls_sql = "pa_sel_um_gen_tabcod '01','CONFIG.IMPUESTO','" & _empresa & "'"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "flexline_impuesto"
            If ods.Tables.Contains(dt.TableName) Then
                ods.Tables.Remove(dt.TableName)
            End If
            ods.Tables.Add(dt.Copy)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try


    End Sub

    Private Function Procesar_Conteos_Consignaciones(ByVal pdr As DataRow, ByVal _dt As DataTable)


        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ClsGen As New ClasesGenerales.General
        Dim drv As DataRowView
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Proceso_Exitoso As Boolean = True
        Dim iCodEmpresa As Integer = 0
        Dim iCodConteo As Integer

        Try
            myOtrans.open()
            iCodEmpresa = ClsGen.Codigo_Empresa_Onbase(pdr.Item("empresa").ToString)

            'For Each dr In _dt.Rows
            ls_sql = "call pa_ins_um_crm_cliente_producto_consignacion_conteo_encabezado(" &
                        iCodEmpresa & ",'" &
                        pdr.Item("ctacte").ToString & "','" &
                        DateTime.Parse(pdr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd") & "','" &
                        pdr.Item("comentarios_reposicion").ToString & "','" &
                        pdr.Item("comentarios_factura").ToString & "','" &
                        pdr.Item("usuario_grabo").ToString & "')"
            ','" & _
            '                        pdr.Item("direccion_entrega_reposicion").ToString & "','" & _
            '                        pdr.Item("direccion_entrega_factura").ToString & "')"

            '31/03/2011

            myOtrans.Ingresa(ls_sql)
            If myOtrans.Codigo_error = 0 Then
                dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                iCodConteo = dt.Rows(0).Item("newid").ToString

                _dt.DefaultView.RowFilter = "empresa = '" & pdr.Item("empresa") &
                                            "' and ctacte = '" & pdr.Item("ctacte") &
                                            "' and cod_conteo = " & pdr.Item("cod_conteo")


                For Each drv In _dt.DefaultView
                    ls_sql = "call pa_ins_um_crm_cliente_producto_consignacion_conteo (" &
                                iCodEmpresa & ",'" &
                                drv.Item("ctacte").ToString & "','" &
                                drv.Item("producto").ToString & "','" &
                                DateTime.Parse(drv.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm") & "'," &
                                drv.Item("cantidad").ToString & ",0,'" &
                                pdr.Item("usuario_grabo").ToString & "'," & iCodConteo.ToString & ")"

                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error > 0 Then
                        Proceso_Exitoso = False
                    End If
                Next
            Else
                If myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                    Proceso_Exitoso = True
                Else
                    Proceso_Exitoso = False
                End If

            End If

        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing

        End Try

        Return Proceso_Exitoso
    End Function


    ''GenerarDocumentos de Consignaciones

#Region " Documentos Consignaciones"



    Private Function Generar_Documentos_Consignaciones() As Boolean


        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("Corporativo")
        Dim ClsGen As New ClasesGenerales.General
        Dim dt, dt2 As DataTable
        Dim dr, dr_aux As DataRow
        Dim ods As New DataSet
        Dim lBodega As String = "CONSIGNACIONES"

        Try





            'Ods.Tables("Conteos_Pendientes").Rows.Clear()
            Otrans.open()
            ls_sql = "pa_sel_um_mov_consignacion_conteo_pendiente null,null,null"
            dt = Otrans.Obtiene(ls_sql)
            If dt.Rows.Count > 0 Then
                dt2 = New DataTable("Conteos_Pendientes")
                dt2.Columns.Add(New DataColumn("cod_conteo", GetType(Integer)))
                dt2.Columns.Add(New DataColumn("cod_empresa", GetType(Integer)))
                dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
                dt2.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
                dt2.Columns.Add(New DataColumn("Razon_Social", GetType(String)))
                dt2.Columns.Add(New DataColumn("Cod_Producto", GetType(String)))
                dt2.Columns.Add(New DataColumn("nombre_producto", GetType(String)))
                dt2.Columns.Add(New DataColumn("saldo_actual", GetType(Integer)))
                dt2.Columns.Add(New DataColumn("conteo", GetType(Integer)))
                dt2.Columns.Add(New DataColumn("cantidad_facturar", GetType(Integer)))
                dt2.Columns.Add(New DataColumn("cantidad_Consignar", GetType(Integer)))
                dt2.Columns.Add(New DataColumn("cantidad_aprobada", GetType(Integer)))
                dt2.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
                dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("Usuario_Grabo", GetType(String)))
                dt2.Columns.Add(New DataColumn("bodega", GetType(String))) 'Establecer CONSIGNACIONES, REN_CONSIGNACIONES
                ods.Tables.Add(dt2.Copy)

                dt2 = New DataTable("clientes_procesar")
                dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
                dt2.Columns.Add(New DataColumn("cod_cliente", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("Comentarios_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_reposicion", GetType(String)))
                dt2.Columns.Add(New DataColumn("direccion_entrega_factura", GetType(String)))
                dt2.Columns.Add(New DataColumn("bodega", GetType(String))) '(c) 20180629
                ods.Tables.Add(dt2.Copy)
            End If


            Dim dtBodega As DataTable




            For Each dr In dt.Rows




                dr_aux = ods.Tables("Conteos_Pendientes").NewRow
                dtBodega = ClsGen.selectQuery("FlexLine", "pa_sel_um_consignacion_cliente_bodega '" & dr.Item("empresa").ToString & "','" & dr.Item("cod_cliente_flex").ToString & "'")
                dr_aux.Item("Bodega") = "CONSIGNACIONES"
                '20180629 (c)
                If dtBodega.Rows(0).Item("Lineas") > 0 Then
                    '      dr_aux.Item("Bodega") = "REN_CONSIGNACIONES"
                End If
                dr_aux.Item("cod_conteo") = dr.Item("cod_conteo")
                dr_aux.Item("cod_empresa") = dr.Item("cod_empresa")
                dr_aux.Item("empresa") = dr.Item("empresa").ToString
                dr_aux.Item("cod_cliente") = dr.Item("cod_cliente_flex")
                'dr_aux.Item("Razon_Social") = ""
                dr_aux.Item("cod_producto") = dr.Item("cod_producto_flex")
                ' dr_aux.Item("nombre_producto") = ""
                dr_aux.Item("conteo") = dr.Item("conteo")
                dr_aux.Item("cantidad_aprobada") = dr.Item("cantidad_maxima")
                dr_aux.Item("fecha") = dr.Item("fecha")
                dr_aux.Item("saldo_actual") = Obtener_Saldo_Consignacion_Actual(dr.Item("empresa").ToString, dr.Item("cod_producto_flex").ToString, dr.Item("cod_cliente_flex"), dr_aux.Item("Bodega"))
                dr_aux.Item("cantidad_consignar") = IIf(dr.Item("cantidad_maxima") Is System.DBNull.Value, 0, dr.Item("cantidad_maxima")) - dr.Item("conteo").ToString
                dr_aux.Item("cantidad_facturar") = IIf(dr_aux.Item("saldo_actual") Is System.DBNull.Value, 0, dr_aux.Item("saldo_actual")) - dr.Item("conteo").ToString
                dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios").ToString
                dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_factura").ToString
                dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega_reposicion").ToString
                dr_aux.Item("Direccion_entrega_factura") = dr.Item("direccion_entrega_factura").ToString
                dr_aux.Item("Usuario_Grabo") = dr.Item("Usuario_Grabo").ToString
                ods.Tables("Conteos_Pendientes").Rows.Add(dr_aux)

            Next



            For Each dr In ods.Tables("Conteos_Pendientes").Rows

                ods.Tables("clientes_procesar").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
                If ods.Tables("clientes_procesar").DefaultView.Count = 0 Then
                    dr_aux = ods.Tables("clientes_procesar").NewRow
                    dr_aux.Item("empresa") = dr.Item("empresa")
                    dr_aux.Item("cod_cliente") = dr.Item("cod_cliente")
                    dr_aux.Item("Comentarios_reposicion") = dr.Item("Comentarios_reposicion").ToString
                    dr_aux.Item("Comentarios_factura") = dr.Item("Comentarios_factura").ToString
                    dr_aux.Item("Direccion_entrega_reposicion") = dr.Item("direccion_entrega_reposicion").ToString
                    dr_aux.Item("Direccion_entrega_factura") = dr.Item("direccion_entrega_factura").ToString
                    dr_aux.Item("bodega") = dr.Item("bodega").ToString
                    ods.Tables("clientes_procesar").Rows.Add(dr_aux)
                End If

            Next

            For Each dr In ods.Tables("clientes_procesar").Rows
                ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "empresa = '" & dr.Item("empresa").ToString & "' and cod_cliente = '" & dr.Item("cod_cliente").ToString & "'"
                Crear_Documento_Consignacion_Factura_Flex(ods.Tables("conteos_pendientes").DefaultView, dr.Item("cod_cliente").ToString,
                    dr.Item("Comentarios_reposicion").ToString, dr.Item("Comentarios_factura").ToString,
                    dr.Item("Direccion_entrega_reposicion").ToString, dr.Item("Direccion_entrega_factura").ToString, dr.Item("Bodega").ToString)
            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
            ClsGen = Nothing
        End Try

        Return True

    End Function

    Private Function obtenerBodegaConsignacion(psEmpresa As String, psCodigoCliente As String) As String

        Dim lsBodega As String = "CONSIGNACIONES"



        Return lsBodega
    End Function




    Private Function Obtener_Saldo_Consignacion_Actual(ByVal _empresa As String, ByVal _producto As String, ByVal _cliente As String, psBodega As String) As Integer
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_Sql As String
        Dim saldo_actual As Integer = 0

        Try
            otrans.open()
            ls_Sql = "pa_sel_um_consignaciones_saldos_cliente '" & _cliente & "','" & _empresa & "','" & _producto & "'"
            If psBodega = "REN_CONSIGNACIONES" Then
                ls_Sql = "pa_sel_um_consignaciones_saldos_cliente_ren '" & _cliente & "','" & _empresa & "','" & _producto & "'"
            End If

            dt = otrans.Obtiene(ls_Sql)
            saldo_actual = dt.Rows(0).Item("Saldo")

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try
        Return saldo_actual
    End Function

    Private Sub Crear_Documento_Consignacion_Factura_Flex(ByVal _dv As DataView, ByVal _cod_cliente As String,
                ByVal _comentario_consignacion As String, ByVal _comentario_factura As String,
                ByVal _direccion_entrega_consignacion As String, ByVal _direccion_entrega_factura As String,
                ByVal psBodega As String)

        Dim Oflex As New Umbral_Flex.Pedidos(True)
        Dim Oflex_Facturar As New Umbral_Flex.Pedidos(True)
        Dim Oflex_producto As New Umbral_Flex.productos
        Dim OtransCorp As New Transaccional.Conexion("Corporativo")
        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dr, dr2, drf As DataRow
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim li_secuencia As Integer = 0
        Dim li_secuenciaFactura As Integer = 0
        Dim ls_filtro As String = ""
        Dim dc As DataColumn
        Dim lsMoneda As String = Obtener_Moneda(_dv(0).Item("empresa").ToString)
        'Dim lubicacion As String = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString


        Try
            Otrans.open()

            Oflex.Consignaciones = True
            Oflex.Limpiar_Datos()
            Oflex.Validar_Totales = False

            Oflex_Facturar.Consignaciones = True
            Oflex_Facturar.Limpiar_Datos()
            Oflex_Facturar.Validar_Totales = True

            dt = Obtener_Cliente(_dv(0).Item("empresa").ToString, _cod_cliente)

            dr = Oflex.ods.Tables("encabezado").NewRow()

            dr.Item("empresa") = _dv(0).Item("empresa").ToString
            dr.Item("tipodocto") = "SOLICITUD CONSIGNACION"
            dr.Item("correlativo") = 0
            dr.Item("numero") = "" 'El Numero Lo Agregara Cuando se Guarde el Pedido
            dr.Item("fecha") = Today
            dr.Item("Cliente") = _cod_cliente
            dr.Item("Bodega") = "CD_CENTRAL"
            dr.Item("Bodega2") = psBodega ' "CONSIGNACIONES" (c) 20180629
            dr.Item("vendedor") = dt.Rows(0).Item("Ejecutivo").ToString
            dr.Item("FechaVcto") = Today '"Pendiente Establecer"
            dr.Item("listaprecio") = dt.Rows(0).Item("ListaPrecio").ToString
            dr.Item("Moneda") = lsMoneda
            dr.Item("Paridad") = 1
            dr.Item("Neto") = 0
            dr.Item("SubTotal") = 0
            dr.Item("Total") = 0
            dr.Item("NetoIngreso") = 0
            dr.Item("SubTotalIngreso") = 0
            dr.Item("TotalIngreso") = 0
            dr.Item("aprobacion") = "P"
            dr.Item("PeriodoLibro") = Now.ToString("yyyyMM")
            dr.Item("FactorMonto") = 0
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = _cod_cliente
            dr.Item("Glosa") = _comentario_consignacion
            dr.Item("Direccion") = _direccion_entrega_consignacion
            dr.Item("comentario1") = "PDA- CON"
            dr.Item("Vigencia") = "S"
            dr.Item("Emitido") = "N"
            dr.Item("PorcentajeAsignado") = 0
            dr.Item("FechaModif") = Now
            dr.Item("FechaUModif") = Now
            dr.Item("UsuarioModif") = _dv(0).Item("usuario_grabo").ToString
            dr.Item("Hora") = Now.ToString("HH:mm:ss")
            dr.Item("NetoBimoneda") = 0
            dr.Item("SubTotalBimoneda") = 0
            dr.Item("TotalBimoneda") = 0
            dr.Item("ParidadBimoneda") = 1
            dr.Item("AnalisisE3") = "30/12/1899"
            dr.Item("AnalisisE7") = ""
            Oflex.ods.Tables("encabezado").Rows.Add(dr)


            'Ods.Tables("Conteos_Pendientes").DefaultView.RowFilter = "cod_cliente = '" & _cod_cliente & "'"
            For Each drv In _dv 'Ods.Tables("Conteos_Pendientes").DefaultView
                If drv.Item("cantidad_consignar") > 0 Then

                    dr = Oflex.ods.Tables("detalle").NewRow()


                    li_secuencia += 1
                    dr.Item("Empresa") = drv.Item("empresa").ToString
                    dr.Item("TipoDocto") = "SOLICITUD CONSIGNACION"
                    dr.Item("Correlativo") = 0
                    dr.Item("secuencia") = li_secuencia
                    dr.Item("Linea") = li_secuencia
                    dr.Item("producto") = drv.Item("cod_producto")
                    dr.Item("cantidad") = drv.Item("cantidad_consignar")

                    dt = Oflex_producto.Obtener_Precio_Final(drv.Item("empresa").ToString, drv.Item("cod_producto").ToString, _cod_cliente)
                    Try
                        dr.Item("precio") = dt.Rows(0).Item("valor")
                        dr.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                    Catch ex As Exception
                        dr.Item("precio") = 0
                    End Try

                    dr.Item("PorcentajeDr") = 0
                    dr.Item("SubTotal") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                    dr.Item("Neto") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("Impuesto") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                    dr.Item("DrGlobal") = 0

                    dt = Oflex_producto.Obtener_Producto(drv.Item("empresa").ToString, drv.Item("cod_producto"))
                    Try
                        dr.Item("Costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                    Catch ex As Exception
                        dr.Item("Costo") = 0
                    End Try



                    dr.Item("total") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("PrecioAjustado") = Round(dr.Item("precio") / 1.12, 6)
                    dr.Item("UnidadIngreso") = "UN"
                    dr.Item("CantidadIngreso") = drv.Item("cantidad_consignar")
                    dr.Item("PrecioIngreso") = dr.Item("precio")
                    dr.Item("SubTotalIngreso") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                    dr.Item("ImpuestoIngreso") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                    dr.Item("NetoIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("DrGlobalIngreso") = 0
                    dr.Item("TotalIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                    dr.Item("CorrelativoOrigen") = 0
                    dr.Item("SecuenciaOrigen") = 0
                    dr.Item("Bodega") = "CD_CENTRAL"
                    dr.Item("FactorInventario") = 0
                    dr.Item("FechaEntrega") = Today
                    dr.Item("CantidadAsignada") = 0
                    dr.Item("fecha") = Today
                    dr.Item("Comentario") = ""
                    dr.Item("Vigente") = "S"
                    dr.Item("CUP") = dr.Item("Costo")
                    dr.Item("Ubicacion") = "PRINCIPAL"
                    dr.Item("Ubicacion2") = "PRINCIPAL"
                    dr.Item("Cuenta") = ""
                    dr.Item("FactorImpto") = Round(1 / 1.12, 6)
                    dr.Item("PrecioBimoneda") = dr.Item("precio")
                    dr.Item("SubTotalBimoneda") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                    dr.Item("ImpuestoBimoneda") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                    dr.Item("NetoBimoneda") = dr.Item("Neto")
                    dr.Item("DrGlobalBimoneda") = 0
                    dr.Item("TotalBimoneda") = dr.Item("Neto")
                    dr.Item("PrecioListaP") = dr.Item("Precio")
                    dr.Item("UniMedDynamic") = 0
                    dr.Item("LoteDestino") = ""
                    dr.Item("SerieDestino") = ""
                    dr.Item("ProdAlias") = ""
                    dr.Item("DoctoOrigenVal") = "N"
                    dr.Item("MontoAsignado") = 0


                    dr2 = dr
                    Oflex.ods.Tables("detalle").Rows.Add(dr)

                    dr2 = Oflex.ods.Tables("detalle").NewRow()
                    For Each dc In Oflex.ods.Tables("detalle").Columns
                        dr2.Item(dc) = dr.Item(dc)
                    Next


                    dr2.Item("Secuencia") = dr2.Item("Secuencia") * -1
                    dr2.Item("Linea") = dr2.Item("Linea") * -1
                    dr2.Item("Cantidad") = dr2.Item("Cantidad") * -1
                    dr2.Item("SubTotal") = dr2.Item("SubTotal") * -1
                    dr2.Item("Impuesto") = dr2.Item("Impuesto") * -1
                    dr2.Item("Neto") = dr2.Item("Neto") * -1
                    dr2.Item("Total") = dr2.Item("Total") * -1
                    dr2.Item("CantidadIngreso") = dr2.Item("CantidadIngreso") * -1
                    dr2.Item("SubTotalIngreso") = dr2.Item("SubTotalIngreso") * -1
                    dr2.Item("ImpuestoIngreso") = dr2.Item("ImpuestoIngreso") * -1
                    dr2.Item("NetoIngreso") = dr2.Item("NetoIngreso") * -1
                    dr2.Item("TotalIngreso") = dr2.Item("TotalIngreso") * -1
                    dr2.Item("Bodega") = psBodega '"CONSIGNACIONES" (c) 20180629
                    dr2.Item("CUP") = System.DBNull.Value
                    dr2.Item("Ubicacion2") = System.DBNull.Value
                    dr2.Item("FactorImpto") = System.DBNull.Value
                    dr2.Item("PrecioBimoneda") = dr2.Item("PrecioBimoneda") * -1
                    dr2.Item("SubTotalBimoneda") = dr2.Item("SubTotalBimoneda") * -1
                    dr2.Item("ImpuestoBimoneda") = dr2.Item("ImpuestoBimoneda") * -1
                    dr2.Item("NetoBimoneda") = dr2.Item("NetoBimoneda") * -1
                    dr2.Item("TotalBimoneda") = dr2.Item("TotalBimoneda") * -1
                    dr2.Item("PrecioListaP") = dr2.Item("PrecioListaP") * -1
                    dr2.Item("FechaVigenciaLp") = System.DBNull.Value
                    dr2.Item("DoctoOrigenVal") = System.DBNull.Value
                    dr2.Item("MontoAsignado") = System.DBNull.Value
                    Oflex.ods.Tables("detalle").Rows.Add(dr2)

                End If




                If drv.Item("cantidad_facturar") > 0 Then

                    ''Genero El Detalle de la Solicitud de Facturacion
                    dt = Obtener_Consignacion_Facturar(_cod_cliente,
                                                    drv.Item("cod_producto"),
                                                    drv.Item("cantidad_facturar"), _dv(0).Item("empresa").ToString,
                                                    IIf(drv.Item("empresa").ToString = "DIVINOS", "NOTA DE REMISION", "CONSIGNACIONES"),
psBodega)

                    For Each drf In dt.Rows ' Ods.Tables("detalle_facturar").Rows


                        li_secuenciaFactura += 1
                        dr = Oflex_Facturar.ods.Tables("detalle").NewRow()

                        dr.Item("Empresa") = _dv(0).Item("empresa").ToString
                        dr.Item("TipoDocto") = "FACTURAR CONSIGNACION"
                        dr.Item("Correlativo") = 0
                        dr.Item("secuencia") = li_secuenciaFactura
                        dr.Item("Linea") = li_secuenciaFactura
                        dr.Item("producto") = drv.Item("cod_producto")

                        dr.Item("cantidad") = drf.Item("cantidad")  ''debo establecer cuanto se va a facturar

                        dr.Item("precio") = 0
                        dt = Oflex_producto.Obtener_Precio_Final(_dv(0).Item("empresa").ToString, drv.Item("cod_producto").ToString, _cod_cliente)
                        Try
                            dr.Item("precio") = dt.Rows(0).Item("valor")
                            dr.Item("FechaVigenciaLp") = dt.Rows(0).Item("fec_inicio").ToString
                        Catch ex As Exception
                        End Try

                        dr.Item("PorcentajeDr") = 0
                        dr.Item("SubTotal") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                        dr.Item("Neto") = Round(dr.Item("SubTotal") / 1.12, 6)
                        dr.Item("Impuesto") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                        dr.Item("DrGlobal") = 0

                        dt = Oflex_producto.Obtener_Producto(_dv(0).Item("empresa").ToString, drv.Item("cod_producto"))
                        Try
                            dr.Item("Costo") = Double.Parse(dt.Rows(0).Item("costo").ToString)
                        Catch ex As Exception
                            dr.Item("Costo") = 0
                        End Try
                        dr.Item("total") = Round(dr.Item("SubTotal") / 1.12, 6)
                        dr.Item("PrecioAjustado") = Round(dr.Item("precio") / 1.12, 6)
                        dr.Item("UnidadIngreso") = "UN"

                        dr.Item("CantidadIngreso") = drf.Item("cantidad")

                        dr.Item("PrecioIngreso") = dr.Item("precio")
                        dr.Item("SubTotalIngreso") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                        dr.Item("ImpuestoIngreso") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                        dr.Item("NetoIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)
                        dr.Item("DrGlobalIngreso") = 0
                        dr.Item("TotalIngreso") = Round(dr.Item("SubTotal") / 1.12, 6)

                        dr.Item("TipoDoctoOrigen") = drf.Item("TipoDoctoOrigen").ToString
                        dr.Item("CorrelativoOrigen") = drf.Item("CorrelativoOrigen").ToString
                        dr.Item("SecuenciaOrigen") = drf.Item("SecuenciaOrigen").ToString

                        dr.Item("Bodega") = "CONSIGNACIONES"
                        dr.Item("FactorInventario") = 0
                        dr.Item("FechaEntrega") = Today
                        dr.Item("CantidadAsignada") = 0
                        dr.Item("fecha") = Today
                        dr.Item("Comentario") = ""
                        dr.Item("Vigente") = "S"
                        dr.Item("CUP") = dr.Item("Costo")
                        dr.Item("Ubicacion") = "PRINCIPAL"
                        dr.Item("Ubicacion2") = "PRINCIPAL"
                        dr.Item("Cuenta") = ""
                        dr.Item("FactorImpto") = Round(1 / 1.12, 6)
                        dr.Item("PrecioBimoneda") = dr.Item("precio")
                        dr.Item("SubTotalBimoneda") = Round(dr.Item("precio") * dr.Item("cantidad"), 6)
                        dr.Item("ImpuestoBimoneda") = Round(dr.Item("SubTotal") - dr.Item("Neto"), 6)
                        dr.Item("NetoBimoneda") = dr.Item("Neto")
                        dr.Item("DrGlobalBimoneda") = 0
                        dr.Item("TotalBimoneda") = dr.Item("Neto")
                        dr.Item("PrecioListaP") = dr.Item("Precio")
                        dr.Item("UniMedDynamic") = 0
                        dr.Item("LoteDestino") = ""
                        dr.Item("SerieDestino") = ""
                        dr.Item("ProdAlias") = ""
                        dr.Item("DoctoOrigenVal") = "N"
                        dr.Item("MontoAsignado") = 0
                        Oflex_Facturar.ods.Tables("detalle").Rows.Add(dr)
                    Next ''Facturacion
                End If


            Next
            ''Encabezado de Facturacion

            dt = Obtener_Cliente(_dv(0).Item("empresa").ToString, _cod_cliente)
            dr = Oflex_Facturar.ods.Tables("encabezado").NewRow()

            dr.Item("empresa") = _dv(0).Item("empresa").ToString
            dr.Item("tipodocto") = "FACTURAR CONSIGNACION"
            dr.Item("correlativo") = 0
            dr.Item("numero") = "" 'El Numero Lo Agregara Cuando se Guarde el Pedido
            dr.Item("fecha") = Today
            dr.Item("Cliente") = _cod_cliente
            dr.Item("Bodega") = "CONSIGNACIONES"
            dr.Item("Bodega2") = "CONSIGNACIONES"
            dr.Item("vendedor") = dt.Rows(0).Item("Ejecutivo").ToString
            dr.Item("FechaVcto") = Today '"Pendiente Establecer"
            dr.Item("listaprecio") = dt.Rows(0).Item("ListaPrecio").ToString
            dr.Item("Moneda") = lsMoneda
            dr.Item("Paridad") = 1
            dr.Item("Neto") = 0
            dr.Item("SubTotal") = 0
            dr.Item("Total") = 0
            dr.Item("NetoIngreso") = 0
            dr.Item("SubTotalIngreso") = 0
            dr.Item("TotalIngreso") = 0
            dr.Item("aprobacion") = "S"
            dr.Item("PeriodoLibro") = Now.ToString("yyyyMM")
            dr.Item("FactorMonto") = 0
            dr.Item("TipoCtaCte") = "CLIENTE"
            dr.Item("IdCtaCte") = _cod_cliente
            dr.Item("Glosa") = ""
            dr.Item("comentario1") = "PDA- CON " & _comentario_factura
            dr.Item("direccion") = _direccion_entrega_factura
            dr.Item("Vigencia") = "S"
            dr.Item("Emitido") = "N"
            dr.Item("PorcentajeAsignado") = 0
            dr.Item("FechaModif") = Now
            dr.Item("FechaUModif") = Now
            dr.Item("UsuarioModif") = _dv(0).Item("usuario_grabo").ToString
            dr.Item("Hora") = Now.ToString("HH:mm:ss")
            dr.Item("NetoBimoneda") = 0
            dr.Item("SubTotalBimoneda") = 0
            dr.Item("TotalBimoneda") = 0
            dr.Item("ParidadBimoneda") = 1
            dr.Item("AnalisisE3") = "30/12/1899"
            dr.Item("AnalisisE7") = ""
            Oflex_Facturar.ods.Tables("encabezado").Rows.Add(dr)



            ''actualizo encabezado Solicitud
            ls_filtro = "linea > 0"

            Try
                Oflex.ods.Tables("encabezado").Rows(0).Item("neto") = Oflex.ods.Tables("detalle").Compute("sum(neto)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotal") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotal)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("Total") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotal") 'Round(Oflex.ods.Tables("detalle").Compute("sum(Total)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("NetoIngreso") = Oflex.ods.Tables("detalle").Compute("sum(NetoIngreso)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotalIngreso)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("TotalIngreso") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") ''Round(Oflex.ods.Tables("detalle").Compute("sum(TotalIngreso)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("NetoBimoneda") = Oflex.ods.Tables("detalle").Compute("sum(NetoBimoneda)", ls_filtro)
                Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") = Round(Oflex.ods.Tables("detalle").Compute("sum(SubTotalBimoneda)", ls_filtro), 2)
                Oflex.ods.Tables("encabezado").Rows(0).Item("TotalBimoneda") = Oflex.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") 'Round(Oflex.ods.Tables("detalle").Compute("sum(TotalBimoneda)", ls_filtro), 2)

            Catch ex As Exception
                Otrans.Escribir_Log("Solicitud Consignacion")
                Otrans.Escribir_Log(ex.Message)
                Otrans.Escribir_Log(ex.ToString)
            End Try

            Try

                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("neto") = Oflex_Facturar.ods.Tables("detalle").Compute("sum(neto)", ls_filtro)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotal") = Round(Oflex_Facturar.ods.Tables("detalle").Compute("sum(SubTotal)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("Total") = Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotal") 'Round(Oflex.ods.Tables("detalle").Compute("sum(Total)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("NetoIngreso") = Oflex_Facturar.ods.Tables("detalle").Compute("sum(NetoIngreso)", ls_filtro)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") = Round(Oflex_Facturar.ods.Tables("detalle").Compute("sum(SubTotalIngreso)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("TotalIngreso") = Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") ''Round(Oflex.ods.Tables("detalle").Compute("sum(TotalIngreso)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("NetoBimoneda") = Oflex_Facturar.ods.Tables("detalle").Compute("sum(NetoBimoneda)", ls_filtro)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") = Round(Oflex_Facturar.ods.Tables("detalle").Compute("sum(SubTotalBimoneda)", ls_filtro), 2)
                Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("TotalBimoneda") = Oflex_Facturar.ods.Tables("encabezado").Rows(0).Item("SubTotalBimoneda") 'Round(Oflex.ods.Tables("detalle").Compute("sum(TotalBimoneda)", ls_filtro), 2)
            Catch ex As Exception
                Otrans.Escribir_Log("Facturar Consignacion")
                Otrans.Escribir_Log(ex.Message)
                Otrans.Escribir_Log(ex.ToString)
            End Try


            ''(c) Debo Identificar a que consignaciones se va a rebajar el total
            ls_filtro = ""
            'For Each dr In Oflex.ods.Tables("detalle").Rows
            '    If dr.Item("linea") > 0 Then

            '        Obtener_Consignacion_Facturar(_cod_cliente, _
            '                                                dr.Item("producto"), _
            '                                                dr.Item("cantidad"), _dv(0).Item("empresa").ToString)
            '    End If

            'Next

            ' Oflex.ods.Tables("encabezado").Rows(0).Item("Comentario1") = "PDA- Prueba IT **No Facturar*** " & ls_filtro

            Dim liCorrelativoGeneradoConsignacion As Integer = 0
            Dim liCorrelativoGeneradoFacturaCosignacion As Integer = 0

            Try
                liCorrelativoGeneradoConsignacion = Oflex.Guardar_Documento()

            Catch ex As Exception

            End Try
            Try
                liCorrelativoGeneradoFacturaCosignacion = Oflex_Facturar.Guardar_Documento()
            Catch ex As Exception

            End Try


            '(c) 20180702 Generar Correo de Confirmacion



            Try

            Catch ex As Exception

            End Try



            OtransCorp.open()

            For Each drv In _dv 'Ods.Tables("Conteos_Pendientes").DefaultView
                OtransCorp.Actualiza("pa_upd_um_mov_consignacion_conteo_detalle_proceso " &
                                    drv.Item("cod_empresa").ToString & ",'" &
                                    drv.Item("cod_cliente").ToString & "','" &
                                    drv.Item("cod_producto").ToString & "'," &
                                    drv.Item("cod_conteo").ToString & ",1")
            Next
            OtransCorp.close()


            If liCorrelativoGeneradoConsignacion > 0 Then
                Dim clsGen As New ClasesGenerales.General
                Try

                    '(c) 20151911 Enviar Correo Informando que se proceso el pedido


                    Dim lsBodyMail, sBody As String
                    Dim iCount As Integer

                    Dim dtPedido As DataTable
                    Dim dtPedidoDetalle As DataTable
                    Dim lsUsuarioGrabo As String = ""



                    lsBodyMail = String.Empty
                    iCount = 0

                    sBody = String.Empty
                    For Each drvConsignacion As DataRowView In Oflex.ods.Tables("encabezado").DefaultView


                        lsUsuarioGrabo = drvConsignacion.Item("usuarioModif").ToString
                        iCount += 1

                        sBody = sBody & "<tr></tr><tr>"
                        sBody = sBody & "</tr>"
                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Empresa</td><td>" & drvConsignacion.Item("Empresa").ToString & "</td>"
                        sBody = sBody & "</tr><tr>"

                        Try

                            sBody = sBody & "<td>Consignacion</td><td>" & drvConsignacion.Item("tipodocto").ToString & "-" & drvConsignacion.Item("Numero").ToString & "</td>"

                            dtPedido = clsGen.selectQuery("FlexLine", "pa_var_um_documento '" & drvConsignacion.Item("Empresa").ToString &
                                                "','" & drvConsignacion.Item("tipodocto").ToString & "','" & drvConsignacion.Item("Numero").ToString & "'")


                            dtPedidoDetalle = clsGen.selectQuery("FlexLine", "pa_var_um_valida_documento_encabezado_detalle_consignacion '" & drvConsignacion.Item("Empresa").ToString &
                                                "','" & drvConsignacion.Item("tipodocto").ToString & "','" & drvConsignacion.Item("Numero").ToString & "'")



                        Catch ex As Exception
                        End Try

                        sBody = sBody & "</tr><tr>"

                        Try
                            If dtPedidoDetalle.Rows.Count > 0 Then
                                sBody = sBody & "<td>Unidades Consignar</td><td>" & dtPedidoDetalle.Rows(0).Item("Cantidad").ToString & "</td>"
                            End If
                        Catch ex As Exception

                        End Try

                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Total</td><td>" & drvConsignacion.Item("Total").ToString & "</td>"
                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Comentario</td><td>" & drvConsignacion.Item("Comentario1").ToString & "</td>"
                        sBody = sBody & "<td> </td><td>" & drvConsignacion.Item("glosa").ToString & "</td>"

                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Cliente</td><td>" & drvConsignacion.Item("cliente").ToString


                        Try
                            sBody = sBody & " -- " & dtPedido.Rows(0).Item("razonsocial").ToString
                        Catch ex As Exception
                        End Try
                        sBody = sBody & "</td>"
                        sBody = sBody & "</tr><tr><td></td><td></td></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                    Next






                    For Each drvConsignacion As DataRowView In Oflex_Facturar.ods.Tables("encabezado").DefaultView


                        lsUsuarioGrabo = drvConsignacion.Item("usuarioModif").ToString
                        iCount += 1

                        sBody = sBody & "<tr></tr><tr>"
                        sBody = sBody & "</tr>"
                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "</tr><tr>"

                        Try

                            sBody = sBody & "<td>Facturar Consignacion</td><td>" & drvConsignacion.Item("tipodocto").ToString & "-" & drvConsignacion.Item("Numero").ToString & "</td>"



                            dtPedidoDetalle = clsGen.selectQuery("FlexLine", "pa_var_um_valida_documento_encabezado_detalle_consignacion '" & drvConsignacion.Item("Empresa").ToString &
                                                "','" & drvConsignacion.Item("tipodocto").ToString & "','" & drvConsignacion.Item("Numero").ToString & "'")

                        Catch ex As Exception

                        End Try

                        sBody = sBody & "</tr><tr>"
                        If dtPedidoDetalle.Rows.Count > 0 Then
                            sBody = sBody & "<td>Unidades Facturar</td><td>" & dtPedidoDetalle.Rows(0).Item("Cantidad").ToString & "</td>"
                        End If

                        sBody = sBody & "</tr><tr>"
                        sBody = sBody & "<td>Comentario</td><td>" & drvConsignacion.Item("Comentario1").ToString & "</td>"
                        sBody = sBody & "<td> </td><td>" & drvConsignacion.Item("glosa").ToString & "</td>"

                        sBody = sBody & "</tr><tr>"
                        'sBody = sBody & "<td>Cliente</td><td>" & drvConsignacion.Item("cliente").ToString
                        'sBody = sBody & "</td>"
                        sBody = sBody & "</tr><tr><td></td><td></td></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                        sBody = sBody & "<tr></tr><tr></tr>"
                    Next


                    ''Si Sbody lleva datos debo enviar correo de confirmacion de recepcion de Pedidos
                    If sBody.Length > 0 Then
                        lsBodyMail = "<table><font size=1>"

                        lsBodyMail = lsBodyMail & "<tr></tr><tr>"
                        lsBodyMail = lsBodyMail & "<td>Buen Dia </td><td>"
                        Dim dtUsuario As DataTable = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_simple '" & lsUsuarioGrabo & "'")

                        Try
                            lsBodyMail = lsBodyMail & StrConv(dtUsuario.Rows(0).Item("nombre").ToString, VbStrConv.ProperCase)
                        Catch ex As Exception

                        End Try
                        lsBodyMail = lsBodyMail & "</td>"
                        lsBodyMail = lsBodyMail & "</tr><tr>"
                        lsBodyMail = lsBodyMail & "<td>Le informamos que hemos procesado las siguientes Consignaciones: "
                        lsBodyMail = lsBodyMail & "</td>"
                        lsBodyMail = lsBodyMail & "</tr><tr>"

                        sBody = sBody & "</table>"
                        lsBodyMail = lsBodyMail + sBody

                        dtUsuario = clsGen.selectQuery("FlexLine", "pa_sel_um_sg_usuario_email '" & lsUsuarioGrabo & "'")

                        Try
                            Dim lsCuentaUsuario As String
                            Try
                                lsCuentaUsuario = dtUsuario.Rows(0).Item("correo").ToString
                                '& ",alfredo.saravia@umbralcorp.com,coscal@umbral.com.gt"
                            Catch ex As Exception
                                'lsCuentaUsuario = "alfredo.saravia@umbralcorp.com,coscal@umbral.com.gt"
                            End Try



                            clsGen.enviarcorreo("notificacion@umbralcorp.com", "Notificaciones Umbral",
                                                lsCuentaUsuario,
                                                "Confirmacion Recepcion de Consignaciones", lsBodyMail, "")
                            clsGen.Escribir_Log("Enviando Correo de Consignaciones a " & lsUsuarioGrabo.ToString)
                        Catch ex As Exception
                            clsGen.Escribir_Log(ex.Message)
                        End Try

                    End If
                    lsBodyMail = String.Empty


                Catch ex As Exception
                    clsGen.Escribir_Log(ex.Message)
                Finally

                    ClsGen = Nothing

                End Try
            End If



        Catch ex As Exception
            OtransCorp.Escribir_Log(ex.ToString)
        Finally
            OtransCorp = Nothing
            Oflex = Nothing
            Oflex_Facturar = Nothing

        End Try

    End Sub

    Private Function Obtener_Consignacion_Facturar(ByVal _cod_cliente As String,
                                                     ByVal _cod_producto As String,
                                                     ByVal _cantidad As Integer,
                                                     ByVal _empresa As String, ByVal ptipoDocto As String,
                                                   ByVal psBodega As String) As DataTable

        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim dt, dt2, dt3 As DataTable
        Dim dr As DataRow
        Dim drv, drv2 As DataRowView
        Dim ls_sql As String
        ' Dim ls_consignaciones5 As String = ""
        Dim nueva_cantidad As Integer = _cantidad
        Dim cantidad_asignada As Integer = 0

        dt3 = New DataTable("detalle_facturar")
        dt3.Columns.Add(New DataColumn("cod_Producto", GetType(String)))
        dt3.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt3.Columns.Add(New DataColumn("TipoDoctoOrigen", GetType(String)))
        dt3.Columns.Add(New DataColumn("CorrelativoOrigen", GetType(Integer)))
        dt3.Columns.Add(New DataColumn("SecuenciaOrigen", GetType(Integer)))
        'Ods.Tables("detalle_facturar").Rows.Clear()

        Try
            oTrans.open()
            ls_sql = "pa_sel_um_consignaciones_saldos NULL,'" & _empresa & "','" & _cod_cliente & "','" & _cod_producto & "'"
            If psBodega = "REN_CONSIGNACIONES" Then
                ls_sql = "pa_sel_um_consignaciones_saldos_re NULL,'" & _empresa & "','" & _cod_cliente & "','" & _cod_producto & "'"
            End If
            oTrans.Escribir_Log(ls_sql)

            dt = oTrans.Obtiene(ls_sql)
            dt.DefaultView.RowFilter = "Saldo > 0"
            For Each drv In dt.DefaultView
                If drv.Item("saldo") < nueva_cantidad Then
                    cantidad_asignada = drv.Item("saldo")
                    nueva_cantidad = nueva_cantidad - drv.Item("saldo")
                Else
                    cantidad_asignada = nueva_cantidad
                    nueva_cantidad = nueva_cantidad - drv.Item("saldo")
                End If
                If nueva_cantidad < 1 Then
                    nueva_cantidad = 0
                End If


                'ls_sql = "pa_sel_um_documentod '" & _empresa & "','" & ptipoDocto & "','" & drv.Item("con_numero") & "'"
                ls_sql = "pa_sel_um_documentod '" & _empresa & "','" & drv.Item("fd_tipor") & "','" & drv.Item("con_numero") & "'"
                dt2 = oTrans.Obtiene(ls_sql)
                dt2.DefaultView.RowFilter = "producto = '" & _cod_producto & "' and cantidad > 0 "
                If dt2.Rows.Count > 0 Then
                    drv2 = dt2.DefaultView(0)
                    dr = dt3.NewRow()
                    dr.Item("cod_producto") = _cod_producto
                    dr.Item("cantidad") = cantidad_asignada
                    dr.Item("TipoDoctoOrigen") = drv2.Item("tipodocto")  'ptipoDocto '"CONSIGNACIONES"
                    dr.Item("CorrelativoOrigen") = drv2.Item("correlativo")
                    dr.Item("SecuenciaOrigen") = drv2.Item("secuencia")
                    dt3.Rows.Add(dr)
                End If

                '                ls_consignaciones += " Consignacion No. " & drv.Item("con_numero").ToString & " Cantidad " & cantidad_asignada & "," & vbCrLf

                If nueva_cantidad < 1 Then
                    Exit For
                End If

            Next

        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing

        End Try
        Return dt3
    End Function
#End Region

    Private Function Obtener_Cliente(ByVal _empresa As String, ByVal _codigo As String) As DataTable
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As New DataTable

        Try
            Otrans.open()
            ls_sql = "pa_sel_um_ctacte '" & _empresa & "','CLIENTE','" & _codigo & "'"
            dt = Otrans.Obtiene(ls_sql)
            '            nombre_cliente = dt.Rows(0).Item("nombre_cliente").ToString




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
        Return dt

    End Function

    Private Function Obtener_Moneda(ByVal pempresa As String) As String
        Dim lsSQL As String
        Dim lsMoneda As String = String.Empty
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("Flexline")

        Try
            otrans.open()
            lsSQL = "pa_sel_um_gen_tabcod 'MONEDA','CONFIG.EMPRESA','" & pempresa & "'"
            dt = otrans.Obtiene(lsSQL)
            dt.TableName = "flexline_configuracion"
            lsMoneda = dt.Rows(0)("Texto")
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try
        Return lsMoneda

    End Function

    ''Generar_informacion Enterprise Edition
    Private Sub Generar_Informacion_Umbright_Mobile_EE()

        Dim dt As DataTable
        Dim drv As DataRowView
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim ClsGen As New ClasesGenerales.General

        Try
            myOtrans.open()
            dt = myOtrans.Obtiene("CALL pa_sel_um_sg_usuario_todos()")
            dt.DefaultView.RowFilter = "cod_tipo_usuario = 7"

            myOtrans.close()
            myOtrans = Nothing

            For Each drv In dt.DefaultView
                Generar_Informacion_Umbright_Mobile_EE_Usuario(drv.Item("usuario"), 8)
            Next

        Catch ex As Exception
            ClsGen.Escribir_Log("Generar Informacion UmbrightMobile EE " & ex.Message)
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub Generar_Informacion_Umbright_Mobile_EE_Usuario(ByVal psUsuarioActual As String, ByVal piProceso As Integer)

        Dim Osinc As New Sincronizacion.Preparar_Informacion_PDA
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Try
            myOtrans.open()
            Osinc.PDA_Generar_Informacion(psUsuarioActual)

            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf (" & piProceso.ToString & ")")
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Osinc = Nothing
        End Try

    End Sub

    Private Sub Generar_Informacion_Complementaria_Mobile_EE(ByVal pcod_proceso As Integer)
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Osinc As New Sincronizacion.Preparar_Informacion_PDA
        Dim ClsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim drv As DataRowView
        Dim ls_Sql As String


        Try
            myOtrans.open()

            dt = myOtrans.Obtiene("CALL pa_sel_um_sg_usuario_todos()")
            dt.DefaultView.RowFilter = "cod_tipo_usuario = 7 and email ='*'"
            'ls_Sql = "call pa_sel_um_edi_configuraciones (null)"
            'dt = myOtrans.Obtiene(ls_Sql)
            'dt.DefaultView.RowFilter = "tipo = 'Umbright Mobile Enterprise'"
            For Each drv In dt.DefaultView
                ls_Sql = Osinc.PDA_Generar_Informacion_Complementaria(drv.Item("usuario"))
                ClsGen.Mover_Archivo(ls_Sql, "C:\Aplicaciones\Umbright Mobile EE\Send\Log\" & ls_Sql.Split("\").GetValue(ls_Sql.Split("\").LongLength - 1))
            Next

            ls_Sql = "call pa_upd_um_pg_procesos_isf (" & pcod_proceso & ")"
            myOtrans.Actualiza(ls_Sql)
        Catch ex As Exception
        Finally

            ClsGen = Nothing
            myOtrans.close()
            myOtrans = Nothing
            Osinc = Nothing
        End Try


    End Sub

    Private Sub Generar_Informacion_Umbright_Mobile_SE(ByVal suarioEspecifico As String)



        Dim Osinc As New Sincronizacion.Preparar_Informacion_Umbright_Mobile_SE




        Try
            Osinc.PrepararInformacion_Umbright_Moble_SEGlobal("")

            Osinc.PrepararInformacion_tekne("")
            '(c)29032011 se comentario para generar informacion global en xml
            'Osinc.Preparar_Informacion_Umbright_Mobile_SE(suarioEspecifico)
            'Subir_Informacion_Umbright_Mobile_Standard()

        Catch ex As Exception

            '            ClsGen.Escribir_Log("Generar Informacion Mysysgold " & ex.Message)
        Finally

            Osinc = Nothing


        End Try
    End Sub

    Private Sub Subir_Informacion_Umbright_Mobile_Standard()
        Dim ClsFTP As ClasesGenerales.Manejo_FTP
        Dim archivo As String
        Dim Archivos() As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Ruta_Archivos As String = "c:\Aplicaciones\Umbright Mobile SE\Send\"
        Try

            ClsFTP = New ClasesGenerales.Manejo_FTP("Umbright_Mobile_SE", "Onbase")
            ClsFTP.FTP_CambiarDirectorio("cell")

            'Archivos = Directory.GetFiles(Ruta_Archivos, "*.txt")
            'For Each archivo In Archivos
            '    If ClsFTP.FTP_SubirArchivo(archivo) Then
            '        ClsGen.Mover_Archivo(archivo, Ruta_Archivos & "Log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))

            '    End If
            'Next
            ClsFTP.FTP_CambiarDirectorio("refresh")
            Archivos = Directory.GetFiles(Ruta_Archivos, "*.xml")
            For Each archivo In Archivos
                If ClsFTP.FTP_SubirArchivo(archivo) Then
                    ClsGen.Mover_Archivo(archivo, Ruta_Archivos & "Log\" & archivo.Split("\").GetValue(archivo.Split("\").LongLength - 1))

                End If
            Next
            ClsFTP.Finalizar()
        Finally
            ClsFTP = Nothing

            ClsGen = Nothing
        End Try
    End Sub

    Private Function Procesar_Log_Actividades55(ByVal pdr As DataRow) As Boolean
        Dim Proceso_Exitoso As Boolean = True
        Dim Otrans As New Transaccional.Conexion("SysGold")
        Dim ls_sql As String

        Try
            Otrans.open()
            ls_sql = "pa_ins_um_tiempos "
            If pdr.Item("modulo").ToString.ToLower.StartsWith("pedido") Then
                ls_sql += "1"
            ElseIf pdr.Item("modulo").ToString.ToLower.StartsWith("noventa") Then
                ls_sql += "7"
            ElseIf pdr.Item("modulo").ToString.ToLower.StartsWith("consig") Then
                ls_sql += "10"
            End If
            ls_sql += ",'" & DateTime.Parse(pdr.Item("fecha_actividad").ToString).ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                    DateTime.Parse(pdr.Item("fecha_final").ToString).ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                    pdr.Item("ctacte").ToString & pdr.Item("empresa").ToString.Substring(0, 3) & "','" &
                    pdr.Item("numero_pedido").ToString & "','" &
                    pdr.Item("usuario_sysgold").ToString & pdr.Item("empresa").ToString.Substring(0, 3) & "','','','',''"

            Otrans.Ingresa(ls_sql)
            If Otrans.Codigo_error > 0 Then
                Proceso_Exitoso = False
            End If

        Catch ex As Exception
            Proceso_Exitoso = False
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


        Return Proceso_Exitoso
    End Function

    Private Function Procesar_Log_Actividades(ByVal pdr As DataRow, ByVal dt As DataTable) As Boolean
        Dim Proceso_Exitoso As Boolean = True
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim ls_sql As String

        Try
            myOtrans.open()
            ls_sql = "call pa_ins_um_mov_log_visita ('" &
                    pdr.Item("empresa") & "','" &
                    pdr.Item("ctacte") & "','" &
                    DateTime.Parse(pdr.Item("fecha_actividad").ToString).ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                    DateTime.Parse(pdr.Item("fecha_final").ToString).ToString("yyyy-MM-dd HH:mm:ss") & "',"

            If pdr.Item("modulo").ToString.ToLower.StartsWith("pedido") Then
                ls_sql += "1,'" & pdr.Item("numero_pedido") & "','" & pdr.Item("ruta") & "',null,"
            ElseIf pdr.Item("modulo").ToString.ToLower.StartsWith("noventa") Then
                ls_sql += "2,NULL,'" & pdr.Item("ruta") & "',"
                dt.DefaultView.RowFilter = "empresa = '" & pdr.Item("empresa") & "' and ctacte = '" & pdr.Item("ctacte") & "'"
                If dt.DefaultView.Count > 0 Then
                    ls_sql += dt.DefaultView(0).Item("cod_motivo") & ","
                End If
            ElseIf pdr.Item("modulo").ToString.ToLower.StartsWith("consig") Then
                ls_sql += "3,NULL,'" & pdr.Item("ruta") & "',null,"
            End If
            ls_sql += "'" & pdr.Item("usuario_grabo") & "','" & pdr.Item("frecuencia") & "')"


            myOtrans.Ingresa(ls_sql)
            If myOtrans.Codigo_error > 0 Then
                Proceso_Exitoso = False
            End If

        Catch ex As Exception
            Proceso_Exitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
        End Try


        Return Proceso_Exitoso
    End Function

    Private Function Procesar_NoVenta(ByVal dr As DataRow) As Boolean
        Dim Proceso_Exitoso As Boolean = True
        Dim Otrans As New Transaccional.Conexion("SysGold")
        Dim ls_sql As String

        Try
            Otrans.open()
            ls_sql = "pa_ins_um_novisita '" & dr.Item("usuario_sysgold") & dr.Item("empresa").ToString.Substring(0, 3) & "','" &
                dr.Item("ctacte").ToString & dr.Item("empresa").ToString.Substring(0, 3) & "','" &
                DateTime.Parse(dr.Item("fecha").ToString).ToString("yyyy-MM-dd") & "','" &
                dr.Item("cod_motivo").ToString.PadLeft(2, "0") & "','" &
                DateTime.Parse(dr.Item("fecha").ToString).ToString("yyyy-MM-dd HH:mm:ss") & "'," &
                DateTime.Parse(dr.Item("fecha").ToString).ToString("ddHHmmss")
            Otrans.Ingresa(ls_sql)

            If Otrans.Codigo_error > 0 Then
                Proceso_Exitoso = False
            End If

        Catch ex As Exception
            Proceso_Exitoso = False
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        Return Proceso_Exitoso

    End Function

    Private Function Procesar_Inventario_Cliente(ByVal pdt As DataTable)
        Dim ls_sql As String
        Dim dr As DataRow
        Dim oTrans As New Transaccional.Conexion("sysgold")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")

        Try
            oTrans.open()
            myOtrans.open()

            For Each dr In pdt.Rows
                ls_sql = "pa_ins_um_cliinven '" & dr.Item("ctacte").ToString & dr.Item("empresa").ToString.Substring(0, 3) & " ','" &
                            dr.Item("usuario_sysgold") & dr.Item("empresa").ToString.Substring(0, 3) & "','" & dr.Item("producto").ToString & dr.Item("empresa").ToString.Substring(0, 3) & "'," &
                            dr.Item("existencia") & ",'" & DateTime.Parse(dr.Item("fecha_grabo").ToString).ToString("yyyy-MM-dd HH:mm:ss") & "'"

                oTrans.Ingresa(ls_sql)

                ls_sql = "call pa_ins_um_mov_inventario_cliente ('" & dr.Item("empresa") & "','" &
                                   dr.Item("ctacte") & "','" & dr.Item("producto") & "'," & dr.Item("existencia") & ",'" & dr.Item("usuario_grabo") & "')"
                myOtrans.Ingresa(ls_sql)

            Next


        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
        End Try
        Return True

    End Function


#End Region





#Region "EdiFact"
    'Private Sub obtener_pedidos_access_codicasa()
    '    Dim aOtrans As New Transaccional.Conexion_Access("edi_codicasa")
    '    Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
    '    Dim otrans As New Transaccional.Conexion("FlexLine")
    '    Dim oFlex As New Umbral_Flex.productos
    '    Dim dt As DataTable
    '    'Dim dr As DataRow
    '    Dim ls_sql, lsCodigoCliente, lsCodigoProducto, lsGlosa As String
    '    Dim ldPrecio As Double
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim odataset As New DataSet

    '    Try
    '        aOtrans.Open()
    '        myOtrans.open()
    '        otrans.open()


    '        If odataset.Tables.Contains("pedidos_detalle") Then odataset.Tables.Remove("pedidos_detalle")
    '        If odataset.Tables.Contains("pedidos") Then odataset.Tables.Remove("pedidos")
    '        If odataset.Tables.Contains("clientes") Then odataset.Tables.Remove("clientes")


    '        aOtrans.Nombre_Tabla = "Empresa_local"
    '        dt = aOtrans.Obtiene()
    '        dt.TableName = "clientes"
    '        odataset.Tables.Add(dt.Copy)

    '        aOtrans.Lista_Campos = "a.*"
    '        aOtrans.Nombre_Tabla = "Transaccion_detalle a, transaccion b"
    '        aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora > #" & Today.AddDays(-3).ToString("MM-dd-yyyy") & "#"
    '        'aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora < #06-08-2012#"
    '        ' myOtrans.Condiciones = ""
    '        dt = aOtrans.Obtiene()
    '        dt.TableName = "pedidos_detalle"
    '        odataset.Tables.Add(dt.Copy)

    '        aOtrans.Lista_Campos = "*"
    '        aOtrans.Nombre_Tabla = "Transaccion"
    '        aOtrans.Condiciones = "fechahora > #" & Today.AddDays(-3).ToString("MM-dd-yyyy") & "#"
    '        'aOtrans.Condiciones = "fechahora < #06-08-2012#"
    '        dt = aOtrans.Obtiene()
    '        dt.TableName = "pedidos"
    '        odataset.Tables.Add(dt.Copy)

    '        For Each dr As DataRow In odataset.Tables("clientes").Rows
    '            ls_sql = "call pa_ins_edi_cliente('CODICASA','" & dr.Item("idempresalocal") & "','" & dr.Item("idempresa") & "','" & dr.Item("GLN") & "','" & dr.Item("descripcion") & "','" & _
    '                 dr.Item("nombre") & "','" & dr.Item("direccion1") & "','" & dr.Item("direccion2") & "','" & dr.Item("direccion3") & "','" & _
    '                  dr.Item("ciudadmunicipio") & "','" & dr.Item("departamento") & "','" & dr.Item("codigopostal") & "','" & dr.Item("paisiso") & "','" & dr.Item("tipodestino") & "','" & dr.Item("nombrecontacto") & "')"
    '            myOtrans.Ingresa(ls_sql)

    '        Next

    '        For Each dr As DataRow In odataset.Tables("pedidos").Rows
    '            odataset.Tables("pedidos_detalle").DefaultView.RowFilter = " idTransaccion = '" & dr.Item("idTransaccion").ToString & "'"




    '            ls_sql = "call pa_sel_um_edi_cliente_encabezado ('CODICASA','" & dr.Item("idempresalocal") & "')"
    '            dt = myOtrans.Obtiene(ls_sql)

    '            lsCodigoCliente = String.Empty
    '            If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString


    '            ls_sql = "call pa_ins_edi_pedidos_encabezado('CODICASA','" & dr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" & _
    '                                                        dr.Item("idempresaproveedor") & "','" & dr.Item("idempresalocal") & "','" & _
    '                                                        dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & _
    '                                                        Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & _
    '                                                        dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" & _
    '                                                        dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" & _
    '                                                        dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" & _
    '                                                        dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" & _
    '                                                        dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
    '            myOtrans.Ingresa(ls_sql)
    '            If myOtrans.Codigo_error = 0 Then
    '                'Dim drv As DataRowView
    '                'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
    '                For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1


    '                    ls_sql = "pa_sel_um_prodcodbarra 'CODICASA',null,null,'" & drv2.Item("idproducto") & "'"
    '                    dt = otrans.Obtiene(ls_sql)

    '                    lsCodigoProducto = String.Empty
    '                    If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

    '                    lsGlosa = String.Empty
    '                    ldPrecio = 0
    '                    dt = oFlex.Obtener_Producto("CODICASA", lsCodigoProducto)
    '                    If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

    '                    dt = oFlex.Obtener_Precio_Final("CODICASA", lsCodigoProducto, lsCodigoCliente)
    '                    If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)

    '                    ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" & _
    '                                                    drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" & _
    '                                                    drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," & _
    '                                                    drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" & _
    '                                                    drv2.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" & _
    '                                                    lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ")"
    '                    myOtrans.Ingresa(ls_sql)
    '                Next
    '            End If
    '        Next
    '    Catch ex As System.Exception            '        
    '        ClsGen.Escribir_Log("Obtener Pedidos Codicasa" & ex.Message)
    '    Finally
    '        aOtrans.Close()
    '        aOtrans = Nothing
    '        myOtrans.close()
    '        myOtrans = Nothing
    '        otrans.close()
    '        otrans = Nothing
    '        oFlex.close()
    '        oFlex = Nothing
    '        ClsGen = Nothing
    '    End Try

    'End Sub

    'Private Sub obtener_pedidos_access_dmarte(ByVal ipProceso As Integer)
    '    Dim aOtrans As New Transaccional.Conexion_Access("edi_dmarte")
    '    Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
    '    Dim otrans As New Transaccional.Conexion("FlexLine")
    '    Dim oFlex As New Umbral_Flex.productos
    '    Dim dt, dtCliente As DataTable
    '    Dim ls_sql, lsCodigoCliente, lsCodigoProducto, lsGlosa As String
    '    Dim ldPrecio As Double
    '    Dim ClsGen As New ClasesGenerales.General
    '    Dim odataset As New DataSet


    '    Try
    '        aOtrans.Open()
    '        myOtrans.open()
    '        otrans.open()



    '        If odataset.Tables.Contains("pedidos_detalle") Then odataset.Tables.Remove("pedidos_detalle")
    '        If odataset.Tables.Contains("pedidos") Then odataset.Tables.Remove("pedidos")
    '        If odataset.Tables.Contains("clientes") Then odataset.Tables.Remove("clientes")

    '        aOtrans.Nombre_Tabla = "Empresa_local"
    '        dt = aOtrans.Obtiene()
    '        dt.TableName = "clientes"
    '        odataset.Tables.Add(dt.Copy)

    '        aOtrans.Lista_Campos = "a.*"
    '        aOtrans.Nombre_Tabla = "Transaccion_detalle a, transaccion b"
    '        'aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora < #06-07-2012#"
    '        aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora > #" & Today.AddDays(-3).ToString("MM-dd-yyyy") & "#"
    '        dt = aOtrans.Obtiene()
    '        dt.TableName = "pedidos_detalle"
    '        odataset.Tables.Add(dt.Copy)

    '        aOtrans.Lista_Campos = "*"
    '        aOtrans.Nombre_Tabla = "Transaccion"
    '        'aOtrans.Condiciones = "fechahora < #06-07-2012#"
    '        aOtrans.Condiciones = "fechahora > #" & Today.AddDays(-3).ToString("MM-dd-yyyy") & "#"
    '        dt = aOtrans.Obtiene()
    '        dt.TableName = "pedidos"
    '        odataset.Tables.Add(dt.Copy)

    '        For Each dr As DataRow In odataset.Tables("clientes").Rows
    '            ls_sql = "call pa_ins_edi_cliente('DMARTE1','" & dr.Item("idempresalocal") & "','" & dr.Item("idempresa") & "','" & dr.Item("GLN") & "','" & dr.Item("descripcion") & "','" & _
    '                    dr.Item("nombre") & "','" & dr.Item("direccion1") & "','" & dr.Item("direccion2") & "','" & dr.Item("direccion3") & "','" & _
    '                    dr.Item("ciudadmunicipio") & "','" & dr.Item("departamento") & "','" & dr.Item("codigopostal") & "','" & dr.Item("paisiso") & "','" & dr.Item("tipodestino") & "','" & dr.Item("nombrecontacto") & "')"

    '            myOtrans.Ingresa(ls_sql)
    '        Next



    '        For Each dr As DataRow In odataset.Tables("pedidos").Rows

    '            ls_sql = "call pa_sel_um_edi_cliente_encabezado ('DMARTE1','" & dr.Item("idempresalocal") & "')"
    '            dt = myOtrans.Obtiene(ls_sql)

    '            lsCodigoCliente = String.Empty
    '            If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString


    '            ls_sql = "call pa_ins_edi_pedidos_encabezado('DMARTE1','" & dr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" & _
    '                                                        dr.Item("idempresaproveedor") & "','" & dr.Item("idempresalocal") & "','" & _
    '                                                        dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & _
    '                                                        Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & _
    '                                                        dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" & _
    '                                                        dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" & _
    '                                                        dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" & _
    '                                                        dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" & _
    '                                                        dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
    '            myOtrans.Ingresa(ls_sql)
    '            If myOtrans.Codigo_error = 0 Then

    '                odataset.Tables("pedidos_detalle").DefaultView.RowFilter = " idTransaccion = '" & dr.Item("idTransaccion").ToString & "'"
    '                '              Dim drv As DataRowView
    '                '               drv = odataset.Tables("pedidos_detalle").DefaultView(0)
    '                For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView

    '                    ls_sql = "pa_sel_um_prodcodbarra 'DMARTE1',null,null,'" & drv2.Item("idproducto") & "'"
    '                    dt = otrans.Obtiene(ls_sql)

    '                    lsCodigoProducto = String.Empty
    '                    If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

    '                    lsGlosa = String.Empty
    '                    ldPrecio = 0
    '                    dt = oFlex.Obtener_Producto("DMARTE1", lsCodigoProducto)
    '                    If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

    '                    dt = oFlex.Obtener_Precio_Final("DMARTE1", lsCodigoProducto, lsCodigoCliente)

    '                    If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)


    '                    ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" & _
    '                                                    drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" & _
    '                                                    drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," & _
    '                                                    drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" & _
    '                                                    drv2.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" & _
    '                                                    lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ")"
    '                    myOtrans.Ingresa(ls_sql)

    '                Next
    '            End If
    '        Next
    '        myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & ipProceso.ToString & ")")

    '    Catch ex As System.Exception            '        
    '        ClsGen.Escribir_Log("obtener_pedidos_access_dmarte " & ex.Message)
    '    Finally
    '        aOtrans.Close()
    '        aOtrans = Nothing
    '        myOtrans.close()
    '        myOtrans = Nothing
    '        otrans.close()

    '        otrans = Nothing
    '        ClsGen = Nothing
    '        oFlex.close()
    '        oFlex = Nothing
    '    End Try

    'End Sub

    Private Sub obtener_pedidos_access_codicasa_21022013(ByVal ipProceso As Integer)
        Dim aOtrans As New Transaccional.Conexion_Access("edi_codicasa")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt As DataTable
        'Dim dr As DataRow
        Dim ls_sql, lsCodigoCliente, lsCodigoProducto, lsGlosa As String
        Dim ldPrecio As Double
        Dim ClsGen As New ClasesGenerales.General
        Dim odataset As New DataSet
        Dim cruceanden As String = ""


        Try
            aOtrans.Open()
            myOtrans.open()
            otrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & ipProceso.ToString & ")")

            If odataset.Tables.Contains("pedidos_detalle") Then odataset.Tables.Remove("pedidos_detalle")
            If odataset.Tables.Contains("pedidos") Then odataset.Tables.Remove("pedidos")
            If odataset.Tables.Contains("clientes") Then odataset.Tables.Remove("clientes")


            aOtrans.Nombre_Tabla = "Empresa_local"
            dt = aOtrans.Obtiene()
            dt.TableName = "clientes"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "a.*"
            aOtrans.Nombre_Tabla = "Transaccion_detalle a, transaccion b"
            aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora > #" & Today.AddDays(-3).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora < #06-08-2012#"
            ' myOtrans.Condiciones = ""
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos_detalle"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "*"
            aOtrans.Nombre_Tabla = "Transaccion"
            aOtrans.Condiciones = "fechahora > #" & Today.AddDays(-3).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "fechahora < #06-08-2012#"
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos"
            odataset.Tables.Add(dt.Copy)

            For Each dr As DataRow In odataset.Tables("clientes").Rows
                ls_sql = "call pa_ins_edi_cliente('CODICASA','" & dr.Item("idempresalocal") & "','" & dr.Item("idempresa") & "','" & dr.Item("GLN") & "','" & dr.Item("descripcion") & "','" &
                     dr.Item("nombre") & "','" & dr.Item("direccion1") & "','" & dr.Item("direccion2") & "','" & dr.Item("direccion3") & "','" &
                      dr.Item("ciudadmunicipio") & "','" & dr.Item("departamento") & "','" & dr.Item("codigopostal") & "','" & dr.Item("paisiso") & "','" & dr.Item("tipodestino") & "','" & dr.Item("nombrecontacto") & "')"
                myOtrans.Ingresa(ls_sql)

            Next

            For Each dr As DataRow In odataset.Tables("pedidos").Rows

                odataset.Tables("pedidos_detalle").DefaultView.RowFilter = " idTransaccion = '" & dr.Item("idTransaccion").ToString & "'"
                ls_sql = "call pa_sel_um_edi_cliente_encabezado ('CODICASA','" & dr.Item("idempresalocal") & "')"
                dt = myOtrans.Obtiene(ls_sql)
                lsCodigoCliente = String.Empty
                If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString

                Dim dts As DataTable
                dts = odataset.Tables("pedidos_detalle").DefaultView.ToTable

                Dim dtaux As DataTable = ClsGen.ValoresDistinto(dts, "IdTransaccion,cruceAndenGLN,LugarEntregaGLN".Split(","))

                If dtaux.Rows.Count > 1 Then

                    For Each ddr As DataRow In dtaux.Rows
                        If ddr.Item("LugarEntregaGLN").ToString.Length > 0 Then
                            Dim dt_rows As DataTable

                            dt_rows = odataset.Tables("pedidos_detalle")
                            dt_rows.DefaultView.RowFilter = "LugarEntregaGLN = '" & ddr.Item("LugarEntregaGLN").ToString & "'"
                            ls_sql = "call pa_ins_edi_pedidos_encabezado('CODICASA','" & ddr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                           dr.Item("idempresaproveedor") & "','" & ddr.Item("LugarEntregaGLN") & "','" &
                                                           dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                           dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                           dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                           dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                           dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                            myOtrans.Ingresa(ls_sql)
                            If myOtrans.Codigo_error = 0 Then
                                'Dim drv As DataRowView
                                'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
                                For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1


                                    ls_sql = "pa_sel_um_prodcodbarra 'CODICASA',null,null,'" & drv2.Item("idproducto") & "'"
                                    dt = otrans.Obtiene(ls_sql)

                                    lsCodigoProducto = String.Empty
                                    If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                                    lsGlosa = String.Empty
                                    ldPrecio = 0
                                    dt = oFlex.Obtener_Producto("CODICASA", lsCodigoProducto)
                                    If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                                    dt = oFlex.Obtener_Precio_Final("CODICASA", lsCodigoProducto, lsCodigoCliente)
                                    If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)

                                    ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                                    drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                                    drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                                    drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                                    ddr.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                                    lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & ddr.Item("LugarEntregaGLN") & "')"
                                    myOtrans.Ingresa(ls_sql)
                                Next
                            End If

                        End If

                    Next

                Else

                    ls_sql = "call pa_ins_edi_pedidos_encabezado('CODICASA','" & dr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                                               dr.Item("idempresaproveedor") & "','" & dr.Item("idempresalocal") & "','" &
                                                                               dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                                               dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                                               dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                                               dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                                               dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error = 0 Then
                        'Dim drv As DataRowView
                        'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
                        For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1

                            ls_sql = "pa_sel_um_prodcodbarra 'CODICASA',null,null,'" & drv2.Item("idproducto") & "'"
                            dt = otrans.Obtiene(ls_sql)

                            lsCodigoProducto = String.Empty
                            If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                            lsGlosa = String.Empty
                            ldPrecio = 0
                            dt = oFlex.Obtener_Producto("CODICASA", lsCodigoProducto)
                            If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                            dt = oFlex.Obtener_Precio_Final("CODICASA", lsCodigoProducto, lsCodigoCliente)
                            If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)

                            cruceanden = ""

                            'If drv2.Item("cruceAndenGLN").ToString.Length > 1 Then
                            '    cruceanden = drv2.Item("cruceAndenGLN").ToString

                            'Else
                            cruceanden = dr.Item("idempresalocal").ToString
                            'End If

                            ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                            drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                            drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                            drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                            drv2.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                            lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & cruceanden & "')"
                            myOtrans.Ingresa(ls_sql)

                        Next
                    End If


                End If

            Next



        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener Pedidos Codicasa" & ex.Message)
        Finally
            aOtrans.Close()
            aOtrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            otrans.close()
            otrans = Nothing
            oFlex.close()
            oFlex = Nothing
            ClsGen = Nothing
        End Try

    End Sub



    Private Sub obtener_pedidos_access_codicasa(ByVal ipProceso As Integer)
        Dim aOtrans As New Transaccional.Conexion_Access("edi_codicasa")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt As DataTable
        'Dim dr As DataRow
        Dim ls_sql, lsCodigoCliente, lsCodigoProducto, lsGlosa As String
        Dim ldPrecio As Double
        Dim ClsGen As New ClasesGenerales.General
        Dim odataset As New DataSet
        Dim cruceanden As String = ""


        Try
            aOtrans.Open()
            myOtrans.open()
            otrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & ipProceso.ToString & ")")


            If odataset.Tables.Contains("pedidos_detalle") Then odataset.Tables.Remove("pedidos_detalle")
            If odataset.Tables.Contains("pedidos") Then odataset.Tables.Remove("pedidos")
            If odataset.Tables.Contains("clientes") Then odataset.Tables.Remove("clientes")


            aOtrans.Nombre_Tabla = "Empresa_local"
            dt = aOtrans.Obtiene()
            dt.TableName = "clientes"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "a.*"
            aOtrans.Nombre_Tabla = "Transaccion_detalle a, transaccion b"
            aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora > #" & Today.AddDays(-6).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora < #06-08-2012#"
            ' myOtrans.Condiciones = ""
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos_detalle"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "*"
            aOtrans.Nombre_Tabla = "Transaccion"
            aOtrans.Condiciones = "fechahora > #" & Today.AddDays(-6).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "fechahora < #06-08-2012#"
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos"
            odataset.Tables.Add(dt.Copy)


            For Each dr As DataRow In odataset.Tables("pedidos").Rows

                odataset.Tables("pedidos_detalle").DefaultView.RowFilter = " idTransaccion = '" & dr.Item("idTransaccion").ToString & "'"

                ls_sql = "call pa_sel_um_edi_cliente_encabezado ('CODICASA','" & dr.Item("idempresalocal") & "')"
                dt = myOtrans.Obtiene(ls_sql)
                lsCodigoCliente = String.Empty
                If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString

                Dim dts As DataTable
                dts = odataset.Tables("pedidos_detalle").DefaultView.ToTable

                Dim dtaux As DataTable = ClsGen.ValoresDistinto(dts, "IdTransaccion,cruceAndenGLN,LugarEntregaGLN".Split(","))

                If dtaux.Rows.Count > 1 Then 'Reparticion, Varias Ordenes con el Mismo Numero y Diferente Tienda

                    For Each ddr As DataRow In dtaux.Rows
                        If ddr.Item("LugarEntregaGLN").ToString.Length > 0 Then
                            Dim dt_rows As DataTable

                            dt_rows = odataset.Tables("pedidos_detalle")
                            dt_rows.DefaultView.RowFilter = "LugarEntregaGLN = '" & ddr.Item("LugarEntregaGLN").ToString & "'"
                            ls_sql = "call pa_ins_edi_pedidos_encabezado('CODICASA','" & ddr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                           dr.Item("idempresaproveedor") & "','" & ddr.Item("LugarEntregaGLN") & "','" &
                                                           dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                           dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                           dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                           dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                           dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                            myOtrans.Ingresa(ls_sql)


                            'If myOtrans.Codigo_error = 0 Then
                            'Dim drv As DataRowView
                            'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
                            For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1


                                ls_sql = "pa_sel_um_prodcodbarra 'CODICASA',null,null,'" & drv2.Item("idproducto") & "'"
                                dt = otrans.Obtiene(ls_sql)

                                lsCodigoProducto = String.Empty
                                If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                                lsGlosa = String.Empty
                                ldPrecio = 0
                                dt = oFlex.Obtener_Producto("CODICASA", lsCodigoProducto)
                                If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                                ''
                                ls_sql = "call pa_sel_um_edi_cliente_encabezado ('CODICASA','" & drv2.Item("LugarEntregaGLN") & "')"
                                dt = myOtrans.Obtiene(ls_sql)
                                lsCodigoCliente = String.Empty
                                If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString
                                ''

                                dt = oFlex.Obtener_Precio_Final("CODICASA", lsCodigoProducto, lsCodigoCliente)
                                If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)

                                ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                                drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                                drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                                drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                                ddr.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                                lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & ddr.Item("LugarEntregaGLN") & "')"
                                myOtrans.Ingresa(ls_sql)


                            Next
                            'End If

                        End If

                    Next



                Else


                    Dim glnLugarEntrega As String = String.Empty
                    If dtaux.Rows.Count = 1 Then
                        'If ddr.Item("LugarEntregaGLN") Then
                        If dr.Item("idempresalocal").ToString.Trim.Equals(dtaux.Rows(0).Item("LugarEntregaGLN").ToString.Trim) Then
                            glnLugarEntrega = dr.Item("idempresalocal").ToString.Trim
                        Else
                            glnLugarEntrega = dtaux.Rows(0).Item("LugarEntregaGLN").ToString.Trim
                        End If
                    End If




                    ls_sql = "call pa_ins_edi_pedidos_encabezado('CODICASA','" & dr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                                               dr.Item("idempresaproveedor") & "','" & glnLugarEntrega & "','" &
                                                                               dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                                               dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                                               dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                                               dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                                               dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error = 0 Then

                        For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1

                            ls_sql = "pa_sel_um_prodcodbarra 'CODICASA',null,null,'" & drv2.Item("idproducto") & "'"
                            dt = otrans.Obtiene(ls_sql)

                            lsCodigoProducto = String.Empty
                            If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                            lsGlosa = String.Empty
                            ldPrecio = 0
                            dt = oFlex.Obtener_Producto("CODICASA", lsCodigoProducto)
                            If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                            dt = oFlex.Obtener_Precio_Final("CODICASA", lsCodigoProducto, lsCodigoCliente)
                            If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)

                            cruceanden = ""
                            cruceanden = dr.Item("idempresalocal").ToString
                            cruceanden = glnLugarEntrega


                            ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                            drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                            drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                            drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                            drv2.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                            lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & cruceanden & "')"
                            myOtrans.Ingresa(ls_sql)

                        Next
                    End If


                End If

            Next



        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener Pedidos Codicasa" & ex.Message)
        Finally
            aOtrans.Close()
            aOtrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            otrans.close()
            otrans = Nothing
            oFlex.close()
            oFlex = Nothing
            ClsGen = Nothing
        End Try

    End Sub



    Private Sub obtener_pedidos_access_dmarte(ByVal ipProceso As Integer)
        Dim aOtrans As New Transaccional.Conexion_Access("edi_dmarte")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt As DataTable
        Dim ls_sql, lsCodigoCliente, lsCodigoProducto, lsGlosa As String
        Dim ldPrecio As Double
        Dim ClsGen As New ClasesGenerales.General
        Dim odataset As New DataSet
        Dim cruceanden As String = ""


        Try
            aOtrans.Open()
            myOtrans.open()
            otrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & ipProceso.ToString & ")")


            If odataset.Tables.Contains("pedidos_detalle") Then odataset.Tables.Remove("pedidos_detalle")
            If odataset.Tables.Contains("pedidos") Then odataset.Tables.Remove("pedidos")
            If odataset.Tables.Contains("clientes") Then odataset.Tables.Remove("clientes")


            aOtrans.Nombre_Tabla = "Empresa_local"
            dt = aOtrans.Obtiene()
            dt.TableName = "clientes"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "a.*"
            aOtrans.Nombre_Tabla = "Transaccion_detalle a, transaccion b"
            aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora > #" & Today.AddDays(-8).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora < #06-08-2012#"
            ' myOtrans.Condiciones = ""
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos_detalle"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "*"
            aOtrans.Nombre_Tabla = "Transaccion"
            aOtrans.Condiciones = "fechahora > #" & Today.AddDays(-8).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "fechahora < #06-08-2012#"
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos"
            odataset.Tables.Add(dt.Copy)

            For Each dr As DataRow In odataset.Tables("clientes").Rows
                ls_sql = "call pa_ins_edi_cliente('DMARTE1','" & dr.Item("idempresalocal") & "','" & dr.Item("idempresa") & "','" & dr.Item("GLN") & "','" & dr.Item("descripcion") & "','" &
                     dr.Item("nombre") & "','" & dr.Item("direccion1") & "','" & dr.Item("direccion2") & "','" & dr.Item("direccion3") & "','" &
                      dr.Item("ciudadmunicipio") & "','" & dr.Item("departamento") & "','" & dr.Item("codigopostal") & "','" & dr.Item("paisiso") & "','" & dr.Item("tipodestino") & "','" & dr.Item("nombrecontacto") & "')"
                myOtrans.Ingresa(ls_sql)

            Next

            For Each dr As DataRow In odataset.Tables("pedidos").Rows

                odataset.Tables("pedidos_detalle").DefaultView.RowFilter = " idTransaccion = '" & dr.Item("idTransaccion").ToString & "'"
                ls_sql = "call pa_sel_um_edi_cliente_encabezado ('DMARTE1','" & dr.Item("idempresalocal") & "')"
                dt = myOtrans.Obtiene(ls_sql)
                lsCodigoCliente = String.Empty
                If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString

                Dim dts As DataTable
                dts = odataset.Tables("pedidos_detalle").DefaultView.ToTable

                Dim dtaux As DataTable = ClsGen.ValoresDistinto(dts, "IdTransaccion,cruceAndenGLN,LugarEntregaGLN".Split(","))

                If dtaux.Rows.Count > 1 Then 'Reparticion, Varias Ordenes con el Mismo Numero y Diferente Tienda

                    For Each ddr As DataRow In dtaux.Rows
                        If ddr.Item("LugarEntregaGLN").ToString.Length > 0 Then
                            Dim dt_rows As DataTable

                            dt_rows = odataset.Tables("pedidos_detalle")
                            dt_rows.DefaultView.RowFilter = "LugarEntregaGLN = '" & ddr.Item("LugarEntregaGLN").ToString & "'"
                            ls_sql = "call pa_ins_edi_pedidos_encabezado('DMARTE1','" & ddr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                           dr.Item("idempresaproveedor") & "','" & ddr.Item("LugarEntregaGLN") & "','" &
                                                           dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                           dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                           dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                           dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                           dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                            myOtrans.Ingresa(ls_sql)
                            'If myOtrans.Codigo_error = 0 Then
                            'Dim drv As DataRowView
                            'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
                            For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1


                                ls_sql = "pa_sel_um_prodcodbarra 'DMARTE1',null,null,'" & drv2.Item("idproducto") & "'"
                                dt = otrans.Obtiene(ls_sql)

                                lsCodigoProducto = String.Empty
                                If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                                lsGlosa = String.Empty
                                ldPrecio = 0
                                dt = oFlex.Obtener_Producto("DMARTE1", lsCodigoProducto)
                                If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                                dt = oFlex.Obtener_Precio_Final("DMARTE1", lsCodigoProducto, lsCodigoCliente)
                                If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)

                                ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                                drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                                drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                                drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                                ddr.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                                lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & ddr.Item("LugarEntregaGLN") & "')"
                                myOtrans.Ingresa(ls_sql)
                            Next
                            'End If

                        End If

                    Next


                Else

                    ls_sql = "call pa_ins_edi_pedidos_encabezado('DMARTE1','" & dr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                                               dr.Item("idempresaproveedor") & "','" & dr.Item("idempresalocal") & "','" &
                                                                               dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                                               dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                                               dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                                               dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                                               dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error = 0 Then
                        'Dim drv As DataRowView
                        'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
                        For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1

                            ls_sql = "pa_sel_um_prodcodbarra 'DMARTE1',null,null,'" & drv2.Item("idproducto") & "'"
                            dt = otrans.Obtiene(ls_sql)

                            lsCodigoProducto = String.Empty
                            If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                            lsGlosa = String.Empty
                            ldPrecio = 0
                            dt = oFlex.Obtener_Producto("DMARTE1", lsCodigoProducto)
                            If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                            dt = oFlex.Obtener_Precio_Final("DMARTE1", lsCodigoProducto, lsCodigoCliente)
                            If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)


                            cruceanden = ""
                            cruceanden = dr.Item("idempresalocal").ToString


                            ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                            drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                            drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                            drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                            drv2.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                            lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & cruceanden & "')"
                            myOtrans.Ingresa(ls_sql)

                        Next
                    End If


                End If

            Next



        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener Pedidos Dmarte" & ex.Message)
        Finally
            aOtrans.Close()
            aOtrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            otrans.close()
            otrans = Nothing
            oFlex.close()
            oFlex = Nothing
            ClsGen = Nothing
        End Try
    End Sub



    Private Sub obtener_pedidos_access_diuva(ByVal ipProceso As Integer)
        Dim aOtrans As New Transaccional.Conexion_Access("edi_diuva")
        Dim myOtrans As New Transaccional.Conexion_mysql("onbase")
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos
        Dim dt As DataTable
        Dim ls_sql, lsCodigoCliente, lsCodigoProducto, lsGlosa As String
        Dim ldPrecio As Double
        Dim ClsGen As New ClasesGenerales.General
        Dim odataset As New DataSet
        Dim cruceanden As String = ""


        Try
            aOtrans.Open()
            myOtrans.open()
            otrans.open()
            myOtrans.Actualiza("call pa_upd_um_pg_procesos_isf  (" & ipProceso.ToString & ")")


            If odataset.Tables.Contains("pedidos_detalle") Then odataset.Tables.Remove("pedidos_detalle")
            If odataset.Tables.Contains("pedidos") Then odataset.Tables.Remove("pedidos")
            If odataset.Tables.Contains("clientes") Then odataset.Tables.Remove("clientes")


            aOtrans.Nombre_Tabla = "Empresa_local"
            dt = aOtrans.Obtiene()
            dt.TableName = "clientes"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "a.*"
            aOtrans.Nombre_Tabla = "Transaccion_detalle a, transaccion b"
            aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora > #" & Today.AddDays(-10).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "a.idtransaccion = b.idtransaccion and b.fechahora < #06-08-2012#"
            ' myOtrans.Condiciones = ""
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos_detalle"
            odataset.Tables.Add(dt.Copy)

            aOtrans.Lista_Campos = "*"
            aOtrans.Nombre_Tabla = "Transaccion"
            aOtrans.Condiciones = "fechahora > #" & Today.AddDays(-10).ToString("MM-dd-yyyy") & "#"
            'aOtrans.Condiciones = "fechahora < #06-08-2012#"
            dt = aOtrans.Obtiene()
            dt.TableName = "pedidos"
            odataset.Tables.Add(dt.Copy)

            For Each dr As DataRow In odataset.Tables("clientes").Rows
                ls_sql = "call pa_ins_edi_cliente('DIUVA','" & dr.Item("idempresalocal") & "','" & dr.Item("idempresa") & "','" & dr.Item("GLN") & "','" & dr.Item("descripcion") & "','" &
                     dr.Item("nombre") & "','" & dr.Item("direccion1") & "','" & dr.Item("direccion2") & "','" & dr.Item("direccion3") & "','" &
                      dr.Item("ciudadmunicipio") & "','" & dr.Item("departamento") & "','" & dr.Item("codigopostal") & "','" & dr.Item("paisiso") & "','" & dr.Item("tipodestino") & "','" & dr.Item("nombrecontacto") & "')"
                myOtrans.Ingresa(ls_sql)

            Next

            For Each dr As DataRow In odataset.Tables("pedidos").Rows

                odataset.Tables("pedidos_detalle").DefaultView.RowFilter = " idTransaccion = '" & dr.Item("idTransaccion").ToString & "'"
                ls_sql = "call pa_sel_um_edi_cliente_encabezado ('DIUVA','" & dr.Item("idempresalocal") & "')"
                dt = myOtrans.Obtiene(ls_sql)
                lsCodigoCliente = String.Empty
                If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString

                Dim dts As DataTable
                dts = odataset.Tables("pedidos_detalle").DefaultView.ToTable

                Dim dtaux As DataTable = ClsGen.ValoresDistinto(dts, "IdTransaccion,cruceAndenGLN,LugarEntregaGLN".Split(","))

                If dtaux.Rows.Count > 1 Then

                    For Each ddr As DataRow In dtaux.Rows
                        If ddr.Item("LugarEntregaGLN").ToString.Length > 0 Then
                            Dim dt_rows As DataTable

                            dt_rows = odataset.Tables("pedidos_detalle")
                            dt_rows.DefaultView.RowFilter = "LugarEntregaGLN = '" & ddr.Item("LugarEntregaGLN").ToString & "'"
                            ls_sql = "call pa_ins_edi_pedidos_encabezado('DIUVA','" & ddr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                           dr.Item("idempresaproveedor") & "','" & ddr.Item("LugarEntregaGLN") & "','" &
                                                           dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                           dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                           dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                           dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                           dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                           dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                            myOtrans.Ingresa(ls_sql)
                            If myOtrans.Codigo_error = 0 Then
                                'Dim drv As DataRowView
                                'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
                                For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1


                                    ls_sql = "pa_sel_um_prodcodbarra 'DIUVA',null,null,'" & drv2.Item("idproducto") & "'"
                                    dt = otrans.Obtiene(ls_sql)

                                    lsCodigoProducto = String.Empty
                                    If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                                    lsGlosa = String.Empty
                                    ldPrecio = 0
                                    dt = oFlex.Obtener_Producto("DIUVA", lsCodigoProducto)
                                    If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                                    ls_sql = "call pa_sel_um_edi_cliente_encabezado ('CODICASA','" & drv2.Item("LugarEntregaGLN") & "')"
                                    dt = myOtrans.Obtiene(ls_sql)
                                    lsCodigoCliente = String.Empty
                                    If dt.Rows.Count = 1 Then lsCodigoCliente = dt.Rows(0).Item("ctacte").ToString

                                    dt = oFlex.Obtener_Precio_Final("DIUVA", lsCodigoProducto, lsCodigoCliente)
                                    If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)

                                    ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                                    drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                                    drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                                    drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                                    ddr.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                                    lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & ddr.Item("LugarEntregaGLN") & "')"
                                    myOtrans.Ingresa(ls_sql)
                                Next
                            End If

                        End If

                    Next

                Else ''Solo 1 Lugar de Entrega

                    Dim glnLugarEntrega As String = String.Empty
                    If dtaux.Rows.Count = 1 Then
                        'If ddr.Item("LugarEntregaGLN") Then
                        If dr.Item("idempresalocal").ToString.Trim.Equals(dtaux.Rows(0).Item("LugarEntregaGLN").ToString.Trim) Then
                            glnLugarEntrega = dr.Item("idempresalocal").ToString.Trim
                        Else
                            glnLugarEntrega = dtaux.Rows(0).Item("LugarEntregaGLN").ToString.Trim
                        End If
                    End If

                    ls_sql = "call pa_ins_edi_pedidos_encabezado('DIUVA','" & dr.Item("idtransaccion") & "','" & dr.Item("idempresacadena") & "','" &
                                                                               dr.Item("idempresaproveedor") & "','" & glnLugarEntrega & "','" &
                                                                               dr.Item("idempresalocalproveedor") & "','" & Date.Parse(dr.Item("fechahora").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               Date.Parse(dr.Item("fechahoraentrega").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & Date.Parse(dr.Item("fechahoravencimiento").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" &
                                                                               dr.Item("tipoorden") & "','" & dr.Item("observaciones") & "','" &
                                                                               dr.Item("departamentoventas") & "','" & dr.Item("referenciadepromocion") & "','" &
                                                                               dr.Item("monedaiso") & "','" & dr.Item("pagoterminos") & "','" & dr.Item("pagoreferencia") & "','" &
                                                                               dr.Item("pagoperiodos") & "','" & dr.Item("pagofecha") & "'," & dr.Item("montodescuento") & ",'" &
                                                                               dr.Item("status") & "','" & Date.Parse(dr.Item("fechahoraenviado").ToString).ToString("yyyy-MM-dd hh:ss:mm") & "','" & dr.Item("usuariotransaccion") & "')"
                    myOtrans.Ingresa(ls_sql)
                    If myOtrans.Codigo_error = 0 Then
                        'Dim drv As DataRowView
                        'drv = odataset.Tables("pedidos_detalle").DefaultView(0)
                        For Each drv2 As DataRowView In odataset.Tables("pedidos_detalle").DefaultView '. Count '- 1

                            ls_sql = "pa_sel_um_prodcodbarra 'DIUVA',null,null,'" & drv2.Item("idproducto") & "'"
                            dt = otrans.Obtiene(ls_sql)

                            lsCodigoProducto = String.Empty
                            If dt.Rows.Count = 1 Then lsCodigoProducto = dt.Rows(0)("producto").ToString

                            lsGlosa = String.Empty
                            ldPrecio = 0
                            dt = oFlex.Obtener_Producto("DIUVA", lsCodigoProducto)
                            If dt.Rows.Count = 1 Then lsGlosa = dt.Rows(0).Item("Glosa")

                            dt = oFlex.Obtener_Precio_Final("DIUVA", lsCodigoProducto, lsCodigoCliente)
                            If dt.Rows.Count > 0 And dt.Rows.Count < 5 Then ldPrecio = Round(dt.Rows(0).Item("Valor") / 1.12, 4)


                            cruceanden = ""
                            cruceanden = dr.Item("idempresalocal").ToString
                            cruceanden = glnLugarEntrega

                            ls_sql = "call pa_ins_um_edi_pedido_detalle('" & drv2.Item("idtransaccion") & "','" & drv2.Item("idproducto") & "','" &
                                                            drv2.Item("GTIN13") & "','" & drv2.Item("GTIN14") & "','" & drv2.Item("descripcion") & "','" &
                                                            drv2.Item("idproductoproveedor") & "'," & drv2.Item("cantidadunidades") & "," & drv2.Item("bonificacionunidades") & "," &
                                                            drv2.Item("costonegociado") & ",'" & drv2.Item("empaquecantidadcontenida") & "','" & drv2.Item("empaquetipo") & "','" &
                                                            drv2.Item("cruceAndenGLN") & "','" & drv2.Item("cruceAndenDividir") & "','" & drv2.Item("idcomprador") & "','" &
                                                            lsCodigoProducto & "','" & lsGlosa & "'," & ldPrecio & ",'" & cruceanden & "')"
                            myOtrans.Ingresa(ls_sql)
                        Next
                    End If
                End If
            Next

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Obtener Pedidos DIUVA" & ex.Message)
        Finally
            aOtrans.Close()
            aOtrans = Nothing
            myOtrans.close()
            myOtrans = Nothing
            otrans.close()
            otrans = Nothing
            oFlex.close()
            oFlex = Nothing
            ClsGen = Nothing
        End Try
    End Sub





#End Region


    Private Sub subirPedidosBazar()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oDS As New DataSet
        Dim ls_sql As String
        Dim dt As DataTable
        Dim liCod_Pedido As Integer
        Dim lbExitoso As Boolean = True

        Try
            myOtrans.open()
            Otrans.open()

            ls_sql = "pa_var_um_pedidos_bazar_encabezado"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "encabezado"
            oDS.Tables.Add(dt.Copy)

            ls_sql = "pa_var_um_pedidos_bazar_detalle"
            dt = Otrans.Obtiene(ls_sql)
            dt.TableName = "pedidos_detalle"
            oDS.Tables.Add(dt.Copy)

            For Each dr_encabezado As DataRow In oDS.Tables("encabezado").Rows


                With dr_encabezado
                    ls_sql = "call pa_ins_um_mov_pedidos_encabezado ('" &
                            .Item("empresa").ToString & "','" & .Item("numero_pedido").ToString & "','" &
                            .Item("ctacte").ToString & "','" & .Item("forma_pago").ToString & "'," &
                            .Item("total_pedido").ToString & "," & .Item("total_lineas").ToString & ",'" &
                            DateTime.Parse(.Item("fecha_pedido").ToString).ToString("yyyy-MM-dd HH:mm") & "','" &
                            DateTime.Parse(.Item("fecha_entrega").ToString).ToString("yyyy-MM-dd") & "','"
                    If Not .Item("fecha_modifico") Is System.DBNull.Value Then


                        ls_sql += DateTime.Parse(.Item("fecha_modifico").ToString).ToString("yyyy-MM-dd HH:mm")
                    Else
                        ls_sql += "1900-01-01"
                    End If
                    ls_sql += "','"

                    ls_sql += .Item("comentarios").ToString & "','" &
                            .Item("usuario_grabo").ToString & "'," &
                            .Item("estado").ToString & ",'" &
                            .Item("ListaPrecio").ToString & "','" &
                            Now.ToString("yyyy-MM-dd HH:mm:ss") & "',"

                    Try
                        ls_sql += "'" & .Item("direccion_entrega").ToString.PadRight(100, " ").Substring(0, 100).Trim & "'"
                    Catch ex As Exception
                        ls_sql += "NULL"
                    End Try

                    ls_sql += ")"

                    '31/03/2011 Se Agrego Direccion de Entrega

                    myOtrans.Ingresa(ls_sql)

                    If myOtrans.Codigo_error = 0 Then
                        dt = myOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                        liCod_Pedido = dt.Rows(0).Item("newid").ToString
                        ls_sql = "empresa = '" & dr_encabezado.Item("empresa") & "' and numero_pedido = '" & dr_encabezado.Item("numero_pedido") & "'"

                        oDS.Tables("pedidos_detalle").DefaultView.RowFilter = ls_sql
                        oDS.Tables("pedidos_detalle").DefaultView.Sort = "Linea"

                        Dim LineaLocal As Integer = 0
                        For Each drv As DataRowView In oDS.Tables("pedidos_detalle").DefaultView
                            If drv.Item("numero_pedido") = dr_encabezado.Item("numero_pedido") Then
                                LineaLocal += 1
                                ls_sql = "call pa_ins_um_mov_pedidos_detalle (" & liCod_Pedido & "," &
                                        LineaLocal & ",'" & drv.Item("producto").ToString & "'," &
                                        drv.Item("Cantidad") & "," & drv.Item("precio") & "," &
                                        drv.Item("total_linea") & ")"
                                myOtrans.Ingresa(ls_sql)
                                If myOtrans.Codigo_error > 0 Then
                                    lbExitoso = False
                                End If
                            End If

                        Next
                    Else
                        If myOtrans.descripcion_error.ToLower.IndexOf("duplicate") > -1 Then
                            lbExitoso = True
                        Else
                            lbExitoso = False
                        End If

                    End If
                End With
            Next

        Catch ex As Exception
            lbExitoso = False
        Finally
            myOtrans.close()
            myOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try

        '  Return lbExitoso
    End Sub




    Private Sub Enviar_Informacion_Sitio_Tekne23(ByVal pRuta As String, ByVal dataUser As DataTable, ByVal dataFtp As DataTable)
        Dim ff As New FTP.clsFTP

        Dim archivos() As String
        '        Dim archivo As String
        '       Dim icount As Integer
        Dim ClsGen As New ClasesGenerales.General


        Try
            ClsGen.Escribir_Log("Enviando Informacion FTP Tekne  " & dataUser.Rows(0).Item("descripcion"))
            ff = New FTP.clsFTP

            ' Setup the appropriate properties.
            'ff.RemoteHost = data.Rows(0).Item("host") 'drv.Item("host")
            'ff.RemoteUser = data.Rows(0).Item("usuario") 'drv.Item("usuario")
            'ff.RemotePassword = data.Rows(0).Item("password") ' drv.Item("password")

            'ff.RemoteHost = "dmarte.com"
            'ff.RemoteUser = "dmarteco"
            'ff.RemotePassword = "02TwepX9f2"

            ff.RemoteHost = dataFtp.Rows(0).Item("host") 'drv.Item("host")
            ff.RemoteUser = dataFtp.Rows(0).Item("usuario") 'drv.Item("usuario")
            ff.RemotePassword = dataFtp.Rows(0).Item("password") ' drv.Item("password")

            If (ff.Login()) Then
                ff.ChangeDirectory("www/tekne/bd") 'drv.Item("carpeta").ToString)
                ff.ChangeDirectory(dataUser.Rows(0).Item("descripcion").ToString) 'drv.Item("descripcion").ToString)
                ff.SetBinaryMode(True)
                Try
                    archivos = ff.GetFileList("*.txt")
                Catch ex As Exception

                End Try
                Dim dimension As String = ""
                ff.UploadFile("C:\Aplicaciones\SQLITE\" & dataUser.Rows(0).Item("descripcion").ToString & "\tekne.sqlite")
                dimension = getTamFile("C:\Aplicaciones\SQLITE\" & dataUser.Rows(0).Item("descripcion").ToString & "\tekne.sqlite")
                ClsGen.Escribir_Log("Tamaño de Archivo Enviado: " & dimension)
            End If

        Catch ex As System.Exception            '        
            ClsGen.Escribir_Log("Envio de Informacion Warning " & dataUser.Rows(0).Item("descripcion").ToString)
            ClsGen.Escribir_Log("Message from FTP Server was: " & ff.MessageString)
        Finally
            ff.CloseConnection()
            ff = Nothing
            ClsGen = Nothing
        End Try
    End Sub



    Private Sub generarFacturaDTT()

        Dim Ods As New DataSet
        Dim dt As DataTable

        Dim Oflex As New Umbral_Flex.Pedidos(False, True)
        Oflex.Validar_Totales = True

        Dim osinc As New Sincronizacion.Recepcion_Informacion_PDA()
        'osinc.Llenar_Auxiliares(ods, drEncabezado.Item("ctacte"), s_empresa)
        osinc = Nothing
        Try



        Catch ex As Exception

        End Try
    End Sub
    ' Campos en la clase
    Private scheduledHours As Integer() = New Integer() {12, 14, 15, 16}
    Private lastRunDate As Date = Date.MinValue
    Private lastRunHour As Integer = -1

    Private Sub correorechazos()


        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt, dtEjecutivo As DataTable

        Try

            Dim oCorreosSeg As DataTable = clsGen.selectQuery("SCM",
                                                        String.Format("pa_var_um_credenciales_notificacion"))

            Dim lsfecha As String = DateTime.Today.ToString("dd-MM-yyyy")
            lsSQL = $"pa_um_sel_drivin_doctos_rechazados '{lsfecha}'"


            'lsSQL = "pa_um_sel_drivin_doctos_rechazados '19-11-2025'"
            dt = clsGen.selectQuery("Corporativo", lsSQL)

            dtEjecutivo = clsGen.ValoresDistinto(dt, "ejecutivo".Split(","))

            For Each drEjecutivo As DataRow In dtEjecutivo.Rows
                Try




                    Dim oDetalleRechazos As New List(Of Interfaz_CRM.Mail.RechazoEntrega)

                    dt.DefaultView.RowFilter = "ejecutivo = '" & drEjecutivo.Item("ejecutivo") & "'"


                    For Each dr As DataRowView In dt.DefaultView
                        ' Crear una instancia de RechazoEntrega y asignar los valores desde el DataRow
                        oDetalleRechazos.Add(New Interfaz_CRM.Mail.RechazoEntrega() With {
                            .tipoDocto = dr.Item("tipoDocto").ToString,
                            .Numero = dr.Item("Numero").ToString,
                            .controlTransporte = dr.Item("controlTransporte").ToString,
                            .fecha = DateTime.Parse(dr.Item("fecha").ToString),
                            .EstadoCliente = dr.Item("EstadoCliente").ToString,
                            .motivo = dr.Item("motivo").ToString,
                            .CodigoCliente = dr.Item("CodigoCliente").ToString + "-" + dr.Item("razonsocial").ToString,
                            .pdf_pod = dr.Item("pdf_pod").ToString,
                            .tracking_url = dr.Item("tracking_url").ToString,
                            .empresa = dr.Item("empresa").ToString,
                            .comentario_piloto = dr.Item("comentario_piloto").ToString,
                             .fecha_rechazo = DateTime.Parse(dr.Item("fecha_rechazo").ToString)
                        })

                    Next

                    Interfaz_CRM.Mail.MailRechazos.EnviarCorreoRechazos(
                        pUsuario:=dt.DefaultView(0).Item("nombre_ejecutivo").ToString,
                        pCorreo:="carlos.oscal@umbralcorp.com," & dt.DefaultView(0).Item("email").ToString & ",harold.garcia@logiservicios.com,jose.segura@umbralcorp.com," & dt.DefaultView(0).Item("email_supervisor").ToString,
                        lista:=oDetalleRechazos,
                        pUsermail:=oCorreosSeg.Rows(0).Item("mail").ToString,
                        pPwdmail:=oCorreosSeg.Rows(0).Item("pwd").ToString,
                        psOrigen:="DRIV.IN"
                    )

                Catch ex As Exception
                    clsGen.Escribir_Log("Error Envio Correo Rechazos Ejecutivo " & drEjecutivo.Item("ejecutivo") & " - " & ex.Message)

                End Try
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub corrreoreservas()


        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt, dtusuario As DataTable

        Try

            Dim oCorreosSeg As DataTable = clsGen.selectQuery("SCM",
                                                        String.Format("pa_var_um_credenciales_notificacion"))



            lsSQL = "pa_var_um_da_reserva_El_salvador"
            dt = clsGen.selectQuery("SCM", lsSQL)
            dt.DefaultView.RowFilter = "estatus = 'aprobada'"

            dtusuario = clsGen.ValoresDistinto(dt.DefaultView.ToTable, "usuario".Split(","))


            For Each drUsuario As DataRowView In dtusuario.DefaultView





                Dim oservas As New List(Of Interfaz_CRM.Mail.ReservaProducto)
                dt.DefaultView.RowFilter = "usuario = '" & drUsuario.Item("usuario") & "' and estatus = 'aprobada'"


                For Each dr As DataRowView In dt.DefaultView


                    oservas.Add(New Interfaz_CRM.Mail.ReservaProducto() With {
            .empresa = dr.Item("empresa"),
            .no_orden = dr.Item("no_orden"),
            .bodega = dr.Item("bodega"),
            .fecha = DateTime.Parse(dr.Item("fecha")),
            .dua = dr.Item("dua"),
            .proveedor = dr.Item("proveedor"),
            .usuario = dr.Item("usuario"),
            .fecha_hora_grabo = DateTime.Parse("28/08/2025 12:49"),
            .estatus = "APROBADA",
            .producto = dr.Item("producto"),
            .glosa = dr.Item("glosa"),
            .cantidad = dr.Item("cantidad"),
            .bultos = dr.Item("bultos"),
            .lote = dr.Item("lote")
        })
                Next



                ' Envío
                Interfaz_CRM.Mail.MailReservas.EnviarCorreoReservas(
    pUsuario:="Administrador",
    pCorreo:="carlos.oscal@umbralcorp.com",
    reservas:=oservas,
    pUsermail:=oCorreosSeg.Rows(0).Item("mail").ToString,
    pPwdmail:=oCorreosSeg.Rows(0).Item("pwd").ToString,
    psOrigen:="Umbright"
)

            Next
        Catch ex As Exception

            End Try

    End Sub


    '(c)20251210 se debe validar que los pedidos de bazar mobile esten correctos, esto porque deben cumpli con la unidad minima de venta

    Public Function Validar_Pedidos_Bazar_Mobile_Azzure() As DataTable



        Dim dt, dtdetalle, dtValidacion, dtAux As DataTable
        Dim dr As DataRow
        Dim lsSQL As String
        Dim lsNumeroPedido, lsTipoDocumento, lsCliente, lsComentarioRechazo As String
        Dim ClsGen As New ClasesGenerales.General
        Dim lbOrdenEdifact As Boolean = False
        Dim lstPedidos As New List(Of Interfaz_CRM.Mail.DTO.mov_pedidos_encabezado_mercaderistas)
        Dim sMonedaPago As String
        Dim sMaximoComentarios As Integer = 45
        Dim lsOrigen As String
        Dim liunidad_minima_venta As Integer
        Dim lbProcesar As Boolean = False
        Try

            lsSQL = "pa_var_um_mov_pedidos_encabezado_bazar"
            dt = ClsGen.selectQuery("RegionalDB", lsSQL)

            For Each dr In dt.Rows
                'si todo esta correcto se debe cambiar a estado 1
                'si una linea esta por fuera de la unidad minima de venta se debe cambiar llevar al multiplo anterior
                lsSQL = "pa_var_um_mov_pedidos_detalle_procesables " & dr.Item("cod_pedido").ToString
                dtdetalle = ClsGen.selectQuery("RegionalDB", lsSQL)
                dtdetalle.TableName = "pedidos_detalle"

                For Each drLinea As DataRow In dtdetalle.Rows

                    liunidad_minima_venta = 0
                    Try
                        lsSQL = "pa_var_um_producto_umv '" & dr.Item("empresa").ToString & "','" & drLinea.Item("cod_producto_flex").ToString & "'"
                        dtValidacion = ClsGen.selectQuery("SCM", lsSQL)
                        If dtValidacion.Rows.Count = 1 Then
                            liunidad_minima_venta = dtValidacion.Rows(0).Item("uxc")

                            If drLinea.Item("cantidad") Mod liunidad_minima_venta <> 0 Then
                                'tengo que ajustar la cantidad
                                Dim liCantidad_Ajustada As Integer
                                liCantidad_Ajustada = (drLinea.Item("cantidad") \ liunidad_minima_venta) * liunidad_minima_venta
                                lsSQL = "pa_upd_um_mov_pedidos_detalle_cantidad_ajustada " & drLinea.Item("Id").ToString & "," & liCantidad_Ajustada.ToString
                                ClsGen.insertQuery("RegionalDB", lsSQL)
                                'agregar comentario de ajuste
                                lsSQL = "pa_upd_um_mov_pedidos_detalle_comentario_ajuste " & drLinea.Item("Id").ToString & ",'Ajuste Automatico por Unidad Minima de Venta'"
                                ClsGen.insertQuery("RegionalDB", lsSQL)
                                'cambiar estado del pedido a rechazado 3
                                lsSQL = "pa_upd_um_mov_pedidos_encabezado_bazar " & dr.Item("cod_pedido").ToString & ",'" & dr.Item("empresa").ToString & "',3,'',''"
                                ClsGen.insertQuery("RegionalDB", lsSQL)

                            End If
                            lbProcesar = True
                        Else
                            lbProcesar = False
                        End If

                    Catch ex As Exception

                    End Try
                Next

                If lbProcesar Then
                    'todo esta correcto
                    lsSQL = "pa_upd_um_mov_Pedidos_encabezado " & dr.Item("cod_pedido").ToString & ",'" & dr.Item("empresa").ToString & "',1,'',''"
                    ClsGen.insertQuery("RegionalDB", lsSQL)
                End If

            Next

        Catch ex As Exception
        End Try
        Return dt
    End Function



    Private Sub frm_sincronizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Validar_Pedidos_Bazar_Mobile_Azzure

        '(c) 20230221 Factura Automatico los pedidos de vinoteca premium
        '(c) 20230221 Envio Correo de Consignaciones

        'corrreoreservas()
        correorechazos()
        Dim clsGen As New ClasesGenerales.General

        Try

            If clsGen.ValidarHorarioTareaRecurrenteAppConfig("ejecucion_laincondicional") Then




                clsGen.Escribir_Log("Compra Interempresa La Incodicional " & Now.Hour & " " & Now.Minute)
                Dim umbralflex As New Umbral_Flex.comprasInterempresa
                umbralflex.verificarStockLAINCONDICIONAL()

                umbralflex = Nothing

            End If



        Catch ex As Exception
        End Try


        Try

            clsGen.Escribir_Log("Generar_Pedidos_Umbright_Mobile")

            Generar_Pedidos_Umbright_Mobile()  'Proceso Generico

            Try
                If (Now.Minute Mod 10) < 4 Then

                    clsGen.Escribir_Log("Generar_Documentos_Consignaciones")
                    Dim umbralflex As New Umbral_Flex.consignaciones
                    umbralflex.Generar_Documentos_Consignaciones()
                    umbralflex = Nothing
                End If

            Catch ex As Exception
            End Try




        Catch ex As Exception
        End Try



        clsGen = Nothing
        Me.Close()

    End Sub

    '(c) 20230808
#Region "La Incondicional"


    Public Sub verificarStockLAINCONDICIONAL()

        '(c)
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim dtStock As DataTable
        Dim liPedir As Integer = 0
        Dim ods_listado As New DataSet
        Dim lsEmpresa As String = "LAINCONDI"
        Dim lsUsuario As String = "JESTRADA"

        Dim ods As New DataSet
        Dim sCedi As String
        Dim sCentrosDistribucion As String = "CD_CENTRAL"

        Try

            For Each sBodega As String In sCentrosDistribucion.Split(",")

                dt = clsGen.selectQuery("FlexLine", "pa_sel_um_usuario_bodega 'laincondi','SOLICITUD O/COMPRA','JESTRADA'")
                Dim pcomprador As String
                Dim ctacte As String
                If dt.Rows.Count > 0 Then
                    pcomprador = dt.Rows(0).Item("comprador")
                    ctacte = dt.Rows(0).Item("cliente")
                End If


                If sBodega = "CDR_ANTIGUA" Then
                    sCedi = "AG"
                    ctacte = "1187845402"
                ElseIf sBodega = "CDR_XELA" Then
                    sCedi = "XE"
                    ctacte = "1187845401"
                ElseIf sBodega = "CD_CENTRAL" Then
                    sCedi = ""
                    ctacte = "11878454"
                End If

                crear_estructura_auxiliar(ods, ods_listado, lsEmpresa)
                ods_listado.Tables("listado").Rows.Clear()

                'dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_laincondicional '" & Today.ToString("dd-MM-yyyy") & "'")
                dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_laincondicional_cedi '" & Today.ToString("dd-MM-yyyy") & "','" & sCedi & "'")

                For Each dr As DataRow In dt.Rows
                    liPedir = 0
                    dtStock = Oflex.Obtener_Existencias(lsEmpresa, dr.Item("producto"), sBodega)

                    If dtStock.Rows.Count > 0 Then
                        If dtStock.Rows(0).Item("existencia") = 0 Then
                            liPedir = dr.Item("cantidad")
                        ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
                            ''Pedir la diferencia
                            liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
                        End If
                    Else
                        'Pedir completo
                        liPedir = dr.Item("cantidad")
                    End If

                    '
                    If liPedir > 0 Then
                        Dim drAux As DataRow = ods_listado.Tables("listado").NewRow

                        drAux.Item("producto") = dr.Item("producto")
                        Try
                            drAux.Item("proveedor") = dtStock.Rows(0).Item("subfamilia")
                        Catch ex As Exception
                            Dim dtProducto As DataTable
                            dtProducto = Oflex.Obtener_Producto(lsEmpresa, dr.Item("producto"))
                            If dtProducto.Rows.Count > 0 Then
                                drAux.Item("proveedor") = dtProducto.Rows(0).Item("subfamilia")
                            End If
                        End Try
                        drAux.Item("sugerido") = liPedir
                        ods_listado.Tables("listado").Rows.Add(drAux)

                    End If
                Next

                If ods_listado.Tables("listado").Rows.Count > 0 Then
                    Dim dtProveedores As DataTable = clsGen.ValoresDistinto(ods_listado.Tables("listado"), "proveedor".Split(","))
                    For Each dr As DataRow In dtProveedores.Rows

                        Dim sEmpresaCompra As String

                        If dr.Item("proveedor") = "CODICASA" Then
                            sEmpresaCompra = "CODICASA"
                            'ctacte = "79512"
                        ElseIf dr.Item("proveedor") = "DISTRIBUIDORA MARTE" Then
                            sEmpresaCompra = "DMARTE1"
                            'ctacte = "122183"
                        ElseIf dr.Item("proveedor") = "DIUVA" Then
                            sEmpresaCompra = "DIUVA"
                            'ctacte = "6608388"
                        End If

                        Preparar_Factura(1, lsEmpresa, lsUsuario, dr.Item("proveedor"), "Reposicion Autogenerada " & Now.ToString("HH:mm"), ods, ods_listado, sBodega)


                        Dim aa As String
                        Try
                            Guardar_Documento(ods, sEmpresaCompra, ctacte, pcomprador, aa, lsUsuario)
                        Catch ex As Exception

                        End Try
                    Next
                End If

            Next
        Catch ex As Exception
        End Try


    End Sub


    Private Sub crear_estructura_auxiliar(ByRef ods As DataSet, ByRef ods_listado As DataSet, psEmpresa As String)
        Dim ls_sql As String

        Dim Otrans As New Transaccional.Conexion("FlexLine")

        Dim dt As DataTable

        Try
            Otrans.open()
            If Not ods.Tables.Contains("documento") Then

                ls_sql = "pa_var_um_documento_traslado_fecha '" & psEmpresa & "',NULL,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)

                dt.TableName = "documento"
                If ods.Tables.Contains("documento") Then
                    ods.Tables.Remove("documento")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documento").Rows.Clear()
            End If


            ''documentod
            If Not ods.Tables.Contains("documentod") Then
                ls_sql = "pa_var_um_documentod_traslado_fecha '" & psEmpresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentod"
                If ods.Tables.Contains("documentod") Then
                    ods.Tables.Remove("documentod")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentod").Rows.Clear()
            End If


            ''documentov
            If Not ods.Tables.Contains("documentov") Then
                ls_sql = "pa_var_um_documentov_traslado_fecha '" & psEmpresa & "',null,'01/01/2009','01/01/2009'"

                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentov"
                If ods.Tables.Contains("documentov") Then
                    ods.Tables.Remove("documentov")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentov").Rows.Clear()
            End If

            ''documentop
            If Not ods.Tables.Contains("documentop") Then
                ls_sql = "pa_var_um_documentop_traslado_fecha '" & psEmpresa & "',null,'01/01/2009','01/01/2009'"
                dt = Otrans.Obtiene(ls_sql)
                dt.TableName = "documentop"
                If ods.Tables.Contains("documentop") Then
                    ods.Tables.Remove("documentop")
                End If
                dt.Rows.Clear()
                ods.Tables.Add(dt.Copy)
            Else
                ods.Tables("documentop").Rows.Clear()
            End If


            ods_listado = New DataSet
            Dim dt2 = New DataTable("listado")
            dt2.Columns.Add(New DataColumn("empresa", GetType(String)))
            dt2.Columns.Add(New DataColumn("producto", GetType(String)))
            dt2.Columns.Add(New DataColumn("glosa", GetType(String)))
            dt2.Columns.Add(New DataColumn("proveedor", GetType(String)))
            dt2.Columns.Add(New DataColumn("stockminimo", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("stockmaximo", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("Existencia", GetType(String)))
            dt2.Columns.Add(New DataColumn("ExistenciaCD", GetType(String)))
            dt2.Columns.Add(New DataColumn("Sugerido", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("Sugerido_original", GetType(Integer)))
            dt2.Columns.Add(New DataColumn("Comprar", GetType(Boolean)))
            dt2.Columns.Add(New DataColumn("valor", GetType(Decimal)))
            dt2.Columns.Add(New DataColumn("total", GetType(Decimal)))
            dt2.Columns.Add(New DataColumn("grupo", GetType(Integer)))
            ods_listado.Tables.Add(dt2)

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try



    End Sub



    'Public Sub verificarStockLAINCONDICIONAL_crud()

    '    '(c)
    '    Dim clsGen As New ClasesGenerales.General
    '    Dim dt As DataTable
    '    Dim Oflex As New Umbral_Flex.productos
    '    Dim dtStock As DataTable
    '    Dim liPedir As Integer = 0
    '    Dim ods_listado As New DataSet
    '    Dim lsEmpresa As String = "LAINCONDI"
    '    Dim lsUsuario As String = "CARANA"
    '    Dim ods As New DataSet
    '    Dim odsCRUD As DataSet
    '    Dim crudFlex As New FlexLine_CRUD.crearDocumento

    '    Try

    '        crudFlex.Empresa = lsEmpresa
    '        odsCRUD = crudFlex.getEstructura
    '        crear_estructura_auxiliar(ods, ods_listado, lsEmpresa)
    '        ods_listado.Tables("listado").Rows.Clear()

    '        dt = clsGen.selectQuery("FlexLine", "pa_var_um_pedidos_laincondicional '" & Today.ToString("dd-MM-yyyy") & "'")



    '        For Each dr As DataRow In dt.Rows
    '            liPedir = 0
    '            dtStock = Oflex.Obtener_Existencias(lsEmpresa, dr.Item("producto"), "CD_CENTRAL")

    '            If dtStock.Rows.Count > 0 Then
    '                If dtStock.Rows(0).Item("existencia") = 0 Then
    '                    liPedir = dr.Item("cantidad")
    '                ElseIf dtStock.Rows(0).Item("existencia") < dr.Item("cantidad") Then
    '                    ''Pedir la diferencia
    '                    liPedir = dr.Item("cantidad") - dtStock.Rows(0).Item("existencia")
    '                End If
    '            Else
    '                'Pedir completo
    '                liPedir = dr.Item("cantidad")
    '            End If

    '            '
    '            If liPedir > 0 Then
    '                Dim drAux As DataRow = ods_listado.Tables("listado").NewRow

    '                drAux.Item("producto") = dr.Item("producto")
    '                Try
    '                    drAux.Item("proveedor") = dtStock.Rows(0).Item("subfamilia")
    '                Catch ex As Exception
    '                    Dim dtProducto As DataTable
    '                    dtProducto = Oflex.Obtener_Producto(lsEmpresa, dr.Item("producto"))
    '                    If dtProducto.Rows.Count > 0 Then
    '                        drAux.Item("proveedor") = dtProducto.Rows(0).Item("subfamilia")
    '                    End If
    '                End Try
    '                drAux.Item("sugerido") = liPedir
    '                ods_listado.Tables("listado").Rows.Add(drAux)

    '            End If
    '        Next

    '        If ods_listado.Tables("listado").Rows.Count > 0 Then
    '            Dim dtProveedores As DataTable = clsGen.ValoresDistinto(ods_listado.Tables("listado"), "proveedor".Split(","))
    '            For Each dr As DataRow In dtProveedores.Rows

    '                Dim sEmpresaCompra As String
    '                Dim ctacte As String
    '                If dr.Item("proveedor") = "CODICASA" Then
    '                    sEmpresaCompra = "CODICASA"
    '                    ctacte = "79512"
    '                ElseIf dr.Item("proveedor") = "DISTRIBUIDORA MARTE" Then
    '                    sEmpresaCompra = "DMARTE1"
    '                    ctacte = "122183"
    '                ElseIf dr.Item("proveedor") = "DIUVA" Then
    '                    sEmpresaCompra = "DIUVA"
    '                    ctacte = "6608388"
    '                End If

    '                Preparar_Documento_crud(1, lsEmpresa, lsUsuario, dr.Item("proveedor"), "Reposicion Autogenerada " & Now.ToString("HH:mm"), odsCRUD, ods_listado, "CD_CENTRAL")
    '                'Preparar_Factura(1, lsEmpresa, lsUsuario, dr.Item("proveedor"), "Reposicion Autogenerada " & Now.ToString("HH:mm"), ods, ods_listado, "CD_CENTRAL")


    '                dt = clsGen.selectQuery("FlexLine", "pa_sel_um_usuario_bodega 'laincondi','SOLICITUD O/COMPRA','JESTRADA'")
    '                Dim pcomprador As String ' = "GABRIELA BARRIOS"
    '                If dt.Rows.Count > 0 Then
    '                    pcomprador = dt.Rows(0).Item("comprador")
    '                    ctacte = dt.Rows(0).Item("cliente")
    '                End If

    '                Dim documentoValido As Boolean = crudFlex.checkEstructura(odsCRUD)

    '                Dim aa As String
    '                Try
    '                    If documentoValido Then
    '                        Guardar_Documento_crud(odsCRUD, sEmpresaCompra, ctacte, pcomprador, aa)
    '                    End If

    '                Catch ex As Exception

    '                End Try
    '            Next
    '        End If

    '    Catch ex As Exception
    '    End Try


    'End Sub

    'Public Sub Guardar_Documento_crud(pOds As DataSet, psEmpresaCompra As String, psCodigoCliente As String, psComprador As String, ByRef psPedidosGenerados As String)
    '    Dim Osinc As New Sincronizacion.Documentos("")
    '    Dim dr As DataRow
    '    Dim HuboError As Boolean = False
    '    Dim ndoctoserror As Integer = 0
    '    Dim porcentaje_consumido As Double = 0
    '    Dim facturas_disponibles As Integer = 0

    '    psPedidosGenerados = String.Empty

    '    Try
    '        For Each dr In pOds.Tables("encabezado").Rows
    '            HuboError = False
    '            pOds.Tables("detalle").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
    '            pOds.Tables("valores").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
    '            pOds.Tables("pagos").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
    '            If pOds.Tables("detalle").DefaultView.Count > 0 Then
    '                Osinc.Enviar_Documento(dr.Item("empresa"), dr, pOds.Tables("detalle").DefaultView.ToTable, pOds.Tables("valores").DefaultView.ToTable, pOds.Tables("pagos").DefaultView.ToTable, "", True)
    '            End If
    '        Next
    '        If Osinc.codigo_error = 0 Then
    '            ''MessageBox.Show("Pedido Ingresado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            ''Me.txtPedidosGenerados.Text += pOds.Tables("documento").Rows(0).Item("numero") & ","
    '            psPedidosGenerados += pOds.Tables("encabezado").Rows(0).Item("numero") & ","
    '            For Each dr In pOds.Tables("encabezado").Rows
    '                HuboError = False
    '                pOds.Tables("detalle").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
    '                If pOds.Tables("detalle").DefaultView.Count > 0 Then
    '                    generarPedido_Umbright(dr, pOds.Tables("detalle").DefaultView, psEmpresaCompra, psCodigoCliente, psComprador)
    '                End If

    '                'If psEmpresaCompra = "" Then
    '                'mostrarOC(dr.Item("empresa").ToString, dr.Item("tipodocto").ToString, dr.Item("numero").ToString)
    '                'End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '    Finally
    '        Osinc.Cerrar()
    '        Osinc = Nothing
    '    End Try
    'End Sub




    'Public Function Preparar_Documento_crud(ByVal igrupo As Integer, pgs_empresa As String, pgs_usuario As String, pgs_proveedor As String,
    '                                  pgs_comentarios As String, ByRef ods As DataSet, ByRef ods_listado As DataSet, psBodega As String) As Boolean
    '    Dim Osinc As New Sincronizacion.Documentos("")
    '    Dim dr_aux As DataRow
    '    Dim oTrans As New Transaccional.Conexion("flexline")
    '    Dim dt, dtProveedor As DataTable
    '    Dim Oflex As New Umbral_Flex.productos
    '    Dim iCount As Integer
    '    Dim ls_sql, sTipoDocto As String
    '    Dim dtotal As Double = 0
    '    Dim correlativo As Integer
    '    Dim snumero As String = "0000000000001"

    '    Dim sbodega As String = psBodega '"CD_CENTRAL"
    '    Dim pComprador As String
    '    Dim ctacte As String
    '    Dim sListaPrecio As String
    '    Dim sEmpresaCompra As String
    '    Dim lsUsuario As String = "CARANA"



    '    Try

    '        oTrans.open()

    '        ls_sql = "pa_sel_um_usuario_bodega '" & pgs_empresa & "','SOLICITUD O/COMPRA','" & pgs_usuario & "'"
    '        dt = oTrans.Obtiene(ls_sql)
    '        dt.TableName = "usuario_activo"
    '        'ods.Tables.Add(dt.Copy)

    '        If dt.Rows.Count > 0 Then
    '            sbodega = dt.Rows(0).Item("bodega")
    '            pComprador = dt.Rows(0).Item("comprador")
    '            If psBodega = "CD_PREMIUM" Then
    '                ctacte = dt.Rows(0).Item("cliente").ToString
    '            Else
    '                ctacte = dt.Rows(0).Item("clienteAG").ToString
    '                sbodega = psBodega
    '            End If
    '            'sbodega = dt.Rows(0).Item("ubicacion")
    '        End If

    '        sTipoDocto = "ORDEN/COMPRA"

    '        ls_sql = "pa_sel_um_documento_numero'" & pgs_empresa & "','" & sTipoDocto & "'"
    '        dt = oTrans.Obtiene(ls_sql)
    '        Try
    '            If dt.Rows(0).Item("numero").ToString <> "" Then
    '                snumero = dt.Rows(0).Item("numero") + 1
    '                If Len(snumero) < 10 Then snumero = snumero.PadLeft(10, "0")
    '                'Else
    '                '    numero = 1
    '            End If

    '        Catch ex As Exception
    '        End Try


    '        If pgs_proveedor = "CODICASA" Then
    '            sEmpresaCompra = "CODICASA"
    '            ctacte = "79512"
    '        ElseIf pgs_proveedor = "DISTRIBUIDORA MARTE" Then
    '            sEmpresaCompra = "DMARTE1"
    '            ctacte = "122183"
    '        ElseIf pgs_proveedor = "DIUVA" Then
    '            sEmpresaCompra = "DIUVA"
    '            ctacte = "6608388"
    '        End If

    '        'If Me.cmb_proveedor.Text <> "DIUVA" Then
    '        ls_sql = "pa_sel_um_proveedor_pedido_automatico '" & pgs_empresa & "' ,'Proveedor'," & ctacte
    '        dtProveedor = oTrans.Obtiene(ls_sql)
    '        sListaPrecio = dtProveedor.Rows(0).Item("ListaPrecio")



    '        ls_sql = "pa_sel_um_documento_correlativo '" & pgs_empresa & "','" & sTipoDocto & "'"
    '        dt = oTrans.Obtiene(ls_sql)
    '        Try
    '            If dt.Rows(0).Item("correlativo").ToString <> "" Then
    '                correlativo = dt.Rows(0).Item("correlativo") + 1
    '            Else
    '                correlativo = 1
    '            End If

    '        Catch ex As Exception
    '        End Try


    '        Dim total As Double = 0



    '        'crear_estructura_auxiliar(ods)

    '        ods.Tables("encabezado").Rows.Clear()
    '        ods.Tables("detalle").Rows.Clear()

    '        dr_aux = ods.Tables("encabezado").NewRow
    '        dr_aux.Item("empresa") = pgs_empresa
    '        dr_aux.Item("TipoDocto") = sTipoDocto  '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
    '        dr_aux.Item("Numero") = snumero 'numero.ToString.PadLeft(13, "0")
    '        dr_aux.Item("Correlativo") = correlativo
    '        dr_aux.Item("ctacte") = ""
    '        dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
    '        dr_aux.Item("proveedor") = ctacte
    '        dr_aux.Item("Local") = sbodega 'Me.cmbBodega.Text '"SVMF_KIOSKO"  ''(c) 191011 Agregar Combo
    '        dr_aux.Item("Comprador") = pComprador
    '        dr_aux.Item("FechaVcto") = Today.ToString("dd/MM/yyyy")
    '        dr_aux.Item("ListaPrecio") = sListaPrecio
    '        dr_aux.Item("Moneda") = "QUETZALES"
    '        dr_aux.Item("Paridad") = 1
    '        dr_aux.Item("Total") = total
    '        dr_aux.Item("Neto") = total 'dr_aux.Item("Total")
    '        dr_aux.Item("SubTotal") = total ' dr_aux.Item("Total")
    '        dr_aux.Item("NetoIngreso") = total ' dr_aux.Item("Total")
    '        dr_aux.Item("SubTotalIngreso") = total ' dr_aux.Item("Total")
    '        dr_aux.Item("TotalIngreso") = total 'dr_aux.Item("Total")
    '        dr_aux.Item("Aprobacion") = "S"
    '        dr_aux.Item("PeriodoLibro") = Today.ToString("yyyyMM")
    '        dr_aux.Item("FactorMonto") = 0 'ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
    '        dr_aux.Item("FactorMontoProyectado") = 0
    '        dr_aux.Item("TipoCtaCte") = "PROVEEDOR"
    '        dr_aux.Item("IdCtaCte") = ctacte
    '        dr_aux.Item("glosa") = "" 'Me.txt_observaciones.Text
    '        dr_aux.Item("Comentario1") = pgs_comentarios 'sTipoDocto & " " & snumero
    '        dr_aux.Item("Vigencia") = "S"
    '        dr_aux.Item("Emitido") = "N" ''Emitido S para que no puedan realizarle cambios
    '        dr_aux.Item("PorcentajeAsignado") = 0
    '        dr_aux.Item("Adjuntos") = "N"
    '        dr_aux.Item("FechaModif") = Now
    '        'dr_aux.Item("Comentario1") = "" ' Me.txt_observaciones.Text
    '        dr_aux.Item("FechaUModif") = Now
    '        dr_aux.Item("UsuarioModif") = lsUsuario
    '        dr_aux.Item("Hora") = Now.ToString("HH:mm")
    '        dr_aux.Item("Caja") = "" 'gsCaja
    '        dr_aux.Item("Pago") = 0 'dr_aux.Item("Total")
    '        dr_aux.Item("IdApertura") = 0
    '        dr_aux.Item("NetoBimoneda") = 0
    '        dr_aux.Item("SubTotalBimoneda") = 0
    '        dr_aux.Item("TotalBimoneda") = 0
    '        dr_aux.Item("ParidadBimoneda") = 1
    '        ods.Tables("documento").Rows.Add(dr_aux)


    '        'ods_listado.Tables("listado").DefaultView.RowFilter = "grupo = " & igrupo

    '        For Each drv As DataRowView In ods_listado.Tables("listado").DefaultView 'ods.Tables("productos").Rows

    '            If drv.Item("proveedor").ToString.ToUpper.Equals(pgs_proveedor.ToUpper) Then
    '                iCount += 1
    '                dr_aux = ods.Tables("detalle").NewRow
    '                dr_aux.Item("Empresa") = pgs_empresa
    '                dr_aux.Item("TipoDocto") = sTipoDocto '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
    '                dr_aux.Item("Correlativo") = correlativo
    '                dr_aux.Item("Secuencia") = iCount
    '                dr_aux.Item("Linea") = iCount
    '                dr_aux.Item("Producto") = drv.Item("producto").ToString 'dt_producto_barra.DefaultView(0).Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")
    '                dr_aux.Item("Cantidad") = drv.Item("sugerido")

    '                'Obtener precio del producto
    '                Dim dtprecio As DataTable
    '                dtprecio = Oflex.Obtener_Precio_Final(pgs_empresa, drv.Item("producto"), "", sListaPrecio)
    '                Dim ldprecio As Double = 0
    '                If dtprecio.Rows.Count > 0 Then
    '                    ldprecio = dtprecio.Rows(0).Item("valor")

    '                End If

    '                dr_aux.Item("Precio") = ldprecio 'dr.Item("precio") '+ drv.Item("ValorDescuento")
    '                dr_aux.Item("PorcentajeDr") = 0
    '                dr_aux.Item("SubTotal") = ldprecio * dr_aux.Item("Cantidad")  ''drv.Item("Total")
    '                dr_aux.Item("Impuesto") = 0 'dr.Item("Total") - (dr.Item("Total") / porcentajeIva)  'drv.Item("ValorImpuesto")
    '                dr_aux.Item("Neto") = dr_aux.Item("Subtotal") 'drv.Item("Total") ' dr.Item("Total") 'dr.Item("Total") - dr_aux.Item("Impuesto")
    '                dr_aux.Item("DrGlobal") = 0
    '                dr_aux.Item("Total") = dr_aux.Item("Subtotal") ' drv.Item("Total") 'dr.Item("Total")
    '                dr_aux.Item("PrecioAjustado") = ldprecio 'drv.Item("valor") ' dr.Item("precio")   'drv.Item("Price") - drv.Item("Incltax")
    '                dr_aux.Item("UnidadIngreso") = "UN"
    '                dr_aux.Item("CantidadIngreso") = drv.Item("sugerido")
    '                dr_aux.Item("PrecioIngreso") = ldprecio 'drv.Item("valor") 'dr_aux.Item("Precio")
    '                dr_aux.Item("SubTotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
    '                dr_aux.Item("ImpuestoIngreso") = 0
    '                dr_aux.Item("NetoIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
    '                dr_aux.Item("DRGlobalIngreso") = 0
    '                dr_aux.Item("TotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") ' dr.Item("Total")
    '                dr_aux.Item("CorrelativoOrigen") = 0
    '                dr_aux.Item("SecuenciaOrigen") = 0
    '                dr_aux.Item("Bodega") = "" 'Me.cmbBodega.Text '"SVMF_KIOSKO" ''(c) 191011 Agregar Combo
    '                dr_aux.Item("FactorInventario") = 0 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario") ''(c) 191011 Depende si es Entrada o Salida
    '                dr_aux.Item("FechaEntrega") = Today.ToString("dd/MM/yyyy") ' Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
    '                dr_aux.Item("CantidadAsignada") = 0 ''dr.Item("sugerido")
    '                dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
    '                dr_aux.Item("Vigente") = "S" 'IIf(dr.Item("EstadoDocumento").ToString = "INA", "A", "S")
    '                dr_aux.Item("CUP") = 0 'dr_aux.Item("Precio")
    '                dr_aux.Item("Ubicacion") = "PRINCIPAL"
    '                dr_aux.Item("Ubicacion2") = "PRINCIPAL"
    '                dr_aux.Item("FactorImpto") = 1 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
    '                dr_aux.Item("PrecioBimoneda") = 0 'dr_aux.Item("Precio")
    '                dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
    '                dr_aux.Item("ImpuestoBimoneda") = 0
    '                dr_aux.Item("NetoBimoneda") = dr_aux.Item("total")                ' drv.Item("Total") 'dr_aux.Item("total")
    '                dr_aux.Item("DrGlobalBimoneda") = 0
    '                dr_aux.Item("TotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
    '                dr_aux.Item("ValPorcentajeDr1") = 0
    '                dr_aux.Item("ValPorcentajeDr1Ingreso") = 0
    '                dr_aux.Item("costo") = ldprecio ' drv.Item("valor") ' dr_aux.Item("Precio")
    '                dr_aux.Item("FechaVigenciaLp") = "01/01/1900"
    '                dr_aux.Item("PrecioListaP") = 0
    '                dr_aux.Item("DoctoOrigenVal") = "N"
    '                ods.Tables("detalle").Rows.Add(dr_aux)

    '                dtotal += dr_aux.Item("total")
    '            End If
    '        Next


    '        ods.Tables("encabezado").Rows(0).Item("Total") = dtotal
    '        ods.Tables("encabezado").Rows(0).Item("Neto") = dtotal 'dr_aux.Item("Total")
    '        ods.Tables("encabezado").Rows(0).Item("SubTotal") = dtotal ' dr_aux.Item("Total")
    '        ods.Tables("encabezado").Rows(0).Item("NetoIngreso") = dtotal ' dr_aux.Item("Total")
    '        ods.Tables("encabezado").Rows(0).Item("SubTotalIngreso") = dtotal ' dr_aux.Item("Total")
    '        ods.Tables("encabezado").Rows(0).Item("TotalIngreso") = dtotal
    '    Catch ex As Exception
    '    Finally
    '        'ClsPOS = Nothing
    '        'Oflex.close()
    '        'Oflex = Nothing

    '    End Try
    '    Return True
    'End Function




    Public Function Preparar_Factura(ByVal igrupo As Integer, pgs_empresa As String, pgs_usuario As String, pgs_proveedor As String,
                                      pgs_comentarios As String, ByRef ods As DataSet, ByRef ods_listado As DataSet, psBodega As String) As Boolean
        Dim Osinc As New Sincronizacion.Documentos("")
        Dim dr_aux As DataRow
        Dim oTrans As New Transaccional.Conexion("flexline")
        Dim dt, dtProveedor As DataTable
        Dim Oflex As New Umbral_Flex.productos
        Dim iCount As Integer
        Dim ls_sql, sTipoDocto As String
        Dim dtotal As Double = 0
        Dim correlativo As Integer
        Dim snumero As String = "0000000000001"

        Dim sbodega As String = psBodega '"CD_CENTRAL"
        Dim pComprador As String
        Dim ctacte As String
        Dim sListaPrecio As String
        Dim sEmpresaCompra As String
        ''Dim lsUsuario As String = "CARANA"



        Try

            oTrans.open()

            ls_sql = "pa_sel_um_usuario_bodega '" & pgs_empresa & "','SOLICITUD O/COMPRA','" & pgs_usuario & "'"
            dt = oTrans.Obtiene(ls_sql)
            dt.TableName = "usuario_activo"
            'ods.Tables.Add(dt.Copy)

            If dt.Rows.Count > 0 Then
                sbodega = dt.Rows(0).Item("bodega")
                pComprador = dt.Rows(0).Item("comprador")
                If psBodega = "CD_PREMIUM" Then
                    ctacte = dt.Rows(0).Item("cliente").ToString
                Else
                    ctacte = dt.Rows(0).Item("clienteAG").ToString
                    sbodega = psBodega
                End If
                'sbodega = dt.Rows(0).Item("ubicacion")
            End If

            sTipoDocto = "ORDEN/COMPRA"

            ls_sql = "pa_sel_um_documento_numero'" & pgs_empresa & "','" & sTipoDocto & "'"
            dt = oTrans.Obtiene(ls_sql)
            Try
                If dt.Rows(0).Item("numero").ToString <> "" Then
                    snumero = dt.Rows(0).Item("numero") + 1
                    If Len(snumero) < 10 Then snumero = snumero.PadLeft(10, "0")
                    'Else
                    '    numero = 1
                End If

            Catch ex As Exception
            End Try


            If pgs_proveedor = "CODICASA" Then
                sEmpresaCompra = "CODICASA"
                ctacte = "79512"
            ElseIf pgs_proveedor = "DISTRIBUIDORA MARTE" Then
                sEmpresaCompra = "DMARTE1"
                ctacte = "122183"
            ElseIf pgs_proveedor = "DIUVA" Then
                sEmpresaCompra = "DIUVA"
                ctacte = "6608388"
            End If

            'If Me.cmb_proveedor.Text <> "DIUVA" Then
            ls_sql = "pa_sel_um_proveedor_pedido_automatico '" & pgs_empresa & "' ,'Proveedor','" & ctacte & "'"
            dtProveedor = oTrans.Obtiene(ls_sql)
            sListaPrecio = dtProveedor.Rows(0).Item("ListaPrecio")



            ls_sql = "pa_sel_um_documento_correlativo '" & pgs_empresa & "','" & sTipoDocto & "'"
            dt = oTrans.Obtiene(ls_sql)
            Try
                If dt.Rows(0).Item("correlativo").ToString <> "" Then
                    correlativo = dt.Rows(0).Item("correlativo") + 1
                Else
                    correlativo = 1
                End If

            Catch ex As Exception
            End Try


            Dim total As Double = 0



            'crear_estructura_auxiliar(ods)

            ods.Tables("documento").Rows.Clear()
            ods.Tables("documentod").Rows.Clear()

            dr_aux = ods.Tables("documento").NewRow
            dr_aux.Item("empresa") = pgs_empresa
            dr_aux.Item("TipoDocto") = sTipoDocto  '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
            dr_aux.Item("Numero") = snumero 'numero.ToString.PadLeft(13, "0")
            dr_aux.Item("Correlativo") = correlativo
            dr_aux.Item("ctacte") = ""
            dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
            dr_aux.Item("proveedor") = ctacte
            dr_aux.Item("Local") = sbodega 'Me.cmbBodega.Text '"SVMF_KIOSKO"  ''(c) 191011 Agregar Combo
            dr_aux.Item("Comprador") = pComprador
            dr_aux.Item("FechaVcto") = Today.ToString("dd/MM/yyyy")
            dr_aux.Item("ListaPrecio") = sListaPrecio
            dr_aux.Item("Moneda") = "QUETZALES"
            dr_aux.Item("Paridad") = 1
            dr_aux.Item("Total") = total
            dr_aux.Item("Neto") = total 'dr_aux.Item("Total")
            dr_aux.Item("SubTotal") = total ' dr_aux.Item("Total")
            dr_aux.Item("NetoIngreso") = total ' dr_aux.Item("Total")
            dr_aux.Item("SubTotalIngreso") = total ' dr_aux.Item("Total")
            dr_aux.Item("TotalIngreso") = total 'dr_aux.Item("Total")
            dr_aux.Item("Aprobacion") = "S"
            dr_aux.Item("PeriodoLibro") = Today.ToString("yyyyMM")
            dr_aux.Item("FactorMonto") = 0 'ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
            dr_aux.Item("FactorMontoProyectado") = 0
            dr_aux.Item("TipoCtaCte") = "PROVEEDOR"
            dr_aux.Item("IdCtaCte") = ctacte
            dr_aux.Item("glosa") = "" 'Me.txt_observaciones.Text
            dr_aux.Item("Comentario1") = pgs_comentarios 'sTipoDocto & " " & snumero
            dr_aux.Item("Vigencia") = "S"
            dr_aux.Item("Emitido") = "N" ''Emitido S para que no puedan realizarle cambios
            dr_aux.Item("PorcentajeAsignado") = 0
            dr_aux.Item("Adjuntos") = "N"
            dr_aux.Item("FechaModif") = Now
            'dr_aux.Item("Comentario1") = "" ' Me.txt_observaciones.Text
            dr_aux.Item("FechaUModif") = Now
            dr_aux.Item("UsuarioModif") = pgs_usuario
            dr_aux.Item("Hora") = Now.ToString("HH:mm")
            dr_aux.Item("Caja") = "" 'gsCaja
            dr_aux.Item("Pago") = 0 'dr_aux.Item("Total")
            dr_aux.Item("IdApertura") = 0
            dr_aux.Item("NetoBimoneda") = 0
            dr_aux.Item("SubTotalBimoneda") = 0
            dr_aux.Item("TotalBimoneda") = 0
            dr_aux.Item("ParidadBimoneda") = 1
            ods.Tables("documento").Rows.Add(dr_aux)


            'ods_listado.Tables("listado").DefaultView.RowFilter = "grupo = " & igrupo

            For Each drv As DataRowView In ods_listado.Tables("listado").DefaultView 'ods.Tables("productos").Rows

                If drv.Item("proveedor").ToString.ToUpper.Equals(pgs_proveedor.ToUpper) Then
                    iCount += 1
                    dr_aux = ods.Tables("documentod").NewRow
                    dr_aux.Item("Empresa") = pgs_empresa
                    dr_aux.Item("TipoDocto") = sTipoDocto '"SOLICITUD O/COMPRA" 'Me.cmbTipoMovimiento.Text '"ENTRADA BODEGA MF" ''(c) 191011 Agregar Combo
                    dr_aux.Item("Correlativo") = correlativo
                    dr_aux.Item("Secuencia") = iCount
                    dr_aux.Item("Linea") = iCount
                    dr_aux.Item("Producto") = drv.Item("producto").ToString 'dt_producto_barra.DefaultView(0).Item("Producto") ' dt_Itm.DefaultView(0).Item("Bohname")
                    dr_aux.Item("Cantidad") = drv.Item("sugerido")

                    'Obtener precio del producto
                    Dim dtprecio As DataTable
                    dtprecio = Oflex.Obtener_Precio_Final(pgs_empresa, drv.Item("producto"), "", sListaPrecio)
                    Dim ldprecio As Double = 0
                    If dtprecio.Rows.Count > 0 Then
                        ldprecio = dtprecio.Rows(0).Item("valor")

                    End If

                    dr_aux.Item("Precio") = ldprecio 'dr.Item("precio") '+ drv.Item("ValorDescuento")
                    dr_aux.Item("PorcentajeDr") = 0
                    dr_aux.Item("SubTotal") = ldprecio * dr_aux.Item("Cantidad")  ''drv.Item("Total")
                    dr_aux.Item("Impuesto") = 0 'dr.Item("Total") - (dr.Item("Total") / porcentajeIva)  'drv.Item("ValorImpuesto")
                    dr_aux.Item("Neto") = dr_aux.Item("Subtotal") 'drv.Item("Total") ' dr.Item("Total") 'dr.Item("Total") - dr_aux.Item("Impuesto")
                    dr_aux.Item("DrGlobal") = 0
                    dr_aux.Item("Total") = dr_aux.Item("Subtotal") ' drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("PrecioAjustado") = ldprecio 'drv.Item("valor") ' dr.Item("precio")   'drv.Item("Price") - drv.Item("Incltax")
                    dr_aux.Item("UnidadIngreso") = "UN"
                    dr_aux.Item("CantidadIngreso") = drv.Item("sugerido")
                    dr_aux.Item("PrecioIngreso") = ldprecio 'drv.Item("valor") 'dr_aux.Item("Precio")
                    dr_aux.Item("SubTotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("ImpuestoIngreso") = 0
                    dr_aux.Item("NetoIngreso") = dr_aux.Item("total")                'drv.Item("Total") 'dr.Item("Total")
                    dr_aux.Item("DRGlobalIngreso") = 0
                    dr_aux.Item("TotalIngreso") = dr_aux.Item("total")                'drv.Item("Total") ' dr.Item("Total")
                    dr_aux.Item("CorrelativoOrigen") = 0
                    dr_aux.Item("SecuenciaOrigen") = 0
                    dr_aux.Item("Bodega") = "" 'Me.cmbBodega.Text '"SVMF_KIOSKO" ''(c) 191011 Agregar Combo
                    dr_aux.Item("FactorInventario") = 0 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario") ''(c) 191011 Depende si es Entrada o Salida
                    dr_aux.Item("FechaEntrega") = Today.ToString("dd/MM/yyyy") ' Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                    dr_aux.Item("CantidadAsignada") = 0 ''dr.Item("sugerido")
                    dr_aux.Item("Fecha") = Today.ToString("dd/MM/yyyy") 'Date.Parse(dr.Item("FechaDocumento").ToString).ToString("dd/MM/yyyy")
                    dr_aux.Item("Vigente") = "S" 'IIf(dr.Item("EstadoDocumento").ToString = "INA", "A", "S")
                    dr_aux.Item("CUP") = 0 'dr_aux.Item("Precio")
                    dr_aux.Item("Ubicacion") = "PRINCIPAL"
                    dr_aux.Item("Ubicacion2") = "PRINCIPAL"
                    dr_aux.Item("FactorImpto") = 1 ' ods.Tables("tipodocumento").DefaultView(0)("factorinventario")
                    dr_aux.Item("PrecioBimoneda") = 0 'dr_aux.Item("Precio")
                    dr_aux.Item("SubTotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ImpuestoBimoneda") = 0
                    dr_aux.Item("NetoBimoneda") = dr_aux.Item("total")                ' drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("DrGlobalBimoneda") = 0
                    dr_aux.Item("TotalBimoneda") = dr_aux.Item("total")                'drv.Item("Total") 'dr_aux.Item("total")
                    dr_aux.Item("ValPorcentajeDr1") = 0
                    dr_aux.Item("ValPorcentajeDr1Ingreso") = 0
                    dr_aux.Item("costo") = ldprecio ' drv.Item("valor") ' dr_aux.Item("Precio")
                    dr_aux.Item("FechaVigenciaLp") = "01/01/1900"
                    dr_aux.Item("PrecioListaP") = 0
                    dr_aux.Item("DoctoOrigenVal") = "N"
                    ods.Tables("documentod").Rows.Add(dr_aux)

                    dtotal += dr_aux.Item("total")
                End If
            Next


            ods.Tables("documento").Rows(0).Item("Total") = dtotal
            ods.Tables("documento").Rows(0).Item("Neto") = dtotal 'dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("SubTotal") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("NetoIngreso") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("SubTotalIngreso") = dtotal ' dr_aux.Item("Total")
            ods.Tables("documento").Rows(0).Item("TotalIngreso") = dtotal
        Catch ex As Exception
        Finally
            'ClsPOS = Nothing
            'Oflex.close()
            'Oflex = Nothing

        End Try
        Return True
    End Function



    Public Sub Guardar_Documento(pOds As DataSet, psEmpresaCompra As String, psCodigoCliente As String, psComprador As String, ByRef psPedidosGenerados As String, psUsuarioPedido As String)
        Dim Osinc As New Sincronizacion.Documentos("")
        Dim dr As DataRow
        Dim HuboError As Boolean = False
        Dim ndoctoserror As Integer = 0
        Dim porcentaje_consumido As Double = 0
        Dim facturas_disponibles As Integer = 0

        psPedidosGenerados = String.Empty

        Try
            For Each dr In pOds.Tables("documento").Rows
                HuboError = False
                pOds.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                pOds.Tables("documentov").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                pOds.Tables("documentop").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                If pOds.Tables("documentod").DefaultView.Count > 0 Then
                    Osinc.Enviar_Documento(dr.Item("empresa"), dr, pOds.Tables("documentod").DefaultView.ToTable, pOds.Tables("documentov").DefaultView.ToTable, pOds.Tables("documentop").DefaultView.ToTable, "", True)
                End If
            Next
            If Osinc.codigo_error = 0 Then
                ''MessageBox.Show("Pedido Ingresado Exitosamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''Me.txtPedidosGenerados.Text += pOds.Tables("documento").Rows(0).Item("numero") & ","
                psPedidosGenerados += pOds.Tables("documento").Rows(0).Item("numero") & ","
                For Each dr In pOds.Tables("documento").Rows
                    HuboError = False
                    pOds.Tables("documentod").DefaultView.RowFilter = "empresa= '" & dr.Item("empresa") & "' and tipodocto = '" & dr.Item("tipodocto").ToString & "' and correlativo = " & dr.Item("correlativo").ToString
                    If pOds.Tables("documentod").DefaultView.Count > 0 Then
                        generarPedido_Umbright(dr, pOds.Tables("documentod").DefaultView, psEmpresaCompra, psCodigoCliente, psComprador, psUsuarioPedido)
                    End If

                    'If psEmpresaCompra = "" Then
                    'mostrarOC(dr.Item("empresa").ToString, dr.Item("tipodocto").ToString, dr.Item("numero").ToString)
                    'End If
                Next
            End If
        Catch ex As Exception
        Finally
            Osinc.Cerrar()
            Osinc = Nothing
        End Try
    End Sub


    Public Sub generarPedido_Umbright(ByVal drEncabezado As DataRow, ByVal dtvDetalle As DataView,
                                    psEmpresaCompra As String, psCodigoCliente As String, psComprador As String, psUsuarioPedido As String)
        Dim lsSQL As String
        Dim cOtrans As New Transaccional.Conexion("Corporativo")
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim oFlex As New Umbral_Flex.productos("FlexLine")
        Dim dt, dtCliente As DataTable
        Dim numero_pedido As String
        Dim precio_unitario As Double
        'Dim lsUsuario As String = "CARANA"

        Try

            Otrans.open()
            cOtrans.open()
            dtCliente = Otrans.Obtiene("pa_sel_um_ctacte '" & psEmpresaCompra & "','CLIENTE','" & psCodigoCliente & "'")

            If dtCliente.Rows.Count > 0 Then

                ''Guardar 

                lsSQL = "pa_ins_um_mov_pedidos_encabezado_tekne '" &
                         psEmpresaCompra & "','" & Now.ToString("ddMMyyyyHHmmss") & "','" &
                         psCodigoCliente & "','" & dtCliente.Rows(0).Item("Condpago").ToString & "'," &
                         "0,0,'" &
                        DateTime.Parse(Today.ToString).ToString("dd-MM-yyyy") & "','" &
                        DateTime.Parse(Today.ToString).ToString("dd-MM-yyyy") & "','"

                'lsSQL += "1900-01-01','" Fecha Modifico

                lsSQL += "Orden de Compra No. " & drEncabezado.Item("numero") & " " & drEncabezado("comentario1").ToString & " Comprador " & psComprador & "','" &
                        psUsuarioPedido.ToString & "',0,'" &
                        dtCliente.Rows(0).Item("ListaPrecio").ToString & "',null,'',''"



                cOtrans.Ingresa(lsSQL)

                If cOtrans.Codigo_error = 0 Then
                    dt = cOtrans.Obtiene("SELECT @@IDENTITY AS NewID")
                    numero_pedido = dt.Rows(0).Item("newid").ToString

                    For Each drv As DataRowView In dtvDetalle

                        dt = oFlex.Obtener_Precio_Final(psEmpresaCompra, drv.Item("producto"), psCodigoCliente)
                        Try
                            precio_unitario = dt.Rows(0).Item("valor")
                        Catch ex As Exception
                            precio_unitario = 0
                        End Try

                        lsSQL = "pa_ins_um_mov_pedidos_detalle " & numero_pedido & "," &
                                          drv.Item("Linea") & ",'" & drv.Item("producto") & "'," &
                                          drv.Item("cantidad") & "," & precio_unitario & "," &
                                          precio_unitario * drv.Item("cantidad")

                        cOtrans.Ingresa(lsSQL)
                        If cOtrans.Codigo_error > 0 Then
                            'lbExitoso = False
                        End If
                    Next
                End If

                lsSQL = "pa_upd_mov_pedidos_encabezado_cell " & numero_pedido
                cOtrans.Actualiza(lsSQL)


                '(c) 20230811 Llamar al proceso de facturación automatico

                lsSQL = "pa_var_um_mov_pedidos_encabezado_procesables_id " & numero_pedido
                dt = cOtrans.Obtiene(lsSQL)

                Dim oSinc As New Sincronizacion.Recepcion_Informacion_PDA

                Dim dtDetalle As DataTable = dtvDetalle.ToTable

                oSinc.generarPedidoCorporativo_to_flexline(dt.Rows(0), "", "", dtDetalle, 75)




            End If
        Catch ex As Exception
        Finally
            cOtrans.close()
            cOtrans = Nothing
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub



#End Region







    ' Método central que ejecuta la tarea
    Private Sub PerformScheduledTask(nowDt As DateTime)
        Dim clsGen As New ClasesGenerales.General

        Try
            clsGen.Escribir_Log("Compra Interempresa La Incodicional " & nowDt.ToString("HH:mm"))
            Dim umbralflex As New Umbral_Flex.comprasInterempresa
            umbralflex.verificarStockLAINCONDICIONAL()
            umbralflex = Nothing

            lastRunDate = nowDt.Date
            lastRunHour = nowDt.Hour
        Catch ex As Exception
            Try
                clsGen.Escribir_Log("Error en PerformScheduledTask: " & ex.Message)
            Catch
            End Try
        End Try
    End Sub

    ' Tick que comprueba cada minuto y dispara solo una vez por hora programada
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim clsGen As New ClasesGenerales.General
        Try
            Dim nowDt As DateTime = DateTime.Now
            If nowDt.Minute = 0 AndAlso Array.IndexOf(scheduledHours, nowDt.Hour) >= 0 Then
                If lastRunDate.Date <> nowDt.Date OrElse lastRunHour <> nowDt.Hour Then
                    PerformScheduledTask(nowDt)
                End If
            End If
        Catch ex As Exception
            Try
                clsGen.Escribir_Log("Error en Timer1_Tick: " & ex.Message)
            Catch
            End Try
        End Try
    End Sub
End Class