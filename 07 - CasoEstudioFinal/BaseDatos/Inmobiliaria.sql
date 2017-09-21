use master
go

------------------------------------------------------------------------------------------------------------------
--Determina si esta la base de datos Inmobiliaria y la borra
if exists(Select * FROM SysDataBases WHERE name='Inmobiliaria')
BEGIN
	DROP DATABASE Inmobiliaria
END
go

--Crea la base de datos Inmobiliaria en el lugar especificado
CREATE DATABASE Inmobiliaria
ON(
	NAME=Inmobiliaria,
	FILENAME='c:\Inmobiliaria.mdf'
)
go

------------------------------------------------------------------------------------------------------------------
--pone en uso la bd
USE Inmobiliaria
go

--Creacion de tablas
Create Table Usuarios
(
	CiUsu int not null Primary Key,
	NomUsu varchar(30) not null,
	UsuUsu varchar(10) not null,
	PassUsu varchar(10)
)
go

CREATE TABLE Duenios(
	CiD int NOT NULL PRIMARY KEY,
	NomD varchar(25) NOT NULL
)
go

CREATE TABLE Viviendas(
	PadronViv int NOT NULL PRIMARY KEY ,
	DirViv varchar(40) NOT NULL,
	FConsViv Date NOT NULL,
	PreAlqViv int NOT NULL, 
	CiD int NOT NULL Foreign Key References Duenios(CiD)  
) 
go

CREATE TABLE Apartamentos(
	PadronViv int NOT NULL PRIMARY KEY Foreign Key References Viviendas(PadronViv),
	PorteroApto bit NOT NULL,
	PisoApto int NOT NULL,
	GCApto int NOT NULL
) 
go

CREATE TABLE Casas(
	PadronViv int NOT NULL PRIMARY KEY Foreign Key References Viviendas(PadronViv),
	MtFondoC int NOT NULL
) 
go

------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE EliminarVivienda @Padron int AS
BEGIN 
	
	IF (NOT EXISTS (SELECT * FROM Viviendas WHERE PadronViv = @Padron ))
		RETURN -1

	--si llego aca puedo eliminar
	DECLARE @Error int

	BEGIN TRAN
	DELETE Casas WHERE PadronViv = @Padron
	SET @Error=@@ERROR;
	
	DELETE Apartamentos	WHERE  PadronViv = @Padron
	SET @Error=@@ERROR+@Error;
	
	DELETE Viviendas WHERE  PadronViv = @Padron
	SET @Error=@@ERROR+@Error;
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
end
go

CREATE  PROCEDURE AgregarApartamento @Padron int ,@Dir varchar(40), @Fecha date, @Precio int, @duenio int,
                                     @Portero bit, @Piso int, @Gastos int AS
BEGIN 
	if (EXISTS (SELECT * FROM Viviendas WHERE PadronViv=@Padron))
		RETURN -1

	if Not(EXISTS(Select * From Duenios Where CiD = @duenio))
		return -2
		
	--si llego aca puedo agregar
	DECLARE @Error int
	BEGIN TRAN

	INSERT Viviendas(PadronViv, DirViv, FConsViv, PreAlqViv, CiD) VALUES(@Padron, @Dir, @Fecha, @Precio, @duenio) 
	SET @Error=@@ERROR;

	INSERT Apartamentos( PadronViv, PorteroApto, PisoApto, GCApto ) VALUES( @Padron, @Portero, @Piso, @Gastos)
	SET @Error=@@ERROR+@Error;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END
go

CREATE PROCEDURE ModificarApartamento 	@Padron int ,@Dir varchar(40), @Fecha date, @Precio int, @duenio int,
                                     @Portero bit, @Piso int, @Gastos int AS
BEGIN 
	if Not(EXISTS (SELECT * FROM Viviendas WHERE PadronViv=@Padron))
		RETURN -1

	if Not(EXISTS(Select * From Duenios Where CiD = @duenio))
		return -2
		
	--si llego aca puedo modificar
	DECLARE @Error int
	BEGIN TRAN

	UPDATE Apartamentos 
	SET PorteroApto = @Portero, PisoApto = @Piso, GCApto = @Gastos
	WHERE PadronViv = @Padron
	
	SET @Error=@@ERROR;

	UPDATE Viviendas 
	SET DirViv = @Dir, FConsViv = @Fecha, PreAlqViv = @Precio, CiD = @duenio
	WHERE PadronViv = @Padron
	
	SET @Error=@@ERROR+@Error;

	IF(@Error=0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	
END
go

CREATE  PROCEDURE BuscarApartamento @Padron int AS
BEGIN 
	SELECT *  
	FROM Apartamentos AS A INNER JOIN Viviendas AS V 
	     ON a.PadronViv=V.PadronViv AND A.PadronViv=@Padron
END
go

CREATE  PROCEDURE ListarApartamentos AS
BEGIN 
	SELECT *  
	FROM Apartamentos AS A INNER JOIN Viviendas AS V 
	     ON a.PadronViv=V.PadronViv
END
go

CREATE PROCEDURE AgregarDuenio @Ci int, @Nombre varchar(25) AS
Begin
	if (EXISTS(Select * From Duenios Where CiD = @Ci))
		return -1
		
	--si llego aca puedo agregar
	INSERT Duenios(CiD, NomD) VALUES(@Ci, @Nombre) 
	
	IF(@@Error=0)
		RETURN 1
	else
		RETURN -2
End
go

CREATE PROCEDURE ModificarDuenio @Ci int, @Nombre varchar(25) AS
Begin
	if Not(EXISTS(Select * From Duenios Where CiD = @Ci))
		return -1
		
	--si llego aca puedo modificar
	UPDATE Duenios 
	SET NomD = @Nombre
	WHERE CiD = @Ci
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -2
End
go

CREATE PROCEDURE EliminarDuenio @Ci int AS
Begin
	if Not(EXISTS(Select * From Duenios Where CiD = @Ci))
		return -1
	
	if (EXISTS(Select * From Viviendas Where CiD = @Ci))
		return -2
		
	Delete Duenios Where CiD = @Ci
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -3
End
go

CREATE PROCEDURE BuscarDuenio @Ci int AS
Begin
	Select * From Duenios Where CiD = @Ci
End
go

CREATE PROCEDURE ListarDuenio AS
Begin
	Select * From Duenios
End
go

CREATE PROCEDURE Logueo @Usu varchar(10), @Pass varchar(10) AS
Begin
	Select *
	From Usuarios U
	Where U.UsuUsu = @Usu AND U.PassUsu = @Pass
End
go

CREATE PROCEDURE ListarApartamentosDuenio @Ci int AS
Begin
	Select * 
	From Apartamentos A inner join Viviendas V
	     on A.PadronViv = V.PadronViv
	Where V.CiD = @Ci
End
go

CREATE PROCEDURE ListarCasasDuenio @Ci int AS
Begin
	Select * 
	From Casas C inner join Viviendas V
	     on C.PadronViv = V.PadronViv
	Where V.CiD = @Ci
End
go

CREATE PROCEDURE CantTotalCasas @CantC int output AS
Begin
	Select @CantC = COUNT(*)
	From Casas C inner join Viviendas V
	     on C.PadronViv = V.PadronViv
end
go

cREATE PROCEDURE CantTotalAptos @CantA int output AS
Begin
	Select @CantA = COUNT(*)
	From Apartamentos A inner join Viviendas V
	     on A.PadronViv = V.PadronViv
End
go     

CREATE  PROCEDURE ListarCasas AS
BEGIN 
	SELECT *  
	FROM Casas AS C INNER JOIN Viviendas AS V 
	     ON C.PadronViv=V.PadronViv
END
go

------------------------------------------------------------------------------------------------------------------
--datos de prueba

--Usuarios
Insert Usuarios(CiUsu, NomUsu, PassUsu, UsuUsu) Values (11111, 'Andrea Perez', 'usu1', 'usu1')
Insert Usuarios(CiUsu, NomUsu, PassUsu, UsuUsu) Values (22222, 'Juan Rodriguez', 'usu2', 'usu2')

--Duenios
Exec AgregarDuenio 12345678, 'Pedro Caseres'
Exec AgregarDuenio 12345689, 'Maria Andes'
Exec AgregarDuenio 12345600, 'Gustavo Sosa'
go

--Apartamentos
exec AgregarApartamento 123456, 'una Calle 4589', '19820325', 25000, 12345678, 0, 3, 2500
exec AgregarApartamento 112233, 'una Avenida 7532', '19990920', 40700, 12345678, 1, 11, 5250
exec AgregarApartamento 445566, 'un Boulevard 1234', '20051114', 38500, 12345689, 1, 8, 8200
go

--Casa
Insert Viviendas(PadronViv, DirViv, FConsViv, PreAlqViv, CiD) Values(778899, 'Una Callesita esq Otra Cosa', '19651013',28650,12345678) 
go
Insert Casas(PadronViv, MtFondoC) Values (778899, 25)
go
