## Maxson Almeida -  Rinha 2025 - Sistem de Processamento de Pagamentos

#### Stack

- ![Java](https://img.shields.io/badge/Java-24-red?logo=openjdk) + ![Spring Boot](https://img.shields.io/badge/Spring%20Boot-3.5-6DB33F?logo=springboot)
- ![GraalVM](https://img.shields.io/badge/GraalVM-Native%20Image-orange?logo=graalvm)
- ![Threads](https://img.shields.io/badge/Virtual%20Threads-milhares%20concorrentes-blue?logo=java)
- ![Architecture](https://img.shields.io/badge/Clean%20Architecture-Ports%20%26%20Adapters-lightgrey?logo=architecture)
- ![Redis](https://img.shields.io/badge/Redis-Filas%20Ass%C3%ADncronas-DC382D?logo=redis)
- ![Nginx](https://img.shields.io/badge/Nginx-Load%20Balancer-009639?logo=nginx)

#### Arquitetura

```
[Nginx] → [App-1 + App-2] → [Redis Queue] → [Async Worker] → [Payment Processors]
```

#### Repositórios

| Repositório | Descrição |
|-------------|-----------|
| [![ApiPaymentProcessor](https://img.shields.io/badge/GitHub-ApiPaymentProcessor-blue?logo=github)](https://github.com/maxsonferovante/ApiPaymentProcessor) | API principal para processamento de pagamentos |
| [![AsyncPaymentProcessor](https://img.shields.io/badge/GitHub-AsyncPaymentProcessor-blue?logo=github)](https://github.com/maxsonferovante/AsyncPaymentProcessor) | Worker assíncrono para processamento paralelo |

#### Redes Sociais

[![GitHub](https://img.shields.io/badge/GitHub-maxsonferovante-181717?logo=github)](https://github.com/maxsonferovante)  
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Maxson%20Almeida-0A66C2?logo=linkedin)](https://www.linkedin.com/in/maxson-almeida/)
