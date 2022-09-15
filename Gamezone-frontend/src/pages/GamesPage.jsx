import Header from "../components/Header";
import { useEffect, useState } from "react";
import axios from "axios";
import * as React from "react";
import GameCard from "../components/Cards/GameCard";
import "./css/GamesPage.css";
import AddBoxIcon from "@mui/icons-material/AddBox";
import { IconButton } from "@mui/material";
import { Link } from "react-router-dom";
import AppPagination from "../components/Pagination/AppPagination";

function GamesPage() {
  const [games, setGames] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);

  useEffect(() => {
    getGames();

    // const {data} = useQuery("/games", "GET");
    // if (isLodoing){
    //   // display loading
    // }
    // else
    // setGames(data)

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  //const {data, isLoading, errors} = useQuery('/Games');

  // is Loading  = true
  // finally flase
  // return {data: data, isLoading, error ""}

  const getGames = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/page/${page}/page-size/${8}`
      )
      .then((res) => {
        setGames(res.data.data);
        setNumberOfPages(res.data.totalPages);
      })
      .catch();
  };

  return (
    <div className="gamePageContent">
      <Header />
      {console.log(page)}
      <div className="subheader">
        <IconButton className="addButton" size="large">
          <Link style={{ textDecoration: "none", color: "black" }} to={`/add`}>
            {" "}
            <AddBoxIcon fontSize="large" sx={{ color: "white" }} />{" "}
          </Link>
        </IconButton>
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
      <AppPagination
        setPage={setPage}
        numberOfPages={numberOfPages}
      />
    </div>
  );
}

export default GamesPage;
