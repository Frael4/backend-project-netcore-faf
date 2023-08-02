USE [PROJECT_FAF_DAW]
GO

CREATE OR ALTER  PROCEDURE [dbo].[SP_CONSULTAR_ACTAS_PARTIDO]
	@TRANSACCION VARCHAR(100),
	@DATAXML XML = NULL,
	@FILTRO VARCHAR(100) = NULL
AS
BEGIN
	
	DECLARE @ID_ACTA AS INT

	IF @FILTRO = NULL
	BEGIN
		SET @FILTRO = ''
	END
	SELECT @ID_ACTA = ISNULL(ACTA.X.value('Id[1]','INT'), 0) FROM @DATAXML.nodes('/ActaPartido') as ACTA(X)

	BEGIN TRY

		IF UPPER(@TRANSACCION) = 'CONSULTAR_ALL_ACTAS_PARTIDO'
		BEGIN
			SELECT ac.id_acta_partido, ac.fecha_emision_acta, ac.hora_inicio_partido,
			ac.hora_fin_partido, ac.duracion_partido, ac.num_gol_equipo_local, ac.num_gol_equipo_rival,
			ac.partido_id_partido, l.id_club as id_club_l, l.nombre as nombre_local, r.id_club as id_club_r, r.nombre as nombre_rival,
			ac.equipo_ganador FROM ACTA_PARTIDO ac inner join partido p on ac.partido_id_partido = p.id_partido
			inner join club l on l.id_club = p.club_id_local
			inner join club r on r.id_club = p.club_id_rival where ac.estado <> 'E'

			SELECT 'OK' AS ERROR

		END

		IF UPPER(@TRANSACCION) = 'CONSULTA_ACTA_PARTIDO'
		BEGIN
			
			SELECT ac.id_acta_partido, ac.fecha_emision_acta, ac.hora_inicio_partido,
			ac.hora_fin_partido, ac.duracion_partido, ac.num_gol_equipo_local, ac.num_gol_equipo_rival,
			ac.partido_id_partido, l.id_club as id_club_l, l.nombre as nombre_local, r.id_club as id_club_r, r.nombre as nombre_rival,
			ac.equipo_ganador FROM ACTA_PARTIDO ac 
			inner join partido p on ac.partido_id_partido = p.id_partido
			inner join club l on l.id_club = p.club_id_local
			inner join club r on r.id_club = p.club_id_rival
			WHERE AC.ID_ACTA_PARTIDO = @ID_ACTA

			SELECT 'OK' AS ERROR
		END

		/*IF UPPER(@TRANSACCION) = 'CONSULTA_ACTA_PARTIDO_POR'
		BEGIN

			SELECT ac.id_acta_partido, ac.fecha_emision_acta, ac.hora_inicio_partido,
			ac.hora_fin_partido, ac.duracion_partido, ac.num_gol_equipo_local, ac.num_gol_equipo_rival,
			ac.partido_id_partido, l.id_club as id_club_l, l.nombre AS NOMBRE_LOCAL, r.id_club as id_club_r, r.nombre AS NOMBRE_RIVAL,
			ac.equipo_ganador FROM ACTA_PARTIDO ac 
			inner join partido p on ac.partido_id_partido = p.id_partido
			inner join club l on l.id_club = p.club_id_local
			inner join club r on r.id_club = p.club_id_rival
			WHERE L.NOMBRE LIKE '%'+TRIM(@FILTRO)+'%' OR R.NOMBRE LIKE '%'+TRIM(@FILTRO)+'%' OR ac.EQUIPO_GANADOR LIKE '%'+TRIM(@FILTRO)+'%'

			SELECT 'OK' AS ERROR
		END */

	END TRY

	BEGIN CATCH
		--SELECT 'ERROR EN CONSULTA'
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END
GO


CREATE OR ALTER PROCEDURE [dbo].[SP_MAESTRO_ACTAS_PARTIDO]
	@TRANSACCION NVARCHAR(50),
	@DATAXML XML
AS
BEGIN
	DECLARE @ID INT
	DECLARE @CODIGO_ACTA VARCHAR(100)
	DECLARE @FECHA_EMISION VARCHAR(100)
	DECLARE @HORA_INICIO VARCHAR(100)
	DECLARE @HORA_FIN VARCHAR(100)
	DECLARE @EQUIPO_LOCAL VARCHAR(100)
	DECLARE @EQUIPO_RIVAL VARCHAR(100)
	DECLARE @DURACION_PARTIDO VARCHAR(100)
	DECLARE @NUM_GOL_EQUIPO_LOCAL INT
	DECLARE @NUM_GOL_EQUIPO_RIVAL INT
	DECLARE @TOTAL_TARJETA_AMARILLAS INT
	DECLARE @TOTAL_TARJETA_ROJAS INT
	DECLARE @EQUIPO_GANADOR VARCHAR(100)
	DECLARE @PARTIDO_ID INT 
	SELECT  @PARTIDO_ID = max(id_partido) from partido

	SET NOCOUNT ON

	BEGIN TRANSACTION
	BEGIN TRY
		
	
		SELECT @FECHA_EMISION = ISNULL(ACTAPARTIDO.X.value('FechaEmision[1]', 'VARCHAR(100)'), ''),
			@HORA_INICIO = ISNULL(ACTAPARTIDO.X.value('HoraInicio[1]', 'VARCHAR(100)'), ''),
			@HORA_FIN = ISNULL(ACTAPARTIDO.X.value('HoraFin[1]', 'VARCHAR(100)'), ''),
			@EQUIPO_LOCAL = ISNULL(ACTAPARTIDO.X.value('EquipoLocal[1]', 'VARCHAR(100)'), ''),
			@EQUIPO_RIVAL = ISNULL(ACTAPARTIDO.X.value('EquipoRival[1]', 'VARCHAR(100)'), ''),
			@DURACION_PARTIDO = ISNULL(ACTAPARTIDO.X.value('DuracionPartido[1]', 'VARCHAR(100)'),''),
			@NUM_GOL_EQUIPO_LOCAL = ISNULL(ACTAPARTIDO.X.value('NumGolEquipoLocal[1]', 'INT'), 0),
			@NUM_GOL_EQUIPO_RIVAL = ISNULL(ACTAPARTIDO.X.value('NumGolEquipoRival[1]', 'INT'), 0),
			@TOTAL_TARJETA_AMARILLAS = ISNULL(ACTAPARTIDO.X.value('TotTarjetAmarillas[1]', 'INT'), 0),
			@TOTAL_TARJETA_ROJAS = ISNULL(ACTAPARTIDO.X.value('TotTarjetaRojas[1]', 'INT'), 0),
			@EQUIPO_GANADOR = ISNULL(ACTAPARTIDO.X.value('EquipoGanador[1]', 'VARCHAR(100)'), 'YOMEROS'),
			@ID = ISNULL(ACTAPARTIDO.X.value('Id[1]', 'INT'), 0)
			FROM @DATAXML.nodes('/ActaPartido') as ACTAPARTIDO(X)

		IF @TRANSACCION = 'CREAR_ACTA_PARTIDO'
		BEGIN
			--PRINT 'GUARADAR ACTA PARTIDO'

			INSERT INTO ACTA_PARTIDO (CODIGO_ACTA, FECHA_EMISION_ACTA, HORA_INICIO_PARTIDO, HORA_FIN_PARTIDO, EQUIPO_LOCAL, EQUIPO_RIVAL,
			DURACION_PARTIDO, NUM_GOL_EQUIPO_LOCAL, NUM_GOL_EQUIPO_RIVAL, TOTAL_TARJETA_AMARILLAS, TOTAL_TARJETA_ROJAS, EQUIPO_GANADOR, CREATE_AT,
			ESTADO, PARTIDO_ID_PARTIDO)
			VALUES('default-c', @FECHA_EMISION, @HORA_INICIO, @HORA_FIN, @EQUIPO_LOCAL, @EQUIPO_RIVAL, @DURACION_PARTIDO, @NUM_GOL_EQUIPO_LOCAL,
			@NUM_GOL_EQUIPO_RIVAL, @TOTAL_TARJETA_AMARILLAS, @TOTAL_TARJETA_ROJAS, @EQUIPO_GANADOR, GETDATE(), 'A', @PARTIDO_ID)

			IF @@ROWCOUNT > 0
			BEGIN
				SELECT 'OK' AS ERROR
			END
		END

		IF @TRANSACCION = 'ACTUALIZAR_ACTA_PARTIDO'
		BEGIN
			PRINT 'ACTUALIZAR ACTA PARTIDO ...'

			--PRINT 'FECHA '+ @FECHA_EMISION 

			UPDATE ACTA_PARTIDO SET CODIGO_ACTA = 'default-c',
			--FECHA_EMISION_ACTA = @FECHA_EMISION,
			HORA_INICIO_PARTIDO = @HORA_INICIO,
			HORA_FIN_PARTIDO = @HORA_FIN,
			EQUIPO_LOCAL = @EQUIPO_LOCAL,
			EQUIPO_RIVAL = @EQUIPO_RIVAL,
			DURACION_PARTIDO = @DURACION_PARTIDO,
			NUM_GOL_EQUIPO_LOCAL = @NUM_GOL_EQUIPO_LOCAL,
			NUM_GOL_EQUIPO_RIVAL = @NUM_GOL_EQUIPO_RIVAL,
			TOTAL_TARJETA_AMARILLAS = @TOTAL_TARJETA_AMARILLAS,
			TOTAL_TARJETA_ROJAS = @TOTAL_TARJETA_ROJAS,
			EQUIPO_GANADOR = @EQUIPO_GANADOR,
			UPDATE_AT = GETDATE(),
			ESTADO = 'A' WHERE ID_ACTA_PARTIDO = @ID

			IF @@ROWCOUNT > 0
			BEGIN
				SELECT 'Actualizado correctamente' AS ERROR
			END	
			ELSE
			BEGIN
				SELECT 'ERROR, EN TRANSACCION ACTUALIZAR ACTA CON ID ' + CAST(@ID AS VARCHAR(5)) AS ERROR
			END
		END

		IF @TRANSACCION = 'ELIMINAR_ACTA_PARTIDO'
		BEGIN
			--PRINT 'ACTUALIZAR ACTA PARTIDO'
			PRINT @ID

			UPDATE ACTA_PARTIDO SET ESTADO = 'E' WHERE ID_ACTA_PARTIDO = @ID

			IF @@ROWCOUNT > 0
			BEGIN
				SELECT 'Eliminado Correctamente' AS ERROR
			END
		END

		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		--PRINT 'ERROR ES ' + ERROR_MESSAGE()
		SELECT ERROR_MESSAGE() AS ERROR , ERROR_LINE() AS ERRO_LINEA
	END CATCH

END
GO