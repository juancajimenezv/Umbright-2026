Public Class frmRequisicionUsuarioSolicito
    Dim ods As DataSet

    Private Sub crearEstructura()
        Dim dt As DataTable
        ods = New DataSet
        dt = New DataTable("usuario")
        dt.Columns.Add(New DataColumn("usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Double)))
        dt.Columns("usuario").Unique = True 'Llave Unica
        ods.Tables.Add(dt)

        Me.dgvUsuario.DataSource = ods.Tables("usuario")
        alinearGrid()
    End Sub

    Private Function buscarNombreUsuario(ByVal sUsuario As String) As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim sDescripcion As String = String.Empty

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_sg_usuario_simple'" & sUsuario & "'")
            If dt.Rows.Count = 1 Then
                sDescripcion = dt.Rows(0).Item("nombre").ToString
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return sDescripcion
    End Function

    Private Sub alinearGrid()
        Dim clsGen As New ClasesGenerales.General
        clsGen.Alinear_GridView(ods.Tables("usuario"), Me.dgvUsuario, "", "", ",nombre,", "", "", "", "", True, True, 250, 0)
        clsGen = Nothing
    End Sub

    Private Sub frmRequisicionUsuarioSolicito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
    End Sub

    Private Sub dgvUsuario_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuario.CellContentClick

    End Sub

    Private Sub dgvUsuario_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuario.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgvUsuario.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvUsuario.Columns(colIndex).Name.ToLower = "usuario" Then
                    Try
                        If Me.dgvUsuario.Item("usuario", rowIndex).Value = "+" Then

                            Dim frm_busqueda As New frm_busqueda_general
                            frm_busqueda.parametros_fijos = "estatus = 1 and "
                            frm_busqueda.parametros = "nombre, usuario"
                            frm_busqueda.nombre_vista = "sg_usuario"
                            frm_busqueda.lista_campos = "usuario, nombre"
                            frm_busqueda.txt_buscar1.Focus()

                            frm_busqueda.txt_buscar1.Focus()
                            frm_busqueda.dg_buscar.ReadOnly = False
                            frm_busqueda.btn_seleccion_multipe.Visible = False
                            frm_busqueda.Btn_Aceptar.Visible = False
                            frm_busqueda.ShowDialog(Me)

                            If frm_busqueda.resultado.Length > 0 Then
                                Me.dgvUsuario.Item("usuario", rowIndex).Value = frm_busqueda.resultado
                            Else
                                Me.dgvUsuario.Item("usuario", rowIndex).Value = ""
                            End If


                            frm_busqueda.Dispose()
                            frm_busqueda = Nothing
                        End If
                        Dim sNombreUsuario As String = buscarNombreUsuario(Me.dgvUsuario.Item("usuario", rowIndex).Value)

                        Me.dgvUsuario.Item("nombre", rowIndex).Value = sNombreUsuario
                        If sNombreUsuario.Trim.Length > 0 Then
                        End If
                    Catch ex As Exception

                    End Try


                End If
                If Me.dgvUsuario.Columns(colIndex).Name.ToLower = "porcentaje" Then
                    Me.alinearGrid()
                End If
            End If


        Catch ex As Exception


        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class