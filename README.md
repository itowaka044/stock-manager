
# 📚 Nome do Projeto

> Stock Controller loja a granel

## 🧾 Descrição

> Esta API simula o controle de estoque de uma loja a granel. Permite cadastrar/deletar, visualizar, alterar produtos e calcular o preço dos produtos relacionados ao peso.

---

## 👥 Integrantes da Dupla

- Francisco Bueno Ghizelini - [chico-bueno](https://github.com/chico-bueno)
- João Vitor Wakamori - [itowaka044](https://github.com/itowaka044)

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 8)
- **Framework:** ASP.NET Core - Minimal API
- **ORM:** Entity Framework Core
- **Banco de Dados:** SQLite
- **Front-end:** JavaScript
- **Versionamento:** Git + GitHub

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download)
- [dotnet ef]
- [SQLite](https://www.sqlite.org/download.html) (ou algum cliente de visualização como DB Browser for SQLite)
- Git instalado

### Passos

```bash
# 1. Clone o repositório
git clone https://github.com/itowaka044/stock-manager

# 2. Acesse a pasta do projeto
cd stock-manager/A_granel

# 3. Restaure os pacotes
dotnet restore

# 4. crie o banco
dotnet ef database update

# 5. Execute a aplicação
dotnet run

