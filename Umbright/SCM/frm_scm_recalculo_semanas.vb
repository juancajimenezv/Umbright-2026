Public Class frm_scm_recalculo_semanas

    Private nsemana_actual As Integer = DatePart(DateInterval.WeekOfYear, Today)
    Dim ds_preparacion As DataSet

    Public Sub New(ByRef ds_calculo As Object)
        MyBase.New()
        ds_preparacion = ds_calculo
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Private Sub frm_scm_recalculo_semanas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSemanaActual.Text += " " + nsemana_actual.ToString
        lblSemanaCalculo.Text = "Semana Calculo " + (nsemana_actual + NUDSemana.Value).ToString
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUDSemana.ValueChanged
        lblSemanaCalculo.Text = "Semana Calculo " + (nsemana_actual + NUDSemana.Value).ToString
    End Sub

 
    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Try
            Dim Ocompras As New Compras.SCM(ds_preparacion)
            Ocompras.Minimos_Maximos(Me.NUDSemana.Value, False)
            Ocompras.Generar_Pedido_Sugerido(Me.NUDSemana.Value, Me.CheckBox1.Checked)
            Ocompras = Nothing
        Catch ex As Exception

        End Try
    End Sub
End Class