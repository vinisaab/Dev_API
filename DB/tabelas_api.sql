--CREATE DATABASE DevAPI;

use DevAPI;

CREATE TABLE desenvolvedor(
	id INT IDENTITY(1,1) ,
	cpf VARCHAR(11) NULL,
	nome VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	usuario_github VARCHAR(50) NULL,
	link_github VARCHAR(50) NULL,
	qtd_repo INT null,
	disponivel bit null
	CONSTRAINT pk_cliente_id PRIMARY KEY (id)
	);

CREATE TABLE linguagem(
	id INT IDENTITY(1,1) ,
	nome VARCHAR(50) NOT NULL,
	CONSTRAINT pk_linguagem_id PRIMARY KEY (id)
	);
	   
CREATE TABLE dev_linguagem(
   	id INT IDENTITY(1,1),
   	id_dev INT FOREIGN KEY REFERENCES desenvolvedor(id),   
   	id_lang INT FOREIGN KEY REFERENCES linguagem(id),
 	CONSTRAINT pk_dev_linguagem_id PRIMARY KEY (id)
);

-------------CARGA DE TABELA---------------

INSERT INTO desenvolvedor (cpf, nome, email)
VALUES ('133123123', 'Dev 01', 'Dev01@dev.com.br')

INSERT INTO linguagem (nome)
VALUES ('C#')

INSERT INTO linguagem (nome)
VALUES ('.Net Core')

INSERT INTO linguagem (nome)
VALUES ('Angular')

INSERT INTO linguagem (nome)
VALUES ('Python')

INSERT INTO linguagem (nome)
VALUES ('Python')