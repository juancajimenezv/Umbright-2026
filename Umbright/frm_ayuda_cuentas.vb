Public Class frm_ayuda_cuentas
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_cuentas As System.Windows.Forms.DataGrid
    Friend WithEvents txt_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_cuenta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dg_cuentas = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_cuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txt_descripcion)
        Me.GroupBox1.Controls.Add(Me.txt_cuenta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Location = New System.Drawing.Point(112, 32)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(248, 22)
        Me.txt_descripcion.TabIndex = 2
        '
        'txt_cuenta
        '
        Me.txt_cuenta.Location = New System.Drawing.Point(20, 32)
        Me.txt_cuenta.Name = "txt_cuenta"
        Me.txt_cuenta.Size = New System.Drawing.Size(92, 22)
        Me.txt_cuenta.TabIndex = 4
        Me.txt_cuenta.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(112, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(248, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cuenta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dg_cuentas)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 376)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'dg_cuentas
        '
        Me.dg_cuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_cuentas.CaptionText = "Cuentas Contables"
        Me.dg_cuentas.DataMember = ""
        Me.dg_cuentas.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_cuentas.Location = New System.Drawing.Point(8, 16)
        Me.dg_cuentas.Name = "dg_cuentas"
        Me.dg_cuentas.ReadOnly = True
        Me.dg_cuentas.Size = New System.Drawing.Size(376, 352)
        Me.dg_cuentas.TabIndex = 6
        '
        'frm_ayuda_cuentas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(408, 472)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ayuda_cuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "::. Cuentas .::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dg_cuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim mRow As DataRow
    Dim ds_cuentas_i As New DataSet

    Public Function muestraDatos(ByVal ds_cuentas As DataSet) As DataRow
        dg_cuentas.DataSource = ds_cuentas.Tables("cta_contables")
        ds_cuentas_i = ds_cuentas.Copy

        Dim ClsGen As New ClasesGenerales.General
        ClsGen.Alinea_Grid(ds_cuentas.Tables("cta_contables"), dg_cuentas, ds_cuentas.Tables("cta_contables").TableName, -1, 250, 50, False, False, "cuenta, descripcion", False, "cuenta, Descripcion")
        ClsGen = Nothing

        If Me.ShowDialog = DialogResult.OK Then
            Return mRow
        Else
            Return Nothing
        End If
    End Function

    Private Sub dg_cuentas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_cuentas.DoubleClick
        Dim mSelectRow As DataRow = ds_cuentas_i.Tables("cta_contables").NewRow

        mSelectRow("cuenta") = dg_cuentas.Item(dg_cuentas.CurrentRowIndex, 0)
        mSelectRow("descripcion") = dg_cuentas.Item(dg_cuentas.CurrentRowIndex, 1)

        mRow = mSelectRow

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub txt_cuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cuenta.TextChanged
        If txt_cuenta.Text.Trim.Length <= 0 Then Exit Sub

        Dim mRowB() As DataRow = ds_cuentas_i.Tables("cta_contables").Select("cuenta like '" & txt_cuenta.Text & "%'")

        Dim dsInfo As New DataSet
        Dim dt As New DataTable("cta_contables")

        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dsInfo.Tables.Add(dt)

        For ii As Integer = 0 To mRowB.Length - 1
            Dim mNewRow As DataRow = dsInfo.Tables("cta_contables").NewRow

            mNewRow("cuenta") = mRowB(ii)("cuenta")
            mNewRow("descripcion") = mRowB(ii)("descripcion")

            dsInfo.Tables("cta_contables").Rows.Add(mNewRow)
        Next

        dg_cuentas.DataSource = dsInfo.Tables("cta_contables")
        Dim ClsGen As New ClasesGenerales.General
        ClsGen.Alinea_Grid(dsInfo.Tables("cta_contables"), dg_cuentas, dsInfo.Tables("cta_contables").TableName, -1, 250, 50, False, False, "cuenta, descripcion", False, "cuenta, Descripcion")
        ClsGen = Nothing

    End Sub

    Private Sub txt_descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descripcion.TextChanged
        If txt_descripcion.Text.Trim.Length <= 0 Then Exit Sub

        Dim mRowB() As DataRow = ds_cuentas_i.Tables("cta_contables").Select("descripcion like '" & txt_descripcion.Text & "%'")

        Dim dsInfo As New DataSet
        Dim dt As New DataTable("cta_contables")

        dt.Columns.Add(New DataColumn("CUENTA", GetType(String)))
        dt.Columns.Add(New DataColumn("DESCRIPCION", GetType(String)))
        dsInfo.Tables.Add(dt)

        For ii As Integer = 0 To mRowB.Length - 1
            Dim mNewRow As DataRow = dsInfo.Tables("cta_contables").NewRow

            mNewRow("cuenta") = mRowB(ii)("cuenta")
            mNewRow("descripcion") = mRowB(ii)("descripcion")

            dsInfo.Tables("cta_contables").Rows.Add(mNewRow)
        Next

        dg_cuentas.DataSource = dsInfo.Tables("cta_contables")
        Dim ClsGen As New ClasesGenerales.General
        ClsGen.Alinea_Grid(dsInfo.Tables("cta_contables"), dg_cuentas, dsInfo.Tables("cta_contables").TableName, -1, 250, 50, False, False, "cuenta, descripcion", False, "cuenta, Descripcion")
        ClsGen = Nothing
    End Sub

    Private Sub frm_ayuda_cuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_descripcion.Focus()
    End Sub

    Private Sub dg_cuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg_cuentas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim mSelectRow As DataRow = ds_cuentas_i.Tables("cta_contables").NewRow

            mSelectRow("cuenta") = dg_cuentas.Item(dg_cuentas.CurrentRowIndex, 0)
            mSelectRow("descripcion") = dg_cuentas.Item(dg_cuentas.CurrentRowIndex, 1)

            mRow = mSelectRow

            Me.DialogResult = DialogResult.OK
        End If

    End Sub

End Class
