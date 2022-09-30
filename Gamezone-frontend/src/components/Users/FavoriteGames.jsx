import { Box, Grid } from "@mui/material";
import { useEffect } from "react";
import { useState } from "react";
import { useParams } from "react-router";
import UserService from "../../api/UserService";
import SimpleGameCard from "../Cards/SimpleGameCard";

export default function FavoriteGames(props) {
  const [favoriteGames, setFavoriteGames] = useState([]);
  const params = useParams();
  useEffect(() => {
    getFavoriteGames();
  }, [params]);

  const getFavoriteGames = () => {
    UserService.GetUsersFavorites(params.username).then((res) => {
      setFavoriteGames(res.data);
      console.log(favoriteGames);
    });
  };

  return (
    <Box sx={{ width: "100%", display: "flex", justifyContent: "center" }}>
      <Grid container spacing={4}>
        {favoriteGames.map((game) => {
          return (
            <Grid item md={4} lg={4} xs={12}>
              <SimpleGameCard data={game} />
            </Grid>
          );
        })}
      </Grid>
    </Box>
  );
}
