Use Master;

if exists(Select * FROM SysDataBases WHERE name='Empresa')
BEGIN
	DROP DATABASE Empresa
END
go

create database Empresa 
on(
	name = 'Empresa',
	filename = 'c:\Empresa.mdf'
)
go

USE  Empresa
go

CREATE TABLE Empresas(
	 ruc   int  NOT NULL PRIMARY KEY,
	 nombre   varchar (50) NULL,
)
GO

CREATE TABLE  Empleados (
	 cedula   int  NOT NULL PRIMARY KEY ,
	 nombre   varchar (50) NULL,
	 edad   int  NULL,
	 sueldo   float  NULL,
	 casado   bit  NULL,
	 trabajaEn   int  NULL FOREIGN KEY REFERENCES  Empresas (ruc) 
)
go

CREATE PROCEDURE  listarPorEdad @edad INT
AS
Begin
	SELECT * 
	FROM Empleados
	WHERE Edad > @edad 
End
go 

CREATE PROCEDURE  MaxMinSueldo @min float output,@max float output as
Begin
	SELECT @Max=Max(sueldo),@min =Min(sueldo) 
	FROM Empleados
end
go
 
CREATE PROCEDURE  ListarEmpresas AS
Begin
	SELECT * 
	FROM Empresas
End
go

CREATE PROCEDURE  EmpleadosPorRuc @Ruc int AS
Begin
	SELECT * 
	FROM Empleados
	WHERE TrabajaEn= @Ruc
End
go 

CREATE PROCEDURE AltaEmpleados @cedula int, @nombre varchar(50), @edad int, @sueldo float, @casado bit, @trabaja int AS
Begin
	if (Exists(select * from Empleados where cedula = @cedula))
	begin
		return -1
	end
	else
	begin
		Insert Empleados (cedula, nombre, edad, sueldo, casado, trabajaEn) Values (@cedula, @nombre, @edad, @sueldo, @casado, @trabaja)
		if (@@Error = 0)
		begin 
			return 1
		end
		else
		begin
			return 0
		end
	end
end
go


INSERT INTO Empresas(ruc   ,nombre)VALUES (11111111,'RochaTur');
INSERT INTO Empresas(ruc   ,nombre)VALUES (22222222,'Mar y Playa');
INSERT INTO Empresas(ruc   ,nombre)VALUES (33333333,'Palmares de Rocha');
go
INSERT INTO   Empleados (cedula, nombre, edad, sueldo, casado,	trabajaEn) VALUES(1111111,'Lia I',11,11111.11,1,11111111);
INSERT INTO   Empleados (cedula, nombre, edad, sueldo, casado,	trabajaEn) VALUES(2222222,'Mia II',22,22222.22,2,22222222);
INSERT INTO   Empleados (cedula, nombre, edad, sueldo, casado,	trabajaEn) VALUES(3333333,'Rosa III',33,33333.33,3,11111111);
INSERT INTO   Empleados (cedula, nombre, edad, sueldo, casado,	trabajaEn) VALUES(4444444,'Juan IV',44,44444.44,4,11111111);
INSERT INTO   Empleados (cedula, nombre, edad, sueldo, casado,	trabajaEn) VALUES(5555555,'Ana V',55,55555.55,5,22222222);
go