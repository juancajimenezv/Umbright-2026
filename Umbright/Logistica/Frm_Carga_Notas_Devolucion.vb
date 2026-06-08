Public Class Frm_Carga_Notas_Devolucion
    'Dim gs_empresa As String = "DMARTE1"

    Private Sub Frm_Carga_Notas_Devolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Nuevo()
    End Sub

    Private Sub tb_Numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Numero.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not IsNumeric(tb_Numero.Text) Then
                MsgBox("Debe Ingresar Un Numero", MsgBoxStyle.Critical, "Numero")
                tb_Numero.Focus()
                tb_Numero.SelectAll()
            Else
                Busca_Notas()
                tb_Numero.Enabled = False
                cb_Empresa.Enabled = False
            End If
        End If
    End Sub

    Private Sub Busca_Notas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Notas_Devolucion '" & cb_Empresa.Text & "','" & tb_Numero.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            If dt.Rows(0)("Cliente").ToString = Nothing Then
                MsgBox("Nota No Existe", MsgBoxStyle.Critical, tb_Numero.Text)
            End If

            Me.lb_Fecha.Text = dt.Rows(0)("Fecha").ToString
            Me.lb_Cliente.Text = dt.Rows(0)("Cliente").ToString
            Me.lb_Nombre.Text = dt.Rows(0)("Nombre").ToString
            Me.lb_Total.Text = dt.Rows(0)("Total").ToString
            Me.lb_Comentario.Text = dt.Rows(0)("Comentario").ToString

        Catch ex As Exception
            MsgBox("Nota No Existe, Verifique", MsgBoxStyle.Critical, tb_Numero.Text)
            Nuevo()
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Nuevo()
        lb_Cliente.Text = "Cliente"
        lb_Fecha.Text = "Fecha"
        lb_Nombre.Text = "Nombre"
        tb_Numero.Text = ""
        lb_Total.Text = "0.00"
        lb_Comentario.Text = "Comentario"
        tb_Numero.Enabled = True
        cb_Empresa.Enabled = True
        tb_Numero.Focus()
    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Nuevo()
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        If MsgBox("Seguro de Agregar Documento Para Guias?", MsgBoxStyle.YesNo, tb_Numero.Text) = MsgBoxResult.Yes Then
            Agregar()
            Nuevo()
        End If
    End Sub

    Private Sub Agregar()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "spa_Nota_Devolucion_Control '" & cb_Empresa.Text & "','" & tb_Numero.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            MsgBox("Nota Agregada Correctamente!!", MsgBoxStyle.Information, tb_Numero.Text)
        Catch ex As Exception
            MsgBox("Problemas Al Agregar", MsgBoxStyle.Critical, tb_Numero.Text)

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub
End Class