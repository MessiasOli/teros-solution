import { FC, useState } from "react";
import InfoIcon from "../../../components/Icons/InfoIcon";
import ModalGeneric from "../../../components/ModalGeneric/ModalGeneric";

const ShowDetails: FC<{ msg: string, nomeFantasia:string, urlImg:string }> = ({ msg, nomeFantasia, urlImg }) => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  const openModal = () => {
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  return (
    <div className="p-2">
      <div className="flex justify-center">
        <span className="icon__bt" onClick={openModal} title="Clique aqui para saber mais...">
          {<InfoIcon heigth={20} width={20} custonClass="cursor-pointer" />}
        </span>
      </div>

      <ModalGeneric isOpen={isModalOpen} onClose={closeModal} size="lg">
        <div className="px-4 flex flex-col  text-black">
            <div className="flex w-full border-b-4 border-cblue text-xl font-semibold">
            <strong>{nomeFantasia}</strong>: Informações
            </div>
            <div className="flex w-full flex-row h-[15vh] bg-cblue rounded-b px-2 border-b-4 text-center overflow-y-auto">
              <div className="flex justify-center teros__anitmation w-2/6"><img className="p-1" src={urlImg} alt="Logo" /></div>
              <p className="my-auto w-4/6 pr-5 ">
                {msg}
              </p>
            </div>
          <div className="flex justify-end gap-2 my-2 ">
            <button
              form="grafico-form"
              className=""
              onClick={closeModal}
            >
              Ok
            </button>
          </div>
        </div>
      </ModalGeneric>
    </div>
  );
};

export default ShowDetails;
