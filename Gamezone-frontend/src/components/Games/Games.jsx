import React from "react";
import { useGames } from "../../ContextProvider/GamesContextProvider";
import GameCard from "../Cards/GameCard";
import AppPagination from "../Pagination/AppPagination";

function Games() {

  const { games, setPage, setGames, numberOfPages } = useGames();

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
