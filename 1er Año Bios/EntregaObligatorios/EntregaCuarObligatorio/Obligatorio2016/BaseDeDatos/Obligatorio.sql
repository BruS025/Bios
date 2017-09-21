USE master
GO

-- Elimino base de datos Obligatorio si ya existe...
if exists (select * from sys.databases where name = 'OBLIGATORIO')
BEGIN
	DROP DATABASE OBLIGATORIO
END 
GO

-- Creo la Base de Datos
CREATE DATABASE OBLIGATORIO
GO

USE OBLIGATORIO
GO

-- Creo la Tabla Clientes...
CREATE TABLE Clientes
(
	ciCli INT NOT NULL PRIMARY KEY,
	nomCli VARCHAR(20) NOT NULL,
	telCli VARCHAR(9) NOT NULL,
	dirCli VARCHAR(40) NOT NULL,
)
GO



-- Creo la tabla Productos
CREATE TABLE Productos
(
	codB INT NOT NULL PRIMARY KEY,
	nomProd VARCHAR(20) NOT NULL,
	fechaVto DATETIME NOT NULL,
	precioProd MONEY NOT NULL,
)
GO

-- Creo la Tabla Enlatados
CREATE TABLE Enlatados
(
	codB INT PRIMARY KEY FOREIGN KEY REFERENCES Productos(codB),
	tipoTapa VARCHAR(10) NOT NULL,
)
GO

-- Creo la Tabla Congelados
CREATE TABLE Congelados
(
	codB INT PRIMARY KEY FOREIGN KEY REFERENCES Productos(codB),
	pesoProd INT NOT NULL,
)
GO


-- Creo la Tabla Ventas...
CREATE TABLE Ventas
(
	idVen INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	fechaVen DATETIME NOT NULL,
	fechaPago DATETIME NOT NULL,
	totalVen MONEY NOT NULL,
	ciCli INT FOREIGN KEY REFERENCES Clientes(ciCli)
)
GO


-- Creo la Tabla Lineas de las Ventas
CREATE TABLE Linea
(
	idVen int foreign key references Ventas(idVen),
	codB INT FOREIGN KEY REFERENCES Productos(codB),
	cantidad int Not Null,
	primary key(idVen, codB)
)
GO
