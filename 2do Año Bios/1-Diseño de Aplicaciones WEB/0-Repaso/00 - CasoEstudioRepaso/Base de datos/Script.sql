--si la base de datos existe la borro------------------------------------------------------
use master
go

if exists(Select * FROM SysDataBases WHERE name='Banco')
BEGIN
	DROP DATABASE Banco
END
go


--creo la base de datos---------------------------------------------------------------------
CREATE DATABASE Banco
/*ON(
	NAME=Banco,
	FILENAME='C:\Banco.mdf'
)*/
go


--pone en uso la bd-------------------------------------------------------------------------
USE Banco
go


--creo las tablas --------------------------------------------------------------------------
Create Table Cliente
(
	CICli int Not Null Primary Key,
	NomCli varchar(30) Not Null,
	DirCli varchar(30),
	Estado bit Not null default 1
)
go

Create Table Cuenta
(
	NumCta int Not Null Primary Key Identity(1,1),
	CICli int Not Null Foreign Key References Cliente(CICli),
	SaldoCta money Not Null Default 0
)
go

Create Table CuentaCorriente
(
	NumCta int Not Null Primary Key Foreign Key References Cuenta(NumCta),
	MinimoCta money Not Null Default 0
)
go

Create Table CuentaCAhorro
(
	NumCta int Not Null Primary Key Foreign Key References Cuenta(NumCta),
	MovsCta int Not Null Default 0,  -- cantida de movimientos gratis
	CostoMovCta money Not Null Default 25
)
go

Create Table Movimientos
(
	IdMov int Not Null Primary Key Identity(1,1),
	FechaMov datetime Not Null Default GetDate(),
	MontoMov money Not Null,
	TipoMov varchar(1) Not Null,	--R es un retiro y D es un Deposito
	NumCta int Not Null Foreign Key References Cuenta(NumCta)	
)
go


---Doy de alta Datos de Prueba--------------------------------------------------------------
Insert Cliente Values (1,'Primer Cliente','Primer Direccion',1)
Insert Cliente Values (2,'Segundo Cliente','Segunda Direccion',1)
Insert Cliente Values (3,'Tercer Cliente','Tercera Direccion',0)
Insert Cliente Values (4,'Cuarto Cliente','Cuarta Direccion',1)
go

Insert Cuenta(CICli,SaldoCta) Values (1,1000)
Insert Cuenta(CICli,SaldoCta) Values (2,2000)
Insert Cuenta(CICli,SaldoCta) Values (3,3000)
go

Insert CuentaCorriente(NumCta) Values (1)
insert CuentaCorriente(NumCta,MinimoCta) Values (2,500)
go

Insert CuentaCAhorro(NumCta,MovsCta,CostoMovCta) Values (3,5,100)
go


--SP basicos para manejo del ejemplo------------------------------------------------------
--SP CLIENTES-----------------------------------------------------------------------------
Create Procedure ClienteAlta @CICLI int, @NomCli varchar(30), @DirCli varchar(30) As
Begin
		if (Exists(Select * From Cliente Where CICli = @CICli and Estado = 0))
			Begin
				update Cliente set Estado = 1 Where CICli = @CICli 
			End		
		Else if (Exists(Select * From Cliente Where CICli = @CICli))
			Begin
				return -1
			end
		Else
			Begin
				Insert Cliente Values (@CICLI, @NomCli, @DirCli,1)
			End
End
go

Create Procedure ClienteBaja @CICli int As
Begin
		if (Not Exists(Select * From Cliente Where CICli = @CICli))
			Begin
				return -1
			end

		if (Exists(Select * From Cuenta Where CICli = @CICli))
			Begin
				update Cliente set Estado = 0 where CICli = @CICli
				return -2
			end
		Else
			Begin
				Delete From Cliente where CICli = @CICli
				If (@@ERROR = 0)
					return 1
				Else
					return -3
			End
End
go

Create Procedure ClienteModificar @CICli int, @NomCli varchar(30), @DirCli varchar(30) As
Begin
		if (Not Exists(Select * From Cliente Where CICli = @CICli))
			Begin
				return -1
			end
		Else
			Begin
				Update Cliente Set NomCli=@NomCli, DirCli=@DirCli Where CICli = @CICli and Estado = 1
				If (@@ERROR = 0)
					return 1
				Else
					return -2
			End
End
go

Create Procedure ClienteListado As 
Begin
	Select CICli, NomCli, DirCli From Cliente Where Estado = 1
End
go

Create Procedure ClienteBuscar @CICli  int As
Begin
	Select CICli, NomCli, DirCli From Cliente where CICli  = @CICli 
End
go

--SP CUENTA CORRIENTE---------------------------------------------------------------------
Create Procedure CuentaCorrienteAlta @CICli int, @MinimoCta money As
Begin
		Begin Transaction
	
		Insert Cuenta (CICli ) Values (@CICli )
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -1
		End

		Insert CuentaCorriente (NumCta, MinimoCta) Values(IDENT_CURRENT('Cuenta'), @MinimoCta)
		if (@@ERROR<>0)
		Begin
			RollBack Transaction
			return -2
		End

		Commit Transaction
		return 1
End
go

Create Procedure CuentaCorrienteBaja @NumCta int As
Begin
		---Existe dependencia pongo default 0 baja logica
		if (Exists(Select * From Movimientos Where NumCta = @NumCta))
		begin
				Begin Transaction

				UPDATE Cliente 
				set Estado = 0 
				where Cliente.CICli =(select m.NumCta from Movimientos m where m.NumCta = @NumCta)
				 
			if (@@ERROR <> 0)
			Begin
				RollBack Transaction
				return -4
			End
		end
		--NO existe dependencia baja fisica
		if (not Exists(Select * From Movimientos Where NumCta = @NumCta))

		Delete From CuentaCorriente Where NumCta =(SELECT C.NumCta FROM Cuenta C join Cliente Cli on C.CICli = Cli.CICli
													WHERE Cli.Estado = 0 and C.NumCta = @NumCta)
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -2
		End

		Delete From Cuenta Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End

		Commit Transaction
		return 1

End
go

Create Procedure CuentaCorrienteListado As
Begin
	Select * From Cuenta Cta Inner Join CuentaCorriente CC on Cta.NumCta = CC.NumCta 
End
go

Create Procedure CuentaCorrienteBuscar @NumCta int As
Begin
	Select * 
	From Cuenta Cta Inner Join CuentaCorriente CC on Cta.NumCta = CC.NumCta 
	Where cc.NumCta = @NumCta
End
go

--SP CUENTA AHORRO-----------------------------------------------------------------------
Create Procedure CuentaCAhorroAlta @CICli  int, @MovsCta int, @CostoMovCta money As
Begin
		Begin Transaction
	
		Insert Cuenta (CICli ) Values (@CICli )
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -1
		End

		Insert CuentaCAhorro(NumCta, MovsCta, CostoMovCta) Values(IDENT_CURRENT('Cuenta'), @MovsCta, @CostoMovCta)
		if (@@ERROR<>0)
		Begin
			RollBack Transaction
			return -2
		End

		Commit Transaction
		return 1
End
go

Create Procedure CuentaCAhorroBaja @NumCta int As
Begin
		if (Exists(Select * From Movimientos Where NumCta = @NumCta))
				return -1

		Begin Transaction

		Delete From CuentaCAhorro Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -2
		End

		Delete From Cuenta Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End

		Commit Transaction
		return 1

End
go

Create Procedure CuentaCAhorroListado As
Begin
	Select * From Cuenta Cta Inner Join CuentaCAhorro CCA on Cta.NumCta = CCA.NumCta 
End
go

Create Procedure CuentaCAhorroBuscar @NumCta int As
Begin
	Select * 
	From Cuenta Cta Inner Join CuentaCAhorro CC on Cta.NumCta = CC.NumCta 
	Where cc.NumCta = @NumCta
End
go


Create Procedure MovimientosAlta @NumCta int, @MontoMov money, @TipoMov varchar(1), @SaldoCta money As
Begin
		--Verifico existencia de datos
		if (Not Exists(Select * From Cuenta where NumCta = @NumCta))
			return -1
		
		--Doy de alta el movimiento y actualizo saldos
		Begin Transaction
		
		Insert Movimientos (MontoMov, TipoMov, NumCta) Values (@MontoMov, @TipoMov, @NumCta)
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -2
		End																									

		Update Cuenta Set SaldoCta = @SaldoCta Where NumCta = @NumCta		
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End	
		
		Commit Transaction
		return 1
		
End
go