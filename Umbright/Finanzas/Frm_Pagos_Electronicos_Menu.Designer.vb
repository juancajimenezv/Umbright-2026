<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pagos_Electronicos_Menu
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
        Me.pb_Tracking = New System.Windows.Forms.PictureBox()
        Me.pb_Creacion = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.pb_Tracking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Creacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb_Tracking
        '
        Me.pb_Tracking.Image = Global.Umbright.My.Resources.Resources.Tracking
        Me.pb_Tracking.Location = New System.Drawing.Point(245, 114)
        Me.pb_Tracking.Name = "pb_Tracking"
        Me.pb_Tracking.Size = New System.Drawing.Size(125, 98)
        Me.pb_Tracking.TabIndex = 5
        Me.pb_Tracking.TabStop = False
        '
        'pb_Creacion
        '
        Me.pb_Creacion.Image = Global.Umbright.My.Resources.Resources.Creacion
        Me.pb_Creacion.Location = New System.Drawing.Point(97, 114)
        Me.pb_Creacion.Name = "pb_Creacion"
        Me.pb_Creacion.Size = New System.Drawing.Size(125, 98)
        Me.pb_Creacion.TabIndex = 4
        Me.pb_Creacion.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Umbright.My.Resources.Resources.Lotes
        Me.PictureBox1.Location = New System.Drawing.Point(114, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(239, 59)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Frm_Pagos_Electronicos_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(482, 235)
        Me.Controls.Add(Me.pb_Tracking)
        Me.Controls.Add(Me.pb_Creacion)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Frm_Pagos_Electronicos_Menu"
        Me.Text = "Menú Pagos Electronicos"
        CType(Me.pb_Tracking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Creacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pb_Creacion As PictureBox
    Friend WithEvents pb_Tracking As PictureBox
End Class
