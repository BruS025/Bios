create database Practico4
GO
use Practico4
go
create table Partes
(
idParte int primary key not null identity,
Nombre varchar(20) not null,
Color varchar(20) null,
Peso int not null,
Ciudad varchar(20) null
)
Go
create table Proyectos
(
idProyecto int primary key not null identity,
Nombre varchar (20) not null,
ciudad varchar(20) null
)
Go
create table Proveedores
(
idProveedores int primary key not null identity,
Nombre varchar(20) not null,
Situacion int not null,
Ciudad varchar(15)not null
)
Go
create table Envios
( 
idProveedores int not null,
idParte int not null,
idProyecto int not null,
Cantidad int not null,
constraint fk_Partes_Envios foreign key(idParte) references Partes(idParte),
constraint fk_Proyectos_Envios foreign key(idProyecto) references Proyectos(idProyecto),
constraint fk_Proveedores_Envios foreign key(idProveedores) references Proveedores(idProveedores)
)
Go
insert into Partes (Nombre,Color,Peso,Ciudad)values('Tuerca','Rojo',12,'Londres')
insert into Partes (Nombre,Color,Peso,Ciudad)values('Perno','Verde',17,'Paris')
insert into Partes (Nombre,Peso,Ciudad)values('Birlo',17,'Roma')
insert into Partes (Nombre,Color,Peso,Ciudad)values('Birlo','Rojo',14,'Londres')
insert into Partes (Nombre,Color,Peso,Ciudad)values('Leva','Azul',12,'Paris')
insert into Partes (Nombre,Color,Peso,Ciudad)values('Engranaje','Rojo',19,'Londres')
GO
insert into Proveedores(Nombre,Situacion,Ciudad)values('Salazar',20,'Londres')
insert into Proveedores(Nombre,Situacion,Ciudad)values('Jaimes',10,'Paris')
insert into Proveedores(Nombre,Situacion,Ciudad)values('Bernal',30,'Paris')
insert into Proveedores(Nombre,Situacion,Ciudad)values('Corona',20,'Londres')
insert into Proveedores(Nombre,Situacion,Ciudad)values('Aldana',30,'Atenas')
GO
insert into Proyectos(Nombre,ciudad)values('Clasificacion','Paris')
insert into Proyectos(Nombre,ciudad)values('Perforadora','Roma')
insert into Proyectos(Nombre,ciudad)values('Lectora','Atenas')
insert into Proyectos(Nombre,ciudad)values('Consola','Atenas')
insert into Proyectos(Nombre,ciudad)values('Compaginador','Londres')
insert into Proyectos(Nombre)values('Terminal')
insert into Proyectos(Nombre,ciudad)values('Cinta','Londres')
Go
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(2,3,5,600)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(2,3,6,400)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(2,3,7,800)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(2,5,2,100)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(3,3,1,200)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(3,4,2,500)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(4,6,3,300)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(4,6,7,300)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,1,4,100)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,2,2,200)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,2,4,100)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,3,4,200)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,4,4,800)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,5,4,400)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,5,5,500)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,5,7,100)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(5,6,4,500)
go
select * from Proyectos
select * from Partes
select * from Proveedores
select * from Envios --sirve para verificar que esten todos los datos creados
