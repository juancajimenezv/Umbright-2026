-- ============================================================================
-- MODIFICACION SP: pa_ins_um_producto_interempresas
-- BD destino: BDFlexline (172.50.0.150)
--
-- Cambio: las 3 cuentas (CUENTACOMPRA, CUENTAVENTA, CUENTACOSTO) ahora se
--         copian del producto origen, igual que ya se hacia con Cuentadesc
--         y Cuentadev. Antes se insertaban con un espacio en blanco.
--
-- Diff aplicado:
--   ANTES: ,' ' [CUENTACOMPRA]      ,' ' [CUENTAVENTA]      ,' ' [CUENTACOSTO]
--   AHORA: ,[CUENTACOMPRA]          ,[CUENTAVENTA]          ,[CUENTACOSTO]
--
-- Como deshacer: volver a poner los ' ' literales en esas 3 columnas.
-- ============================================================================

USE [BDFlexline]
GO

ALTER Procedure [flexline].[pa_ins_um_producto_interempresas]
-- pa_ins_um_producto_interempresas 'DIUVA','0300010013','VINOTECA','pplamport'

@PEmp_Origen as nVarChar(20),
@PProducto as nVarChar(20),
@PEmp_Destino as nVarChar(20),
@Pusuario as nVarChar(20)

As

Declare @PCantidad as Int
Declare @PProveedor as nVarChar(20)
Declare @PBU as nVarChar(20)

Select @PCantidad = count(*)
	from producto
	where empresa = @PEmp_Destino
		and producto = @PProducto

if @PEmp_Origen = 'dmarte1'
begin
	Select @PProveedor = 'DISTRIBUIDORA MARTE'
End
If @PEmp_Origen ='CODICASA'
BEGIN
	SELECT @PProveedor ='CODICASA'
END
if @PEmp_Origen ='diuva'
begin
	SELECT @PProveedor ='DIUVA'
end
Select @PBU = Null
if @PEmp_Destino = 'vinoteca'
begin
	Select @PBU = 'BU VINOTECA'
end


if @PCantidad > 0
Begin
	Print 'Ya Existe en Destino'
End
Else
Begin

	Insert into Producto ([EMPRESA]      ,[PRODUCTO]      ,[GLOSA]      ,[TIPOPRODUCTO]      ,[FAMILIA]      , [SUBFAMILIA]   ,[TIPO]     ,[SUBTIPO]      ,[VIGENTE]      ,[UNIDAD]
      ,[DECIMALES]      , [PRECIOVENTA]      ,[PROCEDENCIA]      , [CUENTACOMPRA]      , [CUENTAVENTA]      , [CUENTACOSTO]      ,[UNIDADALT]      ,[FACTORALT]
      ,[DECIMALESALT]      ,[BMP]      ,[SERIE]      ,[LOTE]      ,[FECHAVCTO]      ,[VALIDASTOCK]      ,[CMONETARIA]      ,[COSTEABLE]      ,[DEPRECIABLE]      ,[COMPUESTO]
      ,[FACTOR1]      ,[FACTOR2]      ,[FACTOR3]      ,[FACTOR4]      ,[FACTOR5]      ,[FACTOR6]      ,[FACTOR7]      ,[FACTOR8]      ,[FACTOR9]      ,[FACTOR10]
      ,[FACTOR11]      ,[FACTOR12]      ,[FACTOR13]      ,[FACTOR14]      ,[FACTOR15]      ,[FACTOR16]      ,[FACTOR17]      ,[FACTOR18]      ,[FACTOR19]      ,[FACTOR20]
      ,[STOCKMINIMO]      ,[STOCKMAXIMO]      , [COSTOESTANDAR]      ,[COMENTARIO]      ,[FECHAMODIF]      ,[MONEDACMONETARIA]      , [COSTO]      , [USUARIOMODIF]
      ,[AUX_VALOR1]      ,[AUX_VALOR2]      ,[AUX_VALOR3]      ,[AUX_VALOR4]      ,[AUX_VALOR5]      ,[AUX_VALOR6]      ,[AUX_VALOR7]      ,[AUX_VALOR8]
      ,[AUX_VALOR9]      ,[AUX_VALOR10]      ,[AUX_VALOR11]      ,[AUX_VALOR12]      ,[AUX_VALOR13]      ,[AUX_VALOR14]      ,[AUX_VALOR15]      ,[AUX_VALOR16]
      ,[AUX_VALOR17]      ,[AUX_VALOR18]      ,[AUX_VALOR19]      ,[AUX_VALOR20]      ,[VALOR1]      ,[VALOR2]      ,[VALOR3]      ,[VALOR4]      ,[VALOR5]
      ,[VALOR6]      ,[VALOR7]      ,[VALOR8]      ,[VALOR9]      ,[VALOR10]      ,[VALOR11]      ,[VALOR12]      ,[VALOR13]      ,[VALOR14]      ,[VALOR15]
      ,[VALOR16]      ,[VALOR17]      ,[VALOR18]      ,[VALOR19]      ,[VALOR20]      ,[ABC]      ,[DIASCOMPRA]      ,[DIASPRODUCCION]      ,[LOTECOMPRA]
      ,[LOTEPRODUCCION]      ,[STOCKREPOSICION]      ,[PESO]      ,[VOLUMEN]      ,[Proveedor]      ,[KitVirtual]      ,[Clasificador1]      ,[Clasificador2]      ,[Clasificador3]
      ,[Clasificador4]      ,[Clasificador5]      ,[Clasificador6]      ,[Clasificador7]      ,[Clasificador8]      ,[Clasificador9]      ,[Clasificador10]      ,[Clasificador11]
      ,[Clasificador12]      ,[Clasificador13]      ,[Clasificador14]      ,[Clasificador15]      ,[Clasificador16]      ,[Clasificador17]      ,[Clasificador18]      ,[Clasificador19]
      ,[Clasificador20]      ,[Cuentadesc]      ,[Cuentadev]      ,[ProductosxEmpaque1]      ,[Empaque1xEmpaque2]      ,[Mascara]      ,[AnalisisProducto1]      ,[AnalisisProducto2]
      ,[AnalisisProducto3]      ,[AnalisisProducto4]      ,[AnalisisProducto5]      ,[AnalisisProducto6]      ,[AnalisisProducto7]      ,[AnalisisProducto8]      ,[AnalisisProducto9]
      ,[AnalisisProducto10]      ,[RutaAsociada]      ,[MULTIPLE]      ,[Act_Grupo]      ,[Act_SerieCartola]      ,[FechaUModif]      ,[AnalisisProducto11]      ,[AnalisisProducto12]
      ,[AnalisisProducto13]      ,[AnalisisProducto14]      ,[AnalisisProducto15]      ,[AnalisisProducto16]      , [AnalisisProducto17]      ,[AnalisisProducto18]      ,[AnalisisProducto19]
      ,[AnalisisProducto20]      ,[AnalisisProducto21]      ,[AnalisisProducto22]      ,[AnalisisProducto23]      ,[AnalisisProducto24]      ,[AnalisisProducto25]      ,[AnalisisProducto26]
      ,[AnalisisProducto27]      ,[AnalisisProducto28]      ,[AnalisisProducto29]      ,[AnalisisProducto30])


	SELECT @PEmp_Destino As [EMPRESA]      ,[PRODUCTO]      ,[GLOSA]      ,[TIPOPRODUCTO]      ,[FAMILIA]      ,@PProveedor  as [SUBFAMILIA]   ,[TIPO]     ,[SUBTIPO]      ,[VIGENTE]      ,[UNIDAD]
      ,[DECIMALES]      , 0 as [PRECIOVENTA]      ,[PROCEDENCIA]      ,[CUENTACOMPRA]      ,[CUENTAVENTA]      ,[CUENTACOSTO]      ,[UNIDADALT]      ,[FACTORALT]
      ,[DECIMALESALT]      ,[BMP]      ,[SERIE]      ,[LOTE]      ,[FECHAVCTO]      ,[VALIDASTOCK]      ,[CMONETARIA]      ,[COSTEABLE]      ,[DEPRECIABLE]      ,[COMPUESTO]
      ,[FACTOR1]      ,[FACTOR2]      ,[FACTOR3]      ,[FACTOR4]      ,[FACTOR5]      ,[FACTOR6]      ,[FACTOR7]      ,[FACTOR8]      ,0 [FACTOR9]      ,0 [FACTOR10]
      ,0 [FACTOR11]      ,0 [FACTOR12]      ,0 [FACTOR13]      ,0 [FACTOR14]      ,0 [FACTOR15]      ,0 [FACTOR16]      ,0 [FACTOR17]      ,0 [FACTOR18]      ,0 [FACTOR19]      ,0 [FACTOR20]
      ,0 [STOCKMINIMO]      ,0 [STOCKMAXIMO]      ,0 [COSTOESTANDAR]      ,[COMENTARIO]      ,getdate()     ,[MONEDACMONETARIA]      ,0 [COSTO]      , @Pusuario [USUARIOMODIF]
      ,[AUX_VALOR1]      ,[AUX_VALOR2]      ,[AUX_VALOR3]      ,[AUX_VALOR4]      ,[AUX_VALOR5]      ,[AUX_VALOR6]      ,[AUX_VALOR7]      ,[AUX_VALOR8]
      ,[AUX_VALOR9]      ,[AUX_VALOR10]      ,[AUX_VALOR11]      ,[AUX_VALOR12]      ,[AUX_VALOR13]      ,[AUX_VALOR14]      ,[AUX_VALOR15]      ,[AUX_VALOR16]
      ,[AUX_VALOR17]      ,[AUX_VALOR18]      ,[AUX_VALOR19]      ,[AUX_VALOR20]      ,[VALOR1]      ,[VALOR2]      ,[VALOR3]      ,[VALOR4]      ,[VALOR5]
      ,[VALOR6]      ,[VALOR7]      ,[VALOR8]      ,[VALOR9]      ,[VALOR10]      ,[VALOR11]      ,[VALOR12]      ,[VALOR13]      ,[VALOR14]      ,[VALOR15]
      ,[VALOR16]      ,[VALOR17]      ,[VALOR18]      ,[VALOR19]      ,[VALOR20]      ,[ABC]      ,[DIASCOMPRA]      ,[DIASPRODUCCION]      ,[LOTECOMPRA]
      ,[LOTEPRODUCCION]      ,[STOCKREPOSICION]      ,[PESO]      ,[VOLUMEN]      ,[Proveedor]      ,[KitVirtual]      ,[Clasificador1]      ,[Clasificador2]      ,[Clasificador3]
      ,[Clasificador4]      ,[Clasificador5]      ,[Clasificador6]      ,[Clasificador7]      ,[Clasificador8]      ,[Clasificador9]      ,[Clasificador10]      ,[Clasificador11]
      ,[Clasificador12]      ,[Clasificador13]      ,[Clasificador14]      ,[Clasificador15]      ,[Clasificador16]      ,[Clasificador17]      ,[Clasificador18]      ,[Clasificador19]
      ,[Clasificador20]      ,[Cuentadesc]      ,[Cuentadev]      ,[ProductosxEmpaque1]      ,[Empaque1xEmpaque2]      ,[Mascara]      ,[AnalisisProducto1]      ,[AnalisisProducto2]
      ,[AnalisisProducto3]      ,[AnalisisProducto4]      ,[AnalisisProducto5]      ,[AnalisisProducto6]      ,[AnalisisProducto7]      ,[AnalisisProducto8]      ,[AnalisisProducto9]
      ,[AnalisisProducto10]      ,[RutaAsociada]      ,[MULTIPLE]      ,[Act_Grupo]      ,[Act_SerieCartola]      ,GETDATE()       ,[AnalisisProducto11]      ,[AnalisisProducto12]
      ,[AnalisisProducto13]      ,[AnalisisProducto14]      ,[AnalisisProducto15]      ,[AnalisisProducto16]      ,isnull(@PBU,[AnalisisProducto17]) AS [AnalisisProducto17]      ,[AnalisisProducto18]      ,[AnalisisProducto19]
      ,[AnalisisProducto20]      ,[AnalisisProducto21]      ,[AnalisisProducto22]      ,[AnalisisProducto23]      ,[AnalisisProducto24]      ,[AnalisisProducto25]      ,[AnalisisProducto26]
      ,[AnalisisProducto27]      ,[AnalisisProducto28]      ,[AnalisisProducto29]      ,[AnalisisProducto30]
	FROM [flexline].[PRODUCTO] where EMPRESA = @PEmp_Origen and PRODUCTO = @PProducto

	Insert Into PRODCODBARRA (Empresa, CODBARRA, producto, unidad, factor, linea, TipoCodigo)
	Select @PEmp_Destino as Empresa, CODBARRA, producto, unidad, factor, linea, TipoCodigo
	from [flexline].[PRODCODBARRA]
	where EMPRESA = @PEmp_Origen and PRODUCTO = @PProducto




	-- Creacion de Barras
	-- Creacion de


End
GO

-- ============================================================================
-- VERIFICACION: probar con un producto de DIUVA y comparar las cuentas
-- ============================================================================
-- DECLARE @prod varchar(20) = '0300010013'   -- cambia por uno de prueba
-- SELECT EMPRESA, PRODUCTO, CUENTACOMPRA, CUENTAVENTA, CUENTACOSTO, Cuentadesc, Cuentadev
-- FROM flexline.PRODUCTO
-- WHERE PRODUCTO = @prod AND EMPRESA IN ('DIUVA','VINOTECA')
-- ORDER BY EMPRESA
-- ============================================================================
