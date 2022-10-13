import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import TopPage from "./pages/TopPage";
import GamesPage from "./pages/GamesPage";
import GameDetailsPage from "./pages/GameDetailsPage";
import AdminPage from "./pages/AdminPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Error404Page from "./pages/Error404Page";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import { UserContextProvider } from "./hooks/useUser";
import ProfilePage from "./pages/ProfilePage";
import { ConfirmProvider } from "material-ui-confirm";

function App(props) {
  return (
    <div style={{ height: "100%" }}>
      <ConfirmProvider>
        <ToastContainer />
        <UserContextProvider>
          <BrowserRouter>
            <Routes>
              <Route exact path={"/"} element={<HomePage />} />
              <Route exact path={"/top"} element={<TopPage />} />
              <Route exact path={"/games"} element={<GamesPage />} />
              <Route path={"/:admin-page/*"} element={<AdminPage />} />
              <Route path={"/game/:id/*"} element={<GameDetailsPage />} />
              <Route path={"/notfound"} element={<Error404Page />} />
              <Route path={"*"} element={<Navigate to="/notfound" replace />} />
              <Route
                path={"/admin-page"}
                element={<Navigate to="/admin-page/add-game" replace />}
              />
              <Route path={"/login"} element={<LoginPage />} />
              <Route path={"/register"} element={<RegisterPage />} />
              <Route path={"/profile/:username/*"} element={<ProfilePage />} />
            </Routes>
          </BrowserRouter>
        </UserContextProvider>
      </ConfirmProvider>
    </div>
  );
}

export default App;
