Option Strict Off
Option Explicit On
Option Infer On

''' <summary>
''' Paleta y helpers visuales del módulo de Requisiciones Masivas IA, extraídos
''' directamente de frm_menuprincipal.vb (header oliva oscuro FromArgb(45,50,22),
''' acento terracota FromArgb(196,81,35), acento oliva FromArgb(106,116,56), fondo
''' crema FromArgb(242,240,234), tipografía Segoe UI) para que este módulo nuevo se
''' sienta parte de la misma identidad visual del resto de Umbright ERP, en vez de
''' verse como una pantalla ajena pegada al sistema.
''' </summary>
Public Module RequisicionIA_Estilos

    Public ReadOnly ColorFondo As Color = Color.FromArgb(242, 240, 234)
    Public ReadOnly ColorHeader As Color = Color.FromArgb(45, 50, 22)
    Public ReadOnly ColorTerracota As Color = Color.FromArgb(196, 81, 35)
    Public ReadOnly ColorOliva As Color = Color.FromArgb(106, 116, 56)
    Public ReadOnly ColorTextoOscuro As Color = Color.FromArgb(55, 62, 28)
    Public ReadOnly ColorTextoMuted As Color = Color.FromArgb(160, 155, 145)
    Public ReadOnly ColorBorde As Color = Color.FromArgb(220, 215, 200)
    Public ReadOnly ColorPanelSuave As Color = Color.FromArgb(230, 227, 218)
    Public ReadOnly ColorHover As Color = Color.FromArgb(250, 248, 244)

    Public Const NOMBRE_FUENTE As String = "Segoe UI"

    ''' <summary>
    ''' Banda de encabezado igual a la de frm_menuprincipal (mismo panel oliva oscuro,
    ''' mismo par eyebrow-terracota + título-blanco). Agregar SIEMPRE después de
    ''' InitializeComponent (en el Load), para que quede docked-Top por encima de lo
    ''' que ya existe (WinForms respeta el orden de inserción para el docking).
    ''' </summary>
    Public Function CrearHeader(titulo As String) As Panel
        Dim pnl As New Panel With {
            .Height = 54,
            .Dock = DockStyle.Top,
            .BackColor = ColorHeader
        }

        Dim lblEyebrow As New Label With {
            .Text = "REQUISICIONES · IA",
            .ForeColor = ColorTerracota,
            .Font = New Font(NOMBRE_FUENTE, 7.5F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(16, 8)
        }
        Dim lblTitulo As New Label With {
            .Text = titulo,
            .ForeColor = Color.White,
            .Font = New Font(NOMBRE_FUENTE, 13.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(16, 24)
        }

        pnl.Controls.Add(lblEyebrow)
        pnl.Controls.Add(lblTitulo)
        Return pnl
    End Function

    ''' <summary>Acción principal de la pantalla (Guardar, Enviar, Aceptar) — relleno terracota.</summary>
    Public Sub EstilizarBotonPrimario(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(212, 100, 55)
        btn.BackColor = ColorTerracota
        btn.ForeColor = Color.White
        btn.Font = New Font(NOMBRE_FUENTE, 9.0F, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
    End Sub

    ''' <summary>Acción secundaria (Agregar, Buscar, Distribución, Configurar) — relleno oliva.</summary>
    Public Sub EstilizarBotonSecundario(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(122, 132, 68)
        btn.BackColor = ColorOliva
        btn.ForeColor = Color.White
        btn.Font = New Font(NOMBRE_FUENTE, 9.0F, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
    End Sub

    ''' <summary>Acción de bajo riesgo/salida (Cancelar, Eliminar, Descartar) — contorno suave, sin relleno.</summary>
    Public Sub EstilizarBotonSuave(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderColor = ColorBorde
        btn.FlatAppearance.BorderSize = 1
        btn.FlatAppearance.MouseOverBackColor = ColorPanelSuave
        btn.BackColor = ColorFondo
        btn.ForeColor = ColorTextoOscuro
        btn.Font = New Font(NOMBRE_FUENTE, 9.0F, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
    End Sub

    ''' <summary>Encabezado oliva oscuro + selección terracota + filas alternadas crema, igual look que el menú principal.</summary>
    Public Sub EstilizarGrid(dgv As DataGridView)
        dgv.EnableHeadersVisualStyles = False
        dgv.BackgroundColor = Color.White
        dgv.BorderStyle = BorderStyle.None
        dgv.GridColor = ColorBorde
        dgv.RowHeadersVisible = False
        dgv.ColumnHeadersHeight = 30
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorHeader
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font(NOMBRE_FUENTE, 8.5F, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.DefaultCellStyle.Font = New Font(NOMBRE_FUENTE, 8.5F)
        dgv.DefaultCellStyle.ForeColor = ColorTextoOscuro
        dgv.DefaultCellStyle.SelectionBackColor = ColorTerracota
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorFondo
        dgv.RowTemplate.Height = 24
    End Sub

    ''' <summary>Color de "semáforo" para un estado de borrador: oliva = listo, terracota = necesita atención.</summary>
    Public Function ColorEstado(estado As String) As Color
        If String.Equals(estado, "Valido", StringComparison.OrdinalIgnoreCase) Then
            Return ColorOliva
        End If
        Return ColorTerracota
    End Function

End Module
