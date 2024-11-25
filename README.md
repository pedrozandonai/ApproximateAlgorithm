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

### Baixando o arquivo e executando o .exe
