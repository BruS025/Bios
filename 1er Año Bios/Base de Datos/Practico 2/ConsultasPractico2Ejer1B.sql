use Practico2Ejer1B
go

--2 Selecciones solo los Apellidos sin repeticiones de los empleados--distinct no va a repetir valores
select distinct

e.Apellido

from Empleados e
--4. Seleccione el IDCargo, la Denominaci�n y el Sueldo incrementado en un 10% de todos los cargos
select 
c.IDCargo,
c.Denominacion,
c.Sueldo*10/100+c.Sueldo as'Sueldo Aumentado'
from Cargos c
--5. Seleccione todos los Empleados de Apellido �Sosa�
select
e.Nombre,
e.Apellido
from Empleados e
where Apellido ='Sosa'
--7. Selecci�n de dos tablas con los dos m�todos: Muestre todos los datos de todos los Empleados y donde trabajan
select
e.Apellido,
e.CI,
e.Direcci�n,
e.IDEmp,
e.Licencia,
e.Nombre,
t.IDCargo
from Empleados e join Trabajan t on e.IDEmp = t.IDCargo
--8. Selecci�n de tres tablas con los dosm�todos: Muestre todos los datos de todos los Empleados y donde trabajan incluyendo la descripci�n de la secci�n
select
e.Apellido,
e.CI,
e.Direcci�n,
e.IDEmp,
e.Licencia,
e.Nombre

from Empleados e
--10. Seleccione Nombre, Direcci�n, Cargo y Sueldo de todos los empleados con cargo asignado (es decir que tienen un cargo)
select
e.Nombre,
e.Direcci�n,
c.IDCargo,
c.Sueldo
from Empleados e join Cargos c 

where c.IDCargo != 'Sin'