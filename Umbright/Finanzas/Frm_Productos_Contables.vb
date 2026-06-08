Public Class Frm_Productos_Contables
    'Dim gs_Empresa As String = "DMARTE1"
    'Dim gs_usuario As String = "admin"

    Private Sub Frm_Productos_Contables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Combos()
        tb_Codigo.Focus()
        RadioButton1.Checked = True
    End Sub

    Private Sub Carga_Combos()
        Dim ldt_table As New DataTable
        Dim l_Dataset As New DataSet
        Dim ls_SqlScript As String
        Dim otrans As New Transaccional.Conexion("flexline")
        otrans.open()

        ls_SqlScript = "pa_vb_Productos_Contables_Tipo '" & gs_Empresa & "'"
        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Tipo"
        l_Dataset.Tables.Add(ldt_table.Copy)
        Me.cb_Tipo.DisplayMember = "TipoProducto"
        Me.cb_Tipo.ValueMember = "TipoProducto"
        Me.cb_Tipo.DataSource = ldt_table

        ls_SqlScript = "pa_vb_Productos_Contables_Familia '" & gs_Empresa & "'"
        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Familia"
        l_Dataset.Tables.Add(ldt_table.Copy)
        Me.cb_Familia.DisplayMember = "Familia"
        Me.cb_Familia.ValueMember = "Familia"
        Me.cb_Familia.DataSource = ldt_table

        ls_SqlScript = "pa_vb_Productos_Contables_SubFamilia '" & gs_Empresa & "'"
        ldt_table = otrans.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Sub"
        l_Dataset.Tables.Add(ldt_table.Copy)
        Me.cb_SubFamilia.DisplayMember = "SubFamilia"
        Me.cb_SubFamilia.ValueMember = "SubFamilia"
        Me.cb_SubFamilia.DataSource = ldt_table

    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        Valida()
    End Sub

    Private Sub Valida()
        If tb_Codigo.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar Codigo de Producto", MsgBoxStyle.Critical, "Codigo")
            tb_Codigo.Focus()
        ElseIf cb_Tipo.Text.Length = 0 Then
            MsgBox("Debe Seleccionar Tipo de Producto", MsgBoxStyle.Critical, "Tipo")
            cb_Tipo.Focus()
        ElseIf tb_Glosa.Text.Trim.Length = 0 Then
            MsgBox("Debe Ingresar Nombre o Descripción del Producto", MsgBoxStyle.Critical, "Glosa")
            tb_Glosa.Focus()
        ElseIf tb_Cuenta.Text.Trim.Length = 0 Then
            MsgBox("Debe Ingresar o seleccionar Cuenta Contable", MsgBoxStyle.Critical, "Cuenta")
            tb_Cuenta.Focus()
        ElseIf cb_Familia.Text.Length = 0 Then
            MsgBox("Debe Seleccionar Familia de Producto", MsgBoxStyle.Critical, "Familia")
            cb_Familia.Focus()
        ElseIf cb_SubFamilia.Text.Length = 0 Then
            MsgBox("Debe Seleccionar SubFamilia de Producto", MsgBoxStyle.Critical, "SubFamilia")
            cb_SubFamilia.Focus()
        Else
            Graba()
        End If
    End Sub

    Private Sub Graba()
        Dim Utrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim cuenta As Integer

        Try

            If RadioButton1.Checked = True Then
                cuenta = 1
            ElseIf RadioButton2.Checked = True Then
                cuenta = 2
            Else
                cuenta = 3
            End If

            Utrans.open()
            ls_sql = "pa_vb_Productos_Contables_Graba '" & gs_Empresa & "','" & tb_Codigo.Text & "','" & tb_Glosa.Text & "','" & cb_Tipo.Text & "','" & cb_Familia.Text & "','" & _
            cb_SubFamilia.Text & "','" & lb_Cta.Text & "','" & cuenta & "','" & gs_usuario & "'"
            Utrans.Ingresa(ls_sql)
            MsgBox("Grabado Correctamente!! ", MsgBoxStyle.Critical, "Guardar")

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing
            Limpiar()
        End Try
        
    End Sub

    Private Sub Limpiar()
        tb_Codigo.Text = ""
        cb_Tipo.Text = ""
        tb_Glosa.Text = ""
        tb_Cuenta.Text = ""
        cb_Familia.Text = ""
        cb_SubFamilia.Text = ""
        lb_Cuenta.Text = "Cuenta Contable"
        lb_Valida.Text = "Valida"
        tb_Codigo.Focus()
    End Sub

    'Private Sub tb_Cuenta_LostFocus(sender As Object, e As EventArgs) Handles tb_Cuenta.LostFocus
    '    Busca_Cuentas()
    'End Sub

    Private Sub Busca_Cuentas()
        Dim Utrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As DataTable

        Try

            If tb_Cuenta.Text.Length > 0 Then
                Utrans.open()
                ls_sql = "pa_vb_Productos_Contables_Cuenta '" & gs_Empresa & "','" & tb_Cuenta.Text.Trim & "'"
                dt = Utrans.Obtiene(ls_sql)

                If (dt.Rows.Count > 0) Then
                    lb_Cuenta.Text = dt.Rows(0).Item("Descripcion").ToString
                    lb_cta.text = dt.Rows(0).Item("Cta").ToString
                    cb_Familia.Focus()

                Else
                    MsgBox("Cuenta Contable No Existe", MsgBoxStyle.Critical, "Cuenta")
                    tb_Cuenta.Focus()
                    tb_Cuenta.SelectAll()
                End If

            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing

        End Try
    End Sub

    Private Sub tb_Codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Codigo.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_Codigo.Text.Length > 0 Then
                Busca_Productos_Existentes()
            Else
                MsgBox("Debe Ingresar Codigo, Verifique", MsgBoxStyle.Critical, "Ingrese Codigo")
                tb_Codigo.Focus()
            End If
        End If
    End Sub

    Private Sub cb_Tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Tipo.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Glosa.Focus()
        End If
    End Sub

    Private Sub tb_Glosa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Glosa.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Cuenta.Focus()
        End If
    End Sub

    Private Sub tb_Cuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Cuenta.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca_Cuentas()
        End If
    End Sub

    Private Sub cb_Familia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Familia.KeyPress
        If e.KeyChar = Chr(13) Then
            cb_SubFamilia.Focus()
        End If
    End Sub

    Private Sub cb_SubFamilia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_SubFamilia.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_Grabar.Focus()
        End If
    End Sub

    Private Sub Busca_Productos_Existentes()
        Dim Utrans As New Transaccional.Conexion("FLEXLINE")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As DataTable

        Try

            If tb_Codigo.Text.Length > 0 Then
                Utrans.open()
                ls_sql = "pa_vb_Productos_Contables_Codigo '" & gs_Empresa & "','" & tb_Codigo.Text & "'"
                dt = Utrans.Obtiene(ls_sql)

                If (dt.Rows.Count > 0) Then
                    MsgBox("Codigo Ya Existe, Verifique!!", MsgBoxStyle.Information, dt.Rows(0).Item("Descripcion").ToString)
                    lb_Valida.Text = dt.Rows(0).Item("Descripcion").ToString
                    Limpiar()
                Else
                    lb_Valida.Text = "NUEVO"
                    cb_Tipo.Focus()
                End If

            End If

        Catch ex As Exception
            MsgBox("Ha Ocurrido un Error, Verifique el Proceso!! ", MsgBoxStyle.Critical, "Error")

        Finally
            Utrans.close()
            Utrans = Nothing

        End Try
    End Sub

    
End Class