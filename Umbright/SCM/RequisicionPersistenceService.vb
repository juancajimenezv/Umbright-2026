Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic

''' <summary>
''' Guarda una RequisicionCabeceraDraft ya validada usando exactamente la misma secuencia de
''' stored procedures que frmRequisiciones.vb:571-668 (guardarRequisicion), para que las
''' requisiciones generadas por el módulo de IA entren al mismo workflow de aprobación
''' (Estado 10, "Esperando Revisión") sin ningún atajo.
''' No modifica frmRequisiciones.vb; es una extracción paralela del mismo flujo.
''' </summary>
Public Class RequisicionPersistenceService

    Public Class ResultadoGuardado
        Public Property Numero As String
        Public Property Correlativo As String
        Public Property Errores As New List(Of String)
        Public ReadOnly Property Exitoso As Boolean
            Get
                Return Errores.Count = 0
            End Get
        End Property
    End Class

    ''' <summary>
    ''' Guarda cabecera + detalle + distribuciones (CC/Marca/Gasto/Canal) de una requisición.
    ''' Se asume que RequisicionValidator.ValidarRequisicion(cab) ya devolvió cero errores.
    ''' </summary>
    Public Function GuardarRequisicion(cab As RequisicionCabeceraDraft, empresa As String, usuario As String) As ResultadoGuardado
        Dim resultado As New ResultadoGuardado
        Dim oTrans As New Transaccional.Conexion("SCM")
        Dim sql As String
        Dim dt As DataTable

        Try
            oTrans.open()

            ' --- Número de requisición (pa_var_um_numero_requisicion) — frmRequisiciones.vb:583-586 ---
            sql = "pa_var_um_numero_requisicion '" & RequisicionSqlUtil.EscaparSql(empresa) & "'"
            dt = oTrans.Obtiene(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                resultado.Errores.Add("No se pudo generar el número de requisición.")
                Return resultado
            End If
            Dim numero As String = dt.Rows(0).Item("numero").ToString.PadLeft(10, "0"c)

            ' --- Cabecera (pa_ins_um_requisicion) — frmRequisiciones.vb:588-594 ---
            sql = "pa_ins_um_requisicion '" & RequisicionSqlUtil.EscaparSql(empresa) & "','" & numero & "','" &
                  cab.FechaEntrega.ToString("yyyy-MM-dd") & "','" & RequisicionSqlUtil.EscaparSql(cab.LugarEntrega) & "'," &
                  "'" & RequisicionSqlUtil.EscaparSql(cab.Observaciones) & "','" & RequisicionSqlUtil.EscaparSql(cab.Proveedor) & "','" &
                  RequisicionSqlUtil.EscaparSql(usuario) & "','" & RequisicionSqlUtil.EscaparSql(cab.Moneda).ToUpper & "','" &
                  RequisicionSqlUtil.EscaparSql(cab.Anticipo).ToUpper & "','" & RequisicionSqlUtil.EscaparSql(cab.Cadena).ToUpper & "'," &
                  If(cab.Anticipo IsNot Nothing AndAlso cab.Anticipo.ToUpper = "SI", cab.MontoAnticipo, 0).ToString(Globalization.CultureInfo.InvariantCulture) &
                  ",'" & RequisicionSqlUtil.EscaparSql(cab.AfectaInventario).ToUpper & "'"

            oTrans.Ingresa(sql)
            If oTrans.Codigo_error > 0 Then
                resultado.Errores.Add("Error al guardar la requisición: " & oTrans.descripcion_error)
                Return resultado
            End If

            ' --- Correlativo recién creado (pa_sel_um_requisicion) — frmRequisiciones.vb:600-602 ---
            sql = "pa_sel_um_requisicion '" & RequisicionSqlUtil.EscaparSql(empresa) & "','" & numero & "'"
            dt = oTrans.Obtiene(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                resultado.Errores.Add("La requisición se creó pero no se pudo recuperar su correlativo.")
                Return resultado
            End If
            Dim correlativo As String = dt.Rows(0).Item("correlativo").ToString

            ' --- Detalle por línea + distribución ÚNICA (CC/Marca/Gasto/Canal de la cabecera,
            ' replicada a cada línea) — igual que frmRequisiciones.vb:600-649, donde el guardado
            ' siempre toma la distribución de `linea = min(linea)` para TODAS las líneas.
            For Each linea In cab.Lineas
                sql = "pa_ins_um_requisiciond '" & RequisicionSqlUtil.EscaparSql(empresa) & "'," & correlativo & "," &
                      linea.Linea & ",'" & RequisicionSqlUtil.EscaparSql(linea.Codigo) & "'," &
                      linea.Cantidad.ToString(Globalization.CultureInfo.InvariantCulture) & "," &
                      linea.Precio.ToString(Globalization.CultureInfo.InvariantCulture) & ",'" &
                      RequisicionSqlUtil.EscaparSql(linea.Observaciones) & "'"
                oTrans.Ingresa(sql)
                If oTrans.Codigo_error > 0 Then
                    resultado.Errores.Add($"Error al guardar la línea {linea.Linea}: " & oTrans.descripcion_error)
                    Return resultado
                End If

                For Each cc In cab.CentrosCosto
                    sql = "pa_ins_um_requisicion_Costo '" & RequisicionSqlUtil.EscaparSql(empresa) & "'," & correlativo & ",'" &
                          RequisicionSqlUtil.EscaparSql(linea.Codigo) & "','" & RequisicionSqlUtil.EscaparSql(cc.Codigo) & "'," &
                          cc.Porcentaje.ToString(Globalization.CultureInfo.InvariantCulture) & "," & linea.Linea
                    oTrans.Ingresa(sql)
                Next

                For Each marca In cab.Marcas
                    sql = "pa_ins_um_requisicion_marca '" & RequisicionSqlUtil.EscaparSql(empresa) & "'," & correlativo & ",'" &
                          RequisicionSqlUtil.EscaparSql(linea.Codigo) & "','" & RequisicionSqlUtil.EscaparSql(marca.Codigo) & "'," &
                          marca.Porcentaje.ToString(Globalization.CultureInfo.InvariantCulture) & "," &
                          If(marca.PorcentajeEmpresa, 0).ToString(Globalization.CultureInfo.InvariantCulture) & "," &
                          If(marca.PorcentajeSocio, 0).ToString(Globalization.CultureInfo.InvariantCulture) & "," & linea.Linea
                    oTrans.Ingresa(sql)
                Next

                For Each gasto In cab.Gastos
                    sql = "pa_ins_um_requisicion_gasto '" & RequisicionSqlUtil.EscaparSql(empresa) & "'," & correlativo & ",'" &
                          RequisicionSqlUtil.EscaparSql(linea.Codigo) & "','" & RequisicionSqlUtil.EscaparSql(gasto.Codigo) & "'," &
                          gasto.Porcentaje.ToString(Globalization.CultureInfo.InvariantCulture) & ",'" &
                          RequisicionSqlUtil.EscaparSql(cab.TipoGasto) & "'," & linea.Linea
                    oTrans.Ingresa(sql)
                Next

                For Each canal In cab.Canales
                    sql = "pa_ins_um_requisicion_canal '" & RequisicionSqlUtil.EscaparSql(empresa) & "'," & correlativo & ",'" &
                          RequisicionSqlUtil.EscaparSql(canal.Codigo) & "'," & canal.Porcentaje.ToString(Globalization.CultureInfo.InvariantCulture)
                    oTrans.Ingresa(sql)
                Next
            Next

            resultado.Numero = numero
            resultado.Correlativo = correlativo

        Catch ex As Exception
            resultado.Errores.Add("Excepción al guardar la requisición: " & ex.Message)
        Finally
            oTrans.close()
        End Try

        Return resultado
    End Function

End Class
