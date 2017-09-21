
use master
--Creacion de base de datos de BiosRealState
IF EXISTS(SELECT * FROM SysDataBases WHERE name='BiosRealState')
BEGIN
	USE master
	DROP DATABASE BiosRealState
END
GO

CREATE DATABASE BiosRealState
GO

-- Usar la bd
USE BiosRealState
GO

CREATE TABLE Zona
(
	Nombre VARCHAR(3) NOT NULL CHECK (Nombre like '[A-Z][A-Z][A-Z]'),
	Departamento VARCHAR(1) NOT NULL CHECK (Departamento like '[A-S]'),
	NombreOficial VARCHAR(20) NOT NULL,
	Habitantes INT NOT NULL CHECK (Habitantes > 0),
	PRIMARY KEY(Nombre, Departamento),
	Activo BIT DEFAULT 1  ---1 Activo   0 Desactivado
)
GO

CREATE TABLE Servicios
(
	Nombre VARCHAR(3) NOT NULL,
	Departamento VARCHAR(1) NOT NULL,
	Servicio VARCHAR(20) NOT NULL,
	PRIMARY KEY(Nombre, Departamento,Servicio),
	FOREIGN KEY (Nombre, Departamento) REFERENCES Zona(Nombre, Departamento)
)
GO

CREATE TABLE Empleado
(
	NombreLogueo VARCHAR(10) PRIMARY KEY NOT NULL,
	Contrasenia VARCHAR(10) NOT NULL CHECK (LEN(Contrasenia)= 10),-- Verificar con replace, Saca todos los espacios y preguntar 
	Activo INT DEFAULT 1 NOT NULL
)
GO

CREATE TABLE Propiedades
(
	Padron INT PRIMARY KEY NOT NULL,
	Departamento VARCHAR(1) NOT NULL,
	Nombre VARCHAR(3) NOT NULL,
	NombreLogueo VARCHAR(10) FOREIGN KEY REFERENCES Empleado(NombreLogueo),
	Precio INT NOT NULL CHECK (Precio > 0),
	Direccion VARCHAR(50) NOT NULL CHECK (LEN(Direccion)>=10),
	TipoDeAccion VARCHAR(8) NOT NULL CHECK (TipoDeAccion IN ('Venta', 'Alquiler', 'Permuta')),
	Banios INT NOT NULL CHECK (Banios > 0),
	Habitaciones INT NOT NULL CHECK (Habitaciones >= 0),
	MetrosCuadradosP INT NOT NULL CHECK (MetrosCuadradosP > 0), --MetrosCuadradosP son los del tamaño del terreno
	FOREIGN KEY (Nombre, Departamento) REFERENCES Zona(Nombre, Departamento)
)
GO

CREATE TABLE Apartamento
(
	Padron INT PRIMARY KEY FOREIGN KEY REFERENCES Propiedades (Padron),
	Ascensor BIT NOT NULL DEFAULT 0,
	Piso INT NOT NULL CHECK (Piso >= 0)
)
GO

CREATE TABLE Casa
(
	Padron INT PRIMARY KEY FOREIGN KEY REFERENCES Propiedades (Padron),
	FondoJardin BIT NOT NULL,
	MetrosCuadradosC INT NOT NULL CHECK (MetrosCuadradosC >0)--MetrosCuadradosC son los Construidos
)
GO

CREATE TABLE LocaL
(
	Padron INT PRIMARY KEY FOREIGN KEY REFERENCES Propiedades (Padron),
	Habilitacion BIT NOT NULL
)
GO

CREATE TABLE Visita
(
	IdVisita INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	FechaHora DATETIME NOT NULL CHECK (FechaHora > GETDATE()),
	Telefono INT NOT NULL,
	Nombre VARCHAR(20),
	Padron INT FOREIGN KEY REFERENCES Propiedades (Padron)
)
GO

-- Store procedures

-------------------------------------------------------------------------
------------------------------SP EMPLEADOS-------------------------------
-------------------------------------------------------------------------
CREATE PROCEDURE INICIAR_SESSION
@NombreLogueo VARCHAR(10),
@Contrasenia VARCHAR(10)
AS
BEGIN
	SELECT * FROM Empleado 
	WHERE @NombreLogueo = NombreLogueo 
	AND @Contrasenia = Contrasenia 
	AND Activo = 1
END
GO

CREATE PROCEDURE LISTAR_EMPLEADOS
AS
BEGIN
	SELECT * FROM Empleado 
	WHERE Activo = 1
END
GO

CREATE PROCEDURE LOGIN_EMPLEADO
@NombreLogueo VARCHAR(10),
@Contraseña VARCHAR(10)
AS
BEGIN
	SELECT * FROM Empleado 
	WHERE NombreLogueo = @NombreLogueo
	AND Contrasenia = @Contraseña 
	AND Activo = 1
END
GO

CREATE PROCEDURE BUSCAR_EMPLEADOST
@NombreLogueo VARCHAR(10)
AS
BEGIN
	SELECT * FROM Empleado 
	WHERE NombreLogueo = @NombreLogueo
END
GO

CREATE PROCEDURE BUSCAR_EMPLEADOS
@NombreLogueo VARCHAR(10)
AS
BEGIN
	SELECT * FROM Empleado 
	WHERE NombreLogueo = @NombreLogueo
	AND Activo = 1
END
GO

CREATE PROCEDURE CREAR_EMPLEADO
@NombreLogueo VARCHAR(10),
@Contrasenia VARCHAR(10)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo)
		BEGIN
			INSERT INTO Empleado (NombreLogueo, Contrasenia) 
			VALUES(@NombreLogueo, @Contrasenia)
			RETURN 1
		END
	ELSE IF EXISTS(SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo AND Activo = 0)
		BEGIN
			UPDATE Empleado SET Contrasenia = @Contrasenia, Activo = 1 
			WHERE NombreLogueo = @NombreLogueo
			RETURN 1
		END
	ELSE
		BEGIN
			RETURN -1
		END
END
GO

CREATE PROCEDURE MODIFICAR_EMPLEADO
@NombreLogueo VARCHAR(10),
@Contrasenia VARCHAR(10),
@Activo INT
AS
BEGIN
	IF EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo AND Activo = 1)
		BEGIN
			UPDATE Empleado SET Contrasenia = @Contrasenia, Activo = @Activo 
			WHERE NombreLogueo = @NombreLogueo
			RETURN 1
		END
	ELSE
		BEGIN
			RETURN -1
		END
END
GO

CREATE PROCEDURE BORRAR_EMPLEADO
@NombreLogueo VARCHAR(10)
AS
BEGIN
	IF EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo)
		BEGIN
			IF EXISTS (SELECT * FROM Propiedades WHERE NombreLogueo = @NombreLogueo)
				BEGIN
					UPDATE Empleado
					SET Activo = 0
					WHERE NombreLogueo = @NombreLogueo
					RETURN 1
				END
			ELSE
				BEGIN
					DELETE Empleado
					WHERE NombreLogueo = @NombreLogueo
					RETURN 2
				END
		END
	ELSE
		BEGIN
			RETURN -1
		END
END
GO 

-------------------------------------------------------------------------
------------------------------SP ZONAS-----------------------------------
-------------------------------------------------------------------------
CREATE PROCEDURE LISTAR_ZONAS
AS
BEGIN
	SELECT * FROM Zona 
	WHERE Activo = 1
END
GO

CREATE PROCEDURE BUSCAR_ZONAS
@Nombre VARCHAR(3),
@Departamento VARCHAR(1)
AS
BEGIN
	SELECT * FROM Zona 
	WHERE Departamento = @Departamento
	AND Nombre = @Nombre
	AND Activo = 1
END
GO

CREATE PROCEDURE BUSCAR_ZONAST
@Nombre VARCHAR(3),
@Departamento VARCHAR(1)
AS
BEGIN
	SELECT * FROM Zona 
	WHERE Departamento = @Departamento
	AND Nombre = @Nombre
END
GO

CREATE PROCEDURE CREAR_ZONA
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreOficial VARCHAR(20),
@Habitantes INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN
			INSERT INTO Zona (Nombre, Departamento, NombreOficial, Habitantes) VALUES(@Nombre, @Departamento, @NombreOficial, @Habitantes)
			RETURN 1
		END
	ELSE IF EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento AND Activo = 0)
		BEGIN
			UPDATE Zona SET NombreOficial = @NombreOficial, Habitantes = @Habitantes, Activo = 1 
			WHERE Nombre = @Nombre 
			AND Departamento = @Departamento
			RETURN 2
		END
	ELSE
		BEGIN
			RETURN -1
		END
END

GO

CREATE PROCEDURE MODIFICAR_ZONA
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreOficial VARCHAR(20),
@Habitantes INT
AS
BEGIN
	IF EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento AND Activo = 1)
		BEGIN
			UPDATE Zona set NombreOficial = @NombreOficial, Habitantes = @Habitantes
			WHERE Nombre = @Nombre AND Departamento = @Departamento
			RETURN 1
		END
	ELSE
		BEGIN
			RETURN -1
		END
END

GO

CREATE PROCEDURE BORRAR_ZONA
@Nombre VARCHAR(3),
@Departamento VARCHAR(1)
AS
BEGIN
	IF EXISTS (SELECT * FROM ZONA WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN	
			IF EXISTS (SELECT * FROM Propiedades WHERE Nombre = @Nombre AND Departamento = @Departamento)
				BEGIN	
					UPDATE ZONA
					SET Activo = 0
					WHERE Nombre = @Nombre AND Departamento = @Departamento
					RETURN 1
				END
			ELSE
				BEGIN
					BEGIN TRANSACTION
						DELETE Servicios
						WHERE Nombre = @Nombre AND Departamento = @Departamento

						IF(@@ERROR <>0)
							BEGIN
								ROLLBACK TRANSACTION
								RETURN -1
							END

						DELETE Zona
						WHERE Nombre = @Nombre AND Departamento = @Departamento

						IF (@@ERROR <> 0)
							BEGIN
								ROLLBACK TRANSACTION
								RETURN -2
							END
						ELSE
							BEGIN
								COMMIT TRANSACTION
								RETURN 2
							END
					END
				END
	ELSE
		BEGIN
			RETURN -3
		END
END
GO

--------------------------------------------------------------------------
------------------------------SP SERVICIOS--------------------------------
--------------------------------------------------------------------------
CREATE PROCEDURE LISTAR_SERVICIOS
@Departamento VARCHAR(1),
@Nombre VARCHAR(3)
AS
BEGIN
	SELECT * FROM Servicios 
	WHERE Nombre = @Nombre and Departamento = @Departamento
END
GO

CREATE PROCEDURE CREAR_SERVICIO
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@Servicio VARCHAR(20)
AS
BEGIN
	IF EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento AND Activo = 1)
		BEGIN
			IF NOT EXISTS (SELECT * FROM Servicios WHERE Nombre = @Nombre AND Departamento = @Departamento AND Servicio = @Servicio)
				BEGIN
					INSERT INTO Servicios (Nombre, Departamento, Servicio) VALUES (@Nombre, @Departamento, @Servicio)
					RETURN 1
				END
			ELSE
				BEGIN
				RETURN -1
			END
		END
	ELSE
		BEGIN
			RETURN -2
		END
END
GO

CREATE PROCEDURE ELIMINAR_SERVICIO
@Nombre VARCHAR(3),
@Departamento VARCHAR(1)
AS
BEGIN
	IF EXISTS (SELECT * FROM Servicios WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN
			DELETE FROM Servicios WHERE Nombre = @Nombre AND Departamento = @Departamento
		END
	ELSE
		BEGIN
			RETURN -1
		END
END
GO

---------------------------------------------------------------------------
------------------------------SP CASAS-------------------------------------
---------------------------------------------------------------------------
CREATE PROCEDURE CREAR_CASA
@Padron INT,
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreLogueo VARCHAR(10),
@Precio INT,
@Direccion VARCHAR(30),
@TipoDeAccion VARCHAR(8),
@Banios INT,
@Habitaciones INT,
@MetrosCuadradosP INT,
@Fondo_Jardin BIT,
@MetrosCuadradosC INT
AS
BEGIN
	IF (@MetrosCuadradosC > @MetrosCuadradosP)
		BEGIN
			RETURN -1
		END
	IF NOT EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo)
		BEGIN
			RETURN -2
		END
	IF NOT EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN
			RETURN -3
		END
	IF NOT EXISTS (SELECT * FROM Propiedades WHERE Padron = @Padron)
	BEGIN
		BEGIN TRANSACTION
			INSERT INTO Propiedades (Padron, Nombre, Departamento, NombreLogueo, Precio, Direccion, TipoDeAccion, Banios, Habitaciones, MetrosCuadradosP)
			VALUES(@Padron, @Nombre, @Departamento, @NombreLogueo, @Precio, @Direccion, @TipoDeAccion, @Banios, @Habitaciones, @MetrosCuadradosP)

			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -4
				END

			INSERT INTO Casa (Padron, FondoJardin, MetrosCuadradosC)
			VALUES (@Padron, @Fondo_Jardin, @MetrosCuadradosC)

			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -5
				END

			ELSE 
				BEGIN
					COMMIT TRANSACTION
					RETURN 1
				END
	END
						
	ELSE
		BEGIN
			RETURN -6
		END
END
GO

CREATE PROCEDURE MODIFICAR_CASA
@Padron INT,
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreLogueo VARCHAR(10),
@Precio INT,
@Direccion VARCHAR(30),
@TipoDeAccion VARCHAR(8),
@Banios INT,
@Habitaciones INT,
@MetrosCuadradosP INT,
@Fondo_Jardin BIT,
@MetrosCuadradosC INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo AND Activo = 1)
		BEGIN
			RETURN -1
		END
	IF NOT EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento AND Activo = 1)
		BEGIN
			RETURN -2
		END
	IF NOT EXISTS(SELECT * FROM Casa WHERE Padron = @Padron)
		BEGIN
			RETURN -1
		END
	ELSE
		BEGIN TRANSACTION
				UPDATE Propiedades SET Nombre = @Nombre,Departamento = @Departamento,NombreLogueo = @NombreLogueo,Precio = @Precio,Direccion = @Direccion,TipoDeAccion = @TipoDeAccion,Banios = @Banios,Habitaciones = @Habitaciones,MetrosCuadradosP = @MetrosCuadradosP
				WHERE Padron = @Padron
				IF(@@ERROR <> 0 )
					BEGIN
						ROLLBACK TRANSACTION
						RETURN -2
					END
				UPDATE Casa SET FondoJardin = @Fondo_Jardin,MetrosCuadradosC = @MetrosCuadradosC
				WHERE Padron = @Padron
				IF (@@ERROR <> 0 )
					BEGIN
						ROLLBACK TRANSACTION
						RETURN -3
					END
			ELSE
				BEGIN
					COMMIT TRANSACTION
					RETURN 1
				END
	END
GO
		 
CREATE PROCEDURE BORRAR_CASA
@Padron INT
AS
BEGIN
	IF EXISTS (SELECT * FROM Casa WHERE Padron = @Padron)
		BEGIN
			BEGIN TRANSACTION
				DELETE Visita
				WHERE Padron = @Padron

				IF (@@ERROR <> 0)
					BEGIN 
						RETURN -1
					END

				DELETE Casa
				WHERE Padron = @Padron

				IF (@@ERROR <> 0)
					BEGIN
						RETURN -1
					END

				DELETE Propiedades
				WHERE Padron = @Padron
						
				IF (@@ERROR <> 0)
					BEGIN	
						RETURN -1
					END
				ELSE
					BEGIN
						COMMIT TRANSACTION
						RETURN 1
					END
			END
	ELSE
		BEGIN
			RETURN -1
		END
END
GO

CREATE PROCEDURE LISTAR_CASA
AS
BEGIN
	SELECT * FROM Propiedades P 
	JOIN Casa C ON C.Padron = P.Padron
END
GO

CREATE PROCEDURE BUSCAR_CASA
@Padron INT
AS
BEGIN
	SELECT * FROM Casa C
	JOIN Propiedades P ON C.Padron = P.Padron
	WHERE C.Padron = @Padron
END
GO 

--------------------------------------------------------------------------
------------------------------SP LOCAL------------------------------------
--------------------------------------------------------------------------
CREATE PROCEDURE CREAR_LOCAL
@Padron INT,
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreLogueo VARCHAR(10),
@Precio INT,
@Direccion VARCHAR(30),
@TipoDeAccion VARCHAR(8),
@Banios INT,
@Habitaciones INT,
@MetrosCuadradosP INT,
@Habilitacion BIT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo)
		BEGIN
			RETURN -1
		END
	IF NOT EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN
			RETURN -2
		END
	IF NOT EXISTS (SELECT * FROM Propiedades WHERE Padron = @Padron)
	BEGIN
		BEGIN TRANSACTION
				INSERT INTO Propiedades (Padron, Nombre, Departamento, NombreLogueo, Precio, Direccion, TipoDeAccion, Banios, Habitaciones, MetrosCuadradosP)
				VALUES(@Padron, @Nombre, @Departamento, @NombreLogueo, @Precio, @Direccion, @TipoDeAccion, @Banios, @Habitaciones, @MetrosCuadradosP)

				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN -3
					END

				INSERT INTO Local(Padron, Habilitacion)
				VALUES (@Padron, @Habilitacion)

				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN -4
					END
				ELSE 
					BEGIN
						COMMIT TRANSACTION
						RETURN 1
					END						
				END
	ELSE
		BEGIN
			RETURN -5
		END
	END
GO

CREATE PROCEDURE MODIFICAR_LOCAL
@Padron INT,
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreLogueo VARCHAR(10),
@Precio INT,
@Direccion VARCHAR(30),
@TipoDeAccion VARCHAR(8),
@Banios INT,
@Habitaciones INT,
@MetrosCuadradosP INT,
@Habilitacion BIT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo)
		BEGIN
			RETURN -1
		END
	IF NOT EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN
			RETURN -2
		END
	IF EXISTS(SELECT * FROM LocaL WHERE Padron = @Padron)
		BEGIN
			BEGIN TRANSACTION
				UPDATE Propiedades
				SET Nombre = @Nombre,Departamento = @Departamento,NombreLogueo = @NombreLogueo,Precio = @Precio,Direccion = @Direccion,TipoDeAccion = @TipoDeAccion,Banios = @Banios,Habitaciones = @Habitaciones,MetrosCuadradosP = @MetrosCuadradosP
				WHERE Padron = @Padron
				IF(@@ERROR <> 0 )
					BEGIN
						ROLLBACK TRANSACTION
						RETURN -1
					END
				UPDATE LocaL
				SET Habilitacion = @Habilitacion
				WHERE Padron = @Padron
				IF(@@ERROR <> 0 )
					BEGIN
						ROLLBACK TRANSACTION
						RETURN -2
					END
			ELSE
				BEGIN
					COMMIT TRANSACTION
					RETURN 1
				END
		END
END
GO

CREATE PROCEDURE BORRAR_LOCAL
@Padron INT
AS
BEGIN
	IF EXISTS (SELECT * FROM LocaL WHERE Padron = @Padron)
		BEGIN
			BEGIN TRANSACTION
			DELETE Visita
			WHERE Padron = @Padron

			IF (@@ERROR <> 0)
				BEGIN 
					RETURN -1
				END

			DELETE LocaL
			WHERE Padron = @Padron

			IF (@@ERROR <> 0)
				BEGIN
					RETURN -2
				END

			DELETE Propiedades
			WHERE Padron = @Padron
						
			IF (@@ERROR <> 0)
				BEGIN	
					RETURN -3
				END
			ELSE
				BEGIN
					COMMIT TRANSACTION
					RETURN 1
				END
		END
	ELSE
		BEGIN
			RETURN -4
		END
END
GO

CREATE PROCEDURE LISTAR_LOCAL
AS
BEGIN
	SELECT * FROM Propiedades P 
	JOIN LocaL L ON P.Padron = L.Padron
END
GO

CREATE PROCEDURE BUSCAR_LOCAL
@Padron INT
AS
BEGIN
	SELECT * FROM Propiedades P 
	JOIN LocaL L ON P.Padron = L.Padron
	WHERE L.Padron = @Padron
END
GO

--------------------------------------------------------------------------
------------------------------SP APARTAMENTO------------------------------
--------------------------------------------------------------------------
CREATE PROCEDURE CREAR_APARTAMENTO
@Padron INT,
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreLogueo VARCHAR(10),
@Precio INT,
@Direccion VARCHAR(30),
@TipoDeAccion VARCHAR(8),
@Banios INT,
@Habitaciones INT,
@MetrosCuadradosP INT,
@Asensor BIT,
@Piso INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo)
		BEGIN
			RETURN -1
		END
	IF NOT EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN
			RETURN -2
		END
	IF NOT EXISTS (SELECT * FROM Propiedades WHERE Padron = @Padron)
	BEGIN
		BEGIN TRANSACTION

			INSERT INTO Propiedades (Padron, Nombre, Departamento, NombreLogueo, Precio, Direccion, TipoDeAccion, Banios, Habitaciones, MetrosCuadradosP)
			VALUES(@Padron, @Nombre, @Departamento, @NombreLogueo, @Precio, @Direccion, @TipoDeAccion, @Banios, @Habitaciones, @MetrosCuadradosP)

			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -2
				END

			INSERT INTO Apartamento(Padron, Ascensor, Piso)
			VALUES (@Padron, @Asensor, @Piso)

			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -3
				END

			ELSE 
				BEGIN
					COMMIT TRANSACTION
					RETURN 1
				END	
	END					
	ELSE
		BEGIN
			RETURN -4
		END
	END
GO

CREATE PROCEDURE MODIFICAR_APARTAMENTO
@Padron INT,
@Nombre VARCHAR(3),
@Departamento VARCHAR(1),
@NombreLogueo VARCHAR(10),
@Precio INT,
@Direccion VARCHAR(30),
@TipoDeAccion VARCHAR(8),
@Banios INT,
@Habitaciones INT,
@MetrosCuadradosP INT,
@Ascensor BIT,
@Piso INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Empleado WHERE NombreLogueo = @NombreLogueo)
		BEGIN
			RETURN -1
		END
	IF NOT EXISTS (SELECT * FROM Zona WHERE Nombre = @Nombre AND Departamento = @Departamento)
		BEGIN
			RETURN -2
		END
	IF NOT EXISTS (SELECT * FROM Apartamento WHERE Padron = @Padron)
		BEGIN
			RETURN -1
		END
	ELSE
		BEGIN TRANSACTION
			UPDATE Propiedades
			SET Nombre = @Nombre,Departamento = @Departamento,NombreLogueo = @NombreLogueo,Precio = @Precio,Direccion = @Direccion,TipoDeAccion = @TipoDeAccion,Banios = @Banios,Habitaciones = @Habitaciones,MetrosCuadradosP = @MetrosCuadradosP
			WHERE Padron = @Padron

			IF(@@ERROR <> 0 )
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -1
				END

			UPDATE Apartamento
			SET Ascensor = @Ascensor, Piso  = @Piso

			IF(@@ERROR <> 0 )
				BEGIN
					ROLLBACK TRANSACTION
					RETURN -2
				END
		ELSE
			BEGIN
				COMMIT TRANSACTION
				RETURN 1
			END
END
GO

CREATE PROCEDURE BORRAR_APARTAMENTO
@Padron INT
AS
BEGIN
	IF EXISTS (SELECT * FROM Apartamento WHERE Padron = @Padron)
		BEGIN
			BEGIN TRANSACTION
			DELETE Visita
			WHERE Padron = @Padron

			IF (@@ERROR <> 0)
				BEGIN 
					RETURN -1
				END

			DELETE Apartamento
			WHERE Padron = @Padron

			IF (@@ERROR <> 0)
				BEGIN
					RETURN -2
				END

			DELETE Propiedades
			WHERE Padron = @Padron
						
			IF (@@ERROR <> 0)
				BEGIN	
					RETURN -3
				END
		ELSE
			BEGIN
				COMMIT TRANSACTION
				RETURN 1
			END
		END
		ELSE
			BEGIN
				RETURN -1
			END
END
GO

CREATE PROCEDURE LISTAR_APARTAMENTO
AS
BEGIN
	SELECT * FROM Propiedades P 
	JOIN Apartamento A ON P.Padron=A.Padron
END
GO

CREATE PROCEDURE BUSCAR_APARTAMENTO
@Padron INT
AS
BEGIN
	SELECT * FROM Propiedades P 
	JOIN Apartamento A ON P.Padron = A.Padron
	WHERE A.Padron = @Padron

END
GO

-------------------------------------------------------------------------
------------------------------CREAR VISITA-------------------------------
-------------------------------------------------------------------------
CREATE PROCEDURE CREAR_VISITA
@Padron INT,
@FechaHora DATETIME,
@Telefono INT,
@Nombre VARCHAR(20)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Visita WHERE Padron = @Padron AND FechaHora = @FechaHora)
		BEGIN
			IF ((SELECT COUNT(*) FROM Visita WHERE Telefono = @Telefono AND Padron = @Padron) < 2)
			BEGIN
				INSERT INTO Visita (FechaHora,Telefono,Nombre,Padron)
				VALUES (@FechaHora,@Telefono,@Nombre,@Padron)
				RETURN 1
			END
			ELSE
				BEGIN
					RETURN -1
				END
		END
	ELSE
		BEGIN
			RETURN -2
		END
END
GO

-------------------------------------------------------------------------
------------------------------DATOS PRUEBAS EMPLEADOS--------------------
-------------------------------------------------------------------------
EXEC CREAR_EMPLEADO 'admin', '1234567890'
EXEC CREAR_EMPLEADO 'rodri','1234567890'

-------------------------------------------------------------------------
------------------------------DATOS PRUEBA ZONA--------------------------
------------------------------DATOS PRUEBA SERVICIOS---------------------
-------------------------------------------------------------------------
GO
EXEC CREAR_ZONA 'AAA', 'A', 'ZONA PRUEBA 1 A', 850000
EXEC CREAR_SERVICIO 'AAA', 'A', 'Netflix'
EXEC CREAR_SERVICIO 'AAA', 'A', 'Spotify'
EXEC CREAR_SERVICIO 'AAA', 'A', 'VERA'
EXEC CREAR_SERVICIO 'AAA', 'A', 'TV Cable'

EXEC CREAR_ZONA 'AAB', 'A', 'ZONA PRUEBA 2 A', 850000
EXEC CREAR_SERVICIO 'AAB', 'A', 'Netflix'
EXEC CREAR_SERVICIO 'AAB', 'A', 'Spotify'
EXEC CREAR_SERVICIO 'AAB', 'A', 'VERA'
EXEC CREAR_SERVICIO 'AAB', 'A', 'TV Cable'

EXEC CREAR_ZONA 'BBB', 'B', 'ZONA PRUEBA 1 B', 850000
EXEC CREAR_SERVICIO 'BBB', 'B', 'Netflix'
EXEC CREAR_SERVICIO 'BBB', 'B', 'Spotify'
EXEC CREAR_SERVICIO 'BBB', 'B', 'VERA'
EXEC CREAR_SERVICIO 'BBB', 'B', 'TV Cable'

EXEC CREAR_ZONA 'BBC', 'B', 'ZONA PRUEBA 2 B', 850000
EXEC CREAR_SERVICIO 'BBC', 'B', 'Netflix'
EXEC CREAR_SERVICIO 'BBC', 'B', 'Spotify'
EXEC CREAR_SERVICIO 'BBC', 'B', 'VERA'
EXEC CREAR_SERVICIO 'BBC', 'B', 'TV Cable'

EXEC CREAR_ZONA 'CCC', 'C', 'ZONA PRUEBA 1 C', 850000
EXEC CREAR_SERVICIO 'CCC', 'C', 'Netflix'
EXEC CREAR_SERVICIO 'CCC', 'C', 'Spotify'
EXEC CREAR_SERVICIO 'CCC', 'C', 'VERA'
EXEC CREAR_SERVICIO 'CCC', 'C', 'TV Cable'

EXEC CREAR_ZONA 'CCD', 'C', 'ZONA PRUEBA 2 C', 850000
EXEC CREAR_SERVICIO 'CCD', 'C', 'Netflix'
EXEC CREAR_SERVICIO 'CCD', 'C', 'Spotify'
EXEC CREAR_SERVICIO 'CCD', 'C', 'VERA'
EXEC CREAR_SERVICIO 'CCD', 'C', 'TV Cable'

EXEC CREAR_ZONA 'DDD', 'D', 'ZONA PRUEBA 1 D', 850000
EXEC CREAR_SERVICIO 'DDD', 'D', 'Netflix'
EXEC CREAR_SERVICIO 'DDD', 'D', 'Spotify'
EXEC CREAR_SERVICIO 'DDD', 'D', 'VERA'
EXEC CREAR_SERVICIO 'DDD', 'D', 'TV Cable'

EXEC CREAR_ZONA 'DDE', 'D', 'ZONA PRUEBA 2 D', 850000
EXEC CREAR_SERVICIO 'DDE', 'D', 'Netflix'
EXEC CREAR_SERVICIO 'DDE', 'D', 'Spotify'
EXEC CREAR_SERVICIO 'DDE', 'D', 'VERA'
EXEC CREAR_SERVICIO 'DDE', 'D', 'TV Cable'

EXEC CREAR_ZONA 'EEE', 'E', 'ZONA PRUEBA 1 E', 850000
EXEC CREAR_SERVICIO 'EEE', 'E', 'Netflix'
EXEC CREAR_SERVICIO 'EEE', 'E', 'Spotify'
EXEC CREAR_SERVICIO 'EEE', 'E', 'VERA'
EXEC CREAR_SERVICIO 'EEE', 'E', 'TV Cable'

EXEC CREAR_ZONA 'EEF', 'E', 'ZONA PRUEBA 2 E', 850000
EXEC CREAR_SERVICIO 'EEF', 'E', 'Netflix'
EXEC CREAR_SERVICIO 'EEF', 'E', 'Spotify'
EXEC CREAR_SERVICIO 'EEF', 'E', 'VERA'
EXEC CREAR_SERVICIO 'EEF', 'E', 'TV Cable'

EXEC CREAR_ZONA 'FFF', 'F', 'ZONA PRUEBA 1 F', 850000
EXEC CREAR_SERVICIO 'FFF', 'F', 'Netflix'
EXEC CREAR_SERVICIO 'FFF', 'F', 'Spotify'
EXEC CREAR_SERVICIO 'FFF', 'F', 'VERA'
EXEC CREAR_SERVICIO 'FFF', 'F', 'TV Cable'

EXEC CREAR_ZONA 'FFG', 'F', 'ZONA PRUEBA 2 F', 850000
EXEC CREAR_SERVICIO 'FFG', 'F', 'Netflix'
EXEC CREAR_SERVICIO 'FFG', 'F', 'Spotify'
EXEC CREAR_SERVICIO 'FFG', 'F', 'VERA'
EXEC CREAR_SERVICIO 'FFG', 'F', 'TV Cable'

EXEC CREAR_ZONA 'GGG', 'G', 'ZONA PRUEBA 1 G', 850000
EXEC CREAR_SERVICIO 'GGG', 'G', 'Netflix'
EXEC CREAR_SERVICIO 'GGG', 'G', 'Spotify'
EXEC CREAR_SERVICIO 'GGG', 'G', 'VERA'
EXEC CREAR_SERVICIO 'GGG', 'G', 'TV Cable'

EXEC CREAR_ZONA 'GGH', 'G', 'ZONA PRUEBA 2 G', 850000
EXEC CREAR_SERVICIO 'GGH', 'G', 'Netflix'
EXEC CREAR_SERVICIO 'GGH', 'G', 'Spotify'
EXEC CREAR_SERVICIO 'GGH', 'G', 'VERA'
EXEC CREAR_SERVICIO 'GGH', 'G', 'TV Cable'

EXEC CREAR_ZONA 'HHH', 'H', 'ZONA PRUEBA 1 H', 850000
EXEC CREAR_SERVICIO 'HHH', 'H', 'Netflix'
EXEC CREAR_SERVICIO 'HHH', 'H', 'Spotify'
EXEC CREAR_SERVICIO 'HHH', 'H', 'VERA'
EXEC CREAR_SERVICIO 'HHH', 'H', 'TV Cable'

EXEC CREAR_ZONA 'HHI', 'H', 'ZONA PRUEBA 2 H', 850000
EXEC CREAR_SERVICIO 'HHI', 'H', 'Netflix'
EXEC CREAR_SERVICIO 'HHI', 'H', 'Spotify'
EXEC CREAR_SERVICIO 'HHI', 'H', 'VERA'
EXEC CREAR_SERVICIO 'HHI', 'H', 'TV Cable'

EXEC CREAR_ZONA 'III', 'I', 'ZONA PRUEBA 1 I', 850000
EXEC CREAR_SERVICIO 'III', 'I', 'Netflix'
EXEC CREAR_SERVICIO 'III', 'I', 'Spotify'
EXEC CREAR_SERVICIO 'III', 'I', 'VERA'
EXEC CREAR_SERVICIO 'III', 'I', 'TV Cable'

EXEC CREAR_ZONA 'IIJ', 'I', 'ZONA PRUEBA 2 I', 850000
EXEC CREAR_SERVICIO 'IIJ', 'I', 'Netflix'
EXEC CREAR_SERVICIO 'IIJ', 'I', 'Spotify'
EXEC CREAR_SERVICIO 'IIJ', 'I', 'VERA'
EXEC CREAR_SERVICIO 'IIJ', 'I', 'TV Cable'

EXEC CREAR_ZONA 'JJJ', 'J', 'ZONA PRUEBA 1 J', 850000
EXEC CREAR_SERVICIO 'JJJ', 'J', 'Netflix'
EXEC CREAR_SERVICIO 'JJJ', 'J', 'Spotify'
EXEC CREAR_SERVICIO 'JJJ', 'J', 'VERA'
EXEC CREAR_SERVICIO 'JJJ', 'J', 'TV Cable'

EXEC CREAR_ZONA 'JJK', 'J', 'ZONA PRUEBA 2 J', 850000
EXEC CREAR_SERVICIO 'JJK', 'J', 'Netflix'
EXEC CREAR_SERVICIO 'JJK', 'J', 'Spotify'
EXEC CREAR_SERVICIO 'JJK', 'J', 'VERA'
EXEC CREAR_SERVICIO 'JJK', 'J', 'TV Cable'

EXEC CREAR_ZONA 'KKK', 'K', 'ZONA PRUEBA 1 K', 850000
EXEC CREAR_SERVICIO 'KKK', 'K', 'Netflix'
EXEC CREAR_SERVICIO 'KKK', 'K', 'Spotify'
EXEC CREAR_SERVICIO 'KKK', 'K', 'VERA'
EXEC CREAR_SERVICIO 'KKK', 'K', 'TV Cable'

EXEC CREAR_ZONA 'KKL', 'K', 'ZONA PRUEBA 2 K', 850000
EXEC CREAR_SERVICIO 'KKL', 'K', 'Netflix'
EXEC CREAR_SERVICIO 'KKL', 'K', 'Spotify'
EXEC CREAR_SERVICIO 'KKL', 'K', 'VERA'
EXEC CREAR_SERVICIO 'KKL', 'K', 'TV Cable'

EXEC CREAR_ZONA 'LLL', 'L', 'ZONA PRUEBA 1 L', 850000
EXEC CREAR_SERVICIO 'LLL', 'L', 'Netflix'
EXEC CREAR_SERVICIO 'LLL', 'L', 'Spotify'
EXEC CREAR_SERVICIO 'LLL', 'L', 'VERA'
EXEC CREAR_SERVICIO 'LLL', 'L', 'TV Cable'

EXEC CREAR_ZONA 'LLM', 'L', 'ZONA PRUEBA 2 L', 850000
EXEC CREAR_SERVICIO 'LLM', 'L', 'Netflix'
EXEC CREAR_SERVICIO 'LLM', 'L', 'Spotify'
EXEC CREAR_SERVICIO 'LLM', 'L', 'VERA'
EXEC CREAR_SERVICIO 'LLM', 'L', 'TV Cable'

EXEC CREAR_ZONA 'MMM', 'M', 'ZONA PRUEBA 1 M', 850000
EXEC CREAR_SERVICIO 'MMM', 'M', 'Netflix'
EXEC CREAR_SERVICIO 'MMM', 'M', 'Spotify'
EXEC CREAR_SERVICIO 'MMM', 'M', 'VERA'
EXEC CREAR_SERVICIO 'MMM', 'M', 'TV Cable'

EXEC CREAR_ZONA 'MMN', 'M', 'ZONA PRUEBA 2 M', 850000
EXEC CREAR_SERVICIO 'MMN', 'M', 'Netflix'
EXEC CREAR_SERVICIO 'MMN', 'M', 'Spotify'
EXEC CREAR_SERVICIO 'MMN', 'M', 'VERA'
EXEC CREAR_SERVICIO 'MMN', 'M', 'TV Cable'

EXEC CREAR_ZONA 'NNN', 'N', 'ZONA PRUEBA 1 N', 850000
EXEC CREAR_SERVICIO 'NNN', 'N', 'Netflix'
EXEC CREAR_SERVICIO 'NNN', 'N', 'Spotify'
EXEC CREAR_SERVICIO 'NNN', 'N', 'VERA'
EXEC CREAR_SERVICIO 'NNN', 'N', 'TV Cable'

EXEC CREAR_ZONA 'NNO', 'N', 'ZONA PRUEBA 2 N', 850000
EXEC CREAR_SERVICIO 'NNO', 'N', 'Netflix'
EXEC CREAR_SERVICIO 'NNO', 'N', 'Spotify'
EXEC CREAR_SERVICIO 'NNO', 'N', 'VERA'
EXEC CREAR_SERVICIO 'NNO', 'N', 'TV Cable'

EXEC CREAR_ZONA 'OOO', 'O', 'ZONA PRUEBA 1 O', 850000
EXEC CREAR_SERVICIO 'OOO', 'O', 'Netflix'
EXEC CREAR_SERVICIO 'OOO', 'O', 'Spotify'
EXEC CREAR_SERVICIO 'OOO', 'O', 'VERA'
EXEC CREAR_SERVICIO 'OOO', 'O', 'TV Cable'

EXEC CREAR_ZONA 'OOP', 'O', 'ZONA PRUEBA 2 O', 850000
EXEC CREAR_SERVICIO 'OOP', 'O', 'Netflix'
EXEC CREAR_SERVICIO 'OOP', 'O', 'Spotify'
EXEC CREAR_SERVICIO 'OOP', 'O', 'VERA'
EXEC CREAR_SERVICIO 'OOP', 'O', 'TV Cable'

EXEC CREAR_ZONA 'PPP', 'G', 'ZONA PRUEBA 1 P', 850000
EXEC CREAR_SERVICIO 'PPP', 'G', 'Netflix'
EXEC CREAR_SERVICIO 'PPP', 'G', 'Spotify'
EXEC CREAR_SERVICIO 'PPP', 'G', 'VERA'
EXEC CREAR_SERVICIO 'PPP', 'G', 'TV Cable'

EXEC CREAR_ZONA 'PPQ', 'G', 'ZONA PRUEBA 2 P', 850000
EXEC CREAR_SERVICIO 'POR', 'G', 'Netflix'
EXEC CREAR_SERVICIO 'POR', 'G', 'Spotify'
EXEC CREAR_SERVICIO 'POR', 'G', 'VERA'
EXEC CREAR_SERVICIO 'POR', 'G', 'TV Cable'

EXEC CREAR_ZONA 'QQQ', 'Q', 'ZONA PRUEBA 1 Q', 850000
EXEC CREAR_SERVICIO 'QQQ', 'Q', 'Netflix'
EXEC CREAR_SERVICIO 'QQQ', 'Q', 'Spotify'
EXEC CREAR_SERVICIO 'QQQ', 'Q', 'VERA'
EXEC CREAR_SERVICIO 'QQQ', 'Q', 'TV Cable'

EXEC CREAR_ZONA 'QQR', 'Q', 'ZONA PRUEBA 2 Q', 850000
EXEC CREAR_SERVICIO 'QQR', 'Q', 'Netflix'
EXEC CREAR_SERVICIO 'QQR', 'Q', 'Spotify'
EXEC CREAR_SERVICIO 'QQR', 'Q', 'VERA'
EXEC CREAR_SERVICIO 'QQR', 'Q', 'TV Cable'

EXEC CREAR_ZONA 'RRR', 'R', 'ZONA PRUEBA 1 R', 850000
EXEC CREAR_SERVICIO 'RRR', 'R', 'Netflix'
EXEC CREAR_SERVICIO 'RRR', 'R', 'Spotify'
EXEC CREAR_SERVICIO 'RRR', 'R', 'VERA'
EXEC CREAR_SERVICIO 'RRR', 'R', 'TV Cable'

EXEC CREAR_ZONA 'RRS', 'R', 'ZONA PRUEBA 2 R', 850000
EXEC CREAR_SERVICIO 'RRS', 'R', 'Netflix'
EXEC CREAR_SERVICIO 'RRS', 'R', 'Spotify'
EXEC CREAR_SERVICIO 'RRS', 'R', 'VERA'
EXEC CREAR_SERVICIO 'RRS', 'R', 'TV Cable'

EXEC CREAR_ZONA 'SSS', 'S', 'ZONA PRUEBA 1 S', 850000
EXEC CREAR_SERVICIO 'SSS', 'S', 'Netflix'
EXEC CREAR_SERVICIO 'SSS', 'S', 'Spotify'
EXEC CREAR_SERVICIO 'SSS', 'S', 'VERA'
EXEC CREAR_SERVICIO 'SSS', 'S', 'TV Cable'

EXEC CREAR_ZONA 'SST', 'S', 'ZONA PRUEBA 2 S', 850000
EXEC CREAR_SERVICIO 'SST', 'S', 'Netflix'
EXEC CREAR_SERVICIO 'SST', 'S', 'Spotify'
EXEC CREAR_SERVICIO 'SST', 'S', 'VERA'
EXEC CREAR_SERVICIO 'SST', 'S', 'TV Cable'

GO
-------------------------------------------------------------------------
------------------------------DATOS PRUEBA CASA--------------------------
-------------------------------------------------------------------------
GO
EXEC CREAR_CASA 1, 'AAA', 'A', 'admin', 1000000, 'DIRECCION CASA 1', 'Venta', 2, 1, 50, 1, 40
EXEC CREAR_CASA 2, 'BBB', 'B', 'admin', 20000, 'DIRECCION CASA 2', 'Alquiler', 2, 2, 70, 0, 70
EXEC CREAR_CASA 3, 'BBC', 'B', 'admin', 30000, 'DIRECCION CASA 3', 'Permuta', 2, 2, 70, 0, 70
EXEC CREAR_CASA 4, 'CCC', 'C', 'admin', 4000000, 'DIRECCION CASA 4', 'Venta', 2, 3, 50, 1, 40
EXEC CREAR_CASA 5, 'DDD', 'D', 'admin', 50000, 'DIRECCION CASA 5', 'Alquiler', 2, 4, 70, 0, 70
EXEC CREAR_CASA 6, 'DDE', 'D', 'admin', 60000, 'DIRECCION CASA 6', 'Permuta', 2, 4, 70, 0, 70
EXEC CREAR_CASA 7, 'EEE', 'E', 'admin', 7000000, 'DIRECCION CASA 7', 'Venta', 2, 5, 50, 1, 40
EXEC CREAR_CASA 8, 'FFF', 'F', 'admin', 80000, 'DIRECCION CASA 8', 'Alquiler', 2, 6, 70, 0, 70
EXEC CREAR_CASA 9, 'FFG', 'F', 'admin', 90000, 'DIRECCION CASA 9', 'Permuta', 2, 6, 70, 0, 70
GO

-------------------------------------------------------------------------
------------------------------DATOS PRUEBA APARTAMENTO-------------------
-------------------------------------------------------------------------
GO
EXEC CREAR_APARTAMENTO 10, 'GGG', 'G', 'admin', 10000, 'DIRECCION APARTAMENTO 10', 'Alquiler', 2, 1, 50, 1, 7
EXEC CREAR_APARTAMENTO 11, 'HHH', 'H', 'admin', 1100000, 'DIRECCION APARTAMENTO 11', 'Venta', 2, 2, 70, 1, 8
EXEC CREAR_APARTAMENTO 12, 'HHI', 'H', 'admin', 12000, 'DIRECCION APARTAMENTO 12', 'Permuta', 2, 2, 70, 1, 8
EXEC CREAR_APARTAMENTO 13, 'III', 'I', 'admin', 13000, 'DIRECCION APARTAMENTO 13', 'Alquiler', 2, 3, 50, 1, 9
EXEC CREAR_APARTAMENTO 14, 'JJJ', 'J', 'admin', 1400000, 'DIRECCION APARTAMENTO 14', 'Venta', 2, 4, 70, 1, 10
EXEC CREAR_APARTAMENTO 15, 'JJK', 'J', 'admin', 15000, 'DIRECCION APARTAMENTO 15', 'Permuta', 2, 4, 70, 1, 10
EXEC CREAR_APARTAMENTO 16, 'KKK', 'K', 'admin', 16000, 'DIRECCION APARTAMENTO 16', 'Alquiler', 2, 5, 50, 1, 11
EXEC CREAR_APARTAMENTO 17, 'MMM', 'M', 'admin', 1700000, 'DIRECCION APARTAMENTO 17', 'Venta', 2, 6, 70, 1, 12
EXEC CREAR_APARTAMENTO 18, 'MMN', 'M', 'admin', 18000, 'DIRECCION APARTAMENTO 18', 'Permuta', 2, 6, 70, 1, 12
GO

-------------------------------------------------------------------------
------------------------------DATOS PRUEBA LOCAL-------------------------
-------------------------------------------------------------------------
GO
EXEC CREAR_LOCAL 19, 'NNN', 'N', 'admin', 19000, 'DIRECCION LOCAL 19', 'Alquiler', 2, 4, 50, 1
EXEC CREAR_LOCAL 20, 'NNO', 'N', 'admin', 2000000, 'DIRECCION LOCAL 20', 'Venta', 2, 4, 50, 1
EXEC CREAR_LOCAL 21, 'OOO', 'O', 'admin', 30000, 'DIRECCION LOCAL 21', 'Permuta', 2, 4, 50, 1
EXEC CREAR_LOCAL 22, 'OOP', 'O', 'admin', 40000, 'DIRECCION LOCAL 22', 'Alquiler', 2, 4, 50, 1
EXEC CREAR_LOCAL 23, 'PPP', 'P', 'admin', 1000000, 'DIRECCION LOCAL 23', 'Venta', 2, 4, 50, 1
EXEC CREAR_LOCAL 24, 'QQQ', 'Q', 'admin', 10000, 'DIRECCION LOCAL 24', 'Permuta', 2, 4, 50, 1
EXEC CREAR_LOCAL 25, 'QQR', 'Q', 'admin', 10000, 'DIRECCION LOCAL 25', 'Alquiler', 2, 4, 50, 1
EXEC CREAR_LOCAL 26, 'SSS', 'S', 'admin', 1000000, 'DIRECCION LOCAL 26', 'Venta', 2, 4, 50, 1
EXEC CREAR_LOCAL 27, 'SST', 'S', 'admin', 50000, 'DIRECCION LOCAL 27', 'Permuta', 2, 4, 50, 0
/*
GO
EXEC CREAR_VISITA 4, '2017-07-26 15:00:00', 95159334, 'Rodri'
EXEC CREAR_VISITA 4, '2017-07-27 16:00:00', 95159334, 'Rodri'
*/
/*
1 - El atributo "Contraseña" debe ser de diez caracteres												OK
2 - Una propiedad puede tener hasta dos visitas controlado por teléfono ingresado en la visita.			OK
3 - Una propiedad solo puede recibir una visita al mismo día y hora.									OK
4 - El nombre de cada zona se compone por tres letras que corresponden al nombre de la zona.			OK
5 - El departamento al que pertenece una zona se identifica con una letra.								OK
6 - Los metros cuadrados de una propiedad no pueden ser menores a los metros cuadrados de la casa		OK
7 - Solo existen tres tipos de acción para las propiedades: Alquiler, Venta y Permuta					OK

DECLARE @RETORNO INT
EXEC @RETORNO = CREAR_VISITA 2,'2017-08-10 15:30:00',93815335,'prueba4'
PRINT @RETORNO

*/