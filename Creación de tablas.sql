-- Ingenieria de Software I
-- Laboratorio para ASP.NET MVC 
-- Isabel Chaves A 

use BD_B31880;

CREATE TABLE cliente(
cedula		VARCHAR(10)	PRIMARY KEY,
nombre		VARCHAR(30)	NOT NULL,
apellido1	VARCHAR(30),
apellido2	VARCHAR(30),
correo		VARCHAR(30),
direccion	VARCHAR(100)
);

CREATE TABLE telefono(
cedula		VARCHAR(10),
numero		VARCHAR(15),
CONSTRAINT PK_Telefono PRIMARY KEY(cedula, numero),
CONSTRAINT FK_Cliente FOREIGN KEY (cedula) REFERENCES cliente (cedula)
);

CREATE TABLE cuenta(
cedula		VARCHAR(10),
tipo		VARCHAR(20),
numero		VARCHAR(30),
CONSTRAINT PK_Cuenta PRIMARY KEY (cedula, numero),
CONSTRAINT FK_ClienteCuenta FOREIGN KEY (cedula) REFERENCES cliente (cedula)
);