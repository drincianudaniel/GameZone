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

function App() {
  return (
    <div style={{ height: "100%" }}>
      <ToastContainer />
      <Routes>
        <Route exact path={"/"} element={<HomePage />} />
        <Route exact path={"/top"} element={<TopPage />} />
        <Route exact path={"/games"} element={<GamesPage />} />
        <Route exact path={"/admin-page"} element={<AdminPage />} />
          <Route path=":developers" element={<DevelopersTabbedPanel />} />
        <Route path={"/game/:id"} element={<GameDetailsPage />} />
        <Route path={"/notfound"} element={<Error404Page />} />
        <Route path={"*"} element={<Navigate to="/notfound" replace />} />
      </Routes>
    </div>
  );
}

export default App;
