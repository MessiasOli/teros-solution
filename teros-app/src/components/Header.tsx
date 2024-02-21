import { Link } from "react-router-dom";
import { SetPageSelected } from "../utils/handlers";
import GetPackageVersion from "../pages/About/GetVersion";

function Header() {
  let nameProject = import.meta.env.VITE_APP_PROJECT_NAME;
  return (
    <div className="header__content bg-blue-500 text-white py-4">
      <div className="flex justify-between items-center px-6">
        <h1 className="name-project text-3xl font-semibold">
          <Link className="text-white" to="/home" onClick={() => SetPageSelected("item-1")}>{nameProject}</Link>
        </h1>
        <span className="text-sm cursor-pointer" onClick={() => SetPageSelected("item-4")}>
          <Link to="/about" className="text-white text-ms">
            Versão {GetPackageVersion()}
          </Link>
        </span>
      </div>
    </div>
  );
}

export default Header;
