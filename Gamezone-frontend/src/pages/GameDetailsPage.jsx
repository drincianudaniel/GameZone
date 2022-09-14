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
import moment from "moment";
import DetailsTabbedPanel from "../components/TabbedPanels/DetailsTabbedPannel";
import { Container } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import useMediaQuery from "@mui/material/useMediaQuery";

function GameDetailsPage() {
  const [game, setGame] = useState();
  const params = useParams();
  const theme = useTheme();

  useEffect(() => {
    getGame();
  }, [params.id]);

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
      <Container
        maxWidth="lg"
        disableGutters={useMediaQuery(theme.breakpoints.only("xs"))}
      >
        <Box sx={{ flexGrow: 1, padding: 5 }}>
          {!game && <>Loading...</>}
          {game && (
            <Grid container spacing={2}>
              <Grid item xs={12} sm={12} sx={{ borderBottom: 1 }}>
                <Typography variant="h4">{game.name}</Typography>
              </Grid>
              <Grid
                item
                xs={12}
                md={3}
                sx={{ borderRight: { lg: 1 }, borderColor: "grey.500" }}
              >
                <Grid item xs={12} md={12} lg={12} justify="center">
                  <img
                    alt={game.name}
                    className="gameImg"
                    src={game.imageSrc}
                  />
                  <Typography>
                    Release date:{" "}
                    {moment(game.releaseDate).format("YYYY-MM-DD")}
                  </Typography>
                  <Typography>Developers:</Typography>
                  {game.developers && game.developers.length > 0 ?
                    game.developers.map((developer) => (
                      <Chip key={developer.id} label={developer.name} />
                    )): <Typography>No Developers</Typography>}
                  <Typography>Genres:</Typography>
                  {game.genres && game.genres.length > 0 ?
                    game.genres.map((genre) => (
                      <Chip key={genre.id} label={genre.name} />
                    )): <Typography>No Genres</Typography>}
                  <Typography>Platforms:</Typography>
                  {game.platforms && game.platforms.length > 0 ?
                    game.platforms.map((platform) => (
                      <Chip key={platform.id} label={platform.name} />
                    )): <Typography>No Platforms</Typography>}
                </Grid>
              </Grid>
              <Grid item xs={12} sm={12} md={12} lg={9} justify="center">
                <Box sx={{ flexGrow: 1 }} className="detailsBox">
                  <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={12}>
                      <Rating
                        name="read-only"
                        value={game.totalRating / 2}
                        readOnly
                        precision={0.1}
                      />
                    </Grid>
                    <Grid item xs={12} md={12} sx={{ borderBottom: 1 }}>
                      <Typography className="details">
                        <Typography
                          sx={{ fontWeight: "bold", marginBottom: 0.2 }}
                        >
                          Synopsis:
                        </Typography>
                        {game.gameDetails}
                      </Typography>
                    </Grid>
                  </Grid>
                  <DetailsTabbedPanel getGame={getGame}/>
                </Box>
              </Grid>
            </Grid>
          )}
        </Box>
      </Container>
    </div>
  );
}

export default GameDetailsPage;
