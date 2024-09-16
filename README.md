# AgroCare API

## Descrição

A **AgroCare API** é a interface principal do grupo AgroCare, desenvolvida para o consumo de dados por meio do banco de dados e do front-end da aplicação. Esta API será utilizada em um aplicativo mobile voltado para a gestão e monitoramento agrícola. Ela é composta por **6 entidades**, **2 enums** e **1 classe de resposta**, implementando funcionalidades que atendem às necessidades do projeto de forma eficiente e simplificada.

Optamos por uma **arquitetura monolítica** para este projeto, pois não haverá expansão significativa de funcionalidades no futuro, e o consumo de usuários não será elevado. Também adotamos o padrão **Singleton** para a gestão eficiente de recursos compartilhados ao longo da aplicação. A documentação detalhada de todos os endpoints foi feita utilizando o **Swagger**, facilitando o entendimento e uso da API.

## Diferença entre Arquitetura Monolítica e Microserviços

A escolha pela arquitetura monolítica foi estratégica para atender às demandas específicas do projeto. Aqui está um breve comparativo entre as duas abordagens:

- **Monolítica**: 
  - A aplicação inteira é desenvolvida e implantada como um único bloco. 
  - Simplifica a comunicação entre diferentes partes do sistema, pois tudo está contido em um só lugar.
  - Ideal para sistemas menores ou com baixa necessidade de escalabilidade e separação de responsabilidades.
  - Facilita o gerenciamento e a manutenção de pequenas equipes de desenvolvimento, como o caso da **AgroCare**.

- **Microserviços**: 
  - A aplicação é dividida em vários serviços independentes, cada um com uma função específica.
  - Mais adequado para sistemas grandes e complexos, com alto tráfego e necessidade de escalabilidade horizontal.
  - A comunicação entre serviços pode ser mais complexa, geralmente utilizando APIs REST ou mensageria.

Optamos por uma arquitetura **monolítica** porque o projeto **não prevê crescimento substancial** de funcionalidades e a base de usuários será controlada, eliminando a necessidade de um design mais complexo como o de microserviços.

## Uso do Padrão Singleton

O padrão **Singleton** foi utilizado em partes críticas da aplicação para garantir que certas classes tenham apenas uma única instância durante o ciclo de vida da aplicação. Isso é benéfico para cenários onde:

- Há **recursos compartilhados** que devem ser acessados de maneira controlada por várias partes da aplicação.
- É necessário **controlar o acesso** a recursos ou serviços globais de forma eficiente e consistente.
- Evita-se a criação desnecessária de múltiplas instâncias, economizando recursos e melhorando o desempenho.

No caso da **AgroCare**, o Singleton nos ajuda a gerenciar **instâncias de serviços compartilhados** de maneira eficiente, garantindo que haja uma única fonte de verdade.

## Documentação da API

Toda a documentação foi gerada utilizando o **Swagger**, o que facilita a visualização, compreensão e teste dos endpoints disponíveis. O Swagger permite que os desenvolvedores e consumidores da API visualizem e interajam com ela diretamente através de uma interface web amigável.

Você pode acessar a documentação completa dos endpoints e suas descrições em: /swagger/index.html
## Tecnologias Utilizadas

- **ASP.NET Core** (para desenvolvimento da API)
- **Swagger** (para documentação da API)
- **SQL Server** (para banco de dados)
- **Singleton Pattern** (para gerenciamento de instâncias únicas)

## Como Rodar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/alefgas/apiagrocare.git
2. Entre no diretório do projeto:
   ```bash
   cd agrocare-api
3. Restaure as dependências do projeto:
   ```bash
    dotnet restore

- **Controllers**  Contém os controladores responsáveis pelos endpoints
- **Models**  Contém as entidades, enums e classes de resposta
- **Services**  Implementação dos serviços de negócio, seguindo o padrão Singleton
- **Swagger**  Configurações do Swagger para documentação

## Desenvolvedores


- [Alef RM 99487]
- [Felipe Sieiro RM 98249]
- [Danilo RM99752 ]
- [Leonardo Ferreira Lizier RM551509]
- [Rodrigo Gonçalves Teixeira Filho RM99838]
