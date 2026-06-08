Public Class frm_Maquila_3PL_Producto
    Public Numero As String
    Public Producto As String
    Public Glosa As String
    Public Cantidad As String
    Public Maquilar As String

    Private Sub frm_Maquila_3PL_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Producto()
        Timer1.Enabled = False
    End Sub

    Private Sub Carga_Producto()
        btn_Finaliza.Enabled = False
        lb_numero.Text = Numero
        lb_Producto.Text = Producto
        lb_glosa.Text = Glosa
        lb_Cantidad.Text = Cantidad
        lb_Maquilar.Text = Maquilar

    End Sub

    Private Sub btn_Inicia_Click(sender As Object, e As EventArgs) Handles btn_Inicia.Click
        Label5.Text = Now().ToString
        btn_Finaliza.Enabled = True
        btn_Inicia.Enabled = False
        Inicia()
    End Sub

    Private Sub Inicia()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_upd_um_documentod_3pl_Inicio '" & Numero & "','" & lb_Producto.Text & "'"
            otrans.Obtiene(lsSQL)

        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub btn_Finaliza_Click(sender As Object, e As EventArgs) Handles btn_Finaliza.Click
        Label6.Text = Now().ToString
        btn_Finaliza.Enabled = False
        Finaliza()
        Timer1.Enabled = True
    End Sub

    Private Sub Finaliza()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "pa_upd_um_documentod_3pl_Fin '" & Numero & "','" & lb_Producto.Text & "'"
            otrans.Obtiene(lsSQL)

        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub


End Class