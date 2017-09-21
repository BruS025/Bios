
----------------------------------------------------------------------------------
create database Academia

------------------------------------------------------------------------------------

use Academia

CREATE TABLE Alumnos(
	  Ci INT PRIMARY KEY  NOT NULL,
	  Nombre NVARCHAR(30) NOT NULL,
	  gen int not null, 
	  CalleDireccion NVARCHAR(30),
	  NroDireccion INT
	);
	go
CREATE TABLE  Materias(
	  IdMateria INT PRIMARY KEY  NOT NULL,
	  Nombre NVARCHAR(20) UNIQUE,--Los textos no son buenos como claves
	  CargaHoraria INT
	);
	go
	
CREATE TABLE  Curso(
	  Ci INT NOT NULL,
	  IdMateria INT NOT NULL,
	  Año INT NOT NULL,
	  PRIMARY KEY (Ci, IdMateria ),
	  FOREIGN KEY (Ci) REFERENCES Alumnos(Ci),
	  FOREIGN KEY (IdMateria) REFERENCES Materias(IdMateria)
	);
go

------------------------------------------------------------------------------------
insert into Alumnos values (111111,'Ana',2006,'Carrua',4444)
insert into Alumnos values (666666,'Luchi',2009,'Yi',2222)
insert into Alumnos values (333333,'Ceci',2005,'Yaro',2222)
insert into Alumnos values (555555,'Nacho',1998,'Rocha',1111)
insert into Alumnos values (444444,'Laura',1997,'Rocha',1111)
insert into Alumnos values (222222,'Ceci',2005,'Chuy',3333)
go

insert into Materias values (1,'BdeD',60)
insert into Materias values (2,'Redes',60)
insert into Materias values (3,'PrgIntro',120)
insert into Materias values (4,'PrgWeb',120)
go
	
insert into Curso values( 111111,1,1998)
insert into Curso values( 111111,2,1999)
insert into Curso values( 222222,1,1999)
insert into Curso values( 222222,2,2000)
insert into Curso values( 222222,4,2005)
insert into Curso values( 555555,1,2004)
insert into Curso values( 555555,2,2005)
insert into Curso values( 111111,4,2000)
insert into Curso values( 555555,4,2007)
go

------------------------------------------------------------------------------------
CREATE PROC Agregar  @IdMateria int, @Nombre NVARCHAR(20), @Año INT AS
begin
	If (exists(select * from materias where IdMAteria = @IdMateria))
		return -1;
	INSERT INTO materias VALUES (@Idmateria,@nombre,@Año);
		IF (@@ERROR<>0)
			RETURN -2;
		ELSE
			RETURN 1;	
end
go


Create Proc Salida @Id int, @Nom Nvarchar(20) output AS
Begin
		Select @nom = nombre
		From materias
		Where IdMateria = @id
end
go