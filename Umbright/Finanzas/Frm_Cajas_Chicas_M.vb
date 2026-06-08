Imports vb = Microsoft.VisualBasic

Public Class Frm_Cajas_Chicas_M
    Dim _dtDetalle As DataTable
    '   Dim gs_empresa As String = "UMBRAL"
    '  Dim gs_usuario As String = "ROOT"
    Dim tipodocto As String = ""
    Dim Numero As String = ""
    Dim Proveedor As String = ""
    Dim ds As New DataSet

    Private Sub crearEstructura()
        Dim dt As New DataTable


        dt.Columns.Add(New DataColumn("Empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocto", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha", GetType(Date)))
        dt.Columns.Add(New DataColumn("Factura_Serie", GetType(String)))
        dt.Columns.Add(New DataColumn("Factura_Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Responsable", GetType(String)))
        'dt.Columns.Add(New DataColumn("Factura_Serie", GetType(String)))
        'dt.Columns.Add(New DataColumn("Factura_Numero", GetType(String)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Double)))
        dt.Columns.Add(New DataColumn("Renta", GetType(Double)))

        dt.Columns.Add(New DataColumn("IVA", GetType(Double)))
        dt.Columns.Add(New DataColumn("Base", GetType(Double)))

        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("Item", GetType(String)))
        dt.Columns.Add(New DataColumn("Iva_Clase", GetType(String)))
        dt.Columns.Add(New DataColumn("Combustible", GetType(String)))
        dt.Columns.Add(New DataColumn("Galones", GetType(Double)))
        dt.Columns.Add(New DataColumn("Exento", GetType(Double)))
        dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("SubTotal", GetType(Double)))
        dt.Columns.Add(New DataColumn("Ccosto", GetType(String)))

        dt.TableName = "Details"


        If ds.Tables.Contains("Details") Then ds.Tables.Remove("Details")
        ds.Tables.Add(dt.Copy)

        dgv_Detalle.DataSource = dt

    End Sub

    Private Sub Frm_Cajas_Chicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        INICIAL()
    End Sub

    Private Sub INICIAL()
        'tb_Monto.Enabled = False
        tb_Monto.Text = "0.00"
        tb_Renta.Text = "0.00"
        tb_Exento.Text = "0.00"
        tb_Renta.Text = "0.00"
        tb_Galones.Text = "0.00"
        tb_SubTotal.Text = "0.00"


        cb_TipoDocto.Enabled = False
        dtp_Fecha.Enabled = False
        Tb_Proveedor.Enabled = False

        LlenaCombo()
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        'GroupBox4.Enabled = False
        btn_Imprime.Enabled = False
        btn_Traslada.Enabled = False

        tb_Lote.Enabled = False
        tb_Lote.Text = ""

        btn_Guardar.Enabled = False
        btn_Traslada.Visible = False

        crearEstructura()
    End Sub


    Private Sub LIMPIA()
        'tb_Monto.Enabled = False
        tb_Monto.Text = "0.00"
        tb_Renta.Text = "0.00"
        tb_Exento.Text = "0.00"
        tb_Renta.Text = "0.00"
        tb_Galones.Text = "0.00"
        tb_SubTotal.Text = "0.00"

        tb_Serie.Text = ""
        tb_Numero.Text = ""
        tb_Monto.Text = "0.00"
        tb_Renta.Text = "0.00"
        tb_Producto.Text = ""
        tb_Item.Text = ""
        tb_Galones.Text = "0.00"
        tb_Exento.Text = "0.00"
        tb_Glosa.Text = ""
        tb_SubTotal.Text = "0.00"


        '  LlenaCombo()
        lb_RazonSocial.Text = ""
        Tb_Proveedor.Text = ""

        GroupBox3.Enabled = False
        '  btn_Imprime.Enabled = False
        '  btn_Traslada.Enabled = False


        '  btn_Guardar.Enabled = False

    End Sub

    Private Sub LlenaCombo()
        Dim otrans As New Transaccional.Conexion("flexline") 'Abre conexion
        Dim clsGen As New ClasesGenerales.General           'Abre las clases generales
        Dim lsSQL As String                                 'Declara Variable lsSql como String
        Dim dt As DataTable  'Declara dt como DataTable

        Try
            otrans.open()   'abre conexion

            lsSQL = " select TipoDocto from tipodocumento where empresa='" & gs_empresa & "' and sistema='compras'and clase='Factura (c)' order by tipodocto "     'asigna el procedimiento a lsSql
            dt = otrans.Obtiene(lsSQL)                                                      'Ejecuta el procedimiento guardado en lsSql

            Me.cb_TipoDocto.DataSource = dt                                                'asigna comboBox la tabla o resultado del procedimiento
            Me.cb_TipoDocto.DisplayMember = "TipoDocto"                                   'Despliega el miembro familia 
            Me.cb_TipoDocto.ValueMember = "TipoDocto"


            lsSQL = "select Codigo from gen_tabcod where empresa='" & gs_empresa & "' and Tipo='CON_TIPOIVA' order by codigo"
            dt = otrans.Obtiene(lsSQL)

            Me.cb_TipoIva.DataSource = dt
            Me.cb_TipoIva.DisplayMember = "Codigo"
            Me.cb_TipoIva.ValueMember = "Codigo"


            lsSQL = "select Codigo from gen_tabcod where empresa='" & gs_empresa & "' and Tipo='CON_ccosto' order by codigo"
            dt = otrans.Obtiene(lsSQL)

            Me.cb_CCosto.DataSource = dt
            Me.cb_CCosto.DisplayMember = "Codigo"
            Me.cb_CCosto.ValueMember = "Codigo"

            lsSQL = "select Codigo from gen_tabcod where empresa='" & gs_empresa & "' and Tipo='GEN_COMPRADOR' AND VIGENCIA='S' order by codigo"
            dt = otrans.Obtiene(lsSQL)
            Me.cb_Responsable.DataSource = dt
            Me.cb_Responsable.DisplayMember = "Codigo"
            Me.cb_Responsable.ValueMember = "Codigo"


            lsSQL = "select Codigo from gen_tabcod where empresa='" & gs_empresa & "' and Tipo='CON_EMPRESA' order by codigo"
            dt = otrans.Obtiene(lsSQL)
            Me.cb_Empresa.DataSource = dt
            Me.cb_Empresa.DisplayMember = "Codigo"
            Me.cb_Empresa.ValueMember = "Codigo"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()      'cierra conexion
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub Llena_Grid()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "select top 0 * from SCM.FLEXLINE.CON_CAJAS_CHICAS "

            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            Me.dgv_Detalle.DataSource = dt

            '_dtDetalle.Rows.Clear()
            'For Each dr As DataRow In dt.Rows
            '    dr2 = _dtDetalle.NewRow
            '    dr2.Item("Empresa") = dr.Item("Empresa")
            '    dr2.Item("TipoDocto") = dr.Item("TipoDocto")
            '    dr2.Item("Numero") = dr.Item("Numero")
            '    dr2.Item("Proveedor") = dr.Item("Proveedor")
            '    dr2.Item("Factura_Serie") = dr.Item("Factura_Serie")
            '    dr2.Item("Factura_Numero") = dr.Item("Factura_Numero")
            '    dr2.Item("Factura_Fecha") = dr.Item("Factura_Fecha")
            '    dr2.Item("Monto") = dr.Item("Monto")
            '    dr2.Item("Producto") = dr.Item("Producto")
            '    dr2.Item("Item") = dr.Item("Item")
            '    dr2.Item("CCosto") = dr.Item("CCosto")
            '    dr2.Item("Iva_Clase") = dr.Item("Iva_Clase")
            '    dr2.Item("Exento") = dr.Item("Exento")
            '    dr2.Item("Glosa") = dr.Item("Glosa")
            '    dr2.Item("Combustible") = dr.Item("Combustible")
            '    dr2.Item("Galones") = dr.Item("Galones")

            '    _dtDetalle.Rows.Add(dr2)

            'Next

            'Me.dgv_Detalle.DataSource = _dtDetalle    'Despliega el resultado del procedimiento en un Grid
            'clsGen.Alinear_GridView(_dtDetalle, Me.dgv_Detalle, ",Producto,Glosa,UxC,Peso,Etiquetas,Cajas_x_Tarima,Cajas_x_Cama,Camas_x_Tarima,Existencia,", ",Empresa", ",Producto,Glosa,UxC,Existencia,", "", "", "", "", True, True, 275, 0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
            Muestra_Facturas()
        End Try
    End Sub

    Private Sub guardar()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable
        Dim iva As Double
        Dim base As Double
        Dim sbase As String
        Dim siva As String
        Dim Monto As Double
        Dim smonto As String

        Try

            iva = Math.Round((CDbl(tb_SubTotal.Text) - Math.Round(CDbl(tb_Exento.Text), 2)) / 1.12 * 0.12, 6)

            base = CDbl(tb_SubTotal.Text) - iva '+ CDbl(tb_Exento.Text),"######.00")
            Monto = CDbl(tb_SubTotal.Text)

            sbase = Format(base, "######0.00")
            siva = Format(iva, "######0.00")
            smonto = Format(Monto, "######0.00")

            If tb_Galones.Text = "" Then
                tb_Galones.Text = "0"
            End If

            If tb_Renta.Text = "" Then
                tb_Renta.Text = "0"
            End If

            'MsgBox(iva & " - " & base)
            Otrans.open()   'abre conexion

            ls_sql = "spa_Guarda_Cajas_Chicas_M '" & gs_empresa & "','" & tb_Lote.Text & "','" & cb_TipoDocto.Text & "','" & dtp_Fecha.Text & "','" & tb_Numero.Text & "','" & Tb_Proveedor.Text & "','" &
                cb_Responsable.Text & "','" & tb_Serie.Text & "','" & tb_Monto.Text & "','" & tb_Producto.Text & "','" &
                tb_Item.Text & "','" & cb_CCosto.Text & "','" & cb_TipoIva.Text & "','" & siva & "','" & tb_Exento.Text & "','" & sbase & "','" & tb_Renta.Text & "','" & tb_Glosa.Text & "','" &
                cb_Combustible.Text & "','" & tb_Galones.Text & "','" & gs_usuario & "','" & Now() & "',0," & smonto & ",'" & cb_Empresa.Text & "'"
            Otrans.Actualiza(ls_sql)

            Total()
            'MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Muestra_Facturas()
            'Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Guardar_Dgv()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try

            Otrans.open()   'abre conexion
            dt = dgv_Detalle.DataSource

            For Each drv As DataRowView In dt.DefaultView
                If drv.Item("Producto").ToString <> Nothing Then
                    ls_sql = "exec spa_Guarda_Cajas_Chicas_M_U '" & gs_empresa & "','" & tb_Lote.Text & "','" & drv.Item("TipoDocto").ToString & "','" & drv.Item("Fecha").ToString & "','" &
                    drv.Item("Factura_Numero").ToString & "','" & drv.Item("Proveedor").ToString & "','" & drv.Item("Responsable").ToString & "','" & drv.Item("Factura_Serie").ToString & "','" &
                    drv.Item("Monto").ToString & "','" & drv.Item("Renta").ToString & "','" & drv.Item("Producto").ToString & "','" & drv.Item("Item").ToString & "','" & drv.Item("Ccosto").ToString & "','" & drv.Item("Iva_Clase").ToString & "','" &
                    drv.Item("Exento").ToString & "','" & drv.Item("Glosa").ToString & "','" & drv.Item("Combustible").ToString & "','" & drv.Item("Galones").ToString & "','" & drv.Item("SubTotal").ToString & "','" &
                    gs_usuario & "'"
                    Otrans.Actualiza(ls_sql)

                Else
                End If
            Next
            Reporte()
            INICIAL()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        ' If MessageBox.Show("Desea Guardar El Documento?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
        If Tb_Proveedor.Text = "" Then
            MsgBox("El Proveedor No Puede estar Vacio")
            Tb_Proveedor.Focus()
        ElseIf tb_Numero.Text = "" Then
            MsgBox("El Numero No Puede estar Vacio")
            tb_Numero.Focus()
        ElseIf tb_SubTotal.Text = "" Then
            MsgBox("El Monto No Puede estar Vacio")
            tb_Monto.Focus()
        ElseIf tb_SubTotal.Text = "0.00" Then
            MsgBox("El Monto No Puede ser Cero")
            tb_SubTotal.Focus()
        ElseIf cb_CCosto.Text = Nothing Then
            MsgBox("El Centro De Costo No Puede Estar Vacio")
            cb_CCosto.Focus()
        ElseIf cb_Responsable.Text = Nothing Then
            MsgBox("El Responsable No Puede Estar Vacio")
            cb_Responsable.Focus()
        ElseIf tb_Producto.Text = "" Then
            MsgBox("El Producto no puede estar Vacio")
            tb_Producto.Focus()
        ElseIf tb_Item.Text = "" Then
            MsgBox("El Item Gasto NO puede estar Vacio")
            tb_Item.Focus()
        ElseIf cb_TipoIva.Text = Nothing Then
            MsgBox("El Tipo De IVA No puede Estar Vacio")
            cb_TipoIva.Focus()
        Else
            ' guardar()
            Agregar()
            GroupBox2.Enabled = True
            LIMPIA()
            btn_Guardar.Enabled = True
            Tb_Proveedor.Focus()
        End If

        'Else
        '    Limpiar()

        'End If
    End Sub

    Private Sub Agregar()
        Dim dr_aux As DataRow

        Try
            dr_aux = ds.Tables("Details").NewRow
            dr_aux.Item("Empresa") = gs_empresa
            dr_aux.Item("TipoDocto") = cb_TipoDocto.Text 'drr.Item("tipodocto")
            dr_aux.Item("Fecha") = dtp_Fecha.Text ' drr.Item("devolucion")
            dr_aux.Item("Factura_Numero") = tb_Numero.Text 'IIf(Me.nupAnioFACE.Value > 0, Me.nupAnioFACE.Value.ToString, "") & Me.txt_NoDocto.Text.Trim 'drr.Item("nodocto")
            dr_aux.Item("Proveedor") = Tb_Proveedor.Text 'Me.dtpFechaDocumento.Value
            dr_aux.Item("Responsable") = cb_Responsable.Text
            dr_aux.Item("Factura_Serie") = tb_Serie.Text 'Me.txt_cod_producto.Text.Trim 'drr.Item("producto")
            'dr_aux.Item("Factura_Numero") = tb_Numero.Text 'drr.Item("glosa")
            dr_aux.Item("Monto") = tb_Monto.Text ' drr.Item("preciou")
            dr_aux.Item("Renta") = tb_Monto.Text ' drr.Item("preciou")
            dr_aux.Item("Producto") = tb_Producto.Text 'Me.txt_cantidadDevolver.Text * Me.preciou 'drr.Item("total")
            dr_aux.Item("Item") = tb_Item.Text 'drr.Item("motivo")
            dr_aux.Item("Ccosto") = cb_CCosto.Text  'drr.Item("motivo")
            dr_aux.Item("Iva_Clase") = cb_TipoIva.Text 'drr.Item("motivo")
            dr_aux.Item("Exento") = tb_Exento.Text  'drr.Item("motivo")
            dr_aux.Item("Glosa") = tb_Glosa.Text  'drr.Item("motivo")
            dr_aux.Item("Combustible") = cb_Combustible.Text  'drr.Item("motivo")
            dr_aux.Item("Galones") = IIf(tb_Galones.Text.Length = 0, 0, tb_Galones.Text)  'drr.Item("motivo")
            dr_aux.Item("SubTotal") = tb_SubTotal.Text


            ds.Tables("Details").Rows.Add(dr_aux)

            Me.dgv_Detalle.DataSource = ds.Tables("Details")
            ds.Tables("Details").DefaultView.RowFilter = ""

            Total()
            btn_Guardar.Enabled = True
            GroupBox2.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        'If CDbl(tb_Monto.Text) <> CDbl(lb_Total.Text) Then
        'MsgBox("Documento Descuadrado, favor de Verificar....", MsgBoxStyle.Critical, "Descuadre")
        'Exit Sub
        'Else
        Try

            If MsgBox("Seguro de Guardar la Preparacion", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Guardar_Dgv()
                '  Trasladar()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'End If


    End Sub

    Private Sub Guardar_Detalle()
        Dim Otrans As New Transaccional.Conexion("flexline")
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As DataTable

        If MessageBox.Show("¿Se Procesará Un pago?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

        Try

            Otrans.open()   'abre conexion
            dt = Me.dgv_Detalle.DataSource

            For Each drv As DataRowView In dt.DefaultView

                If drv.Item("Tipodocto").ToString <> "" Then
                    ls_sql = "exec sp'" & drv.Item("Empresa") & "','" & drv.Item("Proveedor") & "','" & drv.Item("Documento") & "','" & drv.Item("Numero") & "','" & gs_usuario & "'"
                    Otrans.Actualiza(ls_sql)

                Else
                End If
            Next
            dt.DefaultView.RowFilter = ""
            'MessageBox.Show("Se Presentará Una Pantalla de Verificación !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Limpiar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub

    Private Sub Nuevo()
        tb_Lote.Text = ""
        dtp_Fecha.Text = Now().ToString
        tb_Numero.Text = ""
        Tb_Proveedor.Text = ""
        tb_Serie.Text = ""
        tb_Monto.Text = "0.00"
        tb_Renta.Text = "0.00"
        tb_Producto.Text = ""
        tb_Item.Text = ""
        'cb_CCosto.Text = Nothing
        'cb_TipoIva.Text = Nothing
        'cb_Responsable.Text = Nothing
        tb_Exento.Text = "0.00"
        tb_Glosa.Text = ""
        cb_Combustible.Text = Nothing
        lb_Total.Text = "0.00"
        lb_Iva.Text = "0.00"
        tb_Galones.Text = "0.00"
        lb_Desc_Producto.Text = ""
        lb_RazonSocial.Text = ""
        cb_Combustible.Visible = True
        tb_Galones.Visible = True
        dgv_Detalle.DataSource = Nothing
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        btn_Imprime.Enabled = False
        btn_Traslada.Enabled = False

        cb_TipoDocto.Focus()
    End Sub
    Private Sub Limpiar()
        tb_Numero.Text = ""
        Tb_Proveedor.Text = ""
        tb_Serie.Text = ""
        tb_Monto.Text = "0.00"
        tb_Renta.Text = "0.00"
        tb_Producto.Text = ""
        tb_Item.Text = ""
        tb_Exento.Text = "0.00"
        tb_Glosa.Text = ""
        tb_Galones.Text = "0.00"
        tb_SubTotal.Text = "0.00"
        lb_Desc_Producto.Text = ""
        lb_RazonSocial.Text = ""
        cb_Combustible.Visible = True
        tb_Galones.Visible = True
        crearEstructura()
        tb_Numero.Focus()

    End Sub

    Private Sub Muestra_Facturas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim Otrans2 As New Transaccional.Conexion("RegionalDBintOut")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL, lsSQL2, Num As String
        Dim dt, dt2 As DataTable
        Dim Itur As Double
        Dim Idp As Double

        Try

            otrans.open()   'abre conexion
            Otrans2.open()

            lsSQL = "select Empresa, TipoDocto, fecha, Factura_Serie, numero Factura_Numero,Proveedor, Responsable, Monto, Renta, Iva, Base, Producto, Item, Iva_Clase, Combustible, Galones, Exento , Glosa, SubTotal, Centro_Costo Ccosto  from SCM.FLEXLINE.CON_CAJAS_CHICAS_M WHERE empresa='" & gs_empresa & "' and lote='" & tb_Lote.Text & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            'Num = dt.Rows(0).Item("Numero").ToString()

            'lsSQL2 = "pa_sel_um_numero_compra '" & gs_empresa & "','" & tb_Numero.Text & "'"
            'dt2 = Otrans2.Obtiene(lsSQL2)

            'Itur = dt.Rows(0).Item("ImpuestoTurismo").ToString()
            'Idp = dt.Rows(0).Item("MontoImpuestoIDP").ToString()


            Me.dgv_Detalle.DataSource = dt


            Total()

            btn_Traslada.Visible = True
            btn_Traslada.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub dgv_Detalle_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Detalle.RowHeaderMouseClick

        tipodocto = dgv_Detalle.CurrentRow.Cells(2).Value
        Numero = dgv_Detalle.CurrentRow.Cells(4).Value
        Proveedor = dgv_Detalle.CurrentRow.Cells(5).Value

    End Sub

    Private Sub dgv_Detalle_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgv_Detalle.UserDeletedRow
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        If MsgBox("Seguro de Eliminar: Empresa: " & Me.dgv_Detalle.CurrentRow.Cells.Item(0).Value.ToString & ", TipoDocto: " & Me.dgv_Detalle.CurrentRow.Cells.Item(1).Value.ToString & ", Numero: " & _
               Me.dgv_Detalle.CurrentRow.Cells.Item(3).Value.ToString & ", Proveedor: " & Me.dgv_Detalle.CurrentRow.Cells.Item(4).Value.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Nuevo()
            Muestra_Facturas()

        Else
            Try

                Otrans.open()
                ls_sql = "Delete from SCM.FLEXLINE.CON_CAJAS_CHICAS where empresa= '" & gs_empresa & "' and tipodocto='" & tipodocto & "' and numero='" & Numero & "' and proveedor='" & Proveedor & "'"
                Otrans.Elimina(ls_sql)

                MessageBox.Show("Documento Eliminado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Muestra_Facturas()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Otrans.close()
                Otrans = Nothing
            End Try

        End If

    End Sub

    Private Sub Total()
        Dim ntotal As Double
        Dim niva As Double
        Dim dt As DataTable
        ' Dim Otrans As New Transaccional.Conexion("FlexLine")

        Try
            '    Otrans.open()   'abre conexion
            dt = Me.dgv_Detalle.DataSource

            ntotal = dt.Compute("sum(SubTotal)", "SubTotal>0")
            '  niva = dt.Compute("sum(Iva)", "Iva>0")
            Me.lb_Total.Text = Format(ntotal, "###,##0.00")
            Me.lb_Iva.Text = Format(Math.Round(ntotal / 1.12 * 0.12, 2), "###,##0.00")
            '    Me.tb_Monto.Text = Format(ntotal, "###,##0.00")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Tb_Proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_Proveedor.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca_Proveedor()
        End If
    End Sub

    Private Sub Busca_Proveedor()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim proveedor As String


        Try
            otrans.open()
            lsSQL = "select RazonSocial from ctacte where empresa='" & gs_empresa & "' and tipoctacte='PROVEEDOR' and ctacte='" & Tb_Proveedor.Text & "' AND VIGENCIA='S'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            'MsgBox(dt.Rows(0).Item(0))

            proveedor = dt.Rows(0).Item(0).ToString
            lb_RazonSocial.Text = dt.Rows(0).Item(0).ToString
            GroupBox2.Enabled = True
            tb_Serie.Focus()

        Catch ex As Exception
            MsgBox("Proveedor No Existe, Verifique!!")
            Tb_Proveedor.Focus()
            Tb_Proveedor.SelectAll()

            'MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub tb_Serie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Serie.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Numero.Focus()
        End If
    End Sub

    Private Sub tb_Numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Numero.KeyPress
        Dim numero As String = "000000000000" & tb_Numero.Text

        If e.KeyChar = Chr(13) Then
            If Mid(cb_TipoDocto.Text, 1, 4) = "FACE" Then
                tb_Numero.Text = vb.Right(numero, 12)
                tb_Monto.Focus()
            Else
                tb_Numero.Text = vb.Right(numero, 10)
                tb_Monto.Focus()
            End If

        End If
    End Sub

    Private Sub tb_Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Monto.KeyPress
        Dim monto As Double
        If e.KeyChar = Chr(13) Then

            Try
                monto = CDbl(tb_Monto.Text)
                tb_Monto.Text = Format(monto, "###,##0.00")

                If cb_Responsable.Visible = True Then
                    cb_Responsable.Focus()
                Else
                    GroupBox3.Enabled = True
                    tb_Producto.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                tb_Monto.Focus()
                tb_Monto.SelectAll()
            End Try
        End If
    End Sub

    Private Sub cb_CCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_CCosto.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_Agregar.Focus()
        End If
    End Sub

    Private Sub tb_Renta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Renta.KeyPress
        Dim renta As Double
        If e.KeyChar = Chr(13) Then
            Try
                renta = CDbl(tb_Monto.Text)
                tb_Monto.Text = Format(renta, "###,##0.00")
                cb_Responsable.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                tb_Renta.Focus()
                tb_Renta.SelectAll()
            End Try

        End If
    End Sub

    Private Sub cb_Responsable_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Responsable.KeyPress
        If e.KeyChar = Chr(13) Then
            GroupBox3.Enabled = True
            tb_Producto.Focus()
        End If
    End Sub

    Private Sub Busca_Producto()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim producto As String

        Try
            otrans.open()
            lsSQL = "select glosa from producto where empresa='" & gs_empresa & "' and producto='" & tb_Producto.Text & "' and  tipoproducto  IN ('SERVICIOS','GASTOS','GASTO') AND VIGENTE='S'"
            dt = otrans.Obtiene(lsSQL)

            'MsgBox(dt.Rows(0).Item(0))

            producto = dt.Rows(0).Item(0).ToString
            lb_Desc_Producto.Text = Mid(dt.Rows(0).Item(0).ToString, 1, 27)
            tb_Item.Text = tb_Producto.Text
            tb_Glosa.Focus()

        Catch ex As Exception
            MsgBox("Producto No Existe, Verifique!!")
            tb_Producto.Focus()
            tb_Producto.SelectAll()

            'MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub tb_Producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Producto.KeyPress
        If e.KeyChar = Chr(13) Then
            Busca_Producto()
        End If
    End Sub

    Private Sub tb_Item_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Item.KeyPress
        If e.KeyChar = Chr(13) Then
            lb_Desc_Producto.Text = ""
            Busca_Item()
        End If
    End Sub

    Private Sub Busca_Item()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim item As String

        Try
            otrans.open()
            lsSQL = "select Descripcion from gen_tabcod where empresa='" & gs_empresa & "' and tipo='con_item' and codigo='" & tb_Item.Text & "'"
            dt = otrans.Obtiene(lsSQL)

            'MsgBox(dt.Rows(0).Item(0))

            item = dt.Rows(0).Item(0).ToString
            lb_Desc_Producto.Text = Mid(dt.Rows(0).Item(0).ToString, 1, 27)
            cb_TipoIva.Focus()

        Catch ex As Exception
            MsgBox("Item Gasto No Existe, Verifique!!")
            tb_Item.Focus()
            tb_Item.SelectAll()

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub cb_TipoIva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_TipoIva.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Glosa.Focus()
        End If
    End Sub

    Private Sub cb_Empresa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Empresa.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_Galones.Visible = True Then
                cb_CCosto.Focus()
            Else
                cb_CCosto.Focus()
            End If
        End If
    End Sub

    Private Sub tb_Exento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Exento.KeyPress
        Dim Exento As Double

        If e.KeyChar = Chr(13) Then

            Try
                Exento = CDbl(tb_Exento.Text)
                tb_Exento.Text = Format(Exento, "###,##0.00")

                If cb_Combustible.Visible = True Then
                    cb_Combustible.Focus()
                Else
                    tb_Glosa.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                tb_Exento.Focus()
                tb_Exento.SelectAll()
            End Try
        End If
    End Sub

    Private Sub cb_Combustible_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Combustible.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Galones.Focus()
        End If
    End Sub

    Private Sub tb_Galones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Galones.KeyPress
        Dim galones As Double

        'If cb_Combustible.Visible = True Then
        'End If

        If e.KeyChar = Chr(13) Then

            Try
                galones = tb_Galones.Text
                tb_Galones.Text = Format(galones, "###,##0.0000")

                If cb_Combustible.Text = "SUPER" Then
                    tb_Exento.Text = CDbl(tb_Galones.Text) * 4.7
                ElseIf cb_Combustible.Text = "DIESEL" Then
                    tb_Exento.Text = CDbl(tb_Galones.Text) * 1.3
                ElseIf cb_Combustible.Text = "REGULAR" Then
                    tb_Exento.Text = CDbl(tb_Galones.Text) * 4.6
                End If

                tb_Glosa.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                tb_Galones.Focus()
                tb_Galones.SelectAll()
            End Try
        End If
    End Sub

    Private Sub tb_Glosa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Glosa.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_SubTotal.Focus()
        End If
    End Sub


    Private Sub tb_SubTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_SubTotal.KeyPress
        If e.KeyChar = Chr(13) Then
            If tb_SubTotal.Text.Length = 0 Or Not IsNumeric(tb_SubTotal.Text) Then
                MsgBox("Sub Total Incorrecto!!!", MsgBoxStyle.Critical, "Valor Incorrecto")
                tb_SubTotal.Focus()
                tb_SubTotal.SelectAll()
            Else
                cb_CCosto.Focus()
            End If
        End If
    End Sub

    Private Sub cb_TipoDocto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_TipoDocto.KeyPress
        If e.KeyChar = Chr(13) Then
            If cb_TipoDocto.Text = "FACE COMBUSTIBLE POR PAGAR" Then
                cb_Combustible.Visible = True
                tb_Galones.Visible = True
                Label11.Visible = True
                Label12.Visible = True
            ElseIf cb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR" Then
                cb_Combustible.Visible = True
                tb_Galones.Visible = True
                Label11.Visible = True
                Label12.Visible = True
            ElseIf cb_TipoDocto.Text = "FACT PEQUEÑO CONTRI" Or cb_TipoDocto.Text = "FACTURAS EXENTAS" Then
                cb_Combustible.Visible = False
                tb_Galones.Visible = False
                Label11.Visible = False
                Label12.Visible = False
                cb_TipoIva.Text = "EXENTO"

            Else
                cb_Combustible.Visible = False
                tb_Galones.Visible = False
                Label11.Visible = False
                Label12.Visible = False
            End If

            dtp_Fecha.Focus()
        End If
    End Sub

    Private Sub tb_Nuevo_Click(sender As Object, e As EventArgs) Handles tb_Nuevo.Click
        Nuevo()
    End Sub

    Private Sub btn_Traslada_Click(sender As Object, e As EventArgs) Handles btn_Traslada.Click
        btn_traslado()
    End Sub

    Private Sub btn_traslado()
        Dim var1 As String

        If MsgBox("Seguro de Sincronizar hacia Flexline?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            var1 = InputBox("Ingrese la Palabra Clave: ", "Seguridad al Sincronizar", "***", 100, 100)
            If var1 = "UmbralCajasChicas$" Then



                btn_Traslada.Enabled = False
                btn_Traslada.Visible = False
                Sincroniza_Flexline()
                'MsgBox("Sincronizar")
            Else
                Exit Sub
            End If

            Exit Sub
        End If

    End Sub

    Private Sub Trasladar()
        If Me.dgv_Detalle.Rows.Count = 0 Then
            MsgBox("No Hay Documentos Ingresados, Verifique", MsgBoxStyle.Critical, "Atención")
            Nuevo()

        Else

            'If MessageBox.Show("Desea Trasladar Documentos a FLEXLINE ??", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            '    Muestra_Facturas()
            '    Nuevo()
            'Else
            '  If MessageBox.Show("Desea Imprimir El Soporte Antes De Trasladar ??", "Soporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Crea_Encabezado()
            '  Muestra_Facturas()
            '      Reporte()
            '   Nuevo()
            ' Else
            'Reporte()
            '    Crea_Encabezado()
            '    Muestra_Facturas()
            '    Nuevo()
        End If


        '   End If
        'End If
    End Sub

    Private Sub Crea_Encabezado()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim item As String

        Try
            otrans.open()

            lsSQL = "pa_vb_ins_Cajas_Chicas_M '" & gs_empresa & "','" & tb_Lote.Text & "','" & cb_TipoDocto.Text & "','" & tb_Numero.Text & "','" & Tb_Proveedor.Text & "'"
            otrans.Actualiza(lsSQL)

            Traslada()

        Catch ex As Exception
            MsgBox("Problemas al Crear, Verifique!!")

        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub Traslada()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql0 As String
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            Otrans.open()   'abre conexion
            ls_sql = "select empresa,tipodocto,numero,proveedor, centro_costo Ccosto from scm.flexline.con_cajas_chicas_M where empresa='" & gs_empresa & "' and convertido = 0 and lote= '" & tb_Lote.Text & "'"
            dt = Otrans.Obtiene(ls_sql)  'obtiene o ejecuta el procedimiento para extraer los datos


            For Each dr As DataRow In dt.Rows


                ls_sql0 = "SCM.flexline.pa_vb_ins_Cajas_Chicas_M_Dist '" & tb_Lote.Text & "','" & cb_TipoDocto.Text & "','" & tb_Numero.Text & "','" & Tb_Proveedor.Text & "','" & dr.Item("Ccosto").ToString & "'"
                Otrans.Obtiene(ls_sql0)

                'lb_Mensaje.Text = "Mensajes"

                ' se envia a sincroniza a flexline

                'ls_sql2 = "spa_Convierte_Doctos_aCajasChicas_M '" & gs_empresa & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "','" & tb_Lote.Text & "'"
                'Otrans.Obtiene(ls_sql2)


                '              MsgBox("Trasladando Documento " & dr.Item("TipoDocto") & " - " & dr.Item("Numero") & " - " & dr.Item("Proveedor"))
                '             lb_Mensaje.Text = "Trasladando Documento " & dr.Item("TipoDocto") & " - " & dr.Item("Numero") & " - " & dr.Item("Proveedor")

                Total()
            Next


            '           Muestra_Facturas()
            MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Ocurrio un Problema Al Trasladar Documentos a FLEXLINE, Verifique!!")
        Finally
            Otrans.close()
            Otrans = Nothing
            '            Muestra_Facturas()
            '          Nuevo()
            '       Limpiar()

        End Try

    End Sub

    Private Sub Sincroniza_Flexline()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim OtransR As New Transaccional.Conexion("RegionalDBintOut")
        Dim ls_sql0 As String
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim ls_sqlR As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt, dtR As DataTable
        Dim Itur As Double
        Dim Idp As Double

        Try

            Otrans.open()   'abre conexion
            OtransR.open()

            ls_sql = "select empresa, tipodocto, Fecha, Numero, Proveedor, Centro_costo Ccosto from scm.flexline.con_cajas_chicas_M where empresa='" & gs_empresa & "' and convertido = 0 and lote= '" & tb_Lote.Text & "'"
            dt = Otrans.Obtiene(ls_sql)  'obtiene o ejecuta el procedimiento para extraer los datos

            For Each dr As DataRow In dt.Rows

                ls_sqlR = "pa_sel_um_numero_compra '" & gs_empresa & "','" & dr.Item("Numero").ToString & "'"
                dtR = OtransR.Obtiene(ls_sqlR)

                If dtR.Rows.Count > 0 Then
                    Itur = dtR.Rows(0).Item("ImpuestoTurismo")
                    Idp = dtR.Rows(0).Item("MontoImpuestoIDP")

                Else
                    Itur = 0.00
                    Idp = 0.00
                End If


                ls_sql2 = "pa_vb_ins_Cajas_Chicas_M '" & gs_empresa & "','" & tb_Lote.Text & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "'," & Idp & "," & Itur
                Otrans.Actualiza(ls_sql2)

                ls_sql0 = "SCM.flexline.pa_vb_ins_Cajas_Chicas_M_Dist '" & tb_Lote.Text & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "','" & dr.Item("Ccosto").ToString & "'," &
                Idp & "," & Itur
                Otrans.Obtiene(ls_sql0)


                lb_Mensaje.Text = "Mensajes"
                ls_sql2 = "spa_Convierte_Doctos_aCajasChicas_M '" & gs_empresa & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "','" & tb_Lote.Text & "'"
                '    Idp & "," & Itur
                Otrans.Obtiene(ls_sql2)

                Total()
            Next

            '           Muestra_Facturas()
            MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reporte()
            Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Ocurrio un Problema Al Trasladar Documentos a FLEXLINE, Verifique!!")
        Finally
            Otrans.close()
            Otrans = Nothing

        End Try
    End Sub


    Private Sub Reporte()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt

        Try

            pm_conexion = ClsGen.Parametros_Conexion("SCM")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "\Finanzas\Contabilidad\Jefatura\Informe De Cajas Chicas Multiple.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Lote"
            pm_valores(1) = tb_Lote.Text

            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                                    False, False, "PDF", True)

            If MessageBox.Show("Desea Imprimir los DTE ??", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Imprime_DTE()
            End If

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub Imprime_DTE()
        Dim ls_ubicaciones As String = ""
        Dim path_reporte, ppath_reporte As String

        Dim pm_valores(1), pm_valores_consolidado(1) As String
        Dim pm_parametros(1) As String
        Dim pm_conexion(1) As String
        Dim ClsGen As New ClasesGenerales.General
        Dim Oaut As Automatizar.Reportes_CraxDrt


        Try

            pm_conexion = ClsGen.Parametros_Conexion("vDataServer")
            ppath_reporte = ClsGen.Path_Reporte

            Oaut = New Automatizar.Reportes_CraxDrt("Empresa")
            path_reporte = ppath_reporte & "\Finanzas\Contabilidad\Jefatura\Impresion Facturas Sat.rpt"

            pm_parametros(0) = "@empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@lote"
            pm_valores(1) = tb_Lote.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
                                    False, False, "PDF", True)

        Catch ex As Exception
        Finally

            Oaut.finalizar()
            Oaut = Nothing
            ClsGen = Nothing

        End Try

    End Sub

    Private Sub btn_Imprime_Click(sender As Object, e As EventArgs) Handles btn_Imprime.Click
        Reporte()

    End Sub

    Private Sub btn_Producto_Click(sender As Object, e As EventArgs) Handles btn_Producto.Click
        Busca_Proveedor()
    End Sub

    Private Sub Busca_Proveedor_Grid()
        Dim AbreForma As New Frm_Proveedor_Cajas
        AbreForma.ShowDialog()

        'ls_producto = Me.dgv_empleados.Item("producto", nrow).Value
        'ods.Tables("derivados").DefaultView.RowFilter = "padre = '" & ls_producto & "'"

        Tb_Proveedor.Text = AbreForma.CtaCte
        lb_RazonSocial.Text = AbreForma.Nombre


    End Sub

    Private Sub btn_Proveedor_Click(sender As Object, e As EventArgs) Handles btn_Proveedor.Click
        Busca_Proveedor_Grid()
    End Sub

    Private Sub dtp_Fecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_Fecha.KeyPress
        If e.KeyChar = Chr(13) Then
            Tb_Proveedor.Focus()
        End If
    End Sub

    Private Sub btn_CreaLote_Click(sender As Object, e As EventArgs) Handles btn_CreaLote.Click
        Crea_Lote()
        cb_TipoDocto.Enabled = True
        dtp_Fecha.Enabled = True
        Tb_Proveedor.Enabled = True
        btn_Imprime.Enabled = True
        btn_Traslada.Enabled = True
        cb_TipoDocto.Focus()
    End Sub

    Public Sub Crea_Lote()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        Dim dr2 As DataRow

        Try

            otrans.open()    'abre conexion

            lsSQL = "spa_Cajas_chicas_Correlativo_M '" & gs_empresa & "','" & gs_usuario & "'"
            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            'lsSQL = "Select Lote from SCM.flexline.Recibos_Lote_Correlativo where empresa='" & gs_empresa & "'"
            'dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos

            For Each dr As DataRow In dt.Rows

                tb_Lote.Text = dr.Item("Lote")
                'dt.Rows(0).Item(0).ToString
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btn_BuscaLote_Click(sender As Object, e As EventArgs) Handles btn_BuscaLote.Click
        Busca_Lote()
    End Sub

    Private Sub Busca_Lote()
        Dim oform As New Frm_Cajas_Chicas_Detalle_M
        oform.ShowDialog()

        If oform.Lote = Nothing Then
            Nuevo()
        Else
            tb_Lote.Text = oform.Lote
            lb_Estado.Text = oform.Estado


            btn_Imprime.Enabled = True

            If lb_Estado.Text = "1" Then
                btn_Traslada.Enabled = False
            Else
                btn_Traslada.Enabled = True
                btn_Traslada.Visible = True
                GroupBox1.Enabled = True
                GroupBox2.Enabled = True
                GroupBox3.Enabled = True
                GroupBox4.Enabled = True

                cb_TipoDocto.Enabled = True
                dtp_Fecha.Enabled = True
                Tb_Proveedor.Enabled = True
                btn_Imprime.Enabled = True
                tb_Lote.Enabled = True
            End If

            Muestra_Facturas()
        End If

    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpiar()
    End Sub

    Private Sub cb_TipoDocto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_TipoDocto.SelectedValueChanged
        If cb_TipoDocto.SelectedIndex = -1 Or cb_TipoDocto.Text = "System.Data.DataRowView" Then
            Exit Sub
        Else
            Seleccion_Comprador_Vendedor()
        End If

    End Sub

    Private Sub Seleccion_Comprador_Vendedor()
        Dim otrans As New Transaccional.Conexion("flexline") 'Abre conexion
        Dim clsGen As New ClasesGenerales.General           'Abre las clases generales
        Dim lsSQL As String                                 'Declara Variable lsSql como String
        Dim dt As DataTable

        otrans.open()

        Try

            lsSQL = "select Empresa, TipoDocto, Comprador, Vendedor from TipoDocumento where Empresa='UMBRAL' AND Sistema='COMPRAS' and Vigente='S' and tipodocto='" & cb_TipoDocto.Text & "' ORDER BY TIPODOCTO"
            dt = otrans.Obtiene(lsSQL)

            If dt.Rows(0).Item("Comprador").ToString = "S" Then
                cb_Responsable.Visible = True
                lsSQL = "select Codigo from gen_tabcod where empresa='" & gs_empresa & "' and Tipo='GEN_COMPRADOR' AND VIGENCIA='S' order by codigo"
                dt = otrans.Obtiene(lsSQL)
                Me.cb_Responsable.DataSource = dt
                Me.cb_Responsable.DisplayMember = "Codigo"
                Me.cb_Responsable.ValueMember = "Codigo"

            ElseIf dt.Rows(0).Item("Vendedor").ToString = "S" Then
                cb_Responsable.Visible = True
                lsSQL = "select Codigo from gen_tabcod where empresa='" & gs_empresa & "' and Tipo='GEN_VENDEDOR' AND VIGENCIA='S' order by codigo"
                dt = otrans.Obtiene(lsSQL)
                Me.cb_Responsable.DataSource = dt
                Me.cb_Responsable.DisplayMember = "Codigo"
                Me.cb_Responsable.ValueMember = "Codigo"

            Else

                cb_Responsable.Text = ""
                cb_Responsable.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()      'cierra conexion
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

End Class