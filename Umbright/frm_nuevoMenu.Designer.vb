<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nuevoMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.menu_principal = New System.Windows.Forms.MenuStrip
        Me.m_archivo = New System.Windows.Forms.ToolStripMenuItem
        Me.m_comercial = New System.Windows.Forms.ToolStripMenuItem
        Me.m_rrhh = New System.Windows.Forms.ToolStripMenuItem
        Me.m_finanzas = New System.Windows.Forms.ToolStripMenuItem
        Me.m_it = New System.Windows.Forms.ToolStripMenuItem
        Me.m_logisticia = New System.Windows.Forms.ToolStripMenuItem
        Me.m_presidencia = New System.Windows.Forms.ToolStripMenuItem
        Me.m_compras = New System.Windows.Forms.ToolStripMenuItem
        Me.m_telemarketing = New System.Windows.Forms.ToolStripMenuItem
        Me.m_mercadeo = New System.Windows.Forms.ToolStripMenuItem
        Me.CubosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'menu_principal
        '
        Me.menu_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_archivo, Me.m_comercial, Me.m_rrhh, Me.m_finanzas, Me.m_it, Me.m_logisticia, Me.m_presidencia, Me.m_compras, Me.m_telemarketing, Me.m_mercadeo})
        Me.menu_principal.Location = New System.Drawing.Point(0, 0)
        Me.menu_principal.Name = "menu_principal"
        Me.menu_principal.Size = New System.Drawing.Size(896, 24)
        Me.menu_principal.TabIndex = 0
        Me.menu_principal.Text = "MenuStrip1"
        '
        'm_archivo
        '
        Me.m_archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CubosToolStripMenuItem})
        Me.m_archivo.Name = "m_archivo"
        Me.m_archivo.Size = New System.Drawing.Size(55, 20)
        Me.m_archivo.Text = "Archivo"
        '
        'm_comercial
        '
        Me.m_comercial.Name = "m_comercial"
        Me.m_comercial.Size = New System.Drawing.Size(65, 20)
        Me.m_comercial.Text = "Comercial"
        '
        'm_rrhh
        '
        Me.m_rrhh.Name = "m_rrhh"
        Me.m_rrhh.Size = New System.Drawing.Size(33, 20)
        Me.m_rrhh.Text = "RH"
        '
        'm_finanzas
        '
        Me.m_finanzas.Name = "m_finanzas"
        Me.m_finanzas.Size = New System.Drawing.Size(61, 20)
        Me.m_finanzas.Text = "Finanzas"
        '
        'm_it
        '
        Me.m_it.Name = "m_it"
        Me.m_it.Size = New System.Drawing.Size(29, 20)
        Me.m_it.Text = "IT"
        '
        'm_logisticia
        '
        Me.m_logisticia.Name = "m_logisticia"
        Me.m_logisticia.Size = New System.Drawing.Size(60, 20)
        Me.m_logisticia.Text = "Logistica"
        '
        'm_presidencia
        '
        Me.m_presidencia.Name = "m_presidencia"
        Me.m_presidencia.Size = New System.Drawing.Size(73, 20)
        Me.m_presidencia.Text = "Presidencia"
        '
        'm_compras
        '
        Me.m_compras.Name = "m_compras"
        Me.m_compras.Size = New System.Drawing.Size(61, 20)
        Me.m_compras.Text = "Compras"
        '
        'm_telemarketing
        '
        Me.m_telemarketing.Name = "m_telemarketing"
        Me.m_telemarketing.Size = New System.Drawing.Size(86, 20)
        Me.m_telemarketing.Text = "Telemarketing"
        '
        'm_mercadeo
        '
        Me.m_mercadeo.Name = "m_mercadeo"
        Me.m_mercadeo.Size = New System.Drawing.Size(66, 20)
        Me.m_mercadeo.Text = "Mercadeo"
        '
        'CubosToolStripMenuItem
        '
        Me.CubosToolStripMenuItem.Name = "CubosToolStripMenuItem"
        Me.CubosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CubosToolStripMenuItem.Text = "Cubos"
        '
        'frm_nuevoMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 548)
        Me.Controls.Add(Me.menu_principal)
        Me.MainMenuStrip = Me.menu_principal
        Me.Name = "frm_nuevoMenu"
        Me.Text = "frm_nuevoMenu"
        Me.menu_principal.ResumeLayout(False)
        Me.menu_principal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menu_principal As System.Windows.Forms.MenuStrip
    Friend WithEvents m_archivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_comercial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_rrhh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_finanzas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_it As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_logisticia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_presidencia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_compras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_telemarketing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_mercadeo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CubosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
