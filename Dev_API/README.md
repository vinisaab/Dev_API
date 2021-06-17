# Projeto API - Treinamento FMX

Projeto final entregue após o treinamento de 'Criação de API´s .Net Core com DDD'

Cadastro de Desenvolvedore e linguagens, utilizando a api externa do Github e disponibilizando endpoints para cadastro/consulta.

## Visão Geral
### Tabelas
**Desenvolvedor**
* ID
* Nome
* CPF
* EMAIL		 
* Usuário do GitHub -> API
* link do perfil do github <- API
* Quantidade de Repositórios <- API
* Disponivel para contratação <- API
		
**Linguagens/Framework**
* ID
* Nome da Linguagem/Framework
		
**Relacionamento Dev/Linguagem (1 - N)**
* ID_DEV
* ID_LINGUAGEM
		
### EndPoints
	* Cadastrar Linguagens/Framework
	* Cadastrar Dev
	
	* Consultar Linguagens/Framework por id
	* Consultar Linguagens/Framework por descrição
	
	* Consultar Dev por id
	* Consultar Dev por cpf
	* Consultar Dev por usuário do github
	* Consultar Devs por linguagem
	
	* Consulta Ranking por linguagem
	
