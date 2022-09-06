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
import Comment from "../components/Comment";
import Pagination from "@mui/material/Pagination";
import GamePagination from "../components/GamePagination";

function GameDetailsPage(props) {
  const [game, setGame] = useState([]);
  const [comments, setComments] = useState([]);
  const params = useParams();

  useEffect(() => {
    getGame();
    getComments();
  }, []);

  const getGame = async () => {
    const response = await axios
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

  const getData = async ({ from, to }) => {
    return await new Promise((resolve, reject) => {
      const data = comments.slice(from, to);
      resolve({
        count: comments.length,
        data: data,
      });
    });
  };

  return (
    <div>
      <Header />
      <div className="pageContent">
        {console.log(comments.Count)}
        <Box sx={{ flexGrow: 1, padding: 5 }} className="gameBox">
          <Grid container spacing={2}>
            <Grid item xs={12} sx={{ borderBottom: 1 }}>
              <Typography>{game.name}</Typography>
            </Grid>
            <Grid
              item
              xs={12}
              md={3}
              sx={{ borderRight: 1, borderColor: "grey.500" }}
            >
              <Grid item xs={12} md={12} justify="center">
                <img className="gameImg" src={game.imageSrc} />
                <Typography>Developers:</Typography>
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
                {Array.isArray(game.comments)
                  ? game.comments.map((comment) => {
                      return <Comment comment={comment} />;
                    })
                  : null}
                <GamePagination getData = {getData}></GamePagination>
              </Box>
            </Grid>
          </Grid>
        </Box>
      </div>
    </div>
  );
}

export default GameDetailsPage;
