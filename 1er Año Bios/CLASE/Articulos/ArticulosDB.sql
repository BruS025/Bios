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
	Descuento int null,
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



------------------------------------------------------------------------------------
CREATE PROC Agregar  @IdMateria int, @Nombre NVARCHAR(20), @Año INT AS
begin
	If (exists(select * from materias where IdMAteria = @IdMateria))
		return -1;
	INSERT INTO materias VALUES (@Idmateria,@nombre,@Año);
		IF (@@ERROR<>0)
			RETURN -2;
		ELSE
			RETURN 1;	
end
go


Create Proc Salida @Id int, @Nom Nvarchar(20) output AS
Begin
		Select @nom = nombre
		From materias
		Where IdMateria = @id
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

