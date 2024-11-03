# Projeto Backend - Sistema de Controle de Carros e Marcas

Este é o backend do sistema de controle de carros e marcas, desenvolvido com .NET 8 e Entity Framework. O projeto foi criado para gerenciar as informações sobre carros e marcas, utilizando ASP.NET Identity para autenticação e autorização.

## Tecnologias Utilizadas

- .NET 8
- Entity Framework
- ASP.NET Identity
- LocalDB SQL Server
- Mediator

## Arquitetura e conceitos utilizados

- CQRS
- DDD
- Seguindo conceitos do SOLID

## Pré-requisitos

Antes de iniciar o projeto, você precisa ter o .NET SDK e o SQL Server LocalDB instalados em sua máquina. Se você ainda não os possui, siga as instruções abaixo.

### Instalando o .NET 8 SDK

1. Acesse a página de download do .NET 8: [Download .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0).
2. Baixe e instale a versão recomendada para o seu sistema operacional.

### Instalando o SQL Server LocalDB

Para instalar o LocalDB, você pode baixar o instalador do SQL Server Express, que inclui o LocalDB. Siga as instruções abaixo:

1. Acesse a página de download do SQL Server Express: [Download SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).
2. Escolha a versão Express e siga as instruções para instalação.

## Instalando as Dependências do Projeto

Na pasta raiz do projeto, execute o seguinte comando no terminal para restaurar as dependências:

```bash
dotnet restore
```

## Executando o Projeto

Para rodar o projeto em modo de desenvolvimento, use o seguinte comando na pasta raiz do projeto, certificando-se de usar o perfil de desenvolvimento DesafioTecnicoFSBR-DEV:

```bash
dotnet run --launch-profile DesafioTecnicoFSBR-DEV --project DesafioTecnicoFSBR.Api
```
