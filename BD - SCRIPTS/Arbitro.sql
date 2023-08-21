USE [PROJECT_FAF_DAW]
GO

CREATE OR ALTER  PROCEDURE [dbo].[SP_CONSULTAR_ARBITRO]
	@TRANSACCION varchar(100),
	@DATAXML XML = null
AS
BEGIN

	
	BEGIN TRY

		IF UPPER(@TRANSACCION) = 'CONSULTAR_TDS_ARBITRO'
		BEGIN
			SELECT arb.id_arbitro, arb.categoria, arb.nombre,
			arb.apellido, arb.email, arb.nombre_usuario, arb.contrasenia, arb.edad,
			arb.nacionalidad, arb.cantidad_partidos FROM ARBITRO arb 

			SELECT 'OK' AS ERROR

		END

		IF UPPER(@TRANSACCION) = 'CONSULTA_ARBITRO'
		BEGIN
			DECLARE @ID_ARBITRO AS INT
			SET @ID_ARBITRO = 1

			SELECT arb.id_arbitro, arb.categoria, arb.nombre,
			arb.apellido, arb.email, arb.nombre_usuario, arb.contrasenia, arb.edad,
			arb.nacionalidad, arb.cantidad_partidos FROM ARBITRO arb 

			SELECT 'OK' AS ERROR
		END
	END TRY

	BEGIN CATCH
		--SELECT 'ERROR EN CONSULTA'
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END
GO


CREATE OR ALTER PROCEDURE [dbo].[SP_MAESTRO_ARBITRO]
	@TRANSACCION NVARCHAR(50),
	@DATAXML XML
AS
BEGIN
	DECLARE @ID INT
	DECLARE @CATEGORIA VARCHAR(100)
	DECLARE @NOMBRE VARCHAR(100)
	DECLARE @APELLIDO VARCHAR(100)
	DECLARE @EMAIL VARCHAR(100)
	DECLARE @NOMBRE_USUARIO VARCHAR(100)
	DECLARE @CONTRASENIA VARCHAR(100)
	DECLARE @EDAD INT
	DECLARE @NACIONALIDAD VARCHAR(100)
	DECLARE @CANTIDAD_PARTIDOS INT

	SET NOCOUNT ON

	BEGIN TRANSACTION
	BEGIN TRY
		
	
		SELECT @CATEGORIA = ISNULL(ARBITRO.X.value('Categoria[1]', 'VARCHAR(100)'), ''),
			@NOMBRE = ISNULL(ARBITRO.X.value('Nombre[1]', 'VARCHAR(100)'), ''),
			@APELLIDO = ISNULL(ARBITRO.X.value('Apellido[1]', 'VARCHAR(100)'), ''),
			@EMAIL = ISNULL(ARBITRO.X.value('Email[1]', 'VARCHAR(100)'), ''),
			@NOMBRE_USUARIO = ISNULL(ARBITRO.X.value('NombreUsuario[1]', 'VARCHAR(100)'), ''),
			@CONTRASENIA = ISNULL(ARBITRO.X.value('Contrasenia[1]', 'VARCHAR(100)'),''),
			@EDAD = ISNULL(ARBITRO.X.value('Edad[1]', 'INT'), ''),
			@NACIONALIDAD = ISNULL(ARBITRO.X.value('Nacionalidad[1]', 'VARCHAR(100)'), ''),
			@CANTIDAD_PARTIDOS = ISNULL(ARBITRO.X.value('CantPartidos[1]', 'INT'), ''),
			@ID = ISNULL(ARBITRO.X.value('Id[1]', 'INT'), 0)
			FROM @DATAXML.nodes('/Arbitro') as ARBITRO(X)

		IF @TRANSACCION = 'CREAR_ARBITRO'
		BEGIN
			--PRINT 'GUARDAR ARBITRO'

			INSERT INTO ARBITRO (CATEGORIA, NOMBRE, APELLIDO, EMAIL, NOMBRE_USUARIO, CONTRASENIA, EDAD, NACIONALIDAD, CANTIDAD_PARTIDOS, CREATE_AT, ESTADO )
			VALUES(@CATEGORIA, @NOMBRE, @APELLIDO, @EMAIL, @NOMBRE_USUARIO, @CONTRASENIA, @EDAD, @NACIONALIDAD, @CANTIDAD_PARTIDOS, GETDATE(), 'A')

			IF @@ROWCOUNT > 0
			BEGIN
				SELECT 'OK' AS ERROR
			END
		END

		IF @TRANSACCION = 'ACTUALIZAR_ARBITRO'
		BEGIN
			--PRINT 'ACTUALIZAR ARBITRO ...'

			--ACTUALIZAR 

			UPDATE ARBITRO SET CATEGORIA = @CATEGORIA,
			NOMBRE = @NOMBRE,
			APELLIDO = @APELLIDO,
			EMAIL = @EMAIL,
			NOMBRE_USUARIO = @NOMBRE_USUARIO,
			CONTRASENIA = @CONTRASENIA,
			EDAD = @EDAD,
			NACIONALIDAD = @NACIONALIDAD,
			CANTIDAD_PARTIDOS = @CANTIDAD_PARTIDOS,
			ESTADO = 'A' WHERE ID_ARBITRO = @ID

			IF @@ROWCOUNT > 0
			BEGIN
				SELECT 'Actualizado correctamente' AS ERROR
			END	
			ELSE
			BEGIN
				SELECT 'ERROR, EN TRANSACCION ACTUALIZAR ' + CAST(@ID AS VARCHAR(5)) AS ERROR
			END
		END

		IF @TRANSACCION = 'ELIMINAR_ARBITRO'
		BEGIN
			--ELIMINAR
			PRINT @ID

			UPDATE ARBITRO SET ESTADO = 'E' WHERE ID_ARBITRO = @ID

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


Select * From arbitro