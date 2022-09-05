import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Header from "../components/Header";
import Rating from "@mui/material/Rating";
import Typography from "@mui/material/Typography";
import "./css/GameDetailsPage.css";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Chip from "@mui/material/Chip";
function GameDetailsPage(props) {
  const [game, setGame] = useState([]);

  const params = useParams();

  useEffect(() => {
    getGame();
    console.log(game)
  }, []);

  const getGame = async () => {
    await axios
      .get(`${process.env.REACT_APP_SERVERIP}/Games/${params.id}`)
      .then((res) => {
        setGame(res.data);
      });
  };
  return (
    <div>
      <Header />
      <div className="pageContent">
        <Box sx={{ flexGrow: 1, padding: 5 }} className="gameBox">
          <Grid container spacing={2}>
            <Grid item xs={12} sx={{borderBottom: 1}}>
              <Typography>{game.name}</Typography>
            </Grid>
            <Grid item xs={12} md={3}>
              <img className="gameImg" src={game.imageSrc} />
            </Grid>
            <Grid item xs={9} md={9} justify="center">
              <Box sx={{ flexGrow: 1 }} className="detailsBox">
                  <Grid container spacing={2}>
                    <Grid item xs={12} md={12}>
                      <Rating name="read-only" value={game.totalRating / 2} readOnly />
                    </Grid>
                    <Grid item xs={12} md={12}>
                      <Typography>{game.gameDetails}</Typography>
                    </Grid>
                  </Grid>
              </Box>
            </Grid>
            
            <Grid item xs={12} md={4} justify="center"  >
              <Typography >Developers:</Typography>
              {Array.isArray(game.developers)
                ? game.developers.map((developer) => {
                    return <Chip label={developer.name} />;
                  })
                : null}
              <Typography>Genres:</Typography>
              {Array.isArray(game.genres)
                ? game.genres.map((genre) => {
                    return <Chip label={genre.name} />;
                  })
                : null}
              <Typography>Platforms:</Typography>
              {Array.isArray(game.platforms)
                ? game.platforms.map((platform) => {
                    return <Chip label={platform.name} />;
                  })
                : null}
            </Grid>
          </Grid>
        </Box>
      </div>
    </div>
  );
}

export default GameDetailsPage;
