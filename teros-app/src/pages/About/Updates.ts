type Update = {
  date: string;
  version: string;
  description: string[];
};

const Updates: Update[] = [
  {
    date: "09/02/2024",
    version: "0.0.1",
    description: [
      "- Base da arquitetura backend pré finalizada.",
      "- Base da arquitetura frontend pré finalizada.",
    ],
  },
  {
    date: "16/02/2024",
    version: "0.0.2",
    description: [
      "- Criando banco de dados através de migration.",
    ],
  },
  {
    date: "16/02/2024",
    version: "0.0.3",
    description: [
      "- Criado serviço de monitoramento periódico do open banking.",
    ],
  },
  {
    date: "16/02/2024",
    version: "0.0.4",
    description: [
      "- Feito a apresentação e criação de banco de dados via migration no menu configuração.",
    ],
  },
  {
    date: "16/02/2024",
    version: "0.0.5",
    description: [
      "- Feito a carga das informações em tabela e ajustado informações sobre sistema.",
    ],
  },
  {
    date: "18/02/2024",
    version: "0.0.6",
    description: [
      "- Criado mecanismo para favoritar os bancos do open banking.",
    ],
  },
  {
    date: "18/02/2024",
    version: "0.0.7",
    description: [
      "- Criado mecanismo para ajustar o tempo de atualização do serviço de monitoramento openbanking.",
      "- Criado Teste em forma TDD para garantir que o tempo mostrado na tela home seja sempre correta",
      "- Criado histórico para dar boas vindas."
    ],
  },
  {
    date: "20/02/2024",
    version: "1.0.0",
    description: [
      "- Criado testes frontend E2E com cypress.",
      "- Corrigido documentação do projeto",
      "- Adicionado arquivos de criação de banco de dados."
    ],
  },
];

export default Updates;
