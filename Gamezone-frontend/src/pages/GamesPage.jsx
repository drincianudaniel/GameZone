import Header from "../components/Header";
import { useEffect, useState } from "react";
import axios from "axios";
import * as React from "react";
import GameCard from "../components/GameCard";
import AppPagination from "../components/AppPagination";
import "./css/GamesPage.css";
import { Link } from "react-router-dom";

function GamesPage() {
  const [games, setGames] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:7092/api/Games")
      .then((res) => setGames(res.data));
  }, []);

  return (
    <div className="gamePageContent">
      <Header />
      {console.log(games)}
      <div className="games">
        {games.map((data, i) => {
          return (
            <div key={data.id}>
              <Link style={{ textDecoration: "none" }} to={`/game/${data.id}`}>
                <GameCard data={data} i={i} />
              </Link>
            </div>
          );
        })}
      </div>
      <AppPagination></AppPagination>
    </div>
  );
}

export default GamesPage;
