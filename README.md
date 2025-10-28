# API de Gerenciamento Bancário com ASP.NET Core 8

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-11.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity%20Framework-Core-9B4F96?style=for-the-badge)
![Swagger](https://img.shields.io/badge/Swagger-UI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

API RESTful para gerenciamento de contas bancárias, construída do zero com C# 12, .NET 8, e Entity Framework Core 8.

## 🚀 Sobre o Projeto

Este projeto é uma API RESTful completa que simula o back-end de um sistema de gerenciamento bancário. Ele implementa o ciclo **CRUD** (Create, Read, Update, Delete) de ponta a ponta, permitindo a criação, listagem, consulta, atualização e exclusão de contas empresariais.

O objetivo deste projeto foi aplicar os conceitos fundamentais do desenvolvimento back-end .NET, desde a modelagem de domínio com POO até a persistência de dados em um banco de dados real.

## ✨ Principais Funcionalidades

* **Criação de Contas (`POST`):** Cadastra uma nova conta empresarial no banco de dados.
* **Leitura de Contas (`GET`):** Permite consultar a lista completa de contas ou buscar uma conta específica pelo seu número.
* **Atualização de Contas (`PUT`):** Modifica os dados de uma conta existente (como Titular ou Limite).
* **Exclusão de Contas (`DELETE`):** Remove uma conta do banco de dados.
* **Persistência de Dados:** As informações são salvas em um banco de dados **SQLite**, garantindo que os dados sobrevivam ao reinício da aplicação.
* **Tratamento de Erros:** A API retorna os códigos de status HTTP corretos (ex: `404 Not Found` para contas não encontradas, `201 Created` para criação bem-sucedida).

## 🛠️ Tecnologias Utilizadas

Este projeto foi construído utilizando o que há de mais moderno no ecossistema .NET:

* **.NET 8** e **C# 12**
* **ASP.NET Core:** Framework principal para a construção da API RESTful.
* **Entity Framework Core (EF Core):** ORM utilizado para o mapeamento objeto-relacional e comunicação com o banco de dados.
* **SQLite:** Banco de dados relacional leve utilizado para persistência dos dados.
* **LINQ:** Utilizado para a escrita de consultas ao banco de dados de forma expressiva.
* **Injeção de Dependência (DI):** Utilizada para injetar o `ApiDbContext` nos controllers.
* **Padrão de DTOs (Data Transfer Objects):** Para desacoplar os modelos de entrada/saída do modelo de domínio.
* **Programação Assíncrona (`async/await`):** Para garantir que as chamadas de banco de dados não bloqueiem o servidor.
* **Swagger/OpenAPI:** Para documentação e teste interativo dos endpoints.

## 🏁 Como Executar o Projeto

Siga os passos abaixo para executar a aplicação localmente.

**Pré-requisitos:**
* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Ferramenta de linha de comando do EF Core (`dotnet tool install --global dotnet-ef`)

**Passos:**

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git](https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git)
    cd SEU-REPOSITORIO
    ```

2.  **Restaure os pacotes:**
    ```bash
    dotnet restore
    ```

3.  **Crie o banco de dados (Migration):**
    O Entity Framework Core cuidará da criação do banco `contas.db` e suas tabelas.
    ```bash
    dotnet ef database update
    ```

4.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```

5.  **Acesse o Swagger:**
    Abra seu navegador e acesse a URL `https` que apareceu no terminal (geralmente algo como `https://localhost:7123/swagger`).

## 🗺️ Endpoints da API

A API expõe os seguintes endpoints:

| Verbo | Rota | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/Contas` | Retorna a lista de todas as contas. |
| `GET` | `/api/Contas/{numeroDaConta}` | Busca uma conta específica pelo seu número. |
| `POST` | `/api/Contas` | Cria uma nova conta. |
| `PUT` | `/api/Contas/{numeroDaConta}` | Atualiza uma conta existente. |
| `DELETE` | `/api/Contas/{numeroDaConta}` | Deleta uma conta existente. |
