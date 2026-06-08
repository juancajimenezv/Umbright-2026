<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecepcionControlTransporte
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecepcionControlTransporte))
        Me.dgvDocumentos = New System.Windows.Forms.DataGridView()
        Me.txtNumeroControl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAuxiliar = New System.Windows.Forms.TextBox()
        Me.txtVehiculo = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.txtChequeador = New System.Windows.Forms.TextBox()
        Me.txt_piloto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtNumeroFactura = New System.Windows.Forms.TextBox()
        Me.txtComentarioFactura = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDocumentos
        '
        Me.dgvDocumentos.AllowUserToAddRows = False
        Me.dgvDocumentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocumentos.Location = New System.Drawing.Point(12, 158)
        Me.dgvDocumentos.Name = "dgvDocumentos"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        Me.dgvDocumentos.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDocumentos.Size = New System.Drawing.Size(727, 323)
        Me.dgvDocumentos.TabIndex = 0
        '
        'txtNumeroControl
        '
        Me.txtNumeroControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroControl.Location = New System.Drawing.Point(155, 10)
        Me.txtNumeroControl.Name = "txtNumeroControl"
        Me.txtNumeroControl.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroControl.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Numero de Control"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Auxiliar"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Vehiculo"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 20)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Piloto"
        '
        'txtAuxiliar
        '
        Me.txtAuxiliar.Location = New System.Drawing.Point(117, 81)
        Me.txtAuxiliar.Name = "txtAuxiliar"
        Me.txtAuxiliar.ReadOnly = True
        Me.txtAuxiliar.Size = New System.Drawing.Size(232, 20)
        Me.txtAuxiliar.TabIndex = 7
        '
        'txtVehiculo
        '
        Me.txtVehiculo.Location = New System.Drawing.Point(117, 59)
        Me.txtVehiculo.Name = "txtVehiculo"
        Me.txtVehiculo.ReadOnly = True
        Me.txtVehiculo.Size = New System.Drawing.Size(232, 20)
        Me.txtVehiculo.TabIndex = 8
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(400, 60)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(156, 20)
        Me.txtRuta.TabIndex = 9
        '
        'txtChequeador
        '
        Me.txtChequeador.Location = New System.Drawing.Point(400, 37)
        Me.txtChequeador.Name = "txtChequeador"
        Me.txtChequeador.ReadOnly = True
        Me.txtChequeador.Size = New System.Drawing.Size(156, 20)
        Me.txtChequeador.TabIndex = 10
        '
        'txt_piloto
        '
        Me.txt_piloto.Location = New System.Drawing.Point(117, 37)
        Me.txt_piloto.Name = "txt_piloto"
        Me.txt_piloto.ReadOnly = True
        Me.txt_piloto.Size = New System.Drawing.Size(232, 20)
        Me.txt_piloto.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(365, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Ruta"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(365, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Cheq"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(400, 82)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(104, 20)
        Me.txt_fecha.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(365, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Fecha"
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.ImageKey = "1286297283_unknown.png"
        Me.btnNuevo.ImageList = Me.ImageList1
        Me.btnNuevo.Location = New System.Drawing.Point(590, 15)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 66)
        Me.btnNuevo.TabIndex = 18
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.ImageKey = "1286297068_Floppy-64.png"
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(667, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 66)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'txtNumeroFactura
        '
        Me.txtNumeroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroFactura.Location = New System.Drawing.Point(129, 127)
        Me.txtNumeroFactura.Name = "txtNumeroFactura"
        Me.txtNumeroFactura.Size = New System.Drawing.Size(100, 20)
        Me.txtNumeroFactura.TabIndex = 1
        '
        'txtComentarioFactura
        '
        Me.txtComentarioFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentarioFactura.Location = New System.Drawing.Point(436, 130)
        Me.txtComentarioFactura.Name = "txtComentarioFactura"
        Me.txtComentarioFactura.Size = New System.Drawing.Size(267, 20)
        Me.txtComentarioFactura.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Numero Documento"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(376, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Comentario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_fecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtAuxiliar)
        Me.GroupBox1.Controls.Add(Me.txtVehiculo)
        Me.GroupBox1.Controls.Add(Me.txtRuta)
        Me.GroupBox1.Controls.Add(Me.txtChequeador)
        Me.GroupBox1.Controls.Add(Me.txt_piloto)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNumeroControl)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 113)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1286297068_Floppy-64.png")
        Me.ImageList1.Images.SetKeyName(1, "1286297283_unknown.png")
        '
        'frmRecepcionControlTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(751, 493)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtComentarioFactura)
        Me.Controls.Add(Me.txtNumeroFactura)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvDocumentos)
        Me.Name = "frmRecepcionControlTransporte"
        Me.Text = ":: Recepcion Control Transporte ::"
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents txtNumeroControl As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAuxiliar As System.Windows.Forms.TextBox
    Friend WithEvents txtVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeador As System.Windows.Forms.TextBox
    Friend WithEvents txt_piloto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtNumeroFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtComentarioFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
