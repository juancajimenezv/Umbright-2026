Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Frm_Clientes_Contado
    Inherits System.Windows.Forms.Form
    Dim oTransaccion As Transaccional.Conexion
    Dim ls_SqlScript As String
    Dim ls_SqlScript2 As String
    Dim oTabla1 As DataTable
    Dim pds_Dataset As New DataSet
    Dim pdataset As New DataSet
    'Dim gs_empresa As String = "VINOTECA"
    'Dim gs_usuario As String = "ROOT"
    Dim ds_clientes As DataSet


    Private Sub Frm_Clientes_Contado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_ComboBox()
        Nuevo()
        tb_Cliente.Focus()
    End Sub

    Private Sub carga_ComboBox()

        Dim ldt_table As New DataTable
        Dim ldt_table2 As New DataTable
        Dim l_Dataset As New DataSet
        Dim l_Dataset2 As New DataSet

        oTransaccion = New Transaccional.Conexion("flexline")
        oTransaccion.open()

        ls_SqlScript = "pa_um_sel_Vigencia_Ctacte '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Vigencia"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Vigencia.DisplayMember = "Vigencia"
        Me.cb_Vigencia.ValueMember = "Vigencia"
        Me.cb_Vigencia.DataSource = ldt_table

        ls_SqlScript = "pa_um_sel_Vendedor_CtaCte '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Vendedor"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Vendedor.DisplayMember = "Vendedor"
        Me.cb_Vendedor.ValueMember = "Vendedor"
        Me.cb_Vendedor.DataSource = ldt_table


        ls_SqlScript = "pa_um_sel_Condicion_CtaCte '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Condicion"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Condicion.DisplayMember = "Condicion"
        Me.cb_Condicion.ValueMember = "Condicion"
        Me.cb_Condicion.DataSource = ldt_table

        ls_SqlScript = "pa_sel_um_ListaPrecio_CtaCte'" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Lista"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_ListaPrecio.DisplayMember = "Lista"
        Me.cb_ListaPrecio.ValueMember = "Lista"
        Me.cb_ListaPrecio.DataSource = ldt_table

        ls_SqlScript = "spa_Ruta_CtaCte_Contado '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Ruta"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Ruta.DisplayMember = "Ruta"
        Me.cb_Ruta.ValueMember = "Ruta"
        Me.cb_Ruta.DataSource = ldt_table


        ls_SqlScript = "spa_Region_CtaCte_Contado '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Region"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Region.DisplayMember = "Region"
        Me.cb_Region.ValueMember = "Region"
        Me.cb_Region.DataSource = ldt_table

        ls_SqlScript = "spa_Estado_CtaCte_Contado '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Estado"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Estado.DisplayMember = "Estado"
        Me.cb_Estado.ValueMember = "Estado"
        Me.cb_Estado.DataSource = ldt_table

        ls_SqlScript = "spa_Comuna_CtaCte_Contado '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Comuna"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Comuna.DisplayMember = "Comuna"
        Me.cb_Comuna.ValueMember = "Comuna"
        Me.cb_Comuna.DataSource = ldt_table

        ls_SqlScript = "spa_Tipo_CtaCte_Contado '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Tipo"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Tipo.DisplayMember = "Tipo"
        Me.cb_Tipo.ValueMember = "Tipo"
        Me.cb_Tipo.DataSource = ldt_table

        ls_SqlScript = "spa_Grupo_CtaCte_Contado '" & gs_empresa & "'"

        ldt_table = oTransaccion.Obtiene(ls_SqlScript)
        ldt_table.TableName = "Grupo"
        l_Dataset.Tables.Add(ldt_table.Copy)

        Me.cb_Grupo.DisplayMember = "Grupo"
        Me.cb_Grupo.ValueMember = "Grupo"
        Me.cb_Grupo.DataSource = ldt_table

    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            otrans.open()   'abre conexion
            lsSQL = "flexline.pa_sel_um_ctacte_Existe '" & gs_empresa & "','" & tb_Cliente.Text & "'"
            dt = otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then
                If tb_Nit.Text.Length = 0 Then
                    MsgBox("Falta Ingresar NIT", MsgBoxStyle.Critical, "Falta NIT")
                    tb_Nit.Focus()

                ElseIf tb_RazonSocial.Text.Length = 0 Then
                    MsgBox("Falta Ingresar Razón Social", MsgBoxStyle.Critical, "Falta Razón Social")
                    tb_RazonSocial.Focus()


                ElseIf tb_Direccion.Text.Length = 0 Then
                    MsgBox("Falta Ingresar Dirección", MsgBoxStyle.Critical, "Falta Dirección")
                    tb_Direccion.Focus()
                End If
                Actualizar()

            Else

                If tb_Nit.Text.Length = 0 Then
                    MsgBox("Falta Ingresar NIT", MsgBoxStyle.Critical, "Falta NIT")
                    tb_Nit.Focus()

                ElseIf tb_RazonSocial.Text.Length = 0 Then
                    MsgBox("Falta Ingresar Razón Social", MsgBoxStyle.Critical, "Falta Razón Social")
                    tb_RazonSocial.Focus()


                ElseIf tb_Direccion.Text.Length = 0 Then
                    MsgBox("Falta Ingresar Dirección", MsgBoxStyle.Critical, "Falta Dirección")
                    tb_Direccion.Focus()
                End If
                Grabar()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
        End Try



    End Sub

    Private Sub Grabar()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try

            Otrans.open()   'abre conexion

            ls_sql = "spa_CtaCte_CtaCte_Contado '" & gs_empresa & "','" & tb_Cliente.Text & "','" & tb_Nit.Text & "','" & tb_RazonSocial.Text & "','" & tb_Giro.Text & "','" &
                cb_Tipo.Text & "','" & cb_Grupo.Text & "','" & tb_Sucursal.Text & "','S','" &
                cb_Vendedor.Text & "','" & cb_Condicion.Text & "','" & cb_ListaPrecio.Text & "','" & tb_Contacto.Text & "','" & cb_Ruta.Text & "','" & tb_Comentario.Text & "','" & tb_Direccion.Text & "','" & cb_Region.Text & "','" &
                cb_Estado.Text & "','" & cb_Comuna.Text & "','" & tb_Telefono.Text & "','" & gs_usuario & "','" & Now() & "'"
            Otrans.Actualiza(ls_sql)

            Guarda_Zona10()

            MessageBox.Show("Cliente Grabado Correctamente, Revisen en FLEXLINE!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try

    End Sub

    Private Sub Guarda_Zona10()
        Dim Otrans As New Transaccional.Conexion("FlexLineSV10")
        Dim ls_sql As String

        Try

            Otrans.open()   'abre conexion

            ls_sql = "spa_CtaCte_CtaCte_Contado '" & gs_empresa & "','" & tb_Cliente.Text & "','" & tb_Nit.Text & "','" & tb_RazonSocial.Text & "','" & tb_Giro.Text & "','" &
                cb_Tipo.Text & "','" & cb_Grupo.Text & "','" & tb_Sucursal.Text & "','S','" &
                cb_Vendedor.Text & "','" & cb_Condicion.Text & "','" & cb_ListaPrecio.Text & "','" & tb_Contacto.Text & "','" & cb_Ruta.Text & "','" & tb_Comentario.Text & "','" & tb_Direccion.Text & "','" & cb_Region.Text & "','" &
                cb_Estado.Text & "','" & cb_Comuna.Text & "','" & tb_Telefono.Text & "','" & gs_usuario & "','" & Now() & "'"
            Otrans.Actualiza(ls_sql)

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub Actualizar()
        Dim Otrans As New Transaccional.Conexion("FlexLine")
        Dim ls_sql As String

        Try

            Otrans.open()   'abre conexion

            ls_sql = "pa_upd_um_CtaCte_TKM '" & gs_empresa & "','" & tb_Cliente.Text & "','" & tb_Nit.Text & "','" & tb_RazonSocial.Text & "','" & tb_Giro.Text & "','" &
                cb_Tipo.Text & "','" & cb_Grupo.Text & "','" & tb_Sucursal.Text & "','S','" &
                cb_Vendedor.Text & "','" & cb_Condicion.Text & "','" & cb_ListaPrecio.Text & "','" & tb_Contacto.Text & "','" & cb_Ruta.Text & "','" & tb_Comentario.Text & "','" & tb_Direccion.Text & "','" & cb_Region.Text & "','" &
                cb_Estado.Text & "','" & cb_Comuna.Text & "','" & tb_Telefono.Text & "','" & gs_usuario & "','" & Now() & "'"
            Otrans.Actualiza(ls_sql)

            ActualizarZ10()

            MessageBox.Show("Cliente Actualizado Correctamente, Revisen en FLEXLINE!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub

    Private Sub ActualizarZ10()
        Dim Otrans As New Transaccional.Conexion("FlexLineSV10")
        Dim ls_sql As String

        Try

            Otrans.open()   'abre conexion

            ls_sql = "pa_upd_um_CtaCte_TKM '" & gs_empresa & "','" & tb_Cliente.Text & "','" & tb_Nit.Text & "','" & tb_RazonSocial.Text & "','" & tb_Giro.Text & "','" &
                cb_Tipo.Text & "','" & cb_Grupo.Text & "','" & tb_Sucursal.Text & "','S','" &
                cb_Vendedor.Text & "','" & cb_Condicion.Text & "','" & cb_ListaPrecio.Text & "','" & tb_Contacto.Text & "','" & cb_Ruta.Text & "','" & tb_Comentario.Text & "','" & tb_Direccion.Text & "','" & cb_Region.Text & "','" &
                cb_Estado.Text & "','" & cb_Comuna.Text & "','" & tb_Telefono.Text & "','" & gs_usuario & "','" & Now() & "'"
            Otrans.Actualiza(ls_sql)

            Nuevo()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            Otrans.close()
            Otrans = Nothing
        End Try
    End Sub
    Private Sub Nuevo()
        tb_Cliente.Text = ""
        tb_Nit.Text = ""
        tb_RazonSocial.Text = ""
        tb_Giro.Text = ""
        cb_Tipo.SelectedIndex = -1
        cb_Grupo.SelectedIndex = -1
        tb_Sucursal.Text = ""
        cb_Vigencia.SelectedIndex = -1
        cb_Vendedor.SelectedIndex = -1
        cb_Condicion.SelectedIndex = -1
        cb_ListaPrecio.SelectedIndex = -1
        tb_Contacto.Text = ""
        cb_Ruta.SelectedIndex = -1
        tb_Comentario.Text = ""
        tb_Direccion.Text = ""
        cb_Region.SelectedIndex = -1
        cb_Estado.SelectedIndex = -1
        cb_Comuna.SelectedIndex = -1
        tb_Telefono.Text = ""

        tb_Nit.Enabled = False
        tb_RazonSocial.Enabled = False
        tb_Giro.Enabled = False
        cb_Tipo.Enabled = False
        cb_Grupo.Enabled = False
        tb_Sucursal.Enabled = False
        cb_Vigencia.Enabled = False
        cb_Vendedor.Enabled = False
        cb_Condicion.Enabled = False
        cb_ListaPrecio.Enabled = False
        tb_Contacto.Enabled = False
        cb_Ruta.Enabled = False
        tb_Comentario.Enabled = False
        tb_Direccion.Enabled = False
        cb_Region.Enabled = False
        cb_Estado.Enabled = False
        cb_Comuna.Enabled = False
        tb_Telefono.Enabled = False

        tb_Cliente.Enabled = True
        tb_Cliente.Focus()

    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Nuevo()
    End Sub

    Private Sub tb_Cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Cliente.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                If Me.tb_Cliente.Text.Length > 0 Then
                    Busca_Cliente()
                    tb_Nit.Focus()
                    tb_Cliente.Enabled = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Busca_Cliente()
        Dim otrans As New Transaccional.Conexion("flexline")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable
        'Dim dr, dr_aux As DataRow

        Try
            otrans.open()   'abre conexion
            lsSQL = "flexline.pa_sel_um_ctacte_Existe '" & gs_empresa & "','" & tb_Cliente.Text & "'"
            dt = otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then

                tb_Cliente.Text = dt.Rows(0)("Cliente").ToString
                tb_Nit.Text = dt.Rows(0)("CodLegal").ToString
                tb_RazonSocial.Text = dt.Rows(0)("RazonSocial").ToString
                tb_Giro.Text = dt.Rows(0)("Giro").ToString
                cb_Tipo.Text = dt.Rows(0)("Tipo").ToString
                cb_Grupo.Text = dt.Rows(0)("Grupo").ToString
                tb_Sucursal.Text = dt.Rows(0)("Sucursal").ToString
                cb_Vigencia.Text = dt.Rows(0)("Vigencia").ToString
                cb_Vendedor.Text = dt.Rows(0)("Vendedor").ToString
                cb_Condicion.Text = dt.Rows(0)("Condicion").ToString
                cb_ListaPrecio.Text = dt.Rows(0)("ListaPRecio").ToString
                tb_Contacto.Text = dt.Rows(0)("Contacto").ToString
                cb_Ruta.Text = dt.Rows(0)("Ruta").ToString
                tb_Comentario.Text = dt.Rows(0)("Comentario1").ToString
                tb_Direccion.Text = dt.Rows(0)("Direccion").ToString
                cb_Region.Text = dt.Rows(0)("Region").ToString
                cb_Estado.Text = dt.Rows(0)("Estado").ToString
                cb_Comuna.Text = dt.Rows(0)("Comuna").ToString
                tb_Telefono.Text = dt.Rows(0)("Telefono").ToString
                tb_Cliente.Enabled = False
                Activa()

            Else
                Activa()
                tb_Cliente.Enabled = False
                tb_Nit.Focus()
            End If

        Catch ex As Exception

        Finally
            otrans.close()
            otrans = Nothing
        End Try
    End Sub


    Private Sub Activa()
        tb_Nit.Enabled = True
        tb_RazonSocial.Enabled = True
        tb_Giro.Enabled = True
        cb_Tipo.Enabled = True
        cb_Grupo.Enabled = True
        tb_Sucursal.Enabled = True
        cb_Vigencia.Enabled = False
        cb_Vendedor.Enabled = True
        cb_Condicion.Enabled = True
        cb_ListaPrecio.Enabled = True
        tb_Contacto.Enabled = True
        cb_Ruta.Enabled = True
        tb_Comentario.Enabled = True
        tb_Direccion.Enabled = True
        cb_Region.Enabled = True
        cb_Estado.Enabled = True
        cb_Comuna.Enabled = True
        tb_Telefono.Enabled = True
    End Sub

    Private Sub tb_Nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Nit.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                tb_RazonSocial.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tb_RazonSocial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_RazonSocial.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Sucursal.Text = tb_RazonSocial.Text
            tb_Giro.Focus()
        End If
    End Sub

    Private Sub tb_Giro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Giro.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Contacto.Focus()
        End If
    End Sub

    Private Sub tb_Contacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Contacto.KeyPress
        If e.KeyChar = Chr(13) Then
            tb_Direccion.Focus()
        End If
    End Sub

    Private Sub tb_Direccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Direccion.KeyPress
        If e.KeyChar = Chr(13) Then
            btn_Grabar.Focus()
        End If
    End Sub


    Private Sub btn_Abrir_Click(sender As Object, e As EventArgs) Handles btn_Abrir.Click
        'Dim frm_abre As New Frm_Abre_Facturas
        'frm_abre.Show()
    End Sub


End Class