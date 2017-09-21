USE master
GO

-- Elimino base de datos Obligatorio si ya existe...
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'OBLIGATORIOFINAL')
BEGIN
	DROP DATABASE OBLIGATORIOFINAL
END 
GO

-- Creo la Base de Datos
CREATE DATABASE OBLIGATORIOFINAL
GO

USE OBLIGATORIOFINAL
GO

--Creo la tabla Usuarios
CREATE TABLE Usuario
(
	IdLogueo INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(20) NOT NULL,
	Apellido VARCHAR (20) NOT NULL,
	Contrasenia VARCHAR(20) NOT NULL,
	NroDoc INT NOT NULL,
	NombreLogueo VARCHAR(20) UNIQUE NOT NULL
)
GO
--Creo la tabla Cliente
CREATE TABLE Cliente
(
	IdLogueo INT PRIMARY KEY FOREIGN KEY REFERENCES Usuario(IdLogueo) ON DELETE CASCADE,
	NroTarjeta BIGINT NOT NULL,
	Calle VARCHAR(20) NOT NULL,
	NroPuerta INT NOT NULL
)
GO
--Creo la tabla Cargo
CREATE TABLE Cargo
(
	Tipo VARCHAR(20) NOT NULL,
	IdCargo INT PRIMARY KEY IDENTITY(1,1)
)
GO
--Creo la tabla Administrador
CREATE TABLE Administrador
(
	IdLogueo INT PRIMARY KEY FOREIGN KEY REFERENCES Usuario(IdLogueo) ON DELETE CASCADE,
	IdCargo INT FOREIGN KEY REFERENCES Cargo(IdCargo)
)
GO
--Creo la tabla Especializacion
CREATE TABLE Especializacion
(
	Tipo VARCHAR(20) NOT NULL,
	IdEspe INT PRIMARY KEY IDENTITY(1,1)
)
GO

--Creo la tabla Casa
CREATE TABLE Casa   
(
	Rut BIGINT NOT NULL PRIMARY KEY,
	IdEspe INT NOT NULL,
	Nombre VARCHAR (20) NOT NULL
)
GO

--Creo la tabla Plato
CREATE TABLE Plato 
(
	IdPlato INT PRIMARY KEY IDENTITY NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Precio INT NOT NULL,
    Foto VARCHAR(MAX)
)
GO
--Creo la tabla Tienen
CREATE TABLE Tienen
(
	Rut BIGINT FOREIGN KEY REFERENCES Casa(Rut) ON DELETE CASCADE,
	IdPlato INT FOREIGN KEY REFERENCES Plato(IdPlato) ON DELETE CASCADE UNIQUE,
	IdPlatoCasa INT NOT NULL,
	PRIMARY KEY(Rut,IdPlato)
)
GO

--Creo la tabla Pedido
CREATE TABLE Pedido
(
	IdPedido INT NOT NULL UNIQUE IDENTITY (1,1),
	FechaPedido DATETIME NOT NULL,
	FechaEntregado DATETIME NOT NULL,
	Entregado BIT NOT NULL,
	Total MONEY NOT NULL,
)
GO

--Creo la tabla Compran
CREATE TABLE Compran
(
	IdCompra INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	IdPlato INT FOREIGN KEY REFERENCES Plato(IdPlato) ON DELETE CASCADE,
	IdLogueo INT FOREIGN KEY REFERENCES Usuario(IdLogueo) ON DELETE CASCADE
)
GO

--Creo la tabla Realizan
CREATE TABLE Realizan
(
	IdRealizan INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	IdCompra INT FOREIGN KEY REFERENCES Compran(IdCompra) ON DELETE CASCADE,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) ON DELETE CASCADE,
	Cantidad INT NOT NULL
)
GO

------------------------
--SP Necesarios Clientes
------------------------
CREATE PROCEDURE SP_AgregarCliente
@NombreN VARCHAR(20) ,
@ApellidoN VARCHAR (20),
@ContraseniaN VARCHAR(20),
@NroDocN INT,
@NombreLogueoN VARCHAR(20),
@NroTarjetaN BIGINT,
@CalleN VARCHAR(20),
@NroPuertaN INT
AS
BEGIN
	
	IF EXISTS (SELECT U.NroDoc FROM Usuario U WHERE U.NroDoc = @NroDocN OR U.NombreLogueo = @NombreLogueoN)
		BEGIN
			RETURN -1
		END
	ELSE
		BEGIN TRANSACTION
				INSERT INTO Usuario (Nombre,Apellido,Contrasenia,NroDoc,NombreLogueo)
				VALUES (@NombreN,@ApellidoN,@ContraseniaN,@NroDocN,@NombreLogueoN)
					
				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END

			INSERT INTO Cliente (IdLogueo,NroTarjeta,Calle,NroPuerta)
			VALUES((SELECT max(IdLogueo) FROM Usuario),@NroTarjetaN,@CalleN,@NroPuertaN)

				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END
				ELSE 
					BEGIN
						COMMIT TRANSACTION
						RETURN 2
					END
		END	
GO
-- -1 documento existente -2 nombrelogueo existente 

-------------------------------
--SP Necesarios administradores
-------------------------------
CREATE PROCEDURE SP_AgregarAdministrador
@NombreN VARCHAR(20) ,
@ApellidoN VARCHAR (20),
@ContraseniaN VARCHAR(20),
@NroDocN INT,
@NombreLogueoN VARCHAR(20),
@CargoN INT
AS
BEGIN
	
	IF EXISTS (SELECT U.NroDoc FROM Usuario U WHERE U.NroDoc = @NroDocN)
		BEGIN
			RETURN -1
		END
	IF EXISTS (SELECT U.NombreLogueo FROM Usuario U WHERE U.NombreLogueo = @NombreLogueoN)
		BEGIN
			RETURN -2
		END
	ELSE
		BEGIN TRANSACTION
				INSERT INTO Usuario (Nombre,Apellido,Contrasenia,NroDoc,NombreLogueo)
				VALUES (@NombreN,@ApellidoN,@ContraseniaN,@NroDocN,@NombreLogueoN)
					
				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END

			INSERT INTO Administrador (IdLogueo,IdCargo)
			VALUES((SELECT max(IdLogueo) FROM Usuario),@CargoN)

				IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END
				ELSE 
					BEGIN
						COMMIT TRANSACTION
						RETURN 1
					END
		END	
GO
CREATE PROCEDURE SP_ModificarAdministrador
@NombreM VARCHAR(20),
@ApellidoM VARCHAR (20),
@ContraseniaM VARCHAR(20),
@NroDocM INT,
@NombreLogueoM VARCHAR(20),
@CargoM INT
AS
BEGIN
	IF NOT EXISTS (SELECT U.NroDoc FROM Usuario U WHERE U.NroDoc = @NroDocM)
		BEGIN
			RETURN 2
		END
	ELSE
		BEGIN TRANSACTION
			
			UPDATE Usuario
			SET
				Nombre=@NombreM,
				Apellido=@ApellidoM,
				Contrasenia=@ContraseniaM,
				NombreLogueo=@NombreLogueoM
			WHERE
				Usuario.NroDoc=@NroDocM

			IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END

			UPDATE Administrador
			SET
				IdCargo=@CargoM
			WHERE
				Administrador.IdLogueo =(SELECT U.IdLogueo FROM Usuario U WHERE U.NroDoc=@NroDocM)

			IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END
       ELSE
			BEGIN
				COMMIT TRANSACTION
				RETURN 1	
			END
END
GO
CREATE PROCEDURE SP_BorrarAdministrador
@NroDocB INT
AS
BEGIN
	BEGIN TRANSACTION 
		DELETE Usuario
		WHERE IdLogueo = (SELECT U.IdLogueo FROM Usuario U WHERE U.NroDoc=@NroDocB)

			IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END
       ELSE
			BEGIN
				COMMIT TRANSACTION
				RETURN 1	
			END
END
GO
CREATE PROCEDURE SP_ListarAdministradores
@IdCargoB INT
AS
BEGIN
	SELECT DISTINCT U.Nombre,
		   U.Apellido,
		   U.NroDoc, 
		   U.NombreLogueo
		  
    FROM Usuario U join Administrador A on U.IdLogueo=A.IdLogueo
	WHERE A.IdCargo=@IdCargoB
END
GO
CREATE PROCEDURE SP_BuscarAdmin
@DocB INT

AS
BEGIN
	SELECT U.Nombre,
		   U.Apellido,
		   U.IdLogueo,
		   U.NroDoc,
		   U.NombreLogueo,
		   U.Contrasenia
	FROM Usuario u JOIN Administrador a ON u.IdLogueo=a.IdLogueo
	WHERE u.NroDoc=@DocB 
END
GO

-- -1 documento existente -2 nombrelogueo existente 

---------------------
--SP Necesarios para Casas
--------------------

CREATE PROCEDURE SP_AgregarCasa
@RutN BIGINT,
@IdEspeN INT,
@NombreN VARCHAR (20)
AS
BEGIN
	IF EXISTS (SELECT C.Rut FROM Casa C WHERE C.Rut=@RutN)
		BEGIN
			RETURN -1
		END
	ELSE
		BEGIN TRANSACTION		
			INSERT INTO Casa (Rut,IdEspe,Nombre)
			VALUES (@RutN,@IdEspeN,@NombreN)

			IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END
				ELSE 
					BEGIN
						COMMIT TRANSACTION
						RETURN 1
					END
END
GO
CREATE PROCEDURE SP_ModificarCasa
@RutM BIGINT,
@IdEspeM INT,
@NombreM VARCHAR (20)
AS
BEGIN
	IF NOT EXISTS (SELECT C.Rut FROM Casa C WHERE C.Rut=@RutM)
		BEGIN
			RETURN -1
		END
	ELSE
		BEGIN TRANSACTION
			UPDATE Casa
			SET Rut=@RutM,
				IdEspe=@IdEspeM,
				Nombre=@NombreM
				WHERE casa.Rut = @RutM
		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END
       ELSE
			BEGIN
				COMMIT TRANSACTION
				RETURN 1	
			END
END
GO
CREATE PROCEDURE SP_BuscarCasa
@RutB BIGINT
AS
BEGIN
	IF NOT EXISTS (SELECT C.Rut FROM Casa C WHERE C.Rut=@RutB)
		BEGIN
			RETURN -1
		END
	ELSE
		 SELECT C.Nombre,
			    C.Rut,
				C.IdEspe
		 FROM Casa C WHERE C.Rut = @RutB
END
GO
CREATE PROCEDURE SP_BorrarCasa
@RutB BIGINT
AS
BEGIN
		BEGIN TRANSACTION

		DELETE FROM Pedido WHERE IdPedido in (
		SELECT p2.IdPedido FROM Plato p 
		JOIN Tienen t on t.IdPlato = p.IdPlato
		JOIN Casa c on c.Rut = t.Rut
		JOIN Compran c2 on c2.IdPlato = p.IdPlato
		JOIN Realizan r on r.IdCompra = c2.IdCompra
		JOIN Pedido p2 on p2.IdPedido = r.IdPedido
		WHERE c.Rut = @RutB )

		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END

		DELETE Plato WHERE Plato.IdPlato IN (SELECT t.IdPlato FROM Tienen t WHERE t.Rut=@RutB)

		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END

		DELETE Casa WHERE Casa.Rut = @RutB

			IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END
	 ELSE
			BEGIN
				COMMIT TRANSACTION
				RETURN 1
			END
END
GO

----------------------------
--SP Necesarios para Platos
----------------------------
CREATE PROCEDURE SP_AgregarPlato
@Rut BIGINT,
@NombreA VARCHAR(20),
@PrecioA FLOAT,
@FotoA VARCHAR(MAX)
AS
BEGIN
	IF EXISTS(SELECT Tienen.Rut FROM Tienen WHERE Tienen.Rut=@Rut)
	BEGIN
		BEGIN TRANSACTION
		     INSERT INTO Plato (Nombre,Precio,Foto)
			        VALUES (@NombreA,@PrecioA,@FotoA)

			IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END
			     INSERT INTO Tienen (Rut,IdPlato,IdPlatoCasa)
			     VALUES (@Rut,(SELECT max(Plato.IdPlato) FROM Plato),(SELECT max(Tienen.IdPlatoCasa) +1 FROM Tienen WHERE Tienen.Rut=@Rut))
			IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END
			ELSE 
					BEGIN
						COMMIT TRANSACTION
						RETURN 1
					END
	END
	ELSE
		BEGIN
		     BEGIN TRANSACTION
		     INSERT INTO Plato (Nombre,Precio,Foto)
			        VALUES (@NombreA,@PrecioA,@FotoA)

			IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END

		     INSERT INTO Tienen (Rut,IdPlato,IdPlatoCasa)
			        VALUES (@Rut,(SELECT max(Plato.IdPlato) FROM Plato),1)

			IF @@ERROR <> 0
					BEGIN
						ROLLBACK TRANSACTION
						RETURN @@ERROR
					END
			ELSE 
					BEGIN
						COMMIT TRANSACTION
						RETURN 1
					END 		
    END
END
GO
CREATE PROCEDURE SP_ModificarPlato
@RutOriginal BIGINT,
@IdOriginal INT,
@NombreM VARCHAR(20),
@PrecioM FLOAT,
@FotoM VARCHAR(MAX)
AS
BEGIN
 IF EXISTS(SELECT T.IdPlatoCasa FROM Tienen T WHERE Rut=@RutOriginal)
	BEGIN
		BEGIN TRANSACTION
			UPDATE Plato SET Nombre=@NombreM, Precio=@PrecioM, Foto=@FotoM
			WHERE Plato.IdPlato IN (SELECT T.IdPlato FROM Tienen T WHERE Rut=@RutOriginal AND T.IdPlatoCasa = @IdOriginal)
		
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN @@ERROR
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
CREATE PROCEDURE SP_BorrarPlato
@IdPlatoB INT,
@Rut BIGINT
AS
BEGIN
	BEGIN TRANSACTION

		DELETE FROM Pedido WHERE IdPedido in (
		SELECT p2.IdPedido FROM Plato p 
		JOIN Tienen t on t.IdPlato = p.IdPlato
		JOIN Casa c on c.Rut = t.Rut
		JOIN Compran c2 on c2.IdPlato = p.IdPlato
		JOIN Realizan r on r.IdCompra = c2.IdCompra
		JOIN Pedido p2 on p2.IdPedido = r.IdPedido
		WHERE t.Rut = @Rut and t.IdPlatoCasa = @IdPlatoB )

		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END

		DELETE Plato WHERE Plato.IdPlato = (SELECT pl.IdPlato FROM Casa ca
											JOIN Tienen ti on Ca.Rut = ti.Rut
											JOIN Plato pl on ti.IdPlato = pl.IdPlato
											WHERE ti.IdPlatoCasa = @IdPlatoB and ti.Rut = @Rut)

		IF @@ERROR <> 0
			BEGIN
				ROLLBACK TRANSACTION
				RETURN @@ERROR
			END
       ELSE
			BEGIN
				COMMIT TRANSACTION
				RETURN 1	
			END
END
GO
CREATE PROCEDURE SP_BuscarPlato
@Rut BIGINT,
@IdPlatoCasa INT
AS
BEGIN
	SELECT T.IdPlatoCasa,
		   P.Nombre,
		   P.Precio,
		   P.Foto
	FROM Plato P JOIN Tienen T ON P.IdPlato=T.IdPlato
	WHERE T.Rut=@Rut AND T.IdPlatoCasa=@IdPlatoCasa
END
GO
---------------------------
--SP Necesarios para Pedido
---------------------------
CREATE PROCEDURE SP_ListarTodasLasCasas
AS
BEGIN
	SELECT C.Nombre,
		   C.Rut, 
		   C.IdEspe
    FROM Casa C
END
GO

CREATE PROCEDURE SP_ListarCasa
@IdEspeMostrar INT
AS
BEGIN
	SELECT C.Nombre,
		   C.Rut,
		   C.IdEspe
    FROM Casa C JOIN Especializacion E ON C.IdEspe=E.IdEspe
	WHERE E.IdEspe=@IdEspeMostrar
END
GO

-- Listar especializaciones
CREATE PROCEDURE SP_ListarEspecializaciones
AS
BEGIN
	SELECT * FROM Especializacion;
END
GO

-- Listar cargos
CREATE PROCEDURE SP_ListarCargos
AS
BEGIN
	SELECT * FROM Cargo;
END
GO

CREATE PROCEDURE SP_LoginCliente
@NomLogueo VARCHAR(20),
@PassUser VARCHAR(20)
AS
BEGIN
	SELECT * FROM Usuario U 
	JOIN Cliente C ON C.IdLogueo= U.IdLogueo  
	WHERE U.NombreLogueo = @NomLogueo
	AND U.Contrasenia = @PassUser
END
GO

CREATE PROCEDURE SP_LoginAdministrador
@NomLogueo VARCHAR(20),
@PassUser VARCHAR(20)
AS
BEGIN
	SELECT * FROM Usuario U 
	JOIN Administrador A ON A.IdLogueo= U.IdLogueo  
	WHERE U.NombreLogueo = @NomLogueo
	AND U.Contrasenia = @PassUser
END
GO

-- Casas pedidos
-- Recibe: idEspe - RUT
-- Envia: RUT - idPlatoCasa - Nombre - Plato - Precio
CREATE PROCEDURE ListarPlatoPedido
@IdEspe INT,
@Rut BIGINT
AS
BEGIN
	SELECT pl.IdPlato, pl.Nombre, pl.Precio, pl.Foto FROM Plato pl
	JOIN Tienen ti on pl.IdPlato = ti.IdPlato 
	JOIN Casa ca on ca.Rut = ti.Rut
	JOIN Especializacion esp on esp.IdEspe = ca.IdEspe
	WHERE esp.IdEspe = @IdEspe and ca.Rut = @Rut
 END
 GO

 --Listado de pedidos por fecha
 CREATE PROCEDURE ListarPedido
@fecha DATETIME
AS
BEGIN
	SELECT r.Cantidad,
		   p.FechaPedido,
		   pl.Nombre,
		   c.Calle,
		   c.NroPuerta		   
	
	FROM Pedido p --WHERE p.FechaPedido = @fecha
	join Realizan r on r.IdPedido = p.IdPedido
	join Compran co on co.IdCompra = r.IdCompra
	join Plato pl on pl.IdPlato = co.IdPlato
	join Cliente c on c.IdLogueo = co.IdLogueo
	WHERE p.FechaPedido = @fecha
 END
 GO
 -- Listado de casas para el pedido
 CREATE PROCEDURE ListarCasaPedido
@IdEspe INT
AS
BEGIN
	SELECT * FROM Casa ca WHERE ca.IdEspe = @IdEspe
 END
 GO

-- Listado de platos para casa
 CREATE PROCEDURE ListarPlato
@rut BIGINT
AS
BEGIN
	SELECT ti.IdPlatoCasa, pl.Nombre, pl.Precio, pl.Foto FROM Plato pl
	JOIN Tienen ti on pl.IdPlato = ti.IdPlato 
	JOIN Casa ca on ca.Rut = ti.Rut
	JOIN Especializacion esp on esp.IdEspe = ca.IdEspe
	WHERE ca.Rut = @Rut

 END
 GO

 -- Crear pedido
 CREATE PROCEDURE AgregarVenta
 @fechaPedido DATETIME,
 @fechaEntrega DATETIME,
 @totalVenta MONEY,
 @cliente INT
 AS
 BEGIN
	IF EXISTS (SELECT u.NroDoc FROM Usuario u WHERE u.NroDoc = @cliente)
	BEGIN
		BEGIN TRANSACTION
			INSERT INTO Pedido VALUES (@fechaPedido,@fechaEntrega,0,@totalVenta)
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN @@ERROR
				END
			ELSE 
				BEGIN
					COMMIT TRANSACTION
					RETURN 1
				END
	END
	ELSE
		BEGIN
			RETURN -2
		END
 END
 GO

-- Crear linea
CREATE PROCEDURE AgregarLinea
@total MONEY,
@idPlato INT,
@casa BIGINT,
@cantidad INT,
@cliente INT
AS
BEGIN
	BEGIN TRANSACTION
			INSERT INTO Compran VALUES ((SELECT p.IdPlato FROM Plato p JOIN Tienen t on p.IdPlato = t.IdPlato WHERE t.Rut = @casa AND t.IdPlatoCasa = @idPlato ),
										(SELECT u.IdLogueo FROM Usuario u WHERE u.NroDoc = @cliente ))
			DECLARE @ultimaVenta INT;
			SET @ultimaVenta = (SELECT max(p.IdPedido) FROM Pedido p);
			
			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION
					RETURN @@ERROR
				END
			
				UPDATE Pedido SET Total = @total WHERE IdPedido = @ultimaVenta
			
				IF @@ERROR <> 0
						BEGIN
							ROLLBACK TRANSACTION
							RETURN @@ERROR
						END					

				INSERT INTO Realizan VALUES ((SELECT max(c.IdCompra) FROM Compran c ),
											(SELECT max(p.IdPedido) FROM Pedido p ),
											@cantidad)

				IF @@ERROR <> 0
						BEGIN
							ROLLBACK TRANSACTION
							RETURN @@ERROR
						END					
				ELSE 
					BEGIN
						COMMIT TRANSACTION
						RETURN 1
					END	
END
GO

-- Listar pedidos pendientes
CREATE PROCEDURE PedidosPendientes
@cliente INT
AS
BEGIN
	SELECT DISTINCT p.IdPedido, p.FechaPedido, p.FechaEntregado, p.Entregado, p.Total, r.Cantidad
	FROM Pedido p
	JOIN Realizan r on r.IdPedido = p.IdPedido
	JOIN Compran c on c.IdCompra = r.IdCompra
	JOIN Usuario u on u.IdLogueo = c.IdLogueo
	WHERE u.NroDoc = @cliente
	AND p.Entregado = 0
END
GO

-- Listar todos los pedidos pendientes
CREATE PROCEDURE PedidosPendientesTodos
AS
BEGIN
	SELECT DISTINCT p.IdPedido, p.FechaPedido, p.FechaEntregado, p.Entregado, p.Total, r.Cantidad
	FROM Pedido p
	JOIN Realizan r on r.IdPedido = p.IdPedido
	JOIN Compran c on c.IdCompra = r.IdCompra
	JOIN Usuario u on u.IdLogueo = c.IdLogueo
	WHERE p.Entregado = 0
END
GO

-- Listar lineas de pedido
CREATE PROCEDURE LineasPendientes
@pedido INT
AS
BEGIN
	SELECT pl.IdPlato, pl.Nombre, pl.Precio, pl.Foto, ca.Rut, ca.Nombre, r.Cantidad
	FROM Pedido p
	JOIN Realizan r on r.IdPedido = p.IdPedido
	JOIN Compran c on c.IdCompra = r.IdCompra
	JOIN Tienen t on t.IdPlato = c.IdPlato
	JOIN Plato pl on pl.IdPlato = t.IdPlato
	JOIN Casa ca on ca.Rut = t.Rut
	WHERE p.Entregado = 0
	AND p.IdPedido = @pedido
END
GO

-- Entregar pedido
CREATE PROCEDURE EntregarPedido
@pedido INT,
@fecha DATETIME
AS
BEGIN
	UPDATE Pedido set Entregado = 1 WHERE IdPedido = @pedido
	UPDATE Pedido set FechaEntregado = @fecha WHERE IdPedido = @pedido
END
GO

-- Pedidos XML
CREATE PROCEDURE PedidosXML
@fecha DATE
AS
BEGIN
	SELECT CONVERT(VARCHAR(5),FechaEntregado,108) AS Hora, ca.Rut AS CasaComidas, pl.IdPlato, r.Cantidad, CONCAT (cl.Calle, ' ' ,cl.NroPuerta) AS DireccionEntrega FROM Pedido p
	JOIN Realizan r on r.IdPedido = p.IdPedido
	JOIN Compran c on c.IdCompra = r.IdCompra
	JOIN Plato pl on pl.IdPlato = c.IdPlato
	JOIN Tienen t on t.IdPlato = pl.IdPlato
	JOIN Casa ca on ca.Rut = t.Rut
	JOIN Cliente cl on cl.IdLogueo = c.IdLogueo
	WHERE CONVERT(VARCHAR(10),FechaEntregado,110) = @fecha -- '2017-01-01 00:00:00.000'
END
GO

-- DATOS DE AMBIENTE
--Especializaciones Basicos
INSERT INTO Especializacion VALUES('Pizzeria')
INSERT INTO Especializacion VALUES('Parrillada')
INSERT INTO Especializacion VALUES('Minutas')
INSERT INTO Especializacion VALUES('Internacional')
INSERT INTO Especializacion VALUES('Vegetariano')

-- Cargos Basicos
INSERT INTO Cargo VALUES ('Administrador')
INSERT INTO Cargo VALUES ('Gerente')

-- Admin por defecto
INSERT INTO Usuario VALUES ('admin','admin','MTIz',11111111,'admin')
INSERT INTO Administrador VALUES((SELECT max(IdLogueo) FROM Usuario),1)

-- Usuario para testing
INSERT INTO Usuario VALUES ('user','user','MTIz',11111112,'user')
INSERT INTO Cliente VALUES ((SELECT max(IdLogueo) FROM Usuario),1234123412341234,'Calle',1234)