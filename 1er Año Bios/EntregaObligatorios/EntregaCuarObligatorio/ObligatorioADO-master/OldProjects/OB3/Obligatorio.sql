-- Obligatorio 3
use master;

-- Verificacion para eliminar base de datos vieja
if exists (select * from SysDataBases where name = 'COMIDA_RICA')
begin	
	drop database COMIDA_RICA
end
go

-- Creacion de nueva base de datos
CREATE DATABASE COMIDA_RICA
GO

USE COMIDA_RICA
go

-- Tabla "Empresa"
create table Empresa
(
	ruc bigint not null primary key,
	nombre varchar (50) not null,
	telefono bigint not null
)
go

-- Tabla "Producto"
create table Producto
(
	cod bigint not null primary key,
	nombre varchar(50) not null,
	fecha_vencimiento date not null,
	precio money not null
)
go

-- Tabla "Congelado"
create table Congelado
(
	cod bigint not null primary key foreign key references Producto(cod) ON DELETE CASCADE,
	peso decimal not null
)
go

-- Tabla "Enlatado"
create table Enlatado
(
	cod bigint not null primary key foreign key references Producto(cod) ON DELETE CASCADE,
	tipo bit
)
go

-- Tabla "Similar"
create table Similar
(
	cod bigint not null foreign key references Producto(cod) ON DELETE CASCADE,
	cod_similar bigint not null
)
go

-- Tabla "Cliente" 
create table Cliente
( 
	documento int primary key not null,
	nombre varchar(20) not null,
	apellido varchar (20) not null,
	calle varchar (50),
	numero_puerta int,
	telefono int not null	
)
go

-- Tabla "Venta"
create table Venta
(
	id_venta bigint primary key identity,
	fecha date,
	total_venta money not null,
	cantidad int not null 	
)
go

-- Tabla "Relación"
create table Relacion
(
	id bigint primary key identity,
	id_venta bigint foreign key references Venta(id_venta),
	documento int foreign key references Cliente(documento), 
	cod bigint foreign key references Producto(cod)
)
go

-- SP1: Productos por vencer
create PROC SP_ProductosPorVencer

AS
BEGIN

SELECT pro.nombre,pro.fecha_vencimiento FROM PRODUCTO pro
where pro.fecha_vencimiento <= GETDATE()+30

END
GO

-- Exec SP1
EXEC SP_ProductosPorVencer

-- SP2: Total recaudado por producto
create PROC SP_TotalRecaudadoPorProducto

@FECHAING1 DATETIME,
@FECHAING2 DATETIME,
@cod bigint

AS
BEGIN

SELECT pro.cod as 'Codigo producto',
	   SUM(ven.total_venta) as 'Total vendido' 
		
 FROM Producto pro
	JOIN Relacion r on r.cod = pro.cod
	JOIN Venta ven on ven.id_venta = r.id_venta

where r.cod = @cod and ven.fecha between @FECHAING1 and @FECHAING2
group by pro.cod

END
GO

-- Exec SP2
EXEC SP_TotalRecaudadoPorProducto  '2000-5-27' , '2020-5-27' , 1234123412341234

go

-- SP3: Producto mas vendido
create PROC SP_ProductoMasVendido

AS
BEGIN

select top 10 pro.cod,
	   pro.fecha_vencimiento,
	   pro.nombre,
	   pro.precio,
	   sum (ven.cantidad) as 'Cantidad vendida del producto' 

from Producto pro
	 left join Relacion r on r.cod = pro.cod
	 left join Venta ven on ven.id_venta = r.id_venta

group by pro.cod,pro.fecha_vencimiento,pro.nombre,pro.precio
order by sum (ven.cantidad) desc

END
GO

-- SP4: Agregar producto congelado
create proc SP_AgregarProductoCongelado

@cod bigint,
@nombre varchar (50),
@fecha_vencimiento datetime,
@precio money,
@peso decimal,
@cod_similar bigint

AS
BEGIN

DECLARE @validar varchar (16)

-- Validar si existe el codigo del producto
SET @validar = null 
SELECT @validar = cod from Producto
WHERE cod = @cod
IF @validar is not null return -1


BEGIN TRANSACTION
INSERT INTO Producto (cod,nombre,fecha_vencimiento,precio)
VALUES (@cod,@nombre,@fecha_vencimiento,@precio)

INSERT INTO Similar (cod,cod_similar)
VALUES (@cod,@cod_similar)


INSERT INTO Congelado (cod,peso)
VALUES (@cod,@peso)

IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
ELSE
	BEGIN
	COMMIT TRANSACTION
	RETURN 1
END
END

-- EXEC SP4
DECLARE @RETORNO INT
EXEC @RETORNO = SP_AgregarProductoCongelado 1234567890,'Prueba','2020-5-27',900,1000,1234
PRINT @retorno

-- SP5: Eliminar producto
create proc SP_EliminarProducto
--Datos para producto congelado
@cod bigint

AS
BEGIN

DECLARE @validar varchar (16)

-- Validacion si producto existe
SET @validar = null 
SELECT @validar = cod from Producto
WHERE cod = @cod
IF @validar is null return -1

-- Validacion si existe alguna venta
SET @validar = null 
SELECT @validar = cod from Relacion
WHERE cod = @cod
IF @validar is not null return 0

BEGIN TRANSACTION
DELETE Producto where cod = @cod

IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRANSACTION
		RETURN @@ERROR
	END
ELSE
	BEGIN
	COMMIT TRANSACTION
	RETURN 1
END
END

DECLARE @RETORNO INT
EXEC @RETORNO = SP_EliminarProducto 1234567890
PRINT @retorno

---- FIN SP--------------

-- DATOS DE PRUEBA

-- Producto
insert into Producto values (1234123412341234,'Alfajor','2016-10-23',30000)
insert into Producto values (4321,'Bondiola','2016-12-23',2000)
insert into Producto values (1234,'Chorizo','2016-12-23',1000)

-- Congelado
insert into Congelado values (1234123412341234,50)
insert into Congelado values (4321,10)

-- Enlatado
insert into Enlatado values (12341234,1)
insert into Enlatado values (432101,2)

-- Cliente
insert into Cliente values (48939397,'Rodrigo','Cardoso','José Enrique Rodo',1414,095987987)

-- Venta
insert into Venta values ('2016-10-23',5000,10)
insert into Venta values ('2016-11-03',5000,50)
insert into Venta values ('2015-11-24',8000,15)
insert into Venta values ('2015-11-22',8000,45)
insert into Venta values ('2015-12-12',1000,45)

-- Relacion
insert into Relacion values (1,48939397,1234123412341234)
insert into Relacion values (2,48939397,1234123412341234)
insert into Relacion values (3,48939397,4321)
insert into Relacion values (4,48939397,4321)
insert into Relacion values (5,48939397,1234)

-- Similar
insert into Similar values (1234123412341234,565456489454)
insert into Similar values (4321,1234)

-- Consultas basicas
select * from Producto;
select * from congelado;
select * from enlatado;
select * from cliente;
select * from Relacion;
select * from venta;
select * from Similar;
