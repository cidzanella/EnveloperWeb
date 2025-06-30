# EnveloperWeb

**EnveloperWeb** é uma aplicação web para controle de envelopes de valores em operações comerciais. Ela permite o acompanhamento do fluxo de abertura, movimentação e fechamento de envelopes utilizados para armazenar dinheiro físico, com funcionalidades adicionais como conferência, registro de ocorrências e geração de recibos para impressão local.

## 📦 Principais Funcionalidades

- Início, movimentação e fechamento de envelopes
- Consulta e filtros avançados por período, status e operador
- Registro e histórico de conferência de envelopes
- Registro de ocorrências (ex: divergências, problemas operacionais)
- Emissão de recibos para impressão térmica via serviço local
- Backend desacoplado com arquitetura limpa (Clean Architecture)

## 🧱 Tecnologias Utilizadas

### Backend (.NET Core)

- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- Clean Architecture (Application, Domain, Infrastructure)
- Banco de dados relacional (ex: SQL Server ou SQLite)

### Frontend (Angular)

- Angular 15+
- Material Design
- Comunicação via HTTP com backend RESTful
- Integração direta com serviço local de impressão

### Serviço de Impressão Local

- Minimal API .NET
- Impressão via ESC/POS (ex: Bematech MP-4200 TH)
- Recebe requisições HTTP com o conteúdo do recibo
- Roda localmente no Windows como aplicação de fundo

## 📁 Estrutura do Projeto

```plaintext
EnveloperWeb/
├── EnveloperWeb.Api/              # Camada de apresentação (Controllers REST)
├── EnveloperWeb.Application/      # Regras de negócio (Services, DTOs, Interfaces)
├── EnveloperWeb.Domain/           # Entidades e contratos de domínio
├── EnveloperWeb.Infrastructure/   # Acesso a dados, serviços externos, implementação de repositórios
├── EnveloperPrinterService/       # Projeto separado: serviço local de impressão térmica

🚀 Como Rodar
Pré-requisitos
.NET 8 SDK

Node.js e Angular CLI (para frontend)

SQL Server ou SQLite

Impressora compatível com ESC/POS (para testes de impressão)

Backend
cd EnveloperWeb.Api
dotnet run

Frontend
cd EnveloperWeb.Frontend
npm install
ng serve

Serviço de Impressão Local
cd EnveloperPrinterService
dotnet run
