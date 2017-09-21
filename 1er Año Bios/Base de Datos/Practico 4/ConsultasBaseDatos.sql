use Practico4
go
--Obtener todos los números de partes enviados. 
create proc numParteEnviados as 
begin
select idParte
from Envios
end
exec numParteEnviados
go
--2Obtener los distintos números de partes enviados. 
create proc numDistParteEnviado as
begin 
select distinct 
idParte
from Envios
end
exec numDistParteEnviado 
go
--3 Datos completos de todos los proveedores. 
create proc datosProv as
begin 
select*from Proveedores
end
exec datosProv
go
--4 Números de los proveedores radicados en Paris cuya situación sea mayor que 20. 
create proc datosProvExactos as
begin 
select 
p.Ciudad,
p.idProveedores
from Proveedores p
where p.Situacion>20
end
exec datosProvExactos
go
--5 Números de proveedor y situación de los proveedores radicados en Paris en orden descendiente por situación. 
create proc situacionProv as
begin 
select 
p.idProveedores,
p.Situacion,
p.Ciudad
from Proveedores p
where p.Ciudad = 'Paris'
order by p.Situacion desc --es para darle el orden descendiente 
end
exec situacionProv
go
--6 . Todas las combinaciones de información de proveedores y partes, tales que el proveedor y la parte en cuestión estén situados en la misma ciudad. 
create proc provPartesMismoLado as--alter es para modificar los datos por si te olvidas de algo
begin
select
pr.Ciudad,
pr.idProveedores,
pr.Nombre,
pr.Situacion,
pa.Ciudad,
pa.Color,
pa.idParte,
pa.Nombre,
pa.Peso
from Proveedores pr join Partes pa on pr.Ciudad=pa.Ciudad
end
exec provPartesMismoLado
go
--7 Toda la información de proveedores y partes donde el proveedor y la parte en cuestión estén en la misma ciudad,omitiendo a los proveedores cuya situación sea 20. 
create proc ParProvMismoLadoDifSitu as
begin
select
pr.Ciudad,
pr.idProveedores,
pr.Nombre,
pr.Situacion,
par.Ciudad,
par.Color,
par.idParte,
par.Nombre,
par.Peso
from Proveedores pr join Partes par on pr.Ciudad=par.Ciudad
where pr.Situacion!=20
end
exec ParProvMismoLadoDifSitu
go
--8 Número total de proveedores. 
create proc numtotalprov as
begin
select top 1
p.idProveedores
from Proveedores p
order by idProveedores desc
end 
exec numtotalprov
go
--9 Números de envíos de la parte 2. 
create proc ordenparte2 as
begin
select 
e.idParte
from Envios e
where e.idParte =2
end
exec ordenparte2
go
--10 Cantidad total suministrada de la parte 2. 
create proc cantotal as
begin
select sum(Cantidad) as 'Suma'
from Envios e
where e.idParte = 2
end
go
exec cantotal
go
--11 Número de parte y cantidad total enviada a cada uno de los proyectos. 
create proc canttotalpartproyec as
begin 
select 
e.idProyecto,
e.idParte,
sum(e.Cantidad) as 'Suma total'
from Envios e
group by e.idProyecto, e.idParte
end
go
exec canttotalpartproyec
go
--12 Todos los envíos en los cuales la cantidad está en el intervalo de 300 a 750 inclusive. 
create proc ejer12 
@entre int,@entre2 int
as
begin
select
e.idParte,
e.idProveedores,
e.idProyecto,
e.Cantidad
from envios e
where Cantidad between @entre and @entre2 
end
go 
exec ejer12 300 ,700
go
--13 Obtener los números de las partes suministradas por un proveedor de Londres a un proyecto en Londres.
create proc ejer13 as
begin
select distinct
pro.ciudad,
prov.idProveedores
from Proveedores prov join Proyectos pro on prov.Ciudad=pro.ciudad 
where prov.Ciudad = 'Londres'
end
go
exec ejer13
go
--14 Todas las partes cuyo nombre comienza con la letra B. 
create proc ejer14 
@letraABuscar varchar(20)
as
begin
select
par.Nombre
from Partes par
where par.Nombre LIKE @letraABuscar+'%'--concatenar el porcentaje para el like solamente
end
go
exec ejer14 T
GO
--15 Nombre de los proveedores que suministran la parte 2, 
create proc ejer15
@idparte int
as
begin
select distinct
env.idParte,
prov.Nombre
from Envios env join Proveedores prov on env.idParte=prov.idProveedores
where env.idParte = @idparte
end
go
exec ejer15 2
go
--16..Nombre de los proveedores parte y proyectos que están relacionados
create proc ejer16
as
begin
select
prov.Nombre,
par.Nombre,
proy.Nombre
from Envios envi
inner join Proveedores prov on envi.idProveedores=prov.idProveedores
inner join Partes par on envi.idParte=par.idParte
inner join Proyectos proy on envi.idProyecto=proy.idProyecto
end
go
exec ejer16
go

--ejer 17 Nombre de los proveedores que no suministran la parte 2 (utilizando IN). 
alter proc  ejer17
@numabuscar int
as
begin
select distinct
env.idParte,
prov.Nombre
from Envios env join Proveedores prov on env.idParte=prov.idProveedores
where env.idParte in (@numabuscar) 
end
go
exec ejer17 2
go

--ejer 18 Nombre de los proveedores que suministran la parte 2 (utilizando IN).
alter proc  ejer18
@numabuscar int
as
begin
select distinct
env.idParte,
prov.Nombre
from Envios env join Proveedores prov on env.idParte=prov.idProveedores
where env.idParte not in ( @numabuscar )
end
go
exec ejer18 2
go

--19 Número de proveedores situados en la misma ciudad del proveedor 1 (utilizando IN).
alter proc ejer19
@ciudadabuscar varchar(20)
as
begin
select
prov.idProveedores,
prov.Nombre
from Proveedores prov 
where prov.Ciudad in (@ciudadabuscar)
end
go
exec ejer19 Londres
go

--20 . Número de partes que no tienen color (utilizando NULL).
create proc ejer2o
as
begin
select
p.Nombre,
p.Ciudad,
p.Color,
p.idParte,
p.Peso
from Partes p
where p.Color is null
end
go
exec ejer2o 
go


--21 Todos los datos de los proyectos que no tienen ciudad.
alter proc ejer21
as
begin
select
proy.Nombre,
proy.ciudad,
proy.idproyecto
from proyectos proy
where proy.ciudad is null
end
go
exec ejer21
go

--22 Todos los datos de los proyectos que si tienen ciudad. 
alter proc ejer22
as
begin
select
proy.Nombre,
proy.ciudad,
proy.idproyecto
from Proyectos proy 
where proy.ciudad is not null
end
go
exec ejer22 
go

--23 Números de los proveedores cuya situación sea menor que el valor máximo de situación en la tabla Proveedores.
alter proc ejer23
as
begin
select
p.idProveedores,
p.Nombre,
p.Situacion
from Proveedores p 
where p.Situacion < ( select max (situacion)from proveedores )
select * from Proveedores
end
go
exec ejer23 
go
--24 Obtener los números de las partes que pesen más de 16 y sean suministradas por el proveedor 2 o las dos cosas
alter proc ejer24
@valorpeso int,
@idprov int
as
begin
select
par.idParte,
prov.idProveedores
from Partes par , Proveedores prov
where par.peso>@valorpeso or prov.idProveedores=@idprov or (par.peso>@valorpeso and prov.idProveedores=@idprov)
end
go
exec ejer24 16 , 2
go

--25 Mostrar los datos de la parte más pesada
alter proc ejer25
as
begin
select top (1)
p.Ciudad,
p.Color,
p.idParte,
p.Nombre
from Partes p
order by max 
end
go
exec ejer25
go
--26 Mostrar los datos del envío con mayor cantidad
alter proc ejer26
as
begin
select top (2)
env.idParte,
env.idProveedores,
env.idProyecto
from Envios env
order by env.Cantidad desc
end
go
exec ejer26
go

--27. Cambiar a amarillo el color de la parte 2, el peso a 5 y la ciudad a desconocida (NULL)
alter proc ejer27
@color varchar(20),
@parte int,
@ciudad varchar(20),
@partemod int
as
begin
update Partes
set Color = @color, Peso =@parte , Ciudad= @ciudad
where idParte=@partemod
select * from partes where idParte =@partemod
end
go
exec ejer27 Amarillo , 5 , null , 2
go
--ALTER TABLE [partes] ALTER COLUMN [ciudad] varchar(20) NULL modifica la tabla
--28 Multiplique todos los valores de situación de los proveedores por 10. 
create proc ejer28
as
begin
update Proveedores
set Situacion = Situacion*10
select p.situacion from Proveedores p
end 
go
exec ejer28 
go
--29 Duplicar la situación de todos los proveedores situados en Londres. 
alter proc ejer29
as
begin
update proveedores
set situacion = situacion * 2
where proveedores.ciudad ='londres'
select*from proveedores
end
go
exec ejer29
go
--30  Poner en cero la cantidad enviada por todos los proveedores de Londres. 
alter proc ejer30
as
begin
update envios
set cantidad=0
where envios.idproveedores in ( select idProveedores from Proveedores where Ciudad = 'londres')
select*from envios
end
exec ejer30
go 
--31 Poner en la mitad las cantidades a los proyectos de Londres. 
create proc ejer31
as
begin
update envios
set cantidad = cantidad / 2
where envios.idproveedores in ( select idproveedores from proveedores where ciudad = 'londres')
select*from envios
end
exec ejer31
go
--32 Eliminar el proveedor 5.
alter proc ejer32
@provborrar int
as
begin
delete from envios
where idProveedores = @provborrar
delete from proveedores
where idProveedores = @provborrar
select * from proveedores
end
exec ejer32 5
go

--33 Eliminar los envíos cuya cantidad es mayor que 300.
create proc ejer33
@valorborrar int
as
begin
delete envios
where Cantidad>@valorborrar
select*from envios
end
exec ejer33 300

--34. Eliminar todos los envíos de los proveedores situados en Londres.
alter proc ejer34
as
begin
delete envios
where envios.idproveedores in ( select idProveedores from Proveedores where Ciudad = 'londres')
select*from envios
end
exec ejer34

--35. Agregar una nueva parte con: Ciudad=Atenas, Peso=24, Nombre y Color desconocidos.
create proc ejer35
as
begin
insert into Partes (Nombre,Color,Peso,Ciudad)values(null,null,24,'Atenas')
select * from partes
end
exec ejer35

/*ALTER TABLE [partes] ALTER COLUMN [Color] varchar(20) NULL
ALTER TABLE [partes] ALTER COLUMN [Nombre] varchar(20) NULL*/

--36. Agregar un nuevo proveedor con: Nombre=Ana, Situación=12 y Ciudad=NULL.
create proc ejer36
as
begin
insert into Proveedores(Nombre,Situacion,Ciudad)values('Ana',12,null)
select*from proveedores
end
exec ejer36

--37. Agregar un nuevo envío con: IDProveedor=101, IDParte=2, IDProyecto=5 y Cantidad=400.
alter proc ejer37
as
begin
insert into Proveedores(Nombre,Situacion,Ciudad)values('Ana',12,null)
insert into Envios(idProveedores,idParte,idProyecto,Cantidad)values(@@IDENTITY,2,5,400)
select * from envios
end
exec ejer37

--38. Agregar un nuevo proyecto con: IDProyecto=100, Nombre=Palmares, Ciudad=Rocha.
alter proc ejer38
as
begin
insert into Proyectos(Nombre,ciudad)values('palmares','rocha')
select*from proyectos
end
exec ejer38