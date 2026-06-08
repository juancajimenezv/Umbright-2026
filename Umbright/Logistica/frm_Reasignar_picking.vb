Public Class frm_Reasignar_picking
    Public dt As DataTable
    Private Sub frm_Reasignar_picking1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Llenar_Combo()
    End Sub

    Private Sub Llenar_Combo()

        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim dt As DataTable

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_pickeadores_picking '" & Me.fecha.Text & "'")


            Me.ComboBox1.DataSource = dt
            Me.ComboBox1.ValueMember = "nombre_picking"
            Me.ComboBox1.DisplayMember = "nombre_picking"




        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Reasignar_picking()
    End Sub

    Private Sub Reasignar_picking()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String
        Try
            otrans.open()

            If MessageBox.Show("¿Desea Reasignar Picking de Usuario? " & Me.ComboBox1.SelectedValue, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                lsSQL = "pa_del_um_picking '" & Me.ComboBox1.SelectedValue & "','" & Me.fecha.Text & "'"
                otrans.Elimina(lsSQL)
                Llenar_Combo()
                MessageBox.Show("Picking Reasignado Correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try

    End Sub

    Private Sub Reasignar_picking_general()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim lsSQL As String

        Try
            otrans.open()
            If MessageBox.Show("¿Desea Reasignar Picking General?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                lsSQL = "pa_del_um_picking_general '" & Me.fecha.Text & "'"
                otrans.Elimina(lsSQL)
                Llenar_Combo()
                MessageBox.Show("Picking Reasignado Correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
        Finally
            otrans.close()
            otrans = Nothing

        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Reasignar_picking_general()
    End Sub
End Class