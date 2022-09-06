import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import TopPage from "./pages/TopPage";
import GamesPage from "./pages/GamesPage";
import GameDetailsPage from "./pages/GameDetailsPage";
import AddGamesPage from "./pages/AddGamesPage";

function App() {
  return (
    <Routes>
      <Route exact path={"/"} element={<HomePage />} />
      <Route exact path={"/top"} element={<TopPage />} />
      <Route exact path={"/games"} element={<GamesPage />} />
      <Route exact path={"/add-games"} element={<AddGamesPage />} />
      <Route path={"/game/:id"} element={<GameDetailsPage />} />
    </Routes>
  );
}

export default App;
