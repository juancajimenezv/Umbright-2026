Public Class frm_ruta_logisitca
    Private ps_ctacte As String
    Dim ods As New DataSet


    Public WriteOnly Property ctacteDirecciones() As String

        Set(ByVal Value As String)
            ps_ctacte = Value
        End Set
    End Property

    Private Sub crear_estructura()
        Dim ClsGen As New ClasesGenerales.General
        Dim dt1 As DataTable

        dt1 = New DataTable("direcciones")
        ods = New DataSet
        dt1.Columns.Add(New DataColumn("Direccion", GetType(String)))
        dt1.Columns.Add(New DataColumn("Ruta Logistica", GetType(String)))
        dt1.Columns.Add(New DataColumn("Telefono", GetType(String)))
        dt1.Columns.Add(New DataColumn("Fax", GetType(String)))
        '  dt1.Columns.Add(New DataColumn("Fecha", GetType(String)))
        ' dt1.Columns.Add(New DataColumn("Usuario", GetType(String)))
        ods.Tables.Add(dt1)
        Me.dgv_direcciones.DataSource = ods.Tables("direcciones")

    End Sub

    Private Sub llenar_informacion()
        Dim clsgen As New ClasesGenerales.General
        Dim ls_sql As String
        Dim dt As DataTable
        Dim dr, dr_aux As DataRow
        Dim oTrans As New Transaccional.Conexion("Flexline")

        ods.Tables("direcciones").Rows.Clear()

        Try
            oTrans.open()


            ls_sql = "pa_sel_um_ctactedirecciones   '" & gs_empresa & "','CLIENTE','" & ps_ctacte & "'"
            dt = oTrans.Obtiene(ls_sql)
            'Me.dgv_fechas.DataSource = dt


            For Each dr In dt.Rows

                dr_aux = ods.Tables("direcciones").NewRow
                If dr.Item("principal").ToString <> "S" Then
                    dr_aux.Item("Direccion") = dr.Item("direccion")
                    dr_aux.Item("Ruta Logistica") = dr.Item("Email")
                    dr_aux.Item("Telefono") = dr.Item("telefono")
                    dr_aux.Item("Fax") = dr.Item("fax")
                    'dr_aux.Item("Lo tiene") = 0
                    ods.Tables("direcciones").Rows.Add(dr_aux)
                End If

            Next


            clsgen.Alinear_GridView(ods.Tables("direcciones"), Me.dgv_direcciones, ",Direccion,Ruta Logistica,", ",Telefono,Fax,", ",Direccion,", "", "", ",Direccion=420,Ruta Logistica=200,", "", True, True, 200, 0)


        Catch ex As Exception
        Finally
            oTrans.close()
            oTrans = Nothing
        End Try
    End Sub

    Private Sub Guardar_informacion()

        Dim ls_sql As String
        Dim dt As DataTable

        Dim oTrans As New Transaccional.Conexion("Flexline")

        Dim dr As DataRow
       
        Try
            oTrans.open()

            For Each dr In ods.Tables("direcciones").Rows
                ls_sql = "pa_upd_um_ctacteRutaLogistica '" & gs_empresa & "','" & ps_ctacte & "','" & dr.Item("Ruta Logistica").ToString & " ','" & dr.Item("Telefono").ToString & "','" & dr.Item("Fax").ToString & "'"
                oTrans.Actualiza(ls_sql)

            Next
           
            MessageBox.Show("Proceso Realizado con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Me.txt_comentario.Text = ""


        Catch ex As Exception
        Finally

            oTrans.close()
            oTrans = Nothing
        End Try

    End Sub
    Private Sub frm_ruta_logisitca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crear_estructura()

        llenar_informacion()

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Guardar_Informacion()

    End Sub
End Class