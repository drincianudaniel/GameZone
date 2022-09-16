import { createContext, useContext, useState, useEffect } from "react";
import GameService from "../api/GameService";

const GamesContext = createContext();

export function useGames() {
  return useContext(GamesContext);
}

export function GamesContextProvider({ children }) {
  const [games, setGames] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);

  const value = {
    games,
    page,
    numberOfPages,
    isLoading,
    setGames,
    setPage,
    setNumberOfPages,
    setIsLoading,
  };

  useEffect(() => {
    GameService.getGamesPaginated(page).then((response) => {
      console.log(response);
      setGames(response.data.data);
      setNumberOfPages(response.data.totalPages);
    });
  }, [page]);

  return (
    <GamesContext.Provider value={value}>{children}</GamesContext.Provider>
  );
}
