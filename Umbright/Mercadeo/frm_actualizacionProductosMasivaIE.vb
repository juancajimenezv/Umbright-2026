Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports GemBox.Spreadsheet

' =============================================================================
' Actualización Masiva IE
' Sube un Excel con 2 columnas (producto, valor) y actualiza una columna
' específica de flexline.producto para una empresa seleccionada.
'
' Para agregar otra columna actualizable a futuro: agregar el nombre a
' CargarColumnasDisponibles (el resto es genérico).
' =============================================================================
Public Class frm_actualizacionProductosMasivaIE

    Private Const COL_PROD As String = "producto"
    Private Const COL_VALOR_NUEVO As String = "valor_nuevo"
    Private Const COL_GLOSA As String = "glosa"
    Private Const COL_VALOR_ACTUAL As String = "valor_actual"
    Private Const COL_ESTADO As String = "estado"

    Private datosCargados As Boolean = False
    Private validado As Boolean = False

    ' Mapeo columna → tipo en GEN_TABCOD
    Private ReadOnly TiposGenTabcod As New Dictionary(Of String, String) From {
        {"tipoproducto", "GEN_TIPOPRODUCTO"},
        {"familia", "PRODUCTO.FAMILIA"},
        {"subfamilia", "PRODUCTO.SUBFAMILIA"},
        {"tipo", "producto.tipo"},
        {"subtipo", "producto.subtipo"},
        {"procedencia", "PRODUCTO.PROCEDENCIA"},
        {"analisisproducto4", "PRODUCTO.PROCEDENCIA"}
    }

    Private Sub frm_actualizacionProductosMasivaIE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Try
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")
            Catch
            End Try

            PermisosActProductos.Cargar()
            CargarEmpresas()
            ActualizarColumnasDisponibles()  ' depende de cmbEmpresa
            ConfigurarGrid()
        Catch ex As Exception
            MessageBox.Show("Error al cargar: " & ex.Message)
        End Try
    End Sub

    ' Cuando cambia la empresa, refrescar columnas disponibles según permisos
    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        ActualizarColumnasDisponibles()
    End Sub

    Private Sub CargarEmpresas()
        Dim clsGen As New ClasesGenerales.General
        Try
            Dim dt As DataTable = clsGen.selectQuery("FlexLine",
                "SELECT DISTINCT empresa FROM flexline.producto ORDER BY empresa")
            cmbEmpresa.Items.Clear()
            Dim empresasOk As HashSet(Of String) = PermisosActProductos.EmpresasConPermiso()
            For Each row As DataRow In dt.Rows
                Dim emp As String = row(0).ToString().Trim()
                If empresasOk IsNot Nothing AndAlso Not empresasOk.Contains(emp) Then Continue For
                cmbEmpresa.Items.Add(emp)
            Next
            For i As Integer = 0 To cmbEmpresa.Items.Count - 1
                If cmbEmpresa.Items(i).ToString() = gs_empresa Then
                    cmbEmpresa.SelectedIndex = i
                    Exit For
                End If
            Next
            If cmbEmpresa.SelectedIndex < 0 AndAlso cmbEmpresa.Items.Count > 0 Then
                cmbEmpresa.SelectedIndex = 0
            End If
        Catch
        Finally
            clsGen = Nothing
        End Try
    End Sub

    ' Lista maestra de todas las columnas con su label visible
    ' Mapeo etiqueta visible → nombre real de columna en flexline.producto
    Private ReadOnly EtiquetaAColumna As New Dictionary(Of String, String) From {
        {"TIPO DE PRODUCTO", "tipoproducto"},
        {"FAMILIA", "familia"},
        {"PROVEEDOR", "subfamilia"},
        {"TIPO", "tipo"},
        {"SUBTIPO", "subtipo"},
        {"UXC", "factoralt"},
        {"PRECIO SUGERIDO", "precioventa"},
        {"MEDIDA EN LITROS", "volumen"},
        {"PROCEDENCIA", "procedencia"},
        {"ORIGEN", "AnalisisProducto4"},
        {"DESCRIPCIÓN DE PRODUCTO", "glosa"},
        {"ACTIVAR/INACTIVAR PRODUCTO", "vigente"},
        {"BU", "AnalisisProducto17"},
        {"CUENTA COMPRA", "cuentacompra"},
        {"CUENTA VENTA", "cuentaventa"},
        {"CUENTA COSTO", "cuentacosto"},
        {"CUENTA DESCUENTO", "cuentadesc"},
        {"CUENTA DEVOLUCIONES", "cuentadev"}
    }

    Private Function TodasLasColumnas() As List(Of String)
        Return New List(Of String) From {
            "TIPO DE PRODUCTO", "FAMILIA", "PROVEEDOR", "TIPO", "SUBTIPO",
            "UXC", "PRECIO SUGERIDO", "MEDIDA EN LITROS",
            "PROCEDENCIA", "ORIGEN", "DESCRIPCIÓN DE PRODUCTO", "ACTIVAR/INACTIVAR PRODUCTO", "BU",
            "CUENTA COMPRA", "CUENTA VENTA", "CUENTA COSTO", "CUENTA DESCUENTO", "CUENTA DEVOLUCIONES"
        }
    End Function

    ' Refresca cmbColumna según la empresa seleccionada y los permisos del usuario
    Private Sub ActualizarColumnasDisponibles()
        cmbColumna.Items.Clear()
        Dim emp As String = If(cmbEmpresa.SelectedItem, "").ToString()
        Dim colsOk As HashSet(Of String) = PermisosActProductos.ColumnasConPermiso(emp)
        For Each item As String In TodasLasColumnas()
            Dim colReal As String = ColumnaReal(item)
            If colsOk Is Nothing OrElse colsOk.Contains(colReal) Then
                cmbColumna.Items.Add(item)
            End If
        Next
        If cmbColumna.Items.Count > 0 Then cmbColumna.SelectedIndex = 0
        ActualizarHintVigente()
    End Sub

    ' Muestra el label informativo solo cuando la columna seleccionada es vigente
    Private Sub ActualizarHintVigente()
        Dim mostrar As Boolean = False
        Dim texto As String = ""
        If cmbColumna.SelectedItem IsNot Nothing Then
            Dim col As String = ColumnaReal(cmbColumna.SelectedItem.ToString())
            If col = "vigente" Then
                mostrar = True
                texto = """S"" ACTIVAR    ""N"" INACTIVAR"
            ElseIf col = "AnalisisProducto17" Then
                mostrar = True
                texto = "El BU debe existir en SCM.dbo.BU_Empresa (cualquier empresa)"
            End If
        End If
        lbl_vigente_hint.Text = texto
        lbl_vigente_hint.Visible = mostrar
    End Sub

    Private Sub cmbColumna_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColumna.SelectedIndexChanged
        ActualizarHintVigente()
    End Sub

    ' "TIPO DE PRODUCTO" -> "tipoproducto"  ·  "UXC" -> "factoralt"
    Private Function ColumnaReal(item As String) As String
        If item Is Nothing Then Return ""
        If EtiquetaAColumna.ContainsKey(item) Then Return EtiquetaAColumna(item)
        Return item.Trim().ToLower()
    End Function

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
            Return True
        End Try
    End Function

    ' True si el producto tiene movimientos en flexline.documentod con factorInventario <> 0
    ' Devuelve lista de bodegas con saldo != 0 para el producto
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

    ' True si el BU existe en SCM.dbo.BU_Empresa (cualquier empresa)
    Private Function ExisteBU(valor As String, oScm As Transaccional.Conexion) As Boolean
        Try
            Dim sql As String = _
                "SELECT TOP 1 1 FROM SCM.dbo.BU_Empresa " & _
                " WHERE AnalisisProducto17 = '" & valor.Replace("'", "''") & "'"
            Dim dt As DataTable = oScm.Obtiene(sql)
            Return (dt IsNot Nothing AndAlso dt.Rows.Count > 0)
        Catch
            Return False
        End Try
    End Function

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
            Return True
        End Try
    End Function

    Private Sub ConfigurarGrid()
        dgvDatos.Columns.Clear()
        dgvDatos.Columns.Add(NewCol(COL_PROD, "Producto", 110))
        dgvDatos.Columns.Add(NewCol(COL_GLOSA, "Descripción", 220))
        dgvDatos.Columns.Add(NewCol(COL_VALOR_ACTUAL, "Valor actual", 130))
        dgvDatos.Columns.Add(NewCol(COL_VALOR_NUEVO, "Valor nuevo", 130))
        dgvDatos.Columns.Add(NewCol(COL_ESTADO, "Estado", 90))
    End Sub

    Private Function NewCol(name As String, header As String, width As Integer) As DataGridViewTextBoxColumn
        Dim c As New DataGridViewTextBoxColumn() With {.Name = name, .HeaderText = header, .Width = width, .ReadOnly = True}
        Return c
    End Function

    Private Sub btnCargarExcel_Click(sender As Object, e As EventArgs) Handles btnCargarExcel.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Excel|*.xlsx;*.xls;*.csv"
            ofd.Title = "Selecciona el archivo Excel"
            If ofd.ShowDialog() <> DialogResult.OK Then Return

            Try
                Cursor = Cursors.WaitCursor
                LimpiarGrid()
                btnAplicar.Enabled = False
                validado = False

                Dim wb As ExcelFile = ExcelFile.Load(ofd.FileName)
                Dim ws As ExcelWorksheet = wb.Worksheets(0)

                ' Detectar si fila 0 es encabezado (contiene 'producto'/'codigo'/'código')
                Dim primA As String = SafeCell(ws, 0, 0).ToLower()
                Dim tieneEncabezado As Boolean = (primA.Contains("producto") OrElse primA.Contains("codigo") OrElse primA.Contains("código"))
                Dim row As Integer = If(tieneEncabezado, 1, 0)
                Dim cargados As Integer = 0
                Do
                    Dim cellProd As String = SafeCell(ws, row, 0)
                    Dim cellVal As String = SafeCell(ws, row, 1)
                    If cellProd = "" AndAlso cellVal = "" Then Exit Do

                    ' Padding: si es numérico y tiene menos de 10 dígitos, completar con ceros a la izquierda
                    If cellProd <> "" AndAlso IsNumeric(cellProd) AndAlso cellProd.Length < 10 Then
                        cellProd = cellProd.PadLeft(10, "0"c)
                    End If

                    Dim r As Integer = dgvDatos.Rows.Add()
                    dgvDatos.Rows(r).Cells(COL_PROD).Value = cellProd
                    dgvDatos.Rows(r).Cells(COL_VALOR_NUEVO).Value = cellVal.ToUpper()
                    dgvDatos.Rows(r).Cells(COL_ESTADO).Value = "(pendiente)"
                    cargados += 1
                    row += 1
                    If row > 50000 Then Exit Do
                Loop

                lblArchivo.Text = Path.GetFileName(ofd.FileName) & "  (" & cargados & " filas)"
                lblArchivo.ForeColor = System.Drawing.Color.Black
                datosCargados = (cargados > 0)
                Estado("Excel cargado. Selecciona Empresa y Columna, luego presiona Validar.", False)
            Catch ex As Exception
                Estado("Error al leer Excel: " & ex.Message, True)
            Finally
                Cursor = Cursors.Default
            End Try
        End Using
    End Sub

    Private Function SafeCell(ws As ExcelWorksheet, r As Integer, c As Integer) As String
        Try
            Dim v As Object = ws.Cells(r, c).Value
            If v Is Nothing Then Return ""
            Return v.ToString().Trim()
        Catch
            Return ""
        End Try
    End Function

    Private Sub LimpiarGrid()
        dgvDatos.Rows.Clear()
    End Sub

    Private Sub btnValidar_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        If Not datosCargados Then
            Estado("Primero carga un Excel.", True)
            Return
        End If
        If cmbEmpresa.SelectedItem Is Nothing Then
            Estado("Selecciona una empresa.", True)
            Return
        End If
        If cmbColumna.SelectedItem Is Nothing Then
            Estado("Selecciona la columna a actualizar.", True)
            Return
        End If

        Dim emp As String = cmbEmpresa.SelectedItem.ToString()
        Dim col As String = ColumnaReal(cmbColumna.SelectedItem.ToString())

        Try
            Cursor = Cursors.WaitCursor
            Dim clsGen As New ClasesGenerales.General
            Dim okCount As Integer = 0, notFoundCount As Integer = 0, sameCount As Integer = 0

            For Each row As DataGridViewRow In dgvDatos.Rows
                Dim cod As String = SafeStr(row.Cells(COL_PROD).Value)
                Dim valNuevo As String = SafeStr(row.Cells(COL_VALOR_NUEVO).Value)

                If cod = "" Then
                    row.Cells(COL_ESTADO).Value = "Sin código"
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                    notFoundCount += 1
                    Continue For
                End If

                Dim sql As String =
                    "SELECT TOP 1 glosa, ISNULL(LTRIM(RTRIM(" & col & ")),'') AS val " &
                    "  FROM flexline.producto " &
                    " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                    "   AND LTRIM(RTRIM(producto)) = '" & cod.Replace("'", "''") & "'"
                Dim dt As DataTable = clsGen.selectQuery("FlexLine", sql)

                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    row.Cells(COL_GLOSA).Value = ""
                    row.Cells(COL_VALOR_ACTUAL).Value = ""
                    row.Cells(COL_ESTADO).Value = "No existe"
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                    notFoundCount += 1
                Else
                    Dim glosa As String = dt.Rows(0)("glosa").ToString().Trim()
                    Dim valActual As String = dt.Rows(0)("val").ToString()
                    row.Cells(COL_GLOSA).Value = glosa
                    row.Cells(COL_VALOR_ACTUAL).Value = valActual
                    If valActual = valNuevo Then
                        row.Cells(COL_ESTADO).Value = "Sin cambio"
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow
                        sameCount += 1
                    Else
                        row.Cells(COL_ESTADO).Value = "Listo"
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew
                        okCount += 1
                    End If
                End If
            Next

            clsGen = Nothing
            validado = True
            btnAplicar.Enabled = (okCount > 0)
            Estado("Validado: " & okCount & " listos | " & sameCount & " sin cambio | " & notFoundCount & " con problemas. " &
                   If(okCount > 0, "Puedes Aplicar.", "No hay nada que aplicar."),
                   notFoundCount > 0 AndAlso okCount = 0)
        Catch ex As Exception
            Estado("Error al validar: " & ex.Message, True)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        If Not validado Then
            Estado("Primero presiona Validar.", True)
            Return
        End If

        Dim emp As String = cmbEmpresa.SelectedItem.ToString()
        Dim col As String = ColumnaReal(cmbColumna.SelectedItem.ToString())
        Dim obs As String = txtObs.Text.Trim()

        Dim listos As Integer = 0
        For Each row As DataGridViewRow In dgvDatos.Rows
            If SafeStr(row.Cells(COL_ESTADO).Value) = "Listo" Then listos += 1
        Next

        ' Advertencias por valores altos (precioventa >= 10000, volumen >= 10)
        If col = "precioventa" OrElse col = "volumen" Then
            Dim umbral As Double = If(col = "precioventa", 10000.0, 10.0)
            Dim desc As String = If(col = "precioventa", "precio sugerido mayor o igual a 10,000.00", "volumen mayor o igual a 10 LTS")
            Dim titulo As String = If(col = "precioventa", "Precios altos detectados", "Volúmenes altos detectados")
            Dim verifica As String = If(col = "precioventa", "Verifica que los precios sugeridos sean correctos.", "Verifica que los volúmenes sean correctos.")

            Dim conValorAlto As Integer = 0
            For Each row As DataGridViewRow In dgvDatos.Rows
                If SafeStr(row.Cells(COL_ESTADO).Value) <> "Listo" Then Continue For
                Dim val As Double = 0
                If Double.TryParse(SafeStr(row.Cells(COL_VALOR_NUEVO).Value).Replace(",", "."),
                                    Globalization.NumberStyles.Any,
                                    Globalization.CultureInfo.InvariantCulture, val) AndAlso val >= umbral Then
                    conValorAlto += 1
                End If
            Next
            If conValorAlto > 0 Then
                If MessageBox.Show(conValorAlto & " producto(s) tienen " & desc & "." & vbCrLf & vbCrLf &
                                   verifica & vbCrLf & vbCrLf &
                                   "¿Deseas continuar?",
                                   titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                    Return
                End If
            End If
        End If

        If MessageBox.Show("¿Está seguro que desea guardar estos cambios?" & vbCrLf & vbCrLf &
                           "Se actualizará la columna '" & col & "' en " & listos & " producto(s)" & vbCrLf &
                           "de la empresa '" & emp & "'." & vbCrLf & vbCrLf &
                           "Esta acción se aplicará en BD y quedará registrada en el log.",
                           "Confirmar guardado",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim oFlex As New Transaccional.Conexion("FlexLine")
        Dim oScm As Transaccional.Conexion = Nothing
        Dim okCount As Integer = 0, errCount As Integer = 0
        Dim errMsg As String = ""

        Try
            Cursor = Cursors.WaitCursor
            oFlex.open()
            oScm = New Transaccional.Conexion("SCM")
            oScm.open()

            For Each row As DataGridViewRow In dgvDatos.Rows
                If SafeStr(row.Cells(COL_ESTADO).Value) <> "Listo" Then Continue For

                Dim cod As String = SafeStr(row.Cells(COL_PROD).Value)
                Dim valActual As String = SafeStr(row.Cells(COL_VALOR_ACTUAL).Value)
                Dim valNuevo As String = SafeStr(row.Cells(COL_VALOR_NUEVO).Value)

                ' Validación de permiso por empresa+columna
                If Not PermisosActProductos.TienePermiso(emp, col) Then
                    errCount += 1
                    errMsg &= "[" & cod & "] sin permiso para columna '" & col & "' en empresa " & emp & vbCrLf
                    row.Cells(COL_ESTADO).Value = "Sin permiso"
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                    Continue For
                End If

                ' Validación genérica: existencia en GEN_TABCOD según el tipo de columna
                If TiposGenTabcod.ContainsKey(col) AndAlso
                   Not ExisteEnGenTabcod(emp, valNuevo, TiposGenTabcod(col), oFlex) Then
                    errCount += 1
                    errMsg &= "[" & cod & "] '" & valNuevo & "' no existe en GEN_TABCOD (" & TiposGenTabcod(col) & ")." & vbCrLf
                    row.Cells(COL_ESTADO).Value = "Valor inválido"
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                    Continue For
                End If

                ' Validación especial tipoproducto: NO debe tener impuesto de distribución
                If col = "tipoproducto" AndAlso TieneImpuestoDistribucion(emp, valNuevo, oFlex) Then
                    errCount += 1
                    errMsg &= "[" & cod & "] '" & valNuevo & "' tiene impuesto de distribución (IMP_DISTRIB). No se asigna." & vbCrLf
                    row.Cells(COL_ESTADO).Value = "Con IMP_DISTRIB"
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                    Continue For
                End If

                ' Validación especial: cuentas contables deben existir en CON_CTACON para la empresa
                If col.StartsWith("cuenta") Then
                    If Not ExisteCuenta(emp, valNuevo, oFlex) Then
                        errCount += 1
                        errMsg &= "[" & cod & "] Cuenta '" & valNuevo & "' no existe en CON_CTACON para " & emp & vbCrLf
                        row.Cells(COL_ESTADO).Value = "Cuenta inválida"
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                        Continue For
                    End If
                End If

                ' Validación especial: AnalisisProducto17 (BU) debe existir en SCM.dbo.BU_Empresa (cualquier empresa)
                If col = "AnalisisProducto17" Then
                    If Not ExisteBU(valNuevo, oScm) Then
                        errCount += 1
                        errMsg &= "[" & cod & "] BU '" & valNuevo & "' no existe en SCM.dbo.BU_Empresa." & vbCrLf
                        row.Cells(COL_ESTADO).Value = "BU inválido"
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                        Continue For
                    End If
                End If

                ' Validación especial: vigente='N' (inactivar) requiere stock=0 en todas las bodegas
                If col = "vigente" Then
                    Dim valLimpio As String = valNuevo.Trim().ToUpper()
                    If valLimpio <> "S" AndAlso valLimpio <> "N" Then
                        errCount += 1
                        errMsg &= "[" & cod & "] Valor '" & valNuevo & "' inválido. Solo S o N." & vbCrLf
                        row.Cells(COL_ESTADO).Value = "Valor inválido"
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                        Continue For
                    End If
                    valNuevo = valLimpio
                    If valLimpio = "N" Then
                        Dim bodegasConStock As List(Of String) = ObtenerBodegasConStock(emp, cod, oFlex)
                        If bodegasConStock.Count > 0 Then
                            errCount += 1
                            errMsg &= "[" & cod & "] No se puede inactivar. Existencia en: " & String.Join(" | ", bodegasConStock.ToArray()) & vbCrLf
                            row.Cells(COL_ESTADO).Value = "Con stock"
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                            Continue For
                        End If
                    End If
                End If

                ' Validación especial: factoralt (UXC) y glosa no se actualizan si tienen movimientos en documentod
                If (col = "factoralt" OrElse col = "glosa") AndAlso TieneMovimientosUXC(emp, cod, oFlex) Then
                    errCount += 1
                    errMsg &= "[" & cod & "] tiene movimientos en documentod (factorInventario<>0). No se actualiza " & col & "." & vbCrLf
                    row.Cells(COL_ESTADO).Value = "Con movimiento"
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
                    Continue For
                End If

                Dim sqlUpd As String =
                    "UPDATE flexline.producto " &
                    "   SET " & col & " = '" & valNuevo.Replace("'", "''") & "' " &
                    " WHERE empresa = '" & emp.Replace("'", "''") & "' " &
                    "   AND producto = '" & cod.Replace("'", "''") & "'"
                oFlex.Ingresa(sqlUpd)
                If oFlex.Codigo_error <> 0 Then
                    errCount += 1
                    errMsg &= "[" & cod & "] " & oFlex.descripcion_error & vbCrLf
                    row.Cells(COL_ESTADO).Value = "Error"
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
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
                    "'" & col & "', " &
                    "N'" & valActual.Replace("'", "''") & "', " &
                    "N'" & valNuevo.Replace("'", "''") & "', " &
                    "'UPDATE-MASIVO', " &
                    "'" & gs_usuario.Replace("'", "''") & "', " &
                    "'" & gs_nombre_equipo.Replace("'", "''") & "', " &
                    "'Umbright', " &
                    If(obs.Length = 0, "NULL", "N'" & obs.Replace("'", "''") & "'") & ")"
                oScm.Ingresa(sqlLog)

                row.Cells(COL_ESTADO).Value = "OK"
                row.Cells(COL_VALOR_ACTUAL).Value = valNuevo
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen
                okCount += 1
            Next

            Dim res As String = "Aplicados: " & okCount & " | Errores: " & errCount
            If errCount > 0 Then res &= vbCrLf & vbCrLf & errMsg
            Estado(res, errCount > 0)
            MessageBox.Show(res, "Resultado", MessageBoxButtons.OK,
                            If(errCount = 0, MessageBoxIcon.Information, MessageBoxIcon.Warning))
            btnAplicar.Enabled = False
        Catch ex As Exception
            Estado("Error: " & ex.Message, True)
        Finally
            Cursor = Cursors.Default
            Try : oFlex.close() : Catch : End Try
            If oScm IsNot Nothing Then Try : oScm.close() : Catch : End Try
        End Try
    End Sub

    ' Colorea el COL_VALOR_ACTUAL en verde/rojo cuando la columna a actualizar es vigente (S/N)
    Private Sub dgvDatos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDatos.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If cmbColumna Is Nothing OrElse cmbColumna.SelectedItem Is Nothing Then Return
        Dim col As String = ColumnaReal(cmbColumna.SelectedItem.ToString())
        If col <> "vigente" Then Return
        Dim colName As String = dgvDatos.Columns(e.ColumnIndex).Name
        If colName <> COL_VALOR_ACTUAL AndAlso colName <> COL_VALOR_NUEVO Then Return
        Dim v As String = If(e.Value Is Nothing, "", e.Value.ToString().Trim().ToUpper())
        If v = "S" Then
            e.CellStyle.BackColor = System.Drawing.Color.FromArgb(200, 255, 200)
            e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen
            e.CellStyle.Font = New System.Drawing.Font(dgvDatos.Font, System.Drawing.FontStyle.Bold)
        ElseIf v = "N" Then
            e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200)
            e.CellStyle.ForeColor = System.Drawing.Color.DarkRed
            e.CellStyle.Font = New System.Drawing.Font(dgvDatos.Font, System.Drawing.FontStyle.Bold)
        End If
    End Sub

    Private Function SafeStr(o As Object) As String
        If o Is Nothing OrElse o Is DBNull.Value Then Return ""
        Return o.ToString().Trim()
    End Function

    Private Sub Estado(msg As String, esError As Boolean)
        lblEstado.Text = msg
        lblEstado.ForeColor = If(esError, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkBlue)
    End Sub

End Class
