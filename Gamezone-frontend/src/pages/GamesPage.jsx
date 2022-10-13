import Header from "../components/Header";
import { useEffect, useState, createContext, useContext } from "react";
import * as React from "react";
import GameCard from "../components/Cards/GameCard";
import "./css/GamesPage.css";
import { Box, IconButton, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import AppPagination from "../components/Pagination/AppPagination";
import GameService from "../api/GameService";
import AdminPanelSettingsIcon from "@mui/icons-material/AdminPanelSettings";
import { useUser } from "../hooks/useUser";
import GameFilter from "../components/Filters/GameFilter";
import SpinningLoading from "../components/LoadingComponents/SpinningLoading";

const GamesContext = createContext();

export function useGames() {
  return useContext(GamesContext);
}

function GamesPage() {
  const [games, setGames] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const { user, loadingUser } = useUser();
  const [isLoading, setIsLoading] = useState(false);
  //filter system
  const [selectedGenre, setSelectedGenre] = useState("");
  const [selectedDeveloper, setSelectedDeveloper] = useState("");
  const [selectedPlatform, setSelectedPlatform] = useState("");

  const handleChangeGenre = (event) => {
    setSelectedGenre(event.target.value);
  };

  const handleChangeDeveloper = (event) => {
    setSelectedDeveloper(event.target.value);
  };

  const handleChangePlatform = (event) => {
    setSelectedPlatform(event.target.value);
  };

  useEffect(() => {
    if (loadingUser) {
      return;
    }

    if (!user.IsLoggedIn) {
      getGames();
    }

    if (user.IsLoggedIn) {
      getGamesWhenLoggedIn();
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page, user, loadingUser]);

  const getGames = async () => {
    setIsLoading(true);
    GameService.getGamesPaginated(
      page,
      selectedGenre,
      selectedDeveloper,
      selectedPlatform
    ).then((response) => {
      setGames(response.data.data);
      setNumberOfPages(response.data.totalPages);
      setIsLoading(false);
    });
  };

  const getGamesWhenLoggedIn = async () => {
    setIsLoading(true);
    GameService.getGamesWithUserFavorites(
      user.UserName,
      page,
      selectedGenre,
      selectedDeveloper,
      selectedPlatform
    ).then((response) => {
      setGames(response.data.data);
      setNumberOfPages(response.data.totalPages);
      setIsLoading(false);
    });
  };

  return (
    <Box
      sx={{
        background:
          "linear-gradient(-45deg, #000000, #00177a, #227fd6, #bce9f7)",
        backgroundSize: "400% 400%",
        animation: "gradient 20s ease infinite",
        height: {
          lg: games.length < 5 ? "100vh" : "100%",
          md: "100%",
          sm: "100%",
          xs: games.length < 1 ? "100vh" : "100%",
        },
      }}
    >
      <Header />
      <Box className="gamesContent">
        <Box sx={{ textAlign: "right" }}>
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
        </Box>
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100%",
            mt: 2
          }}
        >
          <GameFilter
            handleChangePlatform={handleChangePlatform}
            handleChangeDeveloper={handleChangeDeveloper}
            handleChangeGenre={handleChangeGenre}
            genre={selectedGenre}
            developer={selectedDeveloper}
            platform={selectedPlatform}
            getGames={getGamesWhenLoggedIn}
            getGamesWhenLoggedOut={getGames}
          />
        </Box>
        {isLoading ? (
          <SpinningLoading />
        ) : (
          <>
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                width: "100%",
                mt: 3,
              }}
            >
              {games.length === 0 && (
                <Typography sx={{ fontSize: "40px", color: "white" }}>
                  No games found
                </Typography>
              )}
            </Box>
            <Box className="games">
              {games.map((data, i) => {
                return (
                  <React.Fragment key={data.id}>
                    <GameCard data={data} getGames={getGames} />
                  </React.Fragment>
                );
              })}
            </Box>
          </>
        )}
        <AppPagination setPage={setPage} numberOfPages={numberOfPages} />
      </Box>
    </Box>
  );
}

export default GamesPage;
