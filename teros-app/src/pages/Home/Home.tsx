import automation from "../../assets/automacao.jpeg"
import "./Home.css"

function Home() {
  return <div className="home__container">
    <img src={automation} alt="Automaçaõ" />
    <h1>Sistema Open Finance - Teros</h1>
  </div>;
}

export default Home;
