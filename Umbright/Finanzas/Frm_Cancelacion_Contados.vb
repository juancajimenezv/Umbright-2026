Public Class Frm_Cancelacion_Contados
    Inherits System.Windows.Forms.Form
    Dim oTransaccion As Transaccional.Conexion
    Dim ls_SqlScript As String
    Dim ls_SqlScript2 As String
    Dim oTabla1 As DataTable
    Dim pds_Dataset As New DataSet
    Dim pdataset As New DataSet
    '   Dim gs_empresa As String = "VINOTECA"
    '  Dim gs_usuario As String = "nhernandez"
    Dim dtRecibos As DataTable
    Dim _dtFacturas As DataTable
    Dim _dtDepositos As DataTable
    Dim _dtMovimientos As DataTable
    Dim _dtCorrelativo As DataTable
    Dim nada As String = "nada"



    Private Sub Frm_Cancelacion_Contados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaTabla()
        GroupBox3.Enabled = False

        tb_DepositoGeneral.Enabled = False
        tb_deposito.Text = ""

        tb_Monto.Text = "0.00"

        btn_Agregar.Enabled = False
        lb_checkDep.Visible = False

        Carga_Ubicaciones_tienda()

    End Sub

    Private Sub CreaTabla()
        _dtFacturas = New DataTable("Tmp_Facturas")
        _dtFacturas.Columns.Add(New DataColumn("Tienda", GetType(String)))
        _dtFacturas.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        _dtFacturas.Columns.Add(New DataColumn("Numero", GetType(String)))
        _dtFacturas.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        _dtFacturas.Columns.Add(New DataColumn("CodigoPago", GetType(String)))
        _dtFacturas.Columns.Add(New DataColumn("MontoOrigen", GetType(Double)))
        _dtFacturas.Columns.Add(New DataColumn("CtaCte", GetType(String)))

        '_dtDepositos = New DataTable("Tmp_Depositos")
        '_dtDepositos.Columns.Add(New DataColumn("Deposito", GetType(String)))
        '_dtDepositos.Columns.Add(New DataColumn("TipoPago", GetType(String)))
        '_dtDepositos.Columns.Add(New DataColumn("Monto", GetType(Double)))


        _dtMovimientos = New DataTable("Tmp_Movimientos")
        _dtMovimientos.Columns.Add(New DataColumn("Deposito", GetType(String)))
        _dtMovimientos.Columns.Add(New DataColumn("Monto", GetType(Double)))
        _dtMovimientos.Columns.Add(New DataColumn("CtaCte", GetType(String)))
        _dtMovimientos.Columns.Add(New DataColumn("Glosa", GetType(String)))

        _dtCorrelativo = New DataTable("Tmp_Correlativo")
        _dtCorrelativo.Columns.Add(New DataColumn("Correlativo", GetType(Integer)))


    End Sub

    Private Sub Carga_Ubicaciones_tienda()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_sql As String

        oTransaccion = New Transaccional.Conexion("SCM")
        oTransaccion.open()


        ls_sql = "select distinct Ubicacion from scm.flexline.GEN_UBICACION_VNT WHERE UBICACION!='' AND Ubicacion NOT IN ('ANTIGUA GUATEMALA','FONTABELLA') "

        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "Ubi"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Ubicacion.DisplayMember = "Ubicacion"
        Me.cb_Ubicacion.ValueMember = "Ubicacion"
        Me.cb_Ubicacion.DataSource = ldt_table

        ls_sql = "select distinct Tienda from scm.flexline.GEN_UBICACION_VNT WHERE UBICACION!='' and tienda!='' AND Ubicacion NOT IN ('ANTIGUA GUATEMALA','FONTABELLA')"
        ldt_table = oTransaccion.Obtiene(ls_sql)
        ldt_table.TableName = "Tda"
        l_Dataset.Tables.Add(ldt_table.Copy)
        Me.cb_Tienda.DisplayMember = "Tienda"
        Me.cb_Tienda.ValueMember = "Tienda"
        Me.cb_Tienda.DataSource = ldt_table
    End Sub

    Private Sub cargacombo()

        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_sql As String

        oTransaccion = New Transaccional.Conexion("SCM")
        oTransaccion.open()

        ls_SqlScript = "spa_Seleccion_Serie_Tienda '" & Me.cb_Ubicacion.Text & "','" & Me.cb_Tienda.Text & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "TpDocto"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Serie.DisplayMember = "tipodocto"
        Me.cb_Serie.ValueMember = "tipodocto"
        Me.cb_Serie.DataSource = ldt_table

    End Sub

    Private Sub btn_Continuar_Click(sender As Object, e As EventArgs) Handles btn_Continuar.Click
        Genera_Facturas()
        btn_Agregar.Enabled = True
    End Sub

    Private Sub Genera_Facturas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion
            lsSQL = "spa_Cancelacion_Facturas'" & dtp_Fecha.Text & "','" & dtp_FechaFinal.Text & "','" & cb_Tienda.Text & "','" & cb_Serie.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows.Count > 0 Then

                ' _dtFacturas.Rows.Clear()
                For Each dr As DataRow In dt.Rows
                    dr2 = _dtFacturas.NewRow
                    dr2.Item("Tienda") = dr.Item("Tienda")
                    dr2.Item("TipoDocto") = dr.Item("TipoDocto")
                    dr2.Item("Numero") = dr.Item("Numero")
                    dr2.Item("Fecha") = dr.Item("Fecha")
                    dr2.Item("CodigoPago") = dr.Item("CodigoPago")
                    dr2.Item("MontoOrigen") = dr.Item("MontoOrigen")
                    dr2.Item("CtaCte") = dr.Item("CtaCte")

                    _dtFacturas.Rows.Add(dr2)
                Next

                Me.dgv_Facturas.DataSource = _dtFacturas    'Despliega el resultado del procedimiento en un Grid
                Total()
                lb_Diferencia.Text = Format(lb_SubTotal.Text - lb_TotalDepositos.Text, "###,##0.00")
                clsGen.Alinear_GridView(_dtFacturas, Me.dgv_Facturas, ",Tienda,TipoDocto,Numero,Fecha,CodigoPago,MontoOrigen,CtaCte,", ",,", ",TipoDocto,Numero,Fecha,CodigoPago,CtaCte,", "", "", "", "", True, True, 275, 0)

            Else

                MsgBox("No Existen Datos Para Desplegar, Verifique...", MsgBoxStyle.Information, "Sin Datos...")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Cancelar()

        dtp_Fecha.Enabled = True
        dtp_FechaFinal.Enabled = True
        cb_Tienda.Enabled = True
        cb_Serie.Enabled = True
        btn_Continuar.Enabled = True

        cb_Tienda.ResetText()

        cb_Tienda.Text = ""

        cb_Serie.Text = ""
        tb_deposito.Text = ""

        Limpia_Grid()
        Limpia_Depositos()

        lb_SubTotal.Text = "0.00"
        lb_Diferencia.Text = "0.00"

        tb_deposito.Enabled = False
        btn_ProcesarC.Enabled = False

        tb_Monto.Text = "0.00"
        'tb_Monto.Enabled = False
        'cb_CuentaContable.Text = ""
        'cb_CuentaContable.Enabled = False
        'tb_SobraFalta.Text = "0.00"
        'tb_SobraFalta.Enabled = False
        tb_ClienteC.Text = ""
        tb_ClienteC.Enabled = False

        'GroupBox2.Enabled = False
        GroupBox3.Enabled = False

        cargacombo()
        dtp_Fecha.Focus()

    End Sub

    Private Sub cb_Tienda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Tienda.SelectedValueChanged
        cargacombo()
    End Sub

    Private Sub Total()
        Dim ntotal As Double
        Dim dt As DataTable
        ' Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            '    Otrans.open()   'abre conexion
            dt = Me.dgv_Facturas.DataSource

            If dt.Rows.Count > 0 Then
                ntotal = dt.Compute("sum(MontoOrigen)", "MontoOrigen>0")
                Me.lb_SubTotal.Text = Format(ntotal, "###,##0.00")
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GeneraDeposito()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim deposito As Double
        Dim MontoC2 As Double
        Dim depositoC2 As String

        Try

            If tb_deposito.Text.Length > 0 Then
                deposito = CDbl(Me.tb_deposito.Text)
                Utrans.open()

                ls_sql = "flexline.spa_Crea_Partida_Tmp_Contado '" & Me.dtp_Fecha.Text & "','" & Me.dtp_FechaFinal.Text & "','" & Me.cb_Tienda.Text & "','CONTADO','" & Me.cb_Serie.Text & "','" & Me.tb_deposito.Text & "','" & "Admin','" & depositoC2 & "','" & MontoC2 & "','""','nada','" & tb_ClienteC.Text & "'"
                Utrans.Ingresa(ls_sql)
                MsgBox("Proceso Generado Con Existe, Debe Revisar y Actualizar!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")
                '    Reporte()
            Else
                Cancelar()
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Cancelar()
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub dgv_Facturas_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_Facturas.RowsRemoved
        'MsgBox("rows_removed")
        lb_Diferencia.Text = Format(lb_SubTotal.Text, "###,##0.00")
    End Sub

    Private Sub dgv_Facturas_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_Facturas.SelectionChanged
        Total()
        'MsgBox("selectionchanged")

    End Sub
    Private Sub ReiniciaIdentidad()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Try
            Utrans.open()
            ls_sql = "DBCC CHECKIDENT (CON_MOVCOM_TC, RESEED,0) "
            Utrans.Obtiene(ls_sql)
        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado ", MsgBoxStyle.Critical, "Error")
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub btn_ProcesarC_Click(sender As Object, e As EventArgs) Handles btn_ProcesarC.Click

        If CDbl(lb_Diferencia.Text) > 0 Then
            MsgBox("Existe Diferencia, Favor Verifique !!", MsgBoxStyle.Critical, "Diferencia")
            '       tb_SobraFalta.SelectAll()
            '      tb_SobraFalta.Focus()

        Else

            If MsgBox("Seguro de Procesar El Deposito " & tb_deposito.Text & " ?", MsgBoxStyle.YesNo, "Procesar Deposito") = MsgBoxResult.Yes Then
                ReiniciaIdentidad()
                Genera_Deposito()
                Genera_Reporte()
                Me.Close()
            Else
                Cancelar()
            End If
        End If
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        Actualiza_Correlativo()
        Agregar_Preparacion()

        btn_Agregar.Enabled = False

    End Sub

    Private Sub Agrega_Sobrante_Faltante()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim deposito As Double
        Dim MontoD As Double
        Dim MontoH As Double
        Dim CodigoPago As String
        Dim TipoDocto As String
        Dim cb_CuentaContable As String = "nada"
        Dim tb_SobraFalta As String = "nada"

        Try

            If cb_CuentaContable.Length > 0 Then

                If tb_SobraFalta.Length > 0 Then

                    If Not (IsNumeric(tb_SobraFalta)) Then

                        MsgBox("Se Debe Ingresar Valores Numericos, Verifique ", MsgBoxStyle.Critical, "Precaución")

                    Else

                        If cb_CuentaContable = "FALTANTE" Or cb_CuentaContable = "DOLARES" Or cb_CuentaContable = "ANTICIPO" Then
                            MontoD = CDbl(tb_SobraFalta)
                            MontoH = 0
                        Else    'If cb_CuentaContable.Text = "SOBRANTE" Then
                            MontoH = CDbl(tb_SobraFalta)
                            MontoD = 0
                        End If

                        If cb_CuentaContable = "OCCIDENTE" Or cb_CuentaContable = "AGROMERCANTIL" Or cb_CuentaContable = "BI" Or cb_CuentaContable = "CITI" _
                            Or cb_CuentaContable = "CREDOMATIC" Or cb_CuentaContable = "G&T" Or cb_CuentaContable = "PROMERICA " Then
                            CodigoPago = cb_CuentaContable
                            TipoDocto = "CANJE"
                        Else
                            CodigoPago = "CONTADO"
                            '      TipoDocto = cb_CuentaContable.Text
                        End If

                        Utrans.open()
                        ls_sql = "spa_Cancelacion_Prepara '" & gs_empresa & "','" & cb_Tienda.Text & "','" & tb_DepositoGeneral.Text & "','" & TipoDocto & "','" & tb_DepositoGeneral.Text & "','" & dtp_Fecha_Operacion.Text & "','" & CodigoPago & "','" & MontoD & "','" & MontoH & "','" & tb_ClienteC.Text & "','" & tb_Glosa.Text & "'"
                        Utrans.Ingresa(ls_sql)
                        MsgBox("Proceso Generado Con Exito", MsgBoxStyle.MsgBoxSetForeground, "Generado")
                        Muestra_Movimiento()
                        '     lb_checkMov.Visible = True
                        ' lb_Diferencia.Text = Format(lb_Diferencia.Text - tb_SobraFalta.Text, "###,##0.00")
                        '    cb_CuentaContable.Text = ""
                        tb_ClienteC.Text = ""
                        '   tb_SobraFalta.Text = "0.00"
                        tb_Glosa.Text = ""

                        'Else
                        '    MsgBox("Falta Cliente/Proveedor", MsgBoxStyle.Critical)
                        '    tb_ClienteC.Focus()
                        'End If
                    End If
                Else
                    MsgBox("Falta Monto", MsgBoxStyle.Critical)

                End If

            Else
                MsgBox("Falta Movimiento", MsgBoxStyle.Critical)

            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try

    End Sub

    Private Sub Genera_Deposito()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try


            tb_deposito.Enabled = True
            tb_Monto.Enabled = True

            If CDbl(lb_Diferencia.Text) = 0 Then

                Utrans.open()
                ls_sql = "spa_Cancelacion_Crea_Partida_Tmp '" & gs_empresa & "','" & tb_DepositoGeneral.Text & "','" & dtp_Fecha_Operacion.Text & "','" & cb_Ubicacion.Text & "','" & gs_usuario & "'"
                Utrans.Ingresa(ls_sql)
                MsgBox("Deposito Generado Con Existo!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")
                lb_checkDep.Visible = True
                lb_Diferencia.Text = Format(lb_SubTotal.Text - lb_TotalDepositos.Text, "###,##0.00")
            Else
                MsgBox("Existe Diferencia, No Se Puede Crear Deposito", MsgBoxStyle.Critical)
                tb_Monto.Focus()
                End
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub Limpia_Grid()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion
            lsSQL = "select top 0 Tienda,TipoDocto,Numero,Fecha,CodigoPago,MontoOrigen from SCM.flexline.Recibos_Tvn_Prepara'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtFacturas.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtFacturas.NewRow
                dr2.Item("Tienda") = dr.Item("Tienda")
                dr2.Item("TipoDocto") = dr.Item("TipoDocto")
                dr2.Item("Numero") = dr.Item("Numero")
                dr2.Item("Fecha") = dr.Item("Fecha")
                dr2.Item("CodigoPago") = dr.Item("CodigoPago")
                dr2.Item("MontoOrigen") = dr.Item("MontoOrigen")
                dr2.Item("CtaCte") = dr.Item("CtaCte")

                _dtFacturas.Rows.Add(dr2)
            Next

            Me.dgv_Facturas.DataSource = _dtFacturas    'Despliega el resultado del procedimiento en un Grid
            'Total()
            clsGen.Alinear_GridView(_dtFacturas, Me.dgv_Facturas, ",Tienda,TipoDocto,Numero,Fecha,CodigoPago,MontoOrigen,CtaCte,", ",,", ",Tienda,TipoDocto,Numero,Fecha,CodigoPago,MontoOrigen,CtaCte,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Cancelar()
    End Sub

    Private Sub Agregar_Preparacion()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim ldt_table As DataTable
        Dim l_Dataset As New DataSet

        If MessageBox.Show("¿Se Agregaran Las Facturas a La Preparación?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Cancelar()

        Try

            Otrans.open()   'abre conexion
            dt = Me.dgv_Facturas.DataSource()

            For Each dr As DataRow In dt.Rows

                ls_sql = "spa_Cancelacion_Prepara '" & gs_empresa & "','" & cb_Ubicacion.Text & "','" & dr.Item("Tienda") & "','" & tb_DepositoGeneral.Text & "','" & dr.Item("TipoDocto") & "','" & dr.Item("Numero") & "','" & dtp_Fecha_Operacion.Text & "','" & dr.Item("CodigoPago") & "',0,'" & dr.Item("MontoOrigen") & "','" & dr.Item("CtaCte") & "','','','',''"
                Otrans.Obtiene(ls_sql)
            Next

            ' dt.DefaultView.RowFilter = ""
            MessageBox.Show("Las Facturas Fueron Agregadas a La Preparación", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tb_deposito.Enabled = True
            GroupBox3.Enabled = True

            ls_SqlScript = "select codigo Operacion, DESCRIPCION, TEXTO Cuenta, TEXTO1, TEXTO2 TipoPago, Texto3, Texto4 from GEN_TABCOD where TIPO='CON_CANCELACION' order by codigo " ' Me.cb_Ubicacion.Text & "','" & Me.cb_Tienda.Text & "'"
            ldt_table = Otrans.Obtiene(ls_SqlScript)

            If ldt_table.Rows.Count > 0 Then
                ldt_table.TableName = "Op"
                l_Dataset.Tables.Add(ldt_table.Copy)
                Me.cb_Operacion.DisplayMember = "DESCRIPCION"
                Me.cb_Operacion.ValueMember = "DESCRIPCION"
                Me.cb_Operacion.DataSource = ldt_table

                lb_Operacion.Text = ldt_table.Rows(0).Item("Operacion")
                lb_Cuenta.Text = ldt_table.Rows(0).Item("Cuenta")
                lb_TipoPago.Text = ldt_table.Rows(0).Item("TipoPago")
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub Combo_Operaciones()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ldt_table As DataTable
        Dim l_Dataset As New DataSet

        Try
            Otrans.open()

            lb_Operacion.Text = ""
            lb_Cuenta.Text = ""
            lb_TipoPago.Text = ""
            lb_DH.Text = ""

            ls_SqlScript = "select codigo Operacion, DESCRIPCION, TEXTO Cuenta, TEXTO1, TEXTO2 TipoPago, Texto3, Texto4, TEXTO5 dh from GEN_TABCOD where TIPO='CON_CANCELACION' and descripcion='" & cb_Operacion.Text & "'"
            ldt_table = Otrans.Obtiene(ls_SqlScript)

            'ldt_table.TableName = "Op"
            'l_Dataset.Tables.Add(ldt_table.Copy)
            'Me.cb_Operacion.DisplayMember = "DESCRIPCION"
            'Me.cb_Operacion.ValueMember = "DESCRIPCION"
            'Me.cb_Operacion.DataSource = ldt_table
            If ldt_table.Rows.Count > 0 Then
                lb_Operacion.Text = ldt_table.Rows(0).Item("Operacion")
                lb_Cuenta.Text = ldt_table.Rows(0).Item("Cuenta")
                lb_TipoPago.Text = ldt_table.Rows(0).Item("TipoPago")
                lb_DH.Text = ldt_table.Rows(0).Item("dh")

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub


    Private Sub btn_SobraFalta_Click(sender As Object, e As EventArgs)
        Agrega_Sobrante_Faltante()


    End Sub

    'Private Sub btn_Deposito2_Click(sender As Object, e As EventArgs) Handles btn_Deposito.Click
    '    Agrega_Deposito()
    '    Muestra_Depositos()
    '    btn_ProcesarC.Enabled = True

    'End Sub

    Private Sub Agrega_Deposito()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql, ls_sql2 As String
        Dim deposito As Double
        Dim Monto As Double
        Dim depositoC2 As String

        Try
            tb_deposito.Enabled = True
            tb_Monto.Enabled = True

            If tb_deposito.Text.Length > 0 Then

                If Not (IsNumeric(tb_deposito.Text)) Or Not (IsNumeric(tb_Monto.Text)) Then
                    MsgBox("Se Debe Ingresar Valores Numericos", MsgBoxStyle.Critical, "Precaución")
                    tb_deposito.Focus()
                Else


                    Monto = CDbl(Me.tb_Monto.Text)

                    Utrans.open()
                    ls_sql = "spa_Cancela_Deposito '" & gs_empresa & "','" & cb_Ubicacion.Text & "','" & tb_DepositoGeneral.Text & "','" & lb_Operacion.Text & "','" & lb_Cuenta.Text & "','" & tb_deposito.Text & "','" & lb_TipoPago.Text & "','" & Monto & "','" & gs_usuario & "','" & cb_Tienda.Text & "','" & tb_ClienteC.Text & "','" & tb_Glosa.Text & "'"
                    Utrans.Obtiene(ls_sql)

                    ls_sql2 = "spa_Cancelacion_Prepara '" & gs_empresa & "','" & cb_Ubicacion.Text & "','" & cb_Tienda.Text & "','" & tb_DepositoGeneral.Text & "','DEPOSITOS','" & tb_deposito.Text & "','" & dtp_Fecha_Operacion.Text & "','" & lb_TipoPago.Text & "','" & IIf(lb_DH.Text = "D", tb_Monto.Text, 0) & "','" & IIf(lb_DH.Text = "H", tb_Monto.Text, 0) & "','" & tb_ClienteC.Text & "','" & tb_Glosa.Text & "','" & lb_Cuenta.Text & "','" & lb_Operacion.Text & "',''"
                    Utrans.Obtiene(ls_sql2)

                    MsgBox("Deposito Agregado!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")
                    lb_checkDep.Visible = True
                    '     GroupBox2.Enabled = True
                    tb_deposito.Text = ""
                    tb_ClienteC.Text = ""
                    '        tb_Glosa.Text = ""
                    tb_deposito.Focus()
                End If
            Else
                MsgBox("Falta Monto", MsgBoxStyle.Critical)
                tb_Monto.Focus()
                End
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub Muestra_Depositos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion
            lsSQL = "Select Deposito, Monto, isnull(Ctacte,'')CtaCte, Glosa from SCM.flexline.Cancela_Deposito where empresa='" & gs_empresa & "' and usuario='" & gs_usuario & "' and estado = 0 and tienda='" & cb_Tienda.Text & "' and correlativo='" & tb_DepositoGeneral.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtMovimientos.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtMovimientos.NewRow
                dr2.Item("Deposito") = dr.Item("Deposito")
                dr2.Item("Monto") = dr.Item("Monto")
                dr2.Item("CtaCte") = dr.Item("CtaCte")
                dr2.Item("Glosa") = dr.Item("Glosa")

                _dtMovimientos.Rows.Add(dr2)
            Next

            Me.dgv_Deposito.DataSource = _dtMovimientos    'Despliega el resultado del procedimiento en un Grid
            '  Total()
            Total_Depositos()


            If lb_Operacion.Text = "012" Or lb_Operacion.Text = "013" Or lb_Operacion.Text = "015" Then


                lb_TotalDepositos.Text = CDbl(lb_TotalDepositos.Text) - CDbl(tb_Monto.Text)
                lb_Diferencia.Text = Format(CDbl(lb_SubTotal.Text) - CDbl(lb_TotalDepositos.Text), "###,##0.00")

                'ElseIf lb_Operacion.Text = "013" Then

                '    lb_TotalDepositos.Text = CDbl(lb_TotalDepositos.Text) - CDbl(tb_Monto.Text)
                '        lb_Diferencia.Text = Format(CDbl(lb_SubTotal.Text) - CDbl(lb_TotalDepositos.Text), "###,##0.00")

            Else
                lb_Diferencia.Text = Format(CDbl(lb_SubTotal.Text) - CDbl(lb_TotalDepositos.Text), "###,##0.00")
            End If

            tb_Monto.Text = "0.00"

            tb_deposito.Focus()
            'clsGen.Alinear_GridView(_dtMovimientos, Me.dgv_Deposito, ",Deposito,Monto,CtaCte,Glosa", ",,", ",Deposito,Monto,CtaCte,Glosa,", "", "", "", "", True, True, 275, 0)

            '   Total_Depositos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Total_Depositos()
        Dim ntotal As Double
        Dim dt As DataTable
        ' Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            '    Otrans.open()   'abre conexion
            dt = Me.dgv_Deposito.DataSource

            If dt.Rows.Count > 0 Then
                If lb_Operacion.Text = "012" Or lb_Operacion.Text = "013" Or lb_Operacion.Text = "015" Then
                    Me.lb_TotalDepositos.Text = Format(CDbl(lb_TotalDepositos.Text), "###,###,##0.00")
                Else

                    ntotal = dt.Compute("sum(Monto)", "Monto>0")
                    Me.lb_TotalDepositos.Text = Format(ntotal, "###,##0.00")
                End If

            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            '    Diferencia()
        End Try
    End Sub

    Private Sub Limpia_Depositos()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion
            lsSQL = "Select top 0 Deposito, TipoPago, Monto from SCM.flexline.Cancela_Deposito where empresa='" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtDepositos.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtDepositos.NewRow
                dr2.Item("Deposito") = dr.Item("Deposito")
                dr2.Item("TipoPago") = dr.Item("TipoPago")
                dr2.Item("Monto") = dr.Item("Monto")

                _dtDepositos.Rows.Add(dr2)
            Next

            Me.dgv_Deposito.DataSource = _dtDepositos    'Despliega el resultado del procedimiento en un Grid
            'Total()
            clsGen.Alinear_GridView(_dtDepositos, Me.dgv_Deposito, ",Deposito,TipoPago,Monto,", ",,", ",Deposito,TipoPago,Monto,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub Muestra_Movimiento()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try


            otrans.open()    'abre conexion

            lsSQL = "spa_Cancela_Movimientos '" & gs_empresa & "','" & tb_DepositoGeneral.Text & "','" & cb_Operacion.Text & "','" & tb_ClienteC.Text & "','0','" & tb_Glosa.Text & "','" & gs_usuario & "','" & cb_Tienda.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos


            lsSQL = "Select Movimiento, Monto, CtaCte from SCM.flexline.Cancela_Movimientos where empresa='" & gs_empresa & "' and usuario='" & gs_usuario & "' and estado = 0 and tienda='" & cb_Tienda.Text & "' and numero='" & tb_DepositoGeneral.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            _dtMovimientos.Rows.Clear()
            For Each dr As DataRow In dt.Rows
                dr2 = _dtMovimientos.NewRow
                dr2.Item("Movimiento") = dr.Item("Movimiento")
                dr2.Item("Monto") = dr.Item("Monto")
                dr2.Item("CtaCte") = dr.Item("CtaCte")

                _dtMovimientos.Rows.Add(dr2)
            Next

            Me.dgv_Deposito.DataSource = _dtMovimientos    'Despliega el resultado del procedimiento en un Grid

            If nada = "SOBRANTE" Or nada = "OCCIDENTE" Or nada = "AGROMERCANTIL" Or nada = "BI" Or cb_Operacion.Text = "CITI" _
                        Or cb_Operacion.Text = "CREDOMATIC" Or cb_Operacion.Text = "G&T" Or cb_Operacion.Text = "PROMERICA" Or cb_Operacion.Text = "ANTICIPO" Then
                lb_Diferencia.Text = CDbl(lb_Diferencia.Text) + CDbl(nada)

            ElseIf cb_Operacion.Text = "PROPINA VISA NET" Or cb_Operacion.Text = "PROPINA CREDOMATIC" Then
                lb_Diferencia.Text = lb_Diferencia.Text

            Else
                lb_Diferencia.Text = CDbl(Format(lb_Diferencia.Text - 0, "###,##0.00"))
            End If


            clsGen.Alinear_GridView(_dtMovimientos, Me.dgv_Deposito, ",Movimiento,Monto,CtaCte,", ",,", ",Movimiento,Monto,CtaCte", "", "", "", "", True, True, 275, 0)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try

    End Sub

    Private Sub Actualiza_Correlativo()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion

            lsSQL = "spa_Cancela_Correlativo '" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            lsSQL = "Select Correlativo from SCM.flexline.Cancela_Correlativo where empresa='" & gs_empresa & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            For Each dr As DataRow In dt.Rows

                '  dr2 = _dtCorrelativo.NewRow
                tb_DepositoGeneral.Text = dr.Item("Correlativo")

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_Deposito_Click(sender As Object, e As EventArgs) Handles btn_Deposito.Click

        If cb_Operacion.Text = "" Then
            MsgBox("Debe Agregar Tipo de Operación", MsgBoxStyle.Critical, "Error")
            cb_Operacion.Focus()
        ElseIf tb_deposito.Text = "" Then
            MsgBox("Debe Agregar Número de Deposito", MsgBoxStyle.Critical, "Error")
            tb_deposito.Focus()
        ElseIf tb_Monto.Text = "" Or tb_Monto.Text = "0.00" Then
            MsgBox("Debe Agregar Monto de Deposito", MsgBoxStyle.Critical, "Error")
            tb_Monto.Focus()
        ElseIf (lb_Cuenta.Text = "112001001" And tb_ClienteC.Text = "") Or (lb_Cuenta.Text = "211002006" And tb_ClienteC.Text = "") Or (lb_Cuenta.Text = "211003001" And tb_ClienteC.Text = "") Then
            MsgBox("Debe Agregar Cliente/Proveedor", MsgBoxStyle.Critical, "Error")
            tb_ClienteC.Focus()
            ' Exit Sub
        ElseIf tb_Glosa.Text = "" Then
            MsgBox("Debe Agregar Glosa", MsgBoxStyle.Critical, "Error")
            tb_Glosa.Focus()
            Exit Sub
        End If


        Agrega_Deposito()
        Muestra_Depositos()
        btn_ProcesarC.Enabled = True
    End Sub

    Private Sub Genera_Reporte()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(2) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim Deposito As String

        Try

            pm_conexion = ClsGen.Parametros_Conexion("VDataserver")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Vinoteca\Impresion Depositos.rpt"

            pm_parametros(0) = "@pEmpresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Correlativo"
            pm_valores(1) = tb_DepositoGeneral.Text

            pm_parametros(2) = "@Fecha"
            pm_valores(2) = dtp_Fecha_Operacion.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub dgv_Facturas_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgv_Facturas.UserDeletedRow

        lb_Diferencia.Text = lb_SubTotal.Text

    End Sub

    Private Sub cb_Operacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_Operacion.SelectedValueChanged
        Combo_Operaciones()
    End Sub

    'Private Sub dgv_Deposito_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_Deposito.RowsRemoved
    '    '  Total()
    '    Total_Depositos()
    '    Elimina_Linea()
    '    Muestra_Depositos()
    'End Sub

    Private Sub Diferencia()


        Try
            If lb_TotalDepositos.Text = Nothing Then
                lb_TotalDepositos.Text = "0.00"
                lb_Diferencia.Text = Format(CDbl(lb_SubTotal.Text) - CDbl(lb_TotalDepositos.Text), "###,###,###.00")
            Else
                lb_Diferencia.Text = Format(CDbl(lb_SubTotal.Text) - CDbl(lb_TotalDepositos.Text), "###,###,###.00")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Elimina_Linea()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()    'abre conexion
            lsSQL = "delete from SCM.flexline.Cancela_Deposito where empresa='" & gs_empresa & "' and usuario='" & gs_usuario & "' and estado = 0 and tienda='" & cb_Tienda.Text & "' and correlativo='" & tb_DepositoGeneral.Text & "'"
            dt = otrans.Obtiene(lsSQL)

            'Total_Depositos()
            'Diferencia()
            tb_deposito.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_Deposito_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgv_Deposito.UserDeletingRow
        Elimina_Linea()
        Total_Depositos()
        Muestra_Depositos()
        ''   Diferencia()
    End Sub

    Private Sub cb_Tienda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Tienda.SelectedIndexChanged

    End Sub

    Private Sub cb_Ubicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Ubicacion.SelectedIndexChanged

    End Sub
End Class
