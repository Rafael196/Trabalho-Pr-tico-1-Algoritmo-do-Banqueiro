# Algoritmo do Banqueiro - Trabalho Prático
---

## 🤖 Uso de Inteligência Artificial

Este trabalho contou com o apoio de ferramentas de Inteligência Artificial para auxiliar no entendimento do problema, organização das ideias e estruturação do código.

O uso da IA foi feito como suporte ao aprendizado, sendo o conteúdo revisado e compreendido pelos autores antes da entrega.

---

## 📌 Descrição

Este projeto implementa o **Algoritmo do Banqueiro** em C#, utilizado em Sistemas Operacionais para evitar deadlocks.

O sistema simula múltiplos clientes (threads) que solicitam e liberam recursos, garantindo que o sistema permaneça em estado seguro.

---

## ⚙️ Tecnologias utilizadas

* C#
* .NET SDK

---

## 📦 Pré-requisitos

Antes de executar o projeto, é necessário ter instalado:

* .NET SDK (versão 6 ou superior)

Download: https://dotnet.microsoft.com/download

---

## 🛠️ Compilação

1. Clone o repositório:

```bash
git clone https://github.com/Rafael196/Trabalho-Pr-tico-1-Algoritmo-do-Banqueiro
```

2. Acesse a pasta do projeto:

```bash
cd Trabalho-Pr-tico-1-Algoritmo-do-Banqueiro
```

3. Compile o projeto:

```bash
dotnet build
```

---

## ▶️ Execução

Após compilar, execute o programa com:

```bash
dotnet run 10 5 7
```

📌 Os números representam a quantidade de recursos disponíveis no sistema.

Exemplo:

* 10 instâncias do recurso A
* 5 instâncias do recurso B
* 7 instâncias do recurso C

---

## 🧠 Funcionamento

O algoritmo utiliza as seguintes estruturas:

* **available** → recursos disponíveis
* **maximum** → demanda máxima de cada cliente
* **allocation** → recursos alocados
* **need** → recursos ainda necessários

Antes de conceder recursos, o sistema verifica se o estado continua seguro utilizando a função `isSafe()`.

Se não for seguro, a requisição é negada.

---

## 📊 Exemplo de saída

```
Cliente 0 iniciou
Cliente 1 pediu: 1,0,2
Cliente 1 liberou: 0,0,1
```

---

## ⚠️ Observação

O programa roda em loop infinito para simular execução contínua.

Para interromper:

```
Ctrl + C
```

---

## 👨‍💻 Autores

* Rafael
* Thulio Funayama
