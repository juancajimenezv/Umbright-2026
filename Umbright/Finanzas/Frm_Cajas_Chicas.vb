Imports System.Math
Imports vb = Microsoft.VisualBasic

Public Class Frm_Cajas_Chicas
    Dim _dtDetalle As DataTable
    'Dim gs_empresa As String = "LOGISERV"
    'Dim gs_usuario As String = "ROOT"
    Dim tipodocto As String = ""
    Dim Numero As String = ""
    Dim Proveedor As String = ""

    Private Sub Frm_Cajas_Chicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCombo()

        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        btn_Imprime.Enabled = False
        '   btn_Traslada.Enabled = False

        Me.TabPage2.Parent = Nothing

        tb_Lote.Enabled = False
        tb_Lote.Text = ""
        tb_Renta.Text = "0.00"
        tb_Exento.Text = "0.00"

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
        Dim ls_sql, sql As String
        Dim dt As DataTable
        Dim iva As Double
        Dim base As Double
        Dim sbase As String
        Dim siva As String
        Dim Monto As Double
        Dim smonto As String

        Try

            iva = Math.Round((CDbl(tb_Monto.Text) - Math.Round(CDbl(tb_Exento.Text), 2)) / 1.12 * 0.12, 6)

            base = CDbl(tb_Monto.Text) - iva '+ CDbl(tb_Exento.Text),"######.00")
            Monto = CDbl(tb_Monto.Text)

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

            sql = "pa_sel_um_proveedor_caja_chica" & gs_empresa & "','" & Tb_Proveedor.Text & "','" & lb_RazonSocial.Text & "'"
            Otrans.Ingresa(sql)


            ls_sql = "spa_Guarda_Cajas_Chicas '" & gs_empresa & "','" & tb_Lote.Text & "','" & cb_TipoDocto.Text & "','" & dtp_Fecha.Text & "','" & tb_Numero.Text & "','" & Tb_Proveedor.Text & "','" &
                cb_Responsable.Text & "','" & tb_Serie.Text & "','" & smonto & "','" & tb_Producto.Text & "','" &
                tb_Item.Text & "','" & cb_CCosto.Text & "','" & cb_TipoIva.Text & "','" & siva & "','" & tb_Exento.Text & "','" & sbase & "','" & tb_Renta.Text & "','" & tb_Glosa.Text & "','" &
                cb_Combustible.Text & "','" & tb_Galones.Text & "','" & gs_usuario & "','" & Now() & "',0,'" & txt_Isr.Text & "'," & txt_diferencial.Text & "," & lbl_Idp.Text & "," & lbl_impTurismo.Text
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

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        If MessageBox.Show("Desea Guardar El Documento?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            If Tb_Proveedor.Text = "" Then
                MsgBox("El Proveedor No Puede estar Vacio")
                Tb_Proveedor.Focus()
            ElseIf tb_Numero.Text = "" Then
                MsgBox("El Numero No Puede estar Vacio")
                tb_Numero.Focus()
            ElseIf tb_Monto.Text = "" Then
                MsgBox("El Monto No Puede estar Vacio")
                tb_Monto.Focus()
            ElseIf tb_Monto.Text = "0.00" Then
                MsgBox("El Monto No Puede ser Cero")
                tb_Monto.Focus()
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
                guardar()
                ' Limpiar()
                tb_Producto.Focus()
            End If
        Else
            Limpiar()

        End If
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
        lbl_Idp.Text = "0.00"
        lbl_impTurismo.Text = "0.00"
        cb_Combustible.Visible = True
        tb_Galones.Visible = True
        dgv_Detalle.DataSource = Nothing
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        btn_Imprime.Enabled = False
        '  btn_Traslada.Enabled = False

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
        lb_Desc_Producto.Text = ""
        lb_RazonSocial.Text = ""
        lbl_Idp.Text = "0.00"
        lbl_impTurismo.Text = "0.00"
        cb_Combustible.Visible = True
        tb_Galones.Visible = True
        cb_TipoDocto.Focus()
    End Sub

    Private Sub Muestra_Facturas()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "select * from SCM.FLEXLINE.CON_CAJAS_CHICAS WHERE empresa='" & gs_empresa & "' and lote='" & tb_Lote.Text & "'"

            dt = otrans.Obtiene(lsSQL)  'obtiene o ejecuta el procedimiento para extraer los datos
            Me.dgv_Detalle.DataSource = dt
            Total()

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

            ntotal = dt.Compute("sum(Monto)", "Monto>0")
            niva = dt.Compute("sum(Iva)", "Iva>0")
            Me.lb_Total.Text = Format(ntotal, "###,##0.00")
            Me.lb_Iva.Text = Format(niva, "###,##0.00")


        Catch ex As Exception
            'MessageBox.Show(ex.Message)
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
            lb_RazonSocial.Text = dt.Rows(0).Item(0)
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

        If e.KeyChar = Chr(13) Then
            If tb_Numero.Text = "" Or tb_Numero.Text.Length = 0 Then
                Exit Sub
            Else

                busca_Datos_Sat()
            End If

        End If

        'Dim numero As String = "000000000000" & tb_Numero.Text

        'If e.KeyChar = Chr(13) Then
        '    If Mid(cb_TipoDocto.Text, 1, 4) = "FACE" Then
        '        tb_Numero.Text = vb.Right(numero, 12)
        '        tb_Monto.Focus()
        '    Else
        '        tb_Numero.Text = vb.Right(numero, 10)
        '        tb_Monto.Focus()
        '    End If

        'End If
    End Sub

    Private Sub busca_Datos_Sat()
        'clsGen.selectQuery("RegionalDBintOut", lsSQL)
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("RegionalDBintOut")

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_numero_compra '" & gs_empresa & "','" & tb_Numero.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0).Item("tipoDTE").ToString = "FPEQ" Then
                    cb_TipoDocto.Text = "FACT PEQUEÑO CONTRI"
                    cb_TipoIva.Text = "Exento"
                Else
                    cb_TipoDocto.Text = cb_TipoDocto.Text
                End If


                ' MsgBox("hay informacion")
                tb_Numero.Text = dt.Rows(0).Item("Numero")
                tb_Serie.Text = dt.Rows(0).Item("Serie")
                dtp_Fecha.Text = dt.Rows(0).Item("Fecha")
                Tb_Proveedor.Text = dt.Rows(0).Item("NitEmisor")
                tb_Monto.Text = dt.Rows(0).Item("Total")
                lb_RazonSocial.Text = dt.Rows(0).Item("RazonEmisor")
                'cmb_tipo_documento.Text = dt.Rows(0).Item("TipoGasto")
                cb_Combustible.Text = dt.Rows(0).Item("TipoGasolina")
                tb_Galones.Text = dt.Rows(0).Item("CantidadCombustible")
                lbl_Idp.Text = dt.Rows(0).Item("MontoImpuestoIDP")
                lbl_impTurismo.Text = dt.Rows(0).Item("ImpuestoTurismo")
                tb_Exento.Text = dt.Rows(0).Item("ImpuestoTurismo") + dt.Rows(0).Item("MontoImpuestoIDP")

                If dt.Rows(0).Item("TipoGasto").ToString <> "COMBUSTIBLE" Then
                    cb_Combustible.Text = "NO"
                    tb_Galones.Text = "0"
                    cb_TipoDocto.Text = "CAJAS CHICAS"
                    'cb_tipo_documento.Text = "Comida"

                ElseIf dt.Rows(0).Item("TipoGasto").ToString = "COMBUSTIBLE" Then

                    cb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR"

                End If


                Busca_Numero_Existe()

                tb_Producto.Focus()
            Else
                MsgBox("Documento no Existe, Favor de validar", MsgBoxStyle.Information, "Validar")
                Exit Sub

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Busca_Numero_Existe()
        Dim dt As DataTable
        Dim ls_sql As String
        Dim Otrans As New Transaccional.Conexion("flexline")

        Try
            Otrans.open()

            ls_sql = "pa_sel_um_busca_fel_existe_caja_chica '" & gs_empresa & "','" & tb_Numero.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then
                MessageBox.Show("El Numero Ingresado ya existe en el lote " & dt.Rows(0).Item("lote") & ", Tipo Documento " & dt.Rows(0).Item("TipoDocto") & ", Numero: " & dt.Rows(0).Item("numero"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

                tb_Numero.Focus()
                Exit Sub

            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub tb_Monto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Monto.KeyPress
        Dim monto As Double
        If e.KeyChar = Chr(13) Then

            Try
                monto = tb_Monto.Text
                tb_Monto.Text = Format(monto, "###,##0.00")
                cb_CCosto.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                tb_Monto.Focus()
                tb_Monto.SelectAll()
            End Try
        End If
    End Sub

    Private Sub cb_CCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_CCosto.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Renta.Focus()
        End If
    End Sub

    Private Sub tb_Renta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Renta.KeyPress
        Dim renta As Double
        If e.KeyChar = Chr(13) Then
            Try
                renta = tb_Monto.Text
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
            tb_Item.Focus()

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

            'MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub cb_TipoIva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_TipoIva.KeyPress
        If e.KeyChar = Chr(13) Then
            valida_periodos_abiertos()
        Else
            Exit Sub


        End If
    End Sub

    Private Sub valida_periodos_abiertos()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim dt As DataTable

        Try

            Otrans.open()   'abre conexion


            ls_sql = "pa_sel_um_periodo_activo_flexline 'LOGISERV','" & dtp_Fecha.Text & "'"
            dt = Otrans.Obtiene(ls_sql)

            If dt.Rows.Count > 0 Then

                btn_Agregar.Focus()

                'Buscar_Cliente(True)

                'If existe_cliente Then
                'boton_agregar_informacion()

                '   MessageBox.Show("Ingrese Informacion Correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)


            Else

                MessageBox.Show("Ingrese Fecha Valida! Periodo Cerrado en Flexline!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtp_Fecha.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try


    End Sub

    Private Sub tb_Exento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Exento.KeyPress
        Dim Exento As Double

        If e.KeyChar = Chr(13) Then

            Try
                Exento = tb_Exento.Text
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
            btn_Agregar.Focus()
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

    'Private Sub cb_TipoDocto_LostFocus(sender As Object, e As EventArgs) Handles cb_TipoDocto.LostFocus
    '    If cb_TipoDocto.Text = "FACE COMBUSTIBLE POR PAGAR" Then
    '        cb_Combustible.Visible = True
    '        tb_Galones.Visible = True
    '        Label11.Visible = True
    '        Label12.Visible = True
    '    ElseIf cb_TipoDocto.Text = "COMBUSTIBLE POR PAGAR" Then
    '        cb_Combustible.Visible = True
    '        tb_Galones.Visible = True
    '        Label11.Visible = True
    '        Label12.Visible = True
    '    Else
    '        cb_Combustible.Visible = False
    '        tb_Galones.Visible = False
    '        Label11.Visible = False
    '        Label12.Visible = False
    '    End If

    'End Sub


    Private Sub tb_Nuevo_Click(sender As Object, e As EventArgs) Handles tb_Nuevo.Click
        Nuevo()
    End Sub

    Private Sub btn_Traslada_Click(sender As Object, e As EventArgs) Handles btn_Traslada.Click

        If Me.dgv_Detalle.Rows.Count = 0 Then
            MsgBox("No Hay Documentos Ingresados, Verifique", MsgBoxStyle.Critical, "Atención")
            Nuevo()

        Else

            If MessageBox.Show("Desea Trasladar Documentos a FLEXLINE ??", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Muestra_Facturas()
                Nuevo()

            Else
                If MessageBox.Show("Desea Imprimir El Soporte Antes De Trasladar ??", "Soporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Traslada()
                    Muestra_Facturas()
                    Nuevo()

                Else
                    Reporte()
                    Traslada()
                    Muestra_Facturas()
                    Nuevo()
                End If

                
            End If
        End If
    End Sub

    Private Sub Traslada()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String
        Dim ls_sql2 As String
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable

        Try

            Otrans.open()   'abre conexion
            ls_sql = "select empresa,tipodocto,numero,proveedor from scm.flexline.con_cajas_chicas where empresa='" & gs_empresa & "' and convertido = 0 and lote='" & tb_Lote.Text & "'"
            dt = Otrans.Obtiene(ls_sql)  'obtiene o ejecuta el procedimiento para extraer los datos



            For Each dr As DataRow In dt.Rows

                lb_Mensaje.Text = "Mensajes"
                ls_sql2 = "spa_Convierte_Doctos_aCajasChicas '" & gs_empresa & "','" & dr.Item("TipoDocto").ToString & "','" & dr.Item("Numero").ToString & "','" & dr.Item("Proveedor").ToString & "','" & tb_Lote.Text & "'"
                Otrans.Actualiza(ls_sql2)

                'MsgBox("Trasladando Documento " & dr.Item("TipoDocto") & " - " & dr.Item("Numero") & " - " & dr.Item("Proveedor"))
                lb_Mensaje.Text = "Trasladando Documento " & dr.Item("TipoDocto").ToString & " - " & dr.Item("Numero").ToString & " - " & dr.Item("Proveedor").ToString

                Total()
            Next

            Muestra_Facturas()
            MessageBox.Show("Proceso Finalizado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("Ocurrio un Problema Al Trasladar Documentos a FLEXLINE, Verifique!!")
        Finally
            Otrans.close()
            Otrans = Nothing
            Muestra_Facturas()
            Nuevo()

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
            path_reporte = ppath_reporte & "\Finanzas\Contabilidad\Jefatura\Informe De Cajas Chicas.rpt"

            pm_parametros(0) = "@Empresa"
            pm_valores(0) = gs_empresa

            pm_parametros(1) = "@Lote"
            pm_valores(1) = tb_Lote.Text


            Oaut._reporte_generico(path_reporte, pm_parametros, pm_valores, pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3),
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
        'Busca_Proveedor()
    End Sub

    Private Sub Busca_Proveedor_Grid()
        Dim AbreForma As New Frm_Proveedor_Cajas
        AbreForma.ShowDialog()

        Tb_Proveedor.Text = AbreForma.CtaCte
        lb_RazonSocial.Text = AbreForma.Nombre
        'ls_producto = Me.dgv_empleados.Item("producto", nrow).Value
        'ods.Tables("derivados").DefaultView.RowFilter = "padre = '" & ls_producto & "'"

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
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
        GroupBox4.Enabled = True
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

            lsSQL = "spa_Cajas_chicas_Correlativo '" & gs_empresa & "','" & gs_usuario & "'"
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
        Dim oform As New Frm_Cajas_Chicas_Detalle
        oform.ShowDialog()

        If oform.Lote = Nothing Then
            Nuevo()
        Else
            tb_Lote.Text = oform.Lote
            lb_Estado.Text = oform.Estado

            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
            GroupBox4.Enabled = True
            btn_Imprime.Enabled = True

            If lb_Estado.Text = "1" Then
                btn_Traslada.Enabled = True 'False
            Else
                btn_Traslada.Enabled = True
            End If

            Muestra_Facturas()
        End If

    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Limpiar()
    End Sub

    Private Sub btnListarCajasChicas_Teams_Click(sender As Object, e As EventArgs)
        Dim clsGen As New ClasesGenerales.General
        Dim dt As DataTable
        Dim lsSQL As String

        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub
End Class