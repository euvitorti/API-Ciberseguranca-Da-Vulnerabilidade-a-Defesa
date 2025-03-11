# Estudo Iterativo de Segurança em API

Bem-vindo ao repositório **Segurança Iterativa em API**! Este projeto integra meus estudos em cibersegurança, com foco em SOC, pentesting e aprimoramento de segurança. Aqui, você acompanhará a evolução contínua de uma API, onde cada iteração demonstra a implementação de novas medidas de proteção e boas práticas.

---

## Visão Geral

Este repositório tem como objetivo demonstrar um ciclo completo de aprendizado prático:

1. **Criação da API** 
   - Desenvolvimento de uma API simples utilizando .NET, sem autenticação ou validação.  
   - Implementação de logs (IPs de origem, URLs acessadas, parâmetros de consulta, erros de autenticação) para rastrear as atividades da API.

2. **Teste de Invasão (Pentest)**  
   - Aplicação de ferramentas como **Burp Suite**, **OWASP ZAP**, **Hydra**, **Gobuster**, **Nmap**, entre outras, para identificar vulnerabilidades comuns, tais como:  
     - **SQL Injection**  
     - **Brute Force**  
     - **Cross-Site Scripting (XSS)**  
     - **Broken Authentication**  
     - **Varredura de Rede**

3. **Análise de Logs Durante os Testes**  
   - Monitoramento em tempo real utilizando ferramentas como **Wireshark**.  
   - Coleta e análise dos logs com uma solução SIEM (utilizando o **Wazuh**) para identificar e correlacionar eventos.

4. **Melhoria da Segurança da API (Iteração)**  
   - Implementação de medidas de segurança baseadas nos resultados dos testes, como:  
     - Autenticação e autorização (ex.: JWT, OAuth)  
     - Validação de dados  
     - Proteção contra ataques de brute force  
     - Criptografia de dados (em trânsito e em repouso)  
     - Rate Limiting para prevenir DoS

5. **Ciclo Iterativo**  
   - Repetição dos testes após cada melhoria para verificar se as vulnerabilidades foram corrigidas e identificar novas áreas de aprimoramento.

---

## Estrutura do Repositório

Cada diretório deste repositório representa uma etapa na evolução da segurança da API:

- **/versao1-insegura**  
  Primeira versão da API, sem nenhuma proteção.

- **/versao2-aprimorada**  
  Implementação de melhorias de segurança baseadas nos testes realizados.

- **/versao3-e-posteriores**  
  Novas funcionalidades, novos testes de penetração e análises em SOC.

> *(As pastas evoluem conforme o avanço dos estudos e das melhorias implementadas.)*

Cada diretório contém seu próprio `README.md` detalhando as mudanças, as ferramentas utilizadas, os resultados dos testes e as lições aprendidas.

---

## Como Navegar

- **Leia os READMEs de cada versão:**  
  Cada diretório possui um arquivo `README.md` que explica as implementações, ferramentas utilizadas e os resultados obtidos.

- **Compare as Iterações:**  
  Observe como a API evolui de um estado vulnerável para uma aplicação cada vez mais robusta em termos de segurança.

- **Experimente os Testes e Melhorias:**  
  Sinta-se à vontade para clonar as versões, realizar seus próprios testes de invasão e analisar os logs para entender como cada medida de segurança impacta o comportamento da API.

---

## Objetivos do Projeto

- **Aprendizado Prático:**  
  Consolidar e aplicar conhecimentos teóricos em SOC, pentest e cibersegurança através de uma aplicação real.

- **Ciclo Contínuo de Melhoria:**  
  Demonstrar a importância de testar, identificar vulnerabilidades e implementar melhorias contínuas para fortalecer a segurança.

- **Construção de Portfólio:**  
  Documentar cada etapa da evolução da API, servindo como prova prática do desenvolvimento das minhas habilidades em cibersegurança.

---

## Ambiente de Desenvolvimento

Estou utilizando um ambiente híbrido com Windows e Kali Linux rodando em máquina virtual (VM). Seguem alguns links e dicas para configurar seu ambiente:

1. **VirtualBox:**  
   [Download VirtualBox](https://www.virtualbox.org/wiki/Downloads)

2. **Kali Linux:**  
   [Download Kali Linux](https://www.kali.org/get-kali/#kali-installer-images)

3. **Configuração da VM:**  
   - **Adaptador 1:** Configure como **Host-Only** para comunicação entre o host e a VM.  
   - **Adaptador 2:** Configure como **NAT** para acesso à internet.

4. **Instalação do Kali Linux:**  
   Siga as instruções oficiais do processo de instalação.

5. **API em .NET:**  
   [Baixar o .NET para Windows (Estou utilizando o .NET 9.0)](https://dotnet.microsoft.com/pt-br/download)

---

## Aprenda Mais

Estou seguindo o [Roadmap de Cyber Security Expert](https://roadmap.sh/cyber-security) e os desafios do [TryHackMe](https://tryhackme.com/). Se você quiser acompanhar meu progresso e aprendizado, confira também os repositórios onde documentei meus conhecimentos:

1. [Cyber-Security-Expert-PT](https://github.com/euvitorti/Cyber-Security-Expert-PT)

---

Este projeto é uma parte fundamental da minha jornada em cibersegurança. Ao explorar este repositório, você verá na prática como aplicar conceitos de SOC, pentest e aprimoramento de segurança de forma iterativa e eficaz.

**Bons estudos e boas práticas!**

---

*Vítor – Estudante de Cibersegurança | SOC | Desenvolvimento*
