Imports System.Data
Imports System.Drawing
Imports System.Math
Public Class frm_3PL_HH

    Dim ds_datos As New DataSet
    Dim estilo As New DataGridTableStyle
    Dim sql_st As String = String.Empty
    Dim dt As DataTable
    Dim nuevo As Boolean = False
    Dim no_oc As String = String.Empty
    Dim idRow As Integer
    Dim dtSaldos As New DataTable
    Dim ods As New DataSet
    Dim total_unidades As Integer = 0
    Dim unidades_dañadas As String = ""
    Public gs_usuario As String



    Private Sub txt_ingresoDua_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ingresoDua.KeyDown

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ingresoDua.KeyPress
        If e.KeyChar = Chr(13) Then
            If txt_ingresoDua.Text.Trim.Length > 0 Then mostrar_detalle_dua(txt_ingresoDua.Text)
        End If
    End Sub
    Private Sub mostrar_detalle_dua(ByVal Numero As String)
        Dim clGen As New ClasesGenerales.General
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim dt2 As DataTable

        Try
            Otrans.open()

            If ods.Tables.Contains("detalle") Then ods.Tables("detalle").Rows.Clear()
            Me.Crear_estructura()

            sql_st = "pa_sel_um_da_detalle_dua_informe_recepcion_temp '" & gs_empresa & "', '" & Numero.Trim & "'"
            dt = Otrans.Obtiene(sql_st)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No exise este Numero de Dua Ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim dr_aux As DataRow
                Dim dt3 As DataTable
                dt3 = clGen.ValoresDistinto(dt, "proveedor".Split(","))
                Me.cmb_proveedor.DataSource = dt3
                Me.cmb_proveedor.ValueMember = "proveedor"
                Me.cmb_proveedor.DisplayMember = "proveedor"



                For Each dr As DataRow In dt.Rows
                    dr_aux = ods.Tables("detalle").NewRow
                    dr_aux.Item("no_orden") = dr.Item("no_orden")
                    dr_aux.Item("bodega") = dr.Item("bodega")
                    dr_aux.Item("correlativo") = dr.Item("correlativo")
                    dr_aux.Item("Producto") = dr.Item("Producto")
                    dr_aux.Item("Glosa") = dr.Item("Glosa")
                    dr_aux.Item("Codigo_barra") = dr.Item("Codigo_barra")
                    dr_aux.Item("Bultos") = dr.Item("Bultos")
                    dr_aux.Item("Unidades") = dr.Item("Unidades")
                    dr_aux.Item("Estanteria") = dr.Item("Estanteria")
                    dr_aux.Item("Nivel") = dr.Item("Nivel")
                    dr_aux.Item("Pasillo") = dr.Item("Pasillo")
                    dr_aux.Item("Tramo") = dr.Item("Tramo")
                    dr_aux.Item("Fecha_venc") = dr.Item("Fecha_venc")
                    dr_aux.Item("Observaciones") = dr.Item("Observaciones")
                    dr_aux.Item("Vence") = dr.Item("Vence")
                    dr_aux.Item("Produccion") = dr.Item("Produccion")
                    dr_aux.Item("Proveedor") = dr.Item("Proveedor")
                    dr_aux.Item("Registro") = dr.Item("Registro")
                    dr_aux.Item("Lote") = dr.Item("Lote")
                    dr_aux.Item("bacth") = dr.Item("bacth")
                    dr_aux.Item("Pc") = dr.Item("Pc")
                    dr_aux.Item("Unidades_malas") = dr.Item("Unidades_malas")
                    dr_aux.Item("Motivo_daño") = dr.Item("Motivo_daño")
                    dr_aux.Item("no_ordenCompra") = dr.Item("no_ordenCompra")
                    dr_aux.Item("Origen") = dr.Item("Origen")
                    dr_aux.Item("factorA") = dr.Item("factorA")
                    dr_aux.Item("barraA") = dr.Item("barraA")
                    dr_aux.Item("registro_sanitarioFechaVcto") = dr.Item("registro_sanitarioFechaVcto")
                    dr_aux.Item("casilla_31") = dr.Item("casilla_31")
                    dr_aux.Item("casilla_362") = dr.Item("casilla_362")

                    ods.Tables("detalle").Rows.Add(dr_aux)

                Next

                dgv_detalleDua.DataSource() = ods.Tables("detalle")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

        clGen.Alinear_GridView(dt, Me.dgv_detalleDua, ",no_orden,correlativo,producto,glosa,bultos,unidades,Fecha_venc,lote,unidades_malas,origen,Produccion,proveedor,Motivo_daño, ", ",Codigo_barra,bodega,Estanteria,Nivel,Pasillo,Tramo,Observaciones,Vence,Registro,bacth,Pc,no_ordenCompra,factorA,barraA,registro_sanitarioFechaVcto,", ",no_orden,correlativo,producto,glosa,bultos,unidades,Fecha_venc,lote,unidades_malas,origen,Produccion,Proveedor,Motivo_daño,", "", "", ",no_orden,", "", True, True, 250, 0)

        clGen = Nothing

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If Me.dgv_detalleDua.Rows.Count > 0 And Me.txt_ingresoDua.Text.Trim.Length > 0 Then
            If MessageBox.Show("Esta seguro de Guardar este numero de Dua ", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If Me.btn_grabar.Text = "Guardar" Then
                    Guardar_Dua()
                    limpiar_pantalla()
                End If
            Else
                MessageBox.Show("Debe ingresar Numero de Dua", "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txt_ingresoDua.Focus()
            End If

        End If

    End Sub
    Private Sub Guardar_Dua()
        Dim otrans As New Transaccional.Conexion("FlexLine")
        Dim Utrans As New Transaccional.Conexion("SCM")

        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dta As DataTable

        Try

            Utrans.open()
            otrans.open()

            ls_sql = "select numero from Documento where empresa = '" & gs_empresa & "' and numero LIKE '%" & Me.txt_ingresoDua.Text.Trim & "%'"
            dta = otrans.Obtiene(ls_sql)
            If dta.Rows.Count > 0 Then
                MessageBox.Show("Numero de Documentos ya existe en el sistema", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                ls_sql = "flexline.pa_ins_umb_Entrada_Producto_3PL '" & Me.txt_ingresoDua.Text.Trim & "','" & gs_usuario & "'"
                Utrans.Obtiene(ls_sql)

                MessageBox.Show("Proceso Guardado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
        Finally
            Utrans.close()
            otrans.close()
        End Try
    End Sub
    Private Sub limpiar_pantalla()
        Me.dgv_detalleDua.DataSource = Nothing
        Me.txt_ingresoDua.Text = ""
    End Sub


    Private Sub frm_Ingreso_dua_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Crear_estructura()



    End Sub
    Private Sub Crear_estructura()
        'Dim dt, dt2, dt3 As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        'ods = New DataSet
        'dt = New DataTable("detalle")
        'dt2 = New DataTable("encabezado")

        dt.Columns.Add(New DataColumn("no_orden", GetType(String)))
        dt.Columns.Add(New DataColumn("bodega", GetType(String)))
        dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
        dt.Columns.Add(New DataColumn("Producto", GetType(String)))
        dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("Codigo_barra", GetType(String)))
        dt.Columns.Add(New DataColumn("Bultos", GetType(String)))
        dt.Columns.Add(New DataColumn("Unidades", GetType(String)))
        dt.Columns.Add(New DataColumn("Estanteria", GetType(String)))
        dt.Columns.Add(New DataColumn("Nivel", GetType(String)))
        dt.Columns.Add(New DataColumn("Pasillo", GetType(String)))
        dt.Columns.Add(New DataColumn("Tramo", GetType(String)))
        dt.Columns.Add(New DataColumn("Fecha_venc", GetType(String)))
        dt.Columns.Add(New DataColumn("Observaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("Vence", GetType(String)))
        dt.Columns.Add(New DataColumn("Produccion", GetType(String)))
        dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
        dt.Columns.Add(New DataColumn("Registro", GetType(String)))
        dt.Columns.Add(New DataColumn("Lote", GetType(String)))
        dt.Columns.Add(New DataColumn("bacth", GetType(String)))
        dt.Columns.Add(New DataColumn("Pc", GetType(String)))
        dt.Columns.Add(New DataColumn("Unidades_malas", GetType(String)))
        dt.Columns.Add(New DataColumn("Motivo_daño", GetType(String)))
        dt.Columns.Add(New DataColumn("no_ordenCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("Origen", GetType(String)))
        dt.Columns.Add(New DataColumn("factorA", GetType(String)))
        dt.Columns.Add(New DataColumn("barraA", GetType(String)))
        dt.Columns.Add(New DataColumn("registro_sanitarioFechaVcto", GetType(String)))
        dt.Columns.Add(New DataColumn("casilla_31", GetType(Integer)))
        dt.Columns.Add(New DataColumn("casilla_362", GetType(String)))


        'dr.Item("factorA") & "','" & dr.Item("barraA") & "','" & dr.Item("registro_sanitarioFechaVcto") & "'"
        '  ods.Tables.Add(dt)




        dt.TableName = "detalle"

        If ods.Tables.Contains("detalle") Then ods.Tables.Remove("detalle")
        ods.Tables.Add(dt.Copy)
        Me.dgv_detalleDua.DataSource = ods.Tables("Detalle")



        ' dt = New DataTable("dt_motivo_daño")




        dt2.Columns.Add("Descripcion", GetType(String))
        dt2.Columns.Add("Cantidad", GetType(Integer))
        dt2.TableName = "dt_motivo_daño"
        '        ods.Tables.Add(dt2.Copy)

        If ods.Tables.Contains("dt_motivo_daño") Then ods.Tables.Remove("dt_motivo_daño")
        ods.Tables.Add(dt2.Copy)
        Me.dgv_motivo_daño.DataSource = ods.Tables("dt_motivo_daño")



        Me.llenar_motivos()




















    End Sub
    Private Sub llenar_motivos()

        Dim Otrans As New Transaccional.Conexion("scm")
        Dim dtr As DataTable
        Dim dr_aux As DataRow

        Dim ls_sql As String
        Dim clgen As New ClasesGenerales.General



        Try

            Otrans.open()

            ls_sql = "scm.flexline.pa_sel_um_codigos_genericos null, 'MOTIVO_DAÑO'"
            dtr = Otrans.Obtiene(ls_sql)
            For Each dr As DataRow In dtr.Rows
                dr_aux = ods.Tables("dt_motivo_daño").NewRow
                dr_aux.Item("Descripcion") = dr.Item("descripcion")
                dr_aux.Item("Cantidad") = 0
                ods.Tables("dt_motivo_daño").Rows.Add(dr_aux)

            Next

            Try
                Me.dgv_motivo_daño.DataSource = ods.Tables("dt_motivo_daño")
                clgen.Alinear_GridView(ods.Tables("dt_motivo_daño"), Me.dgv_motivo_daño, ",Descripcion,cantidad,", ",,", ",Descripcion,", "", "", ",Descripcion=150,cantidad=30,", "", True, True, 250, 0)
            Catch ex As Exception

            End Try


        Catch ex As Exception
        Finally
            Otrans.close()

        End Try

    End Sub



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Exportar_reporte()
    End Sub

    Private Sub Exportar_reporte()
        Dim path_reporte As String
        Dim pm_valores(4) As String
        Dim pm_parametros(4) As String


        Dim nrow, npedido As Integer
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            ' pm_conexion = ClsGen.Parametros_Conexion("dataserver")
            pm_conexion(0) = "vDATASERVER"
            pm_conexion(1) = "SCM"
            pm_conexion(2) = "flexline"
            pm_conexion(3) = "flexline"


            path_reporte = ClsGen.Path_Reporte()

            path_reporte = "\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\Reportes$\Compras e Importaciones\da\informe de recepcion de mercancia ingreso PDA Da julio.rpt"
            pm_parametros(0) = "empresa"
            'pm_parametros(0) = "empresa"
            pm_valores(0) = gs_empresa
            'pm_valores(0) = gs_empresa
            pm_parametros(1) = "noDUA"
            'pm_parametros(1) = "noDUA"
            pm_valores(1) = Me.txt_ingresoDua.Text.Trim
            'pm_valores(1) = Me.txt_ingresoDua.Text.Trim
            'pm_parametros(2) = "@Empresa"
            'pm_valores(2) = gs_empresa
            'pm_parametros(3) = "@Proveedor"
            'pm_valores(3) = ""
            'pm_parametros(4) = "@Numero"
            'pm_valores(4) = Me.txt_ingresoDua.Text.Trim




            'pm_valores(1) = Today
            'pm_parametros(2) = "@FechaF"
            'pm_valores(2) = Now

            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "DATASERVER", "BDflexline", "flexline", "flexline", True, False, "PDF", False, "", True)

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                          False, True, "PDF", False, "", True)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ClsGen = Nothing
        End Try
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        imprimir_reporte()
    End Sub
    Private Sub imprimir_reporte()
        Dim path_reporte As String
        Dim pm_valores(1) As String
        Dim pm_parametros(1) As String
        Dim nrow, npedido As Integer
        Dim pm_conexion(3) As String
        Dim ClsGen As New ClasesGenerales.General

        Try
            ' pm_conexion = ClsGen.Parametros_Conexion("dataserver")
            pm_conexion(0) = "vDATASERVER"
            pm_conexion(1) = "SCM"
            pm_conexion(2) = "flexline"
            pm_conexion(3) = "flexline"


            path_reporte = ClsGen.Path_Reporte()

            path_reporte = "\\" & ClsGen.Obtener_XMLConfig("Servidor_Alterno_" & ClsGen.Obtener_XMLConfig("ubicacion", False), False) & "\Reportes$\Compras e Importaciones\da\informe de recepcion de mercancia ingreso PDA Da julio.rpt"
            pm_parametros(0) = "empresa"
            pm_valores(0) = gs_empresa
            pm_parametros(1) = "noDUA"
            pm_valores(1) = Me.txt_ingresoDua.Text.Trim


            'pm_valores(1) = Today
            'pm_parametros(2) = "@FechaF"
            'pm_valores(2) = Now



            '_reporte_generico_clase(path_reporte, pm_parametros, pm_valores, "DATASERVER", "BDflexline", "flexline", "flexline", True, False, "PDF", False, "", True)

            _reporte_generico_clase(path_reporte, pm_parametros, pm_valores, _
                          pm_conexion(0), pm_conexion(1), pm_conexion(2), pm_conexion(3), _
                          False, True, "PDF", False, "", True)




            ' Exportar_reporte()

        Catch ex As Exception

        End Try
    End Sub



    Private Sub unidades_malas(ByVal idrow As Integer)


        Dim motivos As String
        Dim cantidad_motivos As Integer
        Dim expresion, valor As String
        Dim cantidad As String

        Dim i As Integer = 0
        Dim j As Integer = 0
        Try



            For Each drx As DataRow In ods.Tables("dt_motivo_daño").Rows
                drx.Item("Cantidad") = 0

            Next
            Me.dgv_motivo_daño.Refresh()

            motivos = Me.dgv_detalleDua.Item("motivo_daño", idrow).Value
            cantidad_motivos = motivos.Split(",").Length - 1

            For i = 0 To cantidad_motivos
                expresion = motivos.Split(",")(i).Split(")")(1).Trim()
                valor = motivos.Split(",")(i).Split(")")(0).Trim()
                cantidad = valor.Split("(")(1)

                'For j As Integer = 0 To Me.dgv_motivo_daño.Rows.Count - 1
                '    If expresion = Me.dgv_motivo_daño.Item("Descripcion", j).Value Then
                '        Me.dgv_motivo_daño.Item("Cantidad", j).Value = cantidad
                '        Exit For
                '    End If
                'Next

                For Each dr As DataRow In ods.Tables("dt_motivo_daño").Rows
                    If expresion = dr.Item("Descripcion").ToString Then
                        dr.Item("cantidad") = cantidad
                        Exit For
                    End If
                Next

            Next

        Catch ex As Exception

        End Try




    End Sub
    Private Sub Despliega_Informacion(ByVal pirow As Integer)
        Try

            Me.txt_cod_producto.Text = Me.dgv_detalleDua.Item("producto", pirow).Value
            Me.txt_descripcion.Text = Me.dgv_detalleDua.Item("Glosa", pirow).Value
            Me.txt_unidades.Text = Me.dgv_detalleDua.Item("Unidades", pirow).Value
            Try
                Me.dtpFechaVctoProducto.Value = Me.dgv_detalleDua.Item("Fecha_venc", pirow).Value
            Catch ex As Exception
                Me.dtpFechaVctoProducto.Value = Now.ToString


            End Try
            Try
                Me.txt_lote_oculto.Text = Me.dgv_detalleDua.Item("lote", pirow).Value
            Catch ex As Exception
                Me.txt_lote_oculto.Text = ""

            End Try

            Try
                Me.txt_produccion.Text = Me.dgv_detalleDua.Item("Produccion", pirow).Value
            Catch ex As Exception
                Me.txt_produccion.Text = ""

            End Try


            Me.txtLoteProducto.Text = Me.dgv_detalleDua.Item("Lote", pirow).Value
            Try
                Me.txt_origen.Text = Me.dgv_detalleDua.Item("Origen", pirow).Value
            Catch ex As Exception
                Me.txt_origen.Text = ""

            End Try

            ' Me.txt_umalas.Text = Me.dgv_detalleDua.Item("Unidades_malas", pirow).Value

            unidades_malas(pirow)





        Catch ex As Exception

        End Try

    End Sub





    Private Sub dgv_detalleDua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_detalleDua.Click
        Try
            Despliega_Informacion(Me.dgv_detalleDua.CurrentRow.Index)

        Catch ex As Exception

        End Try
    End Sub



    Private Sub dgv_detalleDua_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_detalleDua.CurrentCellChanged
        Try
            Despliega_Informacion(Me.dgv_detalleDua.CurrentRow.Index)

        Catch ex As Exception

        End Try
    End Sub



    Function validar_campos() As Boolean

        If Me.txt_cod_producto.Text.Trim.Length > 0 And Me.txt_unidades.Text.Trim.Length > 0 And Val(Me.txt_unidades.Text.Trim) > 0 Then


        Else
            MessageBox.Show("Verifique Unidades", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txt_unidades.Focus()

            Return False

        End If

        If Me.dtpFechaVctoProducto.Value < Today And Me.chk_fechavcto.Checked = True Then


            MessageBox.Show("La fecha de Vencimiento no puede ser menor al dia de hoy", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.dtpFechaVctoProducto.Focus()
            Return False
        End If


        Return True

    End Function
    Private Sub verificar_unidades()

        total_unidades = 0
        unidades_dañadas = ""

        For Each dr As DataRow In ods.Tables("dt_motivo_daño").Rows
            If Val(dr.Item("cantidad").ToString) > 0 Then
                If unidades_dañadas.Length = 0 Then
                    unidades_dañadas = "(" & dr.Item("cantidad") & ") " & dr.Item("Descripcion")
                ElseIf unidades_dañadas.Length > 0 Then
                    unidades_dañadas += ",(" & dr.Item("cantidad") & ") " & dr.Item("Descripcion")
                End If

            End If


        Next


        Try
            Me.total_unidades = ods.Tables("dt_motivo_daño").Compute("sum(cantidad)", "cantidad>0")
        Catch ex As Exception
            Me.total_unidades = 0
        End Try
        For Each dr As DataRow In ods.Tables("dt_motivo_daño").Rows
            dr.Item("cantidad") = 0

        Next
    End Sub
    Private Sub modificar_info()
        'Despliega_Informacion(Me.dgv_detalleDua.CurrentRow.Index)

        verificar_unidades()
        For Each dr As DataRow In ods.Tables("Detalle").Rows
            If Me.txt_cod_producto.Text = dr.Item("producto").ToString And Me.txt_lote_oculto.Text = dr.Item("lote").ToString Then
                dr.Item("unidades") = Me.txt_unidades.Text.Trim
                dr.Item("Unidades_malas") = Me.total_unidades
                'Me.dgv_detalleDua.Item("unidades", Me.dgv_detalleDua.CurrentRow.Index).Value = Me.txt_unidades.Text.Trim
                'Me.dgv_detalleDua.Item("Unidades_malas", Me.dgv_detalleDua.CurrentRow.Index).Value = Me.total_unidades
                'Me.dgv_detalleDua.Item("motivo_daño", Me.dgv_detalleDua.CurrentRow.Index).Value = Me.unidades_dañadas
                dr.Item("Motivo_daño") = Me.unidades_dañadas
                dr.Item("produccion") = Me.txt_produccion.Text.Trim
                dr.Item("origen") = Me.txt_origen.Text.Trim
                dr.Item("lote") = Me.txtLoteProducto.Text.Trim

                If Me.chk_fechavcto.Checked = True Then
                    dr.Item("fecha_venc") = Me.dtpFechaVctoProducto.Value.ToString("dd/MM/yyyy")


                End If


                Exit For

            End If
        Next
    End Sub
    Private Sub limpiar_linea()
        Me.txt_unidades.Text = ""
        Me.txt_cod_producto.Text = ""
        Me.txt_descripcion.Text = ""
        Me.dtpFechaVctoProducto.Value = Today
        Me.txt_lote_oculto.Text = ""
        Me.txt_produccion.Text = ""
        Me.txt_origen.Text = ""
        Me.txt_produccion.Text = ""
        Me.txtLoteProducto.Text = ""
        Me.chk_fechavcto.Checked = False
        Me.dtpFechaVctoProducto.Enabled = False




    End Sub
    Private Sub btn_agrega_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agrega_producto.Click
        If validar_campos() Then
            modificar_info()
            limpiar_linea()
            filtrar_grid()



        End If
    End Sub

    Private Sub txt_unidades_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_unidades.LostFocus
        Try
            Me.txt_unidades.Text = Int32.Parse(Me.txt_unidades.Text)
            If Double.Parse(Me.txt_unidades.Text.ToString) < 0 Then
                Me.txt_unidades.Text = 0
                Me.txt_unidades.Focus()
            End If

        Catch ex As Exception
            Me.txt_unidades.Text = 0
        Finally

        End Try
    End Sub



    Private Sub chk_fechavcto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_fechavcto.CheckedChanged
        If Me.chk_fechavcto.Checked = True Then
            Me.dtpFechaVctoProducto.Enabled = True
        Else
            Me.dtpFechaVctoProducto.Enabled = False

        End If
    End Sub
    Private Sub actualizar_dua()
        Dim Otrans As New Transaccional.Conexion("scm")
        Dim dtr As DataTable
        Dim dr_aux As DataRow

        Dim ls_sql As String
        Dim clgen As New ClasesGenerales.General




        Try

            Otrans.open()
            ls_sql = "delete from da_dua_detalle_tmp where empresa='" & gs_empresa & "' and no_orden='" & ods.Tables("detalle").Rows(0).Item("no_orden") & "'"
            Otrans.Obtiene(ls_sql)


            For Each dr As DataRow In ods.Tables("detalle").Rows

                'dt.Columns.Add(New DataColumn("no_orden", GetType(String)))
                'dt.Columns.Add(New DataColumn("bodega", GetType(String)))
                'dt.Columns.Add(New DataColumn("correlativo", GetType(String)))
                'dt.Columns.Add(New DataColumn("Producto", GetType(String)))
                'dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
                'dt.Columns.Add(New DataColumn("Codigo_barra", GetType(String)))
                'dt.Columns.Add(New DataColumn("Bultos", GetType(String)))
                'dt.Columns.Add(New DataColumn("Unidades", GetType(String)))
                'dt.Columns.Add(New DataColumn("Estanteria", GetType(String)))
                'dt.Columns.Add(New DataColumn("Nivel", GetType(String)))
                'dt.Columns.Add(New DataColumn("Pasillo", GetType(String)))
                'dt.Columns.Add(New DataColumn("Tramo", GetType(String)))
                'dt.Columns.Add(New DataColumn("Fecha_venc", GetType(String)))
                'dt.Columns.Add(New DataColumn("Observaciones", GetType(String)))
                'dt.Columns.Add(New DataColumn("Vence", GetType(String)))
                'dt.Columns.Add(New DataColumn("Produccion", GetType(String)))
                'dt.Columns.Add(New DataColumn("Proveedor", GetType(String)))
                'dt.Columns.Add(New DataColumn("Registro", GetType(String)))
                'dt.Columns.Add(New DataColumn("Lote", GetType(String)))
                'dt.Columns.Add(New DataColumn("bacth", GetType(String)))
                'dt.Columns.Add(New DataColumn("Pc", GetType(String)))
                'dt.Columns.Add(New DataColumn("Unidades_malas", GetType(String)))
                'dt.Columns.Add(New DataColumn("Motivo_daño", GetType(String)))
                'dt.Columns.Add(New DataColumn("no_ordenCompra", GetType(String)))
                'dt.Columns.Add(New DataColumn("Origen", GetType(String)))

                ls_sql = "scm.flexline.pa_ins_um_da_dua_detalleProveedor_tmp '" & dr.Item("no_orden") & "','" & _
                dr.Item("no_ordenCompra") & "',0,'','','','" & gs_empresa & "','" & dr.Item("bodega") & "'," & _
                dr.Item("correlativo") & ",'" & dr.Item("producto") & "','" & dr.Item("codigo_barra") & "','" & _
                dr.Item("fecha_venc").ToString & "',NULL," & dr.Item("bultos") & "," & _
                dr.Item("unidades") & ",'" & dr.Item("estanteria") & "','" & dr.Item("nivel") & "','" & _
                dr.Item("pasillo") & "','" & dr.Item("tramo") & "',0,'" & dr.Item("observaciones") & "',0,'" & _
                dr.Item("vence") & "','" & dr.Item("proveedor") & "','" & dr.Item("registro") & "','" & _
                dr.Item("lote") & "','" & dr.Item("bacth") & "','" & dr.Item("pc") & "'," & dr.Item("unidades_malas") & "," & _
                IIf(dr.Item("produccion").ToString.Length > 0, dr.Item("produccion").ToString, 0) & ",NULL,NULL,NULL,'" & dr.Item("motivo_daño") & "',NULL,NULL,NULL,'" & dr.Item("no_ordenCompra") & "','" & _
                dr.Item("origen") & "','" & dr.Item("factorA") & "','" & dr.Item("barraA") & "','" & dr.Item("registro_sanitarioFechaVcto") & "'," & dr.Item("casilla_31") & ",'" & dr.Item("casilla_362").ToString & "'"


                Otrans.Ingresa(ls_sql)





            Next



        Catch ex As Exception
        Finally
            Otrans.close()

        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Esta seguro de Actualizar la Informacion ", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            actualizar_dua()
            Me.limpiar_pantalla()
            limpiar_linea()
            Crear_estructura()
            MessageBox.Show("Informacion Actualizada con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If


    End Sub

    Private Sub filtrar_grid()

        Try
            Dim dt As DataTable
            Dim clgen As New ClasesGenerales.General

            ods.Tables("detalle").DefaultView.RowFilter = "proveedor= '" & Me.cmb_proveedor.Text & "'"
            dt = ods.Tables("detalle").DefaultView.ToTable
            Me.dgv_detalleDua.DataSource = dt

            clgen.Alinear_GridView(dt, Me.dgv_detalleDua, ",no_orden,correlativo,producto,glosa,bultos,unidades,Fecha_venc,lote,unidades_malas,origen,Produccion,proveedor,Motivo_daño,", ",Codigo_barra,bodega,Estanteria,Nivel,Pasillo,Tramo,Observaciones,Vence,Registro,bacth,Pc,no_ordenCompra ,", ",no_orden,correlativo,producto,glosa,bultos,unidades,Fecha_venc,lote,unidades_malas,origen,Produccion,Proveedor,Motivo_daño,", "", "", ",no_orden,", "", True, True, 250, 0)




            ods.Tables("detalle").DefaultView.RowFilter = ""


            clgen = Nothing

        Catch ex As Exception

        End Try
    End Sub



    Private Sub cmb_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_proveedor.SelectedIndexChanged
        Try
            filtrar_grid()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_ingresoDua_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ingresoDua.TextChanged

    End Sub

    Private Sub dgv_detalleDua_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_detalleDua.CellContentClick

    End Sub
End Class