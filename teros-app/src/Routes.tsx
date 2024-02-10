import { Routes, Route } from "react-router-dom";
import Layout from './layout/Layout';
import Home from './pages/Home/Home';
// import Configuration from './pages/Configuration/Configuration';
import TerosFinance from './pages/TerosFinance/TerosFinance';
import About from './pages/About/about';

function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} /> 
        <Route path="home" element={<Home />} />
        {/* <Route path="configuration" element={<Configuration />} /> */}
        <Route path="terosFinance" element={<TerosFinance />} />
        <Route path="about" element={<About />} />
        <Route path="*" element={<NoMatch />} />
      </Route>
    </Routes>
  )
}

export default AppRoutes

function NoMatch() {
  return (
    <div>
      <p>Ops dados não encontrados</p>
    </div>
  );
}
