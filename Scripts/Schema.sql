CREATE TABLE Videojuego
(
IdVideojuego INT IDENTITY(1,1) PRIMARY KEY,
Titulo VARCHAR(50),
Descripcion Varchar(100),
Año SMALLINT,
Calificacion SMALLINT,
Estatus BIT,
IdConsola SMALLINT,
IdGenero SMALLINT,

FOREIGN KEY (IdConsola) REFERENCES Consola(IdConsola),
FOREIGN KEY (IdGenero)  REFERENCES Genero(IdGenero)
);



CREATE TABLE Genero
(
IdGenero SMALLINT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50));

INSERT INTO Genero (Nombre) Values
('Deportes'),
('Accion'),
('Aventura');




CREATE TABLE Consola
(
IdConsola SMALLINT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50));


INSERT INTO Consola (Nombre) Values
('X box'),
('PC'),
('PlayStation');


