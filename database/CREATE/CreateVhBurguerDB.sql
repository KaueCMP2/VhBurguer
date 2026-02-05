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
	PrecoAtual DECIMAL,
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

-- TRIGGERS
-- INATIVAR O USUARIO MUDANDO DE 1 PARA 0 AO DELETAR
CREATE TRIGGER trg_Usuario_StatusUsuario
ON Usuario
INSTEAD OF DELETE 
AS 
BEGIN
	UPDATE Usuario 
	SET StatusUsuario = 0
	FROM Usuario u
	JOIN deleted d ON u.UsuarioId = d.UsuarioId;
END
GO

-- AO ALTERAR OS DADOS DO PRODUTO NA TABELA OS DADOS ANTIGOS SERAO ENVIADOS PARA A TABELA LOG
CREATE TRIGGER trg_AlteracaoProduto
ON Produto 
AFTER UPDATE 
AS 
BEGIN
	INSERT INTO Log_AlteracaoProduto(DataAlteracao, ProdutoId, NomeAnterior, PrecoAnterior)	
	SELECT GETDATE(), ProdutoId, Nome, Preco FROM deleted
END
GO

-- INATIVAR O PRODUTO MUDANDO DE 1 PARA 0 AO DELETAR
CREATE TRIGGER trg_Produto_StatusProduto
ON Produto
INSTEAD OF DELETE 
AS 
BEGIN
	UPDATE Produto
	SET StatusProduto = 0
	FROM Produto p
	JOIN deleted d ON p.ProdutoId= d.ProdutoId;
END
GO