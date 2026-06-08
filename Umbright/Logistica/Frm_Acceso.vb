'Imports ThoughtWorks.QRCode
'Imports ThoughtWorks.QRCode.Codec
'Imports ThoughtWorks.QRCode.Codec.Data
Imports System.Windows.Forms.Application
Imports GemBox.Spreadsheet
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq

Public Class Frm_Acceso
    Dim Tipo As String = ""
    Dim Origen As String = ""
    Dim Accion As String = ""
    Dim Dui As Boolean = False
    Dim Lic As Boolean = False

    'Private webcam As WebCam_Capture

    Private Sub llenarGrid()

        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try
            lsSQL = "pa_sel_um_log_visitas '" & Me.dtpInicio.Value.ToShortDateString & "','" & Me.dtpFinal.Value.ToShortDateString & "'"

            dt = clsGen.selectQuery("SCM", lsSQL)
            Me.dgvListado.DataSource = dt

            clsGen.Alinear_GridView(dt, Me.dgvListado, "", " ", "", "", "", ",accion=75,gafete=45,", "", True, True, 250, 0)


        Catch ex As Exception
        Finally
            clsGen = Nothing

        End Try

    End Sub


    Private Sub Frm_Acceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tb_Datos.Visible = False
        'btn_Guardar.Enabled = False
        'btn_Salida.Enabled = False
        tb_Lectura.Focus()
        llenarGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        If Me.txtPlaca.Text.Length > 5 Then
            Accion = "ENTRADA"
            'Origen = InputBox("Nos Visita De: ", "Visitante")
            Origen = Me.txtPlaca.Text & ";" & Me.txtPersona.Text & ";" & Me.txtDepto.Text & ";" & Me.txtGafete.Text
            'Guardar()
            GuardaEntrada()
            'nuevo()
        Else
            MessageBox.Show("Debe Indicar de Donde Nos Visita", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtPlaca.Focus()
        End If
    End Sub

    Private Sub Datos()
        Dim numerodoc As String = ""
        Dim Cadena As String = ""
        Dim Str As String()

        'tb_Datos.Text = Mid(tb_Lectura.Text, 433, 212)
        tb_Datos.Text = Mid(tb_Lectura.Text, 1, 212)
        Cadena = tb_Datos.Text
        Str = Cadena.Split("|")
        If Not Str.Length > 1 Then
            Str = Cadena.Split("]")
        End If

        tb_NumeroDocto.Text = Val(Mid(Str(0).ToString, 1, 16)).ToString
        numerodoc = Mid(tb_NumeroDocto.Text, 1, 1) & "-" & Mid(tb_NumeroDocto.Text, 2, 10)
        tb_NumeroDocto.Text = numerodoc

        tb_Tipo.Text = Str(1).ToString
        tb_Nombres.Text = Str(2).ToString & " " & Str(3).ToString
        tb_Apellidos.Text = Str(4).ToString & " " & Str(5).ToString & " " & Str(6).ToString

        tb_NumeroLic.Text = Str(9).ToString
        tb_FechaVcto.Text = Str(8).ToString
        tb_Telefono.Text = Str(10).ToString
    End Sub

    Private Sub Dpi()
        Dim numerodoc As String = ""
        Dim Cadena As String = ""
        Dim Str As String()
        Dim Str2 As String

        Cadena = tb_Lectura.Text



        Try
            If Cadena.LastIndexOf("<") > 0 Then
                Str = Cadena.Split("<")
            Else
                Str = Cadena.Split(";")
            End If
        Catch ex As Exception

        End Try

        tb_NumeroDocto.Text = (Mid(Str(0).ToString, 6, 9)).ToString & (Mid(Str(0).ToString, 16, 4)).ToString
 
        Label10.Text = Str(5).ToString

        Str2 = Replace(Label10.Text, "0", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "1", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "2", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "3", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "4", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "5", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "6", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "7", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "8", "")
        Label10.Text = Str2
        Str2 = Replace(Label10.Text, "9", "")
        Label10.Text = Str2

        tb_Nombres.Text = Str(7).ToString
        tb_Apellidos.Text = Label10.Text
        
    End Sub

    Private Sub tb_Lectura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_Lectura.KeyPress
        If e.KeyChar = Chr(13) Then
            Label9.Text = tb_Lectura.Text.Length.ToString
            If Val(Label9.Text) > 200 Then
                Tipo = "LICENCIA"
                Datos()
            ElseIf Label9.Text = "90" Then
                Tipo = "DPI"
                Dpi()
            End If
            Label8.Text = Label8.Text & " " & Tipo
            'BuscaVisitas()
            Me.txtPlaca.Focus()
        End If
    End Sub

    Private Sub tb_Lectura_TextChanged(sender As Object, e As EventArgs) Handles tb_Lectura.TextChanged



    End Sub

    Private Sub nuevo()
        tb_Lectura.Text = ""
        tb_Datos.Text = ""
        tb_NumeroDocto.Text = ""
        tb_Tipo.Text = ""
        tb_Nombres.Text = ""
        tb_Apellidos.Text = ""
        tb_NumeroLic.Text = ""
        tb_FechaVcto.Text = ""
        tb_Telefono.Text = ""
        Origen = ""
        Label9.Text = "0"
        Label8.Text = "Tipo: "
        'btn_Guardar.Enabled = False
        'btn_Salida.Enabled = False
        tb_Lectura.Focus()
        Me.txtDepto.Text = String.Empty
        Me.txtOrigenVisita.Text = String.Empty
        Me.txtGafete.Text = String.Empty
        Me.txtPersona.Text = String.Empty
        Me.txtPlaca.Text = String.Empty

    End Sub

    Private Sub tb_Origen_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            btn_Guardar.Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label14.Text = DateTime.Now.ToString()
    End Sub

    Private Sub GuardaEntrada()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()

            lsSQL = "pa_vb_Control_Visitas '" & Tipo & "','" & Accion & "','" & tb_NumeroDocto.Text & "','" & tb_Tipo.Text & "','" & tb_Nombres.Text & "','" & tb_Apellidos.Text & "','" & _
            tb_NumeroLic.Text & "','" & tb_FechaVcto.Text & "','" & tb_Telefono.Text & "','" & Label14.Text & "','" & Me.txtOrigenVisita.Text & "','" & _
                Me.txtPlaca.Text & "','" & Me.txtPersona.Text & "','" & Me.txtDepto.Text & "','" & Me.txtGafete.Text & "','" &
                gs_usuario & "'"
            otrans.Ingresa(lsSQL)
            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Almacenado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.nuevo()
                llenarGrid()
            Else
                MessageBox.Show("Problemas al Guardar " & otrans.descripcion_error, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub


    Private Sub Guardar()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()

            lsSQL = "pa_vb_Control_Visitas '" & Tipo & "','" & Accion & "','" & tb_NumeroDocto.Text & "','" & tb_Tipo.Text & "','" & tb_Nombres.Text & "','" & tb_Apellidos.Text & "','" & _
            tb_NumeroLic.Text & "','" & tb_FechaVcto.Text & "','" & tb_Telefono.Text & "','" & Label14.Text & "','" & Origen & "','" & _
                Me.txtPlaca.Text & "','" & Me.txtPersona.Text & "','" & Me.txtDepto.Text & "','" & Me.txtGafete.Text & "'"

            otrans.Ingresa(lsSQL)
            If otrans.Codigo_error = 0 Then
                MessageBox.Show("Almacenado Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.nuevo()
                llenarGrid()
            Else
                MessageBox.Show("Problemas al Guardar " & otrans.descripcion_error, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub tb_Limpiar_Click(sender As Object, e As EventArgs) Handles tb_Limpiar.Click
        nuevo()
    End Sub

    Private Sub btn_Salida_Click(sender As Object, e As EventArgs) Handles btn_Salida.Click
        Try
            Origen = "SALIDA DE LAS INSTALACIONES"
            Accion = "SALIDA"
            Guardar()
            'nuevo()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BuscaVisitas()
        Dim otrans As New Transaccional.Conexion("SCM")
        Dim clsGen As New ClasesGenerales.General
        Dim lsSQL As String
        Dim dt As DataTable

        Try

            otrans.open()

            lsSQL = "pa_vb_Busca_Visitas '" & Trim(Tipo) & Trim(tb_NumeroDocto.Text) & Trim(tb_Nombres.Text) & Trim(tb_Apellidos.Text) & "'"
            dt = otrans.Obtiene(lsSQL)

            If dt.Rows.Count > 0 Then



                If dt.Rows(0)("Valor") > 0 Then
                    btn_Guardar.Enabled = False
                    btn_Salida.Enabled = True
                Else
                    btn_Guardar.Enabled = True
                    btn_Salida.Enabled = False
                End If
            Else
                btn_Guardar.Enabled = True
                btn_Salida.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            otrans.close()
            otrans = Nothing
            clsGen = Nothing
        End Try
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        llenarGrid()

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        Dim sfdVisitas As New SaveFileDialog()
        Dim gbReporteVisitas As New ExcelFile()
        Dim gbWorkSheet As ExcelWorksheet = gbReporteVisitas.Worksheets.Add("Visitas")

        Try

            sfdVisitas.Title = "Guardar reporte de visitas"
            sfdVisitas.Filter = "Archivo de Microsoft Excel|*xlsx"
            sfdVisitas.FileName = "reporte_visitas_" & DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")
            sfdVisitas.AddExtension = True

            gbWorkSheet.Cells("A1").Value = "Fecha"
            gbWorkSheet.Cells("B1").Value = "Accion"
            gbWorkSheet.Cells("C1").Value = "Departamento"
            gbWorkSheet.Cells("D1").Value = "Visita a"
            gbWorkSheet.Cells("E1").Value = "Origen"
            gbWorkSheet.Cells("F1").Value = "Licencia / DPI"
            gbWorkSheet.Cells("G1").Value = "Numero"
            gbWorkSheet.Cells("H1").Value = "Tipo licencia"
            gbWorkSheet.Cells("I1").Value = "Nombres"
            gbWorkSheet.Cells("J1").Value = "Apellidos"
            gbWorkSheet.Cells("K1").Value = "Gafete"

            Dim nFila As Integer = 1

            'Using dbScm As New SCMEntities()

            '    Dim lstVisitas =
            '       From log In dbScm.pa_sel_um_log_visitas(dtpInicio.Value.ToString("dd/MM/yyyy"), dtpFinal.Value.ToString("dd/MM/yyyy"))
            '       Select New rpt_log_visitas With {
            '           .fecha = log.fecha,
            '            .Accion = log.Accion,
            '            .Apellidos = log.Apellidos,
            '            .departamento_visita = log.departamento_visita,
            '           .gafete = log.gafete,
            '            .Nombres = log.Nombres,
            '            .NumeroDocto = log.NumeroDocto,
            '            .Origen = log.Origen,
            '            .persona_visita = log.persona_visita,
            '            .Tipo = log.Tipo,
            '            .TipoLicencia = log.TipoLicencia,
            '            .usuario_grabo = log.usuario_grabo}

            '    For Each visita As rpt_log_visitas In lstVisitas

            '        gbWorkSheet.Rows(nFila).Cells(0).Value = visita.fecha
            '        gbWorkSheet.Rows(nFila).Cells(1).Value = visita.Accion
            '        gbWorkSheet.Rows(nFila).Cells(2).Value = visita.departamento_visita
            '        gbWorkSheet.Rows(nFila).Cells(3).Value = visita.persona_visita
            '        gbWorkSheet.Rows(nFila).Cells(4).Value = visita.Origen
            '        gbWorkSheet.Rows(nFila).Cells(5).Value = visita.Tipo
            '        gbWorkSheet.Rows(nFila).Cells(6).Value = visita.NumeroDocto
            '        gbWorkSheet.Rows(nFila).Cells(7).Value = visita.TipoLicencia
            '        gbWorkSheet.Rows(nFila).Cells(8).Value = visita.Nombres
            '        gbWorkSheet.Rows(nFila).Cells(9).Value = visita.Apellidos
            '        gbWorkSheet.Rows(nFila).Cells(10).Value = visita.gafete

            '        nFila = nFila + 1

            '    Next

            '    nFila = 1

            '    Dim rTitulos As CellRange

            '    rTitulos = gbWorkSheet.Cells.GetSubrange("A1:K1")

            '    rTitulos.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center
            '    rTitulos.Style.Font.Weight = ExcelFont.BoldWeight
            '    rTitulos.Style.Font.Color = SpreadsheetColor.FromArgb(255, 255, 255)
            '    rTitulos.Style.FillPattern.SetSolid(SpreadsheetColor.FromArgb(28, 50, 77))

            '    For columna As Integer = 0 To 10

            '        gbWorkSheet.Columns(columna).AutoFit()

            '    Next

            '    If sfdVisitas.ShowDialog() = DialogResult.OK Then

            '        gbReporteVisitas.Save(sfdVisitas.FileName & ".xlsx")
            '        MessageBox.Show("Reporte guardado correctamente")

            '    End If

            'End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("4551-3345-5544-38546")
    End Sub

End Class