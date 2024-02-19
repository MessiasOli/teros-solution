import { FC, useState } from "react";
import ModalGeneric from "../../../components/ModalGeneric/ModalGeneric";
import ConfigurationIcon from "../../../components/Icons/ConfigurationIcon";
import { IOpenBanking } from "../../../model/Interface/IOpenBanking";
import { usePostMutationToast } from "../../../hooks/useMutationToast";
import IOpenBankingFavorite from "../../../model/Interface/IOpenBankingFavorite";

const ShowConfiguration: FC<{ openBanking: IOpenBanking }> = ({
  openBanking,
}) => {

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isChecked, setIsChecked] = useState(openBanking.favorito);

  const saveFavorite = usePostMutationToast<IOpenBankingFavorite>({
    route: "FavoriteOpenBanking",
    invalidateQueryKey: ["GetAllOpenBanking"],
    stateMessages: {
      success: `${openBanking.nomeFantasia} favoritado com sucesso!`,
      pending: `Favoritado ${openBanking.nomeFantasia}...`,
      error: `Falha ao favoritar ${openBanking.nomeFantasia}`,
    },
  });

  const openModal = () => {
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  const handleCheckboxChange = () => {
    setIsChecked(!isChecked);
    saveFavorite({ favorite: !isChecked, customerFriendlyName: openBanking.nomeFantasia })
  };

  return (
    <div className="p-2">
      <div className="flex justify-center">
        <span
          className="icon__bt"
          title="Informações de conexão e configuração"
          onClick={openModal}
        >
          <a>
            {
              <ConfigurationIcon
                heigth={20}
                width={20}
                custonClass="cursor-pointer"
              />
            }
          </a>
        </span>
      </div>
      <ModalGeneric isOpen={isModalOpen} onClose={closeModal} size="lg">
        <div className="px-4 flex flex-col  text-black">
          <div className="flex w-full border-b-4 border-cblue text-xl font-semibold">
            <strong>{openBanking.nomeFantasia}</strong>: Configurações
          </div>
          <div className="flex w-full flex-row h-[25vh] bg-cblue rounded-b px-2 border-b-4 overflow-y-auto">
            <div className="flex justify-center teros__anitmation w-1/6">
              <img className="p-1" src={openBanking.logo} alt="Logo" />
            </div>
            <div className="pl-3 mt-2 w-5/6">
              <p>
                <strong>Url de configuração/discovery: </strong>
              </p>
              {openBanking.authorisationServersList?.map((a, i) => {
                return (
                  <div className="pl-1 mt-1" key={i}>
                    <strong>Opção {i + 1}: </strong>
                    <p>{a.openIDDiscoveryDocument ?? "-"}</p>
                  </div>
                );
              })}
              <div className="mt-3">
                <input
                  name="checkbox_favoritar"
                  type="checkbox"
                  checked={isChecked}
                  onChange={handleCheckboxChange}
                  className="cursor-pointer"
                />
                <label htmlFor="checkbox_favoritar"  className="font-bold ml-2">
                  Favoritar banco
                </label>
              </div>
            </div>
          </div>
          <div className="flex justify-end gap-2 my-2 ">
            <button form="grafico-form" className="" onClick={closeModal}>
              Ok
            </button>
          </div>
        </div>
      </ModalGeneric>
    </div>
  );
};

export default ShowConfiguration;
