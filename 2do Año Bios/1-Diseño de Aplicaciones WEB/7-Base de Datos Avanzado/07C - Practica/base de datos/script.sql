--creo la base de datos de ventas
if exists(Select * FROM SysDataBases WHERE name='Ventas')
BEGIN
	DROP DATABASE Ventas
END
go

CREATE DATABASE Ventas

go

--pone en uso la bd
USE Ventas
go

--creo la tabla de Articulos
CREATE TABLE Articulos(
	CodArt int NOT NULL PRIMARY KEY ,
	NomArt varchar(20) NOT NULL,
	PreArt Money
) 
go

CREATE TABLE Factura(
	NumFac int NOT NULL IDENTITY PRIMARY KEY,
	FechaFac DATETIME NOT NULL,
	NomCli VARCHAR(30) NOT NULL,
	TotBru MONEY NOT NULL,
	TotIva MONEY NOT NULL,
	TotFac MONEY NOT NULL
)

GO

CREATE TABLE LineaFactura(
	NumFac int NOT NULL FOREIGN KEY REFERENCES Factura(NumFac),
	CodArt int NOT NULL FOREIGN KEY REFERENCES Articulos(CodArt),
	Cantidad int NOT NULL
	PRIMARY KEY (NumFac, CodArt)
)

GO

--CREO

--creo SP de alta
Create Procedure AltaArticulo @cod int, @nom varchar(20), @pre money AS
Begin
	if (exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Insert Articulos(CodARt, NomArt, PreArt) Values (@cod, @nom, @pre)
		return 1
	end
end
go

--creo SP de Baja
Create Procedure BajaArticulo @cod int AS
Begin
	if (not exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Delete From Articulos where codArt = @cod
		return 1
	end
end
go

--creo SP de modificacion
Create Procedure ModArticulo @cod int, @nom varchar(20), @pre money AS
Begin
	if (not exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Update Articulos Set NomArt=@nom, PreArt=@pre where codArt = @cod
		return 1
	end
end
go

--creo SP de busqueda
Create Procedure BuscoArticulo @cod int AS
Begin
	Select *
	From Articulos
	where codArt = @cod
end
go

--creo SP de listado
Create Procedure ListoArticulo AS
Begin
	Select *
	From Articulos
end
go

--ingreso datos de prueba
Exec AltaArticulo 23, "Licuadora", 2500
go
Exec AltaArticulo 48, "Maquina de Coser", 6700
go
Exec AltaArticulo 514, "Ventilador de Techo Vertical", 250
go

--CREO SP ALTA FACTURA

CREATE PROC AltaLineaFactura @numFac INT, @codArt INT, @cantidad INT
AS
BEGIN
	if not exists(select * from Articulos where codArt = @codArt)
		return -1
	if not exists(select * from Factura where NumFac = @numFac)
		return -2
	if (SELECT COUNT(*) FROM LineaFactura WHERE NumFac = @numFac) >= 5
		return -3
		
	INSERT LineaFactura
	VALUES(@numFac,@codArt, @cantidad)
	
	IF @@ERROR <> 0
	BEGIN
		RETURN -4
	END

END
GO 

CREATE PROC AltaFactura 
@fechaFac DATETIME, 
@nomCli VARCHAR(30), 
@totBru MONEY, 
@totIva MONEY, 
@totFac MONEY
AS
BEGIN

	INSERT Factura
	VALUES(@fechaFac, @nomCli, @totBru, @totIva, @totFac)
	
	if @@ERROR <> 0
	BEGIN
		RETURN -1
	END
	
	RETURN ident_current('Factura');
	
END

GO