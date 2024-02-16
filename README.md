# Resumo e Instruções para Inicialização do Projeto

## Resumo

O desafio de desenvolvimento Open Finance propõe a criação de um módulo de aplicação integrado ao ecossistema de Open Finance, capaz de apresentar uma lista atualizada dos participantes do Open Banking. Essa lista deve incluir informações como nome, logo e URL de configuração/discovery do Authorization Server de cada participante. O objetivo é contribuir para a inovação, concorrência e melhoria na oferta de produtos no sistema financeiro, conforme proposto pelo Banco Central do Brasil.

## Instruções para Inicialização do Projeto

Siga as instruções abaixo para iniciar o projeto:

### Pré-requisitos

- Certifique-se de ter o Node.js instalado em seu sistema.
- Utilizaremos o Yarn como gerenciador de pacotes. Caso não tenha instalado, [instale o Yarn](https://yarnpkg.com/getting-started/install).

### Passos

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/MessiasOli/teros-solution.git
   cd open-finance-challenge
   ```

2. **Instale as dependências:**
   ```bash
   yarn install
   ```

3. **Configure o ambiente:**
   - Certifique-se de configurar corretamente o banco de dados, frontend e backend conforme a estrutura do projeto.
   - Configure as variáveis de ambiente necessárias.

4. **Execute o projeto:**
   - Inicie o backend:
     ```bash
     cd backend
     yarn start
     ```
   - Inicie o frontend:
     ```bash
     cd frontend
     yarn start
     ```

5. **Acesse a aplicação:**
   - Abra o navegador e acesse a aplicação no endereço fornecido durante a inicialização do frontend.

6. **Atualização automática da lista:**
   - O módulo deve atualizar a lista de participantes automaticamente a cada 1 hora. Verifique se esse processo está funcionando corretamente.

### Entrega e Avaliação

- Publique o código-fonte do projeto em um repositório Git.
- Conceda as permissões de acesso ao repositório conforme acordado.
- Agende uma apresentação dos resultados do projeto após a entrega na data combinada.
