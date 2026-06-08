Public Class frmRequisiconesDetalle
    Public odsPrevio As DataSet
    Public ods As DataSet
    Public psEmpresa As String
    Public pbProcesar As Boolean = False
    Public pbDatosPrevios As Boolean = False

    Private Sub crearEstructura()
        Dim dt As DataTable
        ods = New DataSet
        dt = New DataTable("centro_costo")
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        dt.Columns("codigo").Unique = True 'Llave Unica
        ods.Tables.Add(dt)

        dt = New DataTable("marca")
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        '(c) 06012016 'Solicitado por hmorales
        dt.Columns.Add(New DataColumn("Porcentaje_Empresa", GetType(Double))) ''Porcentaje empresa + socio debe sumar 100 en cada linea
        dt.Columns.Add(New DataColumn("Porcentaje_Socio", GetType(Double)))
        '(c) 15062016 Solicitado por hmorales
        dt.Columns.Add(New DataColumn("bu", GetType(String)))


        dt.Columns("codigo").Unique = True 'Llave Unica
        ods.Tables.Add(dt)

        dt = New DataTable("gasto")
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns("codigo").Unique = True 'Llave Unica
        ods.Tables.Add(dt)

        dt = New DataTable("canal")
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Porcentaje", GetType(Double)))
        dt.Columns("codigo").Unique = True 'Llave Unica
        ods.Tables.Add(dt)

        Me.dgvCentroCosto.DataSource = ods.Tables("centro_costo")
        Me.dgvMarca.DataSource = ods.Tables("marca")
        Me.dgvGasto.DataSource = ods.Tables("gasto")
        Me.dgvCanal.DataSource = ods.Tables("canal")
        alinearGrid()

    End Sub

    Private Function buscarGlosaConta(ByVal sCodigo As String, ByVal sTipo As String, ByRef sBum As String) As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim sDescripcion As String = String.Empty

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_sel_um_gen_tabcod '" & sCodigo & "','" & sTipo & "','" & psEmpresa & "'")
            If dt.Rows.Count = 1 Then
                sDescripcion = dt.Rows(0).Item("descripcion").ToString
                sBum = dt.Rows(0).Item("texto4").ToString
            End If
        Catch ex As Exception
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
        Return sDescripcion
    End Function


    Private Function buscarGlosaContaCanal(ByVal sCodigo As String, ByVal sTipo As String, ByRef sBum As String) As String
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim dt As DataTable
        Dim sDescripcion As String = String.Empty

        Try
            Otrans.open()
            dt = Otrans.Obtiene("pa_var_um_canales '" & sCodigo & "'")
            If dt.Rows.Count = 1 Then
                sDescripcion = dt.Rows(0).Item("texto4").ToString
                'sBum = dt.Rows(0).Item("texto4").ToString
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
        clsGen.Alinear_GridView(ods.Tables("centro_costo"), Me.dgvCentroCosto, "", "", ",descripcion,", "", "", "", "", True, True, 250, 0)
        clsGen.Alinear_GridView(ods.Tables("gasto"), Me.dgvGasto, "", ",tipo,", ",descripcion,tipo,", "", "", "", "", True, True, 250, 0)
        clsGen.Alinear_GridView(ods.Tables("marca"), Me.dgvMarca, "", "", ",descripcion,", "", "", "", "", True, True, 250, 0)
        clsGen.Alinear_GridView(ods.Tables("canal"), Me.dgvCanal, "", "", ",descripcion,", "", "", "", "", True, True, 250, 0)
        clsGen = Nothing
    End Sub

    Private Sub llenarDatosPrevios()
        Dim dr As DataRow
        Me.odsPrevio.Tables("centro_costo").DefaultView.RowFilter = "linea = 1"
        For Each drv As DataRowView In odsPrevio.Tables("centro_costo").DefaultView
            dr = ods.Tables("centro_costo").NewRow
            dr.Item("codigo") = drv.Item("codigo")
            dr.Item("descripcion") = drv.Item("descripcion")
            dr.Item("porcentaje") = drv.Item("porcentaje")
            ods.Tables("centro_costo").Rows.Add(dr)
        Next

        Me.odsPrevio.Tables("gasto").DefaultView.RowFilter = "linea = 1"
        For Each drv As DataRowView In odsPrevio.Tables("gasto").DefaultView
            dr = ods.Tables("gasto").NewRow
            dr.Item("codigo") = drv.Item("codigo")
            dr.Item("descripcion") = drv.Item("descripcion")
            dr.Item("porcentaje") = drv.Item("porcentaje")
            ods.Tables("gasto").Rows.Add(dr)
        Next

        Me.odsPrevio.Tables("marca").DefaultView.RowFilter = "linea = 1"
        For Each drv As DataRowView In odsPrevio.Tables("marca").DefaultView
            dr = ods.Tables("marca").NewRow
            dr.Item("codigo") = drv.Item("codigo")
            dr.Item("descripcion") = drv.Item("descripcion")
            dr.Item("porcentaje") = drv.Item("porcentaje")
            dr.Item("porcentaje_empresa") = drv.Item("porcentaje_empresa")
            dr.Item("porcentaje_socio") = drv.Item("porcentaje_socio")
            ods.Tables("marca").Rows.Add(dr)
        Next

        alinearGrid()

    End Sub

    Private Sub frmRequisiconesDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearEstructura()
        If Me.pbDatosPrevios Then
            llenarDatosPrevios()
        End If

    End Sub

    Private Sub dgvCentroCosto_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCentroCosto.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgvCentroCosto.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvCentroCosto.Columns(colIndex).Name.ToLower = "codigo" Then
                    Try
                        If Me.dgvCentroCosto.Item("codigo", rowIndex).Value = "+" Then

                            Dim frm_busqueda As New frm_busqueda_general
                            frm_busqueda.parametros_fijos = "empresa = '" & gs_empresa & "' and tipo in ('CON_CCOSTO') and "
                            frm_busqueda.parametros = "descripcion, codigo"
                            frm_busqueda.nombre_vista = "gen_tabcod"
                            frm_busqueda.lista_campos = "codigo, descripcion, tipo"
                            frm_busqueda.txt_buscar1.Focus()

                            frm_busqueda.txt_buscar1.Focus()
                            frm_busqueda.dg_buscar.ReadOnly = False
                            frm_busqueda.btn_seleccion_multipe.Visible = False
                            frm_busqueda.Btn_Aceptar.Visible = False
                            frm_busqueda.ShowDialog(Me)

                            Try
                                If frm_busqueda.resultado.Length > 0 Then
                                    Me.dgvCentroCosto.Item("codigo", rowIndex).Value = frm_busqueda.resultado
                                Else
                                    Me.dgvCentroCosto.Item("codigo", rowIndex).Value = ""
                                End If
                            Catch ex As Exception
                                Me.dgvCentroCosto.Item("codigo", rowIndex).Value = ""
                            End Try
                           


                            frm_busqueda.Dispose()
                            frm_busqueda = Nothing
                        End If
                        Dim sdescripcion As String = buscarGlosaConta(Me.dgvCentroCosto.Item("codigo", rowIndex).Value, "CON_CCOSTO", String.Empty)

                        Me.dgvCentroCosto.Item("descripcion", rowIndex).Value = sdescripcion

                        If sdescripcion.Trim.Length > 0 Then
                        End If
                    Catch ex As Exception

                    End Try


                End If
                If Me.dgvCentroCosto.Columns(colIndex).Name.ToLower = "porcentaje" Then
                    Me.alinearGrid()
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvGasto_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGasto.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If rowIndex > -1 Then
                Me.rbItem.Enabled = False
                Me.rbAyP.Enabled = False
            End If
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgvGasto.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvGasto.Columns(colIndex).Name.ToLower = "codigo" Then
                    Try
                        If Me.rbAyP.Checked = False And Me.rbItem.Checked = False Then
                            MessageBox.Show("Debe Seleccionar Item o A&P", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        If Me.dgvGasto.Item("codigo", rowIndex).Value = "+" Then


                            Dim frm_busqueda As New frm_busqueda_general
                            frm_busqueda.parametros_fijos = "empresa = '" & gs_empresa & "' and tipo in ('" & IIf(Me.rbItem.Checked = True, "CON_ITEM", "CON_A&P") & "') and " 'con_item','con_a&p') and "
                            frm_busqueda.parametros = "descripcion, codigo"
                            frm_busqueda.nombre_vista = "gen_tabcod"
                            frm_busqueda.lista_campos = "codigo, descripcion, tipo"
                            frm_busqueda.txt_buscar1.Focus()

                            frm_busqueda.txt_buscar1.Focus()
                            frm_busqueda.dg_buscar.ReadOnly = False
                            frm_busqueda.btn_seleccion_multipe.Visible = False
                            frm_busqueda.Btn_Aceptar.Visible = False
                            frm_busqueda.ShowDialog(Me)
                            Try
                                If frm_busqueda.resultado.Length > 0 Then
                                    Me.dgvGasto.Item("codigo", rowIndex).Value = frm_busqueda.resultado
                                Else
                                    Me.dgvGasto.Item("codigo", rowIndex).Value = ""
                                End If
                            Catch ex As Exception
                                Me.dgvGasto.Item("codigo", rowIndex).Value = ""
                            End Try

                            frm_busqueda.Dispose()
                            frm_busqueda = Nothing
                        End If

                        Dim sdescripcion As String = buscarGlosaConta(Me.dgvGasto.Item("codigo", rowIndex).Value, IIf(Me.rbItem.Checked = True, "CON_ITEM", "CON_A&P"), String.Empty)
                        'If sdescripcion.Trim.Length = 0 Then
                        '    sdescripcion = buscarGlosaConta(Me.dgvGasto.Item("codigo", rowIndex).Value, "CON_A&P")
                        'End If

                        Me.dgvGasto.Item("descripcion", rowIndex).Value = sdescripcion
                        If sdescripcion.Trim.Length > 0 Then
                        End If
                    Catch ex As Exception
                    Finally


                    End Try

                End If
                If Me.dgvGasto.Columns(colIndex).Name.ToLower = "porcentaje" Then
                    Me.alinearGrid()

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCentroCosto_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvCentroCosto.DataError, dgvMarca.DataError, dgvGasto.DataError
        MessageBox.Show("Ingreso Un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub dgvMarca_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMarca.CellContentClick

    End Sub

    Private Sub dgvMarca_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMarca.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgvMarca.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvMarca.Columns(colIndex).Name.ToLower = "codigo" Then
                    Try
                        If Me.dgvMarca.Item("codigo", rowIndex).Value = "+" Then

                            Dim frm_busqueda As New frm_busqueda_general
                            frm_busqueda.parametros_fijos = "empresa = '" & gs_empresa & "' and tipo in ('CON_MARCA') and "
                            frm_busqueda.parametros = "descripcion, codigo"
                            frm_busqueda.nombre_vista = "gen_tabcod"
                            frm_busqueda.lista_campos = "codigo, descripcion, tipo"
                            frm_busqueda.txt_buscar1.Focus()

                            frm_busqueda.txt_buscar1.Focus()
                            frm_busqueda.dg_buscar.ReadOnly = False
                            frm_busqueda.btn_seleccion_multipe.Visible = False
                            frm_busqueda.Btn_Aceptar.Visible = False
                            frm_busqueda.ShowDialog(Me)

                            If frm_busqueda.resultado.Length > 0 Then
                                Me.dgvMarca.Item("codigo", rowIndex).Value = frm_busqueda.resultado
                            Else
                                Me.dgvMarca.Item("codigo", rowIndex).Value = ""
                            End If

                            frm_busqueda.Dispose()
                            frm_busqueda = Nothing
                        End If
                        Dim sBu As String = String.Empty
                        Dim sdescripcion As String = buscarGlosaConta(Me.dgvMarca.Item("codigo", rowIndex).Value, "CON_MARCA", sBu)

                        Me.dgvMarca.Item("descripcion", rowIndex).Value = sdescripcion
                        Me.dgvMarca.Item("bu", rowIndex).Value = sBu

                        If sdescripcion.Trim.Length > 0 Then
                        End If
                    Catch ex As Exception

                    End Try


                End If
                If Me.dgvMarca.Columns(colIndex).Name.ToLower = "porcentaje" Then Me.alinearGrid()

                If Me.dgvMarca.Columns(colIndex).Name.ToLower = "porcentaje_empresa" Then
                    Try
                        If Me.dgvMarca.Item("porcentaje_empresa", rowIndex).Value > 100 Or Me.dgvMarca.Item("porcentaje_empresa", rowIndex).Value < 0 Then
                            MessageBox.Show("Ingreso un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.dgvMarca.Item("porcentaje_empresa", rowIndex).Value = 0
                        End If

                    Catch ex As Exception

                    End Try
                End If
                If Me.dgvMarca.Columns(colIndex).Name.ToLower = "porcentaje_socio" Then
                    Try
                        If Me.dgvMarca.Item("porcentaje_socio", rowIndex).Value > 100 Or Me.dgvMarca.Item("porcentaje_socio", rowIndex).Value < 0 Then
                            MessageBox.Show("Ingreso un Valor Invalido", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.dgvMarca.Item("porcentaje_socio", rowIndex).Value = 0
                        End If

                    Catch ex As Exception

                    End Try
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim ntotal As Double
        Dim lbContinuar As Boolean = False
        Dim clsGen As New ClasesGenerales.General
        'validar CCosto
        Try
            If ods.Tables("centro_costo").Rows.Count > 0 Then
                lbContinuar = True
                ntotal = ods.Tables("centro_costo").Compute("sum(porcentaje)", "porcentaje > 0")
                If ntotal <> 100 Then
                    MessageBox.Show("El Total de Centro de Costo No Suma 100%", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    lbContinuar = False
                End If
                ods.Tables("centro_costo").DefaultView.RowFilter = "descripcion = ''"
                If ods.Tables("centro_costo").DefaultView.Count > 0 Then
                    MessageBox.Show("Tiene Centro de Costos Invalidos, Por Favor Verificar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lbContinuar = False
                End If
                ods.Tables("centro_costo").DefaultView.RowFilter = ""
            Else
                MessageBox.Show("La Solicitud Debe Llevar Centro de Costo", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                lbContinuar = False
            End If
        Catch ex As Exception
        End Try

        If lbContinuar Then
            'validar Marca
            Try
                If ods.Tables("marca").Rows.Count > 0 Then
                    lbContinuar = True
                    ntotal = ods.Tables("marca").Compute("sum(porcentaje)", "porcentaje > 0")
                    If ntotal <> 100 Then
                        MessageBox.Show("El Total Por Marca No Suma 100%", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        lbContinuar = False
                    End If
                    ods.Tables("marca").DefaultView.RowFilter = "descripcion = ''"
                    If ods.Tables("marca").DefaultView.Count > 0 Then
                        MessageBox.Show("Tiene Marcas Invalidas, Por Favor Verificar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lbContinuar = False
                    End If
                    ods.Tables("marca").DefaultView.RowFilter = ""

                    'Cada Linea de Marca debe sumar 100
                    For Each dr As DataRow In ods.Tables("marca").Rows
                        If dr.Item("porcentaje_empresa") + dr.Item("porcentaje_socio") <> 100 Then
                            MessageBox.Show("La Marca " & dr.Item("descripcion").ToString & " Debe Sumar 100%", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            lbContinuar = False
                        End If
                    Next

                    '20160621
                    Try
                        Dim dtBu As DataTable = clsGen.ValoresDistinto(ods.Tables("marca"), "bu".Split(","))
                        If dtBu.Rows.Count <> ods.Tables("centro_costo").Rows.Count Then
                            MessageBox.Show("Debe Definir las Unidades de Negocio que Corresponden a las Marcas", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            lbContinuar = False
                        End If
                    Catch ex As Exception

                    End Try
                    

                    End If
            Catch ex As Exception
                MessageBox.Show("Problemas en Verificacion", ex.Message)
                lbContinuar = False
            End Try
        End If

        If lbContinuar Then

            'validar Gasto
            Try
                If ods.Tables("gasto").Rows.Count > 0 Then
                    lbContinuar = True
                    ntotal = ods.Tables("gasto").Compute("sum(porcentaje)", "porcentaje > 0")
                    If ntotal <> 100 Then
                        MessageBox.Show("El Total Por Gasto No Suma 100%", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        lbContinuar = False
                    End If
                    ods.Tables("gasto").DefaultView.RowFilter = "descripcion = ''"
                    If ods.Tables("gasto").DefaultView.Count > 0 Then
                        MessageBox.Show("Tiene Gastos Invalidos, Por Favor Verificar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lbContinuar = False
                    End If
                    ods.Tables("gasto").DefaultView.RowFilter = ""

                End If
            Catch ex As Exception
            End Try
        End If

        If lbContinuar Then

            'validar Canal
            Try
                If ods.Tables("canal").Rows.Count > 0 Then
                    lbContinuar = True
                    ntotal = ods.Tables("canal").Compute("sum(porcentaje)", "porcentaje > 0")
                    If ntotal <> 100 Then
                        MessageBox.Show("El Total Por Canal No Suma 100%", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        lbContinuar = False
                    End If
                    ods.Tables("canal").DefaultView.RowFilter = "descripcion = ''"
                    If ods.Tables("canal").DefaultView.Count > 0 Then
                        MessageBox.Show("Tiene Canal Invalidos, Por Favor Verificar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lbContinuar = False
                    End If
                    ods.Tables("canal").DefaultView.RowFilter = ""

                End If
            Catch ex As Exception
            End Try
        End If


        If lbContinuar Then
            If Me.rbItem.Checked = False And Me.rbAyP.Checked = False Then
                MessageBox.Show("No Puede Continuar Por que no Selecciono ITEM o A&P", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lbContinuar = False
            ElseIf Me.rbAyP.Checked = True And ods.Tables("marca").Rows.Count = 0 Then
                MessageBox.Show("Debe Ingresar Marcas para poder Continuar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lbContinuar = False
            ElseIf Me.rbAyP.Checked = True And ods.Tables("canal").Rows.Count = 0 Then
                MessageBox.Show("Debe Ingresar Canales para poder Continuar", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lbContinuar = False
            Else

                For Each dr As DataRow In ods.Tables("gasto").Rows
                    dr.Item("tipo") = IIf(rbItem.Checked = True, "CON_ITEM", "CON_A&P")
                Next

            End If
        End If

        If lbContinuar Then
            pbProcesar = True
            Me.Close()
        End If

    End Sub


    Private Sub dgvGasto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGasto.CellContentClick

    End Sub

    Private Sub dgvCentroCosto_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCentroCosto.CellContentClick

    End Sub

    Private Sub dgvCanal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCanal.CellContentClick

    End Sub

    Private Sub dgvCanal_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCanal.CellValueChanged
        Dim colIndex As Integer = e.ColumnIndex
        Dim rowIndex As Integer = e.RowIndex
        Dim therow As DataGridViewRow


        Try
            If rowIndex > -1 Then
                Me.rbItem.Enabled = False
                Me.rbAyP.Enabled = False
            End If
            If colIndex > -1 And rowIndex > -1 Then
                'rowIndex >= 0 And 
                therow = Me.dgvCanal.Rows(rowIndex)
                'If therow.Cells("vigente").Value.ToString.ToLower = "bloqueado" Then
                '    therow.DefaultCellStyle.BackColor = Color.Yellow
                'ElseIf therow.Cells("vigente").Value.ToString.ToLower = "no vigente" Then
                '    therow.DefaultCellStyle.BackColor = Color.Red
                'End If
                If Me.dgvCanal.Columns(colIndex).Name.ToLower = "codigo" Then
                    Try
                        If Me.rbAyP.Checked = False And Me.rbItem.Checked = False Then
                            MessageBox.Show("Debe Seleccionar Item o A&P", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        If Me.dgvCanal.Item("codigo", rowIndex).Value = "+" Then


                            Dim frm_busqueda As New frm_busqueda_general
                            ' frm_busqueda.parametros_fijos = "empresa = '" & gs_empresa & "' and tipo in ('" & IIf(Me.rbItem.Checked = True, "CON_ITEM", "CON_A&P") & "') and " 'con_item','con_a&p') and "
                            frm_busqueda.parametros_fijos = "empresa = '" & gs_empresa & "' and tipo = 'sysgold_ejecutivos' and substring(texto4,3,1) =  ')' and " 'con_item','con_a&p') and "
                            frm_busqueda.parametros = "texto4"
                            frm_busqueda.nombre_vista = "gen_tabcod"
                            frm_busqueda.lista_campos = "Distinct texto4 as codigo, texto4 as descripcion"
                            frm_busqueda.txt_buscar1.Focus()

                            frm_busqueda.txt_buscar1.Focus()
                            frm_busqueda.dg_buscar.ReadOnly = False
                            frm_busqueda.btn_seleccion_multipe.Visible = False
                            frm_busqueda.Btn_Aceptar.Visible = False
                            frm_busqueda.ShowDialog(Me)
                            Try
                                If frm_busqueda.resultado.Length > 0 Then
                                    Me.dgvCanal.Item("codigo", rowIndex).Value = frm_busqueda.resultado
                                Else
                                    Me.dgvCanal.Item("codigo", rowIndex).Value = ""
                                End If
                            Catch ex As Exception
                                Me.dgvCanal.Item("codigo", rowIndex).Value = ""
                            End Try

                            frm_busqueda.Dispose()
                            frm_busqueda = Nothing
                        End If

                        Dim sdescripcion As String = buscarGlosaContaCanal(Me.dgvCanal.Item("codigo", rowIndex).Value, "sysgold_ejecutivos", String.Empty)
                        'If sdescripcion.Trim.Length = 0 Then
                        '    sdescripcion = buscarGlosaConta(Me.dgvGasto.Item("codigo", rowIndex).Value, "CON_A&P")
                        'End If

                        Me.dgvCanal.Item("descripcion", rowIndex).Value = sdescripcion
                        If sdescripcion.Trim.Length > 0 Then
                        End If
                    Catch ex As Exception
                    Finally


                    End Try

                End If
                If Me.dgvCanal.Columns(colIndex).Name.ToLower = "porcentaje" Then
                    Me.alinearGrid()

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class