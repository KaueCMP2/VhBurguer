CREATE DATABASE VhBurguerDb
GO

USE VhBurguerDb
Go

CREATE TABLE Usuario
(
UsuarioId INT IDENTITY PRIMARY KEY,
Nome VARCHAR (60) NOT NULL,
Email VARCHAR (150) NOT NULL UNIQUE,
Senha VARBINARY (32) NOT NULL,
StatusUsuario BIT DEFAULT 1 NOT NULL
)
GO

CREATE TABLE Produto
(
ProdutoId INT IDENTITY PRIMARY KEY,
Nome NVARCHAR (100) NOT NULL UNIQUE,
Descricao NVARCHAR (MAX) NOT NULL,
Imagem VARBINARY (MAX) NOT NULL,
Preco DECIMAL,
StatusProduto BIT DEFAULT 1 NOT NULL,
UsuarioId INT NOT NULL,
CONSTRAINT FK_Produto_Usuario_UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuario (UsuarioId)
)
GO

CREATE TABLE Log_AlteracaoProduto
(
Log_AltercaoProdutoId INT IDENTITY PRIMARY KEY,
DataAlteracao DATETIME NOT NULL,
NomeAnterior VARCHAR (100) NOT NULL,
PrecoAnterior DECIMAL NOT NULL,
ProdutoId INT NOT NULL,
CONSTRAINT FK_Log_AlteracaoProduto FOREIGN KEY (ProdutoId) REFERENCES Produto (ProdutoId)
)
GO

CREATE TABLE Promocao
(
PromocaoId INT IDENTITY PRIMARY KEY,
Nome VARCHAR (100) NOT NULL UNIQUE,
DataExpiracao DATETIME,
StatusPromocao BIT DEFAULT 1
)
GO

CREATE TABLE ProdutoPromocao
(
ProdutoId INT NOT NULL,
PromocaoId INT NOT NULL,
CONSTRAINT PK_ProdutoPromocao_ProdutoId_PromocaoId PRIMARY KEY (ProdutoId, PromocaoId),
CONSTRAINT FK_ProdutoPromocao_ProdutoId FOREIGN KEY (ProdutoId) REFERENCES Produto (ProdutoId)
)
GO

CREATE TABLE Categoria
(
CategoriaId INT IDENTITY PRIMARY KEY,
Nome VARCHAR (50) NOT NULL
)
GO

CREATE TABLE ProdutoCategoria
(
ProdutoId INT NOT NULL,
CategoriaId INT NOT NULL,
CONSTRAINT PK_ProdutoCategoria_ProdutoId_CategoriaId PRIMARY KEY (ProdutoId, CategoriaId),
CONSTRAINT FK_ProdutoCategoria_Produto_ProdutoId FOREIGN KEY (ProdutoId) REFERENCES Produto (ProdutoId),
CONSTRAINT FK_ProdutoCategoria_Categoria_CategoriaId FOREIGN KEY (CategoriaId) REFERENCES Categoria (CategoriaId)
)
GO

