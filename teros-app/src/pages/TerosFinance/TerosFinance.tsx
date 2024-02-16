import { useState } from "react";
import { useQuery } from "react-query";
import Message from "../../model/Message";
import DefaultResponse from "../../model/DefaultResponse";
import Carregando from "../../components/Carregando";
import ErroCarregar from "../../components/ErroCarregar";

function TerosFinance() {
  const [statusServer, setStatusServer] = useState("Offiline");

  const queryLoading = useQuery<DefaultResponse<Message>>([""], {
    onSuccess: (resp) => {
      setStatusServer(resp.data.value);
    },
  });

  if (queryLoading.isLoading) return <Carregando />;
  if (queryLoading.isError) return <ErroCarregar />;

  return (
    <div>
      <h1>Teros Finance</h1>
      <label>Status API: {statusServer}</label>
    </div>
  );
}

export default TerosFinance;
