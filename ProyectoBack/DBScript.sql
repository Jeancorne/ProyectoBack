create database [DbPrueba]
GO
USE [DbPrueba]
GO
create table tblCasa(
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
nombre varchar(100) NULL,
fechaCreacion datetime NULL,
fechaModificacion datetime NULL,
)
GO
create table tblAspirante(
id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
nombre varchar(20) NOT NULL,
apellido varchar(20) NOT NULL,
identificacion varchar(10) NOT NULL,
edad varchar(2) NOT NULL,
idCasa int,
fechaCreacion datetime NOT NULL,
fechaModificacion datetime NULL,
)
GO
CREATE TABLE tblUsuario(
	id int primary key IDENTITY(1,1) NOT NULL,
	usuario varchar(100) NULL,
	password varchar(max) NULL,
	fechaCreacion datetime NULL,
	fechaModificacion datetime NULL
)
GO
ALTER TABLE tblAspirante
ADD CONSTRAINT fk_idCasa
FOREIGN KEY (idCasa) REFERENCES tblCasa(id);
GO
insert into tblCasa(nombre, fechaCreacion) values('Gryffindor', GETDATE())
GO
insert into tblCasa(nombre, fechaCreacion) values('Hufflepuff', GETDATE())
GO
insert into tblCasa(nombre, fechaCreacion) values('Ravenclaw', GETDATE())
GO
insert into tblCasa(nombre, fechaCreacion) values('Slytherin', GETDATE())
