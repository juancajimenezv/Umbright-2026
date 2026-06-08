Public Class Frm_ClienteNuevo
    Public Cerrar_Ventana As Boolean = False
    Public CodigoNuevo As String = String.Empty
    Public cnit As String = ""
    Public crazon As String = ""

    Dim dtCaja As DataTable

    Private Sub Guardar_Cliente()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim ls_sql, lsql As String
        Dim ClsGen As New ClasesGenerales.General
        Dim ls_parametros As String = ClsGen.Obtener_XMLConfig("Cliente_Nuevo", False)
        Dim ls_parametrosa As String() = ls_parametros.Split(",")

        Try
            Otrans.open()
            ls_sql = "select * from ctacte where EMPRESA='LOGISERV' AND codlegal='" & Me.txt_nit.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count = 0 Then

                ls_sql = "select * from LiquidacionpilotoProveedores WHERE codlegal='" & Me.txt_nit.Text & "'"
                dt = Otrans.Obtiene(ls_sql)



                If dt.Rows.Count = 0 Then
                    'ls_sql = "pa_ins_um_ctacte '" & gs_empresa & "','" & Me.txt_codigo.Text & "','" & _
                    '        Me.txt_nit.Text & "','" & Me.txt_razon_social.Text & "','" & _
                    '        dtCaja.Rows(0)("CondPago").ToString & "','" & _
                    '        dtCaja.Rows(0)("ListaPrecio").ToString & "','" & _
                    '        Me.txt_direccion.Text & "','" & Me.cmb_municipio.SelectedValue & "','" & _
                    '        Me.cmb_depto.Text & "','GUATEMALA','" & Me.txt_telefono.Text & "','','" & _
                    '        Me.txt_contacto.Text & "','" & Me.txt_direccion.Text & "','" & gs_usuario & "','" & _
                    '        dtCaja.Rows(0)("Tipo").ToString & "','" & _
                    '        dtCaja.Rows(0)("Analisis").ToString & "','" & _


                    '
                    '        Me.cmb_vendedor.Text & "'"






                    'ls_sql = " insert into LiquidacionpilotoProveedores (empresa,ctacte,codlegal,razonsocial,g,direccion) values ('CODICASA','" & Me.txt_nit.Text.Split("-")(0) & "','" & _
                    '           Me.txt_nit.Text & "','" & Me.txt_razon_social.Text & "','" & Me.txt_direccion.Text & "')"

                    ls_sql = "pa_ins_um_LiquidacionpilotoProveedores 'LOGISERV','" & Me.txt_nit.Text.Split("-")(0) & "','" & Me.txt_nit.Text & "','" & Me.txt_contacto.Text & "','" &
                                    Me.txt_razon_social.Text & "','" & Me.txt_direccion.Text & "','" & gs_usuario & "'"
                    Otrans.Ingresa(ls_sql)

                    lsql = "pa_ins_um_Proveedor_flexline 'LOGISERV','PROVEEDOR','" & Me.txt_nit.Text.Split("-")(0) & "','" & Me.txt_nit.Text & "','" &
                        Me.txt_razon_social.Text & "','" &
                        Me.txt_direccion.Text & "','" &
                        Me.txt_contacto.Text & "','" &
                        gs_usuario & "'"
                    Otrans.Ingresa(lsql)

                    If Otrans.Codigo_error > 0 Then
                        MessageBox.Show("No Se Pudo Almacenar La Informacion", "", MessageBoxButtons.OK)
                    Else
                        MessageBox.Show("Proveedor Almacenado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Cerrar_Ventana = True

                        If Cerrar_Ventana Then
                            'CodigoNuevo = Me.txt_codigo.Text
                            Me.Close()
                        End If
                    End If


                Else
                    MessageBox.Show("EL Nit ya aparece Registrado en el Sistema", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("EL Codigo de Proveedor ya aparece Registrado en el Sistema", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If Me.txt_nit.Text.Length > 0 And Me.txt_razon_social.Text.Length > 0 Then
            If MessageBox.Show("Esta Seguro de Guardar el Proveedor", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Guardar_Cliente()
            End If
        Else
            MessageBox.Show("Ingrese Informacion Correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If

    End Sub

    Private Sub txt_nit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nit.LostFocus
        Me.txt_codigo.Text = Me.txt_nit.Text.Split("-")(0)
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()

    End Sub

    Private Sub Frm_ClienteNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_nit.Text = cnit
        txt_razon_social.Text = crazon
    End Sub
End Class