create database tarea;

use tarea;

CREATE TABLE Usuarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL, 
    Apellido NVARCHAR(100) NOT NULL, 
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    FechaRegistro DATETIME DEFAULT GETDATE(), 
    Estado BIT DEFAULT 1
);


CREATE TABLE mantenimiento (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(255)
);