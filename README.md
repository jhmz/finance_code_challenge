# CodeChallenge

## Descrição do Projeto

Este projeto é uma aplicação de console que calcula impostos com base em operações financeiras. A aplicação lê os dados de entrada, que podem ser fornecidos através da linha de comando ou de um arquivo de texto, processa essas operações e calcula os impostos devidos. O resultado é impresso em formato JSON.

## Decisões Técnicas e Arquiteturais

### Estrutura do Projeto

O projeto é estruturado em torno de duas classes principais:

1. **Program**: A classe principal que gerencia a entrada e saída de dados.
2. **TaxCalculator**: A classe responsável pelo cálculo dos impostos com base nas operações fornecidas.

### Processamento de Dados

- As operações são lidas e desserializadas usando `System.Text.Json`.
- O cálculo do imposto é feito pela classe `TaxCalculator`, que mantém o preço médio ponderado, a quantidade total e a perda acumulada para determinar o imposto devido em cada operação de venda.

### Tratamento de Entrada

- Se o programa for executado sem argumentos, ele espera que a entrada seja fornecida através da linha de comando.
- Se um argumento for fornecido, ele é tratado como o caminho para um arquivo de texto que contém as operações.

## Justificativa para Uso de Frameworks/Bibliotecas

- **System.Text.Json**: Usado para serialização e desserialização de objetos JSON. Esta biblioteca foi escolhida por ser eficiente e fazer parte da biblioteca padrão do .NET, garantindo boa performance e fácil integração.

## Instruções de Compilação e Execução

### Compilação do Projeto

Para compilar o projeto, navegue até a pasta do projeto e execute:

```bash
dotnet build
```

### Execução do Projeto

### Entrada pela Linha de Comando

Para executar o programa e fornecer a entrada diretamente pela linha de comando, use:

```bash
dotnet run
```

Em seguida, digite as operações uma por linha e pressione Enter. Para finalizar a entrada aperte enter (input vazio).

### Entrada por Arquivo

Para executar o programa com a entrada fornecida por um arquivo de texto, use:

```bash
dotnet run caminho/para/o/arquivo.txt
```

### Execução dos Testes

Para executar os testes do projeto, navegue até a pasta do projeto (./CodeChallenge) e execute:

```bash
dotnet test
```

### Notas Adicionais

- Certifique-se de que o arquivo de entrada esteja no formato JSON correto, conforme esperado pelo programa.
- O programa assume que o arquivo de entrada e os dados fornecidos pela linha de comando estão no formato JSON esperado, com cada linha representando uma lista de operações.
