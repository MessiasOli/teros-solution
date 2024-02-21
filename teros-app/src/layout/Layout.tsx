
import { Outlet } from "react-router-dom"
import Header from "../components/Header";
import Menu from "../components/Menu";

function Layout() {
    return (
      <div className='app__content'>
        <Header />
        <Menu/>
        <div className="p-2 view__area">
          <Outlet />
        </div>
      </div>
    );
  }

  export default Layout;