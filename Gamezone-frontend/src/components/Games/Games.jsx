import React, { useEffect, useState } from "react";
import GameService from "../../api/GameService";
import { useGames } from "../../ContextProvider/GamesContextProvider";
import GameCard from "../Cards/GameCard";
import AppPagination from "../Pagination/AppPagination";

function Games() {

const [games, setGames] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);

  useEffect(() => {
    GameService.getGamesPaginated(page).then((response) => {
      console.log(response);
      setGames(response.data.data);
      setNumberOfPages(response.data.totalPages);
    });
  }, [page]);

  return (
    <>
      {console.log(games)}
      <div className="games">
        {games.map((data, i) => {
          return (
            <React.Fragment key={data.id}>
              <GameCard data={data} setGames ={setGames} games={games}/>
            </React.Fragment>
          );
        })}
      </div>
      <AppPagination setPage={setPage} numberOfPages={numberOfPages} />
    </>
  );
}
export default Games;
