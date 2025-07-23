# Rinha de Backend 2025 - Matheus do Java

Solução em **Java 21** com **Spring Boot**, **GraalVM Native Image** e suporte a **Threads Virtuais (Project Loom)**, buscando máxima concorrência com código simples e eficiente.

---

## 🧱 Tecnologias

- Java 21 (com Loom)
- Spring Boot
- GraalVM Native Image
- MongoDB
- HttpClient nativo da JDK
- Nginx (para balanceamento entre instâncias)

---

## 🚀 Estratégia

- Uso de **threads virtuais** para escalar o número de requisições concorrentes mesmo com chamadas bloqueantes.
- Cliente HTTP baseado no `java.net.http.HttpClient` da JDK 21, com controle de timeout e fallback.
- Aplicação compilada com **GraalVM** para reduzir o tempo de inicialização e consumo de memória.
- Balanceamento entre instâncias da API via **Nginx**.

---

## 🐳 Como rodar

Se você já tem a imagem nativa construída localmente ou baixada do Docker Hub, basta rodar:

```bash
docker-compose up -d
```
---

## 📺 Canal no YouTube

Acompanhe mais conteúdos sobre Java e back-end no meu canal:

➡️ [Matheus do Java](https://www.youtube.com/@MatheusdoJava)