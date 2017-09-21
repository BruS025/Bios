use Practico2Ejer1B
go

--2 Selecciones solo los Apellidos sin repeticiones de los empleados--distinct no va a repetir valores
select distinct

e.Apellido

from Empleados e
--4. Seleccione el IDCargo, la Denominación y el Sueldo incrementado en un 10% de todos los cargos
select 
c.IDCargo,
c.Denominacion,
c.Sueldo*10/100+c.Sueldo as'Sueldo Aumentado'
from Cargos c
--5. Seleccione todos los Empleados de Apellido ’Sosa’
select
e.Nombre,
e.Apellido
from Empleados e
where Apellido ='Sosa'
--7. Selección de dos tablas con los dos métodos: Muestre todos los datos de todos los Empleados y donde trabajan
select
e.Apellido,
e.CI,
e.Dirección,
e.IDEmp,
e.Licencia,
e.Nombre,
t.IDCargo
from Empleados e join Trabajan t on e.IDEmp = t.IDCargo
--8. Selección de tres tablas con los dosmétodos: Muestre todos los datos de todos los Empleados y donde trabajan incluyendo la descripción de la sección
select
e.Apellido,
e.CI,
e.Dirección,
e.IDEmp,
e.Licencia,
e.Nombre

from Empleados e
--10. Seleccione Nombre, Dirección, Cargo y Sueldo de todos los empleados con cargo asignado (es decir que tienen un cargo)
select
e.Nombre,
e.Dirección,
c.IDCargo,
c.Sueldo
from Empleados e join Cargos c 

where c.IDCargo != 'Sin'