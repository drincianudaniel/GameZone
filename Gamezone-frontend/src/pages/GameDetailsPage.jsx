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
import Comments from "../components/Comments";

function GameDetailsPage() {
  const [game, setGame] = useState([]);
  const [comments, setComments] = useState([]);
  const params = useParams();

  useEffect(() => {
    const getGame = async () => {
      await axios
        .get(`${process.env.REACT_APP_SERVERIP}/Games/${params.id}`)
        .then((res) => {
          setGame(res.data);
        });
    };

    const getComments = async () => {
      const response = await axios.get(
        `${process.env.REACT_APP_SERVERIP}/Games/${params.id}`
      );
      setComments(response.data.comments);
    };

    getGame();
    getComments();
  }, [params.id]);

  return (
    <div>
      <Header />
      <div className="pageContent">
        <Box sx={{ flexGrow: 1, padding: 5 }} className="gameBox">
          <Grid container spacing={2}>
            <Grid item xs={12} sx={{ borderBottom: 1 }}>
              <Typography variant="h4">{game.name}</Typography>
            </Grid>
            <Grid
              item
              xs={12}
              md={3}
              sx={{ borderRight: 1, borderColor: "grey.500" }}
            >
              <Grid item xs={12} md={12} justify="center">
                <img alt={game.name} className="gameImg" src={game.imageSrc} />
                <Typography>Developers:</Typography>
                {Array.isArray(game.developers)
                  ? game.developers.map((developer) => {
                      return <Chip key={developer.id} label={developer.name} />;
                    })
                  : null}
                <Typography>Genres:</Typography>
                {Array.isArray(game.genres)
                  ? game.genres.map((genre) => {
                      return <Chip key={genre.id} label={genre.name} />;
                    })
                  : null}
                <Typography>Platforms:</Typography>
                {Array.isArray(game.platforms)
                  ? game.platforms.map((platform) => {
                      return <Chip key={platform.id} label={platform.name} />;
                    })
                  : null}
              </Grid>
            </Grid>
            <Grid item xs={9} md={9} justify="center">
              <Box sx={{ flexGrow: 1 }} className="detailsBox">
                <Grid container spacing={2}>
                  <Grid item xs={12} md={12}>
                    <Rating
                      name="read-only"
                      value={game.totalRating / 2}
                      readOnly
                    />
                  </Grid>
                  <Grid item xs={12} md={12} sx={{ borderBottom: 1 }}>
                    <Typography className="details">
                      {game.gameDetails}
                    </Typography>
                  </Grid>
                </Grid>
                <Typography>Comments</Typography>
                <Comments />
              </Box>
            </Grid>
          </Grid>
        </Box>
      </div>
    </div>
  );
}

export default GameDetailsPage;
