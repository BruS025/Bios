----------------------------------------------------------------------------------
create database ArticulosDBClase

go
------------------------------------------------------------------------------------

use ArticulosDBClase

CREATE TABLE Articulos(
	  Id INT IDENTITY PRIMARY KEY,
	  Nombre NVARCHAR(150) NOT NULL,
	  Tipo VARCHAR (50) not null
	  
	);
	go

------------------------------------------------------------------------------------
insert into Articulos values ('Jabon','Limpieza')
insert into Articulos values ('Lapiz','Escolar')
insert into Articulos values ('Azucar','Almacen')
insert into Articulos values ('Leche','Lacteos')
insert into Articulos values ('frutillas','Verduleria')

go


------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
CREATE TABLE Pedido(
	  IdPedido INT IDENTITY PRIMARY KEY,
	  Fecha DATETIME NOT NULL,
	  Descripcion VARCHAR (150) not null, 
	  Total int NOT NULL,
	  SubTotal int NOT NULL,
	  Cliente VARCHAR (100)
	  
	);
	go


------------------------------------------------------------------------------------

CREATE TABLE Tiene(
	  Id INT FOREIGN KEY REFERENCES Articulos(Id),	
	  IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido),	   
	  Cantidad INT NOT NULL,
	  Precio INT	  
	);
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


create proc Buscar
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
