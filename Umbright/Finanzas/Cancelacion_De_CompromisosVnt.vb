Public Class Cancelacion_De_CompromisosVnt

    Inherits System.Windows.Forms.Form
    Dim oTransaccion As Transaccional.Conexion
    Dim ls_SqlScript As String
    Dim ls_SqlScript2 As String
    Dim oTabla1 As DataTable
    Dim pds_Dataset As New DataSet
    Dim pdataset As New DataSet
    Dim gs_empresa As String = "VINOTECA"
    Dim dtRecibos As DataTable
    

    Private Sub Cancelacion_De_CompromisosVnt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cb_Serie.Enabled = False
        tb_depositoC.Enabled = False
        tb_depositoC.Text = ""
        tb_Deposito2C.Enabled = False
        btn_ProcesarC.Enabled = False
        tb_MontoC.Text = ""

        tb_SobraFalta.Text = "0.00"
        cb_CuentaContable.Enabled = False
        tb_SobraFalta.Enabled = False
        tb_ClienteC.Enabled = False

        cb_Pos.Enabled = False
        tb_DepositoT.Text = ""
        tb_DepositoT2.Text = ""
        tb_DepositoT.Enabled = False
        tb_DepositoT2.Enabled = False

        tb_MontoC.Enabled = False
        tb_MontoC.Text = "0.00"
        tb_Monto.Text = "0.00"
        tb_Monto.Enabled = False
        tb_FaltaSobreT.Enabled = False
        tb_MontoSFt.Text = "0.00"
        tb_MontoSFt.Enabled = False
        tb_ClienteT.Enabled = False

        tb_Propina.Enabled = False
        tb_Propina.Text = "0.00"

        tb_Propina2.Enabled = False
        tb_Propina2.Text = "0.00"

        btn_ProcesarT.Enabled = False
        clb_Series.Enabled = False
        dtp_FechaActualiza.Enabled = False
        btnVisaNet.Enabled = False

    End Sub

    Private Sub cargacombo()

        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet

        oTransaccion = New Transaccional.Conexion("SCM")
        oTransaccion.open()

        ls_SqlScript = "spa_Seleccion_Serie_Tienda '" & Me.cb_Tienda.Text & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "TpDocto"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Serie.DisplayMember = "tipodocto"
        Me.cb_Serie.ValueMember = "tipodocto"
        Me.cb_Serie.DataSource = ldt_table

    End Sub

    Private Sub CheckList()
        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet

        oTransaccion = New Transaccional.Conexion("SCM")
        oTransaccion.open()

        ls_SqlScript = "flexline.spa_Seleccion_Serie_Tienda '" & Me.cb_Tienda.Text & "'"
        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "TpDocto"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.clb_Series.DataSource = ldt_table
        'Me.clb_Series.DisplayMember = "tipodocto" SOLO PARA COMBO BOX
        Me.clb_Series.ValueMember = "tipodocto"

    End Sub

    Private Sub btn_Continuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Continuar.Click
        If cb_FormaPago.Text = "CONTADO" Then
            If MsgBox("Seguro De Procesar Contados?", MsgBoxStyle.YesNo, "Proceso Contados") = MsgBoxResult.Yes Then
                Contado()
            Else
                Cancelar()
            End If

        Else
            If MsgBox("Seguro Procesar Tarjetas?", MsgBoxStyle.YesNo, "Procesar POS") = MsgBoxResult.Yes Then
                Tarjeta()
            Else
                Cancelar()
            End If

        End If
    End Sub

    Private Sub Contado()

        Me.dtp_Fecha.Enabled = False
        Me.cb_Tienda.Enabled = False
        Me.cb_FormaPago.Enabled = False
        btn_Continuar.Enabled = False

        'Me.clb_Series.Items.Clear()
        Me.clb_Series.Enabled = False
        Me.cb_Serie.Enabled = True
        cargacombo()
        Me.tb_depositoC.Enabled = True
        Me.tb_Deposito2C.Enabled = True
        Me.tb_MontoC.Enabled = True
        cb_CuentaContable.Enabled = True
        tb_SobraFalta.Enabled = True
        tb_ClienteC.Enabled = True

        'Me.btn_ProcesarC.Enabled = True

    End Sub

    Private Sub Tarjeta()

        Me.cb_Serie.Enabled = False
        LimpiaSeries()
        Me.CheckList()
        Me.clb_Series.Enabled = True
        Me.btnVisaNet.Enabled = True
        
        'Me.btn_ProcesarT.Enabled = True
    End Sub

    Private Sub Cancelar()

        dtp_Fecha.Enabled = True
        cb_Tienda.Enabled = True
        cb_FormaPago.Enabled = True
        btn_Continuar.Enabled = True

        cb_Tienda.ResetText()
        cb_FormaPago.ResetText()

        cb_Tienda.Text = ""
        cb_FormaPago.Text = ""

        cb_Serie.Text = ""
        tb_depositoC.Text = ""
        cb_Serie.Enabled = False
        tb_depositoC.Enabled = False
        btn_ProcesarC.Enabled = False

        tb_Deposito2C.Text = ""
        tb_Deposito2C.Enabled = False
        tb_MontoC.Text = "0.00"
        tb_MontoC.Enabled = False
        cb_CuentaContable.Text = ""
        cb_CuentaContable.Enabled = False
        tb_SobraFalta.Text = "0.00"
        tb_SobraFalta.Enabled = False
        tb_ClienteC.Text = ""
        tb_ClienteC.Enabled = False

        btnVisaNet.Enabled = False
        cb_Pos.Text = ""
        tb_Monto.Text = "0.00"
        tb_Monto.Enabled = False
        tb_DepositoT.Text = ""
        tb_DepositoT2.Text = ""
        tb_MontoSFt.Text = "0.00"
        tb_MontoSFt.Enabled = False
        cb_Pos.Enabled = False
        tb_DepositoT.Enabled = False
        tb_DepositoT2.Enabled = False
        btn_ProcesarT.Enabled = False

        tb_FaltaSobreT.Text = ""
        tb_MontoSFt.Text = "0.00"
        tb_ClienteT.Text = ""
        tb_Propina.Text = "0.00"

        tb_FaltaSobreT.Enabled = False
        tb_MontoSFt.Enabled = False
        tb_ClienteT.Enabled = False
        tb_Propina.Enabled = False

        'Me.clb_Series.DataSource = Nothing
        clb_Series.ValueMember = Nothing
        cargacombo()
        clb_Series.Enabled = False

        btn_Actualiza.Enabled = True
        tb_DepActualiza.Text = ""
        l_Deposito.Text = ""


        dtp_Fecha.Focus()

    End Sub

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click
        Cancelar()
    End Sub

    Private Sub GeneraContados()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim deposito As Double
        Dim MontoC2 As Double
        Dim depositoC2 As String

        Try
            MontoC2 = CDbl(tb_MontoC.Text)

            If tb_Deposito2C.Text = "" Then
                depositoC2 = "0"
            Else
                depositoC2 = tb_Deposito2C.Text
            End If

            ReiniciaIdentidad()
            If tb_depositoC.Text.Length > 0 Then
                deposito = CDbl(Me.tb_depositoC.Text)
                Utrans.open()
                ls_sql = "flexline.spa_Crea_Partida_Tmp_TC '" & Me.dtp_Fecha.Text & "','" & Me.dtp_FechaFinal.Text & "','" & Me.cb_Tienda.Text & "','" & Me.cb_FormaPago.Text & "','" & Me.cb_Serie.Text & "','" & Me.tb_depositoC.Text & "','" & "Admin','" & depositoC2 & "','" & MontoC2 & "','" & cb_CuentaContable.Text & "','" & tb_SobraFalta.Text & "','" & tb_ClienteC.Text & "','" & tb_Propina.Text & "','" & tb_Propina2.Text & "'"
                Utrans.Ingresa(ls_sql)
                MsgBox("Proceso Generado Con Existe, Debe Revisar y Actualizar!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")
                Reporte()
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

    Private Sub GeneraPos()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim deposito As Double
        Dim Monto As Double
        Dim Deposito2 As String

        Try
            Monto = CDbl(tb_Monto.Text)

            If tb_DepositoT2.Text = "" Then
                Deposito2 = "0"
            Else
                Deposito2 = tb_DepositoT2.Text
            End If

            ReiniciaIdentidad()
            If tb_DepositoT.Text.Length > 0 Then
                deposito = CDbl(Me.tb_DepositoT.Text)
                Utrans.open()
                ls_sql = "flexline.spa_Crea_Partida_Tmp_TC '" & Me.dtp_Fecha.Text & "','" & Me.dtp_FechaFinal.Text & "','" & Me.cb_Tienda.Text & "','" & Me.cb_FormaPago.Text & "','" & Me.cb_Pos.Text & "','" & Me.tb_DepositoT.Text & "','" & "Admin','" & Deposito2 & "','" & Monto & "','" & tb_FaltaSobreT.Text & "','" & tb_MontoSFt.Text & "','" & tb_ClienteT.Text & "','" & tb_Propina.Text & "','" & tb_Propina2.Text & "'"
                Utrans.Ingresa(ls_sql)
                MsgBox("Proceso Generado Con Exito, Debe Revisar y Actualizar!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")
                Reporte()
            Else
                Cancelar()
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Cancelar()
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub btn_ProcesarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProcesarC.Click
        If CDbl(tb_SobraFalta.Text) > 0 And tb_ClienteC.Text = "" Then
            MsgBox("Falta Ingresar Cliente/Personal, Favor Verifique !!", MsgBoxStyle.Critical, "Campo Vacio")
            tb_ClienteC.SelectAll()
            tb_ClienteC.Focus()
        Else

            If MsgBox("Seguro de Procesar El Deposito " & tb_depositoC.Text & " ?", MsgBoxStyle.YesNo, "Procesar Deposito") = MsgBoxResult.Yes Then
                GeneraContados()
            Else
                Cancelar()
            End If
        End If
    End Sub

    Private Sub btn_ProcesarT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProcesarT.Click
        If CDbl(tb_MontoSFt.Text) > 0 And tb_ClienteT.Text = "" Then
            MsgBox("Falta Ingresar Cliente/Personal, Favor Verifique !!", MsgBoxStyle.Critical, "Campo Vacio")
            tb_ClienteT.SelectAll()
            tb_ClienteT.Focus()
        Else

            If MsgBox("Seguro de Procesar el Deposito " & tb_DepositoT.Text & " ?", MsgBoxStyle.YesNo, "Procesar POS") = MsgBoxResult.Yes Then
                GeneraPos()
                Cancelar()
            End If
            Cancelar()
        End If
    End Sub

    Private Sub tb_depositoC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_depositoC.TextChanged
        Try
            If Me.tb_depositoC.Text.Length > 0 Then
                btn_ProcesarC.Enabled = True
            Else
                Me.btn_ProcesarC.Enabled = False

            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub tb_depositoC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tb_depositoC.Validating
    '    Try
    '        If Me.tb_depositoC.Text.Length > 0 Then
    '            btn_ProcesarC.Enabled = True
    '        Else
    '            Me.btn_ProcesarC.Enabled = False
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub tb_DepositoT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_DepositoT.TextChanged
        Try
            If Me.tb_DepositoT.Text.Length > 0 Then
                btn_ProcesarT.Enabled = True
                tb_DepositoT2.Enabled = True
            Else
                Me.btn_ProcesarT.Enabled = False
                Me.tb_DepositoT2.Enabled = False
            End If
        Catch ex As Exception

        End Try
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

    Private Sub LimpiaSeries()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Try
            Utrans.open()
            ls_sql = "TRUNCATE TABLE CON_SERIES"
            Utrans.Obtiene(ls_sql)
        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado ", MsgBoxStyle.Critical, "Error")
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub Reporte()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt
        Dim Deposito As String

        Try
            If cb_FormaPago.Text = "CONTADO" Then
                Deposito = tb_depositoC.Text
            Else
                Deposito = tb_DepositoT.Text
            End If

            pm_conexion = ClsGen.Parametros_Conexion("vDataserver")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Vinoteca\Impresion Depositos.rpt"

            pm_parametros(0) = "@pEmpresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Correlativo"
            pm_valores(1) = Deposito

            pm_parametros(2) = "@Fecha"
            pm_valores(2) = dtp_FechaFinal.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Impresion_Final()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(2), pm_valores_consolidado(2) As String
        Dim pm_parametros(2) As String
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataserver")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Vinoteca\Impresion Depositos.rpt"

            pm_parametros(0) = "@pEmpresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Correlativo"
            pm_valores(1) = tb_DepActualiza.Text

            pm_parametros(2) = "@Fecha"
            pm_valores(2) = dtp_FechaActualiza.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try
    End Sub

    Private Sub btn_Genera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Genera.Click
        If MsgBox("Desea Generar Datos del Dia " & dtp_Genera.Text & " al " & dtp_GeneraFinal.Text & " ?", MsgBoxStyle.YesNo, "Genera Datos") = MsgBoxResult.Yes Then
            GeneraDatos()
            dtp_Fecha.Text = dtp_Genera.Text
            dtp_FechaFinal.Text = dtp_GeneraFinal.Text
        Else
            Cancelar()
        End If
    End Sub

    Private Sub GeneraDatos()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try
            If dtp_Genera.Text.Length > 0 Then
                Utrans.open()
                ls_sql = " flexline.spa_Crea_Movimientos_Partidas_TC '" & Me.dtp_Genera.Text & "','" & Me.dtp_GeneraFinal.Text & "'"
                Utrans.Ingresa(ls_sql)
                MsgBox("Proceso Generado Con Exito, Puede Preparar Partidas!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")
            Else
                Cancelar()
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado!! ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub

    Private Sub btn_Actualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Actualiza.Click
        If tb_DepActualiza.Text.Length > 0 Then

            If MsgBox("Seguro de Actualizar a la Contabilidad El Deposito " & tb_DepActualiza.Text & " Con Fecha " & dtp_FechaActualiza.Text & " ?", MsgBoxStyle.YesNo, "Actualizar") = MsgBoxResult.Yes Then
                l_Deposito.Text = tb_DepActualiza.Text
                btn_Actualiza.Enabled = True
                Actualizar()
                Cancelar()
            Else
                tb_DepActualiza.Text = ""
                Cancelar()
            End If
        Else
            MsgBox("Debe Ingresar Numero de Deposito", MsgBoxStyle.Critical, "Numero Deposito")
            tb_DepActualiza.Focus()
        End If

    End Sub

    Public Sub Actualizar()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try
            If l_Deposito.Text.Length > 0 Then

                Utrans.open()
                ls_sql = "flexline.spa_Actualiza_Depositos '" & tb_DepActualiza.Text & "','" & dtp_FechaActualiza.Text & "','" & "Admin'"
                Utrans.Ingresa(ls_sql)
                MsgBox("Deposito Actualizado Con Existo!!, Debe Imprimir!!", MsgBoxStyle.MsgBoxSetForeground, "Actualizado")
                Impresion_Final()
            Else
                Cancelar()
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Cancelar()
            Utrans.close()
            Utrans = Nothing
        End Try

    End Sub

    Private Sub tb_DepositoT2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_DepositoT2.TextChanged
        Try
            If Me.tb_DepositoT2.Text.Length > 0 Then
                tb_Monto.Enabled = True
                tb_Propina2.Enabled = True
            Else
                Me.tb_Monto.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tb_DepActualiza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_DepActualiza.TextChanged
        Try
            If Me.tb_DepActualiza.Text.Length > 0 Then
                dtp_FechaActualiza.Enabled = True
                tb_FaltaSobreT.Enabled = True
                tb_MontoSFt.Enabled = True

            Else
                Me.dtp_FechaActualiza.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnVisaNet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisaNet.Click
        Dim Otrans As New Transaccional.Conexion("SCM")
        Dim lsSQL As String

        Try
            Otrans.open()

            Dim iCount As Integer
            For iCount = 0 To Me.clb_Series.Items.Count() - 1
                If Me.clb_Series.GetItemChecked(iCount) Then
                    'Dar de alta una empresa
                    'ls_SqlString = "pa_ins_um_sg_usuario_empresa '" & Me.txt_usuario.Text & "','" & Me.chk_list_empresa.Items(i)("EMPRESA") & "'"
                    'li_resultado = oTrans.Ingresa(ls_SqlString)
                    'MessageBox.Show(Me.clb_Series.Items(iCount)("tipodocto"))
                    lsSQL = "pa_ins_um_con_series '" & gs_empresa & "','" & Me.clb_Series.Items(iCount)("tipodocto") & "'"
                    Otrans.Ingresa(lsSQL)
                    Me.cb_Pos.Enabled = True
                    Me.tb_DepositoT.Enabled = True
                    Me.clb_Series.Enabled = True
                    Me.tb_FaltaSobreT.Enabled = True
                    tb_MontoSFt.Enabled = True
                    tb_ClienteT.Enabled = True
                    tb_Propina.Enabled = True
                End If
            Next

        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class