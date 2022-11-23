insert into Categoria(Nome,Descricao,Imediato) values('Refrigerantes','Bebidas não alcoólicas gaseificadas',1);
insert into Categoria(Nome,Descricao,Imediato) values('Saladas','Verduras e leguminosas',0);
insert into Categoria(Nome,Descricao,Imediato) values('Carnes','Carne animal',0);

insert into Produto(Nome,Descricao,Categoria,Preco) values('Guaraná Antartica 350ml','Refrigerante de guaraná em latinha',1,6.99);
insert into Produto(Nome,Descricao,Categoria,Preco) values('Salada de legumes','Cenoura, batata inglesa, vagem, azeitona e temperos',2,6.99);
insert into Produto(Nome,Descricao,Categoria,Preco) values('Filé mignon','Bife de carne aproximadamente 250g',3,28.00);

insert into Menu(Nome) values('Menu Completo');

insert into MenuItem(MenuNome,ProdutoId) values('Menu Completo',1);
insert into MenuItem(MenuNome,ProdutoId) values('Menu Completo',2);
insert into MenuItem(MenuNome,ProdutoId) values('Menu Completo',3);