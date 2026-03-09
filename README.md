# 🍔 C# Lanchonete

Sistema de lanchonete desenvolvido em **C# (.NET)** utilizando a biblioteca **Spectre.Console** para criação de interfaces ricas no terminal.
O projeto simula operações de uma lanchonete diretamente no console, com menus interativos e saída formatada. Spectre.Console

---

# 🚀 Tecnologias utilizadas

* **C#**
* **.NET SDK**
* **Spectre.Console**
* **Git**

---

# 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

* **.NET SDK 7 ou superior**
* **Git**

Verifique se o .NET está instalado:

```bash
dotnet --version
```

---

# 📥 Como clonar o repositório

Clone o projeto utilizando o Git:

```bash
git clone https://github.com/devsuzarte/csharp-lanchonete.git
```

Entre no diretório do projeto:

```bash
cd csharp-lanchonete
```

---

# 📦 Restaurar dependências

O projeto utiliza pacotes NuGet, incluindo o **Spectre.Console**.

Execute:

```bash
dotnet restore
```

---

# 🔨 Build do projeto

Para compilar o sistema execute:

```bash
dotnet build
```

Se tudo estiver correto, o .NET irá gerar os arquivos compilados na pasta:

```
/bin/Debug/
```

---

# ▶️ Executar o sistema

Após o build, execute:

```bash
dotnet run
```

O sistema iniciará no terminal exibindo a interface interativa da lanchonete.

---

# 📁 Estrutura do projeto (exemplo)

```
csharp-lanchonete
│
├── src
    ├── Program.cs
    ├── Entidades
        ├── Bebida.cs
        ├── Ingrediente.cs
        ├── Item.cs
        ├── Lanche.cs
├── .gitignore
├── Lanchonete.slnx
├── Lanchonete.csproj
└── README.md
```
