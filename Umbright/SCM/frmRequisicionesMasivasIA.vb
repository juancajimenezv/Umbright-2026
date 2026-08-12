Option Strict Off
Option Explicit On
Option Infer On

Imports System.Linq

''' <summary>
''' Chat de generación masiva de requisiciones con IA. Envía instrucciones en lenguaje
''' natural a RequisicionChatOrchestrator, muestra el borrador resultante (con su estado
''' de validación) en dgvBorrador, y permite guardar solo las requisiciones válidas
''' reutilizando exactamente los mismos stored procedures que el flujo manual.
''' </summary>
Public Class frmRequisicionesMasivasIA

    Private _orquestador As RequisicionChatOrchestrator

    Private Sub frmRequisicionesMasivasIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AplicarEstilos()

        ' La configuración de la API Key es solo para administradores (IT), aunque el
        ' resto del módulo ya está restringido a admin desde el menú (frm_menuprincipal).
        btnConfigurarApiKey.Visible = (gi_tipo_usuario = 1)

        _orquestador = New RequisicionChatOrchestrator(gs_empresa, gs_usuario)
        RefrescarGrid()
        AgregarAlHistorial("Sistema", "Describe las requisiciones que necesitas (proveedor, productos, centros de costo, marcas, etc.). Puedes pedir varias a la vez.")
    End Sub

    ''' <summary>Aplica la misma paleta e identidad visual de frm_menuprincipal (header oliva,
    ''' acentos terracota/oliva sobre fondo crema) para que el módulo se sienta parte de Umbright.</summary>
    Private Sub AplicarEstilos()
        Me.BackColor = RequisicionIA_Estilos.ColorFondo
        Me.Controls.Add(RequisicionIA_Estilos.CrearHeader("Requisiciones Masivas"))

        RequisicionIA_Estilos.EstilizarBotonPrimario(btnEnviar)
        RequisicionIA_Estilos.EstilizarBotonPrimario(btnGuardarValidas)
        RequisicionIA_Estilos.EstilizarBotonSecundario(btnConfigurarApiKey)
        RequisicionIA_Estilos.EstilizarBotonSuave(btnDescartar)
        RequisicionIA_Estilos.EstilizarGrid(dgvBorrador)

        rtbHistorial.BackColor = Color.White
        rtbHistorial.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 9.0F)
        rtbHistorial.BorderStyle = BorderStyle.None

        lblContador.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 9.5F, FontStyle.Bold)
        lblContador.ForeColor = RequisicionIA_Estilos.ColorTextoOscuro
        lblContador.BackColor = RequisicionIA_Estilos.ColorPanelSuave

        txtMensaje.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 9.5F)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        EnviarMensajeActual()
    End Sub

    Private Sub txtMensaje_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMensaje.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Not e.Shift Then
            e.SuppressKeyPress = True
            EnviarMensajeActual()
        End If
    End Sub

    Private Sub EnviarMensajeActual()
        Dim mensaje As String = txtMensaje.Text.Trim()
        If mensaje.Length = 0 Then Return

        AgregarAlHistorial("Tú", mensaje)
        txtMensaje.Clear()

        Me.Cursor = Cursors.WaitCursor
        Me.SplitContainer1.Enabled = False
        Try
            Dim respuesta As String = _orquestador.EnviarMensaje(mensaje)
            AgregarAlHistorial("Asistente", respuesta)
            RefrescarGrid()
        Catch ex As Exception
            AgregarAlHistorial("Sistema", "No se pudo procesar la solicitud: " & ex.Message)
        Finally
            Me.SplitContainer1.Enabled = True
            Me.Cursor = Cursors.Default
            Me.txtMensaje.Focus()
        End Try
    End Sub

    Private Sub btnGuardarValidas_Click(sender As Object, e As EventArgs) Handles btnGuardarValidas.Click
        If _orquestador.Lote.Where(Function(i) i.Estado = EstadoBorradorRequisicion.Valido).Count() = 0 Then
            MessageBox.Show("No hay requisiciones válidas para guardar todavía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim resultados = _orquestador.GuardarLoteValido()
            Dim numerosGuardados = resultados.Where(Function(r) r.Exitoso).Select(Function(r) r.Numero).ToList()
            Dim conError = resultados.Where(Function(r) Not r.Exitoso).ToList()

            RefrescarGrid()

            If numerosGuardados.Count > 0 Then
                AgregarAlHistorial("Sistema", "Se guardaron las requisiciones: " & String.Join(", ", numerosGuardados))
            End If
            If conError.Count > 0 Then
                AgregarAlHistorial("Sistema", $"{conError.Count} requisición(es) fallaron al guardar. Revisa la columna Detalle del borrador.")
            End If
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnConfigurarApiKey_Click(sender As Object, e As EventArgs) Handles btnConfigurarApiKey.Click
        Dim oform As New frmConfigurarApiKeyIA
        oform.ShowDialog(Me)
        oform.Dispose()
    End Sub

    Private Sub dgvBorrador_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBorrador.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= _orquestador.Lote.Count Then Return

        Dim item = _orquestador.Lote(e.RowIndex)
        Dim frm As New frmRequisicionMasivaIA_Cabecera(item.Cabecera)
        If frm.ShowDialog(Me) = DialogResult.OK Then
            item.Cabecera = frm.CabeceraResultado
            Me.Cursor = Cursors.WaitCursor
            Try
                _orquestador.RevalidarItem(item)
            Finally
                Me.Cursor = Cursors.Default
            End Try
            RefrescarGrid()
        End If
        frm.Dispose()
    End Sub

    Private Sub btnDescartar_Click(sender As Object, e As EventArgs) Handles btnDescartar.Click
        If MessageBox.Show("¿Descartar todo el borrador actual y comenzar una conversación nueva?", "Confirmar",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _orquestador = New RequisicionChatOrchestrator(gs_empresa, gs_usuario)
            rtbHistorial.Clear()
            RefrescarGrid()
        End If
    End Sub

    Private Sub RefrescarGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(String))
        dt.Columns.Add("Estado", GetType(String))
        dt.Columns.Add("Proveedor", GetType(String))
        dt.Columns.Add("Centros de Costo", GetType(String))
        dt.Columns.Add("Moneda", GetType(String))
        dt.Columns.Add("Total", GetType(Double))
        dt.Columns.Add("Líneas", GetType(Integer))
        dt.Columns.Add("Número", GetType(String))
        dt.Columns.Add("Detalle", GetType(String))

        For Each item In _orquestador.Lote
            Dim detalle As String = String.Join(" | ", item.Errores.Concat(item.PreguntasAclaracion))
            Dim ccConcatenados As String = String.Join(", ", item.Cabecera.CentrosCosto.Select(Function(cc) $"{cc.Codigo} ({cc.Porcentaje}%)"))
            Dim total As Double = item.Cabecera.Lineas.Sum(Function(l) l.Cantidad * l.Precio)
            dt.Rows.Add(
                item.Id,
                item.Estado.ToString(),
                item.Cabecera.Proveedor,
                ccConcatenados,
                item.Cabecera.Moneda,
                total,
                item.Cabecera.Lineas.Count,
                If(item.NumeroRequisicionGuardada, ""),
                detalle)
        Next

        dgvBorrador.DataSource = dt
        If dgvBorrador.Columns.Count > 0 Then
            ' Anchos fijos para las columnas "de contexto"; "Detalle" (por qué falta algo)
            ' es la única que se estira — es la información que más se necesita ver de un
            ' vistazo, y con las columnas nuevas (CC/Moneda/Total) ya no cabía sola.
            dgvBorrador.Columns("Id").Width = 40
            dgvBorrador.Columns("Estado").Width = 130
            dgvBorrador.Columns("Proveedor").Width = 90
            dgvBorrador.Columns("Centros de Costo").Width = 140
            dgvBorrador.Columns("Moneda").Width = 75
            dgvBorrador.Columns("Total").Width = 90
            dgvBorrador.Columns("Total").DefaultCellStyle.Format = "N2"
            dgvBorrador.Columns("Líneas").Width = 55
            dgvBorrador.Columns("Número").Width = 90
            For Each nombre In {"Id", "Estado", "Proveedor", "Centros de Costo", "Moneda", "Total", "Líneas", "Número"}
                dgvBorrador.Columns(nombre).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Next

            dgvBorrador.Columns("Detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvBorrador.Columns("Detalle").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            dgvBorrador.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        End If

        lblContador.Text = _orquestador.ResumenConteo()
    End Sub

    ''' <summary>Semáforo de estado: oliva = lista para guardar, terracota = necesita atención.</summary>
    Private Sub dgvBorrador_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvBorrador.CellFormatting
        If dgvBorrador.Columns(e.ColumnIndex).Name <> "Estado" Then Return
        e.CellStyle.ForeColor = RequisicionIA_Estilos.ColorEstado(If(e.Value, "").ToString)
        e.CellStyle.Font = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 8.5F, FontStyle.Bold)
    End Sub

    ''' <summary>Cada interlocutor tiene su propio color (terracota = asistente, oliva = tú,
    ''' gris muted = sistema) para que el historial se lea como un chat, no como un log plano.</summary>
    Private Sub AgregarAlHistorial(rol As String, texto As String)
        Dim colorRol As Color = RequisicionIA_Estilos.ColorTextoOscuro
        Select Case rol
            Case "Asistente"
                colorRol = RequisicionIA_Estilos.ColorTerracota
            Case "Tú"
                colorRol = RequisicionIA_Estilos.ColorOliva
            Case "Sistema"
                colorRol = RequisicionIA_Estilos.ColorTextoMuted
        End Select

        rtbHistorial.SelectionStart = rtbHistorial.TextLength
        rtbHistorial.SelectionLength = 0
        rtbHistorial.SelectionColor = colorRol
        rtbHistorial.SelectionFont = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 9.0F, FontStyle.Bold)
        rtbHistorial.AppendText($"{rol}" & Environment.NewLine)

        rtbHistorial.SelectionColor = RequisicionIA_Estilos.ColorTextoOscuro
        rtbHistorial.SelectionFont = New Font(RequisicionIA_Estilos.NOMBRE_FUENTE, 9.0F, FontStyle.Regular)
        rtbHistorial.AppendText(texto & Environment.NewLine & Environment.NewLine)

        rtbHistorial.SelectionStart = rtbHistorial.TextLength
        rtbHistorial.ScrollToCaret()
    End Sub

End Class
