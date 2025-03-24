# Ambev Developer Evaluation

## Visão Geral

Este projeto implementa um sistema de vendas utilizando uma arquitetura moderna e robusta, fundamentada em princípios e padrões de design que facilitam a manutenção e escalabilidade. As principais decisões técnicas adotadas são:

- **CQRS (Command Query Responsibility Segregation):** Separa as operações de leitura e escrita, melhorando a performance, a escalabilidade e a clareza do código.
- **DDD (Domain-Driven Design):** A modelagem é centrada no domínio do negócio, promovendo uma comunicação clara entre os desenvolvedores e os especialistas do domínio.
- **Repository Pattern:** Abstrai o acesso aos dados, facilitando a manutenção, os testes e a evolução do sistema.
- **Arquitetura Orientada a Eventos:** O fluxo de compras dispara eventos de integração (por exemplo, via RabbitMQ) para processar pagamentos e enviar notificações aos clientes de forma assíncrona e desacoplada.

## Fluxo de Compras

O fluxo de compras implementado é o seguinte:

1. **Selecionar o Produto:** O usuário escolhe os produtos desejados.
2. **Criar um Carrinho (Cart):** Os produtos selecionados são adicionados ao carrinho.
3. **Realizar uma Compra:** O usuário finaliza a compra, transformando o carrinho em uma venda.
4. **Disparo de Evento:** Após a finalização da compra, é disparado um evento que aciona o processamento do pagamento e a notificação do cliente.

## Tecnologias Utilizadas

- **.NET 8**
- **PostgreSQL** como banco de dados
- **Entity Framework Core** para ORM e migrações
- **RabbitMQ** para mensageria e integração via eventos
- **FluentValidation** para validação de comandos e requisições
- **AutoMapper** para mapeamento entre entidades e DTOs
- **UnitOfWork** para aumentando a consistência dos dados.
- **Dependency Injection** para promover um código mais modular e testável.

## Como Executar o Projeto

1. **Clonar o Repositório:**
   ```bash
   git clone https://github.com/GabrieLeme07/tech-challenge.git

2. **Navegar até a Pasta `src`:**
   ```bash
   cd src/

3. **Configurar a Connection String**
Configure a string de conexão com o PostgreSQL no arquivo de configuração (por exemplo, `appsettings.json`) de acordo com a sua instância do banco de dados.

4. **Executar as Migrations:**
Para atualizar o banco de dados, execute o seguinte comando a partir da pasta `src/`:
   ```bash
   dotnet ef database update --project ./Ambev.DeveloperEvaluation.ORM/Ambev.DeveloperEvaluation   ORM.csproj --startup-project ./Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation WebApi.csproj --context DefaultContext

5. **Executar o Projeto**
Você pode iniciar o projeto através do Visual Studio, VS Code ou pela linha de comando:
   ```bash
   dotnet run --project ./Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj
