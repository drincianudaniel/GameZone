import Header from "../components/Header";
import { useEffect, useState } from "react";
import axios from "axios";
import * as React from "react";
import GameCard from "../components/GameCard";
import AppPagination from "../components/AppPagination";
import "./css/GamesPage.css";
import AddBoxIcon from "@mui/icons-material/AddBox";
import { IconButton } from "@mui/material";
import { Link } from "react-router-dom";

function GamesPage() {
  const [games, setGames] = useState([]);

  useEffect(() => {
    getGames();
  }, []);

  //const {data, isLoading, errors} = useQuery('/Games');

  // is Loading  = true
  // finally flase
  // return {data: data, isLoading, error ""}

  const getGames = async () => {
    await axios
      .get(`${process.env.REACT_APP_SERVERIP}/Games`)
      .then((res) => setGames(res.data))
      .catch()
      .finally();
  };

  return (
    <div className="gamePageContent">
      <Header />
      <div className="subheader">
      <IconButton className="addButton" size="large">
        <Link
          style={{ textDecoration: "none", color: "black" }}
          to={`/add-games`}
        >
          {" "}
          <AddBoxIcon fontSize="large" sx={{ color: "white" }} />{" "}
        </Link>
      </IconButton> 
      </div>
      <div className="games">
        {games.map((data, i) => {
          return (
            <div key={data.id}>
              <GameCard data={data} i={i} getGames={getGames} />
            </div>
          );
        })}
      </div>
      <AppPagination></AppPagination>
    </div>
  );
}

export default GamesPage;
