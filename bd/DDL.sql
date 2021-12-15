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

ALTER TABLE Usuario
ADD NomeUsuario VARCHAR(100);
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
Marca VARCHAR (200) NOT NULL,
TipoEquipamento VARCHAR(200),
NumeroPatrimonio VARCHAR(200),
Quantidade VARCHAR(200),

);
go

CREATE TABLE Chamado (

IdChamado INT PRIMARY KEY IDENTITY,
IdUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Usuario(IdUsuario),
IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao),
Data DATETIME,
TipoProblema VARCHAR (200) NOT NULL,
TipoServico VARCHAR (200) NOT NULL,
Classe VARCHAR (200) NOT NULL,
Andar VARCHAR (200) NOT NULL,
Sala VARCHAR (200) NOT NULL,
Descricao VARCHAR(200),
Situacao VARCHAR (200) NOT NULL,
Prioridade VARCHAR (200) NOT NULL,

);
go