Imports System.Windows.Forms
Imports System.Collections
Imports External
Public Class frm_automatizaTransporte
    Dim ls_sql As String
    Dim dt As DataTable
    Dim dr As DataRow
    Dim ods As New DataSet
    Dim clsgls As New ClasesGenerales.General()
    Dim oTrans As New Transaccional.Conexion("flexline")
    Dim facturasGeneradas As Boolean = False
    Dim numFacturasAsignadas As Integer = 0
    Dim pesoFacturaActual, volumenFacturaActual As Decimal
    Dim arrayMontos As New ArrayList
    Dim dtOrdenes As New DataTable
    Dim monto As Double = 0

    Private Sub llenarCombos()
        llenarCombo(oTrans, "pa_sel_um_rutas_transporte", "rutas", "codigo", "codigo", cmb_Rutas)
        llenarCombo(oTrans, "pa_sel_um_rutas_transporte", "rutas", "codigo", "codigo", cmbRutaCambio)
        llenarCombo(oTrans, "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'", "empresa", "empresa", "empresa", cmbEmpresa)

        llenarCombo(oTrans, "pa_sel_um_sg_usuario_empresa '" & gs_usuario & "'", "empresaVerifica", "empresa", "empresa", cmbEmpresaVerifica)



        Try
            Dim oTransaccion As New Transaccional.Conexion("flexline")
            oTransaccion.open()

            ls_sql = "pa_sel_um_gen_parametros_sistema"
            Dim ldt_table As DataTable = oTransaccion.Obtiene(ls_sql)
            Dim tipos_doctos(20) As String
            tipos_doctos = ldt_table.Rows(0).Item("documentos_control_transporte").ToString.Split(",")
            Me.cmbTipoDoctoVerifica.Items.AddRange(tipos_doctos)
            oTransaccion.close()
            oTransaccion = Nothing






        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenar_ubicacion()
        Dim ls_sql As String
        Dim tipos_doctos(20) As String
        Dim ldt_table, ldt_tablec, ldt_table_ As New DataTable
        Dim oTransaccion As New Transaccional.Conexion("flexline")
        oTransaccion.open()


        ls_sql = "pa_sel_um_ubicacion_planificacion "
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "ubica"
        'ldt_table.DefaultView.RowFilter = "vigencia <> 'N'"
        Me.cmbUbicacion.DisplayMember = "Ubicacion"
        Me.cmbUbicacion.ValueMember = "Ubicacion"
        Me.cmbUbicacion.DataSource = ldt_table.DefaultView
    End Sub
    Private Sub convertirDevolucion()
        Dim clsgen As New ClasesGenerales.General
        Dim nrow As Integer
        Try
            nrow = Me.dgvReenvios.CurrentRow.Index

            If MessageBox.Show("Esta Seguro de Asignar La Devolucion " &
                               Me.dgvReenvios.Item("correlativo", nrow).Value & " de la Empresa " &
                                Me.dgvReenvios.Item("empresa", nrow).Value, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



                clsgen.insertQuery("FlexLine", "spa_Nota_Devolucion_Control '" & Me.dgvReenvios.Item("empresa", nrow).Value & "','" & Me.dgvReenvios.Item("correlativo", nrow).Value & "'")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarDevolucionesPendientes()
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String
        Try
            dt = clsGen.selectQuery("FlexLine", "pa_sel_um_devolucion_encabezado_listado_transporte '01/01/2023'")
            Me.dgvDevoluciones.DataSource = dt


            clsGen.Alinear_GridView(dt, Me.dgvDevoluciones, ",empresa,ctacte,razonsocial,total_devolucion,total_lineas,fecha_devolucion,comentarios,usuario_grabod,correlativo,usuario_aprobo,fecha_aprobacion,estadod,tipodocto,fecha_docto,forma_entrega,estadotransporte,usuario_asigna_ruta,fecha_asigna_ruta,", "", "", "", ",correlativo=numero,", "", ",empresa,correlativo,ctacte,razon_social,fecha_devolucion,total_devolucion,total_lineas,", True, True, 150, 0)



        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_buscarRutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscarRutas.Click
        buscarRutas()
        If (Not chkDevoluciones.Checked) Then
            'sumarPesos()
        End If

        'verificarFacturaAsignada() 'Oculta las facturas que se estan trabajando

        ocultarFacturasAsignadas()
    End Sub

    Private Sub ocultarFacturasAsignadas()
        Try


            For Each drDocumento As DataRow In ods.Tables("facturas").Rows

                ods.Tables("facturasAsignadas").DefaultView.RowFilter = "empresa = '" & drDocumento.Item("empresa").ToString & "' and " &
                                                    "TipoDocto = '" & drDocumento.Item("TipoDocto").ToString & "' and " &
                                                    "Numero = '" & drDocumento.Item("numero").ToString & "'"
                If ods.Tables("facturasAsignadas").DefaultView.Count > 0 Then
                    'dg_facturas.Rows(i).Visible = False
                    'dg_facturas.Rows(i).Cells("mostrar").Value = 0
                    drDocumento.Item("mostrar") = 0
                Else
                    'dg_facturas.Rows(i).Visible = True
                End If


                'If dg_facturas.Rows(i).Cells("analisisE26").Value.ToString.Length > 0 Then
                '    dg_facturas.Rows(i).Cells("mostrar").Value = 0
                'End If

            Next


            ods.Tables("facturasAsignadas").DefaultView.RowFilter = ""

        Catch ex As Exception
        Finally

            Try
                ods.Tables("facturas").DefaultView.RowFilter = "mostrar = 1"
            Catch ex As Exception

            End Try

        End Try
    End Sub


    Private Sub verificarFacturaAsignada()
        Try


            For i As Integer = 0 To dg_facturas.RowCount
                ods.Tables("facturasAsignadas").DefaultView.RowFilter = "empresa = '" & dg_facturas.Rows(i).Cells("empresa").Value & "' and " &
                                                    "TipoDocto = '" & dg_facturas.Rows(i).Cells("TipoDocto").Value & "' and " &
                                                    "Numero = '" & dg_facturas.Rows(i).Cells("numero").Value & "'"
                If ods.Tables("facturasAsignadas").DefaultView.Count > 0 Then
                    'dg_facturas.Rows(i).Visible = False
                    dg_facturas.Rows(i).Cells("mostrar").Value = 0
                Else
                    'dg_facturas.Rows(i).Visible = True
                End If


                'If dg_facturas.Rows(i).Cells("analisisE26").Value.ToString.Length > 0 Then
                '    dg_facturas.Rows(i).Cells("mostrar").Value = 0
                'End If

            Next


            ods.Tables("facturasAsignadas").DefaultView.RowFilter = ""

        Catch ex As Exception
        Finally

            Try
                ods.Tables("facturas").DefaultView.RowFilter = "mostrar = 1"
            Catch ex As Exception

            End Try

        End Try
    End Sub

    Private Sub buscarRutas()
        Dim ruta As String
        cmbRutaCambio.SelectedIndex = cmb_Rutas.SelectedIndex
        If chkFiltrarRuta.Checked Then
            ruta = "NULL"
        Else
            ruta = "'" & cmb_Rutas.SelectedValue.ToString & "'"
        End If

        ls_sql = "pa_sel_um_facturas_transporte " & ruta & ", '" &
            dtFechaInicialFacturas.Text & "', '" & dtFechaFinalFacturas.Text & "','" & cmbUbicacion.Text & "'"

        If (Me.chkMostrarEmpresa.Checked) Then
        Else
            ls_sql = ls_sql + ",'" & Me.cmbEmpresa.SelectedValue & "'"
        End If



        If (chkDevoluciones.Checked) Then
            ls_sql = "pa_sel_um_devoluciones_transporte " & ruta & ", '" &
                        dtFechaInicialFacturas.Text & "', '" & dtFechaFinalFacturas.Text & "'"
        End If
        'llenarGridView(oTrans, ls_sql, dg_facturas, ",empresa,tipodocto,numero,nombre_cliente,comentario1,direccion,direccion1,")

        Try

            dt = clsgls.selectQuery("flexline", ls_sql)
            dt.TableName = "facturas"
            If (ods.Tables.CanRemove(ods.Tables("facturas"))) Then
                ods.Tables.Remove(ods.Tables("facturas"))
            End If

            ''Debo Agregar Columna para ver si esta en proceso"
            'dt.Columns.Add(New DataColumn("asignada", GetType(Integer)))

            ods.Tables.Add(dt.Copy)
            dg_facturas.DataSource = ods.Tables("facturas").DefaultView

            Me.lblDocumentos.Text = dt.Rows.Count & " Documentos"
            ' verificarFacturaAsignada()
        Catch ex As Exception

        End Try
        clsgls.Alinear_GridView(ods.Tables("facturas"), dg_facturas, ",empresa,tipodocto,numero,nombre_cliente,fecha,comentario1,direccion,direccion1,total,ruta_logistica,fecha_entrega,impresiones,ubicacion_chequeo,reenvio,vendedor,referencia_pdv,dias_entrega,horas_entrega,",
            "", "", "", "", ",empresa=40,tipodocto=70,fecha=80,", "", True, True, 400, 10)



    End Sub

    Private Sub llenarGridView(ByVal otrans As Transaccional.Conexion,
        ByVal ls_sql As String, ByVal dg As DataGridView, Optional ByVal mostrar As String = "",
        Optional ByVal ocultar As String = "", Optional ByVal colsReadOnly As String = "",
        Optional ByVal derecha As String = "", Optional ByVal fdecimal As Boolean = True,
        Optional ByVal autoajustar As Boolean = True, Optional ByVal max As Integer = 400,
        Optional ByVal min As Integer = 15)

        prepararGridView(otrans, ls_sql, dg)
        clsgls.Alinear_GridView(dt, dg, mostrar, ocultar, colsReadOnly, derecha, fdecimal, autoajustar, max, min)
        dt = Nothing
    End Sub

    Private Sub prepararGridView(ByVal conexion As Transaccional.Conexion, ByVal ls_sql As String, ByVal dg As DataGridView)
        conexion.open()
        dt = conexion.Obtiene(ls_sql)
        conexion.close()

        dg.DataSource = dt
    End Sub

    Private Function getDataTable(ByVal conexion As Transaccional.Conexion, ByVal ls_sql As String) As DataTable
        Dim dt As DataTable
        conexion.open()
        dt = conexion.Obtiene(ls_sql)
        conexion.close()
        Return dt
    End Function

    Private Sub llenarCombo(ByVal conexion As Transaccional.Conexion, ByVal ls_sql As String, ByVal tableName As String, ByVal displaymember As String, ByVal valuemember As String, ByVal cmb As ComboBox)
        conexion.open()
        dt = conexion.Obtiene(ls_sql)
        conexion.close()

        dt.TableName = tableName
        cmb.DisplayMember = displaymember
        cmb.ValueMember = valuemember
        cmb.DataSource = dt.DefaultView

        dt = Nothing
    End Sub

    Private Sub frm_automatizaTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        llenar_ubicacion()
        getRutasDetalle()
        facturasGeneradas = True
        'sumarPesosVehiculo()
        ' lblMonto.Text = "Monto: " & (getMontoActual()).ToString
        getRutasPlanificadas()
        'dgProductosDetalle.Font = lblVolumenRuta.Font
        'dg_facturas.Font = lblVolumenRuta.Font
        Permisos_botones()

    End Sub

    Private Sub Permisos_botones()

        Dim ClsGen As New ClasesGenerales.General
        Dim dtDatos As DataTable
        Dim lsSQL As String

        Try
            lsSQL = String.Format("pa_sel_um_permisos_planificar '{0}'", gs_usuario)
            dtDatos = ClsGen.selectQuery("FlexLine", lsSQL)

            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0).Item("Boton3") = "SI" Then
                    btnGuardarPlanificacion.Enabled = True
                Else
                    btnGuardarPlanificacion.Enabled = False
                End If

                If dtDatos.Rows(0).Item("Boton1") = "SI" Then
                    btn_buscarRutas.Enabled = True
                Else
                    btn_buscarRutas.Enabled = False
                End If
                If dtDatos.Rows(0).Item("Boton2") = "SI" Then
                    btnProcesar.Enabled = True
                Else
                    btnProcesar.Enabled = False
                End If

                If dtDatos.Rows(0).Item("Ubicacion") = "ORIENTE" Then
                    cmbUbicacion.SelectedIndex = 1
                    cmbUbicacion.Enabled = False
                ElseIf dtDatos.Rows(0).Item("Ubicacion") = "XELA" Then
                    cmbUbicacion.SelectedIndex = 2
                    cmbUbicacion.Enabled = False
                ElseIf dtDatos.Rows(0).Item("Ubicacion") = "ANTIGUA" Then
                    cmbUbicacion.SelectedIndex = 3
                    cmbUbicacion.Enabled = False

                Else
                    cmbUbicacion.Enabled = True
                End If
            Else
                    MessageBox.Show("No Tiene Permisos para la Planificación", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub calculaPesoyVolumen(psEmpresa As String, psTipoDocto As String, psNumero As String)

        Dim pesototal, voltotal As String
        Dim ClsGen As New ClasesGenerales.General
        Dim dtDatos As DataTable
        Dim lsSQL As String

        Try

            lsSQL = String.Format("pa_sel_um_documentod_transportes '{0}','{1}','{2}'", psEmpresa, psTipoDocto, psNumero)
            dtDatos = ClsGen.selectQuery("FlexLine", lsSQL)

            ' llenarGridView(oTrans, ls_sql, dgProductosDetalle, ",empresa,tipodocto,producto,numero_docto,glosa,")

            dgProductosDetalle.DataSource = dtDatos
            '            clsgls.Alinear_GridView(dt, dgProductosDetalle, ",glosa,cantidad,peso,volumen,", "", "", "", "", "", "", True, True, 200, 10)
            ClsGen.Alinear_GridView(dtDatos, dgProductosDetalle, ",glosa,cantidad,peso,volumen,", "", "", "", "", ",empresa=40,tipodocto=80,", ",glosa,cantidad,peso,volumen,", True, True, 200, 10)

        Catch ex As Exception

        End Try
        Dim pesoFactura As Decimal = 0
        Dim volumenFactura As Decimal = 0
        Dim ind = 0
        ' las facturas, para sacar peso y volumen
        Try


            For Each dr As DataRow In dtDatos.Rows
                Try
                    'pesoFactura += Decimal.Parse((dr.Item("cantidad") * dr.Item("peso")).ToString)
                    pesoFactura += Decimal.Parse(dr.Item("peso").ToString)
                    If (dr.Item("peso") = 0) Then
                        dgProductosDetalle.Rows(ind).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Catch
                    '  dgProductosDetalle.Rows(3).
                    ' dgProductosDetalle.Rows(ind).DefaultCellStyle.BackColor = Color.Aquamarine
                End Try

                Try
                    volumenFactura += Decimal.Parse(dr.Item("volumen").ToString)
                    'volumenFactura += Decimal.Parse((dr.Item("cantidad") * dr.Item("volumen")).ToString)
                    If (dr.Item("volumen") = 0) Then
                        dgProductosDetalle.Rows(ind).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Catch ex As Exception
                    ' dgProductosDetalle.Rows(ind).DefaultCellStyle.BackColor = Color.Aquamarine
                Finally
                    ind += 1
                End Try

            Next
        Catch ex As Exception

        End Try
        pesototal = "Peso: " & pesoFactura.ToString("F")
        voltotal = "Volumen: " & volumenFactura.ToString("F")

        volumenFacturaActual = volumenFactura
        pesoFacturaActual = pesoFactura

        lblPeso.Text = pesototal
        lblVolumen.Text = voltotal
        lblNum.Text = psNumero
        lblTipo.Text = psTipoDocto + psNumero


    End Sub


    Private Sub dg_facturas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_facturas.CellClick, dgvFacturasAsignadas.CellClick
        Dim row As Integer
        Dim empresa, tipodoc, numdoc, pesototal, voltotal As String
        row = getSelectedRow(dg_facturas)

        Try
            row = getSelectedRow(dg_facturas)
            empresa = getGridViewValue(dg_facturas, "Empresa", row)
            tipodoc = getGridViewValue(dg_facturas, "TipoDocto", row)

            numdoc = getGridViewValue(dg_facturas, "numero", row)

            calculaPesoyVolumen(empresa, tipodoc, numdoc)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub sumarPesosOld()
        Dim subtotal As Double = 0
        Dim subtotal2 As Double = 0
        Dim ls_sql As String
        For Each row As DataGridViewRow In dg_facturas.Rows
            ls_sql = " pa_sel_um_documento_peso_volumen '" & row.Cells("empresa").Value.ToString & "','" & row.Cells("tipodocto").Value.ToString & "','" & row.Cells("numero").Value.ToString & "'"
            Try
                oTrans.open()
                dt = oTrans.Obtiene(ls_sql)
                subtotal += dt.Rows(0).Item("pesototal")
                subtotal2 += dt.Rows(0).Item("volumentotal")
            Catch ex As Exception
            Finally
                oTrans.close()
                'lblPesoRuta.Text = "Peso Total: " & subtotal
                'lblVolumenRuta.Text = "Volumen Total: " & subtotal2
            End Try
        Next
    End Sub
    Private Sub sumarPesosVehiculo()
        Dim subtotal As Double = 0
        Dim subtotal2 As Double = 0
        Dim ls_sql As String
        For Each row As DataGridViewRow In dgvFacturasAsignadas.Rows
            ls_sql = " pa_sel_um_documento_peso_volumen '" & row.Cells("empresa").Value.ToString & "','" & row.Cells("tipodocto").Value.ToString & "','" & row.Cells("Número").Value.ToString & "'"
            Try
                oTrans.open()
                dt = oTrans.Obtiene(ls_sql)
                subtotal += dt.Rows(0).Item("pesototal")
                subtotal2 += dt.Rows(0).Item("volumentotal")
            Catch ex As Exception
            Finally
                oTrans.close()
                lblPesoCargado.Text = "Peso Cargado: " & subtotal
                lblVolumenCargado.Text = "Volumen Cargado: " & subtotal2
            End Try
        Next
    End Sub
    Private Function calculaMontosRuta() As Double



        Dim sumar As Double

        Try
            lblPesoC.Text = ods.Tables("facturasAsignadas").Compute("sum(Peso)", "Peso>0")
            lblVolC.Text = ods.Tables("facturasAsignadas").Compute("sum(Volumen)", "Volumen>0")
            monto = ods.Tables("facturasAsignadas").Compute("sum(Total)", "Total>0")
            'de kgs a toneladas
            Me.lblToneladas.Text = Double.Parse(lblPesoC.Text) / 1000

        Catch ex As Exception

        End Try
        Return monto
    End Function
    Private Function getSelectedRow(ByVal gridview As DataGridView) As Integer
        Try
            Return gridview.SelectedCells(0).RowIndex
        Catch
            Return -1
        End Try
    End Function

    Private Function getGridViewValue(ByVal gridview As DataGridView, ByVal column As String, ByVal row As Integer) As String
        Return gridview.Item(column, row).Value.ToString
    End Function

    'Cambiar la Ruta 
    Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        Dim row As Integer
        Dim empresa, tipo, numero As String


        Try


            row = getSelectedRow(dg_facturas)


            empresa = getGridViewValue(dg_facturas, "empresa", row)
            tipo = getGridViewValue(dg_facturas, "tipodocto", row)
            numero = getGridViewValue(dg_facturas, "numero", row)
            If MessageBox.Show("Esta Seguro de Asignar la Ruta" & cmbRutaCambio.SelectedValue.ToString & " al Cliente " & getGridViewValue(dg_facturas, "nombre_cliente", row), "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                'ls_sql = "UPDATE documento SET AnalisisE8 = '" & cmbRutaCambio.SelectedValue.ToString & _
                '                    "' WHERE empresa = '" & empresa & "' AND tipodocto = '" & tipo & "' AND numero = '" & numero & "'"
                Try
                    oTrans.open()
                    'oTrans.Actualiza(ls_sql)
                Catch ex As Exception
                Finally
                    oTrans.close()

                    dg_facturas.CurrentCell = Nothing
                    dg_facturas.Rows(row).Visible = False
                    ' Vuelve a sacar las que ya estaban asignadas, es inneficiente
                    ' buscarRutas()
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub getRutasDetalle()
        Dim row As Integer

        'ls_sql = "pa_sel_um_vehiculo_documento_asignado '" & cmbVehiculos.SelectedValue.ToString & "', '" & dtpControl.Text & "'"
        'Dim dt As DataTable = getDataTable(oTrans, ls_sql)
        crearEstructura()
        Dim i As Integer = 0
        dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")
        For Each dr As DataRow In ods.Tables("facturasAsignadas").Rows
            Dim draux As DataRow

            draux = ods.Tables("facturasAsignadas").NewRow()
            draux.Item("Empresa") = dg_facturas.SelectedRows(0).Cells("Empresa")
            'draux.Item("Control de Transporte") = dt.Rows.Item(i).Item("controldetransporte")
            draux.Item("TipoDocto") = dg_facturas.SelectedRows(0).Cells("TipoDocto")
            draux.Item("Número") = dg_facturas.SelectedRows(0).Cells("Numero")
            'draux.Item("Distancia") = 0
            ods.Tables("facturasAsignadas").Rows.Add(draux)
            '            DataGridView1.Rows.Add(gs_empresa, dt.Rows.Item(i).Item("controldetransporte"), _
            'dt.Rows.Item(i).Item("tipodocto"), dt.Rows.Item(i).Item("numero"), dt.Rows.Item(i).Item("distancia"))
            i = i + 1
        Next
        dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")

        numFacturasAsignadas = ods.Tables("facturasAsignadas").Rows.Count

    End Sub
    Private Sub enviarvehiculo(prow As Integer)

        'Dim row As Integer
        'lblMonto.Text = "Monto: " & (getMontoActual()).ToString("C")
        Try
            'row = getSelectedRow(dg_facturas)
            'dg_facturas.CurrentCell = Nothing
            'dg_facturas.Rows(row).Visible = False
            'dg_facturas.Rows(row).Cells("mostrar").Value = 0


            Dim draux As DataRow
            draux = ods.Tables("facturasAsignadas").NewRow()
            draux.Item("seleccionar") = True


            draux.Item("Empresa") = dg_facturas.Item("empresa", prow).Value.ToString
            'draux.Item("Control de Transporte") = ""
            draux.Item("TipoDocto") = dg_facturas.Item("tipodocto", prow).Value.ToString
            draux.Item("ctacte") = dg_facturas.Item("ctacte", prow).Value.ToString
            draux.Item("RazonSocial") = dg_facturas.Item("nombre_cliente", prow).Value.ToString
            draux.Item("Comentario") = dg_facturas.Item("comentario1", prow).Value.ToString
            draux.Item("Direccion") = dg_facturas.Item("direccion", prow).Value.ToString
            draux.Item("Direccion1") = dg_facturas.Item("direccion1", prow).Value.ToString
            draux.Item("Numero") = dg_facturas.Item("numero", prow).Value.ToString
            draux.Item("Peso") = lblPeso.Text.Substring(5)
            draux.Item("Volumen") = lblVolumen.Text.Substring(8)
            draux.Item("Total") = dg_facturas.Item("total", prow).Value.ToString
            draux.Item("ruta") = dg_facturas.Item("ruta_logistica", prow).Value
            draux.Item("Impresiones") = dg_facturas.Item("impresiones", prow).Value
            draux.Item("ubicacion_chequeo") = dg_facturas.Item("ubicacion_chequeo", prow).Value
            draux.Item("reenvio") = dg_facturas.Item("reenvio", prow).Value

            draux.Item("referencia_pdv") = dg_facturas.Item("referencia_pdv", prow).Value
            draux.Item("dias_entrega") = dg_facturas.Item("dias_entrega", prow).Value
            draux.Item("horas_entrega") = dg_facturas.Item("horas_entrega", prow).Value

            ods.Tables("facturasAsignadas").Rows.Add(draux)


            dg_facturas.Item("mostrar", prow).Value = 0
            'dg_facturas.Rows(row).Cells("mostrar").Value = 0
            'dg_facturas.Refresh()
            'dgvFacturasAsignadas.Font = lblVolumenRuta.Font
            'dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")
            clsgls.Alinear_GridView(ods.Tables("facturasAsignadas"), dgvFacturasAsignadas, "", "", "", "", "", ",seleccionar=20,empresa=38,tipodocto=50,", "", True, True, 200, 10)


            lblMonto.Text = calculaMontosRuta.ToString("C")
        Catch ex As Exception

        End Try


    End Sub

    Private Sub guardarCambios()
        Dim row As Integer
        Dim monto, peso As Double
        Dim ptipo_guia, ls_periodo, numTransporte As String


        'row = getSelectedRow(dg_facturas)
        Dim otransS As New Transaccional.Conexion("flexline")

        otransS.open()
        Try


            otransS.Elimina("pa_del_um_control_transporte_temporal '" & txNombrePlanificacion.Text & "','" & dtpFechaEntrega.Text & "'")
            'otransS.close()

            'Vamos a validar si ya existe un control de transporte asignado al vehículo en la fecha
            'seleccionada
            'Dim dt1 As DataTable


            If (ods.Tables("facturasAsignadas").Rows.Count() > 0) Then
                'Obtiene un nuevo número de control de transporte
                'Si ya existía esto se omite


                monto = 0


                oTrans.open()
                'Hace los inserts
                'For Each dr As DataGridViewRow In dgvFacturasAsignadas.Rows
                For Each dr As DataRow In ods.Tables("facturasAsignadas").Rows
                    If dr.Item("Seleccionar") = True Then


                        ls_sql = "pa_ins_um_gen_control_transporte_temporal_tmp '" & dr.Item("empresa").ToString & "','" &
                         "','" & "','" &
                        dr.Item("tipodocto").ToString & "','" &
                        dr.Item("numero").ToString & "','" &
                        gs_usuario & "', '" &
                        txNombrePlanificacion.Text & "','" &
                        "PLANIF', '" & dtpFechaEntrega.Text & "','" & dr.Item("reenvio").ToString & "'"
                        oTrans.Ingresa(ls_sql)
                    End If


                Next



            End If
        Catch ex As Exception
        Finally
            oTrans.close()
            'oTrans = Nothing

        End Try
    End Sub

    Private Sub crearEstructura()
        Dim dt As DataTable


        dt = New DataTable("facturasAsignadas")
        dt.Columns.Add(New DataColumn("Seleccionar", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("Control de Transporte", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
        dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("Peso", GetType(Double)))
        dt.Columns.Add(New DataColumn("Volumen", GetType(Double)))
        dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
        dt.Columns.Add(New DataColumn("Direccion1", GetType(String)))
        dt.Columns.Add(New DataColumn("Referencia_PDV", GetType(String)))
        dt.Columns.Add(New DataColumn("Dias_Entrega", GetType(String)))
        dt.Columns.Add(New DataColumn("Horas_Entrega", GetType(String)))
        dt.Columns.Add(New DataColumn("Direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("ruta", GetType(String)))
        dt.Columns.Add(New DataColumn("Total", GetType(Double)))
        dt.Columns.Add(New DataColumn("Impresiones", GetType(Double)))
        dt.Columns.Add(New DataColumn("ubicacion_chequeo", GetType(String)))
        dt.Columns.Add(New DataColumn("reenvio", GetType(String)))
        dt.PrimaryKey = New DataColumn() {dt.Columns("Empresa"), dt.Columns("TipoDocto"), dt.Columns("Numero")}

        If (ods.Tables.CanRemove(ods.Tables("facturasAsignadas"))) Then
            ods.Tables.Remove(ods.Tables("facturasAsignadas"))
        End If
        ods.Tables.Add(dt.Copy)
        dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")
    End Sub



    Private Sub dgvFacturasAsignadas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFacturasAsignadas.DoubleClick
        Try
            Dim row As Integer = getSelectedRow(dgvFacturasAsignadas)
            Dim actual, nueva As String
            Dim restar As Double
            Dim facturas As New DataTable

            volumenFacturaActual = dgvFacturasAsignadas.Rows(row).Cells("volumen").Value
            pesoFacturaActual = dgvFacturasAsignadas.Rows(row).Cells("peso").Value

            monto -= dgvFacturasAsignadas.Rows(row).Cells("total").Value
            lblMonto.Text = monto.ToString("C")


            lblVolC.Text = (Decimal.Parse(lblVolC.Text) - volumenFacturaActual).ToString("F")
            lblPesoC.Text = (Decimal.Parse(lblPesoC.Text) - pesoFacturaActual).ToString("F")

            actual = dgvFacturasAsignadas.Item("Número", row).Value.ToString
            For Each dr As DataGridViewRow In dg_facturas.Rows
                If (dr.Cells("numero").Value.ToString.Equals(actual)) Then
                    dr.Visible = True
                    Exit For
                End If
            Next
            ods.Tables("facturasAsignadas").Rows(row).Delete()
            'dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscarHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarHistorico.Click
        llenarGridView(oTrans, "pa_sel_um_facturas_transporte_historico '" & dtpHistorico.Text & "'", dgFacturasHistorico, "", ",correlativo,")
    End Sub

    Private Sub dg_facturas_DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_facturas.CellDoubleClick
        enviarvehiculo(e.RowIndex)
    End Sub


    Private Sub btnGuardarPlanificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarPlanificacion.Click

        Try

            If Me.txNombrePlanificacion.Text.Length > 0 Then
                Me.Cursor = Cursors.WaitCursor

                guardarCambios()


                dgvFacturasAsignadas.DataSource = New DataTable
                dgProductosDetalle.DataSource = New DataTable
                facturasGeneradas = False
                limpiar()
                getRutasDetalle()
                getRutasPlanificadas()
                Me.Cursor = Cursors.Default
            Else
                MessageBox.Show("Debe Agregar Nombre de Planificacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Sub getRutasPlanificadas()
        'Dim otrans As New Transaccional.Conexion("Flexline")
        'Dim clsGen As New ClasesGenerales.General
        ' Dim dt As DataTable
        '  Dim sql As String


        dt = clsgls.selectQuery("flexline", "pa_sel_um_facturas_transporte_planificadas '" & gs_usuario & "'")
        '     sql = "pa_sel_um_facturas_transporte_planificadas '" & gs_usuario & "','"

        dgvPlanificado.DataSource = dt
        clsgls.Alinear_GridView(dt, dgvPlanificado, "", "", "", "", True, True, 400, 20)
        Dim fechita As New Date
        fechita = fechita.Parse(dtFechaInicialFacturas.Text)

        For Each dgPlanifRow As DataGridViewRow In dgvPlanificado.Rows
            Try
                fechita = fechita.Parse(dgPlanifRow.Cells("fechaEntrega").Value.ToString)
                If (fechita < Date.Now.Date) Then
                    'vencidas
                    dgPlanifRow.DefaultCellStyle.ForeColor = Color.Brown
                ElseIf (fechita = Date.Now.Date) Then
                    dgPlanifRow.DefaultCellStyle.ForeColor = Color.Red
                ElseIf (fechita.AddDays(-1) = Date.Now.Date) Then
                    dgPlanifRow.DefaultCellStyle.ForeColor = Color.Orange
                ElseIf (fechita.AddDays(-2) = Date.Now.Date) Then
                    dgPlanifRow.DefaultCellStyle.ForeColor = Color.BurlyWood
                Else
                    dgPlanifRow.DefaultCellStyle.ForeColor = Color.Green
                End If
            Catch ex As Exception
                dgPlanifRow.DefaultCellStyle.ForeColor = Color.Gray
            End Try
        Next


        Try
            Me.dgvRutasPlanificadas.DataSource = dt
            clsgls.Alinear_GridView(dt, dgvRutasPlanificadas, "", "", "", "", True, True, 400, 20)
        Catch ex As Exception

        End Try

        'dt = clsgls.selectQuery("SCM", "select *  from gen_control_transporte_temporal_tmp where estatus = 'PLANIF'")
        'dgPlanificadoDetalle.DataSource = dt
    End Sub


    Private Sub generarAvisoDetalle(psNombrePlanificacion As String, psFehaEntrega As String, piCantidadPlanificada As Integer, piCantidadDetalle As Integer)


        Dim varMotivo As String = "PLANIFICACION CONTROL TRANSPORTE"
        Dim varMensajeAEnviar As String
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL, lsCuentasAvisos, lsCorreo As String
        Dim dtCorreo As DataTable



        Try




            varMensajeAEnviar = "Control Transporte Temporal" & "|" &
                                        "Planificacion : " & psNombrePlanificacion & "|" &
                                        "Fecha Entrega : " & psFehaEntrega & "|" &
                                        "Cantidad Planificada : " & piCantidadPlanificada & "|" &
                                        "Cantidad Detalle : " & piCantidadDetalle & "|" &
                                        "Usuario : " & gs_usuario & "|" &
                                        "Equipo : " & gs_nombre_equipo & "|" &
                                        "Referencia:  Automatizacion Control Transporte" & "|" &
                                        DateAndTime.Now.ToString("dd/MM/yyyy HH:mm:ss")




            lsCuentasAvisos = clsGen.Obtener_XMLConfig("usuarios_avisos_tecnologia", False)

            For Each pscuentafacturacion As String In lsCuentasAvisos.Split(",")

                lsSQL = "pa_sel_um_sg_usuario_email '" & pscuentafacturacion & "'"
                dtCorreo = clsGen.selectQuery("FlexLine", lsSQL)
                lsCorreo = dtCorreo.Rows(0).Item("correo").ToString
                If lsCorreo.Length > 0 Then
                    clsGen.enviarMensajeTeams(lsCorreo, varMotivo, varMensajeAEnviar)
                End If
            Next


        Catch ex As Exception


        End Try

    End Sub

    Private Sub dgPlanificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvPlanificado.Click
        Dim row As Integer
        Dim iCantidadPlanificada As Integer = 0
        Try


            row = getSelectedRow(dgvPlanificado)
            If (row >= 0) Then

                Dim dtDetalle As New DataTable
                Dim dtDetalleRow As DataRow
                iCantidadPlanificada = dgvPlanificado.Rows(row).Cells("facturasAsignadas").Value

                dtDetalle = clsgls.selectQuery("flexline", "pa_sel_um_control_transporte_detalle '" & dgvPlanificado.Rows(row).Cells("nombre_planif").Value.ToString & "','" & dgvPlanificado.Rows(row).Cells("fechaEntrega").Value.ToString & "','" & cmbUbicacion.Text & "'")

                If dtDetalle.Rows.Count > 0 Then
                    If dtDetalle.Rows(0).Item("Tipodoctoorigen").ToString.Equals("DEVOLUCION") Then
                        dtDetalle = clsgls.selectQuery("flexline", "pa_sel_um_control_transporte_detalle_devoluciones '" & dgvPlanificado.Rows(row).Cells("nombre_planif").Value.ToString & "','" & dgvPlanificado.Rows(row).Cells("fechaEntrega").Value.ToString & "'")
                    End If
                    Try


                        If dtDetalle.Rows.Count < iCantidadPlanificada Then
                            generarAvisoDetalle(dgvPlanificado.Rows(row).Cells("nombre_planif").Value.ToString, dgvPlanificado.Rows(row).Cells("fechaEntrega").Value.ToString, iCantidadPlanificada, dtDetalle.Rows.Count)
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    generarAvisoDetalle(dgvPlanificado.Rows(row).Cells("nombre_planif").Value.ToString, dgvPlanificado.Rows(row).Cells("fechaEntrega").Value.ToString, iCantidadPlanificada, 0)
                End If
                Dim dt As DataTable

                dt = New DataTable("FacturasDetalle")
                ' dt.Columns.Add(New DataColumn("Entregado", GetType(Boolean)))
                dt.Columns.Add(New DataColumn("Planificacion", GetType(String)))
                dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
                dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
                dt.Columns.Add(New DataColumn("Numero", GetType(String)))
                dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
                dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
                dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
                dt.Columns.Add(New DataColumn("Direccion", GetType(String)))
                dt.Columns.Add(New DataColumn("referencia_pdv", GetType(String)))
                dt.Columns.Add(New DataColumn("dias_entrega", GetType(String)))
                dt.Columns.Add(New DataColumn("horas_entrega", GetType(String)))

                dt.Columns.Add(New DataColumn("Direccion1", GetType(String)))
                dt.Columns.Add(New DataColumn("Peso", GetType(Double)))
                dt.Columns.Add(New DataColumn("Volumen", GetType(Double)))
                dt.Columns.Add(New DataColumn("Total", GetType(Double)))
                dt.Columns.Add(New DataColumn("Impresiones", GetType(Double)))
                dt.Columns.Add(New DataColumn("ubicacion_chequeo", GetType(String)))
                dt.Columns.Add(New DataColumn("reenvio", GetType(String)))
                Dim newRow As DataRow

                For Each dtDetalleRow In dtDetalle.Rows
                    newRow = dt.NewRow()
                    ' newRow.Item("Entregado") = True
                    newRow.Item("Planificacion") = dtDetalleRow.Item("nombre_planif").ToString
                    newRow.Item("Empresa") = dtDetalleRow.Item("empresa").ToString
                    newRow.Item("Tipodocto") = dtDetalleRow.Item("TipodoctoOrigen").ToString
                    newRow.Item("Numero") = dtDetalleRow.Item("numeroOrigen").ToString
                    newRow.Item("ctacte") = dtDetalleRow.Item("ctacte").ToString
                    newRow.Item("RazonSocial") = dtDetalleRow.Item("razonsocial").ToString
                    newRow.Item("Comentario") = dtDetalleRow.Item("comentario1").ToString
                    newRow.Item("Direccion") = dtDetalleRow.Item("direccion").ToString
                    newRow.Item("Direccion1") = dtDetalleRow.Item("direccion1").ToString
                    newRow.Item("Peso") = dtDetalleRow.Item("peso")
                    newRow.Item("Volumen") = dtDetalleRow.Item("volumen")
                    newRow.Item("Impresiones") = dtDetalleRow.Item("impresiones")
                    newRow.Item("ubicacion_chequeo") = dtDetalleRow.Item("ubicacion_chequeo")
                    newRow.Item("reenvio") = dtDetalleRow.Item("reenvio")
                    newRow.Item("referencia_pdv") = dtDetalleRow.Item("referencia_pdv")
                    newRow.Item("dias_entrega") = dtDetalleRow.Item("dias_entrega")
                    newRow.Item("horas_entrega") = dtDetalleRow.Item("horas_entrega")


                    Try
                        newRow.Item("Total") = Double.Parse(dtDetalleRow.Item("total").ToString)
                        'Si no pudo parsear, no va a meter la row al grid por que se muere
                        'Y ya no muestra nada
                        dt.Rows.Add(newRow)
                    Catch

                    End Try

                Next

                dgPlanificadoDetalle.DataSource = dt

                clsgls.Alinear_GridView(dt, dgPlanificadoDetalle, ",Entregado,Planificacion,Empresa,Tipodocto,Numero,RazonSocial,Comentario,Direccion,Direccion1,Peso,Volumen,Total,impresiones,ubicacion_chequeo,reenvio,referencia_pdv,dias_entrega,horas_entrega," _
                , "", "", "", "", "", "", True, True, 500, 20)
                Dim ix As Integer = 0
                For Each dtDetalleRow In dtDetalle.Rows

                    If dtDetalleRow.Item("estatus").ToString.Equals("GUARD") Then
                        dgPlanificadoDetalle.Rows(ix).DefaultCellStyle.ForeColor = Color.Blue
                    End If
                    ix += 1
                Next

                '(c) validacion



            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgPlanificado_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvPlanificado.DoubleClick
        Dim row As Integer
        row = getSelectedRow(dgvPlanificado)
        Dim clsGen As New ClasesGenerales.General

        If row >= 0 Then
            pesoFacturaActual = 0
            volumenFacturaActual = 0
            monto = 0
            lblVolC.Text = 0
            lblPesoC.Text = 0
            getRutasDetalle()

            Try
                'txNombrePlanificacion.Text = dgPlanificadoDetalle.Rows(0).Cells("Planificacion").Value.ToString
                txNombrePlanificacion.Text = dgvPlanificado.Rows(row).Cells("nombre_planif").Value.ToString()
                dtpFechaEntrega.Text = dgvPlanificado.Rows(row).Cells("fechaEntrega").Value.ToString

            Catch ex As Exception

            End Try

            Dim draux As DataRow
            For Each dgvr As DataGridViewRow In dgPlanificadoDetalle.Rows

                Try


                    draux = ods.Tables("facturasAsignadas").NewRow()
                    draux.Item("seleccionar") = True
                    draux.Item("Empresa") = dgvr.Cells("empresa").Value.ToString
                    'draux.Item("Control de Transporte") = ""
                    draux.Item("ctacte") = dgvr.Cells("ctacte").Value.ToString
                    draux.Item("TipoDocto") = dgvr.Cells("Tipodocto").Value.ToString
                    draux.Item("RazonSocial") = dgvr.Cells("razonsocial").Value.ToString
                    draux.Item("Comentario") = dgvr.Cells("comentario").Value.ToString
                    draux.Item("Direccion") = dgvr.Cells("direccion").Value.ToString
                    draux.Item("Direccion1") = dgvr.Cells("direccion1").Value.ToString
                    draux.Item("Numero") = dgvr.Cells("Numero").Value.ToString
                    draux.Item("Peso") = dgvr.Cells("peso").Value.ToString
                    draux.Item("Volumen") = dgvr.Cells("volumen").Value.ToString
                    draux.Item("Total") = dgvr.Cells("total").Value.ToString
                    draux.Item("impresiones") = dgvr.Cells("impresiones").Value.ToString
                    draux.Item("ubicacion_chequeo") = dgvr.Cells("ubicacion_chequeo").Value.ToString
                    draux.Item("reenvio") = dgvr.Cells("reenvio").Value.ToString
                    'pesoFacturaActual += dgvr.Cells("peso").Value
                    'volumenFacturaActual += dgvr.Cells("volumen").Value
                    'monto += dgvr.Cells("total").Value
                    ods.Tables("facturasAsignadas").Rows.Add(draux)


                    'lblVolC.Text = volumenFacturaActual.ToString("F")
                    'lblPesoC.Text = pesoFacturaActual.ToString("F")
                    'lblMonto.Text = monto.ToString("C")
                    TabControl1.SelectedIndex = 0
                Catch ex As Exception
                    clsGen.Escribir_Log(ex.ToString)
                    clsGen.Escribir_Log(ex.Message)
                End Try
            Next
            'dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")

            clsgls.Alinear_GridView(ods.Tables("facturasAsignadas"), dgvFacturasAsignadas, "", "", "", "", "", ",seleccionar=20,empresa=38,tipodocto=50,", "", True, True, 200, 10)



            lblMonto.Text = calculaMontosRuta.ToString("F")
        End If


    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
        getRutasDetalle()
    End Sub

    Private Sub limpiar()
        pesoFacturaActual = 0
        volumenFacturaActual = 0
        monto = 0
        lblVolC.Text = 0
        lblPesoC.Text = 0
        txNombrePlanificacion.Text = ""
        lblMonto.Text = "0"
        Me.lblToneladas.Text = "0"
        Try
            dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")
            getRutasDetalle()
            facturasGeneradas = True
            'sumarPesosVehiculo()
            ' lblMonto.Text = "Monto: " & (getMontoActual()).ToString
            getRutasPlanificadas()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting

        getRutasPlanificadas()

    End Sub

    Private Sub btnQuitardeRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitardeRuta.Click
        Dim row As Integer
        Dim tipodocto, sql, numero, empresa As String

        row = getSelectedRow(dgPlanificadoDetalle)
        If (row >= 0) Then

            tipodocto = dgPlanificadoDetalle.Rows(row).Cells("TipoDocto").Value.ToString
            numero = dgPlanificadoDetalle.Rows(row).Cells("Numero").Value.ToString
            empresa = dgPlanificadoDetalle.Rows(row).Cells("Empresa").Value.ToString

            sql = "pa_var_um_quitarderuta '" & empresa & "','" & tipodocto & "','" & numero & "','" & gs_usuario & "'"
            clsgls.dbQuery("flexline", sql, "DELETE")
            dgPlanificadoDetalle.CurrentCell = Nothing
            dgPlanificadoDetalle.Rows(row).Visible = False
            getRutasPlanificadas()
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim tipodocto, sql, numero, empresa As String
        dgPlanificadoDetalle.CurrentCell = Nothing
        For Each dgRow As DataGridViewRow In dgPlanificadoDetalle.Rows

            If (dgRow.Cells("Entregado").Value) Then

                tipodocto = dgRow.Cells("TipoDocto").Value.ToString
                numero = dgRow.Cells("Numero").Value.ToString
                empresa = dgRow.Cells("Empresa").Value.ToString
                'si no la selecciono, significa que tengo que reenviarla
                sql = "pa_var_um_cambiar_ruta_estatus '" & empresa & "','" & tipodocto & "','" & numero & "','REENVI'"
                clsgls.dbQuery("flexline", sql, "UPDATE")

            Else
                tipodocto = dgRow.Cells("TipoDocto").Value.ToString
                numero = dgRow.Cells("Numero").Value.ToString
                empresa = dgRow.Cells("Empresa").Value.ToString
                'si la selecciono tengo que marcarla como entregada
                sql = "pa_var_um_cambiar_ruta_estatus '" & empresa & "','" & tipodocto & "','" & numero & "','ENTREG'"
                clsgls.dbQuery("flexline", sql, "UPDATE")


            End If

        Next
    End Sub

    Public Sub Imprimir_Control(ByVal numTrans As String)
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim dtEmpresas As DataTable

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            path_reporte = ClsGen.Path_Reporte()

            path_reporte += "Logistica\Trafico\Guía del Liquidador Global Citizen.rpt"
            pm_parametros(0) = "Numero de Documento"

            pm_valores(0) = numTrans

            Dim ncopias As Integer = 3
            Try
                ncopias = ClsGen.Obtener_XMLConfig("numero_copias_guias", False)
            Catch ex As Exception

            End Try

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True, 3)
            'Next
        Catch ex As Exception
        Finally
            ClsGen = Nothing

        End Try


    End Sub

    Private Sub BuscarOrdenesWalmart()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim myOtrans As New Transaccional.Conexion_mysql("Onbase")
        Dim lsSQL As String
        Dim dt As DataTable
        Try
            Otrans.open()
            myOtrans.open()
            lsSQL = "pa_var_um_facturas_oc_edifact '" & Me.dtFechaFinalFacturas.Value.ToString("dd/MM/yyyy") & "','" & Me.dtFechaFinalFacturas.Value.ToString("dd/MM/yyyy") & "'"
            dtOrdenes = Otrans.Obtiene(lsSQL)
            If dtOrdenes.Rows.Count > 0 Then
                dtOrdenes.Columns.Add(New DataColumn("Imprimir", GetType(Boolean)))
                dtOrdenes.Columns.Add(New DataColumn("numero_oc", GetType(String)))
                dtOrdenes.Columns.Add(New DataColumn("usuario_impresion", GetType(String)))
                dtOrdenes.Columns.Add(New DataColumn("idempresalocal", GetType(String)))
                For Each dr As DataRow In dtOrdenes.Rows
                    dr.Item("usuario_impresion") = String.Empty
                    lsSQL = "call pa_var_um_mov_edi_pedido_wm ('" & dr.Item("empresa").ToString & "','" &
                        dr.Item("tipo_pedido").ToString & "','" & dr.Item("numero_pedido").ToString & "','" & dr.Item("ctacte") & "')"
                    dt = myOtrans.Obtiene(lsSQL)
                    If dt.Rows.Count > 0 Then
                        dr.Item("numero_oc") = dt.Rows(0).Item("idtransaccion")
                        dr.Item("usuario_impresion") = dt.Rows(0).Item("usuarioimpresion_tr").ToString
                        dr.Item("idempresalocal") = dt.Rows(0).Item("idempresalocal").ToString
                    End If
                Next
                dtOrdenes.DefaultView.Sort = "minutos desc"
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub
    Private Sub imprimirOrdenes()
        Dim myOtrans As New Transaccional.Conexion_mysql("OnBase")
        Try
            myOtrans.open()
            dtOrdenes.DefaultView.RowFilter = "imprimir = true"
            For Each drv As DataRowView In dtOrdenes.DefaultView
                Imprimir_Ordenes(drv.Item("empresa").ToString, drv.Item("numero_oc").ToString, drv.Item("idempresalocal").ToString)
                myOtrans.Actualiza("call pa_upd_um_edi_pedido_encabezado_trs ('" & drv.Item("Empresa").ToString & "','" & drv.Item("numero_oc").ToString & "','" & gs_usuario & "','" & drv.Item("idempresalocal").ToString & "')")
            Next
        Catch ex As Exception
        Finally
            myOtrans.close()
            myOtrans = Nothing
            BuscarOrdenesWalmart()
        End Try
    End Sub

    Public Sub Imprimir_Ordenes(ByVal spEmpresa As String, ByVal spOrdendeCompra As String, ByVal cliente_ As String)
        Dim path_reporte As String
        Dim pm_valores(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Try
            pm_conexion = ClsGen.Parametros_Conexion("Onbase")
            path_reporte = ClsGen.Path_Reporte()
            path_reporte += "Direccion Comercial\edifact.rpt"
            pm_parametros(0) = "empresa"
            pm_parametros(1) = "cod_pedido"
            pm_parametros(2) = "cliente"

            pm_valores(0) = spEmpresa
            pm_valores(1) = spOrdendeCompra
            pm_valores(2) = cliente_

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores,
                            pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                            False, True, "PDF", False, "", True)

        Catch ex As Exception
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub SeleccionarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarToolStripMenuItem.Click
        Dim oform As New frm_separar_factura_transporte
        oform.Show()
    End Sub

    Private Sub QuitarDeAntiguoControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitarDeAntiguoControlToolStripMenuItem.Click
        Dim oform As New frm_reenvioAutomatizacion
        oform.Show()


    End Sub

    Private Sub dgFacturasHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgFacturasHistorico.Click
        Dim row As Integer
        row = getSelectedRow(dgFacturasHistorico)
        If (row >= 0) Then

            Dim dtDetalle As New DataTable
            Dim dtDetalleRow As DataRow
            dtDetalle = clsgls.selectQuery("flexline", "pa_sel_um_control_transporte_detalle_historico '" & dgFacturasHistorico.Rows(row).Cells("nombre_planif").Value.ToString & "','" & dgFacturasHistorico.Rows(row).Cells("fechaEntrega").Value.ToString & "'")

            Dim dt As DataTable

            dt = New DataTable("FacturasDetalle")
            ' dt.Columns.Add(New DataColumn("Entregado", GetType(Boolean)))

            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
            dt.Columns.Add(New DataColumn("Numero", GetType(String)))
            dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
            dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
            dt.Columns.Add(New DataColumn("Direccion", GetType(String)))
            dt.Columns.Add(New DataColumn("Direccion1", GetType(String)))
            dt.Columns.Add(New DataColumn("Peso", GetType(Double)))
            dt.Columns.Add(New DataColumn("Volumen", GetType(Double)))
            dt.Columns.Add(New DataColumn("Total", GetType(Double)))
            dt.Columns.Add(New DataColumn("usuario_planifica", GetType(String)))
            dt.Columns.Add(New DataColumn("Planificacion", GetType(String)))
            dt.Columns.Add(New DataColumn("control", GetType(String)))
            Dim newRow As DataRow

            For Each dtDetalleRow In dtDetalle.Rows
                newRow = dt.NewRow()
                ' newRow.Item("Entregado") = True
                newRow.Item("Planificacion") = dtDetalleRow.Item("nombre_planif").ToString
                newRow.Item("Empresa") = dtDetalleRow.Item("empresa").ToString
                newRow.Item("Tipodocto") = dtDetalleRow.Item("TipodoctoOrigen").ToString
                newRow.Item("ctacte") = dtDetalleRow.Item("ctacte").ToString
                newRow.Item("Numero") = dtDetalleRow.Item("numeroOrigen").ToString
                newRow.Item("RazonSocial") = dtDetalleRow.Item("razonsocial").ToString
                newRow.Item("Comentario") = dtDetalleRow.Item("comentario1").ToString
                newRow.Item("Direccion") = dtDetalleRow.Item("direccion").ToString
                newRow.Item("Direccion1") = dtDetalleRow.Item("direccion1").ToString
                newRow.Item("Peso") = dtDetalleRow.Item("peso").ToString
                newRow.Item("Volumen") = dtDetalleRow.Item("volumen").ToString
                newRow.Item("Total") = Double.Parse(dtDetalleRow.Item("total").ToString)
                newRow.Item("Control") = dtDetalleRow.Item("numero").ToString
                newRow.Item("usuario_planifica") = dtDetalleRow.Item("usuario_planifica").ToString
                dt.Rows.Add(newRow)
            Next

            dgHistoricoDetalle.DataSource = dt

            clsgls.Alinear_GridView(dt, dgHistoricoDetalle, ",Entregado,Planificacion,Empresa,Tipodocto,Numero,RazonSocial,Comentario,Direccion,Direccion1,Peso,Volumen,Total,control,usuario_planifica," _
            , "", "", "", "", "", "", True, True, 200, 20)
            ',razonsocial=150,empresa=38,tipodocto=50,comentario=150,direccion=150,direccion1=150,
            Dim ix As Integer = 0

        End If
    End Sub



    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            If ods.Tables("facturasAsignadas").Rows.Count > 0 And Me.txNombrePlanificacion.Text.Trim.Length > 0 Then
                If MessageBox.Show("Esta Seguro de Procesar La Orden", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim oform As New frm_automatizarTransporteGuia
                    oform.pdt = ods.Tables("facturasasignadas")
                    oform.dgvFacturasAsignadas.DataSource = oform.pdt 'ods.Tables("facturasasignadas")
                    oform.ShowDialog()
                    oform = Nothing
                    limpiar()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNumeroVerifica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroVerifica.KeyPress

        If e.KeyChar = Chr(13) Or txtNumeroVerifica.Text.Length = 12 Then


            Dim ls_sql As String
            Dim dt As DataTable

            Dim otrans As New Transaccional.Conexion("flexline")
            Dim clsgen As New ClasesGenerales.General
            Try

                otrans.open()
                ls_sql = "pa_var_um_documento_control_transporte  '" & Me.cmbEmpresaVerifica.SelectedValue & "','" & Me.cmbTipoDoctoVerifica.Text & "','" & Me.txtNumeroVerifica.Text & "'"

                dt = clsgen.selectQuery("FlexLine", ls_sql)
                Me.dgvControlesVerifica.DataSource = dt
                clsgen.Alinear_GridView(dt, Me.dgvControlesVerifica, ",tipodocto,numero,nombre_cliente,numero_temporal,nombre_planif,numero_final,", "", "", "", "", "", "", True, True, 250, 0)


            Catch ex As Exception
            Finally
                otrans.close()
                otrans = Nothing


            End Try
            Me.txtNumeroVerifica.SelectAll()

        End If
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim nrow As Integer = Me.dg_facturas.CurrentRow.Index
            If MessageBox.Show("Esta Seguro que la Factura " & Me.dg_facturas.Item("numero", nrow).Value.ToString & " La Recogera El Cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim clsgen As New ClasesGenerales.General
                Dim lsSQL As String

                lsSQL = "pa_upd_um_documento_analisis_transporte '" &
                Me.dg_facturas.Item("empresa", nrow).Value.ToString & "','" &
                Me.dg_facturas.Item("tipodocto", nrow).Value.ToString & "','" &
                Me.dg_facturas.Item("numero", nrow).Value.ToString & "','" &
                    gs_usuario & "',null,'Cliente Recoge'"

                clsgen.insertQuery("FlexLine", lsSQL)
                clsgen = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            'se llenara el analisise26 del documento para no mostrar esos
            Dim nrow As Integer = Me.dg_facturas.CurrentRow.Index
            If MessageBox.Show("Esta Seguro que la Factura " & Me.dg_facturas.Item("numero", nrow).Value.ToString & " El Vendedor la Entregara", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim clsgen As New ClasesGenerales.General
                Dim lsSQL As String

                lsSQL = "pa_upd_um_documento_analisis_transporte '" &
                Me.dg_facturas.Item("empresa", nrow).Value.ToString & "','" &
                Me.dg_facturas.Item("tipodocto", nrow).Value.ToString & "','" &
                Me.dg_facturas.Item("numero", nrow).Value.ToString & "','" &
                    gs_usuario & "',null,'Vendedor Entrega'"

                clsgen.insertQuery("FlexLine", lsSQL)
                clsgen = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDevolucionesPendientes_Click(sender As Object, e As EventArgs) Handles btnDevolucionesPendientes.Click
        llenarDevolucionesPendientes()
    End Sub

    Private Sub btnAsignarDevolucion_Click(sender As Object, e As EventArgs) Handles btnAsignarDevolucion.Click
        'convertirDevolucion()
    End Sub

    Private Sub dg_facturas_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dg_facturas.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dg_facturas.Rows(rowIndex)


                If Me.dg_facturas.Item("factura_costo", rowIndex).Value > 0 Then
                    Me.dg_facturas.Rows(rowIndex).DefaultCellStyle.BackColor = Color.YellowGreen
                End If
                If Me.dg_facturas.Item("reenvio", rowIndex).Value = "SI" Then
                    Me.dg_facturas.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightSteelBlue
                End If

                If Me.dg_facturas.Item("impresiones", rowIndex).Value > 0 Then
                    Me.dg_facturas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                ElseIf Me.dg_facturas.Item("ubicacion_chequeo", rowIndex).Value.ToString.Length > 0 Then
                    Me.dg_facturas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If

            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenarDetallePlanificacion(psNombrePlanificacion As String, psFechaEntrega As String, psUbicacion As String)
        Try


            Dim row As Integer
            'row = getSelectedRow(dgvPlanificado)
            'If (row >= 0) Then

            Dim dtDetalle As New DataTable
            Dim dtDetalleRow As DataRow
            dtDetalle = clsgls.selectQuery("flexline", "pa_sel_um_control_transporte_detalle '" & psNombrePlanificacion & "','" & psFechaEntrega & "','" & psUbicacion & "'")
            If dtDetalle.Rows.Count > 0 Then
                'If dtDetalle.Rows(0).Item("Tipodoctoorigen").ToString.Equals("DEVOLUCION") Then
                '    dtDetalle = clsgls.selectQuery("flexline", "pa_sel_um_control_transporte_detalle_devoluciones '" & dgvPlanificado.Rows(row).Cells("nombre_planif").Value.ToString & "','" & dgvPlanificado.Rows(row).Cells("fechaEntrega").Value.ToString & "'")
                'End If
            End If
            Dim dt As DataTable

            dt = New DataTable("FacturasDetalle")
            ' dt.Columns.Add(New DataColumn("Entregado", GetType(Boolean)))
            dt.Columns.Add(New DataColumn("Planificacion", GetType(String)))
            dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
            dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
            dt.Columns.Add(New DataColumn("Numero", GetType(String)))
            dt.Columns.Add(New DataColumn("ctacte", GetType(String)))
            dt.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
            dt.Columns.Add(New DataColumn("Comentario", GetType(String)))
            dt.Columns.Add(New DataColumn("Direccion", GetType(String)))
            dt.Columns.Add(New DataColumn("referencia_pdv", GetType(String)))
            dt.Columns.Add(New DataColumn("dias_entrega", GetType(String)))
            dt.Columns.Add(New DataColumn("horas_entrega", GetType(String)))
            dt.Columns.Add(New DataColumn("Direccion1", GetType(String)))
            dt.Columns.Add(New DataColumn("Peso", GetType(Double)))
            dt.Columns.Add(New DataColumn("Volumen", GetType(Double)))
            dt.Columns.Add(New DataColumn("Total", GetType(Double)))
            dt.Columns.Add(New DataColumn("Impresiones", GetType(Double)))
            dt.Columns.Add(New DataColumn("ubicacion_chequeo", GetType(String)))
            dt.Columns.Add(New DataColumn("reenvio", GetType(String)))

            Dim newRow As DataRow

            For Each dtDetalleRow In dtDetalle.Rows

                newRow = dt.NewRow()
                ' newRow.Item("Entregado") = True
                newRow.Item("Planificacion") = dtDetalleRow.Item("nombre_planif").ToString
                newRow.Item("Empresa") = dtDetalleRow.Item("empresa").ToString
                newRow.Item("Tipodocto") = dtDetalleRow.Item("TipodoctoOrigen").ToString
                newRow.Item("Numero") = dtDetalleRow.Item("numeroOrigen").ToString
                newRow.Item("ctacte") = dtDetalleRow.Item("ctacte").ToString
                newRow.Item("RazonSocial") = dtDetalleRow.Item("razonsocial").ToString
                newRow.Item("Comentario") = dtDetalleRow.Item("comentario1").ToString
                newRow.Item("Direccion") = dtDetalleRow.Item("direccion").ToString
                newRow.Item("Direccion1") = dtDetalleRow.Item("direccion1").ToString
                newRow.Item("Peso") = dtDetalleRow.Item("peso")
                newRow.Item("Volumen") = dtDetalleRow.Item("volumen")
                newRow.Item("impresiones") = dtDetalleRow.Item("impresiones")
                newRow.Item("ubicacion_chequeo") = dtDetalleRow.Item("ubicacion_chequeo")
                newRow.Item("reenvio") = dtDetalleRow.Item("reenvio")
                newRow.Item("referencia_pdv") = dtDetalleRow.Item("referencia_pdv")
                newRow.Item("dias_entrega") = dtDetalleRow.Item("dias_entrega")
                newRow.Item("horas_entrega") = dtDetalleRow.Item("horas_entrega")




                Try
                    newRow.Item("Total") = Double.Parse(dtDetalleRow.Item("total").ToString)
                    'Si no pudo parsear, no va a meter la row al grid por que se muere
                    'Y ya no muestra nada
                    dt.Rows.Add(newRow)
                Catch

                End Try

            Next

            dgPlanificadoDetalle.DataSource = dt

            clsgls.Alinear_GridView(dt, dgPlanificadoDetalle, ",Entregado,Planificacion,Empresa,Tipodocto,Numero,RazonSocial,Comentario,Direccion,Direccion1,Peso,Volumen,Total,impresiones,ubicacion_chequeo,reenvio,referencia_pdv,dias_entrega,horas_entrega," _
                , "", "", "", "", "", "", True, True, 500, 20)
            Dim ix As Integer = 0
            For Each dtDetalleRow In dtDetalle.Rows

                If dtDetalleRow.Item("estatus").ToString.Equals("GUARD") Then
                    dgPlanificadoDetalle.Rows(ix).DefaultCellStyle.ForeColor = Color.Blue
                End If
                ix += 1
            Next
            ' E'nd If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBatch_Click(sender As Object, e As EventArgs) Handles btnBatch.Click
        Dim iSelectedRow As Integer
        Dim sTipodocto, sEmpresa, sNumero, lsBodega, slCedi As String
        Dim dt As DataTable
        Dim clsGen As New ClasesGenerales.General
        Dim slistaPrecios As String

        Try

            iSelectedRow = Me.dg_facturas.Rows.GetRowCount(DataGridViewElementStates.Selected)

            For irow As Integer = 0 To iSelectedRow

                Try


                    slCedi = String.Empty


                    calculaPesoyVolumen(dg_facturas.Item("empresa", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString,
                                        dg_facturas.Item("tipodocto", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString,
                                        dg_facturas.Item("numero", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString)

                    Dim draux As DataRow
                    draux = ods.Tables("facturasAsignadas").NewRow()
                    draux.Item("seleccionar") = True


                    draux.Item("Empresa") = dg_facturas.Item("empresa", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    'draux.Item("Control de Transporte") = ""
                    draux.Item("TipoDocto") = dg_facturas.Item("tipodocto", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("ctacte") = dg_facturas.Item("ctacte", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("RazonSocial") = dg_facturas.Item("nombre_cliente", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("Comentario") = dg_facturas.Item("comentario1", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("Direccion") = dg_facturas.Item("direccion", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("Direccion1") = dg_facturas.Item("direccion1", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("Numero") = dg_facturas.Item("numero", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("Peso") = lblPeso.Text.Substring(5)
                    draux.Item("Volumen") = lblVolumen.Text.Substring(8)
                    draux.Item("Total") = dg_facturas.Item("total", Me.dg_facturas.SelectedRows(irow).Index).Value.ToString
                    draux.Item("ruta") = dg_facturas.Item("ruta_logistica", Me.dg_facturas.SelectedRows(irow).Index).Value
                    draux.Item("reenvio") = dg_facturas.Item("reenvio", Me.dg_facturas.SelectedRows(irow).Index).Value
                    ods.Tables("facturasAsignadas").Rows.Add(draux)


                    'dg_facturas.Item("mostrar", Me.dg_facturas.SelectedRows(irow).Index).Value = 0
                Catch ex As Exception

                End Try


            Next

            clsgls.Alinear_GridView(ods.Tables("facturasAsignadas"), dgvFacturasAsignadas, "", "", "", "", "", ",seleccionar=20,empresa=38,tipodocto=50,", "", True, True, 200, 10)


            lblMonto.Text = calculaMontosRuta.ToString("C")


            ocultarFacturasAsignadas()


        Catch ex As Exception

        End Try


    End Sub

    Private Sub RecogeEnBodegaZona13ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecogeEnBodegaZona13ToolStripMenuItem.Click
        enviarFactura_area("BODEGA ZONA 13")
    End Sub

    Private Sub RecogeEnCajaZona13ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecogeEnCajaZona13ToolStripMenuItem.Click
        enviarFactura_area("CAJA ZONA 13")
    End Sub

    Private Sub RecogeEnFacturacionZona13ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecogeEnFacturacionZona13ToolStripMenuItem.Click
        enviarFactura_area("FACTURACION ZONA 13")
    End Sub

    Private Sub enviarFactura_area(psArea As String)

        Try

            Dim nrow As Integer = Me.dg_facturas.CurrentRow.Index
            If MessageBox.Show("Esta Seguro que la Factura " & Me.dg_facturas.Item("numero", nrow).Value.ToString & " La Recogera El Cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim clsgen As New ClasesGenerales.General
                Dim lsSQL As String

                lsSQL = "pa_upd_um_documento_analisis_transporte '" &
                    Me.dg_facturas.Item("empresa", nrow).Value.ToString & "','" &
                    Me.dg_facturas.Item("tipodocto", nrow).Value.ToString & "','" &
                    Me.dg_facturas.Item("numero", nrow).Value.ToString & "','" &
                       gs_usuario & "',null,null,'" & psArea & "'"

                clsgen.insertQuery("FlexLine", lsSQL)
                clsgen = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvRutasPlanificadas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRutasPlanificadas.CellDoubleClick
        Dim lirow As Integer

        Try
            lirow = dgvRutasPlanificadas.CurrentRow.Index


            Try
                'txNombrePlanificacion.Text = dgPlanificadoDetalle.Rows(0).Cells("Planificacion").Value.ToString
                'dtpFechaEntrega.Text = dgvPlanificado.Rows(0).Cells("fechaEntrega").Value.ToString
                txNombrePlanificacion.Text = dgvRutasPlanificadas.Item("nombre_planif", lirow).Value
                dtpFechaEntrega.Text = Me.dgvRutasPlanificadas.Item("fechaentrega", lirow).Value
            Catch ex As Exception

            End Try

            llenarDetallePlanificacion(Me.dgvRutasPlanificadas.Item("nombre_planif", lirow).Value, Me.dgvRutasPlanificadas.Item("fechaentrega", lirow).Value, cmbUbicacion.Text)


            'nrow = getSelectedRow(dgvPlanificado)
            If lirow >= 0 Then
                pesoFacturaActual = 0
                volumenFacturaActual = 0
                monto = 0
                lblVolC.Text = 0
                lblPesoC.Text = 0
                getRutasDetalle()
                Dim draux As DataRow
                For Each dgvr As DataGridViewRow In dgPlanificadoDetalle.Rows

                    draux = ods.Tables("facturasAsignadas").NewRow()
                    draux.Item("seleccionar") = True
                    draux.Item("Empresa") = dgvr.Cells("empresa").Value.ToString
                    'draux.Item("Control de Transporte") = ""
                    draux.Item("ctacte") = dgvr.Cells("ctacte").Value.ToString
                    draux.Item("TipoDocto") = dgvr.Cells("Tipodocto").Value.ToString
                    draux.Item("RazonSocial") = dgvr.Cells("razonsocial").Value.ToString
                    draux.Item("Comentario") = dgvr.Cells("comentario").Value.ToString
                    draux.Item("Direccion") = dgvr.Cells("direccion").Value.ToString
                    draux.Item("Direccion1") = dgvr.Cells("direccion1").Value.ToString
                    draux.Item("Numero") = dgvr.Cells("Numero").Value.ToString
                    draux.Item("Peso") = dgvr.Cells("peso").Value.ToString
                    draux.Item("Volumen") = dgvr.Cells("volumen").Value.ToString
                    draux.Item("Total") = dgvr.Cells("total").Value.ToString
                    draux.Item("impresiones") = dgvr.Cells("impresiones").Value.ToString
                    draux.Item("ubicacion_chequeo") = dgvr.Cells("ubicacion_chequeo").Value.ToString
                    draux.Item("reenvio") = dgvr.Cells("reenvio").Value.ToString
                    draux.Item("referencia_pdv") = dgvr.Cells("referencia_pdv").Value.ToString
                    draux.Item("dias_entrega") = dgvr.Cells("dias_entrega").Value.ToString
                    draux.Item("horas_entrega") = dgvr.Cells("horas_entrega").Value.ToString


                    ods.Tables("facturasAsignadas").Rows.Add(draux)


                Next
                'dgvFacturasAsignadas.DataSource = ods.Tables("facturasAsignadas")

                clsgls.Alinear_GridView(ods.Tables("facturasAsignadas"), dgvFacturasAsignadas, "", "", "", "", "", ",seleccionar=20,empresa=38,tipodocto=50,", "", True, True, 200, 10)


                lblMonto.Text = calculaMontosRuta.ToString("F")
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub dgPlanificadoDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgPlanificadoDetalle.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgPlanificadoDetalle.Rows(rowIndex)

                If Me.dgPlanificadoDetalle.Item("impresiones", rowIndex).Value > 0 Then
                    Me.dgPlanificadoDetalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                ElseIf Me.dgPlanificadoDetalle.Item("ubicacion_chequeo", rowIndex).Value.ToString.Length > 0 Then
                    Me.dgPlanificadoDetalle.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If

                If Me.dgPlanificadoDetalle.Item("reenvio", rowIndex).Value = "SI" Then
                    Me.dgPlanificadoDetalle.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightSteelBlue
                End If

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub chk_Pick_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Pick.CheckedChanged
        Try
            If Me.chkDevoluciones.Checked = True Then
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvFacturasAsignadas_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvFacturasAsignadas.CellPainting
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow

        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvFacturasAsignadas.Rows(rowIndex)

                If Me.dgvFacturasAsignadas.Item("impresiones", rowIndex).Value > 0 Then
                    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Red
                ElseIf Me.dgvFacturasAsignadas.Item("ubicacion_chequeo", rowIndex).Value.ToString.Length > 0 Then
                    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If
                If Me.dgvFacturasAsignadas.Item("reenvio", rowIndex).Value = "SI" Then
                    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightSteelBlue
                End If

                'If Me.dgvFacturasAsignadas.Item("facturas_asignadas", rowIndex).Value.ToString.Length > 0 Then
                '    Me.dgvFacturasAsignadas.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Green



                'End If
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub mostrarReenvios()

    End Sub

    Private Sub btnReenvios_Click(sender As Object, e As EventArgs)
        mostrarReenvios()

    End Sub

    Private Sub bntGenerarReenvios_Click(sender As Object, e As EventArgs) Handles bntGenerarReenvios.Click
        Dim clsgen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            lsSQL = String.Format("exec pa_sel_um_reenvios_pendientes '{0}', '{1}'", Me.dtpFechaI_reenvio.Value.ToString("dd/MM/yyyy"), Me.dtpfechaf_reenvio.Value.ToString("dd/MM/yyyy"))
            dt = clsgen.selectQuery("Flexline", lsSQL)



            dt.TableName = "reenvios"

            If (ods.Tables.CanRemove(ods.Tables("reenvios"))) Then
                ods.Tables.Remove(ods.Tables("reenvios"))
            End If
            dt.Columns.Add(New DataColumn("seleccionar", GetType(Boolean)))
            For Each dr As DataRow In dt.Rows
                dr.Item("Seleccionar") = False
            Next

            ods.Tables.Add(dt.Copy)
            Me.dgvReenvios.DataSource = ods.Tables("reenvios").DefaultView


            clsgls.Alinear_GridView(ods.Tables("reenvios"), Me.dgvReenvios, ",seleccionar,recibido,empresa,tipodocto,numero,nombre_cliente,fecha,comentario1,direccion,direccion1,total,ruta_logistica,fecha_entrega,impresiones,ubicacion_chequeo,",
                "", "", "", "", ",empresa=40,tipodocto=70,fecha=80,", "", True, True, 400, 10)

        Catch ex As Exception

        End Try


        Try
            dt = clsgls.selectQuery("flexline", "pa_sel_um_facturas_transporte_planificadas")
            Me.dgvRutasPlanificadasReenvios.DataSource = dt
            clsgls.Alinear_GridView(dt, dgvRutasPlanificadasReenvios, "", "", "", "", True, True, 400, 20)

        Catch ex As Exception

        End Try
    End Sub



    Private Sub txtNumeroFacturaReenvio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroFacturaReenvio.KeyPress

        If e.KeyChar = Chr(13) Then

            Me.txtNumeroFacturaReenvio.Text = Me.txtNumeroFacturaReenvio.Text.PadLeft(10, "0").Trim

            Try
                For Each dr In ods.Tables("reenvios").Rows
                    If dr.Item("numero") = Me.txtNumeroFacturaReenvio.Text Then
                        dr.Item("seleccionar") = True
                        Exit Try
                    End If
                Next

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub dg_facturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_facturas.CellContentClick

    End Sub

    Private Sub btnAplicarRecepcion_Click(sender As Object, e As EventArgs) Handles btnAplicarRecepcion.Click
        ods.Tables("reenvios").DefaultView.RowFilter = "seleccionar = true"

        If MessageBox.Show("Esta Seguro que Recibio los Documentos", "Validacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim clsGen As New ClasesGenerales.General
            Dim lsSQL As String


            For Each drv As DataRowView In ods.Tables("reenvios").DefaultView
                Try
                    lsSQL = String.Format("exec pa_ins_um_Reenvios_recepcion '{0}', '{1}','{2}','{3}','{4}', '{5}'",
                                          drv.Item("empresa"), drv.Item("tipodocto"), drv.Item("numero"),
                                          drv.Item("control_transporte"), gs_usuario, gs_nombre_equipo)


                    clsGen.insertQuery("SCM", lsSQL)




                Catch ex As Exception

                End Try

            Next

        End If

        ods.Tables("reenvios").DefaultView.RowFilter = ""
    End Sub

    Private Sub dgvReenvios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReenvios.CellContentClick

    End Sub

    Private Sub dgvPlanificado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPlanificado.CellContentClick

    End Sub

    Private Sub dgvFacturasAsignadas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturasAsignadas.CellContentClick

    End Sub

    Private Sub dgPlanificadoDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPlanificadoDetalle.CellContentClick

    End Sub

    Private Sub dgvRutasPlanificadas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRutasPlanificadas.CellContentClick

    End Sub

    Private Sub dgvReenvios_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvReenvios.CellPainting

        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                therow = Me.dgvReenvios.Rows(rowIndex)


                If Me.dgvReenvios.Item("seleccionar", rowIndex).Value = True Then
                    Me.dgvReenvios.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Blue
                End If

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvPlanificado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPlanificado.CellDoubleClick

    End Sub

    Private Sub dgvPlanificado_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles dgvPlanificado.ChangeUICues

    End Sub

    Private Sub dgvFacturasAsignadas_ContextMenuChanged(sender As Object, e As EventArgs) Handles dgvFacturasAsignadas.ContextMenuChanged

    End Sub

    Private Sub dgvFacturasAsignadas_CursorChanged(sender As Object, e As EventArgs) Handles dgvFacturasAsignadas.CursorChanged

    End Sub
End Class