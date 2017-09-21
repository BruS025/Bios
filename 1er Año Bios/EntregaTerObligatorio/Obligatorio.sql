--Creo la base de datos
Create database Obligatorio
go
--Le digo que base de datos usar al sql
use Obligatorio
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
	CodigoCongelado int not null,
	CiCliente int not null,
	CodigoDeVenta int not null primary key identity,
	CantDeProductosAVender int identity,
	constraint fk_ProductosCongelados_Ventas foreign key(CodigoCongelado) references ProductosCongelados(CodigoCongelado),
	constraint fk_ProductosCongelados_Clientes foreign key(CiCliente) references Clientes(CiCliente),
)
go

--Insertamos valores de prueba en las tablas

insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Papita Caliente',15,'20170114',5,12345,10)
insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Pescado Oloroso',16,'20170115',6,23456,11)
insert ProductosCongelados (NombreCongelado,PrecioCongelado,FechaVencimientoCongelado,Peso,CodigoCongelado,CantDelProducto) values ('Empanada de Atun',17,'20170116',7,34567,12)
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

insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Arturo','Gomez',0303456,'DelPerro',1213,12345)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Pepita','LaLoca', 29008335,'Yaguaron',1414,23456)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Andrea','Del Carmen',29013223,'Paysandu',1313,34567)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Pampita','LaArgentina',29085694,'Reyles',1616,45678)
insert Clientes (NombreCliente,ApellidoCliente,TelefonoCliente,NombreCalle,NumeroCalle,CiCliente) values ('Armando','Paredez',29085694,'Buxareo',2020,56789)
go

alter proc ProductosPorVencer 
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

exec ProductosPorVencer
go

create proc AgregarProductoCongelado
as
begin

end

