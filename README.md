# Approximate Algorithm

Este projeto implementa um algoritmo aproximativo para o problema da mochila fracionária (Fractional Knapsack Problem), inspirado no conteúdo do livro _Dasgupta, S., Papadimitriou, C. H., & Vazirani, U. V. (n.d.). Algorithms. McGraw-Hill Higher Education._

O problema da mochila fracionária é um problema clássico de otimização, onde o objetivo é preencher uma mochila com itens de diferentes valores e pesos de maneira a maximizar o valor total, respeitando uma capacidade máxima da mochila. Ao contrário do problema clássico da mochila (onde os itens devem ser inteiros), neste caso, é permitido fracionar os itens, o que facilita encontrar uma solução aproximada eficiente.

## Contexto e Justificativa

O algoritmo aproximativo implementado neste projeto segue a estratégia de greedy (guloso), onde os itens são classificados de acordo com seu valor por unidade de peso. Os itens com maior valor relativo são selecionados primeiro, e, se necessário, fracionados para preencher a mochila até sua capacidade máxima. Este tipo de abordagem é frequentemente usado em cenários onde uma solução exata não é viável devido ao tempo de processamento ou à complexidade computacional, mas onde uma boa aproximação é suficiente para a maioria das aplicações.

O algoritmo foi desenvolvido com base no livro de algoritmos de Dasgupta, Papadimitriou e Vazirani, uma referência fundamental no estudo de algoritmos e problemas de otimização. A implementação demonstra a aplicabilidade de técnicas aproximativas para problemas clássicos de otimização combinatória e é uma excelente maneira de ilustrar conceitos como programação gulosa e aproximações eficientes.

## Objetivo do Projeto

O principal objetivo deste projeto é implementar e testar um algoritmo aproximativo para o problema da mochila fracionária e validar sua eficácia ao encontrar uma solução eficiente para o problema em instâncias de diferentes tamanhos e capacidades. A solução utiliza uma abordagem gulosa para selecionar itens e fracioná-los, se necessário, maximizando o valor total dentro da capacidade da mochila.

## Como executar a aplicação

### Através do código fonte do GitHub

Dependências:

1.  [Git](https://git-scm.com/downloads)

2.  [.NET 9.0](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)

Comandos:

```bash
git clone https://github.com/pedrozandonai/ApproximateAlgorithm.git

cd ApproximateAlgorithm/src/ApproximateAlgorithm.ConsoleApp

dotnet run Program.cs
```

### Baixando o arquivo e executando o .exe

Dependências:

1.  [.NET 9.0](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)

## Relatório (à pedido do professor)

### Performance e Complexidade

Complexidade de Tempo:

**Ordenação:** A ordenação dos itens pela relação valor/peso tem complexidade O(n log n), onde n é o número de itens.
Iteração sobre os Itens: Após ordenar os itens, o código itera sobre a lista de itens uma vez, o que é O(n). Portanto, a complexidade total de tempo é O(n log n).
Complexidade de Espaço:

O espaço necessário é O(n) para armazenar as listas de itens incluídos e excluídos, além da lista original de itens.
A ordenação também requer espaço adicional de O(n) para realizar a ordenação.

### Qualidade e Custo da Solução

A implementação do algoritmo da mochila fracionária é de alta qualidade, pois segue uma abordagem eficiente usando o algoritmo guloso, que é adequado para problemas de otimização com itens fracionados. No entanto, a solução pode ser mais cara em termos de tempo quando o número de itens é muito grande devido à complexidade da ordenação.

**Pontos Positivos:**

- _Simplicidade:_ O código é claro e fácil de entender, utilizando um algoritmo de otimização bem estabelecido.

- _Eficiência:_ A ordenação e iteração são as operações dominantes, e o tempo de execução cresce de forma eficiente com o aumento do número de itens.

**Pontos de Melhoria:**

- _Uso de LINQ:_ O uso de LINQ para ordenar e filtrar os itens pode ser substituído por loops manuais para melhorar a legibilidade e o desempenho em alguns casos.

- _Precisão com Frações:_ Embora o algoritmo trabalhe com frações de itens, o tratamento de frações de peso como inteiros pode levar a pequenas imprecisões, dependendo do contexto da aplicação.
