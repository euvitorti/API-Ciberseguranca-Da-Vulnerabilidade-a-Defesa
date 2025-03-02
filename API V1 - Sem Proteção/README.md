# Versão 1: API Inicial Sem Segurança

Esta é a primeira versão da API, gerada com o comando:

```
    dotnet new webapi -n NomeDaApi
```

Nesta versão, a API é muito básica e não possui nenhuma implementação de autenticação, validação ou outras medidas de segurança. O objetivo aqui é estabelecer uma base para os testes e, posteriormente, implementar melhorias de segurança.

---

## Configuração Inicial e Acesso Remoto

Por padrão, a API gerada pelo .NET utiliza o Kestrel como servidor web e é configurada para escutar apenas no localhost (127.0.0.1). Isso significa que, inicialmente, a API não está acessível a partir de outras máquinas, como uma VM Kali, na mesma rede.

### Por que Configurar o Kestrel para Escutar em Todas as Interfaces?

Para que a API seja acessível de fora da máquina local (por exemplo, a partir da VM Kali), é necessário que ela escute em todas as interfaces de rede. Dessa forma, a API passará a responder por meio do IP de rede (no nosso caso, algo como 192.168.56.X), e não apenas no localhost.

---

## Como Configurar

No arquivo Program.cs (ou Startup.cs, dependendo da versão do .NET), você deve configurar o Kestrel para ouvir em todas as interfaces. Por exemplo, para .NET 5 ou superior, adicione a seguinte configuração:

```
    // Configura o Kestrel para escutar em todas as interfaces na porta 5000
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Listen(System.Net.IPAddress.Any, 5000); // Substitua 5000 pela porta desejada
    });
```

Essa configuração garante que a API fique acessível externamente através do IP de rede da máquina (por exemplo, 192.168.56.1) e na porta especificada (neste exemplo, 5000).

---

## Testes de Reconhecimento a Partir do Kali

1. Passo 1: Obter o IP do Windows

No Windows, execute o comando ipconfig para identificar o IP da interface de rede usada na comunicação com a VM (por exemplo, 192.168.56.1).

2. Passo 2: Testar com Nmap

No Kali, execute o seguinte comando para verificar se a porta 5000 está aberta:

```
    nmap -p 5000 192.168.56.1
```

3. Saída de exemplo:

```
    Starting Nmap 7.94SVN ( https://nmap.org ) at 2025-03-01 16:03 -03
    Nmap scan report for 192.168.56.1
    Host is up (0.0055s latency).

    PORT     STATE SERVICE
    5000/tcp open  upnp
    MAC Address: XX:XX:XX:XX:XX:XX (Unknown)

    Nmap done: 1 IP address (1 host up) scanned in 13.89 seconds
```

*Observações:*

- A porta 5000 está aberta e o Nmap a identifica como utilizando o serviço upnp?. O "?" indica que o Nmap não tem 100% de certeza sobre o serviço.
- O endereço MAC aparece, mas como se trata de uma máquina virtual, o fabricante pode aparecer como Unknown.

4. Comando Detalhado

Para obter uma análise mais aprofundada, use o comando com a opção -A:

```
    nmap -A -p 5000 192.168.56.1
```

Saída detalhada de exemplo:

```
    Starting Nmap 7.94SVN ( https://nmap.org ) at 2025-03-01 16:04 -03
    Nmap scan report for 192.168.56.1
    Host is up (0.0013s latency).

    PORT     STATE SERVICE VERSION
    5000/tcp open  upnp?
    | fingerprint-strings: 
    |   DNSStatusRequestTCP, DNSVersionBindReqTCP, Help, RPCCheck, SMBProgNeg, SSLSessionReq, TerminalServerCookie, ZendJavaBridge: 
    |     HTTP/1.1 400 Bad Request
    |     Content-Length: 0
    |     Connection: close
    |     Date: Sun, 02 Mar 2025 13:28:21 GMT
    |     Server: Kestrel
    |   GetRequest: 
    |     HTTP/1.1 404 Not Found
    |     Content-Length: 0
    |     Connection: close
    |     Date: Sun, 02 Mar 2025 13:28:19 GMT
    |     Server: Kestrel
    |   HTTPOptions: 
    |     HTTP/1.1 404 Not Found
    |     Content-Length: 0
    |     Connection: close
    |     Date: Sun, 02 Mar 2025 13:28:21 GMT
    |     Server: Kestrel
    |   RTSPRequest: 
    |     HTTP/1.1 505 HTTP Version Not Supported
    |     Content-Length: 0
    |     Connection: close
    |     Date: Sun, 02 Mar 2025 13:28:21 GMT
    |_    Server: Kestrel
    ...
    MAC Address: XX:XX:XX:XX:XX:XX (Unknown)
    Warning: OSScan results may be unreliable because we could not find at least 1 open and 1 closed port
    Device type: general purpose
    Running (JUST GUESSING): Microsoft Windows 11|10 (91%), FreeBSD 6.X (88%)
    ...
    Network Distance: 1 hop
```

5. Interpretação dos Resultados do Nmap

- Informações Básicas: Host is up (0.0013s latency): O host está ativo e responde rapidamente na rede local.
- PORT 5000/tcp open upnp?: A porta 5000 está aberta. O Nmap sugere UPnP, mas não tem certeza; isso se deve ao fato de o Kestrel responder com mensagens HTTP padrão.
- Server: Kestrel: Indica que o servidor HTTP é o Kestrel, comumente usado em aplicações ASP.NET Core.
- Respostas HTTP: 400 Bad Request, 404 Not Found, 505 HTTP Version Not Supported: O Nmap testou várias requisições. Essas respostas indicam que a API está ativa, mas os endpoints requisitados não foram encontrados ou a requisição não foi entendida — comportamento esperado em uma API mínima sem endpoints definidos além dos padrões.
- Possível Sistema Operacional: O Nmap tenta adivinhar o SO (como Windows 10/11 ou até FreeBSD) com base nos padrões de resposta. Isso auxilia no reconhecimento do ambiente.
- Network Distance: 1 hop: O host está na mesma rede local, sem intermediários, facilitando o teste e a análise.

6. Como essas informações são utilizadas:

- Reconhecimento: Identificar o tipo de servidor e sistema operacional ajuda a entender a infraestrutura e potenciais pontos de ataque.
- Testes de Segurança: Saber quais portas estão abertas e como os serviços respondem é fundamental para identificar vulnerabilidades.
- Análise de Servidor: Confirmar que o servidor é o Kestrel e que a API está acessível via IP de rede valida que as configurações estão corretas para os próximos testes.

---

## Conclusão

Nesta primeira versão, a API foi gerada de forma básica e configurada para ser acessível externamente ajustando o Kestrel para escutar em todas as interfaces (0.0.0.0). Os testes realizados com o Nmap confirmam que a porta 5000 está aberta e que o servidor responde conforme esperado, apesar de retornar erros HTTP padrão (400, 404, 505) — um comportamento normal para uma API inicial sem endpoints específicos implementados.

Esta versão serve como base para futuras iterações, onde serão implementadas melhorias de segurança, novos endpoints e funcionalidades, permitindo uma análise contínua e aprimoramento da segurança da API.

*Vítor – Estudante de Cibersegurança | SOC | Desenvolvimento*