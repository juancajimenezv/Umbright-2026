-- =============================================================================
-- ALTER flexline.pa_pro_um_lgs_solicitudes_pago
-- Cambio respecto a la version instalada (2026-10-08 09:38):
--   La requisicion se marca como automatica: Requisicion.TipoComprobante (la
--   columna del combo "Anticipo" de Umbright) queda en 'Auto', salvo que se
--   ejecute con @Anticipo = 'SI' (anticipo real, queda 'SI').
--   Se pone despues de pa_upd_um_requisicion_anticipo, que es quien graba esa
--   columna al generar la OC; Adjuntos sigue en 'N'.
-- Ejecutar en SCM. Archivo UTF-8: con sqlcmd usar -f 65001.
-- =============================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [flexline].[pa_pro_um_lgs_solicitudes_pago]
    @SoloValidar  BIT        = 0,      -- 1 = no crea nada, solo devuelve la validacion
    @Anticipo     VARCHAR(2) = 'NO'    -- valor de Requisicion.TipoComprobante (SI / NO)
AS
SET NOCOUNT ON
SET XACT_ABORT ON

DECLARE @EmpresaDefault  VARCHAR(20)
DECLARE @EmpresaProducto VARCHAR(20)
SET @EmpresaDefault  = 'LOGISERV'   -- empresa de la requisicion si la solicitud no trae Empresa
SET @EmpresaProducto = 'LOGISERV'   -- productos y asociacion siempre de LOGISERV (como frmRequisiciones)
--Sin producto asociado para CC 1717 + Item 1111010
-- Evita dos corridas simultaneas
DECLARE @lock INT
EXEC @lock = sp_getapplock @Resource = 'pa_pro_um_lgs_solicitudes_pago',
                           @LockMode = 'Exclusive', @LockOwner = 'Session', @LockTimeout = 0
IF @lock < 0
BEGIN
    RAISERROR('pa_pro_um_lgs_solicitudes_pago ya se esta ejecutando.', 16, 1)
    RETURN
END

-- -----------------------------------------------------------------------------
-- 1) Pendientes del origen
-- -----------------------------------------------------------------------------
CREATE TABLE #src (
    IDRegistro        INT,
    SP_ID             INT,
    Empresa           VARCHAR(20)   COLLATE DATABASE_DEFAULT,
    Title             VARCHAR(255)  COLLATE DATABASE_DEFAULT,
    Area              VARCHAR(50)   COLLATE DATABASE_DEFAULT,
    NumeroAprobacion  VARCHAR(40)   COLLATE DATABASE_DEFAULT,
    FechaSolicitud    DATETIME,
    NombreProveedor   VARCHAR(200)  COLLATE DATABASE_DEFAULT,
    NIT               VARCHAR(30)   COLLATE DATABASE_DEFAULT,
    Serie             VARCHAR(50)   COLLATE DATABASE_DEFAULT,
    NoFactura         VARCHAR(50)   COLLATE DATABASE_DEFAULT,
    FechaFactura      DATETIME,
    Concepto          VARCHAR(1000) COLLATE DATABASE_DEFAULT,
    CentroCosto       VARCHAR(20)   COLLATE DATABASE_DEFAULT,
    ItemGasto         VARCHAR(20)   COLLATE DATABASE_DEFAULT,
    Monto             DECIMAL(18,2),
    PDF_Link          VARCHAR(500)  COLLATE DATABASE_DEFAULT,
    CorreoSolicita    VARCHAR(150)  COLLATE DATABASE_DEFAULT,
    CorreoAutoriza    VARCHAR(150)  COLLATE DATABASE_DEFAULT,
    MonedaOrigen      VARCHAR(10)   COLLATE DATABASE_DEFAULT,
    -- resueltos
    NITNorm           VARCHAR(30)   COLLATE DATABASE_DEFAULT,
    Grupo             INT,
    Linea             INT,
    Moneda            VARCHAR(20)   COLLATE DATABASE_DEFAULT,
    Proveedor         VARCHAR(20)   COLLATE DATABASE_DEFAULT,
    UsuarioSolicita   VARCHAR(25)   COLLATE DATABASE_DEFAULT,
    UsuarioAutoriza   VARCHAR(25)   COLLATE DATABASE_DEFAULT,
    Producto          VARCHAR(20)   COLLATE DATABASE_DEFAULT,
    Error             VARCHAR(1000) COLLATE DATABASE_DEFAULT
)

INSERT INTO #src (IDRegistro, SP_ID, Empresa, Title, Area, NumeroAprobacion, FechaSolicitud,
                  NombreProveedor, NIT, Serie, NoFactura, FechaFactura, Concepto, CentroCosto,
                  ItemGasto, Monto, PDF_Link, CorreoSolicita, CorreoAutoriza, MonedaOrigen)
SELECT s.IDRegistro, s.SP_ID,
       ISNULL(NULLIF(LTRIM(RTRIM(s.Empresa)), ''), @EmpresaDefault),
       LTRIM(RTRIM(s.Title)), LTRIM(RTRIM(s.Area)), LTRIM(RTRIM(s.NumeroAprobacion)),
       s.FechaSolicitud, LTRIM(RTRIM(s.Proveedor)), LTRIM(RTRIM(s.NIT)),
       LTRIM(RTRIM(s.Serie)), LTRIM(RTRIM(s.NoFactura)), s.FechaFactura,
       LTRIM(RTRIM(s.Concepto)), LTRIM(RTRIM(s.CentroCosto)), LTRIM(RTRIM(s.ItemGasto)),
       s.Monto, NULLIF(LTRIM(RTRIM(s.PDF_Link)), ''),
       LOWER(LTRIM(RTRIM(s.CorreoSolicita))), LOWER(LTRIM(RTRIM(s.CorreoAutoriza))),
       UPPER(LTRIM(RTRIM(s.Moneda)))
  FROM WMS_INTERFACE.lgs_transportes.dbo.LGS_SolicitudesPago s
 WHERE s.Estado = 'En pago'
   AND s.Procesado IS NULL

-- Ya creadas en una corrida anterior (solo falta marcar el origen): no se repiten
DELETE s
  FROM #src s
 WHERE EXISTS (SELECT 1 FROM flexline.um_lgs_solicitudes_pago_log l
                WHERE l.IDRegistro = s.IDRegistro AND l.Resultado = 'OK')

UPDATE #src
   SET NITNorm = REPLACE(REPLACE(UPPER(NIT), '-', ''), ' ', ''),
       Moneda  = CASE MonedaOrigen
                      WHEN 'GTQ' THEN 'QUETZALES'
                      WHEN 'USD' THEN 'DOLARES'
                      WHEN 'EUR' THEN 'EUROS'
                      WHEN 'HNL' THEN 'LEMPIRAS'
                 END

-- Grupo = Empresa + Title + NIT + Serie + NoFactura (una OC por factura); Linea dentro del grupo
;WITH g AS (
    SELECT Grupo, Linea,
           DENSE_RANK() OVER (ORDER BY Empresa, Title, NITNorm, Serie, NoFactura) AS g,
           ROW_NUMBER() OVER (PARTITION BY Empresa, Title, NITNorm, Serie, NoFactura ORDER BY IDRegistro) AS l
      FROM #src
)
UPDATE g SET Grupo = g, Linea = l

-- -----------------------------------------------------------------------------
-- 2) Resolucion de datos
-- -----------------------------------------------------------------------------
-- Proveedor: se busca el NIT en CTACTE.CODLEGAL (sin guiones ni espacios) y se
-- toma su CTACTE. Si el NIT tiene mas de una cuenta vigente no se elige: error.
UPDATE s
   SET Proveedor = p.CtaCte,
       Error     = CASE WHEN p.Cuentas > 1
                        THEN ISNULL(s.Error + ' | ', '') + 'NIT ' + s.NIT + ' tiene '
                             + CAST(p.Cuentas AS VARCHAR(5)) + ' cuentas de proveedor en CTACTE'
                        ELSE s.Error END
  FROM #src s
 CROSS APPLY (SELECT MIN(c.CTACTE) AS CtaCte, COUNT(DISTINCT c.CTACTE) AS Cuentas
                FROM BDFlexline.flexline.CTACTE c
               WHERE c.EMPRESA = s.Empresa
                 AND c.TIPOCTACTE = 'PROVEEDOR'
                 AND c.VIGENCIA = 'S'
                 AND REPLACE(REPLACE(UPPER(c.CODLEGAL), '-', ''), ' ', '') = s.NITNorm) p
 WHERE s.NITNorm <> ''

UPDATE #src SET Proveedor = NULL WHERE Error LIKE '%cuentas de proveedor en CTACTE%'

-- Si no se encontro por NIT (CODLEGAL), se busca el NIT en la columna CTACTE
UPDATE s
   SET Proveedor = CASE WHEN p.Cuentas = 1 THEN p.CtaCte END,
       Error     = CASE WHEN p.Cuentas > 1
                        THEN ISNULL(s.Error + ' | ', '') + 'NIT ' + s.NIT + ' coincide con '
                             + CAST(p.Cuentas AS VARCHAR(5)) + ' cuentas de proveedor en CTACTE'
                        ELSE s.Error END
  FROM #src s
 CROSS APPLY (SELECT MIN(c.CTACTE) AS CtaCte, COUNT(DISTINCT c.CTACTE) AS Cuentas
                FROM BDFlexline.flexline.CTACTE c
               WHERE c.EMPRESA = s.Empresa
                 AND c.TIPOCTACTE = 'PROVEEDOR'
                 AND c.VIGENCIA = 'S'
                 AND REPLACE(REPLACE(UPPER(c.CTACTE), '-', ''), ' ', '') = s.NITNorm) p
 WHERE s.NITNorm <> ''
   AND s.Proveedor IS NULL
   AND s.Error IS NULL

-- Usuarios
UPDATE s
   SET UsuarioSolicita = (SELECT TOP 1 LEFT(e.usuario, 25)
                            FROM BDFlexline.flexline.sg_usuario_email e
                           WHERE LOWER(LTRIM(RTRIM(e.correo))) = s.CorreoSolicita
                           ORDER BY e.usuario),
       UsuarioAutoriza = (SELECT TOP 1 LEFT(e.usuario, 25)
                            FROM BDFlexline.flexline.sg_usuario_email e
                           WHERE LOWER(LTRIM(RTRIM(e.correo))) = s.CorreoAutoriza
                           ORDER BY e.usuario)
  FROM #src s

-- Producto (de LOGISERV): CC + Item exacto; si no, el EsDefault del Item
UPDATE s
   SET Producto = (SELECT TOP 1 a.Producto
                     FROM flexline.um_lgs_asociacion_producto a
                    WHERE a.Empresa = @EmpresaProducto
                      AND a.ItemGasto = s.ItemGasto
                      AND a.Vigente = 'S'
                      AND (a.CentroCosto = s.CentroCosto
                           OR (a.CentroCosto IS NULL AND a.EsDefault = 1))
                    ORDER BY CASE WHEN a.CentroCosto IS NULL THEN 1 ELSE 0 END)
  FROM #src s

-- Validaciones por fila
UPDATE #src SET Error = ISNULL(Error + ' | ', '') + 'Proveedor con NIT ' + ISNULL(NIT, '(vacio)') + ' no existe en CTACTE (ni por NIT ni por codigo)'
 WHERE Proveedor IS NULL AND (Error IS NULL OR Error NOT LIKE '%cuentas de proveedor en CTACTE%')

UPDATE #src SET Error = ISNULL(Error + ' | ', '') + 'CorreoSolicita ' + ISNULL(CorreoSolicita, '(vacio)') + ' sin usuario en sg_usuario_email'
 WHERE UsuarioSolicita IS NULL

UPDATE #src SET Error = ISNULL(Error + ' | ', '') + 'CorreoAutoriza ' + ISNULL(CorreoAutoriza, '(vacio)') + ' sin usuario en sg_usuario_email'
 WHERE UsuarioAutoriza IS NULL

UPDATE #src SET Error = ISNULL(Error + ' | ', '') + 'Moneda ' + ISNULL(MonedaOrigen, '(vacia)') + ' no reconocida'
 WHERE Moneda IS NULL

UPDATE #src SET Error = ISNULL(Error + ' | ', '') + 'Monto invalido'
 WHERE Monto IS NULL OR Monto <= 0 OR Monto > 99999999.99

UPDATE s SET Error = ISNULL(Error + ' | ', '') + 'CC ' + ISNULL(s.CentroCosto, '(vacio)') + ' no existe en CON_CCOSTO'
  FROM #src s
 WHERE NOT EXISTS (SELECT 1 FROM BDFlexline.flexline.GEN_TABCOD g
                    WHERE g.EMPRESA = s.Empresa AND g.TIPO = 'CON_CCOSTO'
                      AND g.CODIGO = s.CentroCosto
                      AND LEN(g.CODIGO) = 4                       -- igual que pa_sel_um_gen_tabcod
                      AND ISNULL(g.VIGENCIA, '') IN ('S', ''))

UPDATE s SET Error = ISNULL(Error + ' | ', '') + 'Item ' + ISNULL(s.ItemGasto, '(vacio)') + ' no existe en CON_ITEM'
  FROM #src s
 WHERE NOT EXISTS (SELECT 1 FROM BDFlexline.flexline.GEN_TABCOD g
                    WHERE g.EMPRESA = s.Empresa AND g.TIPO = 'CON_ITEM'
                      AND g.CODIGO = s.ItemGasto
                      AND ISNULL(g.VIGENCIA, '') IN ('S', ''))   -- igual que pa_sel_um_gen_tabcod

UPDATE #src SET Error = ISNULL(Error + ' | ', '') + 'Sin producto asociado para CC ' + ISNULL(CentroCosto, '') + ' + Item ' + ISNULL(ItemGasto, '')
 WHERE Producto IS NULL

UPDATE s SET Error = ISNULL(Error + ' | ', '') + 'Producto ' + s.Producto + ' no vigente o duplicado en PRODUCTO de ' + @EmpresaProducto
  FROM #src s
 WHERE s.Producto IS NOT NULL
   AND (SELECT COUNT(*) FROM flexline.PRODUCTO p
         WHERE p.EMPRESA = @EmpresaProducto AND p.PRODUCTO = s.Producto AND p.VIGENTE = 'S') <> 1

-- Validaciones por grupo: mas de una moneda
UPDATE s SET Error = ISNULL(Error + ' | ', '') + 'El grupo tiene mas de una moneda'
  FROM #src s
 WHERE (SELECT COUNT(DISTINCT x.MonedaOrigen) FROM #src x WHERE x.Grupo = s.Grupo) > 1

-- -----------------------------------------------------------------------------
-- 3) Solo validar
-- -----------------------------------------------------------------------------
IF @SoloValidar = 1
BEGIN
    SELECT s.Grupo, s.Linea, s.IDRegistro, s.Empresa, s.Title, s.NIT, s.Proveedor,
           s.UsuarioSolicita, s.UsuarioAutoriza, s.Moneda, s.CentroCosto, s.ItemGasto,
           s.Producto, s.Monto,
           CASE WHEN EXISTS (SELECT 1 FROM #src x WHERE x.Grupo = s.Grupo AND x.Error IS NOT NULL)
                THEN 'NO SE CREA' ELSE 'SE CREA' END AS Grupo_resultado,
           s.Error
      FROM #src s
     ORDER BY s.Grupo, s.Linea

    EXEC sp_releaseapplock @Resource = 'pa_pro_um_lgs_solicitudes_pago', @LockOwner = 'Session'
    RETURN
END

-- Grupos con error: se registran y no se procesan
INSERT INTO flexline.um_lgs_solicitudes_pago_log
    (IDRegistro, SP_ID, Empresa, Title, NIT, Linea, Resultado, Mensaje)
SELECT s.IDRegistro, s.SP_ID, s.Empresa, LEFT(s.Title, 255), s.NIT, s.Linea, 'ERROR',
       LEFT(ISNULL(s.Error, 'Otra linea del grupo tiene error'), 1000)
  FROM #src s
 WHERE EXISTS (SELECT 1 FROM #src x WHERE x.Grupo = s.Grupo AND x.Error IS NOT NULL)

-- Avisos de error por grupo (se envian al final, punto 6)
CREATE TABLE #aviso (Grupo INT, Mensaje NVARCHAR(2000))

INSERT INTO #aviso (Grupo, Mensaje)
SELECT g.Grupo,
       LEFT(STUFF((SELECT DISTINCT ' | ' + x.Error
                     FROM #src x
                    WHERE x.Grupo = g.Grupo AND x.Error IS NOT NULL
                      FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, ''), 2000)
  FROM (SELECT DISTINCT Grupo FROM #src WHERE Error IS NOT NULL) g

-- -----------------------------------------------------------------------------
-- 4) Crear requisicion y llevarla a OC (estado 60), un grupo por transaccion
-- -----------------------------------------------------------------------------
DECLARE @Grupo INT, @Empresa VARCHAR(20), @Title VARCHAR(255), @NIT VARCHAR(30),
        @Proveedor VARCHAR(20), @UsrSol VARCHAR(25), @UsrAut VARCHAR(25), @Moneda VARCHAR(20),
        @FechaEntrega VARCHAR(15), @Lugar VARCHAR(75), @Obs VARCHAR(255), @Cotizacion VARCHAR(100),
        @Aprobacion VARCHAR(40), @PDF VARCHAR(500), @MontoTotal DECIMAL(18,2),
        @Concepto VARCHAR(1000), @Referencia VARCHAR(255),
        @MaxNumero BIGINT, @Numero VARCHAR(25), @Correlativo INT, @Cmt VARCHAR(150),
        @Linea INT, @Producto VARCHAR(25), @CC VARCHAR(50), @Item VARCHAR(50),
        @Monto NUMERIC(10,2), @Comentario VARCHAR(255), @MontoAnticipo NUMERIC(10,2)

DECLARE cGrupos CURSOR LOCAL FAST_FORWARD FOR
    SELECT s.Grupo, MIN(s.Empresa), MIN(s.Title), MIN(s.NIT), MIN(s.Proveedor),
           MIN(CASE WHEN s.Linea = 1 THEN s.UsuarioSolicita END),
           MIN(CASE WHEN s.Linea = 1 THEN s.UsuarioAutoriza END),
           MIN(s.Moneda),
           CONVERT(VARCHAR(8), ISNULL(MIN(s.FechaSolicitud), GETDATE()), 112),
           concat(LEFT(ISNULL(MIN(s.Area), ''), 75),'/Automatica') ,
           ISNULL(MIN(s.Serie) + '-', '') + ISNULL(MIN(s.NoFactura), ''),
           MIN(s.NumeroAprobacion), MAX(s.PDF_Link), SUM(s.Monto),
           MIN(CASE WHEN s.Linea = 1 THEN s.Concepto END)
      FROM #src s
     GROUP BY s.Grupo
    HAVING SUM(CASE WHEN s.Error IS NULL THEN 0 ELSE 1 END) = 0
     ORDER BY s.Grupo

OPEN cGrupos
FETCH NEXT FROM cGrupos INTO @Grupo, @Empresa, @Title, @NIT, @Proveedor, @UsrSol, @UsrAut, @Moneda,
                             @FechaEntrega, @Lugar, @Obs, @Aprobacion, @PDF, @MontoTotal, @Concepto

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Observaciones (max 255): Concepto + referencia de la solicitud.
    -- @Obs llega con "serie-factura". Si no cabe, se recorta el concepto, no la referencia.
    SET @Referencia = LEFT(' | Solicitud de pago ' + @Title
                           + ' | Aut. ' + ISNULL(@Aprobacion, '')
                           + ' | Fact. ' + ISNULL(@Obs, ''), 255)
    SET @Concepto   = REPLACE(REPLACE(ISNULL(@Concepto, ''), CHAR(13), ' '), CHAR(10), ' ')
    SET @Obs        = CASE WHEN @Concepto = '' THEN LTRIM(STUFF(@Referencia, 1, 3, ''))
                           ELSE LEFT(@Concepto, 255 - LEN(@Referencia)) + @Referencia END
    SET @Cotizacion = LEFT('Solicitud de pago ' + @Title, 100)
    SET @MontoAnticipo = CASE WHEN @Anticipo = 'SI' THEN @MontoTotal ELSE 0 END
    SET @Numero = NULL
    SET @Correlativo = NULL

    BEGIN TRY
        BEGIN TRAN

        -- Numero siguiente, bloqueando la empresa para no chocar con la pantalla
        SELECT @MaxNumero = MAX(CASE WHEN r.Numero NOT LIKE '%[^0-9]%' AND LEN(r.Numero) BETWEEN 1 AND 18
                                     THEN CAST(r.Numero AS BIGINT) END)
          FROM flexline.Requisicion r WITH (UPDLOCK, HOLDLOCK)
         WHERE r.Empresa = @Empresa

        SET @Numero = RIGHT('0000000000' + CAST(ISNULL(@MaxNumero, 1) + 1 AS VARCHAR(20)), 10)

        EXEC flexline.pa_ins_um_requisicion
             @PEmpresa       = @Empresa,
             @PNumero        = @Numero,
             @PFechaEntrega  = @FechaEntrega,      -- yyyymmdd (servidor en idioma dmy)
             @PLugarEntrega  = @Lugar ,
             @PObservaciones = @Obs,
             @PCodigoCliente = @Proveedor,         -- la pantalla manda aqui el proveedor
             @PUsuarioGrabo  = @UsrSol,
             @Pmoneda        = @Moneda,
             @PAnticipo      = @Anticipo,
             @PCadena        = 'NO',
             @PMontoAnticipo = @MontoAnticipo,
             @Pcosteo        = 'N'

        SELECT @Correlativo = r.Correlativo
          FROM flexline.Requisicion r
         WHERE r.Empresa = @Empresa AND r.Numero = @Numero

        IF @Correlativo IS NULL
            RAISERROR('No se encontro la requisicion %s recien creada.', 16, 1, @Numero)

        -- Lineas con su CC e Item
        DECLARE cLineas CURSOR LOCAL FAST_FORWARD FOR
            SELECT s.Linea, s.Producto, s.CentroCosto, s.ItemGasto, s.Monto, LEFT(ISNULL(s.Concepto, ''), 255)
              FROM #src s
             WHERE s.Grupo = @Grupo
             ORDER BY s.Linea

        OPEN cLineas
        FETCH NEXT FROM cLineas INTO @Linea, @Producto, @CC, @Item, @Monto, @Comentario
        WHILE @@FETCH_STATUS = 0
        BEGIN
            EXEC flexline.pa_ins_um_requisiciond @Empresa, @Correlativo, @Linea, @Producto, 1, @Monto, @Comentario
            EXEC flexline.pa_ins_um_requisicion_costo @Empresa, @Correlativo, @Producto, @CC, 100, @Linea
            EXEC flexline.pa_ins_um_requisicion_gasto @Empresa, @Correlativo, @Producto, @Item, 100, 'CON_ITEM', @Linea

            FETCH NEXT FROM cLineas INTO @Linea, @Producto, @CC, @Item, @Monto, @Comentario
        END
        CLOSE cLineas
        DEALLOCATE cLineas

        -- PDF de la solicitud autorizada
        IF @PDF IS NOT NULL AND LEN(@PDF) <= 255
            EXEC flexline.pa_ins_um_requisicionImagen @Empresa, @Correlativo,
                 'Solicitud de pago autorizada.pdf', @PDF, @PDF, @UsrSol

        -- 10: grabada por quien solicita
        SET @Cmt = LEFT('Creada desde Solicitud de Pago ' + @Title, 150)
        EXEC flexline.pa_upd_um_requisicion_estado @Empresa, @Numero, @UsrSol, 10, @Cmt

        -- 20/30: revision y aprobacion (ya autorizada en SharePoint)
        UPDATE dbo.requisicionCodigo
           SET usuario_reviso = @UsrAut, fecha_reviso = GETDATE()
         WHERE empresa = @Empresa AND correlativo = @Correlativo AND tipo = 'CON_CCOSTO'

        SET @Cmt = LEFT('Autorizada en SharePoint ' + ISNULL(@Aprobacion, ''), 150)
        EXEC flexline.pa_upd_um_requisicion_estado @Empresa, @Numero, @UsrAut, 20, @Cmt
        EXEC flexline.pa_upd_um_requisicion_estado @Empresa, @Numero, @UsrAut, 30, @Cmt
        EXEC flexline.pa_upd_um_requisicion_estado @Empresa, @Numero, @UsrAut, 40, @Cmt

        -- 50: OC, mismo orden que frmRequisiciones (estado, proveedor, precios, anticipo)
        EXEC flexline.pa_upd_um_requisicion_estado @Empresa, @Numero, @UsrAut, 50, @Cmt
        EXEC flexline.pa_upd_um_requisicion_proveedor @Empresa, @Numero, @Proveedor, @Cotizacion

        DECLARE cPrecios CURSOR LOCAL FAST_FORWARD FOR
            SELECT s.Linea, s.Producto, s.Monto FROM #src s WHERE s.Grupo = @Grupo ORDER BY s.Linea
        OPEN cPrecios
        FETCH NEXT FROM cPrecios INTO @Linea, @Producto, @Monto
        WHILE @@FETCH_STATUS = 0
        BEGIN
            EXEC flexline.pa_upd_um_requisiciond_precio @Empresa, @Numero, @Linea, @Producto, @Monto, 1
            FETCH NEXT FROM cPrecios INTO @Linea, @Producto, @Monto
        END
        CLOSE cPrecios
        DEALLOCATE cPrecios

        EXEC flexline.pa_upd_um_requisicion_anticipo @Empresa, @Numero, @UsrAut, @Anticipo

        -- Requisicion automatica: 'Auto' en la columna del combo Anticipo (salvo anticipo real)
        IF @Anticipo <> 'SI'
            UPDATE flexline.Requisicion SET TipoComprobante = 'Auto'
             WHERE Empresa = @Empresa AND Numero = @Numero

        -- 60: OC generada
        EXEC flexline.pa_upd_um_requisicion_estado @Empresa, @Numero, @UsrAut, 60, @Cmt

        INSERT INTO flexline.um_lgs_solicitudes_pago_log
            (IDRegistro, SP_ID, Empresa, Title, NIT, Linea, Resultado, NumeroRequisicion, Correlativo, Mensaje)
        SELECT s.IDRegistro, s.SP_ID, s.Empresa, LEFT(s.Title, 255), s.NIT, s.Linea, 'OK',
               @Numero, @Correlativo, 'Requisicion ' + @Numero + ' creada en estado 60'
          FROM #src s
         WHERE s.Grupo = @Grupo

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN
        IF CURSOR_STATUS('local', 'cLineas')  >= -1 BEGIN CLOSE cLineas  DEALLOCATE cLineas  END
        IF CURSOR_STATUS('local', 'cPrecios') >= -1 BEGIN CLOSE cPrecios DEALLOCATE cPrecios END

        INSERT INTO flexline.um_lgs_solicitudes_pago_log
            (IDRegistro, SP_ID, Empresa, Title, NIT, Linea, Resultado, Mensaje)
        SELECT s.IDRegistro, s.SP_ID, s.Empresa, LEFT(s.Title, 255), s.NIT, s.Linea, 'ERROR',
               LEFT('Error al crear: ' + ERROR_MESSAGE(), 1000)
          FROM #src s
         WHERE s.Grupo = @Grupo

        INSERT INTO #aviso (Grupo, Mensaje)
        VALUES (@Grupo, LEFT('Error al crear: ' + ERROR_MESSAGE(), 2000))
    END CATCH

    FETCH NEXT FROM cGrupos INTO @Grupo, @Empresa, @Title, @NIT, @Proveedor, @UsrSol, @UsrAut, @Moneda,
                                 @FechaEntrega, @Lugar, @Obs, @Aprobacion, @PDF, @MontoTotal, @Concepto
END
CLOSE cGrupos
DEALLOCATE cGrupos

-- -----------------------------------------------------------------------------
-- 5) Marcar el origen (incluye pendientes de corridas anteriores)
-- -----------------------------------------------------------------------------
DECLARE @LogId INT, @IdReg INT, @NumReq VARCHAR(20)

DECLARE cMarca CURSOR LOCAL FAST_FORWARD FOR
    SELECT l.id, l.IDRegistro, l.NumeroRequisicion
      FROM flexline.um_lgs_solicitudes_pago_log l
     WHERE l.Resultado = 'OK' AND l.MarcadoOrigen = 0

OPEN cMarca
FETCH NEXT FROM cMarca INTO @LogId, @IdReg, @NumReq
WHILE @@FETCH_STATUS = 0
BEGIN
    BEGIN TRY
        UPDATE WMS_INTERFACE.lgs_transportes.dbo.LGS_SolicitudesPago
           SET Procesado = 1,
               fechaProcesado = GETDATE(),
               NumeroRequisicion = @NumReq
         WHERE IDRegistro = @IdReg

        UPDATE flexline.um_lgs_solicitudes_pago_log
           SET MarcadoOrigen = 1, FechaMarcado = GETDATE()
         WHERE id = @LogId
    END TRY
    BEGIN CATCH
        UPDATE flexline.um_lgs_solicitudes_pago_log
           SET Mensaje = LEFT(ISNULL(Mensaje, '') + ' | No se pudo marcar el origen: ' + ERROR_MESSAGE(), 1000)
         WHERE id = @LogId
    END CATCH

    FETCH NEXT FROM cMarca INTO @LogId, @IdReg, @NumReq
END
CLOSE cMarca
DEALLOCATE cMarca

-- -----------------------------------------------------------------------------
-- 6) Aviso de error: una fila por correo (Solicita y Autoriza) por cada grupo
--    no procesado, en bot_avisos_teams_2022 (Azure). Va fuera de transaccion y
--    con SQL dinamico para que un fallo del servidor remoto no corte el proceso.
-- -----------------------------------------------------------------------------
IF EXISTS (SELECT 1 FROM #aviso)
BEGIN
    CREATE TABLE #dest (
        id_unico  VARCHAR(150)   COLLATE DATABASE_DEFAULT,
        Correo    VARCHAR(50)    COLLATE DATABASE_DEFAULT,
        Mensaje   NVARCHAR(2000),
        Campo1    NVARCHAR(500),
        Campo2    NVARCHAR(500),
        Campo3    NVARCHAR(500),
        Campo4    NVARCHAR(500)
    )

    ;WITH g AS (
        SELECT a.Grupo, a.Mensaje,
               MIN(s.Empresa) AS Empresa, ISNULL(MIN(s.Title), '') AS Title, MIN(s.NIT) AS NIT,
               MIN(s.NITNorm) AS NITNorm, MIN(s.NombreProveedor) AS NombreProveedor,
               ISNULL(MIN(s.Serie) + '-', '') + ISNULL(MIN(s.NoFactura), '') AS Factura,
               SUM(s.Monto) AS Monto, MIN(s.MonedaOrigen) AS Moneda,
               MIN(s.NumeroAprobacion) AS Aprobacion
          FROM #aviso a
          JOIN #src s ON s.Grupo = a.Grupo
         GROUP BY a.Grupo, a.Mensaje
    ), c AS (
        SELECT DISTINCT s.Grupo, s.CorreoSolicita AS Correo FROM #src s WHERE ISNULL(s.CorreoSolicita, '') <> ''
        UNION
        SELECT DISTINCT s.Grupo, s.CorreoAutoriza FROM #src s WHERE ISNULL(s.CorreoAutoriza, '') <> ''
    )
    INSERT INTO #dest (id_unico, Correo, Mensaje, Campo1, Campo2, Campo3, Campo4)
    SELECT LEFT('LGS_SolPago_' + LEFT(g.Title, 60) + '_'
                + CONVERT(VARCHAR(32), HASHBYTES('MD5', g.Empresa + '|' + g.Title + '|' + ISNULL(g.NITNorm, '')
                                                        + '|' + g.Factura + '|' + g.Mensaje), 2), 150),
           c.Correo,
           LEFT('No se proceso la solicitud de pago ' + g.Title + '. ' + g.Mensaje, 2000),
           LEFT('Empresa: ' + g.Empresa + ' Solicitud: ' + g.Title, 500),
           LEFT('Proveedor: ' + ISNULL(g.NombreProveedor, '') + ' NIT: ' + ISNULL(g.NIT, ''), 500),
           LEFT('Factura: ' + g.Factura + ' Monto: ' + ISNULL(CONVERT(VARCHAR(30), g.Monto), '')
                + ' ' + ISNULL(g.Moneda, ''), 500),
           LEFT('Aprobacion: ' + ISNULL(g.Aprobacion, ''), 500)
      FROM g
      JOIN c ON c.Grupo = g.Grupo
     WHERE LEN(c.Correo) <= 50          -- Correo es varchar(50) en el destino

    BEGIN TRY
        -- Avisos ya enviados por corridas anteriores (mismo error, mismo correo)
        CREATE TABLE #enviados (id_unico VARCHAR(150) COLLATE DATABASE_DEFAULT,
                                Correo   VARCHAR(50)  COLLATE DATABASE_DEFAULT)

        EXEC sp_executesql N'
            INSERT INTO #enviados (id_unico, Correo)
            SELECT id_unico, Correo
              FROM OPENQUERY(azure_regionaldb_in_out,
                   ''SELECT id_unico, Correo FROM dbo.bot_avisos_teams_2022
                      WHERE Programa = ''''Solicitudes Pago LGS''''
                        AND id_unico LIKE ''''LGS[_]SolPago[_]%'''''')'

        EXEC sp_executesql N'
            INSERT INTO azure_regionaldb_in_out.regionaldb_in_out.dbo.bot_avisos_teams_2022
                (id_unico, fecha_creacion, Correo, Programa, motivo, Mensaje_A_Enviar,
                 Campo1, Campo2, Campo3, Campo4)
            SELECT d.id_unico, GETDATE(), d.Correo, ''Solicitudes Pago LGS'', N''Error al procesar OC'',
                   d.Mensaje, d.Campo1, d.Campo2, d.Campo3, d.Campo4
              FROM #dest d
             WHERE NOT EXISTS (SELECT 1 FROM #enviados e
                                WHERE e.id_unico = d.id_unico AND e.Correo = d.Correo)'
    END TRY
    BEGIN CATCH
        UPDATE l
           SET Mensaje = LEFT(ISNULL(l.Mensaje, '') + ' | No se pudo enviar el aviso: ' + ERROR_MESSAGE(), 1000)
          FROM flexline.um_lgs_solicitudes_pago_log l
         WHERE l.Resultado = 'ERROR'
           AND l.FechaProceso >= DATEADD(MINUTE, -30, GETDATE())
           AND l.IDRegistro IN (SELECT s.IDRegistro FROM #src s JOIN #aviso a ON a.Grupo = s.Grupo)
    END CATCH
END

-- Resumen de esta corrida
SELECT l.IDRegistro, l.Title, l.NIT, l.Linea, l.Resultado, l.NumeroRequisicion, l.MarcadoOrigen, l.Mensaje
  FROM flexline.um_lgs_solicitudes_pago_log l
 WHERE l.IDRegistro IN (SELECT IDRegistro FROM #src)
   AND l.FechaProceso >= DATEADD(MINUTE, -30, GETDATE())
 ORDER BY l.Title, l.NIT, l.Linea

EXEC sp_releaseapplock @Resource = 'pa_pro_um_lgs_solicitudes_pago', @LockOwner = 'Session'


GO
