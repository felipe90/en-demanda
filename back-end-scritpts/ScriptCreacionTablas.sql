--DROP DATABASE IF EXISTS Hackathon;
CREATE DATABASE Hackathon;

DROP TABLE IF EXISTS Municipio;
DROP TABLE IF EXISTS Persona;

CREATE TABLE Municipio(
    Mun_Num INT(3) NOT NULL,
    Mun_Nombre CHAR(15) NOT NULL,
    Mun_RU CHAR(6) NOT NULL,
    PRIMARY KEY (Mun_Num)
);

CREATE TABLE Persona(
    Per_Id INT(10) NOT NULL,
    Per_Gen CHAR(1) 'F'/'M' NOT NULL,
    Per_Edad INT(3) NOT NULL,
    Per_Grado INT(2) NOT NULL,
    Per_Situ CHAR(50) NOT NULL,
    Per_Etnia CHAR(50) NOT NULL,
    Per_Discapacidad CHAR(50) NOT NULL,
    Per_Calif INT(3) NOT NULL,
    
    Per_Cocina NUMBER(1) 0/1 NOT NULL,
    Per_Pintura NUMBER(1) 0/1 NOT NULL,
    Per_Aseo NUMBER(1) 0/1 NOT NULL,
    Per_Ropa NUMBER(1) 0/1 NOT NULL,
    Per_Jardineria NUMBER(1) 0/1 NOT NULL,
    
    FOREIGN KEY (Per_NumMun)
        REFERENCES Municipio (Mun_Num),
    PRIMARY KEY (Per_Id),
    Per_Correo VARCHAR(30) NOT NULL
);