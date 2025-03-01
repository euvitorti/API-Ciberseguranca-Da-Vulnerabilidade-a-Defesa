# Estudo Iterativo de Segurança em API

Bem-vindo ao repositório **Segurança Iterativa em API**! Este projeto faz parte dos meus estudos em cibersegurança, com foco em SOC, pentesting e aprimoramento de segurança. Nele, você encontrará uma evolução contínua de uma mesma aplicação API, onde cada iteração demonstra a implementação de novas medidas de proteção e boas práticas de segurança.

---

## Visão Geral

Neste repositório, o objetivo é demonstrar um ciclo completo de aprendizado prático:

1. **Criação da API Sem Segurança:**  
   - Desenvolvimento de uma API simples (utilizando, por exemplo, Spring Boot ou Node.js) sem autenticação ou validação.  
   - Implementação de logs (IPs de origem, URLs acessadas, parâmetros de consulta, erros de autenticação) para rastrear as atividades da API.

2. **Teste de Invasão (Pentest):**  
   - Aplicação de ferramentas como **Burp Suite**, **OWASP ZAP** e **Hydra** para identificar vulnerabilidades comuns, tais como:  
     - **SQL Injection**  
     - **Brute Force**  
     - **Cross-Site Scripting (XSS)**  
     - **Broken Authentication**

3. **Análise de Logs Durante os Testes:**  
   - Monitoramento em tempo real utilizando ferramentas como **Wireshark** ou **tcpdump**.  
   - Uso de ferramentas SIEM (por exemplo, **ELK Stack** ou **Wazuh**) para coletar e analisar os logs gerados durante os testes.

4. **Melhoria da Segurança da API (Iteração):**  
   - Implementação de medidas de segurança com base nos resultados dos testes, tais como:  
     - Autenticação e autorização (ex.: JWT, OAuth)  
     - Validação e sanitização de dados  
     - Proteção contra ataques de brute force  
     - Criptografia de dados (em trânsito e em repouso)  
     - Rate Limiting para prevenir DoS

5. **Ciclo Iterativo:**  
   - Repetição dos testes após cada melhoria para verificar se as vulnerabilidades foram corrigidas e identificar novas áreas de aprimoramento.

---

## Estrutura do Repositório

Cada diretório deste repositório representa uma iteração na evolução da segurança da API:

- **/versao1-insegura**  
  Primeira versão da API, sem nenhuma proteção.

- **/versao2-pentest**  
  API com logs implementados e testes de invasão realizados para identificar vulnerabilidades.

- **/versao3-aprimorada**  
  Implementação de melhorias de segurança com base nos testes (autenticação, validação de dados, etc.).

- **/versao4-reteste**  
  Nova rodada de testes de invasão para validar as correções e identificar novos pontos de melhoria.

*(As pastas seguem evoluindo conforme o avanço dos estudos e melhorias implementadas.)*

Cada pasta contém seu próprio `README.md` detalhando as mudanças, ferramentas utilizadas, resultados dos testes e lições aprendidas.

---

## Como Navegar

- **Leia os READMEs de cada versão:**  
  Cada diretório possui um arquivo `README.md` que explica as implementações, as ferramentas usadas e os resultados obtidos nessa fase.

- **Compare as iterações:**  
  Observe como a aplicação evolui de uma API totalmente vulnerável para uma aplicação cada vez mais robusta em termos de segurança.

- **Experimente os testes e melhorias:**  
  Sinta-se à vontade para clonar as versões, realizar seus próprios testes de invasão e analisar os logs para entender como cada medida de segurança impacta o comportamento da API.

---

## Objetivos do Projeto

- **Aprendizado Prático:**  
  Aplicar e consolidar os conhecimentos teóricos em SOC, pentest e cibersegurança por meio de uma aplicação real.

- **Ciclo Contínuo de Melhoria:**  
  Demonstrar a importância de testar, identificar vulnerabilidades e implementar melhorias contínuas para fortalecer a segurança.

- **Construção de Portfólio:**  
  Documentar cada passo da evolução da API, servindo como prova prática do desenvolvimento das minhas habilidades em cibersegurança.

---

Este projeto é uma parte integral dos meus estudos e da minha jornada em cibersegurança. Espero que, ao explorar este repositório, você possa ver na prática como aplicar conceitos de SOC, pentest e aprimoramento de segurança de forma iterativa e efetiva.

Bons estudos e boas práticas!

---

*Vítor – Estudante de Cibersegurança | SOC, Pentest e Desenvolvimento*
