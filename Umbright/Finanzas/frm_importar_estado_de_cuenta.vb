Imports System.Environment
Imports System.Collections


Public Class frm_importar_estado_de_cuenta
    Public cuenta As String
    Private clsGen As New ClasesGenerales.General
    Dim ods As DataSet





    Private Sub Button1_Click(sender As Object, e As EventArgs)


        Dim conci As New frm_conciliacion_bancaria()
        Dim valor As String()
        valor = TextBox1.Text.Split(CChar("x"))

        TextBox1.Text = Convert.ToString(valor(0))

        If (valor.Length > 0) Then

            ' conci.dgv_banco.Rows.Add(valor(0), TextBox1.Text, (Convert.ToDecimal(valor(0)) * (Convert.ToDecimal(valor(1)))))

        End If


        Me.Close()
    End Sub

    Private Sub frm_importar_estado_de_cuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oTrans As Transaccional.Conexion
        oTrans = New Transaccional.Conexion("flexline")


        Try
            Cmb_bancos_importar.Items.Clear()

            clsGen.fillComboBox(oTrans, "pa_var_Configuracion_Concilicaciones", "Gen_Conciliaciones_Bancos", "tipo_banco", "tipo_banco", Cmb_bancos_importar)



        Catch ex As Exception

        Finally
            oTrans.close()
            oTrans = Nothing

        End Try



    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Cmb_bancos_importar.Text <> "" And TextBox2.Text <> "" Then
            importar_texto()




            Me.Close()
        Else
            MessageBox.Show("Debe Ingresar el Banco y el No. de Cuenta ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox2.Focus()
        End If
    End Sub

    Private Sub importar_texto()
        Dim Fecha, Documento, Tipo, Concepto, sql As String
        Dim debe, haber As Double
        'Dim C1, C2, C3, C4, C5, C6, campos, campo As Array
        Dim ubi_fecha, ubi_docto, ubi_tipo, ubi_con, ubi_debe, ubi_haber As String
        Dim campos, campo As Array
        Dim linea As Integer
        Dim oTrans As Transaccional.Conexion
        Dim oTabla, dt1 As DataTable
        Dim DR, dr_aux As DataRow

        Dim conci As New frm_conciliacion_bancaria()

        oTrans = New Transaccional.Conexion("flexline")
        sql = "pa_var_Configuracion_Concilicaciones '" & gs_empresa & "','" & Me.Cmb_bancos_importar.SelectedValue.ToString & "'"


        Try

            oTrans.open()
            oTabla = oTrans.Obtiene(sql)
            If oTabla.Rows.Count > 0 Then
                For Each DR In oTabla.Rows
                    ubi_fecha = DR.Item("Pos_Fecha")
                    ubi_docto = DR.Item("Pos_Documento")
                    ubi_tipo = DR.Item("Pos_Tipo")
                    ubi_con = DR.Item("Pos_Concepto")
                    ubi_debe = DR.Item("Pos_Debe")
                    ubi_haber = DR.Item("Pos_Haber")
                Next
            End If
            'llena el listbox 
            ListBox1.Items.AddRange(TextBox1.Text.Split(vbNewLine))

            DataGridView1.Columns.Add("Fecha", "fecha")
            DataGridView1.Columns.Add("Documento", "documento")
            DataGridView1.Columns.Add("Tipo", "tipo")
            DataGridView1.Columns.Add("Concepto", "concepto")
            DataGridView1.Columns.Add("Debe", "debe")
            DataGridView1.Columns.Add("Haber", "haber")

            'FUNCION QUE LEE LA LINEA
            For Each item As String In ListBox1.Items
                ListBox2.Items.Clear()
                ListBox2.Items.AddRange(item.ToString.Split(vbTab))

                If Len(item) > 40 Then
                    linea = 0
                    For Each item2 As String In ListBox2.Items
                        linea += 1

                        ' todos 

                        '  If MsgBox("desea automatico", vbYesNo) = vbYes Then



                        Select Case linea
                            Case ubi_fecha : Fecha = Replace(item2, vbLf, "")
                            Case ubi_tipo : Tipo = item2
                            Case ubi_con : Concepto = item2
                            Case ubi_docto : Documento = item2
                            Case ubi_debe : If item2 = "" Or Trim(item2) = "-" Then
                                    debe = 0
                                Else : debe = item2
                                End If

                            Case ubi_haber : If item2 = "" Or Trim(item2) = "-" Then
                                    haber = 0
                                Else : haber = item2
                                End If
                        End Select
                        'End If


                    Next
                    DataGridView1.Rows().Add(New String() {Fecha, Documento, Tipo, Concepto, debe, haber})
                    'DataGridView1.Rows.Insert(Me.DataGridView1.ColumnCount, New String() {value1, value2, value3})

                    'llenamos los registros nuevos
                    If Fecha <> "" And Documento <> "" And debe + haber <> 0 Then
                        sql = "pa_var_agrega_estado_cuenta_bancario '" & gs_empresa & "','" & TextBox2.Text & "','" & Fecha & "','" & Documento & "','" & Tipo & "','" & Concepto & "'," & debe & "," & haber & " ; "
                        oTrans.Ingresa(sql)
                    End If
                End If

            Next
        Catch ex As Exception
        Finally
            MsgBox("Proceso de importacion terminado", MsgBoxStyle.Information)
        End Try

        oTrans.close()
        oTrans = Nothing

    End Sub
    Private Sub importar_texto_copy()
        Dim Fecha, Documento, Tipo, Concepto, sql As String
        Dim debe, haber As Double
        Dim C1, C2, C3, C4, C5, C6, campos, campo As Array
        Dim linea As Integer
        Dim oTrans As Transaccional.Conexion
        Dim oTabla, dt1 As DataTable
        Dim DR, dr_aux As DataRow

        Dim conci As New frm_conciliacion_bancaria()

        oTrans = New Transaccional.Conexion("flexline")
        sql = "pa_var_Configuracion_Concilicaciones '" & gs_empresa & "','" & Cmb_bancos_importar.SelectedItem.ToString & "'"
        oTrans.open()
        oTabla = oTrans.Obtiene(sql)
        If oTabla.Rows.Count > 0 Then
            For Each DR In oTabla.Rows
                C1 = Split(DR.Item("Pos_Fecha"), ",")
                C2 = Split(DR.Item("Pos_Documento"), ",")
                C3 = Split(DR.Item("Pos_Tipo"), ",")
                C4 = Split(DR.Item("Pos_Concepto"), ",")
                C5 = Split(DR.Item("Pos_Debe"), ",")
                C6 = Split(DR.Item("Pos_Haber"), ",")

            Next
        End If
        'llena el listbox 
        ListBox1.Items.AddRange(TextBox1.Text.Split(vbNewLine))

        DataGridView1.Columns.Add("Fecha", "fecha")
        DataGridView1.Columns.Add("Documento", "documento")
        DataGridView1.Columns.Add("Tipo", "tipo")
        DataGridView1.Columns.Add("Concepto", "concepto")
        DataGridView1.Columns.Add("Debe", "debe")
        DataGridView1.Columns.Add("Haber", "haber")

        'FUNCION QUE LEE LA LINEA
        For Each item As String In ListBox1.Items
            ListBox2.Items.Clear()
            ListBox2.Items.AddRange(item.ToString.Split(vbTab))

            If Len(item) > 40 Then
                linea = 0
                For Each item2 As String In ListBox2.Items
                    linea += 1
                    Select Case linea
                        Case 1
                            Fecha = Trim(Replace(item2, vbLf, ""))
                        Case 2
                            Tipo = Trim(item2)
                        Case 3
                            Concepto = Trim(item2)
                        Case 4
                            Documento = Trim(item2)
                        Case 5
                            If Trim(item2) = "" Then
                                debe = 0
                            Else
                                debe = Trim(item2)
                            End If
                        Case 6
                            If Trim(item2) = "" Then
                                haber = 0
                            Else
                                haber = Trim(item2)
                            End If
                    End Select

                    'Fecha = Trim(Mid(item, C1(0), C1(1)))
                    'Documento = Trim(Mid(item, C2(0), C2(1)))
                    'Tipo = Trim(Mid(item, C3(0), C3(1)))
                    'Concepto = Trim(Mid(item, C4(0), C4(1)))
                    'debe = Trim(Mid(item, C5(0), C5(1)))
                    'haber = Trim(Mid(item, C6(0), C6(1)))

                Next
                DataGridView1.Rows().Add(New String() {Fecha, Documento, Tipo, Concepto, debe, haber})
                'DataGridView1.Rows.Insert(Me.DataGridView1.ColumnCount, New String() {value1, value2, value3})

                'llenamos los registros nuevos
                sql = "pa_var_agrega_estado_cuenta_bancario '" & gs_empresa & "','" & TextBox2.Text & "','" & Fecha & "','" & Documento & "','" & Tipo & "','" & Concepto & "'," & debe & "," & haber & " ; "
                oTrans.Ingresa(sql)

            End If

        Next

        oTrans.close()
        oTrans = Nothing
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Cmb_bancos_importar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_bancos_importar.SelectedIndexChanged

    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text <> cuenta Then
            MsgBox("Error: la ingresada no corresponde a la cuenta origen", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class