-- Creo la base de datos -----------------------------------------------------------------------------
use master
go

if exists(Select * FROM SysDataBases WHERE name='Archivador')
BEGIN
	DROP DATABASE Archivador
END
go

CREATE DATABASE Archivador
go

-- Creo la estructura de la bd ----------------------------------------------------------------------
USE Archivador
go

CREATE TABLE Archivos(
	Id bigint NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre varchar(256) NOT NULL,
	Extension varchar(4) NULL,
	Tamanio bigint NOT NULL,
	FechaCreacion datetime NOT NULL
) 
go


--creo SP para manejo ------------------------------------------------------------------------------
Create Procedure AltaArchivo @nom varchar(256), @ext varchar(4), @tam bigint, @fecha datetime AS
Begin
	if (exists(select * from Archivos where Nombre = @nom))
		return -1
	else
	begin
		Insert Archivos(Nombre, Extension, Tamanio, FechaCreacion) Values (@nom, @ext, @tam, @fecha)
		return 1
	end
end
go
