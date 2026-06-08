Imports System.Data.OleDb
Imports System.Configuration
Imports Microsoft.Office.Interop

Public Class frm_DTS

    Private Sub llenarComboDestino(psServidor)
        Dim clsGen As New ClasesGenerales.General
        'Dim Otrans As New Transaccional.Conexion("umbralDB")
        Dim dt As DataTable

        Dim lsSQL As String


        Try
            'Otrans.open()
            lsSQL = "pa_sel_um_gen_dts_tabla '" & psServidor & "','" & gs_usuario & "'"
            'dt = Otrans.Obtiene(lsSQL)
            dt = clsGen.selectQuery("dwh", lsSQL)
            Me.Grid_Tablas_destino.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.Grid_Tablas_destino, ",tabla,", "", ",tabla,", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            'Otrans.close()
            'Otrans = Nothing
            clsGen = Nothing

        End Try

    End Sub

    Private Sub llenarVistaDestino(psServidor As String, psTabla As String)
        Dim clsGen As New ClasesGenerales.General

        Dim dt As DataTable

        Dim lsSQL As String


        Try
            'Otrans.open()
            'lsSQL = "pa_sel_um_gen_dts_tabla '" & psServidor & "','" & gs_usuario & "'"
            lsSQL = "Select " & IIf(Me.ToolTop.Text = "Todos", " ", " top " & Me.ToolTop.Text) & " * from " & psTabla

            'dt = Otrans.Obtiene(lsSQL)
            dt = clsGen.selectQuery(psServidor, lsSQL)
            Me.Grid_Vista_Destino.DataSource = dt
            clsGen.Alinear_GridView(dt, Me.Grid_Vista_Destino, "", "", "", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            'Otrans.close()
            'Otrans = Nothing
            clsGen = Nothing

        End Try
    End Sub

    Private Sub frm_DTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTop.Text = "1000"

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CboOrigen.Text = "Excel" Then
            Dim oExcel As New OpenFileDialog
            oExcel.Filter = "Excel 97-2003 Files|*.xls|Excel 2007 Files|*.xlsx|Excel xlsb|*.xlsb|Excel xlsm|*.xlsm|All Files|*.*"

            If oExcel.ShowDialog = DialogResult.OK Then
                TextBox1.Text = oExcel.FileName
            End If


            MostrarDatExcel(TextBox1.Text)
            Grid_Tablas_Origen.DataSource = Nothing
            Exit Sub
        Else
            TextBox1.Text = "Base de Datos"
        End If
        'DBConnect.ModVariables.ConnectionString = CboOrigen.Text
        'Grid_Tablas_Origen.DataSource = DBConnect.SourceInfo.ObjetosServer()
    End Sub

    Private Function MostrarDatExcel(ByVal RUTA As String) As DataTable
        Dim WHERE As String = ""
        Grid_Tablas_Origen.DataSource = Nothing
        Dim hoja1 As Excel.Worksheet
        Try


            FrmWait.Show()
            Application.DoEvents()


            Dim cnn As New OleDb.OleDbConnection


            Dim XL As New Excel.Application 'Crea el objeto excel
            XL.Workbooks.Open(RUTA, , True) 'El true es para abrir el archivo en modo Solo lectura (False si lo quieres de otro modo)
            XL.Visible = False
            'XL.WindowState = xlMaximized 'Para que la ventana aparezca maximizada.
            cboHojas.Items.Clear()
            For Each hoja1 In XL.Sheets
                cboHojas.Items.Add(Convert.ToString(hoja1.Name) & "$")
                cboHojas.Text = Convert.ToString(hoja1.Name) & "$"
            Next
            XL.Workbooks.Close()

            If cboHojas.Text = "" Then
                MsgBox("Seleccione una hoja por favor")
                Exit Function
            End If

            Dim Dst As New DataSet
            Dim Coneccion As String = String.Empty
            Dim TABLE As DataTable
            Dim ru As New IO.FileInfo(RUTA)
            Select Case ru.Extension
                Case ".xls"
                    Coneccion = "Provider=Microsoft.Jet.Oledb.4.0; data source= " & RUTA & ";Extended properties=""Excel 8.0;hdr=yes;imex=1"""
                Case ".xlsx"
                    Coneccion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & RUTA & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"""
                Case ".xlsb"
                    Coneccion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & RUTA & ";Extended Properties=""Excel 12.0;HDR=YES"""
                Case ".xlsm"
                    Coneccion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & RUTA & ";Extended Properties=""Excel 12.0 Macro;HDR=YES"""
            End Select
            Dim Cn As New OleDbConnection(Coneccion)
            Dim rs As New DataTable


            Try
                Dst = New DataSet
                Dim Dap As New OleDbDataAdapter("Select * From [" & cboHojas.Text & "]" & IIf(WHERE = String.Empty, "", WHERE), Cn)
                Cn.Open()
                Dap.Fill(Dst)
                Dap.Dispose()
                Cn.Close()
                TABLE = Dst.Tables(0)
                Dst.Dispose()
                Grid_vista_Origen.DataSource = TABLE
                TABLE.Dispose()
                lblTotalColumnas1.Text = "Columnas : " & Grid_vista_Origen.ColumnCount
                lbltotalregistrosorigen.Text = "Total Filas: " & Grid_vista_Origen.Rows.Count
                FrmWait.Close()
            Catch ex As Exception
                Cn.Close()
                MessageBox.Show(ex.Message, "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TABLE = Nothing
            End Try
            Return TABLE
        Catch ex As Exception
            FrmWait.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CboDestino.Text = "Excel" Then
            Dim oExcel As New OpenFileDialog
            oExcel.Filter = "Excel 97-2003 Files|*.xls|Excel 2007 Files|*.xlsx|Excel xlsb|*.xlsb|Excel xlsm|*.xlsm|All Files|*.*"

            If oExcel.ShowDialog = DialogResult.OK Then
                TextBox2.Text = oExcel.FileName
            End If
            'MostrarDatExcel2(TextBox2.Text) 'Mostrar
            Grid_Tablas_destino.DataSource = Nothing
            Exit Sub
        Else
            TextBox2.Text = "Base de Datos"
        End If
        llenarComboDestino(CboDestino.Text)

        'DBConnect.ModVariables.ConnectionString = CboDestino.Text
        'Grid_Tablas_destino.DataSource = DBConnect.SourceInfo.ObjetosServer()
    End Sub

    Private Sub Grid_Tablas_destino_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid_Tablas_destino.CellContentClick

    End Sub

    Private Sub Grid_Tablas_destino_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid_Tablas_destino.CellDoubleClick
        If MessageBox.Show("Desea Cargar Vista Previa", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then

            'If MsgBox("Cargar vista previa ", vbYesNo, "Confirmacion") = MsgBoxResult.No Then
            Exit Sub
        End If

        FrmWait.Show()
        If Grid_Tablas_destino.RowCount = 0 Then Exit Sub
        llenarVistaDestino(Me.CboDestino.Text, Grid_Tablas_destino.Item("tabla", Grid_Tablas_destino.CurrentCell.RowIndex).Value)
        'Grid_Vista_Destino.DataSource = DBConnect.SourceInfo._DataTable(CboDestino.Text, Grid_Tablas_destino.Item(0, Grid_Tablas_destino.CurrentCell.RowIndex).Value, ToolTop.Text)
        LblTotalColumnas2.Text = "Columnas : " & Grid_Vista_Destino.ColumnCount
        lbltotalregistrosdestino.Text = "Total Filas: " & Grid_Vista_Destino.Rows.Count
        FrmWait.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If CboOrigen.Text = "Excel" Then
            If Grid_vista_Origen.RowCount = 0 Then
                MsgBox("No existen datos en el origen", vbInformation)
            End If
        End If


        'MsgBox(DBConnect.GeneraScript.Insert(Grid_Tablas_destino.Item(0, Grid_Tablas_destino.CurrentCell.RowIndex).Value, CboDestino.Text, Grid_Vista_Destino.DataSource))
        'Dim dbConnect As New DBConnect.GeneraScript
        If Me.lblTotalColumnas1.Text <> Me.LblTotalColumnas2.Text Then
            MessageBox.Show("El Total de Columnas No Coindice", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            prepara_insert_dts(Grid_Tablas_destino.Item("tabla", Grid_Tablas_destino.CurrentCell.RowIndex).Value, CboDestino.Text, Grid_vista_Origen.DataSource)
        End If


    End Sub


End Class