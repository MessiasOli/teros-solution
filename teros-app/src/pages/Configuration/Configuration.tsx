import { useQuery } from "react-query";
import DefaultResponse from "../../model/DefaultResponse";
import { IConfiguration } from "../../model/Interface/IConfiguration";
import { useState } from "react";
import Carregando from "../../components/Carregando";
import ErroCarregar from "../../components/ErroCarregar";
import { DatabaseStatus } from "../../model/enums/DataBaseStatus";
import { showMessage } from "../../common/alertmessage.common";
import { usePostMutationToast } from "../../hooks/useMutationToast";

function Configuration() {
  const [sendCreateDatabase, setSendCreateDatabase] = useState<boolean>(false);
  const [updateInfo, setUpdateInfo] = useState<boolean>(true);
  const [updateCycle, setUpdateCycle] = useState<boolean>(false);
  const [updateCycleBackup, setUpdateCycleBackup] = useState<number>(15);
  const [configuration, setConfiguration] = useState<IConfiguration>({
    lastSystemUpdate: "-",
    lastUpdate: "-",
    statusDatabase: DatabaseStatus.Disconnected,
    updateCycle: 15
  });
  const MIN_VALUE:number = 15
  const MAX_VALUE:number = 60
  const routerGetConfiguration:string[] = ["worker", "getconfiguration"];

  const queryLoading = useQuery<DefaultResponse<IConfiguration>>(
    routerGetConfiguration,
    {
      enabled: updateInfo,
      onSuccess: (resp) => {
        setConfiguration(resp.data);
        setUpdateInfo(false);
        setUpdateCycleBackup(resp.data.updateCycle)
        setUpdateCycle(false)
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

  const salvarConfiguracoes = usePostMutationToast<IConfiguration>({
    route: "SaveConfiguration",
    invalidateQueryKey: routerGetConfiguration.join("/"),
    stateMessages: {
      success: "Configurações salvas com sucesso!",
      pending: "Salvando novas configurações...",
      error: "Falha ao salvar as configurações",
    },
    onSuccessCb: () => setUpdateCycle(false)
  });

  const handlerChange = (valueStr:string) => {
    if(!valueStr) return;
    const value = parseInt(valueStr)
    setConfiguration({...configuration, updateCycle: value})
    setUpdateCycle(updateCycleBackup != value && value >= MIN_VALUE && value <= MAX_VALUE)
  }

  const handlerSalvarConfiguracoes = () => {
    salvarConfiguracoes(configuration)
  }

  if (queryLoading.isLoading || createQuery.isLoading) return <Carregando />;
  if (queryLoading.isError) return <ErroCarregar />;

  return (
    <div>
      <p className="text-3xl font-bold mb-2">Configurações do sistema</p>
      <div className="teros__anitmation">
        <div>
          <div className="flex w-3/5 justify-between">
            <label>Último acesso ás listas open banking: </label>
            <div>{configuration.lastUpdate}</div>
          </div>
          <div className="flex w-3/5 justify-between">
            <label>Última atualização do sistema: </label>
            <div>{configuration.lastSystemUpdate}</div>
          </div>
          <div className="flex w-3/5 justify-between">
            <label>Status Banco de dados: </label>
            {configuration.statusDatabase == DatabaseStatus.Disconnected ? (
              <div className="text-red-500 font-semibold">Desconectado</div>
            ) : (
              <div className="text-green-500 font-semibold">Conectado</div>
            )}
          </div>
          <div className="flex w-3/5 justify-between">
            <label>Tempo de refresh dos dados open banking [15-60] (Minutos): </label>
            <input id="change-refresh-time" className="px-2" type="number" min={MIN_VALUE} max={MAX_VALUE} value={configuration.updateCycle} onChange={event => handlerChange(event?.target?.value)} />
          </div>
        </div>
        <button onClick={() => window.location.reload()} className="mt-3">Atualizar</button>
        {configuration.statusDatabase == DatabaseStatus.Disconnected ? (
          <button className="mt-3 ml-3" onClick={() => setSendCreateDatabase(true)}>
              Criar Banco de Dados
          </button>
        ) : null}
        {updateCycle ? (
          <button id="btn-salvar" className="mt-3 ml-3" onClick={() => handlerSalvarConfiguracoes()}>
              Salvar
          </button>
        ) : null}
      </div>
    </div>
  );
}

export default Configuration;
