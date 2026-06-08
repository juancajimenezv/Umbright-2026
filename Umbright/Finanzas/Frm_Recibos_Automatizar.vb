Imports System.Linq

Public Class Frm_Recibos_Automatizar
    Public Empresa As String = ""
    Public Recibo As String = ""
    Public TipoDocto As String = ""
    Public Fecha As String = ""
    Public Numero As String = ""
    Public Cliente As String = ""
    Public Nombre As String = ""
    Public Monto As String = ""
    Public Estado As Integer = 0
    Public t3Lote As Integer

    Public dlote As Integer
    Public dTipoDocto As String
    Public dNumero As String
    Public destado As Integer

    Dim _dtRecibos As DataTable
    Dim _dtFact As DataTable
    Dim _dtCambioFecha As DataTable

    Dim _dtAutoRecibos As DataTable
    Dim _dtAutoFact As DataTable
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "ROOT"
    Dim Pass As String = "Admin.$."


    Private Sub Frm_Recibos_Automatizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combbox_crea()
        CreaTabla()
        Inicial()
        Desactiva_Grupos()
        gb_Contraseña.Enabled = False
        gb_Contraseña.Visible = False

        gpbCambiarFecha.Enabled = False
        gpb_ActivarCambio.Enabled = False

        Me.StatusBarPanel1.Text = System.Configuration.ConfigurationManager.AppSettings("ubicacion").ToString & " " & Application.ProductVersion
        Me.StatusBarPanel2.Text = "Usuario .: (" & gs_usuario & ") " & gs_nombre_usuario
        Me.StatusBarPanel3.Text = "Fecha Actual .: " & Now.ToLongDateString

        GroupBox12.Enabled = False
        GroupBox13.Enabled = False
        GroupBox14.Enabled = False
        GroupBox15.Enabled = False
        btn_AutoActualizar.Enabled = False
        btnProcesar.Enabled = False

    End Sub

    Private Sub Inicial()
        tb_Lote.Enabled = False
        gp_Recibo.Enabled = False
        gp_Valores.Enabled = False
        gp_Detalle.Enabled = False
        tb_Recibo.Enabled = False
        tb_Cliente.Enabled = False
        btn_Regresar.Enabled = False

        gb_Contraseña.Enabled = False
        gb_Contraseña.Visible = False
        tb_Constraseña.Text = ""

        tb_TipoDocto.Enabled = False
        tb_Numero.Enabled = False
        tb_Fecha.Enabled = False
        tb_MontoRm.Enabled = False
        btn_AgregarRm.Enabled = False
        tb_Lote.Focus()
    End Sub

    Private Sub Busca_Recibos_Electronicos()

    End Sub

    Private Sub CreaTabla()
        _dtRecibos = New DataTable("Tmp_Recibos")

        _dtRecibos.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtRecibos.Columns.Add(New DataColumn("Recibo", GetType(String)))
        _dtRecibos.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        _dtRecibos.Columns.Add(New DataColumn("Fecha", GetType(String)))
        _dtRecibos.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtRecibos.Columns.Add(New DataColumn("Cliente", GetType(String)))
        _dtRecibos.Columns.Add(New DataColumn("Nombre", GetType(String)))
        _dtRecibos.Columns.Add(New DataColumn("Monto", GetType(Double)))


        _dtFact = New DataTable("Tmp_Fact")

        _dtFact.Columns.Add(New DataColumn("Tipodocto", GetType(String)))
        _dtFact.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtFact.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtFact.Columns.Add(New DataColumn("Total", GetType(Double)))
        _dtFact.Columns.Add(New DataColumn("Guia", GetType(String)))

        _dtCambioFecha = New DataTable("Tmp_Cambio")
        _dtCambioFecha.Columns.Add(New DataColumn("Lote", GetType(String)))
        _dtCambioFecha.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtCambioFecha.Columns.Add(New DataColumn("Total", GetType(Double)))
        _dtCambioFecha.Columns.Add(New DataColumn("NuevaFecha", GetType(Date)))

        dgv_cambiarFecha.DataSource = _dtCambioFecha

    End Sub

    Private Sub combbox_crea()
        Dim dt As New DataTable
        Dim ls_SqlScript As String
        Dim l_Dataset As New DataSet

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()


        ls_SqlScript = "select distinct empresa from scm.flexline.Recibos_Lote_Acumula "
        dt = otrans.Obtiene(ls_SqlScript)

        Dim comboBoxColumn As New DataGridViewComboBoxColumn()
        l_Dataset.Tables.Add(dt.Copy)
        dt.TableName = "combo"

        dgv_cambiarFecha.Columns.Add(comboBoxColumn)
        comboBoxColumn.DataSource = dt
        comboBoxColumn.DisplayMember = "empresa"
        comboBoxColumn.ValueMember = "empresa"
        comboBoxColumn.HeaderText = "Empresa"



    End Sub


    Private Sub Carga_Combos()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("SCM")
        otrans.open()

        ls_SqlScript = "pa_vb_Recibos_Formas_Pago '" & gs_empresa & "'"

        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Formas"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_FormasPago.DisplayMember = "Codigo"
        Me.cb_FormasPago.ValueMember = "Codigo"
        Me.cb_FormasPago.DataSource = ldt_table

        Me.cb_FormaPagoRm.DisplayMember = "Codigo"
        Me.cb_FormaPagoRm.ValueMember = "Codigo"
        Me.cb_FormaPagoRm.DataSource = ldt_table


        ls_SqlScript = "spa_Recibos_Lote_Bancos '" & gs_empresa & "'"

        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Bancos"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Banco.DisplayMember = "Descripcion"
        Me.cb_Banco.ValueMember = "Descripcion"
        Me.cb_Banco.DataSource = ldt_table


        Me.cb_BancoRm.DisplayMember = "Descripcion"
        Me.cb_BancoRm.ValueMember = "Descripcion"
        Me.cb_BancoRm.DataSource = ldt_table

        Me.cb_Rcm_Banco.DisplayMember = "Descripcion"
        Me.cb_Rcm_Banco.ValueMember = "Descripcion"
        Me.cb_Rcm_Banco.DataSource = ldt_table

    End Sub

    Private Sub Carga_Estado()
        Dim dt As New DataTable
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("SCM")
        otrans.open()

        ls_SqlScript = "spa_Recibos_lote_Estado '" & lb_Estado.Text & "'"
        dt = otrans.Obtiene(ls_SqlScript)  'obtiene o ejecuta el procedimiento para extraer los datos

        btn_SigEstado.Text = dt.Rows(0).Item("Estado")
        btn_SigEstado.Enabled = True

        'ldt_table = otrans.Obtiene(ls_SqlScript)
        'ldt_table.TableName = "Estado"
        'l_Dataset.Tables.Add(ldt_table.Copy)

        'Me.cb_FormasPago.DisplayMember = "Codigo"
        'Me.cb_FormasPago.ValueMember = "Codigo"
        'Me.cb_FormasPago.DataSource = ldt_table
    End Sub

    Private Sub Llena_Recibos()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim Monto As Double
        Try

            otrans.open()
            lsSQL = "spa_Recibos_Muestra '" & gs_empresa & "','" & tb_Recibo.Text & "'"
            dt = otrans.Obtiene(lsSQL)

            For Each dr As DataRow In dt.Rows

                lb_Empresa.Text = dr.Item("Empresa")
                tb_Recibo.Text = dr.Item("Recibo")
                lb_TipoDocto.Text = dr.Item("Tipodocto")
                lb_Fecha.Text = dr.Item("Fecha")
                lb_Numero.Text = dr.Item("Numero")
                lb_Cliente.Text = dr.Item("Cliente")
                lb_Razon.Text = dr.Item("RazonSocial")
                Monto = CDbl(dr.Item("Total"))
                lb_guia.Text = dr.Item("GuiaTipoDocto")
                lb_Monto.Text = Format(Monto, "#,###,##0.0000")
            Next



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub tb_Recibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Recibo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not (IsNumeric(tb_Recibo.Text)) Then
                MsgBox("Se Debe Ingresar un numero Valido ", MsgBoxStyle.Critical, "Precaución")
                tb_Recibo.Focus()
            Else
                Llena_Recibos()
                tb_Recibo.Enabled = False
                'If lb_guia.Text = "NO" Then
                btn_agregar1.Enabled = True
                btn_agregar1.Focus()
                'Else
                ' MsgBox("Este Recibo No puede Ser aplicado a la Factura Por Tener Guia, Debe Ser Operado en Liquidacion de Guias.", MsgBoxStyle.Information, "No Operable")
                'btn_agregar1.Enabled = False
                'Limpiar1()
                'End If

            End If
        End If
    End Sub

    Private Sub btn_agregar1_Click(sender As Object, e As EventArgs) Handles btn_agregar1.Click
        gp_Valores.Enabled = True
        tb_Monto.Enabled = False
        cb_Banco.Enabled = False
        tb_Cheque.Enabled = False
        btn_Agregar2.Enabled = False

        btn_agregar1.Enabled = False
        tb_Monto.Text = lb_Monto.Text
        Carga_Combos()
        cb_FormasPago.Enabled = True
        Diferencia()
        cb_FormasPago.Focus()

    End Sub

    Private Sub cb_FormasPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_FormasPago.KeyPress
        If e.KeyChar = Chr(13) Then
            '  cb_FormasPago.Enabled = False

            If cb_FormasPago.Text = "CONTADO_CHEQUE" Then
                cb_Banco.Visible = True
                tb_Cheque.Visible = True
                tb_Monto.Enabled = True

            Else
                cb_Banco.Visible = False
                tb_Cheque.Visible = False
                tb_Monto.Enabled = True
                btn_Agregar2.Enabled = False

            End If
            tb_Monto.Focus()

        End If

    End Sub

    Private Sub Diferencia()
        Dim ntotal As Double
        'Dim nMonto As Double
        '    Dim dt As DataTable

        Try
            ntotal = CDbl(lb_Monto.Text)
            ' nMonto = CDbl(tb_Monto.Text)
            'dt.Compute("sum(lb_monto.text)", "lb_monto>0")
            Me.lb_Diferencia.Text = Format(ntotal, "###,##0..00000")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tb_Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Monto.KeyPress
        Dim Monto As Double
        Dim Dif As Double

        If e.KeyChar = Chr(13) Then

            Try

                If Not IsNumeric(tb_Monto.Text) Then
                    MsgBox("Debe ingresar Valores Numericos", MsgBoxStyle.Critical, "Error")
                    tb_Monto.Focus()
                    tb_Monto.SelectAll()
                Else

                    If cb_FormasPago.Text = "CONTADO CHEQUE" Then
                        Monto = CDbl(tb_Monto.Text)
                        tb_Monto.Text = Format(Monto, "###,##0.000000")
                        cb_Banco.Visible = True
                        cb_Banco.Enabled = True
                        tb_Cheque.Visible = True
                        tb_Cheque.Enabled = True
                        cb_Banco.Focus()

                    Else
                        Monto = CDbl(tb_Monto.Text)
                        Dif = CDbl(lb_Diferencia.Text)
                        tb_Monto.Text = Format(Monto, "###,##0.000000")
                        Me.lb_Diferencia.Text = Format(Dif - Monto, "###,##0.000000")
                        cb_Banco.Enabled = False
                        tb_Cheque.Enabled = False
                        btn_Agregar2.Enabled = True
                        btn_Agregar2.Focus()
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub btn_Agregar2_Click(sender As Object, e As EventArgs) Handles btn_Agregar2.Click
        Guarda_Linea()
        Limpiar1()
        Actualiza_Vista_Detalle_Lote()
        Carga_Estado()
        gp_Detalle.Enabled = True
        tb_Recibo.Focus()
    End Sub

    Private Sub Guarda_Linea()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim lbmonto As String
        Dim lbmontod As Double
        Dim tbmonto As String
        Dim tbmontod As Double

        Try
            lbmontod = CDbl(lb_Monto.Text)
            tbmontod = CDbl(tb_Monto.Text)

            lbmonto = Format(lbmontod, "######0.000000")
            tbmonto = Format(tbmontod, "######0.000000")

            Utrans.open()
            ls_sql = "spa_Recibos_Guarda_Linea  '" & gs_empresa & "','" & tb_Lote.Text & "','" & dtp_Fecha.Text & "','" & tb_Recibo.Text & "','" & lb_TipoDocto.Text & "','" & lb_Fecha.Text & "','" & lb_Numero.Text & "','" & lb_Cliente.Text & "','" & lb_Razon.Text.Replace("'", "") & "','" & lbmonto & "','" & cb_FormasPago.Text & "','" & tbmonto & "','" & cb_Banco.Text & "','" & tb_Cheque.Text & "','1', '" & gs_usuario & "'"
            Utrans.Ingresa(ls_sql)

            ' MsgBox("Agregado Con Exito!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub Guarda_Linea_Recibos_Manual()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim lbmonto As String
        Dim lbmontod As Double
        Dim tbmonto As String
        Dim tbmontod As Double

        Try
            lbmontod = CDbl(tb_MontoRm.Text)
            tbmontod = CDbl(tb_Recibido.Text)

            lbmonto = Format(lbmontod, "######0.000000")
            tbmonto = Format(tbmontod, "######0.000000")

            If cb_FormaPagoRm.Text = "CONTADO EFECTIVO" Then
                cb_BancoRm.Text = ""
                tb_ChequeRm.Text = ""
            End If

            Utrans.open()
            ls_sql = "spa_Recibos_Guarda_Linea  '" & gs_empresa & "','" & tb_Lote.Text & "','" & dtp_Fecha.Text & "','" & tb_ReciboRm.Text & "','" & tb_TipoDocto.Text & "','" & tb_Fecha.Text & "','" & tb_Numero.Text & "','" & tb_Cliente.Text & "','" & lb_RazonSocial.Text & "','" & lbmonto & "','" & cb_FormaPagoRm.Text & "','" & tbmonto & "','" & cb_BancoRm.Text & "','" & tb_ChequeRm.Text & "','1', '" & gs_usuario & "'"
            Utrans.Ingresa(ls_sql)

            MsgBox("Agregado Con Exito!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub Actualiza_Lote()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion

            lsSQL = "spa_Recibos_Lote_Correlativo '" & gs_empresa & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            lsSQL = "Select Lote from SCM.flexline.Recibos_Lote_Correlativo where empresa='" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            For Each dr As DataRow In dt.Rows

                tb_Lote.Text = dr.Item("Lote")
                lb_LoteRm.Text = tb_Lote.Text
                lb_FechaRm.Text = dtp_Fecha.Text
                lb_Estado.Text = "INICIAL"
                lb_EstadoRm.Text = lb_Estado.Text

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_AsignaLote_Click(sender As Object, e As EventArgs) Handles btn_AsignaLote.Click
        If MsgBox("Seguro De Crear Lote Inicial? ", MsgBoxStyle.YesNo, "Crear Lote") = MsgBoxResult.Yes Then
            Actualiza_Lote()
            gp_Lote.Enabled = False
            gp_Recibo.Enabled = True
            GroupBox1.Enabled = True
            btn_agregar1.Enabled = False
            tb_Recibo.Enabled = True
            lb_Rcm_Lote.Text = tb_Lote.Text
            lb_Rcm_Estado.Text = lb_Estado.Text
            lb_Rcm_Fecha.Text = dtp_Fecha.Text
            tb_Recibo.Focus()
        Else
            Inicial()
        End If

    End Sub

    Private Sub btn_BuscarLotes_Click(sender As Object, e As EventArgs) Handles btn_BuscarLotes.Click
        BuscaLote()
    End Sub

    Private Sub BuscaLote()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Dim oForm As New Frm_Recibos_Lote_Busca
        oForm.ShowDialog()

        If oForm.Lote = Nothing Then
            MsgBox("No Existen Lotes", MsgBoxStyle.Information, "Verifique")
        Else
            Try
                tb_Lote.Enabled = False
                Me.tb_Lote.Text = oForm.Lote
                Me.dtp_Fecha.Text = oForm.Fecha
                Me.lb_Empresa.Text = gs_empresa

                lb_LoteRm.Text = tb_Lote.Text
                lb_FechaRm.Text = dtp_Fecha.Text


                '   Me.cb_Estado.Text = (Me.cb_Estado.Items.Add(oForm.Estado))

                otrans.open()   'abre conexion
                lsSQL = "spa_Recibos_Lote_Muestra '" & gs_empresa & "','" & tb_Lote.Text & "'"
                dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
                dgv_Detalle.DataSource = dt
                dgv_DetalleM.DataSource = dt

                'Me.cb_Banco.DataSource = dt
                'Me.cb_Banco.ValueMember = "Banco"
                'Me.cb_Banco.DisplayMember = "Banco"


                Total()

                lb_Estado.Text = dt.Rows(0).Item("Estado")
                lb_EstadoRm.Text = dt.Rows(0).Item("Estado")
                Estado = dt.Rows(0).Item("CodEstado")

                lb_Rcm_Lote.Text = tb_Lote.Text
                lb_Rcm_Estado.Text = lb_Estado.Text
                lb_Rcm_Fecha.Text = dtp_Fecha.Text

                Limpiar1()
                dtp_Fecha.Enabled = False
                gp_Detalle.Enabled = True
                GroupBox1.Enabled = True

                Carga_Estado()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Limpiar1()

        tb_Recibo.Text = ""
        tb_Recibo.Enabled = True
        lb_TipoDocto.Text = "TipoDocto"
        lb_Numero.Text = "Numero"
        lb_Fecha.Text = "Fecha"
        lb_Cliente.Text = "Cliente"
        lb_Razon.Text = "Razon Social"
        lb_Monto.Text = "0.000000"
        lb_Empresa.Text = ""

        btn_agregar1.Enabled = False
        gp_Recibo.Enabled = True

        cb_FormasPago.Text = ""
        tb_Monto.Text = "0.000000"
        lb_TotalCuadrados.Text = "0.000000"
        cb_Banco.Text = ""
        tb_Cheque.Text = ""
        gp_Valores.Enabled = False
        lb_Diferencia.Text = "0.000000"

        tb_Recibo.Focus()
    End Sub


    Private Sub cb_Banco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Banco.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Cheque.Focus()
        End If
    End Sub

    Private Sub tb_Cheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Cheque.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_Agregar2.Enabled = True
            btn_Agregar2.Focus()
        End If
    End Sub

    Private Sub btn_BuscarLoteM_Click(sender As Object, e As EventArgs)
        BuscaLote()
    End Sub

    Private Sub tb_Cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Cliente.KeyPress
        If e.KeyChar = Chr(13) Then
            'If Not IsNumeric(tb_Cliente.Text) Then
            '    MsgBox("Debe Ingresar Un codigo Valido", MsgBoxStyle.Critical, "Error")
            '    tb_Cliente.Focus()
            '    tb_Cliente.SelectAll()
            Busca_Clientes()
            Carga_Combos()
            'Else : Busca_Clientes()
            '    tb_Cliente.Enabled = False
            'End If
        End If
    End Sub

    Private Sub Busca_Clientes()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = " pa_vb_Recibos_Clientes '" & gs_empresa & "','" & tb_Cliente.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            lb_RazonSocial.Text = dt.Rows(0).Item("RazonSocial")
            lb_Vendedor.Text = dt.Rows(0).Item("Vendedor")

            lb_RazonSocial.Text = dt.Rows(0).Item("RazonSocial")
            lb_Vendedor.Text = dt.Rows(0).Item("Vendedor")

            Muestra_Facturas()
            '   Carga_Estado()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Muestra_Facturas()
        Dim otrans As New Transaccional.Conexion("Flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Facturas '" & gs_empresa & "','" & tb_Cliente.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtFact.Rows.Clear()
            For Each dr As DataRow In dt.Rows

                dr2 = _dtFact.NewRow
                dr2.Item("TipoDocto") = dr.Item("TipoDocto")
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("Fecha") = dr.Item("Fecha")
                dr2.Item("Total") = dr.Item("Total")
                dr2.Item("Guia") = dr.Item("Guia")
                _dtFact.Rows.Add(dr2)

            Next

            Me.dgv_Facturas.DataSource = _dtFact    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtFact, Me.dgv_Facturas, ",TipoDocto,Numero,Fecha,Total,Guia,", ",,", ",TipoDocto,Numero,Fecha,Total,Guia,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpia_Recibos_Manual()
    End Sub

    Private Sub Limpia_Recibos_Manual()

        lb_RazonSocial.Text = "Razón Social"
        lb_Vendedor.Text = "Vendedor"
        Me.dgv_Facturas.DataSource = Nothing
        tb_Cliente.Enabled = True
        tb_Cliente.Text = ""

        tb_TipoDocto.Text = ""
        tb_Numero.Text = ""
        tb_Fecha.Text = ""
        cb_FormaPagoRm.Text = Nothing
        tb_MontoRm.Text = ""
        cb_BancoRm.Text = Nothing
        tb_Recibido.Text = ""
        tb_ChequeRm.Text = ""
        btn_AgregarRm.Enabled = False

        tb_Cliente.Focus()

    End Sub

    Private Sub tb_ReciboRm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_ReciboRm.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_ReciboRm.Text) Then
                MsgBox("Debe Ingresar Numero Valido!!", MsgBoxStyle.Critical, "Error")
                tb_ReciboRm.Focus()
                tb_ReciboRm.SelectAll()
            Else
                dtp_FechaRm.Enabled = False
                tb_ReciboRm.Enabled = False
                tb_Cliente.Enabled = True
                tb_Cliente.Focus()
            End If
        End If

    End Sub

    Private Sub btn_NuevoRm_Click(sender As Object, e As EventArgs) Handles btn_NuevoRm.Click
        Nuevo_Recibo_Manual()
        tb_ReciboRm.Text = ""
        tb_ReciboRm.Focus()
    End Sub

    Private Sub Nuevo_Recibo_Manual()
        Limpia_Recibos_Manual()
        tb_Cliente.Enabled = False
        dtp_FechaRm.Enabled = True
        tb_ReciboRm.Text = ""
        tb_ReciboRm.Enabled = True
        tb_ReciboRm.Focus()

    End Sub

    Private Sub dgv_Facturas_DoubleClick(sender As Object, e As EventArgs) Handles dgv_Facturas.DoubleClick
        Dim nfila As Integer
        Try
            nfila = Me.dgv_Facturas.CurrentRow.Index

            Guia.Text = Me.dgv_Facturas.Item("Guia", nfila).Value

            '   If Guia.Text = "NO" Then
            tb_TipoDocto.Text = Me.dgv_Facturas.Item("TipoDocto", nfila).Value
            tb_Numero.Text = Me.dgv_Facturas.Item("Numero", nfila).Value
            tb_Fecha.Text = Me.dgv_Facturas.Item("Fecha", nfila).Value
            tb_MontoRm.Text = Me.dgv_Facturas.Item("Total", nfila).Value
            tb_Recibido.Text = Me.dgv_Facturas.Item("Total", nfila).Value
            tb_Recibido.Text = Me.dgv_Facturas.Item("Total", nfila).Value
            cb_FormaPagoRm.Focus()
            '  Else
            'MsgBox("Este Recibo No puede Ser aplicado a la Factura Por Tener Guia, Debe Ser Operado en Liquidacion de Guias.", MsgBoxStyle.Information, "No Operable")
            '    tb_TipoDocto.Text = ""
            '    tb_Numero.Text = ""
            '    tb_Fecha.Text = ""
            '    tb_MontoRm.Text = ""
            ' End If

            '   dgv_Facturas.Rows.RemoveAt(nfila)
            '    Carga_Combos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            tb_TipoDocto.Text = ""
            tb_Numero.Text = ""
            tb_Fecha.Text = ""
            tb_MontoRm.Text = ""
        End Try

    End Sub

    Private Sub cb_FormaPagoRm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_FormaPagoRm.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Recibido.Focus()
        End If
    End Sub

    Private Sub tb_Recibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Recibido.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Recibido.Text) Then
                MsgBox("Debe Ingresar Dato Valido!!", MsgBoxStyle.Critical, "Error")
                tb_Recibido.Focus()
                tb_Recibido.SelectAll()

            Else

                If cb_FormaPagoRm.Text = "CONTADO EFECTIVO" Then
                    btn_AgregarRm.Enabled = True
                    btn_AgregarRm.Focus()
                Else
                    cb_BancoRm.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub cb_BancoRm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_BancoRm.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_ChequeRm.Focus()
        End If
    End Sub

    Private Sub tb_ChequeRm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_ChequeRm.KeyPress
        If e.KeyChar = Chr(13) Then
            If Len(tb_ChequeRm.Text) = 0 Then
                MsgBox("Debe Ingresar Dato!!", MsgBoxStyle.Critical, "Error")
                tb_ChequeRm.Focus()

            Else
                btn_AgregarRm.Enabled = True
                btn_AgregarRm.Focus()

            End If
        End If
    End Sub

    Private Sub btn_AgregarRm_Click(sender As Object, e As EventArgs) Handles btn_AgregarRm.Click

        Guarda_Linea_Recibos_Manual()
        Actualiza_Vista_Detalle_Lote()
        Limpia_Documentos_Recibos_Manual()
        Muestra_Facturas()
        btn_NuevoRm.Focus()
    End Sub

    Private Sub btn_AgregarRm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btn_AgregarRm.KeyPress
        Guarda_Linea_Recibos_Manual()
        Actualiza_Vista_Detalle_Lote()
        Muestra_Facturas()
    End Sub

    Private Sub Actualiza_Vista_Detalle_Lote()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Muestra '" & gs_empresa & "','" & tb_Lote.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            dgv_Detalle.DataSource = dt
            dgv_DetalleM.DataSource = dt
            Total()

            lb_Estado.Text = dt.Rows(0).Item("Estado")
            lb_EstadoRm.Text = dt.Rows(0).Item("Estado")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
        End Try
    End Sub

    Private Sub Limpia_Documentos_Recibos_Manual()
        'cb_FormaPagoRm.Text = Nothing
        tb_TipoDocto.Text = ""
        tb_Fecha.Text = ""
        tb_Recibido.Text = "0.000000"
        tb_Numero.Text = ""
        tb_MontoRm.Text = "0.000000"
        ' cb_BancoRm.Text = Nothing
        ' tb_ChequeRm.Text = ""
    End Sub

    Private Sub btn_SigEstado_Click(sender As Object, e As EventArgs) Handles btn_SigEstado.Click
        If MsgBox("Seguro De Pasar al Siguiente Estado: " & btn_SigEstado.Text & " ?", MsgBoxStyle.YesNo, "Estado") = MsgBoxResult.Yes Then

            Siguiente_Estado()
        Else
            tb_Recibo.Focus()
        End If

    End Sub

    Private Sub Siguiente_Estado()
        Crea_Lote_Cuadrado()
        Impresion_Lote_Cuadrado()
        Limpia_Documentos_Recibos_Manual()
        Limpia_Recibos_Manual()
        Limpiar1()
        Inicial()
        tb_Lote.Text = ""
        dgv_Detalle.DataSource = Nothing
        dgv_DetalleM.DataSource = Nothing
        lb_EstadoRm.Text = "Estado"
        lb_FechaRm.Text = "Fecha"
        lb_LoteRm.Text = "Lote"
        lb_Estado.Text = "Estado"
        dtp_Fecha.Enabled = True
    End Sub

    Private Sub Crea_Lote_Cuadrado()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Cuadra '" & gs_empresa & "','" & tb_Lote.Text & "','" & Estado & "','" & gs_usuario & "','" & Now().ToString & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            MsgBox("El Lote " & tb_Lote.Text & " Se ha Trasladado Al Estado Cuadrado, Verifique", MsgBoxStyle.Information, "Lote Cuadrado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()

        End Try
    End Sub


    Private Sub Total()
        Dim ntotal As Double
        Dim dt As DataTable
        ' Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            '    Otrans.open()   'abre conexion
            dt = Me.dgv_Detalle.DataSource

            ntotal = dt.Compute("sum(Monto)", "Monto>0")
            Me.lb_Total.Text = Format(ntotal, "###,##0.000000")
            Me.lb_TotalRm.Text = Format(ntotal, "###,##0.000000")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Impresion_Lote_Cuadrado()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim Deposito As String
        Dim Lote As String

        Try

            If tb_Lote.Text.Length = 0 Then
                Lote = lb_t3Lote.Text   'lb_t3Lote
            Else
                Lote = tb_Lote.Text
            End If


            pm_conexion = ClsGen.Parametros_Conexion("flexline")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Jefatura\Impresion_Lotes _Recibos.rpt" 'Impresion De Lotes Recibos Cuadrados.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Lote"
            pm_valores(1) = Lote

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try
    End Sub


    Private Sub btn_Generar_Click(sender As Object, e As EventArgs) Handles btn_Generar.Click
        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet
        Dim ls_SqlScript As String


        Dim otrans As New Transaccional.Conexion("SCM")

        Try
            otrans.open()

            ls_SqlScript = "spa_Recibos_Lote_Genera_Cuadrados '" & gs_empresa & "','" & cb_t3Estado.Text & "'"

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "Formas"
            l_Dataset.Tables.Add(ldt_table.Copy)

            If ldt_table.Rows.Count > 0 Then


                Me.cb_LotesCuadrados.DisplayMember = "Lote"
                Me.cb_LotesCuadrados.ValueMember = "Lote"
                Me.cb_LotesCuadrados.DataSource = ldt_table

            Else
                MsgBox("No Existen Lotes", MsgBoxStyle.Information, "Verifique")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub

    Private Sub btn_Muestra_Click(sender As Object, e As EventArgs) Handles btn_Muestra.Click
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        dgv_DetalleCuadrados.DataSource = Nothing

        'MsgBox(cb_LotesCuadrados.Text)

        Try


            'lb_t3Lote.Text = CInt(Mid(cb_LotesCuadrados.Text, 1, 7))

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Muestra_Cuadrados '" & gs_empresa & "','" & Replace(lb_t3Lote.Text, "-", "").Trim() & "','" & cb_t3Estado.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows.Count > 0 Then
                btn_Regresar.Enabled = True
            Else
                btn_Regresar.Enabled = False
            End If

            lb_t3Fecha.Text = dt.Rows(0).Item("Fecha")
            lb_t3Estado.Text = dt.Rows(0).Item("Estado")
            lb_CodEstado.Text = dt.Rows(0).Item("CodEstado")
            lb_t3Lote.Text = CInt(lb_t3Lote.Text)

            dgv_DetalleCuadrados.DataSource = dt


            Total_Cuadrados()
            Carga_Estados()
            btn_Regresar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
        End Try

    End Sub

    Private Sub Total_Cuadrados()
        Dim ntotal As Double
        '  Dim facttotal As Integer
        ' Dim rectotal As Integer
        Dim dt, dt2, DT3 As DataTable

        '    Dim facturasUnicas = (From row In dt2.AsEnumerable() Select row.Field(Of String)("Numero")).Distinct().Count()


        Try
            dt2 = TryCast(Me.dgv_DetalleCuadrados.DataSource, DataTable)
            DT3 = TryCast(Me.dgv_DetalleCuadrados.DataSource, DataTable)

            Dim facturasUnicas = (From row In dt2.AsEnumerable() Select row.Field(Of String)("Numero")).Distinct().Count()

            Dim recibosUnicos = (From row In DT3.AsEnumerable() Where Not IsDBNull(row("Recibo")) Select Convert.ToString(row("Recibo"))).Distinct().Count()




            dt = Me.dgv_DetalleCuadrados.DataSource

            ntotal = dt.Compute("sum(Monto)", "Monto>0")

            Me.lb_TotalCuadrados.Text = Format(ntotal, "#,###,##0.000000")
            lbl_facturas.Text = facturasUnicas
            lbl_Recibos.Text = recibosUnicos

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Carga_Estados()
        Dim dt As New DataTable
        Dim ls_SqlScript As String
        Dim otrans As New Transaccional.Conexion("SCM")

        Try
            otrans.open()

            ls_SqlScript = "spa_Recibos_lote_Estado '" & lb_t3Estado.Text & "'"
            dt = otrans.Obtiene(ls_SqlScript)

            btn_t3SigEstado.Text = dt.Rows(0).Item("Estado")

            If btn_t3SigEstado.Text = "Cerrado" Then

                btn_t3SigEstado.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btn_t3Nuevo_Click(sender As Object, e As EventArgs) Handles btn_t3Nuevo.Click
        T3_Nuevo()
    End Sub

    Private Sub T3_Nuevo()
        Me.cb_t3Estado.Text = ""
        Me.cb_LotesCuadrados.DataSource = Nothing
        lb_t3Lote.Text = "Lote"
        lb_t3Fecha.Text = "Fecha"
        lb_t3Estado.Text = "Estado"
        dgv_DetalleCuadrados.DataSource = Nothing
        lb_TotalCuadrados.Text = "0.000000"
        btn_t3SigEstado.Text = "Sig. Estado"
        btn_t3SigEstado.Enabled = True
    End Sub

    Private Sub btn_t3SigEstado_Click(sender As Object, e As EventArgs) Handles btn_t3SigEstado.Click
        If lb_CodEstado.Text = "4" Then

            Actualiza_Contabilidad()


        ElseIf lb_CodEstado.Text = "5" Then
            MsgBox("Lote Actualizado En Contabilidad, Estado: Cerrado", MsgBoxStyle.Information, "Lote Cerrado")
        Else
            Pasar_Estado()
            Impresion_Lote_Cuadrado()
            T3_Nuevo()
        End If

    End Sub

    Private Sub Pasar_Estado()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Cuadra '" & gs_empresa & "','" & lb_t3Lote.Text & "','" & lb_CodEstado.Text & "','" & gs_usuario & "','" & Now().ToString & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            MsgBox("El Lote " & lb_t3Lote.Text & " Se ha Trasladado A un Nuevo Estado, Verifique", MsgBoxStyle.Information, "Lote Cuadrado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()

        End Try
    End Sub

    Private Sub Actualiza_Contabilidad()
        If MsgBox("Seguro de Actualizar en Contabilidad en estado Actualizado?", MsgBoxStyle.YesNo, "Actualización Contable") = MsgBoxResult.Yes Then
            Verifica()
            Reporte_Actualizado()
            T3_Nuevo()
            Inicial()
            Limpia_Recibos_Manual()
            Limpiar1()
        Else
            T3_Nuevo()
        End If
    End Sub

    Private Sub btn_Limpiar1_Click(sender As Object, e As EventArgs) Handles btn_Limpiar1.Click
        Limpiar1()
    End Sub

    Private Sub Verifica()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "pa_vb_Recibos_lote_Verifica '" & gs_empresa & "','" & lb_t3Lote.Text & "','" & lb_t3Fecha.Text & "','" & 5 & "','" & gs_usuario & "'" ' & Now().ToString & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows.Count > 0 Then

                MsgBox("El Lote " & lb_t3Lote.Text & " Ya existe en Contabilidad con fecha , Verifique", MsgBoxStyle.Information, "Contabilidad")

            Else
                '----------si el periodo esta cerrado no actualizara
                'If dt.Rows.Item("EstadoPeriodo").ToString = "NNNNN" Then
                '    MsgBox("El periodo en el cual quiere actualizar esta cerrado en FLEXLINE, favor validar", MsgBoxStyle.Critical)
                '    Exit Sub
                ''Else
                'Crea_Partidas()
                'End If
                valida_periodo()

            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub valida_periodo()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable


        Try

            otrans.open()   'abre conexion
            lsSQL = "pa_vb_Recibos_lote_Verifica2 '" & gs_empresa & "','" & lb_t3Lote.Text & "','" & lb_t3Fecha.Text & "','" & 4 & "','" & gs_usuario & "'" ' & Now().ToString & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows.Count > 0 Then
                'dt.Rows.Item("EstadoPeriodo").ToString

                If dt.Rows(0)("EstadoPeriodo").ToString = "NNNNN" Then
                    MsgBox("El periodo en el cual quiere actualizar esta cerrado en FLEXLINE, favor validar", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Crea_Partidas()
                End If

            Else
                '----------si el periodo esta cerrado no actualizara

                MsgBox("No Existen datos para actualizar", MsgBoxStyle.Critical)
                Exit Sub
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub



    Private Sub Crea_Partidas()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try




            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Cursor '" & gs_empresa & "','" & lb_t3Lote.Text & "','" & lb_t3Fecha.Text & "','" & lb_CodEstado.Text & "','" & gs_usuario & "'" ' & Now().ToString & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            MsgBox("El Lote " & lb_t3Lote.Text & " Se Actualizo en la Contabilidad, Verifique", MsgBoxStyle.Information, "Contabilidad")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()

        End Try
    End Sub

    Private Sub Reporte_Actualizado()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim Deposito As String

        Try

            pm_conexion = ClsGen.Parametros_Conexion("Flexline")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Jefatura\Comprobantes_Lote_recibo.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@lote"
            pm_valores(1) = lb_t3Lote.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try
    End Sub




    Private Sub cb_LotesCuadrados_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_LotesCuadrados.SelectedValueChanged
        lb_t3Lote.Text = Mid(cb_LotesCuadrados.Text, 1, 10)
    End Sub

    Private Sub dtp_FechaRm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_FechaRm.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_ReciboRm.Focus()
        End If
    End Sub

    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        ' Dim clsGen As New ClasesGenerales.General
        ' Dim fecha As Date
        'Dim dt As New DataTable
        'Dim hoy As String

        'dt = clsGen.Fecha_Servidor("FlexLine")
        'hoy = DateTime.Parse(dt.Rows[0][0].ToString())

        If lb_t3Estado.Text = "Actualizado" Or lb_t3Estado.Text = "Cuadrado" Then
            ' aplicar tambien para aprobado

            If MsgBox("Seguro de Regresar el Lote: " & tb_Lote.Text & " a un Estado Anterior?", MsgBoxStyle.YesNo, "Regresar") = MsgBoxResult.Yes Then
                gb_Contraseña.Enabled = True
                gb_Contraseña.Visible = True

                If lb_t3Estado.Text = "Actualizado" Then
                    MsgBox("El Cambio de Estado del Lote Eliminara las Partidas Contables", MsgBoxStyle.Information, "Información...")
                End If

            End If
        Else
            MsgBox("El Estado del Lote no es Aceptado para Modificarlo...", MsgBoxStyle.Critical, "Estado")
            T3_Nuevo()
        End If


    End Sub

    Private Sub btn_Ok_Click(sender As Object, e As EventArgs) Handles btn_Ok.Click
        If Pass = tb_Constraseña.Text Then
            MsgBox("Contraseña Valida")
            Regresar_Inicial()
        Else
            MsgBox("Contraseña Invalida, Usted No Tiene Permiso para Modficar el Lote...", MsgBoxStyle.Critical, "Cerrar Aplicación")
            Me.Close()
        End If

    End Sub

    Public Sub Regresar_Inicial()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Regresa '" & gs_empresa & "','" & lb_t3Lote.Text & "','" & gs_usuario & "','" & lb_t3Fecha.Text & "','" & lb_t3Estado.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows(0)("Result").ToString = "NO" Then
                MsgBox("El Lote Pasa de Los Dias Permitidos, Verifique...", MsgBoxStyle.Information, "Recibo Antiguo")
            End If

            If dt.Rows(0)("Result").ToString = "SI" Then
                MsgBox("El Lote " & lb_t3Lote.Text & " ha Regresado a un Estado Anterior, Verifique", MsgBoxStyle.Information, "Estado Anterior")
            End If

            Inicial()
            T3_Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()

        End Try
    End Sub

    Private Sub dgv_DetalleCuadrados_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_DetalleCuadrados.CellEndEdit
        Total_Cuadrados()
    End Sub

    Private Sub dgv_Detalle_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Detalle.RowHeaderMouseClick


        dlote = dgv_Detalle.CurrentRow.Cells(1).Value
        dTipoDocto = dgv_Detalle.CurrentRow.Cells(4).Value
        dNumero = dgv_Detalle.CurrentRow.Cells(6).Value
        destado = dgv_Detalle.CurrentRow.Cells(14).Value


    End Sub

    Private Sub dgv_Detalle_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgv_Detalle.UserDeletedRow
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dr2 As DataRow

        Total()

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibo_Lote_Elimina '" & gs_empresa & "','" & dlote & "','" & dTipoDocto & "','" & dNumero & "','" & destado & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            MsgBox("Linea del Lote " & dlote & " ha sido Eliminada, Verifique", MsgBoxStyle.Information, "Eliminar")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()

        End Try


    End Sub

    Private Sub tb_Rcm_Recibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Rcm_Recibo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Rcm_Recibo.Text) Then
                MsgBox("Debe ingresar Numero Valido", MsgBoxStyle.Critical, "Recibo Canal Moderno")
                tb_Rcm_Recibo.Focus()
                tb_Rcm_Recibo.SelectAll()
            Else
                Carga_Combos()
                dtp_Rcm_Fecha.Focus()
            End If
        End If
    End Sub

    Private Sub dtp_Rcm_Fecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_Rcm_Fecha.KeyPress
        If e.KeyChar = Chr(13) Then
            cb_Rcm_Canal.Focus()
        End If
    End Sub

    Private Sub cb_Rcm_Canal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Rcm_Canal.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_Rcm_Canal.Text.Length > 0 Then
                tb_Rcm_Monto.Focus()
            Else
                MsgBox("Debe Seleccionar Canal Moderno", MsgBoxStyle.Information, "Seleccionar")
                cb_Rcm_Canal.Focus()
            End If
        End If
    End Sub

    Private Sub tb_Rcm_Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Rcm_Monto.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Rcm_Monto.Text) Then
                MsgBox("Debe Ingresar Valor Numerico", MsgBoxStyle.Critical, "Monto")
                tb_Rcm_Monto.Focus()
            Else
                cb_Rcm_Banco.Focus()
            End If
        End If
    End Sub

    Private Sub cb_Rcm_Banco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Rcm_Banco.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_Rcm_Banco.Text.Length > 0 Then
                btn_Rcm_Agregar.Focus()
            Else
                MsgBox("Debe Seleccionar Banco", MsgBoxStyle.Information, "Banco")
                cb_Rcm_Banco.Focus()
            End If
        End If
    End Sub

    Private Sub btn_Rcm_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Rcm_Agregar.Click
        If MsgBox("Seguro de Agregar Recibo de Canal Moderno?", MsgBoxStyle.YesNo, "Canal Moderno") = MsgBoxResult.Yes Then
            Agregar_Recibo_Canal_Moderno()
        Else
            Limpia_Canal_Moderno()
        End If
    End Sub

    Public Sub Agregar_Recibo_Canal_Moderno()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        ' Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        'Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibo_Lote_Agrega '" & gs_empresa & "','" & lb_Rcm_Lote.Text & "','" & lb_Rcm_Fecha.Text & "','" & tb_Rcm_Recibo.Text & "','" & dtp_Rcm_Fecha.Text & "','" & tb_Rcm_Recibo.Text & "','" & cb_Rcm_Canal.Text & "','" & tb_Rcm_Monto.Text & "','" & cb_Rcm_Banco.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            MsgBox("Recibo de Canal Moderno Agregado, Verifique", MsgBoxStyle.Information, "Canal Moderno")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            Limpia_Canal_Moderno()
        End Try
    End Sub

    Private Sub Limpia_Canal_Moderno()
        lb_Rcm_Lote.Text = "Lote"
        lb_Rcm_Fecha.Text = "Fecha"
        tb_Rcm_Recibo.Text = ""
        dtp_Rcm_Fecha.Text = ""
        cb_Rcm_Canal.DataSource = Nothing
        tb_Rcm_Monto.Text = "0.000000"
        cb_Rcm_Banco.DataSource = Nothing
    End Sub

    Private Sub tb_Ac_Cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Ac_Cliente.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Ac_Cliente.Text) Then
                MsgBox("Debe Ingresar Un codigo Valido", MsgBoxStyle.Critical, "Error")
                tb_Ac_Cliente.Focus()
                tb_Ac_Cliente.SelectAll()

            Else : Busca_Clientes_Anticipo()
                tb_Ac_Cliente.Enabled = False
                Combo_Anticipos()
            End If
        End If
    End Sub

    Private Sub Busca_Clientes_Anticipo()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "Select RazonSocial,ejecutivo Vendedor From Ctacte where empresa='" & gs_empresa & "' and ctacte='" & tb_Ac_Cliente.Text & "' and tipoctacte='Cliente'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            lb_AcRazon.Text = dt.Rows(0).Item("RazonSocial")
            lb_AcVendedor.Text = dt.Rows(0).Item("Vendedor")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tb_Ac_Recibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Ac_Recibo.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Ac_Recibo.Text) Then
                MsgBox("Debe Ingresar Numero Valido", MsgBoxStyle.Critical, "Recibo")
                tb_Ac_Recibo.Focus()
                tb_Ac_Recibo.SelectAll()
            Else
                dtp_Ac_Fecha.Focus()
            End If
        End If
    End Sub

    Private Sub dtp_Ac_Fecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_Ac_Fecha.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Ac_Monto.Focus()
        End If
    End Sub

    Private Sub tb_Ac_Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Ac_Monto.KeyPress
        Dim montoa As Double

        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Ac_Monto.Text) Then
                MsgBox("Debe Ingresar Monto Valido", MsgBoxStyle.Critical, "Monto")
                tb_Ac_Monto.Focus()
                tb_Ac_Monto.SelectAll()
            Else
                montoa = tb_Ac_Monto.Text
                tb_Ac_Monto.Text = Format(montoa, "###,##0.000000")
                cb_Ac_Tipo.Focus()
            End If
        End If
    End Sub

    Private Sub cb_Ac_Tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Ac_Tipo.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_Ac_Tipo.Text.Length > 0 Then
                If cb_Ac_Tipo.Text = "CONTADO EFECTIVO" Then
                    cb_Ac_Banco.Text = ""
                    tb_Ac_Cheque.Text = ""
                    btn_AcAgregar.Focus()
                Else
                    cb_Ac_Banco.Focus()
                End If
            Else
                MsgBox("Debe Seleccionar Tipo Cobro", MsgBoxStyle.Information, "Tipo")
                cb_Ac_Tipo.Focus()
            End If
        End If
    End Sub

    Private Sub cb_Ac_Banco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Ac_Banco.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_Ac_Banco.Text.Length > 0 Then
                btn_AcAgregar.Focus()
            Else
                MsgBox("Debe Seleccionar Banco", MsgBoxStyle.Information, "Banco")
                cb_Ac_Banco.Focus()
            End If
        End If
    End Sub

    Private Sub btn_AcAgregar_Click(sender As Object, e As EventArgs) Handles btn_AcAgregar.Click
        If MsgBox("Seguro de Agregar Anticipo?", MsgBoxStyle.YesNo, "Anticipo de Clientes") = MsgBoxResult.Yes Then
            Agregar_Anticipos()
        Else
            Limpia_Anticipos()
        End If
    End Sub

    Private Sub Agregar_Anticipos()

        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim monto As Double
        Dim smonto As String = ""

        Try
            otrans.open()   'abre conexion

            monto = tb_Ac_Monto.Text
            smonto = Format(monto, "######0.000000")

            lsSQL = "spa_Recibos_Lote_Anticipos '" & gs_empresa & "','" & lb_Rcm_Lote.Text & "','" & lb_Rcm_Fecha.Text & "','" & tb_Ac_Recibo.Text & "','" & tb_Ac_Cliente.Text & "','" & lb_AcRazon.Text & "','" & smonto & "','" & cb_Ac_Tipo.Text & "','" & cb_Ac_Banco.Text & "','" & tb_Ac_Cheque.Text & "','" & gs_usuario & "'"
            otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            MsgBox("Anticipo de Cliente Agregado, Verifique", MsgBoxStyle.Information, "Anticipo")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            Limpia_Anticipos()
        End Try
    End Sub

    Private Sub Limpia_Anticipos()
        tb_Ac_Cliente.Enabled = True
        tb_Ac_Cliente.Text = ""
        tb_Ac_Recibo.Text = ""
        tb_Ac_Monto.Text = "0.000000"
        cb_Ac_Tipo.DataSource = Nothing
        cb_Ac_Banco.DataSource = Nothing
        tb_Ac_Cliente.Focus()
    End Sub

    Private Sub Combo_Anticipos()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("SCM")
        otrans.open()

        ls_SqlScript = "pa_vb_Recibos_Formas_Pago '" & gs_empresa & "'"


        '" & gs_empresa & "'"

        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Formas"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Ac_Tipo.DisplayMember = "Codigo"
        Me.cb_Ac_Tipo.ValueMember = "Codigo"
        Me.cb_Ac_Tipo.DataSource = ldt_table

        ls_SqlScript = "spa_Recibos_Lote_Bancos '" & gs_empresa & "'"

        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Bancos"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Ac_Banco.DisplayMember = "Descripcion"
        Me.cb_Ac_Banco.ValueMember = "Descripcion"
        Me.cb_Ac_Banco.DataSource = ldt_table


    End Sub

    Private Sub Desactiva_Grupos()
        GroupBox1.Enabled = False
        GroupBox9.Enabled = False
        GroupBox10.Enabled = False
        GroupBox11.Enabled = False
    End Sub

    Private Sub Load_Depositos()

        Dim ldt_table As New DataTable
        ' Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        '  Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()

        tb_Tipod.Text = "DEPOSITOS"
        tb_Tipod.Enabled = False
        tb_Glosad.Text = "DEPOSITO EN "
        tb_Glosa2d.Text = "DEPOSITO EN "
        tb_Glosad.Enabled = True
        tb_Glosa2d.Enabled = True
        GroupBox9.Enabled = True
        GroupBox10.Enabled = True
        GroupBox11.Enabled = True
        tb_Documento.Enabled = False
        tb_Numerod.Enabled = False

        Try
            ls_SqlScript = "flexline.pa_sel_um_gen_tabcod null,'GEN_LOCAL','DMARTE1'"
            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "local"
            l_Dataset.Tables.Add(ldt_table.Copy)
            Me.cmb_ubicacion.DisplayMember = "CODIGO"
            Me.cmb_ubicacion.ValueMember = "CODIGO"
            Me.cmb_ubicacion.DataSource = ldt_table
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try


    End Sub

    Private Sub Carga_Cuentas()
        Dim ldt_table As New DataTable
        ' Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        '  Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript, ls_sql As String

        Dim otrans As New Transaccional.Conexion("SCM")
        otrans.open()

        ls_SqlScript = "Recibos_Lote_Cta '" & gs_empresa & "'"

        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Cuenta"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Cuentad.DisplayMember = "Cuenta"
        Me.cb_Cuentad.ValueMember = "Cuenta"
        Me.cb_Cuentad.DataSource = ldt_table

        ls_SqlScript = "Recibos_Lote_Cta '" & gs_empresa & "'"
        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Cuenta2"
        l_Dataset.Tables.Add(ldt_table.Copy)
        Me.cb_Cuentad.DisplayMember = "Cuenta"
        Me.cb_Cuentad.ValueMember = "Cuenta"
        Me.cb_Cuentad.DataSource = ldt_table

    End Sub

    Private Sub btn_Activar_Click(sender As Object, e As EventArgs) Handles btn_Activar.Click
        Load_Depositos()
        Carga_Cuentas()
        tb_Correlativod.Focus()
    End Sub

    Private Sub tb_Correlativod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Correlativod.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_Correlativod.Text.Length > 0 Then

                If Not IsNumeric(tb_Correlativod.Text) Then
                    MsgBox("Debe Ingresar Correlativo Valido", MsgBoxStyle.Critical, "Correlativo")
                    tb_Correlativod.Focus()
                    tb_Correlativod.SelectAll()
                Else

                    Busca_Depositos()

                    cb_Cuentad.Focus()
                    tb_Documento.Text = "DEPOSITOS"
                    tb_Glosad.Text = "DEPOSITO EN"
                    tb_Glosa2d.Text = "DEPOSITO EN"
                    tb_Numerod.Text = tb_Correlativod.Text
                End If

            Else
                MsgBox("Debe Ingresar Correlativo", MsgBoxStyle.Critical, "Correlativo")
                tb_Correlativod.Focus()
            End If
        End If
    End Sub

    'Private Sub tb_Glosad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Glosad.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        tb_Glosa2d.Text = tb_Glosad.Text
    '        cb_Cuentad.Focus()
    '    End If
    'End Sub

    Private Sub tb_Debed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Debed.KeyPress
        Dim Monto As Double

        If e.KeyChar = Chr(13) Then
            If tb_Debed.Text.Length > 0 Then
                If Not IsNumeric(tb_Debed.Text) Then
                    MsgBox("Debe Ingresar Valor Valido", MsgBoxStyle.Critical, "Monto")
                    tb_Debed.Focus()
                    tb_Debed.SelectAll()
                Else
                    Monto = tb_Debed.Text
                    tb_Debed.Text = Format(Monto, "##,###,##0.000000")
                    btn_Agregard.Focus()
                End If
            Else
                MsgBox("Debe Ingresar Valor", MsgBoxStyle.Critical, "Monto")
            End If
        End If
    End Sub

    Private Sub btn_Agregard_Click(sender As Object, e As EventArgs) Handles btn_Agregard.Click
        Crea_Deposito()
        'Limpia_Depositos()
    End Sub

    Private Sub Crea_Deposito()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim lsSQL2 As String
        Dim monto As Double
        Dim smonto As String

        Try

            otrans.open()   'abre conexion

            monto = tb_Debed.Text
            smonto = Format(monto, "######0.00000")

            lsSQL = "spa_Recibos_Deposito '" & gs_empresa & "','" & tb_Correlativod.Text & "','" & dtp_Fechad.Text & "','" & Mid(tb_Glosa2d.Text, 1, 40) & "','" & Mid(cb_Cuentad.Text, 1, 9) & "','" & smonto & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            lsSQL2 = "spa_Lote_Muestra_Deposito '" & gs_empresa & "','" & tb_Correlativod.Text & "'"
            dt = otrans.Obtiene(lsSQL2)
            dgv_Comprobante.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            Limpia_Anticipos()
        End Try
    End Sub

    Private Sub Limpia_Depositos()
        tb_Correlativod.Text = ""
        tb_Glosad.Text = ""
        tb_Glosa2d.Text = ""
        tb_Debed.Text = "0.000000"
        tb_Documento.Text = ""
        tb_Numerod.Text = ""
        dgv_Comprobante.DataSource = Nothing
        tb_Correlativod.Focus()
    End Sub

    Private Sub btn_Limpiard_Click(sender As Object, e As EventArgs) Handles btn_Limpiard.Click
        Limpia_Depositos()
    End Sub

    Private Sub Busca_Depositos()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        Dim lsSQL2 As String
        Dim monto As Double
        Dim smonto As String

        Try

            otrans.open()   'abre conexion

            lsSQL = "spa_Lote_Busca_Deposito '" & gs_empresa & "','" & tb_Correlativod.Text & "'"
            dt = otrans.Obtiene(lsSQL)

            tb_Correlativod.Text = dt.Rows(0).Item("Correlativo")

            If tb_Correlativod.Text.Length > 0 Then
                dtp_Fechad.Text = dt.Rows(0).Item("Fecha")
                tb_Tipod.Text = dt.Rows(0).Item("Tipo")
                tb_Correlativod.Text = dt.Rows(0).Item("Correlativo")
                tb_Glosad.Text = dt.Rows(0).Item("Glosa")
                cb_Cuentad.Text = dt.Rows(0).Item("Cuenta")
                tb_Debed.Text = dt.Rows(0).Item("Monto")

                tb_Glosa2d.Text = dt.Rows(0).Item("Glosa")
                tb_Documento.Text = dt.Rows(0).Item("Tipo")
                tb_Numerod.Text = dt.Rows(0).Item("Correlativo")

                If dt.Rows(0).Item("Actualizado") = 1 Then
                    lb_Estadod.Text = "Deposito: Actualizado"
                    btn_Creard.Enabled = False
                    tb_Debed.Enabled = False
                    btn_Agregard.Enabled = False
                Else
                    lb_Estadod.Text = "Deposito: No Actualizado"
                    btn_Creard.Enabled = True
                End If

                lsSQL2 = "spa_Lote_Muestra_Deposito '" & gs_empresa & "','" & tb_Correlativod.Text & "'"
                dt = otrans.Obtiene(lsSQL2)
                dgv_Comprobante.DataSource = dt
            Else
                MsgBox("No Existen Datos, Proceda a Crear El Deposito")
            End If


        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            MsgBox("No Existen Datos, Proceda a Crear El Deposito")
        Finally
            otrans.close()

        End Try
    End Sub

    Private Sub btn_Creard_Click(sender As Object, e As EventArgs) Handles btn_Creard.Click
        If MsgBox("Seguro que Desea Crear En Contabilidad el Depositos: " & tb_Correlativod.Text & " ?", MsgBoxStyle.YesNo, "Depoisto") = MsgBoxResult.Yes Then
            Crea_Poliza()
            Limpia_Depositos()
        End If
    End Sub

    Private Sub Crea_Poliza()
        Dim dt As DataTable
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String
        'Dim lsSQL2 As String
        'Dim monto As Double
        'Dim smonto As String

        Try

            otrans.open()   'abre conexion

            lsSQL = "spa_Depositos_Contabilidad '" & gs_empresa & "','" & tb_Correlativod.Text & "','" & dtp_Fechad.Text & "','" & gs_usuario & "','" & cmb_ubicacion.Text & "'"
            dt = otrans.Obtiene(lsSQL)
            MsgBox("Deposito Actualizado Correctamente", MsgBoxStyle.Information, "Deposito: " & tb_Correlativod.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
        End Try
    End Sub

    Private Sub cb_Cuentad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Cuentad.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Debed.Focus()
        End If
    End Sub

    Private Sub dtp_Fechad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_Fechad.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Correlativod.Focus()
        End If
    End Sub

    Private Sub btn_AutoActivar_Click(sender As Object, e As EventArgs) Handles btn_AutoActivar.Click
        Auto_Crea_Tabla()
        GroupBox12.Enabled = True
        GroupBox13.Enabled = True
        GroupBox14.Enabled = True
        GroupBox15.Enabled = True
        btn_AutoAgregar.Enabled = False
        btn_AutoActivar.Enabled = False

        btn_Generar.Enabled = False


    End Sub

    Private Sub Auto_Crea_Tabla()
        _dtAutoRecibos = New DataTable("Tmp_Recibos")

        _dtAutoRecibos.Columns.Add(New DataColumn("Empresa", GetType(String)))
        _dtAutoRecibos.Columns.Add(New DataColumn("Recibo", GetType(String)))
        _dtAutoRecibos.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        _dtAutoRecibos.Columns.Add(New DataColumn("Fecha", GetType(String)))
        _dtAutoRecibos.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtAutoRecibos.Columns.Add(New DataColumn("Cliente", GetType(String)))
        _dtAutoRecibos.Columns.Add(New DataColumn("Nombre", GetType(String)))
        _dtAutoRecibos.Columns.Add(New DataColumn("Monto", GetType(Double)))
        dgv_AutoDetalle.DataSource = _dtAutoRecibos

        _dtAutoFact = New DataTable("Tmp_Fact")

        _dtAutoFact.Columns.Add(New DataColumn("Tipodocto", GetType(String)))
        _dtAutoFact.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtAutoFact.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtAutoFact.Columns.Add(New DataColumn("Total", GetType(Double)))
        dgv_AutoFacturas.DataSource = _dtAutoFact
    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Auto_Nuevo()
    End Sub

    Private Sub Auto_Nuevo()
        tb_AutoCheque.Text = ""
        tb_AutoCliente.Text = ""
        tb_AutoMontoTotal.Text = "0.000000"
        tb_AutoMonto.Text = "0.000000"
        tb_AutoMontoCobro.Text = "0.000000"
        tb_AutoNumero.Text = ""
        tb_AutoTipoDocto.Text = ""
        tb_AutoFecha.Text = ""
        tb_AutoCorrelativo.Text = ""
        tb_AutoCliente.Enabled = True
        btn_Asignar.Enabled = True
        dtp_AutoFecha.Enabled = True
        btn_AutoBuscar.Enabled = True
        dgv_AutoDetalle.DataSource = Nothing
        Auto_Crea_Tabla()
        tb_AutoCorrelativo.Focus()
    End Sub

    Private Sub Auto_Limpia()
        'tb_AutoCheque.Text = ""
        tb_AutoMonto.Text = "0.000000"
        tb_AutoMontoCobro.Text = "0.000000"
        tb_AutoNumero.Text = ""
        tb_AutoTipoDocto.Text = ""
        tb_AutoFecha.Text = ""
    End Sub

    Private Sub tb_AutoCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_AutoCliente.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_AutoCorrelativo.Text.Length = 0 Then
                If MsgBox("No se ha Asignado o Creado Correlativo de Recibo, Desea Crear Uno?", MsgBoxStyle.YesNo, "Correlativo") = MsgBoxResult.Yes Then
                    Auto_Asigna_Correlativo("RECIBO")
                    Busca_Auto_Cliente()
                Else
                    Busca_Auto_Cliente()
                End If
            Else
                Busca_Auto_Cliente()
            End If
        End If

    End Sub

    Private Sub Auto_Asigna_Correlativo(Tipo As String)
        Dim dt As New DataTable
        Dim ls_SqlScript As String
        Dim otrans As New Transaccional.Conexion("SCM")
        Try
            otrans.open()

            ls_SqlScript = "pa_vb_Recibos_Auto_Correlativo '" & gs_empresa & "','" & Tipo & "'"
            dt = otrans.Obtiene(ls_SqlScript)  'obtiene o ejecuta el procedimiento para extraer los datos

            If Tipo = "RECIBO" Then
                tb_AutoCorrelativo.Text = dt.Rows(0).Item("Correlativo")
            Else
                tb_AutoLote.Text = dt.Rows(0).Item("Correlativo")
            End If

        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btn_Asignar_Click(sender As Object, e As EventArgs) Handles btn_Asignar.Click
        Auto_Asigna_Correlativo("RECIBO")
        '   Carga_AutoCombo()
        tb_AutoCliente.Focus()
    End Sub

    Private Sub btn_AutoBuscar_Click(sender As Object, e As EventArgs) Handles btn_AutoBuscar.Click
        If tb_AutoCorrelativo.Text.Length = 0 Then
            If MsgBox("No se ha Asignado o Creado Correlativo de Recibo, Desea Crear Uno?", MsgBoxStyle.YesNo, "Correlativo") = MsgBoxResult.Yes Then
                Auto_Asigna_Correlativo("RECIBO")
                Busca_Auto_Cliente()
            Else
                Busca_Auto_Cliente()
            End If
        Else
            Busca_Auto_Cliente()
        End If
    End Sub

    Private Sub Busca_Auto_Cliente()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()   'abre conexion
            lsSQL = "Select replace(RazonSocial,'''','')RazonSocial ,ejecutivo Vendedor From Ctacte where empresa='" & gs_empresa & "' and ctacte='" & tb_AutoCliente.Text & "' and tipoctacte='Cliente'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            lb_AutoRazon.Text = dt.Rows(0).Item("RazonSocial")
            'lb_Vendedor.Text = dt.Rows(0).Item("Vendedor")
            btn_AutoBuscar.Enabled = False
            Muestra_AutoFacturas()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Muestra_AutoFacturas()
        Dim otrans As New Transaccional.Conexion("Flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Facturas '" & gs_empresa & "','" & tb_AutoCliente.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtAutoFact.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtAutoFact.NewRow
                dr2.Item("TipoDocto") = dr.Item("TipoDocto")
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("Fecha") = dr.Item("Fecha")
                dr2.Item("Total") = dr.Item("Total")
                _dtAutoFact.Rows.Add(dr2)

            Next

            Me.dgv_AutoFacturas.DataSource = _dtAutoFact    'Despliega el resultado del procedimiento en un Grid
            clsGen.Alinear_GridView(_dtAutoFact, Me.dgv_AutoFacturas, ",TipoDocto,Numero,Fecha,Total,", ",,", ",TipoDocto,Numero,Fecha,Total,", "", "", "", "", True, True, 275, 0)

            ' tb_AutoCliente.Enabled = False
            btn_Asignar.Enabled = False
            dtp_AutoFecha.Enabled = False


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_AutoFacturas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgv_AutoFacturas.MouseDoubleClick
        Dim nfila As Integer
        Try
            nfila = Me.dgv_AutoFacturas.CurrentRow.Index
            tb_AutoTipoDocto.Text = Me.dgv_AutoFacturas.Item("TipoDocto", nfila).Value
            tb_AutoNumero.Text = Me.dgv_AutoFacturas.Item("Numero", nfila).Value
            tb_AutoFecha.Text = Me.dgv_AutoFacturas.Item("Fecha", nfila).Value
            tb_AutoMonto.Text = Me.dgv_AutoFacturas.Item("Total", nfila).Value
            tb_AutoMontoCobro.Text = Me.dgv_AutoFacturas.Item("Total", nfila).Value
            '  Carga_AutoCombo()
            dgv_AutoFacturas.Rows.RemoveAt(nfila)
            tb_AutoMontoCobro.Focus()
            btn_AutoAgregar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            tb_AutoTipoDocto.Text = ""
            tb_AutoNumero.Text = ""
            tb_AutoFecha.Text = ""
            tb_AutoMonto.Text = ""
        End Try
    End Sub
    Private Sub Carga_AutoCombo()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_SqlScript As String

        Dim otrans As New Transaccional.Conexion("SCM")
        Try
            otrans.open()

            ls_SqlScript = "pa_vb_Recibos_Formas_Pago '" & gs_empresa & "'"

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "Formas"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_AutoTipoCobro.DisplayMember = "Codigo"
            Me.cb_AutoTipoCobro.ValueMember = "Codigo"
            Me.cb_AutoTipoCobro.DataSource = ldt_table

            ls_SqlScript = "spa_Recibos_Lote_Bancos '" & gs_empresa & "'"

            ldt_table = otrans.Obtiene(ls_SqlScript)
            ldt_table.TableName = "Bancos"
            l_Dataset.Tables.Add(ldt_table.Copy)

            Me.cb_AutoBanco.DisplayMember = "Descripcion"
            Me.cb_AutoBanco.ValueMember = "Descripcion"
            Me.cb_AutoBanco.DataSource = ldt_table
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub



    Private Sub tb_AutoCheque_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then

            If tb_AutoCheque.Text.Length = 0 Then
                tb_AutoCheque.Text = tb_AutoCorrelativo.Text
                btn_AutoAgregar.Enabled = True
                btn_AutoAgregar.Focus()
            Else
                btn_AutoAgregar.Enabled = True
                btn_AutoAgregar.Focus()
            End If
        End If
    End Sub

    Private Sub btn_AutoAgregar_Click(sender As Object, e As EventArgs) Handles btn_AutoAgregar.Click
        Auto_Agregar()
        Auto_Vista_Detalle_Lote()
        Auto_Limpia()
        btn_AutoAgregar.Enabled = False
        btn_AutoActualizar.Enabled = True
        tb_AutoCliente.Enabled = True
        btn_AutoBuscar.Enabled = True
        btn_Asignar.Enabled = True

    End Sub

    Private Sub Auto_Agregar()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim lbmonto As String
        Dim lbmontod As Double
        Dim tbmonto As String
        Dim tbmontod As Double

        Try
            lbmontod = CDbl(tb_AutoMonto.Text)
            tbmontod = CDbl(tb_AutoMontoCobro.Text)

            lbmonto = Format(lbmontod, "######0.000000")
            tbmonto = Format(tbmontod, "######0.000000")

            If cb_AutoTipoCobro.Text = "CONTADO EFECTIVO" Then
                cb_AutoBanco.Text = ""
                'tb_ChequeRm.Text = ""
            End If

            Utrans.open()
            ls_sql = "spa_Recibos_Guarda_Linea  '" & gs_empresa & "','" & tb_AutoLote.Text & "','" & dtp_AutoFecha.Text & "','" & tb_AutoCorrelativo.Text & "','" & tb_AutoTipoDocto.Text & "','" & tb_AutoFecha.Text & "','" & tb_AutoNumero.Text & "','" & tb_AutoCliente.Text & "','" & lb_AutoRazon.Text & "','" & tb_AutoMontoCobro.Text & "','" & cb_AutoTipoCobro.Text & "','" & tb_AutoMontoCobro.Text & "','" & cb_AutoBanco.Text & "','" & tb_AutoCheque.Text & "','1', '" & gs_usuario & "'"
            Utrans.Ingresa(ls_sql)

            'MsgBox("Agregado Con Exito!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub btn_Lote_Click(sender As Object, e As EventArgs) Handles btn_AutoLote.Click
        Auto_Asigna_Correlativo("LOTE")
        btn_AutoLote.Enabled = False
        tb_AutoLote.Enabled = False
        Carga_AutoCombo()
    End Sub

    Private Sub Auto_Vista_Detalle_Lote()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Muestra '" & gs_empresa & "','" & tb_AutoLote.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            dgv_AutoDetalle.DataSource = dt

            Auto_Total()

            tb_Estado.Text = dt.Rows(0).Item("Estado")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
        End Try
    End Sub

    Private Sub Auto_Total()
        Dim ntotal As Double
        Dim dt As DataTable
        ' Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            '    Otrans.open()   'abre conexion
            dt = Me.dgv_AutoDetalle.DataSource

            ntotal = dt.Compute("sum(Monto)", "Monto>0")
            Me.lb_AutoTotal.Text = Format(ntotal, "###,##0.00")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_AutoActualizar.Click

        If CDbl(tb_AutoMontoTotal.Text) <> CDbl(lb_AutoTotal.Text) Then

            MsgBox("El Monto de la Transacción no Cuadra contra la Suma Total de Movimientos, Verifique", MsgBoxStyle.Critical, "Descuadre")
            Exit Sub
        Else

            If MsgBox("Se Emitiran las Partidas Contables y se imprimiran los recibos del Lote Actual", MsgBoxStyle.YesNo, "Actualizar") = MsgBoxResult.Yes Then

                AutoVerifica()
                Reporte_Auto_Actualizado()
                Impresion_Auto_Recibo()
                btn_AutoActualizar.Enabled = False
                btn_AutoLote.Enabled = True
                Nuevo_Auto()
            Else
                Nuevo_Auto()
            End If

        End If



    End Sub

    Private Sub Impresion_Auto_Recibo()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(1) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim Deposito As String
        Dim Lote As String

        Try

            If tb_AutoLote.Text.Length = 0 Then
                MsgBox("No Existe Lote para Imprimir Recibos, Verifique!!")
                Exit Sub
            Else
                Lote = tb_AutoLote.Text
            End If


            pm_conexion = ClsGen.Parametros_Conexion("SCM")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Creditos\Jefatura\Impresion De Recibos Citizen.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Lote"
            pm_valores(1) = Lote

            pm_parametros(2) = "@Usuario"
            pm_valores(2) = gs_usuario


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub Reporte_Auto_Actualizado()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim Deposito As String
        Dim Lote As String


        Try

            If tb_AutoLote.Text.Length = 0 Then
                MsgBox("No Existe Lote para Imprimir Recibos, Verifique!!")
                Exit Sub
            Else
                Lote = tb_AutoLote.Text
            End If


            pm_conexion = ClsGen.Parametros_Conexion("SCM")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Jefatura\Impresion De Lotes Recibos Cuadrados.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Lote"
            pm_valores(1) = Lote


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try
    End Sub


    Private Sub Nuevo_Auto()
        Auto_Nuevo()
        tb_AutoLote.Text = ""
        btn_AutoActualizar.Enabled = False
        lb_AutoTotal.Text = "0.000000"
        dgv_AutoDetalle.DataSource = Nothing
        Auto_Crea_Tabla()
    End Sub

    Private Sub tb_Auto_Busca_Lote_Click(sender As Object, e As EventArgs) Handles tb_Auto_Busca_Lote.Click
        Auto_BuscaLote()
    End Sub

    Private Sub Auto_BuscaLote()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Dim oForm As New Frm_Recibos_Lote_Busca
        oForm.ShowDialog()

        If oForm.Lote = Nothing Then
            MsgBox("No Existen Lotes", MsgBoxStyle.Information, "Verifique")
        Else
            Try

                Me.tb_AutoLote.Text = oForm.Lote
                Me.dtp_AutoFecha.Text = oForm.Fecha
                Me.tb_AutoCheque.Text = oForm.NumeroDocto
                'tb_AutoCheque.Enabled = False
                Me.cb_AutoTipoCobro.Text = oForm.TipoCobro

                ' cb_AutoTipoCobro.Enabled = False
                Me.cb_AutoBanco.Text = oForm.Banco
                'cb_AutoBanco.Enabled = False



                'Me.lb_Empresa.Text = gs_empresa


                otrans.open()   'abre conexion
                lsSQL = "spa_Recibos_Lote_Muestra '" & gs_empresa & "','" & tb_AutoLote.Text & "'"
                dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
                dgv_AutoDetalle.DataSource = dt

                Auto_Total()
                tb_AutoMontoTotal.Text = lb_AutoTotal.Text
                tb_Estado.Text = dt.Rows(0).Item("Estado")
                dtp_AutoFecha.Enabled = False
                btn_AutoActualizar.Enabled = True
                Carga_AutoCombo()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub AutoVerifica()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "pa_vb_Recibos_lote_Verifica '" & gs_empresa & "','" & tb_AutoLote.Text & "','" & dtp_AutoFecha.Text & "','" & 5 & "','" & gs_usuario & "'" ' & Now().ToString & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows.Count > 0 Then
                MsgBox("El Lote " & tb_AutoLote.Text & " Ya existe en Contabilidad con fecha , Verifique", MsgBoxStyle.Information, "Contabilidad")
            Else
                ' MsgBox("Crea la Partida...") ' 
                Auto_CreaPartida()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Auto_CreaPartida()

        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()   'abre conexion
            lsSQL = "spa_Recibos_Lote_Cursor '" & gs_empresa & "','" & tb_AutoLote.Text & "','" & dtp_AutoFecha.Text & "','4','" & gs_usuario & "'" ' & Now().ToString & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            MsgBox("El Lote " & tb_AutoLote.Text & " Se Actualizo en la Contabilidad, Verifique", MsgBoxStyle.Information, "Contabilidad")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub


    Private Sub btn_Activar_Leave(sender As Object, e As EventArgs) Handles btn_Activar.Leave
        btn_Activar.BackColor = Color.Brown
    End Sub

    Private Sub btn_Activar_MouseEnter(sender As Object, e As EventArgs) Handles btn_Activar.MouseEnter
        btn_Activar.BackColor = Color.Beige
    End Sub


    Private Sub tb_AutoMontoCobro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_AutoMontoCobro.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_AutoAgregar.Focus()
        End If
    End Sub

    Private Sub tb_AutoMontoTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_AutoMontoTotal.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_Asignar.Focus()
        End If
    End Sub

    Private Sub btn_Nuevo_Anticipo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo_Anticipo.Click
        Limpia_Anticipos()
    End Sub

    Private Sub dgv_cambiarFecha_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_cambiarFecha.CellValueChanged
        Dim dt As New DataTable
        Dim ls_SqlScript As String
        Dim l_Dataset As New DataSet
        Dim otrans As New Transaccional.Conexion("flexline")

        Try

            otrans.open()

            ' Verifica que no sea una fila nueva
            If e.RowIndex >= 0 Then
                ' Obtén la fila actual
                Dim row As DataGridViewRow = dgv_cambiarFecha.Rows(e.RowIndex)

                ' Recorre todas las columnas del DataGridView
                For Each column As DataGridViewColumn In dgv_cambiarFecha.Columns
                    ' Verifica si la columna es de tipo DataGridViewComboBoxColumn
                    If TypeOf column Is DataGridViewComboBoxColumn Then
                        ' Asigna un nombre a la columna
                        column.Name = "Empresa"
                        ' Puedes salir del bucle si solo necesitas asignar un nombre a una columna
                        Exit For
                    End If
                Next

                ' Verifica si la celda modificada es la que deseas monitorear
                If e.ColumnIndex = dgv_cambiarFecha.Columns("Lote").Index Then

                    ' Obtén el valor de la celda modificada
                    Dim valorEmpresa As String = row.Cells("Empresa").Value.ToString()
                    Dim valorOrigen As String = row.Cells("Lote").Value.ToString()

                    ' Realiza la lógica necesaria para obtener el nuevo valor
                    'Dim nuevoValor As String = "01-01-1900" ' Aquí puedes poner la lógica para calcular el nuevo valor

                    ls_SqlScript = "select Empresa, Lote, Fecha,sum(montoOrigen)Total from scm.flexline.Recibos_Lote_Acumula where empresa='" & valorEmpresa & "' and lote=" & valorOrigen & " group by Empresa, Lote, Fecha "
                    dt = otrans.Obtiene(ls_SqlScript)

                    If dt.Rows.Count > 0 Then
                        Dim nuevoValor As String = dt.Rows(0).Item("Fecha")
                        Dim nuevoTotal As Double = dt.Rows(0).Item("Total")

                        ' Asigna el nuevo valor a la celda deseada
                        row.Cells("Fecha").Value = nuevoValor
                        row.Cells("Total").Value = nuevoTotal

                    Else
                        Dim nuevoValor As String = ""
                        Dim nuevoTotal As Double = 0.00
                        row.Cells("Fecha").Value = nuevoValor
                        row.Cells("Total").Value = nuevoTotal

                    End If


                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnValidaCambio.Click
        If txtContraseña.Text = Pass Then
            gpbCambiarFecha.Enabled = True
            gpb_ActivarCambio.Enabled = True
            'btnEjecutarCambiar.Enabled = False
        End If
    End Sub

    Private Sub btnNuevoCambiar_Click(sender As Object, e As EventArgs) Handles btnNuevoCambiar.Click
        txtContraseña.Text = ""
        ' btnEjecutarCambiar.Enabled = False
        btnValidaCambio.Enabled = False

        _dtCambioFecha = New DataTable("Tmp_Cambio")
        _dtCambioFecha.Columns.Add(New DataColumn("Lote", GetType(String)))
        _dtCambioFecha.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtCambioFecha.Columns.Add(New DataColumn("Total", GetType(Double)))
        _dtCambioFecha.Columns.Add(New DataColumn("NuevaFecha", GetType(Date)))

        dgv_cambiarFecha.DataSource = _dtCambioFecha
    End Sub

    Private Sub btnValidarCambiar_Click(sender As Object, e As EventArgs) Handles btnValidarCambiar.Click
        '   btnEjecutarCambiar.Enabled = True
        validar_cambio()
    End Sub

    Private Sub validar_cambio()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim lsSQL2 As String
        Dim dt As DataTable


        For Each row As DataGridViewRow In dgv_cambiarFecha.Rows

            ' Asegúrate de que la fila no sea una fila nueva
            If Not row.IsNewRow Then

                ' Accede a las celdas por nombre de columna
                Dim cEmpresa As String = row.Cells("Empresa").Value.ToString()
                Dim cLote As String = row.Cells("lote").Value.ToString()
                Dim cFecha As String = row.Cells("NuevaFecha").Value.ToString()

                Try
                    otrans.open()   'abre conexion
                    lsSQL = "select distinct a.empresa, a.Lote, a.Fecha from scm.flexline.Recibos_Lote_Acumula a inner join flexline.GEN_TABCOD g on (g.empresa=a.empresa and codigo=convert(nchar(6),a.fecha,112) and g.texto='S' AND G.TEXTO1='SSSNN') where a.empresa='" & cEmpresa & "' and estado=4 and lote=" & cLote

                    dt = otrans.Obtiene(lsSQL)

                    If dt.Rows.Count > 0 Then

                        MsgBox("Se Procesará Lote " & cEmpresa & " - " & cLote)
                        procesar_cambio(cEmpresa, cLote, cFecha)

                    Else
                        MsgBox("No Procede Lote " & cEmpresa & " - " & cLote)
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    otrans.close()
                    otrans = Nothing
                End Try

                '   MsgBox(cEmpresa & "-" & cLote & "-" & cFecha)

            End If

        Next

    End Sub
    Private Sub procesar_cambio(empresa As String, lote As Integer, fecha As Date)
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL2 As String

        Try
            otrans.open()   'abre conexion
            lsSQL2 = "pa_upd_um_cambia_Fecha_lote_recibo '" & empresa & "'," & lote & ",'" & fecha & "','" & gs_usuario & "'"
            otrans.Obtiene(lsSQL2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub btnEjecutarCambiar_Click(sender As Object, e As EventArgs)
        MsgBox("Utilice el boton de Validar")
    End Sub

    Private Sub btnValidaLote_Click(sender As Object, e As EventArgs) Handles btnValidaLote.Click
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL2 As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion

            lsSQL2 = "select a.empresa, a.id, a.Fecha_Guia, a.Recibo from scm.flexline.liquidacion_muestra_cuadre_4 a
                    inner join flexline.GEN_TABCOD g on (g.empresa=a.empresa and g.codigo=convert(nchar(6),a.Fecha_Guia,112) and g.texto='S' AND G.TEXTO1='SSSNN')
                    where a.empresa ='" & gs_empresa & "' and a.ID=" & txtLote.Text & " and SUBSTRING(id,3,10) 
                    not in (select lote from scm.flexline.Recibos_Lote_Acumula where empresa=a.empresa and lote=SUBSTRING(id,3,10) and estado >= 4)"
            dt = otrans.Obtiene(lsSQL2)

            If dt.Rows.Count > 0 Then

                btnProcesar.Enabled = True
                MsgBox("Se puede crear lote de recibos " & txtLote.Text)
            Else

                MsgBox("No se puede crear lote de recibos " & txtLote.Text & " Valide fechas y si no existe ya....")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If MessageBox.Show("Esta Segur@ de Crear Lote de Recibos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            btnProcesar.Enabled = False
            crea_lote_recibos()
            txtLote.Text = ""
        Else
            txtLote.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub crea_lote_recibos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try
            Otrans.open()

            ls_sql = "pa_in_um_liquidacion_recibo_lote '" & txtLote.Text & "'"
            Otrans.Obtiene(ls_sql)
            MessageBox.Show("Lote de Recibos creado con Existo.... ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally

            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub btnImprime_Click(sender As Object, e As EventArgs) Handles btnImprime.Click
        Impresion_Lote_Cuadrado()
    End Sub
End Class