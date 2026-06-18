Imports System.Data
Imports System.Windows.Forms
Imports System.Collections.Generic

' =============================================================================
' Actualización de Productos IE — multi-empresa, multi-campo, escalable.
'
' Para AGREGAR un campo nuevo:
'   1. Designer: agrega chk_<columna> + txt_<columna> dentro de grpCampos
'   2. Aquí en Form_Load: agrega 1 línea a la lista Campos
'   3. Listo. Búsqueda, grid, UPDATE y log lo manejan automáticamente.
' =============================================================================
Public Class frm_actualizacionProductosIE

    Private Class CampoDef
        Public Columna As String          ' nombre real en flexline.producto
        Public Etiqueta As String         ' label visible
        Public ChkActualizar As CheckBox
        Public TxtNuevo As Control
    End Class

    ' Item para los ComboBox de busqueda: guarda codigo+glosa y muestra solo lo que corresponda
    Private Class ItemBusqueda
        Public Codigo As String
        Public Glosa As String
        Public MostrarCodigo As Boolean  ' True = mostrar codigo; False = mostrar glosa
        Public Overrides Function ToString() As String
            Return If(MostrarCodigo, Codigo, Glosa)
        End Function
    End Class

    Private Const COL_SEL As String = "_sel"
    Private Const COL_EMP As String = "_empresa"

    Private Campos As List(Of CampoDef)

    ' Cache de items completos por ComboBox (para filtrado por substring)
    Private CuentasFullList As New Dictionary(Of ComboBox, List(Of String))
    Private timerBuscarCodigo As Timer
    Private timerBuscarDesc As Timer
    Private actualizandoCampos As Boolean = False

    ' Mapeo columna ? tipo en GEN_TABCOD para validar existencia
    Private ReadOnly TiposGenTabcod As New Dictionary(Of String, String) From {
        {"tipoproducto", "GEN_TIPOPRODUCTO"},
        {"familia", "PRODUCTO.FAMILIA"},
        {"subfamilia", "PRODUCTO.SUBFAMILIA"},
        {"tipo", "producto.tipo"},
        {"subtipo", "producto.subtipo"},
        {"procedencia", "PRODUCTO.PROCEDENCIA"},
        {"AnalisisProducto4", "PRODUCTO.PROCEDENCIA"}
    }

    Private Sub frm_actualizacionProductosIE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PermisosActProductos.Cargar()

        Campos = New List(Of CampoDef) From {
            New CampoDef With {.Columna = "tipoproducto", .Etiqueta = "TIPO DE PRODUCTO", .ChkActualizar = chk_tipoproducto, .TxtNuevo = txt_tipoproducto},
            New CampoDef With {.Columna = "familia", .Etiqueta = "FAMILIA", .ChkActualizar = chk_familia, .TxtNuevo = txt_familia},
            New CampoDef With {.Columna = "subfamilia", .Etiqueta = "PROVEEDOR", .ChkActualizar = chk_subfamilia, .TxtNuevo = txt_subfamilia},
            New CampoDef With {.Columna = "tipo", .Etiqueta = "TIPO", .ChkActualizar = chk_tipo, .TxtNuevo = txt_tipo},
            New CampoDef With {.Columna = "subtipo", .Etiqueta = "MARCA", .ChkActualizar = chk_subtipo, .TxtNuevo = txt_subtipo},
            New CampoDef With {.Columna = "factoralt", .Etiqueta = "UXC", .ChkActualizar = chk_factoralt, .TxtNuevo = txt_factoralt},
            New CampoDef With {.Columna = "precioventa", .Etiqueta = "PRECIO SUGERIDO", .ChkActualizar = chk_precioventa, .TxtNuevo = txt_precioventa},
            New CampoDef With {.Columna = "volumen", .Etiqueta = "MEDIDA EN LITROS", .ChkActualizar = chk_volumen, .TxtNuevo = txt_volumen},
            New CampoDef With {.Columna = "procedencia", .Etiqueta = "PROCEDENCIA", .ChkActualizar = chk_procedencia, .TxtNuevo = txt_procedencia},
            New CampoDef With {.Columna = "AnalisisProducto4", .Etiqueta = "ORIGEN", .ChkActualizar = chk_analisisproducto4, .TxtNuevo = txt_analisisproducto4},
            New CampoDef With {.Columna = "glosa", .Etiqueta = "DESCRIPCIÓN DE PRODUCTO", .ChkActualizar = chk_glosa, .TxtNuevo = txt_glosa},
            New CampoDef With {.Columna = "vigente", .Etiqueta = "ACTIVAR/INACTIVAR PRODUCTO", .ChkActualizar = chk_vigente, .TxtNuevo = txt_vigente},
            New CampoDef With {.Columna = "AnalisisProducto17", .Etiqueta = "BU", .ChkActualizar = chk_AnalisisProducto17, .TxtNuevo = cmb_AnalisisProducto17},
            New CampoDef With {.Columna = "cuentacompra", .Etiqueta = "CUENTA COMPRA", .ChkActualizar = chk_cuentacompra, .TxtNuevo = cmb_cuentacompra},
            New CampoDef With {.Columna = "cuentaventa", .Etiqueta = "CUENTA VENTA", .ChkActualizar = chk_cuentaventa, .TxtNuevo = cmb_cuentaventa},
            New CampoDef With {.Columna = "cuentacosto", .Etiqueta = "CUENTA COSTO", .ChkActualizar = chk_cuentacosto, .TxtNuevo = cmb_cuentacosto},
            New CampoDef With {.Columna = "cuentadesc", .Etiqueta = "CUENTA DESCUENTO", .ChkActualizar = chk_cuentadesc, .TxtNuevo = cmb_cuentadesc},
            New CampoDef With {.Columna = "cuentadev", .Etiqueta = "CUENTA DEVOLUCIONES", .ChkActualizar = chk_cuentadev, .TxtNuevo = cmb_cuentadev}
        }

        ' Habilitar/deshabilitar TextBox según check
        For Each c As CampoDef In Campos
            Dim cAux As CampoDef = c
            AddHandler cAux.ChkActualizar.CheckedChanged,
                Sub(s, ev) cAux.TxtNuevo.Enabled = cAux.ChkActualizar.Checked
        Next

        ' Sombrear precioventa en amarillo pálido si valor >= 10,000 (señal visual)
        AddHandler txt_precioventa.TextChanged,
            Sub(s, ev)
                Dim v As Double = 0
                If Double.TryParse(txt_precioventa.Text.Trim().Replace(",", "."),
                                    Globalization.NumberStyles.Any,
                                    Globalization.CultureInfo.InvariantCulture, v) AndAlso v >= 10000 Then
                    txt_precioventa.BackColor = Drawing.Color.LightYellow
                Else
                    txt_precioventa.BackColor = Drawing.Color.White
                End If
            End Sub

        ' Sombrear volumen en amarillo pálido si valor >= 10 LTS
        AddHandler txt_volumen.TextChanged,
            Sub(s, ev)
                Dim v As Double = 0
                If Double.TryParse(txt_volumen.Text.Trim().Replace(",", "."),
                                    Globalization.NumberStyles.Any,
                                    Globalization.CultureInfo.InvariantCulture, v) AndAlso v >= 10 Then
                    txt_volumen.BackColor = Drawing.Color.LightYellow
                Else
                    txt_volumen.BackColor = Drawing.Color.White
                End If
            End Sub

        ' Ocultar campos para los que el usuario no tiene permiso en ninguna empresa
        For Each c As CampoDef In Campos
            Dim visible As Boolean = PermisosActProductos.ColumnaUsadaEnAlguna(c.Columna)
            c.ChkActualizar.Visible = visible
            c.TxtNuevo.Visible = visible
        Next
        ' El label informativo de vigente sigue la visibilidad del chk_vigente
        lbl_vigente_hint.Visible = chk_vigente.Visible

        ConfigurarGrid()
        CargarValoresBU()
        InicializarBuscadores()
        txtCodigo.Focus()
    End Sub

    ' Construye las columnas del DataGridView dinámicamente
    Private Sub ConfigurarGrid()
        dgvEmpresas.Columns.Clear()

        Dim colSel As New DataGridViewCheckBoxColumn()
        colSel.Name = COL_SEL : colSel.HeaderText = "" : colSel.Width = 30
        dgvEmpresas.Columns.Add(colSel)

        Dim colEmp As New DataGridViewTextBoxColumn()
        colEmp.Name = COL_EMP : colEmp.HeaderText = "Empresa" : colEmp.Width = 130 : colEmp.ReadOnly = True
        colEmp.DefaultCellStyle.Font = New Drawing.Font("Microsoft Sans Serif", 8.25!, Drawing.FontStyle.Bold)
        dgvEmpresas.Columns.Add(colEmp)

        For Each c As CampoDef In Campos
            Dim col As New DataGridViewTextBoxColumn()
            col.Name = c.Columna : col.HeaderText = c.Etiqueta : col.Width = 180 : col.ReadOnly = True
            col.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(245, 245, 245)
            dgvEmpresas.Columns.Add(col)
        Next
    End Sub

    ' Colorea la celda VIGENTE: verde palido si "S", rojo palido si "N"
    Private Sub dgvEmpresas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEmpresas.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        Dim colName As String = dgvEmpresas.Columns(e.ColumnIndex).Name
        If colName.ToLower() <> "vigente" Then Return
        Dim v As String = If(e.Value Is Nothing, "", e.Value.ToString().Trim().ToUpper())
        If v = "S" Then
            e.CellStyle.BackColor = System.Drawing.Color.FromArgb(200, 255, 200)
            e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen
            e.CellStyle.Font = New System.Drawing.Font(dgvEmpresas.Font, System.Drawing.FontStyle.Bold)
        ElseIf v = "N" Then
            e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200)
            e.CellStyle.ForeColor = System.Drawing.Color.DarkRed
            e.CellStyle.Font = New System.Drawing.Font(dgvEmpresas.Font, System.Drawing.FontStyle.Bold)
        End If
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar_Click(sender, EventArgs.Empty)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LimpiarResultados()
        Dim cod As String = txtCodigo.Text.Trim()
        ' Padding con ceros si es numerico y tiene menos de 10 digitos
        If cod.Length > 0 AndAlso cod.Length < 10 AndAlso IsNumeric(cod) Then
            cod = cod.PadLeft(10, "0"c)
        End If
        If cod.Length = 0 Then
            Estado("Ingresa un código de producto.", True)
            txtCodigo.Focus()
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            Dim clsGen As New ClasesGenerales.General

            Dim cols As New List(Of String)
            cols.Add("empresa")
            cols.Add("glosa")
            For Each c As CampoDef In Campos
                cols.Add("ISNULL(LTRIM(RTRIM(" & c.Columna & ")),'') AS [" & c.Columna & "]")
            Next
            Dim sql As String =
                "SELECT " & String.Join(", ", cols.ToArray()) &
                "  FROM flexline.producto" &
                " WHERE LTRIM(RTRIM(producto)) = '" & cod.Replace("'", "''") & "'" &
                " ORDER BY empresa"

            Dim dt As DataTable = clsGen.selectQuery("FlexLine", sql)
            clsGen = Nothing

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Estado("Producto '" & cod & "' no existe en ninguna empresa.", True)
                Return
            End If

            actualizandoCampos = True
            Try
                txtDesc.Text = dt.Rows(0)("glosa").ToString().Trim()
            Finally
                actualizandoCampos = False
            End Try

            ' Agregar TODAS las empresas al grid. Las sin permiso quedan deshabilitadas (gris, readonly)
            Dim empresasOk As HashSet(Of String) = PermisosActProductos.EmpresasConPermiso()
            Dim agregadas As Integer = 0
            Dim sinPermiso As New List(Of String)
            For Each row As DataRow In dt.Rows
                Dim emp As String = row("empresa").ToString().Trim()
                Dim tienePermiso As Boolean = (empresasOk Is Nothing) OrElse empresasOk.Contains(emp)
                Dim valores As New List(Of Object)
                valores.Add(False)                          ' _sel
                valores.Add(emp)                            ' _empresa
                For Each c As CampoDef In Campos
                    Dim v As String = row(c.Columna).ToString()
                    valores.Add(If(v = "", "(vacío)", v))
                Next
                Dim idx As Integer = dgvEmpresas.Rows.Add(valores.ToArray())
                If tienePermiso Then
                    agregadas += 1
                Else
                    sinPermiso.Add(emp)
                    ' Deshabilitar la fila: checkbox readonly + colores grises
                    Dim r As DataGridViewRow = dgvEmpresas.Rows(idx)
                    r.Cells(COL_SEL).ReadOnly = True
                    r.ReadOnly = True
                    r.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray
                    r.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray
                    r.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver
                    r.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DimGray
                    r.Cells(COL_EMP).ToolTipText = "No tienes permiso en " & emp
                End If
            Next

            Dim sufijoSinPermiso As String = ""
            If sinPermiso.Count > 0 Then
                sufijoSinPermiso = "  |  TAMBIÉN EXISTE SIN PERMISO en " & sinPermiso.Count & " empresa(s): " & String.Join(", ", sinPermiso.ToArray())
            End If

            If agregadas = 0 Then
                Estado("Producto existe en " & dt.Rows.Count & " empresa(s) pero no tienes permiso en ninguna." & sufijoSinPermiso, True)
            Else
                Estado("Producto encontrado en " & agregadas & " empresa(s) con permiso. Marca las que quieras actualizar." & sufijoSinPermiso, False)
                CargarValoresGenTabcod()
                CargarCuentasContables()
                ActualizarPermisosColumnasPorProducto()
            End If
        Catch ex As Exception
            Estado("Error al buscar: " & ex.Message, True)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ' Llena los ComboBox de las columnas mapeadas en TiposGenTabcod
    ' con los valores existentes en flexline.GEN_TABCOD para las empresas mostradas en el grid
    Private Sub CargarValoresGenTabcod()
        ' Recopilar empresas en el grid
        Dim empresas As New List(Of String)
        For Each row As DataGridViewRow In dgvEmpresas.Rows
            If row.Cells(COL_SEL).ReadOnly Then Continue For  ' ignorar empresas sin permiso
            Dim emp As String = If(row.Cells(COL_EMP).Value Is Nothing, "", row.Cells(COL_EMP).Value.ToString().Trim())
            If emp <> "" AndAlso Not empresas.Contains(emp) Then empresas.Add(emp)
        Next
        If empresas.Count = 0 Then Return

        Dim empIn As New List(Of String)
        For Each emp As String In empresas
            empIn.Add("'" & emp.Replace("'", "''") & "'")
        Next
        Dim empresasIn As String = String.Join(",", empIn.ToArray())

        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Try
            oFlex.open()
            For Each c As CampoDef In Campos
                If Not TiposGenTabcod.ContainsKey(c.Columna) Then Continue For
                Dim cmb As ComboBox = TryCast(c.TxtNuevo, ComboBox)
                If cmb Is Nothing Then Continue For
                cmb.Items.Clear()
                Dim tipo As String = TiposGenTabcod(c.Columna)
                Dim sql As String = _
                    "SELECT DISTINCT LTRIM(RTRIM(codigo)) AS codigo FROM flexline.GEN_TABCOD " & _
                    " WHERE tipo = '" & tipo.Replace("'", "''") & "' " & _
                    "   AND empresa IN (" & empresasIn & ") " & _
                    "   AND ISNULL(LTRIM(RTRIM(codigo)),'') <> '' " & _
                    " ORDER BY codigo"
                Dim dt2 As DataTable = oFlex.Obtiene(sql)
                If dt2 IsNot Nothing Then
                    For Each rr As DataRow In dt2.Rows
                        cmb.Items.Add(rr("codigo").ToString().Trim())
                    Next
                End If
            Next
        Catch
        Finally
            Try : oFlex.close() : Catch : End Try
        End Try
    End Sub

    Private Sub LimpiarResultados()
        txtDesc.Text = ""
        dgvEmpresas.Rows.Clear()
        For Each c As CampoDef In If(Campos, New List(Of CampoDef))
            c.ChkActualizar.Checked = False
            c.TxtNuevo.Text = ""
            c.TxtNuevo.Enabled = False
        Next
        txtObs.Text = ""
        lblEstado.Text = ""
    End Sub

    Private Sub btnMarcarTodo_Click(sender As Object, e As EventArgs) Handles btnMarcarTodo.Click
        For Each row As DataGridViewRow In dgvEmpresas.Rows
            If Not row.Cells(COL_SEL).ReadOnly Then row.Cells(COL_SEL).Value = True
        Next
    End Sub

    Private Sub btnDesmarcarTodo_Click(sender As Object, e As EventArgs) Handles btnDesmarcarTodo.Click
        For Each row As DataGridViewRow In dgvEmpresas.Rows
            If Not row.Cells(COL_SEL).ReadOnly Then row.Cells(COL_SEL).Value = False
        Next
    End Sub

    ' Permite que el check del grid se aplique inmediatamente
    Private Sub dgvEmpresas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvEmpresas.CurrentCellDirtyStateChanged
        If TypeOf dgvEmpresas.CurrentCell Is DataGridViewCheckBoxCell Then
            dgvEmpresas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cod As String = txtCodigo.Text.Trim()
        Dim obs As String = txtObs.Text.Trim()

        If dgvEmpresas.Rows.Count = 0 Then
            Estado("Primero busca un producto.", True)
            Return
        End If

        ' Empresas seleccionadas con sus valores actuales
        Dim filasSel As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvEmpresas.Rows
            If CBool(If(row.Cells(COL_SEL).Value, False)) Then
                filasSel.Add(row)
            End If
        Next
        If filasSel.Count = 0 Then
            Estado("Marca al menos una empresa.", True)
            Return
        End If

        ' Campos seleccionados con valor
        Dim campSel As New List(Of CampoDef)
        For Each c As CampoDef In Campos
            If c.ChkActualizar.Checked Then
                If c.TxtNuevo.Text.Trim().Length = 0 Then
                    Estado("El campo '" & c.Etiqueta & "' está marcado pero vacío.", True)
                    c.TxtNuevo.Focus()
                    Return
                End If
                campSel.Add(c)
            End If
        Next
        If campSel.Count = 0 Then
            Estado("Marca al menos un campo a actualizar.", True)
            Return
        End If

        ' Resumen
        Dim resumen As String = "Producto: " & cod & vbCrLf & vbCrLf & "Campos nuevos:" & vbCrLf
        For Each c As CampoDef In campSel
            resumen &= "  • " & c.Etiqueta & " = '" & c.TxtNuevo.Text.Trim() & "'" & vbCrLf
        Next
        resumen &= vbCrLf & "Empresas (" & filasSel.Count & "):" & vbCrLf
        For Each row As DataGridViewRow In filasSel
            resumen &= "  • " & row.Cells(COL_EMP).Value.ToString() & vbCrLf
        Next
        resumen &= vbCrLf & "¿Está seguro que desea guardar estos cambios?" & vbCrLf &
                   "Esta acción se aplicará en BD y quedará registrada en el log."

        If MessageBox.Show(resumen, "Confirmar guardado",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        ' Advertencias por valores altos (en ventana aparte, después de la confirmación)
        For Each c As CampoDef In campSel
            Dim val As Double = 0
            Dim parsed As Boolean = Double.TryParse(c.TxtNuevo.Text.Trim().Replace(",", "."),
                                                     Globalization.NumberStyles.Any,
                                                     Globalization.CultureInfo.InvariantCulture, val)
            If c.Columna = "precioventa" AndAlso parsed AndAlso val >= 10000 Then
                If MessageBox.Show("El precio sugerido ingresado es " & Format(val, "N2") & ", mayor o igual a 10,000.00." & vbCrLf & vbCrLf &
                                   "Verifica que el precio sugerido sea correcto." & vbCrLf & vbCrLf &
                                   "¿Deseas continuar?",
                                   "Precio alto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                    Return
                End If
            ElseIf c.Columna = "volumen" AndAlso parsed AndAlso val >= 10 Then
                If MessageBox.Show("El volumen ingresado es " & Format(val, "N2") & " LTS, mayor o igual a 10 LTS." & vbCrLf & vbCrLf &
                                   "Verifica que el volumen sea correcto." & vbCrLf & vbCrLf &
                                   "¿Deseas continuar?",
                                   "Volumen alto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                    Return
                End If
            End If
        Next

        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Dim oScm As Transaccional.Conexion = Nothing
        Dim okCount As Integer = 0, skipCount As Integer = 0, errCount As Integer = 0, solicitudCount As Integer = 0
        Dim errMsg As String = ""

        Try
            Cursor = Cursors.WaitCursor
            oFlex.open()
            oScm = New Transaccional.Conexion("SCM")
            oScm.open()

            For Each row As DataGridViewRow In filasSel
                Dim emp As String = row.Cells(COL_EMP).Value.ToString()
                For Each c As CampoDef In campSel
                    Dim valActual As String = row.Cells(c.Columna).Value.ToString()
                    If valActual = "(vacío)" Then valActual = ""
                    Dim valNuevo As String = c.TxtNuevo.Text.Trim()
                    If c.Columna.StartsWith("cuenta") Then
                        Dim sep As Integer = valNuevo.IndexOf(" - ")
                        If sep > 0 Then valNuevo = valNuevo.Substring(0, sep).Trim()
                    End If

                    If valActual = valNuevo Then
                        skipCount += 1
                        Continue For
                    End If

                    ' Validación de permiso por empresa+columna
                    If Not PermisosActProductos.TienePermiso(emp, c.Columna) Then
                        errCount += 1
                        errMsg &= "[" & emp & "/" & c.Columna & "] Sin permiso." & vbCrLf
                        Continue For
                    End If

                    ' Validación genérica: el valor debe existir en GEN_TABCOD con el tipo correspondiente
                    If TiposGenTabcod.ContainsKey(c.Columna) AndAlso
                       Not ExisteEnGenTabcod(emp, valNuevo, TiposGenTabcod(c.Columna), oFlex) Then
                        errCount += 1
                        errMsg &= "[" & emp & "/" & c.Columna & "] '" & valNuevo & "' no existe en GEN_TABCOD (" & TiposGenTabcod(c.Columna) & ")." & vbCrLf
                        Continue For
                    End If

                    ' Validación especial tipoproducto: si tiene IMP_DISTRIB ? ofrecer crear solicitud de aprobación
                    If c.Columna = "tipoproducto" AndAlso TieneImpuestoDistribucion(emp, valNuevo, oFlex) Then
                        Dim r As DialogResult = MessageBox.Show(
                            "El cambio de tipo de producto a '" & valNuevo & "' es CRÍTICO porque tiene impuesto de distribución (IMP_DISTRIB)." & vbCrLf & vbCrLf &
                            "Producto: " & cod & "    Empresa: " & emp & vbCrLf &
                            "Tipo actual: " & valActual & "    Tipo solicitado: " & valNuevo & vbCrLf & vbCrLf &
                            "¿Desea crear una solicitud de modificación para que Contabilidad la apruebe?" & vbCrLf &
                            "(El cambio se aplicará automáticamente al ser aprobada)",
                            "Cambio crítico", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If r = DialogResult.Yes Then
                            If CrearSolicitudCambioTipoProducto(emp, cod, valActual, valNuevo, obs, oScm) Then
                                solicitudCount += 1
                            Else
                                errCount += 1
                                errMsg &= "[" & emp & "/tipoproducto] Error creando solicitud: " & oScm.descripcion_error & vbCrLf
                            End If
                        Else
                            errCount += 1
                            errMsg &= "[" & emp & "/tipoproducto] '" & valNuevo & "' tiene IMP_DISTRIB. Cambio cancelado por el usuario." & vbCrLf
                        End If
                        Continue For
                    End If

                    ' Validación especial: cuentas contables deben existir en CON_CTACON para esa empresa
                    If c.Columna.StartsWith("cuenta") Then
                        If Not ExisteCuenta(emp, valNuevo, oFlex) Then
                            errCount += 1
                            errMsg &= "[" & emp & "/" & c.Etiqueta & "] Cuenta '" & valNuevo & "' no existe en CON_CTACON." & vbCrLf
                            Continue For
                        End If
                    End If

                    ' Validación especial: AnalisisProducto17 (BU) debe existir en la lista de BU (productos con analisisproducto17 'BU%')
                    If c.Columna = "AnalisisProducto17" Then
                        If Not ExisteBU(valNuevo, oScm) Then
                            errCount += 1
                            errMsg &= "[" & emp & "/BU] '" & valNuevo & "' no existe en la lista de BU (flexline.producto 'BU%')." & vbCrLf
                            Continue For
                        End If
                    End If

                    ' Validación especial: vigente='N' (inactivar) requiere stock=0 en todas las bodegas
                    If c.Columna = "vigente" Then
                        Dim valLimpio As String = valNuevo.Trim().ToUpper()
                        If valLimpio <> "S" AndAlso valLimpio <> "N" Then
                            errCount += 1
                            errMsg &= "[" & emp & "/vigente] Valor inválido '" & valNuevo & "'. Solo se acepta S o N." & vbCrLf
                            Continue For
                        End If
                        valNuevo = valLimpio
                        If valLimpio = "N" Then
                            Dim bodegasConStock As List(Of String) = ObtenerBodegasConStock(emp, cod, oFlex)
                            If bodegasConStock.Count > 0 Then
                                errCount += 1
                                errMsg &= "[" & emp & "/vigente] No se puede inactivar " & cod & ". Tiene existencia en bodegas: " & String.Join(" | ", bodegasConStock.ToArray()) & vbCrLf
                                Continue For
                            End If
                        End If
                    End If

                    ' Validación especial: factoralt (UXC) y glosa no se pueden actualizar si tiene movimientos en documentod
                    If (c.Columna = "factoralt" OrElse c.Columna = "glosa") AndAlso TieneMovimientosUXC(emp, cod, oFlex) Then
                        errCount += 1
                        errMsg &= "[" & emp & "/" & c.Columna & "] " & cod & " tiene movimientos en documentod (factorInventario<>0). No se puede actualizar." & vbCrLf
                        Continue For
                    End If

                    Dim sqlUpd As String =
                        "UPDATE flexline.producto " &
                        "   SET " & c.Columna & " = '" & valNuevo.Replace("'", "''") & "' " &
                        " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                        "   AND producto = '" & cod.Replace("'", "''") & "'"
                    oFlex.Ingresa(sqlUpd)
                    If oFlex.Codigo_error <> 0 Then
                        errCount += 1
                        errMsg &= "[" & emp & "/" & c.Columna & "] " & oFlex.descripcion_error & vbCrLf
                        Continue For
                    End If

                    Dim sqlLog As String =
                        "INSERT INTO scm.dbo.log_modificaciones_productos " &
                        "(empresa, cod_producto, tabla_modificada, columna_modificada, " &
                        " valor_anterior, valor_nuevo, accion, usuario, equipo, aplicacion, observacion) " &
                        "VALUES (" &
                        "'" & emp.Replace("'", "''") & "', " &
                        "'" & cod.Replace("'", "''") & "', " &
                        "'BDFlexline.flexline.producto', " &
                        "'" & c.Columna & "', " &
                        "N'" & valActual.Replace("'", "''") & "', " &
                        "N'" & valNuevo.Replace("'", "''") & "', " &
                        "'UPDATE', " &
                        "'" & gs_usuario.Replace("'", "''") & "', " &
                        "'" & gs_nombre_equipo.Replace("'", "''") & "', " &
                        "'Umbright', " &
                        If(obs.Length = 0, "NULL", "N'" & obs.Replace("'", "''") & "'") & ")"
                    oScm.Ingresa(sqlLog)
                    okCount += 1
                Next
            Next

            Dim res As String =
                "Actualizaciones aplicadas: " & okCount & vbCrLf &
                "Sin cambio (mismo valor): " & skipCount & vbCrLf &
                "Solicitudes de aprobación creadas: " & solicitudCount & vbCrLf &
                "Errores: " & errCount
            If errCount > 0 Then res &= vbCrLf & vbCrLf & errMsg

            Estado(res.Replace(vbCrLf, " | "), errCount > 0)
            MessageBox.Show(res, "Resultado", MessageBoxButtons.OK,
                            If(errCount = 0, MessageBoxIcon.Information, MessageBoxIcon.Warning))

            If okCount > 0 Then btnBuscar_Click(Nothing, EventArgs.Empty)
        Catch ex As Exception
            Estado("Error: " & ex.Message, True)
        Finally
            Cursor = Cursors.Default
            Try : oFlex.close() : Catch : End Try
            If oScm IsNot Nothing Then Try : oScm.close() : Catch : End Try
        End Try
    End Sub

    Private Sub Estado(msg As String, esError As Boolean)
        lblEstado.Text = msg
        lblEstado.ForeColor = If(esError, Drawing.Color.DarkRed, Drawing.Color.DarkBlue)
    End Sub

    ' Genérica: True si el valor existe en GEN_TABCOD para el tipo dado
    Private Function ExisteEnGenTabcod(emp As String, valor As String, tipo As String, oFlex As Transaccional.Conexion) As Boolean
        Try
            Dim sql As String =
                "SELECT TOP 1 1 FROM flexline.GEN_TABCOD " &
                " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                "   AND tipo = '" & tipo.Replace("'", "''") & "' " &
                "   AND codigo = '" & valor.Replace("'", "''") & "'"
            Dim dt As DataTable = oFlex.Obtiene(sql)
            Return (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch
            Return False
        End Try
    End Function

    ' True si el valor tiene impuesto de distribución (existe en GEN_TABCOD con tipo=IMP_DISTRIB)
    Private Function TieneImpuestoDistribucion(emp As String, valor As String, oFlex As Transaccional.Conexion) As Boolean
        Try
            Dim sql As String =
                "SELECT TOP 1 1 FROM flexline.GEN_TABCOD " &
                " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                "   AND tipo = 'IMP_DISTRIB' " &
                "   AND codigo = '" & valor.Replace("'", "''") & "'"
            Dim dt As DataTable = oFlex.Obtiene(sql)
            Return (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch
            Return True  ' por seguridad, si falla la verificación no permite actualizar
        End Try
    End Function

    ' Inserta una solicitud de cambio de tipoproducto en scm.dbo.solicitud_cambio_tipoproducto
    ' Retorna True si la inserción fue exitosa
    Private Function CrearSolicitudCambioTipoProducto(emp As String, cod As String, valActual As String, valNuevo As String, motivo As String, oScm As Transaccional.Conexion) As Boolean
        Try
            Dim glosa As String = ""
            For Each row As DataGridViewRow In dgvEmpresas.Rows
                If row.Cells(COL_EMP).Value.ToString() = emp Then
                    glosa = txtDesc.Text
                    Exit For
                End If
            Next

            Dim sql As String =
                "INSERT INTO scm.dbo.solicitud_cambio_tipoproducto " &
                "(empresa, producto, glosa, valor_anterior, valor_nuevo, estado, motivo, usuario_crea, equipo_crea) " &
                "VALUES (" &
                "'" & emp.Replace("'", "''") & "', " &
                "'" & cod.Replace("'", "''") & "', " &
                "N'" & glosa.Replace("'", "''") & "', " &
                "N'" & valActual.Replace("'", "''") & "', " &
                "N'" & valNuevo.Replace("'", "''") & "', " &
                "'PENDIENTE', " &
                If(motivo.Length = 0, "NULL", "N'" & motivo.Replace("'", "''") & "'") & ", " &
                "'" & gs_usuario.Replace("'", "''") & "', " &
                "'" & gs_nombre_equipo.Replace("'", "''") & "')"
            oScm.Ingresa(sql)
            Return (oScm.Codigo_error = 0)
        Catch
            Return False
        End Try
    End Function

    ' Devuelve lista de bodegas (con saldo) donde el producto tiene existencia != 0
    Private Function ObtenerBodegasConStock(emp As String, cod As String, oFlex As Transaccional.Conexion) As List(Of String)
        Dim lst As New List(Of String)
        Try
            Dim sql As String = _
                "SELECT bodega, SUM(cantidad*factorInventario) AS Saldo " & _
                "  FROM flexline.documentod " & _
                " WHERE empresa = '" & emp.Replace("'", "''") & "' " & _
                "   AND factorInventario <> 0 " & _
                "   AND vigente <> 'a' " & _
                "   AND producto = '" & cod.Replace("'", "''") & "' " & _
                " GROUP BY bodega " & _
                "HAVING SUM(cantidad*factorInventario) <> 0 " & _
                " ORDER BY bodega"
            Dim dt As DataTable = oFlex.Obtiene(sql)
            If dt IsNot Nothing Then
                For Each r As DataRow In dt.Rows
                    Dim bod As String = r("bodega").ToString().Trim()
                    Dim sal As Double = 0
                    Try : sal = CDbl(r("Saldo")) : Catch : End Try
                    lst.Add(bod & "=" & Format(sal, "N2"))
                Next
            End If
        Catch
        End Try
        Return lst
    End Function

    ' Devuelve True si el producto tiene movimientos en flexline.documentod con factorInventario <> 0
    Private Function TieneMovimientosUXC(emp As String, cod As String, oFlex As Transaccional.Conexion) As Boolean
        Try
            Dim sql As String =
                "SELECT TOP 1 1 FROM flexline.documentod " &
                " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                "   AND producto = '" & cod.Replace("'", "''") & "' " &
                "   AND factorInventario <> 0"
            Dim dt As DataTable = oFlex.Obtiene(sql)
            Return (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch
            Return True  ' por seguridad, si falla la verificación no permite actualizar
        End Try
    End Function

    ' Carga los BU (analisisproducto17) que empiezan con 'BU' desde flexline.producto (fuente unica de BU)
    Private Sub CargarValoresBU()
        cmb_AnalisisProducto17.Items.Clear()
        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Try
            oFlex.open()
            Dim sql As String = _
                "SELECT DISTINCT analisisproducto17 " & _
                "  FROM flexline.producto " & _
                " WHERE analisisproducto17 LIKE 'BU%' " & _
                " ORDER BY analisisproducto17"
            Dim dt As DataTable = oFlex.Obtiene(sql)
            If dt IsNot Nothing Then
                For Each r As DataRow In dt.Rows
                    cmb_AnalisisProducto17.Items.Add(r("analisisproducto17").ToString().Trim())
                Next
            End If
        Catch ex As Exception
        Finally
            Try : oFlex.close() : Catch : End Try
        End Try
    End Sub

    ' True si el valor (BU) existe en flexline.producto y empieza con 'BU' (misma lista del desplegable)
    Private Function ExisteBU(valor As String, oScm As Transaccional.Conexion) As Boolean
        Try
            Dim sql As String = _
                "SELECT TOP 1 1 FROM BDFlexline.flexline.producto " & _
                " WHERE analisisproducto17 = '" & valor.Replace("'", "''") & "' " & _
                "   AND analisisproducto17 LIKE 'BU%'"
            Dim dt As DataTable = oScm.Obtiene(sql)
            Return (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch
            Return False
        End Try
    End Function

    ' Carga las cuentas contables (CON_CTACON) de las empresas del grid en los 5 ComboBox
    Private Sub CargarCuentasContables()
        Dim empresas As New List(Of String)
        For Each row As DataGridViewRow In dgvEmpresas.Rows
            If row.Cells(COL_SEL).ReadOnly Then Continue For  ' ignorar empresas sin permiso
            Dim emp As String = If(row.Cells(COL_EMP).Value Is Nothing, "", row.Cells(COL_EMP).Value.ToString().Trim())
            If emp <> "" AndAlso Not empresas.Contains(emp) Then empresas.Add(emp)
        Next
        If empresas.Count = 0 Then Return

        Dim empIn As New List(Of String)
        For Each emp As String In empresas
            empIn.Add("'" & emp.Replace("'", "''") & "'")
        Next
        Dim items As New List(Of String)

        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Try
            oFlex.open()
            Dim sql As String = _
                "SELECT LTRIM(RTRIM(cuenta)) AS cuenta, LTRIM(RTRIM(descripcion)) AS descripcion " & _
                "  FROM BDFlexline.flexline.CON_CTACON " & _
                " WHERE empresa IN (" & String.Join(",", empIn.ToArray()) & ") " & _
                " ORDER BY cuenta"
            Dim dt As DataTable = oFlex.Obtiene(sql)
            If dt IsNot Nothing Then
                For Each rr As DataRow In dt.Rows
                    Dim cta As String = rr("cuenta").ToString().Trim()
                    Dim des As String = rr("descripcion").ToString().Trim()
                    Dim item As String = cta & " - " & des
                    If Not items.Contains(item) Then items.Add(item)
                Next
            End If
        Catch
        Finally
            Try : oFlex.close() : Catch : End Try
        End Try

        ConfigurarCmbCuenta(cmb_cuentacompra, items)
        ConfigurarCmbCuenta(cmb_cuentaventa, items)
        ConfigurarCmbCuenta(cmb_cuentacosto, items)
        ConfigurarCmbCuenta(cmb_cuentadesc, items)
        ConfigurarCmbCuenta(cmb_cuentadev, items)
    End Sub

    ' Configura un ComboBox para busqueda por substring (cuenta o descripcion)
    Private Sub ConfigurarCmbCuenta(cmb As ComboBox, items As List(Of String))
        cmb.DropDownStyle = ComboBoxStyle.DropDown
        cmb.AutoCompleteMode = AutoCompleteMode.None
        cmb.BeginUpdate()
        cmb.Items.Clear()
        cmb.Items.AddRange(items.ToArray())
        cmb.EndUpdate()
        cmb.Text = ""
        CuentasFullList(cmb) = items
        RemoveHandler cmb.KeyUp, AddressOf CmbCuenta_KeyUp
        AddHandler cmb.KeyUp, AddressOf CmbCuenta_KeyUp
    End Sub

    ' Filtra los items del combo segun el texto escrito (busqueda contains)
    Private Sub CmbCuenta_KeyUp(sender As Object, e As KeyEventArgs)
        Dim cmb As ComboBox = TryCast(sender, ComboBox)
        If cmb Is Nothing Then Return
        If Not CuentasFullList.ContainsKey(cmb) Then Return
        Select Case e.KeyCode
            Case Keys.Up, Keys.Down, Keys.Enter, Keys.Escape, Keys.Left, Keys.Right, Keys.Tab
                Return
        End Select
        Dim texto As String = cmb.Text.ToUpper().Trim()
        Dim selStart As Integer = cmb.SelectionStart
        Try
            cmb.BeginUpdate()
            cmb.Items.Clear()
            Dim full As List(Of String) = CuentasFullList(cmb)
            If texto = "" Then
                cmb.Items.AddRange(full.ToArray())
            Else
                For Each itm As String In full
                    If itm.ToUpper().Contains(texto) Then cmb.Items.Add(itm)
                Next
            End If
        Finally
            cmb.EndUpdate()
        End Try
        If cmb.Items.Count > 0 AndAlso texto.Length > 0 Then cmb.DroppedDown = True
        cmb.SelectionStart = selStart
    End Sub

    ' True si la cuenta existe en CON_CTACON para la empresa
    Private Function ExisteCuenta(emp As String, cuenta As String, oFlex As Transaccional.Conexion) As Boolean
        Try
            Dim sql As String = _
                "SELECT TOP 1 1 FROM BDFlexline.flexline.CON_CTACON " & _
                " WHERE empresa = '" & emp.Replace("'", "''") & "' " & _
                "   AND LTRIM(RTRIM(cuenta)) = '" & cuenta.Replace("'", "''") & "'"
            Dim dt As DataTable = oFlex.Obtiene(sql)
            Return (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch
            Return False
        End Try
    End Function

    ' Deshabilita el chk + control de cada columna si el usuario no tiene permiso en NINGUNA empresa del grid
    Private Sub ActualizarPermisosColumnasPorProducto()
        Dim empresasEnGrid As New List(Of String)
        For Each row As DataGridViewRow In dgvEmpresas.Rows
            If row.Cells(COL_SEL).ReadOnly Then Continue For  ' ignorar empresas sin permiso
            Dim emp As String = If(row.Cells(COL_EMP).Value Is Nothing, "", row.Cells(COL_EMP).Value.ToString().Trim())
            If emp <> "" AndAlso Not empresasEnGrid.Contains(emp) Then empresasEnGrid.Add(emp)
        Next
        For Each c As CampoDef In Campos
            If Not c.ChkActualizar.Visible Then Continue For
            Dim tienePermiso As Boolean = False
            For Each emp As String In empresasEnGrid
                If PermisosActProductos.TienePermiso(emp, c.Columna) Then
                    tienePermiso = True
                    Exit For
                End If
            Next
            c.ChkActualizar.Enabled = tienePermiso
            If Not tienePermiso Then
                c.ChkActualizar.Checked = False
                c.TxtNuevo.Enabled = False
                Try : c.TxtNuevo.Text = "" : Catch : End Try
                c.ChkActualizar.Text = c.Etiqueta
                c.ChkActualizar.ForeColor = System.Drawing.Color.Gray
            Else
                c.ChkActualizar.Text = c.Etiqueta
                c.ChkActualizar.ForeColor = System.Drawing.Color.Black
            End If
        Next
        ' Sincronizar el hint de vigente con el estado real del chk_vigente
        lbl_vigente_hint.Visible = chk_vigente.Visible AndAlso chk_vigente.Enabled
    End Sub

    ' Inicializa los timers de busqueda diferida y los handlers de cambio de texto/seleccion
    Private Sub InicializarBuscadores()
        timerBuscarCodigo = New Timer()
        timerBuscarCodigo.Interval = 350
        AddHandler timerBuscarCodigo.Tick, AddressOf TimerBuscarCodigo_Tick
        timerBuscarDesc = New Timer()
        timerBuscarDesc.Interval = 350
        AddHandler timerBuscarDesc.Tick, AddressOf TimerBuscarDesc_Tick
        AddHandler txtCodigo.TextChanged, AddressOf txtCodigo_TextChangedB
        AddHandler txtDesc.TextChanged, AddressOf txtDesc_TextChangedB
        AddHandler txtCodigo.SelectionChangeCommitted, AddressOf txtCodigo_SelChanged
        AddHandler txtDesc.SelectionChangeCommitted, AddressOf txtDesc_SelChanged
        AddHandler txtCodigo.SelectedIndexChanged, AddressOf txtCodigo_SelChanged
        AddHandler txtDesc.SelectedIndexChanged, AddressOf txtDesc_SelChanged
    End Sub

    Private Sub txtCodigo_TextChangedB(sender As Object, e As EventArgs)
        If actualizandoCampos Then Return
        timerBuscarCodigo.Stop() : timerBuscarCodigo.Start()
    End Sub

    Private Sub txtDesc_TextChangedB(sender As Object, e As EventArgs)
        If actualizandoCampos Then Return
        timerBuscarDesc.Stop() : timerBuscarDesc.Start()
    End Sub

    Private Sub TimerBuscarCodigo_Tick(sender As Object, e As EventArgs)
        timerBuscarCodigo.Stop()
        Dim texto As String = txtCodigo.Text.Trim()
        If texto.Length < 2 Then Return
        BuscarSugerencias(txtCodigo, "producto", texto, True)
    End Sub

    Private Sub TimerBuscarDesc_Tick(sender As Object, e As EventArgs)
        timerBuscarDesc.Stop()
        Dim texto As String = txtDesc.Text.Trim()
        If texto.Length < 3 Then Return
        BuscarSugerencias(txtDesc, "glosa", texto, False)
    End Sub

    ' Consulta a BD con LIKE y muestra TOP 50 en el dropdown
    ' modoPrefijo=True usa LIKE 'texto%' (rapido, indice); False usa LIKE '%texto%' (full scan)
    Private Sub BuscarSugerencias(cmb As ComboBox, columna As String, texto As String, modoPrefijo As Boolean)
        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Try
            oFlex.open()
            Dim patron As String = If(modoPrefijo, texto.Replace("'", "''") & "%", "%" & texto.Replace("'", "''") & "%")
            Dim sql As String = _
                "SELECT TOP 50 LTRIM(RTRIM(producto)) AS producto, MAX(LTRIM(RTRIM(glosa))) AS glosa " & _
                "  FROM flexline.producto " & _
                " WHERE " & columna & " LIKE '" & patron & "' " & _
                " GROUP BY producto " & _
                " ORDER BY " & columna
            Dim dt As DataTable = oFlex.Obtiene(sql)
            Dim selStart As Integer = cmb.SelectionStart
            actualizandoCampos = True
            Try
                cmb.BeginUpdate()
                cmb.Items.Clear()
                If dt IsNot Nothing Then
                    For Each rr As DataRow In dt.Rows
                        Dim cd As String = rr("producto").ToString().Trim()
                        Dim gl As String = If(rr("glosa") Is DBNull.Value, "", rr("glosa").ToString().Trim())
                        Dim it As New ItemBusqueda With {.Codigo = cd, .Glosa = gl, .MostrarCodigo = (columna = "producto")}
                        cmb.Items.Add(it)
                    Next
                End If
                cmb.EndUpdate()
            Finally
                actualizandoCampos = False
            End Try
            If cmb.Items.Count > 0 Then cmb.DroppedDown = True
            cmb.SelectionStart = selStart
        Catch
        Finally
            Try : oFlex.close() : Catch : End Try
        End Try
    End Sub

    ' Al seleccionar un codigo (mouse o teclado), llena txtDesc con la descripcion correspondiente
    Private Sub txtCodigo_SelChanged(sender As Object, e As EventArgs)
        If actualizandoCampos Then Return
        Dim it As ItemBusqueda = TryCast(txtCodigo.SelectedItem, ItemBusqueda)
        If it Is Nothing Then Return
        actualizandoCampos = True
        Try
            txtCodigo.Text = it.Codigo
            txtDesc.Text = it.Glosa
        Finally
            actualizandoCampos = False
        End Try
    End Sub

    ' Al seleccionar una descripcion (mouse o teclado), llena txtCodigo con el codigo correspondiente
    Private Sub txtDesc_SelChanged(sender As Object, e As EventArgs)
        If actualizandoCampos Then Return
        Dim it As ItemBusqueda = TryCast(txtDesc.SelectedItem, ItemBusqueda)
        If it Is Nothing Then Return
        actualizandoCampos = True
        Try
            txtDesc.Text = it.Glosa
            txtCodigo.Text = it.Codigo
        Finally
            actualizandoCampos = False
        End Try
    End Sub

End Class
