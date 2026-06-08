Public Class Frm_Traslada_Personal

    Private Sub Frm_Traslada_Personal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ckb_Vacaciones.Checked = True
    End Sub

    Private Sub tb_Ficha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Ficha.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_Empresa_Destino.Text = "" Or cb_Empresa_Destino.Text = Nothing Then
                MsgBox("Debe Seleccionar Empresa", MsgBoxStyle.Critical, "Falta Empresa")
                cb_Empresa_Origen.Focus()
            Else
                Busca_Empleado()
                btn_Traslada.Focus()
            End If
            
        End If
    End Sub

    Private Sub Busca_Empleado()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Traslada_Busca '" & cb_Empresa_Origen.Text & "','" & cb_Empresa_Destino.Text & "','" & tb_Ficha.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            tb_Ficha.Enabled = False
            cb_Empresa_Origen.Enabled = False
            cb_Empresa_Destino.Enabled = False

            If dt.Rows(0)("Nombre").ToString = Nothing Then
                MsgBox("Empleado No Existe", MsgBoxStyle.Critical, tb_Ficha.Text)
            End If

            Me.lb_Nombre.Text = dt.Rows(0)("Nombre").ToString
            
        Catch ex As Exception
            MsgBox("Empleado No Existe, Verifique", MsgBoxStyle.Critical, tb_Ficha.Text)
            Nuevo()
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Nuevo()
        cb_Empresa_Origen.Enabled = True
        cb_Empresa_Destino.Enabled = True
        lb_Nombre.Text = "Nombre"
        tb_Ficha.Text = ""
        tb_Ficha.Enabled = True
        ckb_Vacaciones.Checked = True
    End Sub

    Private Sub btn_Traslada_Click(sender As Object, e As EventArgs) Handles btn_Traslada.Click
        If lb_Nombre.Text = "Nombre" Then
            MsgBox("No ha Cargado Personal, Verifique", MsgBoxStyle.Critical, "Enter")
            tb_Ficha.Focus()
        Else
            If MsgBox("Seguro de Trasladar Personal de la Empresa " & cb_Empresa_Origen.Text & " a la Empresa " & cb_Empresa_Destino.Text, MsgBoxStyle.YesNo, tb_Ficha.Text) = MsgBoxResult.Yes Then
                Traslada()
                If ckb_Vacaciones.Checked = True Then
                    MsgBox("Se trasladaran las Vacaciones", MsgBoxStyle.Information, "Historial de Vacaciones")
                    Traslada_Vacaciones()
                Else
                    MsgBox("No Se trasladaran las Vacaciones", MsgBoxStyle.Information, "Historial de Vacaciones")
                End If
                Nuevo()
            Else : Nuevo()
            End If
        End If
        
    End Sub

    Private Sub Traslada()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Traslada_Personal '" & cb_Empresa_Origen.Text & "','" & cb_Empresa_Destino.Text & "','" & tb_Ficha.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            MsgBox("Empleado Trasladado Correctamente!!", MsgBoxStyle.Information, tb_Ficha.Text)
        Catch ex As Exception
            MsgBox("Problemas Al Trasladar", MsgBoxStyle.Critical, tb_Ficha.Text)

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Public Sub Traslada_Vacaciones()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_upd_um_seg_usuario_vacaciones_empresa '" & cb_Empresa_Origen.Text & "','" & cb_Empresa_Destino.Text & "','" & tb_Ficha.Text & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            MsgBox("Vacaciones Trasladadas Correctamente!!", MsgBoxStyle.Information, tb_Ficha.Text)
        Catch ex As Exception
            MsgBox("Problemas Al Trasladar", MsgBoxStyle.Critical, tb_Ficha.Text)

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

End Class
