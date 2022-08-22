import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Header from "../components/Header";
import Rating from "@mui/material/Rating";
import Typography from "@mui/material/Typography";
import "./css/GameDetailsPage.css";

function GameDetailsPage(props) {
  const [game, setGame] = useState({});

  const params = useParams();

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_SERVERIP}/Games/${params.id}`)
      .then((res) => setGame(res.data));
  }, []);

  return (
    <div>
      {console.log(process.env.REACT_APP_SERVERIP)}
      {console.log(game)}
      <Header />
      <div>
        <img className="gameImg" src={game.imageSrc} />
      </div>
      {game.name}{" "}
      <Rating name="read-only" value={game.totalRating / 2} readOnly />
    </div>
  );
}

export default GameDetailsPage;
