import { useQuery } from "react-query";
import DefaultResponse from "../../model/DefaultResponse";
import { IConfiguration } from "../../model/Interface/IConfiguration";
import { useState } from "react";
import Carregando from "../../components/Carregando";
import ErroCarregar from "../../components/ErroCarregar";
import { DatabaseStatus } from "../../model/enums/DataBaseStatus";
import { showMessage } from "../../common/alertmessage.common";

function Configuration() {
  const [sendCreateDatabase, setSendCreateDatabase] = useState<boolean>(false);
  const [updateInfo, setUpdateInfo] = useState<boolean>(true);
  const [configuration, setConfiguration] = useState<IConfiguration>({
    lastSystemUpdate: "-",
    lastUpdate: "-",
    statusDatabase: DatabaseStatus.Disconnected,
  });

  const queryLoading = useQuery<DefaultResponse<IConfiguration>>(
    ["worker", "getconfiguration"],
    {
      enabled: updateInfo,
      onSuccess: (resp) => {
        setConfiguration(resp.data);
        setUpdateInfo(false);
      },
    }
  );

  const createQuery = useQuery<DefaultResponse<IConfiguration>>(
    ["createDatabase"],
    {
      enabled: sendCreateDatabase,
      onSuccess: (resp) => {
        setConfiguration(resp.data);
        setSendCreateDatabase(false)
        showMessage("Sucesso na criação do banco de dados!", )
      },
      onError: () => setSendCreateDatabase(false)
    }
  );

  if (queryLoading.isLoading || createQuery.isLoading) return <Carregando />;
  if (queryLoading.isError) return <ErroCarregar />;

  return (
    <div>
      <div>
        <div className="flex w-1/3 justify-between">
          <label>Último acesso ás listas open banking: </label>
          <div>{configuration.lastUpdate}</div>
        </div>
        <div className="flex w-1/3 justify-between">
          <label>Última atualização do sistema: </label>
          <div>{configuration.lastSystemUpdate}</div>
        </div>
        <div className="flex w-1/3 justify-between">
          <label>Status Banco de dados: </label>
          {configuration.statusDatabase == DatabaseStatus.Disconnected ? (
            <div className="text-red-500 font-semibold">Desconectado</div>
          ) : (
            <div className="text-green-500 font-semibold">Conectado</div>
          )}
        </div>
      </div>
      <button onClick={() => window.location.reload()} className="mt-3">Atualizar</button>
      {configuration.statusDatabase == DatabaseStatus.Disconnected ? (
        <button className="mt-3 ml-3" onClick={() => setSendCreateDatabase(true)}>
          <span className="flex">
            Criar Banco de Dados
          </span>
        </button>
      ) : null}
    </div>
  );
}

export default Configuration;
