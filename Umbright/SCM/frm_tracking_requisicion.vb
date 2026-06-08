Public Class frm_tracking_requisicion


    Private Sub llenarCombos()
        Me.cmb_valor1.Items.Add("Glosa")
        'Me.cmb_valor1.Items.Add("Origen")
        Me.cmb_valor1.Items.Add("Proveedor")
        Me.cmb_valor1.Items.Add("Orden_Compra")
        'Me.cmb_campos.Items.Add("")

        Me.cmb_valor1.Items.Add("=")
        Me.cmb_valor1.Items.Add(">")
        Me.cmb_valor1.Items.Add("<")
        Me.cmb_valor1.Items.Add("like")

        Me.cmb_valor1.Text = "Glosa"
        Me.cmb_valor1.Text = "like"
    End Sub

    Private Sub frm_tracking_requisicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar1.KeyPress


        If e.KeyChar = Chr(13) Then

            Dim lsfiltro As String

            'lsfiltro = lsfiltro & "d." & tipo & " " & _
            '                Me.cmb_1.Text & " ''" & IIf(Me.cmb_1.Text = "like", "%", "") & Me.txt_buscar1.Text & IIf(Me.cmb_1.Text = "like", "%", "") & "''"

            'crear_estructura(Me.cmb_valor1.Text)

            'If conectar = String.Empty Then
            '    hacer_busqueda_vista()
            'Else
            '    hacer_busqueda_vista(conectar)
            'End If
            ' Else
            '    hacer_busqueda_sp()

        End If

    End Sub

End Class