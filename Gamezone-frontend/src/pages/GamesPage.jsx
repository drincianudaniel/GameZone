import Header from "../components/Header";
import { useEffect, useState, createContext, useContext } from "react";
import axios from "axios";
import * as React from "react";
import GameCard from "../components/Cards/GameCard";
import "./css/GamesPage.css";
import AddBoxIcon from "@mui/icons-material/AddBox";
import { IconButton } from "@mui/material";
import { Link, useParams } from "react-router-dom";
import AppPagination from "../components/Pagination/AppPagination";
import GameService from "../api/GameService";

const GamesContext = createContext();

export function useGames() {
  return useContext(GamesContext);
}

function GamesPage() {
  const [games, setGames] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  useEffect(() => {
    getGames();

    // GameService.getGamesPaginated(page).then((response) =>{
    //   console.log(response);
    //   setGames(response.data.data);
    //   setNumberOfPages(response.data.totalPages);
    // });

    //console.log(data.data);
    // if (isLodoing){
    //   // display loading
    // }
    // else
    //setGames(data);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  //const {data, isLoading, errors} = useQuery('/Games');

  // is Loading  = true
  // finally flase
  // return {data: data, isLoading, error ""}

  const getGames = () => {
    GameService.getGamesPaginated(page).then((response) => {
      console.log(response);
      setGames(response.data.data);
      setNumberOfPages(response.data.totalPages);
    });
  };

  return (
    <div className="gamePageContent">
      <Header />
      <div className="subheader">
        <Link style={{ textDecoration: "none", color: "black" }} to={`/admin-page/add-game`}>
          {" "}
          <IconButton className="addButton" size="large">
            <AddBoxIcon fontSize="large" sx={{ color: "white" }} />{" "}
          </IconButton>
        </Link>
      </div>
      <div className="nav"></div>
      <div className="games">
        {games.map((data, i) => {
          return (
            <React.Fragment key={data.id}>
              <GameCard data={data} getGames={getGames} />
            </React.Fragment>
          );
        })}
      </div>
      <AppPagination setPage={setPage} numberOfPages={numberOfPages} />
    </div>
  );
}

export default GamesPage;
