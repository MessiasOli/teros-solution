import { useState } from "react";
import automation from "../../assets/automacao.jpeg"
import Carregando from "../../components/Carregando";
import ErroCarregar from "../../components/ErroCarregar";
import "./Home.css"
import { useQuery } from "react-query";
import DefaultResponse from "../../model/DefaultResponse";
import Message from "../../model/Message";

function Home() {
  const [message, setMessage] = useState<string>("")
  const queryLoading = useQuery<DefaultResponse<Message>>(
    "getLastAccess",
    {
      onSuccess: (resp) => setMessage(resp.data.value),
    }
  );

  if (queryLoading.isLoading) return <Carregando />;
  if (queryLoading.isError) return <ErroCarregar />;

  return <div className="home__container">
    <img src={automation} alt="Automaçaõ" />
    <h1>Sistema Open Finance - Teros</h1>
    <small>{message}</small>
  </div>;
}

export default Home;
