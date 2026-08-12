Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' Replica, sin dependencia de UI, las reglas de validación que hoy viven en:
''' - frmRequisiciones.vb:2069-2177 (validarGuardar - reglas de cabecera)
''' - frmRequisiconesDetalle.vb:399-529 (validación de CC/Marca/Gasto/Canal por línea)
''' Cualquier cambio a esas reglas de negocio debe reflejarse también aquí (y viceversa)
''' para que el módulo de IA nunca guarde algo que el flujo manual hubiera rechazado.
''' </summary>
Public Class RequisicionValidator

    Private Const TOLERANCIA_PORCENTAJE As Double = 0.01

    Private Shared Function SumaPorcentaje(items As List(Of RequisicionDimensionDraft)) As Double
        Dim total As Double = 0
        For Each item In items
            If item.Porcentaje > 0 Then total += item.Porcentaje
        Next
        Return total
    End Function

    Private Shared Function No100(total As Double) As Boolean
        Return Math.Abs(total - 100) > TOLERANCIA_PORCENTAJE
    End Function

    ''' <summary>
    ''' Validaciones de cabecera equivalentes a frmRequisiciones.vb:validarGuardar(),
    ''' más las reglas explícitas de mínimo pedidas para el módulo de IA
    ''' (observaciones y al menos una línea con código).
    ''' </summary>
    Public Function ValidarCabecera(cab As RequisicionCabeceraDraft) As List(Of String)
        Dim errores As New List(Of String)

        If cab Is Nothing Then
            errores.Add("La requisición no tiene datos de cabecera.")
            Return errores
        End If

        ' El proveedor puede quedar vacío (pedido explícito del usuario) — si viene con un
        ' valor, RequisicionChatOrchestrator.ValidarItem igual valida que exista o sugiere
        ' coincidencias por nombre; simplemente ya no es obligatorio para poder guardar.

        If String.IsNullOrWhiteSpace(cab.Observaciones) Then
            errores.Add("Debe indicar las observaciones generales de la requisición.")
        End If

        If cab.Lineas Is Nothing OrElse cab.Lineas.Count = 0 Then
            errores.Add("La requisición debe llevar al menos una línea de detalle.")
        Else
            For Each linea In cab.Lineas
                If String.IsNullOrWhiteSpace(linea.Codigo) Then
                    errores.Add("Todas las líneas deben tener un código de producto.")
                    Exit For
                End If
            Next
        End If

        If String.IsNullOrWhiteSpace(cab.Cadena) Then
            errores.Add("Debe identificar si la requisición es de una Cadena de Supermercados.")
        End If

        If String.IsNullOrWhiteSpace(cab.Anticipo) Then
            errores.Add("Debe identificar si la requisición tiene anticipos.")
        ElseIf cab.Anticipo.ToUpper = "SI" AndAlso cab.MontoAnticipo < 100 Then
            errores.Add("Debe indicar el monto del anticipo (mínimo 100).")
        End If

        If String.IsNullOrWhiteSpace(cab.AfectaInventario) Then
            errores.Add("Debe identificar si la requisición afecta inventario.")
        End If

        Dim moneda As String = If(cab.Moneda, "").ToUpper
        If moneda <> "QUETZALES" AndAlso moneda <> "DOLARES" Then
            errores.Add("La moneda es obligatoria y debe ser QUETZALES o DOLARES.")
        End If

        Return errores
    End Function

    ''' <summary>
    ''' Valida la distribución de Centro de Costo/Marca/Canal/Gasto de la requisición.
    ''' En el sistema real (frmRequisiciones.vb:2411-2472, frmRequisiconesDetalle.vb:399-529)
    ''' esto se captura UNA sola vez con la primera línea y se reutiliza para las demás — por
    ''' eso se valida a nivel de CABECERA, no por línea.
    ''' </summary>
    Public Function ValidarDistribucion(cab As RequisicionCabeceraDraft) As List(Of String)
        Dim errores As New List(Of String)
        If cab Is Nothing Then Return errores

        ' --- Centro de Costo: obligatorio, suma 100% (frmRequisiconesDetalle.vb:401-417) ---
        If cab.CentrosCosto Is Nothing OrElse cab.CentrosCosto.Count = 0 Then
            errores.Add("La solicitud debe llevar Centro de Costo.")
        Else
            If No100(SumaPorcentaje(cab.CentrosCosto)) Then
                errores.Add("El total de Centro de Costo no suma 100%.")
            End If
            If cab.CentrosCosto.Exists(Function(d) String.IsNullOrWhiteSpace(d.Descripcion)) Then
                errores.Add("Tiene Centros de Costo inválidos.")
            End If
        End If

        ' --- Marca (opcional, pero si existe debe cumplir todas estas reglas) (frmRequisiconesDetalle.vb:421-455) ---
        If cab.Marcas IsNot Nothing AndAlso cab.Marcas.Count > 0 Then
            If No100(SumaPorcentaje(cab.Marcas)) Then
                errores.Add("El total por Marca no suma 100%.")
            End If
            If cab.Marcas.Exists(Function(d) String.IsNullOrWhiteSpace(d.Descripcion)) Then
                errores.Add("Tiene Marcas inválidas.")
            End If

            For Each marca In cab.Marcas
                Dim pctEmpresa As Double = If(marca.PorcentajeEmpresa.HasValue, marca.PorcentajeEmpresa.Value, 0)
                Dim pctSocio As Double = If(marca.PorcentajeSocio.HasValue, marca.PorcentajeSocio.Value, 0)
                If No100(pctEmpresa + pctSocio) Then
                    errores.Add($"La marca '{marca.Descripcion}' debe sumar 100% entre Empresa y Socio.")
                End If
            Next

            Dim busDistintos = cab.Marcas.Select(Function(m) m.Bu).Distinct().Count()
            If busDistintos <> cab.CentrosCosto.Count Then
                errores.Add("Debe definir las Unidades de Negocio que corresponden a las Marcas.")
            End If
        End If

        ' --- Gasto: obligatorio, suma 100% (frmRequisiconesDetalle.vb:465-486) ---
        If cab.Gastos Is Nothing OrElse cab.Gastos.Count = 0 Then
            errores.Add("Debe especificar Item de Gasto.")
        Else
            If No100(SumaPorcentaje(cab.Gastos)) Then
                errores.Add("El total por Gasto no suma 100%.")
            End If
            If cab.Gastos.Exists(Function(d) String.IsNullOrWhiteSpace(d.Descripcion)) Then
                errores.Add("Tiene Gastos inválidos.")
            End If
        End If

        ' --- Canal (opcional salvo A&P) (frmRequisiconesDetalle.vb:490-506) ---
        If cab.Canales IsNot Nothing AndAlso cab.Canales.Count > 0 Then
            If No100(SumaPorcentaje(cab.Canales)) Then
                errores.Add("El total por Canal no suma 100%.")
            End If
            If cab.Canales.Exists(Function(d) String.IsNullOrWhiteSpace(d.Descripcion)) Then
                errores.Add("Tiene Canales inválidos.")
            End If
        End If

        ' --- ITEM vs A&P (frmRequisiconesDetalle.vb:512-528) ---
        Dim tipo As String = If(cab.TipoGasto, "").ToUpper
        If tipo <> "CON_ITEM" AndAlso tipo <> "CON_A&P" Then
            errores.Add("Debe seleccionar ITEM o A&P.")
        ElseIf tipo = "CON_A&P" Then
            If cab.Marcas Is Nothing OrElse cab.Marcas.Count = 0 Then
                errores.Add("Siendo A&P, debe ingresar Marcas.")
            End If
            If cab.Canales Is Nothing OrElse cab.Canales.Count = 0 Then
                errores.Add("Siendo A&P, debe ingresar Canales.")
            End If
        End If

        Return errores
    End Function

    ''' <summary>Valida la requisición completa (cabecera + distribución) y devuelve todos los errores encontrados.</summary>
    Public Function ValidarRequisicion(cab As RequisicionCabeceraDraft) As List(Of String)
        Dim errores As New List(Of String)
        errores.AddRange(ValidarCabecera(cab))
        errores.AddRange(ValidarDistribucion(cab))
        Return errores
    End Function

End Class
