--===============TABLA ESTUDIANTE=======================================================
create table estudiante(
	ID int identity not null primary key,
	Nombre varchar(60) not null,
	Apellido varchar(60) not null,
	Edad int not null,
	Correo varchar(60) not null,
	Telefono varchar(60) not null,
	Direccion varchar(100) not null
)
GO

--=============PROCEDIMIENTO ALMACENAO PARA MOSTRAR LOS ESTUDIANTES=====================

create proc MostrarEstudiante 
as
Select * from estudiante
GO

--=============PROCEDIMIENTO ALMACENADO PARA INSERTAR LOS ESTUDIANTES===================

create proc InsertarEstudiante
@NOMBRE VARCHAR(60),
@APELLIDO VARCHAR(60),
@EDAD INT,
@CORREO VARCHAR(60),
@NUMERO_TELEFONO VARCHAR(60),
@DIRECCION VARCHAR(100)
as
insert into estudiante values (@NOMBRE, @APELLIDO, @EDAD, @CORREO, @NUMERO_TELEFONO, @DIRECCION)
GO
--=============PROCEDMIENTO ALMACENADO PARA ELIMINAR LOS ESTUDIANTES====================

create proc EliminarEstudiante
@Id int
as
Delete from estudiante where @Id = ID
GO
--=============PROCEDIMIENTO ALMACENADO PARA ACTUALZAR LOS ESTUDIANTES==================

create proc ActualizarEstudiante
@id int,
@nombre varchar(60),
@apellido varchar(60),
@edad int,
@correo varchar(60),
@numero_telefono varchar(60),
@direccion varchar(100)
as
Update estudiante set
Nombre = @nombre,
Apellido = @apellido,
Edad = @edad,
Correo = @correo,
Telefono = @numero_telefono,
Direccion = @direccion
where ID = @id
GO
--=============PROCEDIMIENTO ALMACENADO PARA BUSCAR LOS ESTUDIANTES=====================

create proc BuscarEstudiante
@id int
as
select * from estudiante where ID = @id
go
--=============PROCEDIMIENTO ALMACENADO PARA TRUNCAR LOS ESTUDIANTES=====================
create proc TruncateTable
as
truncate table estudiante
go

--=============CREAR TABLA MAESTROS=====================
create table maestro(
	ID int not null identity primary key,
	Nombre varchar(60) not null,
	Apellido varchar(60),
	Edad int,
	Correo varchar(60) not null,
	Telefono varchar(60) not null,
	Direccion varchar(100) not null,
	Materia varchar(60) not null
)
Go

--=============PROCEDIMIENTO ALMACENADO PARA MOSTRAR LOS MAESTROS=====================
create proc MostrarMaestros
as
select * from maestro
GO
--=============PROCEDIMIENTO ALMACENADO PARA INSERTAR LOS MAESTROS=====================

create proc InsertarMaestros
@Nombre varchar(60),
@Apellido varchar(60),
@Edad int,
@Correo varchar(60),
@Telefono varchar(60),
@Direccion varchar(100),
@Materia varchar(60)
as
insert into maestro values (@Nombre,@Apellido,@Edad,@Correo,@Telefono,@Direccion,@Materia)
go
