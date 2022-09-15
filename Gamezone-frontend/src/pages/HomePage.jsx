import Header from "../components/Header";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { Grid, Typography } from "@mui/material";
import Divider from "@mui/material/Divider";
import HomePageList from "../components/Lists/HomePageList";
import { useEffect, useState } from "react";
import axios from "axios";
import HomePageCarousel from "../components/Carousels/HomePageCarousel";

function HomePage() {
  const [actionGames, setActionGames] = useState();
  const [mostPopular, setMostPopular] = useState();
  const [releasedGames, setReleasedGames] = useState();
  const [addedGames, setAddedGames] = useState();
  const [topRatedGames, setTopRatedGames] = useState();
  useEffect(() => {
    getActionGames();
    getMostPopularGames();
    getReleasedGames();
    getAddedGames();
    getTopRatedGames();
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
        `${process.env.REACT_APP_SERVERIP}/games/number/5/sort-order/most-popular`
      )
      .then((res) => {
        setMostPopular(res.data);
      })
      .catch();
  };

  const getReleasedGames = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/number/10/sort-order/latest`
      )
      .then((res) => {
        setReleasedGames(res.data);
      })
      .catch();
  };

  const getAddedGames = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/number/10/sort-order/added-recently`
      )
      .then((res) => {
        setAddedGames(res.data);
      })
      .catch();
  };

  const getTopRatedGames = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/number/3/sort-order/top-rated-games`
      )
      .then((res) => {
        setTopRatedGames(res.data);
      })
      .catch();
  };

  return (
    <div>
      <Header />
      <Container maxWidth="xl">
        <Box sx={{ height: "100%", marginTop: 4 }}>
          <Grid container spacing={4}>
            <Grid item xs={12} md={8} lg={8} sx={{ padding: 2 }}>
              <Typography sx={{ fontSize: 20 }}>
                Latest games released
              </Typography>
              <Divider></Divider>
              <HomePageCarousel data={releasedGames} />
              <Divider></Divider>
              <Typography sx={{ fontSize: 20, marginTop: 3 }}>
                Latest games added
              </Typography>
              <Divider></Divider>
              <HomePageCarousel data={addedGames} />
              <Divider></Divider>
            </Grid>
            <Grid
              item
              xs={12}
              md={4}
              sx={{ borderLeft: 1, borderColor: "grey.500" }}
            >
              <Typography sx={{ fontSize: 20 }}>Top Action Games</Typography>
              <HomePageList data={actionGames} />
              <Divider></Divider>
              <Typography sx={{ fontSize: 20 }}>Most Popular Games</Typography>
              <HomePageList data={mostPopular} />
              <Divider></Divider>
              <Typography sx={{ fontSize: 20 }}>Top 3 Games</Typography>
              <HomePageList data={topRatedGames} />
            </Grid>
          </Grid>
        </Box>
      </Container>
    </div>
  );
}

export default HomePage;
