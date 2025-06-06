# LibraryManager

O **LibraryManager** é um sistema para gerenciamento de bibliotecas, desenvolvido em ASP.NET Core 8.0, com foco em boas práticas de desenvolvimento, arquitetura limpa e código sustentável.

## ✨ Funcionalidades

- 📚 **Gerenciamento de livros:** cadastro, atualização, consulta e remoção.
- 👤 **Gerenciamento de usuários:** registro e autenticação.
- 🔐 **Autenticação via JWT:** segurança para as rotas da API.
- 📖 **Controle de empréstimos e devoluções:** registre e acompanhe o histórico de empréstimos.
- 🚦 **Controle de disponibilidade e concorrência:** evita que um mesmo livro seja emprestado para mais de um usuário ao mesmo tempo.

## 🛠️ Tecnologias e Padrões Utilizados

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **PostgreSQL**
- **MediatR**
- **Swagger/OpenAPI**
- **FluentValidation**
- **JWT Bearer Authentication**

**Padrões e boas práticas:**

- Clean Architecture (Arquitetura Limpa)
- Domain-Driven Design (DDD)
- Repository Pattern
- Unit of Work Pattern
- CQRS (Command Query Responsibility Segregation)
- Result Pattern
- Injeção de Dependência (DI)
- Controle de concorrência otimista

## 🚀 Como rodar o projeto

1. Clone este repositório
2. Configure a string de conexão do PostgreSQL no arquivo `appsettings.json`.
3. Navegue até o projeto Infrastructure:
   ```bash
   cd src/LibraryManager.Infrastructure/
   ```
4. Execute as migrations do Entity Framework Core:
   ```bash
   dotnet ef database update -s ../LibraryManager.API
   ```
5. Rode o projeto

## 🤝 Contribuição

Sinta-se à vontade para abrir issues, sugerir melhorias ou enviar pull requests!

---

Feito com 💙 por Gabriel
