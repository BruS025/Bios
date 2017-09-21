Create database Ejer3Rep
go

use Ejer3Rep

create table Insumos
(
	IdInsumo int primary key not null,
	Nombre varchar(50) not null,
	Stock int not null  
)

create table Trabajos
(
	IdTrabajo int primary key not null,
	Nombre varchar (50) not null,
	Precio int not null
)

create table Pacientes
(
	Cedula bigint primary key not null,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	FechaIngreso datetime not null
)

create table Consultas
(
	IdConsulta int primary key not null,
	IdTrabajo int foreign key references Trabajos (IdTrabajo) not null,
	IdInsumo int foreign key references Insumos (IdInsumo) not null,
	Cedula bigint foreign key references Pacientes(Cedula) not null,
	Fecha datetime not null,
	Cantidad int not null
)

insert into Pacientes(Cedula,Nombre,Apellido,FechaIngreso)Values(11111111,'Ana','Sosa','20161012')
insert into Pacientes(Cedula,Nombre,Apellido,FechaIngreso)Values(22222222,'Eva','Rocha','20161102')
insert into Pacientes(Cedula,Nombre,Apellido,FechaIngreso)Values(33333333,'Gustavo','Ramírez','20160510')
insert into Pacientes(Cedula,Nombre,Apellido,FechaIngreso)Values(44444444,'Marta','Rocha','20160806')
insert into Pacientes(Cedula,Nombre,Apellido,FechaIngreso)Values(55555555,'Miriam','Sosa','20160101')
insert into Pacientes(Cedula,Nombre,Apellido,FechaIngreso)Values(66666666,'Mario','Rodríguez','20161103')

insert into Insumos values (1,'Insumo1',5)
insert into Insumos values (2,'Insumo2',7)
insert into Insumos values (3,'Insumo3',10)
insert into Insumos values (4,'Insumo4',5)
insert into Insumos values (5,'Insumo5',10)
insert into Insumos values (6,'Insumo6',15)

insert into Consultas values (7,

select *

from Pacientes as pa

where pa.FechaIngreso>=getdate()-60

order by pa.FechaIngreso desc