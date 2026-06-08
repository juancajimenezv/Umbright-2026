Imports System.Data
Imports System.Windows.Forms

' Detalle de una solicitud de cambio de tipoproducto
' Se abre desde el grid de "Listado de Solicitudes por Modificación".
' Recibe el id en el constructor. Permite Aprobar/Rechazar.
Public Class frm_detalleSolicitudCambio

    Private _id As Integer
    Public Property HuboCambio As Boolean = False  ' True si se aprobó o rechazó (para refrescar grid)

    Public Sub New(idSolicitud As Integer)
        InitializeComponent()
        _id = idSolicitud
    End Sub

    Private Sub frm_detalleSolicitudCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNumero.Text = "Solicitud #" & _id.ToString()
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim oScm As New Transaccional.Conexion("SCM")
        Try
            oScm.open()
            Dim sql As String =
                "SELECT id, empresa, producto, glosa, valor_anterior, valor_nuevo, estado, " &
                "       motivo, usuario_crea, fecha_crea, usuario_aprueba, fecha_aprueba, observacion " &
                "  FROM scm.dbo.solicitud_cambio_tipoproducto WHERE id = " & _id.ToString()
            Dim dt As DataTable = oScm.Obtiene(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                MessageBox.Show("Solicitud no encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return
            End If
            Dim r As DataRow = dt.Rows(0)
            lblEmpresa.Text = SafeStr(r("empresa"))
            lblProducto.Text = SafeStr(r("producto"))
            lblGlosa.Text = SafeStr(r("glosa"))
            lblValorAnterior.Text = If(SafeStr(r("valor_anterior")) = "", "(vacío)", SafeStr(r("valor_anterior")))
            lblValorNuevo.Text = SafeStr(r("valor_nuevo"))
            lblMotivo.Text = If(SafeStr(r("motivo")) = "", "(sin motivo)", SafeStr(r("motivo")))
            lblSolicitante.Text = SafeStr(r("usuario_crea"))
            lblFecha.Text = SafeStr(r("fecha_crea"))

            Dim estado As String = SafeStr(r("estado"))
            lblEstado.Text = estado
            Select Case estado
                Case "PENDIENTE"
                    lblEstado.ForeColor = System.Drawing.Color.DarkBlue
                Case "APROBADA"
                    lblEstado.ForeColor = System.Drawing.Color.DarkGreen
                Case "RECHAZADA"
                    lblEstado.ForeColor = System.Drawing.Color.DarkRed
                Case Else
                    lblEstado.ForeColor = System.Drawing.Color.Black
            End Select

            ' Solo permitir acciones si está pendiente
            Dim esPendiente As Boolean = (estado = "PENDIENTE")
            btnAprobar.Enabled = esPendiente
            btnRechazar.Enabled = esPendiente
            txtObservacion.Enabled = esPendiente
            If Not esPendiente Then
                txtObservacion.Text = SafeStr(r("observacion"))
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar: " & ex.Message)
            Me.Close()
        Finally
            Try : oScm.close() : Catch : End Try
        End Try
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Dim cod As String = lblProducto.Text
        Dim emp As String = lblEmpresa.Text
        Dim valAnt As String = If(lblValorAnterior.Text = "(vacío)", "", lblValorAnterior.Text)
        Dim valNuevo As String = lblValorNuevo.Text
        Dim obs As String = txtObservacion.Text.Trim()

        If MessageBox.Show("¿Aprobar el cambio de tipo de producto?" & vbCrLf & vbCrLf &
                           "Producto: " & cod & "    Empresa: " & emp & vbCrLf &
                           "De: '" & valAnt & "'    A: '" & valNuevo & "'" & vbCrLf & vbCrLf &
                           "Se actualizará flexline.producto y quedará registrado en el log.",
                           "Confirmar aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Dim oScm As New Transaccional.Conexion("SCM")
        Try
            Cursor = Cursors.WaitCursor
            oFlex.open() : oScm.open()

            ' 1) UPDATE en flexline.producto
            Dim sqlUpd As String =
                "UPDATE flexline.producto SET tipoproducto = '" & valNuevo.Replace("'", "''") & "' " &
                " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                "   AND producto = '" & cod.Replace("'", "''") & "'"
            oFlex.Ingresa(sqlUpd)
            If oFlex.Codigo_error <> 0 Then
                MessageBox.Show("Error UPDATE producto: " & oFlex.descripcion_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' 2) Marcar solicitud como aprobada
            Dim sqlSol As String =
                "UPDATE scm.dbo.solicitud_cambio_tipoproducto " &
                "   SET estado = 'APROBADA', " &
                "       usuario_aprueba = '" & gs_usuario.Replace("'", "''") & "', " &
                "       fecha_aprueba = GETDATE(), " &
                "       observacion = " & If(obs.Length = 0, "NULL", "N'" & obs.Replace("'", "''") & "'") & " " &
                " WHERE id = " & _id.ToString()
            oScm.Ingresa(sqlSol)

            ' 3) Insert log
            Dim obsLog As String = "Solicitud #" & _id & " aprobada por " & gs_usuario
            If obs.Length > 0 Then obsLog &= " | " & obs
            Dim sqlLog As String =
                "INSERT INTO scm.dbo.log_modificaciones_productos " &
                "(empresa, cod_producto, tabla_modificada, columna_modificada, " &
                " valor_anterior, valor_nuevo, accion, usuario, equipo, aplicacion, observacion) " &
                "VALUES (" &
                "'" & emp.Replace("'", "''") & "', " &
                "'" & cod.Replace("'", "''") & "', " &
                "'BDFlexline.flexline.producto', 'tipoproducto', " &
                "N'" & valAnt.Replace("'", "''") & "', " &
                "N'" & valNuevo.Replace("'", "''") & "', " &
                "'UPDATE-APROBADO', " &
                "'" & gs_usuario.Replace("'", "''") & "', " &
                "'" & gs_nombre_equipo.Replace("'", "''") & "', 'Umbright', " &
                "N'" & obsLog.Replace("'", "''") & "')"
            oScm.Ingresa(sqlLog)

            MessageBox.Show("Solicitud aprobada y cambio aplicado correctamente.",
                            "Aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HuboCambio = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Cursor = Cursors.Default
            Try : oFlex.close() : Catch : End Try
            Try : oScm.close() : Catch : End Try
        End Try
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim obs As String = txtObservacion.Text.Trim()
        If obs.Length = 0 Then
            MessageBox.Show("Debes indicar un motivo en la observación para rechazar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtObservacion.Focus()
            Return
        End If

        If MessageBox.Show("¿Confirmas el rechazo de la solicitud #" & _id & "?",
                           "Confirmar rechazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim oScm As New Transaccional.Conexion("SCM")
        Try
            oScm.open()
            Dim sql As String =
                "UPDATE scm.dbo.solicitud_cambio_tipoproducto " &
                "   SET estado = 'RECHAZADA', " &
                "       usuario_aprueba = '" & gs_usuario.Replace("'", "''") & "', " &
                "       fecha_aprueba = GETDATE(), " &
                "       observacion = N'" & obs.Replace("'", "''") & "' " &
                " WHERE id = " & _id.ToString()
            oScm.Ingresa(sql)
            MessageBox.Show("Solicitud rechazada.", "Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HuboCambio = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Try : oScm.close() : Catch : End Try
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Function SafeStr(v As Object) As String
        If v Is Nothing OrElse v Is DBNull.Value Then Return ""
        Return v.ToString().Trim()
    End Function

End Class
