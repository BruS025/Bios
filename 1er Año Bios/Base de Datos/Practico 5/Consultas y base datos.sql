--creo la base de datos-----------------------------------------------------------------------------------
create database Practico5

-- pongo en uso la tabla para trabajar con ella
USE Practico5
go


--creo las tablas------------------------------------------------------------------------------------------
Create Table Cargo
(
	idCargo varchar(3)  collate Modern_Spanish_CI_AS not null primary key,
	denominacion varchar(30) collate Modern_Spanish_CI_AS not null,
	sueldo money not null
)
go

Create Table Seccion
(
	idSeccion varchar(3) not null primary key,
	descripcion varchar(30) not null
)
go

Create Table Empleado
(
	idEmp int not null primary key identity(1,1),
	ci float not null,
	nombre varchar(30) not null,
	apellido varchar(30) not null,               
	direccion varchar (50),
	licencia bit
)
go
	
create Table Trabajan
(
	idEmp int not null unique foreign key references Empleado(idEmp),
	idCargo varchar(3) not null foreign key references Cargo(idCargo),
	idSeccion varchar(3) not null foreign key references Seccion(idSeccion),
	fechaIng smalldatetime
)
go


--cargo datos de prueba-----------------------------------------------------------------------------------------
insert cargo (idCargo, denominacion, sueldo) Values ('Adm', 'Administrador', 5000)
insert cargo (idCargo, denominacion, sueldo) Values ('Aux', 'Auxiliar', 4000)
insert cargo (idCargo, denominacion, sueldo) Values ('Enc', 'Encargada', 7000)
insert cargo (idCargo, denominacion, sueldo) Values ('Ger', 'Gerente', 12000)
insert cargo (idCargo, denominacion, sueldo) Values ('Mof', 'Medio Oficial', 5000)
insert cargo (idCargo, denominacion, sueldo) Values ('Of1', 'Oficial de Primera', 6000)
insert cargo (idCargo, denominacion, sueldo) Values ('Sin', 'Sin Denominacion', 1001)
go

insert seccion (idSeccion, descripcion) Values ('Cre', 'Credito')
insert seccion (idSeccion, descripcion) Values ('Ger', 'Gerencia')
insert seccion (idSeccion, descripcion) Values ('Man', 'Mantenimiento')
insert seccion (idSeccion, descripcion) Values ('Sec', 'Secretaria')
insert seccion (idSeccion, descripcion) Values ('Ven', 'Ventas')
go

insert empleado (ci, nombre, apellido, direccion, licencia) Values (11111111, 'Ana', 'Sosa', 'Yi 1111', 1)
insert empleado (ci, nombre, apellido, direccion, licencia) Values (22222222, 'Eva', 'Rocha', 'Yi 2222', 0)
insert empleado (ci, nombre, apellido, direccion, licencia) Values (33333333, 'Gustavo', 'Ramirez', 'Rio Branco 3321', 1)
insert empleado (ci, nombre, apellido, licencia) Values (44444444, 'Marta', 'Rocha', 0)
insert empleado (ci, nombre, apellido, direccion, licencia) Values (55555555, 'Miriam', 'Sosa', '18 de Julio 1201', 1)
insert empleado (ci, nombre, apellido, direccion, licencia) Values (66666666, 'Mario', 'Rodriguez', 'Andes 1209', 0)
go

insert trabajan (idEmp, idCargo, idSeccion, fechaIng) Values (1, 'Ger', 'Ger', '20110105')
insert trabajan (idEmp, idCargo, idSeccion, fechaIng) Values (2, 'Aux', 'Ven', '20110106')
insert trabajan (idEmp, idCargo, idSeccion, fechaIng) Values (3, 'Aux', 'Cre', '20120109')
insert trabajan (idEmp, idCargo, idSeccion, fechaIng) Values (4, 'Of1', 'Man', '20120106')
insert trabajan (idEmp, idCargo, idSeccion, fechaIng) Values (5, 'Aux', 'Ven', '20120125')
go

--1 Crear un SP que dado la Ci devuelva el IDEmp, nombre, apellido y dirección del empleado, en variables de salida.
create proc ejer1
	@ci int,
	@idemp int output,
	@nombre varchar(10) output,
	@apellido varchar(10) output,
	@direccion varchar(10) output
as
begin
select
	@idemp=e.idEmp,
	@nombre=e.nombre,
	@apellido=e.apellido,
	@direccion=e.direccion
from
	Empleado e
where
	e.ci=@ci
end
go
declare @idemp int
declare @nombre varchar(10)
declare @apellido varchar(10)
declare @direccion varchar(10) 
exec ejer1 11111111,@idemp output,@nombre output,@apellido output,@direccion output

print 'IdEmp: '+cast (@idemp as varchar (50)) + ' Nombre: ' + @nombre + ' Apellido: ' + @apellido + ' Direccion: ' + @direccion


--2 Crear un SP que dado la Ci devuelva la fecha de ingreso del empleado en una variable de salida.
create proc ejer2
	@cedula int,
	@fechaingreso datetime output
as
begin
select 
	@fechaingreso=tra.fechaIng
from
	 Empleado emp join Trabajan tra on emp.idEmp=tra.idEmp
where 
	@cedula=emp.ci
end
go
declare @fechaingreso datetime
exec ejer2 22222222,@fechaingreso output

print 'Fecha ingreso'+cast(@fechaingreso as varchar(50))

--3 Crear una consulta que retorne la cantidad de empleados que trabajan en una sección dada por su IDSECCION.
create proc ejer3
	@idseccion varchar(3),
	@salida int output
as
begin
select 
	@salida=COUNT(tra.idSeccion)
from 
	Trabajan tra
where 
	idSeccion=@idseccion
end
go
declare @salida int
exec ejer3 'ger',@salida output
print 'Cantidad de empleados: '+cast (@salida as varchar (50))
go

--4 Crear un procedimiento que permita agregar una nueva Sección, usar parámetros.
create proc ejer4 
	@idseccioninsert varchar (3),
	@descripcioninsert varchar(30)
as
begin
insert seccion (idSeccion, descripcion) Values (@idseccioninsert,@descripcioninsert)
end
go 
exec ejer4 que ,teimporta

--5 A) Modificar el procedimiento anterior para que en el caso de un error (@@ERROR<>0) retorne -1 sino 1.
create proc ejer5 
	@idseccioninsert varchar (3),
	@descripcioninsert varchar(30)
as
begin
	insert seccion (idSeccion, descripcion) Values (@idseccioninsert,@descripcioninsert)
if @@ERROR <>0
	begin 
		return -1
	end
else
	begin
		return 1
	end
end
declare @retorno int
exec @retorno= ejer5 'que' ,'teimporta'
print @retorno

--5B) Modificar el procedimiento anterior para que en el caso de un error (@@ERROR<>0) retorne el número de error con valor negativo sino 1.
create proc ejer5b 
	@idseccioninsert varchar (3),
	@descripcioninsert varchar(30)
as
begin
declare
	@numError int
	insert seccion (idSeccion, descripcion) Values (@idseccioninsert,@descripcioninsert)
set 
	@numError=@@ERROR

if @numError <>0
	begin 
		return -@numError
	end
else
	begin
		return 1
	end
end
declare @retorno int
exec @retorno= ejer5b 'que' ,'teimporta'
print @retorno

--6) A) Crear un procedimiento que dado una CI retorne: 0 si no está el empleado y 1 en caso contrario, usar If Exists.

create proc ejer6a
	@ciingresar int
as
begin
if exists (select emp.ci from Empleado emp where @ciingresar = emp.ci)
	begin
		return 1
	end
else 
	begin
		return 0
	end
end
go
declare @retorno int
exec @retorno= ejer6a 11111111
print @retorno

--6) B) Modificar el procedimiento anterior que haga lo mismo pero usando variables locales e IS NULL.
create proc ejer6b
	@cedula int
as
begin
declare
	 @count int
select
	 @count = count (idEmp)
from 
	Empleado emp
where
	emp.ci=@cedula
if (@count is not null)
	begin
		return 1
	end
else
	begin
		return @count
	end
end

declare @retorno int
exec @retorno= ejer6b 11111113
print @retorno

--7) En una variable retornar la cantidad de empleados que ingresaron entre 2 fechas dadas (CantIngresos, FechaIni,FechaFin).
create proc ejer7
	@fechaing date,
	@fechafin date,
	@cantingresos int output
as
begin
select
 @cantingresos=count(tra.fechaIng)
from
	Trabajan tra
where
	tra.fechaIng between @fechaing and @fechafin
end
declare @caningresos int
exec ejer7 '20110105' ,'20120105', @caningresos output
print 'cantidad de empleados ' + cast (@caningresos as varchar (30))
go

--8) Eliminar de la tabla trabajan todos los empleados con IDCargo es GER y retornar la cantidad de filas afectadas,usar @@ROWCOUNT.
alter proc ejer8 
	@cargoEliminar varchar(10),
	@cantFilas int output
as
begin

delete Trabajan

where 
	idCargo=@cargoEliminar

set
	@cantFilas =@@rowcount
end

declare @cantFilas int
exec ejer8 'ger',@cantFilas output
print  'Filas afectadas '+cast(@cantFilas as varchar(30))


--9) Modificar todos los empleados con IDCargo AUX para que diga ADM y retornar la cantidad de filas afectadas,usar @@ROWCOUNT.
alter proc ejer9
	@cargoPrevio varchar(3),
	@cargoModificar varchar(3),
	@cantFilas int output
as
begin
update Trabajan

set idCargo=@cargoModificar

where idCargo=@cargoPrevio

set	@cantFilas =@@rowcount
end

declare @cantFilas int
exec ejer9 'aux' , 'adm' , @cantFilas output
print 'Filas afectadas '+cast(@cantFilas as varchar(30))
go

--10) Crear un procedimiento que agrega Empleados dado todos sus datos personales y RETORNE -1 si la Ci está repetida o el último IDEmpleado que es generado automáticamente, usar @@IDENTITY.
/*create proc ejer10 
	@ciIngresar int,
	@NombreIngresar varchar(10),
	@apellidoIngresar varchar(10),
	@direccionIngresar varchar(10),
	@licenciaIngresar bit,
	@NoEstaNum int output,
	@noEstaIdentity int output
as
begin
set 
if exists(select emp.ci from Empleado emp where emp.ci=@ciIngresar)
	begin
		
	end
else
	begin
		insert empleado (ci, nombre, apellido, direccion, licencia) Values (@ciIngresar,@NombreIngresar,@apellidoIngresar,@direccionIngresar,@licenciaIngresar)
	end
end*/
--como nueva forma de trabajo
/*create proc ejer10Clase
	@CI int,
	@Nombre varchar(20),
	@Apellido varchar(20),
	@Direccion varchar(20)
as
begin

	insert into Empleado(ci,nombre,apellido,direccion,licencia) values (@CI,@Nombre,@Apellido,@Direccion,0)

	if (@@Error=0)
		begin
			return @@Identity
		end
	else 
		begin
			return -1
		end
end
go
declare @retorno int
exec @retorno =ejer10Clase 7777777,'Laura','Rocha','yi 7777'
print 'Insertado el empleado con id: '
print @retorno*/
--11)Crear un procedimiento que retorne el próximo IDEmpleado de la Tabla Empleados, usar IDENT_CURRENT(‘TABLA’).
create proc ejer11Clase
as
begin 
	return ident_current('Empleados')+1--Esto solo funciona cuando en la tabla el atributo tiene @@identity
end
go
declare @retorno int
exec @retorno=ejer11Clase
print 'Siguiente IdEmpleados: '
print @retorno
go

--12) Mostrar todos los datos personales de los empleados que ingresaron hace menos de una cantidad de años ingresada como parámetro, usar GETDATE y DATEDIFF.
create proc ejer12Clase
	@anios int
as
begin

	select *
	from Empleado as e inner join Trabajan as t on e.idEmp = t.idEmp
	where @anios>DATEDIFF(yy,getdate(),t.fechaIng)
end
go
exec ejer12Clase 12
go

--13) Borrar de la tabla Trabajan y de la tabla Empleados el empleado que tiene una ci dada, en caso que lo pueda borrar retorna 1, si no está la ci 0 y cuando se provoque algún error -@@ERROR.

create proc ejer13Clase
	@CI int
as
begin
	declare @iDEmp int
	declare @ControlError int

	select @iDEmp=idEmp from Empleado where ci=@CI

	if @iDEmp is null
		return (0)
	else 
	begin
		begin transaction --Hace todo el procedimiento y si todo funciona lo guarda sino no guarda nada

		delete Trabajan
		where idEmp=@iDEmp
		set @ControlError=@@ERROR;

		if @ControlError<>0
		begin
			rollback tran --esta mal vuelve la transaccion para atras
			return (-@controlError)
		end

		delete Empleado
		where idEmp=@iDEmp
		set @ControlError=@@ERROR;

		if @ControlError <> 0
			begin
				rollback tran
				return (-@controlError)
			end

		else
			begin
				commit tran --Si toda la transaccion esta bien el commit la guarda
				return(1)
			end
	end
end
go


--14) Dado todos los datos de una Seccion, un IDCargo y una Ci dar de alta la Seccion y modificar Trabajan para que el
--empleados con esa Ci trabaje en la sección con el cargo dado, la fecha de ingreso es hoy y sin licencia (licencia= 0).
--Retornar:
--1 si el IDSección está repetido
--2 si no está el IDCargo
--3 si no está la CI
--@@Error si se provocó algún tipo de error
--1 si se realizo los cambió correctamente

create proc ejer14 
	@IdSeccionNueva varchar (3),
	@IdCargoNuevo varchar (3),
	@DescripcionNueva varchar(30),
	@CiEmpleadoABuscar int
as
begin
	declare @ControlError int

if exists (select idSeccion from Seccion where idSeccion=@IdSeccionNueva)
	Begin
		return 1
	end
if not exists (select c.idCargo from Cargo c where c.idCargo=@IdCargoNuevo)
	begin
		return 2
	end
if exists (select ci from Empleado where ci=@CiEmpleadoABuscar)
	begin
		return 3
	end
end




create proc ejer18Clase
	@CI int,
	@CausaDespido nvarchar(max)
as
begin
	declare @ControlError int
	declare @BorroEmpleado int
	declare @IDEmp int
	declare @Nombre varchar(20), @Apellido varchar(20), @Direccion varchar(20);

	--1 Obtiene los datos del empleado

	exec ejer1 11111111 , @IDEmp output , @Nombre output , @Apellido output , @Direccion output

	--Si no esta

	if (@IDEmp is null)
		return (0);

	--Trnsaccion
	begin tran

	--borra el empleado

	exec @BorroEmpleado = ejer13Clase @CI;
	if(@BorroEmpleado<1)
	begin
		rollback tran;
		return (@BorroEmpleado);
	end

	--Agrego
