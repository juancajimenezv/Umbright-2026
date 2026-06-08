Public Class frm_nuevoMenu


    Private Sub crearMenu()
        Dim oTrans As New Transaccional.Conexion("FlexLine")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt, dt2 As DataTable

        Try
            otrans.open()
            lsSQL = "pa_sel_um_sg_usuario_menu_opcion NULL,'ccofino'"
            dt = oTrans.Obtiene(lsSQL)
            dt2 = clsGen.ValoresDistinto(dt, "menu".Split(","))



            For Each mni As ToolStripMenuItem In Me.menu_principal.Items
                mni.Visible = False
            Next


            ''Habilo los menus necesarios
            For Each mni As ToolStripMenuItem In Me.menu_principal.Items
                dt2.DefaultView.RowFilter = "menu = '" & mni.Name.ToString.Split("_")(1) & "'"
                If dt2.DefaultView.Count > 0 Then
                    mni.Visible = True
                End If
            Next



        Catch ex As Exception

        Finally
            oTrans.close()
            oTrans = Nothing


        End Try

    End Sub



    Private Sub frm_nuevoMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crearMenu()
    End Sub
End Class