USE master
go

------ Creacion de una base de datos -------------------------------------------------------------------------
IF exists(SELECT * FROM SysDataBases WHERE name='Estacionamiento')
BEGIN
	DROP DATABASE Estacionamiento
END
go

CREATE DATABASE Estacionamiento
/*ON(
	NAME=Estacionamiento,
	FILENAME='C:\Estacionamiento.mdf'
)*/
go

------- Determino un usuario con contraseña---------------------------------------------------------------------
USE master
go

-- USUARIO LOGUEO SQL-Server
-- Nombre entre corchetes rectos y contraseña entre comillas simples
CREATE LOGIN [Alumnis] WITH PASSWORD = 'Al12013'
go

-- ASIGNO ROLE DE SERVIDOR, ENTIDAD y ROLE
EXEC master..sp_addsrvrolemember 'Alumnis', 'sysadmin'
go

-- PARA CREAR USUARIO EN BASE DE DATOS
USE Estacionamiento
go

-- LE PASO USUARIO CON EL QUE SE VA A LOGUEAR
CREATE USER [Alumnis] FOR LOGIN [Alumnis]  -- WITH DEFAULT_SCHEMA = db_datawriter -- NO APLICA POR SYSADMIN
go

-- ROLE y ENTIDAD
-- ESTA LINEA ES INECCESARIA DADO QUE EL USUARIO DE SERVIDOR ES SYSADMIN, NO NECESITO NINGUN OTRO PERMISO
-- EXEC Estacionamiento..sp_addrolemember 'db_owner', 'Alumnis'
-- go

------- Determino usuario para servidor web (IIS 7.0)-----------------------------------------------------------
USE master
go

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS WITH DEFAULT_DATABASE = master
go

USE Estacionamiento
go

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
go

Grant execute To [IIS APPPOOL\DefaultAppPool] -- Permiso ejecutar SP
go

-- POR DEFECTO DA ROLE PUBLIC

------- Creacion de Tablas-------------------------------------------------------------------------------------
USE Estacionamiento
go

CREATE TABLE IngresosDiarios(
	IdID int not null Identity Primary Key,
	MatID Varchar(7) not null,
	HoraInID datetime default GetDate(),
	HoralOutID datetime default null,
	PisoID int not null CHECK (PisoID > 0 AND PisoID <=10),
	LugarId int not null Check (LugarId > 0 AND LugarID <= 100)
)
go

CREATE TABLE Cobros(
	IdCobro int not null Identity Primary Key,
	IDID int not null UNIQUE Foreign Key References IngresosDiarios(IdID),
	MontoCobro money not null
)
go

----------------- Indices ------------------------------------------------------------------------------------



------- Datos de Prueba --------------------------------------------------------------------------------------
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('LHA1234', 1, 26)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('LHA5678', 2, 35)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('LHA9012', 2, 49)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('SAB1234', 3, 2)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('SAB5678', 3, 58)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('SAB9012', 4, 67)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('MAB1234', 5, 23)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('MAB5678', 6, 85)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('MAB9012', 6, 94)
INSERT IngresosDiarios (MatID, PisoID, LugarID) VALUES ('HAT4567', 6, 3)
go

INSERT Cobros VALUES (1, 200)
INSERT Cobros VALUES (2, 300)
INSERT Cobros VALUES (3, 400)
INSERT Cobros VALUES (4, 50)
INSERT Cobros VALUES (5, 500)
INSERT Cobros VALUES (6, 600)
INSERT Cobros VALUES (7, 200)
INSERT Cobros VALUES (8, 800)
go



-------------------------- SP -------------------------------------------------------------------------------
CREATE PROC ListoIngresosXmatricula @mat varchar(7) AS
Begin
	SELECT * 
	FROM IngresosDiarios
	Where @mat = MatID
END
go



-------------------------- Vistas --------------------------------------------------------------------------




----------------------------------------- Pruebas -----------------------------------------------------------

-- SP ADMINISTRACION

Create Procedure NuevoUsuarioSql 
@nombre varchar(10),
@pass varchar (10),
@rol varchar(30)
AS
BEGIN

-- Creo usuario de logueo
DECLARE @VarSentencia varchar(200)
SET @VarSentencia = 'CREATE LOGIN [' + @nombre + '] WITH PASSWORD = ' + QUOTENAME(@pass,'''')
-- SENTENCIAS CREATE, DROP y ALTER no permiten parametrizar datos de creacion,eliminacion o modificacion (por esto se arma,concatena linea anterior)
-- QUOTENAME pemite agregar comillas , ya que paso string entre comillas

-- Se usan parentesis para que se haga macro sustiticion de variable por si contenido
EXEC (@VarSentencia)
IF (@@ERROR <> 0)
	RETURN -1

-- Segundo asigno rol especificado al usuario recien creado
EXEC sp_addsrvrolemember @loginame = @nombre, @rolename = @rol -- Parametrizar los parametros de ejecucion SP se puede hacer si igialemos el nombre del parametro a la variable
IF (@@ERROR = 0)
	RETURN 1
ELSE
	RETURN -2
END
go
	
Create Procedure NuevoUsuarioBd
@nombre varchar(10),
@logueo varchar (10),
@rol varchar(30)
AS
BEGIN
-- Creo usuario de logueo
DECLARE @VarSentencia varchar(200)
SET @VarSentencia = 'CREATE USER [' + @nombre + '] FROM LOGIN = [' + @logueo + ']'

-- Se usan parentesis para que se haga macro sustiticion de variable por si contenido
EXEC (@VarSentencia)
IF (@@ERROR <> 0)
	RETURN -1

-- Segundo asigno rol especificado al usuario recien creado
EXEC sp_addrolemember @rolename = @rol, @membername = @nombre -- Parametrizar los parametros de ejecucion SP se puede hacer si igialemos el nombre del parametro a la variable
IF (@@ERROR = 0)
	RETURN 1
ELSE
	RETURN -2
END
go


/*use master 
go
drop login [IIS APPPOOL\DefaultAppPool] borra el server
go
use master 
go
drop login Alumnis borra el usuario
go*/