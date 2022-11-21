USE master
GO

CREATE DATABASE ContactosDB
GO

USE ContactosDB
GO

CREATE TABLE Contactos(Id Int Primary Key Identity (1,1), Nombre Varchar(50) Not Null, Apellido Varchar(50) Not Null, Celular Varchar(50) Not Null, Dirección Varchar(MAX))
GO