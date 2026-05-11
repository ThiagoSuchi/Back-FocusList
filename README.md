# FocusList API

A **FocusList API** é o backend de uma aplicação de gerenciamento de tarefas (To-Do List) focada em produtividade e organização. Este projeto fornece a estrutura e os endpoints necessários para criar, visualizar, atualizar e excluir tarefas de forma eficiente.

## Ferramentas e Tecnologias

- **C# & .NET 8:** Linguagem e framework principais para a construção de uma web API rápida e moderna.
- **Entity Framework Core (EF Core):** Framework ORM (Object-Relational Mapper) que simplifica a manipulação e acesso a dados.
- **MySQL:** Sistema de gerenciamento de banco de dados relacional (RDBMS) utilizado para a persistência das tarefas e outras informações.
- **Arquitetura Baseada em Serviços (Services):** O projeto está estruturado separando a lógica de requisição (`Controllers`) da lógica de negócios (`Services`), e a representação dos dados (`Models`/`Database`).

---

# !! Primeiros Passos !!
## 1 - Configuração do Banco de dados

### Depois de configurar:
- o DbContext;
- a connection string;
- as entidades/models;
- o provider do MySQL;

### Aí sim roda as migrations!