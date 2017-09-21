--Creo la base de datos
Create database ObligatorioPrueba
go
--Le digo que base de datos usar al sql
use ObligatorioPrueba
go

--Creo las tablas de la base de datos

create table ProductosCongelados
(
	NombreCongelado varchar (20) not null,
	PrecioCongelado int not null,
	FechaVencimientoCongelado datetime not null,
	Peso float not null,
	CodigoCongelado int not null primary key,
	CantDelProducto int not null
)
go


create table ProductosEnlatados
(
	NombreEnlatados varchar (20) not null,
	PrecioEnlatados int not null,
	FechaVencimientoEnlatados datetime not null,
	AbreFacil bit not null,
	CantDelProducto int not null,
	CodigoEnlatados int not null primary key
)
go

create table Clientes
(
	NombreCliente varchar(20) not null,
	ApellidoCliente varchar(20) not null,
	TelefonoCliente int not null,
	NombreCalle varchar (30) not null,
	NumeroCalle int not null,
	CiCliente int primary key not null,
)
go

create table Ventas
(
	TotalDeVenta int not null,
	CantDelProductoVendido int not null,
	FechaDeLaVenta smalldatetime not null,
	CodigoDeVenta int not null primary key identity,
	CodigoCongelado int foreign key references ProductosCongelados(CodigoCongelado),
	CodigoEnlatado int foreign key references ProductosEnlatados(CodigoEnlatados),
	CiCliente int foreign key references Clientes(CiCliente) not null,
)
go

select * from Ventas
--Insertamos valores de prueba en las tablas

insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Papita Caliente',15,'20170114',5,12345,10)
insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Pescado Oloroso',16,'20170115',6,23456,11)
insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Atun en Empanadas',17,'20170116',7,34567,12)
insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Salpicon de Bagre',18,'20170117',8,45678,13)
insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Siluriformes',19,'20161118',9,56789,14)
insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Arbejas al Curri',20,'20161119',10,67890,15)
go

insert ProductosEnlatados (NombreEnlatados,PrecioEnlatados,FechaVencimientoEnlatados,AbreFacil,CodigoEnlatados,CantDelProducto) values ('Lengua de Suegra',25,'20170224',1,11223,20)
insert ProductosEnlatados (NombreEnlatados,PrecioEnlatados,FechaVencimientoEnlatados,AbreFacil,CodigoEnlatados,CantDelProducto) values ('Banana en Lata',26,'20170225',1,22334,21)
insert ProductosEnlatados (NombreEnlatados,PrecioEnlatados,FechaVencimientoEnlatados,AbreFacil,CodigoEnlatados,CantDelProducto) values ('Mix de Arbejas',27,'20170226',1,33445,22)
insert ProductosEnlatados (NombreEnlatados,PrecioEnlatados,FechaVencimientoEnlatados,AbreFacil,CodigoEnlatados,CantDelProducto) values ('Boniato en Almibar',28,'20170227',0,44556,23)
insert ProductosEnlatados (NombreEnlatados,PrecioEnlatados,FechaVencimientoEnlatados,AbreFacil,CodigoEnlatados,CantDelProducto) values ('Pepino en Concerva',29,'20161119',0,55667,24)
insert ProductosEnlatados (NombreEnlatados,PrecioEnlatados,FechaVencimientoEnlatados,AbreFacil,CodigoEnlatados,CantDelProducto) values ('Rabanos',30,'20161120',0,66778,25)
go

insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Arturo','Gomez',0303456,'DelPerro',1213,1111111)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Pepita','LaLoca', 29008335,'Yaguaron',1414,2222222)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Andrea','Del Carmen',29013223,'Paysandu',1313,3333333)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Pampita','LaArgentina',29085694,'Reyles',1616,4444444)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Armando','Paredez',29085694,'Buxareo',2020,5555555)
go

insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoCongelado,CiCliente) values (15,1,'20161027',12345,1111111)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoCongelado,CiCliente) values (45,3,'20161027',12345,1111111)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoCongelado,CiCliente) values (32,2,'20161027',23456,1111111)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoCongelado,CiCliente) values (51,3,'20161027',34567,1111111)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoCongelado,CiCliente) values (80,4,'20161127',67890,3333333)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoEnlatado,CiCliente) values (25,1,'20161028',11223,2222222)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoEnlatado,CiCliente) values (52,2,'20161028',22334,2222222)
insert ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoEnlatado,CiCliente) values (81,3,'20161031',33445,5555555)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoEnlatado,CiCliente) values (150,5,'20161127',66778,4444444)
insert Ventas (TotalDeVenta,CantDelProductoVendido,FechaDeLaVenta,CodigoEnlatado,CiCliente) values (150,5,'20161125',66778,4444444)
go

--Iniciamos los sp

select * from Ventas

create proc ProductosPorVencer 
as
begin
    declare @FechaInicio datetime
	declare @FechaFin datetime
	set @FechaInicio = GETDATE()
	set @FechaFin =GETDATE()+30
select

	PC.NombreCongelado,
	PC.FechaVencimientoCongelado
	
from 
	ProductosCongelados PC
where 
	PC.FechaVencimientoCongelado between @FechaInicio and @FechaFin
	(select PE.NombreEnlatados,
			PE.FechaVencimientoEnlatados
	 from 
			ProductosEnlatados PE 
	 where 
			PE.FechaVencimientoEnlatados between @FechaInicio and @FechaFin)
end
go
exec ProductosPorVencer
go

alter proc AgregarProductoCongelado
	@NombreAgregar varchar(20),
	@PrecioAgregar int,
	@FechaVencimientoAgregar datetime,
	@PesoAgregar int,
	@CantProdAgre int,
	@CodigoCongAgregar int  
as

if exists (select PC.CodigoCongelado from ProductosCongelados PC where PC.CodigoCongelado=@CodigoCongAgregar union select PE.CodigoEnlatados from ProductosEnlatados PE where PE.CodigoEnlatados=@CodigoCongAgregar)
	begin 
		return -1
	end
else
	begin transaction	
				if @PrecioAgregar <=0
					begin
						rollback tran
							select 'Cod.Del.Error==> ' + cast(@@Error as nvarchar(20)) as 'El precio tiene que ser mayor que 0'
					end
				else if @FechaVencimientoAgregar <= GETDATE()
					begin
						rollback tran
							select 'Cod.Del.Error==> ' + cast(@@Error as nvarchar(20)) as 'La fecha tiene que ser mayor al dia actual'
					end
				else if @PesoAgregar<=0
					begin
						rollback tran
							select 'Cod.Del.Error==> ' + cast(@@Error as nvarchar(20)) as 'El peso tiene que ser mayor que 0'
					end
				else if @CantProdAgre <=0
					begin
						rollback tran
							select 'Cod.Del.Error==> ' + cast(@@Error as nvarchar(20)) as 'La cantidad del producto tiene que ser mayor a 0'
					end
				else if @CodigoCongAgregar<=0
					begin
						rollback tran
							select 'Cod.Del.Error==> ' + cast(@@Error as nvarchar(20)) as 'El codigo del producto tiene que ser superior a 0'
					end
				else
					begin
						insert into ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values (@NombreAgregar,@PrecioAgregar,@FechaVencimientoAgregar,@PesoAgregar,@CodigoCongAgregar,@CantProdAgre)
							commit tran
								select 'Codigo==> ' + cast(1 as nvarchar(20)) as 'Se a agregado correctamente el producto'
					end
go
declare @retorno int
exec @retorno = AgregarProductoCongelado prueba,1,'20161130',1,1,222
print @retorno
go
--Orden del sp para agregar
/*	@NombreAgregar
	@PrecioAgregar 
	@FechaVencimientoAgregar
	@PesoAgregar 
	@CantProdAgre 
	@CodigoCongAgregar 
*/

create proc TotalRecaudadoPorProd
	@FechaInicio datetime,
	@FechaFin datetime,
	@CodProd int
as
begin
	select Sum(ve.TotalDeVenta) as 'Total Recaudado',
		   pc.NombreCongelado
	from Ventas ve join ProductosCongelados pc on ve.CodigoCongelado=pc.CodigoCongelado
		
	where 
	ve.CodigoCongelado=@CodProd and ve.FechaDeLaVenta between @FechaInicio and @FechaFin
	group by 
	pc.NombreCongelado

	union 

	select Sum(ve.TotalDeVenta) as 'Total Recaudado',
		   pe.NombreEnlatados
	from
		 Ventas ve join ProductosEnlatados pe on ve.CodigoEnlatado=pe.CodigoEnlatados
	where 
		 ve.CodigoEnlatado=@CodProd and ve.FechaDeLaVenta between @FechaInicio and @FechaFin
	group by 
	 	pe.NombreEnlatados

end

exec TotalRecaudadoPorProd '20161127','20161127',66778
go

create proc ProductoMasVendido

as
begin
	select
	 top 3(ve.CantDelProductoVendido),
	 pc.Peso,
	 pc.CantDelProducto,
	 pc.CodigoCongelado,
	 pc.FechaVencimientoCongelado,
	 pc.NombreCongelado,
	 pc.PrecioCongelado
	from Ventas as ve inner join ProductosCongelados  as pc on ve.CodigoCongelado=pc.CodigoCongelado
	order by ve.CantDelProductoVendido desc

	select top 3(ve.CantDelProductoVendido),
	pe.AbreFacil,
	pe.CantDelProducto,
	pe.CodigoEnlatados,
	pe.FechaVencimientoEnlatados,
	pe.NombreEnlatados,
	pe.PrecioEnlatados
	from Ventas as ve inner join ProductosEnlatados as pe on ve.CodigoEnlatado=pe.CodigoEnlatados
	order by ve.CantDelProductoVendido desc
end

exec ProdMasVendido
go

alter proc EliminarProducto
	@CodigoAEliminar int
as
begin
	 if not exists (select pc.CodigoCongelado from ProductosCongelados as pc where pc.CodigoCongelado=@CodigoAEliminar union select pe.CodigoEnlatados from ProductosEnlatados as pe where pe.CodigoEnlatados=@CodigoAEliminar)
		begin
			return 0
		end
	else if exists (select ve.CodigoCongelado from Ventas as ve where ve.CodigoCongelado=@CodigoAEliminar union select ven.CodigoEnlatado from Ventas as ven where ven.CodigoEnlatado=@CodigoAEliminar)
		begin
			return -1
		end
	 if exists (select pc.CodigoCongelado from ProductosCongelados as pc where pc.CodigoCongelado=@CodigoAEliminar)
		begin transaction
			delete ProductosCongelados 
			where CodigoCongelado = @CodigoAEliminar
			
			if @@Error <> 0
				begin
					rollback transaction
					return @@Error
				end
			else
				begin
					commit transaction
					return 1
				end
	 if exists( select pe.CodigoEnlatados from ProductosEnlatados as pe where pe.CodigoEnlatados=@CodigoAEliminar)
		begin transaction
		delete ProductosEnlatados
			where CodigoEnlatados = @CodigoAEliminar

			if @@ERROR <> 0
				begin
					rollback transaction
					return 0
				end
			else 
				begin
					commit transaction
					return 1
				end	
end
declare @retorno int
exec @retorno=EliminarProducto 34569
print @retorno