USE master
go


------ Creacion de una base de datos -------------------------------------------------------------------------
IF exists(SELECT * FROM SysDataBases WHERE name='Estacionamiento')
BEGIN
	DROP DATABASE Estacionamiento
END
go

CREATE DATABASE Estacionamiento
go


------- Determino un usuario con contraseña---------------------------------------------------------------------

use master;--para crear un usuario del servidor, tengo que estar en la bd master.
go
create login[Alumnis] with password = 'Al2013'--usuario de logueo SQL SErver; las contraseñas van siempre entre comillas y el usuario entre corchetes rectos
go
exec master..sp_addsrvrolemember 'Alumnis','sysadmin' --se le asgina un rol de servidor; para el sv va primero el nombre de usu y despues el rol 
go
use Estacionamiento-- paso a la bd para crear el usuario y trabajar dentro de la bd
go
create user [Alumnis] for login [Alumnis] --with default_schema = db_datawriter --le digo el usuario con el que se va  loguear.cuando se crea un usuariod e la db el default_schema me permite asignar un rol ya predeterminado
go
exec Estacionamiento..sp_addrolemember 'db_owner','Alumnis' --es innecesario agregar un rol ya que es un sysadmin en el sv es al pedo darle otros permisos aca
go 


------- Determino usuario para servidor web (IIS 7.0)-----------------------------------------------------------
use master
go
create login [IIS APPPOOL\DefaultAppPool] FROM WINDOWS WITH DEFAULT_dATABASE = mASTER --crea el rol public para el usuario
GO

USE eSTACIONAMIENTO
GO

create user [IIS APPPOOL\DefaultAppPool] for login [IIS APPPOOL\DefaultAppPool]
go

grant execute to [IIS APPPOOL\DefaultAppPool]--buscar el [IIS APPPOOL\DefaultAppPool] para el 10 -- le damos permiso de ejecucion
go

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
	IdID int not null UNIQUE Foreign Key References IngresosDiarios(IdID),
	MontoCobro money not null
)
go



----------------- Indices ------------------------------------------------------------------------------------
--1 Determinar que indices automaticos genero el servidor con la definicon de tablas
--2 clustered por cada pk y uno nonclustered por el unique

--como se realizaran muchas estadisticas y busquedas por la matricula del automovil

CREATE NONCLUSTERED INDEX IMatricula ON IngresosDiarios(MatID)

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
CREATE VIEW EstadisticasPorMatricula
AS
SELECT MatID,COUNT(*) AS 'CantidadIngresos'
FROM IngresosDiarios
GROUP BY MatID
GO

CREATE VIEW TotalesPorMatricula 
AS
SELECT MatID, SUM(MontoCobro) AS 'TotalCobrado'
FROM IngresosDiarios I INNER JOIN Cobros C ON I.IdID = C.IdID
GROUP BY MatID
GO

CREATE VIEW TotalesPorMatriculaUsoView 
AS
SELECT * FROM TotalesPorMatricula
WHERE TotalCobrado > 500
GO

----------------------------------------- Pruebas -----------------------------------------------------------
EXEC ListoIngresosXmatricula 'LHA1234'
go

SELECT * FROM EstadisticasPorMatricula
go

SELECT * FROM TotalesPorMatricula
go

SELECT * FROM TotalesPorMatriculaUsoView
go
--SP Administracion de la base de datos-
--todas las sentencias create, drop y alter, no permiten parametrizar ninguno de los datos de cracion, modificacion, eliminacion
--por esto se crea un string a mano 
create proc NuevoUsuarioSql @Nombre varchar(10),@pass varchar(10),@rol varchar(30) as
begin

--creo el usuario de logueo
declare @VarSentencia varchar(200)
set @VarSentencia = 'Create Login ['+@Nombre+'] with Password = '+ quotename(@Pass,'''')--el quotename permite agregar comillas simples adentro de comillas simples
exec (@VarSentencia) --se usan parentecis para que se haga la macro sustitucion de la variable por su contenido.
if (@@Error <> 0)
return -1

--segundo asigno rol especifico al usuario recien creado
exec sp_addsrvrolemember @loginame=@nombre, @rolename=@Rol --este sp ya tiene una transaccion por eso no se usa dentro de una
--paramtrizar los paramentros de ejecucion de un SP se puede hacer siemre y cuando igualemos el nombre del parametro a la variable que
--tra el valor que se le quiere pasar.

if(@@Error = 0)
return 1
else 
return -2
end 
go
-------------------------
--usuario de la base de datos
create proc NuevoUsuarioBD @nombre varchar(10),@rol varchar(30),@logueo varchar(10) as
begin
--primero creo el usr
declare @VarSentencia varchar(200)
set @VarSentencia = 'Create User ['+@nombre+'] from login['+@logueo+']'
exec(@VarSentencia)
if(@@Error <>0)
return -1

--segundo asigno rol especifico al usuario recien creado
exec sp_addrolemember @rolename=@rol,@membername=@nombre

if(@@Error=0)
return 1
else return -2
end
 go
 
 --LOS USUARIOS SE ELIMINAN (DE LOGEO) NO ELIMINA LOS USUARIOS ASOCIADOS EN LAS BD Y ESTOS NO PUEDEN SER USUADOS YA QUE NO TIENEN
 --FORMA DE LOGEARSE LOS USUARIOS DE LAS BD SE PUEDEN LUEGO ASOCIAR A OTRO DE LOGEO
 --
 
 CREATE PROCEDURE EliminarUsuarioSql
 @nombre VARCHAR(10)
 AS
 BEGIN
	DECLARE @VarSentencia VARCHAR(200)
	SET @VarSentencia = 'Drop Login [' + @nombre +']'
	EXEC (@VarSentencia)
	
	IF(@@ERROR = 0)
		RETURN 1
	ELSE
		RETURN -1
END
GO

----PERMISOS
CREATE PROCEDURE QuitarPermisoUsuarioBD
@nombre VARCHAR(10),
@permiso INT 
AS
BEGIN
	DECLARE @VarSentencia VARCHAR(200)
	
	IF(@permiso = 1)
		SET @VarSentencia = 'Revoke Execute to ' + @nombre
	ELSE IF (@permiso = 2)
		SET @VarSentencia = 'Revoke Insert On IngresosDiarios To ' + @nombre
	ELSE
		RETURN -1
	
	EXEC (@VarSentencia)
	
	IF (@@ERROR = 0)
		RETURN 1
	ELSE
		RETURN -2
END
GO

CREATE PROCEDURE CrearIndice 
AS
BEGIN--para ver los usuarios si existe es parecido
	IF(EXISTS(SELECT * FROM sys.indexes WHERE sys.indexes.name = 'MiIndice'))
		RETURN -1
	
	CREATE NonClustered Index MiIndice ON IngresosDiarios(PisoId)
	IF (@@ERROR = 0)
		RETURN 1
	ELSE
		RETURN -2
END
GO

CREATE PROCEDURE DeshabilitarIndice 
AS
BEGIN
	IF NOT (EXISTS(SELECT * FROM sys.indexes WHERE sys.indexes.name = 'MiIndice'))
		RETURN -1
	
	ALTER INDEX MiIndice ON IngresosDiarios DISABLE
	
	IF (@@ERROR = 0)
		RETURN 1
	ELSE
		RETURN -2
END
GO
/*use master
drop login Alumnis
go
use master
drop login [IIS APPPOOL\DefaultAppPool]
go*/


