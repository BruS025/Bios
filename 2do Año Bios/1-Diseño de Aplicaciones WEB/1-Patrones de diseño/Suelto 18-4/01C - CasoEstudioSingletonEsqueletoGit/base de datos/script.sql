--creo la base de datos de ventas
if exists(Select * FROM SysDataBases WHERE name='Ventas')
BEGIN
	DROP DATABASE Ventas
END
go

CREATE DATABASE Ventas
ON(
	NAME=Venta,
	FILENAME='C:\Users\popi\Desktop\CasoDeEstudio\01C - CasoEstudioSingleton\base de datos\Ventas.mdf'
)
go

--pone en uso la bd
USE Ventas
go

--creo la tabla de Articulos
CREATE TABLE Articulos(
	CodArt int NOT NULL PRIMARY KEY ,
	NomArt varchar(20) NOT NULL,
	PreArt Money,
	Estado BIT default 1
) 
go

CREATE TABLE Factura
(
	IdFactura INT NOT NULL foreing key,
	Fecha DATE NOT NULL,
	NombreCliente VARCHAR (20) NOT NULL,
)
GO

CREATE TABLE Linea
(
	IdFactura INT NOT NULL foreign key references FACTURA(IdFactura),
	CodArt INT NOT NULL FOREIGN KEY REFERENCES Articulos(CodArt),
	Cantidad INT NOT NULL,
	primary key(IdFactura,CodArt)
)
GO

--creo SP de alta
Create Procedure AltaArticulo @cod int, @nom varchar(20), @pre money AS
Begin
	if (exists(select * from Articulos where codArt = @cod and Estado =0))
		update Articulos
		set Estado = 1
		where CodArt=@cod
		return 2
	if (exists (select * from Articulo where codArt = @cod and Estado = 1))
	begin
		return 3
	end
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
	
	if (exists(select * from linea where codArt = @cod))
		update Articulos
		set Estado = 0
		where codArt=@cod
	else
	begin
		Delete From Articulos where codArt = @cod
		return 1
	end
end
go

--creo SP de modificacion
Create Procedure ModArticulo @cod int, @nom varchar(20), @pre money, @estado bit AS
Begin
	if (not exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Update Articulos Set NomArt=@nom, PreArt=@pre, Estado=@estado where codArt = @cod
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

--Creo SP Alta factura
CREATE PROCEDURE AltaFactura
@IdFactura INT,
@Fecha DATE,
@NombreCli VARCHAR(20),
AS
BEGIN
	IF (EXISTS(SELECT IdFactura FROM Factura where IdFactura = @IdFactura)
	return -1
	else 
	begin transaction
	insert into Factura (IdFactura,Fecha,NombreCliente) values (@IdFactura,@Fecha,@NombreCli)
	if @@ERROR <>0
		begin
		rollback tran
			return -1
		end
	else 
		commit transaction
			return 1
	end
end

--Creo sp altaLinea
CREATE PROCEDURE AltaLinea
@IdFactura INT
@CodArt INT,
@Cantidad INT
AS
BEGIN
IF (EXISTS(SELECT IdFactura FROM Factura where IdFactura = @IdFactura)
BEGIN
	insert into Linea (IdFactura,CodArt,Cantidad) values (@IdFactura, @CodArt, @Cantidad)
	if @@ERROR <>0
		begin
		 rollback tran
			return -1
		end
	return 2
END
	ELSE
		RETURN 1
END

--Creo el SP de baja
CREATE PROCEDURE Eliminar
@IdFactura
AS
IF EXISTS (SELECT IdFactura FROM Factura where IdFactura = @IdFactura)
	begin
		begin transaction 
			delete Factura
			where IdFactura = @Idfactura
		
			delete Linea
			where IdFactura = @IdFactura
		if @@error <>0
			begin 
				rollback transaction 
				return -1
			end
else
return -2
end
	
--ingreso datos de prueba
Exec AltaArticulo 23, "Licuadora", 2500
go
Exec AltaArticulo 48, "Maquina de Coser", 6700
go
Exec AltaArticulo 514, "Ventilador de Techo Vertical", 250
go
