Public Class Frm_Cancelacion_Compromisos
    Dim oTransaccion As Transaccional.Conexion
    'Dim gs_usuario As String = "nhernandez"
    'Dim gs_empresa As String = "VINOTECA"

    Private Sub Frm_Cancelacion_Compromisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargacombo()
    End Sub

    Private Sub cargacombo()

        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet
        Dim ls_Sql As String

        oTransaccion = New Transaccional.Conexion("SCM")
        oTransaccion.open()

        ls_Sql = "select distinct Ubicacion from scm.flexline.GEN_UBICACION_VNT WHERE UBICACION!='' AND Ubicacion NOT IN ('ANTIGUA GUATEMALA','FONTABELLA') "

        ldt_table = oTransaccion.Obtiene(ls_Sql)
        ldt_table.TableName = "Ubi"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Ubicacion.DisplayMember = "Ubicacion"
        Me.cb_Ubicacion.ValueMember = "Ubicacion"
        Me.cb_Ubicacion.DataSource = ldt_table

    End Sub

    Private Sub btn_Genera_Click(sender As Object, e As EventArgs) Handles btn_Genera.Click

        If MsgBox("Desea Generar Datos del Dia " & dtp_FechaI.Text & " al " & dtp_FechaF.Text & " ?", MsgBoxStyle.YesNo, "Genera Datos") = MsgBoxResult.Yes Then
            btn_Genera.Text = "Procesando..."
            btn_Genera.Enabled = False
            GeneraDatos()
            btn_Genera.Text = "Genera"
            btn_Genera.Enabled = True
        Else
            Cancelar()
            btn_Genera.Text = "Genera"
            btn_Genera.Enabled = True

        End If

    End Sub

    Private Sub GeneraDatos()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try
            If dtp_FechaI.Text.Length > 0 Then
                Utrans.open()
                ls_sql = " spa_Cancelacion_Movimientos '" & Me.dtp_FechaI.Text & "','" & Me.dtp_FechaF.Text & "','" & gs_usuario & "'"
                Utrans.Ingresa(ls_sql)
                MsgBox("Proceso Generado Con Exito, Puede Preparar Cancelaciones!!", MsgBoxStyle.MsgBoxSetForeground, "Generado")
                Dim Frm_Preparar As New Frm_Cancelacion_Contados
                Frm_Preparar.ShowDialog()

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

    Private Sub Cancelar()
        tb_Correlativo.Text = ""
        tb_Correlativo.Focus()
    End Sub

    Private Sub btn_Contado_Click(sender As Object, e As EventArgs)
        Dim oform As New Frm_Cancelacion_Contados
        oform.ShowDialog()
    End Sub

    Private Sub btn_Tarjeta_Click(sender As Object, e As EventArgs)
        'Dim oform As New Frm_Cancelacion_Tarjeta
        'oform.ShowDialog()
    End Sub

    Private Sub btn_Actualiza_Click(sender As Object, e As EventArgs) Handles btn_Actualiza.Click

        If tb_Correlativo.Text.Length = 0 Then

            MsgBox("Debe Ingresar Correlativo", MsgBoxStyle.Critical, "Correlativo")
        Else

            If Not (IsNumeric(tb_Correlativo.Text)) Then
                MsgBox("Solo permiten datos numéricos en el campo Correlativo. Por favor verifique su entrada.", vbOKOnly + vbInformation, "Mensaje del Sistema...")
                tb_Correlativo.Text = ""
                tb_Correlativo.Focus()
            Else

                If MsgBox("Seguro de Actualizar a la Contabilidad El Deposito " & tb_Correlativo.Text & " Con Fecha " & dtp_Fecha.Text & " ?", MsgBoxStyle.YesNo, "Actualizar") = MsgBoxResult.Yes Then

                    SiExiste()
                    Cancelar()
                Else
                    Cancelar()
                End If
            End If
        End If
    End Sub

    Private Sub SiExiste()
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As New DataTable

        Try

            Utrans.open()
            ls_sql = "pa_vb_Busca_Deposito '" & tb_Correlativo.Text & "'"
            dt = Utrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                If MsgBox("Ya Existe un Deposito Con el mismo Correlativo de fecha " & dt.Rows(0).Item("Fecha").ToString & ", Desea Actualizarlo de Todas Maneras?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Existe") = MsgBoxResult.Yes Then
                    Actualizar()
                    Impresion_Final()
                Else
                    tb_Correlativo.Focus()
                    tb_Correlativo.SelectAll()
                    Cancelar()
                End If
            Else
                Actualizar()
                Impresion_Final()
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try

    End Sub

    Private Sub Actualizar()
        Dim Utrans As New Transaccional.Conexion("SCM")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String

        Try

            Utrans.open()
            ls_sql = "flexline.spa_Actualiza_Depositos '" & tb_Correlativo.Text & "','" & dtp_Fecha.Text & "','" & gs_usuario & "'"
            Utrans.Ingresa(ls_sql)
            MsgBox("Deposito Actualizado Con Existo!!, Debe Imprimir!!", MsgBoxStyle.MsgBoxSetForeground, "Actualizado")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try

    End Sub

    Private Sub Impresion_Final()
        'Finanzas\Contabilidad\Vinoteca\Impresion Depositos Actualizados.rpt
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
            path_reporte = ppath_reporte & "Finanzas\Contabilidad\Vinoteca\Impresion Depositos Actualizados.rpt"

            pm_parametros(0) = "@pEmpresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Correlativo"
            pm_valores(1) = tb_Correlativo.Text

            pm_parametros(2) = "@Fecha"
            pm_valores(2) = dtp_Fecha.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub btn_GenRandom_Click(sender As Object, e As EventArgs) Handles btn_GenRandom.Click
        Dim NumeroAleatorio As New Random()
        Dim ValorAleatorio As Integer = NumeroAleatorio.Next(10, 99)

        lbAleatorio.Text = System.Convert.ToString(ValorAleatorio)

    End Sub


    Private Sub btn_Activar_Click(sender As Object, e As EventArgs) Handles btn_Activar.Click
        Dim Utrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim dt As New DataTable
        Dim ls_sql As String

        Try

            Utrans.open()
            ls_sql = " pa_vb_Combinacion '" & Mid(Me.lbAleatorio.Text, 1, 1) & "','" & Mid(Me.lbAleatorio.Text, 2, 1) & "'"
            dt = Utrans.Obtiene(ls_sql)

            If tb_Intro.Text = dt.Rows(0).Item("Combinacion").ToString Then
                Dim oform As New Frm_Cancelacion_Anulacion
                oform.ShowDialog()
                Me.Close()
            Else
                MsgBox("Contraseña Incorrecta, No Tiene Permisos para Anular", MsgBoxStyle.Critical, "Sin Permisos")
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error Inesperado!! ", MsgBoxStyle.Critical, "Error")
            Cancelar()
        Finally
            Utrans.close()
            Utrans = Nothing
        End Try
    End Sub
End Class