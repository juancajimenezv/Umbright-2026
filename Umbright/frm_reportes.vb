'Imports CrystalDecisions.CrystalReports
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
'Imports CrystalDecisions.Windows
Imports System.Drawing.Printing
Imports System

Public Class frm_reportes
    Inherits System.Windows.Forms.Form
    Dim Crep As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim oDataSet As New DataSet
    Dim pm_parametros(301, 700) As String
    Dim oPanel As New Panel
    Dim _ServerName, _DataBaseName, _UsrID As String
    Dim is_check_manual As Boolean = True

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
    Friend WithEvents cmb_reporte As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_reporte As System.Windows.Forms.Label
    Friend WithEvents btn_procesar As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btn_Exportar As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reportes))
        Me.cmb_reporte = New System.Windows.Forms.ComboBox()
        Me.lbl_reporte = New System.Windows.Forms.Label()
        Me.btn_procesar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.btn_Exportar = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmb_reporte
        '
        Me.cmb_reporte.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmb_reporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_reporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_reporte.ForeColor = System.Drawing.Color.DarkRed
        Me.cmb_reporte.Location = New System.Drawing.Point(130, 5)
        Me.cmb_reporte.Name = "cmb_reporte"
        Me.cmb_reporte.Size = New System.Drawing.Size(437, 24)
        Me.cmb_reporte.TabIndex = 4
        '
        'lbl_reporte
        '
        Me.lbl_reporte.AutoSize = True
        Me.lbl_reporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_reporte.Location = New System.Drawing.Point(12, 8)
        Me.lbl_reporte.Name = "lbl_reporte"
        Me.lbl_reporte.Size = New System.Drawing.Size(112, 16)
        Me.lbl_reporte.TabIndex = 5
        Me.lbl_reporte.Text = "Nombre  Reporte"
        '
        'btn_procesar
        '
        Me.btn_procesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_procesar.Enabled = False
        Me.btn_procesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_procesar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_procesar.ForeColor = System.Drawing.Color.White
        Me.btn_procesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_procesar.ImageIndex = 3
        Me.btn_procesar.ImageList = Me.ImageList1
        Me.btn_procesar.Location = New System.Drawing.Point(596, 5)
        Me.btn_procesar.Name = "btn_procesar"
        Me.btn_procesar.Size = New System.Drawing.Size(83, 68)
        Me.btn_procesar.TabIndex = 6
        Me.btn_procesar.Text = "&Generar"
        Me.btn_procesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_procesar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "clear.png")
        Me.ImageList1.Images.SetKeyName(1, "revert-to-saved-ltr.png")
        Me.ImageList1.Images.SetKeyName(2, "print_48.png")
        Me.ImageList1.Images.SetKeyName(3, "running_process.png")
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_limpiar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.ImageIndex = 0
        Me.btn_limpiar.ImageList = Me.ImageList1
        Me.btn_limpiar.Location = New System.Drawing.Point(596, 233)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(83, 68)
        Me.btn_limpiar.TabIndex = 8
        Me.btn_limpiar.Text = "&Limpiar"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_Exportar
        '
        Me.btn_Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Exportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_Exportar.Enabled = False
        Me.btn_Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Exportar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Exportar.ForeColor = System.Drawing.Color.White
        Me.btn_Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Exportar.ImageIndex = 1
        Me.btn_Exportar.ImageList = Me.ImageList1
        Me.btn_Exportar.Location = New System.Drawing.Point(596, 81)
        Me.btn_Exportar.Name = "btn_Exportar"
        Me.btn_Exportar.Size = New System.Drawing.Size(83, 68)
        Me.btn_Exportar.TabIndex = 9
        Me.btn_Exportar.Text = "&Exportar"
        Me.btn_Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Exportar.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btn_imprimir.Enabled = False
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.White
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.ImageIndex = 2
        Me.btn_imprimir.ImageList = Me.ImageList1
        Me.btn_imprimir.Location = New System.Drawing.Point(596, 157)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(83, 68)
        Me.btn_imprimir.TabIndex = 10
        Me.btn_imprimir.Text = "&Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'frm_reportes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(691, 416)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.btn_Exportar)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.lbl_reporte)
        Me.Controls.Add(Me.cmb_reporte)
        Me.Controls.Add(Me.btn_procesar)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generador de Reportes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Procedimiento_btn(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For ii As Integer = 0 To oPanel.Controls.Count - 1
            If oPanel.Controls(ii).Name.ToLower = sender.Name.ToString.ToLower Then
                If sender.text.ToString.ToLower.IndexOf("desmarcar") = -1 Then
                    buscar_checkList(sender.Tag.ToString, True)
                Else
                    buscar_checkList(sender.Tag.ToString, False)
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub setCheckItem(ByVal checkBox As CheckedListBox, ByVal check As Boolean)
        is_check_manual = False
        Dim cuenta As Integer

        For jj As Integer = 0 To 300 'checkBox.Items.Count - 1
            If pm_parametros(jj, 0) = checkBox.Name Then
                cuenta = jj
                Exit For
            End If
        Next

        For ii As Integer = 0 To checkBox.Items.Count - 1
            checkBox.SetItemChecked(ii, check)

            checkBox.SelectedIndex = ii

            If check Then
                pm_parametros(cuenta, ii + 1) = checkBox.SelectedValue
            Else
                pm_parametros(cuenta, ii + 1) = ""
            End If
        Next
        is_check_manual = True
    End Sub

    Private Sub buscar_checkList(ByVal nombre As String, ByVal checked As Boolean)
        For ii As Integer = 0 To oPanel.Controls.Count - 1
            If oPanel.Controls(ii).Name.ToLower = nombre.ToLower Then
                setCheckItem(oPanel.Controls(ii), checked)
                Exit For
            End If
        Next
    End Sub

    Public Sub generar_parametros(ByVal ps_nombre_reporte As String)
        Dim intcounter As Integer
        Dim i_count, iaux As Integer
        Dim posiciony As Integer = 0
        Dim aumentary As Integer = -20
        Dim extray As Integer = 0
        Dim lbaumentary As Boolean

        Dim path_reporte As String
        Dim ls_nombre_campo As String
        Dim ls_txtsql As String

        Dim oTxtBox As TextBox
        Dim oComboBox As ComboBox
        Dim oDateTimePicker As DateTimePicker
        Dim oCheckedListBox As CheckedListBox
        Dim oDataGrid As DataGrid
        Dim oLabel As Label
        Dim oBtn As Button

        Dim las_valores(10) As String

        Crep = New CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim paraValue As New CrystalDecisions.Shared.ParameterDiscreteValue

        Dim rVal As New ParameterRangeValue

        Dim oTrans As Transaccional.Conexion
        Dim oTabla As New DataTable

        oDataSet.Tables("reportes").DefaultView.RowFilter = "nombre_reporte = '" & ps_nombre_reporte & "'"
        path_reporte = oDataSet.Tables("reportes").DefaultView(0)("path_reporte")

        For icount As Integer = 0 To 300
            pm_parametros(icount, 0) = String.Empty
        Next
        ''Agrego el panel en el que estaran los controles
        oPanel.Location = New Point(20, 30)
        oPanel.Size = New Size(550, 375)
        oPanel.BorderStyle = BorderStyle.Fixed3D
        oPanel.AutoScroll = True
        oPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Controls.Add(oPanel)

        Try
            ''Cargo el Reporte
            Crep.Load(path_reporte)

            If Crep.DataDefinition.ParameterFields.Count = 0 Then
                Return
            End If

            For intcounter = 0 To Crep.DataDefinition.ParameterFields.Count - 1
                ''Si es reporte que requiere valores
                'Actualizacion 28/07/2014
                If Crep.DataDefinition.ParameterFields(intcounter).HasCurrentValue = True Then
                    ''Si el Nombre del parametro es empresa no se muestra, por que se carga 
                    ''de la empresa en uso del sistema
                    If Crep.DataDefinition.ParameterFields(intcounter).ParameterFieldName().ToUpper.IndexOf("MPRESA") < 0 _
                        And Crep.DataDefinition.ParameterFields(intcounter).ParameterFieldName().ToUpper.IndexOf("USER_NAME") < 0 Then

                        posiciony = posiciony + 1
                        pm_parametros(intcounter, 0) = "txt_parametros_" & intcounter.ToString.Trim

                        If Crep.DataDefinition.ParameterFields(intcounter).ParameterValueKind = ParameterValueKind.NumberParameter Or _
                            Crep.DataDefinition.ParameterFields(intcounter).ParameterValueKind = ParameterValueKind.StringParameter Then

                            ''Permite Multipes Valores
                            If Crep.DataDefinition.ParameterFields(intcounter).EnableAllowMultipleValue = True Then

                                ''Si el Nombre del parametro si empieza con "_" significa que debo llenarlo con
                                ''campos de la tabla gen_tabcod
                                ls_nombre_campo = Crep.DataDefinition.ParameterFields(intcounter).Name
                                iaux = Crep.DataDefinition.ParameterFields(intcounter).DefaultValues.Count
                                If iaux > 0 Or ls_nombre_campo.StartsWith("_") Or ls_nombre_campo.StartsWith("@_") Then
                                    If ls_nombre_campo.StartsWith("_") Or ls_nombre_campo.StartsWith("@_") Then
                                        oTrans = New Transaccional.Conexion("flexline")
                                        oTrans.open()
                                        ls_txtsql = "pa_sel_um_gen_tabcod NULL,'" & _
                                            ls_nombre_campo.Substring(IIf(ls_nombre_campo.StartsWith("@"), 2, 1)).Trim & _
                                            "','" & gs_empresa & "'"
                                        oTabla = oTrans.Obtiene(ls_txtsql)
                                        If oTrans.Codigo_error > 0 Then
                                            MessageBox.Show(oTrans.descripcion_error)
                                        End If
                                        oTrans.close()
                                        iaux = oTabla.Rows.Count
                                        ReDim las_valores(iaux - 1)
                                        For i_count = 0 To iaux - 1
                                            las_valores(i_count) = oTabla.Rows(i_count)("codigo")
                                            pm_parametros(intcounter, i_count + 1) = " "
                                        Next
                                    Else
                                        'ReDim las_valores(iaux - 1)
                                        ReDim las_valores(iaux - 1)
                                        'For i_count = 0 To iaux-1
                                        For i_count = 0 To iaux - 1
                                            'Dim paraValue As New CrystalDecisions.Shared.ParameterDiscreteValue
                                            'paraValue = New CrystalDecisions.Shared.ParameterValues
                                            paraValue = Crep.DataDefinition.ParameterFields(intcounter).DefaultValues(i_count)
                                            las_valores(i_count) = paraValue.Value()
                                            pm_parametros(intcounter, i_count + 1) = " "
                                        Next
                                    End If

                                    oCheckedListBox = New CheckedListBox
                                    oCheckedListBox.DataSource = las_valores
                                    oCheckedListBox.Name = "txt_parametros_" & intcounter.ToString.Trim
                                    oCheckedListBox.Location = New System.Drawing.Point(100, (25 * posiciony) + aumentary)
                                    oCheckedListBox.Size = New System.Drawing.Size(240, 80)
                                    oCheckedListBox.CheckOnClick = True
                                    oCheckedListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                    oCheckedListBox.BorderStyle = BorderStyle.FixedSingle
                                    AddHandler oCheckedListBox.ItemCheck, AddressOf Procedimiento_lcb

                                    oPanel.Controls.Add(oCheckedListBox)
                                    oCheckedListBox = Nothing
                                    lbaumentary = True

                                    Dim y As Integer = (25 * posiciony) + aumentary

                                    oBtn = New Button
                                    oBtn.Name = "btn_parametros_" & intcounter.ToString.Trim
                                    oBtn.Tag = "txt_parametros_" & intcounter.ToString.Trim
                                    oBtn.Text = "&Marcar Todos"
                                    oBtn.FlatStyle = FlatStyle.Flat
                                    oBtn.Location = New System.Drawing.Point(350, y + 6)
                                    oBtn.Size = New System.Drawing.Size(120, 24)
                                    AddHandler oBtn.Click, AddressOf Procedimiento_btn

                                    oPanel.Controls.Add(oBtn)
                                    oBtn = Nothing

                                    oBtn = New Button
                                    oBtn.Name = "btn_parametros_" & intcounter.ToString.Trim
                                    oBtn.Tag = "txt_parametros_" & intcounter.ToString.Trim
                                    oBtn.Text = "&Desmarcar Todos"
                                    oBtn.FlatStyle = FlatStyle.Flat
                                    oBtn.Location = New System.Drawing.Point(350, y + 35)
                                    oBtn.Size = New System.Drawing.Size(120, 24)
                                    AddHandler oBtn.Click, AddressOf Procedimiento_btn

                                    oPanel.Controls.Add(oBtn)
                                    oBtn = Nothing
                                Else
                                    ''Cuando Son Multiples Valores y No tienen Predeterminados
                                    ''El Nombre de Jesus es Poder!!!!!!

                                    oTabla.TableName = "txt_parametros_" & intcounter.ToString.Trim & "1"
                                    oTabla.Columns.Add(New DataColumn("Del", GetType(String)))
                                    If Crep.DataDefinition.ParameterFields(intcounter).DiscreteOrRangeKind = DiscreteOrRangeKind.RangeValue Then
                                        oTabla.Columns.Add(New DataColumn("Al", GetType(String)))
                                    End If

                                    oDataGrid = New DataGrid
                                    oDataGrid.DataSource = oTabla
                                    oDataGrid.Name = "txt_parametros_" & intcounter.ToString.Trim
                                    oDataGrid.Location = New System.Drawing.Point(100, (25 * posiciony) + aumentary)
                                    oDataGrid.ReadOnly = False
                                    oDataGrid.CaptionVisible = False
                                    oDataGrid.Size = New System.Drawing.Size(240, 80)
                                    oDataGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                    ' oDataGrid.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                                    AddHandler oDataGrid.CurrentCellChanged, AddressOf Procedimiento_grd

                                    oPanel.Controls.Add(oDataGrid)
                                    oDataGrid = Nothing
                                    lbaumentary = True
                                    ''Le Asigno espacio en blanco en la 15 posiciones de parametros
                                    For i_count = 1 To 100
                                        pm_parametros(intcounter, i_count) = " "
                                    Next
                                End If
                            Else ''no son multiples valores
                                ls_nombre_campo = Crep.DataDefinition.ParameterFields(intcounter).Name
                                iaux = Crep.DataDefinition.ParameterFields(intcounter).DefaultValues.Count
                                If iaux > 0 Or ls_nombre_campo.StartsWith("_") Or ls_nombre_campo.StartsWith("@_") Then
                                    If ls_nombre_campo.StartsWith("_") Or ls_nombre_campo.StartsWith("@_") Then
                                        oTrans = New Transaccional.Conexion("flexline")
                                        oTrans.open()
                                        ls_txtsql = "pa_sel_um_gen_tabcod NULL,'" & _
                                                ls_nombre_campo.Substring(IIf(ls_nombre_campo.StartsWith("@"), 2, 1)).Trim & _
                                                "','" & gs_empresa & "'"
                                        oTabla = oTrans.Obtiene(ls_txtsql)
                                        If oTrans.Codigo_error > 0 Then
                                            MessageBox.Show(oTrans.descripcion_error)
                                        End If
                                        oTrans.close()
                                        iaux = oTabla.Rows.Count
                                        ReDim las_valores(iaux - 1)
                                        For i_count = 0 To iaux - 1
                                            las_valores(i_count) = oTabla.Rows(i_count)("codigo")
                                            'pm_parametros(intcounter, i_count + 1) = " "
                                        Next
                                    Else
                                        ReDim las_valores(iaux - 1)
                                        For i_count = 0 To iaux - 1
                                            paraValue = Crep.DataDefinition.ParameterFields(intcounter).DefaultValues(i_count)
                                            las_valores(i_count) = paraValue.Value
                                        Next
                                    End If
                                    oComboBox = New ComboBox

                                    oComboBox.DataSource = las_valores
                                    oComboBox.ValueMember = "values"
                                    oComboBox.Name = "txt_parametros_" & intcounter.ToString.Trim
                                    oComboBox.Location = New System.Drawing.Point(100, (25 * posiciony) + aumentary + extray)
                                    oComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                                    oComboBox.DropDownWidth = 240
                                    oComboBox.ForeColor = System.Drawing.Color.DarkRed
                                    oComboBox.BackColor = System.Drawing.SystemColors.ControlLight
                                    oComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                    'oComboBox.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                                    AddHandler oComboBox.SelectedValueChanged, AddressOf Procedimiento_cmb

                                    oPanel.Controls.Add(oComboBox)
                                    oComboBox = Nothing
                                    pm_parametros(intcounter, 1) = " "
                                Else
                                    oTxtBox = New TextBox
                                    oTxtBox.Name = "txt_parametros_" & intcounter.ToString.Trim
                                    oTxtBox.Location = New System.Drawing.Point(100, (25 * posiciony) + aumentary + extray)
                                    oTxtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                    oTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                                    AddHandler oTxtBox.TextChanged, AddressOf Procedimiento_txt
                                    oPanel.Controls.Add(oTxtBox)
                                    oTxtBox = Nothing
                                End If
                            End If ''Multipes valores
                        End If ''number or string

                        If Crep.DataDefinition.ParameterFields(intcounter).ParameterValueKind = ParameterValueKind.DateParameter _
                            Or Crep.DataDefinition.ParameterFields(intcounter).ParameterValueKind = ParameterValueKind.DateTimeParameter Then
                            ''Parametro tipo Fecha
                            oDateTimePicker = New DateTimePicker
                            oDateTimePicker.Name = "txt_parametros_" & intcounter.ToString.Trim
                            oDateTimePicker.Location = New System.Drawing.Point(100, (25 * posiciony) + aumentary + extray)
                            oDateTimePicker.Format = DateTimePickerFormat.Short
                            AddHandler oDateTimePicker.ValueChanged, AddressOf Procedimiento_txt
                            oDateTimePicker.Size = New System.Drawing.Size(100, 20)
                            oDateTimePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                            Try
                                If Crep.DataDefinition.ParameterFields(intcounter).PromptText.ToLower.IndexOf("del") > -1 Or _
                                    Crep.DataDefinition.ParameterFields(intcounter).PromptText.ToLower.IndexOf("inicio") > -1 Or _
                                    Crep.DataDefinition.ParameterFields(intcounter).PromptText.ToLower.IndexOf("inicial") > -1 Then
                                    oDateTimePicker.Value = Now.AddDays((Today.Day * -1) + 1)
                                End If

                            Catch ex As Exception

                            End Try
                            oPanel.Controls.Add(oDateTimePicker)
                            oDateTimePicker = Nothing
                        End If

                        ''Si es un Rango tengo que agregar el control para poner el valor final
                        If Crep.DataDefinition.ParameterFields(intcounter).DiscreteOrRangeKind = DiscreteOrRangeKind.RangeValue Then
                            pm_parametros(intcounter + 25, 0) = "txt_parametros_" & intcounter.ToString.Trim & "1"

                            If Crep.DataDefinition.ParameterFields(intcounter).ParameterValueKind = ParameterValueKind.DateParameter Then
                                ''Parametro tipo Fecha
                                oDateTimePicker = New DateTimePicker
                                oDateTimePicker.Name = "txt_parametros_" & intcounter.ToString.Trim & "1"
                                oDateTimePicker.Location = New System.Drawing.Point(230, (25 * posiciony) + aumentary + extray)
                                AddHandler oDateTimePicker.ValueChanged, AddressOf Procedimiento_txt
                                oDateTimePicker.Format = DateTimePickerFormat.Short
                                oDateTimePicker.Size = New System.Drawing.Size(100, 20)
                                oDateTimePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                oPanel.Controls.Add(oDateTimePicker)
                                oDateTimePicker = Nothing
                            End If

                            If Crep.DataDefinition.ParameterFields(intcounter).ParameterValueKind = ParameterValueKind.NumberParameter Or _
                                Crep.DataDefinition.ParameterFields(intcounter).ParameterValueKind = ParameterValueKind.StringParameter Then

                                If Crep.DataDefinition.ParameterFields(intcounter).EnableAllowMultipleValue = False Then
                                    oTxtBox = New TextBox
                                    oTxtBox.Name = "txt_parametros_" & intcounter.ToString.Trim & "1"
                                    oTxtBox.Location = New System.Drawing.Point(230, (25 * posiciony) + aumentary + extray)
                                    oTxtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                    oTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                                    AddHandler oTxtBox.TextChanged, AddressOf Procedimiento_txt
                                    oPanel.Controls.Add(oTxtBox)
                                    oTxtBox = Nothing
                                End If
                            End If
                            oLabel = New Label
                            oLabel.Name = "lbl_parametros_" & intcounter.ToString.Trim & "12"
                            oLabel.Location = New System.Drawing.Point(210, (25 * posiciony) + aumentary + extray)
                            oLabel.Text = "Al"
                            oLabel.AutoSize = True

                            oPanel.Controls.Add(oLabel)
                        End If 'range

                        oLabel = New Label
                        oLabel.Name = "lbl_parametros_" & intcounter.ToString.Trim
                        oLabel.Location = New System.Drawing.Point(5, (25 * posiciony) + aumentary + extray)

                        oLabel.Text = Crep.DataDefinition.ParameterFields(intcounter).PromptText.ToLower



                        oPanel.Controls.Add(oLabel)
                        oLabel = Nothing
                        ''Aumento el  interlineado por que se crearon
                        ''controles que necesitan mas espacio
                        If lbaumentary Then
                            aumentary = aumentary + 70
                            lbaumentary = False
                        End If
                    End If 'parametro diferente de empresa
                End If 'hascurrentvalue 28/07/2014
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Crep.Dispose()
            Crep = Nothing
        End Try
    End Sub

    Public Sub Cargar_Reportes(ByVal pusuario As String, ByVal pcod_opcion As Integer, ByVal pempresa As String)
        Dim ldt_table As New DataTable
        Dim ls_SqlScript As String

        Dim otransaccion As New Transaccional.Conexion("flexline")

        Try


           
            otransaccion.open()

            ls_SqlScript = "flexline.pa_sel_um_gen_reporte_empresa_usuario " & pcod_opcion & ",'" & pusuario & "','" & pempresa & "'"
            ldt_table = otransaccion.Obtiene(ls_SqlScript)
            ldt_table.TableName = "reportes"
            oDataSet.Tables.Add(ldt_table.Copy)

            Me.cmb_reporte.DisplayMember = "nombre_reporte"
            Me.cmb_reporte.ValueMember = "cod_reporte"
            Me.cmb_reporte.DataSource = ldt_table

        Catch ex As Exception
        Finally

            otransaccion.close()
            otransaccion = Nothing
        End Try

    End Sub

    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        Try
            guardarLogB("Generar Reporte " & Me.cmb_reporte.Text, gs_usuario, Me.Text, Me.cmb_reporte.Text)
        Catch ex As Exception
        End Try

        exportar_craxdrt(False, False)
    End Sub

    Private Sub Procedimiento_cmb(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer

        For i = 0 To 300
            If pm_parametros(i, 0).Equals(sender.name) Then
                pm_parametros(i, 1) = sender.selectedvalue()
                Exit For
            End If
        Next
    End Sub

    Private Sub Procedimiento_txt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        For i = 0 To 300
            If pm_parametros(i, 0) = sender.name Then
                pm_parametros(i, 1) = sender.text
                Exit For
            End If
        Next
    End Sub

    Private Sub Procedimiento_lcb(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
        If Not is_check_manual Then Exit Sub

        Dim i As Integer
        For i = 0 To 300
            If pm_parametros(i, 0) = sender.name Then

                If Not sender.GetItemChecked(sender.selectedindex) Then
                    pm_parametros(i, sender.selectedindex + 1) = sender.selectedvalue
                Else
                    pm_parametros(i, sender.selectedindex + 1) = ""
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub Procedimiento_grd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i, j As Integer
        Dim otabla As DataTable

        For i = 0 To 300
            If pm_parametros(i, 0) = sender.name Then
                otabla = sender.datasource
                j = otabla.Rows.Count
                For j = 0 To otabla.Rows.Count - 1
                    pm_parametros(i, j + 1) = otabla.Rows(j).Item(0)
                    If otabla.Columns.Count = 2 Then
                        pm_parametros(i, j + 1) = otabla.Rows(j).Item(0) & "," & otabla.Rows(j).Item(1)
                    End If
                Next
                Exit For
            End If
        Next
    End Sub

    Private Sub Recorrer_Parametros(ByVal path_reporte As String)
        Dim i_count, i_aux, itemnum As Integer
        Crep = New CrystalDecisions.CrystalReports.Engine.ReportDocument

        Try
            Crep.Load(path_reporte)

            For i_count = 0 To Crep.DataDefinition.ParameterFields.Count - 1
                If Crep.DataDefinition.ParameterFields(i_count).HasCurrentValue Then
                    'If Crep.DataDefinition.ParameterFields(i_count).ParameterFieldName().ToUpper.Trim <> "EMPRESA" Then
                    If Crep.DataDefinition.ParameterFields(i_count).ParameterFieldName().ToUpper.IndexOf("MPRESA") < 0 And _
                      Crep.DataDefinition.ParameterFields(i_count).ParameterFieldName().ToUpper.IndexOf("USER_NAME") < 0 Then
                        ''Recorro los controles de mi panel
                        For i_aux = 0 To oPanel.Controls.Count - 1
                            If oPanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim Then
                                itemnum = i_aux
                                Exit For
                            End If
                        Next

                        If Crep.DataDefinition.ParameterFields(i_count).ParameterValueKind = ParameterValueKind.NumberParameter Or _
                            Crep.DataDefinition.ParameterFields(i_count).ParameterValueKind = ParameterValueKind.StringParameter Then
                            i_aux = Crep.DataDefinition.ParameterFields(i_count).DefaultValues.Count
                            If i_aux > 0 Then
                                If Crep.DataDefinition.ParameterFields(i_count).EnableAllowMultipleValue = False Then
                                    Procedimiento_cmb(oPanel.Controls.Item(itemnum), System.EventArgs.Empty)
                                End If
                            Else
                                If Crep.DataDefinition.ParameterFields(i_count).EnableAllowMultipleValue = False Then
                                    Procedimiento_txt(oPanel.Controls.Item(itemnum), System.EventArgs.Empty)
                                End If
                            End If
                        Else
                            Procedimiento_txt(oPanel.Controls.Item(itemnum), System.EventArgs.Empty)
                        End If

                        If Crep.DataDefinition.ParameterFields(i_count).DiscreteOrRangeKind = DiscreteOrRangeKind.RangeValue Then
                            For i_aux = 0 To oPanel.Controls.Count - 1
                                If oPanel.Controls.Item(i_aux).Name = "txt_parametros_" & i_count.ToString.Trim & "1" Then
                                    itemnum = i_aux
                                    Exit For
                                End If
                            Next
                            If Crep.DataDefinition.ParameterFields(i_count).EnableAllowMultipleValue = False Then
                                Procedimiento_txt(oPanel.Controls.Item(itemnum), System.EventArgs.Empty)
                            End If
                        End If
                    End If
                End If
            Next

            _ServerName = Crep.Database.Tables(0).LogOnInfo.ConnectionInfo.ServerName
            _DataBaseName = Crep.Database.Tables(0).LogOnInfo.ConnectionInfo.DatabaseName
            _UsrID = Crep.Database.Tables(0).LogOnInfo.ConnectionInfo.UserID
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Crep.Dispose()
            Crep = Nothing
        End Try
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Me.oPanel.Controls.Clear()
    End Sub

    Private Sub cmb_reporte_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_reporte.SelectionChangeCommitted
        Try
            Me.oPanel.Controls.Clear()
            Me.btn_procesar.Enabled = False
            Me.btn_Exportar.Enabled = False
            Me.btn_imprimir.Enabled = False
            ''Cargar los Parametros del Reporte

            generar_parametros(Me.cmb_reporte.Text)
            Me.btn_procesar.Enabled = True
            Me.btn_Exportar.Enabled = True
            Me.btn_imprimir.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub exportar_craxdrt(ByVal exportar As Boolean, ByVal imprimir As Boolean)
        Dim path_reporte As String
        Dim proceso_adicional(2) As String

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            oDataSet.Tables("reportes").DefaultView.RowFilter = "nombre_reporte = '" & Me.cmb_reporte.Text & "'"
            path_reporte = oDataSet.Tables("reportes").DefaultView(0)("path_reporte")
            Recorrer_Parametros(path_reporte)

            Try
                proceso_adicional(0) = IIf(oDataSet.Tables("reportes").DefaultView(0)("tiempo_ejecucion") = True, 1, 0)
                proceso_adicional(1) = oDataSet.Tables("reportes").DefaultView(0)("servidor").ToString
                proceso_adicional(2) = oDataSet.Tables("reportes").DefaultView(0)("proceso").ToString
            Catch ex As Exception
                proceso_adicional(0) = -1
            End Try

            _exportar_reporte_Clase(path_reporte, pm_parametros, oPanel, _
                       _ServerName, _
                        _DataBaseName, _
                        _UsrID, exportar, imprimir, _
                        oDataSet.Tables("reportes").DefaultView(0)("acciones").ToString, _
                        oDataSet.Tables("reportes").DefaultView(0)("tipo_exportar").ToString, proceso_adicional)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            Me.Cursor = System.Windows.Forms.Cursors.Default

            Dim otrans As New Transaccional.Conexion("flexline")
            Dim i_aux As Integer
            otrans.open()

            oDataSet.Tables("reportes").DefaultView.RowFilter = "nombre_reporte = '" & Me.cmb_reporte.Text & "'"
            i_aux = oDataSet.Tables("reportes").DefaultView(0)("cod_reporte")
            otrans.Ingresa("pa_ins_um_gen_log_reporte " & i_aux & ",'" & gs_usuario & "','" & gs_empresa & "'")

            otrans.close()
            otrans = Nothing
        End Try
    End Sub

    Private Sub btn_Exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exportar.Click
        exportar_craxdrt(True, False)
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        exportar_craxdrt(False, True)
    End Sub

    Private Sub frm_reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmb_reporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_reporte.SelectedIndexChanged

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    

    Private Sub cmb_reporte_SizeChanged(sender As Object, e As EventArgs) Handles cmb_reporte.SizeChanged

    End Sub
End Class