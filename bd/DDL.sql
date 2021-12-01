CREATE DATABASE Chamados;
go
USE Chamados;

go
CREATE TABLE TipoUsuario (

IdTipoUsuario INT PRIMARY KEY IDENTITY,
NomeTipoUsuario   VARCHAR(200)

);
go

CREATE TABLE Usuario (

IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario),
IdUsuario UNIQUEIDENTIFIER PRIMARY KEY Default NEWID(), 
EmailUsuario VARCHAR(200) NOT NULL,
SenhaUsuario VARCHAR(200) NOT NULL	

);	
go
CREATE TABLE Instituicao (
IdInstituicao   INT PRIMARY KEY IDENTITY, 
NomeInstituicao	VARCHAR(200) NOT NULL,
CNPJ		VARCHAR(14) NOT NULL,
CEP			VARCHAR(8) NOT NULL,
Pais		VARCHAR(50) NOT NULL,
Estado		VARCHAR(50) NOT NULL,
Cidade		VARCHAR(50) NOT NULL,
Bairro		VARCHAR(50) NOT NULL,
Numero		VARCHAR(10) NOT NULL,
Endereco	VARCHAR(200) NOT NULL,
Telefone	VARCHAR(11)

);
go
CREATE TABLE Equipamento (

IdEquipamento   INT PRIMARY KEY IDENTITY,
IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao),
NomeEquipamento VARCHAR (200) NOT NULL,
Descricao VARCHAR(200),

);
go

CREATE TABLE Chamado (

IdChamado INT PRIMARY KEY IDENTITY,
IdUsuario UNIQUEIDENTIFIER,
IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao),
IdReceberChamado UNIQUEIDENTIFIER,
Localizacao VARCHAR (200) NOT NULL,
Motivo VARCHAR (200) NOT NULL,
Descricao VARCHAR(200),

);
go