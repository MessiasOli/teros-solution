import GetPackageVersion from "./GetVersion";
import Updates from "./Updates";

function About() {
  let version = GetPackageVersion();
  let nameProject = import.meta.env.VITE_APP_PROJECT_NAME;
  return (
    <div className="flex">
      {/* Seção de informações à esquerda */}
      <div className="w-1/3 p-4">
        <h1 className="text-3xl font-bold">Sobre o {nameProject}</h1>
        <div className="teros__anitmation">
          <p className="mt-4 text-lg">
            Este sistema foi desenvolvido com o objetivo de atender os requisitos do desafio Teros.
            Ele foi construído com React, TypeScript.
          </p>
          <p className="mt-4">
            <strong>Versão atual:</strong> v {version}
          </p>
          <p>
            <strong>Desenvolvedor:</strong> Messias Oliveira
          </p>
          <p>
            <strong>E-mail:</strong> dev.messias.2019@gmail.com
          </p>
        </div>
      </div>

      <div className="w-2/3 p-4 border-l">
        <h1 className="text-3xl font-bold">Atualizações</h1>
        <div className="about__container overflow-x-auto teros__anitmation">
          <ul className="mt-4 space-y-2">
            {Updates.map((update, index) => (
              <li key={index} className="px-2 py-4 rounded">
                <strong>{update.date} - v{update.version}</strong>
                {update.description.map(desc => (<p>{desc}&nbsp;</p>))}
              </li>
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
}

export default About;