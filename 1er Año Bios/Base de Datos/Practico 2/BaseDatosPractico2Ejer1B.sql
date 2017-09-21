Create database Practico2Ejer1B

GO--Creo la base de datos

use Practico2Ejer1B

GO--Le indico que base de datos usar

create table Cargos
(
	IDCargo varchar(20) NOT NULL PRIMARY KEY,
	Denominacion varchar(20) NOT NULL,
	Sueldo int NOT NULL
)
Go--Creo la tabla cargos con las columnas

create table Empleados
(
	IDEmp int PRIMARY KEY NOT NULL,
    CI int NOT NULL,
	Nombre varchar(20) NOT NULL,
	Apellido varchar(20) NOT NULL,
	Dirección varchar(20) NULL,
	Licencia bit NOT NULL
)
Go--Creo la tabla Empleados con las columnas

create table Secciones
(
	IDSección varchar(20) NOT NULL PRIMARY KEY,
	Descripción varchar(20) NOT NULL
)
Go--Creo la tabla Secciones

create table Trabajan
(
	IDEmp int NOT NULL,
	IDCargo varchar(20) NOT NULL,
	IDSección varchar(20) NOT NULL,
	FechaIng int NOT NULL,
	constraint fk_Cargos_Trabajan FOREIGN KEY (IDCargo) REFERENCES Cargos(IDCargo),
	constraint fk_Empleados_Trabajan FOREIGN KEY(IDEmp) REFERENCES Empleados(IDEmp)
)
Go--Creo la tabla Trabajan

insert into Cargos (IDCargo,Denominacion,Sueldo)Values('Adm','Administrador',5000)
insert into Cargos (IDCargo,Denominacion,Sueldo)Values('Aux','Auxiliar',4000)
insert into Cargos (IDCargo,Denominacion,Sueldo)Values('Enc','Encargada',7000)
insert into Cargos (IDCargo,Denominacion,Sueldo)Values('Ger','Gerente',12000)
insert into Cargos (IDCargo,Denominacion,Sueldo)Values('Mof','Medio Oficial',5000)
insert into Cargos (IDCargo,Denominacion,Sueldo)Values('Of1','Oficial de primera',6000)
insert into Cargos (IDCargo,Denominacion,Sueldo)Values('Sin','Sin Denominación',1001)

Go --Insertando datos a la tabla cargos,,Los valores insertados van en el orden que los colocamos

insert into Empleados(IDEmp,CI,Nombre,Apellido,Dirección,Licencia)Values(1,11111111,'Ana','Sosa','Yí 1111',1)
insert into Empleados(IDEmp,CI,Nombre,Apellido,Dirección,Licencia)Values(2,22222222,'Eva','Rocha','Yí 2222',0)
insert into Empleados(IDEmp,CI,Nombre,Apellido,Dirección,Licencia)Values(3,33333333,'Gustavo','Ramírez','Río Branco 3321',1)
insert into Empleados(IDEmp,CI,Nombre,Apellido,Licencia)Values(4,44444444,'Marta','Rocha',0)
insert into Empleados(IDEmp,CI,Nombre,Apellido,Dirección,Licencia)Values(5,55555555,'Miriam','Sosa','18 de Julio 1201',1)
insert into Empleados(IDEmp,CI,Nombre,Apellido,Dirección,Licencia)Values(6,66666666,'Mario','Rodríguez','Andes 1209',0)

Go--Insertamos datos en la tabla empleados

insert into Secciones(IDSección,Descripción)Values('Cre','Crédito')
insert into Secciones(IDSección,Descripción)Values('Ger','Gerencia')
insert into Secciones(IDSección,Descripción)Values('Man','Mantenimiento')
insert into Secciones(IDSección,Descripción)Values('Sec','Secretaria')
insert into Secciones(IDSección,Descripción)Values('Ven','Ventas')

Go--Insertamos datos en la tabla Secciones

insert into Trabajan(IDEmp,IDCargo,IDSección,FechaIng)Values(1,'GER','ger',2/10/1999)
insert into Trabajan(IDEmp,IDCargo,IDSección,FechaIng)Values(2,'AUX','VEN',3/10/1999)
insert into Trabajan(IDEmp,IDCargo,IDSección,FechaIng)Values(3,'Aux','CRE',9/10/2001)
insert into Trabajan(IDEmp,IDCargo,IDSección,FechaIng)Values(4,'OF1','MAN',3/10/2001)
insert into Trabajan(IDEmp,IDCargo,IDSección,FechaIng)Values(5,'Aux','ven',12/10/2001)

Go--Insertamos datos en la tabla Trabajan