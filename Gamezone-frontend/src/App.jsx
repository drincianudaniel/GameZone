import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import TopPage from "./pages/TopPage";
import GamesPage from "./pages/GamesPage";
import GameDetailsPage from "./pages/GameDetailsPage";
import AddPage from "./pages/AddPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Error404Page from "./pages/Error404Page";

function App() {
  return (
    <div style={{ height: "100%" }}>
      <ToastContainer/>
      <Routes>
        <Route exact path={"/"} element={<HomePage />} />
        <Route exact path={"/top"} element={<TopPage />} />
        <Route exact path={"/games"} element={<GamesPage />} />
        <Route exact path={"/add"} element={<AddPage />} />
        <Route path={"/game/:id"} element={<GameDetailsPage />} />
        <Route exact path={"/404"} element={<Error404Page />} />

      </Routes>
    </div>
  );
}

export default App;
