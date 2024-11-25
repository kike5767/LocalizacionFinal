CREATE DATABASE db_Localizacion;
GO

USE db_Localizacion;
GO

CREATE TABLE Personas
(
    [Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Cedula] NVARCHAR(20) NOT NULL,
    [Nombre] NVARCHAR(50) NOT NULL,
    [Edad] INT NOT NULL,
    [Activo] BIT NOT NULL
);
GO

INSERT INTO [Personas] ([Cedula],[Nombre],[Edad],[Activo])
VALUES ('1020333366','Samuel Garcia', 20, 1);

INSERT INTO [Personas] ([Cedula],[Nombre],[Edad],[Activo])
VALUES ('1044733299','Mateo Vallejo', 20, 1);
GO

CREATE TABLE Localidades
(
    [Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Pais] NVARCHAR(50) NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL,
    [CodigoPostal] NVARCHAR(50) NOT NULL,
    [Ciudad] NVARCHAR(50) NOT NULL,
    [Barrio] NVARCHAR(50) NOT NULL,
    [Calle] NVARCHAR(50) NOT NULL,
    [Activo] BIT NOT NULL
);
GO

INSERT INTO [Localidades] ([Pais],[Estado],[CodigoPostal],[Ciudad],[Barrio],[Calle],[Activo])
VALUES ('Colombia','Antioquia','05001','Medellin','Villa Hermosa','Cl. 54a #30-01,',1);

INSERT INTO [Localidades] ([Pais],[Estado],[CodigoPostal],[Ciudad],[Barrio],[Calle],[Activo])
VALUES ('Colombia','Antioquia','05002','Medellin','Robledo','Calle 73 No. 76A – 354',1);
GO

CREATE TABLE Ubicaciones
(
    [Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Latitud] DECIMAL(9, 6) NOT NULL,
    [Longitud] DECIMAL(9, 6) NOT NULL,
    [Activo] BIT NOT NULL
);
GO

INSERT INTO [Ubicaciones] ([Latitud],[Longitud],[Activo])
VALUES (6.244922, -75.550010, 1);

INSERT INTO [Ubicaciones] ([Latitud],[Longitud],[Activo])
VALUES (6.273538, -75.588527, 1);
GO

CREATE TABLE Imagenes
(
    [Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Url] NVARCHAR(2040) NOT NULL,
    [Activo] BIT NOT NULL
);
GO

INSERT INTO [Imagenes] ([Url],[Activo])
VALUES ('https://www.itm.edu.co//wp-content/uploads/noticias/fraternidad-2.jpg', 1);

INSERT INTO [Imagenes] ([Url],[Activo])
VALUES ('https://www.itm.edu.co//wp-content/uploads/campus/Robledo/fotos_campusRobledo00.jpg', 1);
GO

CREATE TABLE DetallesImagenes
(
    [Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Autor] NVARCHAR(50) NOT NULL,
    [Titulo] NVARCHAR(50) NOT NULL,
    [Fecha] DATE NOT NULL,
    [Detalles] NVARCHAR(2040) NULL,
    [Activo] BIT NOT NULL
);
GO

INSERT INTO [DetallesImagenes] ([Autor],[Titulo],[Fecha],[Detalles],[Activo])
VALUES ('ITM','SEDE FRATERNIDAD',GETDATE(),'Campus Universitario', 1);

INSERT INTO [DetallesImagenes] ([Autor],[Titulo],[Fecha],[Detalles],[Activo])
VALUES ('ITM', 'SEDE ROBLEDO',GETDATE(), 'Campus Universitario', 1);
GO

CREATE TABLE Localizaciones
(
    [Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [personas] INT NOT NULL REFERENCES [Personas]([Id]),
    [localidades] INT NOT NULL REFERENCES [Localidades]([Id]),
    [ubicaciones] INT NOT NULL REFERENCES [Ubicaciones]([Id]),
    [imagenes] INT NOT NULL REFERENCES [Imagenes]([Id]),
    [detalles] INT NOT NULL REFERENCES [DetallesImagenes]([Id]),
    [Hora] TIME NOT NULL,
    [Activo] BIT NOT NULL
);
GO

CREATE TABLE Auditorias
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Tabla] NVARCHAR(50),
	[Referencia] INT,
	[Accion] NVARCHAR(50)
);
GO

INSERT INTO [Localizaciones] ([personas],[localidades],[ubicaciones],[imagenes],[detalles],[Hora],[Activo])
VALUES (1,1,1,1,1,CAST(GETDATE() AS TIME),1);

INSERT INTO [Localizaciones] ([personas],[localidades],[ubicaciones],[imagenes],[detalles],[Hora],[Activo])
VALUES (2,2,2,2,2,CAST(GETDATE() AS TIME),1);
GO

SELECT *
FROM [Personas] P
    INNER JOIN [Localizaciones] L ON P.Id = L.personas;
GO
