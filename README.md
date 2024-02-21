# Resumo e Instruções para Inicialização do Projeto

## Resumo

O desafio de desenvolvimento Open Finance propõe a criação de um módulo de aplicação integrado ao ecossistema de Open Finance, capaz de apresentar uma lista atualizada dos participantes do Open Banking. Essa lista deve incluir informações como nome, logo e URL de configuração/discovery do Authorization Server de cada participante. O objetivo é contribuir para a inovação, concorrência e melhoria na oferta de produtos no sistema financeiro, conforme proposto pelo Banco Central do Brasil.

## Instruções para Inicialização do Projeto

Siga as instruções abaixo para iniciar o projeto:

### Estrtura do Repositório

```
├── SQL           <- Arquivos para criação do banco de dados.
|
├── teros-api     <- Arquivos backend.
|
├── teros-app     <- Arquivos frontend.
|
├── .gitignore    <- ignoradar arquivos para o git.
|
├── LICENSE       <- licença.
|
├── README        <- Notas.
```

### Estrtura do backend

```
├── TEROS.Api              <- Backend do projeto (lógica de servidor, APIs).
|
├── TEROS.Application      <- Arquivos das camadas mais externas intermediaria entre controller e domain (Commands, Query, Extensions, Interfaces e Validações)
|
├── TEROS.DataAccess       <- Arquivos voltados ao acesso e interação com o banco de dados (Migrations, DataContext).
|
├── TEROS.Domain           <- Lógica de domínio do projeto (modelos, regras de negócios).
|
├── TEROS.Tests            <- Testes relacionados ao projeto (Shoulds xUnit).
```

### Estrtura do frontend

```
├── cypress          <- Contém arquivos relacionados ao teste de front-end, 
|   ├── e2e          <- O diretório `e2e` contem testes end-to-end específicos.
|
├── public           <- Arquivos publicos compartilhado com cada cliente.
|
├── src              <- Centraliza arquivos voltados ao desenvolvimento do front-end, como componentes, estilos e lógica da aplicação. 
|   |
|   ├── assets       <- Recursos estáticos, como imagens
|   ├── common       <- Código comum utilizado em várias partes do front-end.
|   ├── components   <- Componentes reutilizáveis.
|   ├── hooks        <- Hooks personalizados para a lógica compartilhada.
|   ├── layout       <- Arquivos relacionados ao layout da aplicação.
|   ├── model        <- Definições de modelos.
|   ├── pages        <- Componentes específicos de páginas.
|   ├── utils        <- Utilitários diversos.
|   ├── ...          <- Outros arquivos conforme necessário.
|   
├── .env.example     <- Exemplo de arquivo de ambiente que contém configurações sensíveis e não deve ser versionado. 
|
├── ...              <- Demais arquivos padrões.
```

### Pré-requisitos

- Certifique-se de ter o Node.js instalado em seu sistema.
- Utilizaremos o Yarn como gerenciador de pacotes. Caso não tenha instalado, [instale o Yarn](https://yarnpkg.com/getting-started/install).

### Passos

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/MessiasOli/teros-solution.git
   cd teros-solution
   ```

2. **Instale as dependências:**
   ```bash
   cd teros-app
   yarn install
   ```

3. **Configure o ambiente:**
   - Certifique-se de configurar corretamente o banco de dados, frontend e backend conforme a estrutura do projeto.
   - Configure as variáveis de ambiente necessárias.

4. **Execute o projeto:**
   - Inicie o backend:
     ```bash
     cd teros-api
     dotnet run
     ```
   - Inicie o frontend:
     ```bash
     cd teros-app
     yarn dev
     ```

5. **Acesse a aplicação:**
   - Abra o navegador e acesse a aplicação no endereço fornecido durante a inicialização do frontend.

6. **Atualização automática da lista:**
   - O módulo deve atualizar a lista de participantes automaticamente a cada 15 min padrão. Verifique se esse processo está funcionando corretamente.

### Entrega e Avaliação

- Publique o código-fonte do projeto em um repositório Git.
- Conceda as permissões de acesso ao repositório conforme acordado.
- Agende uma apresentação dos resultados do projeto após a entrega na data combinada.
