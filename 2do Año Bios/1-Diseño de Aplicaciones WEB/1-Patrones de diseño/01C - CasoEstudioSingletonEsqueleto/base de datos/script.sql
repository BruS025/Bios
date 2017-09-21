use master
go

drop database Ventas
go
--creo la base de datos de ventas

CREATE DATABASE Ventas
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
	IdFactura INT primary key NOT NULL,
	Fecha DATE NOT NULL,
	NombreCliente VARCHAR (20) NOT NULL
)
GO

CREATE TABLE Linea
(
	IdFactura INT NOT NULL foreign key references Factura(IdFactura),
	CodArt INT NOT NULL FOREIGN KEY REFERENCES Articulos(CodArt),
	Cantidad INT NOT NULL,
	primary key(IdFactura,CodArt)
)
GO

--creo SP de alta
Create Procedure AltaArticulo 
@cod int, 
@nom varchar(20), 
@pre money 
AS
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
Create Procedure BajaArticulo 
@cod int 
AS
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
Create Procedure ModArticulo 
@cod int, 
@nom varchar(20), 
@pre money, 
@estado bit
AS
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
Create Procedure BuscoArticulo
@cod int 
AS
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
	where Estado = 1 
end
go

--Creo SP Alta factura
CREATE PROCEDURE AltaFactura
@IdFactura INT,
@Fecha DATE,
@NombreCli VARCHAR(20)
AS
BEGIN
	IF (EXISTS(SELECT IdFactura FROM Factura where IdFactura = @IdFactura))
		begin
			return -1
		end
	else 
		begin transaction
			insert into Factura (IdFactura,Fecha,NombreCliente) values (@IdFactura,@Fecha,@NombreCli)
	if @@ERROR <>0
		begin
			rollback tran
			return -1
		end
		begin
			commit transaction
			return 1
		end
end
go

--Creo sp altaLinea
CREATE PROCEDURE AltaLinea
@IdFactura INT,
@CodArt INT,
@Cantidad INT
AS
BEGIN
IF EXISTS(SELECT IdFactura FROM Factura where IdFactura = @IdFactura)
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
	begin
		RETURN -2
	end
END
go

--Creo el SP de baja
CREATE PROCEDURE EliminarFactura
@IdFactura int
AS
begin
IF EXISTS (SELECT IdFactura FROM Factura where IdFactura = @IdFactura)
	begin
		begin transaction 
		
			delete Linea
			where IdFactura = @IdFactura
		
				if @@error <>0
			begin 
				rollback transaction 
				return -1
			end
		
			delete Factura
			where IdFactura = @Idfactura
		if @@error <>0
			begin 
				rollback transaction 
				return -1
			end
		commit transaction
		return 1
	end
else
	begin
		return -2
	end
end
go	

--creo sp buscar factura
CREATE PROCEDURE BuscarFactura
@IdFactura int
AS
BEGIN
IF EXISTS (SELECT F.IdFactura FROM Factura F where IdFactura=@IdFactura
	begin
		select  F.Fecha,
	            F.NombreCliente
	    FROM Factura F
		WHERE F.IdFactura = @IdFactura
	END
ELSE
	BEGIN
		RETURN -1
	END
END
GO

--Creo SP Busqueda de linea 
CREATE PROCEDURE BuscarLinea
@Id int
AS
BEGIN 
IF EXISTS (SELECT IdFactura FROM Factura where IdFactura=@Id)
begin
	select  A.CodArt,
			A.NomArt,
			A.PreArt,
			L.Cantidad 
	from  Linea L join Articulos A on L.CodArt=A.CodArt
	where L.IdFactura=@Id
end
else
	begin
		return-1
	end
end
go
--ingreso datos de prueba
Exec AltaArticulo 23, "Licuadora", 2500
go
Exec AltaArticulo 48, "Maquina de Coser", 6700
go
Exec AltaArticulo 514, "Ventilador de Techo Vertical", 250
go
