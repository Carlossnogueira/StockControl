# StockControl

O **StockControl** é um sistema de controle de estoque moderno, desenvolvido em .NET 8, com arquitetura em camadas para garantir organização, escalabilidade e facilidade de manutenção. Esse projeto é consumido por um front-end em Angular 18.

---


## ✨ Funcionalidades Principais

- Cadastro, consulta e atualização de itens de estoque
- Gerenciamento de categorias de produtos
- Validação de dados de entrada
- Autenticação e autorização de usuários (JWT)
- API RESTful pronta para integração com frontends modernos

---

## 🚧 Funcionalidades Pendentes

- Remoção de usuário
- Remoção de item
- Remoção de categoria
- Movimentação de produto (entrada e saída de estoque)

---

## 🗂️ Estrutura do Projeto

- **StockControl.Api**: Camada de apresentação (API REST)
- **StockControl.Service**: Lógica de negócio e serviços de aplicação
- **StockControl.Domain**: Entidades, interfaces de repositório e regras de domínio
- **StockControl.Communication**: DTOs para requests e responses
- **StockControl.Infrastructure**: Implementação de repositórios, contexto de banco de dados e segurança

---

## 🚀 Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- FluentValidation
- Mapster
- JWT Authentication

---


## ⚡ Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/Carlossnogueira/StockControl.git
   ```
2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```
3. Defina as configurações do token JWT no arquivo `appsettings.json` da API, por exemplo:
   ```json
   "Jwt": {
     "Key": "sua-chave-secreta",
     "Issuer": "StockControlIssuer",
     "Audience": "StockControlAudience",
     "ExpiresInMinutes": 60
   }
   ```
   > Ajuste os valores conforme sua necessidade.
4. Execute as migrações do banco de dados, após definir a connection string:
   ```bash
   dotnet ef database update --project src/StockControl.Infrastructure
   ```
5. Inicie a aplicação:
   ```bash
   dotnet run --project src/StockControl.Api
   ```

A API estará disponível em `https://localhost:5001` (ou porta configurada).

---

## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

---

Desenvolvido por [Seu Nome] 🚀
