### 🚀 Resumo: Executando o Projeto .NET e Angular  

#### ✅ **Pré-requisitos**  
**Backend (.NET 9)**  
- .NET 9 SDK (https://dotnet.microsoft.com/download/dotnet/9.0)  
- Visual Studio 2022 (versão mais recente) (https://visualstudio.microsoft.com/vs/)  

**Frontend (Angular 19)**  
- Node.js 22+ (https://nodejs.org)  
- Angular CLI 19+  
  Para instalar a versão 19 ou atualizar:  
  `npm install -g @angular/cli`

---

#### 🖥️ **Executando o Backend (.NET 9)**  
- **Via terminal:**  
  1. Acesse a pasta do projeto:
     - `B3Evaluation/src/B3.API`
  2. Restaure as dependências:
     - `dotnet restore`
  3. Execute o projeto:
     - `dotnet run`

- **Via Visual Studio 2022:**  
  1. Abra o arquivo **.sln** e defina **B3.API** como projeto inicial.  
  2. Escolha o perfil **SelfHosting** e pressione **F5** (Debug) ou **Ctrl+F5** (Sem Debug).  

- **Acessar a documentação da API:**  
  - https://localhost:5001/swagger  
  - http://localhost:5000/swagger 

---

#### ✅ **Rodando Testes (.NET 9)**  
1. Acesse a pasta de testes:  
   - `B3Evaluation/tests/B3.Tests`
2. Execute os testes:
   - `dotnet test`

---

#### 🖥️ **Executando o Frontend (Angular 19)**  
- **Via terminal:**  
  1. Acesse a pasta do projeto Angular:
     - `B3Evaluation/src/b3-web-app`
  2. Instale as dependências:
     - `npm install`
  3. Execute o projeto:
     - `ng serve`
  4. Acesse em:  
     - http://localhost:4200

- **Via Visual Studio Code:**  
  1. Acesse a pasta do projeto Angular:
     - `B3Evaluation/src/b3-web-app`
  2. Abra o Visual Studio Code com o seguinte comando no terminal:
     - `code .`
  3. No terminal integrado do Visual Studio Code, instale as dependências:
     - `npm install`
  4. Execute o projeto:
     - `ng serve`
  5. Acesse a aplicação em:
     - http://localhost:4200

Pronto! 🚀
