type Update = {
  date: string;
  version: string;
  description: string[];
};

const Updates: Update[] = [
  {
    date: "18/02/2024",
    version: "0.0.6",
    description: [
      "- Criado mecanismo para favoritar os bancos do open banking.",
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
    date: "16/02/2024",
    version: "0.0.4",
    description: [
      "- Feito a apresentação e criação de banco de dados via migration no menu configuração.",
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
    version: "0.0.2",
    description: [
      "- Criando banco de dados através de migration.",
    ],
  },
  {
    date: "09/02/2024",
    version: "0.0.1",
    description: [
      "- Base da arquitetura backend pré finalizada.",
      "- Base da arquitetura frontend pré finalizada.",
    ],
  },
];

export default Updates;
