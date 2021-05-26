CREATE TABLE desenvolvedor(
	id INT IDENTITY(1,1) ,
	cd_cpf VARCHAR(11) NOT NULL,
	nm_cliente VARCHAR(50) NOT NULL,
	CONSTRAINT pk_cliente_id PRIMARY KEY (id)
	);

CREATE TABLE linguagem(
	id INT IDENTITY(1,1) ,
	linguagem VARCHAR(50) NOT NULL,
	CONSTRAINT pk_linguagem_id PRIMARY KEY (id)
	);
	   
CREATE TABLE dev_linguagem(
   	id INT IDENTITY(1,1),
   	id_dev INT FOREIGN KEY REFERENCES dev(id),   
   	id_lang INT FOREIGN KEY REFERENCES linguagem(id),
 	CONSTRAINT pk_dev_linguagem_id PRIMARY KEY (id)
);

-------------CARGA DE TABELA---------------

INSERT INTO cliente (cd_cpf, nm_cliente)
VALUES ('51266518037', 'Maria Josefina'),
('14224254018', 'Joao da Silva');

INSERT INTO produto (cd_ean, ds_produto)
VALUES ('7891058019099', 'NOVALGINA 500MG C/ 4 COMPRIMIDOS'),
('7891010668624', 'BAND AID FLEXIBLE'),
('7899547500349', 'DIPIRONA'),
('7891010986506', 'TYLENOL 750MG');