-----------------------------------------------------------------------------
create database ArticulosDB

go
------------------------------------------------------------------------------------

use ArticulosDB

create TABLE Articulos(
	  Id INT IDENTITY primary key,
	  Nombre NVARCHAR(150) NOT NULL,
	  Tipo VARCHAR (50) not null, 
	);
go

create table Pedidos
(
	IdPedido int identity not null Primary key,
	Fecha datetime not null,
	Descripcion varchar(150) null,
	total int not null,
	subtotal int not null,
	Cliente varchar(150) not null
)
go

create table tienen
(
	cantidad int not null,
	PrecioU int not null,
	idArticulo int foreign key references Articulos(id),
	IdPedido int foreign key references Pedidos(IdPedido)
)
go

------------------------------------------------------------------------------------
insert into Articulos values ('Jabon','Limpieza')
insert into Articulos values ('Lapiz','Escolar')
insert into Articulos values ('Azucar','Almacen')
insert into Articulos values ('Leche','Lacteos')
insert into Articulos values ('frutillas','Verduleria')

go




CREATE PROC Agregarr
	@fecha datetime,
	@descripcion varchar(150),
	@total int,
	@subtotal int,
	@Cliente varchar(150)
	as
begin
	INSERT INTO Pedidos VALUES (@fecha,@descripcion,@total,@subtotal,@Cliente);
		return @@identity
end
go


alter proc Buscar
 @Id int,
 @Nombre varchar (150) output,
 @Tipo varchar (50) output
 as 
 begin
		select @Nombre = Nombre,
		@Tipo = Tipo
				
		 from Articulos where Id = @Id
		
	end
go
	
	create proc Modificar
 @Id int,
 @Nombre varchar (150),
 @Tipo varchar (50)
 as 
begin
		update Articulos set Nombre = @Nombre, Tipo = @Tipo where Id=@Id
		
		IF (@@ROWCOUNT>0)
			RETURN 1;
		ELSE
			RETURN -1;	

	end

