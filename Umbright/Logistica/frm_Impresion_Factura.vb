Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frm_Impresion_Factura
    Dim clsGen As New ClasesGenerales.General
    Dim Reporte As New ReportDocument
    Dim Params As New ParameterValues
    Dim Par, Par1, Par2 As New ParameterDiscreteValue
    Public Emp, TipDoc, Num, Salida As String
    'Public FechaI, FechaF As Date
    Private Predetarminada As New Printing.PrinterSettings
    Dim ImpresoraActual As String = Predetarminada.PrinterName
    Dim SqlUser As String = "flexline"
    Dim path As String = clsGen.Path_Reporte


    Private Sub frm_Impresion_Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Impresion()
    End Sub

    Private Sub Impresion()
        Try
            Reporte.Load(path & "Finanzas\Facturacion\Impresion De Recibos Antigua.rpt")

            ' MsgBox(path)
            Reporte.SetDatabaseLogon(SqlUser, SqlUser)
            '   toma el formato del reporte desde crystal
            Reporte.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto
            '   imprime dos copias
            '   Reporte.PrintToPrinter(2, False, 1, 1)

            Params.Clear()
            Par.Value = Emp
            Params.Add(Par)
            Reporte.DataDefinition.ParameterFields("Empresa").ApplyCurrentValues(Params)

            Params.Clear()
            Par1.Value = TipDoc
            Params.Add(Par1)
            Reporte.DataDefinition.ParameterFields("TipoDocto").ApplyCurrentValues(Params)

            Par2.Value = Num
            Params.Add(Par2)
            Reporte.DataDefinition.ParameterFields("Numero").ApplyCurrentValues(Params)

            crv_Impresion.ReportSource = Me.Reporte

            If Salida = "Impresora" Then

                Reporte.PrintOptions.PrinterName = clsGen.Obtener_XMLConfig("impresora_recibos", False)

                'Reporte.PrintOptions.PrinterName = "Star TSP100 Cutter (TSP143) (Copy 1)" 'ImpresoraActual '"HP Deskjet 2050 J510 series" ' "PrinterSettings HP Deskjet 2050 J510 series Copies=1 Collate=True Duplex=Simplex FromPage=0 LandscapeAngle=270 MaximumCopies=9999 OutputPort= ToPage=0"
                Reporte.PrintToPrinter(2, False, 0, 0)
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

End Class