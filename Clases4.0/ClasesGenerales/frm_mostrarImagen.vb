
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Diagnostics
Imports System.Drawing.Printing

Public Class frm_mostrarImagen
    Public psimagen As String

    Private Sub frm_mostrarImagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            pbImagen.Image = Image.FromFile(psimagen)
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage

            VScrollBar1.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click

        Try
            Clipboard.SetDataObject(pbImagen.Image, True)
            Dim objClipboard As IDataObject = Clipboard.GetDataObject()
            'devuelve el portapapeles como mapa de bits
            objClipboard.GetData(DataFormats.Bitmap)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Function PreparePrintDocument() As PrintDocument
        ' Make the PrintDocument object.
        Dim print_document As New PrintDocument

        ' Install the PrintPage event handler.
        AddHandler print_document.PrintPage, AddressOf _
            printDoc_PrintPage

        ' Return the object.
        Return print_document
    End Function


    ' Print the next page.
    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e _
        As System.Drawing.Printing.PrintPageEventArgs)
        ' Draw a rectangle at the margins.
        e.Graphics.DrawRectangle(Pens.Black, e.MarginBounds)

        ' Draw a thick, dashed ellipse.
        Dim dotted_pen As New Pen(Color.Black, 5)
        dotted_pen.DashStyle = Drawing2D.DashStyle.Dash
        e.Graphics.DrawEllipse(dotted_pen, e.MarginBounds)
        dotted_pen.Dispose()

        ' Draw a thick diamond.
        Dim x0 As Integer = e.MarginBounds.X
        Dim y0 As Integer = e.MarginBounds.Y
        Dim wid As Integer = e.MarginBounds.Width
        Dim hgt As Integer = e.MarginBounds.Height
        Dim pts() As Point = { _
            New Point(x0, y0 + hgt \ 2), _
            New Point(x0 + wid \ 2, y0), _
            New Point(x0 + wid, y0 + hgt \ 2), _
            New Point(x0 + wid \ 2, y0 + hgt) _
        }
        e.Graphics.DrawPolygon(New Pen(Color.Black, 5), pts)

        ' There are no more pages.
        e.HasMorePages = False
    End Sub

    Private Sub printDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        Try

            Dim x0 As Integer = e.MarginBounds.X
            Dim y0 As Integer = e.MarginBounds.Y
            Dim wid As Integer = e.MarginBounds.Width
            Dim hgt As Integer = e.MarginBounds.Height
            Dim pts() As Point = { _
                New Point(x0, y0 + hgt \ 2), _
                New Point(x0 + wid \ 2, y0), _
                New Point(x0 + wid, y0 + hgt \ 2), _
                New Point(x0 + wid \ 2, y0 + hgt) _
            }
            Dim g As Graphics = e.Graphics
            g.DrawImage(Image.FromFile(psimagen), 0, 0)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ImprimirVistaPreviaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirVistaPreviaToolStripMenuItem.Click

        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    'showDialog method makes the dialog box visible at run time
        printDoc.Print()
        'End If
        'Try

        '    dlgPrintPreview.Document = PreparePrintDocument()

        '    ' Preview.
        '    dlgPrintPreview.WindowState = FormWindowState.Maximized
        '    dlgPrintPreview.ShowDialog()
        'Catch ex As Exception

        'End Try
    End Sub

End Class