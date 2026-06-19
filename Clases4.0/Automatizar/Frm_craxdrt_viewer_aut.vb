
Public Class frm_craxdrt_viewer_aut
    Inherits System.Windows.Forms.Form
    'Public CrRpV As CRAXDRT.Report
    Public Acciones As String = "XPE"
    Public Tipo_Exportar As String = "*"
    Friend WithEvents AxCRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Public descripcion_error As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents menu_principal As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents impresoras As System.Windows.Forms.MenuItem

    'Friend WithEvents AxCRViewer1 As AxCRVIEWERLib.AxCRViewer


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.menu_principal = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.impresoras = New System.Windows.Forms.MenuItem()
        Me.AxCRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'menu_principal
        '
        Me.menu_principal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.impresoras})
        Me.MenuItem1.Text = "Archivo"
        '
        'impresoras
        '
        Me.impresoras.Index = 0
        Me.impresoras.Text = "Configurar Impresora"
        '
        'AxCRV
        '
        Me.AxCRV.ActiveViewIndex = -1
        Me.AxCRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AxCRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.AxCRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxCRV.Location = New System.Drawing.Point(0, 0)
        Me.AxCRV.Name = "AxCRV"
        Me.AxCRV.Size = New System.Drawing.Size(944, 693)
        Me.AxCRV.TabIndex = 0
        '
        'frm_craxdrt_viewer_aut
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(944, 693)
        Me.Controls.Add(Me.AxCRV)
        Me.Menu = Me.menu_principal
        Me.Name = "frm_craxdrt_viewer_aut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vista Preliminar"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub impresoras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles impresoras.Click
        'CrRpV.PrinterSetup(0)
        '' ''Me.AxCRV.RefreshEx(False)
        'Me.AxCRV.ResumeLayout()
        'Me.AxCRV.ReportSource = CrRpV


    End Sub

    Private Sub frm_craxdrt_viewer_aut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            'Me.AxCRV.ReportSource = CrRpV

            Me.AxCRV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            'Me.AxCRV.ViewReport()



            If Tipo_Exportar.LastIndexOf("*") >= 0 Then
                'And acciones.LastIndexOf("E") >= 0 Then
                'Me.AxCRV.EnableExportButton = True
                Me.AxCRV.ShowExportButton = True
            Else
                'Me.AxCRV.EnableExportButton = False
            End If
            ''Permisos para Imprimir
            If Acciones.LastIndexOf("P") >= 0 Then

                'Me.AxCRV.EnablePrintButton = True
            Else
                ''oaut.CrRpV()
                'Me.AxCRV.EnablePrintButton = False
            End If
        Catch ex As Exception
            descripcion_error = ex.Message
        End Try

    End Sub

    Private Sub frm_craxdrt_viewer_aut_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'CrRpV = Nothing
    End Sub
End Class
