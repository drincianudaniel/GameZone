import Header from "../components/Header";
import { useEffect, useState, createContext, useContext } from "react";
import * as React from "react";
import GameCard from "../components/Cards/GameCard";
import "./css/GamesPage.css";
import { Box, IconButton } from "@mui/material";
import { Link } from "react-router-dom";
import AppPagination from "../components/Pagination/AppPagination";
import GameService from "../api/GameService";
import AdminPanelSettingsIcon from "@mui/icons-material/AdminPanelSettings";
import { useUser } from "../hooks/useUser";
import UserService from "../api/UserService";

const GamesContext = createContext();

export function useGames() {
  return useContext(GamesContext);
}

function GamesPage() {

  const [games, setGames] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const [favoriteGames, setFavoriteGames] = useState([]);
  const { user, loadingUser } = useUser();

  useEffect(() => {

    if(loadingUser){
      return
    }
    getGames();

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page, user]);

  const getGames = async () => {

    if (user.IsLoggedIn === true) {
      await getFavoriteGames();
    }

    GameService.getGamesPaginated(page).then((response) => {
      setGames(response.data.data);
      setNumberOfPages(response.data.totalPages);
    });

  };

  const getFavoriteGames = async () => {
    UserService.GetUsersFavorites(user.Id).then((res) => {
      setFavoriteGames(res.data);
      console.log(favoriteGames);
    });
  };

  return (
    <div className="gamePageContent">
      <Header />
      <Box className="gamesContent">
        <div className="subheader">
          {user.IsAdmin && (
            <Link
              style={{ textDecoration: "none", color: "black" }}
              to={`/admin-page/add-game`}
            >
              {" "}
              <IconButton className="addButton" size="large">
                <AdminPanelSettingsIcon
                  fontSize="large"
                  sx={{ color: "white" }}
                />{" "}
              </IconButton>
            </Link>
          )}
        </div>
        <div className="nav"></div>
        <div className="games">
          {games.map((data, i) => {
            return (
              <React.Fragment key={data.id}>
                <GameCard
                  data={data}
                  getGames={getGames}
                  favoriteGames={favoriteGames}
                  getFavoriteGames={getFavoriteGames}
                />
              </React.Fragment>
            );
          })}
        </div>
        <AppPagination setPage={setPage} numberOfPages={numberOfPages} />
      </Box>
    </div>
  );
}

export default GamesPage;
