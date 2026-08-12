Imports System.Net
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Image
Imports ClasesGenerales.General
Imports Microsoft.Office.Interop
Imports System.Threading
Imports System.IO
Imports System.Collections.Generic

Public Class frm_menu_principal
    Inherits System.Windows.Forms.Form
    Dim cod_tipo_usuario As Integer = 0
    Private recientes As New List(Of Tuple(Of String, MenuItem))()
    Private favoritos As New List(Of String)()
    Private favoritosItems As New Dictionary(Of String, MenuItem)()
    Private ReadOnly favoritosPath As String = System.IO.Path.Combine(Application.StartupPath, "um_favs.dat")
    Friend WithEvents mci_trackingInternaciones As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_liquidacionPiloto As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_co_cface As System.Windows.Forms.MenuItem
    Friend WithEvents mcoEdifact As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_ImpresionOrdenesEDI As System.Windows.Forms.MenuItem
    Friend WithEvents mco_devoluciones As System.Windows.Forms.MenuItem
    Friend WithEvents mcoFacturacionCosto As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_evaluacion As System.Windows.Forms.MenuItem
    Friend WithEvents adu_DR As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_cambioHorario As System.Windows.Forms.MenuItem
    Friend WithEvents merEvualuacionDIAGEO As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_fc_FACE As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_ReporteHorario As System.Windows.Forms.MenuItem
    Friend WithEvents adu_trasladoDUA As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico7 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico8 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico9 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico10 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico11 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico12 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico13 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico14 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico15 As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_devolucionesrechazos As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_ComprasInterEmpresas As System.Windows.Forms.MenuItem
    Friend WithEvents mco_div_pedido As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_series As System.Windows.Forms.MenuItem
    Friend WithEvents mer_MantenedorPrecios As System.Windows.Forms.MenuItem
    Friend WithEvents mer_actualizacionProductosIE As System.Windows.Forms.MenuItem
    Friend WithEvents mco_solicitudRequisiciones As System.Windows.Forms.MenuItem
    Friend WithEvents mco_mantenedorITEM As System.Windows.Forms.MenuItem
    Friend WithEvents mco_mantenedorPrecios As System.Windows.Forms.MenuItem
    Friend WithEvents mco_pedidos_telemarketing As System.Windows.Forms.MenuItem
    Friend WithEvents mco_EnvioOrdenesCompra As System.Windows.Forms.MenuItem
    Friend WithEvents mco_RecepcionOrdenesCompra As System.Windows.Forms.MenuItem
    Friend WithEvents mco_ws_productos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_EnvioOrdenesCompraConta As System.Windows.Forms.MenuItem
    Friend WithEvents mco_ws_clientes As System.Windows.Forms.MenuItem
    Friend WithEvents mco_ws_envios As System.Windows.Forms.MenuItem
    Friend WithEvents adu_InventarioFisicoDA As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_planificacion_rutas As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cancelacion_Compromisos As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_asignacion_picking As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_parametrizacion_picking As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cr_recibos_canal_moderno As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cr_envio_documentos_canal_moderno As System.Windows.Forms.MenuItem
    Friend WithEvents mco_trancking_factura As System.Windows.Forms.MenuItem
    Friend WithEvents mco_actualizacion_sku As System.Windows.Forms.MenuItem
    Friend WithEvents mco_reproceso_isf As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_chequeo As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cr_recepcion_devoluciones As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_facturacionANIXTER As System.Windows.Forms.MenuItem
    Friend WithEvents mfiOperacionRecibos As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_productosANIXTER As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_costo_ingresoCD As System.Windows.Forms.MenuItem
    Friend WithEvents mco_ws_entregas As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_tra_liberar_facturas As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_suspensiones As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_fac_direccionar_impresoras As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_actualizacion_productos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_div_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_caja_chica As System.Windows.Forms.MenuItem
    Friend WithEvents mco_edi_inner_pack As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_tr_generarInformacion As System.Windows.Forms.MenuItem
    Friend WithEvents mco_clientesContado As System.Windows.Forms.MenuItem
    Friend WithEvents mcoRetailLink As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_fac_compras_interempresas As System.Windows.Forms.MenuItem
    Friend WithEvents mco_actualizacion_productos As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_actualizacion_pedidowalmart As System.Windows.Forms.MenuItem
    Friend WithEvents mco_mercaderistas As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_tra_notasdevolucion As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_traslado_empleados As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_co_item_producto As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_co_conciliacionBancaria As System.Windows.Forms.MenuItem
    Friend WithEvents mco_edi_validacion_oc_wm As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_ingresos_cd As System.Windows.Forms.MenuItem
    Friend WithEvents mco_MonitorMaquila As System.Windows.Forms.MenuItem
    Friend WithEvents mco_devolucionesInterempresas As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_ci_etiquetado As System.Windows.Forms.MenuItem
    Friend WithEvents mer_actualizacionProductos As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_candidatos As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_con_productos_contables As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_tr_cumplimiento_diario_rentado As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_reasignacionPicking As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_agregar_reenvios As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cubos_logistica As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_tr_cumplimiento_entregas As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_con_analisis_facturas As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_tr_editar_marcajes As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cre_analisis_facturas As System.Windows.Forms.MenuItem
    Friend WithEvents mci_tracking_oc_tesoreria As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_garita As System.Windows.Forms.MenuItem
    Friend WithEvents mci_soc_complemento_divinos As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_picking_3pl As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_informe_recepcion_3pl As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_procesar_pedidos_3pl As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_tableau1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_con_tracking_pagos As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_bono14 As System.Windows.Forms.MenuItem
    Friend WithEvents mco_RecepcionFacturas_Requisicion As System.Windows.Forms.MenuItem
    Friend WithEvents mco_edi_carga_informacion_bi As System.Windows.Forms.MenuItem
    Friend WithEvents mco_presupuesto_marca_ayp As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_fc_traslado_facturas As System.Windows.Forms.MenuItem
    Friend WithEvents mco_Envio_Facturas_Recepcion As System.Windows.Forms.MenuItem
    Friend WithEvents mco_PedidoVinoteca_Bodegas As System.Windows.Forms.MenuItem
    Friend WithEvents mci_soc_ocdivinos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_claim As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_caja_chica_multiple As MenuItem
    Friend WithEvents mti_dts As MenuItem
    Friend WithEvents mfi_cre_consolidacion_consignaciones As MenuItem
    Friend WithEvents mlo_montor_impresiones_AG As MenuItem
    Friend WithEvents mfi_cre_procesos_fel As MenuItem
    Friend WithEvents mco_requisicionesProyecto As MenuItem
    Friend WithEvents mfi_fc_fel_telemarketing As MenuItem
    Friend WithEvents mfi_cre_pagos_exterior As MenuItem
    Friend WithEvents mlo_transporte_tmk As MenuItem
    Friend WithEvents mlo_picking_tmk As MenuItem
    Friend WithEvents mnuAnuladorInFile As MenuItem
    Friend WithEvents mco_vin_sincronizar_memos As MenuItem
    Friend WithEvents mco_vin_sincronizar_productos As MenuItem
    Friend WithEvents mco_pedidos_unisuper As MenuItem
    Friend WithEvents mco_reimpresion_fel As MenuItem
    Friend WithEvents mco_vinoteca_liberar_salidas As MenuItem
    Friend WithEvents mco_vinoteca_entradaxtraslados As MenuItem
    Friend WithEvents mco_recepcion_mercaderia_vinoteca As MenuItem
    Friend WithEvents mfi_co_carga_combustible As MenuItem
    Friend WithEvents mfi_co_liquidacion_caja_chica_teams As MenuItem
    Friend WithEvents mco_administracion_escasez As MenuItem
    Friend WithEvents mco_actualizacion_sku_unisuper As MenuItem
    Friend WithEvents mfi_cre_liquidacion_transportes_caja As MenuItem
    Friend WithEvents mfi_cre_monitor_impresiones As MenuItem
    Friend WithEvents mco_vin_solicitud_traslados As MenuItem
    Friend WithEvents mfi_con_anulacionFEL As MenuItem
    Friend WithEvents mlo_recepcionFacturas As MenuItem
    Friend WithEvents mfi_con_tracking_caja_chica As MenuItem
    Friend WithEvents mfi_fac_monitor_impresiones_recolecta As MenuItem
    Friend WithEvents mlo_tr_recolecciones As MenuItem
    Friend WithEvents btnOpcion1 As Button
    Friend WithEvents btnOpcion2 As Button
    Friend WithEvents gbOpcines As GroupBox
    Friend WithEvents btnOpcion3 As Button
    Private mimg As MImages
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mimg = New MImages(Label1.Image)

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
    Friend WithEvents mti_isf As System.Windows.Forms.MenuItem
    Friend WithEvents mar_salir As System.Windows.Forms.MenuItem
    Friend WithEvents mti_usuario As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_SacarFacturas As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cambiar_empresa As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cambiarclave As System.Windows.Forms.MenuItem
    Friend WithEvents mti_diseñador As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_consignaciones As System.Windows.Forms.MenuItem
    Friend WithEvents pb_logo As System.Windows.Forms.PictureBox
    Friend WithEvents pb_it As System.Windows.Forms.PictureBox
    Friend WithEvents mti_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mar_flexline As System.Windows.Forms.MenuItem
    Friend WithEvents mar_Vnet As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_fc_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cr_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_co_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mci_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mpr_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mar_reverse As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cr_pedidos_pendientes As System.Windows.Forms.MenuItem
    Friend WithEvents mar_crm As System.Windows.Forms.MenuItem
    Friend WithEvents tmk_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_inventario As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_cartera As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_topventas As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_ventasxperiodo As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_topinv As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_tops As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_ventasxrangofecha As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_controltransporte As System.Windows.Forms.MenuItem
    Friend WithEvents mco_cdc_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mco_ala_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mco_inventario As System.Windows.Forms.MenuItem
    Friend WithEvents mco_dma_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_liberar_facturas As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents mci_odc_edifact As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_ventas24meses As System.Windows.Forms.MenuItem
    Friend WithEvents mti_conversiones As System.Windows.Forms.MenuItem
    Friend WithEvents mci_reportes_adicionales As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_reportes_picking As System.Windows.Forms.MenuItem
    Friend WithEvents mti_insumos As System.Windows.Forms.MenuItem
    Friend WithEvents m_archivo As System.Windows.Forms.MenuItem
    Friend WithEvents m_comercial As System.Windows.Forms.MenuItem
    Friend WithEvents m_rh As System.Windows.Forms.MenuItem
    Friend WithEvents m_finanzas As System.Windows.Forms.MenuItem
    Friend WithEvents mar_linea As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cubos As System.Windows.Forms.MenuItem
    Friend WithEvents menu_principal As System.Windows.Forms.MainMenu
    Friend WithEvents m_ti As System.Windows.Forms.MenuItem
    Friend WithEvents m_logistica As System.Windows.Forms.MenuItem
    Friend WithEvents m_presidencia As System.Windows.Forms.MenuItem
    Friend WithEvents m_compras As System.Windows.Forms.MenuItem
    Friend WithEvents m_telemarketing As System.Windows.Forms.MenuItem
    Friend WithEvents m_mercadeo As System.Windows.Forms.MenuItem
    Friend WithEvents mer_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_finalizacion_picking As System.Windows.Forms.MenuItem
    Friend WithEvents mti_plasma As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_pq As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_sq As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_ge As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_ll As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_pq_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_sq_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_ge_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_ll_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_impresion_picking_manual As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_control_transporte As System.Windows.Forms.MenuItem
    Friend WithEvents mti_jsa As System.Windows.Forms.MenuItem
    Friend WithEvents mar_informacion_productos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_trancking_pedidos As System.Windows.Forms.MenuItem
    Friend WithEvents mar_telecomunicaciones As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_if_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_inicializar_periodo As System.Windows.Forms.MenuItem
    Friend WithEvents mco_consulta_clientes As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_fc_pedidos_facturar As System.Windows.Forms.MenuItem
    Friend WithEvents mci_liberar_documentos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_liberar_ppto_cliente As System.Windows.Forms.MenuItem
    Friend WithEvents mci_scm_mantenimiento_proveedores As System.Windows.Forms.MenuItem
    Friend WithEvents mci_scm_parametros As System.Windows.Forms.MenuItem
    Friend WithEvents mci_scm_mantenimiento_productos As System.Windows.Forms.MenuItem
    Friend WithEvents mci_scm_establecer_pedido As System.Windows.Forms.MenuItem
    Friend WithEvents mti_control_fallas As System.Windows.Forms.MenuItem
    Friend WithEvents mci_int_parametros As System.Windows.Forms.MenuItem
    Friend WithEvents mci_int_traslado As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cr_recepcion_Control_transporte As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_asociar_es_inventario As System.Windows.Forms.MenuItem
    Friend WithEvents mci_int_listado As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_scn_Movimientos_Inventario As System.Windows.Forms.MenuItem
    Friend WithEvents mti_scn_precios_ofertas As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_cr_snc_clientes As System.Windows.Forms.MenuItem
    Friend WithEvents mco_tec_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_24m_tiendas As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_maq_monitor As System.Windows.Forms.MenuItem
    Friend WithEvents mci_scm_ver_pedidos As System.Windows.Forms.MenuItem
    Friend WithEvents mti_scn_productos As System.Windows.Forms.MenuItem
    Friend WithEvents mti_activos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_cdc_liberar_pedidos_MR As System.Windows.Forms.MenuItem
    Friend WithEvents mer_memos_promocionales As System.Windows.Forms.MenuItem
    Friend WithEvents mco_back_order As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_Ventas_Vendedor_Vertical As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_enviar_factura As System.Windows.Forms.MenuItem
    Friend WithEvents mco_liberar_ppto_producto As System.Windows.Forms.MenuItem
    Friend WithEvents mco_cdc_reportes_mayoristas As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_pedidos_posfechados As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_ventas_x_dia As System.Windows.Forms.MenuItem
    Friend WithEvents mco_cdc_mensajeria As System.Windows.Forms.MenuItem
    Friend WithEvents mti_eface As System.Windows.Forms.MenuItem
    Friend WithEvents mer_anular_memos_promocionales As System.Windows.Forms.MenuItem
    Friend WithEvents mer_mem_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mco_cdc_productos_mr As System.Windows.Forms.MenuItem
    Friend WithEvents mco_diu_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mco_vin_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mco_enviar_picking As System.Windows.Forms.MenuItem
    Friend WithEvents mer_mem_revision_OC As System.Windows.Forms.MenuItem
    Friend WithEvents mer_mem_solicitud_productos As System.Windows.Forms.MenuItem
    Friend WithEvents mer_cambio_precio As System.Windows.Forms.MenuItem
    Friend WithEvents mti_actualizacion_producto As System.Windows.Forms.MenuItem
    Friend WithEvents mar_control_tarea As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_cancela_prestamo As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_presupuesto_comercial As System.Windows.Forms.MenuItem
    Friend WithEvents mpr_London As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_solicitud_vacaciones As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_ejecuta_sp As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cubo_ventas_por_periodo_complemento As System.Windows.Forms.MenuItem
    Friend WithEvents adu_dua As System.Windows.Forms.MenuItem
    Friend WithEvents adu_di As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents adu_reserva As System.Windows.Forms.MenuItem
    Friend WithEvents adu_solicitud_reserva As System.Windows.Forms.MenuItem
    Friend WithEvents adu_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_listaPrecios As System.Windows.Forms.MenuItem
    Friend WithEvents mco_admon_consignaciones As System.Windows.Forms.MenuItem
    Friend WithEvents mci_scm_establecer_coberturas As System.Windows.Forms.MenuItem
    Friend WithEvents mti_insumos_movimientos As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_sincronizacion_informacion As System.Windows.Forms.MenuItem
    Friend WithEvents mer_productos_derivados As System.Windows.Forms.MenuItem
    Friend WithEvents menuSubirPptoComercial As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_arch_cambiar_periodo As System.Windows.Forms.MenuItem
    Friend WithEvents mco_presupuestoGeneral As System.Windows.Forms.MenuItem
    Friend WithEvents mer_cargarPPTOGeneral As System.Windows.Forms.MenuItem
    Friend WithEvents merForecast As System.Windows.Forms.MenuItem
    Friend WithEvents mfiinventariosFisicos As System.Windows.Forms.MenuItem
    Friend WithEvents mci_soc_fechas_oc As System.Windows.Forms.MenuItem
    Friend WithEvents mti_cuentasContableProductos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_mob_asignacion_rutas As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_actualizacion_prestamos_fecha As System.Windows.Forms.MenuItem
    Friend WithEvents mti_movimientos_activos As System.Windows.Forms.MenuItem
    Friend WithEvents mfiListaCosto As System.Windows.Forms.MenuItem
    Friend WithEvents mfiCambiarDai As System.Windows.Forms.MenuItem
    Friend WithEvents mfi_generarLotes As System.Windows.Forms.MenuItem
    Friend WithEvents mti_Incidencias As System.Windows.Forms.MenuItem
    Friend WithEvents mco_ReportesCorporativos As System.Windows.Forms.MenuItem
    Friend WithEvents mpr_reportesCorporativos As System.Windows.Forms.MenuItem
    Friend WithEvents mci_scm_proceso_compras As System.Windows.Forms.MenuItem
    Friend WithEvents mar_cub_ventasCoporativas As System.Windows.Forms.MenuItem
    Friend WithEvents mrh_ControlAccesos As System.Windows.Forms.MenuItem
    Friend WithEvents mci_soc_documentacion_oc As System.Windows.Forms.MenuItem
    Friend WithEvents mci_tracking_orden_compra As System.Windows.Forms.MenuItem
    Friend WithEvents mci_actualizacion_oc As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_venta_perdida As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_liquidacionGastos As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_controlRegistrosSanitarios As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cuboDevoluciones As System.Windows.Forms.MenuItem
    Friend WithEvents mar_lo_stockDiario As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_nivelServicio As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_productosExistencias As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_salidasEnPedidos As System.Windows.Forms.MenuItem
    Friend WithEvents mco_OdCPedido As System.Windows.Forms.MenuItem
    Friend WithEvents aduEnvioPDA As System.Windows.Forms.MenuItem
    Friend WithEvents aduRecepcionDA As System.Windows.Forms.MenuItem
    Friend WithEvents mco_MaxMinimosVinoteca As System.Windows.Forms.MenuItem
    Friend WithEvents mco_PedidoVinoteca As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_etiq_materiales As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_etiq_OProduccion As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_etiq_ProcesoProduccion As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico1 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico2 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico3 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico4 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico5 As System.Windows.Forms.MenuItem
    Friend WithEvents mar_ol_cubogenerico6 As System.Windows.Forms.MenuItem
    Friend WithEvents mci_int_reportes As System.Windows.Forms.MenuItem
    Friend WithEvents mlo_inventarios_ciclicos As System.Windows.Forms.MenuItem
    Friend WithEvents mci_int_productosBloqueados As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menu_principal))
        Me.menu_principal = New System.Windows.Forms.MainMenu(Me.components)
        Me.m_archivo = New System.Windows.Forms.MenuItem()
        Me.mar_cambiar_empresa = New System.Windows.Forms.MenuItem()
        Me.mar_cambiarclave = New System.Windows.Forms.MenuItem()
        Me.mar_linea = New System.Windows.Forms.MenuItem()
        Me.mar_salir = New System.Windows.Forms.MenuItem()
        Me.mar_flexline = New System.Windows.Forms.MenuItem()
        Me.mar_Vnet = New System.Windows.Forms.MenuItem()
        Me.mar_reverse = New System.Windows.Forms.MenuItem()
        Me.mar_crm = New System.Windows.Forms.MenuItem()
        Me.mar_cubos = New System.Windows.Forms.MenuItem()
        Me.mar_cub_inventario = New System.Windows.Forms.MenuItem()
        Me.mar_cub_cartera = New System.Windows.Forms.MenuItem()
        Me.mar_cub_topventas = New System.Windows.Forms.MenuItem()
        Me.mar_cub_ventasxperiodo = New System.Windows.Forms.MenuItem()
        Me.mar_cub_topinv = New System.Windows.Forms.MenuItem()
        Me.mar_cub_tops = New System.Windows.Forms.MenuItem()
        Me.mar_cub_ventasxrangofecha = New System.Windows.Forms.MenuItem()
        Me.mar_cub_controltransporte = New System.Windows.Forms.MenuItem()
        Me.mar_cub_ventas24meses = New System.Windows.Forms.MenuItem()
        Me.mar_cub_24m_tiendas = New System.Windows.Forms.MenuItem()
        Me.mar_cub_Ventas_Vendedor_Vertical = New System.Windows.Forms.MenuItem()
        Me.mar_cub_ventas_x_dia = New System.Windows.Forms.MenuItem()
        Me.mar_cub_presupuesto_comercial = New System.Windows.Forms.MenuItem()
        Me.mar_cub_listaPrecios = New System.Windows.Forms.MenuItem()
        Me.mar_cub_ventasCoporativas = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_venta_perdida = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cuboDevoluciones = New System.Windows.Forms.MenuItem()
        Me.mar_lo_stockDiario = New System.Windows.Forms.MenuItem()
        Me.mar_ol_nivelServicio = New System.Windows.Forms.MenuItem()
        Me.mar_ol_productosExistencias = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico1 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico2 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico3 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico4 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico5 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico6 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico7 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico8 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico9 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico10 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico11 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico12 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico13 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico14 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_cubogenerico15 = New System.Windows.Forms.MenuItem()
        Me.mar_informacion_productos = New System.Windows.Forms.MenuItem()
        Me.mar_telecomunicaciones = New System.Windows.Forms.MenuItem()
        Me.mar_control_tarea = New System.Windows.Forms.MenuItem()
        Me.mar_cubo_ventas_por_periodo_complemento = New System.Windows.Forms.MenuItem()
        Me.mnu_arch_cambiar_periodo = New System.Windows.Forms.MenuItem()
        Me.mar_cubos_logistica = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mar_ol_tableau1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.m_comercial = New System.Windows.Forms.MenuItem()
        Me.mco_inventario = New System.Windows.Forms.MenuItem()
        Me.mco_dma_reportes = New System.Windows.Forms.MenuItem()
        Me.mco_cdc_reportes = New System.Windows.Forms.MenuItem()
        Me.mco_ala_reportes = New System.Windows.Forms.MenuItem()
        Me.mco_trancking_pedidos = New System.Windows.Forms.MenuItem()
        Me.mco_consulta_clientes = New System.Windows.Forms.MenuItem()
        Me.mco_liberar_ppto_cliente = New System.Windows.Forms.MenuItem()
        Me.mco_tec_reportes = New System.Windows.Forms.MenuItem()
        Me.mco_cdc_liberar_pedidos_MR = New System.Windows.Forms.MenuItem()
        Me.mco_back_order = New System.Windows.Forms.MenuItem()
        Me.mco_liberar_ppto_producto = New System.Windows.Forms.MenuItem()
        Me.mco_cdc_reportes_mayoristas = New System.Windows.Forms.MenuItem()
        Me.mco_cdc_mensajeria = New System.Windows.Forms.MenuItem()
        Me.mco_cdc_productos_mr = New System.Windows.Forms.MenuItem()
        Me.mco_diu_reportes = New System.Windows.Forms.MenuItem()
        Me.mco_vin_reportes = New System.Windows.Forms.MenuItem()
        Me.mco_enviar_picking = New System.Windows.Forms.MenuItem()
        Me.mco_admon_consignaciones = New System.Windows.Forms.MenuItem()
        Me.menuSubirPptoComercial = New System.Windows.Forms.MenuItem()
        Me.mco_presupuestoGeneral = New System.Windows.Forms.MenuItem()
        Me.mco_mob_asignacion_rutas = New System.Windows.Forms.MenuItem()
        Me.mco_ReportesCorporativos = New System.Windows.Forms.MenuItem()
        Me.mco_OdCPedido = New System.Windows.Forms.MenuItem()
        Me.mco_MaxMinimosVinoteca = New System.Windows.Forms.MenuItem()
        Me.mco_PedidoVinoteca = New System.Windows.Forms.MenuItem()
        Me.mcoEdifact = New System.Windows.Forms.MenuItem()
        Me.mco_devoluciones = New System.Windows.Forms.MenuItem()
        Me.mcoFacturacionCosto = New System.Windows.Forms.MenuItem()
        Me.mco_div_pedido = New System.Windows.Forms.MenuItem()
        Me.mco_pedidos_telemarketing = New System.Windows.Forms.MenuItem()
        Me.mco_ws_productos = New System.Windows.Forms.MenuItem()
        Me.mco_ws_clientes = New System.Windows.Forms.MenuItem()
        Me.mco_ws_envios = New System.Windows.Forms.MenuItem()
        Me.mco_trancking_factura = New System.Windows.Forms.MenuItem()
        Me.mco_actualizacion_sku = New System.Windows.Forms.MenuItem()
        Me.mco_reproceso_isf = New System.Windows.Forms.MenuItem()
        Me.mco_ws_entregas = New System.Windows.Forms.MenuItem()
        Me.mco_div_reportes = New System.Windows.Forms.MenuItem()
        Me.mco_edi_inner_pack = New System.Windows.Forms.MenuItem()
        Me.mco_clientesContado = New System.Windows.Forms.MenuItem()
        Me.mcoRetailLink = New System.Windows.Forms.MenuItem()
        Me.mco_actualizacion_productos = New System.Windows.Forms.MenuItem()
        Me.mco_mercaderistas = New System.Windows.Forms.MenuItem()
        Me.mco_edi_validacion_oc_wm = New System.Windows.Forms.MenuItem()
        Me.mco_MonitorMaquila = New System.Windows.Forms.MenuItem()
        Me.mco_devolucionesInterempresas = New System.Windows.Forms.MenuItem()
        Me.mco_edi_carga_informacion_bi = New System.Windows.Forms.MenuItem()
        Me.mco_presupuesto_marca_ayp = New System.Windows.Forms.MenuItem()
        Me.mco_PedidoVinoteca_Bodegas = New System.Windows.Forms.MenuItem()
        Me.mco_claim = New System.Windows.Forms.MenuItem()
        Me.mco_vin_sincronizar_memos = New System.Windows.Forms.MenuItem()
        Me.mco_vin_sincronizar_productos = New System.Windows.Forms.MenuItem()
        Me.mco_pedidos_unisuper = New System.Windows.Forms.MenuItem()
        Me.mco_reimpresion_fel = New System.Windows.Forms.MenuItem()
        Me.mco_vinoteca_liberar_salidas = New System.Windows.Forms.MenuItem()
        Me.mco_vinoteca_entradaxtraslados = New System.Windows.Forms.MenuItem()
        Me.mco_recepcion_mercaderia_vinoteca = New System.Windows.Forms.MenuItem()
        Me.mco_administracion_escasez = New System.Windows.Forms.MenuItem()
        Me.mco_actualizacion_sku_unisuper = New System.Windows.Forms.MenuItem()
        Me.mco_vin_solicitud_traslados = New System.Windows.Forms.MenuItem()
        Me.m_rh = New System.Windows.Forms.MenuItem()
        Me.mrh_pq = New System.Windows.Forms.MenuItem()
        Me.mrh_pq_reportes = New System.Windows.Forms.MenuItem()
        Me.mrh_sq = New System.Windows.Forms.MenuItem()
        Me.mrh_sq_reportes = New System.Windows.Forms.MenuItem()
        Me.mrh_ge = New System.Windows.Forms.MenuItem()
        Me.mrh_ge_reportes = New System.Windows.Forms.MenuItem()
        Me.mrh_ll = New System.Windows.Forms.MenuItem()
        Me.mrh_ll_reportes = New System.Windows.Forms.MenuItem()
        Me.mrh_cancela_prestamo = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mrh_solicitud_vacaciones = New System.Windows.Forms.MenuItem()
        Me.mrh_actualizacion_prestamos_fecha = New System.Windows.Forms.MenuItem()
        Me.mrh_ControlAccesos = New System.Windows.Forms.MenuItem()
        Me.mrh_evaluacion = New System.Windows.Forms.MenuItem()
        Me.mrh_suspensiones = New System.Windows.Forms.MenuItem()
        Me.mrh_traslado_empleados = New System.Windows.Forms.MenuItem()
        Me.mrh_candidatos = New System.Windows.Forms.MenuItem()
        Me.mrh_garita = New System.Windows.Forms.MenuItem()
        Me.mrh_bono14 = New System.Windows.Forms.MenuItem()
        Me.m_finanzas = New System.Windows.Forms.MenuItem()
        Me.mfi_SacarFacturas = New System.Windows.Forms.MenuItem()
        Me.mfi_consignaciones = New System.Windows.Forms.MenuItem()
        Me.mfi_fc_reportes = New System.Windows.Forms.MenuItem()
        Me.mfi_cr_reportes = New System.Windows.Forms.MenuItem()
        Me.mfi_co_reportes = New System.Windows.Forms.MenuItem()
        Me.mfi_cr_pedidos_pendientes = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.mfi_liberar_facturas = New System.Windows.Forms.MenuItem()
        Me.mfi_if_reportes = New System.Windows.Forms.MenuItem()
        Me.mfi_inicializar_periodo = New System.Windows.Forms.MenuItem()
        Me.mfi_fc_pedidos_facturar = New System.Windows.Forms.MenuItem()
        Me.mfi_cr_recepcion_Control_transporte = New System.Windows.Forms.MenuItem()
        Me.mfi_cr_snc_clientes = New System.Windows.Forms.MenuItem()
        Me.mfi_enviar_factura = New System.Windows.Forms.MenuItem()
        Me.mfi_ejecuta_sp = New System.Windows.Forms.MenuItem()
        Me.mfi_sincronizacion_informacion = New System.Windows.Forms.MenuItem()
        Me.mfiinventariosFisicos = New System.Windows.Forms.MenuItem()
        Me.mfiListaCosto = New System.Windows.Forms.MenuItem()
        Me.mfiCambiarDai = New System.Windows.Forms.MenuItem()
        Me.mfi_generarLotes = New System.Windows.Forms.MenuItem()
        Me.mfi_co_cface = New System.Windows.Forms.MenuItem()
        Me.mfi_fc_FACE = New System.Windows.Forms.MenuItem()
        Me.mfi_cancelacion_Compromisos = New System.Windows.Forms.MenuItem()
        Me.mfi_cr_recibos_canal_moderno = New System.Windows.Forms.MenuItem()
        Me.mfi_cr_envio_documentos_canal_moderno = New System.Windows.Forms.MenuItem()
        Me.mfi_cr_recepcion_devoluciones = New System.Windows.Forms.MenuItem()
        Me.mfiOperacionRecibos = New System.Windows.Forms.MenuItem()
        Me.mfi_costo_ingresoCD = New System.Windows.Forms.MenuItem()
        Me.mfi_fac_direccionar_impresoras = New System.Windows.Forms.MenuItem()
        Me.mfi_caja_chica = New System.Windows.Forms.MenuItem()
        Me.mfi_fac_compras_interempresas = New System.Windows.Forms.MenuItem()
        Me.mfi_co_item_producto = New System.Windows.Forms.MenuItem()
        Me.mfi_co_conciliacionBancaria = New System.Windows.Forms.MenuItem()
        Me.mfi_con_productos_contables = New System.Windows.Forms.MenuItem()
        Me.mfi_con_analisis_facturas = New System.Windows.Forms.MenuItem()
        Me.mfi_cre_analisis_facturas = New System.Windows.Forms.MenuItem()
        Me.mfi_con_tracking_pagos = New System.Windows.Forms.MenuItem()
        Me.mfi_fc_traslado_facturas = New System.Windows.Forms.MenuItem()
        Me.mfi_caja_chica_multiple = New System.Windows.Forms.MenuItem()
        Me.mfi_cre_consolidacion_consignaciones = New System.Windows.Forms.MenuItem()
        Me.mfi_cre_procesos_fel = New System.Windows.Forms.MenuItem()
        Me.mfi_fc_fel_telemarketing = New System.Windows.Forms.MenuItem()
        Me.mfi_cre_pagos_exterior = New System.Windows.Forms.MenuItem()
        Me.mfi_co_carga_combustible = New System.Windows.Forms.MenuItem()
        Me.mfi_co_liquidacion_caja_chica_teams = New System.Windows.Forms.MenuItem()
        Me.mfi_cre_liquidacion_transportes_caja = New System.Windows.Forms.MenuItem()
        Me.mfi_cre_monitor_impresiones = New System.Windows.Forms.MenuItem()
        Me.mfi_con_anulacionFEL = New System.Windows.Forms.MenuItem()
        Me.mfi_con_tracking_caja_chica = New System.Windows.Forms.MenuItem()
        Me.mfi_fac_monitor_impresiones_recolecta = New System.Windows.Forms.MenuItem()
        Me.m_ti = New System.Windows.Forms.MenuItem()
        Me.mti_isf = New System.Windows.Forms.MenuItem()
        Me.mti_usuario = New System.Windows.Forms.MenuItem()
        Me.mti_diseñador = New System.Windows.Forms.MenuItem()
        Me.mti_reportes = New System.Windows.Forms.MenuItem()
        Me.mti_conversiones = New System.Windows.Forms.MenuItem()
        Me.mti_insumos = New System.Windows.Forms.MenuItem()
        Me.mti_plasma = New System.Windows.Forms.MenuItem()
        Me.mti_jsa = New System.Windows.Forms.MenuItem()
        Me.mti_control_fallas = New System.Windows.Forms.MenuItem()
        Me.mti_scn_precios_ofertas = New System.Windows.Forms.MenuItem()
        Me.mti_scn_productos = New System.Windows.Forms.MenuItem()
        Me.mti_activos = New System.Windows.Forms.MenuItem()
        Me.mti_eface = New System.Windows.Forms.MenuItem()
        Me.mti_actualizacion_producto = New System.Windows.Forms.MenuItem()
        Me.mti_insumos_movimientos = New System.Windows.Forms.MenuItem()
        Me.mti_cuentasContableProductos = New System.Windows.Forms.MenuItem()
        Me.mti_movimientos_activos = New System.Windows.Forms.MenuItem()
        Me.mti_Incidencias = New System.Windows.Forms.MenuItem()
        Me.mti_dts = New System.Windows.Forms.MenuItem()
        Me.mnuAnuladorInFile = New System.Windows.Forms.MenuItem()
        Me.m_logistica = New System.Windows.Forms.MenuItem()
        Me.mlo_reportes = New System.Windows.Forms.MenuItem()
        Me.mlo_reportes_picking = New System.Windows.Forms.MenuItem()
        Me.mlo_finalizacion_picking = New System.Windows.Forms.MenuItem()
        Me.mlo_impresion_picking_manual = New System.Windows.Forms.MenuItem()
        Me.mlo_control_transporte = New System.Windows.Forms.MenuItem()
        Me.mlo_asociar_es_inventario = New System.Windows.Forms.MenuItem()
        Me.mlo_scn_Movimientos_Inventario = New System.Windows.Forms.MenuItem()
        Me.mlo_maq_monitor = New System.Windows.Forms.MenuItem()
        Me.mlo_pedidos_posfechados = New System.Windows.Forms.MenuItem()
        Me.mlo_liquidacionGastos = New System.Windows.Forms.MenuItem()
        Me.mlo_controlRegistrosSanitarios = New System.Windows.Forms.MenuItem()
        Me.mlo_salidasEnPedidos = New System.Windows.Forms.MenuItem()
        Me.mlo_etiq_materiales = New System.Windows.Forms.MenuItem()
        Me.mlo_etiq_OProduccion = New System.Windows.Forms.MenuItem()
        Me.mlo_etiq_ProcesoProduccion = New System.Windows.Forms.MenuItem()
        Me.mlo_inventarios_ciclicos = New System.Windows.Forms.MenuItem()
        Me.mlo_liquidacionPiloto = New System.Windows.Forms.MenuItem()
        Me.mlo_ImpresionOrdenesEDI = New System.Windows.Forms.MenuItem()
        Me.mlo_cambioHorario = New System.Windows.Forms.MenuItem()
        Me.mlo_ReporteHorario = New System.Windows.Forms.MenuItem()
        Me.mlo_devolucionesrechazos = New System.Windows.Forms.MenuItem()
        Me.mlo_ComprasInterEmpresas = New System.Windows.Forms.MenuItem()
        Me.mlo_series = New System.Windows.Forms.MenuItem()
        Me.mlo_planificacion_rutas = New System.Windows.Forms.MenuItem()
        Me.mlo_asignacion_picking = New System.Windows.Forms.MenuItem()
        Me.mlo_parametrizacion_picking = New System.Windows.Forms.MenuItem()
        Me.mlo_chequeo = New System.Windows.Forms.MenuItem()
        Me.mlo_facturacionANIXTER = New System.Windows.Forms.MenuItem()
        Me.mlo_productosANIXTER = New System.Windows.Forms.MenuItem()
        Me.mlo_tra_liberar_facturas = New System.Windows.Forms.MenuItem()
        Me.mlo_actualizacion_productos = New System.Windows.Forms.MenuItem()
        Me.mlo_tr_generarInformacion = New System.Windows.Forms.MenuItem()
        Me.mlo_actualizacion_pedidowalmart = New System.Windows.Forms.MenuItem()
        Me.mlo_tra_notasdevolucion = New System.Windows.Forms.MenuItem()
        Me.mlo_ingresos_cd = New System.Windows.Forms.MenuItem()
        Me.mlo_tr_cumplimiento_diario_rentado = New System.Windows.Forms.MenuItem()
        Me.mlo_reasignacionPicking = New System.Windows.Forms.MenuItem()
        Me.mlo_agregar_reenvios = New System.Windows.Forms.MenuItem()
        Me.mlo_tr_cumplimiento_entregas = New System.Windows.Forms.MenuItem()
        Me.mlo_tr_editar_marcajes = New System.Windows.Forms.MenuItem()
        Me.mlo_picking_3pl = New System.Windows.Forms.MenuItem()
        Me.mlo_informe_recepcion_3pl = New System.Windows.Forms.MenuItem()
        Me.mlo_procesar_pedidos_3pl = New System.Windows.Forms.MenuItem()
        Me.mlo_montor_impresiones_AG = New System.Windows.Forms.MenuItem()
        Me.mlo_transporte_tmk = New System.Windows.Forms.MenuItem()
        Me.mlo_picking_tmk = New System.Windows.Forms.MenuItem()
        Me.mlo_recepcionFacturas = New System.Windows.Forms.MenuItem()
        Me.mlo_tr_recolecciones = New System.Windows.Forms.MenuItem()
        Me.m_presidencia = New System.Windows.Forms.MenuItem()
        Me.mpr_reportes = New System.Windows.Forms.MenuItem()
        Me.mpr_London = New System.Windows.Forms.MenuItem()
        Me.mpr_reportesCorporativos = New System.Windows.Forms.MenuItem()
        Me.m_compras = New System.Windows.Forms.MenuItem()
        Me.mci_reportes = New System.Windows.Forms.MenuItem()
        Me.mci_odc_edifact = New System.Windows.Forms.MenuItem()
        Me.mci_reportes_adicionales = New System.Windows.Forms.MenuItem()
        Me.mci_liberar_documentos = New System.Windows.Forms.MenuItem()
        Me.mci_scm_mantenimiento_proveedores = New System.Windows.Forms.MenuItem()
        Me.mci_scm_parametros = New System.Windows.Forms.MenuItem()
        Me.mci_scm_mantenimiento_productos = New System.Windows.Forms.MenuItem()
        Me.mci_scm_establecer_pedido = New System.Windows.Forms.MenuItem()
        Me.mci_int_parametros = New System.Windows.Forms.MenuItem()
        Me.mci_int_traslado = New System.Windows.Forms.MenuItem()
        Me.mci_int_listado = New System.Windows.Forms.MenuItem()
        Me.mci_scm_ver_pedidos = New System.Windows.Forms.MenuItem()
        Me.adu_di = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.adu_reserva = New System.Windows.Forms.MenuItem()
        Me.adu_solicitud_reserva = New System.Windows.Forms.MenuItem()
        Me.adu_reportes = New System.Windows.Forms.MenuItem()
        Me.adu_dua = New System.Windows.Forms.MenuItem()
        Me.mci_scm_establecer_coberturas = New System.Windows.Forms.MenuItem()
        Me.mci_soc_fechas_oc = New System.Windows.Forms.MenuItem()
        Me.mci_scm_proceso_compras = New System.Windows.Forms.MenuItem()
        Me.mci_soc_documentacion_oc = New System.Windows.Forms.MenuItem()
        Me.mci_tracking_orden_compra = New System.Windows.Forms.MenuItem()
        Me.mci_actualizacion_oc = New System.Windows.Forms.MenuItem()
        Me.aduEnvioPDA = New System.Windows.Forms.MenuItem()
        Me.aduRecepcionDA = New System.Windows.Forms.MenuItem()
        Me.mci_int_reportes = New System.Windows.Forms.MenuItem()
        Me.mci_int_productosBloqueados = New System.Windows.Forms.MenuItem()
        Me.mci_trackingInternaciones = New System.Windows.Forms.MenuItem()
        Me.adu_DR = New System.Windows.Forms.MenuItem()
        Me.adu_trasladoDUA = New System.Windows.Forms.MenuItem()
        Me.mco_solicitudRequisiciones = New System.Windows.Forms.MenuItem()
        Me.mco_mantenedorITEM = New System.Windows.Forms.MenuItem()
        Me.mco_mantenedorPrecios = New System.Windows.Forms.MenuItem()
        Me.mco_EnvioOrdenesCompra = New System.Windows.Forms.MenuItem()
        Me.mco_RecepcionOrdenesCompra = New System.Windows.Forms.MenuItem()
        Me.mco_EnvioOrdenesCompraConta = New System.Windows.Forms.MenuItem()
        Me.adu_InventarioFisicoDA = New System.Windows.Forms.MenuItem()
        Me.mlo_ci_etiquetado = New System.Windows.Forms.MenuItem()
        Me.mci_tracking_oc_tesoreria = New System.Windows.Forms.MenuItem()
        Me.mci_soc_complemento_divinos = New System.Windows.Forms.MenuItem()
        Me.mco_RecepcionFacturas_Requisicion = New System.Windows.Forms.MenuItem()
        Me.mco_Envio_Facturas_Recepcion = New System.Windows.Forms.MenuItem()
        Me.mci_soc_ocdivinos = New System.Windows.Forms.MenuItem()
        Me.mco_requisicionesProyecto = New System.Windows.Forms.MenuItem()
        Me.m_telemarketing = New System.Windows.Forms.MenuItem()
        Me.tmk_reportes = New System.Windows.Forms.MenuItem()
        Me.m_mercadeo = New System.Windows.Forms.MenuItem()
        Me.mer_reportes = New System.Windows.Forms.MenuItem()
        Me.mer_memos_promocionales = New System.Windows.Forms.MenuItem()
        Me.mer_anular_memos_promocionales = New System.Windows.Forms.MenuItem()
        Me.mer_mem_reportes = New System.Windows.Forms.MenuItem()
        Me.mer_mem_revision_OC = New System.Windows.Forms.MenuItem()
        Me.mer_mem_solicitud_productos = New System.Windows.Forms.MenuItem()
        Me.mer_cambio_precio = New System.Windows.Forms.MenuItem()
        Me.mer_productos_derivados = New System.Windows.Forms.MenuItem()
        Me.mer_cargarPPTOGeneral = New System.Windows.Forms.MenuItem()
        Me.merForecast = New System.Windows.Forms.MenuItem()
        Me.merEvualuacionDIAGEO = New System.Windows.Forms.MenuItem()
        Me.mer_MantenedorPrecios = New System.Windows.Forms.MenuItem()
        Me.mer_actualizacionProductos = New System.Windows.Forms.MenuItem()
        Me.mer_actualizacionProductosIE = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pb_it = New System.Windows.Forms.PictureBox()
        Me.pb_logo = New System.Windows.Forms.PictureBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
        Me.btnOpcion1 = New System.Windows.Forms.Button()
        Me.btnOpcion2 = New System.Windows.Forms.Button()
        Me.gbOpcines = New System.Windows.Forms.GroupBox()
        Me.btnOpcion3 = New System.Windows.Forms.Button()
        CType(Me.pb_it, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpcines.SuspendLayout()
        Me.SuspendLayout()
        '
        'menu_principal
        '
        Me.menu_principal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.m_archivo, Me.m_comercial, Me.m_rh, Me.m_finanzas, Me.m_ti, Me.m_logistica, Me.m_presidencia, Me.m_compras, Me.m_telemarketing, Me.m_mercadeo})
        '
        'm_archivo
        '
        Me.m_archivo.Index = 0
        Me.m_archivo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mar_cambiar_empresa, Me.mar_cambiarclave, Me.mar_linea, Me.mar_salir, Me.mar_flexline, Me.mar_Vnet, Me.mar_reverse, Me.mar_crm, Me.mar_cubos, Me.mar_informacion_productos, Me.mar_telecomunicaciones, Me.mar_control_tarea, Me.mar_cubo_ventas_por_periodo_complemento, Me.mnu_arch_cambiar_periodo, Me.mar_cubos_logistica, Me.MenuItem3})
        Me.m_archivo.Text = "Archivo"
        '
        'mar_cambiar_empresa
        '
        Me.mar_cambiar_empresa.Index = 0
        Me.mar_cambiar_empresa.Text = "&Cambiar Empresa"
        '
        'mar_cambiarclave
        '
        Me.mar_cambiarclave.Index = 1
        Me.mar_cambiarclave.Text = "Cambiar Contraseña"
        '
        'mar_linea
        '
        Me.mar_linea.Index = 2
        Me.mar_linea.Text = "-"
        '
        'mar_salir
        '
        Me.mar_salir.Index = 3
        Me.mar_salir.Text = "Salir"
        '
        'mar_flexline
        '
        Me.mar_flexline.Index = 4
        Me.mar_flexline.Text = "FlexLine"
        '
        'mar_Vnet
        '
        Me.mar_Vnet.Index = 5
        Me.mar_Vnet.Text = "Vnet"
        '
        'mar_reverse
        '
        Me.mar_reverse.Index = 6
        Me.mar_reverse.Text = "Reverse"
        '
        'mar_crm
        '
        Me.mar_crm.Index = 7
        Me.mar_crm.Text = "CRM"
        '
        'mar_cubos
        '
        Me.mar_cubos.Index = 8
        Me.mar_cubos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mar_cub_inventario, Me.mar_cub_cartera, Me.mar_cub_topventas, Me.mar_cub_ventasxperiodo, Me.mar_cub_topinv, Me.mar_cub_tops, Me.mar_cub_ventasxrangofecha, Me.mar_cub_controltransporte, Me.mar_cub_ventas24meses, Me.mar_cub_24m_tiendas, Me.mar_cub_Ventas_Vendedor_Vertical, Me.mar_cub_ventas_x_dia, Me.mar_cub_presupuesto_comercial, Me.mar_cub_listaPrecios, Me.mar_cub_ventasCoporativas, Me.MenuItem2, Me.mar_ol_venta_perdida, Me.mar_ol_cuboDevoluciones, Me.mar_lo_stockDiario, Me.mar_ol_nivelServicio, Me.mar_ol_productosExistencias, Me.mar_ol_cubogenerico1, Me.mar_ol_cubogenerico2, Me.mar_ol_cubogenerico3, Me.mar_ol_cubogenerico4, Me.mar_ol_cubogenerico5, Me.mar_ol_cubogenerico6, Me.mar_ol_cubogenerico7, Me.mar_ol_cubogenerico8, Me.mar_ol_cubogenerico9, Me.mar_ol_cubogenerico10, Me.mar_ol_cubogenerico11, Me.mar_ol_cubogenerico12, Me.mar_ol_cubogenerico13, Me.mar_ol_cubogenerico14, Me.mar_ol_cubogenerico15})
        Me.mar_cubos.Text = "Cubos"
        '
        'mar_cub_inventario
        '
        Me.mar_cub_inventario.Index = 0
        Me.mar_cub_inventario.Text = "inventario"
        '
        'mar_cub_cartera
        '
        Me.mar_cub_cartera.Index = 1
        Me.mar_cub_cartera.Text = "cartera"
        '
        'mar_cub_topventas
        '
        Me.mar_cub_topventas.Index = 2
        Me.mar_cub_topventas.Text = "topventas"
        '
        'mar_cub_ventasxperiodo
        '
        Me.mar_cub_ventasxperiodo.Index = 3
        Me.mar_cub_ventasxperiodo.Text = "ventasxperiodo"
        '
        'mar_cub_topinv
        '
        Me.mar_cub_topinv.Index = 4
        Me.mar_cub_topinv.Text = "topinventario"
        '
        'mar_cub_tops
        '
        Me.mar_cub_tops.Index = 5
        Me.mar_cub_tops.Text = "tops"
        '
        'mar_cub_ventasxrangofecha
        '
        Me.mar_cub_ventasxrangofecha.Index = 6
        Me.mar_cub_ventasxrangofecha.Text = "ventasxrangofecha"
        '
        'mar_cub_controltransporte
        '
        Me.mar_cub_controltransporte.Index = 7
        Me.mar_cub_controltransporte.Text = "Control de Transporte"
        '
        'mar_cub_ventas24meses
        '
        Me.mar_cub_ventas24meses.Index = 8
        Me.mar_cub_ventas24meses.Text = "Ventas 24 Meses"
        '
        'mar_cub_24m_tiendas
        '
        Me.mar_cub_24m_tiendas.Index = 9
        Me.mar_cub_24m_tiendas.Text = "Ventas 24 Meses Tiendas"
        '
        'mar_cub_Ventas_Vendedor_Vertical
        '
        Me.mar_cub_Ventas_Vendedor_Vertical.Index = 10
        Me.mar_cub_Ventas_Vendedor_Vertical.Text = "Cubo_Ventas_Vendedor_Vertical"
        '
        'mar_cub_ventas_x_dia
        '
        Me.mar_cub_ventas_x_dia.Index = 11
        Me.mar_cub_ventas_x_dia.Text = "Ventas x Dia"
        '
        'mar_cub_presupuesto_comercial
        '
        Me.mar_cub_presupuesto_comercial.Index = 12
        Me.mar_cub_presupuesto_comercial.Text = "Presupuesto Comercial"
        '
        'mar_cub_listaPrecios
        '
        Me.mar_cub_listaPrecios.Index = 13
        Me.mar_cub_listaPrecios.Text = "ListasdePrecios"
        '
        'mar_cub_ventasCoporativas
        '
        Me.mar_cub_ventasCoporativas.Index = 14
        Me.mar_cub_ventasCoporativas.Text = "Ventas Corporativo"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 15
        Me.MenuItem2.Text = "Cuentas Por Cobrar"
        '
        'mar_ol_venta_perdida
        '
        Me.mar_ol_venta_perdida.Index = 16
        Me.mar_ol_venta_perdida.Text = "Venta Perdida"
        '
        'mar_ol_cuboDevoluciones
        '
        Me.mar_ol_cuboDevoluciones.Index = 17
        Me.mar_ol_cuboDevoluciones.Text = "Devoluciones"
        '
        'mar_lo_stockDiario
        '
        Me.mar_lo_stockDiario.Index = 18
        Me.mar_lo_stockDiario.Text = "Stok Diario Tarimas"
        '
        'mar_ol_nivelServicio
        '
        Me.mar_ol_nivelServicio.Index = 19
        Me.mar_ol_nivelServicio.Text = "Nivel de Servicio"
        '
        'mar_ol_productosExistencias
        '
        Me.mar_ol_productosExistencias.Index = 20
        Me.mar_ol_productosExistencias.Text = "Productos Precios Existencias"
        '
        'mar_ol_cubogenerico1
        '
        Me.mar_ol_cubogenerico1.Index = 21
        Me.mar_ol_cubogenerico1.Text = "Cubo Generico 1"
        Me.mar_ol_cubogenerico1.Visible = False
        '
        'mar_ol_cubogenerico2
        '
        Me.mar_ol_cubogenerico2.Index = 22
        Me.mar_ol_cubogenerico2.Text = "Cubo Generico 2"
        Me.mar_ol_cubogenerico2.Visible = False
        '
        'mar_ol_cubogenerico3
        '
        Me.mar_ol_cubogenerico3.Index = 23
        Me.mar_ol_cubogenerico3.Text = "Cubo Generico 3"
        Me.mar_ol_cubogenerico3.Visible = False
        '
        'mar_ol_cubogenerico4
        '
        Me.mar_ol_cubogenerico4.Index = 24
        Me.mar_ol_cubogenerico4.Text = "Cubo Generico 4"
        Me.mar_ol_cubogenerico4.Visible = False
        '
        'mar_ol_cubogenerico5
        '
        Me.mar_ol_cubogenerico5.Index = 25
        Me.mar_ol_cubogenerico5.Text = "Cubo Generico 5"
        Me.mar_ol_cubogenerico5.Visible = False
        '
        'mar_ol_cubogenerico6
        '
        Me.mar_ol_cubogenerico6.Index = 26
        Me.mar_ol_cubogenerico6.Text = "Cubo Generico 6"
        Me.mar_ol_cubogenerico6.Visible = False
        '
        'mar_ol_cubogenerico7
        '
        Me.mar_ol_cubogenerico7.Index = 27
        Me.mar_ol_cubogenerico7.Text = "Cubo Generico 7"
        '
        'mar_ol_cubogenerico8
        '
        Me.mar_ol_cubogenerico8.Index = 28
        Me.mar_ol_cubogenerico8.Text = "Cubo Generico 8"
        '
        'mar_ol_cubogenerico9
        '
        Me.mar_ol_cubogenerico9.Index = 29
        Me.mar_ol_cubogenerico9.Text = "Cubo Generico 9"
        '
        'mar_ol_cubogenerico10
        '
        Me.mar_ol_cubogenerico10.Index = 30
        Me.mar_ol_cubogenerico10.Text = "Cubo Generico 10"
        '
        'mar_ol_cubogenerico11
        '
        Me.mar_ol_cubogenerico11.Index = 31
        Me.mar_ol_cubogenerico11.Text = "Cubo Generico 11"
        '
        'mar_ol_cubogenerico12
        '
        Me.mar_ol_cubogenerico12.Index = 32
        Me.mar_ol_cubogenerico12.Text = "Cubo Generico 12"
        '
        'mar_ol_cubogenerico13
        '
        Me.mar_ol_cubogenerico13.Index = 33
        Me.mar_ol_cubogenerico13.Text = "Cubo Generico 13"
        '
        'mar_ol_cubogenerico14
        '
        Me.mar_ol_cubogenerico14.Index = 34
        Me.mar_ol_cubogenerico14.Text = "Cubo Generico 14"
        '
        'mar_ol_cubogenerico15
        '
        Me.mar_ol_cubogenerico15.Index = 35
        Me.mar_ol_cubogenerico15.Text = "Cubo Generico 15"
        '
        'mar_informacion_productos
        '
        Me.mar_informacion_productos.Index = 9
        Me.mar_informacion_productos.Text = "Informacion de Productos"
        '
        'mar_telecomunicaciones
        '
        Me.mar_telecomunicaciones.Index = 10
        Me.mar_telecomunicaciones.Text = "Telecomunicaciones"
        '
        'mar_control_tarea
        '
        Me.mar_control_tarea.Index = 11
        Me.mar_control_tarea.Text = "C&ontrol de Tareas"
        '
        'mar_cubo_ventas_por_periodo_complemento
        '
        Me.mar_cubo_ventas_por_periodo_complemento.Index = 12
        Me.mar_cubo_ventas_por_periodo_complemento.Text = "asdasd"
        '
        'mnu_arch_cambiar_periodo
        '
        Me.mnu_arch_cambiar_periodo.Index = 13
        Me.mnu_arch_cambiar_periodo.Text = "Cambiar Periodo"
        '
        'mar_cubos_logistica
        '
        Me.mar_cubos_logistica.Index = 14
        Me.mar_cubos_logistica.Text = "Cubos Logistica"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 15
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mar_ol_tableau1, Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem9, Me.MenuItem10, Me.MenuItem12, Me.MenuItem13, Me.MenuItem14, Me.MenuItem15})
        Me.MenuItem3.Text = "Tableau"
        '
        'mar_ol_tableau1
        '
        Me.mar_ol_tableau1.Index = 0
        Me.mar_ol_tableau1.Text = "tableau1"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 1
        Me.MenuItem6.Text = "tableau2"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 2
        Me.MenuItem7.Text = "tableau3"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 3
        Me.MenuItem8.Text = "tableau4"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 4
        Me.MenuItem9.Text = "tableau5"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 5
        Me.MenuItem10.Text = "tableau6"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 6
        Me.MenuItem12.Text = "tableau7"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 7
        Me.MenuItem13.Text = "tableau8"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 8
        Me.MenuItem14.Text = "tableau9"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 9
        Me.MenuItem15.Text = "tableau10"
        '
        'm_comercial
        '
        Me.m_comercial.Index = 1
        Me.m_comercial.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mco_inventario, Me.mco_dma_reportes, Me.mco_cdc_reportes, Me.mco_ala_reportes, Me.mco_trancking_pedidos, Me.mco_consulta_clientes, Me.mco_liberar_ppto_cliente, Me.mco_tec_reportes, Me.mco_cdc_liberar_pedidos_MR, Me.mco_back_order, Me.mco_liberar_ppto_producto, Me.mco_cdc_reportes_mayoristas, Me.mco_cdc_mensajeria, Me.mco_cdc_productos_mr, Me.mco_diu_reportes, Me.mco_vin_reportes, Me.mco_enviar_picking, Me.mco_admon_consignaciones, Me.menuSubirPptoComercial, Me.mco_presupuestoGeneral, Me.mco_mob_asignacion_rutas, Me.mco_ReportesCorporativos, Me.mco_OdCPedido, Me.mco_MaxMinimosVinoteca, Me.mco_PedidoVinoteca, Me.mcoEdifact, Me.mco_devoluciones, Me.mcoFacturacionCosto, Me.mco_div_pedido, Me.mco_pedidos_telemarketing, Me.mco_ws_productos, Me.mco_ws_clientes, Me.mco_ws_envios, Me.mco_trancking_factura, Me.mco_actualizacion_sku, Me.mco_reproceso_isf, Me.mco_ws_entregas, Me.mco_div_reportes, Me.mco_edi_inner_pack, Me.mco_clientesContado, Me.mcoRetailLink, Me.mco_actualizacion_productos, Me.mco_mercaderistas, Me.mco_edi_validacion_oc_wm, Me.mco_MonitorMaquila, Me.mco_devolucionesInterempresas, Me.mco_edi_carga_informacion_bi, Me.mco_presupuesto_marca_ayp, Me.mco_PedidoVinoteca_Bodegas, Me.mco_claim, Me.mco_vin_sincronizar_memos, Me.mco_vin_sincronizar_productos, Me.mco_pedidos_unisuper, Me.mco_reimpresion_fel, Me.mco_vinoteca_liberar_salidas, Me.mco_vinoteca_entradaxtraslados, Me.mco_recepcion_mercaderia_vinoteca, Me.mco_administracion_escasez, Me.mco_actualizacion_sku_unisuper, Me.mco_vin_solicitud_traslados})
        Me.m_comercial.Text = "Comercial"
        '
        'mco_inventario
        '
        Me.mco_inventario.Index = 0
        Me.mco_inventario.Text = "Inventario Clientes"
        '
        'mco_dma_reportes
        '
        Me.mco_dma_reportes.Index = 1
        Me.mco_dma_reportes.Text = "Reportes"
        '
        'mco_cdc_reportes
        '
        Me.mco_cdc_reportes.Index = 2
        Me.mco_cdc_reportes.Text = "reportes cdc"
        '
        'mco_ala_reportes
        '
        Me.mco_ala_reportes.Index = 3
        Me.mco_ala_reportes.Text = "reportes ala"
        '
        'mco_trancking_pedidos
        '
        Me.mco_trancking_pedidos.Index = 4
        Me.mco_trancking_pedidos.Text = "Tracking Pedidos"
        '
        'mco_consulta_clientes
        '
        Me.mco_consulta_clientes.Index = 5
        Me.mco_consulta_clientes.Text = "Consulta Clientes"
        '
        'mco_liberar_ppto_cliente
        '
        Me.mco_liberar_ppto_cliente.Index = 6
        Me.mco_liberar_ppto_cliente.Text = "Liberar Presupuesto Cliente"
        '
        'mco_tec_reportes
        '
        Me.mco_tec_reportes.Index = 7
        Me.mco_tec_reportes.Text = "reportes tecno"
        '
        'mco_cdc_liberar_pedidos_MR
        '
        Me.mco_cdc_liberar_pedidos_MR.Index = 8
        Me.mco_cdc_liberar_pedidos_MR.Text = "Liberar Pedidos Mayoristas"
        '
        'mco_back_order
        '
        Me.mco_back_order.Index = 9
        Me.mco_back_order.Text = "Back Order"
        '
        'mco_liberar_ppto_producto
        '
        Me.mco_liberar_ppto_producto.Index = 10
        Me.mco_liberar_ppto_producto.Text = "Liberar Presupuesto Producto"
        '
        'mco_cdc_reportes_mayoristas
        '
        Me.mco_cdc_reportes_mayoristas.Index = 11
        Me.mco_cdc_reportes_mayoristas.Text = "Reportes Mr"
        '
        'mco_cdc_mensajeria
        '
        Me.mco_cdc_mensajeria.Index = 12
        Me.mco_cdc_mensajeria.Text = "Mensajeria Mr"
        '
        'mco_cdc_productos_mr
        '
        Me.mco_cdc_productos_mr.Index = 13
        Me.mco_cdc_productos_mr.Text = "Productos Mr"
        '
        'mco_diu_reportes
        '
        Me.mco_diu_reportes.Index = 14
        Me.mco_diu_reportes.Text = "Reportes Diuiva"
        '
        'mco_vin_reportes
        '
        Me.mco_vin_reportes.Index = 15
        Me.mco_vin_reportes.Text = "Reportes Vinoteca"
        '
        'mco_enviar_picking
        '
        Me.mco_enviar_picking.Index = 16
        Me.mco_enviar_picking.Text = "Enviar Picking"
        '
        'mco_admon_consignaciones
        '
        Me.mco_admon_consignaciones.Index = 17
        Me.mco_admon_consignaciones.Text = "Administracion Consignaciones"
        '
        'menuSubirPptoComercial
        '
        Me.menuSubirPptoComercial.Index = 18
        Me.menuSubirPptoComercial.Text = "Subir Presupuesto Comercial"
        '
        'mco_presupuestoGeneral
        '
        Me.mco_presupuestoGeneral.Index = 19
        Me.mco_presupuestoGeneral.Text = "Presupuesto General"
        '
        'mco_mob_asignacion_rutas
        '
        Me.mco_mob_asignacion_rutas.Index = 20
        Me.mco_mob_asignacion_rutas.Text = "Asignacion de Rutas"
        '
        'mco_ReportesCorporativos
        '
        Me.mco_ReportesCorporativos.Index = 21
        Me.mco_ReportesCorporativos.Text = "Reportes Corporativos"
        '
        'mco_OdCPedido
        '
        Me.mco_OdCPedido.Index = 22
        Me.mco_OdCPedido.Text = "Orden de Compra-Pedido"
        '
        'mco_MaxMinimosVinoteca
        '
        Me.mco_MaxMinimosVinoteca.Index = 23
        Me.mco_MaxMinimosVinoteca.Text = "Mantenimiento Maximos y Minimos"
        '
        'mco_PedidoVinoteca
        '
        Me.mco_PedidoVinoteca.Index = 24
        Me.mco_PedidoVinoteca.Text = "Realizar Pedido"
        '
        'mcoEdifact
        '
        Me.mcoEdifact.Index = 25
        Me.mcoEdifact.Text = "Ordenes de Compra EdiFact"
        '
        'mco_devoluciones
        '
        Me.mco_devoluciones.Index = 26
        Me.mco_devoluciones.Text = "Devoluciones"
        '
        'mcoFacturacionCosto
        '
        Me.mcoFacturacionCosto.Index = 27
        Me.mcoFacturacionCosto.Text = "Solicitud de Facturacion al Costo"
        '
        'mco_div_pedido
        '
        Me.mco_div_pedido.Index = 28
        Me.mco_div_pedido.Text = "Pedido SV"
        '
        'mco_pedidos_telemarketing
        '
        Me.mco_pedidos_telemarketing.Index = 29
        Me.mco_pedidos_telemarketing.Text = "Pedidos Telemarketing"
        '
        'mco_ws_productos
        '
        Me.mco_ws_productos.Index = 30
        Me.mco_ws_productos.Text = "WS Productos"
        '
        'mco_ws_clientes
        '
        Me.mco_ws_clientes.Index = 31
        Me.mco_ws_clientes.Text = "WS Clientes"
        '
        'mco_ws_envios
        '
        Me.mco_ws_envios.Index = 32
        Me.mco_ws_envios.Text = "WS Envios"
        '
        'mco_trancking_factura
        '
        Me.mco_trancking_factura.Index = 33
        Me.mco_trancking_factura.Text = "Tracking por Factura"
        '
        'mco_actualizacion_sku
        '
        Me.mco_actualizacion_sku.Index = 34
        Me.mco_actualizacion_sku.Text = "mantenimiento sku"
        '
        'mco_reproceso_isf
        '
        Me.mco_reproceso_isf.Index = 35
        Me.mco_reproceso_isf.Text = "Reproceso Edifact"
        '
        'mco_ws_entregas
        '
        Me.mco_ws_entregas.Index = 36
        Me.mco_ws_entregas.Text = "WS Control Entregas"
        '
        'mco_div_reportes
        '
        Me.mco_div_reportes.Index = 37
        Me.mco_div_reportes.Text = "Reportes Divinos"
        '
        'mco_edi_inner_pack
        '
        Me.mco_edi_inner_pack.Index = 38
        Me.mco_edi_inner_pack.Text = "Inner Pack"
        '
        'mco_clientesContado
        '
        Me.mco_clientesContado.Index = 39
        Me.mco_clientesContado.Text = "Clientes de Contado"
        '
        'mcoRetailLink
        '
        Me.mcoRetailLink.Index = 40
        Me.mcoRetailLink.Text = "Informacion Retail Link"
        '
        'mco_actualizacion_productos
        '
        Me.mco_actualizacion_productos.Index = 41
        Me.mco_actualizacion_productos.Text = "Actualizacion de Productos"
        '
        'mco_mercaderistas
        '
        Me.mco_mercaderistas.Index = 42
        Me.mco_mercaderistas.Text = "Informacion Mercaderistas"
        '
        'mco_edi_validacion_oc_wm
        '
        Me.mco_edi_validacion_oc_wm.Index = 43
        Me.mco_edi_validacion_oc_wm.Text = "Validacion OC Walmart"
        '
        'mco_MonitorMaquila
        '
        Me.mco_MonitorMaquila.Index = 44
        Me.mco_MonitorMaquila.Text = "Monitor Maquila"
        '
        'mco_devolucionesInterempresas
        '
        Me.mco_devolucionesInterempresas.Index = 45
        Me.mco_devolucionesInterempresas.Text = "Devoluciones InterEmpresas"
        '
        'mco_edi_carga_informacion_bi
        '
        Me.mco_edi_carga_informacion_bi.Index = 46
        Me.mco_edi_carga_informacion_bi.Text = "bi_cargaInformacion"
        '
        'mco_presupuesto_marca_ayp
        '
        Me.mco_presupuesto_marca_ayp.Index = 47
        Me.mco_presupuesto_marca_ayp.Text = "Presupuesto Marca"
        '
        'mco_PedidoVinoteca_Bodegas
        '
        Me.mco_PedidoVinoteca_Bodegas.Index = 48
        Me.mco_PedidoVinoteca_Bodegas.Text = "Pedido Automatico Otras Bodegas"
        '
        'mco_claim
        '
        Me.mco_claim.Index = 49
        Me.mco_claim.Text = "claim"
        '
        'mco_vin_sincronizar_memos
        '
        Me.mco_vin_sincronizar_memos.Index = 50
        Me.mco_vin_sincronizar_memos.Text = "Sincronizar Memos Promocionales"
        '
        'mco_vin_sincronizar_productos
        '
        Me.mco_vin_sincronizar_productos.Index = 51
        Me.mco_vin_sincronizar_productos.Text = "Sincronizar Productos"
        '
        'mco_pedidos_unisuper
        '
        Me.mco_pedidos_unisuper.Index = 52
        Me.mco_pedidos_unisuper.Text = "Pedidos Unisuper"
        '
        'mco_reimpresion_fel
        '
        Me.mco_reimpresion_fel.Index = 53
        Me.mco_reimpresion_fel.Text = "Reimpresion FEL"
        '
        'mco_vinoteca_liberar_salidas
        '
        Me.mco_vinoteca_liberar_salidas.Index = 54
        Me.mco_vinoteca_liberar_salidas.Text = "VINOTECA liberar Traslados"
        '
        'mco_vinoteca_entradaxtraslados
        '
        Me.mco_vinoteca_entradaxtraslados.Index = 55
        Me.mco_vinoteca_entradaxtraslados.Text = "VINOTECA entradas x traslados"
        '
        'mco_recepcion_mercaderia_vinoteca
        '
        Me.mco_recepcion_mercaderia_vinoteca.Index = 56
        Me.mco_recepcion_mercaderia_vinoteca.Text = "VINOTECA recepcion mercaderia"
        '
        'mco_administracion_escasez
        '
        Me.mco_administracion_escasez.Index = 57
        Me.mco_administracion_escasez.Text = "Administracion de Escasez"
        '
        'mco_actualizacion_sku_unisuper
        '
        Me.mco_actualizacion_sku_unisuper.Index = 58
        Me.mco_actualizacion_sku_unisuper.Text = "Mantenimiento SKU Unisuper"
        '
        'mco_vin_solicitud_traslados
        '
        Me.mco_vin_solicitud_traslados.Index = 59
        Me.mco_vin_solicitud_traslados.Text = "VINOTECA Solicitud Traslados"
        '
        'm_rh
        '
        Me.m_rh.Index = 2
        Me.m_rh.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mrh_pq, Me.mrh_sq, Me.mrh_ge, Me.mrh_ll, Me.mrh_cancela_prestamo, Me.MenuItem1, Me.mrh_actualizacion_prestamos_fecha, Me.mrh_ControlAccesos, Me.mrh_evaluacion, Me.mrh_suspensiones, Me.mrh_traslado_empleados, Me.mrh_candidatos, Me.mrh_garita, Me.mrh_bono14})
        Me.m_rh.Text = "RH"
        '
        'mrh_pq
        '
        Me.mrh_pq.Index = 0
        Me.mrh_pq.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mrh_pq_reportes})
        Me.mrh_pq.Text = "Primera Quincena"
        '
        'mrh_pq_reportes
        '
        Me.mrh_pq_reportes.Index = 0
        Me.mrh_pq_reportes.Text = "Reportes"
        '
        'mrh_sq
        '
        Me.mrh_sq.Index = 1
        Me.mrh_sq.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mrh_sq_reportes})
        Me.mrh_sq.Text = "Segunda Quincena"
        '
        'mrh_sq_reportes
        '
        Me.mrh_sq_reportes.Index = 0
        Me.mrh_sq_reportes.Text = "Reportes"
        '
        'mrh_ge
        '
        Me.mrh_ge.Index = 2
        Me.mrh_ge.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mrh_ge_reportes})
        Me.mrh_ge.Text = "Generales"
        '
        'mrh_ge_reportes
        '
        Me.mrh_ge_reportes.Index = 0
        Me.mrh_ge_reportes.Text = "Reportes"
        '
        'mrh_ll
        '
        Me.mrh_ll.Index = 3
        Me.mrh_ll.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mrh_ll_reportes})
        Me.mrh_ll.Text = "Libros Legales"
        '
        'mrh_ll_reportes
        '
        Me.mrh_ll_reportes.Index = 0
        Me.mrh_ll_reportes.Text = "Reportes"
        '
        'mrh_cancela_prestamo
        '
        Me.mrh_cancela_prestamo.Index = 4
        Me.mrh_cancela_prestamo.Text = "Cancelaciñn de Prñstamos"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 5
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mrh_solicitud_vacaciones})
        Me.MenuItem1.Text = "&Vacaciones"
        '
        'mrh_solicitud_vacaciones
        '
        Me.mrh_solicitud_vacaciones.Index = 0
        Me.mrh_solicitud_vacaciones.Text = "&Solicitud de Vacaciones"
        '
        'mrh_actualizacion_prestamos_fecha
        '
        Me.mrh_actualizacion_prestamos_fecha.Index = 6
        Me.mrh_actualizacion_prestamos_fecha.Text = "Actualizacion Prestamos"
        '
        'mrh_ControlAccesos
        '
        Me.mrh_ControlAccesos.Index = 7
        Me.mrh_ControlAccesos.Text = "Control de Accesos"
        '
        'mrh_evaluacion
        '
        Me.mrh_evaluacion.Index = 8
        Me.mrh_evaluacion.Text = "Evaluacion"
        '
        'mrh_suspensiones
        '
        Me.mrh_suspensiones.Index = 9
        Me.mrh_suspensiones.Text = "Control de Suspensiones"
        '
        'mrh_traslado_empleados
        '
        Me.mrh_traslado_empleados.Index = 10
        Me.mrh_traslado_empleados.Text = "Traslado de Empleados"
        '
        'mrh_candidatos
        '
        Me.mrh_candidatos.Index = 11
        Me.mrh_candidatos.Text = "Candidatos"
        '
        'mrh_garita
        '
        Me.mrh_garita.Index = 12
        Me.mrh_garita.Text = "Garitas"
        '
        'mrh_bono14
        '
        Me.mrh_bono14.Index = 13
        Me.mrh_bono14.Text = "Carga Bono 14"
        '
        'm_finanzas
        '
        Me.m_finanzas.Index = 3
        Me.m_finanzas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mfi_SacarFacturas, Me.mfi_consignaciones, Me.mfi_fc_reportes, Me.mfi_cr_reportes, Me.mfi_co_reportes, Me.mfi_cr_pedidos_pendientes, Me.MenuItem11, Me.mfi_liberar_facturas, Me.mfi_if_reportes, Me.mfi_inicializar_periodo, Me.mfi_fc_pedidos_facturar, Me.mfi_cr_recepcion_Control_transporte, Me.mfi_cr_snc_clientes, Me.mfi_enviar_factura, Me.mfi_ejecuta_sp, Me.mfi_sincronizacion_informacion, Me.mfiinventariosFisicos, Me.mfiListaCosto, Me.mfiCambiarDai, Me.mfi_generarLotes, Me.mfi_co_cface, Me.mfi_fc_FACE, Me.mfi_cancelacion_Compromisos, Me.mfi_cr_recibos_canal_moderno, Me.mfi_cr_envio_documentos_canal_moderno, Me.mfi_cr_recepcion_devoluciones, Me.mfiOperacionRecibos, Me.mfi_costo_ingresoCD, Me.mfi_fac_direccionar_impresoras, Me.mfi_caja_chica, Me.mfi_fac_compras_interempresas, Me.mfi_co_item_producto, Me.mfi_co_conciliacionBancaria, Me.mfi_con_productos_contables, Me.mfi_con_analisis_facturas, Me.mfi_cre_analisis_facturas, Me.mfi_con_tracking_pagos, Me.mfi_fc_traslado_facturas, Me.mfi_caja_chica_multiple, Me.mfi_cre_consolidacion_consignaciones, Me.mfi_cre_procesos_fel, Me.mfi_fc_fel_telemarketing, Me.mfi_cre_pagos_exterior, Me.mfi_co_carga_combustible, Me.mfi_co_liquidacion_caja_chica_teams, Me.mfi_cre_liquidacion_transportes_caja, Me.mfi_cre_monitor_impresiones, Me.mfi_con_anulacionFEL, Me.mfi_con_tracking_caja_chica, Me.mfi_fac_monitor_impresiones_recolecta})
        Me.m_finanzas.Text = "Finanzas"
        '
        'mfi_SacarFacturas
        '
        Me.mfi_SacarFacturas.Index = 0
        Me.mfi_SacarFacturas.Text = "&Sacar Facturas de Guias"
        '
        'mfi_consignaciones
        '
        Me.mfi_consignaciones.Index = 1
        Me.mfi_consignaciones.Text = "Liberar Consignaciones"
        '
        'mfi_fc_reportes
        '
        Me.mfi_fc_reportes.Index = 2
        Me.mfi_fc_reportes.Text = "Reportes"
        '
        'mfi_cr_reportes
        '
        Me.mfi_cr_reportes.Index = 3
        Me.mfi_cr_reportes.Text = "reportes Creditos"
        '
        'mfi_co_reportes
        '
        Me.mfi_co_reportes.Index = 4
        Me.mfi_co_reportes.Text = "reportes_contabilidad"
        '
        'mfi_cr_pedidos_pendientes
        '
        Me.mfi_cr_pedidos_pendientes.Index = 5
        Me.mfi_cr_pedidos_pendientes.Text = "pedidos_pendientes"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 6
        Me.MenuItem11.Text = ""
        '
        'mfi_liberar_facturas
        '
        Me.mfi_liberar_facturas.Index = 7
        Me.mfi_liberar_facturas.Text = "Liberar Facturas"
        '
        'mfi_if_reportes
        '
        Me.mfi_if_reportes.Index = 8
        Me.mfi_if_reportes.Text = "Reportes"
        '
        'mfi_inicializar_periodo
        '
        Me.mfi_inicializar_periodo.Index = 9
        Me.mfi_inicializar_periodo.Text = "Inicializacion periodo"
        '
        'mfi_fc_pedidos_facturar
        '
        Me.mfi_fc_pedidos_facturar.Index = 10
        Me.mfi_fc_pedidos_facturar.Text = "Pedidos Facturar"
        '
        'mfi_cr_recepcion_Control_transporte
        '
        Me.mfi_cr_recepcion_Control_transporte.Index = 11
        Me.mfi_cr_recepcion_Control_transporte.Text = "Recepcion Control De Transporte"
        '
        'mfi_cr_snc_clientes
        '
        Me.mfi_cr_snc_clientes.Index = 12
        Me.mfi_cr_snc_clientes.Text = "Sincronizacion Creditos"
        '
        'mfi_enviar_factura
        '
        Me.mfi_enviar_factura.Index = 13
        Me.mfi_enviar_factura.Text = "Enviar Factura"
        '
        'mfi_ejecuta_sp
        '
        Me.mfi_ejecuta_sp.Index = 14
        Me.mfi_ejecuta_sp.Text = "Procedimientos Almacenados"
        '
        'mfi_sincronizacion_informacion
        '
        Me.mfi_sincronizacion_informacion.Index = 15
        Me.mfi_sincronizacion_informacion.Text = "Sincronizacion de Informacion"
        '
        'mfiinventariosFisicos
        '
        Me.mfiinventariosFisicos.Index = 16
        Me.mfiinventariosFisicos.Text = "Inventarios Fisicos"
        '
        'mfiListaCosto
        '
        Me.mfiListaCosto.Index = 17
        Me.mfiListaCosto.Text = "Subir Lista Costo"
        '
        'mfiCambiarDai
        '
        Me.mfiCambiarDai.Index = 18
        Me.mfiCambiarDai.Text = "Cambiar Dai"
        '
        'mfi_generarLotes
        '
        Me.mfi_generarLotes.Index = 19
        Me.mfi_generarLotes.Text = "Lotes de Pago"
        '
        'mfi_co_cface
        '
        Me.mfi_co_cface.Index = 20
        Me.mfi_co_cface.Text = "Factura Electronica"
        '
        'mfi_fc_FACE
        '
        Me.mfi_fc_FACE.Index = 21
        Me.mfi_fc_FACE.Text = "Factura Electronica Pura"
        '
        'mfi_cancelacion_Compromisos
        '
        Me.mfi_cancelacion_Compromisos.Index = 22
        Me.mfi_cancelacion_Compromisos.Text = "Cancelacion de Compromisos"
        '
        'mfi_cr_recibos_canal_moderno
        '
        Me.mfi_cr_recibos_canal_moderno.Index = 23
        Me.mfi_cr_recibos_canal_moderno.Text = "Operacion Recibos Canal Moderno"
        '
        'mfi_cr_envio_documentos_canal_moderno
        '
        Me.mfi_cr_envio_documentos_canal_moderno.Index = 24
        Me.mfi_cr_envio_documentos_canal_moderno.Text = "Envio Documentos Canal Moderno"
        '
        'mfi_cr_recepcion_devoluciones
        '
        Me.mfi_cr_recepcion_devoluciones.Index = 25
        Me.mfi_cr_recepcion_devoluciones.Text = "Recepcion de Devoluciones"
        '
        'mfiOperacionRecibos
        '
        Me.mfiOperacionRecibos.Index = 26
        Me.mfiOperacionRecibos.Text = "Operacion de Recibos"
        '
        'mfi_costo_ingresoCD
        '
        Me.mfi_costo_ingresoCD.Index = 27
        Me.mfi_costo_ingresoCD.Text = "Costo Ingreso CD"
        '
        'mfi_fac_direccionar_impresoras
        '
        Me.mfi_fac_direccionar_impresoras.Index = 28
        Me.mfi_fac_direccionar_impresoras.Text = "Direccionamiento Impresoras"
        '
        'mfi_caja_chica
        '
        Me.mfi_caja_chica.Index = 29
        Me.mfi_caja_chica.Text = "Ingreso de Caja Chica"
        '
        'mfi_fac_compras_interempresas
        '
        Me.mfi_fac_compras_interempresas.Index = 30
        Me.mfi_fac_compras_interempresas.Text = "Compras Interempresas"
        '
        'mfi_co_item_producto
        '
        Me.mfi_co_item_producto.Index = 31
        Me.mfi_co_item_producto.Text = "Item-Producto"
        '
        'mfi_co_conciliacionBancaria
        '
        Me.mfi_co_conciliacionBancaria.Index = 32
        Me.mfi_co_conciliacionBancaria.Text = "Conciliacion Bancaria"
        '
        'mfi_con_productos_contables
        '
        Me.mfi_con_productos_contables.Index = 33
        Me.mfi_con_productos_contables.Text = "Productos Contables"
        '
        'mfi_con_analisis_facturas
        '
        Me.mfi_con_analisis_facturas.Index = 34
        Me.mfi_con_analisis_facturas.Text = "Analisis Documentos"
        '
        'mfi_cre_analisis_facturas
        '
        Me.mfi_cre_analisis_facturas.Index = 35
        Me.mfi_cre_analisis_facturas.Text = "Cruce de Codigos"
        '
        'mfi_con_tracking_pagos
        '
        Me.mfi_con_tracking_pagos.Index = 36
        Me.mfi_con_tracking_pagos.Text = "Tracking Pagos Electronicos"
        '
        'mfi_fc_traslado_facturas
        '
        Me.mfi_fc_traslado_facturas.Index = 37
        Me.mfi_fc_traslado_facturas.Text = "Traslado Facturas"
        '
        'mfi_caja_chica_multiple
        '
        Me.mfi_caja_chica_multiple.Index = 38
        Me.mfi_caja_chica_multiple.Text = "Ingreso de Caja Chica Multiple"
        '
        'mfi_cre_consolidacion_consignaciones
        '
        Me.mfi_cre_consolidacion_consignaciones.Index = 39
        Me.mfi_cre_consolidacion_consignaciones.Text = "Consolidacion Consignaciones"
        '
        'mfi_cre_procesos_fel
        '
        Me.mfi_cre_procesos_fel.Index = 40
        Me.mfi_cre_procesos_fel.Text = "Procesos FEL Creditos"
        '
        'mfi_fc_fel_telemarketing
        '
        Me.mfi_fc_fel_telemarketing.Index = 41
        Me.mfi_fc_fel_telemarketing.Text = "FEL Telemarketing"
        '
        'mfi_cre_pagos_exterior
        '
        Me.mfi_cre_pagos_exterior.Index = 42
        Me.mfi_cre_pagos_exterior.Text = "Pagos Exterior Tesoreria"
        '
        'mfi_co_carga_combustible
        '
        Me.mfi_co_carga_combustible.Index = 43
        Me.mfi_co_carga_combustible.Text = "Carga de Combustible"
        '
        'mfi_co_liquidacion_caja_chica_teams
        '
        Me.mfi_co_liquidacion_caja_chica_teams.Index = 44
        Me.mfi_co_liquidacion_caja_chica_teams.Text = "Liquidacion Caja Chica"
        '
        'mfi_cre_liquidacion_transportes_caja
        '
        Me.mfi_cre_liquidacion_transportes_caja.Index = 45
        Me.mfi_cre_liquidacion_transportes_caja.Text = "Liquidacion Transportes Caja"
        '
        'mfi_cre_monitor_impresiones
        '
        Me.mfi_cre_monitor_impresiones.Index = 46
        Me.mfi_cre_monitor_impresiones.Text = "Monitor de Impresiones - cedis"
        '
        'mfi_con_anulacionFEL
        '
        Me.mfi_con_anulacionFEL.Index = 47
        Me.mfi_con_anulacionFEL.Text = "Anulacion FEL"
        '
        'mfi_con_tracking_caja_chica
        '
        Me.mfi_con_tracking_caja_chica.Index = 48
        Me.mfi_con_tracking_caja_chica.Text = "Tracking Caja Chica"
        '
        'mfi_fac_monitor_impresiones_recolecta
        '
        Me.mfi_fac_monitor_impresiones_recolecta.Index = 49
        Me.mfi_fac_monitor_impresiones_recolecta.Text = "Monitor de Impresiones Recolecta"
        '
        'm_ti
        '
        Me.m_ti.Index = 4
        Me.m_ti.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mti_isf, Me.mti_usuario, Me.mti_diseñador, Me.mti_reportes, Me.mti_conversiones, Me.mti_insumos, Me.mti_plasma, Me.mti_jsa, Me.mti_control_fallas, Me.mti_scn_precios_ofertas, Me.mti_scn_productos, Me.mti_activos, Me.mti_eface, Me.mti_actualizacion_producto, Me.mti_insumos_movimientos, Me.mti_cuentasContableProductos, Me.mti_movimientos_activos, Me.mti_Incidencias, Me.mti_dts, Me.mnuAnuladorInFile})
        Me.m_ti.Text = "IT"
        '
        'mti_isf
        '
        Me.mti_isf.Index = 0
        Me.mti_isf.Text = "ISF"
        '
        'mti_usuario
        '
        Me.mti_usuario.Index = 1
        Me.mti_usuario.Text = "Usuarios"
        '
        'mti_diseñador
        '
        Me.mti_diseñador.Index = 2
        Me.mti_diseñador.Text = "Diseñadore de Reportes"
        '
        'mti_reportes
        '
        Me.mti_reportes.Index = 3
        Me.mti_reportes.Text = "reportes"
        '
        'mti_conversiones
        '
        Me.mti_conversiones.Index = 4
        Me.mti_conversiones.Text = "Parametros Sistema"
        '
        'mti_insumos
        '
        Me.mti_insumos.Index = 5
        Me.mti_insumos.Text = "Insumos"
        '
        'mti_plasma
        '
        Me.mti_plasma.Index = 6
        Me.mti_plasma.Text = "Actualizacion Plasma"
        '
        'mti_jsa
        '
        Me.mti_jsa.Index = 7
        Me.mti_jsa.Text = "jsa"
        '
        'mti_control_fallas
        '
        Me.mti_control_fallas.Index = 8
        Me.mti_control_fallas.Text = "Control de Fallas"
        '
        'mti_scn_precios_ofertas
        '
        Me.mti_scn_precios_ofertas.Index = 9
        Me.mti_scn_precios_ofertas.Text = "Sincronizacion"
        '
        'mti_scn_productos
        '
        Me.mti_scn_productos.Index = 10
        Me.mti_scn_productos.Text = "Sincronizacion Productos"
        '
        'mti_activos
        '
        Me.mti_activos.Index = 11
        Me.mti_activos.Text = "Activos"
        '
        'mti_eface
        '
        Me.mti_eface.Index = 12
        Me.mti_eface.Text = "Eface"
        '
        'mti_actualizacion_producto
        '
        Me.mti_actualizacion_producto.Index = 13
        Me.mti_actualizacion_producto.Text = "Actualiza Producto"
        '
        'mti_insumos_movimientos
        '
        Me.mti_insumos_movimientos.Index = 14
        Me.mti_insumos_movimientos.Text = "Insumos Movimientos"
        '
        'mti_cuentasContableProductos
        '
        Me.mti_cuentasContableProductos.Index = 15
        Me.mti_cuentasContableProductos.Text = "Cuentas Contables Productos"
        '
        'mti_movimientos_activos
        '
        Me.mti_movimientos_activos.Index = 16
        Me.mti_movimientos_activos.Text = "Movimientos Activos"
        '
        'mti_Incidencias
        '
        Me.mti_Incidencias.Index = 17
        Me.mti_Incidencias.Text = "Incidencias"
        '
        'mti_dts
        '
        Me.mti_dts.Index = 18
        Me.mti_dts.Text = "DTS"
        '
        'mnuAnuladorInFile
        '
        Me.mnuAnuladorInFile.Index = 19
        Me.mnuAnuladorInFile.Text = "Anulador de facturas InFile"
        '
        'm_logistica
        '
        Me.m_logistica.Index = 5
        Me.m_logistica.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mlo_reportes, Me.mlo_reportes_picking, Me.mlo_finalizacion_picking, Me.mlo_impresion_picking_manual, Me.mlo_control_transporte, Me.mlo_asociar_es_inventario, Me.mlo_scn_Movimientos_Inventario, Me.mlo_maq_monitor, Me.mlo_pedidos_posfechados, Me.mlo_liquidacionGastos, Me.mlo_controlRegistrosSanitarios, Me.mlo_salidasEnPedidos, Me.mlo_etiq_materiales, Me.mlo_etiq_OProduccion, Me.mlo_etiq_ProcesoProduccion, Me.mlo_inventarios_ciclicos, Me.mlo_liquidacionPiloto, Me.mlo_ImpresionOrdenesEDI, Me.mlo_cambioHorario, Me.mlo_ReporteHorario, Me.mlo_devolucionesrechazos, Me.mlo_ComprasInterEmpresas, Me.mlo_series, Me.mlo_planificacion_rutas, Me.mlo_asignacion_picking, Me.mlo_parametrizacion_picking, Me.mlo_chequeo, Me.mlo_facturacionANIXTER, Me.mlo_productosANIXTER, Me.mlo_tra_liberar_facturas, Me.mlo_actualizacion_productos, Me.mlo_tr_generarInformacion, Me.mlo_actualizacion_pedidowalmart, Me.mlo_tra_notasdevolucion, Me.mlo_ingresos_cd, Me.mlo_tr_cumplimiento_diario_rentado, Me.mlo_reasignacionPicking, Me.mlo_agregar_reenvios, Me.mlo_tr_cumplimiento_entregas, Me.mlo_tr_editar_marcajes, Me.mlo_picking_3pl, Me.mlo_informe_recepcion_3pl, Me.mlo_procesar_pedidos_3pl, Me.mlo_montor_impresiones_AG, Me.mlo_transporte_tmk, Me.mlo_picking_tmk, Me.mlo_recepcionFacturas, Me.mlo_tr_recolecciones})
        Me.m_logistica.Text = "Logistica"
        '
        'mlo_reportes
        '
        Me.mlo_reportes.Index = 0
        Me.mlo_reportes.Text = "reportes"
        '
        'mlo_reportes_picking
        '
        Me.mlo_reportes_picking.Index = 1
        Me.mlo_reportes_picking.Text = "reportes picking"
        '
        'mlo_finalizacion_picking
        '
        Me.mlo_finalizacion_picking.Index = 2
        Me.mlo_finalizacion_picking.Text = "Finalizacion Picking"
        '
        'mlo_impresion_picking_manual
        '
        Me.mlo_impresion_picking_manual.Index = 3
        Me.mlo_impresion_picking_manual.Text = "Impresion Picking Manual"
        '
        'mlo_control_transporte
        '
        Me.mlo_control_transporte.Index = 4
        Me.mlo_control_transporte.Text = "Control Transporte"
        '
        'mlo_asociar_es_inventario
        '
        Me.mlo_asociar_es_inventario.Index = 5
        Me.mlo_asociar_es_inventario.Text = "Asociar Entradas/Salidas "
        '
        'mlo_scn_Movimientos_Inventario
        '
        Me.mlo_scn_Movimientos_Inventario.Index = 6
        Me.mlo_scn_Movimientos_Inventario.Text = "Envio de Documentos a Tiendas"
        '
        'mlo_maq_monitor
        '
        Me.mlo_maq_monitor.Index = 7
        Me.mlo_maq_monitor.Text = "Monitor de Maquila"
        '
        'mlo_pedidos_posfechados
        '
        Me.mlo_pedidos_posfechados.Index = 8
        Me.mlo_pedidos_posfechados.Text = "Facturas Posfechadas"
        '
        'mlo_liquidacionGastos
        '
        Me.mlo_liquidacionGastos.Index = 9
        Me.mlo_liquidacionGastos.Text = "Liquidacion de Gastos"
        '
        'mlo_controlRegistrosSanitarios
        '
        Me.mlo_controlRegistrosSanitarios.Index = 10
        Me.mlo_controlRegistrosSanitarios.Text = "Control de Registros Sanitarios"
        '
        'mlo_salidasEnPedidos
        '
        Me.mlo_salidasEnPedidos.Index = 11
        Me.mlo_salidasEnPedidos.Text = "Convertir Salidas en Pedidos"
        '
        'mlo_etiq_materiales
        '
        Me.mlo_etiq_materiales.Index = 12
        Me.mlo_etiq_materiales.Text = "etiquetado Materiales"
        '
        'mlo_etiq_OProduccion
        '
        Me.mlo_etiq_OProduccion.Index = 13
        Me.mlo_etiq_OProduccion.Text = "etiquetado  Orden Produccion"
        '
        'mlo_etiq_ProcesoProduccion
        '
        Me.mlo_etiq_ProcesoProduccion.Index = 14
        Me.mlo_etiq_ProcesoProduccion.Text = "etiquetado Proceso Produccion"
        '
        'mlo_inventarios_ciclicos
        '
        Me.mlo_inventarios_ciclicos.Index = 15
        Me.mlo_inventarios_ciclicos.Text = "Inventarios Ciclicos"
        '
        'mlo_liquidacionPiloto
        '
        Me.mlo_liquidacionPiloto.Index = 16
        Me.mlo_liquidacionPiloto.Text = "Liquidacion de Piloto"
        '
        'mlo_ImpresionOrdenesEDI
        '
        Me.mlo_ImpresionOrdenesEDI.Index = 17
        Me.mlo_ImpresionOrdenesEDI.Text = "Impresion de Ordenes EdiFact"
        '
        'mlo_cambioHorario
        '
        Me.mlo_cambioHorario.Index = 18
        Me.mlo_cambioHorario.Text = "Cambio de Horario"
        '
        'mlo_ReporteHorario
        '
        Me.mlo_ReporteHorario.Index = 19
        Me.mlo_ReporteHorario.Text = "Reporte de Hoario"
        '
        'mlo_devolucionesrechazos
        '
        Me.mlo_devolucionesrechazos.Index = 20
        Me.mlo_devolucionesrechazos.Text = "Tracking Devoluciones/Rechazos"
        '
        'mlo_ComprasInterEmpresas
        '
        Me.mlo_ComprasInterEmpresas.Index = 21
        Me.mlo_ComprasInterEmpresas.Text = "Compras InterEmpresas"
        '
        'mlo_series
        '
        Me.mlo_series.Index = 22
        Me.mlo_series.Text = "Control de Series/Lotes"
        '
        'mlo_planificacion_rutas
        '
        Me.mlo_planificacion_rutas.Index = 23
        Me.mlo_planificacion_rutas.Text = "Planificacion de Rutas"
        '
        'mlo_asignacion_picking
        '
        Me.mlo_asignacion_picking.Index = 24
        Me.mlo_asignacion_picking.Text = "Picking Asignado"
        '
        'mlo_parametrizacion_picking
        '
        Me.mlo_parametrizacion_picking.Index = 25
        Me.mlo_parametrizacion_picking.Text = "Parametrizacion Picking"
        '
        'mlo_chequeo
        '
        Me.mlo_chequeo.Index = 26
        Me.mlo_chequeo.Text = "Control de Chequeo"
        '
        'mlo_facturacionANIXTER
        '
        Me.mlo_facturacionANIXTER.Index = 27
        Me.mlo_facturacionANIXTER.Text = "Facturacion ANIXTER"
        '
        'mlo_productosANIXTER
        '
        Me.mlo_productosANIXTER.Index = 28
        Me.mlo_productosANIXTER.Text = "Creacion Producto ANIXTER"
        '
        'mlo_tra_liberar_facturas
        '
        Me.mlo_tra_liberar_facturas.Index = 29
        Me.mlo_tra_liberar_facturas.Text = "Liberar Facturas"
        '
        'mlo_actualizacion_productos
        '
        Me.mlo_actualizacion_productos.Index = 30
        Me.mlo_actualizacion_productos.Text = "Actualizacion Productos"
        '
        'mlo_tr_generarInformacion
        '
        Me.mlo_tr_generarInformacion.Index = 31
        Me.mlo_tr_generarInformacion.Text = "Generar Informacion Transportes"
        '
        'mlo_actualizacion_pedidowalmart
        '
        Me.mlo_actualizacion_pedidowalmart.Index = 32
        Me.mlo_actualizacion_pedidowalmart.Text = "Actualizacion PEDIDO WALMART"
        '
        'mlo_tra_notasdevolucion
        '
        Me.mlo_tra_notasdevolucion.Index = 33
        Me.mlo_tra_notasdevolucion.Text = "Incluir Notas de Devolucion"
        '
        'mlo_ingresos_cd
        '
        Me.mlo_ingresos_cd.Index = 34
        Me.mlo_ingresos_cd.Text = "Ingreso CD"
        '
        'mlo_tr_cumplimiento_diario_rentado
        '
        Me.mlo_tr_cumplimiento_diario_rentado.Index = 35
        Me.mlo_tr_cumplimiento_diario_rentado.Text = "Cumplimiento Diario Rentados"
        '
        'mlo_reasignacionPicking
        '
        Me.mlo_reasignacionPicking.Index = 36
        Me.mlo_reasignacionPicking.Text = "Reasignacion de Picking"
        '
        'mlo_agregar_reenvios
        '
        Me.mlo_agregar_reenvios.Index = 37
        Me.mlo_agregar_reenvios.Text = "Agregar Reenvios"
        '
        'mlo_tr_cumplimiento_entregas
        '
        Me.mlo_tr_cumplimiento_entregas.Index = 38
        Me.mlo_tr_cumplimiento_entregas.Text = "Cumplimiento de Entregas"
        '
        'mlo_tr_editar_marcajes
        '
        Me.mlo_tr_editar_marcajes.Index = 39
        Me.mlo_tr_editar_marcajes.Text = "Editar Marcajes"
        '
        'mlo_picking_3pl
        '
        Me.mlo_picking_3pl.Index = 40
        Me.mlo_picking_3pl.Text = "Picking 3PL"
        '
        'mlo_informe_recepcion_3pl
        '
        Me.mlo_informe_recepcion_3pl.Index = 41
        Me.mlo_informe_recepcion_3pl.Text = "Informe Recepcion 3PL"
        '
        'mlo_procesar_pedidos_3pl
        '
        Me.mlo_procesar_pedidos_3pl.Index = 42
        Me.mlo_procesar_pedidos_3pl.Text = "Procesar Pedidos 3PL"
        '
        'mlo_montor_impresiones_AG
        '
        Me.mlo_montor_impresiones_AG.Index = 43
        Me.mlo_montor_impresiones_AG.Text = "Monitor Impresiones AG"
        '
        'mlo_transporte_tmk
        '
        Me.mlo_transporte_tmk.Index = 44
        Me.mlo_transporte_tmk.Text = "Control Transporte TMK"
        '
        'mlo_picking_tmk
        '
        Me.mlo_picking_tmk.Index = 45
        Me.mlo_picking_tmk.Text = "Picking TMK"
        '
        'mlo_recepcionFacturas
        '
        Me.mlo_recepcionFacturas.Index = 46
        Me.mlo_recepcionFacturas.Text = "Recepcion Documentos"
        '
        'mlo_tr_recolecciones
        '
        Me.mlo_tr_recolecciones.Index = 47
        Me.mlo_tr_recolecciones.Text = "Recoleccion de Mercancia"
        '
        'm_presidencia
        '
        Me.m_presidencia.Index = 6
        Me.m_presidencia.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mpr_reportes, Me.mpr_London, Me.mpr_reportesCorporativos})
        Me.m_presidencia.Text = "Presidencia"
        '
        'mpr_reportes
        '
        Me.mpr_reportes.Index = 0
        Me.mpr_reportes.Text = "reportes"
        '
        'mpr_London
        '
        Me.mpr_London.Index = 1
        Me.mpr_London.Text = "&London"
        '
        'mpr_reportesCorporativos
        '
        Me.mpr_reportesCorporativos.Index = 2
        Me.mpr_reportesCorporativos.Text = "Reportes Corporativos"
        '
        'm_compras
        '
        Me.m_compras.Index = 7
        Me.m_compras.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mci_reportes, Me.mci_odc_edifact, Me.mci_reportes_adicionales, Me.mci_liberar_documentos, Me.mci_scm_mantenimiento_proveedores, Me.mci_scm_parametros, Me.mci_scm_mantenimiento_productos, Me.mci_scm_establecer_pedido, Me.mci_int_parametros, Me.mci_int_traslado, Me.mci_int_listado, Me.mci_scm_ver_pedidos, Me.adu_di, Me.MenuItem5, Me.adu_reserva, Me.adu_solicitud_reserva, Me.adu_reportes, Me.adu_dua, Me.mci_scm_establecer_coberturas, Me.mci_soc_fechas_oc, Me.mci_scm_proceso_compras, Me.mci_soc_documentacion_oc, Me.mci_tracking_orden_compra, Me.aduEnvioPDA, Me.aduRecepcionDA, Me.mci_int_reportes, Me.mci_int_productosBloqueados, Me.mci_trackingInternaciones, Me.adu_DR, Me.adu_trasladoDUA, Me.mco_solicitudRequisiciones, Me.mco_mantenedorITEM, Me.mco_mantenedorPrecios, Me.mco_EnvioOrdenesCompra, Me.mco_RecepcionOrdenesCompra, Me.mco_EnvioOrdenesCompraConta, Me.adu_InventarioFisicoDA, Me.mlo_ci_etiquetado, Me.mci_tracking_oc_tesoreria, Me.mci_soc_complemento_divinos, Me.mco_RecepcionFacturas_Requisicion, Me.mco_Envio_Facturas_Recepcion, Me.mci_soc_ocdivinos, Me.mco_requisicionesProyecto, Me.mci_actualizacion_oc})
        Me.m_compras.Text = "Compras"
        '
        'mci_reportes
        '
        Me.mci_reportes.Index = 0
        Me.mci_reportes.Text = "reportes"
        '
        'mci_odc_edifact
        '
        Me.mci_odc_edifact.Index = 1
        Me.mci_odc_edifact.Text = "compras_ean_com"
        '
        'mci_reportes_adicionales
        '
        Me.mci_reportes_adicionales.Index = 2
        Me.mci_reportes_adicionales.Text = "Reportes_Adicionales"
        '
        'mci_liberar_documentos
        '
        Me.mci_liberar_documentos.Index = 3
        Me.mci_liberar_documentos.Text = "Liberar Documentos"
        '
        'mci_scm_mantenimiento_proveedores
        '
        Me.mci_scm_mantenimiento_proveedores.Index = 4
        Me.mci_scm_mantenimiento_proveedores.Text = "Mantenimiento de Proveedores"
        '
        'mci_scm_parametros
        '
        Me.mci_scm_parametros.Index = 5
        Me.mci_scm_parametros.Text = "Parametros"
        '
        'mci_scm_mantenimiento_productos
        '
        Me.mci_scm_mantenimiento_productos.Index = 6
        Me.mci_scm_mantenimiento_productos.Text = "Mantenimiento de Productos"
        '
        'mci_scm_establecer_pedido
        '
        Me.mci_scm_establecer_pedido.Index = 7
        Me.mci_scm_establecer_pedido.Text = "Establecer Pedido"
        '
        'mci_int_parametros
        '
        Me.mci_int_parametros.Index = 8
        Me.mci_int_parametros.Text = "Parametros Internaciones"
        '
        'mci_int_traslado
        '
        Me.mci_int_traslado.Index = 9
        Me.mci_int_traslado.Text = "Establecer Traslado"
        '
        'mci_int_listado
        '
        Me.mci_int_listado.Index = 10
        Me.mci_int_listado.Text = "Listado de Internaciones"
        '
        'mci_scm_ver_pedidos
        '
        Me.mci_scm_ver_pedidos.Index = 11
        Me.mci_scm_ver_pedidos.Text = "Ver Pedidos"
        '
        'adu_di
        '
        Me.adu_di.Index = 12
        Me.adu_di.Text = "Ingreso de DI"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 13
        Me.MenuItem5.Text = "Ingreso de Retenciones"
        '
        'adu_reserva
        '
        Me.adu_reserva.Index = 14
        Me.adu_reserva.Text = "Reservas"
        '
        'adu_solicitud_reserva
        '
        Me.adu_solicitud_reserva.Index = 15
        Me.adu_solicitud_reserva.Text = "Solicitud Reserva"
        '
        'adu_reportes
        '
        Me.adu_reportes.Index = 16
        Me.adu_reportes.Text = "Reportes"
        '
        'adu_dua
        '
        Me.adu_dua.Index = 17
        Me.adu_dua.Text = "Ingreso de DUA"
        '
        'mci_scm_establecer_coberturas
        '
        Me.mci_scm_establecer_coberturas.Index = 18
        Me.mci_scm_establecer_coberturas.Text = "Revisar Coberturas"
        '
        'mci_soc_fechas_oc
        '
        Me.mci_soc_fechas_oc.Index = 19
        Me.mci_soc_fechas_oc.Text = "Fechas de OC"
        '
        'mci_scm_proceso_compras
        '
        Me.mci_scm_proceso_compras.Index = 20
        Me.mci_scm_proceso_compras.Text = "Procesos de Compras"
        '
        'mci_soc_documentacion_oc
        '
        Me.mci_soc_documentacion_oc.Index = 21
        Me.mci_soc_documentacion_oc.Text = "Control Documentacion"
        '
        'mci_tracking_orden_compra
        '
        Me.mci_tracking_orden_compra.Index = 22
        Me.mci_tracking_orden_compra.Text = "Tracking OC"
        '
        'mci_actualizacion_oc
        '
        Me.mci_actualizacion_oc.Text = "Actualizacion OC"
        '
        'aduEnvioPDA
        '
        Me.aduEnvioPDA.Index = 23
        Me.aduEnvioPDA.Text = "Envio Informacion PDA"
        '
        'aduRecepcionDA
        '
        Me.aduRecepcionDA.Index = 24
        Me.aduRecepcionDA.Text = "Obtener Informacion PDA"
        '
        'mci_int_reportes
        '
        Me.mci_int_reportes.Index = 25
        Me.mci_int_reportes.Text = "Reportes Internaciones"
        '
        'mci_int_productosBloqueados
        '
        Me.mci_int_productosBloqueados.Index = 26
        Me.mci_int_productosBloqueados.Text = "internaciones Productos Blosqueados"
        '
        'mci_trackingInternaciones
        '
        Me.mci_trackingInternaciones.Index = 27
        Me.mci_trackingInternaciones.Text = "Tracking Internaciones"
        '
        'adu_DR
        '
        Me.adu_DR.Index = 28
        Me.adu_DR.Text = "Ingreso DR"
        '
        'adu_trasladoDUA
        '
        Me.adu_trasladoDUA.Index = 29
        Me.adu_trasladoDUA.Text = "Traslado DUA HH"
        '
        'mco_solicitudRequisiciones
        '
        Me.mco_solicitudRequisiciones.Index = 30
        Me.mco_solicitudRequisiciones.Text = "Solicitud de Requisiciones"
        '
        'mco_mantenedorITEM
        '
        Me.mco_mantenedorITEM.Index = 31
        Me.mco_mantenedorITEM.Text = "Mantenedor de ITEM"
        '
        'mco_mantenedorPrecios
        '
        Me.mco_mantenedorPrecios.Index = 32
        Me.mco_mantenedorPrecios.Text = "Mantenedor de Usuarios Centro Costo"
        '
        'mco_EnvioOrdenesCompra
        '
        Me.mco_EnvioOrdenesCompra.Index = 33
        Me.mco_EnvioOrdenesCompra.Text = "Requisiciones Envio"
        '
        'mco_RecepcionOrdenesCompra
        '
        Me.mco_RecepcionOrdenesCompra.Index = 34
        Me.mco_RecepcionOrdenesCompra.Text = "Requisiciones Recepcion"
        '
        'mco_EnvioOrdenesCompraConta
        '
        Me.mco_EnvioOrdenesCompraConta.Index = 35
        Me.mco_EnvioOrdenesCompraConta.Text = "Requisicion Envio a Contabilidad"
        '
        'adu_InventarioFisicoDA
        '
        Me.adu_InventarioFisicoDA.Index = 36
        Me.adu_InventarioFisicoDA.Text = "Inventario Fisico DA"
        '
        'mlo_ci_etiquetado
        '
        Me.mlo_ci_etiquetado.Index = 37
        Me.mlo_ci_etiquetado.Text = "Internaciones Etiquetado"
        '
        'mci_tracking_oc_tesoreria
        '
        Me.mci_tracking_oc_tesoreria.Index = 38
        Me.mci_tracking_oc_tesoreria.Text = "Trackin OC Tesoreria"
        '
        'mci_soc_complemento_divinos
        '
        Me.mci_soc_complemento_divinos.Index = 39
        Me.mci_soc_complemento_divinos.Text = "Complemento Divinos"
        '
        'mco_RecepcionFacturas_Requisicion
        '
        Me.mco_RecepcionFacturas_Requisicion.Index = 40
        Me.mco_RecepcionFacturas_Requisicion.Text = "Recepcion Factura Requisiciones"
        '
        'mco_Envio_Facturas_Recepcion
        '
        Me.mco_Envio_Facturas_Recepcion.Index = 41
        Me.mco_Envio_Facturas_Recepcion.Text = "Envio Facturas Recibidas Recepcion"
        '
        'mci_soc_ocdivinos
        '
        Me.mci_soc_ocdivinos.Index = 42
        Me.mci_soc_ocdivinos.Text = "Convertir Factura-OC Divinos"
        '
        'mco_requisicionesProyecto
        '
        Me.mco_requisicionesProyecto.Index = 43
        Me.mco_requisicionesProyecto.Text = "mcoRequisiconesProyecto"
        '
        'm_telemarketing
        '
        Me.m_telemarketing.Index = 8
        Me.m_telemarketing.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.tmk_reportes})
        Me.m_telemarketing.Text = "Telemarketing"
        '
        'tmk_reportes
        '
        Me.tmk_reportes.Index = 0
        Me.tmk_reportes.Text = "Reportes"
        '
        'm_mercadeo
        '
        Me.m_mercadeo.Index = 9
        Me.m_mercadeo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mer_reportes, Me.mer_memos_promocionales, Me.mer_anular_memos_promocionales, Me.mer_mem_reportes, Me.mer_mem_revision_OC, Me.mer_mem_solicitud_productos, Me.mer_cambio_precio, Me.mer_productos_derivados, Me.mer_cargarPPTOGeneral, Me.merForecast, Me.merEvualuacionDIAGEO, Me.mer_MantenedorPrecios, Me.mer_actualizacionProductos, Me.mer_actualizacionProductosIE})
        Me.m_mercadeo.Text = "Mercadeo"
        '
        'mer_reportes
        '
        Me.mer_reportes.Index = 0
        Me.mer_reportes.Text = "Reportes"
        '
        'mer_memos_promocionales
        '
        Me.mer_memos_promocionales.Index = 1
        Me.mer_memos_promocionales.Text = "Memos Promocionales"
        '
        'mer_anular_memos_promocionales
        '
        Me.mer_anular_memos_promocionales.Index = 2
        Me.mer_anular_memos_promocionales.Text = "Anular Memos Promocionales"
        '
        'mer_mem_reportes
        '
        Me.mer_mem_reportes.Index = 3
        Me.mer_mem_reportes.Text = "Reportes Memos"
        '
        'mer_mem_revision_OC
        '
        Me.mer_mem_revision_OC.Index = 4
        Me.mer_mem_revision_OC.Text = "Revision Ordenes de Compra"
        '
        'mer_mem_solicitud_productos
        '
        Me.mer_mem_solicitud_productos.Index = 5
        Me.mer_mem_solicitud_productos.Text = "Solicitud Productos"
        '
        'mer_cambio_precio
        '
        Me.mer_cambio_precio.Index = 6
        Me.mer_cambio_precio.Text = "Cambio de Precios a Productos Compras"
        '
        'mer_productos_derivados
        '
        Me.mer_productos_derivados.Index = 7
        Me.mer_productos_derivados.Text = "Productos Derivados"
        '
        'mer_cargarPPTOGeneral
        '
        Me.mer_cargarPPTOGeneral.Index = 8
        Me.mer_cargarPPTOGeneral.Text = "Cargar Prespuesto General"
        '
        'merForecast
        '
        Me.merForecast.Index = 9
        Me.merForecast.Text = "Forecast"
        '
        'merEvualuacionDIAGEO
        '
        Me.merEvualuacionDIAGEO.Index = 10
        Me.merEvualuacionDIAGEO.Text = "Evaluacion DIAGEO"
        '
        'mer_MantenedorPrecios
        '
        Me.mer_MantenedorPrecios.Index = 11
        Me.mer_MantenedorPrecios.Text = "Cambio de Precios"
        '
        'mer_actualizacionProductos
        '
        Me.mer_actualizacionProductos.Index = 12
        Me.mer_actualizacionProductos.Text = "Actualizacion de Productos"
        '
        'mer_actualizacionProductosIE
        '
        Me.mer_actualizacionProductosIE.Index = 13
        Me.mer_actualizacionProductosIE.Text = "Actualizaciñn de Productos"
        '
        'Label1
        '
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(20, 371)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(824, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Visible = False
        '
        'pb_it
        '
        Me.pb_it.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_it.Image = CType(resources.GetObject("pb_it.Image"), System.Drawing.Image)
        Me.pb_it.Location = New System.Drawing.Point(876, 469)
        Me.pb_it.Name = "pb_it"
        Me.pb_it.Size = New System.Drawing.Size(86, 94)
        Me.pb_it.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_it.TabIndex = 2
        Me.pb_it.TabStop = False
        '
        'pb_logo
        '
        Me.pb_logo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pb_logo.Location = New System.Drawing.Point(12, 438)
        Me.pb_logo.Name = "pb_logo"
        Me.pb_logo.Size = New System.Drawing.Size(162, 117)
        Me.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_logo.TabIndex = 3
        Me.pb_logo.TabStop = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 569)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(962, 6)
        Me.StatusBar1.TabIndex = 4
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 315
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 315
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel3.Name = "StatusBarPanel3"
        Me.StatusBarPanel3.Width = 315
        '
        'btnOpcion1
        '
        Me.btnOpcion1.Location = New System.Drawing.Point(17, 28)
        Me.btnOpcion1.Name = "btnOpcion1"
        Me.btnOpcion1.Size = New System.Drawing.Size(75, 55)
        Me.btnOpcion1.TabIndex = 5
        Me.btnOpcion1.Text = "Button1"
        Me.btnOpcion1.UseVisualStyleBackColor = True
        '
        'btnOpcion2
        '
        Me.btnOpcion2.Location = New System.Drawing.Point(17, 101)
        Me.btnOpcion2.Name = "btnOpcion2"
        Me.btnOpcion2.Size = New System.Drawing.Size(75, 57)
        Me.btnOpcion2.TabIndex = 5
        Me.btnOpcion2.Text = "Button1"
        Me.btnOpcion2.UseVisualStyleBackColor = True
        '
        'gbOpcines
        '
        Me.gbOpcines.Controls.Add(Me.btnOpcion1)
        Me.gbOpcines.Controls.Add(Me.btnOpcion3)
        Me.gbOpcines.Controls.Add(Me.btnOpcion2)
        Me.gbOpcines.Location = New System.Drawing.Point(37, 85)
        Me.gbOpcines.Name = "gbOpcines"
        Me.gbOpcines.Size = New System.Drawing.Size(137, 259)
        Me.gbOpcines.TabIndex = 6
        Me.gbOpcines.TabStop = False
        Me.gbOpcines.Text = "Opciones Recurrentes"
        Me.gbOpcines.Visible = False
        '
        'btnOpcion3
        '
        Me.btnOpcion3.Location = New System.Drawing.Point(17, 180)
        Me.btnOpcion3.Name = "btnOpcion3"
        Me.btnOpcion3.Size = New System.Drawing.Size(75, 57)
        Me.btnOpcion3.TabIndex = 5
        Me.btnOpcion3.Text = "Button1"
        Me.btnOpcion3.UseVisualStyleBackColor = True
        '
        'frm_menu_principal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(962, 575)
        Me.Controls.Add(Me.gbOpcines)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.pb_logo)
        Me.Controls.Add(Me.pb_it)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.menu_principal
        Me.MinimumSize = New System.Drawing.Size(962, 600)
        Me.Name = "frm_menu_principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pb_it, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpcines.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub asignarMenus2()
        ' Utilizamos los menñs que tenemos asignados y los cambiamos por RichMenuItem
        ' Como vamos a asignar imñgenes, hay que saber que acciñn efectña cada menñ,
        ' por tanto este mñtodo no es del todo automñtico...
        ' Pero se puede preparar para que "casi" lo sea si se siguen unas normas
        ' de nomenclatura.
        Dim mMenuP() As RichMenuItem
        ReDim mMenuP(menu_principal.MenuItems.Count - 1)
        Dim menus() As RichMenuItem
        Dim n As Integer = 0

        For Each mnuP As MenuItem In Me.menu_principal.MenuItems
            ReDim menus(mnuP.MenuItems.Count - 1)
            Dim i As Integer = 0
            For Each mnu As MenuItem In mnuP.MenuItems
                Dim texto As String = mnu.Text
                ' Por defecto convertimos el menñ en RichMenuItem
                Dim rmnu As RichMenuItem = New RichMenuItem(texto)
                ' Si estñ en algunos de estos casos, se usarñ en vez del asignado antes
                If texto.IndexOf("Nuevo") > -1 Then
                    'rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), texto, AddressOf mnuFicNuevo_Click, Shortcut.CtrlS, "Salir")
                    'ElseIf texto.IndexOf("Abrir") > -1 Then
                    '    rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.eOpen), texto, AddressOf mnuFicAbrir_Click, "Abre un fichero existente")
                    'ElseIf texto.IndexOf("Guardar") > -1 Then
                    '    rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.eSave), texto, AddressOf mnuFicGuardar_Click, Shortcut.CtrlG, "Guarda el contenido del fichero")
                    'ElseIf texto.IndexOf("Acerca") > -1 Then
                    '    rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.egMsgBInfo), texto, AddressOf mnuFicAcercaDe_Click, "Muestra la informaciñn Shortcut.Del la aplicaciñn")
                    'ElseIf texto.IndexOf("Salir") > -1 Then
                    '    rmnu = New RichMenuItem(texto, AddressOf mnuFicSalir_Click, "Termina el programa")
                    'ElseIf texto.IndexOf("Cor&tar") > -1 Then
                    '    rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.eCut), texto, AddressOf mnuEdiCortar_Click, Shortcut.CtrlX, "Cortar el texto seleccionado")
                    'ElseIf texto.IndexOf("Copiar") > -1 Then
                    '    rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.eCopy), texto, AddressOf mnuEdiCopiar_Click, Shortcut.CtrlC, "Copia el texto seleccionado")
                    'ElseIf texto.IndexOf("Pegar") > -1 Then
                    '    rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.ePaste), texto, AddressOf mnuEdiPegar_Click, Shortcut.CtrlV, "Pega del portapapeles")
                    'ElseIf texto.IndexOf("Deshacer") > -1 Then
                    ''    rmnu = New RichMenuItem(mimg.Bitmaps(eImagenes.eUndo), texto, AddressOf mnuEdiDeshacer_Click, Shortcut.CtrlZ, "Deshacer la ñltima ediciñn")
                End If
                ' Para mostrar la descripciñn del menñ
                '     AddHandler rmnu.Select, AddressOf mnu_Select
                ' Asignamos el menñ
                menus(i) = rmnu
                i += 1
            Next
            ' Añadimos los submenñs al menñ
            mMenuP(n) = New RichMenuItem(mnuP.Text)
            mMenuP(n).MenuItems.AddRange(menus)
            n += 1
        Next
        ' Eliminamos los que hubiera antes
        menu_principal.MenuItems.Clear()
        ' Añadimos los nuevos menñs creados
        menu_principal.MenuItems.AddRange(mMenuP)


    End Sub

    Private Sub Revisar_Pedidos_Posfechados()
        Dim otrans As New Transaccional.Conexion("Flexline")
        Dim dt As DataTable
        Dim ls_sql As String

        Try
            otrans.open()
            ls_sql = "pa_var_um_documentos_posfechados '" & Today.ToString("dd/MM/yyyy") & "','" & Today.AddMonths(6).ToString("dd/MM/yyyy") & "'"
            dt = otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                Dim oform As New frm_pedidos_facturar
                oform.lpedidos_posfechados = True
                oform.ShowDialog()
                oform.Dispose()
                oform = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub frm_menu_principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'gs_usuario = "arivas"
        'gi_tipo_usuario = 0

        Dim lsVersionAPP As String = Application.ProductVersion

        lsVersionAPP = "8.26.1.2"


        Crear_menu()
        ' -- Header panel -------------------------------------------------------
        Dim pnlHeader As New Panel()
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 54
        pnlHeader.BackColor = Color.FromArgb(45, 50, 22)

        Dim pnlLeft As New Panel()
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Width = 500
        pnlLeft.BackColor = Color.Transparent

        Dim lblSistema As New Label()
        lblSistema.Text = "UMBRIGHT ERP"
        lblSistema.ForeColor = Color.FromArgb(196, 81, 35)
        lblSistema.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblSistema.AutoSize = True
        lblSistema.Location = New Point(14, 8)

        Dim lblEmpresaHeader As New Label()
        lblEmpresaHeader.Name = "lblEmpresaHeader"
        lblEmpresaHeader.Text = If(String.IsNullOrEmpty(mdfo_gs_empresa), gs_empresa, mdfo_gs_empresa & "  (" & gs_empresa & ")")
        lblEmpresaHeader.ForeColor = Color.White
        lblEmpresaHeader.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblEmpresaHeader.AutoSize = True
        lblEmpresaHeader.Location = New Point(14, 25)

        pnlLeft.Controls.Add(lblSistema)
        pnlLeft.Controls.Add(lblEmpresaHeader)

        Dim pnlRight As New Panel()
        pnlRight.Dock = DockStyle.Right
        pnlRight.Width = 340
        pnlRight.BackColor = Color.Transparent

        Dim lblUserTitulo As New Label()
        lblUserTitulo.Text = "USUARIO"
        lblUserTitulo.ForeColor = Color.FromArgb(106, 116, 56)
        lblUserTitulo.Font = New Font("Segoe UI", 7.0F, FontStyle.Bold)
        lblUserTitulo.AutoSize = True
        lblUserTitulo.Location = New Point(10, 8)

        Dim lblUserValor As New Label()
        lblUserValor.Text = gs_nombre_usuario & "  (" & gs_usuario & ")"
        lblUserValor.ForeColor = Color.White
        lblUserValor.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblUserValor.AutoSize = True
        lblUserValor.Location = New Point(10, 25)

        Dim lblFechaTitulo As New Label()
        lblFechaTitulo.Text = "FECHA"
        lblFechaTitulo.ForeColor = Color.FromArgb(106, 116, 56)
        lblFechaTitulo.Font = New Font("Segoe UI", 7.0F, FontStyle.Bold)
        lblFechaTitulo.AutoSize = True
        lblFechaTitulo.Location = New Point(200, 8)

        Dim lblFechaValor As New Label()
        lblFechaValor.Text = Now.ToString("dd/MMM/yyyy")
        lblFechaValor.ForeColor = Color.White
        lblFechaValor.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblFechaValor.AutoSize = True
        lblFechaValor.Location = New Point(200, 25)

        pnlRight.Controls.Add(lblUserTitulo)
        pnlRight.Controls.Add(lblUserValor)
        pnlRight.Controls.Add(lblFechaTitulo)
        pnlRight.Controls.Add(lblFechaValor)

        pnlHeader.Controls.Add(pnlLeft)
        pnlHeader.Controls.Add(pnlRight)
        Me.Controls.Add(pnlHeader)
        pnlHeader.BringToFront()
        ' -- Fin Header panel ---------------------------------------------------
        Crear_tiles()
        CargarFavoritos()
        Crear_acceso_rapido()
        Me.StatusBarPanel1.Text = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString & "  v" & lsVersionAPP & "  |  PC: " & gs_nombre_equipo
        Me.StatusBarPanel2.Text = gs_nombre_usuario & " (" & gs_usuario & ")"
        Me.StatusBarPanel3.Text = Now.ToString("dd/MMM/yyyy  HH:mm")

        'If tiene_permisos("mlo_pedidos_posfechados") _
        '    And gi_tipo_usuario <> 1 Then

        '    Revisar_Pedidos_Posfechados()

        'End If
        'LevantarAvisos()


        Try
            Activar_LogoIT()
        Catch ex As Exception

        End Try


        Try
            mostrarOpcionesRecurrentes()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mostrarOpcionesRecurrentes()

    End Sub

    Private Sub Crear_menu()
        Dim mMenuP() As RichMenuItem
        Dim ls_sqlstring As String
        Dim otabla As DataTable
        Dim otrans As New Transaccional.Conexion("flexline")

        otrans.open()


        ls_sqlstring = "pa_sel_um_sg_usuario_menu_opcion_empresa NULL,'" & gs_usuario & "',NULL,'" & gs_empresa & "'"
        otabla = otrans.Obtiene(ls_sqlstring)
        otrans.close()
        otrans = Nothing

        '' cod_tipo_usuario = 1, es administrador, puede ver todas las opciones
        Try
            cod_tipo_usuario = Int32.Parse(otabla.Rows(0).Item("tipo_usuario").ToString)
        Catch ex As Exception
        End Try

        RichMenuItem.DefaultMenuStyle = IconMenuStyle.Office2003

        ReDim mMenuP(9)
        Me.Menu.MenuItems.Clear()
        mMenuP(0) = New RichMenuItem("&Archivo")


        otabla.DefaultView.RowFilter = "cod_menu=7"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(1) = New RichMenuItem("&Presidencia")
        Else
            mMenuP(1) = New RichMenuItem("")
        End If


        otabla.DefaultView.RowFilter = "cod_menu=2"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2) = New RichMenuItem("&Comercial")
        Else
            mMenuP(2) = New RichMenuItem("")
        End If

        otabla.DefaultView.RowFilter = "cod_menu=3"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3) = New RichMenuItem("&RRHH")
        Else
            mMenuP(3) = New RichMenuItem("")
        End If

        otabla.DefaultView.RowFilter = "cod_menu=4"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(4) = New RichMenuItem("&Finanzas")
        Else
            mMenuP(4) = New RichMenuItem("")
        End If

        otabla.DefaultView.RowFilter = "cod_menu=5"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(5) = New RichMenuItem("&IT")
        Else
            mMenuP(5) = New RichMenuItem("")
        End If

        otabla.DefaultView.RowFilter = "cod_menu=6"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6) = New RichMenuItem("&Logistica")
        Else
            mMenuP(6) = New RichMenuItem("")
        End If

        otabla.DefaultView.RowFilter = "cod_menu=14"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7) = New RichMenuItem("&Compras/Import")
        Else
            mMenuP(7) = New RichMenuItem("")
        End If

        'otabla.DefaultView.RowFilter = "cod_menu=15"
        'If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(8) = New RichMenuItem("&TeleMarketing")
        'Else
        mMenuP(8) = New RichMenuItem("")
        'End If

        otabla.DefaultView.RowFilter = "cod_menu=16"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9) = New RichMenuItem("&Mercadeo")
        Else
            mMenuP(9) = New RichMenuItem("")
        End If

        ''Menu Archivo
        Menu_Archivo(mMenuP, otabla, cod_tipo_usuario)


        ''Menu Presidencia
        otabla.DefaultView.RowFilter = "opcion = 'mpr_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Reportes", AddressOf mpr_reportes_Click, Shortcut.CtrlI, "Reportes"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mpr_reportes_corporativos'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "Reportes Corporativos", AddressOf mpr_ReportesCorporativos_Click, Shortcut.CtrlShiftI, "mpr_ReportesCorporativos_Click"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mpr_London'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Proyectos", AddressOf mpr_London_Click, Shortcut.CtrlF1, "London"))
        End If

        'Menu Comercial
        Menu_Comercial(mMenuP, otabla, cod_tipo_usuario)


        ''menu RRHH
        ''sub menus

        otabla.DefaultView.RowFilter = "cod_sub_menu = 8"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem("Primera Quincena"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If
        otabla.DefaultView.RowFilter = "cod_sub_menu = 9"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem("Segunda Quincena"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If

        otabla.DefaultView.RowFilter = "cod_sub_menu = 10"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem("Generales"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If

        otabla.DefaultView.RowFilter = "cod_sub_menu = 11"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem("Libros Legales"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If

        'otabla.DefaultView.RowFilter = "opcion = 'mrh_cancela_prestamo'"

        'If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Cancelacion de Prestamos", AddressOf mrh_cancela_prestamo_Click, Shortcut.AltF8, "Cancelacion de Prestamos"))
        'Else
        '    mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        'End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_actualizacion_prestamos_fecha'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Actualizacion de Prestamos Fecha Final", AddressOf mrh_actualizacion_prestamos_fecha_Click, Shortcut.AltF8, "Cancelacion de Prestamos"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_control_accesos'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.EConsigna), "Contro&l de Accesos ", AddressOf mrh_ControlAccesos_Click, Shortcut.CtrlL, "Vacaciones"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If




        otabla.DefaultView.RowFilter = "cod_sub_menu = 27"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem("Vacaciones"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_evaluacion'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Evaluaciones", AddressOf mrh_evaluacion_Click, Shortcut.CtrlV, "Vacaciones"))
        Else
            mMenuP(3).MenuItems.Add(New RichMenuItem(""))
        End If
        ''RRHH opciones
        otabla.DefaultView.RowFilter = "opcion = 'mrh_pq_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes ", AddressOf mrh_pq_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_sq_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes ", AddressOf mrh_sq_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_ge_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes ", AddressOf mrh_ge_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_ll_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes ", AddressOf mrh_ll_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_solicitud_vacaciones'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.EConsigna), "&Vacaciones ", AddressOf mrh_solicitud_vacaciones_Click, Shortcut.CtrlR, "Vacaciones"))
        End If


        otabla.DefaultView.RowFilter = "opcion = 'mrh_suspensiones'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "&Control de Suspensiones ", AddressOf mrh_suspensiones_Click, Shortcut.CtrlS, "Vacaciones"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mrh_traslado_empleado'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eBack), "&Traslado Empleados", AddressOf mrh_traslado_empleados_Click, Shortcut.CtrlT, "Vacaciones"))
        End If


        otabla.DefaultView.RowFilter = "opcion = 'mrh_candidatos'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Candidatos", AddressOf mrh_candidatos_Click, Shortcut.CtrlShiftC, "Vacaciones"))
        End If


        otabla.DefaultView.RowFilter = "opcion = 'mrh_garitas'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "&Garitas", AddressOf mrh_garita_Click, Shortcut.CtrlShiftG, "Garitas"))
        End If


        ''Menu Finanzas
        Menu_Finanzas(mMenuP, otabla, cod_tipo_usuario)

        ''Menu IT
        Menu_IT(mMenuP, otabla, cod_tipo_usuario)

        ''****Logistica
        Menu_Logistica(mMenuP, otabla, cod_tipo_usuario)


        ''Compras e Importacions
        Menu_Compras_Importaciones(mMenuP, otabla, cod_tipo_usuario)


        ''TeleMarketing
        otabla.DefaultView.RowFilter = "opcion = 'mtk_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(8).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf tmk_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If


        ''Mercadeo


        otabla.DefaultView.RowFilter = "cod_sub_menu = 19"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem("Memos Promocionales"))
        Else
            mMenuP(9).MenuItems.Add(New RichMenuItem(""))
        End If

        otabla.DefaultView.RowFilter = "cod_menu = 17" ''Menu de Presupuestos
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem("Presupuestos"))
        Else
            mMenuP(9).MenuItems.Add(New RichMenuItem(""))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mer_memos_promocionales'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaLapiz), "Captura de &Memos Promocionales", AddressOf mer_memos_promocionales_Click, Shortcut.CtrlShiftM, "Memos Promocionales"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mer_anular_memos_autorizados'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eUndo), "An&ular Memos Promocionales Autorizados", AddressOf mer_anular_memos_promocionales_Click, Shortcut.CtrlShiftU, "Anular Memos Promocionales Autorizados"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mer_mem_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mer_mem_reportes_Click, Shortcut.CtrlShiftR, "Reportes mos Promocionales Autorizados"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mer_reportes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mer_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mer_mem_revision_OC'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Revision Ordenes de Compra", AddressOf mer_mem_revision_OC_Click, Shortcut.CtrlShiftR, "Reportes"))
        End If

        otabla.DefaultView.RowFilter = "opcion  = 'mer_sp_ingreso_solicitudes'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), "Solicitud de Productos", AddressOf mer_mem_solicitud_productos_Click, Shortcut.CtrlShiftP, "Reportes"))
        End If


        otabla.DefaultView.RowFilter = "opcion = 'mer_cambio_precio'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Cambio de Precio a Productos", AddressOf mer_cambio_precio_Click, Shortcut.CtrlShiftC, "Cambio de precio"))
        End If

        ''SCM Revision de Coberturas
        otabla.DefaultView.RowFilter = "opcion = 'mci_revision_coberturas'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRefresh), "Revision de Coberturas", AddressOf mci_scm_establecer_coberturas_Click, Shortcut.CtrlT, "Establecer Pedidos"))
        End If

        ''Productos Derivados
        otabla.DefaultView.RowFilter = "opcion = 'mer_productos_derivados'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Productos Derivados", AddressOf mer_productos_derivados_Click, Shortcut.CtrlShiftD, "Productos Derivados"))
        End If

        ''Forecast
        otabla.DefaultView.RowFilter = "opcion = 'mer_forecast'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "Forecast", AddressOf merForecast_Click, Shortcut.CtrlT, "Establecer Pedidos"))
        End If

        ''Evualuacion DIAGEO
        otabla.DefaultView.RowFilter = "opcion = 'mer_evaluaciondiageo'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egAltavoz), "Evaluacion DIAGEO", AddressOf merEvualuacionDIAGEO_Click, Shortcut.CtrlShiftD, "Establecer Pedidos"))
        End If

        ''Mantenedor de Precios
        otabla.DefaultView.RowFilter = "opcion = 'mer_mantenedorPrecios'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Solicitud de Cambios de Precios", AddressOf Me.mer_MantenedorPrecios_Click, Shortcut.CtrlShiftD, "Establecer Pedidos"))
        End If


        ''Mantenedor de Precios
        otabla.DefaultView.RowFilter = "opcion = 'mer_actualizacionProductos'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRefresh), "Actualizacion de Productos", AddressOf Me.mer_actualizacionProductos_Click, Shortcut.CtrlShiftD, "Establecer Pedidos"))
        End If

        ''Actualizaciñn de Productos (con sub-menñ de prueba visual)
        otabla.DefaultView.RowFilter = "opcion LIKE 'mer_actProd_%'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRefresh), "Actualizaciñn de Productos", AddressOf Me.mer_actualizacionProductosIE_Click, Shortcut.CtrlShiftT, "Actualizaciñn de Productos"))
            ' Sub-menu: Individual y Masiva
            Dim padre As System.Windows.Forms.MenuItem = mMenuP(9).MenuItems(mMenuP(9).MenuItems.Count - 1)
            padre.MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRefresh), "Actualizaciñn Individual", AddressOf Me.actualizacionProductos_Individual_Click, Shortcut.None, "Actualizaciñn Individual de Productos"))
            padre.MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRefresh), "Actualizaciñn Masiva", AddressOf Me.actualizacionProductos_Masiva_Click, Shortcut.None, "Actualizaciñn Masiva por Excel"))
        End If


        'Presupuestos
        otabla.DefaultView.RowFilter = "opcion = 'mpt_verpresupuestoGeneral'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egAltavoz), "Presupuesto General", AddressOf mco_presupuestoGeneral_Click, Shortcut.CtrlShiftP, "Liberar Ppto Producto"))
        End If

        otabla.DefaultView.RowFilter = "opcion = 'mpt_cargarpresupuesto'"
        If otabla.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(9).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfig1), "Subir Presupuesto General", AddressOf mer_cargarPPTOGeneral_Click, Shortcut.CtrlShiftS, "Liberar Ppto Producto"))
        End If



        Me.Menu.MenuItems.AddRange(mMenuP)

        Activar_Logo()
    End Sub

    Private Sub Menu_Archivo(ByVal mMenuP() As RichMenuItem, ByVal dt As DataTable, ByVal cod_tipo_usuario As Int32)


        dt.DefaultView.RowFilter = "cod_sub_menu = 4"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem("Cubos"))
        Else
            mMenuP(0).MenuItems.Add(New RichMenuItem(""))
        End If


        dt.DefaultView.RowFilter = "cod_sub_menu = 48"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem("Cubos Logistica"))
        Else
            mMenuP(0).MenuItems.Add(New RichMenuItem(""))
        End If



        dt.DefaultView.RowFilter = "cod_sub_menu = 50"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem("Tableau"))
        Else
            mMenuP(0).MenuItems.Add(New RichMenuItem(""))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mar_ol_inventarios'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Inventario", AddressOf mar_cub_inventario_Click)
        End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_topinv'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo TopInventario", AddressOf mar_cub_topinv_Click)
        'End If

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_inventarios_JSA'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Inventarios JSA", AddressOf mar_cub_topinv_Click)
        End If

        ''(c) Se Quitaron el 05/07/2013 por falta de uso
        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_tops'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo Tops", AddressOf mar_cub_tops_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_topventas'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Top Ventas", AddressOf mar_cub_topventas_Click)
        'End If

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cartera'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Cartera Corporativo", AddressOf mar_cub_cartera_Click)
        End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventasxperiodo'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas x Periodo", AddressOf mar_cub_ventasxperiodo_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventas_x_periodo_complemento'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas x Periodo_Complemento", AddressOf mar_cubo_ventas_por_periodo_complemento_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventasxrangofecha'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas x Rango Fecha", AddressOf mar_cub_ventasxrangofecha_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_controltransporte'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Control de Transporte", AddressOf mar_cub_controltransporte_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventas24mese'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas 24 Meses", AddressOf mar_cub_ventas24meses_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventas24meses_tiendas'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas 24 Meses Tiendas", AddressOf mar_cub_24m_tiendas_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventasVendedor_vertical'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas Vendedor Vertical", AddressOf mar_cub_Ventas_Vendedor_Vertical_Click)
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventas_x_dia'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas Por Dia", AddressOf mar_cub_ventas_x_dia_Click)
        'End If


        dt.DefaultView.RowFilter = "opcion = 'mar_ol_Presupuesto_comercial'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Presupuesto Comercial", AddressOf mar_cub_presupuesto_comercial_Click)
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lista_precios'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Listas de Precios", AddressOf mar_cub_listaPrecios_Click)
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_ventas_corporativo'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Ventas Corporativo", AddressOf mar_cub_ventasCoporativas_Click)
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_venta_perdida'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Venta Perdida", AddressOf mar_ol_venta_perdida_Click)
        End If



        dt.DefaultView.RowFilter = "opcion = 'mar_ol_devoluciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Devoluciones", AddressOf mar_ol_cuboDevoluciones_Click)


        '(c)09042015 Se quito la opcion
        ''Nivel de Servicio
        'dt.DefaultView.RowFilter = "opcion = 'mar_ol_nivelservicio'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Nivel de Servicio", AddressOf mar_ol_nivelServicio_Click)


        'Stock Diario
        dt.DefaultView.RowFilter = "opcion = 'mar_ol_stockdiario'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(0).MenuItems(0).MenuItems.Add("Cubo de Stock Diario", AddressOf mar_lo_stockDiario_Click)

        ''Cubo Generico1  para estas opciones si se necisita asignarlo a los administradores      
        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico1'"
        If dt.DefaultView.Count > 0 Then
            mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico2'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico3'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico4'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico5'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico6'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico7'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico8'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico9'"

        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico10'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico11'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico12'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico13'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico14'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico15'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)


        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico16'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico17'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico18'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico19'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico20'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico21'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico22'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico23'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico24'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico25'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)


        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico26'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)


        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico27'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico28'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico29'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico30'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico31'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico32'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico33'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico34'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico35'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico36'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico37'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico38'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico39'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_cubogenerico40'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(0).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)


        '(c) 20151223 Opciones Genericas de Cubos

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico1'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico2'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico3'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico4'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico5'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico6'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico7'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico8'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico9'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico10'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)


        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico11'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico12'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico13'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico14'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico15'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico16'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico17'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico18'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico19'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico20'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico21'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico22'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico23'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico24'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico25'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)


        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico26'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico27'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico28'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico29'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico30'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico31'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico32'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico33'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico34'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico35'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico36'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico37'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico38'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico39'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_lgs_cubogenerico40'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(1).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_cubogenrico1_Click)




        mMenuP(0).MenuItems.Add(New RichMenuItem("-"))

        dt.DefaultView.RowFilter = "opcion = 'mar_flexline'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eSearch), "&Flexline", AddressOf mar_flexline_Click, Shortcut.CtrlF, "Ejecutar Flexline"))
        End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_vnet'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "P&resupuestos\Analyzer", AddressOf mar_Vnet_Click, Shortcut.CtrlR, "Ejecutar Vinet"))
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mar_reverse'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRun), "&Modificar Precios Doctos", AddressOf mar_reverse_Click, Shortcut.CtrlR, "Ejecutar Reverse"))
        'End If

        dt.DefaultView.RowFilter = "opcion = 'mar_telecomunicaciones'"

        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "&Telecomunicaciones", AddressOf mar_telecomunicaciones_Click, Shortcut.CtrlShiftT, "Ejecutar Reverse"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_crm'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRun), "CR&M", AddressOf mar_crm_Click, Shortcut.CtrlM, "Ejecutar CRM"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_informacion_productos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eZoomOut), "&Informacion de Productos", AddressOf mar_informacion_productos_Click, Shortcut.CtrlI, "Informacion de Productos"))
        End If

        'mMenuP(0).MenuItems.Add(New RichMenuItem("-"))
        'dt.DefaultView.RowFilter = "opcion = 'mar_cambiar_empresa'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eBack), "&Cambiar Empresa", AddressOf mar_cambiar_empresa_Click, Shortcut.CtrlC, "Cambiar Empresa"))
        'End If

        dt.DefaultView.RowFilter = "opcion = 'mar_cambiarclave'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Ca&mbiar Contraseña", AddressOf mar_cambiarclave_Click, Shortcut.CtrlM, "Cambiar Contraseña"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_control_tarea'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "C&ontrol de Tareas", AddressOf mar_control_tarea_Click, Shortcut.CtrlT, "Control de Tareas"))
        End If

        dt.DefaultView.RowFilter = "cod_menu = 17" ''Menu de Presupuestos
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Cambiar Periodo", AddressOf mnu_arch_cambiar_periodo_Click, Shortcut.CtrlP, "Control de Tareas"))
        End If


        mMenuP(0).MenuItems.Add(New RichMenuItem("-"))
        mMenuP(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eStop), "&Salir", AddressOf mar_salir_Click, Shortcut.CtrlS, "Salir de Aplicacion"))



        ''Cubo Generico1  para estas opciones si se necisita asignarlo a los administradores      
        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau1'"
        If dt.DefaultView.Count > 0 Then
            mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)
        End If

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau2'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau3'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau4'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau5'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau6'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau7'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau8'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau9'"

        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)

        dt.DefaultView.RowFilter = "opcion = 'mar_ol_tableau10'"
        If dt.DefaultView.Count > 0 Then mMenuP(0).MenuItems(2).MenuItems.Add(dt.DefaultView(0).Item("descripcion"), AddressOf mar_ol_tableau1_Click)


    End Sub

    Private Sub Menu_Comercial(ByVal mMenuP() As RichMenuItem, ByVal dt As DataTable, ByVal cod_tipo_usuario As Int32)
        'Menu Comercial
        ''Sub Menus
        dt.DefaultView.RowFilter = "cod_sub_menu = 5"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Codicasa"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 6"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Dmarte"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 7"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Alamsa"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 16"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Tecno"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 22"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("DiUva"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 23"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Vinoteca"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 28"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Divinos"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_menu = 17" ''Menu de Presupuestos
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Presupuestos"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 32"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Administracion Movil"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 42"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Wine Society"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If


        dt.DefaultView.RowFilter = "cod_sub_menu = 43"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem("Edifact"))
        Else
            mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        End If

        'dt.DefaultView.RowFilter = "cod_sub_menu = 47"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(2).MenuItems.Add(New RichMenuItem("Facturacion al Costo"))
        'Else
        '    mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        'End If

        'dt.DefaultView.RowFilter = "cod_sub_menu = 47"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(2).MenuItems.Add(New RichMenuItem("Facturacion al Costo"))
        'Else
        '    mMenuP(2).MenuItems.Add(New RichMenuItem(""))
        'End If

        dt.DefaultView.RowFilter = "opcion = 'mco_cdc_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reporte", AddressOf mco_cdc_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        '(c)22052011 Se quitaron las opciones de MR a solicitud de Harold
        dt.DefaultView.RowFilter = "opcion = 'mco_cdc_reportes_mayoristas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes Mayoristas", AddressOf mco_cdc_reportes_mayoristas_Click, Shortcut.CtrlR, "Reportes"))
        End If



        dt.DefaultView.RowFilter = "opcion = 'mco_dma_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reporte", AddressOf mco_dma_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_ala_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reporte", AddressOf mco_ala_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_tec_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reporte", AddressOf mco_tec_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_diu_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reporte", AddressOf mco_diu_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If





        dt.DefaultView.RowFilter = "opcion = 'mco_div_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reporte", AddressOf mco_div_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mco_reportes_corporativos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "Reportes Corporativos", AddressOf mco_ReportesCorporativos_Click, Shortcut.CtrlR, "Tracking de Pedidos"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_inventario'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Inventario Clientes", AddressOf mco_inventario_Click, Shortcut.CtrlI, "mco_inventario_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_tracking_pedido'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Trac&king de Pedidos", AddressOf mco_trancking_pedidos_Click, Shortcut.CtrlK, "mco_trancking_pedidos_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_tracking_factura'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Trac&king de Factura", AddressOf mco_trancking_factura_Click, Shortcut.CtrlShiftK, "mco_trancking_factura_Click de Pedidos"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_consulta_cliente'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eLanguages), "Consult&a de Clientes", AddressOf mco_consulta_clientes_Click, Shortcut.CtrlA, "mco_consulta_clientes_Click de Pedidos"))
        End If

        'BackOrder
        dt.DefaultView.RowFilter = "opcion = 'mco_back_order'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eSearch), "&Back Order", AddressOf mco_back_order_Click, Shortcut.CtrlB, "mco_back_order_Click"))
        End If

        'Clientes de Contado
        dt.DefaultView.RowFilter = "opcion = 'mco_clientescontado'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eLanguages), "Clientes de Contado", AddressOf mco_clientesContado_Click, Shortcut.CtrlC, "mco_clientesContado_Click"))
        End If


        'Administracion de la Escasez
        dt.DefaultView.RowFilter = "opcion = 'mco_administracion_escasez'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Administracion de Escase&z", AddressOf mco_administracion_escasez_Click, Shortcut.CtrlZ, "mco_administracion_escasez_Click"))
        End If


        'Soporte CLAIM
        dt.DefaultView.RowFilter = "opcion = 'mco_soporte_claim'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "&Soporte CLAIM", AddressOf mco_claim_Click, Shortcut.CtrlS, "mco_claim_Click"))
        End If


        'Presupuestos


        dt.DefaultView.RowFilter = "opcion = 'mpt_verpresupuestoGeneral'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egAltavoz), "Presupuesto General", AddressOf mco_presupuestoGeneral_Click, Shortcut.CtrlT, "mco_presupuestoGeneral_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mpt_CargarPresupuestoComercial'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            'Me.menu_presupuesto_subir_comercial.Visible = True
            mMenuP(2).MenuItems(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "Subir Presupuesto Comercial", AddressOf menuSubirPptoComercial_Click, Shortcut.CtrlT, "Liberar Ppto Producto"))
        End If

        'Liberar Ppto Cliente
        dt.DefaultView.RowFilter = "opcion = 'mco_liberar_ppto_cliente'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eUndo), "Liberar &Ppto Cliente", AddressOf mco_liberar_ppto_cliente_Click, Shortcut.CtrlP, "Liberar Ppto Cliente"))
        End If

        'Liberar Ppto Producto
        dt.DefaultView.RowFilter = "opcion = 'mco_liberar_ppto_producto'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "Liberar Pp&to Producto", AddressOf mco_liberar_ppto_producto_Click, Shortcut.CtrlT, "Liberar Ppto Producto"))
        End If


        'Liberar Ppto Producto
        dt.DefaultView.RowFilter = "opcion = 'mco_presupuesto_marca_ayp'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egMsgBInfo), "Presupuesto Marca A&&P", AddressOf mco_presupuesto_marca_ayp_Click, Shortcut.CtrlT, "Liberar Ppto Producto"))
        End If

        'Administracion Mobil
        dt.DefaultView.RowFilter = "opcion = 'mco_mob_asignacion_rutas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(8).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfig1), "Asignacion de Rutas  ", AddressOf mco_mob_asignacion_rutas_Click, Shortcut.CtrlShiftR, "mco_mob_asignacion_rutas_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_con_productos_aprobados'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(8).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eStop), "Administracion Con&signaciones ", AddressOf mco_admon_consignaciones_Click, Shortcut.CtrlS, "mco_admon_consignaciones_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_OdeCPedidos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eStop), "Orden de Compra a Pedido ", AddressOf mco_OdCPedido_Click, Shortcut.CtrlS, "mco_OdCPedido_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mco_actualizacion_productos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "Actualizacion de Productos", AddressOf mco_actualizacion_productos_Click, Shortcut.CtrlShiftS, "mco_actualizacion_productos_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mco_vin_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "&Reporte", AddressOf mco_vin_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_VinotecaMaxMin'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Definir Minimos y Maximos ", AddressOf mco_MaxMinimosVinoteca_Click, Shortcut.CtrlS, "mco_MaxMinimosVinoteca_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_VinotecaPedido'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eLanguages), "Realizar Pedido ", AddressOf mco_PedidoVinoteca_Click, Shortcut.CtrlS, "mco_PedidoVinoteca_Click"))
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eParent), "Realizar Pedido Otras Bodegas", AddressOf mco_PedidoVinoteca_Bodegas_Click, Shortcut.CtrlS, "mco_PedidoVinoteca_Bodegas_Click"))

        End If


        dt.DefaultView.RowFilter = "opcion = 'mco_DevolucinesInterempresas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "Devoluciones Interempresas", AddressOf mco_devolucionesInterempresas_Click, Shortcut.CtrlD, "mco_devolucionesInterempresas_Click"))
        End If



        dt.DefaultView.RowFilter = "opcion = 'mco_vin_sincronizar_productos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "&Sincronizar Productos", AddressOf mco_vin_sincronizar_productos_Click, Shortcut.CtrlR, "mco_vin_sincronizar_productos_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_vin_sincronizar_memos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Sincronizar Memos", AddressOf mco_vin_sincronizar_memos_Click, Shortcut.CtrlR, "mco_vin_sincronizar_memos_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_vin_liberar_documentos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "&Liberar Traslados", AddressOf mco_vinoteca_liberar_salidas_Click, Shortcut.CtrlR, "mco_vinoteca_liberar_salidas_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mco_vin_entradas_traslado'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "&Entradas por Traslado", AddressOf mco_vinoteca_entradaxtraslados_Click, Shortcut.CtrlR, "mco_vinoteca_entradaxtraslados_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_vin_recepcion_mercaderia_vinoteca'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "Recepcion de &Mercaderia ", AddressOf mco_recepcion_mercaderia_vinoteca_Click, Shortcut.CtrlR, "mco_recepcion_mercaderia_vinoteca_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_vin_solicitud_traslados'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "Solicitud &Traslados con Min & Max", AddressOf mco_vin_solicitud_traslados_Click, Shortcut.CtrlShiftT, "mco_vin_solicitud_traslados_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mco_Devoluciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRedo), "Devoluciones de Productos", AddressOf mco_devoluciones_Click, Shortcut.CtrlS, "mco_devoluciones_Click"))



        dt.DefaultView.RowFilter = "opcion = 'mco_PedidoDivinos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "Pedidos Divinos", AddressOf mco_div_pedido_Click, Shortcut.CtrlF, "mco_div_pedido_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mco_trackingTraslados'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Tracking Traslados", AddressOf mco_pedidos_telemarketing_Click, Shortcut.CtrlT, "mco_pedidos_telemarketing_Click"))



        dt.DefaultView.RowFilter = "opcion = 'mco_impresionfel'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Reimpresion FEL", AddressOf mco_reimpresion_fel_Click, Shortcut.CtrlU, "mco_reimpresion_fel_Click"))



        'Opcion Actualizacion SKU 05162014
        dt.DefaultView.RowFilter = "opcion = 'mco_actualizar_sku'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfig1), "&Actualizar SKU Walmart", AddressOf mco_actualizacion_sku_Click, Shortcut.CtrlA, "mco_actualizacion_sku_Click"))
        End If

        'Opcion Actualizacion SKU 05162014
        dt.DefaultView.RowFilter = "opcion = 'mco_actualizar_sku_unisuper'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfig1), "&Actualizar SKU UNISUPER", AddressOf mco_actualizacion_sku_unisuper_Click, Shortcut.CtrlA, "mco_actualizacion_sku_unisuper_Click"))
        End If

        'pedidos Unisuper 20220720
        dt.DefaultView.RowFilter = "opcion = 'mco_pedidoUnisuper'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Pedidos Unisuper", AddressOf mco_pedidos_unisuper_Click, Shortcut.CtrlU, "mco_pedidos_unisuper_Click"))


        'Opcion Reprocesa Informacion 05162014
        dt.DefaultView.RowFilter = "opcion = 'mco_reprocesa_edifact'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "&Reprocesar EdiFact", AddressOf mco_reproceso_isf_Click, Shortcut.CtrlR, "mco_reproceso_isf_Click"))
        End If

        'Opcion EdiFact
        dt.DefaultView.RowFilter = "opcion = 'mco_edifact'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRun), "&Ordenes de Compra EdiFact", AddressOf mcoEdifact_Click, Shortcut.CtrlO, "mcoEdifact_Click"))
        End If

        'Informacion Inner Pack
        dt.DefaultView.RowFilter = "opcion = 'mco_innerpack'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eAddToFavorites), "Asignacion &Inner Pack", AddressOf mco_edi_inner_pack_Click, Shortcut.CtrlI, "mco_edi_inner_pack_Click"))
        End If

        'Informacion Retail Link
        dt.DefaultView.RowFilter = "opcion = 'mco_retaillink'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePreview), "Informacion Retail Link", AddressOf mcoRetailLink_Click, Shortcut.CtrlR, "mcoRetailLink_Click"))
        End If


        'Informacion para Mercaderistas
        dt.DefaultView.RowFilter = "opcion = 'mco_mercaderistas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eMail), "Envio Informacion Mercaderistas", AddressOf mco_mercaderistas_Click, Shortcut.CtrlE, "mco_mercaderistas_Click"))
        End If


        'Validar Ordenes 
        dt.DefaultView.RowFilter = "opcion = 'mco_ordenes_centralizadas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Validacion Ordenes Centralizadas", AddressOf mco_edi_validacion_oc_wm_Click, Shortcut.CtrlO, "mco_edi_validacion_oc_wm_Click"))
        End If


        'Cargas BI
        dt.DefaultView.RowFilter = "opcion = 'mco_carga_informacion_bi'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(2).MenuItems(10).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Carga Informacion BI", AddressOf mco_edi_carga_informacion_bi_Click, Shortcut.CtrlO, "mco_edi_carga_informacion_bi_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mco_facturacion_costo'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egStandBy), "Facturacion Autoconsumo", AddressOf mcoFacturacionCosto_Click, Shortcut.CtrlShiftC, "mcoFacturacionCosto_Click"))


        dt.DefaultView.RowFilter = "opcion = 'mco_monitor_maquila'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Monitor Maquila", AddressOf mco_MonitorMaquila_Click, Shortcut.CtrlShiftC, "mco_MonitorMaquila_Click"))


        ''Tipos de facturacion al costo 01072015
        'Facturacion al Costo Bonificaciones
        'dt.DefaultView.RowFilter = "opcion = 'mco_facturacion_costo_bonificaciones'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems(11).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egStandBy), "Facturacion al Costo Bonificacion", AddressOf mcoFacturacionCosto_Click, Shortcut.CtrlF, "Pedido"))

        ' ''Facturacion al Costo Muestras
        'dt.DefaultView.RowFilter = "opcion = 'mco_facturacion_costo_muestras'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems(11).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Facturacion al Costo Muestras", AddressOf mcoFacturacionCosto_Click, Shortcut.CtrlF, "Pedido"))

        ' ''Facturacion al Costo Degustaciones y faltantantes de Origen
        'dt.DefaultView.RowFilter = "opcion = 'mco_facturacion_costo_degustaciones'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems(11).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Facturacion al Costo Degustacion y Faltantes de Origen", AddressOf mcoFacturacionCosto_Click, Shortcut.CtrlF, "Pedido"))

        ' ''Facturacion al Costo destruccion
        'dt.DefaultView.RowFilter = "opcion = 'mco_facturacion_costo_destruccion'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(2).MenuItems(11).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Facturacion al Costo Destruccion", AddressOf mcoFacturacionCosto_Click, Shortcut.CtrlF, "Pedido"))


    End Sub

    Private Sub Menu_Finanzas(ByVal mMenup() As RichMenuItem, ByVal dt As DataTable, ByVal cod_tipo_usuario As Int32)

        'sub menus
        dt.DefaultView.RowFilter = "cod_sub_menu = 1"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems.Add(New RichMenuItem("Contabilidad"))
        Else
            mMenup(4).MenuItems.Add(New RichMenuItem(""))
        End If
        dt.DefaultView.RowFilter = "cod_sub_menu = 2"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems.Add(New RichMenuItem("Creditos"))
        Else
            mMenup(4).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 3"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems.Add(New RichMenuItem("Facturacion"))
        Else
            mMenup(4).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 13"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems.Add(New RichMenuItem("Informes Financieros"))
        Else
            mMenup(4).MenuItems.Add(New RichMenuItem(""))
        End If

        ''Finanzas Contabilidad

        ''Liberar Facturas Parcialmente
        dt.DefaultView.RowFilter = "opcion = 'mfi_LiberarProductos_Facturas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCut), "&Liberar Productos de Facturas", AddressOf mfi_liberar_facturas_Click, Shortcut.CtrlL, "mfi_liberar_facturas_Click"))
        End If


        ''Liberar Facturas de Guia
        dt.DefaultView.RowFilter = "opcion = 'mfi_SacarFacturas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eDelete), "&Liberar Facturas de Guias", AddressOf mfi_SacarFacturas_Click, Shortcut.CtrlS, "mfi_SacarFacturas_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mfi_co_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mfi_co_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mfi_ejecuta_sp'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eParent), "&Procedimientos Almacenados", AddressOf mfi_ejecuta_sp_Click, Shortcut.CtrlF1, "mfi_ejecuta_sp_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mfi_transmision'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eParent), "Traslado de Informacion de Tiendas", AddressOf mfi_sincronizacion_informacion_Click, Shortcut.CtrlF2, "mfi_sincronizacion_informacion_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mfi_PagosElectronicos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Generacion de Lotes", AddressOf mfi_generarLotes_Click, Shortcut.CtrlG, "mfi_generarLotes_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mfi_cancelacionCompromisos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eParent), "Cancelacion de Compromisos", AddressOf mfi_cancelacion_Compromisos_Click, Shortcut.CtrlG, "mfi_cancelacion_Compromisos_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mfi_FacturaElectronica'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eMail), "&Factura Electronica", AddressOf mfi_co_cface_Click, Shortcut.CtrlF, "mfi_co_cface_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mfi_OperacionRecibo'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Operacion de Recibos", AddressOf mfiOperacionRecibos_Click, Shortcut.CtrlShiftO, "mfiOperacionRecibos_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mfi_costoIngresoCD'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCut), "&Costo Ingreso CD", AddressOf mfi_costo_ingresoCD_Click, Shortcut.CtrlShiftO, "mfi_costo_ingresoCD_Click"))


        dt.DefaultView.RowFilter = "opcion = 'mfi_caja_chica'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaLapiz), "Operacion de Caja Chica", AddressOf mfi_caja_chica_Click, Shortcut.CtrlShiftO, "mfi_caja_chica_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mfi_caja_chica_multiple'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Operacion de Caja Chica Multiple", AddressOf mfi_caja_chica_multiple_Click, Shortcut.CtrlShiftM, "mfi_caja_chica_multiple_Click"))


        dt.DefaultView.RowFilter = "opcion = 'mfi_productos_contables'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaIcons), "Productos Contables", AddressOf mfi_con_productos_contables_Click, Shortcut.CtrlShiftP, "mfi_con_productos_contables_Click"))


        dt.DefaultView.RowFilter = "opcion = 'mfi_facturas_analisis'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Modificar Analisis Factura", AddressOf mfi_con_analisis_facturas_Click, Shortcut.CtrlShiftA, "mfi_con_analisis_facturas_Click"))



        dt.DefaultView.RowFilter = "opcion = 'mfi_anulacion_fee'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRedo), "Anular Documento FEL", AddressOf mfi_con_anulacionFEL_Click, Shortcut.CtrlShiftF, "mfi_con_anulacionFEL_Click"))





        ''Finanzas Creditos
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_pedidos_pendientes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "&Pedidos Pendientes de Aprobaciñn", AddressOf mfi_cr_pedidos_pendientes_Click, Shortcut.CtrlP, "mfi_cr_pedidos_pendientes_Click"))
        End If

        ''Recepcion Control Transporte
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_recepcion_control_transporte'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eMail), "Recepcion &Control de Transporte", AddressOf mfi_cr_recepcion_Control_transporte_Click, Shortcut.CtrlC, "mfi_cr_recepcion_Control_transporte_Click"))
        End If

        ''Sincronizacion clientes tiendas
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_scn_clientes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRueda), "&Sincronizacion de Clientes", AddressOf mfi_cr_snc_clientes_Click, Shortcut.CtrlS, "mfi_cr_snc_clientes_Click"))
        End If

        ''Reportes Creditos
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mfi_cr_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        ''Recibos Canal Moderno
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_recibos_canal_moderno'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "&Operacion de Recibos Canal Moderno", AddressOf mfi_cr_recibos_canal_moderno_Click, Shortcut.CtrlShiftC, "mfi_cr_recibos_canal_moderno_Click"))
        End If

        ''Recibos Envio Documentos Canal Moderno
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_envio_canal_moderno'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRun), "&Envio Documentos Canal Moderno", AddressOf mfi_cr_envio_documentos_canal_moderno_Click, Shortcut.CtrlShiftE, "mfi_cr_envio_documentos_canal_moderno_Click"))
        End If


        ''Recepcion de Devoluciones
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_recepcion_devoluciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eAddToFavorites), "&Recepcion de Devoluciones", AddressOf mfi_cr_recepcion_devoluciones_Click, Shortcut.CtrlShiftR, "mfi_cr_recepcion_devoluciones_Click"))
        End If


        ''Recepcion de Devoluciones
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_cancelacionFacturaConNota'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Cancelacion de Factura Con Nota", AddressOf mfi_cre_analisis_facturas_Click, Shortcut.CtrlShiftR, "mfi_cre_analisis_facturas_Click"))
        End If



        ''Renovacion de Consignaciones
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_renovacionConsignaciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eLanguages), "&Renovacion Consignaciones", AddressOf mfi_cre_consolidacion_consignaciones_Click, Shortcut.CtrlShiftR, "mfi_cre_consolidacion_consignaciones_Click"))
        End If

        ''Renovacion de Consignaciones
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_doctos_fel'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eLanguages), "P&rocesos FEL", AddressOf mfi_cre_procesos_fel_Click, Shortcut.CtrlShiftR, "mfi_cre_procesos_fel_Click"))
        End If


        ''Control de Pagos a Exterior Por medio de OC
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_pagos_exterior'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Control &Pagos Exterior", AddressOf mfi_cre_pagos_exterior_Click, Shortcut.CtrlShiftP, "mfi_cre_pagos_exterior_Click"))
        End If



        ''Liquidacion de transportes en Caja
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_liquidacion_transportes_caja'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Liquidacion Transportes-Caja", AddressOf mfi_cre_liquidacion_transportes_caja_Click, Shortcut.CtrlShiftL, "mfi_cre_liquidacion_transportes_caja_Click"))
        End If


        ''Liquidacion de transportes en Caja
        dt.DefaultView.RowFilter = "opcion = 'mfi_cr_monitor_impresiones_cedis'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "Monitor de Impresiones CEDI", AddressOf mfi_cre_monitor_impresiones_Click, Shortcut.CtrlShiftM, "mfi_cre_monitor_impresiones_Click"))
        End If





        ''Finanzas Facturacion e
        dt.DefaultView.RowFilter = "opcion = 'mfi_consignaciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.EConsigna), "Li&berar Consignaciones", AddressOf mfi_consignaciones_Click, Shortcut.CtrlC, "mfi_consignaciones_Click"))
        End If

        '' Pedidos Pendientes Factura
        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_pedidos_facturar'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRueda), "Pedidos Pendientes de &Facturar", AddressOf mfi_fc_pedidos_facturar_Click, Shortcut.CtrlF, "mfi_fc_pedidos_facturar_Click"))
        End If

        ''Reportes
        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mfi_fc_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        ''Envio Documentos Facturas MR
        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_envio_documentos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eMail), "&Envio de Documentos", AddressOf mfi_enviar_factura_Click, Shortcut.CtrlShiftE, "mfi_enviar_factura_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_impresoras'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eLanguages), "&Direccionar Impresoras", AddressOf mfi_fac_direccionar_impresoras_Click, Shortcut.CtrlShiftI, "mfi_fac_direccionar_impresoras_Click"))
        End If

        ''Facturacion Interempresas
        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_facturacion_interempresas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRun), "Facturacion Interempresas", AddressOf mfi_fac_compras_interempresas_Click, Shortcut.CtrlShiftO, "mfi_fac_compras_interempresas_Click"))



        ''Facturacion Interempresas
        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_facturacion_interempresas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "Trasladar Facturas", AddressOf mfi_fc_traslado_facturas_Click, Shortcut.CtrlShiftO, "mfi_fc_traslado_facturas_Click"))



        '''Factura Electronica
        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_fel_telemarketing'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "&Fel TMK", AddressOf mfi_fc_fel_telemarketing_Click, Shortcut.CtrlShiftE, "mfi_fc_fel_telemarketing_Click"))
        End If


        '''Factura Electronica
        dt.DefaultView.RowFilter = "opcion = 'mfi_fc_impresiones_factura_area'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "Centro de &Impresion de Facturas", AddressOf mfi_fac_monitor_impresiones_recolecta_Click, Shortcut.CtrlShiftE, "mfi_fac_monitor_impresiones_recolecta_Click"))
        End If


        ''Informes Financieros

        ''Reportes
        dt.DefaultView.RowFilter = "opcion = 'mfi_inicializar_periodo'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eSearch), "&Inicializar Periodo", AddressOf mfi_inicializar_periodo_Click, Shortcut.CtrlI, "mfi_inicializar_periodo_Click"))
        End If

        ''Reportes
        dt.DefaultView.RowFilter = "opcion = 'mfi_if_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mfi_if_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        ''Inventarios Fisicos
        dt.DefaultView.RowFilter = "opcion = 'mfi_inventariosFisicos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egStandBy), "Inventarios &Fisicos", AddressOf mfiinventariosFisicos_Click, Shortcut.CtrlF, "mfiinventariosFisicos_Click"))
        End If

        ''Inventarios Cargar Lista Costo
        dt.DefaultView.RowFilter = "opcion = 'mfi_CargarListaCosto'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eZoomIn), "Cargar Lista de Costo", AddressOf mfiListaCosto_Click, Shortcut.CtrlF, "mfiListaCosto_Click"))
        End If


        ''Inventarios Cambiar Dai
        dt.DefaultView.RowFilter = "opcion = 'mfi_CambiarDia'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Cambiar DAI", AddressOf mfiCambiarDai_Click, Shortcut.CtrlF, "mfiCambiarDai_Click"))
        End If


        ''Inventarios Cambiar Dai
        dt.DefaultView.RowFilter = "opcion = 'mfi_co_producto_item'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eParent), "Asociar Item", AddressOf mfi_co_item_producto_Click, Shortcut.CtrlA, "mfi_co_item_producto_Click"))
        End If


        ''Conciliacion Bancaria
        dt.DefaultView.RowFilter = "opcion = 'mfi_co_conciliacionbancaria'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eLanguages), "&Conciliacion Bancaria", AddressOf mfi_co_conciliacionBancaria_Click, Shortcut.CtrlC, "mfi_co_conciliacionBancaria_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mfi_con_tracking_pagos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Tracking Pago Facturas", AddressOf mfi_con_tracking_pagos_Click, Shortcut.CtrlShiftA, "mfi_con_tracking_pagos_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mfi_con_carga_combustible'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "Carga Combustible TC", AddressOf mfi_co_carga_combustible_Click, Shortcut.CtrlShiftT, "mfi_co_carga_combustible_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mfi_con_carga_caja_chica_teams'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Carga Caja Chica Teams", AddressOf mfi_co_liquidacion_caja_chica_teams_Click, Shortcut.CtrlShiftT, "mfi_co_liquidacion_caja_chica_teams_Click"))


        dt.DefaultView.RowFilter = "opcion = 'mfi_con_tracking_caja_chica'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenup(4).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Tracking Caja Chica", AddressOf mfi_con_tracking_caja_chica_Click, Shortcut.CtrlShift0, "mfi_con_tracking_caja_chica_Click"))





    End Sub

    Private Sub Menu_IT(ByVal mMenuP() As RichMenuItem, ByVal dt As DataTable, ByVal cod_tipo_usuario As Int32)
        ''SubMenu JSA
        'dt.DefaultView.RowFilter = "cod_sub_menu = 12"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
        '    mMenuP(5).MenuItems.Add(New RichMenuItem("Junta Semanal de Avance"))
        'Else
        '    mMenuP(5).MenuItems.Add(New RichMenuItem(""))
        'End If

        ''SubMenu Procesos
        dt.DefaultView.RowFilter = "cod_sub_menu = 17"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems.Add(New RichMenuItem("Procesos"))
        Else
            mMenuP(5).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 20"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(5).MenuItems.Add(New RichMenuItem("Insumos"))
        Else
            mMenuP(5).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 21"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(5).MenuItems.Add(New RichMenuItem("Activos"))
        Else
            mMenuP(5).MenuItems.Add(New RichMenuItem(""))
        End If
        'mantenimiento de usuarios
        dt.DefaultView.RowFilter = "opcion = 'mti_usuario'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaIcons), "&Seguridad", AddressOf mti_usuario_Click, Shortcut.CtrlS, "mti_usuario_Click"))
        End If

        'diseñador de reportes
        dt.DefaultView.RowFilter = "opcion = 'mti_diseñador'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "&Diseñador de Reportes", AddressOf mti_diseñador_Click, Shortcut.CtrlD, "mti_diseñador_Click"))
        End If

        ''reportes
        dt.DefaultView.RowFilter = "opcion = 'mti_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mti_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        ''Conversiones
        dt.DefaultView.RowFilter = "opcion = 'mti_parametros_sistema'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHelp), "&Parametros del Sistema", AddressOf mti_conversiones_Click, Shortcut.CtrlP, "mti_conversiones_Click"))
        End If

        '' Sincronizacion con tiendas Ofertas
        dt.DefaultView.RowFilter = "opcion = 'mti_scn_precios_ofertas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRueda), "Enviar &Ofertas a Tiendas", AddressOf mti_scn_precios_ofertas_Click, Shortcut.CtrlO, "mti_scn_precios_ofertas_Click"))
        End If

        '' Sincronizacion con tiendas Productos
        dt.DefaultView.RowFilter = "opcion = 'mti_scn_productos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), "Enviar &Productos a Tiendas", AddressOf mti_scn_productos_Click, Shortcut.CtrlP, "mti_scn_productos_Click"))
        End If




        ' ''Reportes Junta Semanal de Avance
        'dt.DefaultView.RowFilter = "opcion = 'mti_jsa_reportes'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
        '    mMenuP(5).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "Reportes", AddressOf mti_jsa_reportes_Click, Shortcut.CtrlP, "JSA"))
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mti_jsa_automatizada'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(5).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "Junta Semanal de Avance", AddressOf mti_jsa_Click, Shortcut.CtrlP, "JSA"))
        '    'Me.menu_it_procesos_JSA.Visible = True
        'End If
        ''eFace
        'dt.DefaultView.RowFilter = "opcion = 'mti_eface'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
        '    mMenuP(5).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "Eface", AddressOf mti_eface_Click, Shortcut.CtrlShiftE, "JSA"))
        'End If

        '' it actualizacion producto
        dt.DefaultView.RowFilter = "opcion = 'mti_actualizacion_producto'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRefresh), "Actualizacion P&roducto", AddressOf mti_actualizacion_producto_Click, Shortcut.CtrlP, "mti_actualizacion_producto_Click"))
        End If

        '' Cuentas Contables de Producto
        dt.DefaultView.RowFilter = "opcion = 'mti_cuentas_contables'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(5).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), "Cuentas Contables de Productos", AddressOf mti_cuentasContableProductos_Click, Shortcut.CtrlShiftE, "mti_cuentasContableProductos_Click"))
        End If

        'dt.DefaultView.RowFilter = "opcion = 'mti_insumos'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(5).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Maestros", AddressOf mti_insumos_Click, Shortcut.CtrlP, "Producto"))
        '    mMenuP(5).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eZoomIn), "Movimientos", AddressOf mti_insumos_movimientos_Click, Shortcut.CtrlP, "Producto"))
        '    'Me.Menu_It_Insumos_Maestros.Visible = True
        '    'Me.Menu_It_Insumos_Movimientos.Visible = True
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mti_activos'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(5).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Maestros", AddressOf mti_activos_Click, Shortcut.CtrlP, "Producto"))
        '    mMenuP(5).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eZoomIn), "Movimientos", AddressOf mti_movimientos_activos_Click, Shortcut.CtrlP, "Producto"))
        'End If

        'dt.DefaultView.RowFilter = "opcion = 'mti_incidencias'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eZoomIn), "Help Desk", AddressOf mti_Incidencias_Click, Shortcut.CtrlP, "Producto"))
        'End If


        'dt.DefaultView.RowFilter = "opcion = 'dts'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(5).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "DTS", AddressOf mti_dts_Click, Shortcut.CtrlP, "Producto"))
        'End If


    End Sub

    Private Sub Menu_Logistica(ByVal mMenuP() As RichMenuItem, ByVal dt As DataTable, ByVal cod_tipo_usuario As Int32)

        Dim clsGen As New ClasesGenerales.General

        dt.DefaultView.RowFilter = "cod_sub_menu = 36"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem("Control Etiquetado"))
        Else
            mMenuP(6).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 38"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem("Horarios"))
        Else
            mMenuP(6).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "cod_sub_menu = 44"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem("Transportes"))
        Else
            mMenuP(6).MenuItems.Add(New RichMenuItem(""))
        End If


        dt.DefaultView.RowFilter = "cod_sub_menu = 49"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem("3PL"))
        Else
            mMenuP(6).MenuItems.Add(New RichMenuItem(""))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mlo_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mlo_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mlo_reportes_picking'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePreview), "R&eportes Picking", AddressOf mlo_reportes_picking_Click, Shortcut.CtrlE, "Reportes"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mlo_recepcionfacturas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Recepcion de Facturas", AddressOf mlo_recepcionFacturas_Click, Shortcut.CtrlF, "Recepciñn Facturas"))
        End If

        'dt.DefaultView.RowFilter = "opcion = 'mlo_finalizacion_picking'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Finalizacion Picking", AddressOf mlo_finalizacion_picking_Click, Shortcut.CtrlF, "Control de Transporte"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_parametrizacion_picking'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Parametrizacion Picking", AddressOf mlo_parametrizacion_picking_Click, Shortcut.CtrlShiftP, "Control de Transporte"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_Impresion_picking_manual'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            'If clsGen.Obtener_XMLConfig("ubicacion", False).ToString.ToLower.StartsWith("sv") Then
            '    mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Envio de Informacion OPL", AddressOf mlo_impresion_picking_manual_Click, Shortcut.CtrlI, "Impresion Picking"))
            'Else
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Impresion Picking Manual", AddressOf mlo_impresion_picking_manual_Click, Shortcut.CtrlI, "Impresion Picking"))
            'End If
        End If

        dt.DefaultView.RowFilter = "opcion = 'mlo_asignacion_picking'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            'If clsGen.Obtener_XMLConfig("ubicacion", False).ToString.ToLower.StartsWith("sv") Then
            '    mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Envio de Informacion OPL", AddressOf mlo_impresion_picking_manual_Click, Shortcut.CtrlI, "Impresion Picking"))
            'Else
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCopy), "&Asignacion Picking", AddressOf mlo_asignacion_picking_Click, Shortcut.CtrlShiftA, "mlo_asignacion_picking_Click"))
            'End If
        End If


        dt.DefaultView.RowFilter = "opcion = 'mlo_reasignacion_picking'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            'If clsGen.Obtener_XMLConfig("ubicacion", False).ToString.ToLower.StartsWith("sv") Then
            '    mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Envio de Informacion OPL", AddressOf mlo_impresion_picking_manual_Click, Shortcut.CtrlI, "Impresion Picking"))
            'Else
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.EConsigna), "&Re-Asignacion Picking", AddressOf mlo_reasignacionPicking_Click, Shortcut.CtrlShiftR, "mlo_reasignacionPicking_Click"))
            'End If
        End If

        ''Planificacion de Rutas
        dt.DefaultView.RowFilter = "opcion = 'mlo_chequeo'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRun), "Chequeo Rutas", AddressOf mlo_chequeo_Click, Shortcut.CtrlK, "mlo_chequeo_Click"))

        ''Planificacion de Rutas
        dt.DefaultView.RowFilter = "opcion = 'mlo_planificacion_rutas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "Planificacion de Rutas", AddressOf mlo_planificacion_rutas_Click, Shortcut.CtrlP, "mlo_planificacion_rutas_Click"))



        ''Control de Transporte
        dt.DefaultView.RowFilter = "opcion = 'mlo_control_transporte'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Control de &Transporte", AddressOf mlo_control_transporte_Click, Shortcut.CtrlT, "mlo_control_transporte_Click"))


        ''Programar una recolecciñn de Mercaderia 20241115 AS
        dt.DefaultView.RowFilter = "opcion = 'mlo_control_recolecciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRueda), "Recoleccion de Mercaderia", AddressOf mlo_tr_recolecciones_Click, Shortcut.CtrlG, "mlo_tr_recolecciones_Click"))




        ''Liquidacion de Piloto
        dt.DefaultView.RowFilter = "opcion = 'mlo_liquidacionPiloto'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "Liquidacion Piloto", AddressOf mlo_liquidacionPiloto_Click, Shortcut.CtrlL, "mlo_liquidacionPiloto_Click"))

        ''Impresion de Ordenes Edi
        dt.DefaultView.RowFilter = "opcion = 'mlo_ImpresionOrdenesEDI'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Monitor de Impresiones Transporte", AddressOf mlo_ImpresionOrdenesEDI_Click, Shortcut.CtrlI, "mlo_ImpresionOrdenesEDI_Click"))


        ''Generar Informacion de Transportes
        dt.DefaultView.RowFilter = "opcion = 'mlo_genera_info'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCulture), "&Genera Informacion Pilotos", AddressOf mlo_tr_generarInformacion_Click, Shortcut.CtrlG, "mlo_tr_generarInformacion_Click"))

        ' ''Generar Informacion de Transportes
        'dt.DefaultView.RowFilter = "opcion = 'mlo_cumplimiento_diario'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "&Cumplimiento Diario", AddressOf mlo_tr_cumplimiento_entregas_Click, Shortcut.CtrlG, "Impresion Picking"))






        ''Asociar E/S Inventarios
        dt.DefaultView.RowFilter = "opcion = 'mlo_asociar_es_inventario'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRueda), "&Asociar E/S Inventarios", AddressOf mlo_asociar_es_inventario_Click, Shortcut.CtrlA, "mlo_asociar_es_inventario_Click"))
        End If

        ''Sincronizacion de Salidas de Inventarios
        dt.DefaultView.RowFilter = "opcion = 'mlo_scn_movimientos_inventario'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eAddToFavorites), "Sincronizar &Movimientos de Inventario", AddressOf mlo_scn_Movimientos_Inventario_Click, Shortcut.CtrlM, "mlo_scn_Movimientos_Inventario_Click"))
        End If

        ''Maquila
        dt.DefaultView.RowFilter = "opcion = 'mlo_maq_monitor'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egCompuTeclado), "Ma&quila", AddressOf mlo_maq_monitor_Click, Shortcut.CtrlQ, "mlo_maq_monitor_Click"))
        End If

        ''Pedidos Posfechados
        dt.DefaultView.RowFilter = "opcion = 'mlo_pedidos_posfechados'"

        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egStandBy), "Pedidos Pos&fechados", AddressOf mlo_pedidos_posfechados_Click, Shortcut.CtrlShiftF, "mlo_pedidos_posfechados_Click"))
        End If


        ''Liquidacion de Gastos
        dt.DefaultView.RowFilter = "opcion = 'mlo_liquidacionGastos'"

        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Liquidacion G&astos", AddressOf mlo_liquidacionGastos_Click, Shortcut.CtrlShiftG, "mlo_liquidacionGastos_Click"))


        ''Liquidacion de Gastos
        dt.DefaultView.RowFilter = "opcion = 'mlo_liberarFacturas'"

        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "Liberar Facturas", AddressOf mlo_tra_liberar_facturas_Click, Shortcut.CtrlShiftL, "mlo_tra_liberar_facturas_Click"))


        ''Cargar solicitud de devoluciones en el control de transporte 20150610
        dt.DefaultView.RowFilter = "opcion = 'mlo_cargardevoluciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egStandBy), "Cargar Solicitud de Devoluciones", AddressOf mlo_tra_notasdevolucion_Click, Shortcut.CtrlShiftD, "mlo_tra_notasdevolucion_Click"))


        ''Generar Informacion de Transportes Rentado
        dt.DefaultView.RowFilter = "opcion = 'mlo_tr_cumplimiento_rentados'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egMsgBInfo), "Cumplimiento Diario Rentados", AddressOf mlo_tr_cumplimiento_diario_rentado_Click, Shortcut.CtrlG, "mlo_tr_cumplimiento_diario_rentado_Click"))

        ''Generar Informacion de Transportes Rentado
        dt.DefaultView.RowFilter = "opcion = 'mlo_tr_asignar_reenvios'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "Agregar Reenvios", AddressOf mlo_agregar_reenvios_Click, Shortcut.CtrlR, "mlo_agregar_reenvios_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_tr_editar_marcajes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFolderProperties), "Editar Marcajes", AddressOf mlo_tr_editar_marcajes_Click, Shortcut.CtrlR, "mlo_tr_editar_marcajes_Click"))


        ''Fin Sub Menu Transportes


        ''Liquidacion de Gastos
        dt.DefaultView.RowFilter = "opcion = 'mlo_ControlRegistrosSanitarios'"

        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "Registros Sanitarios", AddressOf mlo_controlRegistrosSanitarios_Click, Shortcut.CtrlShiftS, "mlo_controlRegistrosSanitarios_Click"))


        ''Facturacion Anixter
        'dt.DefaultView.RowFilter = "opcion = 'mlo_facturacionANIXTER'"

        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Facturacion ANIXTER", AddressOf mlo_facturacionANIXTER_Click, Shortcut.CtrlShiftA, "Facturacion Anixter"))





        'Proceso de Canasta Diciembre 2011
        dt.DefaultView.RowFilter = "opcion = 'mlo_procesoCanastasPedidos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Canastas Traslados-Pedidos", AddressOf mlo_salidasEnPedidos_Click, Shortcut.CtrlShiftS, "mlo_salidasEnPedidos_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_rechazosPendientes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Reimpresion Devoluciones", AddressOf mlo_devolucionesrechazos_Click, Shortcut.CtrlShiftS, "mlo_devolucionesrechazos_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_comprasInterEmpresas'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRedo), "Compras InterEmpresas", AddressOf mlo_ComprasInterEmpresas_Click, Shortcut.CtrlShiftE, "mlo_ComprasInterEmpresas_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_controlSeries'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "Control de Series", AddressOf mlo_series_Click, Shortcut.CtrlShiftS, "mlo_series_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_productos_logistica'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "Productos Logistica", AddressOf mlo_actualizacion_productos_Click, Shortcut.CtrlShiftS, "mlo_actualizacion_productos_Click"))




        dt.DefaultView.RowFilter = "opcion = 'mlo_maquila_3pl'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Maquila 3PL", AddressOf mlo_picking_3pl_Click, Shortcut.CtrlShiftM, "mlo_picking_3pl_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_informe_recepcion_3pl'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eZoomIn), "Informe Recepcion 3PL", AddressOf mlo_informe_recepcion_3pl_Click, Shortcut.CtrlShiftI, "mlo_informe_recepcion_3pl_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_pedidos_3pl'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eZoomIn), "Recepcion Pedidos", AddressOf mlo_procesar_pedidos_3pl_Click, Shortcut.CtrlShiftI, "mlo_procesar_pedidos_3pl_Click"))

        ''Facturacion Anixter
        dt.DefaultView.RowFilter = "opcion = 'mlo_facturacionANIXTER'"

        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Creacion Productos 3PL", AddressOf mlo_productosANIXTER_Click, Shortcut.CtrlShiftA, "mlo_productosANIXTER_Click"))


        dt.DefaultView.RowFilter = "opcion = 'mlo_etiq_materiales'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Asignacion de Materiales", AddressOf mlo_etiq_materiales_Click, Shortcut.CtrlShiftS, "mlo_etiq_materiales_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_etiq_OdeProduccion'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePreview), "Orden de Produccion", AddressOf mlo_etiq_OProduccion_Click, Shortcut.CtrlShiftS, "mlo_etiq_OProduccion_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_etiq_ProcesoProduccion'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eSearch), "Proceso de Produccion", AddressOf mlo_etiq_ProcesoProduccion_Click, Shortcut.CtrlShiftS, "mlo_etiq_ProcesoProduccion_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_etiq_ProcesoProduccionDA'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eSearch), "Proceso de Produccion DA", AddressOf mlo_ci_etiquetado_Click, Shortcut.CtrlShiftS, "mlo_ci_etiquetado_Click"))



        dt.DefaultView.RowFilter = "opcion = 'mlo_inventarios_ciclicos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaIcons), "Inventarios Ciclicos", AddressOf mlo_inventarios_ciclicos_Click, Shortcut.CtrlShiftI, "mlo_inventarios_ciclicos_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_cambiarHorarioIngreso'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "Cambio de Horario (1) Dia", AddressOf mlo_cambioHorario_Click, Shortcut.CtrlShiftI, "mlo_cambioHorario_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_reporteHorario'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Reporte de Horarios", AddressOf mlo_ReporteHorario_Click, Shortcut.CtrlShiftR, "mlo_ReporteHorario_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_editar_pedidowalmart'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Actualizacion Pedido Walmart", AddressOf mlo_actualizacion_pedidowalmart_Click, Shortcut.CtrlShiftW, "mlo_actualizacion_pedidowalmart_Click"))


        dt.DefaultView.RowFilter = "opcion = 'mlo_informeinternaciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Informe de Internaciones", AddressOf mlo_ingresos_cd_Click, Shortcut.CtrlShiftW, "mlo_ingresos_cd_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_monitorimpresionesAG'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Monitor Impresiones AG", AddressOf mlo_montor_impresiones_AG_Click, Shortcut.CtrlShiftW, "mlo_montor_impresiones_AG_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_control_transporte_tmk'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Control de Transporte TMK", AddressOf mlo_transporte_tmk_Click, Shortcut.CtrlShiftT, "mlo_transporte_tmk_Click"))

        dt.DefaultView.RowFilter = "opcion = 'mlo_picking_tmk'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(6).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaListAB), "Picking TMK", AddressOf mlo_picking_tmk_Click, Shortcut.CtrlShiftP, "mlo_picking_tmk_Click"))


        clsGen = Nothing

    End Sub

    Private Sub Menu_Compras_Importaciones(ByVal mMenuP() As RichMenuItem, ByVal dt As DataTable, ByVal cod_tipo_usuario As Int32)
        '' Sub Menu SCM

        dt.DefaultView.RowFilter = "cod_sub_menu = 14"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem("SCM"))
        Else
            mMenuP(7).MenuItems.Add(New RichMenuItem(""))
        End If
        'mMenuP(7).MenuItems(0).Name = "SCM"

        '' Sub Menu Internaciones
        dt.DefaultView.RowFilter = "cod_sub_menu = 15"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem("SCM Internaciones"))
        Else
            mMenuP(7).MenuItems.Add(New RichMenuItem(""))
        End If
        'mMenuP(7).MenuItems(1).Name = "Internaciones"
        '' Sub Menu Aduanas
        dt.DefaultView.RowFilter = "cod_sub_menu = 30"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem("Administraciñn del Almacñn Aduanero"))
        Else
            mMenuP(7).MenuItems.Add(New RichMenuItem(""))
        End If
        'mMenuP(7).MenuItems(2).Name = "DA"
        '' Sub Menu Aduanas
        dt.DefaultView.RowFilter = "cod_sub_menu = 31"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem("Seguimiento Orden de Compra"))
        Else
            mMenuP(7).MenuItems.Add(New RichMenuItem(""))
        End If
        ' mMenuP(7).MenuItems(3).Name = "Seguimiento"
        '' Sub Requisiones
        dt.DefaultView.RowFilter = "cod_sub_menu = 41"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario = 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem("Requisiciones"))
        Else
            mMenuP(7).MenuItems.Add(New RichMenuItem(""))
        End If
        'mMenuP(7).MenuItems(4).Name = "Requisiciones"
        ''Reportes
        dt.DefaultView.RowFilter = "opcion = 'mci_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mci_reportes_Click, Shortcut.CtrlR, "Reportes"))
            '   mMenuP(7).MenuItems(5).Name = "Reportesmci"
        End If

        dt.DefaultView.RowFilter = "opcion = 'mci_reportes_adicionales'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "Reportes &Adicionales", AddressOf mci_reportes_adicionales_Click, Shortcut.CtrlA, "Reportes"))
            '  mMenuP(7).MenuItems(6).Name = "ReportesmciAdicional"
        End If

        ''OdeC EdiFact
        dt.DefaultView.RowFilter = "opcion = 'mci_orden_edifact'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            '    If cod_tipo_usuario = 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), "&OdeC en EDIFACT", AddressOf mci_odc_edifact_Click, Shortcut.CtrlO, "mci_odc_edifact_Click"))
        End If

        ''Tracking OC
        dt.DefaultView.RowFilter = "opcion = 'mci_tracking_orden_compra'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            '    If cod_tipo_usuario = 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "&Tracking Orden de Compra", AddressOf mci_tracking_orden_compra_Click, Shortcut.CtrlShiftT, "mci_tracking_orden_compra_Click"))
        End If

        ''Actualización OC
        dt.DefaultView.RowFilter = "opcion = 'mci_actualización_oc'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), "&Actualización OC", AddressOf mci_actualizacion_oc_Click, "mci_actualizacion_oc_Click"))
        End If


        ''SCM Tracking OC Tesoreria
        ''(c) 20160505
        dt.DefaultView.RowFilter = "opcion = 'mci_tracking_oc_tesoreria'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "&Tracking Orden de Compra Tesoreria", AddressOf mci_tracking_oc_tesoreria_Click, Shortcut.CtrlE, "mci_tracking_oc_tesoreria_Click"))
        End If

        ''Tracking Internaciones
        dt.DefaultView.RowFilter = "opcion = 'mci_trackinginternaciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(7).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egMsgBInfo), "Tracking &Internaciones", AddressOf mci_trackingInternaciones_Click, Shortcut.CtrlShiftI, "mci_trackingInternaciones_Click"))


        ''SCM Mantenimiento Parametros
        dt.DefaultView.RowFilter = "opcion = 'mci_scm_parametros'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfig1), "Parametros &Generales", AddressOf mci_scm_parametros_Click, Shortcut.CtrlG, "mci_scm_parametros_Click"))
            ' mMenuP(7).MenuItems(0).MenuItems(0).Name = "scm_parametos"
        End If

        ''SCM Mantenimiento Proveedores
        dt.DefaultView.RowFilter = "opcion = 'mci_scm_mantenimiento_proveedores'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "&Mantenimiento de Proveedores", AddressOf mci_scm_mantenimiento_proveedores_Click, Shortcut.CtrlM, "mci_scm_mantenimiento_proveedores_Click"))
            'mMenuP(7).MenuItems(0).MenuItems(1).Name = "scm_proveedores"
        End If

        ''SCM Mantenimiento Productos
        dt.DefaultView.RowFilter = "opcion = 'mci_scm_mantenimiento_productos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Ma&ntenimiento de Productos", AddressOf mci_scm_mantenimiento_productos_Click, Shortcut.CtrlN, "mci_scm_mantenimiento_productos_Click"))
            'mMenuP(7).MenuItems(0).MenuItems(2).Name = "scm_productos"
        End If


        ''SCM Preparar Informacion
        dt.DefaultView.RowFilter = "opcion = 'mci_scm_establecer_pedido'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.EConsigna), "Es&tablecer Pedido", AddressOf mci_scm_establecer_pedido_Click, Shortcut.F12, "mci_scm_establecer_pedido_Click"))
            'mMenuP(7).MenuItems(0).MenuItems(3).Name = "scm_pedido"
        End If

        ''SCM Ver Pedidos
        dt.DefaultView.RowFilter = "opcion = 'mci_scm_ver_pedido'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egRun), "&Ver Pedido", AddressOf mci_scm_ver_pedidos_Click, Shortcut.CtrlV, "mci_scm_ver_pedidos_Click"))
        End If

        ''SCM EjecutarProcesos
        dt.DefaultView.RowFilter = "opcion = 'mci_smc_ejecutar_procesos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(0).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "&Ejecutar Procesos", AddressOf mci_scm_proceso_compras_Click, Shortcut.CtrlE, "mci_scm_proceso_compras_Click"))
        End If


        ''Internaciones Parametros Productos
        dt.DefaultView.RowFilter = "opcion = 'mci_int_parametros'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "&Parametros", AddressOf mci_int_parametros_Click, Shortcut.CtrlP, "mci_int_parametros_Click"))
        End If

        ''Internaciones Productos Bloqueados
        dt.DefaultView.RowFilter = "opcion = 'mci_int_productos_bloqueados'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(7).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eStop), "&Productos Bloqueados", AddressOf mci_int_productosBloqueados_Click, Shortcut.CtrlShiftP, "mci_int_productosBloqueados_Click"))

        ''Internaciones traslado
        dt.DefaultView.RowFilter = "opcion = 'mci_int_traslados'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "&Generar Traslado", AddressOf mci_int_traslado_Click, Shortcut.CtrlG, "mci_int_traslado_Click"))
        End If

        ''Internaciones Listado
        dt.DefaultView.RowFilter = "opcion = 'mci_int_listado_internaciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "&Listado Internaciones", AddressOf mci_int_listado_Click, Shortcut.CtrlL, "mci_int_listado_Click"))
        End If


        ''Internaciones Listado
        dt.DefaultView.RowFilter = "opcion = 'mci_int_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then mMenuP(7).MenuItems(1).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf mci_int_reportes_Click, Shortcut.CtrlShiftR, "mci_int_reportes_Click"))


        'Aduanas

        dt.DefaultView.RowFilter = "opcion = 'adu_dua'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egConfigOk), "Ingreso de &DUA", AddressOf adu_dua_Click, Shortcut.CtrlShift1, "adu_dua_Click"))

        End If

        dt.DefaultView.RowFilter = "opcion = 'adu_di'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eOpen), "Ingreso de &DI", AddressOf adu_di_Click, Shortcut.CtrlShift2, "adu_di_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'adu_reserva'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eCopy), "&Reservas", AddressOf adu_reserva_Click, Shortcut.CtrlShift3, "adu_reserva_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'adu_solicitud_reserva'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egCompuTeclado), "&Solicitud de Reserva", AddressOf adu_solicitud_reserva_Click, Shortcut.CtrlShift4, "adu_solicitud_reserva_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'adu_dr'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), "Ingreso de DR", AddressOf adu_DR_Click, Shortcut.CtrlShift3, "adu_DR_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'adu_reportes'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePrint), "&Reportes", AddressOf adu_reportes_Click, Shortcut.CtrlR, "Reportes"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'pda_procesos_da'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eProperties), "Envio Informacion PDA", AddressOf aduEnvioPDA_Click, Shortcut.Ctrl0, "aduEnvioPDA_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'adu_traslada_dua_hh'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eForward), "Traslado DUA HH", AddressOf adu_trasladoDUA_Click, Shortcut.CtrlShiftD, "adu_trasladoDUA_Click"))
        End If


        ''Inventarios Fisicos
        dt.DefaultView.RowFilter = "opcion = 'adu_inventariofisico'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(2).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eFavorites), "Inventario Fisicos Ciclicos", AddressOf adu_InventarioFisicoDA_Click, Shortcut.CtrlShiftI, "adu_InventarioFisicoDA_Click"))
        End If


        ''Liberar Documentos
        dt.DefaultView.RowFilter = "opcion = 'mci_liberar_documentos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eParent), "Confirmacion OC ", AddressOf mci_liberar_documentos_Click, Shortcut.CtrlShiftF, "mci_liberar_documentos_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mci_soc_fechas_oc'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTools), "Fechas OC ", AddressOf mci_soc_fechas_oc_Click, Shortcut.CtrlShiftC, "mci_soc_fechas_oc_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mci_soc_complemento_divinos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Compra Divinos", AddressOf mci_soc_complemento_divinos_Click, Shortcut.CtrlShiftD, "mci_soc_complemento_divinos_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mci_soc_oc_divinos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eVentanaTiles), "Convertir Factura OC Divinos", AddressOf mci_soc_ocdivinos_Click, Shortcut.CtrlShiftD, "mci_soc_ocdivinos_Click"))
        End If




        dt.DefaultView.RowFilter = "opcion = 'mci_solicitudCreacionItem'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eHistory), "Creacion de Items", AddressOf mco_mantenedorITEM_Click, Shortcut.CtrlShiftM, "mco_mantenedorITEM_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mci_mantenedorPrecios'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eNew), "Mantenedor de Precios", AddressOf mco_mantenedorPrecios_Click, Shortcut.CtrlShiftC, "mco_mantenedorPrecios_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mci_solicitudRequisiciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePreview), "Solicitud de Requisiciones", AddressOf mco_solicitudRequisiciones_Click, Shortcut.CtrlShiftR, "mco_solicitudRequisiciones_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mci_envioRequisiciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRedo), "Envio de Requisiciones a Tesoreria", AddressOf mco_EnvioOrdenesCompra_Click, Shortcut.CtrlShiftC, "mco_EnvioOrdenesCompra_Click"))
        End If


        dt.DefaultView.RowFilter = "opcion = 'mci_recepcionRequisiciones'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.ePreview), "Recepcion de Requisiciones Tesoreria", AddressOf mco_RecepcionOrdenesCompra_Click, Shortcut.CtrlShiftO, "mco_RecepcionOrdenesCompra_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mci_RequisicionesEnvioContabilidad'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRedo), "Envio de Ordenes de Compra a Contabilidad", AddressOf mco_EnvioOrdenesCompraConta_Click, Shortcut.CtrlShiftE, "mco_EnvioOrdenesCompraConta_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mci_RequisicionesRecepcionFactura'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eRedo), "Recepcion Facturas", AddressOf mco_RecepcionFacturas_Requisicion_Click, Shortcut.CtrlShiftR, "mco_RecepcionFacturas_Requisicion_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mci_RequisicionesEnvioRecepcion'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.eReSearch), "Envio Facturas Recepcion", AddressOf mco_Envio_Facturas_Recepcion_Click, Shortcut.CtrlShiftE, "mco_Envio_Facturas_Recepcion_Click"))
        End If

        dt.DefaultView.RowFilter = "opcion = 'mci_RequisicionesProyectos'"
        If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
            mMenuP(7).MenuItems(4).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.egCompuTeclado), "Proyectos", AddressOf mco_requisicionesProyecto_Click, Shortcut.CtrlShiftP, "mco_requisicionesProyecto_Click"))
        End If

        'dt.DefaultView.RowFilter = "opcion = 'mci_soc_documentacion_oc'"
        'If dt.DefaultView.Count > 0 Or cod_tipo_usuario >= 1 Then
        '    mMenuP(7).MenuItems(3).MenuItems.Add(New RichMenuItem(mimg.Bitmaps(eImagenes.EConsigna), "Control de Documentacion", AddressOf mci_soc_documentacion_oc_Click, Shortcut.CtrlShiftD, "Liberar Documentos"))
        'End If


    End Sub

    'Private Sub mnu_Select(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If TypeOf sender Is RichMenuItem Then
    '        Dim s As String
    '        Dim mnu As RichMenuItem = CType(sender, RichMenuItem)
    '        s = mnu.Description
    '        If s = "" Then s = "Seleccionado: " & mnu.Text
    '        'LabelStatus.Text = s
    '    End If
    'End Sub

    'Private Sub mnuEstilos_Select(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ' Quitar las marcas
    '    For Each mnu As RichMenuItem In Me.Menu.MenuItems(2).MenuItems
    '        mnu.Checked = False
    '    Next
    '    ' Marcar el actual
    '    CType(sender, RichMenuItem).Checked = True
    '    ' Comprobar el estilo a usar
    '    Select Case CType(sender, RichMenuItem).Text
    '        Case IconMenuStyle.Office2000.ToString
    '            RichMenuItem.DefaultMenuStyle = IconMenuStyle.Office2003
    '        Case IconMenuStyle.Office2003.ToString
    '            RichMenuItem.DefaultMenuStyle = IconMenuStyle.Office2003
    '        Case IconMenuStyle.Standard.ToString
    '            RichMenuItem.DefaultMenuStyle = IconMenuStyle.Standard
    '        Case IconMenuStyle.VSNet.ToString
    '            RichMenuItem.DefaultMenuStyle = IconMenuStyle.VSNet
    '    End Select
    '    ' Asignar el nuevo estilo a los menñs
    '    Dim estilo As IconMenuStyle = RichMenuItem.DefaultMenuStyle
    '    For Each mnu As RichMenuItem In Me.Menu.MenuItems
    '        mnu.MenuStyle = estilo
    '        For Each mnu1 As RichMenuItem In mnu.MenuItems
    '            mnu1.MenuStyle = estilo
    '        Next
    '    Next
    'End Sub

    Private Sub mar_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_salir.Click

        Me.Close()
    End Sub

    Private Sub mfi_consignaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_consignaciones.Click

        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oForm As New frm_consignaciones
        oForm.ShowDialog(Me)
        oForm = Nothing
    End Sub

    Private Sub mco_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_inventario.Click
        Dim oForm As New frm_InventarioCliente
        oForm.ShowDialog(Me)
        oForm = Nothing
    End Sub

    Private Sub mti_usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_usuario.Click


        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception

        End Try
        Dim oForm As New frm_usuario
        oForm.ShowDialog(Me)
        oForm = Nothing
    End Sub

    Private Sub mfi_SacarFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_SacarFacturas.Click
        'Dim Oform As New frm_quitar_facturas_guia
        'Oform.ShowDialog(Me)
        'Oform = Nothing

        'Dim oform As New frm_liquidacionPiloto_Finanzas
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRecepcionControlTransporte
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mar_cambiar_empresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cambiar_empresa.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_cambiar_empresa
        oform.ShowDialog(Me)
        oform = Nothing
        Me.Text = "Menu Principal :::. " & gs_empresa & " - " & mdfo_gs_empresa & " .::: "
        Dim lblHArr() As Control = Me.Controls.Find("lblEmpresaHeader", True)
        If lblHArr.Length > 0 Then
            DirectCast(lblHArr(0), Label).Text = If(String.IsNullOrEmpty(mdfo_gs_empresa), gs_empresa, mdfo_gs_empresa & "  (" & gs_empresa & ")")
        End If
        Crear_menu()
        Crear_tiles()
        Crear_acceso_rapido()
        'Activar_Logo()
    End Sub

    Private Sub mar_cambiarclave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cambiarclave.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oForm As New frm_cambiar_clave
        oForm.ShowDialog(Me)
        oForm = Nothing
    End Sub

    Private Sub mti_diseñador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_diseñador.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_diseñador_reportes
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub Activar_Logo()
        Dim odt As DataTable

        Dim ls_path As String = String.Empty
        Try



            Me.pb_logo.Visible = True
            odt = obtener_parametros_sistema()

            If odt.Rows.Count > 0 Then
                ls_path = odt.Rows(0).Item("path_logos").ToString
            End If

            'pb_it.Image = Image.FromFile(ls_path & "logoUmbright.png")
            Me.pb_logo.Image = Image.FromFile(ls_path & gs_empresa.Trim & ".png")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.pb_logo.Visible = False

        Finally
        End Try

    End Sub

    Private Sub Activar_LogoIT()
        Dim odt As DataTable

        Dim ls_path As String = String.Empty
        Try



            Me.pb_logo.Visible = True
            odt = obtener_parametros_sistema()

            If odt.Rows.Count > 0 Then
                ls_path = odt.Rows(0).Item("path_logos").ToString
            End If

            'pb_it.Image = Image.FromFile(ls_path & "logoUmbright.png")
            'Me.pb_logo.Image = Image.FromFile(ls_path & gs_empresa.Trim & ".png")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'Me.pb_logo.Visible = False

        Finally
        End Try

    End Sub


    Private Sub mco_dma_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_dma_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 31, gs_empresa)
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mti_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 11, gs_empresa)
        oform.Text = oform.Text & " IT"
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mlo_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 12, gs_empresa)
        oform.Text = oform.Text & " Logistica"
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mfi_cr_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cr_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 15, gs_empresa)
        oform.Text = oform.Text & " Creditos"
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mfi_fc_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_fc_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 10, gs_empresa)
        oform.Text = oform.Text & " Facturacion"
        oform.ShowDialog(Me)

        oform = Nothing
    End Sub

    Private Sub mfi_co_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_co_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 16, gs_empresa)
        oform.Text = oform.Text & " Contabilidad"
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mar_flexline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_flexline.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim proceso As Process = New Process
        'Dim procesoFlex As Process() = Process.GetProcesses() 'Process.GetProcessesByName("panel.exe")


        'For icount As Integer = 0 To procesoFlex.Length - 1
        '    Try


        '        If procesoFlex(icount).MainModule.ModuleName.ToString.ToLower = "flex32.exe" Then
        '            MessageBox.Show("FlexLine-ERP Licencias No Disponibles", "Precaucion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Exit Sub

        '        End If
        '    Catch ex As Exception

        '    End Try
        'Next



        Dim dt As DataTable
        Dim ls_path As String

        Try
            dt = obtener_parametros_sistema()
            ls_path = dt.Rows(0).Item("path_erp").ToString

            'Ejecutamos el proceso
            'proceso.StartInfo.FileName = "panel.exe"
            proceso.StartInfo.FileName = "PanelShellUI.exe"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = ls_path

            proceso.Start()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            proceso = Nothing
        End Try
    End Sub

    Private Sub mar_Vnet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_Vnet.Click
        'Dim proceso As Process = New Process

        Dim dt As DataTable
        Dim ls_path As String

        Try
            dt = obtener_parametros_sistema()
            ls_path = dt.Rows(0).Item("path_vnet").ToString

            ''Ejecutara el presupuestos en lugar de vinet
            Process.Start(ls_path & "Presupuestos.exe")
            'proceso = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mci_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 18, gs_empresa)
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mpr_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpr_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 17, gs_empresa)
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    'Private Sub mar_reverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_reverse.Click
    '    Dim proceso As Process = New Process

    '    Dim dt As DataTable
    '    Dim ls_path As String

    '    Try
    '        dt = obtener_parametros_sistema()
    '        ls_path = dt.Rows(0).Item("path_reverse").ToString
    '        'Ejecutamos el proceso
    '        proceso.Start(ls_path & "Reverse1L1.exe")
    '        proceso = Nothing
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Private Sub mfi_cr_pedidos_pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cr_pedidos_pendientes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oForm As New frm_pedidos_pendientes

        oForm.ShowDialog(Me)
        oForm = Nothing

    End Sub

    Private Sub mar_crm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_crm.Click


        Dim dt As DataTable
        Dim ls_path As String

        Try
            Dim proceso As Process = New Process
            dt = obtener_parametros_sistema()
            ls_path = dt.Rows(0).Item("path_crm").ToString

            'Ejecutamos el proceso
            proceso.StartInfo.FileName = "tccrm.exe"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = ls_path

            proceso.Start()
            proceso = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tmk_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmk_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 22, gs_empresa)
        oform.Text = oform.Text & " TeleMarketing"
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mar_cub_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_inventario.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Inventario")
    End Sub

    Private Sub mar_cub_cartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_cartera.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("CARTERA")
    End Sub

    Private Sub mar_cub_topventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_topventas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("TopVentas")
    End Sub

    Private Sub mar_cub_ventasxperiodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_ventasxperiodo.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Venta_x_Periodo")
    End Sub

    Private Sub mar_cub_topinv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_topinv.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Cubo_JSA_Compras")
    End Sub

    Private Sub mar_cub_tops_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_tops.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Tops")
    End Sub

    Private Sub mar_cub_ventasxrangofecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_ventasxrangofecha.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Ventas_x_rango_fecha")
    End Sub

    Private Sub mar_cub_controltransporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_controltransporte.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Control_transporte_Nivel_Servicio")
    End Sub

    Private Sub Ejecutar_Cubo(ByVal nombre_cubo As String)
        Dim dt As DataTable
        Dim ls_path As String
        'El Path o la ubicacion del archivo
        'Dim mExcel As New Excel.Application
        'Try
        Dim clsgen As New ClasesGenerales.General
        dt = obtener_parametros_sistema()
        ls_path = dt.Rows(0).Item("path_olap").ToString

        '    'mExcel.Visible = True
        '    'mExcel.Workbooks.Open(ls_path & nombre_cubo & ".xls", False, True, , , , , , , , , , , , True)
        'Catch ex As Exception
        Try
            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = nombre_cubo & ".xls"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = ls_path

            proceso.Start()
            proceso = Nothing

        Catch ex2 As Exception
            'MessageBox.Show("No Se Pueden Visualizar Los Cubos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clsgen.Escribir_Log(ex2.Message)
            clsgen.Escribir_Log(ex2.ToString)
            If ex2.Message.Contains("find") Or ex2.Message.Contains("encontrar") Then
                EjecutarcuboX(nombre_cubo)
            End If
        Finally
            clsgen = Nothing
        End Try

        'Finally
        '    ' mExcel = Nothing
        'End Try
    End Sub


    Private Sub EjecutarcuboX(ByVal nombre_cubo As String)
        Dim dt As DataTable
        Dim ls_path As String
        Dim clsgen As New ClasesGenerales.General
        'El Path o la ubicacion del archivo
        'Dim mExcel As New Excel.Application
        'Try
        dt = obtener_parametros_sistema()
        ls_path = dt.Rows(0).Item("path_olap").ToString

        '    'mExcel.Visible = True
        '    'mExcel.Workbooks.Open(ls_path & nombre_cubo & ".xls", False, True, , , , , , , , , , , , True)
        'Catch ex As Exception
        Try
            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = nombre_cubo & ".xlsx"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = ls_path

            proceso.Start()
            proceso = Nothing

        Catch ex2 As Exception
            'MessageBox.Show("No Se Pueden Visualizar Los Cubos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clsgen.Escribir_Log(ex2.Message)
            clsgen.Escribir_Log(ex2.ToString)
            If ex2.Message.Contains("find") Or ex2.Message.Contains("encontrar") Then
                EjecutarcuboM(nombre_cubo)
            End If
        Finally
            clsgen = Nothing
        End Try

        'Finally
        '    ' mExcel = Nothing
        'End Try
    End Sub


    Private Sub EjecutarcuboM(ByVal nombre_cubo As String)
        Dim dt As DataTable
        Dim ls_path As String
        'El Path o la ubicacion del archivo
        'Dim mExcel As New Excel.Application
        Dim clsgen As New ClasesGenerales.General
        'Try
        dt = obtener_parametros_sistema()
        ls_path = dt.Rows(0).Item("path_olap").ToString

        '    'mExcel.Visible = True
        '    'mExcel.Workbooks.Open(ls_path & nombre_cubo & ".xls", False, True, , , , , , , , , , , , True)
        'Catch ex As Exception
        Try
            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = nombre_cubo & ".xlsm"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = ls_path

            proceso.Start()
            proceso = Nothing

        Catch ex2 As Exception
            'MessageBox.Show("No Se Pueden Visualizar Los Cubos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clsgen.Escribir_Log(ex2.Message)
            clsgen.Escribir_Log(ex2.ToString)

        Finally
            clsgen = Nothing
        End Try


        'Finally
        '    ' mExcel = Nothing
        'End Try
    End Sub

    Private Sub Ejecutar_Tableau(ByVal psNombreDS As String)
        Dim dt As DataTable
        Dim ls_path As String
        'El Path o la ubicacion del archivo
        'Dim mExcel As New Excel.Application
        'Try
        dt = obtener_parametros_sistema()
        ls_path = dt.Rows(0).Item("path_olap").ToString
        Dim clsgen As New ClasesGenerales.General


        '    'mExcel.Visible = True
        '    'mExcel.Workbooks.Open(ls_path & nombre_cubo & ".xls", False, True, , , , , , , , , , , , True)
        'Catch ex As Exception
        Me.Cursor = Cursors.WaitCursor
        Try

            Try
                If Not Directory.Exists("c:\aplicaciones\tableau") Then
                    Directory.CreateDirectory("c:\aplicaciones\Tableau")
                End If

            Catch ex As Exception

            End Try
            clsgen.Copiar_Archivo(ls_path & "tableau\" & psNombreDS & ".twbx", "c:\aplicaciones\tableau\" & psNombreDS & ".twbx", True)
            Dim proceso As Process = New Process


            'Ejecutamos el proceso
            proceso.StartInfo.FileName = psNombreDS & ".twbx"
            'El Path o la ubicacion del archivo
            'proceso.StartInfo.WorkingDirectory = ls_path & "tableau\"
            proceso.StartInfo.WorkingDirectory = "c:\aplicaciones\tableau\"

            proceso.Start()
            proceso = Nothing

        Catch ex2 As Exception
            '  MessageBox.Show("No Se Pueden Visualizar Los Cubos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

        'Finally
        '    ' mExcel = Nothing
        'End Try
    End Sub


    Private Sub mco_cdc_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_cdc_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim clsgen As New ClasesGenerales.General
        Try

            clsgen.Escribir_Log("Inicializando formulario")
            Dim oform As New frm_reportes
            clsgen.Escribir_Log("Cargando Reportes")

            oform.Cargar_Reportes(gs_usuario, 8, gs_empresa)
            clsgen.Escribir_Log("Cargando Formulario")
            oform.ShowDialog()
            clsgen.Escribir_Log("Cerrando Formulario")
            oform = Nothing

        Catch ex As Exception
            clsgen.Escribir_Log(ex.Message)
            clsgen.Escribir_Log(ex.ToString)
        Finally
            clsgen = Nothing
        End Try

    End Sub

    Private Sub mco_ala_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_ala_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 32, gs_empresa)

        oform.ShowDialog()
        oform = Nothing
    End Sub

    'Private Function version_nueva_sistema() As Boolean
    '    Dim ls_version_servidor, ls_version_cliente As String
    '    Dim lbreturn As Boolean = False

    '    Try
    '        ls_version_servidor = System.Configuration.ConfigurationSettings.AppSettings("ejecutable_servidor")
    '        ls_version_cliente = System.Configuration.ConfigurationSettings.AppSettings("ejecutable_cliente")


    '        Dim FileProperties As FileVersionInfo = _
    '        FileVersionInfo.GetVersionInfo(ls_version_servidor)

    '        ls_version_servidor = FileProperties.FileVersion

    '        FileProperties = FileVersionInfo.GetVersionInfo(ls_version_cliente)
    '        ls_version_cliente = FileProperties.FileVersion

    '        If ls_version_cliente <> ls_version_servidor Then
    '            'Copiar Los Nuevos Archivos
    '            MessageBox.Show("Existe Una Nueva Version del Sistema, " & Chr(13) & _
    '                            "A Continuacion se Actualizara ", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '            lbreturn = True
    '        End If

    '    Catch ex As Exception
    '    End Try

    '    Return lbreturn
    'End Function

    Private Sub mfi_liberar_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_liberar_facturas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_liberar_factura_parcial

        oform.ShowDialog()
        oform = Nothing
    End Sub

    Private Sub mci_odc_edifact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_odc_edifact.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_edifact
        oform.ShowDialog()
        oform = Nothing
    End Sub

    Private Sub mar_cub_ventas24meses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_ventas24meses.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Ventas_24_meses")
    End Sub

    Private Sub mti_conversiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_conversiones.Click
        Dim oform As New frm_conversion
        oform.ShowDialog()
        oform = Nothing
    End Sub

    Private Function obtener_parametros_sistema() As DataTable

        Dim odt As New DataTable
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim ls_sql As String
        ls_sql = "pa_sel_um_gen_parametros_sistema"
        Try
            otrans.open()
            odt = otrans.Obtiene(ls_sql)
            otrans.close()

        Catch ex As Exception
        Finally
            otrans = Nothing

        End Try
        Return odt
    End Function

    Private Sub mci_reportes_adicionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_reportes_adicionales.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(35, "Compras/Importaciones Adicionales")
    End Sub

    Private Sub mlo_reportes_picking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_reportes_picking.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(36, "Logistica Picking")
    End Sub

    Private Sub mti_insumos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_insumos.Click
        Dim oform As New frm_mantenimiento_activos_insumos
        oform.insumos = True
        oform.Show()
    End Sub

    Private Sub mer_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(38, "Mercadeo")
    End Sub

    Private Sub generar_reporte(ByVal _popcion As Integer, ByVal _pnombre As String)
        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, _popcion, gs_empresa)
        oform.Text = "::. " & oform.Text & " " & _pnombre & " .::"
        oform.ShowDialog()
        oform.Dispose()
    End Sub

    Private Sub mti_plasma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_plasma.Click
        'Dim oform As New frm_actualizacion_plasma
        'oform.Show()
    End Sub

    Private Sub mrh_pq_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_pq_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(9, " Recursos Humanos Primera Quincena")
    End Sub

    Private Sub mrh_sq_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_sq_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(39, "Recursos Humanos Primera Quincena")
    End Sub

    Private Sub mrh_ge_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_ge_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(40, " Recursos Humanos Generales")
    End Sub

    Private Sub mrh_ll_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_ll_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(41, " Recursos Humanos Libros Legales")
    End Sub

    Private Sub mlo_impresion_picking_manual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_impresion_picking_manual.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Try
            Dim clsgen As New ClasesGenerales.General
            If clsgen.Obtener_XMLConfig("ubicacion", False).ToLower.StartsWith("sv") Then
                'Dim oform As New frm_listado_opl
                'oform.pb_manual = True
                'oform.ShowDialog()
                'oform.Dispose()

            Else
                Dim oform As New frm_listado_picking
                oform.pb_manual = True
                oform.ShowDialog()
                oform.Dispose()

            End If
            clsgen = Nothing
        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Sub mlo_control_transporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_control_transporte.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_control_transporte
        oform.ShowDialog()
        oform.Dispose()
    End Sub

    Private Sub mti_jsa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_jsa.Click
        'generar_reporte(45, " Junta Semanal de Avance")
        'Dim oform As New frm_junta_semanal_avance
        'oform.Show()
    End Sub

    Private Sub mar_informacion_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_informacion_productos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_producto
        oform.ShowDialog()
        oform.Dispose()
    End Sub

    Private Sub mco_trancking_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_trancking_pedidos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_tracking_pedidos
        oform.ShowDialog()
        oform.Dispose()
    End Sub

    Private Sub mar_telecomunicaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_telecomunicaciones.Click
        Dim proceso As Process = New Process

        Dim dt As DataTable
        Dim ls_path As String

        Try
            dt = obtener_parametros_sistema()
            ls_path = dt.Rows(0).Item("path_telecomunicaciones").ToString

            'Ejecutamos el proceso
            proceso.StartInfo.FileName = "telecomunicaciones.exe"
            'El Path o la ubicacion del archivo
            proceso.StartInfo.WorkingDirectory = ls_path ' "\\DATAServer\FlexlineServidor\FlexlineERP\Comunes\"

            proceso.Start()
            proceso = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mfi_inicializar_periodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_inicializar_periodo.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_inicializar_periodo
        oform.ShowDialog()
        oform.Dispose()
    End Sub

    Private Sub mfi_if_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_if_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(52, " Informes Financieros")
    End Sub

    Private Sub mco_consulta_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_consulta_clientes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim frm_busqueda As New frm_busqueda_general

        frm_busqueda.Text = "Busqueda de Clientes .::"
        frm_busqueda.nombre_vista = "v_um_ctacte_busqueda"
        frm_busqueda.parametros_fijos = " empresa = '" & gs_empresa & "' and "
        'frm_busqueda.ps_parametros_fijos = "'" & Me.cmb_empresa.Text.Trim & "',"
        '        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo,nombrecorto"
        frm_busqueda.parametros = "razonsocial,ctacte,giro,ejecutivo,nombrecorto,clasificacion,segmento,motivoconsumo"

        frm_busqueda.lista_campos = "CtaCte, CodLegal,RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente, direccion, telefono, contacto, ListaPrecio,nombreCorto,subcanal,rutalogistica,clasificacion,segmento,motivoconsumo,idctacte "
        'frm_busqueda.lista_campos = "CtaCte, CodLegal,RazonSocial,Giro,Tipo,Ejecutivo,CondPago,Vigencia_Cliente, direccion, telefono, contacto, ListaPrecio,nombreCorto "
        'frm_busqueda.procedimiento_almacenado = "pa_sel_um_cliente_busqueda"
        frm_busqueda.dg_buscar.ReadOnly = True
        frm_busqueda.Size = New System.Drawing.Size(812, 520)
        'frm_busqueda.dg_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        frm_busqueda.btn_ncorto.Visible = tiene_permisos("mco_cambiarNombreCorto")
        frm_busqueda.btn_rutaLogistica.Visible = tiene_permisos("mco_asignarRutaLogistica")
        frm_busqueda.Show()
    End Sub

    Private Sub mfi_fc_pedidos_facturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_fc_pedidos_facturar.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Try
            Dim oform As New frm_pedidos_facturar
            oform.ShowDialog()
            oform.Dispose()
            oform = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mci_liberar_documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_liberar_documentos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_OCconfirmacion
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_liberar_ppto_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_liberar_ppto_cliente.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_liberar_ppto_cliente
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_scm_mantenimiento_proveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_scm_mantenimiento_proveedores.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_scm_mantenimiento_proveedores
        oform.Show()
        'oform.Dispose()
        'oform = Nothing
    End Sub



    Private Sub mci_scm_parametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_scm_parametros.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_scm_parametros_generales
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_scm_mantenimiento_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_scm_mantenimiento_productos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_scm_mantenimiento_productos
        oform.Show()
        'oform.Dispose()
        'oform = Nothing
    End Sub

    Private Sub mci_scm_establecer_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_scm_establecer_pedido.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_scm_pedido
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_control_fallas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_control_fallas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        'Dim oform As New frm_control_fallas
        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing
    End Sub

    Private Sub mci_int_parametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_int_parametros.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_int_parametros
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_int_traslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_int_traslado.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_int_pedido
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cr_recepcion_Control_transporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cr_recepcion_Control_transporte.Click
        'Try
        '    guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        'Catch ex As Exception
        'End Try

        'Dim oform As New frm_recepcion_control_transporte

        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing
    End Sub

    Private Sub mlo_asociar_es_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_asociar_es_inventario.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_asociar_ES_documentos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_scn_precios_ofertas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_scn_precios_ofertas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scn_ofertas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cr_snc_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cr_snc_clientes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scn_clientes
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_int_listado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_int_listado.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_int_ListadoInternaciones
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_scn_Movimientos_Inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_scn_Movimientos_Inventario.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scn_movimiento_inventarios
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_tec_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_tec_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(60, " Reportes")
    End Sub

    Private Sub mar_cub_24m_tiendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_24m_tiendas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Ventas_24_Meses_Por_Tienda")
    End Sub

    Private Sub mlo_maq_monitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_maq_monitor.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_maq_monitor
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_scm_ver_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_scm_ver_pedidos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scm_ver_pedidos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_scn_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_scn_productos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scn_ofertas
        oform.lproductos = True
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_activos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_activos.Click
        'Dim oform As New frm_asignacion_equipo
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_mantenimiento_activos_insumos
        oform.insumos = False
        oform.Show()

    End Sub

    Private Sub mco_cdc_liberar_pedidos_MR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_cdc_liberar_pedidos_MR.Click
        'Dim oform As New frm_listado_pedidos_MR
        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing
    End Sub

    Private Sub mer_memos_promocionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_memos_promocionales.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_memos_promocionales
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_back_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_back_order.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_backorder
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mar_cub_Ventas_Vendedor_Vertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_Ventas_Vendedor_Vertical.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Cubo_Ventas_Vendedor_Vertical")
    End Sub

    Private Sub mfi_enviar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_enviar_factura.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim Oform As New Frm_edifact
        Oform.lenvio_factura = True
        Oform.ShowDialog()
        Oform.Dispose()
        Oform = Nothing
    End Sub

    Private Sub mco_liberar_ppto_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_liberar_ppto_producto.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim Oform As New frm_liberar_ppto_cliente
        Oform.liberar_Producto = True
        Oform.ShowDialog()
        Oform.Dispose()
        Oform = Nothing
    End Sub

    Private Sub mco_cdc_reportes_mayoristas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_cdc_reportes_mayoristas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(88, " Mayoristas")
    End Sub

    Private Sub mlo_pedidos_posfechados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_pedidos_posfechados.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_pedidos_facturar
        oform.lpedidos_posfechados = True
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mar_cub_ventas_x_dia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_ventas_x_dia.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Ventas_X_Dia")
    End Sub



    Private Sub mco_cdc_mensajeria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_cdc_mensajeria.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_mensajeria_mr
        oform.Show()
    End Sub

    Private Sub mti_eface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_eface.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_edifact
        oform.leface = True
        oform.Show()
    End Sub

    Private Sub mer_anular_memos_promocionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_anular_memos_promocionales.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_pedidos_facturar
        oform.lpedidos_posfechados = False
        oform.lanular_memos = True
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mer_mem_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_mem_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(107, " Memos Promocionales")
    End Sub

    Private Sub mco_cdc_productos_mr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_cdc_productos_mr.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scn_ofertas
        oform.lproductosmr = True
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_diu_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_diu_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(112, " DiUva")
    End Sub

    Private Sub mco_vin_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_vin_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(113, " Vinoteca")
    End Sub

    'Private Sub mco_enviar_picking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_enviar_picking.Click
    '    Dim oform As New frm_enviar_factura_picking
    '    oform.Show()
    'End Sub

    Private Sub mer_mem_revision_OC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_mem_revision_OC.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_listado_pedidos_MR
        oform.tipo_listado = 2
        oform.Show()
    End Sub

    Private Sub mer_mem_solicitud_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_mem_solicitud_productos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_solicitud_productos
        oform.Show()
    End Sub

    Private Sub mer_cambio_precio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_cambio_precio.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_actualiza_precios_compras
        oform.Show()
    End Sub



    Private Sub mar_control_tarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_control_tarea.Click

        'Dim oform As New frm_ventasSugerido
        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing

        'Dim ls_sql As String
        'Dim nombreHost As String = System.Net.Dns.GetHostName
        'Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
        'Dim Direcciones As IPAddress() = hostInfo.AddressList


        'Dim otrans As New Transaccional.Conexion_mysql("onBase")
        'otrans.open()

        'ls_sql = "call pa_ins_um_seg_usuario_sistema ('" & Direcciones(0).ToString & "', '" & gs_empresa & "', '" & gs_usuario & "' , 'control_tarea')"
        'otrans.Ingresa(ls_sql)

        'otrans.close()
        'otrans = Nothing



        'Dim proceso As Process = New Process

        'Try
        '    'Ejecutamos el proceso
        '    proceso.StartInfo.FileName = "Control de Tareas.exe"
        '    'El Path o la ubicacion del archivo
        '    proceso.StartInfo.WorkingDirectory = "C:\Aplicaciones\Control de Tareas"
        '    proceso.Start()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    proceso = Nothing
        'End Try
    End Sub

    'Private Sub mrh_cancela_prestamo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_cancela_prestamo.Click
    '    Try
    '        guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
    '    Catch ex As Exception
    '    End Try

    '    Dim oForm As New frm_cancelacion_prestamo
    '    oForm.ShowDialog(Me)
    '    oForm = Nothing
    'End Sub


    Private Sub mar_cub_presupuesto_comercial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_presupuesto_comercial.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Cubo_De_Presupuesto_Comercial")
    End Sub

    Private Sub m_archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_archivo.Click

    End Sub

    Private Sub mpr_London_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpr_London.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reportes
        oform.Cargar_Reportes(gs_usuario, 142, gs_empresa)
        oform.ShowDialog()
        oform = Nothing
    End Sub

    Private Sub mrh_solicitud_vacaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_solicitud_vacaciones.Click
        'Dim oform As New frm_solicitud_vacaciones
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_control_vacaciones
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mfi_ejecuta_sp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_ejecuta_sp.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_ejecuta_sp
        If cod_tipo_usuario >= 1 Then oform.administrador = True Else oform.administrador = False

        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mar_cubo_ventas_por_periodo_complemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cubo_ventas_por_periodo_complemento.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Ventas_x_Periodo_Complemento")
    End Sub

    Private Sub adu_dua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_dua.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_dua
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub adu_di_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_di.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_di
        oform.ShowDialog(Me)
        oform = Nothing

    End Sub

    Private Sub adu_reserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_reserva.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_reserva
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub adu_solicitud_reserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_solicitud_reserva.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_da_SolicitudReserva
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub adu_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(165, "Aduana")
    End Sub

    Private Sub mar_cub_listaPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_listaPrecios.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Cubo_Lista_De_Precios")
    End Sub

    Private Sub mco_admon_consignaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_admon_consignaciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_consignaciones_saldos
        oform.ShowDialog(Me)
        oform = Nothing
    End Sub

    Private Sub mci_scm_establecer_coberturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_scm_establecer_coberturas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scm_coberturas
        oform.Show()
    End Sub

    Private Sub mti_insumos_movimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_insumos_movimientos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_movimientos_insumos
        oform.Show()
    End Sub

    Private Sub mfi_sincronizacion_informacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_sincronizacion_informacion.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_sincronizacion_informacion
        oform.Show()
    End Sub

    Private Sub mer_productos_derivados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_productos_derivados.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_productos_derivados
        oform.Show()
    End Sub

    Private Sub menuSubirPptoComercial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSubirPptoComercial.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_carga_presupuesto_comercial
        oform.Show()
    End Sub

    Private Sub mnu_arch_cambiar_periodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_arch_cambiar_periodo.Click
        Dim oform As New frm_cambiarperiodo
        oform.Show()
    End Sub

    Private Sub mco_presupuestoGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_presupuestoGeneral.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_ppto_general
        oform.Show()
    End Sub

    Private Sub mer_cargarPPTOGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_cargarPPTOGeneral.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_carga_presupuesto_general
        oform.Show()
    End Sub

    Private Sub merForecast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles merForecast.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmForecast
        oform.Show()
    End Sub

    Private Sub mfiinventariosFisicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfiinventariosFisicos.Click
        'Dim oform As New frm_inventariosCiclicos
        'oform.Show()
    End Sub

    Private Sub mci_soc_fechas_oc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_soc_fechas_oc.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_OCfechas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_cuentasContableProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_cuentasContableProductos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_cuentas_productos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub




    Private Sub mco_mob_asignacion_rutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_mob_asignacion_rutas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmMob_ClienteRuta
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

        'Dim oform1 As New frm_nuevoMenu
        'oform1.Show()

    End Sub

    Private Sub mrh_actualizacion_prestamos_fecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_actualizacion_prestamos_fecha.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_Fecha_Prestamos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_movimientos_activos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_movimientos_activos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_movimientos_activos
        oform.Insumos = False
        oform.Show()
    End Sub

    Private Sub mfiListaCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfiListaCosto.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Carga_Precios_Costo
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mfiCambiarDai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfiCambiarDai.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Cambio_Dai
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mfi_generarLotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_generarLotes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Pagos_Electronicos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_Incidencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_Incidencias.Click
        'Dim oform As New frm_HDIncidencias
        'Dim oform2 As New frm_seguimiento_pedidos
        'oform.Show()
    End Sub

    Private Sub mco_ReportesCorporativos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_ReportesCorporativos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(188, "Comercial Coporativo")
    End Sub

    Private Sub mpr_ReportesCorporativos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpr_reportesCorporativos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(189, "Presidencia Coporativo")
    End Sub

    Private Sub mci_scm_proceso_compras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_scm_proceso_compras.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_SCM_Procesos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mar_cub_ventasCoporativas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_cub_ventasCoporativas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Cubo_Corporativo")
    End Sub

    Private Sub mrh_ControlAccesos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_ControlAccesos.Click
        'Try
        '    guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        'Catch ex As Exception
        'End Try

        'Dim oform As New Frm_Control_Accesos
        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing
    End Sub

    'Private Sub mci_soc_documentacion_oc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_soc_documentacion_oc.Click
    '    Dim oform As New frm_OCcontrol_documento
    '    oform.ShowDialog()
    '    oform.Dispose()
    '    oform = Nothing
    'End Sub

    Private Sub mci_actualizacion_oc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_actualizacion_oc.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_actualizacion_oc
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_tracking_orden_compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_tracking_orden_compra.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_OChistorial
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mar_ol_venta_perdida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_ol_venta_perdida.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Ejecutar_Cubo("Cubo_Venta_Perdida")
    End Sub

    Private Sub mlo_liquidacionGastos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_liquidacionGastos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        'Dim oform As New frm_viaticos
        '(c) 20231115
        Dim oform As New frm_liquidacion_gastos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_controlRegistrosSanitarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_controlRegistrosSanitarios.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_registros_sanitarios
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mar_ol_cuboDevoluciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_ol_cuboDevoluciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Me.Ejecutar_Cubo("Devoluciones_Por_Motivo")
    End Sub

    Private Sub mar_lo_stockDiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_lo_stockDiario.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Me.Ejecutar_Cubo("Cubo_StockDiario2")
    End Sub

    Private Sub mar_ol_nivelServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_ol_nivelServicio.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Me.Ejecutar_Cubo("Cubo_Nivel_De_Servicio_Corp")
    End Sub

    Private Sub mar_ol_productosExistencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mar_ol_productosExistencias.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Me.Ejecutar_Cubo("Cubo_Productos_Precios_Existencias")
    End Sub

    Private Sub mlo_salidasEnPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_salidasEnPedidos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform2 As New frm_canastas2
        oform2.esMovimiento = True
        oform2.ShowDialog()
        oform2.Dispose()
        oform2 = Nothing
    End Sub

    Private Sub mco_OdCPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_OdCPedido.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform2 As New frm_canastas2
        oform2.esMovimiento = False
        oform2.ShowDialog()
        oform2.Dispose()
        oform2 = Nothing
    End Sub

    Private Sub aduEnvioPDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aduEnvioPDA.Click
        'Dim oform As New frm_daEnvioInformacion
        'oform.Show()
    End Sub

    Private Sub mco_MaxMinimosVinoteca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_MaxMinimosVinoteca.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_vin_Inventario_MinimoMaximo
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_PedidoVinoteca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_PedidoVinoteca.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_vin_Pedido_automatico
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_etiq_materiales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_etiq_materiales.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_maq_etiquetas_materiales
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_etiq_OProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_etiq_OProduccion.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_maq_orden_etiquetas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_etiq_ProcesoProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_etiq_ProcesoProduccion.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_maq_etiquetas_produccion
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mar_ol_cubogenrico1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mar_ol_cubogenerico1.Click, mar_ol_cubogenerico2.Click, mar_ol_cubogenerico3.Click, mar_ol_cubogenerico4.Click, mar_ol_cubogenerico5.Click, mar_ol_cubogenerico6.Click, mar_ol_cubogenerico7.Click, mar_ol_cubogenerico8.Click, mar_ol_cubogenerico9.Click, mar_ol_cubogenerico10.Click, mar_ol_cubogenerico11.Click, mar_ol_cubogenerico12.Click, mar_ol_cubogenerico13.Click, mar_ol_cubogenerico14.Click, mar_ol_cubogenerico15.Click
        Me.Ejecutar_Cubo(sender.ToString().Split(",")(2).Split(":")(1).Trim)
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

    End Sub



    Private Sub mci_int_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_int_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(221, "Internaciones")
    End Sub

    Private Sub mlo_inventarios_ciclicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_inventarios_ciclicos.Click
        'Dim oform As New frm_inventariosCiclicos
        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing
    End Sub

    Private Sub mci_int_productosBloqueados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_int_productosBloqueados.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_int_producto_bloqueado
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_trackingInternaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mci_trackingInternaciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_int_trackingInternaciones
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_liquidacionPiloto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_liquidacionPiloto.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_liquidacionPiloto
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_co_cface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_co_cface.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_guate_factura
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mcoEdifact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mcoEdifact.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_PedidosEdiFact
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_ImpresionOrdenesEDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_ImpresionOrdenesEDI.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_listadoOrdenesTransportes
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub


    Private Sub mco_devoluciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_devoluciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Devoluciones
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mcoFacturacionCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mcoFacturacionCosto.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_facturacion_autoconsumo
        oform.psTipo = sender.ToString.Split(":")(2)
        'oform.Text = ":: " & sender.ToString.Split(":")(2) & " ::"
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

        'Me.Ejecutar_Cubo(sender.ToString().Split(",")(2).Split(":")(1).Trim)

    End Sub

    Private Sub mrh_evaluacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrh_evaluacion.Click
        'Dim oform As New Frm_Evaluacion
        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing

    End Sub


    Private Sub adu_DR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_DR.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_dr
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_cambioHorario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_cambioHorario.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_Horarios_Extraordinarios
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub merEvualuacionDIAGEO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles merEvualuacionDIAGEO.Click
        'Dim oform As New Frm_EvaluacionD
        'oform.ShowDialog()
        'oform.Dispose()
        'oform = Nothing
    End Sub


    Private Sub mlo_ReporteHorario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_ReporteHorario.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_HorasExtras_CD
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub adu_trasladoDUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_trasladoDUA.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_dua_HH
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_finalizacion_picking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_finalizacion_picking.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_FinPicking
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_devolucionesrechazos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_devolucionesrechazos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_RechazosPendientesAprobacion
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_ComprasInterEmpresas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_ComprasInterEmpresas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_convierte_ordencompra
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_div_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_div_pedido.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_pedidosElSalvador
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_series.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_ControlSeriesLotes
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mer_MantenedorPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mer_MantenedorPrecios.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmMantenedorPrecios
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_solicitudRequisiciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_solicitudRequisiciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisiciones
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub



    Private Sub mco_mantenedorITEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_mantenedorITEM.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisicionesProducto
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_mantenedorPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_mantenedorPrecios.Click

    End Sub

    Private Sub mco_pedidos_telemarketing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_pedidos_telemarketing.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmTrackingTrasladosVNT
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_EnvioOrdenesCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_EnvioOrdenesCompra.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisicionesEnvio
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_RecepcionOrdenesCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_RecepcionOrdenesCompra.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisicionRecepcionCreditos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_ws_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_ws_productos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_ws_productos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_EnvioOrdenesCompraConta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_EnvioOrdenesCompraConta.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisicionesEnvioTesoreria
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_ws_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_ws_clientes.Click

        Dim oform As New frm_ws_cliente
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_ws_envios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_ws_envios.Click
        Dim oform As New frm_ws_envio
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub adu_InventarioFisicoDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adu_InventarioFisicoDA.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_daInvFisicos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_planificacion_rutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_planificacion_rutas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_automatizaTransporte
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cancelacion_Compromisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cancelacion_Compromisos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Cancelacion_Compromisos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_asignacion_picking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_asignacion_picking.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_pickingporUsuario
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_parametrizacion_picking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_parametrizacion_picking.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_asignarActividadEspecial
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cr_recibos_canal_moderno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cr_recibos_canal_moderno.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_recibos_canal_moderno
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cr_envio_documentos_canal_moderno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cr_envio_documentos_canal_moderno.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_recibos_walmart
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_trancking_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_trancking_factura.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmTrackingFactura
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub


    Private Sub mti_actualizacion_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mti_actualizacion_producto.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_enviarProductoOnbase
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_actualizacion_sku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_actualizacion_sku.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_actualizacion_sku
        oform.sLinea = "6"
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_reproceso_isf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mco_reproceso_isf.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_ReprocesoEdifact
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_chequeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mlo_chequeo.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_ChequeoFacturas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cr_recepcion_devoluciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mfi_cr_recepcion_devoluciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        'Dim oform As New frm_recepcionDevoluciones
        Dim oform As New frmRecepcionRechazosFinanzas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing



    End Sub

    'Private Sub mlo_facturacionANIXTER_Click(sender As Object, e As EventArgs) Handles mlo_facturacionANIXTER.Click
    '    Dim oform As New frm_FacturacionANIXTER
    '    oform.ShowDialog()
    '    oform.Dispose()
    '    oform = Nothing
    'End Sub

    Private Sub mfiOperacionRecibos_Click(sender As Object, e As EventArgs) Handles mfiOperacionRecibos.Click
        'Dim oform As New frm_Recibos_Lote
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Recibos_Automatizar
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mlo_productosANIXTER_Click(sender As Object, e As EventArgs) Handles mlo_productosANIXTER.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Form6
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_costo_ingresoCD_Click(sender As Object, e As EventArgs) Handles mfi_costo_ingresoCD.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Costo__Ingreso_CD
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_ws_entregas_Click(sender As Object, e As EventArgs) Handles mco_ws_entregas.Click
        Dim oform As New frm_ws_control_entregas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_tra_liberar_facturas_Click(sender As Object, e As EventArgs) Handles mlo_tra_liberar_facturas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_liberar_facturas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mrh_suspensiones_Click(sender As Object, e As EventArgs) Handles mrh_suspensiones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_suspension
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_fac_direccionar_impresoras_Click(sender As Object, e As EventArgs) Handles mfi_fac_direccionar_impresoras.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_impresoras1
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_actualizacion_productos_Click(sender As Object, e As EventArgs) Handles mlo_actualizacion_productos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Productos_Bodega
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_div_reportes_Click(sender As Object, e As EventArgs) Handles mco_div_reportes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        generar_reporte(154, " Divinos")
    End Sub

    Private Sub mfi_caja_chica_Click(sender As Object, e As EventArgs) Handles mfi_caja_chica.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Cajas_Chicas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_edi_inner_pack_Click(sender As Object, e As EventArgs) Handles mco_edi_inner_pack.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_analisis20
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_tr_generarInformacion_Click(sender As Object, e As EventArgs) Handles mlo_tr_generarInformacion.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_Genera_Info_Pilotos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_clientesContado_Click(sender As Object, e As EventArgs) Handles mco_clientesContado.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Clientes_Contado
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mcoRetailLink_Click(sender As Object, e As EventArgs) Handles mcoRetailLink.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmCargaInformacionWalmart
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_fac_compras_interempresas_Click(sender As Object, e As EventArgs) Handles mfi_fac_compras_interempresas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Traslados
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_actualizacion_productos_Click(sender As Object, e As EventArgs) Handles mco_actualizacion_productos.Click
        'Dim oform As New Frm_Actualizacion_Codigos
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Productos_Pareto
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_actualizacion_pedidowalmart_Click(sender As Object, e As EventArgs) Handles mlo_actualizacion_pedidowalmart.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_pedido_walmart
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_mercaderistas_Click(sender As Object, e As EventArgs) Handles mco_mercaderistas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_mercaderista_cliente
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_tra_notasdevolucion_Click(sender As Object, e As EventArgs) Handles mlo_tra_notasdevolucion.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Carga_Notas_Devolucion
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mrh_traslado_empleados_Click(sender As Object, e As EventArgs) Handles mrh_traslado_empleados.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Traslada_Personal
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_co_item_producto_Click(sender As Object, e As EventArgs) Handles mfi_co_item_producto.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Producto_Item
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_co_conciliacionBancaria_Click(sender As Object, e As EventArgs) Handles mfi_co_conciliacionBancaria.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_conciliacion_bancaria
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_edi_validacion_oc_wm_Click(sender As Object, e As EventArgs) Handles mco_edi_validacion_oc_wm.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_validacion_OC_WM
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub


    Private Sub mlo_ingresos_cd_Click(sender As Object, e As EventArgs) Handles mlo_ingresos_cd.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_informeInternaciones
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_MonitorMaquila_Click(sender As Object, e As EventArgs) Handles mco_MonitorMaquila.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_MonitorMaquila
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_devolucionesInterempresas_Click(sender As Object, e As EventArgs) Handles mco_devolucionesInterempresas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_DevolucionesInterempresas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_ci_etiquetado_Click(sender As Object, e As EventArgs) Handles mlo_ci_etiquetado.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_int_etiquetado
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mer_actualizacionProductos_Click(sender As Object, e As EventArgs) Handles mer_actualizacionProductos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_actualizacionProducto
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mer_actualizacionProductosIE_Click(sender As Object, e As EventArgs) Handles mer_actualizacionProductosIE.Click
        Try
            guardarLogB("Acceso Actualizaciñn de Productos", gs_usuario, "Mercadeo", "Actualizaciñn de Productos")
        Catch ex As Exception
        End Try

        Dim oform As New frm_actualizacionProductos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub actualizacionProductos_Individual_Click(sender As Object, e As EventArgs)
        Try
            guardarLogB("Acceso Actualizaciñn Individual", gs_usuario, "Mercadeo", "Actualizaciñn Individual")
        Catch ex As Exception
        End Try
        Dim oform As New frm_actualizacionProductosIE
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub actualizacionProductos_Masiva_Click(sender As Object, e As EventArgs)
        Try
            guardarLogB("Acceso Actualizaciñn Masiva", gs_usuario, "Mercadeo", "Actualizaciñn Masiva")
        Catch ex As Exception
        End Try
        Dim oform As New frm_actualizacionProductosMasivaIE
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_con_productos_contables_Click(sender As Object, e As EventArgs) Handles mfi_con_productos_contables.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Productos_Contables
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mrh_candidatos_Click(sender As Object, e As EventArgs) Handles mrh_candidatos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Candidatos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_tr_cumplimiento_diario_rentado_Click(sender As Object, e As EventArgs) Handles mlo_tr_cumplimiento_diario_rentado.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Cumplimiento_Diario_Trans
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub


    Private Sub mlo_reasignacionPicking_Click(sender As Object, e As EventArgs) Handles mlo_reasignacionPicking.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_Reasignar_picking
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_agregar_reenvios_Click(sender As Object, e As EventArgs) Handles mlo_agregar_reenvios.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_AgregarReenvios
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub


    Private Sub mfi_con_analisis_facturas_Click(sender As Object, e As EventArgs) Handles mfi_con_analisis_facturas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Facturas_Analisis
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_tr_editar_marcajes_Click(sender As Object, e As EventArgs) Handles mlo_tr_editar_marcajes.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmEdicionMarcajesPilotos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cre_analisis_facturas_Click(sender As Object, e As EventArgs) Handles mfi_cre_analisis_facturas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Cancela_Facturas_Con_Notas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_tracking_oc_tesoreria_Click(sender As Object, e As EventArgs) Handles mci_tracking_oc_tesoreria.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scm_tracking_pedido_tesoreria
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mrh_garita_Click(sender As Object, e As EventArgs) Handles mrh_garita.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Acceso
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mci_soc_complemento_divinos_Click(sender As Object, e As EventArgs) Handles mci_soc_complemento_divinos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_complemento_divinos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_picking_3pl_Click(sender As Object, e As EventArgs) Handles mlo_picking_3pl.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_Maquila_3PL
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_informe_recepcion_3pl_Click(sender As Object, e As EventArgs) Handles mlo_informe_recepcion_3pl.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_3PL_HH
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_procesar_pedidos_3pl_Click(sender As Object, e As EventArgs) Handles mlo_procesar_pedidos_3pl.Click
        'Dim oform As New frm_Procesar_Pedidos_3pl
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_procesoarchivos3pl
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mar_ol_tableau1_Click(sender As Object, e As EventArgs) Handles mar_ol_tableau1.Click

        Me.Ejecutar_Tableau(sender.ToString().Split(",")(2).Split(":")(1).Trim)
    End Sub

    Private Sub mfi_con_tracking_pagos_Click(sender As Object, e As EventArgs) Handles mfi_con_tracking_pagos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Tracking_Pagos_Electronicos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mrh_bono14_Click(sender As Object, e As EventArgs) Handles mrh_bono14.Click

    End Sub

    Private Sub mco_RecepcionFacturas_Requisicion_Click(sender As Object, e As EventArgs) Handles mco_RecepcionFacturas_Requisicion.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisicionRecepcionFactura
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_edi_carga_informacion_bi_Click(sender As Object, e As EventArgs) Handles mco_edi_carga_informacion_bi.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmCargasBI
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_presupuesto_marca_ayp_Click(sender As Object, e As EventArgs) Handles mco_presupuesto_marca_ayp.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_presupuesto_marcas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_fc_traslado_facturas_Click(sender As Object, e As EventArgs) Handles mfi_fc_traslado_facturas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmTrasladoFacturas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_Envio_Facturas_Recepcion_Click(sender As Object, e As EventArgs) Handles mco_Envio_Facturas_Recepcion.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisicionesTrasladoRecepcion
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_PedidoVinoteca_Bodegas_Click(sender As Object, e As EventArgs) Handles mco_PedidoVinoteca_Bodegas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_vin_Pedido_automatico_otras_bodegas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mci_soc_ocdivinos_Click(sender As Object, e As EventArgs) Handles mci_soc_ocdivinos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_Convierte_FactVentas_OC_SV
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_claim_Click(sender As Object, e As EventArgs) Handles mco_claim.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_soporte_claim
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mfi_caja_chica_multiple_Click(sender As Object, e As EventArgs) Handles mfi_caja_chica_multiple.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New Frm_Cajas_Chicas_M
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mti_dts_Click(sender As Object, e As EventArgs) Handles mti_dts.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_DTS
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cre_consolidacion_consignaciones_Click(sender As Object, e As EventArgs) Handles mfi_cre_consolidacion_consignaciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRenovacionconsignaciones
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mar_cubos_logistica_Click(sender As Object, e As EventArgs) Handles mar_cubos_logistica.Click

    End Sub


    Private Sub mlo_montor_impresiones_AG_Click(sender As Object, e As EventArgs) Handles mlo_montor_impresiones_AG.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmMonitorImpresionesAG
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mfi_cre_procesos_fel_Click(sender As Object, e As EventArgs) Handles mfi_cre_procesos_fel.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_documentos_fel
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_requisicionesProyecto_Click(sender As Object, e As EventArgs) Handles mco_requisicionesProyecto.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmRequisicionesProyectos
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mfi_fc_fel_telemarketing_Click(sender As Object, e As EventArgs) Handles mfi_fc_fel_telemarketing.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmPedidoCreditoTmk
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mfi_cre_pagos_exterior_Click(sender As Object, e As EventArgs) Handles mfi_cre_pagos_exterior.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmPagosExterior
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_transporte_tmk_Click(sender As Object, e As EventArgs) Handles mlo_transporte_tmk.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_control_transporte_tmk
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mlo_picking_tmk_Click(sender As Object, e As EventArgs) Handles mlo_picking_tmk.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_pickeador_TMK
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_vin_sincronizar_productos_Click(sender As Object, e As EventArgs) Handles mco_vin_sincronizar_productos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scn_ofertas
        oform.lproductos = True
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_vin_sincronizar_memos_Click(sender As Object, e As EventArgs) Handles mco_vin_sincronizar_memos.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_scn_ofertas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_pedidos_unisuper_Click(sender As Object, e As EventArgs) Handles mco_pedidos_unisuper.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmPedidosUnisuper
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_reimpresion_fel_Click(sender As Object, e As EventArgs) Handles mco_reimpresion_fel.Click

        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_impresionFEL
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_vinoteca_liberar_salidas_Click(sender As Object, e As EventArgs) Handles mco_vinoteca_liberar_salidas.Click

        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try


        Dim oform As New frm_liberar_facturas
        oform.lbVinoteca = True
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_vinoteca_entradaxtraslados_Click(sender As Object, e As EventArgs) Handles mco_vinoteca_entradaxtraslados.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_traslados_Vinoteca
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_recepcion_mercaderia_vinoteca_Click(sender As Object, e As EventArgs) Handles mco_recepcion_mercaderia_vinoteca.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_recepcion_mercaderia_vinoteca
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_co_carga_combustible_Click(sender As Object, e As EventArgs) Handles mfi_co_carga_combustible.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_Carga_Combustible_TC
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_co_liquidacion_caja_chica_teams_Click(sender As Object, e As EventArgs) Handles mfi_co_liquidacion_caja_chica_teams.Click

        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_liquidacion_caja_chica
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_administracion_escasez_Click(sender As Object, e As EventArgs) Handles mco_administracion_escasez.Click

        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try
        Dim oform As New frm_escasez
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mco_actualizacion_sku_unisuper_Click(sender As Object, e As EventArgs) Handles mco_actualizacion_sku_unisuper.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_actualizacion_sku
        oform.sLinea = "8"
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cre_liquidacion_transportes_caja_Click(sender As Object, e As EventArgs) Handles mfi_cre_liquidacion_transportes_caja.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmLiquidacionCaja

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_cre_monitor_impresiones_Click(sender As Object, e As EventArgs) Handles mfi_cre_monitor_impresiones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmMonitorImpresiones_cedi

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mco_vin_solicitud_traslados_Click(sender As Object, e As EventArgs) Handles mco_vin_solicitud_traslados.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frm_MinMax_Solicitud_Vinoteca

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_con_anulacionFEL_Click(sender As Object, e As EventArgs) Handles mfi_con_anulacionFEL.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try

        Dim oform As New frmAnularDocumentosFEL

        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mlo_recepcionFacturas_Click(sender As Object, e As EventArgs) Handles mlo_recepcionFacturas.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try


        Dim oform As New frmRecepcionFacturas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing
    End Sub

    Private Sub mfi_con_tracking_caja_chica_Click(sender As Object, e As EventArgs) Handles mfi_con_tracking_caja_chica.Click

        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try


        Dim oform As New frmTrackingLote
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mfi_fac_monitor_impresiones_recolecta_Click(sender As Object, e As EventArgs) Handles mfi_fac_monitor_impresiones_recolecta.Click


        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try


        Dim oform As New frmImpresionFacturasAreas
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub

    Private Sub mlo_tr_recolecciones_Click(sender As Object, e As EventArgs) Handles mlo_tr_recolecciones.Click
        Try
            guardarLogB("Acceso " & DirectCast(sender, ClasesGenerales.General.RichMenuItem).Description, gs_usuario, Replace(DirectCast(DirectCast(sender, System.Windows.Forms.MenuItem).Parent, System.Windows.Forms.MenuItem).[Text], "&", ""), Replace(DirectCast(sender, System.Windows.Forms.MenuItem).[Text], "&", ""))
        Catch ex As Exception
        End Try


        Dim oform As New frm_control_recolecciones
        oform.ShowDialog()
        oform.Dispose()
        oform = Nothing

    End Sub


    Private Sub Crear_tiles()
        ' Eliminar panel de tiles anterior si existe
        Dim viejos() As Control = Me.Controls.Find("pnlTiles", False)
        For Each v As Control In viejos
            Me.Controls.Remove(v)
            v.Dispose()
        Next

        Dim pnlTiles As New FlowLayoutPanel()
        pnlTiles.Name = "pnlTiles"
        pnlTiles.Dock = DockStyle.Fill
        pnlTiles.FlowDirection = FlowDirection.LeftToRight
        pnlTiles.WrapContents = True
        pnlTiles.Padding = New Padding(36, 36, 0, 0)
        pnlTiles.BackColor = Color.FromArgb(242, 240, 234)
        pnlTiles.AutoScroll = True

        Dim acentos() As Color = {
            Color.FromArgb(196, 81, 35),
            Color.FromArgb(106, 116, 56),
            Color.FromArgb(196, 81, 35),
            Color.FromArgb(106, 116, 56),
            Color.FromArgb(196, 81, 35),
            Color.FromArgb(106, 116, 56),
            Color.FromArgb(196, 81, 35),
            Color.FromArgb(106, 116, 56),
            Color.FromArgb(196, 81, 35)
        }

        Dim idx As Integer = 0
        For Each mi As MenuItem In menu_principal.MenuItems
            Dim label As String = mi.Text.Replace("&", "").Trim()
            If label = "" Or label = "Archivo" Then Continue For
            If mi.MenuItems.Count = 0 Then Continue For

            Dim acento As Color = acentos(idx Mod acentos.Length)
            idx += 1

            ' Borde externo del tile (simula borde coloreado)
            Dim border As New Panel()
            border.Size = New Size(152, 118)
            border.Margin = New Padding(0, 0, 20, 20)
            border.BackColor = acento
            border.Cursor = Cursors.Hand

            ' Panel interno blanco
            Dim tile As New Panel()
            tile.Location = New Point(2, 2)
            tile.Size = New Size(148, 114)
            tile.BackColor = Color.White
            tile.Cursor = Cursors.Hand
            tile.Tag = border

            ' Barra de acento superior
            Dim pnlAccent As New Panel()
            pnlAccent.Dock = DockStyle.Top
            pnlAccent.Height = 6
            pnlAccent.BackColor = acento

            ' Iniciales como icono
            Dim initials As String
            Dim words() As String = label.Split(" "c)
            If words.Length >= 2 Then
                initials = (words(0).Substring(0, 1) & words(1).Substring(0, 1)).ToUpper()
            Else
                initials = label.Substring(0, Math.Min(3, label.Length)).ToUpper()
            End If

            Dim lblIcon As New Label()
            lblIcon.Text = initials
            lblIcon.Font = New Font("Segoe UI", 24, FontStyle.Bold)
            lblIcon.ForeColor = Color.FromArgb(220, 215, 205)
            lblIcon.TextAlign = ContentAlignment.MiddleCenter
            lblIcon.Dock = DockStyle.Fill
            lblIcon.Cursor = Cursors.Hand

            ' Nombre del modulo
            Dim lblNombre As New Label()
            lblNombre.Text = label
            lblNombre.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            lblNombre.ForeColor = Color.FromArgb(55, 62, 28)
            lblNombre.TextAlign = ContentAlignment.MiddleCenter
            lblNombre.Dock = DockStyle.Bottom
            lblNombre.Height = 30
            lblNombre.Cursor = Cursors.Hand
            lblNombre.BackColor = Color.White

            tile.Controls.Add(lblIcon)
            tile.Controls.Add(lblNombre)
            tile.Controls.Add(pnlAccent)
            border.Controls.Add(tile)

            ' Construir ContextMenuStrip desde el MenuItem existente
            Dim cms As New ContextMenuStrip()
            cms.Font = New Font("Segoe UI", 9)
            cms.Renderer = New UmbralMenuRenderer()
            cms.ShowImageMargin = False
            cms.Padding = New Padding(0, 4, 0, 4)
            BuildContextMenu(cms.Items, mi.MenuItems, label)

            ' Hover
            Dim capturedBorder As Panel = border
            Dim capturedTile As Panel = tile
            Dim capturedAccent As Color = acento
            AddHandler tile.MouseEnter, Sub(s, e)
                                            capturedTile.BackColor = Color.FromArgb(250, 248, 244)
                                        End Sub
            AddHandler tile.MouseLeave, Sub(s, e)
                                            capturedTile.BackColor = Color.White
                                        End Sub
            AddHandler lblIcon.MouseEnter, Sub(s, e) capturedTile.BackColor = Color.FromArgb(250, 248, 244)
            AddHandler lblIcon.MouseLeave, Sub(s, e) capturedTile.BackColor = Color.White
            AddHandler lblNombre.MouseEnter, Sub(s, e) capturedTile.BackColor = Color.FromArgb(250, 248, 244)
            AddHandler lblNombre.MouseLeave, Sub(s, e) capturedTile.BackColor = Color.White

            ' Click izq -> menu, Click der -> favorito
            Dim capturedCms As ContextMenuStrip = cms
            AddHandler tile.Click, Sub(s, e) capturedCms.Show(capturedBorder, 0, capturedBorder.Height)
            AddHandler lblIcon.Click, Sub(s, e) capturedCms.Show(capturedBorder, 0, capturedBorder.Height)
            AddHandler lblNombre.Click, Sub(s, e) capturedCms.Show(capturedBorder, 0, capturedBorder.Height)


            pnlTiles.Controls.Add(border)
        Next

        Me.Controls.Add(pnlTiles)
        pnlTiles.SendToBack()

        ' El header siempre al frente
        Dim hdr() As Control = Me.Controls.Find("pnlHeader", False)
        If hdr.Length > 0 Then hdr(0).BringToFront()
    End Sub

    Private Sub BuildContextMenu(items As ToolStripItemCollection, menuItems As Menu.MenuItemCollection, Optional rutaBase As String = "")
        For Each mi As MenuItem In menuItems
            Dim label As String = mi.Text.Replace("&", "").Trim()
            If label = "-" Then
                items.Add(New ToolStripSeparator())
            ElseIf mi.MenuItems.Count > 0 Then
                Dim tsi As New ToolStripMenuItem(label)
                tsi.Font = New Font("Segoe UI", 9)
                BuildContextMenu(tsi.DropDownItems, mi.MenuItems, rutaBase & " / " & label)
                items.Add(tsi)
            Else
                If label = "" Then Continue For
                Dim tsi As New ToolStripMenuItem(label)
                tsi.Font = New Font("Segoe UI", 9)
                Dim capturedMi As MenuItem = mi
                Dim capturedLbl As String = label
                AddHandler tsi.Click, Sub(s, e)
                                          capturedMi.PerformClick()
                                          AgregarReciente(rutaBase & " / " & capturedLbl, capturedMi)
                                      End Sub
                items.Add(tsi)
            End If
        Next
    End Sub

    ' === FAVORITOS Y RECIENTES ===
    Private Sub AgregarReciente(label As String, mi As MenuItem)
        recientes.RemoveAll(Function(t) t.Item1 = label)
        recientes.Insert(0, Tuple.Create(label, mi))
        If recientes.Count > 3 Then recientes.RemoveAt(3)
        Crear_acceso_rapido()
    End Sub

    Private Sub ToggleFavorito(label As String, mi As MenuItem)
        If favoritos.Contains(label) Then
            favoritos.Remove(label) : favoritosItems.Remove(label)
        Else
            If favoritos.Count >= 5 Then MsgBox("Maximo 5 favoritos. Quita uno primero.", MsgBoxStyle.Information, "Favoritos") : Return
            favoritos.Add(label) : favoritosItems(label) = mi
        End If
        GuardarFavoritos() : Crear_acceso_rapido()
    End Sub

    Private Sub CargarFavoritos()
        favoritos.Clear() : favoritosItems.Clear()
        If Not System.IO.File.Exists(favoritosPath) Then Return
        For Each line As String In System.IO.File.ReadAllLines(favoritosPath)
            If line.Trim() <> "" Then favoritos.Add(line.Trim())
        Next
        For Each mi As MenuItem In menu_principal.MenuItems
            Dim lbl As String = mi.Text.Replace("&", "").Trim()
            If favoritos.Contains(lbl) Then favoritosItems(lbl) = mi
        Next
    End Sub

    Private Sub GuardarFavoritos()
        System.IO.File.WriteAllLines(favoritosPath, favoritos.ToArray())
    End Sub

    Private Sub Crear_acceso_rapido()
        Dim viejos() As Control = Me.Controls.Find("pnlQuickAccess", False)
        For Each v As Control In viejos : Me.Controls.Remove(v) : v.Dispose() : Next

        Dim pnlQA As New Panel()
        pnlQA.Name = "pnlQuickAccess"
        pnlQA.Dock = DockStyle.Top
        pnlQA.Height = 82
        pnlQA.BackColor = Color.FromArgb(230, 227, 218)

        Dim lblR As New Label()
        lblR.Text = ChrW(9202) & " RECIENTES"
        lblR.Font = New Font("Segoe UI", 7.0F, FontStyle.Bold)
        lblR.ForeColor = Color.FromArgb(106, 116, 56)
        lblR.AutoSize = True
        lblR.Location = New Point(36, 6)
        pnlQA.Controls.Add(lblR)

        If recientes.Count = 0 Then
            Dim lhr As New Label()
            lhr.Text = "Las opciones que uses apareceran aqui"
            lhr.Font = New Font("Segoe UI", 7.5F, FontStyle.Italic)
            lhr.ForeColor = Color.FromArgb(160, 155, 145)
            lhr.AutoSize = True
            lhr.Location = New Point(36, 24)
            pnlQA.Controls.Add(lhr)
        Else
            Dim rx As Integer = 36
            For Each t As Tuple(Of String, MenuItem) In recientes
                Dim qt As Panel = CrearQuickTile(t.Item1, t.Item2, Color.FromArgb(106, 116, 56))
                qt.Location = New Point(rx, 18)
                pnlQA.Controls.Add(qt)
                rx += qt.Width + 10
            Next
        End If

        Me.Controls.Add(pnlQA)
        pnlQA.SendToBack()
        Dim hdr() As Control = Me.Controls.Find("pnlHeader", False)
        If hdr.Length > 0 Then hdr(0).SendToBack()
    End Sub

    Private Function CrearQuickTile(ruta As String, mi As MenuItem, acento As Color) As Panel
        Dim sepArr() As String = {" / "}
        Dim partes() As String = ruta.Split(sepArr, StringSplitOptions.None)
        Dim modulo As String = If(partes.Length > 0, partes(0), ruta)
        Dim subRuta As String = If(partes.Length > 1, String.Join(" / ", partes, 1, partes.Length - 1), "")
        Dim tile As New Panel()
        tile.Size = New Size(160, 60) : tile.BackColor = Color.White : tile.Cursor = Cursors.Hand
        Dim pTop As New Panel()
        pTop.Dock = DockStyle.Top : pTop.Height = 3 : pTop.BackColor = acento
        Dim lblMod As New Label()
        lblMod.Text = modulo : lblMod.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblMod.ForeColor = acento : lblMod.Location = New Point(8, 6) : lblMod.AutoSize = True
        lblMod.Cursor = Cursors.Hand
        Dim lblSub As New Label()
        lblSub.Text = subRuta : lblSub.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular)
        lblSub.ForeColor = Color.FromArgb(55, 62, 28) : lblSub.Location = New Point(8, 24)
        lblSub.Size = New Size(146, 30) : lblSub.Cursor = Cursors.Hand
        tile.Controls.Add(lblSub) : tile.Controls.Add(lblMod) : tile.Controls.Add(pTop)
        Dim ct As Panel = tile
        AddHandler tile.MouseEnter, Sub(s, e) ct.BackColor = Color.FromArgb(248, 245, 239)
        AddHandler tile.MouseLeave, Sub(s, e) ct.BackColor = Color.White
        AddHandler lblMod.MouseEnter, Sub(s, e) ct.BackColor = Color.FromArgb(248, 245, 239)
        AddHandler lblMod.MouseLeave, Sub(s, e) ct.BackColor = Color.White
        AddHandler lblSub.MouseEnter, Sub(s, e) ct.BackColor = Color.FromArgb(248, 245, 239)
        AddHandler lblSub.MouseLeave, Sub(s, e) ct.BackColor = Color.White
        Dim cmi As MenuItem = mi : Dim cruta As String = ruta
        AddHandler tile.Click, Sub(s, e)
                                   cmi.PerformClick() : AgregarReciente(cruta, cmi)
                               End Sub
        AddHandler lblMod.Click, Sub(s, e)
                                     cmi.PerformClick() : AgregarReciente(cruta, cmi)
                                 End Sub
        AddHandler lblSub.Click, Sub(s, e)
                                     cmi.PerformClick() : AgregarReciente(cruta, cmi)
                                 End Sub
        Return tile
    End Function

    Private Sub pb_it_Click(sender As Object, e As EventArgs) Handles pb_it.Click

    End Sub
End Class


Public Class UmbralMenuRenderer
    Inherits ToolStripProfessionalRenderer

    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.AffectedBounds)
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(106, 116, 56)), 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1)
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If e.Item.Selected AndAlso e.Item.Enabled Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(240, 235, 225)), New Rectangle(4, 0, e.Item.Width - 8, e.Item.Height))
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Item.ContentRectangle)
        End If
    End Sub

    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        e.TextColor = If(e.Item.Selected AndAlso e.Item.Enabled, Color.FromArgb(196, 81, 35), Color.FromArgb(55, 62, 28))
        MyBase.OnRenderItemText(e)
    End Sub

    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        Dim y = e.Item.Height \ 2
        e.Graphics.DrawLine(New Pen(Color.FromArgb(220, 215, 200)), 10, y, e.ToolStrip.Width - 10, y)
    End Sub

    Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
        e.ArrowColor = If(e.Item.Selected, Color.FromArgb(196, 81, 35), Color.FromArgb(106, 116, 56))
        MyBase.OnRenderArrow(e)
    End Sub

End Class
