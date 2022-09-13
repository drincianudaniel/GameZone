import Header from "../components/Header";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { Grid, Typography } from "@mui/material";
import SimpleSlider from "../components/Carousels/LatestGames";
import Divider from "@mui/material/Divider";
import HomePageList from "../components/Lists/HomePageList";
import { useEffect, useState } from "react";
import axios from "axios";


function HomePage() {
  const [actionGames, setActionGames] = useState([]);
  const [mostPopular, setMostPopular] = useState([]);

  useEffect(() => {
    getActionGames();
    getMostPopularGames();
  }, []);

  const getActionGames = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/number/3/sort-order/top-action`
      )
      .then((res) => {
        setActionGames(res.data);
      })
      .catch();
  };

  const getMostPopularGames = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/number/3/sort-order/most-popular`
      )
      .then((res) => {
        setMostPopular(res.data);
      })
      .catch();
  };

  return (
    <div>
      <Header />
      <Container maxWidth="xl">
        <Box sx={{ height: "100%", marginTop: 2 }}>
          <Grid container spacing={4}>
            <Grid item xs={8}>
              <Typography>Latest games released</Typography>
              <Divider></Divider>
              <SimpleSlider />
            </Grid>
            <Grid item xs={4}>
              Top Action Games
              <HomePageList data={actionGames} />
              Most Popular Games
              <HomePageList data={mostPopular} />
            </Grid>
          </Grid>
        </Box>
      </Container>
    </div>
  );
}

export default HomePage;
