import GetPackageVersion from "./GetVersion";
import Updates from "./Updates";

function About() {
  let version = GetPackageVersion();
  let nameProject = import.meta.env.VITE_APP_PROJECT_NAME;
  return (
    <div className="flex">
      <div className="w-1/3 p-4">
        <h1 className="text-3xl font-bold">Sobre o {nameProject}</h1>
        <div className="teros__anitmation">
          <div className="mt-4 text-lg">
            <strong>Objetivo: </strong>
            <p>Este sistema foi desenvolvido para atender aos requisitos do desafio
            Teros.</p>
            
            <br />
            <strong>Construção:</strong>
            <div className="pl-5">
              <ul className="list-disc">
                <li>
                  <strong>Frontend - </strong> Construído com React, TypeScript
                  e o framework tailwindcss, visando criar um site dinâmico e
                  agradável visualmente para atender ao objetivo central do
                  desafio.
                </li>
                <li>
                  <strong>Backend - </strong> API Desenvolvido em .NET 7 utilizando
                  padrões de projeto como Mediator, Command, Handler, Singleton e Entity
                  Framework para banco de dados.
                </li>
              </ul>
            </div>
            <br />
            <strong>Arquitetura Limpa:</strong>
            <div className="pl-5">
              <ul className="list-disc">
                <li>Interface Externa Web</li>
                <li>Controladores, Services e Banco de Dados PostgreSQL</li>
                <li>Domain</li>
                <li>Entidades</li>
              </ul>
            </div>
            <br />
            <strong>Testes:</strong>
            <div className="pl-5">
              <ul className="list-disc">
                <li>
                  <strong>Frontend:</strong> Cypress
                </li>
                <li>
                  <strong>Backend:</strong> Xunit
                </li>
              </ul>
            </div>
          </div>
          <br />
          <strong>Segurança: </strong> Foram implementados cuidados com
            variáveis de ambiente e senhas.
        </div>
      </div>

      <div className="w-2/3 p-4 border-l">
        <h1 className="text-3xl font-bold">Atualizações</h1>
        <div className="about__container teros__anitmation overflow-y-auto">
        <p className="mt-4">
            <strong>Versão atual:</strong> v {version}
          </p>
          <p>
            <strong>Desenvolvedor:</strong> Messias Oliveira
          </p>
          <p>
            <strong>E-mail:</strong> dev.messias.2019@gmail.com
          </p>
          <p>
            <strong>Desenvolvido em:</strong> 02/2024
          </p>
          <ul className="mt-2 space-y-2">
            {Updates.map((update, index) => (
              <li key={index + "-list"} className="px-2 py-4 rounded">
                <strong>
                  {update.date} - v{update.version}
                </strong>
                {update.description.map((desc, key) => (
                  <p key={key}>{desc}&nbsp;</p>
                ))}
              </li>
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
}

export default About;
