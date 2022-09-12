import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import TopPage from "./pages/TopPage";
import GamesPage from "./pages/GamesPage";
import GameDetailsPage from "./pages/GameDetailsPage";
import AddPage from "./pages/AddPage";

function App() {
  return (
    <div style={{ height: "100%" }}>
      <Routes>
        <Route exact path={"/"} element={<HomePage />} />
        <Route exact path={"/top"} element={<TopPage />} />
        <Route exact path={"/games"} element={<GamesPage />} />
        <Route exact path={"/add"} element={<AddPage />} />
        <Route path={"/game/:id"} element={<GameDetailsPage />} />
      </Routes>
    </div>
  );
}

export default App;
