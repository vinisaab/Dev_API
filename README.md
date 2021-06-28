
# Projeto API - Treinamento FMX

Projeto final entregue após o treinamento de 'Criação de API´s .Net Core com DDD'

Cadastro de Desenvolvedores e linguagens, utilizando a api externa do Github e disponibilizando endpoints para cadastro/consulta.



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
* ID
* ID_DEV
* ID_LINGUAGEM
		

### Autenticação 
	```json
	{
	  "codigoUsuario": 0,
	  "loginDoUsuario": "string",
	  "senhaDoUsuario": "string",
	  "emailDoUsuario": "string"
	}
	```

### EndPoints
	* Cadastrar Linguagens/Framework
	* Cadastrar Dev
	* Cadastrar Relacionamento entre Dev e Linguagem
	
	* Consultar Linguagens/Framework por id
	* Consultar Dev por Id
	* Consultar Devs por Linguagem
	* Consultar Linguagens por Dev
	* Consulta GitHub pelo usuário

