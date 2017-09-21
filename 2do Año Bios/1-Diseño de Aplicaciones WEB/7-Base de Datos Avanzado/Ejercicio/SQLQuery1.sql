Use master
GO

CREATE DATABASE CorreoInterno
GO

CREATE TABLE Usuarios
(
	NombreDeUsuario VARCHAR (20) NOT NULL PRIMARY KEY,
	Contrasenia VARCHAR(10) NOT NULL,
	NombreCompleto VARCHAR(30) NOT NULL
)
GO

CREATE TABLE Docentes
(
	Cedula INT NOT NULL PRIMARY KEY,
	Contrasenia VARCHAR(10),
	Fotografia VARCHAR (MAX)
)
GO

CREATE TABLE AlmacenMail 
(
	IdentificadorDeMail INT NOT NULL PRIMARY KEY,
	NombreUsuarioEnvia VARCHAR(20) NOT NULL,
	NombreUsuarioRecive VARCHAR(20) NOT NULL,
	Asunto VARCHAR (20) NOT NULL,
	Mail VARCHAR (MAX) NOT NULL
)
GO

CREATE PROCEDURE AltaDocente
@Cedula INT,
@Contrasenia VARCHAR(10),
@Foto VARCHAR(MAX)
AS
BEGIN
	IF NOT EXISTS (SELECT D.Cedula FROM Docentes D WHERE D.Cedula = @Cedula)
	begin transaction
		INSERT INTO Docentes(Cedula,Contrasenia,Fotografia) VALUES (@Cedula,@Contrasenia,@Foto)
		if (@@ERROR <> 0)
			begin
				rollback tran
				return -2
			end
	
		--usuario de logueo comun
		declare @VarSentencia varchar(200)
		set @VarSentencia = 'Create Login ['+@Cedula+'] with Password = '+ quotename(@Contrasenia,'''')
		exec (@VarSentencia)
		if (@@Error <> 0)
			begin
				rollback tran
				return -1
			end

		declare @VarSentencia2 varchar(200)
		set @VarSentencia2 = 'Create User ['+@Cedula+'] from login['+@Cedula+']'
		exec(@VarSentencia2)
		if(@@Error <>0)
		begin
				rollback tran
				return -3
			end

	commit transaction

--segundo asigno rol especifico al usuario recien creado
exec sp_addrolemember @rolename='db_OWNER',@membername=@Cedula

	if(@@Error=0)
		return 1
	else 
		return -2
end
go
 