# myfinance-web-netcore
MyFinance - Projeto do Curso de Pós-Graduação em Engenharia de Software da PUC-MG
**Aluno:** Petterson Rodrigues Galdino

## Modelagem

A figura abaixo representa o Diagrama de Entidades e Relacionamentos da aplicação, constituido pelas tabelas:
    
* ACCOUNT_PLANS (Plano de Contas)
* TRANSACTIONS (Transações)
* PAYMENT_METHOD (Métodos de Pagamentos)   

<img src="docs\diagrama.jpeg" alt="diagram">

## Padrão de Arquitetura

A aplicação foi desenvolvida utilizando a arquitetura MVC (Model - View - Controller), sendo:

**Model:** Sua responsabilidade é gerenciar e controlar a forma como os dados se comportam por meio das funções, lógica e regras de negócios estabelecidas.

**View:** Essa camada é responsável por apresentar as informações de forma visual ao usuário.

**Controller:** A camada de controle é responsável por intermediar as requisições enviadas pelo View com as respostas fornecidas pelo Model, processando os dados que o usuário informou e repassando para outras camadas.

<img src="docs\MVC.png" alt="MVC">

### Requisitos

* Versão mais recente do Visual Studio Code

* Extensão do C# para Visual Studio Code -.NET Core SDK 6.0, o qual pode ser obtido através do <a href="https://dotnet.microsoft.com/en-us/download">Link</a>

* Última versão do Git, a qual pode ser adquirida por meio do <a href="https://git-scm.com/downloads">Link</a>

* Última versão do C# extensions, o qual deve ser instalado no Visual Studio Code

* SQL Server 2019

## Executando o projeto

Clone o repositório disponível  <a href="https://github.com/pettersonrodgaldino/myfinance-web-netcore">AQUI</a>

Execute o script de banco de dados (presente em myfinance-web-netcore\docs\my_finance.sql) no SQL Server. 

Abra a pasta com o projeto no VSCode, em seguida abra um terminal e digite **cd myfinance-web-netcore**

Para buildar o projeto, execute o comando **dotnet build**

Para executar o projeto, execute o comando **dotnet run**

Clique sobre a URL do projeto ou copie o endereço e cole no navegador.

## O projeto

<img src="docs\index.jpg" alt="Página inicial">

No cabeçalho , temos as opções Transações e Plano de Contas.

Em Planos de Conta, será registrado os planos a quais serão atribuídos as transações financeiras. Além de exibir o id, descrição e tipo do plano de conta, é possível editar e excluir um plano. Os Planos de contas podem ser do tipo:
* **D** = Despesa
* **R** = Receita

Por padrão, a aplicação já vem com os seguintes planos cadastrados: Aluguel, Alimentação, Combustível, Viagens, Salário e Luz.

<img src="docs\plano.jpg" alt="Plano de Contas">

Para criar um plano novo, basta clicar em "Criar Plano", que será exibida a tela de registro de plano contas, onde deve ser informado a descrição do plano e o tipo. 

<img src="docs\cadastro plano.jpg" alt="Criar Plano">

Na tela de Transações, será listada todas as transações cadastradas com as seguintes informações:
* **ID**: identificar da transação
* **Data**: data da inclusão da transação
* **Tipo**: tipo da transação, que pode ser **Receita** (R) ou **Despesa** (D).
* **Valor**: valor da transação
* **Histórico**: Descrição da transação
* **Plano de Conta**: Id do plano de conta
* **Tipo de Pagamento**: Id do tipo de pagamento da transação

Além disso é possível editar e excluir um plano.

<img src="docs\transacao.jpg" alt="Transação">

Ao clicar em Registrar Transação, o usuário será encaminhado para um formulário para registro de novas transações.

<img src="docs\registrar transacao.jpg" alt="Registrar Transação">

## Feature Extra

**Ajuste  Tela de Registro de Transações:**  Incluir a possibilidade de indicar o tipo de pagamento quando a transação for de despesa. O sistema deve permitir a seleção dos tipos: 
* Dinheiro
* Débito
* Pix
* Crédito
* Boleto

O menu de **Tipo de pagamentos** só estará visível se o tipo da transação for **"Despesa"**. Caso o tipo seja  **Receita**, o menu de tipo de pagamento ficará oculto.

<img src="docs\feature 1.jpg" alt="Novo requisito - Receita">

<img src="docs\feature 2.jpg" alt="Novo requisito - Despesa">















