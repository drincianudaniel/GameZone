import { Navigate, Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import TopPage from "./pages/TopPage";
import GamesPage from "./pages/GamesPage";
import GameDetailsPage from "./pages/GameDetailsPage";
import AdminPage from "./pages/AdminPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Error404Page from "./pages/Error404Page";
import DevelopersTabbedPanel from "./components/TabbedPanels/DevelopersTabbedPanel";
import AddGameForm from "./components/Forms/AddGameForm";
import AddGenreForm from "./components/Forms/AddGenreForm";
import AddPlatformForm from "./components/Forms/AddPlatformForm";

function App() {
  return (
    <div style={{ height: "100%" }}>
      <ToastContainer />
      <Routes>
        <Route exact path={"/"} element={<HomePage />} />
        <Route exact path={"/top"} element={<TopPage />} />
        <Route exact path={"/games"} element={<GamesPage />} />
        <Route path={"/:admin-page/*"} element={<AdminPage />}/>
        <Route path={"/:game/:id/*"} element={<GameDetailsPage />} />
        <Route path={"/notfound"} element={<Error404Page />} />
        <Route path={"*"} element={<Navigate to="/notfound" replace />} />
        <Route path={"/admin-page"} element={<Navigate to="/admin-page/add-game" replace />}/>

      </Routes>
    </div>
  );
}

export default App;
