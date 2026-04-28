# Algoritmo do Banqueiro - Trabalho Prático

## 📌 Descrição
Este projeto implementa o **Algoritmo do Banqueiro** em C#, utilizado em Sistemas Operacionais para evitar deadlocks.

O sistema simula múltiplos clientes (threads) que solicitam e liberam recursos, garantindo que o sistema nunca entre em um estado inseguro.

---

## ⚙️ Tecnologias utilizadas
- C#
- .NET

---

## 🧠 Como funciona o algoritmo

O algoritmo utiliza as seguintes estruturas:

- **available** → recursos disponíveis
- **maximum** → demanda máxima de cada cliente
- **allocation** → recursos atualmente alocados
- **need** → recursos ainda necessários

Antes de conceder recursos, o sistema verifica se o estado continua seguro através da função `isSafe()`.

Se não for seguro, a requisição é negada.

---

## ▶️ Como executar o projeto

### 1. Instalar o .NET SDK
Baixe em: https://dotnet.microsoft.com/download

### 2. Clonar o repositório
```bash
git clone https://github.com/Rafael196/Trabalho-Pr-tico-1-Algoritmo-do-Banqueiro
