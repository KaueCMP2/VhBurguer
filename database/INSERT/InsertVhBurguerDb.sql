Use VhBurguerDb
GO
INSERT INTO Usuario (Nome, Email, Senha)
	VALUES 
	('Carlos Lima', 'carlos@vhburguer.com', HASHBYTES('SHA2_256', 'admin@123'));
GO



INSERT INTO Categoria (Nome)
	VALUES
	('Vegetariano'),
	('Vegano'),
	('Especial');

GO


INSERT INTO Produto (Nome, Preco, Descricao, Imagem, UsuarioID)
VALUES
('VH Classic Burger', 29.90, 'Hamburguer artesanal com pão brioche, carne e queijo cheddar.', CONVERT(VARBINARY(MAX), 'imagem aleatoria'), 1),
('VH Bacon Supreme', 34.90, 'Hambúrguer bovino, bacon crocante, queijo e molho especial da casa.', CONVERT(VARBINARY(MAX), 'imagem aleatoria'), 1),
('Batata Rústica', 14.90, 'Batatas rústicas temperadas com ervas finas.', CONVERT(VARBINARY(MAX), 'imagem aleatoria'), 1);

GO

INSERT INTO ProdutoCategoria (ProdutoID, CategoriaID)
VALUES
(1, 3), 
(2, 3), 
(3, 1),
(3, 3),
(3, 2);

GO

INSERT INTO Promocao (Nome, DataExpiracao)
VALUES
('Promoção Semana do Hambúrguer', '2026-03-01 23:59:59'),
('Combo Happy Hour', '2026-02-20 23:59:59');
GO

INSERT INTO ProdutoPromocao (ProdutoID, PromocaoID, PrecoAtual)
VALUES
(1, 1, 24.90), -- VH Classic Burger
(2, 1, 29.90), -- VH Bacon Supreme
(3, 2, 9.90); -- Batata Rústica
GO
