-- Creo la base de datos -----------------------------------------------------------------------------------------------
USE master
go

if exists(Select * FROM SysDataBases WHERE name='Clase4')
BEGIN
	DROP DATABASE Clase4
END
go

CREATE DATABASE Clase4
go

-- creo tablas ----------------------------------------------------------------------------------------------------------
USE Clase4
go

CREATE TABLE Alumnos(
	Nombre varchar(20) NOT NULL PRIMARY KEY,
	Apellido varchar(20) NOT NULL,
	Nota int,
	Materia varchar(20) NOT NULL
) 
go

INSERT INTO Alumnos values ('Rodri','Anto',90,'MAT')
INSERT INTO Alumnos values ('Fer','Trus',90,'MAT')
INSERT INTO Alumnos values ('Tiki','Taca',50,'BIO')
INSERT INTO Alumnos values ('Placa','Trika',90,'INF')